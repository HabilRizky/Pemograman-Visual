Imports System.Windows.Forms
Partial Class FrmDariArray
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
        Me.lblJudul = New System.Windows.Forms.Label()
        Me.dgvMahasiswa = New System.Windows.Forms.DataGridView()
        Me.colNim = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colNama = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colJurusan = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colAngkatan = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colIpk = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.btnTampilkan = New System.Windows.Forms.Button()
        Me.btnKosongkan = New System.Windows.Forms.Button()
        Me.lblJumlah = New System.Windows.Forms.Label()
        CType(Me.dgvMahasiswa, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblJudul
        '
        Me.lblJudul.AutoSize = True
        Me.lblJudul.Font = New System.Drawing.Font("Segoe UI", 14.0!, System.Drawing.FontStyle.Bold)
        Me.lblJudul.Location = New System.Drawing.Point(20, 15)
        Me.lblJudul.Name = "lblJudul"
        Me.lblJudul.Size = New System.Drawing.Size(280, 32)
        Me.lblJudul.TabIndex = 0
        Me.lblJudul.Text = "Data dari Array 2 Dimensi"
        '
        'dgvMahasiswa
        '
        Me.dgvMahasiswa.AllowUserToAddRows = False
        Me.dgvMahasiswa.AllowUserToDeleteRows = False
        Me.dgvMahasiswa.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvMahasiswa.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colNim, Me.colNama, Me.colJurusan, Me.colAngkatan, Me.colIpk})
        Me.dgvMahasiswa.Location = New System.Drawing.Point(20, 60)
        Me.dgvMahasiswa.MultiSelect = False
        Me.dgvMahasiswa.Name = "dgvMahasiswa"
        Me.dgvMahasiswa.ReadOnly = True
        Me.dgvMahasiswa.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvMahasiswa.Size = New System.Drawing.Size(680, 260)
        Me.dgvMahasiswa.TabIndex = 1
        '
        'colNim
        '
        Me.colNim.HeaderText = "NIM"
        Me.colNim.Name = "colNim"
        Me.colNim.ReadOnly = True
        '
        'colNama
        '
        Me.colNama.HeaderText = "Nama"
        Me.colNama.Name = "colNama"
        Me.colNama.ReadOnly = True
        '
        'colJurusan
        '
        Me.colJurusan.HeaderText = "Jurusan"
        Me.colJurusan.Name = "colJurusan"
        Me.colJurusan.ReadOnly = True
        '
        'colAngkatan
        '
        Me.colAngkatan.HeaderText = "Angkatan"
        Me.colAngkatan.Name = "colAngkatan"
        Me.colAngkatan.ReadOnly = True
        '
        'colIpk
        '
        Me.colIpk.HeaderText = "IPK"
        Me.colIpk.Name = "colIpk"
        Me.colIpk.ReadOnly = True
        '
        'btnTampilkan
        '
        Me.btnTampilkan.Location = New System.Drawing.Point(20, 330)
        Me.btnTampilkan.Name = "btnTampilkan"
        Me.btnTampilkan.Size = New System.Drawing.Size(120, 32)
        Me.btnTampilkan.TabIndex = 2
        Me.btnTampilkan.Text = "Tampilkan"
        Me.btnTampilkan.UseVisualStyleBackColor = True
        '
        'btnKosongkan
        '
        Me.btnKosongkan.Location = New System.Drawing.Point(150, 330)
        Me.btnKosongkan.Name = "btnKosongkan"
        Me.btnKosongkan.Size = New System.Drawing.Size(120, 32)
        Me.btnKosongkan.TabIndex = 3
        Me.btnKosongkan.Text = "Kosongkan"
        Me.btnKosongkan.UseVisualStyleBackColor = True
        '
        'lblJumlah
        '
        Me.lblJumlah.AutoSize = True
        Me.lblJumlah.Location = New System.Drawing.Point(290, 338)
        Me.lblJumlah.Name = "lblJumlah"
        Me.lblJumlah.Size = New System.Drawing.Size(87, 15)
        Me.lblJumlah.TabIndex = 4
        Me.lblJumlah.Text = "Jumlah data: 0"
        '
        'FrmDariArray
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(720, 400)
        Me.Controls.Add(Me.lblJumlah)
        Me.Controls.Add(Me.btnKosongkan)
        Me.Controls.Add(Me.btnTampilkan)
        Me.Controls.Add(Me.dgvMahasiswa)
        Me.Controls.Add(Me.lblJudul)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "FrmDariArray"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "DataGridView dari Array"
        CType(Me.dgvMahasiswa, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lblJudul As Label
    Friend WithEvents dgvMahasiswa As DataGridView
    Friend WithEvents colNim As DataGridViewTextBoxColumn
    Friend WithEvents colNama As DataGridViewTextBoxColumn
    Friend WithEvents colJurusan As DataGridViewTextBoxColumn
    Friend WithEvents colAngkatan As DataGridViewTextBoxColumn
    Friend WithEvents colIpk As DataGridViewTextBoxColumn
    Friend WithEvents btnTampilkan As Button
    Friend WithEvents btnKosongkan As Button
    Friend WithEvents lblJumlah As Label
End Class
