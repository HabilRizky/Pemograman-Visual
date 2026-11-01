# Pertemuan 5 — Modul, Fungsi, dan Array (1D & 2D)

Proyek ini merupakan aplikasi **Windows Forms (VB.NET)** yang mendemonstrasikan pemisahan arsitektur logika program menggunakan **`Module`**, pembuatan fungsi modular (**`Function`** vs **`Sub`**), serta manipulasi struktur data **Array Satu Dimensi** dan **Array Dua Dimensi (Matriks)**.

---

## 📁 Lokasi Proyek & File Utama
- **Folder Proyek**: `Pertemuan5-Modul-Fungi-Array/`
- **File Solusi**: `Pertemuan5-Modul-Fungi-Array.slnx`
- **File Proyek**: `Pertemuan5-Modul-Fungi-Array.vbproj`
- **File Form Utama**: [`FrmArray.vb`](file:///v:/Pemograman-Visual/Pertemuan5-Modul-Fungi-Array/FrmArray.vb)
- **File Modul Helper**: [`ModArray.vb`](file:///v:/Pemograman-Visual/Pertemuan5-Modul-Fungi-Array/ModArray.vb)

---

## 🧰 Kontrol Visual yang Digunakan

| Nama Kontrol | Tipe Kontrol | Fungsi / Peranan |
| :--- | :--- | :--- |
| `txtPanjang` | `TextBox` | Menerima masukan nilai panjang (validasi digit) |
| `txtLebar` | `TextBox` | Menerima masukan nilai lebar (validasi digit) |
| `btnTampil` | `Button` | Menjalankan proses pembacaan array dan menampilkan pesan dialog |
| `lstNilai` | `ListBox` | Disiapkan untuk wadah visual deret elemen array |

---

## 💻 Seluruh Kode Program (Full Code) & Penjelasan Lengkap

### 1. Full Code Modul Helper ([`ModArray.vb`](file:///v:/Pemograman-Visual/Pertemuan5-Modul-Fungi-Array/ModArray.vb))

Berikut adalah seluruh isi kode program dari file `ModArray.vb`:

```vb
Module ModArray
    Public Sub TampilkanPesan(nama As String)
        MessageBox.Show("Halo, " & nama & "!")
    End Sub

    Function hitung(panjang As Integer, lebar As Integer) As Integer
        If panjang > 50 Then
            Return panjang * lebar
        Else
            Return 2 * panjang + 2 * lebar
        End If
    End Function

    Public nilai() As Integer = {50, 60, 70, 80, 90, 100}
    Public nilai2D(,) As Integer = {
        {55, 53, 65},
        {70, 72, 78},
        {80, 85, 90}
        }
End Module
```

---

### 2. Full Code Form Utama ([`FrmArray.vb`](file:///v:/Pemograman-Visual/Pertemuan5-Modul-Fungi-Array/FrmArray.vb))

Berikut adalah seluruh isi kode program dari file `FrmArray.vb`:

```vb
Public Class FrmArray
    Private Sub btnTampil_Click(sender As Object, e As EventArgs) Handles btnTampil.Click
        ' MessageBox.Show(hitung(txtPanjang.Text, txtLebar.Text))

        ' For i As Integer = 0 To nilai.Length - 1
        'lstNilai.Items.Add(nilai(i))
        'Next

        MessageBox.Show("nilai :" & nilai2D(1, 2))
    End Sub

    Private Sub txtPanjang_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPanjang.KeyPress
        If Not Char.IsControl(e.KeyChar) AndAlso Not Char.IsDigit(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtLebar_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtLebar.KeyPress
        If Not Char.IsControl(e.KeyChar) AndAlso Not Char.IsDigit(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub
End Class
```

---

## 🔍 Penjelasan Rinci Konsep & Arsitektur Kode

### 1. Perbedaan Utama `Module` vs `Class`
- Pada VB.NET, **`Module`** merupakan kontainer global yang anggota (*member*)-nya secara otomatis bersifat statis dan dapat diakses langsung dari mana saja dalam lingkup proyek tanpa perlu membuat objek instansiasi baru menggunakan kata kunci `New`.
- Hal ini sangat efisien untuk menyimpan variabel global, fungsi utilitas bersama, atau konstanta proyek.

### 2. Perbedaan `Sub` vs `Function`
- **`Sub` (Subroutine)**:
  ```vb
  Public Sub TampilkanPesan(nama As String)
      MessageBox.Show("Halo, " & nama & "!")
  End Sub
  ```
  Menjalankan serangkaian instruksi tanpa menghasilkan/mengembalikan nilai (*no return value*).
- **`Function`**:
  ```vb
  Function hitung(panjang As Integer, lebar As Integer) As Integer
      If panjang > 50 Then
          Return panjang * lebar
      Else
          Return 2 * panjang + 2 * lebar
      End If
  End Function
  ```
  Menghasilkan sebuah nilai keluaran menggunakan perintah **`Return`**. Pada fungsi `hitung`, logika bercabang: jika `panjang > 50` maka dihitung sebagai luas (`panjang * lebar`), sedangkan jika tidak maka dihitung sebagai keliling (`2 * panjang + 2 * lebar`).

### 3. Struktur Data Array 1 Dimensi vs 2 Dimensi (Matriks)
- **Array 1 Dimensi (`nilai()`)**:
  ```vb
  Public nilai() As Integer = {50, 60, 70, 80, 90, 100}
  ```
  Menyimpan deretan data linear. Diakses menggunakan 1 indeks (berbasis nol / 0-indexed). Contoh: `nilai(0) = 50`, `nilai(5) = 100`.
- **Array 2 Dimensi (`nilai2D(,)`)**:
  ```vb
  Public nilai2D(,) As Integer = {
      {55, 53, 65},   ' Baris 0
      {70, 72, 78},   ' Baris 1
      {80, 85, 90}    ' Baris 2
  }
  ```
  Menyimpan data berbentuk matriks baris dan kolom. Diakses menggunakan 2 indeks: `nilai2D(indeksBaris, indeksKolom)`.
  - Pada baris kode `nilai2D(1, 2)`:
    - `1` menunjukkan baris ke-2 (karena dimulai dari 0: `{70, 72, 78}`).
    - `2` menunjukkan kolom ke-3 (karena dimulai dari 0: elemen ke-3 adalah `78`).
    - Maka dialog menampilkan: `"nilai :78"`.

### 4. Validasi Input `KeyPress`
Kotak teks `txtPanjang` dan `txtLebar` diproteksi dari karakter selain angka numerik menggunakan `Char.IsControl` dan `Char.IsDigit`.

---

## 🚀 Cara Menjalankan Proyek
1. Buka file solusi `Pertemuan5-Modul-Fungi-Array.slnx` di **Microsoft Visual Studio 2022**.
2. Jalankan aplikasi dengan menekan tombol **F5**.
3. Klik tombol **Tampil** untuk melihat hasil pembacaan elemen array dua dimensi `nilai2D(1, 2)` yang muncul pada dialog pop-up.
