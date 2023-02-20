<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class pembelian
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.LinkLabel1 = New System.Windows.Forms.LinkLabel()
        Me.btncancel = New System.Windows.Forms.Button()
        Me.btnsave = New System.Windows.Forms.Button()
        Me.btnadd = New System.Windows.Forms.Button()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.txthabelpcs = New System.Windows.Forms.TextBox()
        Me.txthabelsat = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.nudqty = New System.Windows.Forms.NumericUpDown()
        Me.btninsert = New System.Windows.Forms.Button()
        Me.nudhaju = New System.Windows.Forms.NumericUpDown()
        Me.nudhajupcs = New System.Windows.Forms.NumericUpDown()
        Me.btnubah = New System.Windows.Forms.Button()
        Me.txthaju = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txthajupcs = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.cmbunit = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.nudhabel = New System.Windows.Forms.NumericUpDown()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cmbsupplier = New System.Windows.Forms.ComboBox()
        Me.txtkode = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cmbitem = New System.Windows.Forms.ComboBox()
        Me.txttanggal = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtno = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dgvbeli = New System.Windows.Forms.DataGridView()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.DeleteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EditQtyToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.PictureBox6 = New System.Windows.Forms.PictureBox()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column8 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column10 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column9 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column11 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column12 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.nudqty, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudhaju, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudhajupcs, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudhabel, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvbeli, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStrip1.SuspendLayout()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox6, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.PaleGreen
        Me.Panel1.Controls.Add(Me.LinkLabel1)
        Me.Panel1.Controls.Add(Me.btncancel)
        Me.Panel1.Controls.Add(Me.btnsave)
        Me.Panel1.Controls.Add(Me.btnadd)
        Me.Panel1.Location = New System.Drawing.Point(1, 36)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1155, 36)
        Me.Panel1.TabIndex = 14
        '
        'LinkLabel1
        '
        Me.LinkLabel1.AutoSize = True
        Me.LinkLabel1.Location = New System.Drawing.Point(1020, 12)
        Me.LinkLabel1.Name = "LinkLabel1"
        Me.LinkLabel1.Size = New System.Drawing.Size(54, 13)
        Me.LinkLabel1.TabIndex = 3
        Me.LinkLabel1.TabStop = True
        Me.LinkLabel1.Text = "Kalkulator"
        '
        'btncancel
        '
        Me.btncancel.Enabled = False
        Me.btncancel.Location = New System.Drawing.Point(191, 7)
        Me.btncancel.Name = "btncancel"
        Me.btncancel.Size = New System.Drawing.Size(75, 23)
        Me.btncancel.TabIndex = 2
        Me.btncancel.Text = "CANCEL"
        Me.btncancel.UseVisualStyleBackColor = True
        '
        'btnsave
        '
        Me.btnsave.Enabled = False
        Me.btnsave.Location = New System.Drawing.Point(110, 7)
        Me.btnsave.Name = "btnsave"
        Me.btnsave.Size = New System.Drawing.Size(75, 23)
        Me.btnsave.TabIndex = 1
        Me.btnsave.Text = "SAVE"
        Me.btnsave.UseVisualStyleBackColor = True
        '
        'btnadd
        '
        Me.btnadd.Location = New System.Drawing.Point(29, 7)
        Me.btnadd.Name = "btnadd"
        Me.btnadd.Size = New System.Drawing.Size(75, 23)
        Me.btnadd.TabIndex = 0
        Me.btnadd.Text = "ADD"
        Me.btnadd.UseVisualStyleBackColor = True
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.DarkSeaGreen
        Me.Panel2.Controls.Add(Me.txthabelpcs)
        Me.Panel2.Controls.Add(Me.txthabelsat)
        Me.Panel2.Controls.Add(Me.Label10)
        Me.Panel2.Controls.Add(Me.nudqty)
        Me.Panel2.Controls.Add(Me.btninsert)
        Me.Panel2.Controls.Add(Me.nudhaju)
        Me.Panel2.Controls.Add(Me.nudhajupcs)
        Me.Panel2.Controls.Add(Me.btnubah)
        Me.Panel2.Controls.Add(Me.txthaju)
        Me.Panel2.Controls.Add(Me.Label8)
        Me.Panel2.Controls.Add(Me.txthajupcs)
        Me.Panel2.Controls.Add(Me.Label7)
        Me.Panel2.Controls.Add(Me.cmbunit)
        Me.Panel2.Controls.Add(Me.Label6)
        Me.Panel2.Controls.Add(Me.nudhabel)
        Me.Panel2.Controls.Add(Me.Label5)
        Me.Panel2.Controls.Add(Me.cmbsupplier)
        Me.Panel2.Controls.Add(Me.txtkode)
        Me.Panel2.Controls.Add(Me.Label4)
        Me.Panel2.Controls.Add(Me.Label3)
        Me.Panel2.Controls.Add(Me.cmbitem)
        Me.Panel2.Controls.Add(Me.txttanggal)
        Me.Panel2.Controls.Add(Me.Label2)
        Me.Panel2.Controls.Add(Me.txtno)
        Me.Panel2.Controls.Add(Me.Label1)
        Me.Panel2.Location = New System.Drawing.Point(1, 71)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1155, 253)
        Me.Panel2.TabIndex = 15
        '
        'txthabelpcs
        '
        Me.txthabelpcs.Location = New System.Drawing.Point(334, 160)
        Me.txthabelpcs.Name = "txthabelpcs"
        Me.txthabelpcs.ReadOnly = True
        Me.txthabelpcs.Size = New System.Drawing.Size(100, 20)
        Me.txthabelpcs.TabIndex = 22
        '
        'txthabelsat
        '
        Me.txthabelsat.Location = New System.Drawing.Point(221, 160)
        Me.txthabelsat.Name = "txthabelsat"
        Me.txthabelsat.ReadOnly = True
        Me.txthabelsat.Size = New System.Drawing.Size(100, 20)
        Me.txthabelsat.TabIndex = 21
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(12, 137)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(23, 13)
        Me.Label10.TabIndex = 20
        Me.Label10.Text = "Qty"
        '
        'nudqty
        '
        Me.nudqty.DecimalPlaces = 2
        Me.nudqty.Enabled = False
        Me.nudqty.Location = New System.Drawing.Point(95, 135)
        Me.nudqty.Maximum = New Decimal(New Integer() {1215752191, 23, 0, 0})
        Me.nudqty.Name = "nudqty"
        Me.nudqty.Size = New System.Drawing.Size(120, 20)
        Me.nudqty.TabIndex = 2
        Me.nudqty.ThousandsSeparator = True
        '
        'btninsert
        '
        Me.btninsert.Enabled = False
        Me.btninsert.Location = New System.Drawing.Point(529, 219)
        Me.btninsert.Name = "btninsert"
        Me.btninsert.Size = New System.Drawing.Size(75, 23)
        Me.btninsert.TabIndex = 5
        Me.btninsert.Text = "INSERT"
        Me.btninsert.UseVisualStyleBackColor = True
        '
        'nudhaju
        '
        Me.nudhaju.DecimalPlaces = 2
        Me.nudhaju.Enabled = False
        Me.nudhaju.Location = New System.Drawing.Point(373, 220)
        Me.nudhaju.Maximum = New Decimal(New Integer() {1410065407, 2, 0, 0})
        Me.nudhaju.Name = "nudhaju"
        Me.nudhaju.Size = New System.Drawing.Size(120, 20)
        Me.nudhaju.TabIndex = 8
        Me.nudhaju.ThousandsSeparator = True
        '
        'nudhajupcs
        '
        Me.nudhajupcs.DecimalPlaces = 2
        Me.nudhajupcs.Enabled = False
        Me.nudhajupcs.Location = New System.Drawing.Point(373, 194)
        Me.nudhajupcs.Maximum = New Decimal(New Integer() {-727379969, 232, 0, 0})
        Me.nudhajupcs.Name = "nudhajupcs"
        Me.nudhajupcs.Size = New System.Drawing.Size(120, 20)
        Me.nudhajupcs.TabIndex = 7
        Me.nudhajupcs.ThousandsSeparator = True
        '
        'btnubah
        '
        Me.btnubah.Enabled = False
        Me.btnubah.Location = New System.Drawing.Point(317, 191)
        Me.btnubah.Name = "btnubah"
        Me.btnubah.Size = New System.Drawing.Size(50, 48)
        Me.btnubah.TabIndex = 6
        Me.btnubah.Text = "UBAH"
        Me.btnubah.UseVisualStyleBackColor = True
        '
        'txthaju
        '
        Me.txthaju.Location = New System.Drawing.Point(155, 219)
        Me.txthaju.Name = "txthaju"
        Me.txthaju.ReadOnly = True
        Me.txthaju.Size = New System.Drawing.Size(156, 20)
        Me.txthaju.TabIndex = 16
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(12, 219)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(97, 13)
        Me.Label8.TabIndex = 15
        Me.Label8.Text = "Harga Jual Saat Ini"
        '
        'txthajupcs
        '
        Me.txthajupcs.Location = New System.Drawing.Point(155, 193)
        Me.txthajupcs.Name = "txthajupcs"
        Me.txthajupcs.ReadOnly = True
        Me.txthajupcs.Size = New System.Drawing.Size(156, 20)
        Me.txthajupcs.TabIndex = 14
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(12, 193)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(137, 13)
        Me.Label7.TabIndex = 13
        Me.Label7.Text = "Harga Jual Per Pcs Saat Ini"
        '
        'cmbunit
        '
        Me.cmbunit.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbunit.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbunit.Enabled = False
        Me.cmbunit.FormattingEnabled = True
        Me.cmbunit.Location = New System.Drawing.Point(221, 134)
        Me.cmbunit.Name = "cmbunit"
        Me.cmbunit.Size = New System.Drawing.Size(62, 21)
        Me.cmbunit.TabIndex = 3
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(12, 163)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(60, 13)
        Me.Label6.TabIndex = 11
        Me.Label6.Text = "*Harga Beli"
        '
        'nudhabel
        '
        Me.nudhabel.DecimalPlaces = 2
        Me.nudhabel.Enabled = False
        Me.nudhabel.Location = New System.Drawing.Point(95, 161)
        Me.nudhabel.Maximum = New Decimal(New Integer() {1215752191, 23, 0, 0})
        Me.nudhabel.Name = "nudhabel"
        Me.nudhabel.Size = New System.Drawing.Size(120, 20)
        Me.nudhabel.TabIndex = 4
        Me.nudhabel.ThousandsSeparator = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(12, 108)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(45, 13)
        Me.Label5.TabIndex = 9
        Me.Label5.Text = "Supplier"
        '
        'cmbsupplier
        '
        Me.cmbsupplier.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbsupplier.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbsupplier.Enabled = False
        Me.cmbsupplier.FormattingEnabled = True
        Me.cmbsupplier.Location = New System.Drawing.Point(95, 108)
        Me.cmbsupplier.Name = "cmbsupplier"
        Me.cmbsupplier.Size = New System.Drawing.Size(270, 21)
        Me.cmbsupplier.TabIndex = 1
        '
        'txtkode
        '
        Me.txtkode.Location = New System.Drawing.Point(95, 82)
        Me.txtkode.Name = "txtkode"
        Me.txtkode.ReadOnly = True
        Me.txtkode.Size = New System.Drawing.Size(156, 20)
        Me.txtkode.TabIndex = 7
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(12, 82)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(55, 13)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Kode Item"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 55)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(58, 13)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Nama Item"
        '
        'cmbitem
        '
        Me.cmbitem.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbitem.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbitem.Enabled = False
        Me.cmbitem.FormattingEnabled = True
        Me.cmbitem.Location = New System.Drawing.Point(95, 55)
        Me.cmbitem.Name = "cmbitem"
        Me.cmbitem.Size = New System.Drawing.Size(270, 21)
        Me.cmbitem.TabIndex = 0
        '
        'txttanggal
        '
        Me.txttanggal.Location = New System.Drawing.Point(429, 16)
        Me.txttanggal.Name = "txttanggal"
        Me.txttanggal.ReadOnly = True
        Me.txttanggal.Size = New System.Drawing.Size(122, 20)
        Me.txttanggal.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(331, 16)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(98, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Tanggal Pembelian"
        '
        'txtno
        '
        Me.txtno.Location = New System.Drawing.Point(95, 16)
        Me.txtno.Name = "txtno"
        Me.txtno.ReadOnly = True
        Me.txtno.Size = New System.Drawing.Size(156, 20)
        Me.txtno.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(73, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "No Pembelian"
        '
        'dgvbeli
        '
        Me.dgvbeli.AllowUserToAddRows = False
        Me.dgvbeli.AllowUserToDeleteRows = False
        Me.dgvbeli.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvbeli.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column2, Me.Column4, Me.Column3, Me.Column5, Me.Column8, Me.Column7, Me.Column6, Me.Column1, Me.Column10, Me.Column9, Me.Column11, Me.Column12})
        Me.dgvbeli.ContextMenuStrip = Me.ContextMenuStrip1
        Me.dgvbeli.Location = New System.Drawing.Point(1, 324)
        Me.dgvbeli.Name = "dgvbeli"
        Me.dgvbeli.ReadOnly = True
        Me.dgvbeli.RowHeadersWidth = 50
        Me.dgvbeli.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvbeli.Size = New System.Drawing.Size(1155, 266)
        Me.dgvbeli.TabIndex = 16
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DeleteToolStripMenuItem, Me.EditQtyToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(117, 48)
        '
        'DeleteToolStripMenuItem
        '
        Me.DeleteToolStripMenuItem.Name = "DeleteToolStripMenuItem"
        Me.DeleteToolStripMenuItem.Size = New System.Drawing.Size(116, 22)
        Me.DeleteToolStripMenuItem.Text = "Delete"
        '
        'EditQtyToolStripMenuItem
        '
        Me.EditQtyToolStripMenuItem.Name = "EditQtyToolStripMenuItem"
        Me.EditQtyToolStripMenuItem.Size = New System.Drawing.Size(116, 22)
        Me.EditQtyToolStripMenuItem.Text = "Edit Qty"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Cooper Std Black", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(475, 9)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(233, 19)
        Me.Label9.TabIndex = 19
        Me.Label9.Text = "TRANSAKSI PEMBELIAN"
        '
        'ErrorProvider1
        '
        Me.ErrorProvider1.ContainerControl = Me
        '
        'PictureBox6
        '
        Me.PictureBox6.Cursor = System.Windows.Forms.Cursors.Hand
        Me.PictureBox6.Image = Global.ProjectKios.My.Resources.Resources.close
        Me.PictureBox6.Location = New System.Drawing.Point(1124, 2)
        Me.PictureBox6.Name = "PictureBox6"
        Me.PictureBox6.Size = New System.Drawing.Size(28, 33)
        Me.PictureBox6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox6.TabIndex = 13
        Me.PictureBox6.TabStop = False
        '
        'Column2
        '
        Me.Column2.HeaderText = "No Beli"
        Me.Column2.Name = "Column2"
        Me.Column2.ReadOnly = True
        Me.Column2.Visible = False
        '
        'Column4
        '
        Me.Column4.HeaderText = "Kode Item"
        Me.Column4.Name = "Column4"
        Me.Column4.ReadOnly = True
        '
        'Column3
        '
        Me.Column3.HeaderText = "Nama Item"
        Me.Column3.Name = "Column3"
        Me.Column3.ReadOnly = True
        '
        'Column5
        '
        Me.Column5.HeaderText = "Supplier"
        Me.Column5.Name = "Column5"
        Me.Column5.ReadOnly = True
        '
        'Column8
        '
        DataGridViewCellStyle1.Format = "N2"
        DataGridViewCellStyle1.NullValue = "0"
        Me.Column8.DefaultCellStyle = DataGridViewCellStyle1
        Me.Column8.HeaderText = "Qty"
        Me.Column8.Name = "Column8"
        Me.Column8.ReadOnly = True
        '
        'Column7
        '
        Me.Column7.HeaderText = "Satuan"
        Me.Column7.Name = "Column7"
        Me.Column7.ReadOnly = True
        '
        'Column6
        '
        DataGridViewCellStyle2.Format = "RP #,##0.00"
        DataGridViewCellStyle2.NullValue = "0"
        Me.Column6.DefaultCellStyle = DataGridViewCellStyle2
        Me.Column6.HeaderText = "Harga Beli"
        Me.Column6.Name = "Column6"
        Me.Column6.ReadOnly = True
        '
        'Column1
        '
        DataGridViewCellStyle3.Format = "RP #,##0.00"
        DataGridViewCellStyle3.NullValue = "0"
        Me.Column1.DefaultCellStyle = DataGridViewCellStyle3
        Me.Column1.HeaderText = "Harga Beli/Pcs"
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        '
        'Column10
        '
        DataGridViewCellStyle4.Format = "RP #,##0.00"
        DataGridViewCellStyle4.NullValue = "0"
        Me.Column10.DefaultCellStyle = DataGridViewCellStyle4
        Me.Column10.HeaderText = "Harga Jual"
        Me.Column10.Name = "Column10"
        Me.Column10.ReadOnly = True
        '
        'Column9
        '
        DataGridViewCellStyle5.Format = "RP #,##0.00"
        DataGridViewCellStyle5.NullValue = "0"
        Me.Column9.DefaultCellStyle = DataGridViewCellStyle5
        Me.Column9.HeaderText = "Harga Jual/Pcs"
        Me.Column9.Name = "Column9"
        Me.Column9.ReadOnly = True
        '
        'Column11
        '
        Me.Column11.HeaderText = "Tanggal"
        Me.Column11.Name = "Column11"
        Me.Column11.ReadOnly = True
        Me.Column11.Width = 120
        '
        'Column12
        '
        Me.Column12.HeaderText = "konv"
        Me.Column12.Name = "Column12"
        Me.Column12.ReadOnly = True
        Me.Column12.Visible = False
        '
        'pembelian
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1157, 591)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.dgvbeli)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.PictureBox6)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "pembelian"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "pembelian"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.nudqty, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudhaju, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudhajupcs, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudhabel, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvbeli, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStrip1.ResumeLayout(False)
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox6, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents PictureBox6 As System.Windows.Forms.PictureBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents btnadd As System.Windows.Forms.Button
    Friend WithEvents btncancel As System.Windows.Forms.Button
    Friend WithEvents btnsave As System.Windows.Forms.Button
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cmbsupplier As System.Windows.Forms.ComboBox
    Friend WithEvents txtkode As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cmbitem As System.Windows.Forms.ComboBox
    Friend WithEvents txttanggal As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtno As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btninsert As System.Windows.Forms.Button
    Friend WithEvents nudhaju As System.Windows.Forms.NumericUpDown
    Friend WithEvents nudhajupcs As System.Windows.Forms.NumericUpDown
    Friend WithEvents btnubah As System.Windows.Forms.Button
    Friend WithEvents txthaju As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txthajupcs As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents nudhabel As System.Windows.Forms.NumericUpDown
    Friend WithEvents dgvbeli As System.Windows.Forms.DataGridView
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents DeleteToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents nudqty As System.Windows.Forms.NumericUpDown
    Friend WithEvents cmbunit As System.Windows.Forms.ComboBox
    Friend WithEvents txthabelpcs As System.Windows.Forms.TextBox
    Friend WithEvents txthabelsat As System.Windows.Forms.TextBox
    Friend WithEvents EditQtyToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents LinkLabel1 As System.Windows.Forms.LinkLabel
    Friend WithEvents Column2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column8 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column7 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column10 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column9 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column11 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column12 As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
