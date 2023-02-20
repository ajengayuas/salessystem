Imports x = ProjectKios.ServiceReference1
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Public Class forminvoice
    Public user As String = ""
    Public pass As String = ""
    Public iduser As Guid
    Public no As String = ""
    Public tunai As Decimal
    Public kepada As String=""
    Private _mySrv As New x.WebService1SoapClient
    Private _secure As New x.AutentikasiUser
    Private _myBusObj As x.DataInvoice()
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
        Dim paramfields As New CrystalDecisions.Shared.ParameterFields()
        Dim paramfield As New CrystalDecisions.Shared.ParameterField()
        Dim discreteval As New CrystalDecisions.Shared.ParameterDiscreteValue()
        paramfield.ParameterFieldName = "bayar"
        Dim str As Decimal = tunai
        discreteval.Value = str
        paramfield.CurrentValues.Add(discreteval)

        Dim paramfield2 As New CrystalDecisions.Shared.ParameterField()
        Dim discreteval2 As New CrystalDecisions.Shared.ParameterDiscreteValue()
        paramfield2.ParameterFieldName = "kepada"
        Dim str2 As String = kepada
        discreteval2.Value = str2
        paramfield2.CurrentValues.Add(discreteval2)

        paramfields.Add(paramfield)
        paramfields.Add(paramfield2)
        crvinvoice.ParameterFieldInfo = paramfields

        _myBusObj = _mySrv.AmbilDataInvoice2(_secure, no)
        _rptDoc.Load("F:\KIOS\ProjectKios\ProjectKios\rptinvoice.rpt")
        _rptDoc.SetDataSource(_myBusObj)
        crvinvoice.ReportSource = _rptDoc
        crvinvoice.PrintReport()
    End Sub
End Class