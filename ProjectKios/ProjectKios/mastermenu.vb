Imports x = ProjectKios.ServiceReference1
Public Class mastermenu
    Public user As String = ""
    Public pass As String = ""
    Public idakses As Guid
    Private _mySrv As New x.WebService1SoapClient
    Private _secure As New x.AutentikasiUser
    Private _mastermenu As x.DataMasterMenu()
    Private _isnew As Boolean = True
    Private _pilihan As x.DataMasterMenu

    Private Sub getAccessControl()
        _secure.username = user.ToLower
        _secure.password = pass
        If _secure.Username = "" And _secure.Password = "" Then Me.Close()
    End Sub

    Private Sub mastermenu_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        getAccessControl()
        refreshdata()
        If dgvmenu.RowCount = 0 Then
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
        txtmenu.Enabled = True
        txtmenu.Focus()
        btnsave.Enabled = True
        btnedit.Enabled = False
        btndelete.Enabled = False
        btncancel.Enabled = True
        btnadd.Enabled = False
    End Sub

    Private Sub btnsave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnsave.Click
        If txtmenu.Text = "" Then
            ErrorProvider1.SetError(txtmenu, "Harus diisi")
            Exit Sub
        End If
        Dim cek1 As Boolean = _mySrv.CheckNamaMenu1(_secure, txtmenu.Text)
        Dim cek0 As Boolean = _mySrv.CheckNamaMenu0(_secure, txtmenu.Text)
        If cek1 = True Then
            MsgBox("Menu Sudah Ada!", MsgBoxStyle.OkOnly, "Information...")
            Exit Sub
        End If
        If cek0 = True Then
            Dim respon As MsgBoxResult
            respon = MsgBox("Menu Sudah Pernah Dihapus, Ingin Mengaktifkan Kembali?", MsgBoxStyle.YesNo, "Confirmation...")
            If respon = MsgBoxResult.Yes Then
                _mySrv.UbahStatusMenu(_secure, txtmenu.Text, user)
                txtmenu.Clear()
                txtmenu.Enabled = False
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
        If _isnew = True Then
            _mySrv.TambahMenu(_secure, txtmenu.Text, user)
            txtmenu.Clear()
            txtmenu.Enabled = False
            btnadd.Enabled = True
            btnedit.Enabled = True
            btnsave.Enabled = False
            btncancel.Enabled = False
            btndelete.Enabled = True
        Else
            _mySrv.UbahMenu(_secure, _pilihan.idmenu, txtmenu.Text, user)
            txtmenu.Clear()
            txtmenu.Enabled = False
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
        If dgvmenu.SelectedRows.Count = 0 Then Exit Sub
        _pilihan = dgvmenu.SelectedRows(0).DataBoundItem
        Dim cek As Boolean = _mySrv.CheckMenu(_secure, _pilihan.idmenu)
        If cek = True Then
            MsgBox("Menu Sudah digunakan, tidak bisa dihapus!", MsgBoxStyle.OkOnly, "Information...")
            Exit Sub
        Else
            Dim respon As MsgBoxResult
            respon = MsgBox("Yakin Ingin Menghapus Data Ini?", MsgBoxStyle.YesNo, "Konfirmasi")
            If respon = MsgBoxResult.Yes Then
                _mySrv.HapusMenu(_secure, _pilihan.idmenu)
                txtmenu.Clear()
                txtmenu.Enabled = False
                btnadd.Enabled = True
                btnedit.Enabled = True
                btncancel.Enabled = False
                MsgBox("Success!", MsgBoxStyle.OkOnly, "Information...")
                refreshdata()
                If dgvmenu.SelectedRows.Count = 0 Then
                    btnedit.Enabled = False
                    btndelete.Enabled = False
                Else
                    btnedit.Enabled = True
                    btndelete.Enabled = True
                End If
            End If
        End If
    End Sub

    Private Sub dgvakses_CellFormatting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles dgvmenu.CellFormatting
        dgvmenu.Rows(e.RowIndex).HeaderCell.Value = CStr(e.RowIndex + 1)
    End Sub

    Private Sub btnedit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnedit.Click
        If dgvmenu.SelectedRows.Count = 0 Then Exit Sub
        txtmenu.Enabled = True
        _pilihan = dgvmenu.SelectedRows(0).DataBoundItem
        txtmenu.Text = _pilihan.namamenu
        btnadd.Enabled = False
        btnsave.Enabled = True
        btncancel.Enabled = True
        btnedit.Enabled = False
        btndelete.Enabled = False
        _isnew = False
    End Sub

    Private Sub btncancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btncancel.Click
        ErrorProvider1.Clear()
        txtmenu.Clear()
        txtmenu.Enabled = False
        btnadd.Enabled = True
        btnedit.Enabled = True
        btncancel.Enabled = False
        btnsave.Enabled = False
        btndelete.Enabled = True
    End Sub

    Private Sub refreshdata()
        _mastermenu = _mySrv.AmbilMasterMenu(_secure)
        dgvmenu.DataSource = _mastermenu
    End Sub

    Private Sub txtmenu_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtmenu.Validating
        If txtmenu.Text = "" Then
            ErrorProvider1.SetError(txtmenu, "Harus diisi")
        Else
            ErrorProvider1.Clear()
        End If
    End Sub
End Class