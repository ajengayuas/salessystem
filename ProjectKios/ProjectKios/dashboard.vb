Imports x = ProjectKios.ServiceReference1
Public Class dashboard
    Public user As String = ""
    Public pass As String = ""
    Public idakses As Guid
    Public iduser As Guid
    Public idperusahaan As Guid
    Private _mySrv As New x.WebService1SoapClient
    Private _secure As New x.AutentikasiUser
    Private _namaakses As x.DataAkses()
    Private _aksesmenu As x.DataAksesMenu()
    Private _dataperusahaan As x.DataPerusahaan()

    Private Sub btnexit_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub

    Private Sub PictureBox6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox6.Click
        Login.txtpassword.Clear()
        Me.Close()
    End Sub

    Private Sub dashboard_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        getAccessControl()
        _mySrv.UbahLastLogin(_secure, iduser)
        _namaakses = _mySrv.AmbilNamaAkses(_secure, idakses)
        _dataperusahaan = _mySrv.AmbilDataPerusahaan(_secure, idperusahaan)
        If _dataperusahaan.Length = 0 Then Exit Sub
        lblperusahaan.Text = _dataperusahaan(0).namaperusahaan
        pblogo.Image = KonversiByteArrayToImage(_dataperusahaan(0).logo)
        btnmaster.Enabled = False
        btntransaksi.Enabled = False
        btnreport.Enabled = False
        btnsetting.Enabled = False
        iconmaster.Enabled = False
        icontransaksi.Enabled = False
        iconreport.Enabled = False
        iconsetting.Enabled = False
        btnkategori.Enabled = False
        btnsatuan.Enabled = False
        btnsupplier.Enabled = False
        btnitem.Enabled = False
        btnbeli.Enabled = False
        btnkasir.Enabled = False
        btnro.Enabled = False
        btnri.Enabled = False
        btndatabeli.Enabled = False
        btndatajual.Enabled = False
        btndatastock.Enabled = False
        btndataro.Enabled = False
        btndatari.Enabled = False
        btndatakeu.Enabled = False
        btnchange.Enabled = False
        btnuserman.Enabled = False
        btnperusahaan.Enabled = False
        btnakses.Enabled = False
        btnmenu.Enabled = False
        btngroup.Enabled = False
        panelmaster.Visible = False
        paneltransaksi.Visible = False
        panelreport.Visible = False
        panelsetting.Visible = False
        pbmaster.Visible = False
        pbtransaksi.Visible = False
        pbreport.Visible = False
        pbsetting.Visible = False
        lbluser.Text = user.ToUpper
        lblakses.Text = _namaakses(0).namaakses
        lbltanggal.Text = Date.Now.Day & "/" & Date.Now.Month & "/" & Date.Now.Year
        lbljam.Text = Now().ToString("hh:mm:ss")
        _aksesmenu = _mySrv.AmbilAksesMenu(_secure, idakses, btnmaster.Text.ToLower)
        If _aksesmenu.Length > 0 Then
            If _aksesmenu(0).statusaktif = True Then
                btnmaster.Enabled = True
                iconmaster.Enabled = True
            End If
        End If
        _aksesmenu = _mySrv.AmbilAksesMenu(_secure, idakses, btntransaksi.Text.ToLower)
        If _aksesmenu.Length > 0 Then
            If _aksesmenu(0).statusaktif = True Then
                btntransaksi.Enabled = True
                icontransaksi.Enabled = True
            End If
        End If
        _aksesmenu = _mySrv.AmbilAksesMenu(_secure, idakses, btnreport.Text.ToLower)
        If _aksesmenu.Length > 0 Then
            If _aksesmenu(0).statusaktif = True Then
                btnreport.Enabled = True
                iconreport.Enabled = True
            End If
        End If
        _aksesmenu = _mySrv.AmbilAksesMenu(_secure, idakses, btnsetting.Text.ToLower)
        If _aksesmenu.Length > 0 Then
            If _aksesmenu(0).statusaktif = True Then
                btnsetting.Enabled = True
                iconsetting.Enabled = True
            End If
        End If
        _aksesmenu = _mySrv.AmbilAksesMenu(_secure, idakses, btnkategori.Text.ToLower)
        If _aksesmenu.Length > 0 Then
            If _aksesmenu(0).statusaktif = True Then btnkategori.Enabled = True
        End If
        _aksesmenu = _mySrv.AmbilAksesMenu(_secure, idakses, btnsatuan.Text.ToLower)
        If _aksesmenu.Length > 0 Then
            If _aksesmenu(0).statusaktif = True Then btnsatuan.Enabled = True
        End If
        _aksesmenu = _mySrv.AmbilAksesMenu(_secure, idakses, btnsupplier.Text.ToLower)
        If _aksesmenu.Length > 0 Then
            If _aksesmenu(0).statusaktif = True Then btnsupplier.Enabled = True
        End If
        _aksesmenu = _mySrv.AmbilAksesMenu(_secure, idakses, btnitem.Text.ToLower)
        If _aksesmenu.Length > 0 Then
            If _aksesmenu(0).statusaktif = True Then btnitem.Enabled = True
        End If
        _aksesmenu = _mySrv.AmbilAksesMenu(_secure, idakses, btnbeli.Text.ToLower)
        If _aksesmenu.Length > 0 Then
            If _aksesmenu(0).statusaktif = True Then btnbeli.Enabled = True
        End If
        _aksesmenu = _mySrv.AmbilAksesMenu(_secure, idakses, btnkasir.Text.ToLower)
        If _aksesmenu.Length > 0 Then
            If _aksesmenu(0).statusaktif = True Then btnkasir.Enabled = True
        End If
        _aksesmenu = _mySrv.AmbilAksesMenu(_secure, idakses, btnro.Text.ToLower)
        If _aksesmenu.Length > 0 Then
            If _aksesmenu(0).statusaktif = True Then btnro.Enabled = True
        End If
        _aksesmenu = _mySrv.AmbilAksesMenu(_secure, idakses, btnri.Text.ToLower)
        If _aksesmenu.Length > 0 Then
            If _aksesmenu(0).statusaktif = True Then btnri.Enabled = True
        End If
        _aksesmenu = _mySrv.AmbilAksesMenu(_secure, idakses, btndatabeli.Text.ToLower)
        If _aksesmenu.Length > 0 Then
            If _aksesmenu(0).statusaktif = True Then btndatabeli.Enabled = True
        End If
        _aksesmenu = _mySrv.AmbilAksesMenu(_secure, idakses, btndatajual.Text.ToLower)
        If _aksesmenu.Length > 0 Then
            If _aksesmenu(0).statusaktif = True Then btndatajual.Enabled = True
        End If
        _aksesmenu = _mySrv.AmbilAksesMenu(_secure, idakses, btndatastock.Text.ToLower)
        If _aksesmenu.Length > 0 Then
            If _aksesmenu(0).statusaktif = True Then btndatastock.Enabled = True
        End If
        _aksesmenu = _mySrv.AmbilAksesMenu(_secure, idakses, btndataro.Text.ToLower)
        If _aksesmenu.Length > 0 Then
            If _aksesmenu(0).statusaktif = True Then btndataro.Enabled = True
        End If
        _aksesmenu = _mySrv.AmbilAksesMenu(_secure, idakses, btndatari.Text.ToLower)
        If _aksesmenu.Length > 0 Then
            If _aksesmenu(0).statusaktif = True Then btndatari.Enabled = True
        End If
        _aksesmenu = _mySrv.AmbilAksesMenu(_secure, idakses, btnchange.Text.ToLower)
        If _aksesmenu.Length > 0 Then
            If _aksesmenu(0).statusaktif = True Then btnchange.Enabled = True
        End If
        _aksesmenu = _mySrv.AmbilAksesMenu(_secure, idakses, btnuserman.Text.ToLower)
        If _aksesmenu.Length > 0 Then
            If _aksesmenu(0).statusaktif = True Then btnuserman.Enabled = True
        End If
        _aksesmenu = _mySrv.AmbilAksesMenu(_secure, idakses, btnperusahaan.Text.ToLower)
        If _aksesmenu.Length > 0 Then
            If _aksesmenu(0).statusaktif = True Then btnperusahaan.Enabled = True
        End If
        _aksesmenu = _mySrv.AmbilAksesMenu(_secure, idakses, btnakses.Text.ToLower)
        If _aksesmenu.Length > 0 Then
            If _aksesmenu(0).statusaktif = True Then btnakses.Enabled = True
        End If
        _aksesmenu = _mySrv.AmbilAksesMenu(_secure, idakses, btnmenu.Text.ToLower)
        If _aksesmenu.Length > 0 Then
            If _aksesmenu(0).statusaktif = True Then btnmenu.Enabled = True
        End If
        _aksesmenu = _mySrv.AmbilAksesMenu(_secure, idakses, btngroup.Text.ToLower)
        If _aksesmenu.Length > 0 Then
            If _aksesmenu(0).statusaktif = True Then btngroup.Enabled = True
        End If
        _aksesmenu = _mySrv.AmbilAksesMenu(_secure, idakses, btnreprint.Text.ToLower)
        If _aksesmenu.Length > 0 Then
            If _aksesmenu(0).statusaktif = True Then btnreprint.Enabled = True
        End If
        _aksesmenu = _mySrv.AmbilAksesMenu(_secure, idakses, btndatakeu.Text.ToLower)
        If _aksesmenu.Length > 0 Then
            If _aksesmenu(0).statusaktif = True Then btndatakeu.Enabled = True
        End If
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        lbljam.Text = Now().ToString("hh:mm:ss")
    End Sub

    Private Sub btnmaster_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnmaster.Click
        panelmaster.Visible = True
        paneltransaksi.Visible = False
        panelreport.Visible = False
        panelsetting.Visible = False
        pbmaster.Visible = True
        pbtransaksi.Visible = False
        pbreport.Visible = False
        pbsetting.Visible = False
    End Sub

    Private Sub btntransaksi_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btntransaksi.Click
        panelmaster.Visible = False
        paneltransaksi.Visible = True
        panelreport.Visible = False
        panelsetting.Visible = False
        pbmaster.Visible = False
        pbtransaksi.Visible = True
        pbreport.Visible = False
        pbsetting.Visible = False
    End Sub

    Private Sub btnreport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnreport.Click
        panelmaster.Visible = False
        paneltransaksi.Visible = False
        panelreport.Visible = True
        panelsetting.Visible = False
        pbmaster.Visible = False
        pbtransaksi.Visible = False
        pbreport.Visible = True
        pbsetting.Visible = False
    End Sub

    Private Sub btnsetting_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnsetting.Click
        panelmaster.Visible = False
        paneltransaksi.Visible = False
        panelreport.Visible = False
        panelsetting.Visible = True
        pbmaster.Visible = False
        pbtransaksi.Visible = False
        pbreport.Visible = False
        pbsetting.Visible = True
    End Sub

    Private Sub iconmaster_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles iconmaster.Click
        panelmaster.Visible = True
        paneltransaksi.Visible = False
        panelreport.Visible = False
        panelsetting.Visible = False
        pbmaster.Visible = True
        pbtransaksi.Visible = False
        pbreport.Visible = False
        pbsetting.Visible = False
    End Sub

    Private Sub icontransaksi_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles icontransaksi.Click
        panelmaster.Visible = False
        paneltransaksi.Visible = True
        panelreport.Visible = False
        panelsetting.Visible = False
        pbmaster.Visible = False
        pbtransaksi.Visible = True
        pbreport.Visible = False
        pbsetting.Visible = False
    End Sub

    Private Sub iconreport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles iconreport.Click
        panelmaster.Visible = False
        paneltransaksi.Visible = False
        panelreport.Visible = True
        panelsetting.Visible = False
        pbmaster.Visible = False
        pbtransaksi.Visible = False
        pbreport.Visible = True
        pbsetting.Visible = False
    End Sub

    Private Sub iconsetting_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles iconsetting.Click
        panelmaster.Visible = False
        paneltransaksi.Visible = False
        panelreport.Visible = False
        panelsetting.Visible = True
        pbmaster.Visible = False
        pbtransaksi.Visible = False
        pbreport.Visible = False
        pbsetting.Visible = True
    End Sub

    Private Sub btnperusahaan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnperusahaan.Click
        System.Windows.Forms.Cursor.Current = Cursors.WaitCursor
        Dim f As New masterperusahaan
        f.user = user
        f.pass = pass
        f.ShowDialog()
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

    Private Sub btnchange_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnchange.Click
        System.Windows.Forms.Cursor.Current = Cursors.WaitCursor
        Dim f As New changepassword
        f.user = user
        f.pass = pass
        f.idakses = idakses
        f.iduser = iduser
        f.ShowDialog()
    End Sub

    Private Sub btnakses_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnakses.Click
        System.Windows.Forms.Cursor.Current = Cursors.WaitCursor
        Dim f As New masterakses
        f.user = user
        f.pass = pass
        f.idakses = idakses
        f.ShowDialog()
    End Sub

    Private Sub btnuserman_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnuserman.Click
        System.Windows.Forms.Cursor.Current = Cursors.WaitCursor
        Dim f As New usermanagement
        f.user = user
        f.pass = pass
        f.idakses = idakses
        f.ShowDialog()
    End Sub

    Private Sub btnmenu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnmenu.Click
        System.Windows.Forms.Cursor.Current = Cursors.WaitCursor
        Dim f As New mastermenu
        f.user = user
        f.pass = pass
        f.idakses = idakses
        f.ShowDialog()
    End Sub

    Private Sub btngroup_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btngroup.Click
        System.Windows.Forms.Cursor.Current = Cursors.WaitCursor
        Dim f As New groupakses
        f.user = user
        f.pass = pass
        f.idakses = idakses
        f.ShowDialog()
    End Sub

    Private Sub btnkategori_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnkategori.Click
        System.Windows.Forms.Cursor.Current = Cursors.WaitCursor
        Dim f As New masterkategori
        f.user = user
        f.pass = pass
        f.idakses = idakses
        f.ShowDialog()
    End Sub

    Private Sub btnsatuan_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnsatuan.Click
        System.Windows.Forms.Cursor.Current = Cursors.WaitCursor
        Dim f As New mastersatuan
        f.user = user
        f.pass = pass
        f.idakses = idakses
        f.ShowDialog()
    End Sub

    Private Sub btnsupplier_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnsupplier.Click
        System.Windows.Forms.Cursor.Current = Cursors.WaitCursor
        Dim f As New mastersupplier
        f.user = user
        f.pass = pass
        f.idakses = idakses
        f.ShowDialog()
    End Sub

    Private Sub btnitem_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnitem.Click
        System.Windows.Forms.Cursor.Current = Cursors.WaitCursor
        Dim f As New masteritem
        f.user = user
        f.pass = pass
        f.idakses = idakses
        f.ShowDialog()
    End Sub

    Private Sub btncons_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btncons.Click
        System.Windows.Forms.Cursor.Current = Cursors.WaitCursor
        Dim f As New masterconsumption
        f.user = user
        f.pass = pass
        f.idakses = idakses
        f.ShowDialog()
    End Sub

    Private Sub btnbeli_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnbeli.Click
        System.Windows.Forms.Cursor.Current = Cursors.WaitCursor
        Dim f As New pembelian
        f.user = user
        f.pass = pass
        f.iduser = iduser
        f.idakses = idakses
        f.ShowDialog()
    End Sub

    Private Sub btnkasir_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnkasir.Click
        System.Windows.Forms.Cursor.Current = Cursors.WaitCursor
        Dim f As New penjualan
        f.user = user
        f.pass = pass
        f.iduser = iduser
        f.idakses = idakses
        f.ShowDialog()
    End Sub

    Private Sub btnri_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnri.Click
        System.Windows.Forms.Cursor.Current = Cursors.WaitCursor
        Dim f As New returnin
        f.user = user
        f.pass = pass
        f.iduser = iduser
        f.idakses = idakses
        f.ShowDialog()
    End Sub

    Private Sub btnro_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnro.Click
        System.Windows.Forms.Cursor.Current = Cursors.WaitCursor
        Dim f As New returnout
        f.user = user
        f.pass = pass
        f.iduser = iduser
        f.idakses = idakses
        f.ShowDialog()
    End Sub

    Private Sub btndatabeli_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btndatabeli.Click
        System.Windows.Forms.Cursor.Current = Cursors.WaitCursor
        Dim f As New formrptpembelian
        f.user = user
        f.pass = pass
        f.iduser = iduser
        f.ShowDialog()
    End Sub

    Private Sub btndatari_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btndatari.Click
        System.Windows.Forms.Cursor.Current = Cursors.WaitCursor
        Dim f As New formrptreturnin
        f.user = user
        f.pass = pass
        f.iduser = iduser
        f.ShowDialog()
    End Sub

    Private Sub btndataro_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btndataro.Click
        System.Windows.Forms.Cursor.Current = Cursors.WaitCursor
        Dim f As New formrptreturnout
        f.user = user
        f.pass = pass
        f.iduser = iduser
        f.ShowDialog()
    End Sub

    Private Sub btndatastock_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btndatastock.Click
        System.Windows.Forms.Cursor.Current = Cursors.WaitCursor
        Dim f As New formrptstock
        f.user = user
        f.pass = pass
        f.iduser = iduser
        f.ShowDialog()
    End Sub

    Private Sub btndatajual_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btndatajual.Click
        System.Windows.Forms.Cursor.Current = Cursors.WaitCursor
        Dim f As New formrptpengeluaran
        f.user = user
        f.pass = pass
        f.iduser = iduser
        f.ShowDialog()
    End Sub

    Private Sub btnreprint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnreprint.Click
        System.Windows.Forms.Cursor.Current = Cursors.WaitCursor
        Dim f As New reprint
        f.user = user
        f.pass = pass
        f.iduser = iduser
        f.ShowDialog()
    End Sub

    Private Sub btndatakeu_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btndatakeu.Click
        System.Windows.Forms.Cursor.Current = Cursors.WaitCursor
        Dim f As New formrptkeuangan
        f.user = user
        f.pass = pass
        f.iduser = iduser
        f.ShowDialog()
    End Sub
End Class