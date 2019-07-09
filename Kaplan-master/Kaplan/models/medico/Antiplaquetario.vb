Namespace Clases
    Public Class Antiplaquetario
        Public Property Id As Integer
        Public Property colId As String
        Public Property Descripcion As String
        Public Property Dosis As String

        Public Shared Function MapeoAntiplaquetario(prmDatos As DataTable) As List(Of Antiplaquetario)
            Try
                MapeoAntiplaquetario = New List(Of Antiplaquetario)
                For Each vRow As DataRow In prmDatos.Rows
                    Dim vClass As New Antiplaquetario
                    vClass.Id = vRow("id").ToString
                    vClass.colId = "colId" & vRow("id").ToString
                    vClass.Descripcion = vRow("descripcion").ToString
                    vClass.Dosis = vRow("dosis").ToString
                    MapeoAntiplaquetario.Add(vClass)
                Next
                Return MapeoAntiplaquetario
            Catch ex As Exception
                Return Nothing
            End Try

        End Function

    End Class
End Namespace
