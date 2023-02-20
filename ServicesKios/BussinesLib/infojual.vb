Imports System.Data.SqlClient
Public Class infojual
    Public Shared Function GetUrutanJual(ByVal tahun As Integer) As DataTable
        Dim dt As New DataTable
        Dim qry As String = "select * from tempjual where tahun=@th"
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
    Public Shared Sub InputUrutanJual(ByVal tahun As Integer, ByVal urut As Integer)
        Dim qry As String = "insert into tempjual (tahun,urut) " & _
                            "values (@th,@ur)"
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
    Public Shared Sub EditUrutanJual(ByVal tahun As Integer, ByVal urut As Integer)
        Dim qry As String = "Update tempjual set urut=@ur where tahun=@th"
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
    Public Shared Sub InputJual(ByVal iduser As Guid, ByVal iditem As Guid, ByVal nopengeluaran As String, ByVal tanggalkeluar As Date, ByVal jumlahkeluar As Decimal, ByVal idsatuan As Guid, ByVal hargajual As Decimal, ByVal diskon As Decimal, ByVal keterangan As String, ByVal remark As String, ByVal usermodified As String)
        Dim qry As String = "insert into pengeluaran (iduser,iditem,nopengeluaran,tanggalkeluar,jumlahkeluar,idsatuan,hargajual,diskon,keterangan,remark,createdate,lastmodified,usermodified,statusaktif) " & _
                            "values (@idu,@idi,@no,@tgl,@jml,@ids,@hrg,@dis,@ket,@rem,@cre,@las,@use,@sta)"
        Dim tr As SqlTransaction = Nothing
        Using cn As New SqlConnection(utilities.getconn)
            Try
                cn.Open()
                tr = cn.BeginTransaction
                Using cm As New SqlCommand(qry, cn, tr)
                    cm.Parameters.AddWithValue("@idu", iduser)
                    cm.Parameters.AddWithValue("@idi", iditem)
                    cm.Parameters.AddWithValue("@no", nopengeluaran)
                    cm.Parameters.AddWithValue("@tgl", tanggalkeluar)
                    cm.Parameters.AddWithValue("@jml", jumlahkeluar)
                    cm.Parameters.AddWithValue("@ids", idsatuan)
                    cm.Parameters.AddWithValue("@hrg", hargajual)
                    cm.Parameters.AddWithValue("@dis", diskon)
                    cm.Parameters.AddWithValue("@ket", keterangan)
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
    Public Shared Sub InputJualKepala(ByVal iduser As Guid, ByVal idmulti As Guid, ByVal nopengeluaran As String, ByVal tanggalkeluar As Date, ByVal jumlahkeluar As Decimal, ByVal idsatuan As Guid, ByVal hargajual As Decimal, ByVal diskon As Decimal, ByVal keterangan As String, ByVal remark As String, ByVal usermodified As String)
        Dim qry As String = "insert into pengeluaran (iduser,idmulti,nopengeluaran,tanggalkeluar,jumlahkeluar,idsatuan,hargajual,diskon,keterangan,remark,createdate,lastmodified,usermodified,statusaktif) " & _
                            "values (@idu,@idm,@no,@tgl,@jml,@ids,@hrg,@dis,@ket,@rem,@cre,@las,@use,@sta)"
        Dim tr As SqlTransaction = Nothing
        Using cn As New SqlConnection(utilities.getconn)
            Try
                cn.Open()
                tr = cn.BeginTransaction
                Using cm As New SqlCommand(qry, cn, tr)
                    cm.Parameters.AddWithValue("@idu", iduser)
                    cm.Parameters.AddWithValue("@idm", idmulti)
                    cm.Parameters.AddWithValue("@no", nopengeluaran)
                    cm.Parameters.AddWithValue("@tgl", tanggalkeluar)
                    cm.Parameters.AddWithValue("@jml", jumlahkeluar)
                    cm.Parameters.AddWithValue("@ids", idsatuan)
                    cm.Parameters.AddWithValue("@hrg", hargajual)
                    cm.Parameters.AddWithValue("@dis", diskon)
                    cm.Parameters.AddWithValue("@ket", keterangan)
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
    Public Shared Sub InputJualMulti(ByVal iduser As Guid, ByVal iditem As Guid, ByVal idmulti As Guid, ByVal nopengeluaran As String, ByVal tanggalkeluar As Date, ByVal jumlahkeluar As Decimal, ByVal idsatuan As Guid, ByVal hargajual As Decimal, ByVal diskon As Decimal, ByVal keterangan As String, ByVal remark As String, ByVal usermodified As String)
        Dim qry As String = "insert into pengeluaran (iduser,iditem,idmulti,nopengeluaran,tanggalkeluar,jumlahkeluar,idsatuan,hargajual,diskon,keterangan,remark,createdate,lastmodified,usermodified,statusaktif) " & _
                            "values (@idu,@idi,@idm,@no,@tgl,@jml,@ids,@hrg,@dis,@ket,@rem,@cre,@las,@use,@sta)"
        Dim tr As SqlTransaction = Nothing
        Using cn As New SqlConnection(utilities.getconn)
            Try
                cn.Open()
                tr = cn.BeginTransaction
                Using cm As New SqlCommand(qry, cn, tr)
                    cm.Parameters.AddWithValue("@idu", iduser)
                    cm.Parameters.AddWithValue("@idi", iditem)
                    cm.Parameters.AddWithValue("@idm", idmulti)
                    cm.Parameters.AddWithValue("@no", nopengeluaran)
                    cm.Parameters.AddWithValue("@tgl", tanggalkeluar)
                    cm.Parameters.AddWithValue("@jml", jumlahkeluar)
                    cm.Parameters.AddWithValue("@ids", idsatuan)
                    cm.Parameters.AddWithValue("@hrg", hargajual)
                    cm.Parameters.AddWithValue("@dis", diskon)
                    cm.Parameters.AddWithValue("@ket", keterangan)
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
    Public Shared Function GetKategoriItem(ByVal namaitem As String) As DataTable
        Dim dt As New DataTable
        Dim qry As String = "select k.namakategori from masteritem i inner join masterkategori k on i.idkategori=k.idkategori where i.namaitem=@nm and i.statusaktif=1"
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
    Public Shared Function GetConsJasa(ByVal iditemjasa As Guid) As DataTable
        Dim dt As New DataTable
        Dim qry As String = "select iditemjasa,namaitem,qtycons from masterconsumption where iditemjasa=@id and statusaktif=1"
        Using cn As New SqlConnection(utilities.getconn)
            Try
                cn.Open()
                Using cm As New SqlCommand(qry, cn)
                    cm.Parameters.AddWithValue("@id", iditemjasa)
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
