Imports Kaplan.Clases
Imports System.Globalization
Imports System.Data.OleDb
Imports System.Data.SqlClient

Namespace Clases

    Public Class FichaKinesiologia
        Public Property Id As Integer
        Public Property IdReserva As Integer
        Public Property Riesgo As String
        Public Property NumeroSesion As Integer
        Public Property IdEspecialista As Integer
        Public Property TipoEvaluacion As String
        Public Property ERGOESPIROMETRIA As ERGOESPIROMETRIA
        Public Property SHUTTLE As SHUTTLE
        Public Property EvolucionEgresoKine As EvolucionEgresoKine
        Public Property EvolucionIngresoKine As EvolucionIngresoKine
        Public Property PlanKinesico As PlanKinesico
        Public Shared Function MapeoFichaKine(prmDatos As DataTable) As FichaKinesiologia
            Try
                Dim vKinesiologia As New FichaKinesiologia

                Dim prmRow As DataRow = prmDatos.Rows(0)

                vKinesiologia.Id = prmRow("id_ficha_kine").ToString
                vKinesiologia.IdReserva = prmRow("id_reserva").ToString
                vKinesiologia.Riesgo = prmRow("riesgo").ToString
                vKinesiologia.TipoEvaluacion = prmRow("tipo_evaluacion").ToString

                Dim vERGOESPIROMETRIA As New ERGOESPIROMETRIA
                vERGOESPIROMETRIA.EFechaEgreso = prmRow("ergo_fecha_egr").ToString
                vERGOESPIROMETRIA.EFechaIngreso = prmRow("ergo_fecha_ing").ToString
                vERGOESPIROMETRIA.VO2LEgreso = Double.Parse(prmRow("ergo_vol_egr"))
                vERGOESPIROMETRIA.VO2LIngreso = Double.Parse(prmRow("ergo_vol_ing"))
                vERGOESPIROMETRIA.VO2MEgreso = Double.Parse(prmRow("ergo_voml_egr"))
                vERGOESPIROMETRIA.VO2MIngreso = Double.Parse(prmRow("ergo_voml_ing"))
                vERGOESPIROMETRIA.FCEgreso = Double.Parse(prmRow("ergo_fcmax_egr"))
                vERGOESPIROMETRIA.FCIngreso = Double.Parse(prmRow("ergo_fcmax_ing"))
                vERGOESPIROMETRIA.PulsoEgreso = Double.Parse(prmRow("ergo_pulso_egr"))
                vERGOESPIROMETRIA.PulsoIngreso = Double.Parse(prmRow("ergo_pulso_ing"))
                vERGOESPIROMETRIA.VEEgreso = Double.Parse(prmRow("ergo_ve_egr"))
                vERGOESPIROMETRIA.VEIngreso = Double.Parse(prmRow("ergo_ve_ing"))
                vERGOESPIROMETRIA.METSEgreso = Double.Parse(prmRow("ergo_mets_egr"))
                vERGOESPIROMETRIA.METSIngreso = Double.Parse(prmRow("ergo_mets_ing"))
                vKinesiologia.ERGOESPIROMETRIA = vERGOESPIROMETRIA

                Dim vSHUTTLE As New SHUTTLE
                vSHUTTLE.EFechaEgreso = prmRow("shu_fecha_egr").ToString
                vSHUTTLE.EFechaIngreso = prmRow("shu_fecha_ing").ToString
                vSHUTTLE.METROSEgreso = Double.Parse(prmRow("shu_mts_egr"))
                vSHUTTLE.METROSIngreso = Double.Parse(prmRow("shu_mts_ing"))
                vSHUTTLE.NIVELEgreso = Double.Parse(prmRow("shu_niv_egr"))
                vSHUTTLE.NIVELIngreso = Double.Parse(prmRow("shu_niv_ing"))
                vSHUTTLE.VO2MEgreso = Double.Parse(prmRow("shu_vol_egr"))
                vSHUTTLE.VO2MIngreso = Double.Parse(prmRow("shu_vol_ing"))
                vSHUTTLE.METSEgreso = Double.Parse(prmRow("shu_mets_egr"))
                vSHUTTLE.METSIngreso = Double.Parse(prmRow("shu_mets_ing"))
                vSHUTTLE.FCEgreso = Double.Parse(prmRow("shu_fcmax_egr"))
                vSHUTTLE.FCIngreso = Double.Parse(prmRow("shu_fcmax_ing"))
                vSHUTTLE.FCMTEgreso = Double.Parse(prmRow("shu_fcmt_egr"))
                vSHUTTLE.FCMTIngreso = Double.Parse(prmRow("shu_fcmt_ing"))
                vSHUTTLE.METSMAXEgreso = Double.Parse(prmRow("shu_metsmax_egr"))
                vSHUTTLE.METSMAXIngreso = Double.Parse(prmRow("shu_metsmax_ing"))
                vKinesiologia.SHUTTLE = vSHUTTLE

                Return vKinesiologia
            Catch ex As Exception
                Return Nothing
            End Try

        End Function

    End Class
End Namespace