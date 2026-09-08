# Pertemuan 1 — Pengenalan Pemrograman Visual & VB.NET

Dokumentasi ini berisi pengenalan konsep dasar Pemrograman Visual, lingukngan kerja (IDE) Microsoft Visual Studio, serta struktur dasar aplikasi **Windows Forms** menggunakan bahasa pemrosesan **Visual Basic .NET (VB.NET)**.

---

## 📌 Topik Pembahasan
1. **Pengenalan Pemrograman Visual**: Konsep *Event-Driven Programming* (Pemrograman Berbasis Kejadian) di mana program merespons aksi dari pengguna (seperti klik tombol, pengetikan teks, atau perpindahan kursor).
2. **Pengenalan IDE Visual Studio 2022**:
   - **Form Designer**: Tempat merancang antarmuka grafis (GUI) secara *drag-and-drop*.
   - **Toolbox**: Berisi komponen/kontrol visual dasar (Button, Label, TextBox, PictureBox, dll).
   - **Solution Explorer**: Mengelola file-file proyek, solusi, dan resource.
   - **Properties Window**: Mengatur atribut kontrol (seperti `Name`, `Text`, `BackColor`, `Font`).
3. **Struktur File Proyek Windows Forms (.NET)**:
   - `Form1.vb`: Berisi logika kode program (Code-Behind) dalam VB.NET.
   - `Form1.Designer.vb`: Kode otomatis yang dihasilkan oleh Visual Studio untuk membangun komponen UI.
   - `Form1.resx`: Berisi resource lokal form (seperti icon atau string terlokalisasi).
   - `.vbproj` / `.slnx`: File konfigurasi proyek dan solusi Visual Studio.

---

## 🛠️ Alat & Teknologi yang Digunakan
- **IDE**: Microsoft Visual Studio 2022
- **Bahasa Pemrograman**: Visual Basic .NET (VB.NET)
- **Framework**: .NET Desktop Development (Windows Forms App)

---

## 💡 Konsep Penting Pemrograman Visual

### 1. Model Pemrograman Event-Driven
Berbeda dengan aplikasi konsol (CLI) yang berjalan secara sekuensial dari atas ke bawah, aplikasi Windows Forms menunggu interaksi atau kejadian (*event*) yang dipicu pengguna:
- **Event Click**: Dipicu saat komponen (misalnya `Button`) diklik.
- **Event TextChanged**: Dipicu saat isi teks di `TextBox` berubah.
- **Event KeyPress**: Dipicu saat tombol keyboard ditekan pada suatu kontrol.

### 2. Anatomi Method Handler pada VB.NET
Di VB.NET, sebuah `Sub` dihubungkan ke event menggunakan kata kunci `Handles`:
```vb
Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
    ' Kode logika yang dijalankan saat tombol diklik
End Sub
```
- `sender As Object`: Objek pemicu event (misalnya tombol yang diklik).
- `e As EventArgs`: Data/argumen tambahan mengenai event yang terjadi.
- `Handles Button1.Click`: Mengikat pemanggilan `Sub` secara otomatis ke event `Click` milik `Button1`.

---

## 🚀 Cara Menjalankan Proyek
1. Buka file solusi proyek (`.slnx` atau `.sln`) di **Visual Studio 2022**.
2. Pastikan workload **.NET desktop development** sudah terinstall.
3. Tekan **F5** atau klik tombol **Start** pada Toolbar Visual Studio untuk memjalankan aplikasi (*Debugging*).
