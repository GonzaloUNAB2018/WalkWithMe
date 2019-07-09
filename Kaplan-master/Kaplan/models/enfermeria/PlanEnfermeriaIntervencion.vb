Namespace Clases
    Public Class PlanEnfermeriaIntervencion
        Public Property Id As Integer
        Public Property Tipo As Tipos.TipoIntervencion
        Public Property colId As String
        Public Shared Function MapeoIntervencion(prmDatos As DataTable) As List(Of PlanEnfermeriaIntervencion)
            Try
                MapeoIntervencion = New List(Of PlanEnfermeriaIntervencion)
                For Each vRow As DataRow In prmDatos.Rows
                    Dim vClass As New PlanEnfermeriaIntervencion
                    vClass.Id = vRow("id_cuidados").ToString
                    vClass.colId = "colId" & vRow("id_cuidados").ToString
                    vClass.Tipo = Tipos.TipoIntervencion.getTipo(vRow("cuidado"))
                    MapeoIntervencion.Add(vClass)
                Next
                Return MapeoIntervencion
            Catch ex As Exception
                Return Nothing
            End Try

        End Function


    End Class
End Namespace