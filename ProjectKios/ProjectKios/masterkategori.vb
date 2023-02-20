Imports x = ProjectKios.ServiceReference1
Public Class masterkategori
    Public user As String = ""
    Public pass As String = ""
    Public idakses As Guid
    Private _mySrv As New x.WebService1SoapClient
    Private _secure As New x.AutentikasiUser
    Private _masterkategori As x.DataMasterkategori()
    Private _isnew As Boolean = True
    Private _pilihan As x.DataMasterkategori

    Private Sub getAccessControl()
        _secure.username = user.ToLower
        _secure.password = pass
        If _secure.Username = "" And _secure.Password = "" Then Me.Close()
    End Sub

    Private Sub masterkategori_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        getAccessControl()
        refreshdata()
        If dgvkat.RowCount = 0 Then
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
        txtkat.Enabled = True
        txtkat.Focus()
        btnsave.Enabled = True
        btnedit.Enabled = False
        btndelete.Enabled = False
        btncancel.Enabled = True
        btnadd.Enabled = False
    End Sub

    Private Sub btnsave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnsave.Click
        If txtkat.Text = "" Then
            ErrorProvider1.SetError(txtkat, "Harus diisi")
            Exit Sub
        End If
        Dim cek1 As Boolean = _mySrv.CheckNamakategori1(_secure, txtkat.Text)
        Dim cek0 As Boolean = _mySrv.CheckNamakategori0(_secure, txtkat.Text)
        If _isnew = True Then
            If cek1 = True Then
                MsgBox("Kategori Sudah Ada!", MsgBoxStyle.OkOnly, "Information...")
                Exit Sub
            End If
            If cek0 = True Then
                Dim respon As MsgBoxResult
                respon = MsgBox("Kategori Sudah Pernah Dihapus, Ingin Mengaktifkan Kembali?", MsgBoxStyle.YesNo, "Confirmation...")
                If respon = MsgBoxResult.Yes Then
                    _mySrv.UbahStatuskategori(_secure, txtkat.Text, user)
                    txtkat.Clear()
                    txtkat.Enabled = False
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
            _mySrv.Tambahkategori(_secure, txtkat.Text, user)
            txtkat.Clear()
            txtkat.Enabled = False
            btnadd.Enabled = True
            btnedit.Enabled = True
            btnsave.Enabled = False
            btncancel.Enabled = False
            btndelete.Enabled = True
        Else
            If _pilihan.namakategori <> txtkat.Text Then
                If cek1 = True Then
                    MsgBox("Kategori Sudah Ada!", MsgBoxStyle.OkOnly, "Information...")
                    Exit Sub
                End If
                If cek0 = True Then
                    Dim respon As MsgBoxResult
                    respon = MsgBox("Kategori Sudah Pernah Dihapus, Ingin Mengaktifkan Kembali?", MsgBoxStyle.YesNo, "Confirmation...")
                    If respon = MsgBoxResult.Yes Then
                        _mySrv.UbahStatuskategori(_secure, txtkat.Text, user)
                        txtkat.Clear()
                        txtkat.Enabled = False
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
            _mySrv.Ubahkategori(_secure, _pilihan.idkategori, txtkat.Text, user)
            txtkat.Clear()
            txtkat.Enabled = False
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
        If dgvkat.SelectedRows.Count = 0 Then Exit Sub
        _pilihan = dgvkat.SelectedRows(0).DataBoundItem
        Dim cek As Boolean = _mySrv.CheckKategori(_secure, _pilihan.idkategori)
        If cek = True Then
            MsgBox("Kategori Sudah digunakan, tidak bisa dihapus!", MsgBoxStyle.OkOnly, "Information...")
            Exit Sub
        Else
            Dim respon As MsgBoxResult
            respon = MsgBox("Yakin Ingin Menghapus Data Ini?", MsgBoxStyle.YesNo, "Konfirmasi")
            If respon = MsgBoxResult.Yes Then
                _mySrv.Hapuskategori(_secure, _pilihan.idkategori)
                txtkat.Clear()
                txtkat.Enabled = False
                btnadd.Enabled = True
                btnedit.Enabled = True
                btncancel.Enabled = False
                MsgBox("Success!", MsgBoxStyle.OkOnly, "Information...")
                refreshdata()
                If dgvkat.SelectedRows.Count = 0 Then
                    btnedit.Enabled = False
                    btndelete.Enabled = False
                Else
                    btnedit.Enabled = True
                    btndelete.Enabled = True
                End If
            End If
        End If
    End Sub

    Private Sub dgvkategori_CellFormatting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles dgvkat.CellFormatting
        dgvkat.Rows(e.RowIndex).HeaderCell.Value = CStr(e.RowIndex + 1)
    End Sub

    Private Sub btnedit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnedit.Click
        If dgvkat.SelectedRows.Count = 0 Then Exit Sub
        txtkat.Enabled = True
        _pilihan = dgvkat.SelectedRows(0).DataBoundItem
        txtkat.Text = _pilihan.namakategori
        btnadd.Enabled = False
        btnsave.Enabled = True
        btncancel.Enabled = True
        btnedit.Enabled = False
        btndelete.Enabled = False
        _isnew = False
    End Sub

    Private Sub btncancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btncancel.Click
        ErrorProvider1.Clear()
        txtkat.Clear()
        txtkat.Enabled = False
        btnadd.Enabled = True
        btnedit.Enabled = True
        btncancel.Enabled = False
        btnsave.Enabled = False
        btndelete.Enabled = True
    End Sub

    Private Sub refreshdata()
        _masterkategori = _mySrv.AmbilMasterkategori(_secure)
        dgvkat.DataSource = _masterkategori
    End Sub

    Private Sub txtkategori_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtkat.Validating
        If txtkat.Text = "" Then
            ErrorProvider1.SetError(txtkat, "Harus diisi")
        Else
            ErrorProvider1.Clear()
        End If
    End Sub
End Class