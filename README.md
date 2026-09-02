DOKUMENTASI PRAKTIKUM PEMOGRAMAN VISUAL
======================================

Repositori ini disusun sebagai media pencatatan, pengumpulan tugas, dan dokumentasi berkala untuk modul praktikum mata kuliah Pemrograman Visual. Fokus pembelajaran meliputi pembuatan antarmuka Windows Forms (GUI), event handling, manipulasi kontrol, logika bisnis, dan validasi input.

---

Daftar Modul Praktikum
---------------------

| Modul | Topik Pembahasan | Status | Tautan Dokumentasi |
|-------|------------------|--------|--------------------|
| Pertemuan 01 | Pengenalan Pemrograman Visual & Visual Basic | Selesai | [Buka Dokumentasi](./Pertemuan1-PengenalanPemrogramanVisual/README.md) |
| Pertemuan 02 | Komponen Windows Forms, Event Handling, Properti | Selesai | [Buka Dokumentasi](./Pertemuan2-Komponen%20Visual/) |
| Pertemuan 03 | Operator, Struktur Pengendalian, Validasi Input | Selesai | [Buka Dokumentasi](./Pertemuan3/) |

---

Ringkasan Pertemuan 02 — Profile Mahasiswa
-------------------------------------------

Aplikasi Windows Forms sederhana untuk memasukkan data mahasiswa (Nama, NIM, KOM) dan menampilkan data tersebut lewat MessageBox.

Fitur:
- Form input untuk Nama (txtNama), NIM (txtNIM), KOM (txtKOM)
- Tombol Tampilkan (btnTampilkan) — menampilkan MessageBox berisi Nama, NIM, KOM
- Tombol Hapus (txtHapus) — mengosongkan semua TextBox
- Tombol Keluar (btnKeluar) — menutup aplikasi

File utama:
- Pertemuan2-Komponen Visual/Form1.vb
- Pertemuan2-Komponen Visual/Form1.Designer.vb
- Pertemuan2-Komponen Visual/Form1.resx

Cara menjalankan: buka `Pertemuan2-Komponen Visual.slnx` di Visual Studio, build lalu jalankan (F5).

### Penjelasan Kode Pertemuan 02

Setiap tombol di Windows Forms bekerja lewat mekanisme **event handling**. Ketika sebuah kontrol (misal `Button`) diklik di form desainer, Visual Studio otomatis membuatkan sebuah `Sub` di `Form1.vb` yang terhubung ke event tersebut lewat kata kunci `Handles`. Kata kunci inilah yang membuat kode di dalam `Sub` itu **otomatis dijalankan** saat tombol diklik — tidak perlu memanggilnya secara manual.

```vb
Private Sub btnTampilkan_Click(sender As Object, e As EventArgs) Handles btnTampilkan.Click
    MessageBox.Show("Halo Selamat Datang ! " & vbCrLf &
                    "Nama: " & txtNama.Text & vbCrLf &
                    "NIM: " & txtNIM.Text & vbCrLf &
                    "KOM: " & txtKOM.Text
    )
End Sub
```
- `Handles btnTampilkan.Click` — menghubungkan Sub ini ke event Click milik tombol `btnTampilkan`.
- `txtNama.Text`, `txtNIM.Text`, `txtKOM.Text` — mengambil isi teks yang diketik user di masing-masing TextBox lewat properti `.Text`.
- `vbCrLf` — konstanta ganti baris (carriage return + line feed) agar tampilan MessageBox tersusun rapi per baris.

```vb
Private Sub txtHapus_Click(sender As Object, e As EventArgs) Handles txtHapus.Click
    txtNama.Clear()
    txtNIM.Clear()
    txtKOM.Clear()
End Sub
```
- Method `.Clear()` mengosongkan isi TextBox. Sub ini terhubung ke tombol `txtHapus` (nama kontrolnya memang belum diubah ke `btnHapus`, ini tercatat di bagian TODO).

```vb
Private Sub btnKeluar_Click(sender As Object, e As EventArgs) Handles btnKeluar.Click
    Me.Close()
End Sub
```
- `Me` merujuk ke form yang sedang berjalan (Form1 itu sendiri). `.Close()` menutup form tersebut, yang otomatis mengakhiri aplikasi karena ini form utama.

**Cara memastikan semua bekerja saat dijalankan:** nama Sub (`btnTampilkan_Click`, dst) boleh apa saja, yang penting klausa `Handles NamaKontrol.NamaEvent` sesuai dengan nama kontrol yang dipasang di Form Designer (Properties → Name). Kalau nama kontrol di Designer diubah tapi klausa `Handles` tidak ikut diperbarui, tombol tidak akan merespons klik.

TODO:
- Ubah nama kontrol `txtHapus` menjadi `btnHapus` agar konsisten.
- Tambahkan validasi input (cek kosong dan format NIM).
- Pertimbangkan menampilkan data langsung di form (mis. Label atau List) jika ingin pengembangan lebih lanjut.

---

Ringkasan Pertemuan 03 — Detail Form1.vb
-----------------------------------------

- Lokasi proyek: Pertemuan3\ (solusi: Pertemuan3.slnx)
- File utama: Pertemuan3\Form1.vb

Kontrol utama:
- txtNilai (TextBox): input nilai dari pengguna.
- btnInput (Button): tombol untuk memproses nilai yang dimasukkan.
- picImage (PictureBox): menampilkan gambar hasil berdasarkan nilai.

Logika aplikasi:
1. Saat btnInput diklik, program mencoba mengonversi txtNilai.Text menjadi Integer menggunakan Integer.TryParse.
   - Jika gagal: MessageBox "Masukkan dalam bentuk angka", fokus kembali ke txtNilai.
2. Nilai divalidasi agar berada di rentang 0–100.
   - Jika di luar rentang: MessageBox "Masukkan Nilai 0 - 100", fokus kembali ke txtNilai.
3. Gambar di picImage diambil dari folder Assets:
   - nilai <= 50  -> Assets\1.jpg
   - 51..70       -> Assets\2.jpg
   - >= 71        -> Assets\3.jpg

Validasi tambahan: txtNilai_KeyPress membatasi input hanya digit dan kontrol.

### Penjelasan Kode Pertemuan 03

```vb
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
```
- `Handles btnInput.Click` — Sub ini jalan otomatis setiap tombol `btnInput` diklik.
- `Integer.TryParse(txtNilai.Text, nilai)` — mencoba mengubah teks di `txtNilai` menjadi angka bulat (Integer). Fungsi ini mengembalikan `True`/`False` tanpa membuat program crash walau isinya bukan angka (berbeda dengan `Integer.Parse` biasa yang akan error). Kalau berhasil, hasil angkanya otomatis disimpan ke variabel `nilai`.
- `Return` — menghentikan eksekusi Sub lebih awal (keluar dari `btnInput_Click`) begitu validasi gagal, supaya kode di bawahnya (pengecekan rentang & penentuan gambar) tidak ikut dijalankan.
- `txtNilai.Focus()` — mengembalikan kursor ke TextBox `txtNilai` agar user langsung bisa mengetik ulang tanpa perlu klik manual.
- `If...ElseIf...Else` — struktur percabangan yang menentukan gambar mana yang ditampilkan berdasarkan rentang nilai.
- `Image.FromFile("Assets\1.jpg")` — memuat file gambar dari folder `Assets` (relatif terhadap folder tempat file .exe dijalankan) dan menampilkannya lewat properti `.Image` milik `PictureBox` bernama `picImage`.

```vb
Private Sub txtNilai_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtNilai.KeyPress
    If Not Char.IsControl(e.KeyChar) AndAlso Not Char.IsDigit(e.KeyChar) Then
        e.Handled = True
    End If
End Sub
```
- Event `KeyPress` terpicu setiap kali user menekan tombol keyboard saat fokus berada di `txtNilai`.
- `e.KeyChar` adalah karakter yang baru saja ditekan.
- `Char.IsDigit(e.KeyChar)` — mengecek apakah karakter itu angka (0-9). `Char.IsControl(e.KeyChar)` — mengecek apakah itu tombol kontrol seperti Backspace (perlu tetap diizinkan supaya user bisa menghapus).
- `e.Handled = True` — membatalkan karakter yang baru diketik (dianggap "sudah ditangani") sehingga tidak muncul di TextBox. Efeknya: user hanya bisa mengetik angka.

**Cara memastikan gambar bisa tampil saat dijalankan:** folder `Assets` (berisi `1.jpg`, `2.jpg`, `3.jpg`) harus ikut ter-copy ke folder output build (`bin\Debug\net...\`) setiap kali project di-build, karena path `"Assets\1.jpg"` di atas bersifat relatif. Di Visual Studio, klik kanan file gambar di folder Assets → Properties → set **Copy to Output Directory** menjadi **Copy if newer** agar ini otomatis terjadi.

Catatan menjalankan: pastikan folder Assets berisi 1.jpg, 2.jpg, 3.jpg. Buka Pertemuan3.slnx di Visual Studio, jalankan (F5).
