Imports x = ProjectKios.ServiceReference1
Public Class masteritem
    Public user As String = ""
    Public pass As String = ""
    Public idakses As Guid
    Private _mySrv As New x.WebService1SoapClient
    Private _secure As New x.AutentikasiUser
    Private _masteritem As x.DataMasterItem()
    Private _isnew As Boolean = True
    Private _pilihan As x.DataMasterItem
    Private _masterkategori As x.DataMasterkategori()
    Private _mastersatuan As x.DataMastersatuan()

    Private Sub getAccessControl()
        _secure.username = user.ToLower
        _secure.password = pass
        If _secure.Username = "" And _secure.Password = "" Then Me.Close()
    End Sub
    Public Sub Fillcmbkategori()
        _masterkategori = _mySrv.AmbilMasterkategori(_secure)
        cmbkat.DataSource = _masterkategori
        cmbkat.DisplayMember = "namakategori"
        cmbkat.ValueMember = "namakategori"
    End Sub
    Public Sub Fillcmbsatuan()
        _mastersatuan = _mySrv.AmbilMastersatuan(_secure)
        cmbsatuan.DataSource = _mastersatuan
        cmbsatuan.DisplayMember = "namasatuan"
        cmbsatuan.ValueMember = "namasatuan"
    End Sub

    Private Sub masteritem_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        getAccessControl()
        refreshdata()
        Fillcmbkategori()
        Fillcmbsatuan()
        cmbkat.SelectedIndex = -1
        cmbsatuan.SelectedIndex = -1
        If dgvitem.RowCount = 0 Then
            btnedit.Enabled = False
            btndelete.Enabled = False
        Else
            btnedit.Enabled = True
            btndelete.Enabled = True
        End If
        System.Windows.Forms.Cursor.Current = Cursors.Default
    End Sub

    Private Sub PictureBox6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox6.Click
        Me.Close()
    End Sub

    Private Sub btnadd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnadd.Click
        txtkode.Enabled = True
        txtkode.Focus()
        cmbkat.Enabled = True
        txtnama.Enabled = True
        nudhargapcs.Enabled = True
        cmbsatuan.Enabled = True
        nudharga.Enabled = True
        btnsave.Enabled = True
        btnedit.Enabled = False
        btndelete.Enabled = False
        btncancel.Enabled = True
        btnadd.Enabled = False
        cmbkat.SelectedIndex = -1
        cmbsatuan.SelectedIndex = -1
    End Sub

    Private Sub btnsave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnsave.Click
        If txtkode.Text = "" Then
            ErrorProvider1.SetError(txtkode, "Harus diisi")
            Exit Sub
        End If
        If txtnama.Text = "" Then
            ErrorProvider1.SetError(txtnama, "Harus diisi")
            Exit Sub
        End If
        If cmbkat.Text = "" Then
            ErrorProvider1.SetError(cmbkat, "Harus diisi")
            Exit Sub
        End If
        If cmbsatuan.Text = "" Then
            ErrorProvider1.SetError(cmbsatuan, "Harus diisi")
            Exit Sub
        End If
        If txtkode.Text.Length > 10 Then
            ErrorProvider1.SetError(txtkode, "Maksimal 10 Karakter")
            Exit Sub
        End If
        Dim cek1 As Boolean = _mySrv.CheckNamaitem1(_secure, txtnama.Text)
        Dim cek0 As Boolean = _mySrv.CheckNamaitem0(_secure, txtnama.Text)
        Dim cekk1 As Boolean = _mySrv.Checkkodeitem1(_secure, txtkode.Text)
        Dim cekk0 As Boolean = _mySrv.Checkkodeitem0(_secure, txtkode.Text)
        If _isnew = True Then
            If cek1 = True Then
                MsgBox("Item Sudah Ada!", MsgBoxStyle.OkOnly, "Information...")
                Exit Sub
            End If
            If cekk1 = True Then
                MsgBox("Kode Sudah Ada!", MsgBoxStyle.OkOnly, "Information...")
                Exit Sub
            End If
            If cek0 = True Then
                Dim respon As MsgBoxResult
                respon = MsgBox("Item Sudah Pernah Dihapus, Ingin Mengaktifkan Kembali?", MsgBoxStyle.YesNo, "Confirmation...")
                If respon = MsgBoxResult.Yes Then
                    _mySrv.UbahStatusitem(_secure, txtnama.Text, user)
                    txtkode.Clear()
                    txtkode.Enabled = False
                    cmbkat.SelectedIndex = -1
                    cmbkat.Enabled = False
                    txtnama.Clear()
                    txtnama.Enabled = False
                    nudhargapcs.Text = 0
                    nudhargapcs.Enabled = False
                    nudharga.Text = 0
                    nudharga.Enabled = False
                    cmbsatuan.SelectedIndex = -1
                    cmbsatuan.Enabled = False
                    btnadd.Enabled = True
                    btnedit.Enabled = True
                    btnsave.Enabled = False
                    btncancel.Enabled = False
                    btndelete.Enabled = True
                    MsgBox("Success!", MsgBoxStyle.OkOnly, "Information...")
                    refreshdata()
                    _isnew = True
                    Exit Sub
                Else
                    Exit Sub
                End If
            End If
            If cekk0 = True Then
                Dim respon As MsgBoxResult
                respon = MsgBox("Kode Sudah Pernah Dihapus, Ingin Mengaktifkan Kembali?", MsgBoxStyle.YesNo, "Confirmation...")
                If respon = MsgBoxResult.Yes Then
                    _mySrv.UbahStatusitembyKode(_secure, txtkode.Text, user)
                    txtkode.Clear()
                    txtkode.Enabled = False
                    cmbkat.SelectedIndex = -1
                    cmbkat.Enabled = False
                    txtnama.Clear()
                    txtnama.Enabled = False
                    nudhargapcs.Text = 0
                    nudhargapcs.Enabled = False
                    nudharga.Text = 0
                    nudharga.Enabled = False
                    cmbsatuan.SelectedIndex = -1
                    cmbsatuan.Enabled = False
                    btnadd.Enabled = True
                    btnedit.Enabled = True
                    btnsave.Enabled = False
                    btncancel.Enabled = False
                    btndelete.Enabled = True
                    MsgBox("Success!", MsgBoxStyle.OkOnly, "Information...")
                    refreshdata()
                    _isnew = True
                    Exit Sub
                Else
                    Exit Sub
                End If
            End If
        Else
            If _pilihan.namaitem <> txtnama.Text Then
                If cek1 = True Then
                    MsgBox("Item Sudah Ada!", MsgBoxStyle.OkOnly, "Information...")
                    Exit Sub
                End If
                If cekk1 = True Then
                    MsgBox("Kode Sudah Ada!", MsgBoxStyle.OkOnly, "Information...")
                    Exit Sub
                End If
                If cek0 = True Then
                    Dim respon As MsgBoxResult
                    respon = MsgBox("Item Sudah Pernah Dihapus, Ingin Mengaktifkan Kembali?", MsgBoxStyle.YesNo, "Confirmation...")
                    If respon = MsgBoxResult.Yes Then
                        _mySrv.UbahStatusitem(_secure, txtnama.Text, user)
                        txtkode.Clear()
                        txtkode.Enabled = False
                        cmbkat.SelectedIndex = -1
                        cmbkat.Enabled = False
                        txtnama.Clear()
                        txtnama.Enabled = False
                        nudhargapcs.Text = 0
                        nudhargapcs.Enabled = False
                        nudharga.Text = 0
                        nudharga.Enabled = False
                        cmbsatuan.SelectedIndex = -1
                        cmbsatuan.Enabled = False
                        btnadd.Enabled = True
                        btnedit.Enabled = True
                        btnsave.Enabled = False
                        btncancel.Enabled = False
                        btndelete.Enabled = True
                        MsgBox("Success!", MsgBoxStyle.OkOnly, "Information...")
                        refreshdata()
                        _isnew = True
                        Exit Sub
                    Else
                        Exit Sub
                    End If
                End If
                If cekk0 = True Then
                    Dim respon As MsgBoxResult
                    respon = MsgBox("Kode Sudah Pernah Dihapus, Ingin Mengaktifkan Kembali?", MsgBoxStyle.YesNo, "Confirmation...")
                    If respon = MsgBoxResult.Yes Then
                        _mySrv.UbahStatusitembyKode(_secure, txtkode.Text, user)
                        txtkode.Clear()
                        txtkode.Enabled = False
                        cmbkat.SelectedIndex = -1
                        cmbkat.Enabled = False
                        txtnama.Clear()
                        txtnama.Enabled = False
                        nudhargapcs.Text = 0
                        nudhargapcs.Enabled = False
                        nudharga.Text = 0
                        nudharga.Enabled = False
                        cmbsatuan.SelectedIndex = -1
                        cmbsatuan.Enabled = False
                        btnadd.Enabled = True
                        btnedit.Enabled = True
                        btnsave.Enabled = False
                        btncancel.Enabled = False
                        btndelete.Enabled = True
                        MsgBox("Success!", MsgBoxStyle.OkOnly, "Information...")
                        refreshdata()
                        _isnew = True
                        Exit Sub
                    Else
                        Exit Sub
                    End If
                End If
            End If
        End If
        _masterkategori = _mySrv.AmbilIDMasterkategori(_secure, cmbkat.Text)
        _mastersatuan = _mySrv.AmbilIDMastersatuan(_secure, cmbsatuan.Text)
        Dim idkategori As Guid = _masterkategori(0).idkategori
        Dim idsatuan As Guid = _mastersatuan(0).idsatuan
        If _isnew = True Then
            _mySrv.TambahItem(_secure, idkategori, txtkode.Text, txtnama.Text, nudhargapcs.Text, nudharga.Text, idsatuan, user)
            txtkode.Clear()
            txtkode.Enabled = False
            cmbkat.SelectedIndex = -1
            cmbkat.Enabled = False
            txtnama.Clear()
            txtnama.Enabled = False
            nudhargapcs.Text = 0
            nudhargapcs.Enabled = False
            nudharga.Text = 0
            nudharga.Enabled = False
            cmbsatuan.SelectedIndex = -1
            cmbsatuan.Enabled = False
            btnadd.Enabled = True
            btnedit.Enabled = True
            btnsave.Enabled = False
            btncancel.Enabled = False
            btndelete.Enabled = True
        Else
            _mySrv.UbahItem(_secure, idkategori, txtkode.Text, txtnama.Text, nudhargapcs.Text, nudharga.Text, idsatuan, user, _pilihan.iditem)
            txtkode.Clear()
            txtkode.Enabled = False
            cmbkat.SelectedIndex = -1
            cmbkat.Enabled = False
            txtnama.Clear()
            txtnama.Enabled = False
            nudhargapcs.Text = 0
            nudhargapcs.Enabled = False
            nudharga.Text = 0
            nudharga.Enabled = False
            cmbsatuan.SelectedIndex = -1
            cmbsatuan.Enabled = False
            btnadd.Enabled = True
            btnedit.Enabled = True
            btnsave.Enabled = False
            btncancel.Enabled = False
            btndelete.Enabled = True
        End If
        MsgBox("Success!", MsgBoxStyle.OkOnly, "Information...")
        refreshdata()
        _isnew = True
    End Sub

    Private Sub btndelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btndelete.Click
        If dgvitem.SelectedRows.Count = 0 Then Exit Sub
        _pilihan = dgvitem.SelectedRows(0).DataBoundItem
        Dim cek As Boolean = _mySrv.Checkitem(_secure, _pilihan.iditem)
        If cek = True Then
            MsgBox("Item Sudah digunakan, tidak bisa dihapus!", MsgBoxStyle.OkOnly, "Information...")
            Exit Sub
        Else
            Dim respon As MsgBoxResult
            respon = MsgBox("Yakin Ingin Menghapus Data Ini?", MsgBoxStyle.YesNo, "Konfirmasi")
            If respon = MsgBoxResult.Yes Then
                _pilihan = dgvitem.SelectedRows(0).DataBoundItem
                _mySrv.HapusItem(_secure, _pilihan.iditem)
                txtkode.Clear()
                txtkode.Enabled = False
                cmbkat.SelectedIndex = -1
                cmbkat.Enabled = False
                txtnama.Clear()
                txtnama.Enabled = False
                nudhargapcs.Text = 0
                nudhargapcs.Enabled = False
                nudharga.Text = 0
                nudharga.Enabled = False
                cmbsatuan.SelectedIndex = -1
                cmbsatuan.Enabled = False
                btnadd.Enabled = True
                btnedit.Enabled = True
                btncancel.Enabled = False
                MsgBox("Success!", MsgBoxStyle.OkOnly, "Information...")
                refreshdata()
                If dgvitem.SelectedRows.Count = 0 Then
                    btnedit.Enabled = False
                    btndelete.Enabled = False
                Else
                    btnedit.Enabled = True
                    btndelete.Enabled = True
                End If
            End If
        End If
    End Sub

    Private Sub dgvitem_CellFormatting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles dgvitem.CellFormatting
        dgvitem.Rows(e.RowIndex).HeaderCell.Value = CStr(e.RowIndex + 1)
    End Sub

    Private Sub btnedit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnedit.Click
        If dgvitem.SelectedRows.Count = 0 Then Exit Sub
        txtkode.Enabled = True
        cmbkat.Enabled = True
        txtnama.Enabled = True
        nudhargapcs.Enabled = True
        nudharga.Enabled = True
        cmbsatuan.Enabled = True
        _pilihan = dgvitem.SelectedRows(0).DataBoundItem
        txtkode.Text = _pilihan.kodeitem
        cmbkat.SelectedValue = _pilihan.namakategori
        txtnama.Text = _pilihan.namaitem
        nudhargapcs.Text = _pilihan.hargaperpcs
        nudhargapcs.Text = _pilihan.harga
        cmbsatuan.SelectedValue = _pilihan.namasatuan
        btnadd.Enabled = False
        btnsave.Enabled = True
        btncancel.Enabled = True
        btnedit.Enabled = False
        btndelete.Enabled = False
        _isnew = False
    End Sub

    Private Sub btncancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btncancel.Click
        ErrorProvider1.Clear()
        txtkode.Clear()
        txtkode.Enabled = False
        cmbkat.SelectedIndex = -1
        cmbkat.Enabled = False
        txtnama.Clear()
        txtnama.Enabled = False
        nudhargapcs.Text = 0
        nudhargapcs.Enabled = False
        nudharga.Text = 0
        nudharga.Enabled = False
        cmbsatuan.SelectedIndex = -1
        cmbsatuan.Enabled = False
        btnadd.Enabled = True
        btnedit.Enabled = True
        btncancel.Enabled = False
        btnsave.Enabled = False
        btndelete.Enabled = True
    End Sub

    Private Sub refreshdata()
        _masteritem = _mySrv.AmbilMasterItem(_secure)
        dgvitem.DataSource = _masteritem
    End Sub

    Private Sub txtnama_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtnama.Validating
        If txtnama.Text = "" Then
            ErrorProvider1.SetError(txtnama, "Harus diisi")
        Else
            ErrorProvider1.Clear()
        End If
    End Sub

    Private Sub btncari_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btncari.Click
        _masteritem = _mySrv.Searchitem(_secure, txtcari.Text)
        dgvitem.DataSource = _masteritem
    End Sub

    Private Sub cmbkat_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbkat.Validating
        If cmbkat.Text = "" Then
            ErrorProvider1.SetError(cmbkat, "Harus diisi")
        Else
            ErrorProvider1.Clear()
        End If
    End Sub

    Private Sub cmbsatuan_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbsatuan.Validating
        If cmbsatuan.Text = "" Then
            ErrorProvider1.SetError(cmbsatuan, "Harus diisi")
        Else
            ErrorProvider1.Clear()
        End If
    End Sub

    Private Sub txtkode_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtkode.Validating
        If txtkode.Text = "" Then
            ErrorProvider1.SetError(txtkode, "Harus diisi")
        Else
            ErrorProvider1.Clear()
        End If
    End Sub

End Class