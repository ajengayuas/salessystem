<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AksesMenu
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
        Me.dgvmenu = New System.Windows.Forms.DataGridView()
        Me.No = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.N = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cek = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.btnupdate = New System.Windows.Forms.Button()
        Me.btnadd = New System.Windows.Forms.Button()
        Me.cmbmenu = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        CType(Me.PictureBox6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvmenu, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'PictureBox6
        '
        Me.PictureBox6.Cursor = System.Windows.Forms.Cursors.Hand
        Me.PictureBox6.Image = Global.ProjectKios.My.Resources.Resources.close
        Me.PictureBox6.Location = New System.Drawing.Point(551, 14)
        Me.PictureBox6.Name = "PictureBox6"
        Me.PictureBox6.Size = New System.Drawing.Size(28, 33)
        Me.PictureBox6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox6.TabIndex = 13
        Me.PictureBox6.TabStop = False
        '
        'dgvmenu
        '
        Me.dgvmenu.AllowUserToAddRows = False
        Me.dgvmenu.AllowUserToDeleteRows = False
        Me.dgvmenu.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvmenu.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.No, Me.Column1, Me.Column2, Me.N, Me.cek})
        Me.dgvmenu.Location = New System.Drawing.Point(12, 49)
        Me.dgvmenu.Name = "dgvmenu"
        Me.dgvmenu.RowHeadersWidth = 50
        Me.dgvmenu.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvmenu.Size = New System.Drawing.Size(569, 300)
        Me.dgvmenu.TabIndex = 14
        '
        'No
        '
        Me.No.DataPropertyName = "idgroup"
        Me.No.HeaderText = "idgroup"
        Me.No.Name = "No"
        Me.No.Visible = False
        Me.No.Width = 50
        '
        'Column1
        '
        Me.Column1.DataPropertyName = "idakses"
        Me.Column1.HeaderText = "idakses"
        Me.Column1.Name = "Column1"
        Me.Column1.Visible = False
        '
        'Column2
        '
        Me.Column2.DataPropertyName = "idmenu"
        Me.Column2.HeaderText = "idmenu"
        Me.Column2.Name = "Column2"
        Me.Column2.Visible = False
        '
        'N
        '
        Me.N.DataPropertyName = "namamenu"
        Me.N.HeaderText = "Nama Menu"
        Me.N.Name = "N"
        Me.N.Width = 200
        '
        'cek
        '
        Me.cek.DataPropertyName = "statusaktif"
        Me.cek.HeaderText = "Aktif"
        Me.cek.Name = "cek"
        '
        'btnupdate
        '
        Me.btnupdate.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnupdate.Location = New System.Drawing.Point(492, 6)
        Me.btnupdate.Name = "btnupdate"
        Me.btnupdate.Size = New System.Drawing.Size(75, 38)
        Me.btnupdate.TabIndex = 15
        Me.btnupdate.Text = "Update"
        Me.btnupdate.UseVisualStyleBackColor = True
        '
        'btnadd
        '
        Me.btnadd.Location = New System.Drawing.Point(286, 12)
        Me.btnadd.Name = "btnadd"
        Me.btnadd.Size = New System.Drawing.Size(75, 23)
        Me.btnadd.TabIndex = 16
        Me.btnadd.Text = "Add Menu"
        Me.btnadd.UseVisualStyleBackColor = True
        '
        'cmbmenu
        '
        Me.cmbmenu.FormattingEnabled = True
        Me.cmbmenu.Location = New System.Drawing.Point(89, 12)
        Me.cmbmenu.Name = "cmbmenu"
        Me.cmbmenu.Size = New System.Drawing.Size(191, 21)
        Me.cmbmenu.TabIndex = 17
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(9, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(65, 13)
        Me.Label1.TabIndex = 18
        Me.Label1.Text = "Nama Menu"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.DarkSeaGreen
        Me.Panel1.Controls.Add(Me.cmbmenu)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.btnupdate)
        Me.Panel1.Controls.Add(Me.btnadd)
        Me.Panel1.Location = New System.Drawing.Point(12, 349)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(570, 52)
        Me.Panel1.TabIndex = 19
        '
        'AksesMenu
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(593, 413)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.dgvmenu)
        Me.Controls.Add(Me.PictureBox6)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "AksesMenu"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "AksesMenu"
        CType(Me.PictureBox6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvmenu, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PictureBox6 As System.Windows.Forms.PictureBox
    Friend WithEvents dgvmenu As System.Windows.Forms.DataGridView
    Friend WithEvents No As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents N As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cek As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents btnupdate As System.Windows.Forms.Button
    Friend WithEvents btnadd As System.Windows.Forms.Button
    Friend WithEvents cmbmenu As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
End Class
