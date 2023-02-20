Imports x = ProjectKios.ServiceReference1
Public Class pembelian
    Public user As String = ""
    Public pass As String = ""
    Public iduser As Guid
    Public idakses As Guid
    Private _mySrv As New x.WebService1SoapClient
    Private _secure As New x.AutentikasiUser
    Private _listitem As x.ListDataItem()
    Private _listsupplier As x.ListDataSupplier()
    Private _listsatuan As x.ListDatasatuan()
    Private _listUrutan As x.ListDataUrutan()
    Private _masteritem As x.datakodeharga()
    Private _konv As x.datakonvpcs()
    Private _iditem As x.DataMasterItem()
    Private _idsupplier As x.DataMastersupplier()
    Private _idsatuan As x.DataMastersatuan()
    Private _urut As String
    Private _datastock As x.ListDataStock()
    Private _koma As Long

    Private Sub getAccessControl()
        _secure.username = user.ToLower
        _secure.password = pass
        If _secure.Username = "" And _secure.Password = "" Then Me.Close()
    End Sub
    Public Sub Fillcmbitem()
        _listitem = _mySrv.AmbilListItemBeli(_secure)
        cmbitem.DataSource = _listitem
        cmbitem.DisplayMember = "namaitem"
        cmbitem.ValueMember = "namaitem"
    End Sub
    Public Sub Fillcmbsupplier()
        _listsupplier = _mySrv.AmbilListSupplier(_secure)
        cmbsupplier.DataSource = _listsupplier
        cmbsupplier.DisplayMember = "namasupplier"
        cmbsupplier.ValueMember = "namasupplier"
    End Sub
    Public Sub Fillcmbsatuan()
        _listsatuan = _mySrv.AmbilListSatuan(_secure)
        cmbunit.DataSource = _listsatuan
        cmbunit.DisplayMember = "namasatuan"
        cmbunit.ValueMember = "namasatuan"
    End Sub
    Private Sub PictureBox6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox6.Click
        Close()
    End Sub
    Private Sub pembelian_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        getAccessControl()
        Fillcmbitem()
        Fillcmbsatuan()
        Fillcmbsupplier()
        cmbitem.SelectedIndex = -1
        cmbsupplier.SelectedIndex = -1
        cmbunit.SelectedIndex = -1
        System.Windows.Forms.Cursor.Current = Cursors.Default
    End Sub

    Private Sub btnadd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnadd.Click
        btncancel.Enabled = True
        btninsert.Enabled = True
        btnubah.Enabled = True
        btnsave.Enabled = True
        btnadd.Enabled = False
        cmbitem.Enabled = True
        cmbsupplier.Enabled = True
        cmbunit.Enabled = True
        nudhabel.Enabled = True
        nudqty.Enabled = True
        txttanggal.Text = Format(Date.Now, "dd MMM yyyy ss:mm:dd")
    End Sub

    Private Sub btncancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btncancel.Click
        btncancel.Enabled = False
        btnsave.Enabled = False
        btnadd.Enabled = True
        btnubah.Enabled = False
        btninsert.Enabled = False
        cmbitem.Enabled = False
        cmbsupplier.Enabled = False
        cmbunit.Enabled = False
        nudhabel.Enabled = False
        nudqty.Enabled = False
        nudhaju.Enabled = False
        nudhajupcs.Enabled = False
        txttanggal.Clear()
        txtno.Clear()
        cmbitem.SelectedIndex = -1
        cmbsupplier.SelectedIndex = -1
        cmbunit.SelectedIndex = -1
        txtkode.Clear()
        nudqty.Value = 0
        nudhabel.Value = 0
        txthabelpcs.Clear()
        txthabelsat.Clear()
        txthaju.Clear()
        txthajupcs.Clear()
        dgvbeli.Rows.Clear()
        nudhaju.Value = 0
        nudhajupcs.Value = 0
        ErrorProvider1.Clear()
    End Sub

    Private Sub cmbitem_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbitem.SelectedIndexChanged
        If cmbitem.Enabled = False Then Exit Sub
        _masteritem = _mySrv.Ambilkodeharga(_secure, cmbitem.Text)
        If _masteritem.Length = 0 Then Exit Sub
        txtkode.Text = _masteritem(0).kodeitem
        txthaju.Text = _masteritem(0).harga
        txthajupcs.Text = _masteritem(0).hargaperpcs
    End Sub

    Private Sub btnubah_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnubah.Click
        If btnubah.Text = "UBAH" Then
            nudhaju.Enabled = True
            nudhajupcs.Enabled = True
            btnubah.Text = "Cancel"
        Else
            nudhaju.Enabled = False
            nudhajupcs.Enabled = False
            btnubah.Text = "UBAH"
        End If
        ErrorProvider1.Clear()
    End Sub

    Private Sub btninsert_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btninsert.Click
        If cmbitem.Text = "" Or cmbsupplier.Text = "" Or cmbunit.Text = "" Or nudqty.Value = 0 Or nudhabel.Value = 0 Then
            MsgBox("Data Belum Lengkap!")
            Exit Sub
        End If
        If nudhaju.Enabled = True Then
            If nudhaju.Value = 0 Or nudhajupcs.Value = 0 Then
                MsgBox("Data Belum Lengkap!")
                Exit Sub
            End If
        End If
        Dim haju As Decimal
        Dim hajupcs As Decimal
        If nudhaju.Enabled = True Then
            haju = nudhaju.Value
            hajupcs = nudhajupcs.Value
        Else
            haju = txthaju.Text
            hajupcs = txthajupcs.Text
        End If
        dgvbeli.Rows.Add(1)
        dgvbeli.Rows(dgvbeli.RowCount - 1).Cells(0).Value = txtno.Text
        dgvbeli.Rows(dgvbeli.RowCount - 1).Cells(1).Value = txtkode.Text
        dgvbeli.Rows(dgvbeli.RowCount - 1).Cells(2).Value = cmbitem.Text
        dgvbeli.Rows(dgvbeli.RowCount - 1).Cells(3).Value = cmbsupplier.Text
        dgvbeli.Rows(dgvbeli.RowCount - 1).Cells(4).Value = nudqty.Value
        dgvbeli.Rows(dgvbeli.RowCount - 1).Cells(5).Value = cmbunit.Text
        dgvbeli.Rows(dgvbeli.RowCount - 1).Cells(6).Value = txthabelsat.Text
        dgvbeli.Rows(dgvbeli.RowCount - 1).Cells(7).Value = txthabelpcs.Text
        dgvbeli.Rows(dgvbeli.RowCount - 1).Cells(8).Value = haju
        dgvbeli.Rows(dgvbeli.RowCount - 1).Cells(9).Value = hajupcs
        dgvbeli.Rows(dgvbeli.RowCount - 1).Cells(10).Value = txttanggal.Text
        dgvbeli.Rows(dgvbeli.RowCount - 1).Cells(11).Value = _konv(0).konvpcs * nudqty.Value
        dgvbeli.Update()
        btnubah.Text = "UBAH"
        cmbitem.SelectedIndex = -1
        cmbsupplier.SelectedIndex = -1
        cmbunit.SelectedIndex = -1
        txtkode.Clear()
        nudqty.Value = 0
        nudhabel.Value = 0
        txthabelpcs.Clear()
        txthabelsat.Clear()
        txthaju.Clear()
        txthajupcs.Clear()
        nudhaju.Value = 0
        nudhajupcs.Value = 0
        nudhaju.Enabled = False
        nudhajupcs.Enabled = False
        ErrorProvider1.Clear()
    End Sub

    Private Sub nudhabel_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles nudhabel.KeyPress
        If e.KeyChar = Convert.ToChar(13) Then
            If cmbunit.Text = "" Then
                MsgBox("Pilih Satuan Dahulu!")
                Exit Sub
            End If
            txthabelsat.Text = nudhabel.Value / nudqty.Value
            _konv = _mySrv.Ambilkonvpcs(_secure, cmbunit.Text)
            txthabelpcs.Text = nudhabel.Value / (nudqty.Value * _konv(0).konvpcs)
        End If
    End Sub

    Private Sub dgvbeli_CellFormatting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles dgvbeli.CellFormatting
        dgvbeli.Rows(e.RowIndex).HeaderCell.Value = CStr(e.RowIndex + 1)
    End Sub

    Private Sub DeleteToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteToolStripMenuItem.Click
        Dim i As Integer = dgvbeli.SelectedRows(0).Index
        dgvbeli.Rows.RemoveAt(i)
    End Sub

    Private Sub btnsave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnsave.Click
        Try
            _listUrutan = _mySrv.AmbilListUratan(_secure, Format(Date.Now, "yyyy"))
            If _listUrutan.Length = 0 Then
                txtno.Text = "BE-" & Format(Date.Now, "yyyy") & "-0000001"
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
                txtno.Text = "BE-" & Format(Date.Now, "yyyy") & "-" & _urut & _listUrutan(0).urut
            End If
            For i As Integer = 0 To dgvbeli.Rows.Count - 1
                Dim namaitem As String = dgvbeli.Rows(i).Cells(2).Value
                Dim namasupplier As String = dgvbeli.Rows(i).Cells(3).Value
                Dim no As String = txtno.Text
                Dim qty As Decimal = dgvbeli.Rows(i).Cells(4).Value
                Dim habelpcs As Decimal = dgvbeli.Rows(i).Cells(7).Value
                Dim habel As Decimal = dgvbeli.Rows(i).Cells(6).Value
                Dim namasatuan As String = dgvbeli.Rows(i).Cells(5).Value
                Dim haju As Decimal = dgvbeli.Rows(i).Cells(8).Value
                Dim hajupcs As String = dgvbeli.Rows(i).Cells(9).Value
                Dim qtykonv As String = dgvbeli.Rows(i).Cells(11).Value
                _iditem = _mySrv.AmbilIDMasterItem(_secure, namaitem)
                _idsupplier = _mySrv.AmbilIDMastersupplier(_secure, namasupplier)
                _idsatuan = _mySrv.AmbilIDMastersatuan(_secure, namasatuan)
                _mySrv.TambahBeli(_secure, _iditem(0).iditem, _idsupplier(0).idsupplier, iduser, no, DateTime.Now, qty, habelpcs, habel, _idsatuan(0).idsatuan, user)
                Dim cek As Boolean = _mySrv.CekStock(_secure, _iditem(0).iditem)
                If cek = True Then
                    _datastock = _mySrv.AmbilDataStock(_secure, _iditem(0).iditem)
                    _mySrv.UpdateStock(_secure, _datastock(0).jumlahstock + qtykonv, user, _iditem(0).iditem)
                Else
                    _mySrv.TambahStock(_secure, _iditem(0).iditem, qtykonv, user)
                End If
                _mySrv.UpdateHargaItem(_secure, _iditem(0).iditem, hajupcs, haju, _idsatuan(0).idsatuan, user)
            Next
            If _listUrutan.Length = 0 Then
                _mySrv.TambahUrutan(_secure, Format(Date.Now, "yyyy"), 2)
            Else
                _mySrv.UpdateUrutan(_secure, Format(Date.Now, "yyyy"), _listUrutan(0).urut + 1)
            End If
            MsgBox("Success! No Pembelian : " & txtno.Text, MsgBoxStyle.OkOnly, "Information...")
            btncancel.Enabled = False
            btnsave.Enabled = False
            btnadd.Enabled = True
            btnubah.Enabled = False
            btnubah.Text = "UBAH"
            btninsert.Enabled = False
            cmbitem.Enabled = False
            cmbsupplier.Enabled = False
            cmbunit.Enabled = False
            nudhabel.Enabled = False
            nudqty.Enabled = False
            nudhaju.Enabled = False
            nudhajupcs.Enabled = False
            txttanggal.Clear()
            txtno.Clear()
            cmbitem.SelectedIndex = -1
            cmbsupplier.SelectedIndex = -1
            cmbunit.SelectedIndex = -1
            txtkode.Clear()
            nudqty.Value = 0
            nudhabel.Value = 0
            txthabelpcs.Clear()
            txthabelsat.Clear()
            txthaju.Clear()
            txthajupcs.Clear()
            dgvbeli.Rows.Clear()
            nudhaju.Value = 0
            nudhajupcs.Value = 0
            ErrorProvider1.Clear()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub cmbitem_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbitem.Validating
        If cmbitem.Text = "" Then
            ErrorProvider1.SetError(cmbitem, "Harus diisi")
        Else
            ErrorProvider1.Clear()
        End If
    End Sub

    Private Sub cmbsupplier_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbsupplier.Validating
        If cmbsupplier.Text = "" Then
            ErrorProvider1.SetError(cmbsupplier, "Harus diisi")
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

    Private Sub nudhabel_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles nudhabel.Validating
        If nudhabel.Value = 0 Then
            ErrorProvider1.SetError(txthabelpcs, "Harus diisi")
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

    Private Sub nudhajupcs_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles nudhajupcs.Validating
        If nudhajupcs.Enabled = True Then
            If nudhajupcs.Value = 0 Then
                ErrorProvider1.SetError(nudhajupcs, "Harus diisi")
            Else
                ErrorProvider1.Clear()
            End If
        End If
    End Sub

    Private Sub nudhaju_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles nudhaju.Validating
        If nudhaju.Enabled = True Then
            If nudhaju.Value = 0 Then
                ErrorProvider1.SetError(nudhaju, "Harus diisi")
            Else
                ErrorProvider1.Clear()
            End If
        End If
    End Sub

    Private Sub EditQtyToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EditQtyToolStripMenuItem.Click
        Dim editqty As String
        editqty = InputBox("Masukkan Qty Baru", "Edit Qty")
        Dim i As Integer = dgvbeli.SelectedRows(0).Index
        dgvbeli.Rows(i).Cells(4).Value = editqty
        _konv = _mySrv.Ambilkonvpcs(_secure, dgvbeli.Rows(i).Cells(5).Value)
        dgvbeli.Rows(i).Cells(11).Value = _konv(0).konvpcs * editqty
    End Sub

    Private Sub txthabelsat_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txthabelsat.TextChanged
        If txthabelsat.Text = "" Then Exit Sub
        _koma = txthabelsat.Text
        txthabelsat.Text = Format(_koma, "#,##0.00")
        txthabelsat.SelectionStart = Len(txthabelsat.Text)
    End Sub

    Private Sub txthabelpcs_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txthabelpcs.TextChanged
        If txthabelpcs.Text = "" Then Exit Sub
        _koma = txthabelpcs.Text
        txthabelpcs.Text = Format(_koma, "#,##0.00")
        txthabelpcs.SelectionStart = Len(txthabelpcs.Text)
    End Sub

    Private Sub txthajupcs_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txthajupcs.TextChanged
        If txthajupcs.Text = "" Then Exit Sub
        _koma = txthajupcs.Text
        txthajupcs.Text = Format(_koma, "#,##0.00")
        txthajupcs.SelectionStart = Len(txthajupcs.Text)
    End Sub

    Private Sub txthaju_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txthaju.TextChanged
        If txthaju.Text = "" Then Exit Sub
        _koma = txthaju.Text
        txthaju.Text = Format(_koma, "#,##0.00")
        txthaju.SelectionStart = Len(txthaju.Text)
    End Sub

    Private Sub LinkLabel1_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        System.Diagnostics.Process.Start("calc.exe")
    End Sub
End Class