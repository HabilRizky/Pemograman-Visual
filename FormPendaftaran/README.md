# Pertemuan 7 — Validasi Input, ErrorProvider, & Konversi Tipe Data

Proyek ini berfokus pada pengimplementasian sistem **Validasi Input Berlapis** pada Windows Forms (VB.NET) menggunakan komponen **`ErrorProvider`**, pencegahan duplikasi data (*duplicate entry prevention*), penulisan file eksternal (**Ekspor CSV**), serta studi komparasi penanganan dan konversi tipe data (*Type Conversion & Exception Handling*).

---

## 📁 Lokasi Proyek & File Utama
- **Folder Proyek**: `FormPendaftaran/`
- **File Solusi**: `FormPendaftaran.slnx`
- **File Proyek**: `FormPendaftaran.vbproj`
- **Form Menu Utama**: [`FrmUtama.vb`](file:///v:/Pemograman-Visual/FormPendaftaran/FrmUtama.vb)
- **Form Pendaftaran Mahasiswa**: [`FrmPendaftaran.vb`](file:///v:/Pemograman-Visual/FormPendaftaran/FrmPendaftaran.vb)
- **Form Uji Konversi & Eksepsi**: [`FrmUjiKonversi.vb`](file:///v:/Pemograman-Visual/FormPendaftaran/FrmUjiKonversi.vb)
- **Modul Validasi Helper**: [`ModValidasi.vb`](file:///v:/Pemograman-Visual/FormPendaftaran/ModValidasi.vb)

---

## 🧰 Kontrol Visual yang Digunakan

### 1. Form Pendaftaran Mahasiswa (`FrmPendaftaran`)
| Nama Kontrol | Tipe Kontrol | Fungsi / Peranan |
| :--- | :--- | :--- |
| `txtNim` | `TextBox` | Menerima input NIM (wajib 9 digit angka & unik) |
| `txtNama` | `TextBox` | Menerima input Nama Mahasiswa (tidak boleh kosong/spasi) |
| `txtAngkatan` | `TextBox` | Menerima input tahun angkatan (2015 s.d. tahun sekarang) |
| `txtIpk` | `TextBox` | Menerima input IPK (0.00 s.d. 4.00, mendukung format koma/titik) |
| `cboJurusan` | `ComboBox` | Pilihan program studi / jurusan |
| `btnSimpan` | `Button` | Memvalidasi seluruh isian form dan menyimpan ke ListBox |
| `btnEkspor` | `Button` | Mengekspor seluruh data pendaftar ke file format CSV |
| `btnBersihkan` | `Button` | Mengosongkan form dan menghapus indikator error |
| `lstMahasiswa` | `ListBox` | Menampilkan baris data mahasiswa yang telah terdaftar |
| `errInput` | `ErrorProvider` | Menampilkan ikon peringatan & pesan error di sisi kontrol input |
| `lblStatus` | `Label` | Menampilkan status proses dan informasi penyimpanan |

### 2. Form Uji Konversi Tipe Data (`FrmUjiKonversi`)
| Nama Kontrol | Tipe Kontrol | Fungsi / Peranan |
| :--- | :--- | :--- |
| `txtInput` | `TextBox` | Kotak masukan teks yang akan diuji konversi |
| `btnCInt` | `Button` | Menguji fungsi konversi bawaan `CInt()` |
| `btnVal` | `Button` | Menguji fungsi konversi bawaan `Val()` |
| `btnTryParse` | `Button` | Menguji konversi aman tanpa eksepsi `Integer.TryParse()` |
| `btnTryCatch` | `Button` | Menguji konversi berpelindung `Try...Catch` |
| `btnCatchBertingkat` | `Button` | Menguji penanganan eksepsi bertingkat (`FormatException`, `OverflowException`, `DivideByZeroException`) |
| `lblHasil` | `Label` | Menampilkan hasil konversi atau pesan error eksepsi |

---

## 💻 Seluruh Kode Program (Full Code) & Penjelasan Lengkap

### 1. Modul Validasi Helper ([`ModValidasi.vb`](file:///v:/Pemograman-Visual/FormPendaftaran/ModValidasi.vb))

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

    ' Mengubah teks desimal menjadi Decimal. Koma dan titik sama-sama diterima,
    ' sehingga hasilnya tidak bergantung pada pengaturan bahasa Windows.
    Public Function CobaDesimal(teks As String, ByRef hasil As Decimal) As Boolean
        Dim teksTitik As String = teks.Trim().Replace(",", ".")
        Return Decimal.TryParse(teksTitik, NumberStyles.AllowDecimalPoint,
                                CultureInfo.InvariantCulture, hasil)
    End Function

End Module
```
- **Penjelasan**:
  - `Option Strict On`: Memaksa penulisan kode dengan tipe data yang ketat (*type-safe*).
  - `Kosong`: Memeriksa apakah teks hanya berisi spasi kosong via `.Trim() = ""`.
  - `SemuaDigit`: Memastikan panjang karakter sesuai dan tiap karakter berada pada rentang `'0'c` hingga `'9'c`.
  - `CobaDesimal`: Menggantikan koma dengan titik dan menggunakan `CultureInfo.InvariantCulture` sehingga input desimal seperti `3,75` maupun `3.75` tetap valid terlepas dari konfigurasi regional Windows.

---

### 2. Form Pendaftaran Mahasiswa ([`FrmPendaftaran.vb`](file:///v:/Pemograman-Visual/FormPendaftaran/FrmPendaftaran.vb))

```vb
Option Strict On

Imports System.ComponentModel
Imports System.IO

Public Class FrmPendaftaran

    Private ReadOnly daftarNim As New List(Of String)


    Private ReadOnly lokasiEkspor As String =
        Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
                     "data-mahasiswa.csv")


    Private Function ValidasiInput() As Boolean
        errInput.Clear()
        Dim valid As Boolean = True

        If Kosong(txtNama.Text) Then
            errInput.SetError(txtNama, "Nama wajib diisi.")
            valid = False
        End If

        Dim angkatan As Integer
        If Not Integer.TryParse(txtAngkatan.Text, angkatan) OrElse
           angkatan < 2015 OrElse angkatan > Date.Today.Year Then
            errInput.SetError(txtAngkatan, "Angkatan harus angka 2015 s.d. tahun ini.")
            valid = False
        End If

        If Not SemuaDigit(txtNim.Text, 9) Then
            errInput.SetError(txtNim, "NIM harus 9 digit angka.")
            valid = False
        ElseIf daftarNim.Contains(txtNim.Text) Then
            errInput.SetError(txtNim, "NIM sudah terdaftar.")
            valid = False
        End If

        If cboJurusan.SelectedIndex = -1 Then
            errInput.SetError(cboJurusan, "Pilih salah satu jurusan.")
            valid = False
        End If

        Dim ipk As Decimal
        If Not CobaDesimal(txtIpk.Text, ipk) OrElse ipk < 0D OrElse ipk > 4D Then
            errInput.SetError(txtIpk, "IPK harus angka 0,00 s.d. 4,00.")
            valid = False
        End If

        Return valid
    End Function

    Private Sub btnSimpan_Click(sender As Object, e As EventArgs) Handles btnSimpan.Click
        If Not ValidasiInput() Then
            lblStatus.Text = "Periksa isian yang bertanda merah."
            Return
        End If

        Dim ipk As Decimal
        CobaDesimal(txtIpk.Text, ipk)
        lstMahasiswa.Items.Add(txtNim.Text & " | " & txtNama.Text.Trim() & " | " &
                               cboJurusan.Text & " | " & txtAngkatan.Text & " | " & ipk.ToString("0.00"))
        daftarNim.Add(txtNim.Text)
        lblStatus.Text = "Data " & txtNama.Text.Trim() & " tersimpan."
        BersihkanForm()
    End Sub

    Private Sub txtNim_Validating(sender As Object, e As CancelEventArgs) Handles txtNim.Validating
        If txtNim.Text = "" Then Return

        If SemuaDigit(txtNim.Text, 9) Then
            errInput.SetError(txtNim, "")
        Else
            errInput.SetError(txtNim, "NIM harus 9 digit angka.")

        End If
    End Sub

    Private Sub btnEkspor_Click(sender As Object, e As EventArgs) Handles btnEkspor.Click
        Dim penulis As StreamWriter = Nothing
        Try
            penulis = New StreamWriter(lokasiEkspor)
            For Each baris As Object In lstMahasiswa.Items
                penulis.WriteLine(baris.ToString().Replace(" | ", ";"))
            Next
            lblStatus.Text = "Data diekspor ke " & lokasiEkspor
        Catch ex As IOException
            MessageBox.Show("File sedang dipakai program lain atau tidak bisa ditulis." &
                            vbCrLf & ex.Message, "Ekspor Gagal")
        Finally
            If penulis IsNot Nothing Then penulis.Close()
        End Try
    End Sub


    Private Sub BersihkanForm()
        txtNim.Clear()
        txtNama.Clear()
        txtAngkatan.Clear()
        txtIpk.Clear()
        cboJurusan.SelectedIndex = -1
        errInput.Clear()
        txtNim.Focus()
    End Sub

    Private Sub btnBersihkan_Click(sender As Object, e As EventArgs) Handles btnBersihkan.Click
        BersihkanForm()
        lblStatus.Text = "Form dibersihkan."
    End Sub
End Class
```
- **Penjelasan**:
  - `ValidasiInput`: Memvalidasi seluruh isian form secara berurutan dan mengaktifkan ikon peringatan `ErrorProvider` (`errInput.SetError`) pada kontrol yang tidak memenuhi kriteria.
  - `daftarNim.Contains(txtNim.Text)`: Mencegah penambahan data dengan NIM yang sama.
  - `txtNim_Validating`: Memberikan umpan balik langsung pada saat pengguna beralih (*lost focus*) dari field NIM.
  - `btnEkspor_Click`: Menuliskan seluruh baris `lstMahasiswa.Items` ke file `data-mahasiswa.csv` di folder Dokumen pengguna menggunakan pemisah semikolon (`;`) dan diproteksi penanganan `IOException`.

---

### 3. Form Uji Konversi Tipe Data ([`FrmUjiKonversi.vb`](file:///v:/Pemograman-Visual/FormPendaftaran/FrmUjiKonversi.vb))

```vb
Option Strict On

Public Class FrmUjiKonversi

    Private Sub btnCInt_Click(sender As Object, e As EventArgs) Handles btnCInt.Click
        Dim angka As Integer = CInt(txtInput.Text)
        lblHasil.Text = "CInt berhasil: " & angka.ToString()
    End Sub


    Private Sub btnVal_Click(sender As Object, e As EventArgs) Handles btnVal.Click
        Dim angka As Double = Val(txtInput.Text)
        lblHasil.Text = "Val menghasilkan: " & angka.ToString()
    End Sub

    Private Sub btnTryParse_Click(sender As Object, e As EventArgs) Handles btnTryParse.Click
        Dim angka As Integer
        If Integer.TryParse(txtInput.Text, angka) Then
            lblHasil.Text = "Valid. Nilai angka = " & angka.ToString()
        Else
            lblHasil.Text = "Bukan bilangan bulat yang valid. Tidak ada exception."
        End If
    End Sub

    Private Sub btnTryCatch_Click(sender As Object, e As EventArgs) Handles btnTryCatch.Click
        Try
            Dim angka As Integer = Integer.Parse(txtInput.Text)
            lblHasil.Text = "Berhasil dikonversi: " & angka.ToString()
        Catch ex As Exception
            lblHasil.Text = "Konversi gagal, program tetap berjalan."
            MessageBox.Show("Input harus bilangan bulat, misalnya 25." & vbCrLf &
                            "Detail: " & ex.Message, "Input Tidak Valid",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try
    End Sub

    Private Sub btnCatchBertingkat_Click(sender As Object, e As EventArgs) Handles btnCatchBertingkat.Click
        Try
            Dim angka As Integer = Integer.Parse(txtInput.Text)
            Dim hasil As Integer = 1000 \ angka
            lblHasil.Text = "1000 \ " & angka.ToString() & " = " & hasil.ToString()
        Catch ex As FormatException
            lblHasil.Text = "Format salah: input bukan bilangan bulat."
        Catch ex As OverflowException
            lblHasil.Text = "Angka terlalu besar untuk tipe Integer."
        Catch ex As DivideByZeroException
            lblHasil.Text = "Pembagian dengan nol tidak diperbolehkan."
        Catch ex As Exception
            lblHasil.Text = "Error lain: " & ex.Message
        End Try
    End सौ
End Class
```
- **Penjelasan Perbandingan Metode Konversi**:
  - `CInt`: Mengonversi string ke integer. Jika format salah, langsung melempar *InvalidCastException*.
  - `Val`: Mengekstrak karakter numerik terdepan. Jika diinput `25abc`, menghasilkan `25`. Jika diinput `abc25`, menghasilkan `0`. Tidak melempar eksepsi namun berpotensi memunculkan data siluman (*silent error*).
  - `Integer.TryParse`: Metode paling aman yang mengembalikan `True`/`False` tanpa melempar eksepsi.
  - `Catch Bertingkat`: Menangkap eksepsi dari yang paling spesifik (`FormatException`, `OverflowException`, `DivideByZeroException`) hingga yang paling umum (`Exception`).

---

### 4. Form Menu Navigasi Utama ([`FrmUtama.vb`](file:///v:/Pemograman-Visual/FormPendaftaran/FrmUtama.vb))

```vb
Option Strict On

Public Class FrmUtama


    Private Sub btnUjiKonversi_Click(sender As Object, e As EventArgs) Handles btnUjiKonversi.Click
        Dim frm As New FrmUjiKonversi()
        frm.ShowDialog()
    End Sub


    Private Sub btnPendaftaran_Click(sender As Object, e As EventArgs) Handles btnPendaftaran.Click
        Dim frm As New FrmPendaftaran()
        frm.ShowDialog()
    End Sub

End Class
```
- **Penjelasan**: Berfungsi sebagai menu navigasi utama untuk membuka form `FrmPendaftaran` dan form `FrmUjiKonversi` secara modal (`ShowDialog()`).

---

## 🚀 Cara Menjalankan Proyek
1. Buka solusi `FormPendaftaran.slnx` pada **Microsoft Visual Studio 2022**.
2. Tekan tombol **F5** untuk memulai eksekusi program.
3. Pada form menu utama:
   - Klik **Pendaftaran Mahasiswa** untuk mencoba input form, visualisasi peringatan `ErrorProvider`, dan ekspor CSV.
   - Klik **Uji Konversi** untuk mencoba perbandingan `CInt`, `Val`, `TryParse`, dan penanganan error bertingkat `Try...Catch`.
