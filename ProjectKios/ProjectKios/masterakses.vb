Imports x = ProjectKios.ServiceReference1
Public Class masterakses
    Public user As String = ""
    Public pass As String = ""
    Public idakses As Guid
    Private _mySrv As New x.WebService1SoapClient
    Private _secure As New x.AutentikasiUser
    Private _masterakses As x.DataMasterAkses()
    Private _isnew As Boolean = True
    Private _pilihan As x.DataMasterAkses

    Private Sub getAccessControl()
        _secure.username = user.ToLower
        _secure.password = pass
        If _secure.Username = "" And _secure.Password = "" Then Me.Close()
    End Sub

    Private Sub masterakses_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        getAccessControl()
        refreshdata()
        If dgvakses.RowCount = 0 Then
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
        txtakses.Enabled = True
        txtakses.Focus()
        btnsave.Enabled = True
        btnedit.Enabled = False
        btndelete.Enabled = False
        btncancel.Enabled = True
        btnadd.Enabled = False
    End Sub

    Private Sub btnsave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnsave.Click
        If txtakses.Text = "" Then
            ErrorProvider1.SetError(txtakses, "Harus diisi")
            Exit Sub
        End If
        Dim cek1 As Boolean = _mySrv.CheckNamaAkses1(_secure, txtakses.Text)
        Dim cek0 As Boolean = _mySrv.CheckNamaAkses0(_secure, txtakses.Text)
        If cek1 = True Then
            MsgBox("Akses Sudah Ada!", MsgBoxStyle.OkOnly, "Information...")
            Exit Sub
        End If
        If cek0 = True Then
            Dim respon As MsgBoxResult
            respon = MsgBox("Akses Sudah Pernah Dihapus, Ingin Mengaktifkan Kembali?", MsgBoxStyle.YesNo, "Confirmation...")
            If respon = MsgBoxResult.Yes Then
                _mySrv.UbahStatusAkses(_secure, txtakses.Text, user)
                txtakses.Clear()
                txtakses.Enabled = False
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
            _mySrv.TambahAkses(_secure, txtakses.Text, user)
            txtakses.Clear()
            txtakses.Enabled = False
            btnadd.Enabled = True
            btnedit.Enabled = True
            btnsave.Enabled = False
            btncancel.Enabled = False
            btndelete.Enabled = True
        Else
            _mySrv.UbahAkses(_secure, _pilihan.idakses, txtakses.Text, user)
            txtakses.Clear()
            txtakses.Enabled = False
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
        If dgvakses.SelectedRows.Count = 0 Then Exit Sub
        _pilihan = dgvakses.SelectedRows(0).DataBoundItem
        Dim cek1 As Boolean = _mySrv.CheckAksesGroup(_secure, _pilihan.idakses)
        Dim cek2 As Boolean = _mySrv.CheckAkses(_secure, _pilihan.idakses)
        If cek1 = True And cek2 = True Then
            MsgBox("Akses Sudah digunakan, tidak bisa dihapus!", MsgBoxStyle.OkOnly, "Information...")
            Exit Sub
        Else
            Dim respon As MsgBoxResult
            respon = MsgBox("Yakin Ingin Menghapus Data Ini?", MsgBoxStyle.YesNo, "Konfirmasi")
            If respon = MsgBoxResult.Yes Then
                _mySrv.HapusAkses(_secure, _pilihan.idakses)
                txtakses.Clear()
                txtakses.Enabled = False
                btnadd.Enabled = True
                btnedit.Enabled = True
                btncancel.Enabled = False
                MsgBox("Success!", MsgBoxStyle.OkOnly, "Information...")
                refreshdata()
                If dgvakses.SelectedRows.Count = 0 Then
                    btnedit.Enabled = False
                    btndelete.Enabled = False
                Else
                    btnedit.Enabled = True
                    btndelete.Enabled = True
                End If
            End If
        End If
    End Sub

    Private Sub dgvakses_CellFormatting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles dgvakses.CellFormatting
        dgvakses.Rows(e.RowIndex).HeaderCell.Value = CStr(e.RowIndex + 1)
    End Sub

    Private Sub btnedit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnedit.Click
        If dgvakses.SelectedRows.Count = 0 Then Exit Sub
        txtakses.Enabled = True
        _pilihan = dgvakses.SelectedRows(0).DataBoundItem
        txtakses.Text = _pilihan.namaakses
        btnadd.Enabled = False
        btnsave.Enabled = True
        btncancel.Enabled = True
        btnedit.Enabled = False
        btndelete.Enabled = False
        _isnew = False
    End Sub

    Private Sub btncancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btncancel.Click
        ErrorProvider1.Clear()
        txtakses.Clear()
        txtakses.Enabled = False
        btnadd.Enabled = True
        btnedit.Enabled = True
        btncancel.Enabled = False
        btnsave.Enabled = False
        btndelete.Enabled = True
    End Sub

    Private Sub refreshdata()
        _masterakses = _mySrv.AmbilMasterAkses(_secure)
        dgvakses.DataSource = _masterakses
    End Sub

    Private Sub txtakses_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtakses.Validating
        If txtakses.Text = "" Then
            ErrorProvider1.SetError(txtakses, "Harus diisi")
        Else
            ErrorProvider1.Clear()
        End If
    End Sub
End Class