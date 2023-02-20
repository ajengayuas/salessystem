Imports System.Data.SqlClient
Public Class infobeli
    Public Shared Function GetListItem() As DataTable
        Dim dt As New DataTable
        Dim qry As String = "select i.iditem,i.namaitem from masteritem i inner join masterkategori k on i.idkategori=k.idkategori " & _
                            "where i.statusaktif=1 and k.namakategori='Non Jasa' order by namaitem asc"
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
    Public Shared Function GetListSupplier() As DataTable
        Dim dt As New DataTable
        Dim qry As String = "select idsupplier,namasupplier from mastersupplier where statusaktif=1 order by namasupplier asc"
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
    Public Shared Function GetListSatuan() As DataTable
        Dim dt As New DataTable
        Dim qry As String = "select idsatuan,namasatuan from mastersatuan where statusaktif=1 order by namasatuan"
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
    Public Shared Function GetUrutan(ByVal tahun As Integer) As DataTable
        Dim dt As New DataTable
        Dim qry As String = "select * from tempbeli where tahun=@th"
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
    Public Shared Sub InputUrutan(ByVal tahun As Integer, ByVal urut As Integer)
        Dim qry As String = "insert into tempbeli (tahun,urut) " & _
                            "values (@th,@ur)"
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
    Public Shared Sub EditUrutan(ByVal tahun As Integer, ByVal urut As Integer)
        Dim qry As String = "Update tempbeli set urut=@ur where tahun=@th"
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
    Public Shared Sub EditHargaItem(ByVal iditem As Guid, ByVal hargaperpcs As Decimal, ByVal harga As Decimal, ByVal idsatuan As Guid, ByVal usermodified As String)
        Dim qry As String = "Update masteritem set hargaperpcs=@pcs,harga=@hrg,idsatuan=@ids,usermodified=@user where iditem=@id"
        Dim tr As SqlTransaction = Nothing
        Using cn As New SqlConnection(utilities.getconn)
            Try
                cn.Open()
                tr = cn.BeginTransaction
                Using cm As New SqlCommand(qry, cn, tr)
                    cm.Parameters.AddWithValue("@pcs", hargaperpcs)
                    cm.Parameters.AddWithValue("@hrg", harga)
                    cm.Parameters.AddWithValue("@ids", idsatuan)
                    cm.Parameters.AddWithValue("@user", usermodified)
                    cm.Parameters.AddWithValue("@id", iditem)
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
    Public Shared Function GetStock(ByVal iditem As Guid) As Boolean
        Dim dr As SqlDataReader = Nothing
        Dim qry As String = "select * from stock where iditem=@id and statusaktif=1"
        Using cn As New SqlConnection(utilities.getconn)
            Try
                cn.Open()
                Using cm As New SqlCommand(qry, cn)
                    cm.Parameters.AddWithValue("@id", iditem)
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
    Public Shared Function GetDataStock(ByVal iditem As Guid) As DataTable
        Dim dt As New DataTable
        Dim qry As String = "select * from stock where iditem=@id and statusaktif=1"
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
    Public Shared Sub InputStock(ByVal iditem As Guid, ByVal jumlahstock As Decimal, ByVal usermodified As String)
        Dim qry As String = "insert into stock (iditem,jumlahstock,createdate,lastmodified,usermodified,statusaktif) " & _
                            "values (@idi,@jml,@cre,@last,@user,@sta)"
        Dim tr As SqlTransaction = Nothing
        Using cn As New SqlConnection(utilities.getconn)
            Try
                cn.Open()
                tr = cn.BeginTransaction
                Using cm As New SqlCommand(qry, cn, tr)
                    cm.Parameters.AddWithValue("@idi", iditem)
                    cm.Parameters.AddWithValue("@jml", jumlahstock)
                    cm.Parameters.AddWithValue("@cre", DateTime.Now)
                    cm.Parameters.AddWithValue("@last", DateTime.Now)
                    cm.Parameters.AddWithValue("@user", usermodified)
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
    Public Shared Sub EditStock(ByVal jumlahstock As Decimal, ByVal usermodified As String, ByVal iditem As Guid)
        Dim qry As String = "Update stock set jumlahstock=@jml,lastmodified=@last,usermodified=@user where iditem=@id"
        Dim tr As SqlTransaction = Nothing
        Using cn As New SqlConnection(utilities.getconn)
            Try
                cn.Open()
                tr = cn.BeginTransaction
                Using cm As New SqlCommand(qry, cn, tr)
                    cm.Parameters.AddWithValue("@jml", jumlahstock)
                    cm.Parameters.AddWithValue("@last", DateTime.Now)
                    cm.Parameters.AddWithValue("@user", usermodified)
                    cm.Parameters.AddWithValue("@id", iditem)
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
    Public Shared Sub InputBeli(ByVal iditem As Guid, ByVal idsupplier As Guid, ByVal iduser As Guid, ByVal nopemasukan As String, ByVal tanggalmasuk As Date, ByVal jumlahitem As Decimal, ByVal hargabeliperpcs As Decimal, ByVal hargabeli As Decimal, ByVal idsatuan As Guid, ByVal usermodified As String)
        Dim qry As String = "insert into pemasukan (iditem,idsupplier,iduser,nopemasukan,tanggalmasuk,jumlahitem,hargabeliperpcs,hargabeli,idsatuan,createdate,lastmodified,usermodified,statusaktif) " & _
                            "values (@idi,@ids,@idu,@no,@tgl,@jml,@pcs,@hrg,@idst,@cre,@last,@user,@sta)"
        Dim tr As SqlTransaction = Nothing
        Using cn As New SqlConnection(utilities.getconn)
            Try
                cn.Open()
                tr = cn.BeginTransaction
                Using cm As New SqlCommand(qry, cn, tr)
                    cm.Parameters.AddWithValue("@idi", iditem)
                    cm.Parameters.AddWithValue("@ids", idsupplier)
                    cm.Parameters.AddWithValue("@idu", iduser)
                    cm.Parameters.AddWithValue("@no", nopemasukan)
                    cm.Parameters.AddWithValue("@tgl", tanggalmasuk)
                    cm.Parameters.AddWithValue("@jml", jumlahitem)
                    cm.Parameters.AddWithValue("@pcs", hargabeliperpcs)
                    cm.Parameters.AddWithValue("@hrg", hargabeli)
                    cm.Parameters.AddWithValue("@idst", idsatuan)
                    cm.Parameters.AddWithValue("@cre", DateTime.Now)
                    cm.Parameters.AddWithValue("@last", DateTime.Now)
                    cm.Parameters.AddWithValue("@user", usermodified)
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
    Public Shared Function Getkodeharga(ByVal namaitem As String) As DataTable
        Dim dt As New DataTable
        Dim qry As String = "select m.iditem,m.kodeitem,m.harga,m.hargaperpcs,s.namasatuan from masteritem m inner join mastersatuan s on m.idsatuan=s.idsatuan where m.namaitem=@nm"
        Using cn As New SqlConnection(utilities.getconn)
            Try
                cn.Open()
                Using cm As New SqlCommand(qry, cn)
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
    Public Shared Function Getkonvpcs(ByVal namasatuan As String) As DataTable
        Dim dt As New DataTable
        Dim qry As String = "select konvpcs from mastersatuan where namasatuan=@nm"
        Using cn As New SqlConnection(utilities.getconn)
            Try
                cn.Open()
                Using cm As New SqlCommand(qry, cn)
                    cm.Parameters.AddWithValue("@nm", namasatuan)
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
