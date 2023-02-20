Imports x = ProjectKios.ServiceReference1
Public Class AksesMenu
    Public user As String = ""
    Public pass As String = ""
    Public idakses As Guid
    Private _mySrv As New x.WebService1SoapClient
    Private _secure As New x.AutentikasiUser
    Private _masterakses As x.DataMasterAkses()
    Private _isnew As Boolean = True
    Private _pilihan As x.DataMasterAkses
    Private _mastermenu As x.DataMasterMenu()
    Private _groupakses As x.GroupAksesData()
    Private _cari As Boolean
    Private _idmenu As x.DataMasterMenu()

    Private Sub getAccessControl()
        _secure.username = user.ToLower
        _secure.password = pass
        If _secure.Username = "" And _secure.Password = "" Then Me.Close()
    End Sub

    Public Sub Fillcmbitem()
        _mastermenu = _mySrv.AmbilMasterMenu(_secure)
        cmbmenu.DataSource = _mastermenu
        cmbmenu.DisplayMember = "namamenu"
        cmbmenu.ValueMember = "namamenu"
    End Sub

    Private Sub AksesMenu_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.TransparencyKey = BackColor
        getAccessControl()
        dgvmenu.Columns.Item(3).ReadOnly = True
        _cari = _mySrv.AmbilCariAkses(_secure, idakses)
        If _cari = True Then
            _groupakses = _mySrv.AmbilGroupAkses(_secure, idakses)
            dgvmenu.DataSource = _groupakses
        Else
            _mastermenu = _mySrv.AmbilMasterMenu(_secure)
            dgvmenu.DataSource = _mastermenu
        End If
        Fillcmbitem()
        System.Windows.Forms.Cursor.Current = Cursors.Default
    End Sub

    Private Sub PictureBox6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox6.Click
        Close()
    End Sub

    Private Sub dgvmenu_CellFormatting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles dgvmenu.CellFormatting
        dgvmenu.Rows(e.RowIndex).HeaderCell.Value = CStr(e.RowIndex + 1)
    End Sub

    Private Sub btnupdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnupdate.Click
        Try
            _cari = _mySrv.AmbilCariAkses(_secure, idakses)
            If _cari = True Then
                For i As Integer = 0 To dgvmenu.Rows.Count - 1
                    Dim status As Boolean = dgvmenu.Rows(i).Cells(4).Value
                    Dim idakses2 As Guid = dgvmenu.Rows(i).Cells(1).Value
                    Dim idmenu As Guid = dgvmenu.Rows(i).Cells(2).Value
                    _mySrv.UbahGroupAkses(_secure, status, idakses2, idmenu, user)
                Next
            Else
                For i As Integer = 0 To dgvmenu.Rows.Count - 1
                    Dim status As Boolean = dgvmenu.Rows(i).Cells(2).Value
                    Dim idakses2 As Guid = idakses
                    Dim idmenu As Guid = dgvmenu.Rows(i).Cells(3).Value
                    _mySrv.TambahGroupAkses(_secure, idakses2, idmenu, user, status)
                Next
            End If
            MsgBox("Success!", MsgBoxStyle.OkOnly, "Information...")
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub btnadd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnadd.Click
        _idmenu = _mySrv.AmbilIDMasterMenu(_secure, cmbmenu.Text)
        Dim cek As Boolean = _mySrv.CheckGroupAkses(_secure, idakses, _idmenu(0).idmenu)
        If cek = True Then
            MsgBox("Menu Sudah Ada!", MsgBoxStyle.OkOnly, "Information...")
            Exit Sub
        End If
        _mySrv.TambahGroupAkses(_secure, idakses, _idmenu(0).idmenu, user, 1)

        _groupakses = _mySrv.AmbilGroupAkses(_secure, idakses)
        dgvmenu.DataSource = _groupakses
    End Sub
End Class