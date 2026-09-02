# Profile Mahasiswa (Pertemuan 2 - Komponen Visual)

Deskripsi

Aplikasi Windows Forms sederhana untuk memasukkan data mahasiswa (Nama, NIM, KOM) dan menampilkan data tersebut lewat MessageBox.

Fitur

- Form input untuk:
  - Nama (txtNama)
  - NIM (txtNIM)
  - KOM (txtKOM)
- Tombol:
  - Tampilkan (btnTampilkan) — menampilkan MessageBox berisi Nama, NIM, KOM
  - Hapus (txtHapus) — mengosongkan semua TextBox
  - Keluar (btnKeluar) — menutup aplikasi

File utama

- Pertemuan2-Komponen Visual/Form1.vb
- Pertemuan2-Komponen Visual/Form1.Designer.vb
- Pertemuan2-Komponen Visual/Form1.resx

Cara menjalankan

1. Buka `Pertemuan2-Komponen Visual.slnx` di Visual Studio.
2. Build lalu jalankan (F5).

Contoh penggunaan

1. Isi Nama, NIM, KOM pada kolom masing-masing.
2. Klik "Tampilkan" untuk melihat data di MessageBox.
3. Klik "Hapus" untuk mengosongkan input.
4. Klik "Keluar" untuk menutup aplikasi.

Catatan / TODO

- Ubah nama kontrol `txtHapus` menjadi `btnHapus` agar konsisten.
- Tambahkan validasi input (cek kosong dan format NIM).
- Pertimbangkan menampilkan data langsung di form (mis. Label atau List) jika ingin pengembangan lebih lanjut.
