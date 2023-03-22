Imports x = ProjectKios.ServiceReference1
Public Class returnout
    Public user As String = ""
    Public pass As String = ""
    Public iduser As Guid
    Public idakses As Guid
    Private _mySrv As New x.WebService1SoapClient
    Private _secure As New x.AutentikasiUser
    Private _listitem As x.ListDataItem()
    Private _listsatuan As x.ListDatasatuan()
    Private _listUrutan As x.ListDataUrutanRO()
    Private _masteritem As x.datakodeharga()
    Private _konv As x.datakonvpcs()
    Private _iditem As x.DataMasterItem()
    Private _idsupplier As x.DataMastersupplier()
    Private _idsatuan As x.DataMastersatuan()
    Private _urut As String
    Private _datastock As x.ListDataStock()
    Private _koma As Long
    Private _dtDetail As DataTable
    Private _cmbro As x.ListCmbRo()
    Private _isianRO As x.ListisianRO()
    Private _idbeli As x.ListIDBeli()
    Private _kategori As x.ListNamaKategori()
    Private _datacons As x.ListConsJasa()
    Private _iditem2 As x.DataMasterItem()
    Private _cekjumlah As x.QtyRo()

    Private Sub getAccessControl()
        _secure.username = user.ToLower
        _secure.password = pass
        If _secure.Username = "" And _secure.Password = "" Then Me.Close()
    End Sub

    Private Sub btncancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btncancel.Click
        btnadd.Enabled = True
        btnsave.Enabled = False
        btncancel.Enabled = False
        btninsert.Enabled = False
        'btncetak.Enabled = False
        txtno.Clear()
        txttanggal.Clear()
        cmbbeli.Enabled = False
        cmbbeli.SelectedIndex = -1
        cmbitem.Enabled = False
        cmbitem.SelectedIndex = -1
        txtqty.Clear()
        txtsatuan.Clear()
        txtharga.Clear()
        txtsent.Clear()
        nudqty.Value = 0
        nudqty.Enabled = False
        txtremark.Enabled = False
        txtremark.Clear()
        cbinhouse.Enabled = False
        cbinhouse.Checked = False
        txttotal.Clear()
        dgvro.Rows.Clear()
        ErrorProvider1.Clear()
    End Sub

    Private Sub btnadd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnadd.Click
        FillcmbBeli()
        txtno.Clear()
        cmbbeli.SelectedIndex = -1
        btnadd.Enabled = False
        btncancel.Enabled = True
        btninsert.Enabled = True
        btnsave.Enabled = True
        'btncetak.Enabled = False
        cmbbeli.Enabled = True
        cmbitem.Enabled = True
        nudqty.Enabled = True
        txtremark.Enabled = True
        cbinhouse.Enabled = True
        txttanggal.Text = Format(Date.Now, "dd MMM yyyy")
    End Sub
    Public Sub FillcmbBeli()
        _cmbro = _mySrv.AmbilNoBeli(_secure)
        cmbbeli.DataSource = _cmbro
        cmbbeli.DisplayMember = "nopemasukan"
        cmbbeli.ValueMember = "nopemasukan"
    End Sub
    Private Sub penjualan_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        getAccessControl()
        FillcmbBeli()
        cmbitem.SelectedIndex = -1
        cmbbeli.SelectedIndex = -1
        System.Windows.Forms.Cursor.Current = Cursors.Default
    End Sub

    Private Sub cmbitem_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbitem.SelectedIndexChanged
        If cmbitem.Enabled = False Then Exit Sub
        _iditem = _mySrv.AmbilIDMasterItem(_secure, cmbitem.Text)
        If _iditem.Length = 0 Then Exit Sub
        _isianRO = _mySrv.AmbilDataBeli(_secure, _iditem(0).iditem)
        If _isianRO.Length = 0 Then Exit Sub
        txtqty.Text = _isianRO(0).jumlahitem
        txtsatuan.Text = _isianRO(0).namasatuan
        txtharga.Text = _isianRO(0).hargabeliperpcs
        txtsent.Text = _isianRO(0).namasupplier
    End Sub


    Private Sub btninsert_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btninsert.Click
        If cmbbeli.Text = "" Or cmbitem.Text = "" Or nudqty.Value = 0 Then
            MsgBox("Data Belum Lengkap!")
            Exit Sub
        End If
        Dim sent As String
        If cbinhouse.Checked = True Then
            sent = "INHOUSE"
        Else
            sent = txtsent.Text
        End If
        _konv = _mySrv.Ambilkonvpcs(_secure, txtsatuan.Text)
        If nudqty.Value > txtqty.Text * _konv(0).konvpcs Then
            MsgBox("Qty RO melebihi Qty Pemasukan!")
            Exit Sub
        End If
        _cekjumlah = _mySrv.AmbilQtyRo(_secure, cmbbeli.Text, cmbitem.Text)
        Dim jmlro As Integer = 0
        If _cekjumlah.Length = 0 Then
            jmlro = 0
        Else
            jmlro = _cekjumlah(0).jumlahro
        End If
        Dim selisih As Decimal = (txtqty.Text * _konv(0).konvpcs) - jmlro
        If nudqty.Value > selisih Then
            MsgBox("Qty Habis di RO!")
            Exit Sub
        End If
        dgvro.Rows.Add(1)
        dgvro.Rows(dgvro.RowCount - 1).Cells(0).Value = cmbbeli.Text
        dgvro.Rows(dgvro.RowCount - 1).Cells(1).Value = txtno.Text
        dgvro.Rows(dgvro.RowCount - 1).Cells(2).Value = txttanggal.Text
        dgvro.Rows(dgvro.RowCount - 1).Cells(3).Value = cmbitem.Text
        dgvro.Rows(dgvro.RowCount - 1).Cells(4).Value = nudqty.Value
        dgvro.Rows(dgvro.RowCount - 1).Cells(5).Value = txtharga.Text
        dgvro.Rows(dgvro.RowCount - 1).Cells(6).Value = txtharga.Text * nudqty.Value
        dgvro.Rows(dgvro.RowCount - 1).Cells(7).Value = sent
        dgvro.Rows(dgvro.RowCount - 1).Cells(8).Value = txtremark.Text
        dgvro.Update()
        Dim ttl As Decimal
        For i As Integer = 0 To dgvro.RowCount - 1
            ttl += dgvro.Rows(i).Cells(6).Value
        Next
        txttotal.Text = ttl
        cmbitem.SelectedIndex = -1
        cmbbeli.SelectedIndex = -1
        txtqty.Clear()
        txtsatuan.Clear()
        txtharga.Clear()
        txtsent.Clear()
        nudqty.Value = 0
        txtremark.Clear()
        ErrorProvider1.Clear()
    End Sub

    Private Sub dgvro_CellFormatting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles dgvro.CellFormatting
        dgvro.Rows(e.RowIndex).HeaderCell.Value = CStr(e.RowIndex + 1)
    End Sub

    Private Sub PictureBox6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox6.Click
        Close()
    End Sub

    Private Sub DeleteToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteToolStripMenuItem.Click
        Dim i As Integer = dgvro.SelectedRows(0).Index
        dgvro.Rows.RemoveAt(i)
    End Sub

    Private Sub txttotal_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txttotal.TextChanged
        If txttotal.Text = "" Then Exit Sub
        _koma = txttotal.Text
        txttotal.Text = Format(_koma, "#,##0.00")
        txttotal.SelectionStart = Len(txttotal.Text)
    End Sub

    Private Sub txtharga_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtharga.TextChanged
        If txtharga.Text = "" Then Exit Sub
        _koma = txtharga.Text
        txtharga.Text = Format(_koma, "#,##0.00")
        txtharga.SelectionStart = Len(txtharga.Text)
    End Sub

    Private Sub cmbitem_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbitem.Validating
        If cmbitem.Text = "" Then
            ErrorProvider1.SetError(cmbitem, "Harus diisi")
        Else
            ErrorProvider1.Clear()
        End If
    End Sub

    Private Sub nudqty_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles nudqty.Validating
        If nudqty.Value = 0 Then
            ErrorProvider1.SetError(nudqty, "Harus diisi")
        Else
            ErrorProvider1.Clear()
        End If
    End Sub

    Private Sub btncetak_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        System.Windows.Forms.Cursor.Current = Cursors.WaitCursor
        Dim f As New forminvoice
        f.user = user
        f.pass = pass
        f.iduser = iduser
        f.no = txtno.Text
        f.ShowDialog()
    End Sub

    Private Sub cmbbeli_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbbeli.SelectedIndexChanged
        If cmbbeli.Enabled = False Then Exit Sub
        _cmbro = _mySrv.AmbilNamaItem(_secure, cmbbeli.Text)
        cmbitem.DataSource = _cmbro
        cmbitem.DisplayMember = "namaitem"
        cmbitem.ValueMember = "namaitem"
        cmbitem.SelectedIndex = -1
        txtqty.Clear()
        txtharga.Clear()
        txtsatuan.Clear()
        txtsent.Clear()
    End Sub

    Private Sub btnsave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnsave.Click
        Try
            _listUrutan = _mySrv.AmbilListUratanRO(_secure, Format(Date.Now, "yyyy"))
            If _listUrutan.Length = 0 Then
                txtno.Text = "RO-2021-0000001"
            Else
                Dim counts As Integer = _listUrutan(0).urut.ToString.Count
                If counts = 1 Then
                    _urut = "000000"
                ElseIf counts = 2 Then
                    _urut = "00000"
                ElseIf counts = 3 Then
                    _urut = "0000"
                ElseIf counts = 4 Then
                    _urut = "000"
                ElseIf counts = 5 Then
                    _urut = "00"
                ElseIf counts = 6 Then
                    _urut = "0"
                Else
                    _urut = ""
                End If
                txtno.Text = _listUrutan(0).kode & "-2021-" & _urut & _listUrutan(0).urut
            End If
            For i As Integer = 0 To dgvro.Rows.Count - 1
                Dim nobeli As String = dgvro.Rows(i).Cells(0).Value
                _idbeli = _mySrv.AmbilIDBeli(_secure, nobeli)
                Dim namaitem As String = dgvro.Rows(i).Cells(3).Value
                _iditem = _mySrv.AmbilIDMasterItem(_secure, namaitem)
                Dim noro As String = txtno.Text
                Dim qty As Decimal = dgvro.Rows(i).Cells(4).Value
                _idsatuan = _mySrv.AmbilIDMastersatuan(_secure, "Pcs")
                Dim harga As Decimal = dgvro.Rows(i).Cells(5).Value
                Dim sent As String = dgvro.Rows(i).Cells(7).Value
                Dim remark As String = dgvro.Rows(i).Cells(8).Value
                _mySrv.TambahRO(_secure, _idbeli(0).idpemasukan, _iditem(0).iditem, noro, qty, _idsatuan(0).idsatuan, harga, sent, remark, user)
                _kategori = _mySrv.AmbilKategoriItem(_secure, namaitem)
                If _kategori(0).namakategori.ToString.ToLower = "jasa" Then
                    _datacons = _mySrv.AmbilConsJasa(_secure, _iditem(0).iditem)
                    For ii As Integer = 0 To _datacons.Length - 1
                        _iditem2 = _mySrv.AmbilIDMasterItem(_secure, _datacons(ii).namaitem)
                        _datastock = _mySrv.AmbilDataStock(_secure, _iditem2(0).iditem)
                        _mySrv.UpdateStock(_secure, _datastock(0).jumlahstock - (_datacons(ii).qtycons * qty), user, _iditem2(0).iditem)
                    Next
                Else
                    _datastock = _mySrv.AmbilDataStock(_secure, _iditem(0).iditem)
                    _mySrv.UpdateStock(_secure, _datastock(0).jumlahstock - qty, user, _iditem(0).iditem)
                End If
            Next
            If _listUrutan.Length = 0 Then
                _mySrv.TambahUrutanRO(_secure, Format(Date.Now, "yyyy"), 2, "RO")
            Else
                _mySrv.UpdateUrutanRO(_secure, Format(Date.Now, "yyyy"), _listUrutan(0).urut + 1)
            End If
            MsgBox("Success! No Return Out : " & txtno.Text, MsgBoxStyle.OkOnly, "Information...")
            btnadd.Enabled = True
            btnsave.Enabled = False
            btncancel.Enabled = False
            btninsert.Enabled = False
            'btncetak.Enabled = True
            txttanggal.Clear()
            cmbbeli.Enabled = False
            cmbbeli.SelectedIndex = -1
            cmbitem.Enabled = False
            cmbitem.SelectedIndex = -1
            txtqty.Clear()
            txtsatuan.Clear()
            txtharga.Clear()
            txtsent.Clear()
            nudqty.Value = 0
            nudqty.Enabled = False
            txtremark.Enabled = False
            txtremark.Clear()
            cbinhouse.Enabled = False
            cbinhouse.Checked = False
            txttotal.Clear()
            dgvro.Rows.Clear()
            ErrorProvider1.Clear()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub cmbbeli_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbbeli.Validating
        If cmbbeli.Text = "" Then
            ErrorProvider1.SetError(cmbbeli, "Harus diisi")
        Else
            ErrorProvider1.Clear()
        End If
    End Sub

End Class