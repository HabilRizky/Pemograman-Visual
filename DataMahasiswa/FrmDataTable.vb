
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
