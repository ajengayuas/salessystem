Imports System.Data.SqlClient
Public Class inforo
    Public Shared Function GetUrutanRo(ByVal tahun As Integer) As DataTable
        Dim dt As New DataTable
        Dim qry As String = "select * from tempro where tahun=@th"
        Using cn As New SqlConnection(utilities.getconn)
            Try
                cn.Open()
                Using cm As New SqlCommand(qry, cn)
                    cm.Parameters.AddWithValue("@th", tahun)
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
    Public Shared Sub InputUrutanRo(ByVal tahun As Integer, ByVal urut As Integer, ByVal kode As String)
        Dim qry As String = "insert into tempro (tahun,urut,kode) " & _
                            "values (@th,@ur,@kd)"
        Dim tr As SqlTransaction = Nothing
        Using cn As New SqlConnection(utilities.getconn)
            Try
                cn.Open()
                tr = cn.BeginTransaction
                Using cm As New SqlCommand(qry, cn, tr)
                    cm.Parameters.AddWithValue("@th", tahun)
                    cm.Parameters.AddWithValue("@ur", urut)
                    cm.Parameters.AddWithValue("@kd", kode)
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
    Public Shared Sub EditUrutanRo(ByVal tahun As Integer, ByVal urut As Integer)
        Dim qry As String = "Update tempro set urut=@ur where tahun=@th"
        Dim tr As SqlTransaction = Nothing
        Using cn As New SqlConnection(utilities.getconn)
            Try
                cn.Open()
                tr = cn.BeginTransaction
                Using cm As New SqlCommand(qry, cn, tr)
                    cm.Parameters.AddWithValue("@th", tahun)
                    cm.Parameters.AddWithValue("@ur", urut)
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
    Public Shared Function GetNoBeli() As DataTable
        Dim dt As New DataTable
        Dim qry As String = "select distinct nopemasukan from pemasukan where statusaktif=1"
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
    Public Shared Function GetIDBeli(ByVal nopemasukan As String) As DataTable
        Dim dt As New DataTable
        Dim qry As String = "select idpemasukan from pemasukan where nopemasukan=@no"
        Using cn As New SqlConnection(utilities.getconn)
            Try
                cn.Open()
                Using cm As New SqlCommand(qry, cn)
                    cm.Parameters.AddWithValue("@no", nopemasukan)
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
    Public Shared Function GetNamaItem(ByVal nopemasukan As String) As DataTable
        Dim dt As New DataTable
        Dim qry As String = "select distinct m.namaitem from pemasukan p inner join masteritem m " & _
                            "on p.iditem=m.iditem where p.nopemasukan=@no and p.statusaktif=1"
        Using cn As New SqlConnection(utilities.getconn)
            Try
                cn.Open()
                Using cm As New SqlCommand(qry, cn)
                    cm.Parameters.AddWithValue("@no", nopemasukan)
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
    Public Shared Function GetDataBeli(ByVal iditem As Guid) As DataTable
        Dim dt As New DataTable
        Dim qry As String = "select p.jumlahitem,s.namasatuan,p.hargabeliperpcs,ms.namasupplier " & _
                            "from pemasukan p inner join mastersatuan s on p.idsatuan=s.idsatuan " & _
                            "inner join mastersupplier ms on p.idsupplier=ms.idsupplier where p.iditem=@id and p.statusaktif=1"
        Using cn As New SqlConnection(utilities.getconn)
            Try
                cn.Open()
                Using cm As New SqlCommand(qry, cn)
                    cm.Parameters.AddWithValue("@id", iditem)
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
    Public Shared Sub InputRO(ByVal idpemasukan As Guid, ByVal iditem As Guid, ByVal noro As String, ByVal jumlahro As Decimal, ByVal idsatuan As Guid, ByVal harga As Decimal, ByVal sentto As String, ByVal remark As String, ByVal usermodified As String)
        Dim qry As String = "insert into returnout (idpemasukan,iditem,noro,jumlahro,idsatuan,harga,sentto,remark,createdate,lastmodified,usermodified,statusaktif) " & _
                            "values (@idp,@idi,@no,@jml,@ids,@hrg,@to,@rem,@cre,@las,@use,@sta)"
        Dim tr As SqlTransaction = Nothing
        Using cn As New SqlConnection(utilities.getconn)
            Try
                cn.Open()
                tr = cn.BeginTransaction
                Using cm As New SqlCommand(qry, cn, tr)
                    cm.Parameters.AddWithValue("@idp", idpemasukan)
                    cm.Parameters.AddWithValue("@idi", iditem)
                    cm.Parameters.AddWithValue("@no", noro)
                    cm.Parameters.AddWithValue("@jml", jumlahro)
                    cm.Parameters.AddWithValue("@ids", idsatuan)
                    cm.Parameters.AddWithValue("@hrg", harga)
                    cm.Parameters.AddWithValue("@to", sentto)
                    cm.Parameters.AddWithValue("@rem", remark)
                    cm.Parameters.AddWithValue("@cre", DateTime.Now)
                    cm.Parameters.AddWithValue("@las", DateTime.Now)
                    cm.Parameters.AddWithValue("@use", usermodified)
                    cm.Parameters.AddWithValue("@sta", 1)
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
    Public Shared Function GetQtyRo(ByVal nop As String, ByVal namaitem As String) As DataTable
        Dim dt As New DataTable
        Dim qry As String = "select r.jumlahro from returnout r inner join pemasukan p on r.idpemasukan=p.idpemasukan inner join " & _
                            "masteritem m on p.iditem=m.iditem where p.nopemasukan=@nop and m.namaitem=@nm"
        Using cn As New SqlConnection(utilities.getconn)
            Try
                cn.Open()
                Using cm As New SqlCommand(qry, cn)
                    cm.Parameters.AddWithValue("@nop", nop)
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
End Class
