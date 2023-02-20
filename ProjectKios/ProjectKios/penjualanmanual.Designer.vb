<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class penjualanmanual
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
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.LinkLabel1 = New System.Windows.Forms.LinkLabel()
        Me.btncancel = New System.Windows.Forms.Button()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.txtkepada = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.nudqty = New System.Windows.Forms.NumericUpDown()
        Me.btninsert = New System.Windows.Forms.Button()
        Me.txtharga = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.cmbunit = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cmbitem = New System.Windows.Forms.ComboBox()
        Me.txttanggal = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtno = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dgvjual = New System.Windows.Forms.DataGridView()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column11 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column8 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ket = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.nmkategori = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.idketmulti = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.DeleteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EditQtyToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.nudbayar = New System.Windows.Forms.NumericUpDown()
        Me.nuddisc = New System.Windows.Forms.NumericUpDown()
        Me.btncetak = New System.Windows.Forms.Button()
        Me.txtkembali = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtgrand = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txttotal = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.PictureBox6 = New System.Windows.Forms.PictureBox()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.nudqty, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvjual, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStrip1.SuspendLayout()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel3.SuspendLayout()
        CType(Me.nudbayar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nuddisc, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox6, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.PaleGreen
        Me.Panel1.Controls.Add(Me.LinkLabel1)
        Me.Panel1.Controls.Add(Me.btncancel)
        Me.Panel1.Location = New System.Drawing.Point(1, 36)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1066, 36)
        Me.Panel1.TabIndex = 14
        '
        'LinkLabel1
        '
        Me.LinkLabel1.AutoSize = True
        Me.LinkLabel1.Location = New System.Drawing.Point(947, 11)
        Me.LinkLabel1.Name = "LinkLabel1"
        Me.LinkLabel1.Size = New System.Drawing.Size(54, 13)
        Me.LinkLabel1.TabIndex = 3
        Me.LinkLabel1.TabStop = True
        Me.LinkLabel1.Text = "Kalkulator"
        '
        'btncancel
        '
        Me.btncancel.Enabled = False
        Me.btncancel.Location = New System.Drawing.Point(15, 6)
        Me.btncancel.Name = "btncancel"
        Me.btncancel.Size = New System.Drawing.Size(75, 23)
        Me.btncancel.TabIndex = 2
        Me.btncancel.Text = "RESET"
        Me.btncancel.UseVisualStyleBackColor = True
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.DarkSeaGreen
        Me.Panel2.Controls.Add(Me.Label13)
        Me.Panel2.Controls.Add(Me.Label4)
        Me.Panel2.Controls.Add(Me.TextBox1)
        Me.Panel2.Controls.Add(Me.txtkepada)
        Me.Panel2.Controls.Add(Me.Label15)
        Me.Panel2.Controls.Add(Me.Label10)
        Me.Panel2.Controls.Add(Me.nudqty)
        Me.Panel2.Controls.Add(Me.btninsert)
        Me.Panel2.Controls.Add(Me.txtharga)
        Me.Panel2.Controls.Add(Me.Label7)
        Me.Panel2.Controls.Add(Me.cmbunit)
        Me.Panel2.Controls.Add(Me.Label3)
        Me.Panel2.Controls.Add(Me.cmbitem)
        Me.Panel2.Controls.Add(Me.txttanggal)
        Me.Panel2.Controls.Add(Me.Label2)
        Me.Panel2.Controls.Add(Me.txtno)
        Me.Panel2.Controls.Add(Me.Label1)
        Me.Panel2.Location = New System.Drawing.Point(1, 71)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1066, 165)
        Me.Panel2.TabIndex = 15
        '
        'txtkepada
        '
        Me.txtkepada.Enabled = False
        Me.txtkepada.Location = New System.Drawing.Point(528, 16)
        Me.txtkepada.Name = "txtkepada"
        Me.txtkepada.Size = New System.Drawing.Size(153, 20)
        Me.txtkepada.TabIndex = 27
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(477, 20)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(44, 13)
        Me.Label15.TabIndex = 26
        Me.Label15.Text = "Kepada"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(12, 134)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(23, 13)
        Me.Label10.TabIndex = 20
        Me.Label10.Text = "Qty"
        '
        'nudqty
        '
        Me.nudqty.DecimalPlaces = 2
        Me.nudqty.Enabled = False
        Me.nudqty.Location = New System.Drawing.Point(95, 132)
        Me.nudqty.Maximum = New Decimal(New Integer() {1215752191, 23, 0, 0})
        Me.nudqty.Name = "nudqty"
        Me.nudqty.Size = New System.Drawing.Size(87, 20)
        Me.nudqty.TabIndex = 1
        Me.nudqty.ThousandsSeparator = True
        '
        'btninsert
        '
        Me.btninsert.Enabled = False
        Me.btninsert.Location = New System.Drawing.Point(446, 130)
        Me.btninsert.Name = "btninsert"
        Me.btninsert.Size = New System.Drawing.Size(75, 23)
        Me.btninsert.TabIndex = 3
        Me.btninsert.Text = "INSERT"
        Me.btninsert.UseVisualStyleBackColor = True
        '
        'txtharga
        '
        Me.txtharga.Location = New System.Drawing.Point(95, 105)
        Me.txtharga.Name = "txtharga"
        Me.txtharga.ReadOnly = True
        Me.txtharga.Size = New System.Drawing.Size(87, 20)
        Me.txtharga.TabIndex = 14
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(12, 107)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(36, 13)
        Me.Label7.TabIndex = 13
        Me.Label7.Text = "Harga"
        '
        'cmbunit
        '
        Me.cmbunit.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbunit.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbunit.Enabled = False
        Me.cmbunit.FormattingEnabled = True
        Me.cmbunit.Items.AddRange(New Object() {"Pcs", "Pack"})
        Me.cmbunit.Location = New System.Drawing.Point(188, 132)
        Me.cmbunit.Name = "cmbunit"
        Me.cmbunit.Size = New System.Drawing.Size(62, 21)
        Me.cmbunit.TabIndex = 2
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 78)
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
        Me.cmbitem.Location = New System.Drawing.Point(95, 78)
        Me.cmbitem.Name = "cmbitem"
        Me.cmbitem.Size = New System.Drawing.Size(270, 21)
        Me.cmbitem.TabIndex = 0
        '
        'txttanggal
        '
        Me.txttanggal.Location = New System.Drawing.Point(95, 42)
        Me.txttanggal.Name = "txttanggal"
        Me.txttanggal.ReadOnly = True
        Me.txttanggal.Size = New System.Drawing.Size(100, 20)
        Me.txttanggal.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 45)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(46, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Tanggal"
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
        Me.Label1.Location = New System.Drawing.Point(12, 19)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(21, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "No"
        '
        'dgvjual
        '
        Me.dgvjual.AllowUserToAddRows = False
        Me.dgvjual.AllowUserToDeleteRows = False
        Me.dgvjual.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvjual.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column2, Me.Column11, Me.Column4, Me.Column3, Me.Column8, Me.Column7, Me.Column6, Me.Column1, Me.Column5, Me.ket, Me.nmkategori, Me.idketmulti})
        Me.dgvjual.ContextMenuStrip = Me.ContextMenuStrip1
        Me.dgvjual.Location = New System.Drawing.Point(1, 242)
        Me.dgvjual.Name = "dgvjual"
        Me.dgvjual.ReadOnly = True
        Me.dgvjual.RowHeadersWidth = 50
        Me.dgvjual.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvjual.Size = New System.Drawing.Size(1066, 221)
        Me.dgvjual.TabIndex = 16
        '
        'Column2
        '
        Me.Column2.HeaderText = "No Jual"
        Me.Column2.Name = "Column2"
        Me.Column2.ReadOnly = True
        Me.Column2.Visible = False
        '
        'Column11
        '
        DataGridViewCellStyle1.Format = "D"
        DataGridViewCellStyle1.NullValue = Nothing
        Me.Column11.DefaultCellStyle = DataGridViewCellStyle1
        Me.Column11.HeaderText = "Tanggal"
        Me.Column11.Name = "Column11"
        Me.Column11.ReadOnly = True
        Me.Column11.Width = 120
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
        Me.Column3.Width = 250
        '
        'Column8
        '
        DataGridViewCellStyle2.Format = "N5"
        DataGridViewCellStyle2.NullValue = "0"
        Me.Column8.DefaultCellStyle = DataGridViewCellStyle2
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
        DataGridViewCellStyle3.Format = "RP #,##0.00"
        DataGridViewCellStyle3.NullValue = "0"
        Me.Column6.DefaultCellStyle = DataGridViewCellStyle3
        Me.Column6.HeaderText = "Harga"
        Me.Column6.Name = "Column6"
        Me.Column6.ReadOnly = True
        '
        'Column1
        '
        DataGridViewCellStyle4.Format = "RP #,##0.00"
        DataGridViewCellStyle4.NullValue = "0"
        Me.Column1.DefaultCellStyle = DataGridViewCellStyle4
        Me.Column1.HeaderText = "Amount"
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        '
        'Column5
        '
        Me.Column5.HeaderText = "qtykonv"
        Me.Column5.Name = "Column5"
        Me.Column5.ReadOnly = True
        Me.Column5.Visible = False
        '
        'ket
        '
        Me.ket.DataPropertyName = "keterangan"
        Me.ket.HeaderText = "ket"
        Me.ket.Name = "ket"
        Me.ket.ReadOnly = True
        Me.ket.Visible = False
        '
        'nmkategori
        '
        Me.nmkategori.DataPropertyName = "kategori"
        Me.nmkategori.HeaderText = "nmkategori"
        Me.nmkategori.Name = "nmkategori"
        Me.nmkategori.ReadOnly = True
        Me.nmkategori.Visible = False
        '
        'idketmulti
        '
        Me.idketmulti.DataPropertyName = "idmulti"
        Me.idketmulti.HeaderText = "idmulti"
        Me.idketmulti.Name = "idketmulti"
        Me.idketmulti.ReadOnly = True
        Me.idketmulti.Visible = False
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
        Me.Label9.Size = New System.Drawing.Size(240, 19)
        Me.Label9.TabIndex = 19
        Me.Label9.Text = "TRANSAKSI PENJUALAN"
        '
        'ErrorProvider1
        '
        Me.ErrorProvider1.ContainerControl = Me
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.PaleGreen
        Me.Panel3.Controls.Add(Me.nudbayar)
        Me.Panel3.Controls.Add(Me.nuddisc)
        Me.Panel3.Controls.Add(Me.btncetak)
        Me.Panel3.Controls.Add(Me.txtkembali)
        Me.Panel3.Controls.Add(Me.Label12)
        Me.Panel3.Controls.Add(Me.Label11)
        Me.Panel3.Controls.Add(Me.txtgrand)
        Me.Panel3.Controls.Add(Me.Label8)
        Me.Panel3.Controls.Add(Me.Label6)
        Me.Panel3.Controls.Add(Me.txttotal)
        Me.Panel3.Controls.Add(Me.Label5)
        Me.Panel3.Location = New System.Drawing.Point(1, 510)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(1066, 155)
        Me.Panel3.TabIndex = 20
        '
        'nudbayar
        '
        Me.nudbayar.DecimalPlaces = 2
        Me.nudbayar.Enabled = False
        Me.nudbayar.Location = New System.Drawing.Point(855, 85)
        Me.nudbayar.Maximum = New Decimal(New Integer() {1410065407, 2, 0, 0})
        Me.nudbayar.Name = "nudbayar"
        Me.nudbayar.Size = New System.Drawing.Size(129, 20)
        Me.nudbayar.TabIndex = 1
        Me.nudbayar.ThousandsSeparator = True
        '
        'nuddisc
        '
        Me.nuddisc.DecimalPlaces = 2
        Me.nuddisc.Enabled = False
        Me.nuddisc.Location = New System.Drawing.Point(855, 33)
        Me.nuddisc.Maximum = New Decimal(New Integer() {99999999, 0, 0, 0})
        Me.nuddisc.Name = "nuddisc"
        Me.nuddisc.Size = New System.Drawing.Size(129, 20)
        Me.nuddisc.TabIndex = 0
        Me.nuddisc.ThousandsSeparator = True
        '
        'btncetak
        '
        Me.btncetak.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btncetak.Location = New System.Drawing.Point(990, 7)
        Me.btncetak.Name = "btncetak"
        Me.btncetak.Size = New System.Drawing.Size(55, 125)
        Me.btncetak.TabIndex = 2
        Me.btncetak.Text = "CETAK"
        Me.btncetak.UseVisualStyleBackColor = True
        '
        'txtkembali
        '
        Me.txtkembali.Location = New System.Drawing.Point(855, 111)
        Me.txtkembali.Name = "txtkembali"
        Me.txtkembali.ReadOnly = True
        Me.txtkembali.Size = New System.Drawing.Size(129, 20)
        Me.txtkembali.TabIndex = 9
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(777, 111)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(44, 13)
        Me.Label12.TabIndex = 8
        Me.Label12.Text = "Kembali"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(777, 85)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(47, 13)
        Me.Label11.TabIndex = 6
        Me.Label11.Text = "*Dibayar"
        '
        'txtgrand
        '
        Me.txtgrand.Location = New System.Drawing.Point(855, 59)
        Me.txtgrand.Name = "txtgrand"
        Me.txtgrand.ReadOnly = True
        Me.txtgrand.Size = New System.Drawing.Size(129, 20)
        Me.txtgrand.TabIndex = 5
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(777, 59)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(63, 13)
        Me.Label8.TabIndex = 4
        Me.Label8.Text = "Grand Total"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(777, 33)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(49, 13)
        Me.Label6.TabIndex = 2
        Me.Label6.Text = "*Disc Rp"
        '
        'txttotal
        '
        Me.txttotal.Location = New System.Drawing.Point(855, 7)
        Me.txttotal.Name = "txttotal"
        Me.txttotal.ReadOnly = True
        Me.txttotal.Size = New System.Drawing.Size(129, 20)
        Me.txttotal.TabIndex = 1
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(777, 7)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(31, 13)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "Total"
        '
        'PictureBox6
        '
        Me.PictureBox6.Cursor = System.Windows.Forms.Cursors.Hand
        Me.PictureBox6.Image = Global.ProjectKios.My.Resources.Resources.close
        Me.PictureBox6.Location = New System.Drawing.Point(1038, 2)
        Me.PictureBox6.Name = "PictureBox6"
        Me.PictureBox6.Size = New System.Drawing.Size(28, 33)
        Me.PictureBox6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox6.TabIndex = 13
        Me.PictureBox6.TabStop = False
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(222, 105)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.ReadOnly = True
        Me.TextBox1.Size = New System.Drawing.Size(88, 20)
        Me.TextBox1.TabIndex = 28
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(184, 108)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(30, 13)
        Me.Label4.TabIndex = 29
        Me.Label4.Text = "/Pcs"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(311, 108)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(37, 13)
        Me.Label13.TabIndex = 30
        Me.Label13.Text = "/Pack"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'penjualan
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1067, 677)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.dgvjual)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.PictureBox6)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "penjualan"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "pembelian"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.nudqty, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvjual, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStrip1.ResumeLayout(False)
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        CType(Me.nudbayar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nuddisc, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox6, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents PictureBox6 As System.Windows.Forms.PictureBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents btncancel As System.Windows.Forms.Button
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cmbitem As System.Windows.Forms.ComboBox
    Friend WithEvents txttanggal As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtno As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btninsert As System.Windows.Forms.Button
    Friend WithEvents txtharga As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents dgvjual As System.Windows.Forms.DataGridView
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents DeleteToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents nudqty As System.Windows.Forms.NumericUpDown
    Friend WithEvents cmbunit As System.Windows.Forms.ComboBox
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents btncetak As System.Windows.Forms.Button
    Friend WithEvents txtkembali As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtgrand As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txttotal As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents nudbayar As System.Windows.Forms.NumericUpDown
    Friend WithEvents nuddisc As System.Windows.Forms.NumericUpDown
    Friend WithEvents EditQtyToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents LinkLabel1 As System.Windows.Forms.LinkLabel
    Friend WithEvents txtkepada As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Column2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column11 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column8 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column7 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ket As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents nmkategori As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents idketmulti As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
End Class
