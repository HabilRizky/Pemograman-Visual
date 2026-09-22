<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormMahasiswa
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
        btnTampilkan = New Button()
        dgvMahasiswa = New DataGridView()
        btnTambah = New Button()
        lblNama = New Label()
        lblNim = New Label()
        lblJurusan = New Label()
        txtNama = New TextBox()
        txtNim = New TextBox()
        txtJurusan = New TextBox()
        CType(dgvMahasiswa, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' btnTampilkan
        ' 
        btnTampilkan.Location = New Point(217, 261)
        btnTampilkan.Name = "btnTampilkan"
        btnTampilkan.Size = New Size(75, 23)
        btnTampilkan.TabIndex = 0
        btnTampilkan.Text = "Tampilkan"
        btnTampilkan.UseVisualStyleBackColor = True
        ' 
        ' dgvMahasiswa
        ' 
        dgvMahasiswa.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvMahasiswa.Location = New Point(35, 26)
        dgvMahasiswa.Name = "dgvMahasiswa"
        dgvMahasiswa.Size = New Size(436, 213)
        dgvMahasiswa.TabIndex = 1
        ' 
        ' btnTambah
        ' 
        btnTambah.Location = New Point(570, 203)
        btnTambah.Name = "btnTambah"
        btnTambah.Size = New Size(75, 23)
        btnTambah.TabIndex = 2
        btnTambah.Text = "Tambah"
        btnTambah.UseVisualStyleBackColor = True
        ' 
        ' lblNama
        ' 
        lblNama.AutoSize = True
        lblNama.Location = New Point(477, 76)
        lblNama.Name = "lblNama"
        lblNama.Size = New Size(39, 15)
        lblNama.TabIndex = 3
        lblNama.Text = "Nama"
        ' 
        ' lblNim
        ' 
        lblNim.AutoSize = True
        lblNim.Location = New Point(477, 122)
        lblNim.Name = "lblNim"
        lblNim.Size = New Size(30, 15)
        lblNim.TabIndex = 4
        lblNim.Text = "NIM"
        ' 
        ' lblJurusan
        ' 
        lblJurusan.AutoSize = True
        lblJurusan.Location = New Point(477, 167)
        lblJurusan.Name = "lblJurusan"
        lblJurusan.Size = New Size(47, 15)
        lblJurusan.TabIndex = 5
        lblJurusan.Text = "Jurusan"
        ' 
        ' txtNama
        ' 
        txtNama.Location = New Point(545, 73)
        txtNama.Name = "txtNama"
        txtNama.Size = New Size(124, 23)
        txtNama.TabIndex = 6
        ' 
        ' txtNim
        ' 
        txtNim.Location = New Point(545, 122)
        txtNim.Name = "txtNim"
        txtNim.Size = New Size(124, 23)
        txtNim.TabIndex = 7
        ' 
        ' txtJurusan
        ' 
        txtJurusan.Location = New Point(545, 167)
        txtJurusan.Name = "txtJurusan"
        txtJurusan.Size = New Size(124, 23)
        txtJurusan.TabIndex = 8
        ' 
        ' FormMahasiswa
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(719, 450)
        Controls.Add(txtJurusan)
        Controls.Add(txtNim)
        Controls.Add(txtNama)
        Controls.Add(lblJurusan)
        Controls.Add(lblNim)
        Controls.Add(lblNama)
        Controls.Add(btnTambah)
        Controls.Add(dgvMahasiswa)
        Controls.Add(btnTampilkan)
        Name = "FormMahasiswa"
        Text = "Form1"
        CType(dgvMahasiswa, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents btnTampilkan As Button
    Friend WithEvents dgvMahasiswa As DataGridView
    Friend WithEvents btnTambah As Button
    Friend WithEvents lblNama As Label
    Friend WithEvents lblNim As Label
    Friend WithEvents lblJurusan As Label
    Friend WithEvents txtNama As TextBox
    Friend WithEvents txtNim As TextBox
    Friend WithEvents txtJurusan As TextBox

End Class
