Imports System.Data.SqlClient
Public Class infologin
    Public Shared Function GetData(ByVal username As String, ByVal password As String) As Boolean
        Dim dr As SqlDataReader = Nothing
        Dim qry As String = "select * from userlogin where username=@user and password=@id"
        Using cn As New SqlConnection(utilities.getconn)
            Try
                cn.Open()
                Using cm As New SqlCommand(qry, cn)
                    cm.Parameters.AddWithValue("@user", username)
                    cm.Parameters.AddWithValue("@id", password)
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

    Public Shared Function GetAkses(ByVal username As String, ByVal password As String) As DataTable
        Dim dt As New DataTable
        Dim qry As String = "select a.idakses,a.namaakses,u.username,u.iduser,u.idperusahaan from userlogin u inner join masterakses a on u.idakses=a.idakses " & _
                            "where username=@user and password=@id"
        Using cn As New SqlConnection(utilities.getconn)
            Try
                cn.Open()
                Using cm As New SqlCommand(qry, cn)
                    cm.Parameters.AddWithValue("@user", username)
                    cm.Parameters.AddWithValue("@id", password)
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

    Public Shared Function GetNamaAkses(ByVal idakses As Guid) As DataTable
        Dim dt As New DataTable
        Dim qry As String = "select namaakses from masterakses where idakses=@idakses"
        Using cn As New SqlConnection(utilities.getconn)
            Try
                cn.Open()
                Using cm As New SqlCommand(qry, cn)
                    cm.Parameters.AddWithValue("@idakses", idakses)
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

    Public Shared Function GetAksesMenu(ByVal idakses As Guid, ByVal namamenu As String) As DataTable
        Dim dt As New DataTable
        Dim qry As String = "select g.statusaktif from groupakses g inner join mastermenu m on g.idmenu=m.idmenu " & _
                            "where g.idakses=@idakses and m.namamenu=@namamenu"
        Using cn As New SqlConnection(utilities.getconn)
            Try
                cn.Open()
                Using cm As New SqlCommand(qry, cn)
                    cm.Parameters.AddWithValue("@idakses", idakses)
                    cm.Parameters.AddWithValue("@namamenu", namamenu)
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
    Public Shared Sub EditLastLogin(ByVal iduser As Guid)
        Dim qry As String = "update userlogin set lastlogin=@last where iduser=@id"
        Dim tr As SqlTransaction = Nothing
        Using cn As New SqlConnection(utilities.getconn)
            Try
                cn.Open()
                tr = cn.BeginTransaction
                Using cm As New SqlCommand(qry, cn, tr)
                    cm.Parameters.AddWithValue("@id", iduser)
                    cm.Parameters.AddWithValue("@last", DateTime.Now)
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
End Class
