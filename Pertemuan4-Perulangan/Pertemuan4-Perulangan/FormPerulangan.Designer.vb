<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormPerulangan
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        lblNilaiAwal = New Label()
        btnInput = New Button()
        lblNilaiAkhir = New Label()
        lstHasil = New ListBox()
        txtNilaiAwal = New TextBox()
        txtNilaiAkhir = New TextBox()
        SuspendLayout()
        ' 
        ' lblNilaiAwal
        ' 
        lblNilaiAwal.AutoSize = True
        lblNilaiAwal.Font = New Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblNilaiAwal.Location = New Point(227, 87)
        lblNilaiAwal.Name = "lblNilaiAwal"
        lblNilaiAwal.Size = New Size(89, 21)
        lblNilaiAwal.TabIndex = 0
        lblNilaiAwal.Text = "Nilai Awal :"
        ' 
        ' btnInput
        ' 
        btnInput.Location = New Point(241, 269)
        btnInput.Name = "btnInput"
        btnInput.Size = New Size(75, 23)
        btnInput.TabIndex = 1
        btnInput.Text = "Input"
        btnInput.UseVisualStyleBackColor = True
        ' 
        ' lblNilaiAkhir
        ' 
        lblNilaiAkhir.AutoSize = True
        lblNilaiAkhir.Font = New Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblNilaiAkhir.Location = New Point(227, 176)
        lblNilaiAkhir.Name = "lblNilaiAkhir"
        lblNilaiAkhir.Size = New Size(92, 21)
        lblNilaiAkhir.TabIndex = 2
        lblNilaiAkhir.Text = "Nilai Akhir :"
        ' 
        ' lstHasil
        ' 
        lstHasil.FormattingEnabled = True
        lstHasil.Location = New Point(227, 320)
        lstHasil.Name = "lstHasil"
        lstHasil.Size = New Size(120, 94)
        lstHasil.TabIndex = 3
        ' 
        ' txtNilaiAwal
        ' 
        txtNilaiAwal.Location = New Point(227, 130)
        txtNilaiAwal.Name = "txtNilaiAwal"
        txtNilaiAwal.Size = New Size(125, 23)
        txtNilaiAwal.TabIndex = 4
        ' 
        ' txtNilaiAkhir
        ' 
        txtNilaiAkhir.Location = New Point(227, 224)
        txtNilaiAkhir.Name = "txtNilaiAkhir"
        txtNilaiAkhir.Size = New Size(125, 23)
        txtNilaiAkhir.TabIndex = 5
        ' 
        ' FormPerulangan
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(533, 450)
        Controls.Add(txtNilaiAkhir)
        Controls.Add(txtNilaiAwal)
        Controls.Add(lstHasil)
        Controls.Add(lblNilaiAkhir)
        Controls.Add(btnInput)
        Controls.Add(lblNilaiAwal)
        Name = "FormPerulangan"
        Text = "Form1"
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents lblNilaiAwal As Label
    Friend WithEvents btnInput As Button
    Friend WithEvents lblNilaiAkhir As Label
    Friend WithEvents lstHasil As ListBox
    Friend WithEvents txtNilaiAwal As TextBox
    Friend WithEvents txtNilaiAkhir As TextBox

End Class
