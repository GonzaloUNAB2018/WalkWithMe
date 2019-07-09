Namespace Clases
    Public Class PlanEnfermeriaIndicador
        Public Property Id As Integer
        Public Property Tipo As Tipos.TipoIndicador
        Public Property colId As String
        Public Property Inicio As Integer
        Public Property Final As Integer
        Public Shared Function MapeoIndicador(prmDatos As DataTable) As List(Of PlanEnfermeriaIndicador)
            Try
                MapeoIndicador = New List(Of PlanEnfermeriaIndicador)
                For Each vRow As DataRow In prmDatos.Rows
                    Dim vClass As New PlanEnfermeriaIndicador
                    vClass.Id = vRow("id_indicador").ToString
                    vClass.colId = "colId" & vRow("id_indicador").ToString
                    vClass.Tipo = Tipos.TipoIndicador.getTipo(vRow("indicador"))
                    vClass.Inicio = vRow("inicio").ToString
                    vClass.Final = vRow("final").ToString
                    MapeoIndicador.Add(vClass)
                Next
                Return MapeoIndicador
            Catch ex As Exception
                Return Nothing
            End Try

        End Function


    End Class
End Namespace
