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