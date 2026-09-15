<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmArray
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
        btnTampil = New Button()
        txtLebar = New TextBox()
        txtPanjang = New TextBox()
        lblPanjang = New Label()
        lblLebar = New Label()
        lstNilai = New ListBox()
        SuspendLayout()
        ' 
        ' btnTampil
        ' 
        btnTampil.Location = New Point(158, 235)
        btnTampil.Name = "btnTampil"
        btnTampil.Size = New Size(75, 23)
        btnTampil.TabIndex = 0
        btnTampil.Text = "Tampilkan"
        btnTampil.UseVisualStyleBackColor = True
        ' 
        ' txtLebar
        ' 
        txtLebar.Location = New Point(157, 168)
        txtLebar.Name = "txtLebar"
        txtLebar.Size = New Size(100, 23)
        txtLebar.TabIndex = 1
        ' 
        ' txtPanjang
        ' 
        txtPanjang.Location = New Point(157, 79)
        txtPanjang.Name = "txtPanjang"
        txtPanjang.Size = New Size(100, 23)
        txtPanjang.TabIndex = 2
        ' 
        ' lblPanjang
        ' 
        lblPanjang.AutoSize = True
        lblPanjang.Location = New Point(155, 38)
        lblPanjang.Name = "lblPanjang"
        lblPanjang.Size = New Size(56, 15)
        lblPanjang.TabIndex = 3
        lblPanjang.Text = "Panjang :"
        ' 
        ' lblLebar
        ' 
        lblLebar.AutoSize = True
        lblLebar.Location = New Point(158, 138)
        lblLebar.Name = "lblLebar"
        lblLebar.Size = New Size(42, 15)
        lblLebar.TabIndex = 4
        lblLebar.Text = "Lebar :"
        ' 
        ' lstNilai
        ' 
        lstNilai.FormattingEnabled = True
        lstNilai.Location = New Point(153, 286)
        lstNilai.Name = "lstNilai"
        lstNilai.Size = New Size(120, 94)
        lstNilai.TabIndex = 5
        ' 
        ' FrmArray
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(408, 450)
        Controls.Add(lstNilai)
        Controls.Add(lblLebar)
        Controls.Add(lblPanjang)
        Controls.Add(txtPanjang)
        Controls.Add(txtLebar)
        Controls.Add(btnTampil)
        Name = "FrmArray"
        Text = "Form1"
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents btnTampil As Button
    Friend WithEvents txtLebar As TextBox
    Friend WithEvents txtPanjang As TextBox
    Friend WithEvents lblPanjang As Label
    Friend WithEvents lblLebar As Label
    Friend WithEvents lstNilai As ListBox

End Class
