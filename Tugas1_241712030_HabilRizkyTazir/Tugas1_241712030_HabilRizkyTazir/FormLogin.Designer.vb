<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmLogin
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
        lblRole = New Label()
        lblNama = New Label()
        lblNim = New Label()
        picImage = New PictureBox()
        txtNama = New TextBox()
        txtNim = New TextBox()
        cmbRole = New ComboBox()
        btnLogin = New Button()
        CType(picImage, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' lblRole
        ' 
        lblRole.AutoSize = True
        lblRole.Location = New Point(181, 197)
        lblRole.Name = "lblRole"
        lblRole.Size = New Size(39, 15)
        lblRole.TabIndex = 0
        lblRole.Text = "Role  :"
        ' 
        ' lblNama
        ' 
        lblNama.AutoSize = True
        lblNama.Location = New Point(181, 233)
        lblNama.Name = "lblNama"
        lblNama.Size = New Size(45, 15)
        lblNama.TabIndex = 1
        lblNama.Text = "Nama :"
        ' 
        ' lblNim
        ' 
        lblNim.AutoSize = True
        lblNim.Location = New Point(181, 271)
        lblNim.Name = "lblNim"
        lblNim.Size = New Size(39, 15)
        lblNim.TabIndex = 2
        lblNim.Text = "Nim  :"
        ' 
        ' picImage
        ' 
        picImage.Location = New Point(245, 63)
        picImage.Name = "picImage"
        picImage.Size = New Size(104, 96)
        picImage.SizeMode = PictureBoxSizeMode.Zoom
        picImage.TabIndex = 3
        picImage.TabStop = False
        ' 
        ' txtNama
        ' 
        txtNama.Location = New Point(245, 233)
        txtNama.Name = "txtNama"
        txtNama.Size = New Size(121, 23)
        txtNama.TabIndex = 4
        ' 
        ' txtNim
        ' 
        txtNim.Location = New Point(245, 271)
        txtNim.Name = "txtNim"
        txtNim.Size = New Size(121, 23)
        txtNim.TabIndex = 5
        ' 
        ' cmbRole
        ' 
        cmbRole.DropDownStyle = ComboBoxStyle.DropDownList
        cmbRole.FormattingEnabled = True
        cmbRole.Location = New Point(245, 194)
        cmbRole.Name = "cmbRole"
        cmbRole.Size = New Size(121, 23)
        cmbRole.TabIndex = 6
        ' 
        ' btnLogin
        ' 
        btnLogin.Location = New Point(245, 329)
        btnLogin.Name = "btnLogin"
        btnLogin.Size = New Size(75, 23)
        btnLogin.TabIndex = 7
        btnLogin.Text = "Login"
        btnLogin.UseVisualStyleBackColor = True
        ' 
        ' frmLogin
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(540, 450)
        Controls.Add(btnLogin)
        Controls.Add(cmbRole)
        Controls.Add(txtNim)
        Controls.Add(txtNama)
        Controls.Add(picImage)
        Controls.Add(lblNim)
        Controls.Add(lblNama)
        Controls.Add(lblRole)
        Name = "frmLogin"
        Text = "FormLogin"
        CType(picImage, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents lblRole As Label
    Friend WithEvents lblNama As Label
    Friend WithEvents lblNim As Label
    Friend WithEvents picImage As PictureBox
    Friend WithEvents txtNama As TextBox
    Friend WithEvents txtNim As TextBox
    Friend WithEvents cmbRole As ComboBox
    Friend WithEvents btnLogin As Button
End Class
