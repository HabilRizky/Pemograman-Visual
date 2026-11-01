# Pertemuan 4 — Perulangan (Looping) & Deret Angka

Proyek ini berfokus pada pengimplementasian struktur **Perulangan (`For...Next`)** dalam Visual Basic .NET serta pemanfaatan komponen **`ListBox`** untuk menampung dan menampilkan deret data numerik yang dihasilkan secara dinamis berdasarkan batas awal dan batas akhir yang ditentukan pengguna.

---

## 📁 Lokasi Proyek & File Utama
- **Folder Proyek**: `Pertemuan4-Perulangan/`
- **File Solusi**: `Pertemuan4-Perulangan.slnx`
- **File Proyek**: `Pertemuan4-Perulangan.vbproj`
- **File Kode Utama**: [`FormPerulangan.vb`](file:///v:/Pemograman-Visual/Pertemuan4-Perulangan/Pertemuan4-Perulangan/FormPerulangan.vb)

---

## 🧰 Kontrol Visual yang Digunakan

| Nama Kontrol | Tipe Kontrol | Fungsi / Peranan |
| :--- | :--- | :--- |
| `txtNilaiAwal` | `TextBox` | Menerima masukan batas nilai awal perulangan |
| `txtNilaiAkhir` | `TextBox` | Menerima masukan batas nilai akhir perulangan |
| `btnInput` | `Button` | Memproses logika perulangan dan mencetak deret ke ListBox |
| `lstHasil` | `ListBox` | Wadah visual untuk menampilkan seluruh deret angka hasil iterasi |

---

## 💻 Seluruh Kode Program (Full Code) & Penjelasan Lengkap

### Full Code [`FormPerulangan.vb`](file:///v:/Pemograman-Visual/Pertemuan4-Perulangan/Pertemuan4-Perulangan/FormPerulangan.vb)

Berikut adalah seluruh kode program dari file `FormPerulangan.vb`:

```vb
Public Class FormPerulangan
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

    Private Sub btnInput_Click(sender As Object, e As EventArgs) Handles btnInput.Click
        Dim nilaiAwal As Integer
        Dim nilaiAkhir As Integer

        If Not Integer.TryParse(txtNilaiAwal.Text, nilaiAwal) Then
            MessageBox.Show("Masukkan Dalam Bentuk Angka.")
            txtNilaiAwal.Focus()
            Return
        End If

        If Not Integer.TryParse(txtNilaiAkhir.Text, nilaiAkhir) Then
            MessageBox.Show("Masukkan Dalam Bentuk Angka.")
            txtNilaiAkhir.Focus()
            Return
        End If

        lstHasil.Items.Clear()

        For i As Integer = nilaiAwal To nilaiAkhir
            lstHasil.Items.Add(i)
        Next
    End Sub
End Class
```

---

## 🔍 Penjelasan Rinci Setiap Prosedur & Logika Kode

### 1. Pembatasan Input Karakter Numerik (`txtNilaiAwal_KeyPress` & `txtNilaiAkhir_KeyPress`)
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
- Kedua event handler ini memastikan bahwa pengguna **hanya dapat mengetikkan karakter digit angka (`0-9`)** dan tombol kontrol editing (`Backspace`).
- **`AndAlso`**: Operator evaluasi hubungan sirkuit pendek (*short-circuiting logic*). Jika `Not Char.IsControl(e.KeyChar)` bernilai `False` (berarti tombol tersebut adalah tombol kontrol seperti backspace), maka pemeriksaan kedua dilewati.
- Karakter huruf atau simbol apa pun akan ditolak sebelum sempat tampil di layar melalui `e.Handled = True`.

---

### 2. Logika Iterasi & Menampilkan Deret Angka ke ListBox (`btnInput_Click`)
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

    ' Mengosongkan ListBox sebelum proses cetak baru
    lstHasil.Items.Clear()

    ' Struktur Perulangan For...Next
    For i As Integer = nilaiAwal To nilaiAkhir
        lstHasil.Items.Add(i)
    Next
End Sub
```

#### Rincian Logika:
1. **Konversi String ke Numerik Aman (`Integer.TryParse`)**:
   - Memeriksa apakah teks pada `txtNilaiAwal` dan `txtNilaiAkhir` dapat diubah menjadi integer.
   - Jika pengguna membiarkan kotak teks kosong atau menyalin teks tidak valid, dialog peringatan akan muncul dan eksekusi dihentikan via `Return`.
2. **Pembersihan Kontainer ListBox (`lstHasil.Items.Clear()`)**:
   - Mengosongkan seluruh item yang telah ada di dalam `ListBox` dari iterasi sebelumnya sehingga hasil pencetakan tidak bertumpuk.
3. **Struktur Perulangan `For i As Integer = nilaiAwal To nilaiAkhir`**:
   - Mendeklarasikan variabel counter lokal `i` bertipe `Integer`.
   - Mengiterasi secara otomatis dari nilai `nilaiAwal` hingga mencapai `nilaiAkhir` dengan pertambahan default $+1$ pada setiap putaran (*step 1*).
4. **Pencetakan Item (`lstHasil.Items.Add(i)`)**:
   - Memasukkan nilai counter `i` pada setiap putaran perulangan sebagai satu baris item baru ke dalam koleksi kontrol `ListBox`.

---

## 🚀 Cara Menjalankan Proyek
1. Buka file solusi `Pertemuan4-Perulangan.slnx` menggunakan **Microsoft Visual Studio 2022**.
2. Tekan tombol **F5** untuk memulai eksekusi.
3. Masukkan Nilai Awal (misal: `1`) dan Nilai Akhir (misal: `20`).
4. Klik tombol **Input**. Deret bilangan dari 1 hingga 20 akan otomatis tercetak berurutan di dalam kontrol `ListBox`.
