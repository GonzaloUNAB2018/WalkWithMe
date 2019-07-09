Namespace Clases
    Public Class MedicamentosEnfermeria
        Public Property Id As Integer
        Public Property colId As String
        Public Property Nombre As String
        Public Property Observacion As String
        Public Property Dosis As Double
        Public Property Horario As String

        Public Shared Function MapeoMedicamentos(prmDatos As DataTable) As List(Of MedicamentosEnfermeria)
            Try
                MapeoMedicamentos = New List(Of MedicamentosEnfermeria)
                For Each vRow As DataRow In prmDatos.Rows
                    Dim vClass As New MedicamentosEnfermeria
                    vClass.Id = vRow("id_medicamento").ToString
                    vClass.colId = "colId" & vRow("id_medicamento").ToString
                    vClass.Nombre = vRow("nombre").ToString
                    vClass.Observacion = vRow("glosa").ToString
                    vClass.Dosis = vRow("dosis").ToString
                    vClass.Horario = vRow("horario").ToString
                    MapeoMedicamentos.Add(vClass)
                Next
                Return MapeoMedicamentos
            Catch ex As Exception
                Return Nothing
            End Try

        End Function


    End Class
End Namespace

