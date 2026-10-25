Partial Class FrmUtama
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
        Me.btnUjiKonversi = New System.Windows.Forms.Button()
        Me.btnPendaftaran = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'lblJudul
        '
        Me.lblJudul.AutoSize = True
        Me.lblJudul.Font = New System.Drawing.Font("Segoe UI", 14.0!, System.Drawing.FontStyle.Bold)
        Me.lblJudul.Location = New System.Drawing.Point(20, 15)
        Me.lblJudul.Name = "lblJudul"
        Me.lblJudul.Size = New System.Drawing.Size(215, 32)
        Me.lblJudul.TabIndex = 0
        Me.lblJudul.Text = "Contoh Pertemuan 7"
        '
        'btnUjiKonversi
        '
        Me.btnUjiKonversi.Location = New System.Drawing.Point(20, 60)
        Me.btnUjiKonversi.Name = "btnUjiKonversi"
        Me.btnUjiKonversi.Size = New System.Drawing.Size(380, 40)
        Me.btnUjiKonversi.TabIndex = 1
        Me.btnUjiKonversi.Text = "Uji Konversi: CInt, Val, TryParse, Try...Catch"
        Me.btnUjiKonversi.UseVisualStyleBackColor = True
        '
        'btnPendaftaran
        '
        Me.btnPendaftaran.Location = New System.Drawing.Point(20, 110)
        Me.btnPendaftaran.Name = "btnPendaftaran"
        Me.btnPendaftaran.Size = New System.Drawing.Size(380, 40)
        Me.btnPendaftaran.TabIndex = 2
        Me.btnPendaftaran.Text = "Form Pendaftaran Mahasiswa"
        Me.btnPendaftaran.UseVisualStyleBackColor = True
        '
        'FrmUtama
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(420, 220)
        Me.Controls.Add(Me.btnPendaftaran)
        Me.Controls.Add(Me.btnUjiKonversi)
        Me.Controls.Add(Me.lblJudul)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "FrmUtama"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Pertemuan 7 - Validasi & Error Handling"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lblJudul As Label
    Friend WithEvents btnUjiKonversi As Button
    Friend WithEvents btnPendaftaran As Button
End Class
