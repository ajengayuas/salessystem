Imports System.Data.SqlClient
Public Class infopassword
    Public Shared Sub EditPerusahaan(ByVal iduser As Guid, ByVal password As String)
        Dim qry As String = "update userlogin set password=@pwd where iduser=@id"
        Dim tr As SqlTransaction = Nothing
        Using cn As New SqlConnection(utilities.getconn)
            Try
                cn.Open()
                tr = cn.BeginTransaction
                Using cm As New SqlCommand(qry, cn, tr)
                    cm.Parameters.AddWithValue("@id", iduser)
                    cm.Parameters.AddWithValue("@pwd", password)
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
