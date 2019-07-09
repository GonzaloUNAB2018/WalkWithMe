
Imports Kaplan.Clases
Imports System.Globalization
Imports System.Data.OleDb
Imports System.Data.SqlClient

Namespace Clases


    Public Class PlanKinesicoObjetivo
        Public Property Id As Integer
        Public Property Tipo As Tipos.TipoObjetivoKine
        Public Property colId As String

        Public Shared Function MapeoObjetivo(prmDatos As DataTable) As List(Of PlanKinesicoObjetivo)
            Try
                MapeoObjetivo = New List(Of PlanKinesicoObjetivo)
                For Each vRow As DataRow In prmDatos.Rows
                    Dim vObjetivo As New PlanKinesicoObjetivo
                    vObjetivo.Id = vRow("id_objetivo").ToString
                    vObjetivo.colId = "colId" & vRow("id_objetivo").ToString
                    vObjetivo.Tipo = Tipos.TipoObjetivoKine.getTipo(vRow("id_tipoObj"))
                    MapeoObjetivo.Add(vObjetivo)
                Next
                Return MapeoObjetivo
            Catch ex As Exception
                Return Nothing
            End Try

        End Function

    End Class
End Namespace
