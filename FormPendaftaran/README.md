# Pertemuan 7 — Validasi Input, ErrorProvider, & Konversi Tipe Data

Proyek ini berfokus pada pengimplementasian sistem **Validasi Input Berlapis** pada Windows Forms (VB.NET) menggunakan komponen **`ErrorProvider`**, pencegahan duplikasi data, penulisan file eksternal (**Ekspor CSV**), serta studi komparasi penanganan dan konversi tipe data (*Type Conversion & Exception Handling*).

---

## 📁 Lokasi Proyek & File Utama
- **Folder Proyek**: `FormPendaftaran/`
- **File Solusi**: `FormPendaftaran.slnx`
- **File Form Utama (Menu Navigasi)**: [`FrmUtama.vb`](file:///v:/Pemograman-Visual/FormPendaftaran/FrmUtama.vb)
- **File Form Pendaftaran**: [`FrmPendaftaran.vb`](file:///v:/Pemograman-Visual/FormPendaftaran/FrmPendaftaran.vb)
- **File Form Uji Konversi**: [`FrmUjiKonversi.vb`](file:///v:/Pemograman-Visual/FormPendaftaran/FrmUjiKonversi.vb)
- **File Modul Validasi Helper**: [`ModValidasi.vb`](file:///v:/Pemograman-Visual/FormPendaftaran/ModValidasi.vb)

---

## 🧰 Kontrol Visual yang Digunakan

### 1. Form Pendaftaran Mahasiswa (`FrmPendaftaran`)
| Nama Kontrol | Tipe Kontrol | Fungsi / Peranan |
| :--- | :--- | :--- |
| `txtNim` | `TextBox` | Menerima input NIM (wajib 9 digit angka & unik) |
| `txtNama` | `TextBox` | Menerima input Nama Mahasiswa (tidak boleh kosong/spasi) |
| `txtAngkatan` | `TextBox` | Menerima input tahun angkatan (2015 s.d. tahun sekarang) |
| `txtIpk` | `TextBox` | Menerima input IPK (0.00 s.d. 4.00, mendukung koma/titik) |
| `cboJurusan` | `ComboBox` | Pilihan program studi / jurusan |
| `btnSimpan` | `Button` | Memvalidasi seluruh isian lalu menyimpan ke ListBox |
| `btnEkspor` | `Button` | Mengekspor seluruh data pendaftar ke file CSV |
| `btnBersihkan` | `Button` | Mengosongkan form dan menghapus indikator error |
| `lstMahasiswa` | `ListBox` | Menampilkan baris data mahasiswa yang telah terdaftar |
| `errInput` | `ErrorProvider` | Menampilkan ikon peringatan & pesan error di sisi kontrol input |
| `lblStatus` | `Label` | Menampilkan informasi status operasi aplikasi |

### 2. Form Uji Konversi Tipe Data (`FrmUjiKonversi`)
| Nama Kontrol | Tipe Kontrol | Fungsi / Peranan |
| :--- | :--- | :--- |
| `txtInput` | `TextBox` | Menerima teks uji coba untuk dikonversi |
| `btnCInt` | `Button` | Menguji fungsi bawaan `CInt()` |
| `btnVal` | `Button` | Menguji fungsi bawaan `Val()` |
| `btnTryParse` | `Button` | Menguji metode aman `Integer.TryParse()` |
| `btnTryCatch` | `Button` | Menguji konversi dengan penanganan eksepsi `Try...Catch` |
| `btnCatchBertingkat` | `Button` | Menguji penanganan eksepsi bertingkat (`FormatException`, `OverflowException`, `DivideByZeroException`) |
| `lblHasil` | `Label` | Menampilkan hasil output atau detail eksepsi yang tertangkap |

---

## 💻 Penjelasan Logika & Fitur Utama

### 1. Modul Validasi Terpusat (`ModValidasi.vb`)
Menyediakan fungsi pembantu yang bersih dan reusable untuk dipakai di berbagai form:
```vb
Public Module ModValidasi
    ' Memeriksa apakah string kosong atau hanya berisi spasi putih
    Public Function Kosong(teks As String) As Boolean
        Return teks.Trim() = ""
    End Function

    ' Memeriksa panjang string dan memastikan seluruh karakter berupa angka (0-9)
    Public Function SemuaDigit(teks As String, panjang As Integer) As Boolean
        If teks.Length <> panjang Then Return False
        For Each karakter As Char In teks
            If karakter < "0"c OrElse karakter > "9"c Then Return False
        Next
        Return True
    End Function

    ' Mengonversi desimal secara universal (koma maupun titik diterima tanpa terpengaruh Locale Windows)
    Public Function CobaDesimal(teks As String, ByRef hasil As Decimal) As Boolean
        Dim teksTitik As String = teks.Trim().Replace(",", ".")
        Return Decimal.TryParse(teksTitik, NumberStyles.AllowDecimalPoint,
                                CultureInfo.InvariantCulture, hasil)
    End Function
End Module
```

### 2. Validasi Berlapis & Penggunaan ErrorProvider (`FrmPendaftaran.vb`)
Validasi dilakukan secara menyeluruh sebelum data dimasukkan ke dalam memori:
- **Nama**: Memastikan teks tidak kosong melalui `Kosong(txtNama.Text)`.
- **Angkatan**: Divalidasi menggunakan `Integer.TryParse` dengan batasan `2015 <= angkatan <= Date.Today.Year`.
- **NIM**: Dipastikan tepat 9 digit angka (`SemuaDigit`), serta dicek apakah sudah pernah tersimpan dalam koleksi `daftarNim.Contains(txtNim.Text)` untuk mencegah duplikasi.
- **Jurusan**: Memastikan pengguna memilih opsi (`cboJurusan.SelectedIndex <> -1`).
- **IPK**: Menggunakan `CobaDesimal` dengan rentang valid `0.00` s.d. `4.00`.
- **Feedback Interaktif**: Bila ada input yang gagal, `errInput.SetError(kontrol, pesan)` akan menampilkan ikon tanda seru merah beserta tooltip penjelas.

### 3. Validasi Real-Time (`txtNim_Validating`)
Event `Validating` digunakan untuk memberikan feedback instan saat fokus berpindah dari kotak teks NIM:
```vb
Private Sub txtNim_Validating(sender As Object, e As CancelEventArgs) Handles txtNim.Validating
    If txtNim.Text = "" Then Return
    If SemuaDigit(txtNim.Text, 9) Then
        errInput.SetError(txtNim, "")
    Else
        errInput.SetError(txtNim, "NIM harus 9 digit angka.")
    End If
End Sub
```

### 4. Ekspor Data ke File CSV (`btnEkspor_Click`)
Data yang ada di dalam `ListBox` diekspor ke file `data-mahasiswa.csv` pada folder Documents pengguna dengan format semikolon (`;`):
```vb
Dim penulis As StreamWriter = Nothing
Try
    penulis = New StreamWriter(lokasiEkspor)
    For Each baris As Object In lstMahasiswa.Items
        penulis.WriteLine(baris.ToString().Replace(" | ", ";"))
    Next
    lblStatus.Text = "Data diekspor ke " & lokasiEkspor
Catch ex As IOException
    MessageBox.Show("File sedang dipakai program lain atau tidak bisa ditulis." & vbCrLf & ex.Message, "Ekspor Gagal")
Finally
    If penulis IsNot Nothing Then penulis.Close()
End Try
```

### 5. Komparasi Konversi Tipe Data & Try...Catch Bertingkat (`FrmUjiKonversi.vb`)
Mendemonstrasikan perbedaan mendasar mekanisme konversi:
- **`CInt()`**: Menghasilkan runtime error (*Exception*) jika input berupa teks non-angka.
- **`Val()`**: Mengambil angka dari karakter terdepan, namun berhenti saat menemukan karakter non-angka (bisa menghasilkan nilai tidak akurat tanpa melempar error).
- **`Integer.TryParse()`**: Metode teraman tanpa melempar exception, mengembalikan `Boolean` keberhasilan.
- **`Try...Catch` Bertingkat**: Menangkap jenis error secara spesifik:
  - `FormatException`: Format string tidak dapat diubah menjadi integer.
  - `OverflowException`: Nilai angka melebihi batas tampung integer 32-bit.
  - `DivideByZeroException`: Pembagian matematika dengan angka nol.
  - `Exception`: Penanganan umum fallback untuk error lainnya.

---

## 🚀 Cara Menjalankan Proyek
1. Buka solusi `FormPendaftaran.slnx` pada **Microsoft Visual Studio 2022**.
2. Jalankan aplikasi dengan menekan tombol **F5**.
3. Pada menu utama, pilih:
   - **Pendaftaran Mahasiswa** untuk mencoba form pendaftaran, validasi `ErrorProvider`, dan ekspor CSV.
   - **Uji Konversi** untuk bereksperimen dengan berbagai perilaku konversi tipe data dan exception handling.
