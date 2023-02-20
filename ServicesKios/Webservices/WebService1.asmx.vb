Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports System.ComponentModel
Imports BussinesLib

' To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line.
' <System.Web.Script.Services.ScriptService()> _
<System.Web.Services.WebService(Namespace:="http://tempuri.org/")> _
<System.Web.Services.WebServiceBinding(ConformsTo:=WsiProfiles.BasicProfile1_1)> _
<ToolboxItem(False)> _
Public Class WebService1
    Inherits System.Web.Services.WebService
#Region " Security Class "
    Public Class AutentikasiUser
        Inherits SoapHeader
        Public username As String
        Public password As String
    End Class

    Public MySecurity As New AutentikasiUser
    Public isvalid As Boolean

    Public Function LoginDatabase() As Boolean
        isvalid = infologin.GetData(MySecurity.username, MySecurity.password)
        Return isvalid
    End Function
#End Region

#Region " Login "
    <WebMethod(), SoapHeader("MySecurity")> _
    Public Function LoginDB() As String
        If LoginDatabase() Then
            Return isvalid
        End If
        Return Nothing
    End Function

    <WebMethod(), SoapHeader("MySecurity")> _
    Public Function AmbilAkses() As DataAkses()
        If LoginDatabase() Then
            Dim info As DataTable = infologin.GetAkses(MySecurity.username, MySecurity.password)
            If Not info Is Nothing Then
                Dim data(info.Rows.Count - 1) As DataAkses
                For i As Integer = 0 To info.Rows.Count - 1
                    data(i).idakses = info.Rows(i).Item("idakses")
                    data(i).username = info.Rows(i).Item("username")
                    data(i).iduser = info.Rows(i).Item("iduser")
                    data(i).idperusahaan = info.Rows(i).Item("idperusahaan")
                Next
                Return data
            End If
        End If
        Return Nothing
    End Function
    Public Structure DataAkses
        Public idakses As Guid
        Public iduser As Guid
        Public idperusahaan As Guid
        Public namaakses As String
        Public username As String
    End Structure

    <WebMethod(), SoapHeader("MySecurity")> _
    Public Function AmbilNamaAkses(ByVal idakses As Guid) As DataAkses()
        If LoginDatabase() Then
            Dim info As DataTable = infologin.GetNamaAkses(idakses)
            If Not info Is Nothing Then
                Dim data(info.Rows.Count - 1) As DataAkses
                For i As Integer = 0 To info.Rows.Count - 1
                    data(i).namaakses = info.Rows(i).Item("namaakses")
                Next
                Return data
            End If
        End If
        Return Nothing
    End Function

    <WebMethod(), SoapHeader("MySecurity")> _
    Public Function AmbilAksesMenu(ByVal idakses As Guid, ByVal namamenu As String) As DataAksesMenu()
        If LoginDatabase() Then
            Dim info As DataTable = infologin.GetAksesMenu(idakses, namamenu)
            If Not info Is Nothing Then
                Dim data(info.Rows.Count - 1) As DataAksesMenu
                For i As Integer = 0 To info.Rows.Count - 1
                    data(i).statusaktif = info.Rows(i).Item("statusaktif")
                Next
                Return data
            End If
        End If
        Return Nothing
    End Function
    Public Structure DataAksesMenu
        Public statusaktif As Boolean
    End Structure
    <WebMethod(), SoapHeader("MySecurity")> _
    Public Sub UbahLastLogin(ByVal iduser As Guid)
        If LoginDatabase() Then
            infologin.EditLastLogin(iduser)
        End If
    End Sub
#End Region
#Region "Perusahaan"
    <WebMethod(), SoapHeader("MySecurity")> _
    Public Function AmbilPerusahaan() As DataPerusahaan()
        If LoginDatabase() Then
            Dim info As DataTable = infoperusahaan.GetPerusahaan()
            If Not info Is Nothing Then
                Dim data(info.Rows.Count - 1) As DataPerusahaan
                For i As Integer = 0 To info.Rows.Count - 1
                    data(i).idperusahaan = info.Rows(i).Item("idperusahaan")
                    data(i).namaperusahaan = info.Rows(i).Item("namaperusahaan")
                    data(i).alamatperusahaan = info.Rows(i).Item("alamatperusahaan")
                    data(i).notelp = info.Rows(i).Item("notelp")
                    data(i).logo = info.Rows(i).Item("logo")
                Next
                Return data
            End If
        End If
        Return Nothing
    End Function
    <WebMethod(), SoapHeader("MySecurity")> _
    Public Function AmbilDataPerusahaan(ByVal idperusahaan As Guid) As DataPerusahaan()
        If LoginDatabase() Then
            Dim info As DataTable = infoperusahaan.GetDataPerusahaan(idperusahaan)
            If Not info Is Nothing Then
                Dim data(info.Rows.Count - 1) As DataPerusahaan
                For i As Integer = 0 To info.Rows.Count - 1
                    data(i).namaperusahaan = info.Rows(i).Item("namaperusahaan")
                    data(i).alamatperusahaan = info.Rows(i).Item("alamatperusahaan")
                    data(i).notelp = info.Rows(i).Item("notelp")
                    data(i).logo = info.Rows(i).Item("logo")
                Next
                Return data
            End If
        End If
        Return Nothing
    End Function
    <WebMethod(), SoapHeader("MySecurity")> _
    Public Function AmbilIDPerusahaan(ByVal namaperusahaan As String) As DataPerusahaan()
        If LoginDatabase() Then
            Dim info As DataTable = infoperusahaan.GetIDPerusahaan(namaperusahaan)
            If Not info Is Nothing Then
                Dim data(info.Rows.Count - 1) As DataPerusahaan
                For i As Integer = 0 To info.Rows.Count - 1
                    data(i).idperusahaan = info.Rows(i).Item("idperusahaan")
                Next
                Return data
            End If
        End If
        Return Nothing
    End Function
    Public Structure DataPerusahaan
        Public idperusahaan As Guid
        Public namaperusahaan As String
        Public alamatperusahaan As String
        Public notelp As String
        Public logo As Byte()
    End Structure
    <WebMethod(), SoapHeader("MySecurity")> _
    Public Sub TambahPerusahaan(ByVal namaperusahaan As String, ByVal alamatperusahaan As String, ByVal notelp As String, ByVal logo As Byte(), ByVal usermodified As String)
        If LoginDatabase() Then
            infoperusahaan.InputPerusahaan(namaperusahaan, alamatperusahaan, notelp, logo, usermodified)
        End If
    End Sub
    <WebMethod(), SoapHeader("MySecurity")> _
    Public Sub UbahPerusahaan(ByVal idperusahaan As Guid, ByVal namaperusahaan As String, ByVal alamatperusahaan As String, ByVal notelp As String, ByVal logo As Byte(), ByVal usermodified As String)
        If LoginDatabase() Then
            infoperusahaan.EditPerusahaan(idperusahaan, namaperusahaan, alamatperusahaan, notelp, logo, usermodified)
        End If
    End Sub
    <WebMethod(), SoapHeader("MySecurity")> _
    Public Sub HapusPerusahaan(ByVal idperusahaan As Guid)
        If LoginDatabase() Then
            infoperusahaan.DeletePerusahaan(idperusahaan)
        End If
    End Sub
#End Region
#Region "Change Password"
    <WebMethod(), SoapHeader("MySecurity")> _
    Public Sub Ubahpassword(ByVal iduser As Guid, ByVal password As String)
        If LoginDatabase() Then
            infopassword.EditPerusahaan(iduser, password)
        End If
    End Sub
#End Region
#Region "Akses"
    <WebMethod(), SoapHeader("MySecurity")> _
    Public Function CheckAksesGroup(ByVal idakses As Guid) As String
        If LoginDatabase() Then
            Dim a As Boolean = infoakses.CekAksesGroup(idakses)
            Return a
        End If
        Return Nothing
    End Function
    <WebMethod(), SoapHeader("MySecurity")> _
    Public Function CheckAkses(ByVal idakses As Guid) As String
        If LoginDatabase() Then
            Dim a As Boolean = infoakses.CekAkses(idakses)
            Return a
        End If
        Return Nothing
    End Function
    <WebMethod(), SoapHeader("MySecurity")> _
    Public Function CheckNamaAkses0(ByVal namaakses As String) As String
        If LoginDatabase() Then
            Dim a As Boolean = infoakses.CekNamaAkses0(namaakses)
            Return a
        End If
        Return Nothing
    End Function
    <WebMethod(), SoapHeader("MySecurity")> _
    Public Function CheckNamaAkses1(ByVal namaakses As String) As String
        If LoginDatabase() Then
            Dim a As Boolean = infoakses.CekNamaAkses1(namaakses)
            Return a
        End If
        Return Nothing
    End Function
    <WebMethod(), SoapHeader("MySecurity")> _
    Public Sub UbahStatusAkses(ByVal namaakses As String, ByVal usermodified As String)
        If LoginDatabase() Then
            infoakses.EditStatusAkses(namaakses, usermodified)
        End If
    End Sub
    <WebMethod(), SoapHeader("MySecurity")> _
    Public Function AmbilMasterAkses() As DataMasterAkses()
        If LoginDatabase() Then
            Dim info As DataTable = infoakses.GetMasterAkses()
            If Not info Is Nothing Then
                Dim data(info.Rows.Count - 1) As DataMasterAkses
                For i As Integer = 0 To info.Rows.Count - 1
                    data(i).idakses = info.Rows(i).Item("idakses")
                    data(i).namaakses = info.Rows(i).Item("namaakses")
                Next
                Return data
            End If
        End If
        Return Nothing
    End Function
    <WebMethod(), SoapHeader("MySecurity")> _
    Public Function AmbilIDMasterAkses(ByVal namaakses As String) As DataMasterAkses()
        If LoginDatabase() Then
            Dim info As DataTable = infoakses.GetIDMasterAkses(namaakses)
            If Not info Is Nothing Then
                Dim data(info.Rows.Count - 1) As DataMasterAkses
                For i As Integer = 0 To info.Rows.Count - 1
                    data(i).idakses = info.Rows(i).Item("idakses")
                Next
                Return data
            End If
        End If
        Return Nothing
    End Function
    Public Structure DataMasterAkses
        Public idakses As Guid
        Public namaakses As String
    End Structure
    <WebMethod(), SoapHeader("MySecurity")> _
    Public Sub TambahAkses(ByVal namaakses As String, ByVal usermodified As String)
        If LoginDatabase() Then
            infoakses.InputMasterAkses(namaakses, usermodified)
        End If
    End Sub
    <WebMethod(), SoapHeader("MySecurity")> _
    Public Sub UbahAkses(ByVal idakses As Guid, ByVal namaakses As String, ByVal usermodified As String)
        If LoginDatabase() Then
            infoakses.EditMasterAkses(idakses, namaakses, usermodified)
        End If
    End Sub
    <WebMethod(), SoapHeader("MySecurity")> _
    Public Sub HapusAkses(ByVal idakses As Guid)
        If LoginDatabase() Then
            infoakses.DeleteMasterAkses(idakses)
        End If
    End Sub
#End Region
#Region "UserMan"
    <WebMethod(), SoapHeader("MySecurity")> _
    Public Function AmbilUserMan() As DataUserMan()
        If LoginDatabase() Then
            Dim info As DataTable = infouser.GetUserMan()
            If Not info Is Nothing Then
                Dim data(info.Rows.Count - 1) As DataUserMan
                For i As Integer = 0 To info.Rows.Count - 1
                    data(i).iduser = info.Rows(i).Item("iduser")
                    data(i).idakses = info.Rows(i).Item("idakses")
                    data(i).username = info.Rows(i).Item("username")
                    data(i).namaakses = info.Rows(i).Item("namaakses")
                Next
                Return data
            End If
        End If
        Return Nothing
    End Function
    <WebMethod(), SoapHeader("MySecurity")> _
    Public Function CheckNamaUser0(ByVal username As String) As String
        If LoginDatabase() Then
            Dim a As Boolean = infouser.CekNamaUser0(username)
            Return a
        End If
        Return Nothing
    End Function
    <WebMethod(), SoapHeader("MySecurity")> _
    Public Function CheckNamaUser1(ByVal username As String) As String
        If LoginDatabase() Then
            Dim a As Boolean = infouser.CekNamaUser1(username)
            Return a
        End If
        Return Nothing
    End Function
    <WebMethod(), SoapHeader("MySecurity")> _
    Public Sub UbahStatusUSer(ByVal username As String, ByVal usermodified As String)
        If LoginDatabase() Then
            infouser.EditStatusUser(username, usermodified)
        End If
    End Sub
    <WebMethod(), SoapHeader("MySecurity")> _
    Public Function AmbilAksesForUserMan() As DataUserMan()
        If LoginDatabase() Then
            Dim info As DataTable = infouser.GetAksesForUserMan()
            If Not info Is Nothing Then
                Dim data(info.Rows.Count - 1) As DataUserMan
                For i As Integer = 0 To info.Rows.Count - 1
                    data(i).idakses = info.Rows(i).Item("idakses")
                    data(i).namaakses = info.Rows(i).Item("namaakses")
                Next
                Return data
            End If
        End If
        Return Nothing
    End Function
    Public Structure DataUserMan
        Public iduser As Guid
        Public idakses As Guid
        Public namaakses As String
        Public username As String
    End Structure
    <WebMethod(), SoapHeader("MySecurity")> _
    Public Sub TambahUser(ByVal username As String, ByVal password As String, ByVal idakses As Guid, ByVal idperusahaan As Guid, ByVal usermodified As String)
        If LoginDatabase() Then
            infouser.InputUserMan(username, password, idakses, idperusahaan, usermodified)
        End If
    End Sub
    <WebMethod(), SoapHeader("MySecurity")> _
    Public Sub UbahUser(ByVal iduser As Guid, ByVal idakses As Guid, ByVal usermodified As String)
        If LoginDatabase() Then
            infouser.EditUserMan(iduser, idakses, usermodified)
        End If
    End Sub
    <WebMethod(), SoapHeader("MySecurity")> _
    Public Sub HapusUser(ByVal iduser As Guid)
        If LoginDatabase() Then
            infouser.DeleteUserMan(iduser)
        End If
    End Sub
    <WebMethod(), SoapHeader("MySecurity")> _
    Public Sub GantiPassword(ByVal iduser As Guid)
        If LoginDatabase() Then
            infouser.ResetPassword(iduser)
        End If
    End Sub
#End Region
#Region "Menu"
    <WebMethod(), SoapHeader("MySecurity")> _
    Public Function CheckMenu(ByVal idmenu As Guid) As String
        If LoginDatabase() Then
            Dim a As Boolean = infomenu.CekMenu(idmenu)
            Return a
        End If
        Return Nothing
    End Function
    <WebMethod(), SoapHeader("MySecurity")> _
    Public Function CheckNamaMenu0(ByVal namamenu As String) As String
        If LoginDatabase() Then
            Dim a As Boolean = infomenu.CekNamaMenu0(namamenu)
            Return a
        End If
        Return Nothing
    End Function
    <WebMethod(), SoapHeader("MySecurity")> _
    Public Function CheckNamaMenu1(ByVal namamenu As String) As String
        If LoginDatabase() Then
            Dim a As Boolean = infomenu.CekNamaMenu1(namamenu)
            Return a
        End If
        Return Nothing
    End Function
    <WebMethod(), SoapHeader("MySecurity")> _
    Public Sub UbahStatusMenu(ByVal namamenu As String, ByVal usermodified As String)
        If LoginDatabase() Then
            infomenu.EditStatusMenu(namamenu, usermodified)
        End If
    End Sub
    <WebMethod(), SoapHeader("MySecurity")> _
    Public Function AmbilMasterMenu() As DataMasterMenu()
        If LoginDatabase() Then
            Dim info As DataTable = infomenu.GetMasterMenu()
            If Not info Is Nothing Then
                Dim data(info.Rows.Count - 1) As DataMasterMenu
                For i As Integer = 0 To info.Rows.Count - 1
                    data(i).idmenu = info.Rows(i).Item("idmenu")
                    data(i).namamenu = info.Rows(i).Item("namamenu")
                Next
                Return data
            End If
        End If
        Return Nothing
    End Function
    <WebMethod(), SoapHeader("MySecurity")> _
    Public Function AmbilIDMasterMenu(ByVal namamenu As String) As DataMasterMenu()
        If LoginDatabase() Then
            Dim info As DataTable = infomenu.GetIDMasterMenu(namamenu)
            If Not info Is Nothing Then
                Dim data(info.Rows.Count - 1) As DataMasterMenu
                For i As Integer = 0 To info.Rows.Count - 1
                    data(i).idmenu = info.Rows(i).Item("idmenu")
                Next
                Return data
            End If
        End If
        Return Nothing
    End Function
    Public Structure DataMasterMenu
        Public idmenu As Guid
        Public namamenu As String
    End Structure
    <WebMethod(), SoapHeader("MySecurity")> _
    Public Sub TambahMenu(ByVal namamenu As String, ByVal usermodified As String)
        If LoginDatabase() Then
            infomenu.InputMasterMenu(namamenu, usermodified)
        End If
    End Sub
    <WebMethod(), SoapHeader("MySecurity")> _
    Public Sub UbahMenu(ByVal idmenu As Guid, ByVal namamenu As String, ByVal usermodified As String)
        If LoginDatabase() Then
            infomenu.EditMasterMenu(idmenu, namamenu, usermodified)
        End If
    End Sub
    <WebMethod(), SoapHeader("MySecurity")> _
    Public Sub HapusMenu(ByVal idmenu As Guid)
        If LoginDatabase() Then
            infomenu.DeleteMasterMenu(idmenu)
        End If
    End Sub
#End Region
#Region "Group Akses"
    <WebMethod(), SoapHeader("MySecurity")> _
    Public Function AmbilCariAkses(ByVal idakses As Guid) As String
        If LoginDatabase() Then
            Dim a As Boolean = infogroupakses.GetCariAkses(idakses)
            Return a
        End If
        Return Nothing
    End Function
    <WebMethod(), SoapHeader("MySecurity")> _
    Public Function AmbilGroupAkses(ByVal idakses As Guid) As GroupAksesData()
        If LoginDatabase() Then
            Dim info As DataTable = infogroupakses.GetGroupAkses(idakses)
            If Not info Is Nothing Then
                Dim data(info.Rows.Count - 1) As GroupAksesData
                For i As Integer = 0 To info.Rows.Count - 1
                    data(i).idgroup = info.Rows(i).Item("idgroup")
                    data(i).idakses = info.Rows(i).Item("idakses")
                    data(i).idmenu = info.Rows(i).Item("idmenu")
                    data(i).namamenu = info.Rows(i).Item("namamenu")
                    data(i).statusaktif = info.Rows(i).Item("statusaktif")
                Next
                Return data
            End If
        End If
        Return Nothing
    End Function
    Public Structure GroupAksesData
        Public idgroup As Guid
        Public idakses As Guid
        Public idmenu As Guid
        Public namamenu As String
        Public statusaktif As Boolean
    End Structure
    <WebMethod(), SoapHeader("MySecurity")> _
    Public Sub TambahGroupAkses(ByVal idakses As Guid, ByVal idmenu As Guid, ByVal usermodified As String, ByVal statusaktif As Boolean)
        If LoginDatabase() Then
            infogroupakses.InputGroupAkses(idakses, idmenu, usermodified, statusaktif)
        End If
    End Sub
    <WebMethod(), SoapHeader("MySecurity")> _
    Public Sub UbahGroupAkses(ByVal statusaktif As Boolean, ByVal idakses As Guid, ByVal idmenu As Guid, ByVal usermodified As String)
        If LoginDatabase() Then
            infogroupakses.EditGroupAkses(statusaktif, idakses, idmenu, usermodified)
        End If
    End Sub
    <WebMethod(), SoapHeader("MySecurity")> _
    Public Function CheckGroupAkses(ByVal idakses As Guid, ByVal idmenu As Guid) As String
        If LoginDatabase() Then
            Dim a As Boolean = infogroupakses.CekGroupAkses(idakses, idmenu)
            Return a
        End If
        Return Nothing
    End Function
#End Region
#Region "Kategori"
    <WebMethod(), SoapHeader("MySecurity")> _
    Public Function CheckKategori(ByVal idkategori As Guid) As String
        If LoginDatabase() Then
            Dim a As Boolean = infokategori.CekKategori(idkategori)
            Return a
        End If
        Return Nothing
    End Function
    <WebMethod(), SoapHeader("MySecurity")> _
    Public Function CheckNamakategori0(ByVal namakategori As String) As String
        If LoginDatabase() Then
            Dim a As Boolean = infokategori.CekNamakategori0(namakategori)
            Return a
        End If
        Return Nothing
    End Function
    <WebMethod(), SoapHeader("MySecurity")> _
    Public Function CheckNamakategori1(ByVal namakategori As String) As String
        If LoginDatabase() Then
            Dim a As Boolean = infokategori.CekNamakategori1(namakategori)
            Return a
        End If
        Return Nothing
    End Function
    <WebMethod(), SoapHeader("MySecurity")> _
    Public Sub UbahStatuskategori(ByVal namakategori As String, ByVal usermodified As String)
        If LoginDatabase() Then
            infokategori.EditStatuskategori(namakategori, usermodified)
        End If
    End Sub
    <WebMethod(), SoapHeader("MySecurity")> _
    Public Function AmbilMasterkategori() As DataMasterkategori()
        If LoginDatabase() Then
            Dim info As DataTable = infokategori.GetMasterkategori()
            If Not info Is Nothing Then
                Dim data(info.Rows.Count - 1) As DataMasterkategori
                For i As Integer = 0 To info.Rows.Count - 1
                    data(i).idkategori = info.Rows(i).Item("idkategori")
                    data(i).namakategori = info.Rows(i).Item("namakategori")
                Next
                Return data
            End If
        End If
        Return Nothing
    End Function
    <WebMethod(), SoapHeader("MySecurity")> _
    Public Function AmbilIDMasterkategori(ByVal namakategori As String) As DataMasterkategori()
        If LoginDatabase() Then
            Dim info As DataTable = infokategori.GetIDMasterkategori(namakategori)
            If Not info Is Nothing Then
                Dim data(info.Rows.Count - 1) As DataMasterkategori
                For i As Integer = 0 To info.Rows.Count - 1
                    data(i).idkategori = info.Rows(i).Item("idkategori")
                Next
                Return data
            End If
        End If
        Return Nothing
    End Function
    Public Structure DataMasterkategori
        Public idkategori As Guid
        Public namakategori As String
    End Structure
    <WebMethod(), SoapHeader("MySecurity")> _
    Public Sub Tambahkategori(ByVal namakategori As String, ByVal usermodified As String)
        If LoginDatabase() Then
            infokategori.InputMasterkategori(namakategori, usermodified)
        End If
    End Sub
    <WebMethod(), SoapHeader("MySecurity")> _
    Public Sub Ubahkategori(ByVal idkategori As Guid, ByVal namakategori As String, ByVal usermodified As String)
        If LoginDatabase() Then
            infokategori.EditMasterkategori(idkategori, namakategori, usermodified)
        End If
    End Sub
    <WebMethod(), SoapHeader("MySecurity")> _
    Public Sub Hapuskategori(ByVal idkategori As Guid)
        If LoginDatabase() Then
            infokategori.DeleteMasterkategori(idkategori)
        End If
    End Sub
#End Region
#Region "Satuan"
    <WebMethod(), SoapHeader("MySecurity")> _
    Public Function CheckSatuan(ByVal idsatuan As Guid) As String
        If LoginDatabase() Then
            Dim a As Boolean = infosatuan.CekSatuan(idsatuan)
            Return a
        End If
        Return Nothing
    End Function
    <WebMethod(), SoapHeader("MySecurity")> _
    Public Function CheckNamasatuan0(ByVal namasatuan As String) As String
        If LoginDatabase() Then
            Dim a As Boolean = infosatuan.CekNamasatuan0(namasatuan)
            Return a
        End If
        Return Nothing
    End Function
    <WebMethod(), SoapHeader("MySecurity")> _
    Public Function CheckNamasatuan1(ByVal namasatuan As String) As String
        If LoginDatabase() Then
            Dim a As Boolean = infosatuan.CekNamasatuan1(namasatuan)
            Return a
        End If
        Return Nothing
    End Function
    <WebMethod(), SoapHeader("MySecurity")> _
    Public Sub UbahStatussatuan(ByVal namasatuan As String, ByVal usermodified As String)
        If LoginDatabase() Then
            infosatuan.EditStatussatuan(namasatuan, usermodified)
        End If
    End Sub
    <WebMethod(), SoapHeader("MySecurity")> _
    Public Function AmbilMastersatuan() As DataMastersatuan()
        If LoginDatabase() Then
            Dim info As DataTable = infosatuan.GetMastersatuan()
            If Not info Is Nothing Then
                Dim data(info.Rows.Count - 1) As DataMastersatuan
                For i As Integer = 0 To info.Rows.Count - 1
                    data(i).idsatuan = info.Rows(i).Item("idsatuan")
                    data(i).namasatuan = info.Rows(i).Item("namasatuan")
                    data(i).konvpcs = info.Rows(i).Item("konvpcs")
                Next
                Return data
            End If
        End If
        Return Nothing
    End Function
    <WebMethod(), SoapHeader("MySecurity")> _
    Public Function AmbilIDMastersatuan(ByVal namasatuan As String) As DataMastersatuan()
        If LoginDatabase() Then
            Dim info As DataTable = infosatuan.GetIDMastersatuan(namasatuan)
            If Not info Is Nothing Then
                Dim data(info.Rows.Count - 1) As DataMastersatuan
                For i As Integer = 0 To info.Rows.Count - 1
                    data(i).idsatuan = info.Rows(i).Item("idsatuan")
                Next
                Return data
            End If
        End If
        Return Nothing
    End Function
    Public Structure DataMastersatuan
        Public idsatuan As Guid
        Public namasatuan As String
        Public konvpcs As Decimal
    End Structure
    <WebMethod(), SoapHeader("MySecurity")> _
    Public Sub Tambahsatuan(ByVal namasatuan As String, ByVal konvpcs As Decimal, ByVal usermodified As String)
        If LoginDatabase() Then
            infosatuan.InputMastersatuan(namasatuan, konvpcs, usermodified)
        End If
    End Sub
    <WebMethod(), SoapHeader("MySecurity")> _
    Public Sub Ubahsatuan(ByVal idsatuan As Guid, ByVal namasatuan As String, ByVal konvpcs As Decimal, ByVal usermodified As String)
        If LoginDatabase() Then
            infosatuan.EditMastersatuan(idsatuan, namasatuan, konvpcs, usermodified)
        End If
    End Sub
    <WebMethod(), SoapHeader("MySecurity")> _
    Public Sub Hapussatuan(ByVal idsatuan As Guid)
        If LoginDatabase() Then
            infosatuan.DeleteMastersatuan(idsatuan)
        End If
    End Sub
#End Region
#Region "Supplier"
    <WebMethod(), SoapHeader("MySecurity")> _
    Public Function AmbilMastersupplier() As DataMastersupplier()
        If LoginDatabase() Then
            Dim info As DataTable = infosupplier.GetMastersupplier()
            If Not info Is Nothing Then
                Dim data(info.Rows.Count - 1) As DataMastersupplier
                For i As Integer = 0 To info.Rows.Count - 1
                    data(i).idsupplier = info.Rows(i).Item("idsupplier")
                    data(i).namasupplier = info.Rows(i).Item("namasupplier")
                    data(i).alamatsupplier = info.Rows(i).Item("alamatsupplier")
                    data(i).nohpsupplier = info.Rows(i).Item("nohpsupplier")
                Next
                Return data
            End If
        End If
        Return Nothing
    End Function
    <WebMethod(), SoapHeader("MySecurity")> _
    Public Function AmbilIDMastersupplier(ByVal namasupplier As String) As DataMastersupplier()
        If LoginDatabase() Then
            Dim info As DataTable = infosupplier.GetIDMastersupplier(namasupplier)
            If Not info Is Nothing Then
                Dim data(info.Rows.Count - 1) As DataMastersupplier
                For i As Integer = 0 To info.Rows.Count - 1
                    data(i).idsupplier = info.Rows(i).Item("idsupplier")
                Next
                Return data
            End If
        End If
        Return Nothing
    End Function
    <WebMethod(), SoapHeader("MySecurity")> _
    Public Function CheckSupplier(ByVal idsupplier As Guid) As String
        If LoginDatabase() Then
            Dim a As Boolean = infosupplier.CekSupplier(idsupplier)
            Return a
        End If
        Return Nothing
    End Function
    <WebMethod(), SoapHeader("MySecurity")> _
    Public Function CheckNamasupplier0(ByVal namasupplier As String) As String
        If LoginDatabase() Then
            Dim a As Boolean = infosupplier.CekNamasupplier0(namasupplier)
            Return a
        End If
        Return Nothing
    End Function
    <WebMethod(), SoapHeader("MySecurity")> _
    Public Function CheckNamasupplier1(ByVal namasupplier As String) As String
        If LoginDatabase() Then
            Dim a As Boolean = infosupplier.CekNamasupplier1(namasupplier)
            Return a
        End If
        Return Nothing
    End Function
    <WebMethod(), SoapHeader("MySecurity")> _
    Public Sub UbahStatussupplier(ByVal namasupplier As String, ByVal usermodified As String)
        If LoginDatabase() Then
            infosupplier.EditStatussupplier(namasupplier, usermodified)
        End If
    End Sub
    <WebMethod(), SoapHeader("MySecurity")> _
    Public Function SearchSupplier(ByVal namasupplier As String) As DataMastersupplier()
        If LoginDatabase() Then
            Dim info As DataTable = infosupplier.CariSupplier(namasupplier)
            If Not info Is Nothing Then
                Dim data(info.Rows.Count - 1) As DataMastersupplier
                For i As Integer = 0 To info.Rows.Count - 1
                    data(i).idsupplier = info.Rows(i).Item("idsupplier")
                    data(i).idsupplier = info.Rows(i).Item("idsupplier")
                    data(i).namasupplier = info.Rows(i).Item("namasupplier")
                    data(i).alamatsupplier = info.Rows(i).Item("alamatsupplier")
                    data(i).nohpsupplier = info.Rows(i).Item("nohpsupplier")
                Next
                Return data
            End If
        End If
        Return Nothing
    End Function
    Public Structure DataMastersupplier
        Public idsupplier As Guid
        Public namasupplier As String
        Public alamatsupplier As String
        Public nohpsupplier As String
    End Structure
    <WebMethod(), SoapHeader("MySecurity")> _
    Public Sub Tambahsupplier(ByVal namasupplier As String, ByVal alamatsupplier As String, ByVal nohpsupplier As String, ByVal usermodified As String)
        If LoginDatabase() Then
            infosupplier.InputMastersupplier(namasupplier, alamatsupplier, nohpsupplier, usermodified)
        End If
    End Sub
    <WebMethod(), SoapHeader("MySecurity")> _
    Public Sub Ubahsupplier(ByVal idsupplier As Guid, ByVal namasupplier As String, ByVal alamatsupplier As String, ByVal nohpsupplier As String, ByVal usermodified As String)
        If LoginDatabase() Then
            infosupplier.EditMastersupplier(idsupplier, namasupplier, alamatsupplier, nohpsupplier, usermodified)
        End If
    End Sub
    <WebMethod(), SoapHeader("MySecurity")> _
    Public Sub Hapussupplier(ByVal idsupplier As Guid)
        If LoginDatabase() Then
            infosupplier.DeleteMastersupplier(idsupplier)
        End If
    End Sub
#End Region
#Region "Item"
    <WebMethod(), SoapHeader("MySecurity")> _
    Public Function AmbilMasterItem() As DataMasterItem()
        If LoginDatabase() Then
            Dim info As DataTable = infoitem.GetMasterItem()
            If Not info Is Nothing Then
                Dim data(info.Rows.Count - 1) As DataMasterItem
                For i As Integer = 0 To info.Rows.Count - 1
                    data(i).iditem = info.Rows(i).Item("iditem")
                    data(i).idkategori = info.Rows(i).Item("idkategori")
                    data(i).idsatuan = info.Rows(i).Item("idsatuan")
                    data(i).namakategori = info.Rows(i).Item("namakategori")
                    data(i).kodeitem = info.Rows(i).Item("kodeitem")
                    data(i).namaitem = info.Rows(i).Item("namaitem")
                    data(i).hargaperpcs = info.Rows(i).Item("hargaperpcs")
                    data(i).harga = info.Rows(i).Item("harga")
                    data(i).namasatuan = info.Rows(i).Item("namasatuan")
                Next
                Return data
            End If
        End If
        Return Nothing
    End Function
    <WebMethod(), SoapHeader("MySecurity")> _
    Public Function AmbilIDMasterItem(ByVal namaitem As String) As DataMasterItem()
        If LoginDatabase() Then
            Dim info As DataTable = infoitem.GetIDMasterItem(namaitem)
            If Not info Is Nothing Then
                Dim data(info.Rows.Count - 1) As DataMasterItem
                For i As Integer = 0 To info.Rows.Count - 1
                    data(i).iditem = info.Rows(i).Item("iditem")
                Next
                Return data
            End If
        End If
        Return Nothing
    End Function
    <WebMethod(), SoapHeader("MySecurity")> _
    Public Function Checkitem(ByVal iditem As Guid) As String
        If LoginDatabase() Then
            Dim a As Boolean = infoitem.CekItem(iditem)
            Return a
        End If
        Return Nothing
    End Function
    <WebMethod(), SoapHeader("MySecurity")> _
    Public Function CheckNamaitem0(ByVal namaitem As String) As String
        If LoginDatabase() Then
            Dim a As Boolean = infoitem.CekNamaitem0(namaitem)
            Return a
        End If
        Return Nothing
    End Function
    <WebMethod(), SoapHeader("MySecurity")> _
    Public Function CheckNamaitem1(ByVal namaitem As String) As String
        If LoginDatabase() Then
            Dim a As Boolean = infoitem.CekNamaitem1(namaitem)
            Return a
        End If
        Return Nothing
    End Function
    <WebMethod(), SoapHeader("MySecurity")> _
    Public Function Checkkodeitem0(ByVal kodeitem As String) As String
        If LoginDatabase() Then
            Dim a As Boolean = infoitem.CekkodeItem0(kodeitem)
            Return a
        End If
        Return Nothing
    End Function
    <WebMethod(), SoapHeader("MySecurity")> _
    Public Function Checkkodeitem1(ByVal kodeitem As String) As String
        If LoginDatabase() Then
            Dim a As Boolean = infoitem.CekkodeItem1(kodeitem)
            Return a
        End If
        Return Nothing
    End Function
    <WebMethod(), SoapHeader("MySecurity")> _
    Public Sub UbahStatusitem(ByVal namaitem As String, ByVal usermodified As String)
        If LoginDatabase() Then
            infoitem.EditStatusitem(namaitem, usermodified)
        End If
    End Sub
    <WebMethod(), SoapHeader("MySecurity")> _
    Public Sub UbahStatusitembyKode(ByVal kodeitem As String, ByVal usermodified As String)
        If LoginDatabase() Then
            infoitem.EditStatusitem(kodeitem, usermodified)
        End If
    End Sub
    <WebMethod(), SoapHeader("MySecurity")> _
    Public Function SearchItem(ByVal namaitem As String) As DataMasterItem()
        If LoginDatabase() Then
            Dim info As DataTable = infoitem.CariItem(namaitem)
            If Not info Is Nothing Then
                Dim data(info.Rows.Count - 1) As DataMasterItem
                For i As Integer = 0 To info.Rows.Count - 1
                    data(i).iditem = info.Rows(i).Item("iditem")
                    data(i).idkategori = info.Rows(i).Item("idkategori")
                    data(i).idsatuan = info.Rows(i).Item("idsatuan")
                    data(i).namakategori = info.Rows(i).Item("namakategori")
                    data(i).kodeitem = info.Rows(i).Item("kodeitem")
                    data(i).namaitem = info.Rows(i).Item("namaitem")
                    data(i).hargaperpcs = info.Rows(i).Item("hargaperpcs")
                    data(i).harga = info.Rows(i).Item("harga")
                    data(i).namasatuan = info.Rows(i).Item("namasatuan")
                Next
                Return data
            End If
        End If
        Return Nothing
    End Function
    Public Structure DataMasterItem
        Public iditem As Guid
        Public idkategori As Guid
        Public idsatuan As Guid
        Public namakategori As String
        Public kodeitem As String
        Public namaitem As String
        Public hargaperpcs As Decimal
        Public harga As Decimal
        Public namasatuan As String
    End Structure
    <WebMethod(), SoapHeader("MySecurity")> _
    Public Sub TambahItem(ByVal idkategori As Guid, ByVal kodeitem As String, ByVal namaitem As String, ByVal hargaperpcs As Decimal, ByVal harga As Decimal, ByVal idsatuan As Guid, ByVal usermodified As String)
        If LoginDatabase() Then
            infoitem.InputMasterItem(idkategori, kodeitem, namaitem, hargaperpcs, harga, idsatuan, usermodified)
        End If
    End Sub
    <WebMethod(), SoapHeader("MySecurity")> _
    Public Sub UbahItem(ByVal idkategori As Guid, ByVal kodeitem As String, ByVal namaitem As String, ByVal hargaperpcs As Decimal, ByVal harga As Decimal, ByVal idsatuan As Guid, ByVal usermodified As String, ByVal iditem As Guid)
        If LoginDatabase() Then
            infoitem.EditMasterItem(idkategori, kodeitem, namaitem, hargaperpcs, harga, idsatuan, usermodified, iditem)
        End If
    End Sub
    <WebMethod(), SoapHeader("MySecurity")> _
    Public Sub HapusItem(ByVal iditem As Guid)
        If LoginDatabase() Then
            infoitem.DeleteMasterItem(iditem)
        End If
    End Sub
#End Region
#Region "Consumtions"
    <WebMethod(), SoapHeader("MySecurity")> _
    Public Function CheckCons(ByVal iditemjasa As Guid, ByVal namaitem As String) As String
        If LoginDatabase() Then
            Dim a As Boolean = infocons.CekCons(iditemjasa, namaitem)
            Return a
        End If
        Return Nothing
    End Function
    <WebMethod(), SoapHeader("MySecurity")> _
    Public Function AmbilMasterCons() As DataCons()
        If LoginDatabase() Then
            Dim info As DataTable = infocons.GetCons()
            If Not info Is Nothing Then
                Dim data(info.Rows.Count - 1) As DataCons
                For i As Integer = 0 To info.Rows.Count - 1
                    data(i).idcons = info.Rows(i).Item("idcons")
                    data(i).iditemjasa = info.Rows(i).Item("iditemjasa")
                    data(i).namaitem = info.Rows(i).Item("namaitem")
                    data(i).namajasa = info.Rows(i).Item("namajasa")
                    data(i).qtycons = info.Rows(i).Item("qtycons")
                Next
                Return data
            End If
        End If
        Return Nothing
    End Function
    <WebMethod(), SoapHeader("MySecurity")> _
    Public Function AmbilListJasa() As DataCons()
        If LoginDatabase() Then
            Dim info As DataTable = infocons.GetListJasa()
            If Not info Is Nothing Then
                Dim data(info.Rows.Count - 1) As DataCons
                For i As Integer = 0 To info.Rows.Count - 1
                    data(i).iditem = info.Rows(i).Item("iditem")
                    data(i).namaitem = info.Rows(i).Item("namaitem")
                Next
                Return data
            End If
        End If
        Return Nothing
    End Function
    <WebMethod(), SoapHeader("MySecurity")> _
    Public Function AmbilListItem() As DataCons()
        If LoginDatabase() Then
            Dim info As DataTable = infocons.GetListItem()
            If Not info Is Nothing Then
                Dim data(info.Rows.Count - 1) As DataCons
                For i As Integer = 0 To info.Rows.Count - 1
                    data(i).iditem = info.Rows(i).Item("iditem")
                    data(i).namaitem = info.Rows(i).Item("namaitem")
                Next
                Return data
            End If
        End If
        Return Nothing
    End Function
    <WebMethod(), SoapHeader("MySecurity")> _
    Public Function AmbilIDJasa(ByVal namaitem As String) As DataCons()
        If LoginDatabase() Then
            Dim info As DataTable = infocons.GetIDJasa(namaitem)
            If Not info Is Nothing Then
                Dim data(info.Rows.Count - 1) As DataCons
                For i As Integer = 0 To info.Rows.Count - 1
                    data(i).iditem = info.Rows(i).Item("iditem")
                Next
                Return data
            End If
        End If
        Return Nothing
    End Function
    Public Structure DataCons
        Public idcons As Guid
        Public iditem As Guid
        Public iditemjasa As Guid
        Public qtycons As Decimal
        Public namaitem As String
        Public namajasa As String
    End Structure
    <WebMethod(), SoapHeader("MySecurity")> _
    Public Sub TambahCons(ByVal iditemjasa As Guid, ByVal namaitem As String, ByVal qtycons As Decimal, ByVal usermodified As String)
        If LoginDatabase() Then
            infocons.InputCons(iditemjasa, namaitem, qtycons, usermodified)
        End If
    End Sub
    <WebMethod(), SoapHeader("MySecurity")> _
    Public Sub HapusCons(ByVal idcons As Guid)
        If LoginDatabase() Then
            infocons.DeleteCons(idcons)
        End If
    End Sub
#End Region
#Region "Pembelian"
    <WebMethod(), SoapHeader("MySecurity")> _
    Public Function AmbilListItemBeli() As ListDataItem()
        If LoginDatabase() Then
            Dim info As DataTable = infobeli.GetListItem()
            If Not info Is Nothing Then
                Dim data(info.Rows.Count - 1) As ListDataItem
                For i As Integer = 0 To info.Rows.Count - 1
                    data(i).iditem = info.Rows(i).Item("iditem")
                    data(i).namaitem = info.Rows(i).Item("namaitem")
                Next
                Return data
            End If
        End If
        Return Nothing
    End Function
    Public Structure ListDataItem
        Public iditem As Guid
        Public namaitem As String
    End Structure
    <WebMethod(), SoapHeader("MySecurity")> _
    Public Function AmbilListSupplier() As ListDataSupplier()
        If LoginDatabase() Then
            Dim info As DataTable = infobeli.GetListSupplier()
            If Not info Is Nothing Then
                Dim data(info.Rows.Count - 1) As ListDataSupplier
                For i As Integer = 0 To info.Rows.Count - 1
                    data(i).idsupplier = info.Rows(i).Item("idsupplier")
                    data(i).namasupplier = info.Rows(i).Item("namasupplier")
                Next
                Return data
            End If
        End If
        Return Nothing
    End Function
    Public Structure ListDataSupplier
        Public idsupplier As Guid
        Public namasupplier As String
    End Structure
    <WebMethod(), SoapHeader("MySecurity")> _
    Public Function AmbilListSatuan() As ListDatasatuan()
        If LoginDatabase() Then
            Dim info As DataTable = infobeli.GetListSatuan()
            If Not info Is Nothing Then
                Dim data(info.Rows.Count - 1) As ListDatasatuan
                For i As Integer = 0 To info.Rows.Count - 1
                    data(i).idsatuan = info.Rows(i).Item("idsatuan")
                    data(i).namasatuan = info.Rows(i).Item("namasatuan")
                Next
                Return data
            End If
        End If
        Return Nothing
    End Function
    Public Structure ListDatasatuan
        Public idsatuan As Guid
        Public namasatuan As String
    End Structure
    <WebMethod(), SoapHeader("MySecurity")> _
    Public Function AmbilListUratan(ByVal tahun As Integer) As ListDataUrutan()
        If LoginDatabase() Then
            Dim info As DataTable = infobeli.GetUrutan(tahun)
            If Not info Is Nothing Then
                Dim data(info.Rows.Count - 1) As ListDataUrutan
                For i As Integer = 0 To info.Rows.Count - 1
                    data(i).tahun = info.Rows(i).Item("tahun")
                    data(i).urut = info.Rows(i).Item("urut")
                Next
                Return data
            End If
        End If
        Return Nothing
    End Function
    Public Structure ListDataUrutan
        Public tahun As Integer
        Public urut As Integer
    End Structure
    <WebMethod(), SoapHeader("MySecurity")> _
    Public Sub TambahUrutan(ByVal tahun As Integer, ByVal urut As Integer)
        If LoginDatabase() Then
            infobeli.InputUrutan(tahun, urut)
        End If
    End Sub
    <WebMethod(), SoapHeader("MySecurity")> _
    Public Sub UpdateUrutan(ByVal tahun As Integer, ByVal urut As Integer)
        If LoginDatabase() Then
            infobeli.EditUrutan(tahun, urut)
        End If
    End Sub
    <WebMethod(), SoapHeader("MySecurity")> _
    Public Sub UpdateHargaItem(ByVal iditem As Guid, ByVal hargaperpcs As Decimal, ByVal harga As Decimal, ByVal idsatuan As Guid, ByVal usermodified As String)
        If LoginDatabase() Then
            infobeli.EditHargaItem(iditem, hargaperpcs, harga, idsatuan, usermodified)
        End If
    End Sub
    <WebMethod(), SoapHeader("MySecurity")> _
    Public Function CekStock(ByVal iditem As Guid) As String
        If LoginDatabase() Then
            Dim a As Boolean = infobeli.GetStock(iditem)
            Return a
        End If
        Return Nothing
    End Function
    <WebMethod(), SoapHeader("MySecurity")> _
    Public Function AmbilDataStock(ByVal iditem As Guid) As ListDataStock()
        If LoginDatabase() Then
            Dim info As DataTable = infobeli.GetDataStock(iditem)
            If Not info Is Nothing Then
                Dim data(info.Rows.Count - 1) As ListDataStock
                For i As Integer = 0 To info.Rows.Count - 1
                    data(i).iditem = info.Rows(i).Item("iditem")
                    data(i).jumlahstock = info.Rows(i).Item("jumlahstock")
                Next
                Return data
            End If
        End If
        Return Nothing
    End Function
    Public Structure ListDataStock
        Public idstock As Guid
        Public iditem As Guid
        Public jumlahstock As Decimal
    End Structure
    <WebMethod(), SoapHeader("MySecurity")> _
    Public Sub TambahStock(ByVal iditem As Guid, ByVal jumlahstock As Decimal, ByVal usermodified As String)
        If LoginDatabase() Then
            infobeli.InputStock(iditem, jumlahstock, usermodified)
        End If
    End Sub
    <WebMethod(), SoapHeader("MySecurity")> _
    Public Sub UpdateStock(ByVal jumlahstock As Decimal, ByVal usermodified As String, ByVal iditem As Guid)
        If LoginDatabase() Then
            infobeli.EditStock(jumlahstock, usermodified, iditem)
        End If
    End Sub
    <WebMethod(), SoapHeader("MySecurity")> _
    Public Sub TambahBeli(ByVal iditem As Guid, ByVal idsupplier As Guid, ByVal iduser As Guid, ByVal nopemasukan As String, ByVal tanggalmasuk As DateTime, ByVal jumlahitem As Decimal, ByVal hargabeliperpcs As Decimal, ByVal hargabeli As Decimal, ByVal idsatuan As Guid, ByVal usermodified As String)
        If LoginDatabase() Then
            infobeli.InputBeli(iditem, idsupplier, iduser, nopemasukan, tanggalmasuk, jumlahitem, hargabeliperpcs, hargabeli, idsatuan, usermodified)
        End If
    End Sub
    <WebMethod(), SoapHeader("MySecurity")> _
    Public Function Ambilkodeharga(ByVal namaitem As String) As datakodeharga()
        If LoginDatabase() Then
            Dim info As DataTable = infobeli.Getkodeharga(namaitem)
            If Not info Is Nothing Then
                Dim data(info.Rows.Count - 1) As datakodeharga
                For i As Integer = 0 To info.Rows.Count - 1
                    data(i).iditem = info.Rows(i).Item("iditem")
                    data(i).kodeitem = info.Rows(i).Item("kodeitem")
                    data(i).harga = info.Rows(i).Item("harga")
                    data(i).hargaperpcs = info.Rows(i).Item("hargaperpcs")
                    data(i).namasatuan = info.Rows(i).Item("namasatuan")
                Next
                Return data
            End If
        End If
        Return Nothing
    End Function
    Public Structure datakodeharga
        Public iditem As Guid
        Public kodeitem As String
        Public harga As Decimal
        Public hargaperpcs As Decimal
        Public namasatuan As String
    End Structure
    <WebMethod(), SoapHeader("MySecurity")> _
    Public Function Ambilkonvpcs(ByVal namasatuan As String) As datakonvpcs()
        If LoginDatabase() Then
            Dim info As DataTable = infobeli.Getkonvpcs(namasatuan)
            If Not info Is Nothing Then
                Dim data(info.Rows.Count - 1) As datakonvpcs
                For i As Integer = 0 To info.Rows.Count - 1
                    data(i).konvpcs = info.Rows(i).Item("konvpcs")
                Next
                Return data
            End If
        End If
        Return Nothing
    End Function
    Public Structure datakonvpcs
        Public konvpcs As Decimal
    End Structure
#End Region
#Region "Penjualan"
    <WebMethod(), SoapHeader("MySecurity")> _
    Public Function AmbilListUratanJual(ByVal tahun As Integer) As ListDataUrutanJual()
        If LoginDatabase() Then
            Dim info As DataTable = infojual.GetUrutanJual(tahun)
            If Not info Is Nothing Then
                Dim data(info.Rows.Count - 1) As ListDataUrutanJual
                For i As Integer = 0 To info.Rows.Count - 1
                    data(i).tahun = info.Rows(i).Item("tahun")
                    data(i).urut = info.Rows(i).Item("urut")
                Next
                Return data
            End If
        End If
        Return Nothing
    End Function
    Public Structure ListDataUrutanJual
        Public tahun As Integer
        Public urut As Integer
    End Structure
    <WebMethod(), SoapHeader("MySecurity")> _
    Public Function AmbilConsJasa(ByVal iditemjasa As Guid) As ListConsJasa()
        If LoginDatabase() Then
            Dim info As DataTable = infojual.GetConsJasa(iditemjasa)
            If Not info Is Nothing Then
                Dim data(info.Rows.Count - 1) As ListConsJasa
                For i As Integer = 0 To info.Rows.Count - 1
                    data(i).iditemjasa = info.Rows(i).Item("iditemjasa")
                    data(i).namaitem = info.Rows(i).Item("namaitem")
                    data(i).qtycons = info.Rows(i).Item("qtycons")
                Next
                Return data
            End If
        End If
        Return Nothing
    End Function
    Public Structure ListConsJasa
        Public iditemjasa As Guid
        Public namaitem As String
        Public qtycons As Decimal
    End Structure
    <WebMethod(), SoapHeader("MySecurity")> _
    Public Function AmbilKategoriItem(ByVal namaitem As String) As ListNamaKategori()
        If LoginDatabase() Then
            Dim info As DataTable = infojual.GetKategoriItem(namaitem)
            If Not info Is Nothing Then
                Dim data(info.Rows.Count - 1) As ListNamaKategori
                For i As Integer = 0 To info.Rows.Count - 1
                    data(i).namakategori = info.Rows(i).Item("namakategori")
                Next
                Return data
            End If
        End If
        Return Nothing
    End Function
    Public Structure ListNamaKategori
        Public namakategori As String
    End Structure
    <WebMethod(), SoapHeader("MySecurity")> _
    Public Sub TambahUrutanJual(ByVal tahun As Integer, ByVal urut As Integer)
        If LoginDatabase() Then
            infojual.InputUrutanJual(tahun, urut)
        End If
    End Sub
    <WebMethod(), SoapHeader("MySecurity")> _
    Public Sub UpdateUrutanJual(ByVal tahun As Integer, ByVal urut As Integer)
        If LoginDatabase() Then
            infojual.EditUrutanJual(tahun, urut)
        End If
    End Sub
    <WebMethod(), SoapHeader("MySecurity")> _
    Public Sub TambahJual(ByVal iduser As Guid, ByVal iditem As Guid, ByVal nopengeluaran As String, ByVal tanggalkeluar As DateTime, ByVal jumlahkeluar As Decimal, ByVal idsatuan As Guid, ByVal hargajual As Decimal, ByVal diskon As Decimal, ByVal keterangan As String, ByVal remark As String, ByVal usermodified As String)
        If LoginDatabase() Then
            infojual.InputJual(iduser, iditem, nopengeluaran, tanggalkeluar, jumlahkeluar, idsatuan, hargajual, diskon, keterangan, remark, usermodified)
        End If
    End Sub
    <WebMethod(), SoapHeader("MySecurity")> _
    Public Sub TambahJualKepala(ByVal iduser As Guid, ByVal idmulti As Guid, ByVal nopengeluaran As String, ByVal tanggalkeluar As DateTime, ByVal jumlahkeluar As Decimal, ByVal idsatuan As Guid, ByVal hargajual As Decimal, ByVal diskon As Decimal, ByVal keterangan As String, ByVal remark As String, ByVal usermodified As String)
        If LoginDatabase() Then
            infojual.InputJualKepala(iduser, idmulti, nopengeluaran, tanggalkeluar, jumlahkeluar, idsatuan, hargajual, diskon, keterangan, remark, usermodified)
        End If
    End Sub
    <WebMethod(), SoapHeader("MySecurity")> _
    Public Sub TambahJualMulti(ByVal iduser As Guid, ByVal iditem As Guid, ByVal idmulti As Guid, ByVal nopengeluaran As String, ByVal tanggalkeluar As DateTime, ByVal jumlahkeluar As Decimal, ByVal idsatuan As Guid, ByVal hargajual As Decimal, ByVal diskon As Decimal, ByVal keterangan As String, ByVal remark As String, ByVal usermodified As String)
        If LoginDatabase() Then
            infojual.InputJualMulti(iduser, iditem, idmulti, nopengeluaran, tanggalkeluar, jumlahkeluar, idsatuan, hargajual, diskon, keterangan, remark, usermodified)
        End If
    End Sub
#End Region
#Region "Report"
    <WebMethod(), SoapHeader("MySecurity")> _
    Public Function AmbilDataInvoice2(ByVal nopengeluaran As String) As DataInvoice()
        If LoginDatabase() Then
            Dim info As DataTable = inforeport.GetDataInvoice(nopengeluaran)
            If Not info Is Nothing Then
                Dim data(info.Rows.Count - 1) As DataInvoice
                For i As Integer = 0 To info.Rows.Count - 1
                    data(i).idpengeluaran = info.Rows(i).Item("idpengeluaran")
                    data(i).nopengeluaran = info.Rows(i).Item("nopengeluaran")
                    data(i).tanggalkeluar = info.Rows(i).Item("tanggalkeluar")
                    data(i).jumlahkeluar = info.Rows(i).Item("jumlahkeluar")
                    data(i).hargajual = info.Rows(i).Item("hargajual")
                    If IsDBNull(info.Rows(i).Item("namaitem")) Then
                        data(i).namaitem = "-"
                    Else
                        data(i).namaitem = info.Rows(i).Item("namaitem")
                    End If
                    data(i).namasatuan = info.Rows(i).Item("namasatuan")
                    data(i).diskon = info.Rows(i).Item("diskon")
                    data(i).usermodified = info.Rows(i).Item("usermodified")
                    If IsDBNull(info.Rows(i).Item("remark")) Then
                        data(i).remark = "-"
                    Else
                        data(i).remark = info.Rows(i).Item("remark")
                    End If
                    data(i).keterangan = info.Rows(i).Item("keterangan")
                    data(i).logo = info.Rows(i).Item("logo")
                    data(i).namaperusahaan = info.Rows(i).Item("namaperusahaan")
                    data(i).alamatperusahaan = info.Rows(i).Item("alamatperusahaan")
                    data(i).notelp = info.Rows(i).Item("notelp")
                Next
                Return data
            End If
        End If
        Return Nothing
    End Function
    Public Structure DataInvoice
        Public idpengeluaran As Guid
        Public nopengeluaran As String
        Public tanggalkeluar As DateTime
        Public jumlahkeluar As Decimal
        Public hargajual As Decimal
        Public namaitem As String
        Public namasatuan As String
        Public diskon As Decimal
        Public namaperusahaan As String
        Public alamatperusahaan As String
        Public notelp As String
        Public usermodified As String
        Public remark As String
        Public keterangan As String
        Public logo As Byte()
    End Structure
    <WebMethod(), SoapHeader("MySecurity")> _
    Public Function AmbilDataPembelian(ByVal tgl1 As DateTime, ByVal tgl2 As DateTime) As DataRptPembelian()
        If LoginDatabase() Then
            Dim info As DataTable = inforeport.GetDataPembelian(tgl1, tgl2)
            If Not info Is Nothing Then
                Dim data(info.Rows.Count - 1) As DataRptPembelian
                For i As Integer = 0 To info.Rows.Count - 1
                    data(i).nopemasukan = info.Rows(i).Item("nopemasukan")
                    data(i).tanggalmasuk = info.Rows(i).Item("tanggalmasuk")
                    data(i).namaitem = info.Rows(i).Item("namaitem")
                    data(i).jumlahitem = info.Rows(i).Item("jumlahitem")
                    data(i).hargabeliperpcs = info.Rows(i).Item("hargabeliperpcs")
                    data(i).namasatuan = info.Rows(i).Item("namasatuan")
                    data(i).namasupplier = info.Rows(i).Item("namasupplier")
                    data(i).total = info.Rows(i).Item("total")
                Next
                Return data
            End If
        End If
        Return Nothing
    End Function
    Public Structure DataRptPembelian
        Public nopemasukan As String
        Public tanggalmasuk As DateTime
        Public namaitem As String
        Public jumlahitem As Decimal
        Public hargabeliperpcs As Decimal
        Public namasatuan As String
        Public namasupplier As String
        Public total As Decimal
    End Structure
    <WebMethod(), SoapHeader("MySecurity")> _
    Public Function AmbilDataReturnIn(ByVal tgl1 As DateTime, ByVal tgl2 As DateTime) As DataRptReturnIn()
        If LoginDatabase() Then
            Dim info As DataTable = inforeport.GetDataReturnIn(tgl1, tgl2)
            If Not info Is Nothing Then
                Dim data(info.Rows.Count - 1) As DataRptReturnIn
                For i As Integer = 0 To info.Rows.Count - 1
                    data(i).nori = info.Rows(i).Item("nori")
                    data(i).createdate = info.Rows(i).Item("createdate")
                    data(i).namaitem = info.Rows(i).Item("namaitem")
                    data(i).jumlahri = info.Rows(i).Item("jumlahri")
                    data(i).harga = info.Rows(i).Item("harga")
                    data(i).namasatuan = info.Rows(i).Item("namasatuan")
                    data(i).nopengeluaran = info.Rows(i).Item("nopengeluaran")
                    data(i).total = info.Rows(i).Item("total")
                    data(i).remark = info.Rows(i).Item("remark")
                Next
                Return data
            End If
        End If
        Return Nothing
    End Function
    Public Structure DataRptReturnIn
        Public nori As String
        Public createdate As DateTime
        Public namaitem As String
        Public jumlahri As Decimal
        Public namasatuan As String
        Public harga As Decimal
        Public total As Decimal
        Public nopengeluaran As String
        Public remark As String
    End Structure
    <WebMethod(), SoapHeader("MySecurity")> _
    Public Function AmbilDataReturnOut(ByVal tgl1 As DateTime, ByVal tgl2 As DateTime) As DataRptReturnOut()
        If LoginDatabase() Then
            Dim info As DataTable = inforeport.GetDataReturnOut(tgl1, tgl2)
            If Not info Is Nothing Then
                Dim data(info.Rows.Count - 1) As DataRptReturnOut
                For i As Integer = 0 To info.Rows.Count - 1
                    data(i).noro = info.Rows(i).Item("noro")
                    data(i).createdate = info.Rows(i).Item("createdate")
                    data(i).namaitem = info.Rows(i).Item("namaitem")
                    data(i).jumlahro = info.Rows(i).Item("jumlahro")
                    data(i).harga = info.Rows(i).Item("harga")
                    data(i).namasatuan = info.Rows(i).Item("namasatuan")
                    data(i).nopemasukan = info.Rows(i).Item("nopemasukan")
                    data(i).total = info.Rows(i).Item("total")
                    data(i).remark = info.Rows(i).Item("remark")
                    data(i).sentto = info.Rows(i).Item("sentto")
                Next
                Return data
            End If
        End If
        Return Nothing
    End Function
    Public Structure DataRptReturnOut
        Public noro As String
        Public createdate As DateTime
        Public namaitem As String
        Public jumlahro As Decimal
        Public namasatuan As String
        Public harga As Decimal
        Public total As Decimal
        Public nopemasukan As String
        Public remark As String
        Public sentto As String
    End Structure
    <WebMethod(), SoapHeader("MySecurity")> _
    Public Function AmbilDataStockRpt() As DataRptStock()
        If LoginDatabase() Then
            Dim info As DataTable = inforeport.GetDataStock()
            If Not info Is Nothing Then
                Dim data(info.Rows.Count - 1) As DataRptStock
                For i As Integer = 0 To info.Rows.Count - 1
                    data(i).namaitem = info.Rows(i).Item("namaitem")
                    data(i).jumlahstock = info.Rows(i).Item("jumlahstock")
                Next
                Return data
            End If
        End If
        Return Nothing
    End Function
    Public Structure DataRptStock
        Public namaitem As String
        Public jumlahstock As Decimal
    End Structure
    <WebMethod(), SoapHeader("MySecurity")> _
    Public Function AmbilDataPenjualan(ByVal tgl1 As DateTime, ByVal tgl2 As DateTime) As DataRptPenjualan()
        If LoginDatabase() Then
            Dim info As DataTable = inforeport.GetDataPenjualan(tgl1, tgl2)
            If Not info Is Nothing Then
                Dim data(info.Rows.Count - 1) As DataRptPenjualan
                For i As Integer = 0 To info.Rows.Count - 1
                    data(i).nopengeluaran = info.Rows(i).Item("nopengeluaran")
                    data(i).tanggalkeluar = info.Rows(i).Item("tanggalkeluar")
                    If IsDBNull(info.Rows(i).Item("namaitem")) Then
                        data(i).namaitem = "-"
                    Else
                        data(i).namaitem = info.Rows(i).Item("namaitem")
                    End If
                    data(i).jumlahkeluar = info.Rows(i).Item("jumlahkeluar")
                    data(i).hargajual = info.Rows(i).Item("hargajual")
                    data(i).namasatuan = info.Rows(i).Item("namasatuan")
                    data(i).diskon = info.Rows(i).Item("diskon")
                    data(i).total = info.Rows(i).Item("total")
                    If IsDBNull(info.Rows(i).Item("remark")) Then
                        data(i).remark = "-"
                    Else
                        data(i).remark = info.Rows(i).Item("remark")
                    End If
                Next
                Return data
            End If
        End If
        Return Nothing
    End Function
    Public Structure DataRptPenjualan
        Public nopengeluaran As String
        Public tanggalkeluar As DateTime
        Public namaitem As String
        Public jumlahkeluar As Decimal
        Public namasatuan As String
        Public hargajual As Decimal
        Public total As Decimal
        Public diskon As Decimal
        Public remark As String
    End Structure
#End Region
#Region "Return Out"
    <WebMethod(), SoapHeader("MySecurity")> _
    Public Function AmbilListUratanRO(ByVal tahun As Integer) As ListDataUrutanRO()
        If LoginDatabase() Then
            Dim info As DataTable = inforo.GetUrutanRo(tahun)
            If Not info Is Nothing Then
                Dim data(info.Rows.Count - 1) As ListDataUrutanRO
                For i As Integer = 0 To info.Rows.Count - 1
                    data(i).tahun = info.Rows(i).Item("tahun")
                    data(i).urut = info.Rows(i).Item("urut")
                    data(i).kode = info.Rows(i).Item("kode")
                Next
                Return data
            End If
        End If
        Return Nothing
    End Function
    Public Structure ListDataUrutanRO
        Public tahun As Integer
        Public urut As Integer
        Public kode As String
    End Structure
    <WebMethod(), SoapHeader("MySecurity")> _
    Public Sub TambahUrutanRO(ByVal tahun As Integer, ByVal urut As Integer, ByVal kode As String)
        If LoginDatabase() Then
            inforo.InputUrutanRo(tahun, urut, kode)
        End If
    End Sub
    <WebMethod(), SoapHeader("MySecurity")> _
    Public Sub UpdateUrutanRO(ByVal tahun As Integer, ByVal urut As Integer)
        If LoginDatabase() Then
            inforo.EditUrutanRo(tahun, urut)
        End If
    End Sub
    <WebMethod(), SoapHeader("MySecurity")> _
    Public Function AmbilNoBeli() As ListCmbRo()
        If LoginDatabase() Then
            Dim info As DataTable = inforo.GetNoBeli()
            If Not info Is Nothing Then
                Dim data(info.Rows.Count - 1) As ListCmbRo
                For i As Integer = 0 To info.Rows.Count - 1
                    data(i).nopemasukan = info.Rows(i).Item("nopemasukan")
                Next
                Return data
            End If
        End If
        Return Nothing
    End Function
    <WebMethod(), SoapHeader("MySecurity")> _
    Public Function AmbilNamaItem(ByVal nopemasukan As String) As ListCmbRo()
        If LoginDatabase() Then
            Dim info As DataTable = inforo.GetNamaItem(nopemasukan)
            If Not info Is Nothing Then
                Dim data(info.Rows.Count - 1) As ListCmbRo
                For i As Integer = 0 To info.Rows.Count - 1
                    data(i).namaitem = info.Rows(i).Item("namaitem")
                Next
                Return data
            End If
        End If
        Return Nothing
    End Function
    Public Structure ListCmbRo
        Public nopemasukan As String
        Public namaitem As String
    End Structure
    <WebMethod(), SoapHeader("MySecurity")> _
    Public Function AmbilDataBeli(ByVal iditem As Guid) As ListisianRO()
        If LoginDatabase() Then
            Dim info As DataTable = inforo.GetDataBeli(iditem)
            If Not info Is Nothing Then
                Dim data(info.Rows.Count - 1) As ListisianRO
                For i As Integer = 0 To info.Rows.Count - 1
                    data(i).jumlahitem = info.Rows(i).Item("jumlahitem")
                    data(i).namasatuan = info.Rows(i).Item("namasatuan")
                    data(i).hargabeliperpcs = info.Rows(i).Item("hargabeliperpcs")
                    data(i).namasupplier = info.Rows(i).Item("namasupplier")
                Next
                Return data
            End If
        End If
        Return Nothing
    End Function
    Public Structure ListisianRO
        Public jumlahitem As Decimal
        Public namasatuan As String
        Public hargabeliperpcs As Decimal
        Public namasupplier As String
    End Structure
    <WebMethod(), SoapHeader("MySecurity")> _
    Public Function AmbilIDBeli(ByVal nopemasukan As String) As ListIDBeli()
        If LoginDatabase() Then
            Dim info As DataTable = inforo.GetIDBeli(nopemasukan)
            If Not info Is Nothing Then
                Dim data(info.Rows.Count - 1) As ListIDBeli
                For i As Integer = 0 To info.Rows.Count - 1
                    data(i).idpemasukan = info.Rows(i).Item("idpemasukan")
                Next
                Return data
            End If
        End If
        Return Nothing
    End Function
    Public Structure ListIDBeli
        Public idpemasukan As Guid
    End Structure
    <WebMethod(), SoapHeader("MySecurity")> _
    Public Sub TambahRO(ByVal idpemasukan As Guid, ByVal iditem As Guid, ByVal noro As String, ByVal jumlahro As Decimal, ByVal idsatuan As Guid, ByVal harga As Decimal, ByVal sentto As String, ByVal remark As String, ByVal usermodified As String)
        If LoginDatabase() Then
            inforo.InputRO(idpemasukan, iditem, noro, jumlahro, idsatuan, harga, sentto, remark, usermodified)
        End If
    End Sub
    <WebMethod(), SoapHeader("MySecurity")> _
    Public Function AmbilQtyRo(ByVal nop As String, ByVal namaitem As String) As QtyRo()
        If LoginDatabase() Then
            Dim info As DataTable = inforo.GetQtyRo(nop, namaitem)
            If Not info Is Nothing Then
                Dim data(info.Rows.Count - 1) As QtyRo
                For i As Integer = 0 To info.Rows.Count - 1
                    data(i).jumlahro = info.Rows(i).Item("jumlahro")
                Next
                Return data
            End If
        End If
        Return Nothing
    End Function
    Public Structure QtyRo
        Public jumlahro As Decimal
    End Structure
#End Region
#Region "Return IN"
    <WebMethod(), SoapHeader("MySecurity")> _
    Public Function AmbilListUratanRI(ByVal tahun As Integer) As ListDataUrutanRI()
        If LoginDatabase() Then
            Dim info As DataTable = infori.GetUrutanRi(tahun)
            If Not info Is Nothing Then
                Dim data(info.Rows.Count - 1) As ListDataUrutanRI
                For i As Integer = 0 To info.Rows.Count - 1
                    data(i).tahun = info.Rows(i).Item("tahun")
                    data(i).urut = info.Rows(i).Item("urut")
                    data(i).kode = info.Rows(i).Item("kode")
                Next
                Return data
            End If
        End If
        Return Nothing
    End Function
    Public Structure ListDataUrutanRI
        Public tahun As Integer
        Public urut As Integer
        Public kode As String
    End Structure
    <WebMethod(), SoapHeader("MySecurity")> _
    Public Sub TambahUrutanRI(ByVal tahun As Integer, ByVal urut As Integer, ByVal kode As String)
        If LoginDatabase() Then
            infori.InputUrutanRi(tahun, urut, kode)
        End If
    End Sub
    <WebMethod(), SoapHeader("MySecurity")> _
    Public Sub UpdateUrutanRI(ByVal tahun As Integer, ByVal urut As Integer)
        If LoginDatabase() Then
            infori.EditUrutanRi(tahun, urut)
        End If
    End Sub
    <WebMethod(), SoapHeader("MySecurity")> _
    Public Function AmbilNoJual() As ListCmbRi()
        If LoginDatabase() Then
            Dim info As DataTable = infori.GetNoJual()
            If Not info Is Nothing Then
                Dim data(info.Rows.Count - 1) As ListCmbRi
                For i As Integer = 0 To info.Rows.Count - 1
                    data(i).nopengeluaran = info.Rows(i).Item("nopengeluaran")
                Next
                Return data
            End If
        End If
        Return Nothing
    End Function
    <WebMethod(), SoapHeader("MySecurity")> _
    Public Function AmbilIDJual(ByVal nopengeluaran As String) As ListIDJual()
        If LoginDatabase() Then
            Dim info As DataTable = infori.GetIDJual(nopengeluaran)
            If Not info Is Nothing Then
                Dim data(info.Rows.Count - 1) As ListIDJual
                For i As Integer = 0 To info.Rows.Count - 1
                    data(i).idpengeluaran = info.Rows(i).Item("idpengeluaran")
                Next
                Return data
            End If
        End If
        Return Nothing
    End Function
    Public Structure ListIDJual
        Public idpengeluaran As Guid
    End Structure
    <WebMethod(), SoapHeader("MySecurity")> _
    Public Function AmbilNamaItemJual(ByVal nopengeluaran As String) As ListCmbRi()
        If LoginDatabase() Then
            Dim info As DataTable = infori.GetNamaItemJual(nopengeluaran)
            If Not info Is Nothing Then
                Dim data(info.Rows.Count - 1) As ListCmbRi
                For i As Integer = 0 To info.Rows.Count - 1
                    data(i).remark = info.Rows(i).Item("remark")
                    data(i).keterangan = info.Rows(i).Item("keterangan")
                Next
                Return data
            End If
        End If
        Return Nothing
    End Function
    <WebMethod(), SoapHeader("MySecurity")> _
    Public Function AmbilDataItemJualMulti(ByVal nopengeluaran As String) As ListCmbRi()
        If LoginDatabase() Then
            Dim info As DataTable = infori.GetDataItemJualMulti(nopengeluaran)
            If Not info Is Nothing Then
                Dim data(info.Rows.Count - 1) As ListCmbRi
                For i As Integer = 0 To info.Rows.Count - 1
                    data(i).remark = info.Rows(i).Item("remark")
                Next
                Return data
            End If
        End If
        Return Nothing
    End Function
    Public Structure ListCmbRi
        Public nopengeluaran As String
        Public remark As String
        Public keterangan As String
    End Structure
    <WebMethod(), SoapHeader("MySecurity")> _
    Public Function AmbilDataJual(ByVal iditem As Guid) As ListisianRI()
        If LoginDatabase() Then
            Dim info As DataTable = infori.GetDataJual(iditem)
            If Not info Is Nothing Then
                Dim data(info.Rows.Count - 1) As ListisianRI
                For i As Integer = 0 To info.Rows.Count - 1
                    data(i).jumlahkeluar = info.Rows(i).Item("jumlahkeluar")
                    data(i).namasatuan = info.Rows(i).Item("namasatuan")
                    data(i).hargajual = info.Rows(i).Item("hargajual")
                Next
                Return data
            End If
        End If
        Return Nothing
    End Function
    <WebMethod(), SoapHeader("MySecurity")> _
    Public Function AmbilDataJual2(ByVal remark As String, ByVal nopengeluaran As String) As ListisianRI()
        If LoginDatabase() Then
            Dim info As DataTable = infori.GetDataJual2(remark, nopengeluaran)
            If Not info Is Nothing Then
                Dim data(info.Rows.Count - 1) As ListisianRI
                For i As Integer = 0 To info.Rows.Count - 1
                    data(i).jumlahkeluar = info.Rows(i).Item("jumlahkeluar")
                    data(i).namasatuan = info.Rows(i).Item("namasatuan")
                    data(i).hargajual = info.Rows(i).Item("hargajual")
                Next
                Return data
            End If
        End If
        Return Nothing
    End Function
    Public Structure ListisianRI
        Public jumlahkeluar As Decimal
        Public namasatuan As String
        Public hargajual As Decimal
    End Structure
    <WebMethod(), SoapHeader("MySecurity")> _
    Public Sub TambahRI(ByVal idpengeluaran As Guid, ByVal iditem As Guid, ByVal nori As String, ByVal jumlahri As Decimal, ByVal harga As Decimal, ByVal idsatuan As Guid, ByVal remark As String, ByVal usermodified As String)
        If LoginDatabase() Then
            infori.InputRI(idpengeluaran, iditem, nori, jumlahri, harga, idsatuan, remark, usermodified)
        End If
    End Sub
    <WebMethod(), SoapHeader("MySecurity")> _
    Public Sub TambahRI2(ByVal idpengeluaran As Guid, ByVal nori As String, ByVal jumlahri As Decimal, ByVal harga As Decimal, ByVal idsatuan As Guid, ByVal remark As String, ByVal usermodified As String, ByVal remarkitem As String)
        If LoginDatabase() Then
            infori.InputRI2(idpengeluaran, nori, jumlahri, harga, idsatuan, remark, usermodified, remarkitem)
        End If
    End Sub
    <WebMethod(), SoapHeader("MySecurity")> _
    Public Function AmbilQtyRi(ByVal nop As String, ByVal namaitem As String) As QtyRi()
        If LoginDatabase() Then
            Dim info As DataTable = infori.GetQtyRi(nop, namaitem)
            If Not info Is Nothing Then
                Dim data(info.Rows.Count - 1) As QtyRi
                For i As Integer = 0 To info.Rows.Count - 1
                    data(i).jumlahri = info.Rows(i).Item("jumlahri")
                Next
                Return data
            End If
        End If
        Return Nothing
    End Function
    Public Structure QtyRi
        Public jumlahri As Decimal
    End Structure
#End Region
#Region "Closing"
    <WebMethod(), SoapHeader("MySecurity")> _
    Public Function AmbilDataNonjasa(ByVal tanggalkeluar As Date, ByVal tanggalkeluar2 As Date) As DataClosing()
        If LoginDatabase() Then
            Dim info As DataTable = infoclosing.GetDataNonjasa(tanggalkeluar, tanggalkeluar2)
            If Not info Is Nothing Then
                Dim data(info.Rows.Count - 1) As DataClosing
                For i As Integer = 0 To info.Rows.Count - 1
                    If Not IsDBNull(info.Rows(i).Item("idmulti")) Then
                        data(i).idmulti = info.Rows(i).Item("idmulti")
                    End If
                    data(i).nopengeluaran = info.Rows(i).Item("nopengeluaran")
                    If Not IsDBNull(info.Rows(i).Item("namaitem")) Then
                        data(i).namaitem = info.Rows(i).Item("namaitem")
                    Else
                        data(i).namaitem = "-"
                    End If
                    data(i).qtypcs = info.Rows(i).Item("qtypcs")
                    data(i).jualpcs = info.Rows(i).Item("jualpcs")
                    data(i).amountjual = info.Rows(i).Item("amountjual")
                    data(i).diskon = info.Rows(i).Item("diskon")
                    data(i).remark = info.Rows(i).Item("remark")
                    data(i).keterangan = info.Rows(i).Item("keterangan")
                    If Not IsDBNull(info.Rows(i).Item("belipcs")) Then
                        data(i).belipcs = info.Rows(i).Item("belipcs")
                    End If
                    If Not IsDBNull(info.Rows(i).Item("amountbeli")) Then
                        data(i).amountbeli = info.Rows(i).Item("amountbeli")
                    End If
                    data(i).tanggalkeluar = info.Rows(i).Item("tanggalkeluar")
                Next
                Return data
            End If
        End If
        Return Nothing
    End Function
    <WebMethod(), SoapHeader("MySecurity")> _
    Public Function AmbilDataJasa(ByVal tanggalkeluar As Date, ByVal tanggalkeluar2 As Date) As DataClosing()
        If LoginDatabase() Then
            Dim info As DataTable = infoclosing.GetDataJasa(tanggalkeluar, tanggalkeluar2)
            If Not info Is Nothing Then
                Dim data(info.Rows.Count - 1) As DataClosing
                For i As Integer = 0 To info.Rows.Count - 1
                    If Not IsDBNull(info.Rows(i).Item("idmulti")) Then
                        data(i).idmulti = info.Rows(i).Item("idmulti")
                    End If
                    data(i).nopengeluaran = info.Rows(i).Item("nopengeluaran")
                    If Not IsDBNull(info.Rows(i).Item("namaitem")) Then
                        data(i).namaitem = info.Rows(i).Item("namaitem")
                    Else
                        data(i).namaitem = "-"
                    End If
                    data(i).qtypcs = info.Rows(i).Item("qtypcs")
                    data(i).jualpcs = info.Rows(i).Item("jualpcs")
                    data(i).amountjual = info.Rows(i).Item("amountjual")
                    data(i).diskon = info.Rows(i).Item("diskon")
                    data(i).remark = info.Rows(i).Item("remark")
                    data(i).keterangan = info.Rows(i).Item("keterangan")
                    If Not IsDBNull(info.Rows(i).Item("belipcs")) Then
                        data(i).belipcs = info.Rows(i).Item("belipcs")
                    End If
                    If Not IsDBNull(info.Rows(i).Item("amountbeli")) Then
                        data(i).amountbeli = info.Rows(i).Item("amountbeli")
                    End If
                    data(i).tanggalkeluar = info.Rows(i).Item("tanggalkeluar")
                Next
                Return data
            End If
        End If
        Return Nothing
    End Function
    <WebMethod(), SoapHeader("MySecurity")> _
    Public Function AmbilDataMulti(ByVal tanggalkeluar As Date, ByVal tanggalkeluar2 As Date) As DataClosing()
        If LoginDatabase() Then
            Dim info As DataTable = infoclosing.GetDataMulti(tanggalkeluar, tanggalkeluar2)
            If Not info Is Nothing Then
                Dim data(info.Rows.Count - 1) As DataClosing
                For i As Integer = 0 To info.Rows.Count - 1
                    If Not IsDBNull(info.Rows(i).Item("idmulti")) Then
                        data(i).idmulti = info.Rows(i).Item("idmulti")
                    End If
                    data(i).nopengeluaran = info.Rows(i).Item("nopengeluaran")
                    If Not IsDBNull(info.Rows(i).Item("namaitem")) Then
                        data(i).namaitem = info.Rows(i).Item("namaitem")
                    Else
                        data(i).namaitem = "-"
                    End If
                    data(i).qtypcs = info.Rows(i).Item("qtypcs")
                    data(i).jualpcs = info.Rows(i).Item("jualpcs")
                    data(i).amountjual = info.Rows(i).Item("amountjual")
                    data(i).diskon = info.Rows(i).Item("diskon")
                    data(i).remark = info.Rows(i).Item("remark")
                    data(i).keterangan = info.Rows(i).Item("keterangan")
                    If Not IsDBNull(info.Rows(i).Item("belipcs")) Then
                        data(i).belipcs = info.Rows(i).Item("belipcs")
                    End If
                    If Not IsDBNull(info.Rows(i).Item("amountbeli")) Then
                        data(i).amountbeli = info.Rows(i).Item("amountbeli")
                    End If
                    data(i).tanggalkeluar = info.Rows(i).Item("tanggalkeluar")
                Next
                Return data
            End If
        End If
        Return Nothing
    End Function
    Public Structure DataClosing
        Public idtemp As Guid
        Public idmulti As Guid
        Public nopengeluaran As String
        Public namaitem As String
        Public qtypcs As Decimal
        Public jualpcs As Decimal
        Public amountjual As Decimal
        Public diskon As Decimal
        Public remark As String
        Public keterangan As String
        Public belipcs As Decimal
        Public amountbeli As Decimal
        Public tanggalkeluar As Date
        Public closing As String
        Public lastmodified As DateTime
        Public usermodified As String
    End Structure
    <WebMethod(), SoapHeader("MySecurity")> _
    Public Function CheckClosing(ByVal closing As String) As String
        If LoginDatabase() Then
            Dim a As Boolean = infoclosing.CekClosing(closing)
            Return a
        End If
        Return Nothing
    End Function
    <WebMethod(), SoapHeader("MySecurity")> _
    Public Sub TambahClosing(ByVal idmulti As Guid, ByVal nopengeluaran As String, ByVal namaitem As String, ByVal qtypcs As Decimal, ByVal jualpcs As Decimal, ByVal amountjual As Decimal, ByVal diskon As Decimal, ByVal remark As String, ByVal keterangan As String, ByVal belipcs As Decimal, ByVal amountbeli As Decimal, ByVal tanggalkeluar As DateTime, ByVal closing As String, ByVal usermodified As String)
        If LoginDatabase() Then
            infoclosing.InputClosing(idmulti, nopengeluaran, namaitem, qtypcs, jualpcs, amountjual, diskon, remark, keterangan, belipcs, amountbeli, tanggalkeluar, closing, usermodified)
        End If
    End Sub
    <WebMethod(), SoapHeader("MySecurity")> _
    Public Sub HapusClosing(ByVal closing As String)
        If LoginDatabase() Then
            infoclosing.DeleteClosing(closing)
        End If
    End Sub
    <WebMethod(), SoapHeader("MySecurity")> _
    Public Function AmbilDataClosing(ByVal closing As String) As DataClosing()
        If LoginDatabase() Then
            Dim info As DataTable = infoclosing.GetDataClosing(closing)
            If Not info Is Nothing Then
                Dim data(info.Rows.Count - 1) As DataClosing
                For i As Integer = 0 To info.Rows.Count - 1
                    If Not IsDBNull(info.Rows(i).Item("idtemp")) Then
                        data(i).idtemp = info.Rows(i).Item("idtemp")
                    End If
                    If Not IsDBNull(info.Rows(i).Item("idmulti")) Then
                        data(i).idmulti = info.Rows(i).Item("idmulti")
                    End If
                    data(i).nopengeluaran = info.Rows(i).Item("nopengeluaran")
                    If Not IsDBNull(info.Rows(i).Item("namaitem")) Then
                        data(i).namaitem = info.Rows(i).Item("namaitem")
                    Else
                        data(i).namaitem = "-"
                    End If
                    data(i).qtypcs = info.Rows(i).Item("qtypcs")
                    data(i).jualpcs = info.Rows(i).Item("jualpcs")
                    data(i).amountjual = info.Rows(i).Item("amountjual")
                    data(i).diskon = info.Rows(i).Item("diskon")
                    data(i).remark = info.Rows(i).Item("remark")
                    data(i).keterangan = info.Rows(i).Item("keterangan")
                    If Not IsDBNull(info.Rows(i).Item("belipcs")) Then
                        data(i).belipcs = info.Rows(i).Item("belipcs")
                    End If
                    If Not IsDBNull(info.Rows(i).Item("amountbeli")) Then
                        data(i).amountbeli = info.Rows(i).Item("amountbeli")
                    End If
                    data(i).tanggalkeluar = info.Rows(i).Item("tanggalkeluar")
                    data(i).closing = info.Rows(i).Item("closing")
                Next
                Return data
            End If
        End If
        Return Nothing
    End Function
#End Region
End Class