Imports x = ProjectKios.ServiceReference1
Public Class returnin
    Public user As String = ""
    Public pass As String = ""
    Public iduser As Guid
    Public idakses As Guid
    Private _mySrv As New x.WebService1SoapClient
    Private _secure As New x.AutentikasiUser
    Private _listitem As x.ListDataItem()
    Private _listsatuan As x.ListDatasatuan()
    Private _listUrutan As x.ListDataUrutanRI()
    Private _masteritem As x.datakodeharga()
    Private _konv As x.datakonvpcs()
    Private _iditem As x.DataMasterItem()
    Private _idsupplier As x.DataMastersupplier()
    Private _idsatuan As x.DataMastersatuan()
    Private _urut As String
    Private _datastock As x.ListDataStock()
    Private _koma As Long
    Private _dtDetail As DataTable
    Private _cmbri As x.ListCmbRi()
    Private _cmbri2 As x.ListCmbRi()
    Private _isianRI As x.ListisianRI()
    Private _idjual As x.ListIDJual()
    Private _kategori As x.ListNamaKategori()
    Private _datacons As x.ListConsJasa()
    Private _iditem2 As x.DataMasterItem()
    Private _cekjumlah As x.QtyRi()
    Private _datamultijual As x.ListCmbRi()

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
        txtno.Clear()
        txttanggal.Clear()
        cmbjual.Enabled = False
        cmbjual.SelectedIndex = -1
        cmbitem.Enabled = False
        cmbitem.SelectedIndex = -1
        txtqty.Clear()
        txtsatuan.Clear()
        txtharga.Clear()
        nudqty.Value = 0
        nudqty.Enabled = False
        txtremark.Enabled = False
        txtremark.Clear()
        txttotal.Clear()
        dgvri.Rows.Clear()
        ErrorProvider1.Clear()
    End Sub

    Private Sub btnadd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnadd.Click
        FillcmbJual()
        txtno.Clear()
        cmbjual.SelectedIndex = -1
        btnadd.Enabled = False
        btncancel.Enabled = True
        btninsert.Enabled = True
        btnsave.Enabled = True
        cmbjual.Enabled = True
        cmbitem.Enabled = True
        nudqty.Enabled = True
        txtremark.Enabled = True
        txttanggal.Text = Format(Date.Now, "dd MMM yyyy")
    End Sub
    Public Sub FillcmbJual()
        _cmbri = _mySrv.AmbilNoJual(_secure)
        cmbjual.DataSource = _cmbri
        cmbjual.DisplayMember = "nopengeluaran"
        cmbjual.ValueMember = "nopengeluaran"
    End Sub
    Private Sub penjualan_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        getAccessControl()
        FillcmbJual()
        cmbitem.SelectedIndex = -1
        cmbjual.SelectedIndex = -1
        System.Windows.Forms.Cursor.Current = Cursors.Default
    End Sub

    Private Sub cmbitem_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbitem.SelectedIndexChanged
        If cmbitem.Enabled = False Then Exit Sub
        '_kategori = _mySrv.AmbilKategoriItem(_secure, cmbitem.Text)
        'If _kategori.Length = 0 Then Exit Sub
        'If _kategori(0).namakategori = "kepala" Then
        '    Exit Sub
        'End If
        '_iditem = _mySrv.AmbilIDMasterItem(_secure, cmbitem.Text)
        'If _iditem.Length = 0 Then Exit Sub
        _isianRI = _mySrv.AmbilDataJual2(_secure, cmbitem.Text, cmbjual.Text)
        If _isianRI.Length = 0 Then Exit Sub
        txtqty.Text = _isianRI(0).jumlahkeluar
        txtsatuan.Text = _isianRI(0).namasatuan
        txtharga.Text = _isianRI(0).hargajual
    End Sub

    Private Sub btninsert_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btninsert.Click
        If cmbjual.Text = "" Or cmbitem.Text = "" Or nudqty.Value = 0 Then
            MsgBox("Data Belum Lengkap!")
            Exit Sub
        End If
        _konv = _mySrv.Ambilkonvpcs(_secure, txtsatuan.Text)
        _cekjumlah = _mySrv.AmbilQtyRi(_secure, cmbjual.Text, cmbitem.Text)
        If _cekjumlah.Length = 0 Then
            If nudqty.Value > txtqty.Text * _konv(0).konvpcs Then
                MsgBox("Qty RI melebihi Qty Pengeluaran!")
                Exit Sub
            End If
        Else
            Dim selisih As Decimal = txtqty.Text - _cekjumlah(0).jumlahri
            If nudqty.Value > selisih Then
                MsgBox("Qty Habis di RO!")
                Exit Sub
            End If
        End If

        dgvri.Rows.Add(1)
        dgvri.Rows(dgvri.RowCount - 1).Cells(0).Value = cmbjual.Text
        dgvri.Rows(dgvri.RowCount - 1).Cells(1).Value = txtno.Text
        dgvri.Rows(dgvri.RowCount - 1).Cells(2).Value = txttanggal.Text
        dgvri.Rows(dgvri.RowCount - 1).Cells(3).Value = cmbitem.Text
        dgvri.Rows(dgvri.RowCount - 1).Cells(4).Value = nudqty.Value
        dgvri.Rows(dgvri.RowCount - 1).Cells(5).Value = txtharga.Text
        dgvri.Rows(dgvri.RowCount - 1).Cells(6).Value = txtharga.Text * nudqty.Value
        dgvri.Rows(dgvri.RowCount - 1).Cells(7).Value = txtremark.Text
        dgvri.Update()
        Dim ttl As Decimal
        For i As Integer = 0 To dgvri.RowCount - 1
            ttl += dgvri.Rows(i).Cells(6).Value
        Next
        txttotal.Text = ttl
        cmbitem.SelectedIndex = -1
        cmbjual.SelectedIndex = -1
        txtqty.Clear()
        txtsatuan.Clear()
        txtharga.Clear()
        nudqty.Value = 0
        txtremark.Clear()
        ErrorProvider1.Clear()
    End Sub

    Private Sub dgvjual_CellFormatting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles dgvri.CellFormatting
        dgvri.Rows(e.RowIndex).HeaderCell.Value = CStr(e.RowIndex + 1)
    End Sub

    Private Sub PictureBox6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox6.Click
        Close()
    End Sub

    Private Sub DeleteToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteToolStripMenuItem.Click
        Dim i As Integer = dgvri.SelectedRows(0).Index
        dgvri.Rows.RemoveAt(i)
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

    Private Sub cmbjual_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbjual.SelectedIndexChanged
        If cmbjual.Enabled = False Then Exit Sub
        _cmbri2 = _mySrv.AmbilNamaItemJual(_secure, cmbjual.Text)
        cmbitem.DataSource = _cmbri2
        cmbitem.DisplayMember = "remark"
        cmbitem.ValueMember = "keterangan"
        cmbitem.SelectedIndex = -1
        txtqty.Clear()
        txtharga.Clear()
        txtsatuan.Clear()
    End Sub

    Private Sub cmbjual_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbjual.Validating
        If cmbjual.Text = "" Then
            ErrorProvider1.SetError(cmbjual, "Harus diisi")
        Else
            ErrorProvider1.Clear()
        End If
    End Sub

    Private Sub btnsave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnsave.Click
        Try
            _listUrutan = _mySrv.AmbilListUratanRI(_secure, Format(Date.Now, "yyyy"))
            If _listUrutan.Length = 0 Then
                txtno.Text = "RI-" & Format(Date.Now, "yyyy") & "-0000001"
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
                txtno.Text = _listUrutan(0).kode & "-" & Format(Date.Now, "yyyy") & "-" & _urut & _listUrutan(0).urut
            End If
            For i As Integer = 0 To dgvri.Rows.Count - 1
                Dim nojual As String = dgvri.Rows(i).Cells(0).Value
                _idjual = _mySrv.AmbilIDJual(_secure, nojual)
                Dim namaitem As String = dgvri.Rows(i).Cells(3).Value
                _iditem = _mySrv.AmbilIDMasterItem(_secure, namaitem)
                Dim nori As String = txtno.Text
                Dim qty As Decimal = dgvri.Rows(i).Cells(4).Value
                _idsatuan = _mySrv.AmbilIDMastersatuan(_secure, "Pcs")
                Dim harga As Decimal = dgvri.Rows(i).Cells(5).Value
                Dim remark As String = dgvri.Rows(i).Cells(7).Value
                If _iditem.Length = 0 Then
                    _mySrv.TambahRI2(_secure, _idjual(0).idpengeluaran, nori, qty, harga, _idsatuan(0).idsatuan, remark, user, namaitem)
                    _datamultijual = _mySrv.AmbilDataItemJualMulti(_secure, nojual)
                        For ii As Integer = 0 To _datamultijual.Length - 1
                            _iditem2 = _mySrv.AmbilIDMasterItem(_secure, _datamultijual(ii).remark)
                            _datastock = _mySrv.AmbilDataStock(_secure, _iditem2(0).iditem)
                        _mySrv.UpdateStock(_secure, _datastock(0).jumlahstock + qty, user, _iditem2(0).iditem)
                        Next
                Else
                    _mySrv.TambahRI(_secure, _idjual(0).idpengeluaran, _iditem(0).iditem, nori, qty, harga, _idsatuan(0).idsatuan, remark, user)
                    _kategori = _mySrv.AmbilKategoriItem(_secure, namaitem)
                    If _kategori(0).namakategori.ToString.ToLower = "jasa" Then
                        _datacons = _mySrv.AmbilConsJasa(_secure, _iditem(0).iditem)
                        For ii As Integer = 0 To _datacons.Length - 1
                            _iditem2 = _mySrv.AmbilIDMasterItem(_secure, _datacons(ii).namaitem)
                            _datastock = _mySrv.AmbilDataStock(_secure, _iditem2(0).iditem)
                            _mySrv.UpdateStock(_secure, _datastock(0).jumlahstock + (_datacons(ii).qtycons * qty), user, _iditem2(0).iditem)
                        Next
                    Else
                        _datastock = _mySrv.AmbilDataStock(_secure, _iditem(0).iditem)
                        _mySrv.UpdateStock(_secure, _datastock(0).jumlahstock + qty, user, _iditem(0).iditem)
                    End If
                    End If

            Next
            If _listUrutan.Length = 0 Then
                _mySrv.TambahUrutanRI(_secure, Format(Date.Now, "yyyy"), 2, "RI")
            Else
                _mySrv.UpdateUrutanRI(_secure, Format(Date.Now, "yyyy"), _listUrutan(0).urut + 1)
            End If
            MsgBox("Success! No Return IN : " & txtno.Text, MsgBoxStyle.OkOnly, "Information...")
            btnadd.Enabled = True
            btnsave.Enabled = False
            btncancel.Enabled = False
            btninsert.Enabled = False
            txtno.Clear()
            txttanggal.Clear()
            cmbjual.Enabled = False
            cmbjual.SelectedIndex = -1
            cmbitem.Enabled = False
            cmbitem.SelectedIndex = -1
            txtqty.Clear()
            txtsatuan.Clear()
            txtharga.Clear()
            nudqty.Value = 0
            nudqty.Enabled = False
            txtremark.Enabled = False
            txtremark.Clear()
            txttotal.Clear()
            dgvri.Rows.Clear()
            ErrorProvider1.Clear()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
End Class