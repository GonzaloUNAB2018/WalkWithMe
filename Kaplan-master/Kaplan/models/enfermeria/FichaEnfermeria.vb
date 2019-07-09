Imports Newtonsoft.Json
Namespace Clases
    Public Class CollectionssMedicamentos
        Public Property column As MedicamentosEnfermeria()
    End Class
    Public Class CollectionssEvolucion
        Public Property column As EvolucionEnfermeria()
    End Class

    Public Class FichaEnfermeria
        Public Property Id As Integer
        Public Property IdReserva As Integer
        Public Property TipoEvaluacion As String
        Public Property Procedencia As String
        Public Property IdEspecialista As Integer
        Public Property Diagnostico As String
        Public Property FechaDiagnostico As Date
        Public Property CxProced As String
        Public Property FechaCxProced As Date
        Public Property Controles As String
        Public Property FechaAlta As Date
        Public Property HeridaCX As String
        Public Property HTA As Tipos.TipoHTA
        Public Property DM As Tipos.TipoDM
        Public Property DLP As Tipos.TipoDLP
        Public Property SED As Tipos.TipoSED
        Public Property SPOB As Tipos.TipoSPOB
        Public Property TB As Tipos.TipoTB
        Public Property OH As Tipos.TipoOH
        Public Property AF As Tipos.TipoAF
        Public Property Estres As Tipos.TipoEstres
        Public Property Intervencion As String
        Public Property MedicamentosEnfermeria As List(Of MedicamentosEnfermeria)
        Public Property AnamnesisEnfermeria As AnamnesisEnfermeria
        Public Property ExamenFisicoEnfermeria As ExamenFisicoEnfermeria
        Public Property EvolucionEnfermeria As List(Of EvolucionEnfermeria)
        Public Property PlanEnfermeria As PlanEnfermeria
        Public Shared Function MapeoFichaEnfermeria(prmDatos As DataTable) As FichaEnfermeria
            Try
                Dim vEnfermeria As New FichaEnfermeria

                Dim prmRow As DataRow = prmDatos.Rows(0)

                vEnfermeria.Id = prmRow("id_ficha_enf").ToString
                vEnfermeria.IdReserva = prmRow("id_reserva").ToString
                vEnfermeria.Diagnostico = prmRow("diagnostico").ToString
                vEnfermeria.TipoEvaluacion = prmRow("tipo_evaluacion").ToString

                vEnfermeria.CxProced = prmRow("cx_proced").ToString
                vEnfermeria.FechaDiagnostico = prmRow("diag_fecha").ToString
                vEnfermeria.FechaCxProced = prmRow("cx_pro_fecha").ToString
                vEnfermeria.FechaAlta = prmRow("fecha_alta").ToString
                vEnfermeria.Controles = prmRow("controles").ToString
                vEnfermeria.Procedencia = prmRow("procedencia").ToString
                vEnfermeria.HeridaCX = prmRow("heridacx").ToString
                vEnfermeria.HTA = Tipos.TipoHTA.getTipo(prmRow("fr_hta"))
                vEnfermeria.DM = Tipos.TipoDM.getTipo(prmRow("fr_dm"))
                vEnfermeria.DLP = Tipos.TipoDLP.getTipo(prmRow("fr_dlp"))
                vEnfermeria.SED = Tipos.TipoSED.getTipo(prmRow("fr_sed"))
                vEnfermeria.SPOB = Tipos.TipoSPOB.getTipo(prmRow("fr_spob"))
                vEnfermeria.TB = Tipos.TipoTB.getTipo(prmRow("fr_tb"))
                vEnfermeria.OH = Tipos.TipoOH.getTipo(prmRow("fr_oh"))
                vEnfermeria.AF = Tipos.TipoAF.getTipo(prmRow("fr_af"))
                vEnfermeria.Estres = Tipos.TipoEstres.getTipo(prmRow("fr_estres"))
                vEnfermeria.Intervencion = prmRow("intervencion").ToString

                Return vEnfermeria
            Catch ex As Exception
                Return Nothing
            End Try

        End Function
        Public Function ToJSONMedicamentos(rows As List(Of MedicamentosEnfermeria)) As String
            Dim data As New CollectionssMedicamentos

            data = New CollectionssMedicamentos With {.column = rows.ToArray}
            ToJSONMedicamentos = JsonConvert.SerializeObject(data)
            Return ToJSONMedicamentos
        End Function
        Public Function ToJSONEvolucion(rows As List(Of EvolucionEnfermeria)) As String
            Dim data As New CollectionssEvolucion

            data = New CollectionssEvolucion With {.column = rows.ToArray}
            ToJSONEvolucion = JsonConvert.SerializeObject(data)
            Return ToJSONEvolucion
        End Function

    End Class
End Namespace
