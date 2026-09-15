# Pertemuan 05 — Modul, Fungsi, dan Array

Aplikasi Windows Forms (VB.NET) yang mendemonstrasikan penggunaan **Module**, **Function**, dan **Array** (satu dimensi & dua dimensi), dengan logika data dipisah dari kode Form ke dalam sebuah Module tersendiri (`ModArray`).

## Deskripsi Proyek

Program ini punya dua bagian utama:

1. **`FrmArray.vb`** — Form dengan input Panjang & Lebar, serta tombol yang menampilkan hasil lewat `MessageBox`.
2. **`ModArray.vb`** — Module terpisah berisi Sub, Function, dan data array yang bisa dipanggil langsung dari Form manapun dalam project (karena isi `Module` otomatis bersifat `Public`, tanpa perlu instansiasi objek).

## Kontrol UI

| Kontrol | Nama | Fungsi |
|---|---|---|
| TextBox | `txtPanjang` | Input nilai panjang (hanya menerima digit) |
| TextBox | `txtLebar` | Input nilai lebar (hanya menerima digit) |
| Button | `btnTampil` | Menjalankan proses & menampilkan hasil |
| ListBox | `lstNilai` | Disiapkan untuk menampilkan isi array (belum aktif dipakai) |

## Isi Module ModArray

```vb
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
```

- **TampilkanPesan** — contoh Sub sederhana yang menampilkan pesan sapaan lewat parameter nama.
- **hitung(panjang, lebar)** — contoh Function (mengembalikan nilai lewat Return, beda dari Sub). Logikanya: kalau panjang > 50, dianggap menghitung **luas** (panjang * lebar); kalau tidak, menghitung **keliling** (2*panjang + 2*lebar).
- **nilai()** — array **1 dimensi** berisi 6 angka tetap, diakses lewat 1 index, mis. nilai(0) = 50.
- **nilai2D(,)** — array **2 dimensi** (matriks 3x3), diakses lewat 2 index (baris, kolom). Contoh: nilai2D(1, 2) = baris ke-2, kolom ke-3 (index dari 0) = 78.

## Penjelasan Kode Utama (FrmArray.vb)

```vb
Private Sub btnTampil_Click(sender As Object, e As EventArgs) Handles btnTampil.Click
    MessageBox.Show("nilai :" & nilai2D(1, 2))
End Sub
```

- Handles btnTampil.Click — Sub ini otomatis berjalan saat tombol btnTampil diklik.
- nilai2D(1, 2) — mengambil langsung nilai dari array 2D yang dideklarasikan di ModArray, tanpa perlu menulis nama Module di depannya (karena bersifat Public).
- Hasilnya (78) ditampilkan lewat MessageBox.Show.

```vb
Private Sub txtPanjang_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPanjang.KeyPress
    If Not Char.IsControl(e.KeyChar) AndAlso Not Char.IsDigit(e.KeyChar) Then
        e.Handled = True
    End If
End Sub
```

- Membatasi input txtPanjang (dan txtLebar, dengan Sub serupa) hanya menerima digit angka dan tombol kontrol seperti Backspace.
- e.Handled = True membatalkan karakter yang bukan angka, sehingga tidak muncul di TextBox.

**Catatan:** di FrmArray.vb ada beberapa baris kode yang di-comment (dinonaktifkan dengan tanda petik satu) — draft percobaan memanggil hitung(...) dan melakukan perulangan For...Next untuk mengisi lstNilai dari array nilai(). Baris ini bisa diaktifkan kembali untuk mendemonstrasikan pemanggilan Function dan pengisian ListBox dari array 1 dimensi.

## Cara Menjalankan

1. Buka Pertemuan5-Modul-Fungi-Array.slnx di Visual Studio.
2. Build & Run (F5).
3. Klik tombol **Tampilkan** untuk melihat hasil nilai2D(1, 2) muncul di MessageBox.
