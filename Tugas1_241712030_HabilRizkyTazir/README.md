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
- **File Kode Principal**:
  - Form Login: [`FormLogin.vb`](file:///v:/Pemograman-Visual/Tugas1_241712030_HabilRizkyTazir/Tugas1_241712030_HabilRizkyTazir/FormLogin.vb)
  - Form Perhitungan Pajak: [`FormPajak.vb`](file:///v:/Pemograman-Visual/Tugas1_241712030_HabilRizkyTazir/Tugas1_241712030_HabilRizkyTazir/FormPajak.vb)
- **Folder Gambar Assets**:
  - `Assets/manager.png` (Avatar Manager)
  - `Assets/staff.png` (Avatar Staff)

---

## 🧰 Struktur Kontrol & Peranan

### 1. Form Login (`frmLogin`)
| Nama Kontrol | Tipe Kontrol | Fungsi / Peranan |
| :--- | :--- | :--- |
| `cmbRole` | `ComboBox` | Pilihan peran pengakses (`Staff` atau `Manager`) |
| `txtNama` | `TextBox` | Input nama pengguna (Validasi: hanya huruf) |
| `txtNim` | `TextBox` | Input NIM pengguna (Validasi: hanya angka) |
| `picImage` | `PictureBox` | Menampilkan gambar avatar sesuai role yang dipilih |
| `btnLogin` | `Button` | Memverifikasi kredensial login dan mengarahkan ke Form Pajak |

### 2. Form Pajak (`FrmPajak`)
| Nama Kontrol | Tipe Kontrol | Fungsi / Peranan |
| :--- | :--- | :--- |
| `txtPendapatan` | `TextBox` | Input nominal pendapatan tahunan/bulanan (Validasi: angka) |
| `btnHitung` | `Button` | Menghitung besaran pajak berdasarkan persen tarif bertingkat |
| `btnKeluar` | `Button` | Kembali ke Form Login dan menutup Form Pajak |

---

## 🔑 Data Kredensial Login Valid

| Role | Nama Valid | NIM Valid | Avatar Asset |
| :--- | :--- | :--- | :--- |
| **Manager** | `Habil` | `241712030` | `Assets/manager.png` |
| **Staff** | `Reza` | `241712010` | `Assets/staff.png` |

---

## 💻 Penjelasan Kode

### A. Kode Form Login ([`FormLogin.vb`](file:///v:/Pemograman-Visual/Tugas1_241712030_HabilRizkyTazir/Tugas1_241712030_HabilRizkyTazir/FormLogin.vb))

#### 1. Inisialisasi Pilihan Role (`FrmLogin_Load`)
```vb
Private Sub FrmLogin_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    cmbRole.Items.AddRange({"Staff", "Manager"})
    cmbRole.SelectedIndex = 0
End Sub
```
- Menambahkan pilihan `"Staff"` dan `"Manager"` secara otomatis ke dalam `ComboBox` saat form pertama kali dimuat.

#### 2. Validasi Karakter Nama (Hanya Huruf) & NIM (Hanya Angka)
```vb
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
```
- `Char.IsLetter`: Mengizinkan alfabet A-Z / a-z pada `txtNama`. Karakter angka/simbol ditolak (`e.Handled = True`).
- `Char.IsDigit`: Mengizinkan numerik 0-9 pada `txtNim`. Karakter huruf/simbol ditolak.

#### 3. Perubahan Avatar Berdasarkan Role (`cmbRole_SelectedIndexChanged`)
```vb
Private Sub cmbRole_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbRole.SelectedIndexChanged
    If cmbRole.SelectedItem.ToString() = "Manager" Then
        picImage.Image = Image.FromFile("Assets/manager.png")
    ElseIf cmbRole.SelectedItem.ToString() = "Staff" Then
        picImage.Image = Image.FromFile("Assets/staff.png")
    End If
End Sub
```
- Setiap kali item pada `cmbRole` diganti, event `SelectedIndexChanged` dipicu untuk mengubah gambar `picImage` dari file di direktori `Assets/`.

#### 4. Verifikasi Login & Navigasi Multi-Form (`btnLogin_Click`)
```vb
Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
    Dim role As String = cmbRole.SelectedItem.ToString()
    Dim nama As String = txtNama.Text.Trim()
    Dim nim As String = txtNim.Text.Trim()

    ' Evaluasi Kebenaran Kredensial Login
    Dim valid As Boolean =
        (role = "Manager" AndAlso nama = "Habil" AndAlso nim = "241712030") OrElse
        (role = "Staff" AndAlso nama = "Reza" AndAlso nim = "241712010")

    If Not valid Then
        MessageBox.Show("Role, Nama, atau NIM tidak sesuai!", "Login Gagal", MessageBoxButtons.OK, MessageBoxIcon.Error)
        txtNim.Focus()
        Return
    End If

    ' Pindah ke Form Pajak
    Dim frmPajak As New FrmPajak()
    frmPajak.Show()
    Me.Hide()

    txtNama.Clear()
    txtNim.Clear()
End Sub
```
- **`Dim frmPajak As New FrmPajak()`**: Membuat instance objek baru dari Form Pajak.
- **`frmPajak.Show()`**: Menampilkan Form Pajak kepada pengguna.
- **`Me.Hide()`**: Menyembunyikan Form Login tanpa menghancurkan memorinya.

---

### B. Kode Form Pajak ([`FormPajak.vb`](file:///v:/Pemograman-Visual/Tugas1_241712030_HabilRizkyTazir/Tugas1_241712030_HabilRizkyTazir/FormPajak.vb))

#### 1. Perhitungan Pajak Bertingkat (`btnHitung_Click`)
```vb
Private Sub btnHitung_Click(sender As Object, e As EventArgs) Handles btnHitung.Click
    Dim pendapatan As Decimal

    If Not Decimal.TryParse(txtPendapatan.Text, pendapatan) Then
        MessageBox.Show("Masukkan angka yang valid!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        txtPendapatan.Focus()
        Return
    End If

    Dim persen As Decimal

    ' Skema Tarif Pajak Bertingkat
    If pendapatan <= 5000000 Then
        persen = 0        ' 0%
    ElseIf pendapatan <= 30000000 Then
        persen = 0.1      ' 10%
    ElseIf pendapatan <= 100000000 Then
        persen = 0.2      ' 20%
    Else
        persen = 0.3      ' 30%
    End If

    Dim pajak As Decimal = pendapatan * persen

    MessageBox.Show($"Pajak yang harus dibayar: Rp {pajak:N0}", "Hasil Perhitungan", MessageBoxButtons.OK, MessageBoxIcon.Information)
End Sub
```

#### Skema Tarif Pajak:
- $\text{Pendapatan} \le \text{Rp } 5.000.000 \longrightarrow 0\%$ (Bebas Pajak)
- $\text{Rp } 5.000.001 \text{ s/d } \text{Rp } 30.000.000 \longrightarrow 10\%$
- $\text{Rp } 30.000.001 \text{ s/d } \text{Rp } 100.000.000 \longrightarrow 20\%$
- $\text{Pendapatan} > \text{Rp } 100.000.000 \longrightarrow 30\%$
- **`Rp {pajak:N0}`**: String Interpolation (`$""`) dengan format specifier `:N0` untuk memberikan separator ribuan pada nominal angka rupiah.

#### 2. Logout / Kembali ke Login (`btnKeluar_Click`)
```vb
Private Sub btnKeluar_Click(sender As Object, e As EventArgs) Handles btnKeluar.Click
    Dim frmLogin As New frmLogin()
    frmLogin.Show()
    Me.Close()
End Sub
```
- Membuka kembali Form Login utama dan menghentikan instance `FrmPajak`.
