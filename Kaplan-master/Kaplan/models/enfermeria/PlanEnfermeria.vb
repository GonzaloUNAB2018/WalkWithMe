Imports Newtonsoft.Json
Namespace Clases
    Public Class CollectionssDiagnosticos
        Public Property column As PlanEnfermeriaDiagnostico()
    End Class
    Public Class CollectionssIntervencion
        Public Property column As PlanEnfermeriaIntervencion()
    End Class
    Public Class CollectionssIndicador
        Public Property column As PlanEnfermeriaIndicador()
    End Class
    Public Class PlanEnfermeria
        Public Property Id As Integer
        Public Property AdeherenciaFarma As Tipos.TipoAdherenciaFarma
        Public Property Respiracion As Tipos.TipoValoracion
        Public Property Alimentacion As Tipos.TipoValoracion
        Public Property Eliminacion As Tipos.TipoValoracion
        Public Property Descanso As Tipos.TipoValoracion
        Public Property HigienePiel As Tipos.TipoValoracion
        Public Property Actividades As Tipos.TipoValoracion
        Public Property Vestirse As Tipos.TipoValoracion
        Public Property Comunicarse As Tipos.TipoValoracion
        Public Property AutoRealizacion As Tipos.TipoValoracion
        Public Property RespiracionObservacion As String
        Public Property AlimentacionObservacion As String
        Public Property EliminacionObservacion As String
        Public Property DescansoObservacion As String
        Public Property HigienePielObservacion As String
        Public Property ActividadesObservacion As String
        Public Property VestirseObservacion As String
        Public Property ComunicarseObservacion As String
        Public Property AutoRealizacionObservacion As String
        Public Property Objetivo As String
        Public Property Diagnostico As List(Of PlanEnfermeriaDiagnostico)
        Public Property Intervencion As List(Of PlanEnfermeriaIntervencion)
        Public Property Indicadores As List(Of PlanEnfermeriaIndicador)
        Public Shared Function MapeoPlanEnfermeria(prmDatos As DataTable) As PlanEnfermeria
            Try
                Dim vPlan As New PlanEnfermeria

                Dim prmRow As DataRow = prmDatos.Rows(0)

                vPlan.Id = prmRow("id_plan_enf").ToString
                vPlan.AdeherenciaFarma = Tipos.TipoAdherenciaFarma.getTipo(prmRow("adh_farma"))
                vPlan.Respiracion = Tipos.TipoValoracion.getTipo(prmRow("respiracion"))
                vPlan.Respiracion = Tipos.TipoValoracion.getTipo(prmRow("respiracion"))
                vPlan.Alimentacion = Tipos.TipoValoracion.getTipo(prmRow("alimentacion"))
                vPlan.Eliminacion = Tipos.TipoValoracion.getTipo(prmRow("elminacion"))
                vPlan.Descanso = Tipos.TipoValoracion.getTipo(prmRow("descanso"))
                vPlan.HigienePiel = Tipos.TipoValoracion.getTipo(prmRow("higiene_piel"))
                vPlan.Actividades = Tipos.TipoValoracion.getTipo(prmRow("actividades"))
                vPlan.Vestirse = Tipos.TipoValoracion.getTipo(prmRow("vestirse"))
                vPlan.Comunicarse = Tipos.TipoValoracion.getTipo(prmRow("comunicarse"))
                vPlan.AutoRealizacion = Tipos.TipoValoracion.getTipo(prmRow("auto_real"))
                vPlan.RespiracionObservacion = prmRow("respiracion_obs").ToString
                vPlan.AlimentacionObservacion = prmRow("alimentacion_obs").ToString
                vPlan.EliminacionObservacion = prmRow("eliminacion_obs").ToString
                vPlan.DescansoObservacion = prmRow("descanso_obs").ToString
                vPlan.HigienePielObservacion = prmRow("higiene_piel_obs").ToString
                vPlan.ActividadesObservacion = prmRow("actividades_obs").ToString
                vPlan.VestirseObservacion = prmRow("vestirse_obs").ToString
                vPlan.ComunicarseObservacion = prmRow("comunicarse_obs").ToString
                vPlan.AutoRealizacionObservacion = prmRow("auto_real_obs").ToString
                vPlan.Objetivo = prmRow("objetivo").ToString

                Return vPlan
            Catch ex As Exception
                Return Nothing
            End Try

        End Function
        Public Function ToJSONDiagnosticos(rows As List(Of PlanEnfermeriaDiagnostico)) As String
            Dim data As New CollectionssDiagnosticos

            data = New CollectionssDiagnosticos With {.column = rows.ToArray}
            ToJSONDiagnosticos = JsonConvert.SerializeObject(data)
            Return ToJSONDiagnosticos
        End Function
        Public Function ToJSONIntervencion(rows As List(Of PlanEnfermeriaIntervencion)) As String
            Dim data As New CollectionssIntervencion

            data = New CollectionssIntervencion With {.column = rows.ToArray}
            ToJSONIntervencion = JsonConvert.SerializeObject(data)
            Return ToJSONIntervencion
        End Function
        Public Function ToJSONIndicador(rows As List(Of PlanEnfermeriaIndicador)) As String
            Dim data As New CollectionssIndicador

            data = New CollectionssIndicador With {.column = rows.ToArray}
            ToJSONIndicador = JsonConvert.SerializeObject(data)
            Return ToJSONIndicador
        End Function

    End Class
End Namespace
