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
