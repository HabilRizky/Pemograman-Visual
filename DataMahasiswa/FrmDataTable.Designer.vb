Imports System.Windows.Forms
Partial Class FrmDataTable
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
        Me.lblCari = New System.Windows.Forms.Label()
        Me.txtCari = New System.Windows.Forms.TextBox()
        Me.btnRapikan = New System.Windows.Forms.Button()
        Me.dgvMahasiswa = New System.Windows.Forms.DataGridView()
        Me.lblJumlah = New System.Windows.Forms.Label()
        Me.bsMahasiswa = New System.Windows.Forms.BindingSource(Me.components)
        CType(Me.dgvMahasiswa, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.bsMahasiswa, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.lblJudul.Text = "DataTable + BindingSource"
        '
        'lblCari
        '
        Me.lblCari.AutoSize = True
        Me.lblCari.Location = New System.Drawing.Point(20, 65)
        Me.lblCari.Name = "lblCari"
        Me.lblCari.Size = New System.Drawing.Size(90, 15)
        Me.lblCari.TabIndex = 1
        Me.lblCari.Text = "Cari nama/NIM:"
        '
        'txtCari
        '
        Me.txtCari.Location = New System.Drawing.Point(130, 62)
        Me.txtCari.Name = "txtCari"
        Me.txtCari.Size = New System.Drawing.Size(200, 23)
        Me.txtCari.TabIndex = 2
        '
        'btnRapikan
        '
        Me.btnRapikan.Location = New System.Drawing.Point(350, 61)
        Me.btnRapikan.Name = "btnRapikan"
        Me.btnRapikan.Size = New System.Drawing.Size(130, 26)
        Me.btnRapikan.TabIndex = 3
        Me.btnRapikan.Text = "Rapikan Kolom"
        Me.btnRapikan.UseVisualStyleBackColor = True
        '
        'dgvMahasiswa
        '
        Me.dgvMahasiswa.AllowUserToAddRows = False
        Me.dgvMahasiswa.AllowUserToDeleteRows = False
        Me.dgvMahasiswa.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.None
        Me.dgvMahasiswa.Location = New System.Drawing.Point(20, 100)
        Me.dgvMahasiswa.MultiSelect = False
        Me.dgvMahasiswa.Name = "dgvMahasiswa"
        Me.dgvMahasiswa.ReadOnly = True
        Me.dgvMahasiswa.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvMahasiswa.Size = New System.Drawing.Size(720, 320)
        Me.dgvMahasiswa.TabIndex = 4
        '
        'lblJumlah
        '
        Me.lblJumlah.AutoSize = True
        Me.lblJumlah.Location = New System.Drawing.Point(20, 428)
        Me.lblJumlah.Name = "lblJumlah"
        Me.lblJumlah.Size = New System.Drawing.Size(170, 15)
        Me.lblJumlah.TabIndex = 5
        Me.lblJumlah.Text = "Menampilkan 0 dari 0 data"
        '
        'bsMahasiswa
        '
        '
        'FrmDataTable
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(760, 470)
        Me.Controls.Add(Me.lblJumlah)
        Me.Controls.Add(Me.dgvMahasiswa)
        Me.Controls.Add(Me.btnRapikan)
        Me.Controls.Add(Me.txtCari)
        Me.Controls.Add(Me.lblCari)
        Me.Controls.Add(Me.lblJudul)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "FrmDataTable"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "DataTable, BindingSource & Filter"
        CType(Me.dgvMahasiswa, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.bsMahasiswa, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lblJudul As Label
    Friend WithEvents lblCari As Label
    Friend WithEvents txtCari As TextBox
    Friend WithEvents btnRapikan As Button
    Friend WithEvents dgvMahasiswa As DataGridView
    Friend WithEvents lblJumlah As Label
    Friend WithEvents bsMahasiswa As BindingSource
End Class
