Imports System.Data.SqlClient
Public Class infogroupakses
    Public Shared Function GetCariAkses(ByVal idakses As Guid) As Boolean
        Dim dr As SqlDataReader = Nothing
        Dim qry As String = "select * from groupakses where idakses=@id"
        Using cn As New SqlConnection(utilities.getconn)
            Try
                cn.Open()
                Using cm As New SqlCommand(qry, cn)
                    cm.Parameters.AddWithValue("@id", idakses)
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
    Public Shared Function GetGroupAkses(ByVal idakses As Guid) As DataTable
        Dim dt As New DataTable
        Dim qry As String = "select g.idgroup,g.idakses,g.idmenu,m.namamenu,g.statusaktif from groupakses g " & _
                            "inner join mastermenu m on g.idmenu=m.idmenu where g.idakses=@id order by m.namamenu asc"
        Using cn As New SqlConnection(utilities.getconn)
            Try
                cn.Open()
                Using cm As New SqlCommand(qry, cn)
                    cm.Parameters.AddWithValue("@id", idakses)
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
    Public Shared Sub InputGroupAkses(ByVal idakses As Guid, ByVal idmenu As Guid, ByVal usermodified As String, ByVal statusaktif As Boolean)
        Dim qry As String = "insert into groupakses (idakses,idmenu,createdate,lastmodified,usermodified,statusaktif) " & _
                            "values (@id,@idm,@creat,@last,@user,@stat)"
        Dim tr As SqlTransaction = Nothing
        Using cn As New SqlConnection(utilities.getconn)
            Try
                cn.Open()
                tr = cn.BeginTransaction
                Using cm As New SqlCommand(qry, cn, tr)
                    cm.Parameters.AddWithValue("@id", idakses)
                    cm.Parameters.AddWithValue("@idm", idmenu)
                    cm.Parameters.AddWithValue("@creat", DateTime.Now)
                    cm.Parameters.AddWithValue("@last", DateTime.Now)
                    cm.Parameters.AddWithValue("@user", usermodified)
                    cm.Parameters.AddWithValue("@stat", statusaktif)
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
    Public Shared Sub EditGroupAkses(ByVal statusaktif As Boolean, ByVal idakses As Guid, ByVal idmenu As Guid, ByVal usermodified As String)
        Dim qry As String = "Update groupakses set lastmodified=@last,usermodified=@user,statusaktif=@stat " & _
                            "where idakses=@id and idmenu=@idm"
        Dim tr As SqlTransaction = Nothing
        Using cn As New SqlConnection(utilities.getconn)
            Try
                cn.Open()
                tr = cn.BeginTransaction
                Using cm As New SqlCommand(qry, cn, tr)
                    cm.Parameters.AddWithValue("@last", DateTime.Now)
                    cm.Parameters.AddWithValue("@user", usermodified)
                    cm.Parameters.AddWithValue("@stat", statusaktif)
                    cm.Parameters.AddWithValue("@id", idakses)
                    cm.Parameters.AddWithValue("@idm", idmenu)
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
    Public Shared Function CekGroupAkses(ByVal idakses As Guid, ByVal idmenu As Guid) As Boolean
        Dim dr As SqlDataReader = Nothing
        Dim qry As String = "select * from groupakses where idakses=@ida and idmenu=@idm"
        Using cn As New SqlConnection(utilities.getconn)
            Try
                cn.Open()
                Using cm As New SqlCommand(qry, cn)
                    cm.Parameters.AddWithValue("@ida", idakses)
                    cm.Parameters.AddWithValue("@idm", idmenu)
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
End Class
