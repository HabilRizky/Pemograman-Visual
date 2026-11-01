# Pertemuan 2 — Komponen Visual & Event Handling (Profile Mahasiswa)

Proyek ini merupakan aplikasi **Windows Forms (VB.NET)** sederhana untuk menginput dan mengelola data dasar mahasiswa (Nama, NIM, KOM). Proyek ini mengenalkan penggunaan komponen kontrol visual dasar, manipulasi properti kontrol, serta penanganan kejadian klik (*Event Handling*).

---

## 📁 Lokasi Proyek & File Utama
- **Folder Proyek**: `Pertemuan2-Komponen Visual/`
- **File Solusi**: `Pertemuan2-Komponen Visual.slnx`
- **File Proyek**: `Pertemuan2-Komponen Visual.vbproj`
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

## 💻 Seluruh Kode Program (Full Code) & Penjelasan Lengkap

### Full Code [`Form1.vb`](file:///v:/Pemograman-Visual/Pertemuan2-Komponen%20Visual/Form1.vb)

Berikut adalah kode sumber lengkap dari file `Form1.vb`:

```vb
Public Class Form1
    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles txtNama.TextChanged

    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub btnTampilkan_Click(sender As Object, e As EventArgs) Handles btnTampilkan.Click
        MessageBox.Show("Halo Selamat Datang ! " & vbCrLf &
                        "Nama: " & txtNama.Text & vbCrLf &
                        "NIM: " & txtNIM.Text & vbCrLf &
                        "KOM: " & txtKOM.Text
        )
    End Sub

    Private Sub txtHapus_Click(sender As Object, e As EventArgs) Handles txtHapus.Click
        txtNama.Clear()
        txtNIM.Clear()
        txtKOM.Clear()
    End Sub

    Private Sub btnKeluar_Click(sender As Object, e As EventArgs) Handles btnKeluar.Click
        Me.Close()
    End Sub
End Class
```

---

## 🔍 Penjelasan Detail Setiap Prosedur & Logika Kode

### 1. Inisialisasi & Event Handler Kosong
```vb
Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles txtNama.TextChanged

End Sub

Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

End Sub
```
- **`Handles txtNama.TextChanged`**: Prosedur penanganan event bawaan yang tercipta saat melakukan *double-click* pada kontrol TextBox di designer. Prosedur ini dapat diisi dengan logika validasi dinamis setiap kali isi karakter di `txtNama` berubah.
- **`Handles MyBase.Load`**: Prosedur yang dipicu saat form pertama kali dimuat ke dalam memori sebelum ditampilkan ke layar.

### 2. Prosedur Menampilkan Data (`btnTampilkan_Click`)
```vb
Private Sub btnTampilkan_Click(sender As Object, e As EventArgs) Handles btnTampilkan.Click
    MessageBox.Show("Halo Selamat Datang ! " & vbCrLf &
                    "Nama: " & txtNama.Text & vbCrLf &
                    "NIM: " & txtNIM.Text & vbCrLf &
                    "KOM: " & txtKOM.Text
    )
End Sub
```
- **`Handles btnTampilkan.Click`**: Mengikat pemanggilan subrutin secara otomatis saat tombol `btnTampilkan` diklik oleh pengguna.
- **`txtNama.Text`, `txtNIM.Text`, `txtKOM.Text`**: Membaca teks string yang tersimpan di dalam properti `.Text` masing-masing kontrol input.
- **Operator `&`**: Operator penggabungan (*string concatenation*) standar pada bahasa Visual Basic.
- **`vbCrLf`**: Konstanta bawaan (*Carriage Return + Line Feed*) untuk menyisipkan baris baru (enter) pada dialog pop-up.
- **`MessageBox.Show(...)`**: Menampilkan kotak dialog modal (*pop-up dialog box*) yang berisi informasi data profil mahasiswa.

### 3. Prosedur Membersihkan Input (`txtHapus_Click`)
```vb
Private Sub txtHapus_Click(sender As Object, e As EventArgs) Handles txtHapus.Click
    txtNama.Clear()
    txtNIM.Clear()
    txtKOM.Clear()
End Sub
```
- **`.Clear()`**: Method bawaan kelas `TextBoxBase` untuk menghapus seluruh teks dari kontrol TextBox dan menyetel properti `.Text` kembali menjadi string kosong (`""`).

### 4. Prosedur Keluar dari Aplikasi (`btnKeluar_Click`)
```vb
Private Sub btnKeluar_Click(sender As Object, e As EventArgs) Handles btnKeluar.Click
    Me.Close()
End Sub
```
- **`Me`**: Kata kunci referensi yang menunjuk pada instance Form yang sedang aktif.
- **`Me.Close()`**: Menutup jendela form dan membebaskan resource yang digunakan oleh aplikasi.

---

## 🚀 Cara Menjalankan Proyek
1. Buka file solusi `Pertemuan2-Komponen Visual.slnx` menggunakan **Microsoft Visual Studio 2022**.
2. Tekan tombol **F5** atau klik tombol **Start** untuk menjalankan program dalam mode *Debugging*.
3. Isikan data pada kotak teks **Nama**, **NIM**, dan **KOM**.
4. Klik tombol **Tampilkan** untuk memunculkan kotak dialog profil mahasiswa.
5. Klik tombol **Hapus** untuk mengosongkan semua kolom input.
6. Klik tombol **Keluar** untuk mengakhiri program.
