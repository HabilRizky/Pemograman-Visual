Imports System.Windows.Forms
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
        Me.btnDariArray = New System.Windows.Forms.Button()
        Me.btnDariList = New System.Windows.Forms.Button()
        Me.btnDataTable = New System.Windows.Forms.Button()
        Me.btnCariList = New System.Windows.Forms.Button()
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
        Me.lblJudul.Text = "Contoh Pertemuan 8"
        '
        'btnDariArray
        '
        Me.btnDariArray.Location = New System.Drawing.Point(20, 65)
        Me.btnDariArray.Name = "btnDariArray"
        Me.btnDariArray.Size = New System.Drawing.Size(400, 40)
        Me.btnDariArray.TabIndex = 1
        Me.btnDariArray.Text = "1. DataGridView dari Array"
        Me.btnDariArray.UseVisualStyleBackColor = True
        '
        'btnDariList
        '
        Me.btnDariList.Location = New System.Drawing.Point(20, 115)
        Me.btnDariList.Name = "btnDariList"
        Me.btnDariList.Size = New System.Drawing.Size(400, 40)
        Me.btnDariList.TabIndex = 2
        Me.btnDariList.Text = "2. Binding List(Of Mahasiswa)"
        Me.btnDariList.UseVisualStyleBackColor = True
        '
        'btnDataTable
        '
        Me.btnDataTable.Location = New System.Drawing.Point(20, 165)
        Me.btnDataTable.Name = "btnDataTable"
        Me.btnDataTable.Size = New System.Drawing.Size(400, 40)
        Me.btnDataTable.TabIndex = 3
        Me.btnDataTable.Text = "3. DataTable, Rapikan Kolom dan Filter"
        Me.btnDataTable.UseVisualStyleBackColor = True
        '
        'btnCariList
        '
        Me.btnCariList.Location = New System.Drawing.Point(20, 215)
        Me.btnCariList.Name = "btnCariList"
        Me.btnCariList.Size = New System.Drawing.Size(400, 40)
        Me.btnCariList.TabIndex = 4
        Me.btnCariList.Text = "4. Pencarian dengan Perulangan"
        Me.btnCariList.UseVisualStyleBackColor = True
        '
        'FrmUtama
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(440, 300)
        Me.Controls.Add(Me.btnCariList)
        Me.Controls.Add(Me.btnDataTable)
        Me.Controls.Add(Me.btnDariList)
        Me.Controls.Add(Me.btnDariArray)
        Me.Controls.Add(Me.lblJudul)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "FrmUtama"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Pertemuan 8 - DataGridView, Array & Koleksi Data"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lblJudul As Label
    Friend WithEvents btnDariArray As Button
    Friend WithEvents btnDariList As Button
    Friend WithEvents btnDataTable As Button
    Friend WithEvents btnCariList As Button
End Class
