Imports System.Data.SqlClient
Public Class infouser
    Public Shared Function GetUserMan() As DataTable
        Dim dt As New DataTable
        Dim qry As String = "select u.iduser,u.username,u.idakses,a.namaakses from userlogin u inner join masterakses a " & _
                            "on u.idakses=a.idakses where u.statusaktif=1"
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
    Public Shared Function CekNamaUser0(ByVal username As String) As Boolean
        Dim dr As SqlDataReader = Nothing
        Dim qry As String = "select * from userlogin where username=@nm and statusaktif=0"
        Using cn As New SqlConnection(utilities.getconn)
            Try
                cn.Open()
                Using cm As New SqlCommand(qry, cn)
                    cm.Parameters.AddWithValue("@nm", username)
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
    Public Shared Function CekNamaUser1(ByVal username As String) As Boolean
        Dim dr As SqlDataReader = Nothing
        Dim qry As String = "select * from userlogin where username=@nm and statusaktif=1"
        Using cn As New SqlConnection(utilities.getconn)
            Try
                cn.Open()
                Using cm As New SqlCommand(qry, cn)
                    cm.Parameters.AddWithValue("@nm", username)
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
    Public Shared Sub EditStatusUser(ByVal username As String, ByVal usermodified As String)
        Dim qry As String = "Update userlogin set statusaktif=@stat,lastmodified=@modif,usermodified=@user where username=@nm"
        Dim tr As SqlTransaction = Nothing
        Using cn As New SqlConnection(utilities.getconn)
            Try
                cn.Open()
                tr = cn.BeginTransaction
                Using cm As New SqlCommand(qry, cn, tr)
                    cm.Parameters.AddWithValue("@nm", username)
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
    Public Shared Function GetAksesForUserMan() As DataTable
        Dim dt As New DataTable
        Dim qry As String = "select idakses,namaakses from masterakses where statusaktif=1"
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
    Public Shared Sub InputUserMan(ByVal username As String, ByVal password As String, ByVal idakses As Guid, ByVal idperusahaan As Guid, ByVal usermodified As String)
        Dim qry As String = "insert into userlogin (username,password,idakses,idperusahaan,createdate,lastmodified,usermodified,statusaktif) " & _
                            "values (@user,@pass,@idakses,@idp,@creat,@last,@umod,@stat)"
        Dim tr As SqlTransaction = Nothing
        Using cn As New SqlConnection(utilities.getconn)
            Try
                cn.Open()
                tr = cn.BeginTransaction
                Using cm As New SqlCommand(qry, cn, tr)
                    cm.Parameters.AddWithValue("@user", username)
                    cm.Parameters.AddWithValue("@pass", password)
                    cm.Parameters.AddWithValue("@idakses", idakses)
                    cm.Parameters.AddWithValue("@idp", idperusahaan)
                    cm.Parameters.AddWithValue("@creat", DateTime.Now)
                    cm.Parameters.AddWithValue("@last", DateTime.Now)
                    cm.Parameters.AddWithValue("@umod", usermodified)
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
    Public Shared Sub EditUserMan(ByVal iduser As Guid, ByVal idakses As Guid, ByVal usermodified As String)
        Dim qry As String = "Update userlogin set idakses=@idakses,lastmodified=@modif,usermodified=@user where iduser=@id"
        Dim tr As SqlTransaction = Nothing
        Using cn As New SqlConnection(utilities.getconn)
            Try
                cn.Open()
                tr = cn.BeginTransaction
                Using cm As New SqlCommand(qry, cn, tr)
                    cm.Parameters.AddWithValue("@id", iduser)
                    cm.Parameters.AddWithValue("@idakses", idakses)
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
    Public Shared Sub DeleteUserMan(ByVal iduser As Guid)
        Dim dr As SqlDataReader = Nothing
        Dim qry As String = "update userlogin set statusaktif=@status where iduser=@ID"
        Using cn As New SqlConnection(utilities.getconn)
            Try
                cn.Open()
                Using cm As New SqlCommand(qry, cn)
                    cm.Parameters.AddWithValue("@ID", iduser)
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
    Public Shared Sub ResetPassword(ByVal iduser As Guid)
        Dim dr As SqlDataReader = Nothing
        Dim qry As String = "update userlogin set password=@pass where iduser=@ID"
        Using cn As New SqlConnection(utilities.getconn)
            Try
                cn.Open()
                Using cm As New SqlCommand(qry, cn)
                    cm.Parameters.AddWithValue("@ID", iduser)
                    cm.Parameters.AddWithValue("@pass", "password123")
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
