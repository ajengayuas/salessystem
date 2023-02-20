Imports System.Data.SqlClient
Public Class infocons
    Public Shared Function GetListJasa() As DataTable
        Dim dt As New DataTable
        Dim qry As String = "select m.iditem,m.namaitem from masteritem m inner join masterkategori k on " & _
                            "m.idkategori=k.idkategori where k.namakategori='jasa' and m.statusaktif='1'"
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
    Public Shared Function GetListItem() As DataTable
        Dim dt As New DataTable
        Dim qry As String = "select m.iditem,m.namaitem from masteritem m inner join masterkategori k on " & _
                            "m.idkategori=k.idkategori where k.namakategori<>'jasa' and m.statusaktif='1'"
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
    Public Shared Function GetCons() As DataTable
        Dim dt As New DataTable
        Dim qry As String = "select c.idcons,c.iditemjasa,c.qtycons,c.namaitem,i.namaitem as 'namajasa' from masterconsumption c " & _
                            "inner join masteritem i on c.iditemjasa=i.iditem where c.statusaktif='1' order by i.namaitem asc"
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
    Public Shared Function CekCons(ByVal iditemjasa As Guid, ByVal namaitem As String) As Boolean
        Dim dr As SqlDataReader = Nothing
        Dim qry As String = "select * from masterconsumption where iditemjasa=@id and namaitem=@nm and statusaktif=1"
        Using cn As New SqlConnection(utilities.getconn)
            Try
                cn.Open()
                Using cm As New SqlCommand(qry, cn)
                    cm.Parameters.AddWithValue("@id", iditemjasa)
                    cm.Parameters.AddWithValue("@nm", namaitem)
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
    Public Shared Function GetIDJasa(ByVal namaitem As String) As DataTable
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
    Public Shared Sub InputCons(ByVal iditemjasa As Guid, ByVal namaitem As String, ByVal qtycons As Decimal, ByVal usermodified As String)
        Dim qry As String = "insert into masterconsumption (iditemjasa,namaitem,qtycons,createdate,lastmodified,usermodified,statusaktif) " & _
                            "values (@id,@it,@qty,@create,@modif,@user,@stat)"
        Dim tr As SqlTransaction = Nothing
        Using cn As New SqlConnection(utilities.getconn)
            Try
                cn.Open()
                tr = cn.BeginTransaction
                Using cm As New SqlCommand(qry, cn, tr)
                    cm.Parameters.AddWithValue("@id", iditemjasa)
                    cm.Parameters.AddWithValue("@it", namaitem)
                    cm.Parameters.AddWithValue("@qty", qtycons)
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
    Public Shared Sub DeleteCons(ByVal idcons As Guid)
        Dim qry As String = "Delete from masterconsumption where idcons=@id"
        Dim tr As SqlTransaction = Nothing
        Using cn As New SqlConnection(utilities.getconn)
            Try
                cn.Open()
                tr = cn.BeginTransaction
                Using cm As New SqlCommand(qry, cn, tr)
                    cm.Parameters.AddWithValue("@id", idcons)
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
