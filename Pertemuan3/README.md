# Pertemuan 3 — Operator, Struktur Pengendalian & Validasi Input

Proyek ini mendemonstrasikan penerapan **validasi data input**, penggunaan **struktur keputusan (`If...ElseIf...Else`)**, serta **visualisasi gambar dinamis** pada kontrol `PictureBox` berdasarkan nilai yang dimasukkan oleh pengguna.

---

## 📁 Lokasi Proyek & File Utama
- **Folder Proyek**: `Pertemuan3/`
- **File Solusi**: `Pertemuan3.slnx`
- **File Kode Utama**: [`Form1.vb`](file:///v:/Pemograman-Visual/Pertemuan3/Form1.vb)
- **Folder Gambar**: `Assets/` (berisi `1.jpg`, `2.jpg`, `3.jpg`)

---

## 🧰 Kontrol Visual & Asset yang Digunakan

| Nama Kontrol | Tipe Kontrol | Fungsi / Peranan |
| :--- | :--- | :--- |
| `txtNilai` | `TextBox` | Menerima input nilai dari pengguna (skala 0 - 100) |
| `btnInput` | `Button` | Memvalidasi input dan menampilkan gambar sesuai kategori nilai |
| `picImage` | `PictureBox` | Menampilkan gambar visual sesuai kategori nilai |
| `Assets\1.jpg` | Image File | Gambar untuk nilai $\le 50$ |
| `Assets\2.jpg` | Image File | Gambar untuk nilai $51 - 70$ |
| `Assets\3.jpg` | Image File | Gambar untuk nilai $> 70$ |

---

## 💻 Penjelasan Kode (`Form1.vb`)

Berikut adalah pembahasan detail mengenai logika kode di file [`Form1.vb`](file:///v:/Pemograman-Visual/Pertemuan3/Form1.vb):

### 1. Validasi Karakter Saat Pengetikan (`txtNilai_KeyPress`)
```vb
Private Sub txtNilai_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtNilai.KeyPress
    If Not Char.IsControl(e.KeyChar) AndAlso Not Char.IsDigit(e.KeyChar) Then
        e.Handled = True
    End If
End Sub
```
- **`txtNilai.KeyPress`**: Terpanggil setiap kali pengguna menekan tombol keyboard saat fokus berada di `txtNilai`.
- **`Char.IsDigit(e.KeyChar)`**: Memeriksa apakah karakter yang ditekan adalah angka (`0` s/d `9`).
- **`Char.IsControl(e.KeyChar)`**: Memeriksa apakah karakter yang ditekan adalah tombol kontrol seperti `Backspace` (agar pengguna tetap bisa menghapus teks).
- **`e.Handled = True`**: Menginstruksikan sistem bahwa event pengetikan telah ditangani dan **dibatalkan**, sehingga karakter selain angka/backspace tidak akan muncul di `TextBox`.

---

### 2. Logika Pemrosesan & Percabangan Nilai (`btnInput_Click`)
```vb
Private Sub btnInput_Click(sender As Object, e As EventArgs) Handles btnInput.Click
    Dim nilai As Integer

    ' Validasi Konversi Angka Aman
    If Not Integer.TryParse(txtNilai.Text, nilai) Then
        MessageBox.Show("Masukkan dalam bentuk angka")
        txtNilai.Focus()
        Return
    End If

    ' Validasi Batas Rentang Nilai (0 - 100)
    If nilai < 0 OrElse nilai > 100 Then
        MessageBox.Show("Masukkan Nilai 0 - 100 ")
        txtNilai.Focus()
        Return
    End If

    ' Kondisi Penentuan Gambar Berdasarkan Nilai
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
1. **`Integer.TryParse(txtNilai.Text, nilai)`**: Mengonversi teks ke numerik bertipe `Integer` secara aman. Jika teks berupa karakter non-angka atau kosong, fungsi mengembalikan `False` tanpa menyebabkan program crash (berbeda dari `CInt` atau `Integer.Parse`).
2. **`txtNilai.Focus()` & `Return`**: Kursor dipindahkan kembali ke `txtNilai` dan eksekusi fungsi dihentikan lebih awal (*early return*) saat validasi gagal.
3. **`If...ElseIf...Else`**:
   - $\text{Nilai} \le 50 \longrightarrow$ Memuat gambar `Assets\1.jpg`
   - $51 \le \text{Nilai} \le 70 \longrightarrow$ Memuat gambar `Assets\2.jpg`
   - $\text{Nilai} > 70 \longrightarrow$ Memuat gambar `Assets\3.jpg`
4. **`Image.FromFile(...)`**: Memuat file gambar eksternal dari folder `Assets` yang relatif terhadap direktori kerja aplikasi.

---

## ⚙️ Catatan Penting
Pastikan properti gambar di folder `Assets` diatur ke **Copy to Output Directory = Copy if newer** pada Visual Studio agar gambar ikut disalin ke folder `bin/Debug/` saat aplikasi di-build.
