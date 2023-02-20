Imports System.Data.SqlClient
Public Class infomenu
    Public Shared Function GetMasterMenu() As DataTable
        Dim dt As New DataTable
        Dim qry As String = "select idmenu,namamenu from mastermenu where statusaktif=1 order by namamenu asc"
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
    Public Shared Function GetIDMasterMenu(ByVal namamenu As String) As DataTable
        Dim dt As New DataTable
        Dim qry As String = "select idmenu from mastermenu where namamenu=@nm"
        Using cn As New SqlConnection(utilities.getconn)
            Try
                cn.Open()
                Using cm As New SqlCommand(qry, cn)
                    cm.Parameters.AddWithValue("@nm", namamenu)
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
    Public Shared Function CekMenu(ByVal idmenu As Guid) As Boolean
        Dim dr As SqlDataReader = Nothing
        Dim qry As String = "select * from groupakses where idmenu=@id and statusaktif=1"
        Using cn As New SqlConnection(utilities.getconn)
            Try
                cn.Open()
                Using cm As New SqlCommand(qry, cn)
                    cm.Parameters.AddWithValue("@id", idmenu)
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
    Public Shared Function CekNamaMenu0(ByVal namamenu As String) As Boolean
        Dim dr As SqlDataReader = Nothing
        Dim qry As String = "select * from mastermenu where namamenu=@nm and statusaktif=0"
        Using cn As New SqlConnection(utilities.getconn)
            Try
                cn.Open()
                Using cm As New SqlCommand(qry, cn)
                    cm.Parameters.AddWithValue("@nm", namamenu)
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
    Public Shared Function CekNamaMenu1(ByVal namamenu As String) As Boolean
        Dim dr As SqlDataReader = Nothing
        Dim qry As String = "select * from mastermenu where namamenu=@nm and statusaktif=1"
        Using cn As New SqlConnection(utilities.getconn)
            Try
                cn.Open()
                Using cm As New SqlCommand(qry, cn)
                    cm.Parameters.AddWithValue("@nm", namamenu)
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
    Public Shared Sub EditStatusMenu(ByVal namamenu As String, ByVal usermodified As String)
        Dim qry As String = "Update mastermenu set statusaktif=@stat,lastmodified=@modif,usermodified=@user where namamenu=@nm"
        Dim tr As SqlTransaction = Nothing
        Using cn As New SqlConnection(utilities.getconn)
            Try
                cn.Open()
                tr = cn.BeginTransaction
                Using cm As New SqlCommand(qry, cn, tr)
                    cm.Parameters.AddWithValue("@nm", namamenu)
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
    Public Shared Sub InputMasterMenu(ByVal namamenu As String, ByVal usermodified As String)
        Dim qry As String = "insert into mastermenu (namamenu,createdate,lastmodified,usermodified,statusaktif) " & _
                            "values (@nm,@create,@modif,@user,@stat)"
        Dim tr As SqlTransaction = Nothing
        Using cn As New SqlConnection(utilities.getconn)
            Try
                cn.Open()
                tr = cn.BeginTransaction
                Using cm As New SqlCommand(qry, cn, tr)
                    cm.Parameters.AddWithValue("@nm", namamenu)
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
    Public Shared Sub EditMasterMenu(ByVal idmenu As Guid, ByVal namamenu As String, ByVal usermodified As String)
        Dim qry As String = "Update mastermenu set namamenu=@nm,lastmodified=@modif,usermodified=@user where idmenu=@id"
        Dim tr As SqlTransaction = Nothing
        Using cn As New SqlConnection(utilities.getconn)
            Try
                cn.Open()
                tr = cn.BeginTransaction
                Using cm As New SqlCommand(qry, cn, tr)
                    cm.Parameters.AddWithValue("@id", idmenu)
                    cm.Parameters.AddWithValue("@nm", namamenu)
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
    Public Shared Sub DeleteMasterMenu(ByVal idmenu As Guid)
        Dim dr As SqlDataReader = Nothing
        Dim qry As String = "update mastermenu set statusaktif=@status where idmenu=@ID"
        Using cn As New SqlConnection(utilities.getconn)
            Try
                cn.Open()
                Using cm As New SqlCommand(qry, cn)
                    cm.Parameters.AddWithValue("@ID", idmenu)
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
