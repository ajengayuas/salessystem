Imports x = ProjectKios.ServiceReference1
Public Class masterconsumption
    Public user As String = ""
    Public pass As String = ""
    Public idakses As Guid
    Private _mySrv As New x.WebService1SoapClient
    Private _secure As New x.AutentikasiUser
    Private _mastercons As x.DataCons()
    Private _isnew As Boolean = True
    Private _pilihan As x.DataCons
    Private _listjasa As x.DataCons()
    Private _listitem As x.DataCons()
    Private _idjasa As x.DataCons()

    Private Sub getAccessControl()
        _secure.username = user.ToLower
        _secure.password = pass
        If _secure.Username = "" And _secure.Password = "" Then Me.Close()
    End Sub
    Public Sub Fillcmbjasa()
        _listjasa = _mySrv.AmbilListJasa(_secure)
        cmbjasa.DataSource = _listjasa
        cmbjasa.DisplayMember = "namaitem"
        cmbjasa.ValueMember = "namaitem"
    End Sub
    Public Sub Fillcmbitem()
        _listitem = _mySrv.AmbilListItem(_secure)
        cmbitem.DataSource = _listitem
        cmbitem.DisplayMember = "namaitem"
        cmbitem.ValueMember = "namaitem"
    End Sub
    Private Sub refreshdata()
        _mastercons = _mySrv.AmbilMasterCons(_secure)
        dgvcons.DataSource = _mastercons
    End Sub

    Private Sub PictureBox6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox6.Click
        Close()
    End Sub

    Private Sub masterconsumption_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        getAccessControl()
        Fillcmbjasa()
        Fillcmbitem()
        refreshdata()
        System.Windows.Forms.Cursor.Current = Cursors.Default
    End Sub

    Private Sub btnadd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnadd.Click
        Try
            _idjasa = _mySrv.AmbilIDJasa(_secure, cmbjasa.Text)
            Dim cek As Boolean = _mySrv.CheckCons(_secure, _idjasa(0).iditem, cmbitem.Text)
            If cek = False Then
                _mySrv.TambahCons(_secure, _idjasa(0).iditem, cmbitem.Text, nudqty.Value, user)
                refreshdata()
                MsgBox("Success!", MsgBoxStyle.OkOnly, "Information...")
            Else
                MsgBox("Consumtion Sudah Ada!", MsgBoxStyle.OkOnly, "Information...")
                Exit Sub
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub RemoveToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RemoveToolStripMenuItem.Click
        If dgvcons.SelectedRows.Count = 0 Then Exit Sub
        Try
            _pilihan = dgvcons.SelectedRows(0).DataBoundItem
            _mySrv.HapusCons(_secure, _pilihan.idcons)
            refreshdata()
            MsgBox("Success!", MsgBoxStyle.OkOnly, "Information...")
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
End Class