# Pertemuan 6 — Integrasi Database PostgreSQL (Npgsql) & CRUD Data Mahasiswa

Proyek ini berfokus pada integrasi aplikasi **Windows Forms (VB.NET)** dengan database relational **PostgreSQL** (misalnya Supabase PostgreSQL) menggunakan driver **Npgsql**, konfigurasi berbasis file `appsettings.json`, arsitektur kode modular, serta pengisian data secara interaktif melalui kontrol **`DataGridView`**.

---

## 📁 Lokasi Proyek & File Utama
- **Folder Proyek**: `Pertemuan6-database/`
- **File Solusi**: `Pertemuan6-database.slnx`
- **File Konfigurasi**: [`appsettings.json`](file:///v:/Pemograman-Visual/Pertemuan6-database/appsettings.json)
- **Modul Koneksi**: [`ModDatabase.vb`](file:///v:/Pemograman-Visual/Pertemuan6-database/ModDatabase.vb)
- **Modul Helper Data**: [`ModFunction.vb`](file:///v:/Pemograman-Visual/Pertemuan6-database/ModFunction.vb)
- **Modul Query SQL**: [`ModQuery.vb`](file:///v:/Pemograman-Visual/Pertemuan6-database/ModQuery.vb)
- **Form Utama**: [`FormMahasiswa.vb`](file:///v:/Pemograman-Visual/Pertemuan6-database/FormMahasiswa.vb)

---

## 🧰 Kontrol Visual yang Digunakan

| Nama Kontrol | Tipe Kontrol | Fungsi / Peranan |
| :--- | :--- | :--- |
| `dgvMahasiswa` | `DataGridView` | Menampilkan seluruh data tabel mahasiswa dari database |
| `txtNama` | `TextBox` | Menerima input Nama Mahasiswa (Validasi khusus huruf) |
| `txtNim` | `TextBox` | Menerima input NIM Mahasiswa (Validasi khusus angka) |
| `txtJurusan` | `TextBox` | Menerima input Jurusan Mahasiswa |
| `btnTambah` | `Button` | Memproses penyimpanan data baru ke database PostgreSQL |
| `btnTampilkan` | `Button` | Memuat & menyegarkan (*refresh*) data pada DataGridView |

---

## 🏗️ Arsitektur Kode & Penjelasan Detail

Arsitektur aplikasi ini menerapkan pola **Modular Abstraction** untuk memisahkan tanggung jawab antara *User Interface (UI)*, *Query Execution*, *Database Helper*, dan *Configuration Management*.

### 1. Konfigurasi Connection String (`appsettings.json` & `ModDatabase.vb`)
Connection string database disimpan secara terpisah pada file JSON untuk menjaga kemudahan konfigurasi tanpa perlu melakukan re-compile aplikasi.

**`appsettings.json`**:
```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Host=<HOST>;Port=5432;Database=postgres;Username=<USER>;Password=<PASSWORD>;SSL Mode=Require;Trust Server Certificate=true"
  }
}
```

**`ModDatabase.vb`**:
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
            Using conn As New NpgsqlConnection(GetConnectionString())
                conn.Open()
                MessageBox.Show("Koneksi database berhasil")
            End Using
        Catch ex As Exception
            MessageBox.Show("Koneksi database gagal" & vbCrLf & ex.Message & "database")
        End Try
    End Sub
End Module
```
- **`ConfigurationBuilder`**: Membaca file `appsettings.json` dari folder output `BaseDirectory`.
- **`NpgsqlConnection`**: Mengelola pembukaan koneksi ke database PostgreSQL secara aman menggunakan pola `Using...End Using`.

---

### 2. General Helper Function (`ModFunction.vb`)
Menyediakan fungsi umum untuk mengeksekusi query `SELECT` maupun query manipulasi data (`INSERT`/`UPDATE`/`DELETE`) dengan *Parameterized Queries* guna mencegah ancaman **SQL Injection**.

```vb
Imports Npgsql
Imports System.Data

Module ModFunction
    ' Membaca Data (SELECT) dan mengembalikan DataTable
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

    ' Eksekusi Query Non-Query (INSERT/UPDATE/DELETE) dengan Parameter
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
            MessageBox.Show("Gagal mengeksekusi data:" & vbCrLf & ex.Message, "Error Database")
            Return False
        End Try
    End Function
End Module
```

---

### 3. Layer Query Spesifik (`ModQuery.vb`)
Menampung logika query spesifik untuk entitas `Mahasiswa`.

```vb
Imports System.Data

Module ModQuery
    Public Function TambahData(nim As String, nama As String, jurusan As String) As Boolean
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
        Return ModFunction.AmbilData("SELECT * FROM mahasiswa ORDER BY id ASC")
    End Function
End Module
```

---

### 4. User Interface Logic (`FormMahasiswa.vb`)
Form mengelola validasi input keyboard serta pemanggilan layer query.

```vb
Public Class FormMahasiswa
    ' Menampilkan Data ke DataGridView
    Private Sub btnTest_Click(sender As Object, e As EventArgs) Handles btnTampilkan.Click
        dgvMahasiswa.AutoGenerateColumns = True
        dgvMahasiswa.DataSource = ModQuery.TampilkanData()
    End Sub

    ' Menambah Data Mahasiswa Baru
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnTambah.Click
        If ModQuery.TambahData(txtNim.Text, txtNama.Text, txtJurusan.Text) Then
            MessageBox.Show("Data berhasil disimpan")
        End If

        txtJurusan.Clear()
        txtNama.Clear()
        txtNim.Clear()
    End Sub

    ' Validasi Nama: Hanya Huruf dan Tombol Kontrol
    Private Sub txtNama_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtNama.KeyPress
        If Not Char.IsControl(e.KeyChar) AndAlso Not Char.IsLetter(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    ' Validasi NIM: Hanya Angka dan Tombol Kontrol
    Private Sub txtNIM_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtNim.KeyPress
        If Not Char.IsControl(e.KeyChar) AndAlso Not Char.IsDigit(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub
End Class
```

---

## 🚀 Cara Menjalankan Proyek
1. **Prasyarat Database**: Pastikan tabel `mahasiswa` sudah dibuat pada PostgreSQL dengan struktur:
   ```sql
   CREATE TABLE mahasiswa (
       id SERIAL PRIMARY KEY,
       nim VARCHAR(20) NOT NULL,
       nama VARCHAR(100) NOT NULL,
       jurusan VARCHAR(50) NOT NULL
   );
   ```
2. **Koneksi Database**: Sesuaikan connection string pada file `appsettings.json`.
3. Buka `Pertemuan6-database.slnx` / `.sln` pada **Visual Studio 2022**.
4. Tekan **F5** untuk me-run aplikasi.
5. Klik **Tampilkan** untuk memuat data awal ke DataGridView, atau isikan **Nama**, **NIM**, dan **Jurusan** lalu klik **Tambah** untuk memasukkan data baru.
