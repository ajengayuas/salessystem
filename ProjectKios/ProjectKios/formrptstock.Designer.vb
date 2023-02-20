<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class formrptstock
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
        Me.crvpembelian = New CrystalDecisions.Windows.Forms.CrystalReportViewer()
        Me.rptpembelian1 = New ProjectKios.rptpembelian()
        Me.rptstock1 = New ProjectKios.rptstock()
        Me.SuspendLayout()
        '
        'crvpembelian
        '
        Me.crvpembelian.ActiveViewIndex = 0
        Me.crvpembelian.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.crvpembelian.Cursor = System.Windows.Forms.Cursors.Default
        Me.crvpembelian.Dock = System.Windows.Forms.DockStyle.Fill
        Me.crvpembelian.Location = New System.Drawing.Point(0, 0)
        Me.crvpembelian.Name = "crvpembelian"
        Me.crvpembelian.ReportSource = Me.rptstock1
        Me.crvpembelian.Size = New System.Drawing.Size(611, 326)
        Me.crvpembelian.TabIndex = 2
        Me.crvpembelian.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
        '
        'formrptstock
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(611, 326)
        Me.Controls.Add(Me.crvpembelian)
        Me.Name = "formrptstock"
        Me.Text = "Report Stock"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents rptpembelian1 As ProjectKios.rptpembelian
    Friend WithEvents crvpembelian As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents rptstock1 As ProjectKios.rptstock
End Class
