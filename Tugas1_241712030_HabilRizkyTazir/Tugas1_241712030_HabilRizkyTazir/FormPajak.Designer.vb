<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPajak
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        lblLimaJuta = New Label()
        lblTigaPuluhJuta = New Label()
        lblSeratusJuta = New Label()
        lblPendapatan = New Label()
        lblRupiah = New Label()
        btnHitung = New Button()
        btnKeluar = New Button()
        txtPendapatan = New TextBox()
        SuspendLayout()
        ' 
        ' lblLimaJuta
        ' 
        lblLimaJuta.AutoSize = True
        lblLimaJuta.Font = New Font("Segoe UI Semibold", 15.75F, FontStyle.Bold Or FontStyle.Italic, GraphicsUnit.Point, CByte(0))
        lblLimaJuta.Location = New Point(229, 50)
        lblLimaJuta.Name = "lblLimaJuta"
        lblLimaJuta.Size = New Size(395, 30)
        lblLimaJuta.TabIndex = 0
        lblLimaJuta.Text = "Pendapatan Lebih dari 5 juta, 10% pajak"
        ' 
        ' lblTigaPuluhJuta
        ' 
        lblTigaPuluhJuta.AutoSize = True
        lblTigaPuluhJuta.Font = New Font("Segoe UI Semibold", 15.75F, FontStyle.Bold Or FontStyle.Italic, GraphicsUnit.Point, CByte(0))
        lblTigaPuluhJuta.Location = New Point(229, 99)
        lblTigaPuluhJuta.Name = "lblTigaPuluhJuta"
        lblTigaPuluhJuta.Size = New Size(395, 30)
        lblTigaPuluhJuta.TabIndex = 1
        lblTigaPuluhJuta.Text = "Pendapatan Lebih dari 5 juta, 10% pajak"
        ' 
        ' lblSeratusJuta
        ' 
        lblSeratusJuta.AutoSize = True
        lblSeratusJuta.Font = New Font("Segoe UI Semibold", 15.75F, FontStyle.Bold Or FontStyle.Italic, GraphicsUnit.Point, CByte(0))
        lblSeratusJuta.Location = New Point(229, 152)
        lblSeratusJuta.Name = "lblSeratusJuta"
        lblSeratusJuta.Size = New Size(395, 30)
        lblSeratusJuta.TabIndex = 2
        lblSeratusJuta.Text = "Pendapatan Lebih dari 5 juta, 10% pajak"
        ' 
        ' lblPendapatan
        ' 
        lblPendapatan.AutoSize = True
        lblPendapatan.Font = New Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblPendapatan.Location = New Point(299, 223)
        lblPendapatan.Name = "lblPendapatan"
        lblPendapatan.Size = New Size(215, 25)
        lblPendapatan.TabIndex = 3
        lblPendapatan.Text = "Masukkan Pendapatan"
        ' 
        ' lblRupiah
        ' 
        lblRupiah.AutoSize = True
        lblRupiah.Font = New Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblRupiah.Location = New Point(253, 269)
        lblRupiah.Name = "lblRupiah"
        lblRupiah.Size = New Size(41, 25)
        lblRupiah.TabIndex = 4
        lblRupiah.Text = "Rp."
        ' 
        ' btnHitung
        ' 
        btnHitung.Location = New Point(354, 323)
        btnHitung.Name = "btnHitung"
        btnHitung.Size = New Size(75, 23)
        btnHitung.TabIndex = 5
        btnHitung.Text = "Hitung"
        btnHitung.UseVisualStyleBackColor = True
        ' 
        ' btnKeluar
        ' 
        btnKeluar.Location = New Point(354, 374)
        btnKeluar.Name = "btnKeluar"
        btnKeluar.Size = New Size(75, 23)
        btnKeluar.TabIndex = 6
        btnKeluar.Text = "keluar"
        btnKeluar.UseVisualStyleBackColor = True
        ' 
        ' txtPendapatan
        ' 
        txtPendapatan.Location = New Point(320, 271)
        txtPendapatan.Name = "txtPendapatan"
        txtPendapatan.Size = New Size(157, 23)
        txtPendapatan.TabIndex = 7
        ' 
        ' frmPajak
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(800, 450)
        Controls.Add(txtPendapatan)
        Controls.Add(btnKeluar)
        Controls.Add(btnHitung)
        Controls.Add(lblRupiah)
        Controls.Add(lblPendapatan)
        Controls.Add(lblSeratusJuta)
        Controls.Add(lblTigaPuluhJuta)
        Controls.Add(lblLimaJuta)
        Name = "frmPajak"
        Text = "FromPajak"
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents lblLimaJuta As Label
    Friend WithEvents lblTigaPuluhJuta As Label
    Friend WithEvents lblSeratusJuta As Label
    Friend WithEvents lblPendapatan As Label
    Friend WithEvents lblRupiah As Label
    Friend WithEvents btnHitung As Button
    Friend WithEvents btnKeluar As Button
    Friend WithEvents txtPendapatan As TextBox
End Class
