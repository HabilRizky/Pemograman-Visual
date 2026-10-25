Imports System.Windows.Forms
Partial Class FrmDariList
    Inherits System.Windows.Forms.Form

    Public Sub New()
        MyBase.New()
        InitializeComponent()
    End Sub

    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    Private components As System.ComponentModel.IContainer

    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.lblJudul = New System.Windows.Forms.Label()
        Me.lblNim = New System.Windows.Forms.Label()
        Me.txtNim = New System.Windows.Forms.TextBox()
        Me.lblNama = New System.Windows.Forms.Label()
        Me.txtNama = New System.Windows.Forms.TextBox()
        Me.lblJurusan = New System.Windows.Forms.Label()
        Me.cboJurusan = New System.Windows.Forms.ComboBox()
        Me.lblAngkatan = New System.Windows.Forms.Label()
        Me.txtAngkatan = New System.Windows.Forms.TextBox()
        Me.lblIpk = New System.Windows.Forms.Label()
        Me.txtIpk = New System.Windows.Forms.TextBox()
        Me.btnTambah = New System.Windows.Forms.Button()
        Me.dgvMahasiswa = New System.Windows.Forms.DataGridView()
        Me.lblJumlah = New System.Windows.Forms.Label()
        Me.bsMahasiswa = New System.Windows.Forms.BindingSource(Me.components)
        Me.errInput = New System.Windows.Forms.ErrorProvider(Me.components)
        CType(Me.dgvMahasiswa, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.bsMahasiswa, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.errInput, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblJudul
        '
        Me.lblJudul.AutoSize = True
        Me.lblJudul.Font = New System.Drawing.Font("Segoe UI", 14.0!, System.Drawing.FontStyle.Bold)
        Me.lblJudul.Location = New System.Drawing.Point(20, 15)
        Me.lblJudul.Name = "lblJudul"
        Me.lblJudul.Size = New System.Drawing.Size(300, 32)
        Me.lblJudul.TabIndex = 0
        Me.lblJudul.Text = "List(Of Mahasiswa) + BindingSource"
        '
        'lblNim
        '
        Me.lblNim.AutoSize = True
        Me.lblNim.Location = New System.Drawing.Point(20, 65)
        Me.lblNim.Name = "lblNim"
        Me.lblNim.Size = New System.Drawing.Size(32, 15)
        Me.lblNim.TabIndex = 1
        Me.lblNim.Text = "NIM"
        '
        'txtNim
        '
        Me.txtNim.Location = New System.Drawing.Point(90, 62)
        Me.txtNim.MaxLength = 9
        Me.txtNim.Name = "txtNim"
        Me.txtNim.Size = New System.Drawing.Size(100, 23)
        Me.txtNim.TabIndex = 2
        '
        'lblNama
        '
        Me.lblNama.AutoSize = True
        Me.lblNama.Location = New System.Drawing.Point(210, 65)
        Me.lblNama.Name = "lblNama"
        Me.lblNama.Size = New System.Drawing.Size(40, 15)
        Me.lblNama.TabIndex = 3
        Me.lblNama.Text = "Nama"
        '
        'txtNama
        '
        Me.txtNama.Location = New System.Drawing.Point(260, 62)
        Me.txtNama.Name = "txtNama"
        Me.txtNama.Size = New System.Drawing.Size(160, 23)
        Me.txtNama.TabIndex = 4
        '
        'lblJurusan
        '
        Me.lblJurusan.AutoSize = True
        Me.lblJurusan.Location = New System.Drawing.Point(440, 65)
        Me.lblJurusan.Name = "lblJurusan"
        Me.lblJurusan.Size = New System.Drawing.Size(50, 15)
        Me.lblJurusan.TabIndex = 5
        Me.lblJurusan.Text = "Jurusan"
        '
        'cboJurusan
        '
        Me.cboJurusan.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboJurusan.FormattingEnabled = True
        Me.cboJurusan.Items.AddRange(New Object() {"Teknik Informatika", "Sistem Informasi", "Manajemen Informatika", "Teknik Komputer"})
        Me.cboJurusan.Location = New System.Drawing.Point(500, 62)
        Me.cboJurusan.Name = "cboJurusan"
        Me.cboJurusan.Size = New System.Drawing.Size(200, 23)
        Me.cboJurusan.TabIndex = 6
        '
        'lblAngkatan
        '
        Me.lblAngkatan.AutoSize = True
        Me.lblAngkatan.Location = New System.Drawing.Point(20, 100)
        Me.lblAngkatan.Name = "lblAngkatan"
        Me.lblAngkatan.Size = New System.Drawing.Size(60, 15)
        Me.lblAngkatan.TabIndex = 7
        Me.lblAngkatan.Text = "Angkatan"
        '
        'txtAngkatan
        '
        Me.txtAngkatan.Location = New System.Drawing.Point(90, 97)
        Me.txtAngkatan.MaxLength = 4
        Me.txtAngkatan.Name = "txtAngkatan"
        Me.txtAngkatan.Size = New System.Drawing.Size(100, 23)
        Me.txtAngkatan.TabIndex = 8
        '
        'lblIpk
        '
        Me.lblIpk.AutoSize = True
        Me.lblIpk.Location = New System.Drawing.Point(210, 100)
        Me.lblIpk.Name = "lblIpk"
        Me.lblIpk.Size = New System.Drawing.Size(24, 15)
        Me.lblIpk.TabIndex = 9
        Me.lblIpk.Text = "IPK"
        '
        'txtIpk
        '
        Me.txtIpk.Location = New System.Drawing.Point(260, 97)
        Me.txtIpk.MaxLength = 4
        Me.txtIpk.Name = "txtIpk"
        Me.txtIpk.Size = New System.Drawing.Size(100, 23)
        Me.txtIpk.TabIndex = 10
        '
        'btnTambah
        '
        Me.btnTambah.Location = New System.Drawing.Point(620, 96)
        Me.btnTambah.Name = "btnTambah"
        Me.btnTambah.Size = New System.Drawing.Size(120, 26)
        Me.btnTambah.TabIndex = 11
        Me.btnTambah.Text = "Tambah"
        Me.btnTambah.UseVisualStyleBackColor = True
        '
        'dgvMahasiswa
        '
        Me.dgvMahasiswa.AllowUserToAddRows = False
        Me.dgvMahasiswa.AllowUserToDeleteRows = False
        Me.dgvMahasiswa.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvMahasiswa.Location = New System.Drawing.Point(20, 135)
        Me.dgvMahasiswa.MultiSelect = False
        Me.dgvMahasiswa.Name = "dgvMahasiswa"
        Me.dgvMahasiswa.ReadOnly = True
        Me.dgvMahasiswa.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvMahasiswa.Size = New System.Drawing.Size(720, 280)
        Me.dgvMahasiswa.TabIndex = 12
        '
        'lblJumlah
        '
        Me.lblJumlah.AutoSize = True
        Me.lblJumlah.Location = New System.Drawing.Point(20, 428)
        Me.lblJumlah.Name = "lblJumlah"
        Me.lblJumlah.Size = New System.Drawing.Size(87, 15)
        Me.lblJumlah.TabIndex = 13
        Me.lblJumlah.Text = "Jumlah data: 0"
        '
        'bsMahasiswa
        '
        '
        'errInput
        '
        Me.errInput.ContainerControl = Me
        '
        'FrmDariList
        '
        Me.AcceptButton = Me.btnTambah
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(760, 470)
        Me.Controls.Add(Me.lblJumlah)
        Me.Controls.Add(Me.dgvMahasiswa)
        Me.Controls.Add(Me.btnTambah)
        Me.Controls.Add(Me.txtIpk)
        Me.Controls.Add(Me.lblIpk)
        Me.Controls.Add(Me.txtAngkatan)
        Me.Controls.Add(Me.lblAngkatan)
        Me.Controls.Add(Me.cboJurusan)
        Me.Controls.Add(Me.lblJurusan)
        Me.Controls.Add(Me.txtNama)
        Me.Controls.Add(Me.lblNama)
        Me.Controls.Add(Me.txtNim)
        Me.Controls.Add(Me.lblNim)
        Me.Controls.Add(Me.lblJudul)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "FrmDariList"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Binding List(Of Mahasiswa)"
        CType(Me.dgvMahasiswa, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.bsMahasiswa, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.errInput, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lblJudul As Label
    Friend WithEvents lblNim As Label
    Friend WithEvents txtNim As TextBox
    Friend WithEvents lblNama As Label
    Friend WithEvents txtNama As TextBox
    Friend WithEvents lblJurusan As Label
    Friend WithEvents cboJurusan As ComboBox
    Friend WithEvents lblAngkatan As Label
    Friend WithEvents txtAngkatan As TextBox
    Friend WithEvents lblIpk As Label
    Friend WithEvents txtIpk As TextBox
    Friend WithEvents btnTambah As Button
    Friend WithEvents dgvMahasiswa As DataGridView
    Friend WithEvents lblJumlah As Label
    Friend WithEvents bsMahasiswa As BindingSource
    Friend WithEvents errInput As ErrorProvider
End Class
