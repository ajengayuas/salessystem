Imports x = ProjectKios.ServiceReference1
Public Class mastersupplier
    Public user As String = ""
    Public pass As String = ""
    Public idakses As Guid
    Private _mySrv As New x.WebService1SoapClient
    Private _secure As New x.AutentikasiUser
    Private _mastersupplier As x.DataMastersupplier()
    Private _isnew As Boolean = True
    Private _pilihan As x.DataMastersupplier

    Private Sub getAccessControl()
        _secure.username = user.ToLower
        _secure.password = pass
        If _secure.Username = "" And _secure.Password = "" Then Me.Close()
    End Sub

    Private Sub mastersupplier_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        getAccessControl()
        refreshdata()
        If dgvsup.RowCount = 0 Then
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
        txtsup.Enabled = True
        txtsup.Focus()
        txtal.Enabled = True
        txtno.Enabled = True
        btnsave.Enabled = True
        btnedit.Enabled = False
        btndelete.Enabled = False
        btncancel.Enabled = True
        btnadd.Enabled = False
    End Sub

    Private Sub btnsave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnsave.Click
        If txtsup.Text = "" Then
            ErrorProvider1.SetError(txtsup, "Harus diisi")
            Exit Sub
        End If
        Dim cek1 As Boolean = _mySrv.CheckNamasupplier1(_secure, txtsup.Text)
        Dim cek0 As Boolean = _mySrv.CheckNamasupplier0(_secure, txtsup.Text)
        If _isnew = True Then
            If cek1 = True Then
                MsgBox("Supplier Sudah Ada!", MsgBoxStyle.OkOnly, "Information...")
                Exit Sub
            End If
            If cek0 = True Then
                Dim respon As MsgBoxResult
                respon = MsgBox("Supplier Sudah Pernah Dihapus, Ingin Mengaktifkan Kembali?", MsgBoxStyle.YesNo, "Confirmation...")
                If respon = MsgBoxResult.Yes Then
                    _mySrv.UbahStatussupplier(_secure, txtsup.Text, user)
                    txtsup.Clear()
                    txtsup.Enabled = False
                    txtal.Clear()
                    txtal.Enabled = False
                    txtno.Clear()
                    txtno.Enabled = False
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
            _mySrv.Tambahsupplier(_secure, txtsup.Text, txtal.Text, txtno.Text, user)
            txtsup.Clear()
            txtsup.Enabled = False
            txtal.Clear()
            txtal.Enabled = False
            txtno.Clear()
            txtno.Enabled = False
            btnadd.Enabled = True
            btnedit.Enabled = True
            btnsave.Enabled = False
            btncancel.Enabled = False
            btndelete.Enabled = True
        Else
            If _pilihan.namasupplier <> txtsup.Text Then
                If cek1 = True Then
                    MsgBox("Supplier Sudah Ada!", MsgBoxStyle.OkOnly, "Information...")
                    Exit Sub
                End If
                If cek0 = True Then
                    Dim respon As MsgBoxResult
                    respon = MsgBox("Supplier Sudah Pernah Dihapus, Ingin Mengaktifkan Kembali?", MsgBoxStyle.YesNo, "Confirmation...")
                    If respon = MsgBoxResult.Yes Then
                        _mySrv.UbahStatussupplier(_secure, txtsup.Text, user)
                        txtsup.Clear()
                        txtsup.Enabled = False
                        txtal.Clear()
                        txtal.Enabled = False
                        txtno.Clear()
                        txtno.Enabled = False
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
            _mySrv.Ubahsupplier(_secure, _pilihan.idsupplier, txtsup.Text, txtal.Text, txtno.Text, user)
            txtsup.Clear()
            txtsup.Enabled = False
            txtal.Clear()
            txtal.Enabled = False
            txtno.Clear()
            txtno.Enabled = False
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
        If dgvsup.SelectedRows.Count = 0 Then Exit Sub
        _pilihan = dgvsup.SelectedRows(0).DataBoundItem
        Dim cek As Boolean = _mySrv.CheckSupplier(_secure, _pilihan.idsupplier)
        If cek = True Then
            MsgBox("Supplier Sudah digunakan, tidak bisa dihapus!", MsgBoxStyle.OkOnly, "Information...")
            Exit Sub
        Else
            Dim respon As MsgBoxResult
            respon = MsgBox("Yakin Ingin Menghapus Data Ini?", MsgBoxStyle.YesNo, "Konfirmasi")
            If respon = MsgBoxResult.Yes Then
                _pilihan = dgvsup.SelectedRows(0).DataBoundItem
                _mySrv.Hapussupplier(_secure, _pilihan.idsupplier)
                txtsup.Clear()
                txtsup.Enabled = False
                txtal.Clear()
                txtal.Enabled = False
                txtno.Clear()
                txtno.Enabled = False
                btnadd.Enabled = True
                btnedit.Enabled = True
                btncancel.Enabled = False
                MsgBox("Success!", MsgBoxStyle.OkOnly, "Information...")
                refreshdata()
                If dgvsup.SelectedRows.Count = 0 Then
                    btnedit.Enabled = False
                    btndelete.Enabled = False
                Else
                    btnedit.Enabled = True
                    btndelete.Enabled = True
                End If
            End If
        End If

    End Sub

    Private Sub dgvsupplier_CellFormatting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles dgvsup.CellFormatting
        dgvsup.Rows(e.RowIndex).HeaderCell.Value = CStr(e.RowIndex + 1)
    End Sub

    Private Sub btnedit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnedit.Click
        If dgvsup.SelectedRows.Count = 0 Then Exit Sub
        txtsup.Enabled = True
        txtal.Enabled = True
        txtno.Enabled = True
        _pilihan = dgvsup.SelectedRows(0).DataBoundItem
        txtsup.Text = _pilihan.namasupplier
        txtal.Text = _pilihan.alamatsupplier
        txtno.Text = _pilihan.nohpsupplier
        btnadd.Enabled = False
        btnsave.Enabled = True
        btncancel.Enabled = True
        btnedit.Enabled = False
        btndelete.Enabled = False
        _isnew = False
    End Sub

    Private Sub btncancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btncancel.Click
        ErrorProvider1.Clear()
        txtsup.Clear()
        txtsup.Enabled = False
        txtal.Clear()
        txtal.Enabled = False
        txtno.Clear()
        txtno.Enabled = False
        btnadd.Enabled = True
        btnedit.Enabled = True
        btncancel.Enabled = False
        btnsave.Enabled = False
        btndelete.Enabled = True
    End Sub

    Private Sub refreshdata()
        _mastersupplier = _mySrv.AmbilMastersupplier(_secure)
        dgvsup.DataSource = _mastersupplier
    End Sub

    Private Sub txtsupplier_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtsup.Validating
        If txtsup.Text = "" Then
            ErrorProvider1.SetError(txtsup, "Harus diisi")
        Else
            ErrorProvider1.Clear()
        End If
    End Sub

    Private Sub btncari_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btncari.Click
        _mastersupplier = _mySrv.SearchSupplier(_secure, txtcari.Text)
        dgvsup.DataSource = _mastersupplier
    End Sub
End Class