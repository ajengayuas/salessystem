Imports x = ProjectKios.ServiceReference1
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Public Class formrptpembelian
    Public user As String = ""
    Public pass As String = ""
    Public iduser As Guid
    Public no As String = ""
    Public tunai As Decimal
    Private _mySrv As New x.WebService1SoapClient
    Private _secure As New x.AutentikasiUser
    Private _myBusObj As x.DataRptPembelian()
    Private _rptDoc As New ReportDocument

    Private Sub getAccessControl()
        _secure.username = user.ToLower
        _secure.password = pass
        If _secure.Username = "" And _secure.Password = "" Then Me.Close()
    End Sub

    Private Sub forminvoice_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        getAccessControl()
        isiLap()
        System.Windows.Forms.Cursor.Current = Cursors.Default
    End Sub

    Private Sub isiLap()
        _myBusObj = _mySrv.AmbilDataPembelian(_secure, tgl1.Value, tgl2.Value)
        _rptDoc.Load("F:\KIOS\ProjectKios\ProjectKios\rptpembelian.rpt")
        _rptDoc.SetDataSource(_myBusObj)
        crvpembelian.ReportSource = _rptDoc
        crvpembelian.Show()
    End Sub

    Private Sub btnshow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnshow.Click
        isiLap()
    End Sub
End Class