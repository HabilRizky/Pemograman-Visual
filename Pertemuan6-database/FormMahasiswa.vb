Public Class FormMahasiswa
    Private Sub btnTest_Click(sender As Object, e As EventArgs) Handles btnTampilkan.Click
        dgvMahasiswa.AutoGenerateColumns = True
        dgvMahasiswa.DataSource = ModQuery.TampilkanData()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnTambah.Click
        If ModQuery.TambahData(
            txtNim.Text,
            txtNama.Text,
            txtJurusan.Text
        ) Then

            MessageBox.Show("Data berhasil disimpan")
        End If

        txtJurusan.Clear()
        txtNama.Clear()
        txtNim.Clear()
    End Sub

    Private Sub txtNama_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtNama.KeyPress
        If Not Char.IsControl(e.KeyChar) AndAlso Not Char.IsLetter(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtNIM_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtNim.KeyPress
        If Not Char.IsControl(e.KeyChar) AndAlso Not Char.IsDigit(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

End Class