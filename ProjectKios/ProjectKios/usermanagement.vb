Imports x = ProjectKios.ServiceReference1
Public Class usermanagement
    Public user As String = ""
    Public pass As String = ""
    Public idakses As Guid
    Private _mySrv As New x.WebService1SoapClient
    Private _secure As New x.AutentikasiUser
    Private _userman As x.DataUserMan()
    Private _isnew As Boolean = True
    Private _pilihan As x.DataUserMan
    Private _idakses As x.DataMasterAkses()
    Private _perusahaan As x.DataPerusahaan()

    Private Sub getAccessControl()
        _secure.username = user.ToLower
        _secure.password = pass
        If _secure.Username = "" And _secure.Password = "" Then Me.Close()
    End Sub

    Private Sub masterakses_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Me.Load
        getAccessControl()
        fillcombo()
        cmbakses.SelectedIndex = -1
        refreshdata()
        If dgvuser.RowCount = 0 Then
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
        txtuser.Enabled = True
        txtuser.Focus()
        txtpassword.Enabled = True
        cmbakses.Enabled = True
        btnsave.Enabled = True
        btnedit.Enabled = False
        btndelete.Enabled = False
        btncancel.Enabled = True
        btnadd.Enabled = False
    End Sub

    Private Sub btnsave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnsave.Click
        If txtpassword.Text = "" Or txtuser.Text = "" Or cmbakses.SelectedIndex = -1 Then
            MsgBox("Harus Diisi!", MsgBoxStyle.OkOnly, "Alert!")
            ErrorProvider1.Clear()
            Exit Sub
        End If
        Dim cek1 As Boolean = _mySrv.CheckNamaUser1(_secure, txtuser.Text)
        Dim cek0 As Boolean = _mySrv.CheckNamaUser0(_secure, txtuser.Text)
        If _isnew = True Then
            If cek1 = True Then
                MsgBox("Username Sudah Ada!", MsgBoxStyle.OkOnly, "Information...")
                Exit Sub
            End If
            If cek0 = True Then
                Dim respon As MsgBoxResult
                respon = MsgBox("Username Sudah Pernah Dihapus, Ingin Mengaktifkan Kembali?", MsgBoxStyle.YesNo, "Confirmation...")
                If respon = MsgBoxResult.Yes Then
                    _mySrv.UbahStatusUSer(_secure, txtuser.Text, user)
                    txtuser.Clear()
                    txtuser.Enabled = False
                    txtpassword.Enabled = False
                    txtpassword.Clear()
                    cmbakses.Enabled = False
                    cmbakses.SelectedIndex = -1
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
            If _pilihan.username <> txtuser.Text Then
                If cek1 = True Then
                    MsgBox("Username Sudah Ada!", MsgBoxStyle.OkOnly, "Information...")
                    Exit Sub
                End If
                If cek0 = True Then
                    Dim respon As MsgBoxResult
                    respon = MsgBox("Username Sudah Pernah Dihapus, Ingin Mengaktifkan Kembali?", MsgBoxStyle.YesNo, "Confirmation...")
                    If respon = MsgBoxResult.Yes Then
                        _mySrv.UbahStatusUSer(_secure, txtuser.Text, user)
                        txtuser.Clear()
                        txtuser.Enabled = False
                        txtpassword.Enabled = False
                        txtpassword.Clear()
                        cmbakses.Enabled = False
                        cmbakses.SelectedIndex = -1
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
        _idakses = _mySrv.AmbilIDMasterAkses(_secure, cmbakses.Text)
        _perusahaan = _mySrv.AmbilPerusahaan(_secure)
        If _isnew = True Then
            _mySrv.TambahUser(_secure, txtuser.Text, txtpassword.Text, _idakses(0).idakses, _perusahaan(0).idperusahaan, user)
            txtuser.Clear()
            txtuser.Enabled = False
            txtpassword.Clear()
            txtpassword.Enabled = False
            cmbakses.SelectedIndex = -1
            cmbakses.Enabled = False
            btnadd.Enabled = True
            btnedit.Enabled = True
            btnsave.Enabled = False
            btncancel.Enabled = False
            btndelete.Enabled = True
        Else
            _mySrv.UbahUser(_secure, _pilihan.iduser, _idakses(0).idakses, user)
            txtuser.Clear()
            txtuser.Enabled = False
            txtpassword.Enabled = False
            txtpassword.Clear()
            cmbakses.Enabled = False
            cmbakses.SelectedIndex = -1
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
        If dgvuser.SelectedRows.Count = 0 Then Exit Sub
        Dim respon As MsgBoxResult
        respon = MsgBox("Yakin Ingin Menghapus Data Ini?", MsgBoxStyle.YesNo, "Konfirmasi")
        If respon = MsgBoxResult.Yes Then
            _pilihan = dgvuser.SelectedRows(0).DataBoundItem
            _mySrv.HapusUser(_secure, _pilihan.iduser)
            txtuser.Clear()
            txtuser.Enabled = False
            txtpassword.Clear()
            txtpassword.Enabled = False
            cmbakses.SelectedIndex = -1
            cmbakses.Enabled = False
            btnadd.Enabled = True
            btnedit.Enabled = True
            btncancel.Enabled = False
            MsgBox("Success!", MsgBoxStyle.OkOnly, "Information...")
            refreshdata()
            If dgvuser.SelectedRows.Count = 0 Then
                btnedit.Enabled = False
                btndelete.Enabled = False
            Else
                btnedit.Enabled = True
                btndelete.Enabled = True
            End If
        End If
    End Sub

    Private Sub dgvuser_CellFormatting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles dgvuser.CellFormatting
        dgvuser.Rows(e.RowIndex).HeaderCell.Value = CStr(e.RowIndex + 1)
    End Sub

    Private Sub btnedit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnedit.Click
        If dgvuser.SelectedRows.Count = 0 Then Exit Sub
        txtuser.Enabled = False
        _pilihan = dgvuser.SelectedRows(0).DataBoundItem
        txtuser.Text = _pilihan.username
        txtpassword.Text = "password123"
        cmbakses.SelectedValue = _pilihan.namaakses
        txtpassword.Enabled = False
        cmbakses.Enabled = True
        btnadd.Enabled = False
        btnsave.Enabled = True
        btncancel.Enabled = True
        btnedit.Enabled = False
        btndelete.Enabled = False
        _isnew = False
    End Sub

    Private Sub btncancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btncancel.Click
        txtuser.Clear()
        txtpassword.Clear()
        cmbakses.SelectedIndex = -1
        txtpassword.Enabled = False
        cmbakses.Enabled = False
        txtuser.Enabled = False
        btnadd.Enabled = True
        btnedit.Enabled = True
        btncancel.Enabled = False
        btnsave.Enabled = False
        btndelete.Enabled = True
        ErrorProvider1.Clear()
    End Sub

    Private Sub refreshdata()
        _userman = _mySrv.AmbilUserMan(_secure)
        dgvuser.DataSource = _userman
    End Sub
    Private Sub fillcombo()
        _userman = _mySrv.AmbilAksesForUserMan(_secure)
        cmbakses.DataSource = _userman
        cmbakses.DisplayMember = "namaakses"
        cmbakses.ValueMember = "namaakses"
    End Sub

    Private Sub txtuser_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtuser.Validating
        If txtuser.Text = "" Then
            ErrorProvider1.SetError(txtuser, "Harus Diisi!")
        Else
            ErrorProvider1.Clear()
        End If
    End Sub

    Private Sub txtpassword_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtpassword.Validating
        If txtpassword.Text = "" Then
            ErrorProvider1.SetError(txtpassword, "Harus Diisi!")
        Else
            ErrorProvider1.Clear()
        End If
    End Sub

    Private Sub cmbakses_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbakses.Validating
        If cmbakses.SelectedIndex = -1 Then
            ErrorProvider1.SetError(txtuser, "Harus Diisi!")
        Else
            ErrorProvider1.Clear()
        End If
    End Sub

    Private Sub btnreset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnreset.Click
        If dgvuser.SelectedRows.Count = 0 Then Exit Sub
        _pilihan = dgvuser.SelectedRows(0).DataBoundItem
        Dim respon As MsgBoxResult
        respon = MsgBox("Yakin Ingin Reset Password Ini?", MsgBoxStyle.YesNo, "Konfirmasi")
        If respon = MsgBoxResult.Yes Then
            _mySrv.GantiPassword(_secure, _pilihan.iduser)
            MsgBox("Success!", MsgBoxStyle.OkOnly, "Information...")
        End If
    End Sub
End Class