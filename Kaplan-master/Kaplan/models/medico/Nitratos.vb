Namespace Clases
    Public Class Nitratos
        Public Property Id As Integer
        Public Property colId As String
        Public Property Descripcion As String
        Public Property Dosis As String

        Public Shared Function MapeoNitratos(prmDatos As DataTable) As List(Of Nitratos)
            Try
                MapeoNitratos = New List(Of Nitratos)
                For Each vRow As DataRow In prmDatos.Rows
                    Dim vClass As New Nitratos
                    vClass.Id = vRow("id").ToString
                    vClass.colId = "colId" & vRow("id").ToString
                    vClass.Descripcion = vRow("descripcion").ToString
                    vClass.Dosis = vRow("dosis").ToString
                    MapeoNitratos.Add(vClass)
                Next
                Return MapeoNitratos
            Catch ex As Exception
                Return Nothing
            End Try

        End Function

    End Class
End Namespace