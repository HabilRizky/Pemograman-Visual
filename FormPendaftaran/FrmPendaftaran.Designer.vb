Partial Class FrmPendaftaran
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
        Me.btnSimpan = New System.Windows.Forms.Button()
        Me.btnBersihkan = New System.Windows.Forms.Button()
        Me.lblDaftar = New System.Windows.Forms.Label()
        Me.lstMahasiswa = New System.Windows.Forms.ListBox()
        Me.btnEkspor = New System.Windows.Forms.Button()
        Me.lblStatus = New System.Windows.Forms.Label()
        Me.errInput = New System.Windows.Forms.ErrorProvider(Me.components)
        CType(Me.errInput, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblJudul
        '
        Me.lblJudul.AutoSize = True
        Me.lblJudul.Font = New System.Drawing.Font("Segoe UI", 14.0!, System.Drawing.FontStyle.Bold)
        Me.lblJudul.Location = New System.Drawing.Point(20, 15)
        Me.lblJudul.Name = "lblJudul"
        Me.lblJudul.Size = New System.Drawing.Size(260, 32)
        Me.lblJudul.TabIndex = 0
        Me.lblJudul.Text = "Pendaftaran Mahasiswa"
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
        Me.txtNim.Location = New System.Drawing.Point(110, 62)
        Me.txtNim.MaxLength = 9
        Me.txtNim.Name = "txtNim"
        Me.txtNim.Size = New System.Drawing.Size(220, 23)
        Me.txtNim.TabIndex = 2
        '
        'lblNama
        '
        Me.lblNama.AutoSize = True
        Me.lblNama.Location = New System.Drawing.Point(20, 100)
        Me.lblNama.Name = "lblNama"
        Me.lblNama.Size = New System.Drawing.Size(40, 15)
        Me.lblNama.TabIndex = 3
        Me.lblNama.Text = "Nama"
        '
        'txtNama
        '
        Me.txtNama.Location = New System.Drawing.Point(110, 97)
        Me.txtNama.MaxLength = 100
        Me.txtNama.Name = "txtNama"
        Me.txtNama.Size = New System.Drawing.Size(220, 23)
        Me.txtNama.TabIndex = 4
        '
        'lblJurusan
        '
        Me.lblJurusan.AutoSize = True
        Me.lblJurusan.Location = New System.Drawing.Point(20, 135)
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
        Me.cboJurusan.Location = New System.Drawing.Point(110, 132)
        Me.cboJurusan.Name = "cboJurusan"
        Me.cboJurusan.Size = New System.Drawing.Size(220, 23)
        Me.cboJurusan.TabIndex = 6
        '
        'lblAngkatan
        '
        Me.lblAngkatan.AutoSize = True
        Me.lblAngkatan.Location = New System.Drawing.Point(20, 170)
        Me.lblAngkatan.Name = "lblAngkatan"
        Me.lblAngkatan.Size = New System.Drawing.Size(60, 15)
        Me.lblAngkatan.TabIndex = 7
        Me.lblAngkatan.Text = "Angkatan"
        '
        'txtAngkatan
        '
        Me.txtAngkatan.Location = New System.Drawing.Point(110, 167)
        Me.txtAngkatan.MaxLength = 4
        Me.txtAngkatan.Name = "txtAngkatan"
        Me.txtAngkatan.Size = New System.Drawing.Size(120, 23)
        Me.txtAngkatan.TabIndex = 8
        '
        'lblIpk
        '
        Me.lblIpk.AutoSize = True
        Me.lblIpk.Location = New System.Drawing.Point(20, 205)
        Me.lblIpk.Name = "lblIpk"
        Me.lblIpk.Size = New System.Drawing.Size(24, 15)
        Me.lblIpk.TabIndex = 9
        Me.lblIpk.Text = "IPK"
        '
        'txtIpk
        '
        Me.txtIpk.Location = New System.Drawing.Point(110, 202)
        Me.txtIpk.MaxLength = 4
        Me.txtIpk.Name = "txtIpk"
        Me.txtIpk.Size = New System.Drawing.Size(120, 23)
        Me.txtIpk.TabIndex = 10
        '
        'btnSimpan
        '
        Me.btnSimpan.Location = New System.Drawing.Point(20, 245)
        Me.btnSimpan.Name = "btnSimpan"
        Me.btnSimpan.Size = New System.Drawing.Size(150, 32)
        Me.btnSimpan.TabIndex = 11
        Me.btnSimpan.Text = "Simpan"
        Me.btnSimpan.UseVisualStyleBackColor = True
        '
        'btnBersihkan
        '
        Me.btnBersihkan.CausesValidation = False
        Me.btnBersihkan.Location = New System.Drawing.Point(180, 245)
        Me.btnBersihkan.Name = "btnBersihkan"
        Me.btnBersihkan.Size = New System.Drawing.Size(150, 32)
        Me.btnBersihkan.TabIndex = 12
        Me.btnBersihkan.Text = "Bersihkan"
        Me.btnBersihkan.UseVisualStyleBackColor = True
        '
        'lblDaftar
        '
        Me.lblDaftar.AutoSize = True
        Me.lblDaftar.Location = New System.Drawing.Point(360, 65)
        Me.lblDaftar.Name = "lblDaftar"
        Me.lblDaftar.Size = New System.Drawing.Size(85, 15)
        Me.lblDaftar.TabIndex = 13
        Me.lblDaftar.Text = "Data tersimpan"
        '
        'lstMahasiswa
        '
        Me.lstMahasiswa.HorizontalScrollbar = True
        Me.lstMahasiswa.IntegralHeight = False
        Me.lstMahasiswa.Location = New System.Drawing.Point(360, 90)
        Me.lstMahasiswa.Name = "lstMahasiswa"
        Me.lstMahasiswa.Size = New System.Drawing.Size(400, 280)
        Me.lstMahasiswa.TabIndex = 14
        '
        'btnEkspor
        '
        Me.btnEkspor.CausesValidation = False
        Me.btnEkspor.Location = New System.Drawing.Point(360, 380)
        Me.btnEkspor.Name = "btnEkspor"
        Me.btnEkspor.Size = New System.Drawing.Size(150, 30)
        Me.btnEkspor.TabIndex = 15
        Me.btnEkspor.Text = "Ekspor ke CSV"
        Me.btnEkspor.UseVisualStyleBackColor = True
        '
        'lblStatus
        '
        Me.lblStatus.AutoSize = False
        Me.lblStatus.Location = New System.Drawing.Point(20, 430)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(740, 25)
        Me.lblStatus.TabIndex = 16
        Me.lblStatus.Text = "Siap."
        '
        'errInput
        '
        Me.errInput.ContainerControl = Me
        '
        'FrmPendaftaran
        '
        Me.AcceptButton = Me.btnSimpan
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(780, 470)
        Me.Controls.Add(Me.lblStatus)
        Me.Controls.Add(Me.btnEkspor)
        Me.Controls.Add(Me.lstMahasiswa)
        Me.Controls.Add(Me.lblDaftar)
        Me.Controls.Add(Me.btnBersihkan)
        Me.Controls.Add(Me.btnSimpan)
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
        Me.Name = "FrmPendaftaran"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Pendaftaran Mahasiswa"
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
    Friend WithEvents btnSimpan As Button
    Friend WithEvents btnBersihkan As Button
    Friend WithEvents lblDaftar As Label
    Friend WithEvents lstMahasiswa As ListBox
    Friend WithEvents btnEkspor As Button
    Friend WithEvents lblStatus As Label
    Friend WithEvents errInput As ErrorProvider
End Class
