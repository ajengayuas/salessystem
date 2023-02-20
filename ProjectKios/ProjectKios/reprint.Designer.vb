<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class reprint
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
        Me.btncetak = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.nudtunai = New System.Windows.Forms.NumericUpDown()
        Me.txtno = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtkepada = New System.Windows.Forms.TextBox()
        CType(Me.nudtunai, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btncetak
        '
        Me.btncetak.Location = New System.Drawing.Point(269, 12)
        Me.btncetak.Name = "btncetak"
        Me.btncetak.Size = New System.Drawing.Size(75, 23)
        Me.btncetak.TabIndex = 2
        Me.btncetak.Text = "CETAK"
        Me.btncetak.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(10, 41)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(34, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Tunai"
        '
        'nudtunai
        '
        Me.nudtunai.Location = New System.Drawing.Point(100, 41)
        Me.nudtunai.Maximum = New Decimal(New Integer() {-727379969, 232, 0, 0})
        Me.nudtunai.Name = "nudtunai"
        Me.nudtunai.Size = New System.Drawing.Size(120, 20)
        Me.nudtunai.TabIndex = 1
        '
        'txtno
        '
        Me.txtno.Location = New System.Drawing.Point(100, 12)
        Me.txtno.Name = "txtno"
        Me.txtno.Size = New System.Drawing.Size(162, 20)
        Me.txtno.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(10, 12)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(84, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "No Pengeluaran"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(10, 69)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(44, 13)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Kepada"
        '
        'txtkepada
        '
        Me.txtkepada.Location = New System.Drawing.Point(100, 69)
        Me.txtkepada.Name = "txtkepada"
        Me.txtkepada.Size = New System.Drawing.Size(162, 20)
        Me.txtkepada.TabIndex = 4
        '
        'reprint
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(356, 101)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtkepada)
        Me.Controls.Add(Me.nudtunai)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btncetak)
        Me.Controls.Add(Me.txtno)
        Me.Name = "reprint"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "RE PRINT INVOICE"
        CType(Me.nudtunai, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btncetak As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents nudtunai As System.Windows.Forms.NumericUpDown
    Friend WithEvents txtno As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtkepada As System.Windows.Forms.TextBox
End Class
