Imports x = ProjectKios.ServiceReference1
Public Class masterperusahaan
    Public user As String = ""
    Public pass As String = ""
    Private _mySrv As New x.WebService1SoapClient
    Private _secure As New x.AutentikasiUser
    Private _dataperusahaan As x.DataPerusahaan()
    Private _isnew As Boolean = True

    Private Sub masterperusahaan_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        getAccessControl()
        loadsub()
        System.Windows.Forms.Cursor.Current = Cursors.Default
    End Sub

    Private Sub btnadd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnadd.Click
        editadd()
        txtnama.Focus()
    End Sub

    Private Sub btnedit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnedit.Click
        editadd()
        _isnew = False
        idperusahaan()
    End Sub

    Private Sub btnsave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnsave.Click
        If txtnama.Text = "" Then
            ErrorProvider1.SetError(txtnama, "Harus diisi")
            Exit Sub
        End If
        Try
            If _isnew = True Then
                _mySrv.TambahPerusahaan(_secure, txtnama.Text, txtalamat.Text, txtno.Text, KonversiImageToByteArray(pbfoto.Image), user)
            Else
                _mySrv.UbahPerusahaan(_secure, _dataperusahaan(0).idperusahaan, txtnama.Text, txtalamat.Text, txtno.Text, KonversiImageToByteArray(pbfoto.Image), user)
            End If
            txtnama.Enabled = False
            txtalamat.Enabled = False
            txtno.Enabled = False
            btnbrowse.Enabled = False
            btnsave.Enabled = False
            btnadd.Enabled = False
            btnedit.Enabled = True
            btncancel.Enabled = False
            btndelete.Enabled = True
            MsgBox("Success!", MsgBoxStyle.OkOnly, "Information...")
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        _isnew = True
    End Sub

    Private Sub btndelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btndelete.Click
        idperusahaan()
        Try
            Dim respon As MsgBoxResult
            respon = MsgBox("Yakin Ingin Menghapus Data Ini?", MsgBoxStyle.YesNo, "Konfirmasi")
            If respon = MsgBoxResult.Yes Then
                _mySrv.HapusPerusahaan(_secure, _dataperusahaan(0).idperusahaan)
                txtnama.Clear()
                txtalamat.Clear()
                txtno.Clear()
                pbfoto.Image = Nothing
                btnadd.Enabled = True
                btnbrowse.Enabled = False
                btnedit.Enabled = False
                btnsave.Enabled = False
                btndelete.Enabled = False
                btncancel.Enabled = False
                MsgBox("Success!", MsgBoxStyle.OkOnly, "Information...")
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub btnbrowse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnbrowse.Click
        If OpenFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            pbfoto.Image = Image.FromFile(OpenFileDialog1.FileName)
        End If
    End Sub

    Private Sub PictureBox6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox6.Click
        Me.Close()
    End Sub

    Private Sub btncancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btncancel.Click
        If _isnew = False Then
            loadsub()
            txtnama.Enabled = False
            txtalamat.Enabled = False
            txtno.Enabled = False
            btnbrowse.Enabled = False
            btnsave.Enabled = False
            btncancel.Enabled = False
            ErrorProvider1.Clear()
        Else
            txtnama.Clear()
            txtalamat.Clear()
            txtno.Clear()
            txtnama.Enabled = False
            txtalamat.Enabled = False
            txtno.Enabled = False
            pbfoto.Image = Nothing
            btnadd.Enabled = True
            btnbrowse.Enabled = False
            btnedit.Enabled = False
            btnsave.Enabled = False
            btndelete.Enabled = False
            btncancel.Enabled = False
            ErrorProvider1.Clear()
        End If
    End Sub

    Private Sub idperusahaan()
        _dataperusahaan = _mySrv.AmbilIDPerusahaan(_secure, txtnama.Text)
    End Sub
    Private Sub getAccessControl()
        _secure.username = user.ToLower
        _secure.password = pass
        If _secure.Username = "" And _secure.Password = "" Then Me.Close()
    End Sub
    Private Function KonversiByteArrayToImage(ByVal ByteArray As Byte()) As Image
        Dim ms As New IO.MemoryStream(ByteArray)
        Return Image.FromStream(ms)
    End Function
    Private Function KonversiImageToByteArray(ByVal img As Image) As Byte()
        Dim ms As New IO.MemoryStream
        img.Save(ms, img.RawFormat)
        Return ms.ToArray
    End Function
    Private Sub editadd()
        txtnama.Enabled = True
        txtalamat.Enabled = True
        txtno.Enabled = True
        btnbrowse.Enabled = True
        btnsave.Enabled = True
        btnadd.Enabled = False
        btnedit.Enabled = False
        btndelete.Enabled = False
        btncancel.Enabled = True
    End Sub
    Private Sub loadsub()
        _dataperusahaan = _mySrv.AmbilPerusahaan(_secure)
        If _dataperusahaan.Length = 0 Then Exit Sub
        txtnama.Text = _dataperusahaan(0).namaperusahaan
        txtalamat.Text = _dataperusahaan(0).alamatperusahaan
        txtno.Text = _dataperusahaan(0).notelp
        pbfoto.Image = KonversiByteArrayToImage(_dataperusahaan(0).logo)
        If txtnama.Text <> "" Then
            btnedit.Enabled = True
            btndelete.Enabled = True
            btnadd.Enabled = False
        End If
    End Sub

    Private Sub txtnama_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtnama.Validating
        If txtnama.Text = "" Then
            ErrorProvider1.SetError(txtnama, "Harus diisi")
        Else
            ErrorProvider1.Clear()
        End If
    End Sub
End Class