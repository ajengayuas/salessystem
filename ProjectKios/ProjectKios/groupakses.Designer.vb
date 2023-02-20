<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class groupakses
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
        Me.components = New System.ComponentModel.Container()
        Me.dgvakses = New System.Windows.Forms.DataGridView()
        Me.No = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.N = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PictureBox6 = New System.Windows.Forms.PictureBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        CType(Me.dgvakses, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgvakses
        '
        Me.dgvakses.AllowUserToAddRows = False
        Me.dgvakses.AllowUserToDeleteRows = False
        Me.dgvakses.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvakses.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.No, Me.N})
        Me.dgvakses.Location = New System.Drawing.Point(11, 40)
        Me.dgvakses.Name = "dgvakses"
        Me.dgvakses.ReadOnly = True
        Me.dgvakses.RowHeadersWidth = 50
        Me.dgvakses.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvakses.Size = New System.Drawing.Size(475, 352)
        Me.dgvakses.TabIndex = 1
        '
        'No
        '
        Me.No.DataPropertyName = "idakses"
        Me.No.HeaderText = "No"
        Me.No.Name = "No"
        Me.No.ReadOnly = True
        Me.No.Visible = False
        Me.No.Width = 50
        '
        'N
        '
        Me.N.DataPropertyName = "namaakses"
        Me.N.HeaderText = "Nama Akses"
        Me.N.Name = "N"
        Me.N.ReadOnly = True
        Me.N.Width = 200
        '
        'PictureBox6
        '
        Me.PictureBox6.Cursor = System.Windows.Forms.Cursors.Hand
        Me.PictureBox6.Image = Global.ProjectKios.My.Resources.Resources.close
        Me.PictureBox6.Location = New System.Drawing.Point(458, 5)
        Me.PictureBox6.Name = "PictureBox6"
        Me.PictureBox6.Size = New System.Drawing.Size(28, 33)
        Me.PictureBox6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox6.TabIndex = 12
        Me.PictureBox6.TabStop = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Cooper Std Black", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(171, 9)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(141, 19)
        Me.Label5.TabIndex = 14
        Me.Label5.Text = "GROUP AKSES"
        '
        'ErrorProvider1
        '
        Me.ErrorProvider1.ContainerControl = Me
        '
        'groupakses
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(499, 404)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.PictureBox6)
        Me.Controls.Add(Me.dgvakses)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "groupakses"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "masterakses"
        CType(Me.dgvakses, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dgvakses As System.Windows.Forms.DataGridView
    Friend WithEvents PictureBox6 As System.Windows.Forms.PictureBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents No As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents N As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
End Class
