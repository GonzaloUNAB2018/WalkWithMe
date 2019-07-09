Namespace Clases
    Public Class Hipoglicemiante
        Public Property Id As Integer
        Public Property colId As String
        Public Property Descripcion As String
        Public Property Dosis As String

        Public Shared Function MapeoHipoglicemiante(prmDatos As DataTable) As List(Of Hipoglicemiante)
            Try
                MapeoHipoglicemiante = New List(Of Hipoglicemiante)
                For Each vRow As DataRow In prmDatos.Rows
                    Dim vClass As New Hipoglicemiante
                    vClass.Id = vRow("id").ToString
                    vClass.colId = "colId" & vRow("id").ToString
                    vClass.Descripcion = vRow("descripcion").ToString
                    vClass.Dosis = vRow("dosis").ToString
                    MapeoHipoglicemiante.Add(vClass)
                Next
                Return MapeoHipoglicemiante
            Catch ex As Exception
                Return Nothing
            End Try

        End Function

    End Class
End Namespace
