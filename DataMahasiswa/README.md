# Pertemuan 8 — Data Binding & Visualisasi DataGridView

Proyek ini berfokus pada teknik **Penyajian, Pengikatan (*Data Binding*), dan Manipulasi Data** ke dalam kontrol **`DataGridView`** menggunakan bahasa Visual Basic .NET. Proyek mencakup 4 skenario implementasi mendalam: dari Array 2 Dimensi manual, Koleksi Objek Generik `List(Of T)`, Pencarian Dinamis pada List, hingga arsitektur tingkat lanjut menggunakan `System.Data.DataTable`, `BindingSource`, dan ekspresi filter `LIKE`.

---

## 📁 Lokasi Proyek & File Utama
- **Folder Proyek**: `DataMahasiswa/`
- **File Solusi**: `DataMahasiswa.slnx`
- **File Proyek**: `DataMahasiswa.vbproj`
- **Entitas Objek Mahasiswa**: [`Mahasiswa.vb`](file:///v:/Pemograman-Visual/DataMahasiswa/Mahasiswa.vb)
- **Menu Navigasi Utama**: [`FrmUtama.vb`](file:///v:/Pemograman-Visual/DataMahasiswa/FrmUtama.vb)
- **Form 1 (Binding dari Array 2D)**: [`FrmDariArray.vb`](file:///v:/Pemograman-Visual/DataMahasiswa/FrmDariArray.vb)
- **Form 2 (Binding dari List Objek)**: [`FrmDariList.vb`](file:///v:/Pemograman-Visual/DataMahasiswa/FrmDariList.vb)
- **Form 3 (Pencarian Dinamis pada List)**: [`FrmCariList.vb`](file:///v:/Pemograman-Visual/DataMahasiswa/FrmCariList.vb)
- **Form 4 (Binding DataTable & Filter)**: [`FrmDataTable.vb`](file:///v:/Pemograman-Visual/DataMahasiswa/FrmDataTable.vb)
- **Modul Data Dummy**: [`ModDataContoh.vb`](file:///v:/Pemograman-Visual/DataMahasiswa/ModDataContoh.vb)
- **Modul Pengamanan Filter**: [`ModPencarian.vb`](file:///v:/Pemograman-Visual/DataMahasiswa/ModPencarian.vb)
- **Modul Validasi Helper**: [`ModValidasi.vb`](file:///v:/Pemograman-Visual/DataMahasiswa/ModValidasi.vb)
- **Titik Masuk Program**: [`Program.vb`](file:///v:/Pemograman-Visual/DataMahasiswa/Program.vb)

---

## 💻 Seluruh Kode Program (Full Code) & Penjelasan Lengkap

### 1. Entitas Model Mahasiswa ([`Mahasiswa.vb`](file:///v:/Pemograman-Visual/DataMahasiswa/Mahasiswa.vb))

```vb
Option Strict On

' Satu objek Mahasiswa mewakili satu baris data.
' DataGridView membaca setiap Public Property sebagai satu kolom.
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
- **Penjelasan**: Entitas POCO (*Plain Old CLR Object*). Ketika sebuah koleksi objek `List(Of Mahasiswa)` diikat ke `DataGridView`, komponen tersebut secara otomatis membaca setiap `Public Property` sebagai sebuah kolom tabel.

---

### 2. Modul Penyedia Data Contoh ([`ModDataContoh.vb`](file:///v:/Pemograman-Visual/DataMahasiswa/ModDataContoh.vb))

```vb
Option Strict On

Public Module ModDataContoh
    ' Membuat daftar baru agar data tiap form tetap terpisah.
    Public Function BuatDaftarMahasiswa() As List(Of Mahasiswa)
        Dim daftar As New List(Of Mahasiswa)
        daftar.Add(New Mahasiswa("231712001", "Andi Pratama", "Teknik Informatika", 2023, 3.45D))
        daftar.Add(New Mahasiswa("231712002", "Sari Wulandari", "Sistem Informasi", 2023, 3.8D))
        daftar.Add(New Mahasiswa("221712015", "Budi Santoso", "Teknik Informatika", 2022, 3.12D))
        daftar.Add(New Mahasiswa("241712007", "Dimas Siregar", "Teknik Komputer", 2024, 2.95D))
        daftar.Add(New Mahasiswa("221712020", "Rina Marpaung", "Manajemen Informatika", 2022, 3.5D))
        daftar.Add(New Mahasiswa("241712011", "Putri Lubis", "Sistem Informasi", 2024, 3.91D))
        daftar.Add(New Mahasiswa("231712019", "Fajar Nasution", "Teknik Informatika", 2023, 3.28D))
        daftar.Add(New Mahasiswa("221712031", "Maya Sari Hasibuan", "Teknik Komputer", 2022, 3.55D))
        Return daftar
    End Function
End Module
```
- **Penjelasan**: Menyediakan fungsi `BuatDaftarMahasiswa()` yang mengembalikan instance baru `List(Of Mahasiswa)` agar modifikasi data di satu form tidak merusak data form lainnya.

---

### 3. Modul Pengamanan Filter Teks ([`ModPencarian.vb`](file:///v:/Pemograman-Visual/DataMahasiswa/ModPencarian.vb))

```vb
Option Strict On

' Fungsi bantu untuk BindingSource.Filter
Public Module ModPencarian

    ' Mengamankan karakter khusus agar tidak merusak ekspresi Filter.
    ' Kutip tunggal digandakan; [ ] * % dibungkus kurung siku.
    Public Function AmankanTeksFilter(teks As String) As String
        Dim hasil As String = ""
        For Each karakter As Char In teks
            Select Case karakter
                Case "'"c
                    hasil &= "''"
                Case "["c, "]"c, "*"c, "%"c
                    hasil &= "[" & karakter & "]"
                Case Else
                    hasil &= karakter
            End Select
        Next
        Return hasil
    End Function

End Module
```
- **Penjelasan**: Mensanitasi string input sebelum digunakan dalam ekspresi filter `DataView` agar karakter kutip (`'`) dan wildcard tidak menyebabkan syntax error.

---

### 4. Menu Utama Navigasi ([`FrmUtama.vb`](file:///v:/Pemograman-Visual/DataMahasiswa/FrmUtama.vb))

```vb
Option Strict On

Public Class FrmUtama

    Private Sub btnDariArray_Click(sender As Object, e As EventArgs) Handles btnDariArray.Click
        Dim frm As New FrmDariArray()
        frm.ShowDialog()
    End Sub

    Private Sub btnDariList_Click(sender As Object, e As EventArgs) Handles btnDariList.Click
        Dim frm As New FrmDariList()
        frm.ShowDialog()
    End Sub

    Private Sub btnDataTable_Click(sender As Object, e As EventArgs) Handles btnDataTable.Click
        Dim frm As New FrmDataTable()
        frm.ShowDialog()
    End Sub

    Private Sub btnCariList_Click(sender As Object, e As EventArgs) Handles btnCariList.Click
        Dim frm As New FrmCariList()
        frm.ShowDialog()
    End Sub

End Class
```
- **Penjelasan**: Menyediakan tombol untuk membuka masing-masing form demonstrasi secara dialog modal.

---

### 5. Form 1: Pengisian dari Array 2D ([`FrmDariArray.vb`](file:///v:/Pemograman-Visual/DataMahasiswa/FrmDariArray.vb))

```vb
Option Strict On

Public Class FrmDariArray
    ' Array 2 dimensi: dimensi pertama = baris (mahasiswa).
    ' Dimensi kedua = kolom (NIM, Nama, Jurusan, Angkatan, IPK).
    Private ReadOnly dataMahasiswa(,) As String = {
        {"231712001", "Andi Pratama", "Teknik Informatika", "2023", "3.45"},
        {"231712002", "Sari Wulandari", "Sistem Informasi", "2023", "3.8"},
        {"221712015", "Budi Santoso", "Teknik Informatika", "2022", "3.12"},
        {"241712007", "Dimas Siregar", "Teknik Komputer", "2024", "2.95"},
        {"221712020", "Rina Marpaung", "Manajemen Informatika", "2022", "3.5"},
        {"241712011", "Putri Lubis", "Sistem Informasi", "2024", "3.91"},
        {"231712019", "Fajar Nasution", "Teknik Informatika", "2023", "3.28"},
        {"221712031", "Maya Sari Hasibuan", "Teknik Komputer", "2022", "3.55"}
    }

    Private Sub btnTampilkan_Click(sender As Object, e As EventArgs) Handles btnTampilkan.Click
        dgvMahasiswa.Rows.Clear()
        For i As Integer = 0 To dataMahasiswa.GetUpperBound(0)          ' baris
            Dim indeksBaris As Integer = dgvMahasiswa.Rows.Add()
            For j As Integer = 0 To dataMahasiswa.GetUpperBound(1)      ' kolom
                dgvMahasiswa.Rows(indeksBaris).Cells(j).Value = dataMahasiswa(i, j)
            Next
        Next
        lblJumlah.Text = "Jumlah data: " & dgvMahasiswa.Rows.Count.ToString()
    End Sub

    Private Sub btnKosongkan_Click(sender As Object, e As EventArgs) Handles btnKosongkan.Click
        dgvMahasiswa.Rows.Clear()
        lblJumlah.Text = "Jumlah data: 0"
    End Sub
End Class
```
- **Penjelasan**: Menggunakan nested loop `GetUpperBound(0)` dan `GetUpperBound(1)` untuk menambahkan baris dengan `dgvMahasiswa.Rows.Add()` dan mengisi sel `Cells(j).Value` secara manual dari Array 2D.

---

### 6. Form 2: Binding Objek `List(Of Mahasiswa)` ([`FrmDariList.vb`](file:///v:/Pemograman-Visual/DataMahasiswa/FrmDariList.vb))

```vb
Option Strict On

Public Class FrmDariList
    Private ReadOnly daftarMahasiswa As New List(Of Mahasiswa)

    Private Sub FrmDariList_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        daftarMahasiswa.Add(New Mahasiswa("231712001", "Andi Pratama", "Teknik Informatika", 2023, 3.45D))
        daftarMahasiswa.Add(New Mahasiswa("231712002", "Sari Wulandari", "Sistem Informasi", 2023, 3.8D))
        daftarMahasiswa.Add(New Mahasiswa("221712015", "Budi Santoso", "Teknik Informatika", 2022, 3.12D))
        daftarMahasiswa.Add(New Mahasiswa("241712007", "Dimas Siregar", "Teknik Komputer", 2024, 2.95D))

        bsMahasiswa.DataSource = daftarMahasiswa        ' List -> BindingSource
        dgvMahasiswa.DataSource = bsMahasiswa           ' BindingSource -> DataGridView
        lblJumlah.Text = "Jumlah data: " & bsMahasiswa.Count.ToString()
    End Sub

    Private Sub btnTambah_Click(sender As Object, e As EventArgs) Handles btnTambah.Click
        If Not ValidasiInput() Then Return
        Dim ipk As Decimal
        CobaDesimal(txtIpk.Text, ipk)
        Dim baru As New Mahasiswa(txtNim.Text, txtNama.Text.Trim(), cboJurusan.Text,
                                  Integer.Parse(txtAngkatan.Text), ipk)
        ' Tambah lewat BindingSource, bukan daftarMahasiswa.Add, agar grid langsung diperbarui
        bsMahasiswa.Add(baru)
        lblJumlah.Text = "Jumlah data: " & bsMahasiswa.Count.ToString()
        BersihkanInput()
    End Sub

    ' Periksa semua isian dan tampilkan kesalahan di samping kontrol.
    Private Function ValidasiInput() As Boolean
        errInput.Clear()
        Dim valid As Boolean = True
        Dim angkatan As Integer
        Dim ipk As Decimal

        If Not SemuaDigit(txtNim.Text, 9) Then
            errInput.SetError(txtNim, "NIM harus terdiri dari 9 digit.")
            valid = False
        Else
            For Each mhs As Mahasiswa In daftarMahasiswa
                If mhs.Nim = txtNim.Text Then
                    errInput.SetError(txtNim, "NIM sudah terdaftar.")
                    valid = False
                    Exit For
                End If
            Next
        End If
        If Kosong(txtNama.Text) Then
            errInput.SetError(txtNama, "Nama wajib diisi.")
            valid = False
        End If
        If cboJurusan.SelectedIndex = -1 Then
            errInput.SetError(cboJurusan, "Pilih jurusan terlebih dahulu.")
            valid = False
        End If
        If Not Integer.TryParse(txtAngkatan.Text, angkatan) OrElse
            angkatan < 2015 OrElse angkatan > Date.Today.Year Then
            errInput.SetError(txtAngkatan, "Angkatan harus antara 2015 dan tahun ini.")
            valid = False
        End If
        If Not CobaDesimal(txtIpk.Text, ipk) OrElse ipk < 0D OrElse ipk > 4D Then
            errInput.SetError(txtIpk, "IPK harus berupa angka antara 0 dan 4.")
            valid = False
        End If
        Return valid
    End Function

    Private Sub BersihkanInput()
        txtNim.Clear()
        txtNama.Clear()
        cboJurusan.SelectedIndex = -1
        txtAngkatan.Clear()
        txtIpk.Clear()
        errInput.Clear()
        txtNim.Focus()
    End Sub
End Class
```
- **Penjelasan**: Menghubungkan koleksi objek ke `BindingSource`. Kunci utamanya adalah menambahkan item baru melalui **`bsMahasiswa.Add(baru)`**, bukan `daftarMahasiswa.Add(baru)`, sehingga grid langsung ter-refresh secara otomatis tanpa perlu re-binding.

---

### 7. Form 3: Pencarian Dinamis pada List ([`FrmCariList.vb`](file:///v:/Pemograman-Visual/DataMahasiswa/FrmCariList.vb))

```vb
Option Strict On

Public Class FrmCariList
    Private daftarMahasiswa As List(Of Mahasiswa)

    Private Sub FrmCariList_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        daftarMahasiswa = BuatDaftarMahasiswa()
        bsMahasiswa.DataSource = daftarMahasiswa
        dgvMahasiswa.DataSource = bsMahasiswa
        lblJumlah.Text = "Menampilkan " & daftarMahasiswa.Count.ToString() & " data"
    End Sub

    ' List(Of T) tidak mendukung BindingSource.Filter, jadi pencarian dilakukan dengan perulangan
    Private Sub txtCari_TextChanged(sender As Object, e As EventArgs) Handles txtCari.TextChanged
        Dim kata As String = txtCari.Text.Trim().ToLower()
        Dim hasil As New List(Of Mahasiswa)
        For Each mhs As Mahasiswa In daftarMahasiswa
            If mhs.Nama.ToLower().Contains(kata) OrElse mhs.Nim.Contains(kata) Then
                hasil.Add(mhs)
            End If
        Next
        bsMahasiswa.DataSource = hasil
        lblJumlah.Text = "Menampilkan " & hasil.Count.ToString() & " dari " &
                         daftarMahasiswa.Count.ToString() & " data"
    End Sub
End Class
```
- **Penjelasan**: Karena koleksi generik `List(Of T)` tidak mendukung properti `.Filter` bawaan dari `BindingSource`, pencarian dilakukan dengan memfilter objek dalam perulangan lalu menyetel ulang `bsMahasiswa.DataSource = hasil`.

---

### 8. Form 4: Binding Tingkat Lanjut DataTable & Filter ([`FrmDataTable.vb`](file:///v:/Pemograman-Visual/DataMahasiswa/FrmDataTable.vb))

```vb
Option Strict On

Public Class FrmDataTable

    Private tabelMahasiswa As System.Data.DataTable

    Private Function BuatTabelMahasiswa() As System.Data.DataTable
        Dim tabel As New System.Data.DataTable("Mahasiswa")

        ' Membuat kolom dan tipe data
        tabel.Columns.Add("Nim", GetType(String))
        tabel.Columns.Add("Nama", GetType(String))
        tabel.Columns.Add("Jurusan", GetType(String))
        tabel.Columns.Add("Angkatan", GetType(Integer))
        tabel.Columns.Add("Ipk", GetType(Decimal))

        ' Mengisi data mahasiswa
        tabel.Rows.Add("231712001", "Andi Pratama", "Teknik Informatika", 2023, 3.45D)
        tabel.Rows.Add("231712002", "Sari Wulandari", "Sistem Informasi", 2023, 3.8D)
        tabel.Rows.Add("221712015", "Budi Santoso", "Teknik Informatika", 2022, 3.12D)
        tabel.Rows.Add("241712007", "Dimas Siregar", "Teknik Komputer", 2024, 2.95D)
        tabel.Rows.Add("221712020", "Rina Marpaung", "Manajemen Informatika", 2022, 3.5D)
        tabel.Rows.Add("241712011", "Putri Lubis", "Sistem Informasi", 2024, 3.91D)
        tabel.Rows.Add("231712019", "Fajar Nasution", "Teknik Informatika", 2023, 3.28D)
        tabel.Rows.Add("221712031", "Maya Sari Hasibuan", "Teknik Komputer", 2022, 3.55D)

        Return tabel
    End Function

    Private Sub FrmDataTable_Load(
        sender As Object,
        e As System.EventArgs
    ) Handles MyBase.Load

        tabelMahasiswa = BuatTabelMahasiswa()

        ' Menghubungkan DataTable ke BindingSource
        bsMahasiswa.DataSource = tabelMahasiswa

        ' Menghubungkan BindingSource ke DataGridView
        dgvMahasiswa.DataSource = bsMahasiswa

        AturKolom()
        PerbaruiJumlah()

    End Sub

    Private Sub PerbaruiJumlah()

        If tabelMahasiswa Is Nothing Then Return

        lblJumlah.Text = "Menampilkan " &
                         bsMahasiswa.Count.ToString() &
                         " dari " &
                         tabelMahasiswa.Rows.Count.ToString() &
                         " data"

    End Sub

    ' Mengatur tampilan kolom DataGridView
    Private Sub AturKolom()

        If dgvMahasiswa.Columns.Count = 0 Then Return

        dgvMahasiswa.Columns("Nim").HeaderText = "NIM"
        dgvMahasiswa.Columns("Nama").HeaderText = "Nama"
        dgvMahasiswa.Columns("Jurusan").HeaderText = "Jurusan"
        dgvMahasiswa.Columns("Angkatan").HeaderText = "Angkatan"
        dgvMahasiswa.Columns("Ipk").HeaderText = "IPK"

        dgvMahasiswa.Columns("Ipk").DefaultCellStyle.Format = "N2"

        dgvMahasiswa.Columns("Ipk").DefaultCellStyle.Alignment =
            System.Windows.Forms.DataGridViewContentAlignment.MiddleRight

        dgvMahasiswa.Columns("Angkatan").DefaultCellStyle.Alignment =
            System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter

        dgvMahasiswa.Columns("Nama").FillWeight = 200

        dgvMahasiswa.AutoSizeColumnsMode =
            System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill

    End Sub

    ' Tombol untuk merapikan kolom
    Private Sub btnRapikan_Click(
        sender As Object,
        e As System.EventArgs
    ) Handles btnRapikan.Click

        AturKolom()

    End Sub

    ' Pencarian berdasarkan nama atau NIM
    Private Sub txtCari_TextChanged(
        sender As Object,
        e As System.EventArgs
    ) Handles txtCari.TextChanged

        Dim kata As String = txtCari.Text.Trim()

        ' Mengamankan tanda kutip untuk ekspresi DataView.RowFilter
        kata = kata.Replace("'", "''")
        kata = kata.Replace("[", "[[]")
        kata = kata.Replace("%", "[%]")
        kata = kata.Replace("*", "[*]")

        If kata = "" Then
            bsMahasiswa.RemoveFilter()
        Else
            bsMahasiswa.Filter =
                "Nama LIKE '%" & kata &
                "%' OR Nim LIKE '%" & kata & "%'"
        End If

        PerbaruiJumlah()

    End Sub

End Class
```
- **Penjelasan**:
  - Menggunakan `DataTable` yang kompatibel penuh dengan `BindingSource.Filter`.
  - Format angka IPK diformat 2 desimal melalui `DefaultCellStyle.Format = "N2"` dan perataan ke kanan (`MiddleRight`).
  - Kolom angkatan diratakan ke tengah (`MiddleCenter`).
  - Filter teks menggunakan ekspresi SQL `LIKE` langsung pada properti `bsMahasiswa.Filter`.

---

## 🚀 Cara Menjalankan Proyek
1. Buka file solusi `DataMahasiswa.slnx` di **Microsoft Visual Studio 2022**.
2. Jalankan aplikasi dengan menekan **F5**.
3. Pilih menu yang diinginkan untuk mengamati perbedaan perilaku teknis antara Array 2D, List Objek, Pencarian Dinamis, dan Data Binding tingkat lanjut DataTable.
