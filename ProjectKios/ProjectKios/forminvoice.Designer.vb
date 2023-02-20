<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class forminvoice
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
        Me.crvinvoice = New CrystalDecisions.Windows.Forms.CrystalReportViewer()
        Me.rptinvoice1 = New ProjectKios.rptinvoice()
        Me.SuspendLayout()
        '
        'crvinvoice
        '
        Me.crvinvoice.ActiveViewIndex = 0
        Me.crvinvoice.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.crvinvoice.Cursor = System.Windows.Forms.Cursors.Default
        Me.crvinvoice.Dock = System.Windows.Forms.DockStyle.Fill
        Me.crvinvoice.Location = New System.Drawing.Point(0, 0)
        Me.crvinvoice.Name = "crvinvoice"
        Me.crvinvoice.ReportSource = Me.rptinvoice1
        Me.crvinvoice.Size = New System.Drawing.Size(753, 454)
        Me.crvinvoice.TabIndex = 0
        Me.crvinvoice.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
        '
        'forminvoice
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(753, 454)
        Me.Controls.Add(Me.crvinvoice)
        Me.Name = "forminvoice"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Invoice"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents rptinvoice1 As ProjectKios.rptinvoice
    Friend WithEvents crvinvoice As CrystalDecisions.Windows.Forms.CrystalReportViewer
End Class
