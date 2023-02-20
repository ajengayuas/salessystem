Imports x = ProjectKios.ServiceReference1
Public Class multiitem
    Public user As String = ""
    Public pass As String = ""
    Public iduser As Guid
    Public idakses As Guid
    Public no As String = ""
    Private _mySrv As New x.WebService1SoapClient
    Private _secure As New x.AutentikasiUser
    Private _listitem1 As x.ListDataItem()
    Private _listitem2 As x.ListDataItem()
    Private _listitem3 As x.ListDataItem()
    Private _listitem4 As x.ListDataItem()
    Private _listitem5 As x.ListDataItem()
    Private _masteritem1 As x.datakodeharga()
    Private _datastock1 As x.ListDataStock()
    Private _masteritem2 As x.datakodeharga()
    Private _datastock2 As x.ListDataStock()
    Private _masteritem3 As x.datakodeharga()
    Private _datastock3 As x.ListDataStock()
    Private _masteritem4 As x.datakodeharga()
    Private _datastock4 As x.ListDataStock()
    Private _masteritem5 As x.datakodeharga()
    Private _datastock5 As x.ListDataStock()

    Private Sub getAccessControl()
        _secure.username = user.ToLower
        _secure.password = pass
        If _secure.Username = "" And _secure.Password = "" Then Me.Close()
    End Sub

    Private Sub PictureBox6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox6.Click
        Close()
    End Sub

    Private Sub btncek_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btncek.Click
        If cmbitem1.Text <> "" And nudqty1.Value = 0 Then
            MsgBox("Qty 0!")
            Exit Sub
        End If
        If cmbitem2.Text <> "" And nudqty2.Value = 0 Then
            MsgBox("Qty 0!")
            Exit Sub
        End If
        If cmbitem3.Text <> "" And nudqty3.Value = 0 Then
            MsgBox("Qty 0!")
            Exit Sub
        End If
        If cmbitem4.Text <> "" And nudqty4.Value = 0 Then
            MsgBox("Qty 0!")
            Exit Sub
        End If
        If cmbitem5.Text <> "" And nudqty5.Value = 0 Then
            MsgBox("Qty 0!")
            Exit Sub
        End If
        If nudqty1.Value > txtstock1.Text Then
            MsgBox("Stock Tidak Cukup!")
            Exit Sub
        End If
        If nudqty2.Value > txtstock2.Text Then
            MsgBox("Stock Tidak Cukup!")
            Exit Sub
        End If
        If nudqty3.Value > txtstock3.Text Then
            MsgBox("Stock Tidak Cukup!")
            Exit Sub
        End If
        If nudqty4.Value > txtstock4.Text Then
            MsgBox("Stock Tidak Cukup!")
            Exit Sub
        End If
        If nudqty5.Value > txtstock5.Text Then
            MsgBox("Stock Tidak Cukup!")
            Exit Sub
        End If
        btninsert.Enabled = True
    End Sub

    Private Sub multiitem_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        getAccessControl()
        Fillcmbitem()
        cmbitem1.SelectedIndex = -1
        cmbitem2.SelectedIndex = -1
        cmbitem3.SelectedIndex = -1
        cmbitem4.SelectedIndex = -1
        cmbitem5.SelectedIndex = -1
        txtkode1.Clear()
        txtkode2.Clear()
        txtkode3.Clear()
        txtkode4.Clear()
        txtkode5.Clear()
        txtstock1.Text = 0
        txtstock2.Text = 0
        txtstock3.Text = 0
        txtstock4.Text = 0
        txtstock5.Text = 0
    End Sub

    Public Sub Fillcmbitem()
        _listitem1 = _mySrv.AmbilListItemBeli(_secure)
        cmbitem1.DataSource = _listitem1
        cmbitem1.DisplayMember = "namaitem"
        cmbitem1.ValueMember = "namaitem"
        _listitem2 = _mySrv.AmbilListItemBeli(_secure)
        cmbitem2.DataSource = _listitem2
        cmbitem2.DisplayMember = "namaitem"
        cmbitem2.ValueMember = "namaitem"
        _listitem3 = _mySrv.AmbilListItemBeli(_secure)
        cmbitem3.DataSource = _listitem3
        cmbitem3.DisplayMember = "namaitem"
        cmbitem3.ValueMember = "namaitem"
        _listitem4 = _mySrv.AmbilListItemBeli(_secure)
        cmbitem4.DataSource = _listitem4
        cmbitem4.DisplayMember = "namaitem"
        cmbitem4.ValueMember = "namaitem"
        _listitem5 = _mySrv.AmbilListItemBeli(_secure)
        cmbitem5.DataSource = _listitem5
        cmbitem5.DisplayMember = "namaitem"
        cmbitem5.ValueMember = "namaitem"
    End Sub

    Private Sub cmbitem1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbitem1.SelectedIndexChanged
        _masteritem1 = _mySrv.Ambilkodeharga(_secure, cmbitem1.Text)
        If _masteritem1.Length = 0 Then Exit Sub
        txtkode1.Text = _masteritem1(0).kodeitem
        _datastock1 = _mySrv.AmbilDataStock(_secure, _masteritem1(0).iditem)
        If _datastock1.Length = 0 Then
            txtstock1.Text = 0
        Else
            txtstock1.Text = _datastock1(0).jumlahstock
        End If
    End Sub

    Private Sub cmbitem2_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbitem2.SelectedIndexChanged
        _masteritem2 = _mySrv.Ambilkodeharga(_secure, cmbitem2.Text)
        If _masteritem2.Length = 0 Then Exit Sub
        txtkode2.Text = _masteritem2(0).kodeitem
        _datastock2 = _mySrv.AmbilDataStock(_secure, _masteritem2(0).iditem)
        If _datastock2.Length = 0 Then
            txtstock2.Text = 0
        Else
            txtstock2.Text = _datastock2(0).jumlahstock
        End If
    End Sub

    Private Sub cmbitem3_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbitem3.SelectedIndexChanged
        _masteritem3 = _mySrv.Ambilkodeharga(_secure, cmbitem3.Text)
        If _masteritem3.Length = 0 Then Exit Sub
        txtkode3.Text = _masteritem3(0).kodeitem
        _datastock3 = _mySrv.AmbilDataStock(_secure, _masteritem3(0).iditem)
        If _datastock3.Length = 0 Then
            txtstock3.Text = 0
        Else
            txtstock3.Text = _datastock3(0).jumlahstock
        End If
    End Sub

    Private Sub cmbitem4_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbitem4.SelectedIndexChanged
        _masteritem4 = _mySrv.Ambilkodeharga(_secure, cmbitem4.Text)
        If _masteritem4.Length = 0 Then Exit Sub
        txtkode4.Text = _masteritem4(0).kodeitem
        _datastock4 = _mySrv.AmbilDataStock(_secure, _masteritem4(0).iditem)
        If _datastock4.Length = 0 Then
            txtstock4.Text = 0
        Else
            txtstock4.Text = _datastock4(0).jumlahstock
        End If
    End Sub

    Private Sub cmbitem5_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbitem5.SelectedIndexChanged
        _masteritem5 = _mySrv.Ambilkodeharga(_secure, cmbitem5.Text)
        If _masteritem5.Length = 0 Then Exit Sub
        txtkode5.Text = _masteritem5(0).kodeitem
        _datastock5 = _mySrv.AmbilDataStock(_secure, _masteritem5(0).iditem)
        If _datastock5.Length = 0 Then
            txtstock5.Text = 0
        Else
            txtstock5.Text = _datastock5(0).jumlahstock
        End If
    End Sub


End Class