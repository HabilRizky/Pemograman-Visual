# Tugas 2 (Pertemuan 7) — Aplikasi Peminjaman Buku Perpustakaan

Aplikasi **Peminjaman Buku Perpustakaan** berbasis Windows Forms (VB.NET) yang dirancang untuk mengelola transaksi peminjaman buku dengan validasi pola format khusus, pencegahan peminjaman ganda, perhitungan otomatis tanggal jatuh tempo pengembalian, serta ekspor rekap transaksi ke dalam format file **CSV**.

---

## 📁 Lokasi Proyek & File Utama
- **Folder Proyek**: `PeminjamanBuku/`
- **File Solusi**: `PeminjamanBuku.sln` / `PeminjamanBuku.slnx`
- **Form Utama**: [`FrmPeminjaman.vb`](file:///v:/Pemograman-Visual/PeminjamanBuku/FrmPeminjaman.vb)
- **Modul Validasi Pola Buku**: [`ModValidasiBuku.vb`](file:///v:/Pemograman-Visual/PeminjamanBuku/ModValidasiBuku.vb)
- **Modul Validasi Umum**: [`ModValidasi.vb`](file:///v:/Pemograman-Visual/PeminjamanBuku/ModValidasi.vb)

---

## 🧰 Kontrol Visual yang Digunakan

| Nama Kontrol | Tipe Kontrol | Fungsi / Peranan |
| :--- | :--- | :--- |
| `txtKodeBuku` | `TextBox` | Menerima input kode buku unik (format `BK` + 4 digit angka) |
| `txtJudul` | `TextBox` | Menerima input judul buku (wajib diisi) |
| `cboKategori` | `ComboBox` | Pilihan kategori koleksi buku |
| `txtNamaPeminjam` | `TextBox` | Menerima nama peminjam (minimal 3 karakter) |
| `txtLamaPinjam` | `TextBox` | Menerima durasi pinjam dalam hari (1 s.d. 14 hari) |
| `btnPinjam` | `Button` | Memvalidasi seluruh masukan dan mencatat transaksi peminjaman |
| `btnEkspor` | `Button` | Mengekspor seluruh riwayat peminjaman ke file CSV |
| `btnBersihkan` | `Button` | Mereset seluruh kolom isian formulir dan membersihkan ikon error |
| `lstPeminjaman` | `ListBox` | Menampilkan daftar transaksi peminjaman buku yang aktif |
| `errPinjam` | `ErrorProvider` | Menampilkan peringatan visual error di samping kontrol yang tidak valid |
| `lblStatus` | `Label` | Menampilkan total jumlah transaksi peminjaman aktif |

---

## 💻 Fitur & Penjelasan Logika Kode

### 1. Validasi Pola Kode Buku (`ModValidasiBuku.vb`)
Format kode buku diwajibkan diawali dengan prefix `BK` (case-insensitive) diikuti oleh 4 digit angka (total tepat 6 karakter, contoh: `BK0012`):
```vb
Public Module ModValidasiBuku
    Public Function KodeBukuValid(kode As String) As Boolean
        Dim kodeUpper As String = kode.Trim().ToUpper()
        If kodeUpper.Length <> 6 Then Return False
        If Not kodeUpper.StartsWith("BK") Then Return False
        Return SemuaDigit(kodeUpper.Substring(2), 4)
    End Function
End Module
```

### 2. Pencegahan Peminjaman Ganda
Aplikasi mencatat setiap buku yang sedang dipinjam ke dalam koleksi `daftarKodeDipinjam As New List(Of String)`. Jika kode buku yang sama diinputkan sebelum dikembalikan, sistem akan menolak dan memberi peringatan:
```vb
If Not KodeBukuValid(kodeNormalisasi) Then
    errPinjam.SetError(txtKodeBuku, "Kode harus format BK diikuti 4 digit, contoh BK0012.")
    valid = False
ElseIf daftarKodeDipinjam.Contains(kodeNormalisasi) Then
    errPinjam.SetError(txtKodeBuku, "Buku ini sedang dipinjam.")
    valid = False
End If
```

### 3. Validasi Real-Time saat Kehilangan Fokus (`Validating` Event)
Pengecekan format kode buku langsung dilakukan saat kursor meninggalkan kotak teks `txtKodeBuku`:
```vb
Private Sub txtKodeBuku_Validating(sender As Object, e As CancelEventArgs) Handles txtKodeBuku.Validating
    If txtKodeBuku.Text = "" Then Return
    Dim kodeNormalisasi As String = txtKodeBuku.Text.Trim().ToUpper()
    If KodeBukuValid(kodeNormalisasi) Then
        errPinjam.SetError(txtKodeBuku, "")
    Else
        errPinjam.SetError(txtKodeBuku, "Kode harus format BK diikuti 4 digit, contoh BK0012.")
    End If
End Sub
```

### 4. Perhitungan Otomatis Tanggal Pengembalian
Berdasarkan durasi hari yang dimasukkan pada `txtLamaPinjam` (antara 1 hingga 14 hari), tanggal pengembalian dihitung secara presisi dari tanggal transaksi hari ini (`Date.Today`):
```vb
Dim lama As Integer
Integer.TryParse(txtLamaPinjam.Text, lama)
Dim tanggalKembali As String = Date.Today.AddDays(lama).ToString("dd/MM/yyyy")

lstPeminjaman.Items.Add(kode & " | " & txtJudul.Text.Trim() & " | " & cboKategori.Text & " | " &
                        txtNamaPeminjam.Text.Trim() & " | " & lama.ToString() & " hari | kembali " & tanggalKembali)
daftarKodeDipinjam.Add(kode)
```

### 5. Ekspor Rekap Transaksi ke CSV (`StreamWriter`)
Semua transaksi di dalam `ListBox` dapat diekspor menjadi dokumen CSV (`peminjaman.csv`) di direktori dokumen pengguna, lengkap dengan baris *Header*, pemisah semikolon (`;`), serta penanganan eksepsi `IOException` dan `UnauthorizedAccessException`:
```vb
Dim penulis As StreamWriter = Nothing
Try
    penulis = New StreamWriter(lokasiEkspor)
    penulis.WriteLine("KodeBuku;Judul;Kategori;NamaPeminjam;LamaPinjam;TanggalKembali")
    For Each baris As Object In lstPeminjaman.Items
        penulis.WriteLine(baris.ToString().Replace(" | ", ";"))
    Next
    lblStatus.Text = "Data diekspor ke " & lokasiEkspor
Catch ex As IOException
    MessageBox.Show("File sedang dipakai program lain atau tidak bisa ditulis." & vbCrLf & ex.Message, "Ekspor Gagal")
Catch ex As UnauthorizedAccessException
    MessageBox.Show("Tidak memiliki izin untuk menulis file di lokasi ini." & vbCrLf & ex.Message, "Ekspor Gagal")
Finally
    If penulis IsNot Nothing Then penulis.Close()
End Try
```

---

## 🚀 Cara Menjalankan Proyek
1. Buka file solusi `PeminjamanBuku.sln` / `PeminjamanBuku.slnx` menggunakan **Microsoft Visual Studio 2022**.
2. Jalankan aplikasi dengan menekan tombol **F5**.
3. Masukkan Kode Buku (contoh: `BK0101`), Judul, pilih Kategori, Nama Peminjam, dan Lama Pinjam (1 - 14).
4. Klik **Pinjam** untuk mencatat transaksi dan melihat tanggal jatuh tempo pengembalian.
5. Klik **Ekspor** untuk menyimpan rekap seluruh transaksi ke file `peminjaman.csv`.
