<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class formrptreturnout
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
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btnshow = New System.Windows.Forms.Button()
        Me.tgl2 = New System.Windows.Forms.DateTimePicker()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.tgl1 = New System.Windows.Forms.DateTimePicker()
        Me.crvpembelian = New CrystalDecisions.Windows.Forms.CrystalReportViewer()
        Me.rptpembelian1 = New ProjectKios.rptpembelian()
        Me.rptreturnout1 = New ProjectKios.rptreturnout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.btnshow)
        Me.Panel1.Controls.Add(Me.tgl2)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.tgl1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(611, 57)
        Me.Panel1.TabIndex = 1
        '
        'btnshow
        '
        Me.btnshow.Location = New System.Drawing.Point(459, 27)
        Me.btnshow.Name = "btnshow"
        Me.btnshow.Size = New System.Drawing.Size(75, 23)
        Me.btnshow.TabIndex = 4
        Me.btnshow.Text = "SHOW"
        Me.btnshow.UseVisualStyleBackColor = True
        '
        'tgl2
        '
        Me.tgl2.Location = New System.Drawing.Point(252, 29)
        Me.tgl2.Name = "tgl2"
        Me.tgl2.Size = New System.Drawing.Size(200, 20)
        Me.tgl2.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(236, 34)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(10, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "-"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(29, 7)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(95, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Tanggal Transaksi"
        '
        'tgl1
        '
        Me.tgl1.Location = New System.Drawing.Point(29, 29)
        Me.tgl1.Name = "tgl1"
        Me.tgl1.Size = New System.Drawing.Size(200, 20)
        Me.tgl1.TabIndex = 0
        '
        'crvpembelian
        '
        Me.crvpembelian.ActiveViewIndex = 0
        Me.crvpembelian.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.crvpembelian.Cursor = System.Windows.Forms.Cursors.Default
        Me.crvpembelian.Dock = System.Windows.Forms.DockStyle.Fill
        Me.crvpembelian.Location = New System.Drawing.Point(0, 57)
        Me.crvpembelian.Name = "crvpembelian"
        Me.crvpembelian.ReportSource = Me.rptreturnout1
        Me.crvpembelian.Size = New System.Drawing.Size(611, 269)
        Me.crvpembelian.TabIndex = 2
        Me.crvpembelian.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
        '
        'formrptreturnout
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(611, 326)
        Me.Controls.Add(Me.crvpembelian)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "formrptreturnout"
        Me.Text = "Report Return Out"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents rptpembelian1 As ProjectKios.rptpembelian
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents btnshow As System.Windows.Forms.Button
    Friend WithEvents tgl2 As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents tgl1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents crvpembelian As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents rptreturnout1 As ProjectKios.rptreturnout
End Class
