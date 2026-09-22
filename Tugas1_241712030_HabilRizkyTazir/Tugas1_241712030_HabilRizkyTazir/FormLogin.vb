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