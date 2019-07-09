Namespace Clases
    Public Class IECA
        Public Property Id As Integer
        Public Property colId As String
        Public Property Descripcion As String
        Public Property Dosis As String

        Public Shared Function MapeoIECA(prmDatos As DataTable) As List(Of IECA)
            Try
                MapeoIECA = New List(Of IECA)
                For Each vRow As DataRow In prmDatos.Rows
                    Dim vClass As New IECA
                    vClass.Id = vRow("id").ToString
                    vClass.colId = "colId" & vRow("id").ToString
                    vClass.Descripcion = vRow("descripcion").ToString
                    vClass.Dosis = vRow("dosis").ToString
                    MapeoIECA.Add(vClass)
                Next
                Return MapeoIECA
            Catch ex As Exception
                Return Nothing
            End Try

        End Function

    End Class
End Namespace
