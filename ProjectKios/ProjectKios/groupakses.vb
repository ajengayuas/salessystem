Imports x = ProjectKios.ServiceReference1
Public Class groupakses
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
        System.Windows.Forms.Cursor.Current = Cursors.Default
    End Sub

    Private Sub PictureBox6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox6.Click
        Me.Close()
    End Sub

    Private Sub dgvakses_CellFormatting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles dgvakses.CellFormatting
        dgvakses.Rows(e.RowIndex).HeaderCell.Value = CStr(e.RowIndex + 1)
    End Sub

    Private Sub refreshdata()
        _masterakses = _mySrv.AmbilMasterAkses(_secure)
        dgvakses.DataSource = _masterakses
    End Sub

    Private Sub dgvakses_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvakses.DoubleClick
        _pilihan = dgvakses.SelectedRows(0).DataBoundItem
        Dim f As New AksesMenu
        f.user = user
        f.pass = pass
        f.idakses = _pilihan.idakses
        f.ShowDialog()
    End Sub
End Class