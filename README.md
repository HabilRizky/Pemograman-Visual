# Pemograman-Visual

Pengumpulan Pertemuan Praktikum Pemograman-Visual

# Pertemuan 2-Komponen Visual
Project: Profile Mahasiswa (Pertemuan2 - Komponen Visual)
Ringkasan
•	Aplikasi Windows Forms sederhana untuk memasukkan data mahasiswa (Nama, NIM, KOM) dan menampilkan data tersebut lewat MessageBox.
Perubahan / Fitur yang dibuat
•	Form1 dengan kontrol:
•	Label + TextBox untuk Nama (lblNama, txtNama)
•	Label + TextBox untuk NIM (lblNIM, txtNIM)
•	Label + TextBox untuk KOM (lblKOM, txtKOM)
•	Tombol Tampilkan (btnTampilkan): menampilkan MessageBox berisi Nama, NIM, KOM
•	Tombol Hapus (txtHapus): mengosongkan semua TextBox
•	Tombol Keluar (btnKeluar): menutup form
•	Event handlers di Form1.vb:
•	btnTampilkan_Click: membentuk dan menampilkan pesan
•	txtHapus_Click: Clear() pada txtNama, txtNIM, txtKOM
•	btnKeluar_Click: Me.Close()
•	Ada handler kosong untuk txtNama.TextChanged dan Form1.Load
File utama
•	Pertemuan2-Komponen Visual\Form1.vb
•	Pertemuan2-Komponen Visual\Form1.Designer.vb
•	Pertemuan2-Komponen Visual\Form1.resx
Cara menjalankan
•	Buka Pertemuan2-Komponen Visual.slnx di Visual Studio
•	Build lalu jalankan (F5)
Contoh penggunaan
1.	Isi Nama, NIM, KOM pada bidang masing-masing.
2.	Klik "Tampilkan" untuk melihat data di MessageBox.
3.	Klik "Hapus" untuk mengosongkan input, atau "Keluar" untuk menutup aplikasi.
Catatan / TODO
•	Tambahkan validasi input (kosong, format NIM).
•	Ganti nama kontrol tombol "txtHapus" menjadi btnHapus untuk konsistensi.
•	Pertimbangkan menampilkan data di form (labels) alih-alih MessageBox jika ingin pengembangan lebih lanjut.
