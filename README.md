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

Catatan menjalankan: pastikan folder Assets berisi 1.jpg, 2.jpg, 3.jpg. Buka Pertemuan3.slnx di Visual Studio, jalankan (F5).

---

Lisensi
-------
Proyek ini milik penulis. Sesuaikan lisensi bila ingin membagikan publik.

Footer
------
Pemrograman Visual • Visual Basic .NET Windows Forms