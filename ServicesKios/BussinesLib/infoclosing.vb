Imports System.Data.SqlClient
Public Class infoclosing
    Public Shared Function GetDataNonjasa(ByVal tanggalkeluar As Date, ByVal tanggalkeluar2 As Date) As DataTable
        Dim dt As New DataTable
        Dim qry As String = "select p.idmulti,p.tanggalkeluar,p.nopengeluaran,i.namaitem,p.jumlahkeluar*s.konvpcs as qtypcs, " & _
"p.hargajual/konvpcs as jualpcs,p.diskon,(p.jumlahkeluar*s.konvpcs)*(p.hargajual/konvpcs) as amountjual, " & _
"p.remark,p.keterangan,belipcs,belipcs*(p.jumlahkeluar*s.konvpcs) as amountbeli " & _
"from pengeluaran p left join masteritem i on p.iditem=i.iditem " & _
"inner join mastersatuan s on p.idsatuan=s.idsatuan " & _
"inner join masterkategori k on i.idkategori=k.idkategori " & _
"left join (select iditem,avg(hargabeliperpcs) as belipcs from pemasukan where statusaktif=1 group by iditem) as beli " & _
"on beli.iditem=p.iditem " & _
"where p.statusaktif=1 and p.keterangan='normal' and k.namakategori='non jasa' " & _
"and p.tanggalkeluar between @1 and @2 " & _
"order by i.namaitem asc"
        Using cn As New SqlConnection(utilities.getconn)
            Try
                cn.Open()
                Using cm As New SqlCommand(qry, cn)
                    cm.Parameters.AddWithValue("@1", tanggalkeluar)
                    cm.Parameters.AddWithValue("@2", tanggalkeluar2)
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
    Public Shared Function GetDataJasa(ByVal tanggalkeluar As Date, ByVal tanggalkeluar2 As Date) As DataTable
        Dim dt As New DataTable
        Dim qry As String = "select p.idmulti,p.tanggalkeluar,p.nopengeluaran,i.namaitem,p.jumlahkeluar*s.konvpcs as qtypcs,p.hargajual/s.konvpcs as jualpcs, " & _
"(p.jumlahkeluar*s.konvpcs)*(p.hargajual/s.konvpcs) as amountjual,p.diskon,p.keterangan,p.remark,cons.belipcs, " & _
"(p.jumlahkeluar*s.konvpcs)*cons.belipcs as amountbeli " & _
"from pengeluaran p " & _
"inner join (select c.iditemjasa,sum(c.qtycons*beli.ratapcs )as belipcs " & _
"from masterconsumption c " & _
"inner join masteritem i on c.namaitem=i.namaitem " & _
"inner join (select iditem,avg(hargabeliperpcs) as ratapcs from pemasukan where statusaktif=1 group by iditem) as beli " & _
"on i.iditem=beli.iditem group by c.iditemjasa) as cons on p.iditem=cons.iditemjasa " & _
"inner join masteritem i on p.iditem=i.iditem " & _
"inner join masterkategori k on i.idkategori=k.idkategori " & _
"inner join mastersatuan s on p.idsatuan=s.idsatuan " & _
"where p.statusaktif=1 and keterangan='normal' and k.namakategori='jasa' " & _
"and p.tanggalkeluar between @1 and @2 " & _
"order by i.namaitem asc"
        Using cn As New SqlConnection(utilities.getconn)
            Try
                cn.Open()
                Using cm As New SqlCommand(qry, cn)
                    cm.Parameters.AddWithValue("@1", tanggalkeluar)
                    cm.Parameters.AddWithValue("@2", tanggalkeluar2)
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
    Public Shared Function GetDataMulti(ByVal tanggalkeluar As Date, ByVal tanggalkeluar2 As Date) As DataTable
        Dim dt As New DataTable
        Dim qry As String = "select p.tanggalkeluar,p.idmulti,p.nopengeluaran,i.namaitem,p.jumlahkeluar*s.konvpcs as qtypcs, " & _
"p.hargajual/konvpcs as jualpcs,p.diskon,(p.jumlahkeluar*s.konvpcs)*(p.hargajual/konvpcs) as amountjual, " & _
"p.remark,p.keterangan,belipcs,belipcs*(p.jumlahkeluar*s.konvpcs) as amountbeli " & _
"from pengeluaran p left join masteritem i on p.iditem=i.iditem " & _
"inner join mastersatuan s on p.idsatuan=s.idsatuan " & _
"left join (select iditem,avg(hargabeliperpcs) as belipcs from pemasukan where statusaktif=1 group by iditem) as beli " & _
"on beli.iditem=p.iditem " & _
"where p.statusaktif=1 and p.keterangan<>'normal' " & _
"and p.tanggalkeluar between @1 and @2 " & _
"order by p.idmulti,p.keterangan asc"
        Using cn As New SqlConnection(utilities.getconn)
            Try
                cn.Open()
                Using cm As New SqlCommand(qry, cn)
                    cm.Parameters.AddWithValue("@1", tanggalkeluar)
                    cm.Parameters.AddWithValue("@2", tanggalkeluar2)
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
    Public Shared Sub InputClosing(ByVal idmulti As Guid, ByVal nopengeluaran As String, ByVal namaitem As String, ByVal qtypcs As Decimal, ByVal jualpcs As Decimal, ByVal amountjual As Decimal, ByVal diskon As Decimal, ByVal remark As String, ByVal keterangan As String, ByVal belipcs As Decimal, ByVal amountbeli As Decimal, ByVal tanggalkeluar As DateTime, ByVal closing As String, ByVal usermodified As String)
        Dim qry As String = "insert into tempclosing (idmulti,nopengeluaran,namaitem,qtypcs,jualpcs,amountjual,diskon,remark,keterangan, " & _
                            "belipcs,amountbeli,tanggalkeluar,closing,lastmodified,usermodified) values (@idm,@no,@nm,@qty,@ju,@amj,@dis, " & _
                            "@rem,@ket,@be,@amb,@tgl,@clo,@last,@user)"
        Dim tr As SqlTransaction = Nothing
        Using cn As New SqlConnection(utilities.getconn)
            Try
                cn.Open()
                tr = cn.BeginTransaction
                Using cm As New SqlCommand(qry, cn, tr)
                    cm.Parameters.AddWithValue("@idm", idmulti)
                    cm.Parameters.AddWithValue("@no", nopengeluaran)
                    cm.Parameters.AddWithValue("@nm", namaitem)
                    cm.Parameters.AddWithValue("@qty", qtypcs)
                    cm.Parameters.AddWithValue("@ju", jualpcs)
                    cm.Parameters.AddWithValue("@amj", amountjual)
                    cm.Parameters.AddWithValue("@dis", diskon)
                    cm.Parameters.AddWithValue("@rem", remark)
                    cm.Parameters.AddWithValue("@ket", keterangan)
                    cm.Parameters.AddWithValue("@be", belipcs)
                    cm.Parameters.AddWithValue("@amb", amountbeli)
                    cm.Parameters.AddWithValue("@tgl", tanggalkeluar)
                    cm.Parameters.AddWithValue("@clo", closing)
                    cm.Parameters.AddWithValue("@last", DateTime.Now)
                    cm.Parameters.AddWithValue("@user", usermodified)
                    cm.ExecuteNonQuery()
                End Using
                tr.Commit()
            Catch ex As Exception
                tr.Rollback()
                Throw ex
            Finally
                cn.Close()
                cn.Dispose()
            End Try
        End Using
    End Sub
    Public Shared Function CekClosing(ByVal closing As String) As Boolean
        Dim dr As SqlDataReader = Nothing
        Dim qry As String = "select * from tempclosing where closing=@clo"
        Using cn As New SqlConnection(utilities.getconn)
            Try
                cn.Open()
                Using cm As New SqlCommand(qry, cn)
                    cm.Parameters.AddWithValue("@clo", closing)
                    dr = cm.ExecuteReader
                    If dr.Read Then Return True
                End Using
            Catch ex As Exception
                Throw ex
            Finally
                cn.Close()
            End Try
        End Using
        Return False
    End Function
    Public Shared Sub DeleteClosing(ByVal closing As String)
        Dim qry As String = "Delete from tempclosing where closing=@clo"
        Dim tr As SqlTransaction = Nothing
        Using cn As New SqlConnection(utilities.getconn)
            Try
                cn.Open()
                tr = cn.BeginTransaction
                Using cm As New SqlCommand(qry, cn, tr)
                    cm.Parameters.AddWithValue("@clo", closing)
                    cm.ExecuteNonQuery()
                End Using
                tr.Commit()
            Catch ex As Exception
                tr.Rollback()
                Throw ex
            Finally
                cn.Close()
                cn.Dispose()
            End Try
        End Using
    End Sub
    Public Shared Function GetDataClosing(ByVal closing As String) As DataTable
        Dim dt As New DataTable
        Dim qry As String = "select * from tempclosing where closing=@clo order by nopengeluaran,idmulti,keterangan asc"
        Using cn As New SqlConnection(utilities.getconn)
            Try
                cn.Open()
                Using cm As New SqlCommand(qry, cn)
                    cm.Parameters.AddWithValue("@clo", closing)
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
