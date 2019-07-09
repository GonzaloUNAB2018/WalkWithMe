Namespace Clases
    Public Class Antiarritmicos
        Public Property Id As Integer
        Public Property colId As String
        Public Property Descripcion As String
        Public Property Dosis As String
        Public Shared Function MapeoAntiarritmicos(prmDatos As DataTable) As List(Of Antiarritmicos)
            Try
                MapeoAntiarritmicos = New List(Of Antiarritmicos)
                For Each vRow As DataRow In prmDatos.Rows
                    Dim vClass As New Antiarritmicos
                    vClass.Id = vRow("id").ToString
                    vClass.colId = "colId" & vRow("id").ToString
                    vClass.Descripcion = vRow("descripcion").ToString
                    vClass.Dosis = vRow("dosis").ToString
                    MapeoAntiarritmicos.Add(vClass)
                Next
                Return MapeoAntiarritmicos
            Catch ex As Exception
                Return Nothing
            End Try

        End Function

    End Class
End Namespace