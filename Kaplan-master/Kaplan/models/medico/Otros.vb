Namespace Clases
    Public Class Otros
        Public Property Id As Integer
        Public Property colId As String
        Public Property Descripcion As String
        Public Property Dosis As String
        Public Shared Function MapeoOtros(prmDatos As DataTable) As List(Of Otros)
            Try
                MapeoOtros = New List(Of Otros)
                For Each vRow As DataRow In prmDatos.Rows
                    Dim vClass As New Otros
                    vClass.Id = vRow("id").ToString
                    vClass.colId = "colId" & vRow("id").ToString
                    vClass.Descripcion = vRow("descripcion").ToString
                    vClass.Dosis = vRow("dosis").ToString
                    MapeoOtros.Add(vClass)
                Next
                Return MapeoOtros
            Catch ex As Exception
                Return Nothing
            End Try

        End Function

    End Class
End Namespace