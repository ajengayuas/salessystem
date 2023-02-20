Imports System.Data.SqlClient
Public Class infoitem
    Public Shared Function GetMasterItem() As DataTable
        Dim dt As New DataTable
        Dim qry As String = "select i.iditem,i.idkategori,i.kodeitem,i.namaitem,i.harga,i.hargaperpcs,i.idsatuan,k.namakategori,s.namasatuan " & _
                            "from masteritem i inner join masterkategori k on i.idkategori=k.idkategori " & _
                            "inner join mastersatuan s on i.idsatuan=s.idsatuan where i.statusaktif=1 order by i.namaitem asc"
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
    Public Shared Function GetIDMasterItem(ByVal namaitem As String) As DataTable
        Dim dt As New DataTable
        Dim qry As String = "select iditem from masteritem where namaitem=@nm"
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
    Public Shared Function CekItem(ByVal iditem As Guid) As Boolean
        Dim dr As SqlDataReader = Nothing
        Dim qry As String = "select * from pemasukan where iditem=@id and statusaktif=1"
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
    Public Shared Function CekNamaItem0(ByVal namaItem As String) As Boolean
        Dim dr As SqlDataReader = Nothing
        Dim qry As String = "select * from masterItem where namaItem=@nm and statusaktif=0"
        Using cn As New SqlConnection(utilities.getconn)
            Try
                cn.Open()
                Using cm As New SqlCommand(qry, cn)
                    cm.Parameters.AddWithValue("@nm", namaItem)
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
    Public Shared Function CekNamaItem1(ByVal namaItem As String) As Boolean
        Dim dr As SqlDataReader = Nothing
        Dim qry As String = "select * from masterItem where namaItem=@nm and statusaktif=1"
        Using cn As New SqlConnection(utilities.getconn)
            Try
                cn.Open()
                Using cm As New SqlCommand(qry, cn)
                    cm.Parameters.AddWithValue("@nm", namaItem)
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
    Public Shared Function CekkodeItem0(ByVal kodeItem As String) As Boolean
        Dim dr As SqlDataReader = Nothing
        Dim qry As String = "select * from masterItem where kodeItem=@nm and statusaktif=0"
        Using cn As New SqlConnection(utilities.getconn)
            Try
                cn.Open()
                Using cm As New SqlCommand(qry, cn)
                    cm.Parameters.AddWithValue("@nm", kodeItem)
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
    Public Shared Function CekkodeItem1(ByVal kodeItem As String) As Boolean
        Dim dr As SqlDataReader = Nothing
        Dim qry As String = "select * from masterItem where kodeItem=@nm and statusaktif=1"
        Using cn As New SqlConnection(utilities.getconn)
            Try
                cn.Open()
                Using cm As New SqlCommand(qry, cn)
                    cm.Parameters.AddWithValue("@nm", kodeItem)
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
    Public Shared Sub EditStatusitem(ByVal namaitem As String, ByVal usermodified As String)
        Dim qry As String = "Update masteritem set statusaktif=@stat,lastmodified=@modif,usermodified=@user where namaitem=@nm"
        Dim tr As SqlTransaction = Nothing
        Using cn As New SqlConnection(utilities.getconn)
            Try
                cn.Open()
                tr = cn.BeginTransaction
                Using cm As New SqlCommand(qry, cn, tr)
                    cm.Parameters.AddWithValue("@nm", namaitem)
                    cm.Parameters.AddWithValue("@modif", DateTime.Now)
                    cm.Parameters.AddWithValue("@user", usermodified)
                    cm.Parameters.AddWithValue("@stat", 1)
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
    Public Shared Sub EditStatusitembyKode(ByVal kodeitem As String, ByVal usermodified As String)
        Dim qry As String = "Update masteritem set statusaktif=@stat,lastmodified=@modif,usermodified=@user where kodeitem=@nm"
        Dim tr As SqlTransaction = Nothing
        Using cn As New SqlConnection(utilities.getconn)
            Try
                cn.Open()
                tr = cn.BeginTransaction
                Using cm As New SqlCommand(qry, cn, tr)
                    cm.Parameters.AddWithValue("@nm", kodeitem)
                    cm.Parameters.AddWithValue("@modif", DateTime.Now)
                    cm.Parameters.AddWithValue("@user", usermodified)
                    cm.Parameters.AddWithValue("@stat", 1)
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
    Public Shared Function CariItem(ByVal namaitem As String) As DataTable
        Dim dt As New DataTable
        Dim qry As String = "select * from masteritem i inner join masterkategori k on i.idkategori=k.idkategori " & _
                            "inner join mastersatuan s on i.idsatuan=s.idsatuan " & _
                            "where i.statusaktif=1 and i.namaitem like '%' + @nm + '%' order by i.namaitem asc"
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
    Public Shared Sub InputMasterItem(ByVal idkategori As Guid, ByVal kodeitem As String, ByVal namaitem As String, ByVal hargaperpcs As Decimal, ByVal harga As Decimal, ByVal idsatuan As Guid, ByVal usermodified As String)
        Dim qry As String = "insert into masteritem (idkategori,kodeitem,namaitem,hargaperpcs,harga,idsatuan,createdate,lastmodified,usermodified,statusaktif) " & _
                            "values (@idkat,@kd,@nm,@pcs,@hrg,@idsat,@creat,@last,@user,@stat)"
        Dim tr As SqlTransaction = Nothing
        Using cn As New SqlConnection(utilities.getconn)
            Try
                cn.Open()
                tr = cn.BeginTransaction
                Using cm As New SqlCommand(qry, cn, tr)
                    cm.Parameters.AddWithValue("@idkat", idkategori)
                    cm.Parameters.AddWithValue("@kd", kodeitem)
                    cm.Parameters.AddWithValue("@nm", namaitem)
                    cm.Parameters.AddWithValue("@pcs", hargaperpcs)
                    cm.Parameters.AddWithValue("@hrg", harga)
                    cm.Parameters.AddWithValue("@idsat", idsatuan)
                    cm.Parameters.AddWithValue("@creat", DateTime.Now)
                    cm.Parameters.AddWithValue("@last", DateTime.Now)
                    cm.Parameters.AddWithValue("@user", usermodified)
                    cm.Parameters.AddWithValue("@stat", 1)
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
    Public Shared Sub EditMasterItem(ByVal idkategori As Guid, ByVal kodeitem As String, ByVal namaitem As String, ByVal hargaperpcs As Decimal, ByVal harga As Decimal, ByVal idsatuan As Guid, ByVal usermodified As String, ByVal iditem As Guid)
        Dim qry As String = "Update masteritem set idkategori=@idkat,kodeitem=@kd,namaitem=@nm,hargaperpcs=@pcs,harga=@hrg,idsatuan=@idsat,lastmodified=@last,usermodified=@user where iditem=@id"
        Dim tr As SqlTransaction = Nothing
        Using cn As New SqlConnection(utilities.getconn)
            Try
                cn.Open()
                tr = cn.BeginTransaction
                Using cm As New SqlCommand(qry, cn, tr)
                    cm.Parameters.AddWithValue("@idkat", idkategori)
                    cm.Parameters.AddWithValue("@kd", kodeitem)
                    cm.Parameters.AddWithValue("@nm", namaitem)
                    cm.Parameters.AddWithValue("@pcs", hargaperpcs)
                    cm.Parameters.AddWithValue("@hrg", harga)
                    cm.Parameters.AddWithValue("@idsat", idsatuan)
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
    Public Shared Sub DeleteMasterItem(ByVal iditem As Guid)
        Dim dr As SqlDataReader = Nothing
        Dim qry As String = "update masteritem set statusaktif=@status where iditem=@ID"
        Using cn As New SqlConnection(utilities.getconn)
            Try
                cn.Open()
                Using cm As New SqlCommand(qry, cn)
                    cm.Parameters.AddWithValue("@ID", iditem)
                    cm.Parameters.AddWithValue("@status", 0)
                    dr = cm.ExecuteReader
                    dr.NextResult()
                End Using
            Catch ex As Exception
                Throw ex
            Finally
                cn.Close()
            End Try
        End Using
    End Sub
End Class
