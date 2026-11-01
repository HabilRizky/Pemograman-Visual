# Tugas Pertemuan 8 — Aplikasi Pengelolaan Inventaris Buku Perpustakaan

Proyek ini merupakan aplikasi **Windows Forms (VB.NET)** komprehensif untuk mengelola inventaris buku perpustakaan secara interaktif. Aplikasi mengimplementasikan arsitektur data binding tingkat lanjut menggunakan **`DataTable`**, **`BindingSource`**, dan **`DataGridView`**, dilengkapi dengan validasi input berlapis (**`ErrorProvider`**), penyaringan multi-kriteria (*multi-condition search & filter*), pengurutan data dinamis (*dynamic sorting*), serta rekapitulasi jumlah buku dan total stok fisik secara real-time.

---

## 📁 Lokasi Proyek & File Utama
- **Folder Proyek**: `InventarisBuku/`
- **File Solusi**: `InventarisBuku.sln` / `InventarisBuku.slnx`
- **File Proyek**: `InventarisBuku.vbproj`
- **Form Utama**: [`FrmInventaris.vb`](file:///v:/Pemograman-Visual/InventarisBuku/FrmInventaris.vb)
- **Modul Sanitasi Filter**: [`ModPencarian.vb`](file:///v:/Pemograman-Visual/InventarisBuku/ModPencarian.vb)
- **Modul Validasi Helper Umum**: [`ModValidasi.vb`](file:///v:/Pemograman-Visual/InventarisBuku/ModValidasi.vb)
- **Modul Validasi Kode Buku**: [`ModValidasiBuku.vb`](file:///v:/Pemograman-Visual/InventarisBuku/ModValidasiBuku.vb)
- **File Titik Masuk (Entry Point)**: [`Program.vb`](file:///v:/Pemograman-Visual/InventarisBuku/Program.vb)

---

## 🧰 Kontrol Visual yang Digunakan

| Nama Kontrol | Tipe Kontrol | Fungsi / Peranan |
| :--- | :--- | :--- |
| `txtKodeBuku` | `TextBox` | Input kode buku unik (format `BK` diikuti 4 digit angka, maks 6 karakter) |
| `txtJudul` | `TextBox` | Input judul buku perpustakaan (wajib diisi) |
| `txtPenulis` | `TextBox` | Input nama pengarang/penulis buku (wajib diisi) |
| `cboKategori` | `ComboBox` | Pilihan kategori koleksi (`Fiksi`, `Nonfiksi`, `Referensi`, `Majalah`) |
| `txtTahun` | `TextBox` | Input tahun terbit buku (rentang 1900 s.d. tahun sekarang) |
| `txtStok` | `TextBox` | Input kuantitas stok buku (angka $\ge 0$) |
| `btnTambah` | `Button` | Memvalidasi seluruh masukan dan menambahkan data buku baru ke DataTable |
| `btnBersihkan` | `Button` | Mengosongkan isian form dan menghapus indikator error |
| `txtCari` | `TextBox` | Kotak pencarian judul atau nama penulis secara instan |
| `cboFilterKategori` | `ComboBox` | Filter data grid berdasarkan kategori pilihan (`Semua`, `Fiksi`, dll) |
| `chkStokHabis` | `CheckBox` | Filter cepat hanya menampilkan buku dengan stok habis (`Stok = 0`) |
| `cboUrut` | `ComboBox` | Mengatur urutan tampilan data grid (*Judul ASC*, *Tahun DESC*, *Stok DESC*) |
| `dgvBuku` | `DataGridView` | Grid visual untuk menyajikan seluruh data buku |
| `lblJumlah` | `Label` | Menampilkan jumlah buku yang sedang tampil terhadap total buku |
| `lblTotalStok` | `Label` | Menampilkan akumulasi total stok fisik buku yang sedang tampil |
| `bsBuku` | `BindingSource` | Perantara antara `DataTable` dan `DataGridView` untuk filtering & sorting |
| `errBuku` | `ErrorProvider` | Menampilkan ikon peringatan dan tooltip pesan error di samping kontrol |

---

## 💻 Seluruh Kode Program (Full Code) & Penjelasan Lengkap

### 1. Form Utama ([`FrmInventaris.vb`](file:///v:/Pemograman-Visual/InventarisBuku/FrmInventaris.vb))

Berikut adalah kode sumber lengkap dari form inventaris:

```vb
Option Strict On

Public Class FrmInventaris
    Private tabelBuku As DataTable

    ' Membuat DataTable awal dengan minimal 10 buku, keempat kategori terwakili,
    ' dan minimal dua buku dengan stok 0.
    Private Function BuatTabelBuku() As DataTable
        Dim tabel As New DataTable("Buku")
        tabel.Columns.Add("KodeBuku", GetType(String))
        tabel.Columns.Add("Judul", GetType(String))
        tabel.Columns.Add("Penulis", GetType(String))
        tabel.Columns.Add("Kategori", GetType(String))
        tabel.Columns.Add("Tahun", GetType(Integer))
        tabel.Columns.Add("Stok", GetType(Integer))

        tabel.Rows.Add("BK0001", "Laskar Pelangi", "Andrea Hirata", "Fiksi", 2005, 8)
        tabel.Rows.Add("BK0002", "Bumi Manusia", "Pramoedya Ananta Toer", "Fiksi", 1980, 0)
        tabel.Rows.Add("BK0003", "Negeri 5 Menara", "Ahmad Fuadi", "Fiksi", 2009, 5)
        tabel.Rows.Add("BK0004", "Sapiens", "Yuval Noah Harari", "Nonfiksi", 2011, 6)
        tabel.Rows.Add("BK0005", "Atomic Habits", "James Clear", "Nonfiksi", 2018, 10)
        tabel.Rows.Add("BK0006", "Filosofi Teras", "Henry Manampiring", "Nonfiksi", 2018, 0)
        tabel.Rows.Add("BK0007", "Kamus Besar Bahasa Indonesia", "Badan Bahasa", "Referensi", 2016, 3)
        tabel.Rows.Add("BK0008", "Ensiklopedia Sains", "Tim Penulis", "Referensi", 2015, 2)
        tabel.Rows.Add("BK0009", "Panduan Skripsi Teknik Informatika", "USU Press", "Referensi", 2022, 4)
        tabel.Rows.Add("BK0010", "National Geographic Indonesia", "Redaksi Nat Geo", "Majalah", 2024, 7)
        tabel.Rows.Add("BK0011", "Tempo Edisi Khusus", "Redaksi Tempo", "Majalah", 2023, 0)
        tabel.Rows.Add("BK0012", "Intisari", "Redaksi Intisari", "Majalah", 2024, 5)

        Return tabel
    End Function

    Private Sub FrmInventaris_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        tabelBuku = BuatTabelBuku()
        bsBuku.DataSource = tabelBuku           ' DataTable -> BindingSource
        dgvBuku.DataSource = bsBuku             ' BindingSource -> DataGridView
        AturKolom()
        cboFilterKategori.SelectedIndex = 0     ' "Semua"
        cboUrut.SelectedIndex = 0                ' "Urutan awal"
        PerbaruiRingkasan()
    End Sub

    ' Merapikan judul kolom dan lebar/perataan kolom tertentu setelah grid terisi.
    Private Sub AturKolom()
        dgvBuku.Columns("KodeBuku").HeaderText = "Kode Buku"
        dgvBuku.Columns("Judul").FillWeight = 200
        dgvBuku.Columns("Tahun").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgvBuku.Columns("Stok").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgvBuku.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
    End Sub

    ' Memeriksa semua isian sekaligus. Mengembalikan True jika semuanya valid.
    Private Function ValidasiInput() As Boolean
        errBuku.Clear()
        Dim valid As Boolean = True
        Dim kodeNormalisasi As String = txtKodeBuku.Text.Trim().ToUpper()

        If Not KodeBukuValid(kodeNormalisasi) Then
            errBuku.SetError(txtKodeBuku, "Kode harus format BK diikuti 4 digit, contoh BK0012.")
            valid = False
        Else
            ' Memeriksa kode ganda dengan perulangan pada tabelBuku
            For Each baris As DataRow In tabelBuku.Rows
                If baris("KodeBuku").ToString() = kodeNormalisasi Then
                    errBuku.SetError(txtKodeBuku, "Kode buku sudah terdaftar.")
                    valid = False
                    Exit For
                End If
            Next
        End If

        If Kosong(txtJudul.Text) Then
            errBuku.SetError(txtJudul, "Judul wajib diisi.")
            valid = False
        End If

        If Kosong(txtPenulis.Text) Then
            errBuku.SetError(txtPenulis, "Penulis wajib diisi.")
            valid = False
        End If

        If cboKategori.SelectedIndex = -1 Then
            errBuku.SetError(cboKategori, "Pilih kategori terlebih dahulu.")
            valid = False
        End If

        Dim tahun As Integer
        If Not Integer.TryParse(txtTahun.Text, tahun) OrElse tahun < 1900 OrElse tahun > Date.Today.Year Then
            errBuku.SetError(txtTahun, "Tahun harus angka 1900 sampai tahun ini.")
            valid = False
        End If

        Dim stok As Integer
        If Not Integer.TryParse(txtStok.Text, stok) OrElse stok < 0 Then
            errBuku.SetError(txtStok, "Stok harus angka 0 atau lebih.")
            valid = False
        End If

        Return valid
    End Function

    ' Menambah satu buku baru ke tabelBuku jika semua isian valid.
    Private Sub btnTambah_Click(sender As Object, e As EventArgs) Handles btnTambah.Click
        If Not ValidasiInput() Then Return

        Dim kode As String = txtKodeBuku.Text.Trim().ToUpper()
        Dim tahun As Integer
        Integer.TryParse(txtTahun.Text, tahun)
        Dim stok As Integer
        Integer.TryParse(txtStok.Text, stok)

        tabelBuku.Rows.Add(kode, txtJudul.Text.Trim(), txtPenulis.Text.Trim(), cboKategori.Text, tahun, stok)
        PerbaruiRingkasan()
        BersihkanForm()
    End Sub

    Private Sub BersihkanForm()
        txtKodeBuku.Clear()
        txtJudul.Clear()
        txtPenulis.Clear()
        cboKategori.SelectedIndex = -1
        txtTahun.Clear()
        txtStok.Clear()
        errBuku.Clear()
        txtKodeBuku.Focus()
    End Sub

    Private Sub btnBersihkan_Click(sender As Object, e As EventArgs) Handles btnBersihkan.Click
        BersihkanForm()
    End Sub

    ' Menggabungkan syarat teks, kategori, dan stok habis menjadi satu ekspresi Filter.
    Private Sub TerapkanFilter()
        Dim kata As String = AmankanTeksFilter(txtCari.Text.Trim())
        Dim bagian As New List(Of String)

        If kata <> "" Then
            bagian.Add("(Judul LIKE '%" & kata & "%' OR Penulis LIKE '%" & kata & "%')")
        End If
        If cboFilterKategori.SelectedIndex > 0 Then     ' index 0 = "Semua"
            bagian.Add("Kategori = '" & cboFilterKategori.Text & "'")
        End If
        If chkStokHabis.Checked Then
            bagian.Add("Stok = 0")
        End If

        If bagian.Count = 0 Then
            bsBuku.RemoveFilter()
        Else
            bsBuku.Filter = String.Join(" AND ", bagian)
        End If
        PerbaruiRingkasan()
    End Sub

    Private Sub txtCari_TextChanged(sender As Object, e As EventArgs) Handles txtCari.TextChanged
        TerapkanFilter()
    End Sub

    Private Sub cboFilterKategori_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboFilterKategori.SelectedIndexChanged
        TerapkanFilter()
    End Sub

    Private Sub chkStokHabis_CheckedChanged(sender As Object, e As EventArgs) Handles chkStokHabis.CheckedChanged
        TerapkanFilter()
    End Sub

    ' Mengatur urutan tampilan grid lewat BindingSource.Sort (tantangan tambahan).
    Private Sub cboUrut_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboUrut.SelectedIndexChanged
        Select Case cboUrut.SelectedIndex
            Case 1
                bsBuku.Sort = "Judul ASC"
            Case 2
                bsBuku.Sort = "Tahun DESC"
            Case 3
                bsBuku.Sort = "Stok DESC"
            Case Else
                bsBuku.Sort = ""
        End Select
    End Sub

    ' Menghitung ulang lblJumlah dan lblTotalStok dari baris yang sedang tampil di grid.
    Private Sub PerbaruiRingkasan()
        Dim totalStok As Integer = 0
        For Each baris As DataGridViewRow In dgvBuku.Rows
            If Not baris.IsNewRow Then
                totalStok += CInt(baris.Cells("Stok").Value)
            End If
        Next
        lblJumlah.Text = "Menampilkan " & bsBuku.Count.ToString() & " dari " & tabelBuku.Rows.Count.ToString() & " buku"
        lblTotalStok.Text = "Total stok: " & totalStok.ToString()
    End Sub
End Class
```

#### Penjelasan Rinci Logika `FrmInventaris.vb`:
1. **`BuatTabelBuku()`**:
   - Membangun skema objek `DataTable("Buku")` lengkap dengan kolom bertipe strongly-typed (`String` untuk kode/judul/penulis/kategori, dan `Integer` untuk tahun/stok).
   - Memasukkan 12 data buku awal yang mencakup keempat kategori serta beberapa buku dengan stok `0` untuk keperluan pengujian filter stok habis.
2. **Data Binding (`FrmInventaris_Load`)**:
   - `bsBuku.DataSource = tabelBuku` menghubungkan DataTable ke BindingSource.
   - `dgvBuku.DataSource = bsBuku` menghubungkan BindingSource ke DataGridView.
   - Mengatur styling kolom lewat `AturKolom()`.
3. **Validasi Berlapis (`ValidasiInput`)**:
   - Kode Buku divalidasi formatnya (`KodeBukuValid`) dan dicek keunikannya terhadap seluruh baris `tabelBuku.Rows` agar tidak terjadi duplikasi.
   - Judul dan Penulis dicek dengan `Kosong()`.
   - Kategori wajib dipilih (`SelectedIndex <> -1`).
   - Tahun diuji `Integer.TryParse` dengan batasan `1900 <= tahun <= TahunIni`.
   - Stok diuji `Integer.TryParse` dan harus $\ge 0$.
   - Jika terdapat kegagalan, `errBuku.SetError()` menampilkan indikator merah di samping kontrol terkait.
4. **Penyaringan Multi-Kriteria (`TerapkanFilter`)**:
   - Menyatukan tiga kriteria filter yang berbeda:
     - Kata kunci pencarian judul atau penulis (`LIKE '%...%'`).
     - Pemilihan kategori spesifik (`Kategori = '...'`).
     - Filter stok habis (`Stok = 0`).
   - Ketiganya digabung secara dinamis menggunakan operator logika `AND` via `String.Join(" AND ", bagian)` dan dipasang ke properti `bsBuku.Filter`.
5. **Pengurutan Fleksibel (`cboUrut_SelectedIndexChanged`)**:
   - Memanfaatkan fitur `bsBuku.Sort`:
     - Index 1: Mengurutkan Judul secara alfabetis (`Judul ASC`).
     - Index 2: Mengurutkan Tahun terbit terbaru (`Tahun DESC`).
     - Index 3: Mengurutkan Stok terbanyak (`Stok DESC`).
6. **Kalkulasi Akumulasi Dinamis (`PerbaruiRingkasan`)**:
   - Menghitung ulang total buku yang sedang lolos filter (`bsBuku.Count`) dibandingkan dengan total data sebenarnya (`tabelBuku.Rows.Count`).
   - Melakukan iterasi sel `baris.Cells("Stok").Value` pada baris yang tampak di DataGridView untuk menjumlahkan total stok fisik buku yang tersedia.

---

### 2. Modul Sanitasi Filter ([`ModPencarian.vb`](file:///v:/Pemograman-Visual/InventarisBuku/ModPencarian.vb))

```vb
Option Strict On

' Fungsi bantu untuk BindingSource.Filter (disalin dari contoh di kelas)
Public Module ModPencarian

    ' Mengamankan karakter khusus agar tidak merusak ekspresi Filter.
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
- **Penjelasan**: Mencegah terjadinya error parsing ekspresi DataView/DataTable ketika pengguna mengetikkan tanda petik satu (`'`) atau karakter wildcard seperti `[`, `]`, `*`, dan `%`. Tanda petik digandakan (`''`) dan kurung siku membungkus karakter spesial.

---

### 3. Modul Validasi Helper ([`ModValidasi.vb`](file:///v:/Pemograman-Visual/InventarisBuku/ModValidasi.vb))

```vb
Option Strict On

Imports System.Globalization

' Kumpulan fungsi validasi yang bisa dipakai ulang oleh form mana pun
Public Module ModValidasi

    ' True jika teks kosong atau hanya berisi spasi
    Public Function Kosong(teks As String) As Boolean
        Return teks.Trim() = ""
    End Function

    ' True jika panjang teks tepat sesuai dan semua karakternya digit 0-9
    Public Function SemuaDigit(teks As String, panjang As Integer) As Boolean
        If teks.Length <> panjang Then Return False
        For Each karakter As Char In teks
            If karakter < "0"c OrElse karakter > "9"c Then Return False
        Next
        Return True
    End Function

    ' Mengubah teks desimal menjadi Decimal. Koma dan titik sama-sama diterima.
    Public Function CobaDesimal(teks As String, ByRef hasil As Decimal) As Boolean
        Dim teksTitik As String = teks.Trim().Replace(",", ".")
        Return Decimal.TryParse(teksTitik, NumberStyles.AllowDecimalPoint,
                                CultureInfo.InvariantCulture, hasil)
    End Function

End Module
```
- **Penjelasan**: Modul utilitas independen untuk validasi string kosong, validasi barisan digit numerik dengan panjang spesifik, serta konversi bilangan berkoma/titik.

---

### 4. Modul Validasi Kode Buku ([`ModValidasiBuku.vb`](file:///v:/Pemograman-Visual/InventarisBuku/ModValidasiBuku.vb))

```vb
Option Strict On

' Modul validasi khusus untuk format kode buku (disalin dari Pertemuan 7)
Public Module ModValidasiBuku

    ' Memeriksa apakah teks berformat "BK" diikuti tepat 4 digit angka.
    Public Function KodeBukuValid(kode As String) As Boolean
        Dim kodeUpper As String = kode.Trim().ToUpper()
        If kodeUpper.Length <> 6 Then Return False
        If Not kodeUpper.StartsWith("BK") Then Return False
        Return SemuaDigit(kodeUpper.Substring(2), 4)
    End Function

End Module
```
- **Penjelasan**: Memvalidasi kepatuhan format kode inventaris buku. Panjang wajib 6 karakter, diawali dengan string `"BK"`, dan 4 karakter sisanya wajib berupa digit angka (`0000` s.d. `9999`).

---

### 5. Titik Masuk Aplikasi ([`Program.vb`](file:///v:/Pemograman-Visual/InventarisBuku/Program.vb))

```vb
Imports System
Imports System.Windows.Forms

Module Program
    <STAThread>
    Sub Main()
        Application.EnableVisualStyles()
        Application.SetCompatibleTextRenderingDefault(False)
        Application.Run(New FrmInventaris())
    End Sub
End Module
```
- **Penjelasan**: Prosedur startup utama yang mengaktifkan gaya visual modern Windows Forms dan meluncurkan form `FrmInventaris`.

---

## 🚀 Cara Menjalankan Proyek
1. Buka file solusi `InventarisBuku.sln` atau `InventarisBuku.slnx` menggunakan **Microsoft Visual Studio 2022**.
2. Pastikan file startup terarah pada `FrmInventaris`.
3. Tekan tombol **F5** atau klik tombol **Start** untuk menjalankan aplikasi.
4. Uji fitur yang tersedia:
   - Ketikkan kata kunci pada kotak **Cari judul atau penulis...** untuk melihat filter teks instan.
   - Ubah combo box **Filter Kategori** untuk menyaring kategori buku tertentu.
   - Centang **Hanya stok habis** untuk memfilter buku yang stoknya `0`.
   - Pilih opsi pada combo box **Urutkan berdasarkan** untuk menguji pengurutan data.
   - Masukkan data buku baru lalu klik **Tambah** untuk menguji validasi dan pembaruan grid secara otomatis.
