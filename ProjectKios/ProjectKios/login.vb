Imports x = ProjectKios.ServiceReference1
Public Class Login

    Private _myserv As New x.WebService1SoapClient
    Private _secure As New x.AutentikasiUser
    Private _mybusobj As x.DataAkses()
    Private _menu As New dashboard

    Private Sub getAccessControl()
        _secure.username = txtusername.Text.ToLower
        _secure.password = txtpassword.Text
    End Sub

    Private Sub btncancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btncancel.Click
        Me.Close()
    End Sub

    Private Sub btnlogin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnlogin.Click
        Try
            System.Windows.Forms.Cursor.Current = Cursors.WaitCursor
            Call getAccessControl()
            Dim hasil As String = _myserv.LoginDB(_secure)
            If hasil Is Nothing Then
                Throw New Exception("Invalid Username/Password")
            End If
            _mybusobj = _myserv.AmbilAkses(_secure)
            _menu.user = txtusername.Text
            _menu.pass = txtpassword.Text
            _menu.idakses = _mybusobj(0).idakses
            _menu.iduser = _mybusobj(0).iduser
            _menu.idperusahaan = _mybusobj(0).idperusahaan
            _menu.ShowDialog()
            txtusername.Focus()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        System.Windows.Forms.Cursor.Current = Cursors.Default
    End Sub

    Private Sub chkshow_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkshow.CheckedChanged
        If chkshow.Checked = False Then
            txtpassword.PasswordChar = "*"
        Else
            txtpassword.PasswordChar = ""
        End If
    End Sub

    Private Sub Login_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        txtusername.Focus()
    End Sub

End Class
