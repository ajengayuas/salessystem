Imports x = ProjectKios.ServiceReference1
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Public Class formrptkeuangan
    Public user As String = ""
    Public pass As String = ""
    Public iduser As Guid
    Public idakses As Guid
    Private _mySrv As New x.WebService1SoapClient
    Private _secure As New x.AutentikasiUser
    Private _datanonjasa As x.DataClosing()
    Private _datajasa As x.DataClosing()
    Private _datamulti As x.DataClosing()
    Private _data As x.DataClosing()
    Private _rptDoc As New ReportDocument

    Private Sub getAccessControl()
        _secure.username = user.ToLower
        _secure.password = pass
        If _secure.Username = "" And _secure.Password = "" Then Me.Close()
    End Sub

    Private Sub PictureBox6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox6.Click
        Close()
    End Sub

    Private Sub formrptkeuangan_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        getAccessControl()
    End Sub

    Private Sub btnclosing_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnclosing.Click
        Dim bln As Integer = dtpclosing.Value.Month
        Dim thn As Integer = dtpclosing.Value.Year
        Dim bulantahun As String = bln & "-" & thn
        Dim cek As Boolean = _mySrv.CheckClosing(_secure, bulantahun)
        If cek = True Then
            Dim respon As MsgBoxResult
            respon = MsgBox("Bulan dan Tahun ini sudah pernah diclosing, closing ulang?", MsgBoxStyle.YesNo, "Confirmation...")
            If respon = MsgBoxResult.Yes Then
                _mySrv.HapusClosing(_secure, bulantahun)
            Else
                Exit Sub
            End If
        End If
        Dim _tgl1 As New Date(thn, bln, 1)
        Dim tgl As Integer
        Select Case bln
            Case 1
                tgl = 31
            Case 2
                If thn Mod 4 = 0 Then
                    tgl = 29
                Else
                    tgl = 28
                End If
            Case 3
                tgl = 31
            Case 4
                tgl = 30
            Case 5
                tgl = 31
            Case 6
                tgl = 30
            Case 7
                tgl = 31
            Case 8
                tgl = 31
            Case 9
                tgl = 30
            Case 10
                tgl = 31
            Case 11
                tgl = 30
            Case 12
                tgl = 31
        End Select
        Dim _tgl2 As New Date(thn, bln, tgl)
        _datanonjasa = _mySrv.AmbilDataNonjasa(_secure, _tgl1, _tgl2)
        _datajasa = _mySrv.AmbilDataJasa(_secure, _tgl1, _tgl2)
        _datamulti = _mySrv.AmbilDataMulti(_secure, _tgl1, _tgl2)
        Try
            For i As Integer = 0 To _datanonjasa.Length - 1
                _mySrv.TambahClosing(_secure, _datanonjasa(i).idmulti, _datanonjasa(i).nopengeluaran, _datanonjasa(i).namaitem, _datanonjasa(i).qtypcs, _datanonjasa(i).jualpcs, _datanonjasa(i).amountjual, _datanonjasa(i).diskon, _datanonjasa(i).remark, _datanonjasa(i).keterangan, _datanonjasa(i).belipcs, _datanonjasa(i).amountbeli, _datanonjasa(i).tanggalkeluar, bulantahun, user)
            Next
            For i As Integer = 0 To _datajasa.Length - 1
                _mySrv.TambahClosing(_secure, _datajasa(i).idmulti, _datajasa(i).nopengeluaran, _datajasa(i).namaitem, _datajasa(i).qtypcs, _datajasa(i).jualpcs, _datajasa(i).amountjual, _datajasa(i).diskon, _datajasa(i).remark, _datajasa(i).keterangan, _datajasa(i).belipcs, _datajasa(i).amountbeli, _datajasa(i).tanggalkeluar, bulantahun, user)
            Next
            For i As Integer = 0 To _datamulti.Length - 1
                _mySrv.TambahClosing(_secure, _datamulti(i).idmulti, _datamulti(i).nopengeluaran, _datamulti(i).namaitem, _datamulti(i).qtypcs, _datamulti(i).jualpcs, _datamulti(i).amountjual, _datamulti(i).diskon, _datamulti(i).remark, _datamulti(i).keterangan, _datamulti(i).belipcs, _datamulti(i).amountbeli, _datamulti(i).tanggalkeluar, bulantahun, user)
            Next
            MsgBox("Success Closing!")
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub btnshow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnshow.Click
        isiLap()
    End Sub

    Private Sub isiLap()
        crvkeu.Refresh()
        Dim bln As Integer = dtpclosing.Value.Month
        Dim thn As Integer = dtpclosing.Value.Year
        Dim bulantahun As String = bln & "-" & thn
        _data = _mySrv.AmbilDataClosing(_secure, bulantahun)
        If _data.Length = 0 Then
            MsgBox("Bulan Ini Belum di CLosing!")
            Exit Sub
        End If
        _rptDoc.Load("F:\KIOS\ProjectKios\ProjectKios\rptkeuangan.rpt")
        _rptDoc.SetDataSource(_data)
        crvkeu.ReportSource = _rptDoc
        crvkeu.Show()
    End Sub
End Class