# Tugas 1 — Sistem Autentikasi Login & Kalkulator Pajak Pendapatan

Tugas 1 ini merupakan aplikasi berbasis **Windows Forms (VB.NET)** yang menggabungkan beberapa fitur utama:
1. **Autentikasi Multi-User & Multi-Role** (`Manager` dan `Staff`).
2. **Visualisasi Avatar Dinamis** berbasis pilihan role pada `ComboBox`.
3. **Validasi Karakter Khusus** (Nama hanya huruf, NIM & Pendapatan hanya angka).
4. **Navigasi Multi-Form** antara Form Login (`frmLogin`) dan Form Perhitungan Pajak (`FrmPajak`).
5. **Kalkulasi Pajak Pendapatan Bertingkat** (*Progressive Tax Rate*).

---

## 📁 Lokasi Proyek & File Utama
- **Folder Proyek**: `Tugas1_241712030_HabilRizkyTazir/`
- **File Solusi**: `Tugas1_241712030_HabilRizkyTazir.slnx`
- **File Proyek**: `Tugas1_241712030_HabilRizkyTazir.vbproj`
- **Form Login**: [`FormLogin.vb`](file:///v:/Pemograman-Visual/Tugas1_241712030_HabilRizkyTazir/Tugas1_241712030_HabilRizkyTazir/FormLogin.vb)
- **Form Perhitungan Pajak**: [`FormPajak.vb`](file:///v:/Pemograman-Visual/Tugas1_241712030_HabilRizkyTazir/Tugas1_241712030_HabilRizkyTazir/FormPajak.vb)
- **Folder Asset Gambar**:
  - `Assets/manager.png` (Avatar Role Manager)
  - `Assets/staff.png` (Avatar Role Staff)

---

## 🧰 Kontrol Visual yang Digunakan

### 1. Form Login (`frmLogin`)
| Nama Kontrol | Tipe Kontrol | Fungsi / Peranan |
| :--- | :--- | :--- |
| `cmbRole` | `ComboBox` | Pilihan peran pengguna (`Staff` atau `Manager`) |
| `txtNama` | `TextBox` | Input nama pengguna (Validasi: hanya huruf) |
| `txtNim` | `TextBox` | Input NIM pengguna (Validasi: hanya angka) |
| `picImage` | `PictureBox` | Menampilkan avatar visual sesuai role yang dipilih |
| `btnLogin` | `Button` | Memverifikasi kredensial login dan mengarahkan ke Form Pajak |

### 2. Form Pajak (`FrmPajak`)
| Nama Kontrol | Tipe Kontrol | Fungsi / Peranan |
| :--- | :--- | :--- |
| `txtPendapatan` | `TextBox` | Input nominal pendapatan bulanan/tahunan (Validasi: angka) |
| `btnHitung` | `Button` | Menghitung besaran pajak berdasarkan skema tarif bertingkat |
| `btnKeluar` | `Button` | Kembali ke Form Login dan menutup Form Pajak |

---

## 🔑 Data Kredensial Login Valid

| Role | Nama Valid | NIM Valid | Avatar Asset |
| :--- | :--- | :--- | :--- |
| **Manager** | `Habil` | `241712030` | `Assets/manager.png` |
| **Staff** | `Reza` | `241712010` | `Assets/staff.png` |

---

## 💻 Seluruh Kode Program (Full Code) & Penjelasan Lengkap

### 1. Full Code Form Login ([`FormLogin.vb`](file:///v:/Pemograman-Visual/Tugas1_241712030_HabilRizkyTazir/Tugas1_241712030_HabilRizkyTazir/FormLogin.vb))

Berikut adalah seluruh kode program dari file `FormLogin.vb`:

```vb
Public Class frmLogin
    Private Sub txtNama_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtNama.KeyPress
        If Not Char.IsControl(e.KeyChar) AndAlso Not Char.IsLetter(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtNim_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtNim.KeyPress
        If Not Char.IsControl(e.KeyChar) AndAlso Not Char.IsDigit(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub cmbRole_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbRole.SelectedIndexChanged
        If cmbRole.SelectedItem.ToString() = "Manager" Then
            picImage.Image = Image.FromFile("Assets/manager.png")
        ElseIf cmbRole.SelectedItem.ToString() = "Staff" Then
            picImage.Image = Image.FromFile("Assets/staff.png")
        End If
    End Sub

    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        Dim role As String = cmbRole.SelectedItem.ToString()
        Dim nama As String = txtNama.Text.Trim()
        Dim nim As String = txtNim.Text.Trim()

        Dim valid As Boolean = (role = "Manager" AndAlso nama = "Habil" AndAlso nim = "241712030") OrElse
                        (role = "Staff" AndAlso nama = "Reza" AndAlso nim = "241712010")

        If Not valid Then
            MessageBox.Show("Role, Nama, atau NIM tidak sesuai!", "Login Gagal", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtNim.Focus()
            Return
        End If

        Dim frmPajak As New FrmPajak()
        frmPajak.Show()
        Me.Hide()

        txtNama.Clear()
        txtNim.Clear()
    End Sub
    Private Sub FrmLogin_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cmbRole.Items.AddRange({"Staff", "Manager"})
        cmbRole.SelectedIndex = 0
    End Sub
End Class
```

#### Penjelasan Rinci Form Login:
- **`FrmLogin_Load`**: Mengisi pilihan peran (`"Staff"`, `"Manager"`) ke kontrol `cmbRole` dan memilih indeks ke-0 secara default saat aplikasi dibuka.
- **`txtNama_KeyPress`**: Memeriksa pengetikan dengan `Char.IsLetter`. Karakter angka dan simbol dibatalkan (`e.Handled = True`).
- **`txtNim_KeyPress`**: Memeriksa pengetikan dengan `Char.IsDigit`. Karakter huruf dan simbol dibatalkan (`e.Handled = True`).
- **`cmbRole_SelectedIndexChanged`**: Mengganti avatar pada `picImage` dari file gambar `Assets/manager.png` atau `Assets/staff.png` saat user mengubah peran di dropdown.
- **`btnLogin_Click`**:
  - Mengevaluasi kombinasi kredensial (Role, Nama, dan NIM).
  - Jika tidak cocok, menampilkan pesan kesalahan dan mengembalikan fokus kursor ke kotak NIM.
  - Jika cocok, menginisialisasi instance form baru `Dim frmPajak As New FrmPajak()`, memanggil `frmPajak.Show()`, dan menyembunyikan form login melalui `Me.Hide()`.

---

### 2. Full Code Form Pajak ([`FormPajak.vb`](file:///v:/Pemograman-Visual/Tugas1_241712030_HabilRizkyTazir/Tugas1_241712030_HabilRizkyTazir/FormPajak.vb))

Berikut adalah seluruh kode program dari file `FormPajak.vb`:

```vb
Public Class FrmPajak

    Private Sub txtPendapatan_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPendapatan.KeyPress
        If Not (Char.IsDigit(e.KeyChar) OrElse e.KeyChar = ControlChars.Back) Then
            e.Handled = True
        End If
    End Sub

    Private Sub btnHitung_Click(sender As Object, e As EventArgs) Handles btnHitung.Click

        Dim pendapatan As Decimal

        If Not Decimal.TryParse(txtPendapatan.Text, pendapatan) Then
            MessageBox.Show("Masukkan angka yang valid!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtPendapatan.Focus()
            Return
        End If

        Dim persen As Decimal

        If pendapatan <= 5000000 Then
            persen = 0
        ElseIf pendapatan <= 30000000 Then
            persen = 0.1
        ElseIf pendapatan <= 100000000 Then
            persen = 0.2
        Else
            persen = 0.3
        End If

        Dim pajak As Decimal = pendapatan * persen

        MessageBox.Show($"Pajak yang harus dibayar: Rp {pajak:N0}", "Hasil Perhitungan", MessageBoxButtons.OK, MessageBoxIcon.Information)

    End Sub

    Private Sub btnKeluar_Click(sender As Object, e As EventArgs) Handles btnKeluar.Click
        Dim frmLogin As New frmLogin()
        frmLogin.Show()
        Me.Close()
    End Sub

End Class
```

#### Penjelasan Rinci Form Pajak:
- **`txtPendapatan_KeyPress`**: Membatasi masukan hanya menerima angka (`Char.IsDigit`) dan tombol backspace (`ControlChars.Back`).
- **`btnHitung_Click`**:
  - Mengonversi teks pendapatan ke numerik desimal menggunakan `Decimal.TryParse`.
  - Mengkalkulasi tarif persentase berdasarkan skema tarif pajak bertingkat:
    - Pendapatan $\le \text{Rp } 5.000.000 \longrightarrow 0\%$
    - $\text{Rp } 5.000.001 \text{ s/d } \text{Rp } 30.000.000 \longrightarrow 10\%$ ($0.1$)
    - $\text{Rp } 30.000.001 \text{ s/d } \text{Rp } 100.000.000 \longrightarrow 20\%$ ($0.2$)
    - Pendapatan $> \text{Rp } 100.000.000 \longrightarrow 30\%$ ($0.3$)
  - Menghitung nilai nominal pajak (`pendapatan * persen`) dan menampilkannya dengan format mata uang berpemisah ribuan melalui interpolasi string `$"{pajak:N0}"`.
- **`btnKeluar_Click`**: Membuka kembali jendela Form Login baru dan menutup form kalkulator pajak saat ini (`Me.Close()`).

---

## 🚀 Cara Menjalankan Proyek
1. Buka file solusi `Tugas1_241712030_HabilRizkyTazir.slnx` menggunakan **Microsoft Visual Studio 2022**.
2. Tekan **F5** untuk menjalankan program.
3. Pada halaman Login:
   - Pilih Role `Manager`, ketik Nama `Habil`, NIM `241712030`, lalu klik **Login**.
   - Atau pilih Role `Staff`, ketik Nama `Reza`, NIM `241712010`, lalu klik **Login**.
4. Setelah berhasil masuk ke Form Pajak, masukkan nominal pendapatan (misalnya `25000000`) lalu klik tombol **Hitung**.
5. Dialog hasil perhitungan pajak akan menampilkan nominal pajak yang harus dibayarkan.
