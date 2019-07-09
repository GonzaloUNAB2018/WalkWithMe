Namespace Clases
    Public Class BloqueadorCorrientes
        Public Property Id As Integer
        Public Property colId As String
        Public Property Descripcion As String
        Public Property Dosis As String

        Public Shared Function MapeoBloqueadorCorrientes(prmDatos As DataTable) As List(Of BloqueadorCorrientes)
            Try
                MapeoBloqueadorCorrientes = New List(Of BloqueadorCorrientes)
                For Each vRow As DataRow In prmDatos.Rows
                    Dim vClass As New BloqueadorCorrientes
                    vClass.Id = vRow("id").ToString
                    vClass.colId = "colId" & vRow("id").ToString
                    vClass.Descripcion = vRow("descripcion").ToString
                    vClass.Dosis = vRow("dosis").ToString
                    MapeoBloqueadorCorrientes.Add(vClass)
                Next
                Return MapeoBloqueadorCorrientes
            Catch ex As Exception
                Return Nothing
            End Try

        End Function

    End Class
End Namespace
