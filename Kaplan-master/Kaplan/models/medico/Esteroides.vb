Namespace Clases
    Public Class Esteroides
        Public Property Id As Integer
        Public Property colId As String
        Public Property Descripcion As String
        Public Property Dosis As String

        Public Shared Function MapeoEsteroides(prmDatos As DataTable) As List(Of Esteroides)
            Try
                MapeoEsteroides = New List(Of Esteroides)
                For Each vRow As DataRow In prmDatos.Rows
                    Dim vClass As New Esteroides
                    vClass.Id = vRow("id").ToString
                    vClass.colId = "colId" & vRow("id").ToString
                    vClass.Descripcion = vRow("descripcion").ToString
                    vClass.Dosis = vRow("dosis").ToString
                    MapeoEsteroides.Add(vClass)
                Next
                Return MapeoEsteroides
            Catch ex As Exception
                Return Nothing
            End Try

        End Function

    End Class
End Namespace