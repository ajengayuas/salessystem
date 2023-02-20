Imports System.Data.SqlClient
Public Class infokategori
    Public Shared Function GetMasterkategori() As DataTable
        Dim dt As New DataTable
        Dim qry As String = "select idkategori,namakategori from masterkategori where statusaktif=1 order by namakategori asc"
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
    Public Shared Function GetIDMasterkategori(ByVal namakategori As String) As DataTable
        Dim dt As New DataTable
        Dim qry As String = "select idkategori from masterkategori where namakategori=@nm"
        Using cn As New SqlConnection(utilities.getconn)
            Try
                cn.Open()
                Using cm As New SqlCommand(qry, cn)
                    cm.Parameters.AddWithValue("@nm", namakategori)
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
    Public Shared Function CekKategori(ByVal idkategori As Guid) As Boolean
        Dim dr As SqlDataReader = Nothing
        Dim qry As String = "select * from masteritem where idkategori=@id and statusaktif=1"
        Using cn As New SqlConnection(utilities.getconn)
            Try
                cn.Open()
                Using cm As New SqlCommand(qry, cn)
                    cm.Parameters.AddWithValue("@id", idkategori)
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
    Public Shared Function CekNamakategori0(ByVal namakategori As String) As Boolean
        Dim dr As SqlDataReader = Nothing
        Dim qry As String = "select * from masterkategori where namakategori=@nm and statusaktif=0"
        Using cn As New SqlConnection(utilities.getconn)
            Try
                cn.Open()
                Using cm As New SqlCommand(qry, cn)
                    cm.Parameters.AddWithValue("@nm", namakategori)
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
    Public Shared Function CekNamakategori1(ByVal namakategori As String) As Boolean
        Dim dr As SqlDataReader = Nothing
        Dim qry As String = "select * from masterkategori where namakategori=@nm and statusaktif=1"
        Using cn As New SqlConnection(utilities.getconn)
            Try
                cn.Open()
                Using cm As New SqlCommand(qry, cn)
                    cm.Parameters.AddWithValue("@nm", namakategori)
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
    Public Shared Sub EditStatuskategori(ByVal namakategori As String, ByVal usermodified As String)
        Dim qry As String = "Update masterkategori set statusaktif=@stat,lastmodified=@modif,usermodified=@user where namakategori=@nm"
        Dim tr As SqlTransaction = Nothing
        Using cn As New SqlConnection(utilities.getconn)
            Try
                cn.Open()
                tr = cn.BeginTransaction
                Using cm As New SqlCommand(qry, cn, tr)
                    cm.Parameters.AddWithValue("@nm", namakategori)
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
    Public Shared Sub InputMasterkategori(ByVal namakategori As String, ByVal usermodified As String)
        Dim qry As String = "insert into masterkategori (namakategori,createdate,lastmodified,usermodified,statusaktif) " & _
                            "values (@nm,@create,@modif,@user,@stat)"
        Dim tr As SqlTransaction = Nothing
        Using cn As New SqlConnection(utilities.getconn)
            Try
                cn.Open()
                tr = cn.BeginTransaction
                Using cm As New SqlCommand(qry, cn, tr)
                    cm.Parameters.AddWithValue("@nm", namakategori)
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
    Public Shared Sub EditMasterkategori(ByVal idkategori As Guid, ByVal namakategori As String, ByVal usermodified As String)
        Dim qry As String = "Update masterkategori set namakategori=@nm,lastmodified=@modif,usermodified=@user where idkategori=@id"
        Dim tr As SqlTransaction = Nothing
        Using cn As New SqlConnection(utilities.getconn)
            Try
                cn.Open()
                tr = cn.BeginTransaction
                Using cm As New SqlCommand(qry, cn, tr)
                    cm.Parameters.AddWithValue("@id", idkategori)
                    cm.Parameters.AddWithValue("@nm", namakategori)
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
    Public Shared Sub DeleteMasterkategori(ByVal idkategori As Guid)
        Dim dr As SqlDataReader = Nothing
        Dim qry As String = "update masterkategori set statusaktif=@status where idkategori=@ID"
        Using cn As New SqlConnection(utilities.getconn)
            Try
                cn.Open()
                Using cm As New SqlCommand(qry, cn)
                    cm.Parameters.AddWithValue("@ID", idkategori)
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
