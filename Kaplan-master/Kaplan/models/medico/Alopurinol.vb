Namespace Clases
    Public Class Alopurinol
        Public Property Id As Integer
        Public Property colId As String
        Public Property Descripcion As String
        Public Property Dosis As String

        Public Shared Function MapeoAlopurinol(prmDatos As DataTable) As List(Of Alopurinol)
            Try
                MapeoAlopurinol = New List(Of Alopurinol)
                For Each vRow As DataRow In prmDatos.Rows
                    Dim vClass As New Alopurinol
                    vClass.Id = vRow("id").ToString
                    vClass.colId = "colId" & vRow("id").ToString
                    vClass.Descripcion = vRow("descripcion").ToString
                    vClass.Dosis = vRow("dosis").ToString
                    MapeoAlopurinol.Add(vClass)
                Next
                Return MapeoAlopurinol
            Catch ex As Exception
                Return Nothing
            End Try

        End Function

    End Class
End Namespace