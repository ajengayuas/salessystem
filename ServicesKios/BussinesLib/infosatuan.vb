Imports System.Data.SqlClient
Public Class infosatuan
    Public Shared Function GetMastersatuan() As DataTable
        Dim dt As New DataTable
        Dim qry As String = "select idsatuan,namasatuan,konvpcs from mastersatuan where statusaktif=1 order by namasatuan asc"
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
    Public Shared Function GetIDMastersatuan(ByVal namasatuan As String) As DataTable
        Dim dt As New DataTable
        Dim qry As String = "select idsatuan from mastersatuan where namasatuan=@nm"
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
    Public Shared Function CekSatuan(ByVal idsatuan As Guid) As Boolean
        Dim dr As SqlDataReader = Nothing
        Dim qry As String = "select * from masteritem where idsatuan=@id and statusaktif=1"
        Using cn As New SqlConnection(utilities.getconn)
            Try
                cn.Open()
                Using cm As New SqlCommand(qry, cn)
                    cm.Parameters.AddWithValue("@id", idsatuan)
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
    Public Shared Function CekNamasatuan0(ByVal namasatuan As String) As Boolean
        Dim dr As SqlDataReader = Nothing
        Dim qry As String = "select * from mastersatuan where namasatuan=@nm and statusaktif=0"
        Using cn As New SqlConnection(utilities.getconn)
            Try
                cn.Open()
                Using cm As New SqlCommand(qry, cn)
                    cm.Parameters.AddWithValue("@nm", namasatuan)
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
    Public Shared Function CekNamasatuan1(ByVal namasatuan As String) As Boolean
        Dim dr As SqlDataReader = Nothing
        Dim qry As String = "select * from mastersatuan where namasatuan=@nm and statusaktif=1"
        Using cn As New SqlConnection(utilities.getconn)
            Try
                cn.Open()
                Using cm As New SqlCommand(qry, cn)
                    cm.Parameters.AddWithValue("@nm", namasatuan)
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
    Public Shared Sub EditStatussatuan(ByVal namasatuan As String, ByVal usermodified As String)
        Dim qry As String = "Update mastersatuan set statusaktif=@stat,lastmodified=@modif,usermodified=@user where namasatuan=@nm"
        Dim tr As SqlTransaction = Nothing
        Using cn As New SqlConnection(utilities.getconn)
            Try
                cn.Open()
                tr = cn.BeginTransaction
                Using cm As New SqlCommand(qry, cn, tr)
                    cm.Parameters.AddWithValue("@nm", namasatuan)
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
    Public Shared Sub InputMastersatuan(ByVal namasatuan As String, ByVal konvpcs As Decimal, ByVal usermodified As String)
        Dim qry As String = "insert into mastersatuan (namasatuan,konvpcs,createdate,lastmodified,usermodified,statusaktif) " & _
                            "values (@nm,@pcs,@create,@modif,@user,@stat)"
        Dim tr As SqlTransaction = Nothing
        Using cn As New SqlConnection(utilities.getconn)
            Try
                cn.Open()
                tr = cn.BeginTransaction
                Using cm As New SqlCommand(qry, cn, tr)
                    cm.Parameters.AddWithValue("@nm", namasatuan)
                    cm.Parameters.AddWithValue("@pcs", konvpcs)
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
    Public Shared Sub EditMastersatuan(ByVal idsatuan As Guid, ByVal namasatuan As String, ByVal konvpcs As Decimal, ByVal usermodified As String)
        Dim qry As String = "Update mastersatuan set namasatuan=@nm,konvpcs=@pcs,lastmodified=@modif,usermodified=@user where idsatuan=@id"
        Dim tr As SqlTransaction = Nothing
        Using cn As New SqlConnection(utilities.getconn)
            Try
                cn.Open()
                tr = cn.BeginTransaction
                Using cm As New SqlCommand(qry, cn, tr)
                    cm.Parameters.AddWithValue("@id", idsatuan)
                    cm.Parameters.AddWithValue("@nm", namasatuan)
                    cm.Parameters.AddWithValue("@pcs", konvpcs)
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
    Public Shared Sub DeleteMastersatuan(ByVal idsatuan As Guid)
        Dim dr As SqlDataReader = Nothing
        Dim qry As String = "update mastersatuan set statusaktif=@status where idsatuan=@ID"
        Using cn As New SqlConnection(utilities.getconn)
            Try
                cn.Open()
                Using cm As New SqlCommand(qry, cn)
                    cm.Parameters.AddWithValue("@ID", idsatuan)
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
