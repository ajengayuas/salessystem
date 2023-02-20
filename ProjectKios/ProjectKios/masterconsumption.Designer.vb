<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class masterconsumption
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
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.nudqty = New System.Windows.Forms.NumericUpDown()
        Me.dgvcons = New System.Windows.Forms.DataGridView()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.RemoveToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnadd = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cmbitem = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmbjasa = New System.Windows.Forms.ComboBox()
        Me.PictureBox6 = New System.Windows.Forms.PictureBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.namajasa = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.item = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.idcons = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Panel1.SuspendLayout()
        CType(Me.nudqty, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvcons, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStrip1.SuspendLayout()
        CType(Me.PictureBox6, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.MediumSeaGreen
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.nudqty)
        Me.Panel1.Controls.Add(Me.dgvcons)
        Me.Panel1.Controls.Add(Me.btnadd)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.cmbitem)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.cmbjasa)
        Me.Panel1.Location = New System.Drawing.Point(13, 37)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(566, 300)
        Me.Panel1.TabIndex = 0
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(410, 18)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(50, 13)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "Qty Cons"
        '
        'nudqty
        '
        Me.nudqty.Location = New System.Drawing.Point(413, 36)
        Me.nudqty.Maximum = New Decimal(New Integer() {999999999, 0, 0, 0})
        Me.nudqty.Name = "nudqty"
        Me.nudqty.Size = New System.Drawing.Size(87, 20)
        Me.nudqty.TabIndex = 2
        '
        'dgvcons
        '
        Me.dgvcons.AllowUserToAddRows = False
        Me.dgvcons.AllowUserToDeleteRows = False
        Me.dgvcons.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvcons.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.namajasa, Me.item, Me.Column3, Me.Column1, Me.Column2, Me.idcons})
        Me.dgvcons.ContextMenuStrip = Me.ContextMenuStrip1
        Me.dgvcons.Location = New System.Drawing.Point(14, 75)
        Me.dgvcons.Name = "dgvcons"
        Me.dgvcons.ReadOnly = True
        Me.dgvcons.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvcons.Size = New System.Drawing.Size(534, 211)
        Me.dgvcons.TabIndex = 5
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.RemoveToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(118, 26)
        '
        'RemoveToolStripMenuItem
        '
        Me.RemoveToolStripMenuItem.Name = "RemoveToolStripMenuItem"
        Me.RemoveToolStripMenuItem.Size = New System.Drawing.Size(117, 22)
        Me.RemoveToolStripMenuItem.Text = "Remove"
        '
        'btnadd
        '
        Me.btnadd.Location = New System.Drawing.Point(506, 36)
        Me.btnadd.Name = "btnadd"
        Me.btnadd.Size = New System.Drawing.Size(42, 23)
        Me.btnadd.TabIndex = 3
        Me.btnadd.Text = "ADD"
        Me.btnadd.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(193, 18)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(46, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "List Item"
        '
        'cmbitem
        '
        Me.cmbitem.FormattingEnabled = True
        Me.cmbitem.Location = New System.Drawing.Point(191, 36)
        Me.cmbitem.Name = "cmbitem"
        Me.cmbitem.Size = New System.Drawing.Size(215, 21)
        Me.cmbitem.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(14, 18)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(48, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "List Jasa"
        '
        'cmbjasa
        '
        Me.cmbjasa.FormattingEnabled = True
        Me.cmbjasa.Location = New System.Drawing.Point(14, 36)
        Me.cmbjasa.Name = "cmbjasa"
        Me.cmbjasa.Size = New System.Drawing.Size(150, 21)
        Me.cmbjasa.TabIndex = 0
        '
        'PictureBox6
        '
        Me.PictureBox6.Cursor = System.Windows.Forms.Cursors.Hand
        Me.PictureBox6.Image = Global.ProjectKios.My.Resources.Resources.close
        Me.PictureBox6.Location = New System.Drawing.Point(550, 2)
        Me.PictureBox6.Name = "PictureBox6"
        Me.PictureBox6.Size = New System.Drawing.Size(28, 33)
        Me.PictureBox6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox6.TabIndex = 13
        Me.PictureBox6.TabStop = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Cooper Std Black", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(221, 9)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(157, 19)
        Me.Label5.TabIndex = 15
        Me.Label5.Text = "CONSUMPTIONS"
        '
        'namajasa
        '
        Me.namajasa.DataPropertyName = "namajasa"
        Me.namajasa.HeaderText = "Jasa"
        Me.namajasa.Name = "namajasa"
        Me.namajasa.ReadOnly = True
        Me.namajasa.Width = 150
        '
        'item
        '
        Me.item.DataPropertyName = "namaitem"
        Me.item.HeaderText = "List Item"
        Me.item.Name = "item"
        Me.item.ReadOnly = True
        Me.item.Width = 200
        '
        'Column3
        '
        Me.Column3.DataPropertyName = "qtycons"
        Me.Column3.HeaderText = "Qty Cons"
        Me.Column3.Name = "Column3"
        Me.Column3.ReadOnly = True
        '
        'Column1
        '
        Me.Column1.DataPropertyName = "iditem"
        Me.Column1.HeaderText = "iditem"
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        Me.Column1.Visible = False
        '
        'Column2
        '
        Me.Column2.DataPropertyName = "iditemjasa"
        Me.Column2.HeaderText = "iditemjasa"
        Me.Column2.Name = "Column2"
        Me.Column2.ReadOnly = True
        Me.Column2.Visible = False
        '
        'idcons
        '
        Me.idcons.DataPropertyName = "idcons"
        Me.idcons.HeaderText = "idcons"
        Me.idcons.Name = "idcons"
        Me.idcons.ReadOnly = True
        Me.idcons.Visible = False
        '
        'masterconsumption
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(591, 342)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.PictureBox6)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "masterconsumption"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "masterconsumption"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.nudqty, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvcons, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStrip1.ResumeLayout(False)
        CType(Me.PictureBox6, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents btnadd As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cmbitem As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmbjasa As System.Windows.Forms.ComboBox
    Friend WithEvents dgvcons As System.Windows.Forms.DataGridView
    Friend WithEvents PictureBox6 As System.Windows.Forms.PictureBox
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents RemoveToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents nudqty As System.Windows.Forms.NumericUpDown
    Friend WithEvents namajasa As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents item As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents idcons As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
