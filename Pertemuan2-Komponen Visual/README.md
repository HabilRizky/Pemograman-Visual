# Pertemuan 2 — Komponen Visual & Event Handling (Profile Mahasiswa)

Proyek ini merupakan aplikasi **Windows Forms** sederhana untuk menginput dan mengelola data dasar mahasiswa (Nama, NIM, KOM). Aplikasi ini mengenalkan penggunaan komponen kontrol visual dasar, manipulasi properti, serta penanganan event klik (*Event Handling*).

---

## 📁 Lokasi Proyek & File Utama
- **Folder Proyek**: `Pertemuan2-Komponen Visual/`
- **File Solusi**: `Pertemuan2-Komponen Visual.slnx`
- **File Kode Utama**: [`Form1.vb`](file:///v:/Pemograman-Visual/Pertemuan2-Komponen%20Visual/Form1.vb)

---

## 🧰 Kontrol Visual yang Digunakan

| Nama Kontrol | Tipe Kontrol | Fungsi / Peranan |
| :--- | :--- | :--- |
| `txtNama` | `TextBox` | Tempat pengguna menginputkan Nama Mahasiswa |
| `txtNIM` | `TextBox` | Tempat pengguna menginputkan NIM (Nomor Induk Mahasiswa) |
| `txtKOM` | `TextBox` | Tempat pengguna menginputkan KOM (Kelas Mahasiswa) |
| `btnTampilkan` | `Button` | Memproses dan menampilkan data inputan lewat `MessageBox` |
| `txtHapus` | `Button` | Mengosongkan seluruh `TextBox` yang ada di Form |
| `btnKeluar` | `Button` | Menutup aplikasi Windows Forms |

---

## 💻 Penjelasan Kode (`Form1.vb`)

Berikut adalah penjelasan lengkap mengenai logika pemrograman yang diimplementasikan pada file [`Form1.vb`](file:///v:/Pemograman-Visual/Pertemuan2-Komponen%20Visual/Form1.vb):

### 1. Menampilkan Data Inputan (`btnTampilkan_Click`)
```vb
Private Sub btnTampilkan_Click(sender As Object, e As EventArgs) Handles btnTampilkan.Click
    MessageBox.Show("Halo Selamat Datang ! " & vbCrLf &
                    "Nama: " & txtNama.Text & vbCrLf &
                    "NIM: " & txtNIM.Text & vbCrLf &
                    "KOM: " & txtKOM.Text
    )
End Sub
```
- **`Handles btnTampilkan.Click`**: Menghubungkan eksekusi prosedur `Sub` secara otomatis ketika tombol `btnTampilkan` diklik oleh pengguna.
- **`txtNama.Text`, `txtNIM.Text`, `txtKOM.Text`**: Mengambil nilai string dari properti `.Text` masing-masing kontrol `TextBox`.
- **`&`**: Operator penggabungan string (*string concatenation*) di Visual Basic.
- **`vbCrLf`**: Konstanta *Carriage Return + Line Feed* untuk membuat baris baru pada pesan dialog `MessageBox`.

---

### 2. Mengosongkan Inputan (`txtHapus_Click`)
```vb
Private Sub txtHapus_Click(sender As Object, e As EventArgs) Handles txtHapus.Click
    txtNama.Clear()
    txtNIM.Clear()
    txtKOM.Clear()
End Sub
```
- **`.Clear()`**: Method bawaan `TextBox` untuk mengosongkan seluruh karakter yang diketik di dalam box.

---

### 3. Menutup Aplikasi (`btnKeluar_Click`)
```vb
Private Sub btnKeluar_Click(sender As Object, e As EventArgs) Handles btnKeluar.Click
    Me.Close()
End Sub
```
- **`Me`**: Kata kunci yang merujuk pada instance Form utama yang sedang aktif.
- **`Me.Close()`**: Menutup form dan mengakhiri sesi aplikasi Windows Forms.

---

## 🚀 Cara Menjalankan Proyek
1. Buka file `Pertemuan2-Komponen Visual.slnx` di Visual Studio 2022.
2. Tekan **F5** untuk menjalankan program.
3. Ketikkan Nama, NIM, dan KOM pada kotak input, lalu klik tombol **Tampilkan** untuk melihat hasilnya di dialog box.
