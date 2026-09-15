Module ModArray
    Public Sub TampilkanPesan(nama As String)
        MessageBox.Show("Halo, " & nama & "!")
    End Sub

    Function hitung(panjang As Integer, lebar As Integer) As Integer
        If panjang > 50 Then
            Return panjang * lebar
        Else
            Return 2 * panjang + 2 * lebar
        End If
    End Function

    Public nilai() As Integer = {50, 60, 70, 80, 90, 100}
    Public nilai2D(,) As Integer = {
        {55, 53, 65},
        {70, 72, 78},
        {80, 85, 90}
        }
End Module
