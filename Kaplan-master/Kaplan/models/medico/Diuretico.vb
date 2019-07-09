Namespace Clases
    Public Class Diuretico
        Public Property Id As Integer
        Public Property colId As String
        Public Property Descripcion As String
        Public Property Dosis As String

        Public Shared Function MapeoDiuretico(prmDatos As DataTable) As List(Of Diuretico)
            Try
                MapeoDiuretico = New List(Of Diuretico)
                For Each vRow As DataRow In prmDatos.Rows
                    Dim vClass As New Diuretico
                    vClass.Id = vRow("id").ToString
                    vClass.colId = "colId" & vRow("id").ToString
                    vClass.Descripcion = vRow("descripcion").ToString
                    vClass.Dosis = vRow("dosis").ToString
                    MapeoDiuretico.Add(vClass)
                Next
                Return MapeoDiuretico
            Catch ex As Exception
                Return Nothing
            End Try

        End Function

    End Class
End Namespace