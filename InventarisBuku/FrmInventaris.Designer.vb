Partial Class FrmInventaris
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
        Me.lblPenulis = New System.Windows.Forms.Label()
        Me.txtPenulis = New System.Windows.Forms.TextBox()
        Me.lblKategori = New System.Windows.Forms.Label()
        Me.cboKategori = New System.Windows.Forms.ComboBox()
        Me.lblTahun = New System.Windows.Forms.Label()
        Me.txtTahun = New System.Windows.Forms.TextBox()
        Me.lblStok = New System.Windows.Forms.Label()
        Me.txtStok = New System.Windows.Forms.TextBox()
        Me.btnTambah = New System.Windows.Forms.Button()
        Me.btnBersihkan = New System.Windows.Forms.Button()
        Me.lblCari = New System.Windows.Forms.Label()
        Me.txtCari = New System.Windows.Forms.TextBox()
        Me.lblFilterKategori = New System.Windows.Forms.Label()
        Me.cboFilterKategori = New System.Windows.Forms.ComboBox()
        Me.lblUrut = New System.Windows.Forms.Label()
        Me.cboUrut = New System.Windows.Forms.ComboBox()
        Me.chkStokHabis = New System.Windows.Forms.CheckBox()
        Me.dgvBuku = New System.Windows.Forms.DataGridView()
        Me.lblJumlah = New System.Windows.Forms.Label()
        Me.lblTotalStok = New System.Windows.Forms.Label()
        Me.bsBuku = New System.Windows.Forms.BindingSource(Me.components)
        Me.errBuku = New System.Windows.Forms.ErrorProvider(Me.components)
        CType(Me.dgvBuku, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.bsBuku, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.errBuku, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblJudulForm
        '
        Me.lblJudulForm.AutoSize = True
        Me.lblJudulForm.Font = New System.Drawing.Font("Segoe UI", 14.0!, System.Drawing.FontStyle.Bold)
        Me.lblJudulForm.Location = New System.Drawing.Point(20, 15)
        Me.lblJudulForm.Name = "lblJudulForm"
        Me.lblJudulForm.Size = New System.Drawing.Size(320, 32)
        Me.lblJudulForm.TabIndex = 0
        Me.lblJudulForm.Text = "Inventaris Buku Perpustakaan"
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
        Me.txtKodeBuku.Location = New System.Drawing.Point(110, 62)
        Me.txtKodeBuku.MaxLength = 6
        Me.txtKodeBuku.Name = "txtKodeBuku"
        Me.txtKodeBuku.Size = New System.Drawing.Size(100, 23)
        Me.txtKodeBuku.TabIndex = 2
        '
        'lblJudul
        '
        Me.lblJudul.AutoSize = True
        Me.lblJudul.Location = New System.Drawing.Point(230, 65)
        Me.lblJudul.Name = "lblJudul"
        Me.lblJudul.Size = New System.Drawing.Size(34, 15)
        Me.lblJudul.TabIndex = 3
        Me.lblJudul.Text = "Judul"
        '
        'txtJudul
        '
        Me.txtJudul.Location = New System.Drawing.Point(280, 62)
        Me.txtJudul.Name = "txtJudul"
        Me.txtJudul.Size = New System.Drawing.Size(220, 23)
        Me.txtJudul.TabIndex = 4
        '
        'lblPenulis
        '
        Me.lblPenulis.AutoSize = True
        Me.lblPenulis.Location = New System.Drawing.Point(520, 65)
        Me.lblPenulis.Name = "lblPenulis"
        Me.lblPenulis.Size = New System.Drawing.Size(47, 15)
        Me.lblPenulis.TabIndex = 5
        Me.lblPenulis.Text = "Penulis"
        '
        'txtPenulis
        '
        Me.txtPenulis.Location = New System.Drawing.Point(580, 62)
        Me.txtPenulis.Name = "txtPenulis"
        Me.txtPenulis.Size = New System.Drawing.Size(200, 23)
        Me.txtPenulis.TabIndex = 6
        '
        'lblKategori
        '
        Me.lblKategori.AutoSize = True
        Me.lblKategori.Location = New System.Drawing.Point(20, 100)
        Me.lblKategori.Name = "lblKategori"
        Me.lblKategori.Size = New System.Drawing.Size(50, 15)
        Me.lblKategori.TabIndex = 7
        Me.lblKategori.Text = "Kategori"
        '
        'cboKategori
        '
        Me.cboKategori.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboKategori.FormattingEnabled = True
        Me.cboKategori.Items.AddRange(New Object() {"Fiksi", "Nonfiksi", "Referensi", "Majalah"})
        Me.cboKategori.Location = New System.Drawing.Point(110, 97)
        Me.cboKategori.Name = "cboKategori"
        Me.cboKategori.Size = New System.Drawing.Size(150, 23)
        Me.cboKategori.TabIndex = 8
        '
        'lblTahun
        '
        Me.lblTahun.AutoSize = True
        Me.lblTahun.Location = New System.Drawing.Point(280, 100)
        Me.lblTahun.Name = "lblTahun"
        Me.lblTahun.Size = New System.Drawing.Size(39, 15)
        Me.lblTahun.TabIndex = 9
        Me.lblTahun.Text = "Tahun"
        '
        'txtTahun
        '
        Me.txtTahun.Location = New System.Drawing.Point(330, 97)
        Me.txtTahun.MaxLength = 4
        Me.txtTahun.Name = "txtTahun"
        Me.txtTahun.Size = New System.Drawing.Size(80, 23)
        Me.txtTahun.TabIndex = 10
        '
        'lblStok
        '
        Me.lblStok.AutoSize = True
        Me.lblStok.Location = New System.Drawing.Point(430, 100)
        Me.lblStok.Name = "lblStok"
        Me.lblStok.Size = New System.Drawing.Size(27, 15)
        Me.lblStok.TabIndex = 11
        Me.lblStok.Text = "Stok"
        '
        'txtStok
        '
        Me.txtStok.Location = New System.Drawing.Point(470, 97)
        Me.txtStok.MaxLength = 4
        Me.txtStok.Name = "txtStok"
        Me.txtStok.Size = New System.Drawing.Size(80, 23)
        Me.txtStok.TabIndex = 12
        '
        'btnTambah
        '
        Me.btnTambah.Location = New System.Drawing.Point(580, 96)
        Me.btnTambah.Name = "btnTambah"
        Me.btnTambah.Size = New System.Drawing.Size(100, 28)
        Me.btnTambah.TabIndex = 13
        Me.btnTambah.Text = "Tambah"
        Me.btnTambah.UseVisualStyleBackColor = True
        '
        'btnBersihkan
        '
        Me.btnBersihkan.CausesValidation = False
        Me.btnBersihkan.Location = New System.Drawing.Point(690, 96)
        Me.btnBersihkan.Name = "btnBersihkan"
        Me.btnBersihkan.Size = New System.Drawing.Size(100, 28)
        Me.btnBersihkan.TabIndex = 14
        Me.btnBersihkan.Text = "Bersihkan"
        Me.btnBersihkan.UseVisualStyleBackColor = True
        '
        'lblCari
        '
        Me.lblCari.AutoSize = True
        Me.lblCari.Location = New System.Drawing.Point(20, 140)
        Me.lblCari.Name = "lblCari"
        Me.lblCari.Size = New System.Drawing.Size(119, 15)
        Me.lblCari.TabIndex = 15
        Me.lblCari.Text = "Cari judul/penulis"
        '
        'txtCari
        '
        Me.txtCari.Location = New System.Drawing.Point(150, 137)
        Me.txtCari.Name = "txtCari"
        Me.txtCari.Size = New System.Drawing.Size(220, 23)
        Me.txtCari.TabIndex = 16
        '
        'lblFilterKategori
        '
        Me.lblFilterKategori.AutoSize = True
        Me.lblFilterKategori.Location = New System.Drawing.Point(390, 140)
        Me.lblFilterKategori.Name = "lblFilterKategori"
        Me.lblFilterKategori.Size = New System.Drawing.Size(50, 15)
        Me.lblFilterKategori.TabIndex = 17
        Me.lblFilterKategori.Text = "Kategori"
        '
        'cboFilterKategori
        '
        Me.cboFilterKategori.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboFilterKategori.FormattingEnabled = True
        Me.cboFilterKategori.Items.AddRange(New Object() {"Semua", "Fiksi", "Nonfiksi", "Referensi", "Majalah"})
        Me.cboFilterKategori.Location = New System.Drawing.Point(460, 137)
        Me.cboFilterKategori.Name = "cboFilterKategori"
        Me.cboFilterKategori.Size = New System.Drawing.Size(150, 23)
        Me.cboFilterKategori.TabIndex = 18
        '
        'lblUrut
        '
        Me.lblUrut.AutoSize = True
        Me.lblUrut.Location = New System.Drawing.Point(20, 175)
        Me.lblUrut.Name = "lblUrut"
        Me.lblUrut.Size = New System.Drawing.Size(45, 15)
        Me.lblUrut.TabIndex = 19
        Me.lblUrut.Text = "Urutkan"
        '
        'cboUrut
        '
        Me.cboUrut.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboUrut.FormattingEnabled = True
        Me.cboUrut.Items.AddRange(New Object() {"Urutan awal", "Judul A-Z", "Tahun terbaru", "Stok terbanyak"})
        Me.cboUrut.Location = New System.Drawing.Point(90, 172)
        Me.cboUrut.Name = "cboUrut"
        Me.cboUrut.Size = New System.Drawing.Size(150, 23)
        Me.cboUrut.TabIndex = 20
        '
        'chkStokHabis
        '
        Me.chkStokHabis.AutoSize = True
        Me.chkStokHabis.Location = New System.Drawing.Point(260, 174)
        Me.chkStokHabis.Name = "chkStokHabis"
        Me.chkStokHabis.Size = New System.Drawing.Size(115, 19)
        Me.chkStokHabis.TabIndex = 21
        Me.chkStokHabis.Text = "Hanya stok habis"
        Me.chkStokHabis.UseVisualStyleBackColor = True
        '
        'dgvBuku
        '
        Me.dgvBuku.AllowUserToAddRows = False
        Me.dgvBuku.AllowUserToDeleteRows = False
        Me.dgvBuku.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvBuku.Location = New System.Drawing.Point(20, 205)
        Me.dgvBuku.MultiSelect = False
        Me.dgvBuku.Name = "dgvBuku"
        Me.dgvBuku.ReadOnly = True
        Me.dgvBuku.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvBuku.Size = New System.Drawing.Size(860, 290)
        Me.dgvBuku.TabIndex = 22
        '
        'lblJumlah
        '
        Me.lblJumlah.AutoSize = True
        Me.lblJumlah.Location = New System.Drawing.Point(20, 508)
        Me.lblJumlah.Name = "lblJumlah"
        Me.lblJumlah.Size = New System.Drawing.Size(170, 15)
        Me.lblJumlah.TabIndex = 23
        Me.lblJumlah.Text = "Menampilkan 0 dari 0 buku"
        '
        'lblTotalStok
        '
        Me.lblTotalStok.AutoSize = True
        Me.lblTotalStok.Location = New System.Drawing.Point(430, 508)
        Me.lblTotalStok.Name = "lblTotalStok"
        Me.lblTotalStok.Size = New System.Drawing.Size(65, 15)
        Me.lblTotalStok.TabIndex = 24
        Me.lblTotalStok.Text = "Total stok: 0"
        '
        'bsBuku
        '
        '
        'errBuku
        '
        Me.errBuku.ContainerControl = Me
        '
        'FrmInventaris
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(900, 545)
        Me.Controls.Add(Me.lblTotalStok)
        Me.Controls.Add(Me.lblJumlah)
        Me.Controls.Add(Me.dgvBuku)
        Me.Controls.Add(Me.chkStokHabis)
        Me.Controls.Add(Me.cboUrut)
        Me.Controls.Add(Me.lblUrut)
        Me.Controls.Add(Me.cboFilterKategori)
        Me.Controls.Add(Me.lblFilterKategori)
        Me.Controls.Add(Me.txtCari)
        Me.Controls.Add(Me.lblCari)
        Me.Controls.Add(Me.btnBersihkan)
        Me.Controls.Add(Me.btnTambah)
        Me.Controls.Add(Me.txtStok)
        Me.Controls.Add(Me.lblStok)
        Me.Controls.Add(Me.txtTahun)
        Me.Controls.Add(Me.lblTahun)
        Me.Controls.Add(Me.cboKategori)
        Me.Controls.Add(Me.lblKategori)
        Me.Controls.Add(Me.txtPenulis)
        Me.Controls.Add(Me.lblPenulis)
        Me.Controls.Add(Me.txtJudul)
        Me.Controls.Add(Me.lblJudul)
        Me.Controls.Add(Me.txtKodeBuku)
        Me.Controls.Add(Me.lblKodeBuku)
        Me.Controls.Add(Me.lblJudulForm)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "FrmInventaris"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Inventaris Buku Perpustakaan"
        CType(Me.dgvBuku, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.bsBuku, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.errBuku, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lblJudulForm As Label
    Friend WithEvents lblKodeBuku As Label
    Friend WithEvents txtKodeBuku As TextBox
    Friend WithEvents lblJudul As Label
    Friend WithEvents txtJudul As TextBox
    Friend WithEvents lblPenulis As Label
    Friend WithEvents txtPenulis As TextBox
    Friend WithEvents lblKategori As Label
    Friend WithEvents cboKategori As ComboBox
    Friend WithEvents lblTahun As Label
    Friend WithEvents txtTahun As TextBox
    Friend WithEvents lblStok As Label
    Friend WithEvents txtStok As TextBox
    Friend WithEvents btnTambah As Button
    Friend WithEvents btnBersihkan As Button
    Friend WithEvents lblCari As Label
    Friend WithEvents txtCari As TextBox
    Friend WithEvents lblFilterKategori As Label
    Friend WithEvents cboFilterKategori As ComboBox
    Friend WithEvents lblUrut As Label
    Friend WithEvents cboUrut As ComboBox
    Friend WithEvents chkStokHabis As CheckBox
    Friend WithEvents dgvBuku As DataGridView
    Friend WithEvents lblJumlah As Label
    Friend WithEvents lblTotalStok As Label
    Friend WithEvents bsBuku As BindingSource
    Friend WithEvents errBuku As ErrorProvider
End Class
