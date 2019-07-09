
Imports Kaplan.Clases
Imports System.Globalization
Imports System.Data.OleDb
Imports System.Data.SqlClient

Namespace Clases

    Public Class PlanKinesicoDiagnostico

        Public Property Id As Integer
        Public Property Tipo As Tipos.TipoDiagnosticoKine
        Public Property colId As String


        Public Shared Function MapeoDiagnostico(prmDatos As DataTable) As List(Of PlanKinesicoDiagnostico)
            Try
                MapeoDiagnostico = New List(Of PlanKinesicoDiagnostico)
                For Each vRow As DataRow In prmDatos.Rows
                    Dim vDiagnostico As New PlanKinesicoDiagnostico
                    vDiagnostico.Id = vRow("id_diagnostico").ToString
                    vDiagnostico.colId = "colId" & vRow("id_diagnostico").ToString
                    vDiagnostico.Tipo = Tipos.TipoDiagnosticoKine.getTipo(vRow("id_tipoDiag"))
                    MapeoDiagnostico.Add(vDiagnostico)
                Next
                Return MapeoDiagnostico
            Catch ex As Exception
                Return Nothing
            End Try

        End Function

    End Class
End Namespace
