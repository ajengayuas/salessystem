Imports System.Data.SqlClient
Public Class infoperusahaan
    Public Shared Function GetPerusahaan() As DataTable
        Dim dt As New DataTable
        Dim qry As String = "select idperusahaan,namaperusahaan,alamatperusahaan,notelp,logo from masterperusahaan where statusaktif=1"
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
    Public Shared Function GetIDPerusahaan(ByVal namaperusahaan As String) As DataTable
        Dim dt As New DataTable
        Dim qry As String = "select idperusahaan from masterperusahaan where namaperusahaan=@nm"
        Using cn As New SqlConnection(utilities.getconn)
            Try
                cn.Open()
                Using cm As New SqlCommand(qry, cn)
                    cm.Parameters.AddWithValue("@nm", namaperusahaan)
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
    Public Shared Sub InputPerusahaan(ByVal namaperusahaan As String, ByVal alamatperusahaan As String, ByVal notelp As String, ByVal logo As Byte(), ByVal usermodified As String)
        Dim qry As String = "insert into masterperusahaan (namaperusahaan,alamatperusahaan,notelp,logo,createdate,lastmodified,usermodified,statusaktif) " & _
                            "values (@nm,@alm,@telp,@logo,@create,@modif,@user,@stat)"
        Dim tr As SqlTransaction = Nothing
        Using cn As New SqlConnection(utilities.getconn)
            Try
                cn.Open()
                tr = cn.BeginTransaction
                Using cm As New SqlCommand(qry, cn, tr)
                    cm.Parameters.AddWithValue("@nm", namaperusahaan)
                    cm.Parameters.AddWithValue("@alm", alamatperusahaan)
                    cm.Parameters.AddWithValue("@telp", notelp)
                    cm.Parameters.AddWithValue("@logo", logo)
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
    Public Shared Sub EditPerusahaan(ByVal idperusahaan As Guid, ByVal namaperusahaan As String, ByVal alamatperusahaan As String, ByVal notelp As String, ByVal logo As Byte(), ByVal usermodified As String)
        Dim qry As String = "Update masterperusahaan set namaperusahaan=@nm,alamatperusahaan=@alm,notelp=@telp,logo=@logo,lastmodified=@modif,usermodified=@user where idperusahaan=@id"
        Dim tr As SqlTransaction = Nothing
        Using cn As New SqlConnection(utilities.getconn)
            Try
                cn.Open()
                tr = cn.BeginTransaction
                Using cm As New SqlCommand(qry, cn, tr)
                    cm.Parameters.AddWithValue("@id", idperusahaan)
                    cm.Parameters.AddWithValue("@nm", namaperusahaan)
                    cm.Parameters.AddWithValue("@alm", alamatperusahaan)
                    cm.Parameters.AddWithValue("@telp", notelp)
                    cm.Parameters.AddWithValue("@logo", logo)
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
    Public Shared Sub DeletePerusahaan(ByVal idperusahaan As Guid)
        Dim dr As SqlDataReader = Nothing
        Dim qry As String = "update masterperusahaan set statusaktif=@status where idperusahaan=@ID"
        Using cn As New SqlConnection(utilities.getconn)
            Try
                cn.Open()
                Using cm As New SqlCommand(qry, cn)
                    cm.Parameters.AddWithValue("@ID", idperusahaan)
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
    Public Shared Function GetDataPerusahaan(ByVal idperusahaan As Guid) As DataTable
        Dim dt As New DataTable
        Dim qry As String = "select namaperusahaan,alamatperusahaan,notelp,logo from masterperusahaan where idperusahaan=@id"
        Using cn As New SqlConnection(utilities.getconn)
            Try
                cn.Open()
                Using cm As New SqlCommand(qry, cn)
                    cm.Parameters.AddWithValue("@id", idperusahaan)
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
