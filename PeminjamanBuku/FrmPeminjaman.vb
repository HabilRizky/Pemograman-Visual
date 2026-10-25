Option Strict On

Imports System.ComponentModel
Imports System.IO

Public Class FrmPeminjaman
    ' Kode buku yang sedang dipinjam, untuk mencegah peminjaman ganda
    Private ReadOnly daftarKodeDipinjam As New List(Of String)

    ' File CSV disimpan di folder Documents milik pengguna
    Private ReadOnly lokasiEkspor As String =
        Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
                     "peminjaman.csv")

    ' Memeriksa semua isian sekaligus. Mengembalikan True jika semuanya valid.
    Private Function ValidasiInput() As Boolean
        errPinjam.Clear()
        Dim valid As Boolean = True
        Dim kodeNormalisasi As String = txtKodeBuku.Text.Trim().ToUpper()

        If Not KodeBukuValid(kodeNormalisasi) Then
            errPinjam.SetError(txtKodeBuku, "Kode harus format BK diikuti 4 digit, contoh BK0012.")
            valid = False
        ElseIf daftarKodeDipinjam.Contains(kodeNormalisasi) Then
            errPinjam.SetError(txtKodeBuku, "Buku ini sedang dipinjam.")
            valid = False
        End If

        If Kosong(txtJudul.Text) Then
            errPinjam.SetError(txtJudul, "Judul wajib diisi.")
            valid = False
        End If

        If cboKategori.SelectedIndex = -1 Then
            errPinjam.SetError(cboKategori, "Pilih kategori terlebih dahulu.")
            valid = False
        End If

        Dim namaTrim As String = txtNamaPeminjam.Text.Trim()
        If namaTrim.Length < 3 Then
            errPinjam.SetError(txtNamaPeminjam, "Nama peminjam minimal 3 karakter.")
            valid = False
        End If

        Dim lama As Integer
        If Not Integer.TryParse(txtLamaPinjam.Text, lama) OrElse lama < 1 OrElse lama > 14 Then
            errPinjam.SetError(txtLamaPinjam, "Lama pinjam harus angka 1 sampai 14 hari.")
            valid = False
        End If

        Return valid
    End Function

    ' Mencatat satu peminjaman baru jika semua isian valid.
    Private Sub btnPinjam_Click(sender As Object, e As EventArgs) Handles btnPinjam.Click
        If Not ValidasiInput() Then Return

        Dim kode As String = txtKodeBuku.Text.Trim().ToUpper()
        Dim lama As Integer
        Integer.TryParse(txtLamaPinjam.Text, lama)
        Dim tanggalKembali As String = Date.Today.AddDays(lama).ToString("dd/MM/yyyy")

        lstPeminjaman.Items.Add(kode & " | " & txtJudul.Text.Trim() & " | " & cboKategori.Text & " | " &
                                txtNamaPeminjam.Text.Trim() & " | " & lama.ToString() & " hari | kembali " & tanggalKembali)
        daftarKodeDipinjam.Add(kode)
        lblStatus.Text = "Jumlah peminjaman: " & lstPeminjaman.Items.Count.ToString()
        BersihkanForm()
    End Sub

    ' Validasi format kode buku langsung saat fokus meninggalkan txtKodeBuku.
    Private Sub txtKodeBuku_Validating(sender As Object, e As CancelEventArgs) Handles txtKodeBuku.Validating
        If txtKodeBuku.Text = "" Then Return   ' kosong dicek nanti saat Pinjam
        Dim kodeNormalisasi As String = txtKodeBuku.Text.Trim().ToUpper()
        If KodeBukuValid(kodeNormalisasi) Then
            errPinjam.SetError(txtKodeBuku, "")
        Else
            errPinjam.SetError(txtKodeBuku, "Kode harus format BK diikuti 4 digit, contoh BK0012.")
            ' e.Cancel = True sengaja tidak dipakai, agar fokus tetap bisa berpindah.
        End If
    End Sub

    ' Mengosongkan semua isian dan menghapus semua ikon ErrorProvider.
    Private Sub BersihkanForm()
        txtKodeBuku.Clear()
        txtJudul.Clear()
        cboKategori.SelectedIndex = -1
        txtNamaPeminjam.Clear()
        txtLamaPinjam.Clear()
        errPinjam.Clear()
        txtKodeBuku.Focus()
    End Sub

    Private Sub btnBersihkan_Click(sender As Object, e As EventArgs) Handles btnBersihkan.Click
        BersihkanForm()
    End Sub

    ' Menulis seluruh daftar peminjaman ke file CSV di folder Documents.
    Private Sub btnEkspor_Click(sender As Object, e As EventArgs) Handles btnEkspor.Click
        If lstPeminjaman.Items.Count = 0 Then
            MessageBox.Show("Belum ada data peminjaman untuk diekspor.", "Ekspor Dibatalkan",
                            MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        Dim penulis As StreamWriter = Nothing
        Try
            penulis = New StreamWriter(lokasiEkspor)
            penulis.WriteLine("KodeBuku;Judul;Kategori;NamaPeminjam;LamaPinjam;TanggalKembali")
            For Each baris As Object In lstPeminjaman.Items
                penulis.WriteLine(baris.ToString().Replace(" | ", ";"))
            Next
            lblStatus.Text = "Data diekspor ke " & lokasiEkspor
        Catch ex As IOException
            MessageBox.Show("File sedang dipakai program lain atau tidak bisa ditulis." & vbCrLf &
                            ex.Message, "Ekspor Gagal", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Catch ex As UnauthorizedAccessException
            MessageBox.Show("Tidak memiliki izin untuk menulis file di lokasi ini." & vbCrLf &
                            ex.Message, "Ekspor Gagal", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Finally
            If penulis IsNot Nothing Then penulis.Close()   ' file selalu ditutup
        End Try
    End Sub
End Class
