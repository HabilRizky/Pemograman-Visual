# Pertemuan 8 — Data Binding & Visualisasi DataGridView

Proyek ini berfokus pada teknik **Penyajian, Pengikatan (*Data Binding*), dan Manipulasi Data** ke dalam kontrol **`DataGridView`** menggunakan bahasa Visual Basic .NET. Proyek mencakup 4 skenario implementasi: dari Array 2 Dimensi manual, Objek `List(Of T)`, Pencarian Dinamis, hingga arsitektur tingkat lanjut menggunakan `System.Data.DataTable` dan `BindingSource`.

---

## 📁 Lokasi Proyek & File Utama
- **Folder Proyek**: `DataMahasiswa/`
- **File Solusi**: `DataMahasiswa.slnx`
- **Entitas Objek Mahasiswa**: [`Mahasiswa.vb`](file:///v:/Pemograman-Visual/DataMahasiswa/Mahasiswa.vb)
- **Menu Navigasi Utama**: [`FrmUtama.vb`](file:///v:/Pemograman-Visual/DataMahasiswa/FrmUtama.vb)
- **1. Binding dari Array 2D**: [`FrmDariArray.vb`](file:///v:/Pemograman-Visual/DataMahasiswa/FrmDariArray.vb)
- **2. Binding dari List(Of Mahasiswa)**: [`FrmDariList.vb`](file:///v:/Pemograman-Visual/DataMahasiswa/FrmDariList.vb)
- **3. Pencarian Dinamis pada List**: [`FrmCariList.vb`](file:///v:/Pemograman-Visual/DataMahasiswa/FrmCariList.vb)
- **4. Binding DataTable & RowFilter**: [`FrmDataTable.vb`](file:///v:/Pemograman-Visual/DataMahasiswa/FrmDataTable.vb)
- **Modul Data Dummy**: [`ModDataContoh.vb`](file:///v:/Pemograman-Visual/DataMahasiswa/ModDataContoh.vb)
- **Modul Pengamanan Filter**: [`ModPencarian.vb`](file:///v:/Pemograman-Visual/DataMahasiswa/ModPencarian.vb)

---

## 🧰 Struktur Entitas Mahasiswa (`Mahasiswa.vb`)
Pola Objek (*POCO / Plain Old CLR Object*) digunakan untuk merepresentasikan satu entitas data mahasiswa:
```vb
Public Class Mahasiswa
    Public Property Nim As String
    Public Property Nama As String
    Public Property Jurusan As String
    Public Property Angkatan As Integer
    Public Property Ipk As Decimal

    Public Sub New(nim As String, nama As String, jurusan As String, angkatan As Integer, ipk As Decimal)
        Me.Nim = nim
        Me.Nama = nama
        Me.Jurusan = jurusan
        Me.Angkatan = angkatan
        Me.Ipk = ipk
    End Sub
End Class
```
*Catatan: Kontrol DataGridView membaca setiap `Public Property` sebagai satu kolom tabel secara otomatis saat di-bind.*

---

## 🔬 4 Skenario Pengikatan Data

### 1. Pengisian Manual dari Array 2D (`FrmDariArray.vb`)
Mengisi baris dan sel `DataGridView` secara berulang (*nested loop*) tanpa mekanisme binding otomatis:
```vb
dgvMahasiswa.Rows.Clear()
For i As Integer = 0 To dataMahasiswa.GetUpperBound(0)          ' Loop baris
    Dim indeksBaris As Integer = dgvMahasiswa.Rows.Add()
    For j As Integer = 0 To dataMahasiswa.GetUpperBound(1)      ' Loop kolom
        dgvMahasiswa.Rows(indeksBaris).Cells(j).Value = dataMahasiswa(i, j)
    Next
Next
```
- **Kelebihan**: Sederhana untuk data statis berukuran kecil.
- **Kekurangan**: Tidak fleksibel terhadap perubahan tipe data dan membutuhkan perulangan manual.

---

### 2. Binding Koleksi Objek `List(Of Mahasiswa)` (`FrmDariList.vb`)
Memanfaatkan perantara `BindingSource` agar grid terhubung secara responsif dengan daftar objek:
```vb
bsMahasiswa.DataSource = daftarMahasiswa        ' List -> BindingSource
dgvMahasiswa.DataSource = bsMahasiswa           ' BindingSource -> DataGridView
```
- **Penambahan Data Responsif**:
  ```vb
  Dim baru As New Mahasiswa(txtNim.Text, txtNama.Text.Trim(), cboJurusan.Text,
                            Integer.Parse(txtAngkatan.Text), ipk)
  bsMahasiswa.Add(baru) ' Menambah lewat BindingSource agar grid langsung ter-refresh otomatis
  ```
- Dilengkapi validasi form lengkap menggunakan `ErrorProvider` (`SemuaDigit`, cek keunikan NIM, angkatan, dan rentang IPK).

---

### 3. Pencarian Dinamis pada List (`FrmCariList.vb`)
Karena `List(Of T)` tidak mendukung ekspresi string filter bawaan pada `BindingSource`, pencarian dilakukan dengan perulangan pada event `TextChanged`:
```vb
Private Sub txtCari_TextChanged(sender As Object, e As EventArgs) Handles txtCari.TextChanged
    Dim kata As String = txtCari.Text.Trim().ToLower()
    Dim hasil As New List(Of Mahasiswa)
    For Each mhs As Mahasiswa In daftarMahasiswa
        If mhs.Nama.ToLower().Contains(kata) OrElse mhs.Nim.Contains(kata) Then
            hasil.Add(mhs)
        End If
    Next
    bsMahasiswa.DataSource = hasil
    lblJumlah.Text = "Menampilkan " & hasil.Count.ToString() & " dari " & daftarMahasiswa.Count.ToString() & " data"
End Sub
```

---

### 4. Tingkat Lanjut: `System.Data.DataTable` & Filter Cepat (`FrmDataTable.vb`)
Menggunakan arsitektur relasional `DataTable` yang sangat optimal untuk integrasi database dan filtering instan:
- **Konfigurasi Kolom & Data**:
  ```vb
  Dim tabel As New DataTable("Mahasiswa")
  tabel.Columns.Add("Nim", GetType(String))
  tabel.Columns.Add("Nama", GetType(String))
  tabel.Columns.Add("Jurusan", GetType(String))
  tabel.Columns.Add("Angkatan", GetType(Integer))
  tabel.Columns.Add("Ipk", GetType(Decimal))
  ```
- **Filtering Real-Time melalui `BindingSource.Filter`**:
  ```vb
  Dim kata As String = txtCari.Text.Trim()
  ' Sanitasi karakter khusus agar tidak merusak parser DataView
  kata = kata.Replace("'", "''").Replace("[", "[[]").Replace("%", "[%]").Replace("*", "[*]")

  If kata = "" Then
      bsMahasiswa.RemoveFilter()
  Else
      bsMahasiswa.Filter = "Nama LIKE '%" & kata & "%' OR Nim LIKE '%" & kata & "%'"
  End If
  ```
- **Formatting Tampilan Sel**:
  - Kolom IPK diformat 2 desimal: `dgvMahasiswa.Columns("Ipk").DefaultCellStyle.Format = "N2"`
  - Perataan angka ke kanan: `DataGridViewContentAlignment.MiddleRight`
  - Perataan tahun angkatan ke tengah: `DataGridViewContentAlignment.MiddleCenter`
  - Tata letak lebar kolom adaptif: `AutoSizeColumnsMode = Fill`

---

## 🚀 Cara Menjalankan Proyek
1. Buka solusi `DataMahasiswa.slnx` pada **Visual Studio 2022**.
2. Jalankan aplikasi dengan menekan tombol **F5**.
3. Pada form menu utama, Anda dapat membuka:
   - **Tampilkan dari Array**: Simulasi pengisian baris/sel grid secara manual.
   - **Tampilkan dari List**: Input data mahasiswa baru dan binding objek via `BindingSource`.
   - **Pencarian pada List**: Filter real-time pada koleksi objek generik.
   - **DataTable & Filter**: Binding tabel `System.Data`, format kolom rapi, dan filter instan menggunakan sintaks ekspresi `LIKE`.
