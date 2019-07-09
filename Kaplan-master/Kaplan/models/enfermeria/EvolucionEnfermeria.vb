Namespace Clases
    Public Class EvolucionEnfermeria
        Public Property Id As Integer
        Public Property colId As String
        Public Property Fecha As Date
        Public Property Evolucion As String
        Public Shared Function MapeoEvolucion(prmDatos As DataTable) As List(Of EvolucionEnfermeria)
            Try
                MapeoEvolucion = New List(Of EvolucionEnfermeria)
                For Each vRow As DataRow In prmDatos.Rows
                    Dim vClass As New EvolucionEnfermeria
                    vClass.Id = vRow("id_evolucion").ToString
                    vClass.colId = "colId" & vRow("id_evolucion").ToString
                    vClass.Evolucion = vRow("evolucion").ToString
                    vClass.Fecha = vRow("fecha").ToString
                    MapeoEvolucion.Add(vClass)
                Next
                Return MapeoEvolucion
            Catch ex As Exception
                Return Nothing
            End Try

        End Function


    End Class
End Namespace