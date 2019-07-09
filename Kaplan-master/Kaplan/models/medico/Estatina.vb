Namespace Clases
    Public Class Estatina
        Public Property Id As Integer
        Public Property colId As String
        Public Property Descripcion As String
        Public Property Dosis As String

        Public Shared Function MapeoEstatina(prmDatos As DataTable) As List(Of Estatina)
            Try
                MapeoEstatina = New List(Of Estatina)
                For Each vRow As DataRow In prmDatos.Rows
                    Dim vClass As New Estatina
                    vClass.Id = vRow("id").ToString
                    vClass.colId = "colId" & vRow("id").ToString
                    vClass.Descripcion = vRow("descripcion").ToString
                    vClass.Dosis = vRow("dosis").ToString
                    MapeoEstatina.Add(vClass)
                Next
                Return MapeoEstatina
            Catch ex As Exception
                Return Nothing
            End Try

        End Function

    End Class
End Namespace