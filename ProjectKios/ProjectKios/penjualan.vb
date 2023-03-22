Imports x = ProjectKios.ServiceReference1
Public Class penjualan
    Public user As String = ""
    Public pass As String = ""
    Public iduser As Guid
    Public idakses As Guid
    Private _mySrv As New x.WebService1SoapClient
    Private _secure As New x.AutentikasiUser
    Private _listitem As x.ListDataItem()
    Private _listsatuan As x.ListDatasatuan()
    Private _listUrutan As x.ListDataUrutanJual()
    Private _masteritem As x.datakodeharga()
    Private _konv As x.datakonvpcs()
    Private _iditem As x.DataMasterItem()
    Private _iditem2 As x.DataMasterItem()
    Private _idsupplier As x.DataMastersupplier()
    Private _idsatuan As x.DataMastersatuan()
    Private _urut As String
    Private _datastock As x.ListDataStock()
    Private _koma As Long
    Private _dtDetail As DataTable
    Private _masteritem1 As x.datakodeharga()
    Private _masteritem2 As x.datakodeharga()
    Private _masteritem3 As x.datakodeharga()
    Private _masteritem4 As x.datakodeharga()
    Private _masteritem5 As x.datakodeharga()
    Private _kategori As x.ListNamaKategori()
    Private _datacons As x.ListConsJasa()
    Private _idmulti As Guid

    Private Sub getAccessControl()
        _secure.username = user.ToLower
        _secure.password = pass
        If _secure.username = "" And _secure.password = "" Then Me.Close()
    End Sub

    Private Sub btncancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btncancel.Click
        txtkepada.Clear()
        txtkepada.Enabled = False
        txtremark.Enabled = False
        txtremark.Clear()
        btnadd.Enabled = True
        btncancel.Enabled = False
        btnubah.Enabled = False
        btninsert.Enabled = False
        cmbitem.SelectedIndex = -1
        cmbunit.Text = ""
        txtno.Clear()
        txttanggal.Clear()
        cmbitem.Enabled = False
        txtkode.Clear()
        txtstock.Clear()
        nudqty.Value = 0
        nudqty.Enabled = False
        cmbunit.Enabled = False
        txtharga.Clear()
        nudharga.Value = 0
        nudbayar.Value = 0
        dgvjual.Rows.Clear()
        nuddisc.Value = 0
        nuddisc.Enabled = False
        nudbayar.Enabled = False
        nudbayar.Value = 0
        txttotal.Clear()
        txtkembali.Clear()
        txtgrand.Clear()
        btncetak.Enabled = False
        cbmulti.Enabled = False
        cbmulti.Checked = False
        ErrorProvider1.Clear()
    End Sub

    Private Sub btnadd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnadd.Click
        nudbayar.Value = 0
        txtkepada.Clear()
        txtkepada.Enabled = True
        btnadd.Enabled = False
        btncancel.Enabled = True
        btninsert.Enabled = True
        btnubah.Enabled = True
        cmbitem.Enabled = True
        cmbunit.Enabled = True
        nudqty.Enabled = True
        nuddisc.Enabled = True
        nudbayar.Enabled = True
        btncetak.Enabled = True
        cbmulti.Enabled = True
        txttanggal.Text = Format(DateTime.Now, "dd MMM yyyy ss:mm:dd")
    End Sub
    Public Sub Fillcmbitem()
        _listitem = _mySrv.AmbilListItemBeli(_secure)
        cmbitem.DataSource = _listitem
        cmbitem.DisplayMember = "namaitem"
        cmbitem.ValueMember = "namaitem"
    End Sub
    Private Sub penjualan_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        getAccessControl()
        Fillcmbitem()
        cmbitem.SelectedIndex = -1
        cmbunit.SelectedIndex = -1
        System.Windows.Forms.Cursor.Current = Cursors.Default
    End Sub

    Private Sub cmbitem_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbitem.SelectedIndexChanged
        cmbunit.Items.Clear()
        If cmbitem.Enabled = False Then Exit Sub
        _masteritem = _mySrv.Ambilkodeharga(_secure, cmbitem.Text)
        If _masteritem.Length = 0 Then Exit Sub
        txtkode.Text = _masteritem(0).kodeitem
        _datastock = _mySrv.AmbilDataStock(_secure, _masteritem(0).iditem)
        If _datastock.Length = 0 Then
            txtstock.Text = 0
        Else
            txtstock.Text = _datastock(0).jumlahstock
        End If
        cmbunit.Items.Add(_masteritem(0).namasatuan)
        cmbunit.Items.Add("PCS")
    End Sub

    Private Sub btnubah_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnubah.Click
        If btnubah.Text = "UBAH" Then
            nudharga.Enabled = True
            btnubah.Text = "Cancel"
        Else
            nudharga.Enabled = False
            btnubah.Text = "UBAH"
        End If
        ErrorProvider1.Clear()
    End Sub

    Private Sub cmbunit_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbunit.SelectedIndexChanged
        If cmbitem.Enabled = False Then Exit Sub
        _masteritem = _mySrv.Ambilkodeharga(_secure, cmbitem.Text)
        If cmbunit.Text.ToLower = "pcs" Then
            txtharga.Text = _masteritem(0).hargaperpcs
        Else
            txtharga.Text = _masteritem(0).harga
        End If
    End Sub

    Private Sub btninsert_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btninsert.Click
        If cbmulti.Checked = False Then
            If cmbitem.Text = "" Then
                MsgBox("Data Belum Lengkap!")
                Exit Sub
            End If
        End If
        If cmbunit.Text = "" Or nudqty.Value = 0 Then
            MsgBox("Data Belum Lengkap!")
            Exit Sub
        End If
        If nudharga.Enabled = True Then
            If nudharga.Value = 0 Then
                MsgBox("Data Belum Lengkap!")
                Exit Sub
            End If
        End If
        Dim harga As Decimal
        If nudharga.Enabled = True Then
            harga = nudharga.Value
        Else
            harga = txtharga.Text
        End If
        If cbmulti.Checked = False Then
            _kategori = _mySrv.AmbilKategoriItem(_secure, cmbitem.Text)
            _konv = _mySrv.Ambilkonvpcs(_secure, cmbunit.Text)
            If _kategori(0).namakategori.ToLower <> "jasa" Then
                Dim stock As Decimal
                stock = txtstock.Text - (_konv(0).konvpcs * nudqty.Value)
                If stock < 0 Then
                    MsgBox("Stock Kurang!")
                    Exit Sub
                End If
            End If
        End If
        Dim ket As String = ""
        If cbmulti.Checked = True Then
            ket = "kepala"
        Else
            ket = "normal"
        End If
        If cbmulti.Checked = True And txtremark.Text = "" Then
            MsgBox("Remark Kosong!")
            Exit Sub
        End If
        dgvjual.Rows.Add(1)
        dgvjual.Rows(dgvjual.RowCount - 1).Cells(0).Value = "-"
        dgvjual.Rows(dgvjual.RowCount - 1).Cells(1).Value = txttanggal.Text
        If cbmulti.Checked = True Then
            dgvjual.Rows(dgvjual.RowCount - 1).Cells(2).Value = "multi"
            dgvjual.Rows(dgvjual.RowCount - 1).Cells(3).Value = txtremark.Text
            dgvjual.Rows(dgvjual.RowCount - 1).Cells(8).Value = nudqty.Value
        Else
            dgvjual.Rows(dgvjual.RowCount - 1).Cells(2).Value = txtkode.Text
            dgvjual.Rows(dgvjual.RowCount - 1).Cells(3).Value = cmbitem.Text
            dgvjual.Rows(dgvjual.RowCount - 1).Cells(8).Value = _konv(0).konvpcs * nudqty.Value
        End If
        dgvjual.Rows(dgvjual.RowCount - 1).Cells(4).Value = nudqty.Value
        dgvjual.Rows(dgvjual.RowCount - 1).Cells(5).Value = cmbunit.Text
        dgvjual.Rows(dgvjual.RowCount - 1).Cells(6).Value = harga
        dgvjual.Rows(dgvjual.RowCount - 1).Cells(7).Value = nudqty.Value * harga
        dgvjual.Rows(dgvjual.RowCount - 1).Cells(9).Value = ket
        If _kategori Is Nothing Then
            dgvjual.Rows(dgvjual.RowCount - 1).Cells(10).Value = "-"
        Else
            dgvjual.Rows(dgvjual.RowCount - 1).Cells(10).Value = _kategori(0).namakategori
        End If
        If cbmulti.Checked = True Then
            dgvjual.Rows(dgvjual.RowCount - 1).Cells(11).Value = _idmulti
        Else
            dgvjual.Rows(dgvjual.RowCount - 1).Cells(11).Value = "-"
        End If
        dgvjual.Update()
        Dim ttl As Decimal
        For i As Integer = 0 To dgvjual.RowCount - 1
            If dgvjual.Rows(i).Cells(9).Value <> "multi" Then
                ttl += dgvjual.Rows(i).Cells(7).Value
            End If
        Next
        txttotal.Text = ttl
        cmbitem.SelectedIndex = -1
        cmbunit.Text = ""
        txtkode.Clear()
        txtstock.Clear()
        nudqty.Value = 0
        txtharga.Clear()
        nudharga.Value = 0
        cbmulti.Checked = False
        txtremark.Clear()
        txtremark.Enabled = False
        btnubah.Text = "UBAH"
        nudharga.Enabled = False
        nudharga.Value = 0
        cmbitem.Enabled = True
        cbmulti.Enabled = True
        ErrorProvider1.Clear()
    End Sub

    Private Sub dgvjual_CellFormatting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles dgvjual.CellFormatting
        dgvjual.Rows(e.RowIndex).HeaderCell.Value = CStr(e.RowIndex + 1)
    End Sub

    Private Sub PictureBox6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox6.Click
        Close()
    End Sub

    Private Sub DeleteToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteToolStripMenuItem.Click
        Dim i As Integer = dgvjual.SelectedRows(0).Index
        dgvjual.Rows.RemoveAt(i)
        Dim ttl As Decimal
        For ii As Integer = 0 To dgvjual.RowCount - 1
            If dgvjual.Rows(ii).Cells(9).Value <> "multi" Then
                ttl += dgvjual.Rows(ii).Cells(7).Value
            End If
        Next
        txttotal.Text = ttl
    End Sub

    Private Sub EditQtyToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EditQtyToolStripMenuItem.Click
        Dim i As Integer = dgvjual.SelectedRows(0).Index
        If dgvjual.Rows(i).Cells(9).Value = "multi" Then
            MsgBox("Item Multi, Tidak Dapat di Edit!")
            Exit Sub
        End If
        Dim editqty As String
        editqty = InputBox("Masukkan Qty Baru", "Edit Qty")
        If Not IsNumeric(editqty) Then
            MsgBox("Harus Numeric")
            Exit Sub
        End If
        Dim qtystok As Decimal
        Dim itemname As String = dgvjual.Rows(i).Cells(3).Value
        _iditem = _mySrv.AmbilIDMasterItem(_secure, itemname)
        If _iditem.Length > 0 And dgvjual.Rows(i).Cells(9).Value <> "kepala" Then
            _datastock = _mySrv.AmbilDataStock(_secure, _iditem(0).iditem)
            If _datastock.Length = 0 Then
                qtystok = 0
            Else
                qtystok = _datastock(0).jumlahstock
            End If
        End If

        _konv = _mySrv.Ambilkonvpcs(_secure, dgvjual.Rows(i).Cells(5).Value)
        _kategori = _mySrv.AmbilKategoriItem(_secure, dgvjual.Rows(i).Cells(3).Value)
        If _kategori.Length = 0 Then
            dgvjual.Rows(i).Cells(4).Value = editqty
            dgvjual.Rows(i).Cells(8).Value = _konv(0).konvpcs * editqty
            dgvjual.Rows(i).Cells(7).Value = dgvjual.Rows(i).Cells(6).Value * editqty
            Dim ttl As Decimal
            For ii As Integer = 0 To dgvjual.RowCount - 1
                If dgvjual.Rows(ii).Cells(9).Value <> "multi" Then
                    ttl += dgvjual.Rows(ii).Cells(7).Value
                End If
            Next
            txttotal.Text = ttl
        Else
            If _kategori(0).namakategori.ToLower <> "jasa" Then
                If qtystok - (_konv(0).konvpcs * editqty) >= 0 Then
                    dgvjual.Rows(i).Cells(4).Value = editqty
                    dgvjual.Rows(i).Cells(8).Value = _konv(0).konvpcs * editqty
                    dgvjual.Rows(i).Cells(7).Value = dgvjual.Rows(i).Cells(6).Value * editqty
                    Dim ttl As Decimal
                    For ii As Integer = 0 To dgvjual.RowCount - 1
                        ttl += dgvjual.Rows(ii).Cells(7).Value
                    Next
                    txttotal.Text = ttl
                Else
                    MsgBox("Stock Tidak Cukup")
                    Exit Sub
                End If
            Else
                dgvjual.Rows(i).Cells(4).Value = editqty
                dgvjual.Rows(i).Cells(8).Value = _konv(0).konvpcs * editqty
                dgvjual.Rows(i).Cells(7).Value = dgvjual.Rows(i).Cells(6).Value * editqty
                Dim ttl As Decimal
                For ii As Integer = 0 To dgvjual.RowCount - 1
                    ttl += dgvjual.Rows(ii).Cells(7).Value
                Next
                txttotal.Text = ttl
            End If
        End If
    End Sub

    Private Sub nuddisc_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles nuddisc.KeyPress
        If e.KeyChar = Convert.ToChar(13) Then
            txtgrand.Text = txttotal.Text - nuddisc.Value
        End If
    End Sub

    Private Sub nudbayar_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles nudbayar.KeyPress
        _listUrutan = _mySrv.AmbilListUratanJual(_secure, Format(Date.Now, "yyyy"))
        If _listUrutan.Length = 0 Then
            txtno.Text = "JU-" & Format(Date.Now, "yyyy") & "-0000001"
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
            txtno.Text = "JU-" & Format(Date.Now, "yyyy") & "-" & _urut & _listUrutan(0).urut
        End If
        If e.KeyChar = Convert.ToChar(13) Then
            txtkembali.Text = nudbayar.Value - txtgrand.Text
            For i As Integer = 0 To dgvjual.Rows.Count - 1
                Dim namaitem As String = dgvjual.Rows(i).Cells(3).Value
                Dim no As String = txtno.Text
                Dim jml As String = dgvjual.Rows(i).Cells(4).Value
                Dim satuan As String = dgvjual.Rows(i).Cells(5).Value
                Dim hrg As String = dgvjual.Rows(i).Cells(6).Value
                Dim qtykonv As String = dgvjual.Rows(i).Cells(8).Value
                Dim ket As String = dgvjual.Rows(i).Cells(9).Value
                Dim multiid As Guid
                If ket <> "normal" Then
                    multiid = dgvjual.Rows(i).Cells(11).Value
                End If
                If ket <> "kepala" Then
                    _iditem = _mySrv.AmbilIDMasterItem(_secure, namaitem)
                End If
                _idsatuan = _mySrv.AmbilIDMastersatuan(_secure, satuan)
                Dim dis As Decimal = 0
                If ket = "normal" Then
                    If i > 0 Then
                        dis = 0
                    Else
                        dis = nuddisc.Value
                    End If
                    _mySrv.TambahJual(_secure, iduser, _iditem(0).iditem, no, DateTime.Now, jml, _idsatuan(0).idsatuan, hrg, dis, ket, namaitem, user)
                ElseIf ket = "multi" Then
                    If i > 0 Then
                        dis = 0
                    Else
                        dis = nuddisc.Value
                    End If
                    _mySrv.TambahJualMulti(_secure, iduser, _iditem(0).iditem, multiid, no, DateTime.Now, jml, _idsatuan(0).idsatuan, hrg, dis, ket, namaitem, user)
                Else
                    If i > 0 Then
                        dis = 0
                    Else
                        dis = nuddisc.Value
                    End If
                    _mySrv.TambahJualKepala(_secure, iduser, multiid, no, DateTime.Now, jml, _idsatuan(0).idsatuan, hrg, dis, ket, namaitem, user)
                End If
                If ket <> "kepala" Then
                    If dgvjual.Rows(i).Cells(10).Value.ToString.ToLower = "jasa" Then
                        _datacons = _mySrv.AmbilConsJasa(_secure, _iditem(0).iditem)
                        For ii As Integer = 0 To _datacons.Length - 1
                            _iditem2 = _mySrv.AmbilIDMasterItem(_secure, _datacons(ii).namaitem)
                            _datastock = _mySrv.AmbilDataStock(_secure, _iditem2(0).iditem)
                            _mySrv.UpdateStock(_secure, _datastock(0).jumlahstock - (_datacons(ii).qtycons * qtykonv), user, _iditem2(0).iditem)
                        Next
                    Else
                        _datastock = _mySrv.AmbilDataStock(_secure, _iditem(0).iditem)
                        _mySrv.UpdateStock(_secure, _datastock(0).jumlahstock - qtykonv, user, _iditem(0).iditem)
                    End If
                End If
            Next
            If _listUrutan.Length = 0 Then
                _mySrv.TambahUrutanJual(_secure, Format(Date.Now, "yyyy"), 2)
            Else
                _mySrv.UpdateUrutanJual(_secure, Format(Date.Now, "yyyy"), _listUrutan(0).urut + 1)
            End If
            MsgBox("Success! No Penjualan : " & txtno.Text, MsgBoxStyle.OkOnly, "Information...")
            btnadd.Enabled = True
            btncancel.Enabled = False
            btnubah.Enabled = False
            btninsert.Enabled = False
            cmbitem.SelectedIndex = -1
            cmbunit.Text = ""
            txttanggal.Clear()
            cmbitem.Enabled = False
            txtkode.Clear()
            txtstock.Clear()
            nudqty.Value = 0
            nudqty.Enabled = False
            cmbunit.Enabled = False
            txtharga.Clear()
            nudharga.Value = 0
            nudharga.Enabled = False
            dgvjual.Rows.Clear()
            nuddisc.Value = 0
            nuddisc.Enabled = False
            nudbayar.Enabled = False
            txttotal.Clear()
            txtkembali.Clear()
            txtgrand.Clear()
            btncetak.Enabled = True
            cbmulti.Enabled = False
            cbmulti.Checked = False
            txtremark.Clear()
            txtremark.Enabled = False
            txtkepada.Enabled = False
        End If
    End Sub

    Private Sub txttotal_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txttotal.TextChanged
        If txttotal.Text = "" Then Exit Sub
        _koma = txttotal.Text
        txttotal.Text = Format(_koma, "#,##0.00")
        txttotal.SelectionStart = Len(txttotal.Text)
    End Sub

    Private Sub txtgrand_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtgrand.TextChanged
        If txtgrand.Text = "" Then Exit Sub
        _koma = txtgrand.Text
        txtgrand.Text = Format(_koma, "#,##0.00")
        txtgrand.SelectionStart = Len(txtgrand.Text)
    End Sub

    Private Sub txtkembali_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtkembali.TextChanged
        If txtkembali.Text = "" Then Exit Sub
        _koma = txtkembali.Text
        txtkembali.Text = Format(_koma, "#,##0.00")
        txtkembali.SelectionStart = Len(txtkembali.Text)
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
            ErrorProvider1.SetError(cmbunit, "Harus diisi")
        Else
            ErrorProvider1.Clear()
        End If
    End Sub

    Private Sub cmbunit_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbunit.Validating
        If cmbunit.Text = "" Then
            ErrorProvider1.SetError(cmbunit, "Harus diisi")
        Else
            ErrorProvider1.Clear()
        End If
    End Sub

    Private Sub nudharga_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles nudharga.Validating
        If nudharga.Enabled = True Then
            If nudharga.Value = 0 Then
                ErrorProvider1.SetError(nudharga, "Harus diisi")
            Else
                ErrorProvider1.Clear()
            End If
        End If
    End Sub

    Private Sub btncetak_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btncetak.Click
        System.Windows.Forms.Cursor.Current = Cursors.WaitCursor
        Dim f As New forminvoice
        f.user = user
        f.pass = pass
        f.iduser = iduser
        f.no = txtno.Text
        f.tunai = nudbayar.Value
        f.kepada = txtkepada.Text
        f.ShowDialog()
    End Sub

    Private Sub cbmulti_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbmulti.CheckedChanged
        If cbmulti.Checked = True Then
            cmbitem.Enabled = False
            txtremark.Enabled = True
            nudharga.Enabled = True
            btnubah.Text = "Cancel"
            Dim f As New multiitem
            f.idakses = idakses
            f.user = user
            f.pass = pass
            f.iduser = iduser
            f.no = txtno.Text
            f.ShowDialog()
            If f.DialogResult = Windows.Forms.DialogResult.OK Then
                cmbunit.Text = "Pcs"
                cbmulti.Enabled = False
                _masteritem1 = _mySrv.Ambilkodeharga(_secure, f.cmbitem1.Text)
                If _masteritem1.Length = 0 Then Exit Sub
                _idmulti = Guid.NewGuid
                If f.txtkode1.Text <> "" Then
                    dgvjual.Rows.Add(1)
                    dgvjual.Rows(dgvjual.RowCount - 1).Cells(0).Value = "-"
                    dgvjual.Rows(dgvjual.RowCount - 1).Cells(1).Value = txttanggal.Text
                    dgvjual.Rows(dgvjual.RowCount - 1).Cells(2).Value = f.txtkode1.Text
                    dgvjual.Rows(dgvjual.RowCount - 1).Cells(3).Value = f.cmbitem1.Text
                    dgvjual.Rows(dgvjual.RowCount - 1).Cells(4).Value = f.nudqty1.Value
                    dgvjual.Rows(dgvjual.RowCount - 1).Cells(5).Value = "Pcs"
                    dgvjual.Rows(dgvjual.RowCount - 1).Cells(6).Value = _masteritem1(0).hargaperpcs
                    dgvjual.Rows(dgvjual.RowCount - 1).Cells(7).Value = f.nudqty1.Value * _masteritem1(0).hargaperpcs
                    dgvjual.Rows(dgvjual.RowCount - 1).Cells(8).Value = f.nudqty1.Value
                    dgvjual.Rows(dgvjual.RowCount - 1).Cells(9).Value = "multi"
                    dgvjual.Rows(dgvjual.RowCount - 1).Cells(10).Value = "-"
                    dgvjual.Rows(dgvjual.RowCount - 1).Cells(11).Value = _idmulti
                    dgvjual.Update()
                End If
                _masteritem2 = _mySrv.Ambilkodeharga(_secure, f.cmbitem2.Text)
                If _masteritem2.Length = 0 Then Exit Sub
                If f.txtkode2.Text <> "" Then
                    dgvjual.Rows.Add(1)
                    dgvjual.Rows(dgvjual.RowCount - 1).Cells(0).Value = "-"
                    dgvjual.Rows(dgvjual.RowCount - 1).Cells(1).Value = txttanggal.Text
                    dgvjual.Rows(dgvjual.RowCount - 1).Cells(2).Value = f.txtkode2.Text
                    dgvjual.Rows(dgvjual.RowCount - 1).Cells(3).Value = f.cmbitem2.Text
                    dgvjual.Rows(dgvjual.RowCount - 1).Cells(4).Value = f.nudqty2.Value
                    dgvjual.Rows(dgvjual.RowCount - 1).Cells(5).Value = "Pcs"
                    dgvjual.Rows(dgvjual.RowCount - 1).Cells(6).Value = _masteritem2(0).hargaperpcs
                    dgvjual.Rows(dgvjual.RowCount - 1).Cells(7).Value = f.nudqty2.Value * _masteritem2(0).hargaperpcs
                    dgvjual.Rows(dgvjual.RowCount - 1).Cells(8).Value = f.nudqty2.Value
                    dgvjual.Rows(dgvjual.RowCount - 1).Cells(9).Value = "multi"
                    dgvjual.Rows(dgvjual.RowCount - 1).Cells(10).Value = "-"
                    dgvjual.Rows(dgvjual.RowCount - 1).Cells(11).Value = _idmulti
                    dgvjual.Update()
                End If
                _masteritem3 = _mySrv.Ambilkodeharga(_secure, f.cmbitem3.Text)
                If _masteritem3.Length = 0 Then Exit Sub
                If f.txtkode3.Text <> "" Then
                    dgvjual.Rows.Add(1)
                    dgvjual.Rows(dgvjual.RowCount - 1).Cells(0).Value = "-"
                    dgvjual.Rows(dgvjual.RowCount - 1).Cells(1).Value = txttanggal.Text
                    dgvjual.Rows(dgvjual.RowCount - 1).Cells(2).Value = f.txtkode3.Text
                    dgvjual.Rows(dgvjual.RowCount - 1).Cells(3).Value = f.cmbitem3.Text
                    dgvjual.Rows(dgvjual.RowCount - 1).Cells(4).Value = f.nudqty3.Value
                    dgvjual.Rows(dgvjual.RowCount - 1).Cells(5).Value = "Pcs"
                    dgvjual.Rows(dgvjual.RowCount - 1).Cells(6).Value = _masteritem3(0).hargaperpcs
                    dgvjual.Rows(dgvjual.RowCount - 1).Cells(7).Value = f.nudqty3.Value * _masteritem3(0).hargaperpcs
                    dgvjual.Rows(dgvjual.RowCount - 1).Cells(8).Value = f.nudqty3.Value
                    dgvjual.Rows(dgvjual.RowCount - 1).Cells(9).Value = "multi"
                    dgvjual.Rows(dgvjual.RowCount - 1).Cells(10).Value = "-"
                    dgvjual.Rows(dgvjual.RowCount - 1).Cells(11).Value = _idmulti
                    dgvjual.Update()
                End If
                _masteritem4 = _mySrv.Ambilkodeharga(_secure, f.cmbitem4.Text)
                If _masteritem4.Length = 0 Then Exit Sub
                If f.txtkode4.Text <> "" Then
                    dgvjual.Rows.Add(1)
                    dgvjual.Rows(dgvjual.RowCount - 1).Cells(0).Value = "-"
                    dgvjual.Rows(dgvjual.RowCount - 1).Cells(1).Value = txttanggal.Text
                    dgvjual.Rows(dgvjual.RowCount - 1).Cells(2).Value = f.txtkode4.Text
                    dgvjual.Rows(dgvjual.RowCount - 1).Cells(3).Value = f.cmbitem4.Text
                    dgvjual.Rows(dgvjual.RowCount - 1).Cells(4).Value = f.nudqty4.Value
                    dgvjual.Rows(dgvjual.RowCount - 1).Cells(5).Value = "Pcs"
                    dgvjual.Rows(dgvjual.RowCount - 1).Cells(6).Value = _masteritem4(0).hargaperpcs
                    dgvjual.Rows(dgvjual.RowCount - 1).Cells(7).Value = f.nudqty4.Value * _masteritem4(0).hargaperpcs
                    dgvjual.Rows(dgvjual.RowCount - 1).Cells(8).Value = f.nudqty4.Value
                    dgvjual.Rows(dgvjual.RowCount - 1).Cells(9).Value = "multi"
                    dgvjual.Rows(dgvjual.RowCount - 1).Cells(10).Value = "-"
                    dgvjual.Rows(dgvjual.RowCount - 1).Cells(11).Value = _idmulti
                    dgvjual.Update()
                End If
                _masteritem5 = _mySrv.Ambilkodeharga(_secure, f.cmbitem5.Text)
                If _masteritem5.Length = 0 Then Exit Sub
                If f.txtkode5.Text <> "" Then
                    dgvjual.Rows.Add(1)
                    dgvjual.Rows(dgvjual.RowCount - 1).Cells(0).Value = "-"
                    dgvjual.Rows(dgvjual.RowCount - 1).Cells(1).Value = txttanggal.Text
                    dgvjual.Rows(dgvjual.RowCount - 1).Cells(2).Value = f.txtkode5.Text
                    dgvjual.Rows(dgvjual.RowCount - 1).Cells(3).Value = f.cmbitem5.Text
                    dgvjual.Rows(dgvjual.RowCount - 1).Cells(4).Value = f.nudqty5.Value
                    dgvjual.Rows(dgvjual.RowCount - 1).Cells(5).Value = "Pcs"
                    dgvjual.Rows(dgvjual.RowCount - 1).Cells(6).Value = _masteritem5(0).hargaperpcs
                    dgvjual.Rows(dgvjual.RowCount - 1).Cells(7).Value = f.nudqty5.Value * _masteritem5(0).hargaperpcs
                    dgvjual.Rows(dgvjual.RowCount - 1).Cells(8).Value = f.nudqty5.Value
                    dgvjual.Rows(dgvjual.RowCount - 1).Cells(9).Value = "multi"
                    dgvjual.Rows(dgvjual.RowCount - 1).Cells(10).Value = "-"
                    dgvjual.Rows(dgvjual.RowCount - 1).Cells(11).Value = _idmulti
                    dgvjual.Update()
                End If
            End If
        End If
    End Sub

    Private Sub LinkLabel1_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        System.Diagnostics.Process.Start("calc.exe")
    End Sub
End Class