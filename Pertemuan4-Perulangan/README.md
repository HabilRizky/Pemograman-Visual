# Pertemuan 4 — Perulangan (Looping) & Deret Angka

Proyek ini berfokus pada pengimplementasian struktur **Perulangan (`For...Next`)** dalam Visual Basic .NET serta penggunaan komponen **`ListBox`** untuk menampung deret data angka yang dihasilkan secara dinamis.

---

## 📁 Lokasi Proyek & File Utama
- **Folder Proyek**: `Pertemuan4-Perulangan/`
- **File Solusi**: `Pertemuan4-Perulangan.slnx`
- **File Kode Utama**: [`FormPerulangan.vb`](file:///v:/Pemograman-Visual/Pertemuan4-Perulangan/Pertemuan4-Perulangan/FormPerulangan.vb)

---

## 🧰 Kontrol Visual yang Digunakan

| Nama Kontrol | Tipe Kontrol | Fungsi / Peranan |
| :--- | :--- | :--- |
| `txtNilaiAwal` | `TextBox` | Menerima batas nilai awal perulangan |
| `txtNilaiAkhir` | `TextBox` | Menerima batas nilai akhir perulangan |
| `btnInput` | `Button` | Memproses pencetakan deret angka ke dalam ListBox |
| `lstHasil` | `ListBox` | Menampilkan seluruh deret angka hasil iterasi |

---

## 💻 Penjelasan Kode (`FormPerulangan.vb`)

Berikut adalah pembahasan detail mengenai logika kode di file [`FormPerulangan.vb`](file:///v:/Pemograman-Visual/Pertemuan4-Perulangan/Pertemuan4-Perulangan/FormPerulangan.vb):

### 1. Pembatasan Input Karakter (`txtNilaiAwal_KeyPress` & `txtNilaiAkhir_KeyPress`)
```vb
Private Sub txtNilaiAwal_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtNilaiAwal.KeyPress
    If Not Char.IsControl(e.KeyChar) AndAlso Not Char.IsDigit(e.KeyChar) Then
        e.Handled = True
    End If
End Sub

Private Sub txtNilaiAkhir_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtNilaiAkhir.KeyPress
    If Not Char.IsControl(e.KeyChar) AndAlso Not Char.IsDigit(e.KeyChar) Then
        e.Handled = True
    End If
End Sub
```
- Kedua handler event ini memastikan bahwa pengguna **hanya dapat memasukkan angka positif** dan tombol navigasi/hapus (`Backspace`). Karakter huruf atau simbol akan langsung ditolak oleh event `KeyPress`.

---

### 2. Logika Iterasi & Menampilkan Ke ListBox (`btnInput_Click`)
```vb
Private Sub btnInput_Click(sender As Object, e As EventArgs) Handles btnInput.Click
    Dim nilaiAwal As Integer
    Dim nilaiAkhir As Integer

    ' Validasi Input Nilai Awal
    If Not Integer.TryParse(txtNilaiAwal.Text, nilaiAwal) Then
        MessageBox.Show("Masukkan Dalam Bentuk Angka.")
        txtNilaiAwal.Focus()
        Return
    End If

    ' Validasi Input Nilai Akhir
    If Not Integer.TryParse(txtNilaiAkhir.Text, nilaiAkhir) Then
        MessageBox.Show("Masukkan Dalam Bentuk Angka.")
        txtNilaiAkhir.Focus()
        Return
    End If

    ' Membersihkan item ListBox dari proses sebelumnya
    lstHasil.Items.Clear()

    ' Struktur Perulangan For...Next
    For i As Integer = nilaiAwal To nilaiAkhir
        lstHasil.Items.Add(i)
    Next
End Sub
```

#### Rincian Logika:
1. **`Integer.TryParse`**: Mengonversi teks input dari `txtNilaiAwal` dan `txtNilaiAkhir` menjadi variabel numerik `nilaiAwal` dan `nilaiAkhir`.
2. **`lstHasil.Items.Clear()`**: Mengosongkan tampilan deret sebelumnya dari `ListBox` sebelum deret baru dicetak.
3. **`For i As Integer = nilaiAwal To nilaiAkhir`**:
   - Memulai variabel penghitung `i` dari nilai `nilaiAwal`.
   - Mengiterasi secara berurutan (*step 1*) hingga mencapai `nilaiAkhir`.
4. **`lstHasil.Items.Add(i)`**: Menambahkan nilai `i` pada setiap putaran perulangan sebagai satu item baru di dalam kontrol `ListBox`.

---

## 🚀 Cara Menjalankan Proyek
1. Buka `Pertemuan4-Perulangan.slnx` di Visual Studio 2022.
2. Jalankan aplikasi (F5).
3. Masukkan Nilai Awal (misal `1`) dan Nilai Akhir (misal `10`), lalu klik tombol **Input**. Deret angka 1 sampai 10 akan ditampilkan secara berurutan pada `ListBox`.
