Imports Kaplan.Clases
Imports System.Globalization
Imports System.Data.OleDb
Imports System.Data.SqlClient
Namespace Clases
    Public Class FichaPsicologia
        Public Property Id As Integer
        Public Property IdReserva As Integer
        Public Property IdEspecialista As Integer
        Public Property Sintomatologia As Tipos.TipoSintomatologia
        Public Property DerivacionAPS As Tipos.TipoDerivacionAPS
        Public Property ApoyoSocial As Tipos.TipoApoyoSocial
        Public Property ProblemaPsicosocial As Tipos.TipoProblemaPsicosocial
        Public Property RasgoPersonalidad As Tipos.TipoRasgoPersonalidad
        Public Property TrastornoMental As Tipos.TipoTrastornoMental
        Public Property TraumaPostOp As Tipos.TipoTraumaPostOp
        Public Property ConcienciaFactor As Tipos.TipoConcienciaFactor
        Public Property DificultadResp As Tipos.TipoDificultadResp
        Public Property IngresoTaller As Tipos.TipoIngresoTaller
        Public Property Tratamiento As Tipos.TipoTratamiento
        Public Property Observacion As String
        Public Property Sf36 As Sf36
        Public Property Had As Had
        Public Property Antecedentes As String
        Public Property Diagnostico As String
        Public Property Objetivo As String
        Public Property Intervencion As String
        Public Property Evaluacion As String
        Public Property Evolucion As String
        Public Shared Function MapeoFichaPsicologia(prmDatos As DataTable) As FichaPsicologia
            Try
                Dim vPsicologia As New FichaPsicologia

                Dim prmRow As DataRow = prmDatos.Rows(0)

                vPsicologia.Id = prmRow("id_ficha_psico")
                vPsicologia.IdReserva = prmRow("id_reserva")
                vPsicologia.IdEspecialista = prmRow("id_especialista")
                vPsicologia.Sintomatologia = Tipos.TipoSintomatologia.getTipo(prmRow("sinto_prev"))
                vPsicologia.DerivacionAPS = Tipos.TipoDerivacionAPS.getTipo(prmRow("deriv_aps"))
                vPsicologia.ApoyoSocial = Tipos.TipoApoyoSocial.getTipo(prmRow("apoyo_soc"))
                vPsicologia.ProblemaPsicosocial = Tipos.TipoProblemaPsicosocial.getTipo(prmRow("prob_psico"))
                vPsicologia.RasgoPersonalidad = Tipos.TipoRasgoPersonalidad.getTipo(prmRow("rasgo_perso"))
                vPsicologia.TrastornoMental = Tipos.TipoTrastornoMental.getTipo(prmRow("trast_mental"))
                vPsicologia.TraumaPostOp = Tipos.TipoTraumaPostOp.getTipo(prmRow("trauma_post"))
                vPsicologia.ConcienciaFactor = Tipos.TipoConcienciaFactor.getTipo(prmRow("conci_factor"))
                vPsicologia.DificultadResp = Tipos.TipoDificultadResp.getTipo(prmRow("dific_resp"))
                vPsicologia.IngresoTaller = Tipos.TipoIngresoTaller.getTipo(prmRow("ingre_taller"))
                vPsicologia.Tratamiento = Tipos.TipoTratamiento.getTipo(prmRow("tratamiento"))
                vPsicologia.Observacion = prmRow("observacion").ToString
                vPsicologia.Antecedentes = prmRow("antecedente").ToString
                vPsicologia.Diagnostico = prmRow("diagnostico").ToString
                vPsicologia.Objetivo = prmRow("objetivo").ToString
                vPsicologia.Intervencion = prmRow("intervencion").ToString
                vPsicologia.Evaluacion = prmRow("evaluacion").ToString
                vPsicologia.Evolucion = prmRow("evolucion").ToString

                Dim vSf36 As New Sf36
                vSf36.FechaAIng = prmRow("sf_fechaa_ing").ToString
                vSf36.FechaAEgr = prmRow("sf_fechaa_egr").ToString
                vSf36.FuncionFisicaIng = Double.Parse(prmRow("sf_funcion_ing"))
                vSf36.FuncionFisicaEgr = Double.Parse(prmRow("sf_funcion_egr"))
                vSf36.RolFisicoIng = Double.Parse(prmRow("sf_rol_ing"))
                vSf36.RolFisicoEgr = Double.Parse(prmRow("sf_rol_egr"))
                vSf36.DolorIng = Double.Parse(prmRow("sf_dolor_ing"))
                vSf36.DolorEgr = Double.Parse(prmRow("sf_dolor_egr"))
                vSf36.SaludIng = Double.Parse(prmRow("sf_salud_ing"))
                vSf36.SaludEgr = Double.Parse(prmRow("sf_salud_egr"))
                vSf36.FechaBIng = prmRow("sf_fechab_ing").ToString
                vSf36.FechaBEgr = prmRow("sf_fechab_egr").ToString
                vSf36.VitalidadIng = Double.Parse(prmRow("sf_vital_ing"))
                vSf36.VitalidadEgr = Double.Parse(prmRow("sf_vital_egr"))
                vSf36.FuncionSocialIng = Double.Parse(prmRow("sf_funcionsoc_ing"))
                vSf36.FuncionSocialEgr = Double.Parse(prmRow("sf_funcionsoc_egr"))
                vSf36.RolEmocionalIng = Double.Parse(prmRow("sf_rolemo_ing"))
                vSf36.RolEmocionalEgr = Double.Parse(prmRow("sf_rolemo_egr"))
                vSf36.SaludMentalIng = Double.Parse(prmRow("sf_saludmen_ing"))
                vSf36.SaludMentalEgr = Double.Parse(prmRow("sf_saludmen_egr"))
                vSf36.Observacion = prmRow("sf_observacion").ToString
                vPsicologia.Sf36 = vSf36

                Dim vHad As New Had
                vHad.FechaAIng = prmRow("had_fechaa_ing").ToString
                vHad.FechaAIng = prmRow("had_fechaa_egr").ToString
                vHad.AnsiedadIng = Double.Parse(prmRow("had_ansie_ing"))
                vHad.AnsiedadEgr = Double.Parse(prmRow("had_ansie_egr"))
                vHad.DepresionIng = Double.Parse(prmRow("had_depre_ing"))
                vHad.DepresionEgr = Double.Parse(prmRow("had_depre_egr"))
                vHad.FechaBIng = prmRow("had_fechab_ing").ToString
                vHad.FechaBIng = prmRow("had_fechab_egr").ToString
                vHad.SubEscalaAnsiedadIng = Double.Parse(prmRow("had_suba_ing"))
                vHad.SubEscalaAnsiedadEgr = Double.Parse(prmRow("had_suba_egr"))
                vHad.SubEscalaDepresionIng = Double.Parse(prmRow("had_subd_ing"))
                vHad.SubEscalaDepresionEgr = Double.Parse(prmRow("had_subd_egr"))
                vHad.Observacion = prmRow("had_observacion").ToString
                vPsicologia.Had = vHad
                Return vPsicologia
            Catch ex As Exception
                Return Nothing
            End Try

        End Function
    End Class
End Namespace
