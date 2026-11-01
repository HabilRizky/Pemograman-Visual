# Pertemuan 3 — Operator, Struktur Pengendalian & Validasi Input

Proyek ini mendemonstrasikan implementasi **Validasi Input Angka**, penggunaan **Struktur Percabangan Keputusan (`If...ElseIf...Else`)**, serta **Visualisasi Gambar Dinamis** pada kontrol `PictureBox` berdasarkan rentang nilai skor yang dimasukkan oleh pengguna.

---

## 📁 Lokasi Proyek & File Utama
- **Folder Proyek**: `Pertemuan3/`
- **File Solusi**: `Pertemuan3.slnx`
- **File Proyek**: `Pertemuan3.vbproj`
- **File Kode Utama**: [`Form1.vb`](file:///v:/Pemograman-Visual/Pertemuan3/Form1.vb)
- **Folder Asset Gambar**: `Assets/` (berisi `1.jpg`, `2.jpg`, `3.jpg`)

---

## 🧰 Kontrol Visual & Asset yang Digunakan

| Nama Kontrol | Tipe Kontrol | Fungsi / Peranan |
| :--- | :--- | :--- |
| `txtNilai` | `TextBox` | Menerima masukan nilai dari pengguna (skala 0 - 100) |
| `btnInput` | `Button` | Memvalidasi input dan menampilkan gambar sesuai kategori skor |
| `picImage` | `PictureBox` | Menampilkan visual gambar hasil klasifikasi nilai |
| `Assets\1.jpg` | Image File | Gambar representasi skor kategori rendah ($\le 50$) |
| `Assets\2.jpg` | Image File | Gambar representasi skor kategori sedang ($51 - 70$) |
| `Assets\3.jpg` | Image File | Gambar representasi skor kategori tinggi ($> 70$) |

---

## 💻 Seluruh Kode Program (Full Code) & Penjelasan Lengkap

### Full Code [`Form1.vb`](file:///v:/Pemograman-Visual/Pertemuan3/Form1.vb)

Berikut adalah seluruh kode program dari file `Form1.vb`:

```vb
Public Class Form1

    Private Sub btnInput_Click(sender As Object, e As EventArgs) Handles btnInput.Click
        Dim nilai As Integer

        If Not Integer.TryParse(txtNilai.Text, nilai) Then
            MessageBox.Show("Masukkan dalam bentuk angka")
            txtNilai.Focus()
            Return
        End If

        If nilai < 0 OrElse nilai > 100 Then
            MessageBox.Show("Masukkan Nilai 0 - 100 ")
            txtNilai.Focus()
            Return
        End If

        If nilai <= 50 Then
            picImage.Image = Image.FromFile("Assets\1.jpg")


        ElseIf nilai <= 70 Then
            picImage.Image = Image.FromFile("Assets\2.jpg")

        Else
            picImage.Image = Image.FromFile("Assets\3.jpg")
        End If


    End Sub

    Private Sub txtNilai_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtNilai.KeyPress
        If Not Char.IsControl(e.KeyChar) AndAlso Not Char.IsDigit(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub
End Class
```

---

## 🔍 Penjelasan Rinci Setiap Prosedur & Logika Kode

### 1. Pembatasan Input Karakter Saat Pengetikan (`txtNilai_KeyPress`)
```vb
Private Sub txtNilai_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtNilai.KeyPress
    If Not Char.IsControl(e.KeyChar) AndAlso Not Char.IsDigit(e.KeyChar) Then
        e.Handled = True
    End If
End Sub
```
- **Event `KeyPress`**: Terpanggil secara real-time setiap kali pengguna menekan sebuah tombol pada keyboard sewaktu fokus berada di `txtNilai`.
- **`Char.IsControl(e.KeyChar)`**: Mengecek apakah tombol yang ditekan adalah tombol navigasi atau pengeditan dasar seperti `Backspace`, `Tab`, atau `Enter` agar pengguna tetap dapat mengoreksi pengetikan.
- **`Char.IsDigit(e.KeyChar)`**: Mengecek apakah tombol yang ditekan merupakan karakter angka (`0` sampai dengan `9`).
- **`e.Handled = True`**: Menginstruksikan runtime Windows bahwa event pengetikan sudah diselesaikan dan dibatalkan, sehingga karakter huruf, tanda baca, spasi, atau simbol lainnya dicegah muncul di dalam kotak teks.

---

### 2. Logika Validasi & Percabangan Nilai (`btnInput_Click`)
```vb
Private Sub btnInput_Click(sender As Object, e As EventArgs) Handles btnInput.Click
    Dim nilai As Integer

    ' 1. Validasi Konversi Numerik Aman
    If Not Integer.TryParse(txtNilai.Text, nilai) Then
        MessageBox.Show("Masukkan dalam bentuk angka")
        txtNilai.Focus()
        Return
    End If

    ' 2. Validasi Batas Rentang (Range Validation)
    If nilai < 0 OrElse nilai > 100 Then
        MessageBox.Show("Masukkan Nilai 0 - 100 ")
        txtNilai.Focus()
        Return
    End If

    ' 3. Percabangan Keputusan Penentuan Gambar
    If nilai <= 50 Then
        picImage.Image = Image.FromFile("Assets\1.jpg")
    ElseIf nilai <= 70 Then
        picImage.Image = Image.FromFile("Assets\2.jpg")
    Else
        picImage.Image = Image.FromFile("Assets\3.jpg")
    End If
End Sub
```

#### Rincian Logika:
1. **Konversi Aman dengan `Integer.TryParse`**:
   - Berbeda dari fungsi `CInt` atau `Integer.Parse` yang akan memicu eksepsi *runtime crash* jika kotak teks kosong atau tidak valid, `Integer.TryParse` mengembalikan nilai `Boolean` (`True` jika berhasil dikonversi, `False` jika gagal) dan menyimpan hasilnya ke parameter `ByRef nilai`.
2. **`txtNilai.Focus()` & `Return` (Early Exit)**:
   - Jika pengguna memasukkan input yang salah atau di luar batas `0 - 100`, kursor dikembalikan ke `txtNilai` dan eksekusi prosedur langsung dihentikan dengan perintah `Return`, mencegah kode di bawahnya tereksekusi.
3. **Logika Percabangan `If...ElseIf...Else`**:
   - Rentang $\text{nilai} \le 50$: Memuat gambar visual `Assets\1.jpg`.
   - Rentang $51 \le \text{nilai} \le 70$: Memuat gambar visual `Assets\2.jpg`.
   - Rentang $\text{nilai} > 70$: Memuat gambar visual `Assets\3.jpg`.
4. **Pemuatan Gambar `Image.FromFile`**:
   - Memuat file bitmap secara dinamis dari path relatif `Assets\` terhadap folder eksekusi program.

---

## ⚙️ Konfigurasi Asset Gambar di Visual Studio
Agar gambar di folder `Assets/` dapat ditemukan oleh aplikasi saat dijalankan:
1. Di **Solution Explorer**, pilih file `1.jpg`, `2.jpg`, dan `3.jpg`.
2. Pada jendela **Properties**, ubah properti **Copy to Output Directory** menjadi **Copy if newer** atau **Copy always**.

---

## 🚀 Cara Menjalankan Proyek
1. Buka file solusi `Pertemuan3.slnx` di **Visual Studio 2022**.
2. Tekan tombol **F5** untuk memulai aplikasi.
3. Masukkan angka nilai antara `0` hingga `100` pada kotak input `txtNilai`.
4. Klik tombol **Input** untuk melihat perubahan gambar pada kontrol `picImage`.
