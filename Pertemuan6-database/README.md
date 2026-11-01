# Pertemuan 6 — Integrasi Database PostgreSQL (Npgsql) & CRUD Data Mahasiswa

Proyek ini berfokus pada integrasi aplikasi **Windows Forms (VB.NET)** dengan database relasional **PostgreSQL** (misalnya Supabase Cloud Database) menggunakan driver ADO.NET **Npgsql**, konfigurasi koneksi berbasis file eksternal `appsettings.json`, arsitektur kode modular berlapis (*Layered Architecture*), serta visualisasi data secara interaktif melalui kontrol **`DataGridView`**.

---

## 📁 Lokasi Proyek & File Utama
- **Folder Proyek**: `Pertemuan6-database/`
- **File Solusi**: `Pertemuan6-database.slnx`
- **File Proyek**: `Pertemuan6-database.vbproj`
- **File Konfigurasi**: [`appsettings.json`](file:///v:/Pemograman-Visual/Pertemuan6-database/appsettings.json)
- **Modul Koneksi**: [`ModDatabase.vb`](file:///v:/Pemograman-Visual/Pertemuan6-database/ModDatabase.vb)
- **Modul Helper Generic Data**: [`ModFunction.vb`](file:///v:/Pemograman-Visual/Pertemuan6-database/ModFunction.vb)
- **Modul Query SQL Spesifik**: [`ModQuery.vb`](file:///v:/Pemograman-Visual/Pertemuan6-database/ModQuery.vb)
- **Form Antarmuka Utama**: [`FormMahasiswa.vb`](file:///v:/Pemograman-Visual/Pertemuan6-database/FormMahasiswa.vb)

---

## 🧰 Kontrol Visual yang Digunakan

| Nama Kontrol | Tipe Kontrol | Fungsi / Peranan |
| :--- | :--- | :--- |
| `dgvMahasiswa` | `DataGridView` | Menampilkan seluruh data tabel mahasiswa dari database PostgreSQL |
| `txtNama` | `TextBox` | Menerima input Nama Mahasiswa (Validasi: hanya huruf) |
| `txtNim` | `TextBox` | Menerima input NIM Mahasiswa (Validasi: hanya angka) |
| `txtJurusan` | `TextBox` | Menerima input Program Studi / Jurusan |
| `btnTambah` | `Button` | Menyimpan data mahasiswa baru ke tabel database PostgreSQL |
| `btnTampilkan` | `Button` | Mengambil data terbaru dari database dan memuatnya ke DataGridView |

---

## 💻 Seluruh Kode Program (Full Code) & Penjelasan Lengkap

### 1. File Konfigurasi ([`appsettings.json`](file:///v:/Pemograman-Visual/Pertemuan6-database/appsettings.json))

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Host=aws-0-ap-southeast-1.pooler.supabase.com;Port=5432;Database=postgres;Username=postgres.vpdkszzruhsekcpbstpm;Password=HabilRizky12;SSL Mode=Require;Trust Server Certificate=true"
  }
}
```
- **Penjelasan**: Connection string dipisahkan dari kode sumber VB.NET. File ini dibaca saat runtime sehingga parameter server, nama database, dan kredensial dapat diganti tanpa perlu melakukan compile ulang proyek.

---

### 2. Modul Koneksi Database ([`ModDatabase.vb`](file:///v:/Pemograman-Visual/Pertemuan6-database/ModDatabase.vb))

```vb
Imports Microsoft.Extensions.Configuration
Imports Npgsql

Module ModDatabase
    Public Function GetConnectionString() As String
        Dim config As IConfiguration =
            New ConfigurationBuilder() _
            .SetBasePath(AppContext.BaseDirectory) _
            .AddJsonFile("appsettings.json", optional:=False, reloadOnChange:=True) _
            .Build()

        Return config.GetConnectionString("DefaultConnection")
    End Function
    Public Sub DatabaseKoneksi()
        Try
            Using conn As New NpgsqlConnection(GetConnectionString)
                conn.Open()

                MessageBox.Show("Koneksi database berhasil")
            End Using
        Catch ex As Exception
            MessageBox.Show("Koneksi database gagal" & vbCrLf & ex.Message & "database")
        End Try
    End Sub
End Module
```
- **Penjelasan**:
  - `ConfigurationBuilder`: Menggunakan paket `Microsoft.Extensions.Configuration.Json` untuk membaca file `appsettings.json` di direktori aplikasi (`AppContext.BaseDirectory`).
  - `DatabaseKoneksi`: Prosedur uji coba koneksi menggunakan `NpgsqlConnection` dengan blok `Using...End Using` yang menjamin koneksi ditutup dan dibersihkan secara otomatis (*Dispose*).

---

### 3. Modul Helper Generic Data ([`ModFunction.vb`](file:///v:/Pemograman-Visual/Pertemuan6-database/ModFunction.vb))

```vb
Imports Npgsql
Imports System.Data
Module ModFunction

    Public Function AmbilData(query As String) As DataTable
        Dim dt As New DataTable

        Try
            Using conn As New NpgsqlConnection(ModDatabase.GetConnectionString())
                conn.Open()
                Using cmd As New NpgsqlCommand(query, conn)
                    Using adapter As New NpgsqlDataAdapter(cmd)
                        adapter.Fill(dt)
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Gagal mengambil data" & vbCrLf & ex.Message, " database")
        End Try

        Return dt
    End Function
    Public Function EksekusiData(query As String, parameters As Dictionary(Of String, Object)) As Boolean
        Try
            Using conn As New NpgsqlConnection(ModDatabase.GetConnectionString())
                conn.Open()

                Using cmd As New NpgsqlCommand(query, conn)
                    For Each parameter In parameters
                        cmd.Parameters.AddWithValue(parameter.Key, parameter.Value)
                    Next
                    cmd.ExecuteNonQuery()
                    Return True
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show(
            "Gagal mengeksekusi data:" & vbCrLf & ex.Message,
            "Error Database"
        )
            Return False
        End Try
    End Function

End Module
```
- **Penjelasan**:
  - **`AmbilData(query As String) As DataTable`**: Mengeksekusi query pembacaan data (`SELECT`) menggunakan `NpgsqlDataAdapter` dan mengisi hasilnya ke dalam objek `DataTable` dalam memori.
  - **`EksekusiData(query, parameters) As Boolean`**: Mengeksekusi query manipulasi (`INSERT`, `UPDATE`, `DELETE`) secara aman menggunakan **Parameterized Queries** (`AddWithValue`) untuk menangkal celah keamanan **SQL Injection**.

---

### 4. Modul Query SQL Spesifik ([`ModQuery.vb`](file:///v:/Pemograman-Visual/Pertemuan6-database/ModQuery.vb))

```vb
Imports System.Data
Module ModQuery
    Public Function TambahData(
        nim As String,
        nama As String,
        jurusan As String
    ) As Boolean
        Dim query As String =
            "INSERT INTO mahasiswa (nim, nama, jurusan) " &
            "VALUES (@nim, @nama, @jurusan)"

        Dim parameters As New Dictionary(Of String, Object) From {
            {"@nim", nim},
            {"@nama", nama},
            {"@jurusan", jurusan}
        }
        Return ModFunction.EksekusiData(query, parameters)
    End Function

    Public Function TampilkanData() As DataTable
        Return ModFunction.AmbilData(
            "SELECT * FROM mahasiswa ORDER BY id ASC"
        )
    End Function

End Module
```
- **Penjelasan**: Membungkus logika SQL khusus entitas `mahasiswa`:
  - `TambahData`: Menyiapkan query `INSERT` dengan placeholder parameter `@nim`, `@nama`, `@jurusan` yang dipetakan ke dalam `Dictionary(Of String, Object)`.
  - `TampilkanData`: Memanggil query `SELECT * FROM mahasiswa ORDER BY id ASC` dan mengembalikan objek `DataTable`.

---

### 5. Form Antarmuka Mahasiswa ([`FormMahasiswa.vb`](file:///v:/Pemograman-Visual/Pertemuan6-database/FormMahasiswa.vb))

```vb
Public Class FormMahasiswa
    Private Sub btnTest_Click(sender As Object, e As EventArgs) Handles btnTampilkan.Click
        dgvMahasiswa.AutoGenerateColumns = True
        dgvMahasiswa.DataSource = ModQuery.TampilkanData()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnTambah.Click
        If ModQuery.TambahData(
            txtNim.Text,
            txtNama.Text,
            txtJurusan.Text
        ) Then

            MessageBox.Show("Data berhasil disimpan")
        End If

        txtJurusan.Clear()
        txtNama.Clear()
        txtNim.Clear()
    End Sub

    Private Sub txtNama_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtNama.KeyPress
        If Not Char.IsControl(e.KeyChar) AndAlso Not Char.IsLetter(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtNIM_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtNim.KeyPress
        If Not Char.IsControl(e.KeyChar) AndAlso Not Char.IsDigit(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

End Class
```
- **Penjelasan**:
  - `btnTampilkan.Click`: Mengatur `AutoGenerateColumns = True` dan langsung mengikat hasil `ModQuery.TampilkanData()` ke `dgvMahasiswa.DataSource`.
  - `btnTambah.Click`: Mengirimkan teks isian form ke `ModQuery.TambahData()`. Jika bernilai `True`, muncul notifikasi sukses dan seluruh kotak teks dibersihkan.
  - `txtNama.KeyPress` & `txtNim.KeyPress`: Membatasi nama hanya alfabet huruf dan NIM hanya numerik angka.

---

## 🗄️ Prasyarat Skema Database PostgreSQL
Sebelum menjalankan aplikasi, buat tabel pada PostgreSQL / Supabase Anda:
```sql
CREATE TABLE mahasiswa (
    id SERIAL PRIMARY KEY,
    nim VARCHAR(20) NOT NULL,
    nama VARCHAR(100) NOT NULL,
    jurusan VARCHAR(50) NOT NULL
);
```

---

## 🚀 Cara Menjalankan Proyek
1. Buka solusi `Pertemuan6-database.slnx` pada **Visual Studio 2022**.
2. Pastikan file `appsettings.json` telah dikonfigurasi dengan host, user, dan password database PostgreSQL Anda.
3. Tekan **F5** untuk me-run aplikasi.
4. Klik **Tampilkan** untuk memuat data tabel mahasiswa ke `DataGridView`.
5. Masukkan **Nama**, **NIM**, dan **Jurusan**, lalu klik tombol **Tambah** untuk menyimpan data ke database.
