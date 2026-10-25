# 📚 Dokumentasi Praktikum & Tugas Pemrograman Visual

Repositori ini disusun sebagai media pencatatan, pengumpulan tugas, dan dokumentasi modul praktikum mata kuliah **Pemrograman Visual**. Seluruh proyek dibangun menggunakan bahasa **Visual Basic .NET (VB.NET)** pada platform **Windows Forms (.NET Desktop)** dengan Microsoft Visual Studio 2022.

---

## 📂 Indeks Modul & Dokumentasi Proyek

Setiap folder proyek dilengkapi dengan dokumentasi `README.md` terpisah yang menjelaskan fitur, kontrol UI yang digunakan, skema validasi, serta analisis kodenya.

| Modul / Tugas | Topik Utama & Deskripsi Singkat | Status | Tautan Dokumentasi Terpisah |
| :--- | :--- | :---: | :--- |
| **Pertemuan 01** | Pengenalan IDE Visual Studio, Pemrograman Berbasis Kejadian (*Event-Driven*), & Struktur Proyek VB.NET. | Selesai | 📖 [Dokumentasi Pertemuan 1](./Pertemuan1-PengenalanPemrogramanVisual/README.md) |
| **Pertemuan 02** | Form Input Profile Mahasiswa (Nama, NIM, KOM), Event Handling Tombol, `MessageBox`, & Pengelolaan Properti Kontrol. | Selesai | 📖 [Dokumentasi Pertemuan 2](./Pertemuan2-Komponen%20Visual/README.md) |
| **Pertemuan 03** | Validasi Input Angka (`KeyPress` & `TryParse`), Pengkondisian `If...ElseIf`, & Visualisasi Gambar Dinamis (`PictureBox`). | Selesai | 📖 [Dokumentasi Pertemuan 3](./Pertemuan3/README.md) |
| **Pertemuan 04** | Perulangan (`For...Next`), Pemrosesan Batas Awal-Akhir, & Pencetakan Deret Angka pada Kontrol `ListBox`. | Selesai | 📖 [Dokumentasi Pertemuan 4](./Pertemuan4-Perulangan/README.md) |
| **Pertemuan 05** | Modul (`Module`) & Fungsi (`Function`) Terpisah, serta Array Satu Dimensi & Dua Dimensi (`nilai2D`). | Selesai | 📖 [Dokumentasi Pertemuan 5](./Pertemuan5-Modul-Fungi-Array/README.md) |
| **Tugas 01** | Aplikasi Multi-Form: Autentikasi Login (Staff/Manager), Avatar Dynamic Role, & Perhitungan Pajak Bertingkat. | Selesai | 📖 [Dokumentasi Tugas 1](./Tugas1_241712030_HabilRizkyTazir/README.md) |
| **Pertemuan 06** | Integrasi Database PostgreSQL (Npgsql & Supabase), File Konfigurasi `appsettings.json`, Modular Data Layer, & Tampilan `DataGridView`. | Selesai | 📖 [Dokumentasi Pertemuan 6](./Pertemuan6-database/README.md) |
| **Pertemuan 07** | Form Pendaftaran Mahasiswa, Validasi Input Berlapis (`ErrorProvider`), Pencegahan Duplikasi, & Studi Komparasi Konversi Tipe Data. | Selesai | 📖 [Dokumentasi Pertemuan 7](./FormPendaftaran/README.md) |
| **Tugas 02** | Aplikasi Peminjaman Buku Perpustakaan: Validasi Pola Kode Buku (`BKxxxx`), Cek Duplikasi Pinjam, Hitung Jatuh Tempo, & Ekspor CSV. | Selesai | 📖 [Dokumentasi Tugas 2](./PeminjamanBuku/README.md) |
| **Pertemuan 08** | Data Binding & Visualisasi `DataGridView`: Array 2D, `List(Of T)` Objek, `System.Data.DataTable`, `BindingSource`, & Pencarian Dinamis. | Selesai | 📖 [Dokumentasi Pertemuan 8](./DataMahasiswa/README.md) |

---

## 🛠️ Teknologi & Tools
- **Bahasa Pemrograman**: Visual Basic .NET (VB.NET)
- **Framework**: .NET 8.0 / Windows Forms App (WinForms)
- **Database Driver**: PostgreSQL (`Npgsql`) & `Microsoft.Extensions.Configuration`
- **IDE**: Microsoft Visual Studio 2022
- **Version Control**: Git & GitHub

---

## 🔍 Ringkasan Materi & Materi Utama

### 📌 1. Pertemuan 1 — Pengenalan Pemrograman Visual
- Memahami arsitektur Windows Forms dan konsep *Event-Driven Programming*.
- Memahami struktur file `.vb`, `.Designer.vb`, `.resx`, dan file konfigurasi proyek `.slnx`.

### 📌 2. Pertemuan 2 — Komponen Visual & Profile Mahasiswa
- Input data `txtNama`, `txtNIM`, dan `txtKOM`.
- Menampilkan dialog informasi menggunakan `MessageBox.Show()`.
- Mengosongkan form menggunakan `.Clear()` dan menutup form dengan `Me.Close()`.

### 📌 3. Pertemuan 3 — Validasi & Gambar Dinamis
- Pembatasan pengetikan hanya angka menggunakan `Char.IsDigit` pada event `KeyPress`.
- Konversi aman tipe data string ke numerik menggunakan `Integer.TryParse`.
- Mengganti gambar pada `PictureBox` (`picImage.Image = Image.FromFile(...)`) berdasarkan kriteria rentang nilai 0 - 100.

### 📌 4. Pertemuan 4 — Perulangan (`For...Next`)
- Membaca batas awal (`txtNilaiAwal`) dan batas akhir (`txtNilaiAkhir`).
- Memilih struktur perulangan `For i As Integer = nilaiAwal To nilaiAkhir`.
- Menampilkan deret angka perulangan ke dalam kontrol `ListBox` (`lstHasil.Items.Add(i)`).

### 📌 5. Pertemuan 5 — Modul, Fungsi, dan Array
- Memisahkan logika data ke dalam sebuah `Module` tersendiri (`ModArray`), berbeda dari `Class` karena isinya otomatis `Public`/global tanpa perlu instansiasi objek.
- Membedakan `Sub` (tidak mengembalikan nilai) dengan `Function` (mengembalikan nilai lewat `Return`) melalui contoh `hitung(panjang, lebar)` yang menghitung luas atau keliling tergantung kondisi.
- Mendeklarasikan dan mengakses **Array 1 Dimensi** (`nilai()`) dan **Array 2 Dimensi/matriks** (`nilai2D(,)`), termasuk cara pengambilan elemen lewat index baris & kolom.

### 📌 6. Tugas 1 — Autentikasi Login & Perhitungan Pajak
- **Multi-Form Navigation**: Transisi form dari `frmLogin` menuju `FrmPajak`.
- **Dynamic Role Asset**: Pilihan `ComboBox` (`Staff` / `Manager`) mengubah avatar `PictureBox`.
- **Validasi Multi-Karakter**: `txtNama` hanya huruf, `txtNim` & `txtPendapatan` hanya angka.
- **Kalkulator Pajak Bertingkat**:
  - $\le \text{Rp } 5.000.000 \longrightarrow 0\%$
  - $\le \text{Rp } 30.000.000 \longrightarrow 10\%$
  - $\le \text{Rp } 100.000.000 \longrightarrow 20\%$
  - $> \text{Rp } 100.000.000 \longrightarrow 30\%$

### 📌 7. Pertemuan 6 — Integrasi Database PostgreSQL
- **Konfigurasi JSON**: Pembacaan Connection String secara eksternal melalui `appsettings.json` dan `ConfigurationBuilder`.
- **Driver Database**: Menggunakan Npgsql ADO.NET Data Provider untuk PostgreSQL / Supabase.
- **Modular Data Architecture**:
  - `ModDatabase`: Penanganan koneksi awal.
  - `ModFunction`: Helper generic `AmbilData` (`DataTable`) dan `EksekusiData` (*Parameterized Query*).
  - `ModQuery`: Abstraksi query bisnis (`TambahData` & `TampilkanData`).
- **Penyajian Data**: Menampilkan hasil query `SELECT` pada kontrol `DataGridView` (`dgvMahasiswa.DataSource`).

### 📌 8. Pertemuan 7 — Validasi Input, ErrorProvider, & Konversi Tipe Data
- **Validasi Input & ErrorProvider**: Validasi nama, NIM (9 digit angka unik), jurusan, tahun angkatan, dan IPK desimal (0.00 s.d. 4.00) dengan indikator visual `ErrorProvider`.
- **Validasi On-The-Fly**: Event `Validating` pada field input untuk feedback langsung saat kehilangan fokus.
- **Ekspor CSV**: Menyimpan rekap data ke file CSV menggunakan `StreamWriter` dan penanganan `IOException`.
- **Komparasi Konversi & Exception**: Studi perbandingan `CInt()`, `Val()`, dan `Integer.TryParse()`, serta penanganan eksepsi bertingkat (`FormatException`, `OverflowException`, `DivideByZeroException`).

### 📌 9. Tugas 2 (Pertemuan 7) — Aplikasi Peminjaman Buku Perpustakaan
- **Validasi Pola Khusus**: Pola kode buku unik berformat prefix `BK` diikuti 4 digit angka (`BKxxxx`).
- **Pencegahan Duplikasi**: Pengecekan status peminjaman aktif guna mencegah peminjaman ganda buku yang sama.
- **Kalkulasi Jatuh Tempo**: Perhitungan otomatis tanggal pengembalian buku dari tanggal transaksi (`Date.Today.AddDays(lama)`).
- **Ekspor Riwayat CSV**: Ekspor seluruh rekapitulasi data peminjaman ke format file `.csv`.

### 📌 10. Pertemuan 8 — Data Binding & Visualisasi DataGridView
- **Pola Objek POCO**: Entitas Class `Mahasiswa` dengan properti yang diikat secara otomatis ke kolom grid.
- **Multi Data Source**:
  - Pengisian manual sel dari Array 2 Dimensi.
  - Pengikatan dinamis koleksi `List(Of Mahasiswa)` dengan penambahan data via `BindingSource.Add()`.
  - Penggunaan `System.Data.DataTable` dengan filter ekspresi SQL (`LIKE`) real-time via `BindingSource.Filter`.
- **Grid Styling & Formatting**: Pengaturan lebar kolom otomatis (`Fill`), perataan sel (`MiddleRight`, `MiddleCenter`), dan format angka desimal `N2`.

---

## 🚀 Cara Menjalankan Repository
1. Clone repositori ini ke komputer lokal Anda:
   ```bash
   git clone https://github.com/HabilRizky/Pemograman-Visual.git
   ```
2. Buka folder proyek yang ingin dijalankan di **Visual Studio 2022**.
3. Buka file solusi (`.slnx` / `.sln`) di dalam folder masing-masing.
4. Tekan **F5** untuk me-run aplikasi.
