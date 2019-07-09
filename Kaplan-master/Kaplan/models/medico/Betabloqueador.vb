Namespace Clases
    Public Class Betabloqueador
        Public Property Id As Integer
        Public Property colId As String
        Public Property Descripcion As String
        Public Property Dosis As String

        Public Shared Function MapeoBetabloqueador(prmDatos As DataTable) As List(Of Betabloqueador)
            Try
                MapeoBetabloqueador = New List(Of Betabloqueador)
                For Each vRow As DataRow In prmDatos.Rows
                    Dim vClass As New Betabloqueador
                    vClass.Id = vRow("id").ToString
                    vClass.colId = "colId" & vRow("id").ToString
                    vClass.Descripcion = vRow("descripcion").ToString
                    vClass.Dosis = vRow("dosis").ToString
                    MapeoBetabloqueador.Add(vClass)
                Next
                Return MapeoBetabloqueador
            Catch ex As Exception
                Return Nothing
            End Try

        End Function

    End Class
End Namespace