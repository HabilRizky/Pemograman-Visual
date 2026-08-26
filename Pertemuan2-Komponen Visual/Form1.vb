Public Class Form1
    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles txtNama.TextChanged

    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub btnTampilkan_Click(sender As Object, e As EventArgs) Handles btnTampilkan.Click
        MessageBox.Show("Halo Selamat Datang ! " & vbCrLf &
                        "Nama: " & txtNama.Text & vbCrLf &
                        "NIM: " & txtNIM.Text & vbCrLf &
                        "KOM: " & txtKOM.Text
        )
    End Sub

    Private Sub txtHapus_Click(sender As Object, e As EventArgs) Handles txtHapus.Click
        txtNama.Clear()
        txtNIM.Clear()
        txtKOM.Clear()
    End Sub

    Private Sub btnKeluar_Click(sender As Object, e As EventArgs) Handles btnKeluar.Click
        Me.Close()
    End Sub
End Class
