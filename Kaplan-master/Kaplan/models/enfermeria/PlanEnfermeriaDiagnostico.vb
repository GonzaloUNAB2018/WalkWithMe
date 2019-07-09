Namespace Clases
    Public Class PlanEnfermeriaDiagnostico
        Public Property Id As Integer
        Public Property Tipo As Tipos.TipoDiagnosticoEnfermeria
        Public Property colId As String
        Public Shared Function MapeoDiagnostico(prmDatos As DataTable) As List(Of PlanEnfermeriaDiagnostico)
            Try
                MapeoDiagnostico = New List(Of PlanEnfermeriaDiagnostico)
                For Each vRow As DataRow In prmDatos.Rows
                    Dim vClass As New PlanEnfermeriaDiagnostico
                    vClass.Id = vRow("id_diagnostico").ToString
                    vClass.colId = "colId" & vRow("id_diagnostico").ToString
                    vClass.Tipo = Tipos.TipoDiagnosticoEnfermeria.getTipo(vRow("diagnostico"))
                    MapeoDiagnostico.Add(vClass)
                Next
                Return MapeoDiagnostico
            Catch ex As Exception
                Return Nothing
            End Try

        End Function

    End Class
End Namespace