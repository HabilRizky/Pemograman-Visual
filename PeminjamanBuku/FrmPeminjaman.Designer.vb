Partial Class FrmPeminjaman
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
        Me.lblJudulForm = New System.Windows.Forms.Label()
        Me.lblKodeBuku = New System.Windows.Forms.Label()
        Me.txtKodeBuku = New System.Windows.Forms.TextBox()
        Me.lblJudul = New System.Windows.Forms.Label()
        Me.txtJudul = New System.Windows.Forms.TextBox()
        Me.lblKategori = New System.Windows.Forms.Label()
        Me.cboKategori = New System.Windows.Forms.ComboBox()
        Me.lblNamaPeminjam = New System.Windows.Forms.Label()
        Me.txtNamaPeminjam = New System.Windows.Forms.TextBox()
        Me.lblLamaPinjam = New System.Windows.Forms.Label()
        Me.txtLamaPinjam = New System.Windows.Forms.TextBox()
        Me.btnPinjam = New System.Windows.Forms.Button()
        Me.btnBersihkan = New System.Windows.Forms.Button()
        Me.lstPeminjaman = New System.Windows.Forms.ListBox()
        Me.btnEkspor = New System.Windows.Forms.Button()
        Me.lblStatus = New System.Windows.Forms.Label()
        Me.errPinjam = New System.Windows.Forms.ErrorProvider(Me.components)
        CType(Me.errPinjam, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblJudulForm
        '
        Me.lblJudulForm.AutoSize = True
        Me.lblJudulForm.Font = New System.Drawing.Font("Segoe UI", 14.0!, System.Drawing.FontStyle.Bold)
        Me.lblJudulForm.Location = New System.Drawing.Point(20, 15)
        Me.lblJudulForm.Name = "lblJudulForm"
        Me.lblJudulForm.Size = New System.Drawing.Size(180, 32)
        Me.lblJudulForm.TabIndex = 0
        Me.lblJudulForm.Text = "Peminjaman Buku"
        '
        'lblKodeBuku
        '
        Me.lblKodeBuku.AutoSize = True
        Me.lblKodeBuku.Location = New System.Drawing.Point(20, 65)
        Me.lblKodeBuku.Name = "lblKodeBuku"
        Me.lblKodeBuku.Size = New System.Drawing.Size(70, 15)
        Me.lblKodeBuku.TabIndex = 1
        Me.lblKodeBuku.Text = "Kode Buku"
        '
        'txtKodeBuku
        '
        Me.txtKodeBuku.Location = New System.Drawing.Point(140, 62)
        Me.txtKodeBuku.MaxLength = 6
        Me.txtKodeBuku.Name = "txtKodeBuku"
        Me.txtKodeBuku.Size = New System.Drawing.Size(150, 23)
        Me.txtKodeBuku.TabIndex = 2
        '
        'lblJudul
        '
        Me.lblJudul.AutoSize = True
        Me.lblJudul.Location = New System.Drawing.Point(20, 100)
        Me.lblJudul.Name = "lblJudul"
        Me.lblJudul.Size = New System.Drawing.Size(66, 15)
        Me.lblJudul.TabIndex = 3
        Me.lblJudul.Text = "Judul Buku"
        '
        'txtJudul
        '
        Me.txtJudul.Location = New System.Drawing.Point(140, 97)
        Me.txtJudul.Name = "txtJudul"
        Me.txtJudul.Size = New System.Drawing.Size(300, 23)
        Me.txtJudul.TabIndex = 4
        '
        'lblKategori
        '
        Me.lblKategori.AutoSize = True
        Me.lblKategori.Location = New System.Drawing.Point(20, 135)
        Me.lblKategori.Name = "lblKategori"
        Me.lblKategori.Size = New System.Drawing.Size(50, 15)
        Me.lblKategori.TabIndex = 5
        Me.lblKategori.Text = "Kategori"
        '
        'cboKategori
        '
        Me.cboKategori.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboKategori.FormattingEnabled = True
        Me.cboKategori.Items.AddRange(New Object() {"Fiksi", "Nonfiksi", "Referensi", "Majalah"})
        Me.cboKategori.Location = New System.Drawing.Point(140, 132)
        Me.cboKategori.Name = "cboKategori"
        Me.cboKategori.Size = New System.Drawing.Size(200, 23)
        Me.cboKategori.TabIndex = 6
        '
        'lblNamaPeminjam
        '
        Me.lblNamaPeminjam.AutoSize = True
        Me.lblNamaPeminjam.Location = New System.Drawing.Point(20, 170)
        Me.lblNamaPeminjam.Name = "lblNamaPeminjam"
        Me.lblNamaPeminjam.Size = New System.Drawing.Size(95, 15)
        Me.lblNamaPeminjam.TabIndex = 7
        Me.lblNamaPeminjam.Text = "Nama Peminjam"
        '
        'txtNamaPeminjam
        '
        Me.txtNamaPeminjam.Location = New System.Drawing.Point(140, 167)
        Me.txtNamaPeminjam.Name = "txtNamaPeminjam"
        Me.txtNamaPeminjam.Size = New System.Drawing.Size(300, 23)
        Me.txtNamaPeminjam.TabIndex = 8
        '
        'lblLamaPinjam
        '
        Me.lblLamaPinjam.AutoSize = True
        Me.lblLamaPinjam.Location = New System.Drawing.Point(20, 205)
        Me.lblLamaPinjam.Name = "lblLamaPinjam"
        Me.lblLamaPinjam.Size = New System.Drawing.Size(115, 15)
        Me.lblLamaPinjam.TabIndex = 9
        Me.lblLamaPinjam.Text = "Lama Pinjam (hari)"
        '
        'txtLamaPinjam
        '
        Me.txtLamaPinjam.Location = New System.Drawing.Point(140, 202)
        Me.txtLamaPinjam.MaxLength = 2
        Me.txtLamaPinjam.Name = "txtLamaPinjam"
        Me.txtLamaPinjam.Size = New System.Drawing.Size(100, 23)
        Me.txtLamaPinjam.TabIndex = 10
        '
        'btnPinjam
        '
        Me.btnPinjam.Location = New System.Drawing.Point(20, 240)
        Me.btnPinjam.Name = "btnPinjam"
        Me.btnPinjam.Size = New System.Drawing.Size(140, 32)
        Me.btnPinjam.TabIndex = 11
        Me.btnPinjam.Text = "Pinjam"
        Me.btnPinjam.UseVisualStyleBackColor = True
        '
        'btnBersihkan
        '
        Me.btnBersihkan.CausesValidation = False
        Me.btnBersihkan.Location = New System.Drawing.Point(170, 240)
        Me.btnBersihkan.Name = "btnBersihkan"
        Me.btnBersihkan.Size = New System.Drawing.Size(140, 32)
        Me.btnBersihkan.TabIndex = 12
        Me.btnBersihkan.Text = "Bersihkan"
        Me.btnBersihkan.UseVisualStyleBackColor = True
        '
        'lstPeminjaman
        '
        Me.lstPeminjaman.HorizontalScrollbar = True
        Me.lstPeminjaman.IntegralHeight = False
        Me.lstPeminjaman.Location = New System.Drawing.Point(20, 285)
        Me.lstPeminjaman.Name = "lstPeminjaman"
        Me.lstPeminjaman.Size = New System.Drawing.Size(700, 150)
        Me.lstPeminjaman.TabIndex = 13
        '
        'btnEkspor
        '
        Me.btnEkspor.CausesValidation = False
        Me.btnEkspor.Location = New System.Drawing.Point(20, 445)
        Me.btnEkspor.Name = "btnEkspor"
        Me.btnEkspor.Size = New System.Drawing.Size(160, 32)
        Me.btnEkspor.TabIndex = 14
        Me.btnEkspor.Text = "Ekspor ke CSV"
        Me.btnEkspor.UseVisualStyleBackColor = True
        '
        'lblStatus
        '
        Me.lblStatus.AutoSize = False
        Me.lblStatus.Location = New System.Drawing.Point(190, 452)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(530, 23)
        Me.lblStatus.TabIndex = 15
        Me.lblStatus.Text = "Siap."
        '
        'errPinjam
        '
        Me.errPinjam.ContainerControl = Me
        '
        'FrmPeminjaman
        '
        Me.AcceptButton = Me.btnPinjam
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(760, 495)
        Me.Controls.Add(Me.lblStatus)
        Me.Controls.Add(Me.btnEkspor)
        Me.Controls.Add(Me.lstPeminjaman)
        Me.Controls.Add(Me.btnBersihkan)
        Me.Controls.Add(Me.btnPinjam)
        Me.Controls.Add(Me.txtLamaPinjam)
        Me.Controls.Add(Me.lblLamaPinjam)
        Me.Controls.Add(Me.txtNamaPeminjam)
        Me.Controls.Add(Me.lblNamaPeminjam)
        Me.Controls.Add(Me.cboKategori)
        Me.Controls.Add(Me.lblKategori)
        Me.Controls.Add(Me.txtJudul)
        Me.Controls.Add(Me.lblJudul)
        Me.Controls.Add(Me.txtKodeBuku)
        Me.Controls.Add(Me.lblKodeBuku)
        Me.Controls.Add(Me.lblJudulForm)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "FrmPeminjaman"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Peminjaman Buku"
        CType(Me.errPinjam, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lblJudulForm As Label
    Friend WithEvents lblKodeBuku As Label
    Friend WithEvents txtKodeBuku As TextBox
    Friend WithEvents lblJudul As Label
    Friend WithEvents txtJudul As TextBox
    Friend WithEvents lblKategori As Label
    Friend WithEvents cboKategori As ComboBox
    Friend WithEvents lblNamaPeminjam As Label
    Friend WithEvents txtNamaPeminjam As TextBox
    Friend WithEvents lblLamaPinjam As Label
    Friend WithEvents txtLamaPinjam As TextBox
    Friend WithEvents btnPinjam As Button
    Friend WithEvents btnBersihkan As Button
    Friend WithEvents lstPeminjaman As ListBox
    Friend WithEvents btnEkspor As Button
    Friend WithEvents lblStatus As Label
    Friend WithEvents errPinjam As ErrorProvider
End Class
