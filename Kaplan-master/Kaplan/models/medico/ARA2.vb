Namespace Clases
    Public Class ARA2
        Public Property Id As Integer
        Public Property colId As String
        Public Property Descripcion As String
        Public Property Dosis As String

        Public Shared Function MapeoARA2(prmDatos As DataTable) As List(Of ARA2)
            Try
                MapeoARA2 = New List(Of ARA2)
                For Each vRow As DataRow In prmDatos.Rows
                    Dim vClass As New ARA2
                    vClass.Id = vRow("id").ToString
                    vClass.colId = "colId" & vRow("id").ToString
                    vClass.Descripcion = vRow("descripcion").ToString
                    vClass.Dosis = vRow("dosis").ToString
                    MapeoARA2.Add(vClass)
                Next
                Return MapeoARA2
            Catch ex As Exception
                Return Nothing
            End Try

        End Function
    End Class
End Namespace