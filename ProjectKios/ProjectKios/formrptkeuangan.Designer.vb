<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class formrptkeuangan
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
        Me.PictureBox6 = New System.Windows.Forms.PictureBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.dtpclosing = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnclosing = New System.Windows.Forms.Button()
        Me.btnshow = New System.Windows.Forms.Button()
        Me.crvkeu = New CrystalDecisions.Windows.Forms.CrystalReportViewer()
        Me.rptkeuangan1 = New ProjectKios.rptkeuangan()
        CType(Me.PictureBox6, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'PictureBox6
        '
        Me.PictureBox6.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox6.Cursor = System.Windows.Forms.Cursors.Hand
        Me.PictureBox6.Image = Global.ProjectKios.My.Resources.Resources.close
        Me.PictureBox6.Location = New System.Drawing.Point(859, 2)
        Me.PictureBox6.Name = "PictureBox6"
        Me.PictureBox6.Size = New System.Drawing.Size(28, 33)
        Me.PictureBox6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox6.TabIndex = 14
        Me.PictureBox6.TabStop = False
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Cooper Std Black", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(335, 9)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(174, 19)
        Me.Label9.TabIndex = 20
        Me.Label9.Text = "DATA KEUANGAN"
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.BackColor = System.Drawing.Color.PaleGreen
        Me.Panel1.Controls.Add(Me.btnshow)
        Me.Panel1.Controls.Add(Me.btnclosing)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.dtpclosing)
        Me.Panel1.Location = New System.Drawing.Point(0, 41)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(889, 77)
        Me.Panel1.TabIndex = 21
        '
        'dtpclosing
        '
        Me.dtpclosing.CustomFormat = "MMMM yyyy"
        Me.dtpclosing.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpclosing.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.dtpclosing.Location = New System.Drawing.Point(39, 35)
        Me.dtpclosing.Name = "dtpclosing"
        Me.dtpclosing.Size = New System.Drawing.Size(164, 20)
        Me.dtpclosing.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(36, 19)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(83, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Bulan Transaksi"
        '
        'btnclosing
        '
        Me.btnclosing.Location = New System.Drawing.Point(230, 35)
        Me.btnclosing.Name = "btnclosing"
        Me.btnclosing.Size = New System.Drawing.Size(75, 23)
        Me.btnclosing.TabIndex = 2
        Me.btnclosing.Text = "CLOSING"
        Me.btnclosing.UseVisualStyleBackColor = True
        '
        'btnshow
        '
        Me.btnshow.Location = New System.Drawing.Point(326, 35)
        Me.btnshow.Name = "btnshow"
        Me.btnshow.Size = New System.Drawing.Size(75, 23)
        Me.btnshow.TabIndex = 3
        Me.btnshow.Text = "SHOW"
        Me.btnshow.UseVisualStyleBackColor = True
        '
        'crvkeu
        '
        Me.crvkeu.ActiveViewIndex = 0
        Me.crvkeu.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.crvkeu.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.crvkeu.Cursor = System.Windows.Forms.Cursors.Default
        Me.crvkeu.Location = New System.Drawing.Point(0, 118)
        Me.crvkeu.Name = "crvkeu"
        Me.crvkeu.ReportSource = Me.rptkeuangan1
        Me.crvkeu.Size = New System.Drawing.Size(889, 332)
        Me.crvkeu.TabIndex = 22
        Me.crvkeu.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
        '
        'formrptkeuangan
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(889, 452)
        Me.Controls.Add(Me.crvkeu)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.PictureBox6)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "formrptkeuangan"
        Me.Text = "Data Keuangan"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.PictureBox6, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents PictureBox6 As System.Windows.Forms.PictureBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents dtpclosing As System.Windows.Forms.DateTimePicker
    Friend WithEvents btnshow As System.Windows.Forms.Button
    Friend WithEvents btnclosing As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents crvkeu As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents rptkeuangan1 As ProjectKios.rptkeuangan
End Class
