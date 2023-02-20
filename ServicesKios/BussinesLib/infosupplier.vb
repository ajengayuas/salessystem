Imports System.Data.SqlClient
Public Class infosupplier
    Public Shared Function GetMastersupplier() As DataTable
        Dim dt As New DataTable
        Dim qry As String = "select idsupplier,namasupplier,alamatsupplier,nohpsupplier from mastersupplier where statusaktif=1 order by namasupplier asc"
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
    Public Shared Function GetIDMastersupplier(ByVal namasupplier As String) As DataTable
        Dim dt As New DataTable
        Dim qry As String = "select idsupplier from mastersupplier where namasupplier=@nm"
        Using cn As New SqlConnection(utilities.getconn)
            Try
                cn.Open()
                Using cm As New SqlCommand(qry, cn)
                    cm.Parameters.AddWithValue("@nm", namasupplier)
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
    Public Shared Function CekSupplier(ByVal idsupplier As Guid) As Boolean
        Dim dr As SqlDataReader = Nothing
        Dim qry As String = "select * from pemasukan where idsupplier=@id and statusaktif=1"
        Using cn As New SqlConnection(utilities.getconn)
            Try
                cn.Open()
                Using cm As New SqlCommand(qry, cn)
                    cm.Parameters.AddWithValue("@id", idsupplier)
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
    Public Shared Function CekNamasupplier0(ByVal namasupplier As String) As Boolean
        Dim dr As SqlDataReader = Nothing
        Dim qry As String = "select * from mastersupplier where namasupplier=@nm and statusaktif=0"
        Using cn As New SqlConnection(utilities.getconn)
            Try
                cn.Open()
                Using cm As New SqlCommand(qry, cn)
                    cm.Parameters.AddWithValue("@nm", namasupplier)
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
    Public Shared Function CekNamasupplier1(ByVal namasupplier As String) As Boolean
        Dim dr As SqlDataReader = Nothing
        Dim qry As String = "select * from mastersupplier where namasupplier=@nm and statusaktif=1"
        Using cn As New SqlConnection(utilities.getconn)
            Try
                cn.Open()
                Using cm As New SqlCommand(qry, cn)
                    cm.Parameters.AddWithValue("@nm", namasupplier)
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
    Public Shared Sub EditStatussupplier(ByVal namasupplier As String, ByVal usermodified As String)
        Dim qry As String = "Update mastersupplier set statusaktif=@stat,lastmodified=@modif,usermodified=@user where namasupplier=@nm"
        Dim tr As SqlTransaction = Nothing
        Using cn As New SqlConnection(utilities.getconn)
            Try
                cn.Open()
                tr = cn.BeginTransaction
                Using cm As New SqlCommand(qry, cn, tr)
                    cm.Parameters.AddWithValue("@nm", namasupplier)
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
    Public Shared Function CariSupplier(ByVal namasupplier As String) As DataTable
        Dim dt As New DataTable
        Dim qry As String = "select idsupplier,namasupplier,alamatsupplier,nohpsupplier from mastersupplier where namasupplier like '%' + @nm + '%' and statusaktif=1"
        Using cn As New SqlConnection(utilities.getconn)
            Try
                cn.Open()
                Using cm As New SqlCommand(qry, cn)
                    cm.Parameters.AddWithValue("@nm", namasupplier)
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
    Public Shared Sub InputMastersupplier(ByVal namasupplier As String, ByVal alamatsupplier As String, ByVal nohpsupplier As String, ByVal usermodified As String)
        Dim qry As String = "insert into mastersupplier (namasupplier,alamatsupplier,nohpsupplier,createdate,lastmodified,usermodified,statusaktif) " & _
                            "values (@nm,@al,@no,@create,@modif,@user,@stat)"
        Dim tr As SqlTransaction = Nothing
        Using cn As New SqlConnection(utilities.getconn)
            Try
                cn.Open()
                tr = cn.BeginTransaction
                Using cm As New SqlCommand(qry, cn, tr)
                    cm.Parameters.AddWithValue("@nm", namasupplier)
                    cm.Parameters.AddWithValue("@al", alamatsupplier)
                    cm.Parameters.AddWithValue("@no", nohpsupplier)
                    cm.Parameters.AddWithValue("@create", DateTime.Now)
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
    Public Shared Sub EditMastersupplier(ByVal idsupplier As Guid, ByVal namasupplier As String, ByVal alamatsupplier As String, ByVal nohpsupplier As String, ByVal usermodified As String)
        Dim qry As String = "Update mastersupplier set namasupplier=@nm,alamatsupplier=@al,nohpsupplier=@no,lastmodified=@modif,usermodified=@user where idsupplier=@id"
        Dim tr As SqlTransaction = Nothing
        Using cn As New SqlConnection(utilities.getconn)
            Try
                cn.Open()
                tr = cn.BeginTransaction
                Using cm As New SqlCommand(qry, cn, tr)
                    cm.Parameters.AddWithValue("@id", idsupplier)
                    cm.Parameters.AddWithValue("@nm", namasupplier)
                    cm.Parameters.AddWithValue("@al", alamatsupplier)
                    cm.Parameters.AddWithValue("@no", nohpsupplier)
                    cm.Parameters.AddWithValue("@modif", DateTime.Now)
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
    Public Shared Sub DeleteMastersupplier(ByVal idsupplier As Guid)
        Dim dr As SqlDataReader = Nothing
        Dim qry As String = "update mastersupplier set statusaktif=@status where idsupplier=@ID"
        Using cn As New SqlConnection(utilities.getconn)
            Try
                cn.Open()
                Using cm As New SqlCommand(qry, cn)
                    cm.Parameters.AddWithValue("@ID", idsupplier)
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
