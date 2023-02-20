Imports System.Data.SqlClient
Public Class infori
    Public Shared Function GetUrutanRi(ByVal tahun As Integer) As DataTable
        Dim dt As New DataTable
        Dim qry As String = "select * from tempri where tahun=@th"
        Using cn As New SqlConnection(utilities.getconn)
            Try
                cn.Open()
                Using cm As New SqlCommand(qry, cn)
                    cm.Parameters.AddWithValue("@th", tahun)
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
    Public Shared Sub InputUrutanRi(ByVal tahun As Integer, ByVal urut As Integer, ByVal kode As String)
        Dim qry As String = "insert into tempri (tahun,urut,kode) " & _
                            "values (@th,@ur,@kd)"
        Dim tr As SqlTransaction = Nothing
        Using cn As New SqlConnection(utilities.getconn)
            Try
                cn.Open()
                tr = cn.BeginTransaction
                Using cm As New SqlCommand(qry, cn, tr)
                    cm.Parameters.AddWithValue("@th", tahun)
                    cm.Parameters.AddWithValue("@ur", urut)
                    cm.Parameters.AddWithValue("@kd", kode)
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
    Public Shared Sub EditUrutanRi(ByVal tahun As Integer, ByVal urut As Integer)
        Dim qry As String = "Update tempri set urut=@ur where tahun=@th"
        Dim tr As SqlTransaction = Nothing
        Using cn As New SqlConnection(utilities.getconn)
            Try
                cn.Open()
                tr = cn.BeginTransaction
                Using cm As New SqlCommand(qry, cn, tr)
                    cm.Parameters.AddWithValue("@th", tahun)
                    cm.Parameters.AddWithValue("@ur", urut)
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
    Public Shared Function GetNoJual() As DataTable
        Dim dt As New DataTable
        Dim qry As String = "select distinct nopengeluaran from pengeluaran where statusaktif=1"
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
    Public Shared Function GetIDJual(ByVal nopengeluaran As String) As DataTable
        Dim dt As New DataTable
        Dim qry As String = "select idpengeluaran from pengeluaran where nopengeluaran=@no"
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
    Public Shared Function GetNamaItemJual(ByVal nopengeluaran) As DataTable
        Dim dt As New DataTable
        Dim qry As String = "select remark,keterangan from pengeluaran where nopengeluaran=@no and statusaktif=1 and keterangan<>'multi'"
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
    Public Shared Function GetDataJual(ByVal iditem As Guid) As DataTable
        Dim dt As New DataTable
        Dim qry As String = "select p.jumlahkeluar,s.namasatuan,p.hargajual from pengeluaran p inner join mastersatuan s on p.idsatuan=s.idsatuan " & _
                            "where p.iditem=@id and p.statusaktif=1"
        Using cn As New SqlConnection(utilities.getconn)
            Try
                cn.Open()
                Using cm As New SqlCommand(qry, cn)
                    cm.Parameters.AddWithValue("@id", iditem)
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
    Public Shared Function GetDataJual2(ByVal remark As String, ByVal nopengeluaran As String) As DataTable
        Dim dt As New DataTable
        Dim qry As String = "select p.jumlahkeluar,s.namasatuan,p.hargajual from pengeluaran p inner join mastersatuan s on p.idsatuan=s.idsatuan " & _
                            "where p.remark=@rem and p.nopengeluaran=@no and p.statusaktif=1"
        Using cn As New SqlConnection(utilities.getconn)
            Try
                cn.Open()
                Using cm As New SqlCommand(qry, cn)
                    cm.Parameters.AddWithValue("@rem", remark)
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
    Public Shared Sub InputRI(ByVal idpengeluaran As Guid, ByVal iditem As Guid, ByVal nori As String, ByVal jumlahri As Decimal, ByVal harga As Decimal, ByVal idsatuan As Guid, ByVal remark As String, ByVal usermodified As String)
        Dim qry As String = "insert into returnin (idpengeluaran,iditem,nori,jumlahri,harga,idsatuan,remark,createdate,lastmodified,usermodified,statusaktif,remarkitem) " & _
                            "values (@idp,@idi,@no,@jml,@hrg,@ids,@rem,@cre,@las,@use,@sta)"
        Dim tr As SqlTransaction = Nothing
        Using cn As New SqlConnection(utilities.getconn)
            Try
                cn.Open()
                tr = cn.BeginTransaction
                Using cm As New SqlCommand(qry, cn, tr)
                    cm.Parameters.AddWithValue("@idp", idpengeluaran)
                    cm.Parameters.AddWithValue("@idi", iditem)
                    cm.Parameters.AddWithValue("@no", nori)
                    cm.Parameters.AddWithValue("@jml", jumlahri)
                    cm.Parameters.AddWithValue("@ids", idsatuan)
                    cm.Parameters.AddWithValue("@hrg", harga)
                    cm.Parameters.AddWithValue("@rem", remark)
                    cm.Parameters.AddWithValue("@cre", DateTime.Now)
                    cm.Parameters.AddWithValue("@las", DateTime.Now)
                    cm.Parameters.AddWithValue("@use", usermodified)
                    cm.Parameters.AddWithValue("@sta", 1)
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
    Public Shared Sub InputRI2(ByVal idpengeluaran As Guid, ByVal nori As String, ByVal jumlahri As Decimal, ByVal harga As Decimal, ByVal idsatuan As Guid, ByVal remark As String, ByVal usermodified As String, ByVal remarkitem As String)
        Dim qry As String = "insert into returnin (idpengeluaran,nori,jumlahri,harga,idsatuan,remark,createdate,lastmodified,usermodified,statusaktif,remarkitem) " & _
                            "values (@idp,@no,@jml,@hrg,@ids,@rem,@cre,@las,@use,@sta,@rmk)"
        Dim tr As SqlTransaction = Nothing
        Using cn As New SqlConnection(utilities.getconn)
            Try
                cn.Open()
                tr = cn.BeginTransaction
                Using cm As New SqlCommand(qry, cn, tr)
                    cm.Parameters.AddWithValue("@idp", idpengeluaran)
                    cm.Parameters.AddWithValue("@no", nori)
                    cm.Parameters.AddWithValue("@jml", jumlahri)
                    cm.Parameters.AddWithValue("@ids", idsatuan)
                    cm.Parameters.AddWithValue("@hrg", harga)
                    cm.Parameters.AddWithValue("@rem", remark)
                    cm.Parameters.AddWithValue("@cre", DateTime.Now)
                    cm.Parameters.AddWithValue("@las", DateTime.Now)
                    cm.Parameters.AddWithValue("@use", usermodified)
                    cm.Parameters.AddWithValue("@sta", 1)
                    cm.Parameters.AddWithValue("@rmk", remarkitem)
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
    Public Shared Function GetQtyRi(ByVal nop As String, ByVal namaitem As String) As DataTable
        Dim dt As New DataTable
        Dim qry As String = "select r.jumlahri from returnin r inner join pengeluaran p on r.idpengeluaran=p.idpengeluaran " & _
                            "inner join masteritem m on p.iditem=m.iditem where p.nopengeluaran=@nop and m.namaitem=@nm"
        Using cn As New SqlConnection(utilities.getconn)
            Try
                cn.Open()
                Using cm As New SqlCommand(qry, cn)
                    cm.Parameters.AddWithValue("@nop", nop)
                    cm.Parameters.AddWithValue("@nm", namaitem)
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
    Public Shared Function GetDataItemJualMulti(ByVal nop As String) As DataTable
        Dim dt As New DataTable
        Dim qry As String = "select remark from pengeluaran where nopengeluaran=@nop and keterangan='multi' and statusaktif=1"
        Using cn As New SqlConnection(utilities.getconn)
            Try
                cn.Open()
                Using cm As New SqlCommand(qry, cn)
                    cm.Parameters.AddWithValue("@nop", nop)
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
