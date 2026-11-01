# Pertemuan 1 — Pengenalan Pemrograman Visual & Arsitektur Windows Forms

Dokumentasi ini berisi pengenalan konsep fundamental Pemrograman Visual, lingkungan kerja (*Integrated Development Environment* / IDE) Microsoft Visual Studio 2022, model pemrograman berbasis kejadian (*Event-Driven Programming*), serta struktur arsitektur berkas proyek **Windows Forms (.NET Desktop)** menggunakan bahasa pemrograman **Visual Basic .NET (VB.NET)**.

---

## 📌 Topik Pembahasan
1. **Konsep Pemrograman Visual**: Pergeseran paradigma dari pemrograman sekuensial (Command Line Interface / CLI) menuju antarmuka grafis (Graphical User Interface / GUI) yang digerakkan oleh event pengguna.
2. **Lingkungan Kerja Visual Studio 2022**:
   - **Form Designer**: Ruang kerja visual untuk menyusun kontrol UI secara drag-and-drop.
   - **Toolbox**: Katalog komponen kontrol visual (Button, Label, TextBox, PictureBox, DataGridView, dll).
   - **Solution Explorer**: Panel pengelola hierarki file, referensi dependensi, dan solusi proyek.
   - **Properties Window**: Panel inspeksi untuk memodifikasi atribut kontrol (`Name`, `Text`, `BackColor`, `Font`, `Size`, dll).
3. **Struktur Berkas Proyek Windows Forms (.NET)**:
   - `Form1.vb`: Berkas logika kode program (*Code-Behind*).
   - `Form1.Designer.vb`: Berkas kode otomatis yang di-generate oleh Visual Studio untuk mendefinisikan layout dan inisialisasi komponen UI.
   - `Form1.resx`: Berkas XML yang menampung resource lokal form (ikon, string, gambar).
   - `.vbproj` / `.slnx`: Berkas konfigurasi proyek berbasis MSBuild dan solusi Visual Studio.

---

## 🛠️ Alat & Teknologi yang Digunakan
- **IDE**: Microsoft Visual Studio 2022
- **Bahasa Pemrograman**: Visual Basic .NET (VB.NET)
- **Framework**: .NET 8.0 Windows Forms App (`Microsoft.NET.Sdk`)

---

## 💻 Seluruh Kode Program (Full Code) Contoh Pondasi & Penjelasan Lengkap

Berikut adalah implementasi kode program pondasi Windows Forms standar yang mendemonstrasikan penanganan event, pembacaan kontrol, dan manipulasi properti saat runtime:

### Full Code [`Form1.vb`](file:///v:/Pemograman-Visual/Pertemuan1-PengenalanPemrogramanVisual/README.md)

```vb
Public Class Form1

    ' Event Handler: Dipicu saat form pertama kali dimuat ke memori
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = "Aplikasi Pertemuan 1 — Pengenalan Pemrograman Visual"
        lblPesan.Text = "Silakan masukkan nama Anda dan klik tombol Sapa."
    End Sub

    ' Event Handler: Dipicu saat tombol btnSapa diklik
    Private Sub btnSapa_Click(sender As Object, e As EventArgs) Handles btnSapa.Click
        Dim nama As String = txtNama.Text.Trim()

        If String.IsNullOrEmpty(nama) Then
            MessageBox.Show("Silakan ketikkan nama Anda terlebih dahulu!",
                            "Peringatan",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning)
            txtNama.Focus()
            Return
        End If

        lblPesan.Text = "Halo, selamat datang di Pemrograman Visual, " & nama & "!"
        MessageBox.Show("Halo " & nama & "! Proyek Windows Forms Anda berhasil berjalan.",
                        "Informasi",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information)
    End Sub

    ' Event Handler: Dipicu saat tombol btnReset diklik
    Private Sub btnReset_Click(sender As Object, e As EventArgs) Handles btnReset.Click
        txtNama.Clear()
        lblPesan.Text = "Form telah di-reset."
        txtNama.Focus()
    End Sub

    ' Event Handler: Dipicu saat tombol btnTutup diklik
    Private Sub btnTutup_Click(sender As Object, e As EventArgs) Handles btnTutup.Click
        Dim konfirmasi As DialogResult = MessageBox.Show(
            "Apakah Anda yakin ingin keluar dari aplikasi?",
            "Konfirmasi Keluar",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question
        )

        If konfirmasi = DialogResult.Yes Then
            Me.Close()
        End If
    End Sub

End Class
```

---

## 🔍 Penjelasan Detail Anatomi & Konsep Kunci

### 1. Model Pemrograman Event-Driven
Pada aplikasi Windows Forms, eksekusi kode tidak berjalan lurus dari baris awal ke baris akhir, melainkan berada dalam siklus *Message Loop* yang menunggu terjadinya peristiwa (*event*):
- **Event `Load`**: Dipicu satu kali ketika jendela form pertama kali diciptakan di memori sebelum digambar di monitor.
- **Event `Click`**: Dipicu saat kursor mouse mengklik kontrol tertentu seperti `Button`.
- **Event `TextChanged`**: Dipicu secara langsung setiap kali karakter di dalam `TextBox` berubah.
- **Event `KeyPress`**: Dipicu saat tombol keyboard ditekan sebelum karakter dicetak ke layar.

### 2. Klausa `Handles` & Parameter Method
```vb
Private Sub btnSapa_Click(sender As Object, e As EventArgs) Handles btnSapa.Click
```
- **`sender As Object`**: Merujuk ke objek pemanggil event (dalam hal ini tombol `btnSapa`).
- **`e As EventArgs`**: Menyediakan argumen kontekstual terkait event (misalnya koordinat klik mouse atau status tombol keyboard).
- **`Handles btnSapa.Click`**: Menautkan subrutin ini secara eksplisit ke event `Click` milik komponen `btnSapa`.

### 3. Kotak Dialog Interaktif (`MessageBox.Show`)
```vb
MessageBox.Show(teksPesan, judulDialogBox, tombolPilihan, ikonDialog)
```
Method ini memunculkan kotak pesan modal (*blocking UI*) yang meminta perhatian pengguna dengan tombol standar (`OK`, `YesNo`, `Cancel`) dan ikon visual (`Information`, `Warning`, `Error`, `Question`).

---

## 🚀 Cara Menjalankan Proyek
1. Buka file solusi proyek (`.slnx` atau `.sln`) di **Visual Studio 2022**.
2. Pastikan paket beban kerja **.NET Desktop Development** sudah terpasang.
3. Tekan **F5** atau klik tombol **Start** pada Toolbar Visual Studio untuk meng-compile dan menjalankan aplikasi dalam mode debugging.
