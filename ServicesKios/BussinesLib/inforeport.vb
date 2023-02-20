Imports System.Data.SqlClient
Public Class inforeport
    Public Shared Function GetDataInvoice(ByVal nopengeluaran As String) As DataTable
        Dim dt As New DataTable
        Dim dt2 As New DataTable
        Dim qry As String = "select p.idpengeluaran,p.nopengeluaran,p.tanggalkeluar,p.jumlahkeluar,p.hargajual,p.usermodified,m.namaitem,s.namasatuan,p.diskon,mp.namaperusahaan,mp.alamatperusahaan,mp.notelp,p.keterangan,p.remark,mp.logo " & _
                            "from pengeluaran p left join masteritem m on p.iditem=m.iditem " & _
                            "inner join mastersatuan s on p.idsatuan=s.idsatuan " & _
                            "inner join userlogin ul on p.iduser=ul.iduser " & _
                            "inner join masterperusahaan mp on ul.idperusahaan=mp.idperusahaan " & _
                            "where p.nopengeluaran=@no and p.keterangan<>'multi'"
        Using cn As New SqlConnection(utilities.getconn)
            Try
                cn.Open()
                Using cm As New SqlCommand(qry, cn)
                    cm.Parameters.AddWithValue("@no", nopengeluaran)
                    dt.Load(cm.ExecuteReader)
                End Using
            Catch ex As Exception
                Throw ex
            Finally
                cn.Close()
            End Try
        End Using
        Return dt
    End Function
    Public Shared Function GetDataPembelian(ByVal tgl1 As DateTime, ByVal tgl2 As DateTime) As DataTable
        Dim dt As New DataTable
        Dim dt2 As New DataTable
        Dim qry As String = "select p.nopemasukan,p.tanggalmasuk,p.jumlahitem,p.hargabeliperpcs,i.namaitem,s.namasatuan,m.namasupplier,p.jumlahitem*p.hargabeliperpcs as 'total' " & _
                            "from pemasukan p inner join masteritem i on p.iditem=i.iditem " & _
                            "inner join mastersatuan s on p.idsatuan=s.idsatuan " & _
                            "inner join mastersupplier m on p.idsupplier=m.idsupplier " & _
                            "where p.tanggalmasuk between @tgl1 and @tgl2 and p.statusaktif=1 order by p.nopemasukan asc"
        Using cn As New SqlConnection(utilities.getconn)
            Try
                cn.Open()
                Using cm As New SqlCommand(qry, cn)
                    cm.Parameters.AddWithValue("@tgl1", tgl1)
                    cm.Parameters.AddWithValue("@tgl2", tgl2)
                    dt.Load(cm.ExecuteReader)
                End Using
            Catch ex As Exception
                Throw ex
            Finally
                cn.Close()
            End Try
        End Using
        Return dt
    End Function
    Public Shared Function GetDataReturnIn(ByVal tgl1 As DateTime, ByVal tgl2 As DateTime) As DataTable
        Dim dt As New DataTable
        Dim dt2 As New DataTable
        Dim qry As String = "select r.nori,r.createdate,i.namaitem,r.jumlahri,s.namasatuan,r.harga,r.jumlahri*r.harga as 'total',p.nopengeluaran,r.remark " & _
                            "from returnin r inner join masteritem i on r.iditem=i.iditem " & _
                            "inner join mastersatuan s on r.idsatuan=s.idsatuan " & _
                            "inner join pengeluaran p on r.idpengeluaran=p.idpengeluaran " & _
                            "where r.createdate between @tgl1 and @tgl2 and r.statusaktif=1 order by nori asc"
        Using cn As New SqlConnection(utilities.getconn)
            Try
                cn.Open()
                Using cm As New SqlCommand(qry, cn)
                    cm.Parameters.AddWithValue("@tgl1", tgl1)
                    cm.Parameters.AddWithValue("@tgl2", tgl2)
                    dt.Load(cm.ExecuteReader)
                End Using
            Catch ex As Exception
                Throw ex
            Finally
                cn.Close()
            End Try
        End Using
        Return dt
    End Function
    Public Shared Function GetDataReturnOut(ByVal tgl1 As DateTime, ByVal tgl2 As DateTime) As DataTable
        Dim dt As New DataTable
        Dim dt2 As New DataTable
        Dim qry As String = "select r.noro,r.createdate,i.namaitem,r.jumlahro,s.namasatuan,r.harga,r.jumlahro*r.harga as 'total',p.nopemasukan,r.remark,r.sentto " & _
                            "from returnout r inner join masteritem i on r.iditem=i.iditem " & _
                            "inner join mastersatuan s on r.idsatuan=s.idsatuan " & _
                            "inner join pemasukan p on r.idpemasukan=p.idpemasukan " & _
                            "where r.createdate between @tgl1 and @tgl2 and r.statusaktif=1 order by noro asc"
        Using cn As New SqlConnection(utilities.getconn)
            Try
                cn.Open()
                Using cm As New SqlCommand(qry, cn)
                    cm.Parameters.AddWithValue("@tgl1", tgl1)
                    cm.Parameters.AddWithValue("@tgl2", tgl2)
                    dt.Load(cm.ExecuteReader)
                End Using
            Catch ex As Exception
                Throw ex
            Finally
                cn.Close()
            End Try
        End Using
        Return dt
    End Function
    Public Shared Function GetDataStock() As DataTable
        Dim dt As New DataTable
        Dim dt2 As New DataTable
        Dim qry As String = "select i.namaitem,s.jumlahstock " & _
                            "from stock s inner join masteritem i on s.iditem=i.iditem " & _
                            "where s.statusaktif=1 order by i.namaitem asc"
        Using cn As New SqlConnection(utilities.getconn)
            Try
                cn.Open()
                Using cm As New SqlCommand(qry, cn)
                    dt.Load(cm.ExecuteReader)
                End Using
            Catch ex As Exception
                Throw ex
            Finally
                cn.Close()
            End Try
        End Using
        Return dt
    End Function
    Public Shared Function GetDataPenjualan(ByVal tgl1 As DateTime, ByVal tgl2 As DateTime) As DataTable
        Dim dt As New DataTable
        Dim dt2 As New DataTable
        Dim qry As String = "select p.nopengeluaran,p.tanggalkeluar,i.namaitem,p.jumlahkeluar,s.namasatuan,p.hargajual,p.diskon,(p.hargajual*p.jumlahkeluar)-p.diskon as 'total',p.remark " & _
                            "from pengeluaran p left join masteritem i on p.iditem=i.iditem " & _
                            "inner join mastersatuan s on p.idsatuan=s.idsatuan " & _
                            "where p.tanggalkeluar between @tgl1 and @tgl2 and p.statusaktif=1 and p.keterangan<>'Multi' order by p.nopengeluaran asc"
        Using cn As New SqlConnection(utilities.getconn)
            Try
                cn.Open()
                Using cm As New SqlCommand(qry, cn)
                    cm.Parameters.AddWithValue("@tgl1", tgl1)
                    cm.Parameters.AddWithValue("@tgl2", tgl2)
                    dt.Load(cm.ExecuteReader)
                End Using
            Catch ex As Exception
                Throw ex
            Finally
                cn.Close()
            End Try
        End Using
        Return dt
    End Function
End Class
