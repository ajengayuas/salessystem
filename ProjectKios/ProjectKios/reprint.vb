Imports x = ProjectKios.ServiceReference1
Public Class reprint
    Public user As String = ""
    Public pass As String = ""
    Public idakses As Guid
    Public iduser As Guid
    Private _mySrv As New x.WebService1SoapClient
    Private _secure As New x.AutentikasiUser

    Private Sub getAccessControl()
        _secure.username = user.ToLower
        _secure.password = pass
        If _secure.Username = "" And _secure.Password = "" Then Me.Close()
    End Sub

    Private Sub btncetak_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btncetak.Click
        If txtno.Text = "" Or nudtunai.Value = 0 Then
            MsgBox("Data Belum Lengkap!")
            Exit Sub
        End If
        System.Windows.Forms.Cursor.Current = Cursors.WaitCursor
        Dim f As New forminvoice
        f.user = user
        f.pass = pass
        f.iduser = iduser
        f.no = txtno.Text
        f.tunai = nudtunai.Value
        f.kepada = txtkepada.Text
        f.ShowDialog()
    End Sub

    Private Sub reprint_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        getAccessControl()
        System.Windows.Forms.Cursor.Current = Cursors.Default
    End Sub
End Class