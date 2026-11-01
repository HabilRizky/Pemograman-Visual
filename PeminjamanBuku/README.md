# Tugas 2 (Pertemuan 7) — Aplikasi Peminjaman Buku Perpustakaan

Aplikasi **Peminjaman Buku Perpustakaan** berbasis **Windows Forms (VB.NET)** yang dirancang untuk mengelola transaksi peminjaman buku dengan validasi pola format khusus, pencegahan peminjaman ganda (*duplicate borrow prevention*), perhitungan otomatis tanggal jatuh tempo pengembalian, serta ekspor rekapitulasi transaksi ke dalam format file **CSV**.

---

## 📁 Lokasi Proyek & File Utama
- **Folder Proyek**: `PeminjamanBuku/`
- **File Solusi**: `PeminjamanBuku.sln` / `PeminjamanBuku.slnx`
- **File Proyek**: `PeminjamanBuku.vbproj`
- **Form Antarmuka Utama**: [`FrmPeminjaman.vb`](file:///v:/Pemograman-Visual/PeminjamanBuku/FrmPeminjaman.vb)
- **Modul Validasi Pola Buku**: [`ModValidasiBuku.vb`](file:///v:/Pemograman-Visual/PeminjamanBuku/ModValidasiBuku.vb)
- **Modul Validasi Helper Umum**: [`ModValidasi.vb`](file:///v:/Pemograman-Visual/PeminjamanBuku/ModValidasi.vb)
- **Titik Masuk Program**: [`Program.vb`](file:///v:/Pemograman-Visual/PeminjamanBuku/Program.vb)

---

## 🧰 Kontrol Visual yang Digunakan

| Nama Kontrol | Tipe Kontrol | Fungsi / Peranan |
| :--- | :--- | :--- |
| `txtKodeBuku` | `TextBox` | Menerima input kode buku unik (format `BK` + 4 digit angka, maks 6 karakter) |
| `txtJudul` | `TextBox` | Menerima input judul buku (wajib diisi) |
| `cboKategori` | `ComboBox` | Pilihan kategori koleksi buku |
| `txtNamaPeminjam` | `TextBox` | Menerima nama peminjam (minimal 3 karakter) |
| `txtLamaPinjam` | `TextBox` | Menerima durasi pinjam dalam hari (rentang 1 s.d. 14 hari) |
| `btnPinjam` | `Button` | Memvalidasi seluruh masukan dan mencatat transaksi peminjaman |
| `btnEkspor` | `Button` | Mengekspor seluruh riwayat peminjaman ke file CSV |
| `btnBersihkan` | `Button` | Mereset seluruh kolom isian formulir dan membersihkan indikator error |
| `lstPeminjaman` | `ListBox` | Menampilkan daftar transaksi peminjaman buku yang sedang aktif |
| `errPinjam` | `ErrorProvider` | Menampilkan peringatan visual error di samping kontrol yang tidak valid |
| `lblStatus` | `Label` | Menampilkan informasi status proses dan total transaksi peminjaman aktif |

---

## 💻 Seluruh Kode Program (Full Code) & Penjelasan Lengkap

### 1. Modul Validasi Pola Kode Buku ([`ModValidasiBuku.vb`](file:///v:/Pemograman-Visual/PeminjamanBuku/ModValidasiBuku.vb))

```vb
Option Strict On

' Modul validasi khusus untuk format kode buku (tantangan tambahan Pertemuan 7)
Public Module ModValidasiBuku

    ' Memeriksa apakah teks berformat "BK" diikuti tepat 4 digit angka.
    ' Huruf besar/kecil pada "bk" sama-sama diterima.
    Public Function KodeBukuValid(kode As String) As Boolean
        Dim kodeUpper As String = kode.Trim().ToUpper()
        If kodeUpper.Length <> 6 Then Return False
        If Not kodeUpper.StartsWith("BK") Then Return False
        Return SemuaDigit(kodeUpper.Substring(2), 4)
    End Function

End Module
```
- **Penjelasan**: Memeriksa bahwa kode buku dinormalisasi ke huruf kapital (`ToUpper()`), harus memiliki panjang tepat 6 karakter, diawali dengan string prefix `"BK"`, dan 4 karakter sisanya (`Substring(2)`) seluruhnya adalah digit angka (`0-9`).

---

### 2. Modul Validasi Helper Umum ([`ModValidasi.vb`](file:///v:/Pemograman-Visual/PeminjamanBuku/ModValidasi.vb))

```vb
Option Strict On

Imports System.Globalization

' Kumpulan fungsi validasi yang bisa dipakai ulang oleh form mana pun
Public Module ModValidasi

    ' True jika teks kosong atau hanya berisi spasi
    Public Function Kosong(teks As String) As Boolean
        Return teks.Trim() = ""
    End Function

    ' True jika panjang teks tepat sesuai dan semua karakternya digit 0-9
    Public Function SemuaDigit(teks As String, panjang As Integer) As Boolean
        If teks.Length <> panjang Then Return False
        For Each karakter As Char In teks
            If karakter < "0"c OrElse karakter > "9"c Then Return False
        Next
        Return True
    End Function

    ' Mengubah teks desimal menjadi Decimal. Koma dan titik sama-sama diterima.
    Public Function CobaDesimal(teks As String, ByRef hasil As Decimal) As Boolean
        Dim teksTitik As String = teks.Trim().Replace(",", ".")
        Return Decimal.TryParse(teksTitik, NumberStyles.AllowDecimalPoint,
                                CultureInfo.InvariantCulture, hasil)
    End Function

End Module
```
- **Penjelasan**: Menyediakan fungsi umum untuk pemeriksaan string kosong (`Kosong`), validasi digit berpanjang tetap (`SemuaDigit`), dan parsing desimal universal (`CobaDesimal`).

---

### 3. Form Peminjaman Buku ([`FrmPeminjaman.vb`](file:///v:/Pemograman-Visual/PeminjamanBuku/FrmPeminjaman.vb))

```vb
Option Strict On

Imports System.ComponentModel
Imports System.IO

Public Class FrmPeminjaman
    ' Kode buku yang sedang dipinjam, untuk mencegah peminjaman ganda
    Private ReadOnly daftarKodeDipinjam As New List(Of String)

    ' File CSV disimpan di folder Documents milik pengguna
    Private ReadOnly lokasiEkspor As String =
        Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
                     "peminjaman.csv")

    ' Memeriksa semua isian sekaligus. Mengembalikan True jika semuanya valid.
    Private Function ValidasiInput() As Boolean
        errPinjam.Clear()
        Dim valid As Boolean = True
        Dim kodeNormalisasi As String = txtKodeBuku.Text.Trim().ToUpper()

        If Not KodeBukuValid(kodeNormalisasi) Then
            errPinjam.SetError(txtKodeBuku, "Kode harus format BK diikuti 4 digit, contoh BK0012.")
            valid = False
        ElseIf daftarKodeDipinjam.Contains(kodeNormalisasi) Then
            errPinjam.SetError(txtKodeBuku, "Buku ini sedang dipinjam.")
            valid = False
        End If

        If Kosong(txtJudul.Text) Then
            errPinjam.SetError(txtJudul, "Judul wajib diisi.")
            valid = False
        End If

        If cboKategori.SelectedIndex = -1 Then
            errPinjam.SetError(cboKategori, "Pilih kategori terlebih dahulu.")
            valid = False
        End If

        Dim namaTrim As String = txtNamaPeminjam.Text.Trim()
        If namaTrim.Length < 3 Then
            errPinjam.SetError(txtNamaPeminjam, "Nama peminjam minimal 3 karakter.")
            valid = False
        End If

        Dim lama As Integer
        If Not Integer.TryParse(txtLamaPinjam.Text, lama) OrElse lama < 1 OrElse lama > 14 Then
            errPinjam.SetError(txtLamaPinjam, "Lama pinjam harus angka 1 sampai 14 hari.")
            valid = False
        End If

        Return valid
    End Function

    ' Mencatat satu peminjaman baru jika semua isian valid.
    Private Sub btnPinjam_Click(sender As Object, e As EventArgs) Handles btnPinjam.Click
        If Not ValidasiInput() Then Return

        Dim kode As String = txtKodeBuku.Text.Trim().ToUpper()
        Dim lama As Integer
        Integer.TryParse(txtLamaPinjam.Text, lama)
        Dim tanggalKembali As String = Date.Today.AddDays(lama).ToString("dd/MM/yyyy")

        lstPeminjaman.Items.Add(kode & " | " & txtJudul.Text.Trim() & " | " & cboKategori.Text & " | " &
                                txtNamaPeminjam.Text.Trim() & " | " & lama.ToString() & " hari | kembali " & tanggalKembali)
        daftarKodeDipinjam.Add(kode)
        lblStatus.Text = "Jumlah peminjaman: " & lstPeminjaman.Items.Count.ToString()
        BersihkanForm()
    End Sub

    ' Validasi format kode buku langsung saat fokus meninggalkan txtKodeBuku.
    Private Sub txtKodeBuku_Validating(sender As Object, e As CancelEventArgs) Handles txtKodeBuku.Validating
        If txtKodeBuku.Text = "" Then Return   ' kosong dicek nanti saat Pinjam
        Dim kodeNormalisasi As String = txtKodeBuku.Text.Trim().ToUpper()
        If KodeBukuValid(kodeNormalisasi) Then
            errPinjam.SetError(txtKodeBuku, "")
        Else
            errPinjam.SetError(txtKodeBuku, "Kode harus format BK diikuti 4 digit, contoh BK0012.")
            ' e.Cancel = True sengaja tidak dipakai, agar fokus tetap bisa berpindah.
        End If
    End Sub

    ' Mengosongkan semua isian dan menghapus semua ikon ErrorProvider.
    Private Sub BersihkanForm()
        txtKodeBuku.Clear()
        txtJudul.Clear()
        cboKategori.SelectedIndex = -1
        txtNamaPeminjam.Clear()
        txtLamaPinjam.Clear()
        errPinjam.Clear()
        txtKodeBuku.Focus()
    End Sub

    Private Sub btnBersihkan_Click(sender As Object, e As EventArgs) Handles btnBersihkan.Click
        BersihkanForm()
    End Sub

    ' Menulis seluruh daftar peminjaman ke file CSV di folder Documents.
    Private Sub btnEkspor_Click(sender As Object, e As EventArgs) Handles btnEkspor.Click
        If lstPeminjaman.Items.Count = 0 Then
            MessageBox.Show("Belum ada data peminjaman untuk diekspor.", "Ekspor Dibatalkan",
                            MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        Dim penulis As StreamWriter = Nothing
        Try
            penulis = New StreamWriter(lokasiEkspor)
            penulis.WriteLine("KodeBuku;Judul;Kategori;NamaPeminjam;LamaPinjam;TanggalKembali")
            For Each baris As Object In lstPeminjaman.Items
                penulis.WriteLine(baris.ToString().Replace(" | ", ";"))
            Next
            lblStatus.Text = "Data diekspor ke " & lokasiEkspor
        Catch ex As IOException
            MessageBox.Show("File sedang dipakai program lain atau tidak bisa ditulis." & vbCrLf &
                            ex.Message, "Ekspor Gagal", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Catch ex As UnauthorizedAccessException
            MessageBox.Show("Tidak memiliki izin untuk menulis file di lokasi ini." & vbCrLf &
                            ex.Message, "Ekspor Gagal", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Finally
            If penulis IsNot Nothing Then penulis.Close()   ' file selalu ditutup
        End Try
    End Sub
End Class
```

#### Penjelasan Rinci Alur Kerja `FrmPeminjaman.vb`:
1. **Pencegahan Peminjaman Ganda**:
   - Buku yang sedang dipinjam dicatat kodenya ke `daftarKodeDipinjam As New List(Of String)`.
   - Ketika ada permohonan pinjam baru, `daftarKodeDipinjam.Contains(kodeNormalisasi)` dicek. Jika buku masih dalam status dipinjam, transaksi ditolak.
2. **Validasi On-The-Fly (`txtKodeBuku_Validating`)**:
   - Event `Validating` memverifikasi format kode seketika saat kursor berpindah dari `txtKodeBuku`. Jika tidak valid, `errPinjam.SetError` langsung memunculkan tanda seru merah.
3. **Perhitungan Tanggal Jatuh Tempo**:
   - `Date.Today.AddDays(lama).ToString("dd/MM/yyyy")` menambahkan durasi hari pinjam ke tanggal hari ini secara otomatis dan memformatnya rapi ke format hari/bulan/tahun.
4. **Ekspor File CSV (`btnEkspor_Click`)**:
   - Menuliskan header kolom dan mengganti pemisah visual `" | "` menjadi semikolon `";"`.
   - Menggunakan blok `Try...Catch...Finally` untuk menjamin file stream ditutup (`penulis.Close()`) meskipun terjadi error sistem.

---

### 4. Titik Masuk Program ([`Program.vb`](file:///v:/Pemograman-Visual/PeminjamanBuku/Program.vb))

```vb
Imports System
Imports System.Windows.Forms

Module Program
    <STAThread>
    Sub Main()
        Application.EnableVisualStyles()
        Application.SetCompatibleTextRenderingDefault(False)
        Application.Run(New FrmPeminjaman())
    End Sub
End Module
```
- **Penjelasan**: Prosedur startup utama untuk meluncurkan form `FrmPeminjaman`.

---

## 🚀 Cara Menjalankan Proyek
1. Buka file solusi `PeminjamanBuku.sln` / `PeminjamanBuku.slnx` menggunakan **Microsoft Visual Studio 2022**.
2. Tekan tombol **F5** untuk menjalankan aplikasi.
3. Masukkan Kode Buku (contoh: `BK0025`), Judul Buku, Kategori, Nama Peminjam (minimal 3 huruf), dan Lama Pinjam (1 - 14 hari).
4. Klik tombol **Pinjam**. Transaksi akan tercatat di `lstPeminjaman` dengan tanggal jatuh tempo pengembalian.
5. Klik tombol **Ekspor** untuk mengekspor rekapitulasi data peminjaman ke `peminjaman.csv` di folder Dokumen pengguna.
