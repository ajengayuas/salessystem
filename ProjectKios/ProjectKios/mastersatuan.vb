Imports x = ProjectKios.ServiceReference1
Public Class mastersatuan
    Public user As String = ""
    Public pass As String = ""
    Public idakses As Guid
    Private _mySrv As New x.WebService1SoapClient
    Private _secure As New x.AutentikasiUser
    Private _mastersatuan As x.DataMastersatuan()
    Private _isnew As Boolean = True
    Private _pilihan As x.DataMastersatuan

    Private Sub getAccessControl()
        _secure.username = user.ToLower
        _secure.password = pass
        If _secure.Username = "" And _secure.Password = "" Then Me.Close()
    End Sub

    Private Sub mastersatuan_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        getAccessControl()
        refreshdata()
        If dgvsat.RowCount = 0 Then
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
        txtsat.Enabled = True
        txtsat.Focus()
        txtsat.Clear()
        nudpcs.Enabled = True
        btnsave.Enabled = True
        btnedit.Enabled = False
        btndelete.Enabled = False
        btncancel.Enabled = True
        btnadd.Enabled = False
    End Sub

    Private Sub btnsave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnsave.Click
        If txtsat.Text = "" Then
            ErrorProvider1.SetError(txtsat, "Harus diisi")
            Exit Sub
        End If
        If nudpcs.Value = 0 Then
            ErrorProvider1.SetError(nudpcs, "Harus diisi")
            Exit Sub
        End If
        Dim cek1 As Boolean = _mySrv.CheckNamasatuan1(_secure, txtsat.Text)
        Dim cek0 As Boolean = _mySrv.CheckNamasatuan0(_secure, txtsat.Text)
        If _isnew = True Then
            If cek1 = True Then
                MsgBox("Satuan Sudah Ada!", MsgBoxStyle.OkOnly, "Information...")
                Exit Sub
            End If
            If cek0 = True Then
                Dim respon As MsgBoxResult
                respon = MsgBox("Satuan Sudah Pernah Dihapus, Ingin Mengaktifkan Kembali?", MsgBoxStyle.YesNo, "Confirmation...")
                If respon = MsgBoxResult.Yes Then
                    _mySrv.UbahStatussatuan(_secure, txtsat.Text, user)
                    txtsat.Clear()
                    txtsat.Enabled = False
                    nudpcs.Enabled = False
                    nudpcs.Value = 0
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
            _mySrv.Tambahsatuan(_secure, txtsat.Text, nudpcs.Value, user)
            txtsat.Clear()
            txtsat.Enabled = False
            nudpcs.Enabled = False
            nudpcs.Value = 0
            btnadd.Enabled = True
            btnedit.Enabled = True
            btnsave.Enabled = False
            btncancel.Enabled = False
            btndelete.Enabled = True
        Else
            If _pilihan.namasatuan <> txtsat.Text Then
                If cek1 = True Then
                    MsgBox("Satuan Sudah Ada!", MsgBoxStyle.OkOnly, "Information...")
                    Exit Sub
                End If
                If cek0 = True Then
                    Dim respon As MsgBoxResult
                    respon = MsgBox("Satuan Sudah Pernah Dihapus, Ingin Mengaktifkan Kembali?", MsgBoxStyle.YesNo, "Confirmation...")
                    If respon = MsgBoxResult.Yes Then
                        _mySrv.UbahStatussatuan(_secure, txtsat.Text, user)
                        txtsat.Clear()
                        txtsat.Enabled = False
                        nudpcs.Enabled = False
                        nudpcs.Value = 0
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
            _mySrv.Ubahsatuan(_secure, _pilihan.idsatuan, txtsat.Text, nudpcs.Value, user)
            txtsat.Clear()
            txtsat.Enabled = False
            nudpcs.Enabled = False
            nudpcs.Value = 0
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
        If dgvsat.SelectedRows.Count = 0 Then Exit Sub
        _pilihan = dgvsat.SelectedRows(0).DataBoundItem
        Dim cek As Boolean = _mySrv.CheckSatuan(_secure, _pilihan.idsatuan)
        If cek = True Then
            MsgBox("Satuan Sudah digunakan, tidak bisa dihapus!", MsgBoxStyle.OkOnly, "Information...")
            Exit Sub
        Else
            Dim respon As MsgBoxResult
            respon = MsgBox("Yakin Ingin Menghapus Data Ini?", MsgBoxStyle.YesNo, "Konfirmasi")
            If respon = MsgBoxResult.Yes Then
                _mySrv.Hapussatuan(_secure, _pilihan.idsatuan)
                txtsat.Clear()
                txtsat.Enabled = False
                nudpcs.Enabled = False
                nudpcs.Value = 0
                btnadd.Enabled = True
                btnedit.Enabled = True
                btncancel.Enabled = False
                MsgBox("Success!", MsgBoxStyle.OkOnly, "Information...")
                refreshdata()
                If dgvsat.SelectedRows.Count = 0 Then
                    btnedit.Enabled = False
                    btndelete.Enabled = False
                Else
                    btnedit.Enabled = True
                    btndelete.Enabled = True
                End If
            End If
        End If
    End Sub

    Private Sub dgvsatuan_CellFormatting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles dgvsat.CellFormatting
        dgvsat.Rows(e.RowIndex).HeaderCell.Value = CStr(e.RowIndex + 1)
    End Sub

    Private Sub btnedit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnedit.Click
        If dgvsat.SelectedRows.Count = 0 Then Exit Sub
        txtsat.Enabled = True
        nudpcs.Enabled = True
        _pilihan = dgvsat.SelectedRows(0).DataBoundItem
        txtsat.Text = _pilihan.namasatuan
        nudpcs.Value = _pilihan.konvpcs
        btnadd.Enabled = False
        btnsave.Enabled = True
        btncancel.Enabled = True
        btnedit.Enabled = False
        btndelete.Enabled = False
        _isnew = False
    End Sub

    Private Sub btncancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btncancel.Click
        ErrorProvider1.Clear()
        txtsat.Clear()
        txtsat.Enabled = False
        nudpcs.Enabled = False
        btnadd.Enabled = True
        btnedit.Enabled = True
        btncancel.Enabled = False
        btnsave.Enabled = False
        btndelete.Enabled = True
    End Sub

    Private Sub refreshdata()
        _mastersatuan = _mySrv.AmbilMastersatuan(_secure)
        dgvsat.DataSource = _mastersatuan
    End Sub

    Private Sub txtsatuan_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtsat.Validating
        If txtsat.Text = "" Then
            ErrorProvider1.SetError(txtsat, "Harus diisi")
        Else
            ErrorProvider1.Clear()
        End If
    End Sub

    Private Sub nudpcs_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles nudpcs.Validating
        If nudpcs.Value = 0 Then
            ErrorProvider1.SetError(nudpcs, "Harus diisi")
        Else
            ErrorProvider1.Clear()
        End If
    End Sub
End Class