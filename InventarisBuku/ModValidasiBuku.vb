Option Strict On

' Modul validasi khusus untuk format kode buku (disalin dari Pertemuan 7)
Public Module ModValidasiBuku

    ' Memeriksa apakah teks berformat "BK" diikuti tepat 4 digit angka.
    Public Function KodeBukuValid(kode As String) As Boolean
        Dim kodeUpper As String = kode.Trim().ToUpper()
        If kodeUpper.Length <> 6 Then Return False
        If Not kodeUpper.StartsWith("BK") Then Return False
        Return SemuaDigit(kodeUpper.Substring(2), 4)
    End Function

End Module
