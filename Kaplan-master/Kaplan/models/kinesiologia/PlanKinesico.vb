Imports Kaplan.Clases
Imports System.Globalization
Imports System.Data.OleDb
Imports System.Data.SqlClient
Imports Newtonsoft.Json

Namespace Clases
    Public Class CollectionssDiagnostico
        Public Property column As PlanKinesicoDiagnostico()
    End Class

    Public Class CollectionssObjetivo
        Public Property column As PlanKinesicoObjetivo()
    End Class


    Public Class PlanKinesico
        Public Property Id As Integer
        Public Property AEROBICO As String
        Public Property SOBRECARGA As String
        Public Property FUNCIONAL As String
        Public Property EDUCACION As String
        Public Property Diagnostico As List(Of PlanKinesicoDiagnostico)
        Public Property Objetivo As List(Of PlanKinesicoObjetivo)

        Public Shared Function MapeoPlan(prmDatos As DataTable) As PlanKinesico
            Try
                Dim vPlan As New PlanKinesico
                Dim prmRow As DataRow = prmDatos.Rows(0)

                vPlan.Id = prmRow("id_plan_kine").ToString
                vPlan.AEROBICO = prmRow("eje_aerobico").ToString
                vPlan.SOBRECARGA = prmRow("eje_sobrecarga").ToString
                vPlan.FUNCIONAL = prmRow("entre_funcional").ToString
                vPlan.EDUCACION = prmRow("edu_habitos_cardio").ToString

                Return vPlan
            Catch ex As Exception
                Return Nothing
            End Try
        End Function

        Public Function ToJSONDiagnostico(rows As List(Of PlanKinesicoDiagnostico)) As String
            Dim data As New CollectionssDiagnostico

            data = New CollectionssDiagnostico With {.column = rows.ToArray}
            ToJSONDiagnostico = JsonConvert.SerializeObject(data)
            Return ToJSONDiagnostico
        End Function

        Public Function ToJSONObjetivo(rows As List(Of PlanKinesicoObjetivo)) As String
            Dim data As New CollectionssObjetivo

            data = New CollectionssObjetivo With {.column = rows.ToArray}
            ToJSONObjetivo = JsonConvert.SerializeObject(data)
            Return ToJSONObjetivo
        End Function

    End Class
End Namespace
