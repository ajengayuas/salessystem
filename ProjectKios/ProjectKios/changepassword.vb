Imports x = ProjectKios.ServiceReference1
Public Class changepassword
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

    Private Sub changepassword_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        getAccessControl()
        txtpass.Focus()
        System.Windows.Forms.Cursor.Current = Cursors.Default
    End Sub

    Private Sub PictureBox6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox6.Click
        Close()
    End Sub

    Private Sub btnchange_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnchange.Click
        If txtpass.Text = "" Then
            ErrorProvider1.SetError(txtpass, "Harus Diisi!")
            Exit Sub
        Else
            ErrorProvider1.Clear()
        End If
        If txtpassbar.Text = "" Then
            ErrorProvider1.SetError(txtpassbar, "Harus Diisi!")
            Exit Sub
        Else
            ErrorProvider1.Clear()
        End If
        If txtrepass.Text = "" Then
            ErrorProvider1.SetError(txtrepass, "Harus Diisi!")
            Exit Sub
        Else
            ErrorProvider1.Clear()
        End If
        If txtpass.Text <> pass Then
            ErrorProvider1.SetError(txtpass, "Password Salah!")
            Exit Sub
        Else
            ErrorProvider1.Clear()
        End If
        If txtpassbar.Text <> txtrepass.Text Then
            ErrorProvider1.SetError(txtrepass, "Password Tidak Match!")
            Exit Sub
        Else
            ErrorProvider1.Clear()
        End If
        Try
            _mySrv.Ubahpassword(_secure, iduser, txtpassbar.Text)
            MsgBox("Success!")
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub txtpass_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtpass.Validating
        If txtpass.Text = "" Then
            ErrorProvider1.SetError(txtpass, "Harus Diisi!")
            Exit Sub
        Else
            ErrorProvider1.Clear()
        End If
        If txtpass.Text <> pass Then
            ErrorProvider1.SetError(txtpass, "Password Salah!")
            Exit Sub
        Else
            ErrorProvider1.Clear()
        End If
    End Sub
End Class