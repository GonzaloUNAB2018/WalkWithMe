Imports Kaplan.Clases
Imports System.Globalization
Imports System.Data.OleDb
Imports System.Data.SqlClient

Namespace Clases
    Public Class Ficha
        Public Property Id As Integer
        Public Property Numero As Integer
        Public Property Fecha As Date
        Public ReadOnly Property FechaString As String
            Get
                Return Fecha.ToString("dd MMM yyyy")
            End Get
        End Property
        Public Property Paciente As Paciente
        Public Property FichaKinesiologia As FichaKinesiologia
        Public Property FichaPsicologia As FichaPsicologia
        Public Property FichaNutricion As FichaNutricion
        Public Property FichaEnfermeria As FichaEnfermeria
        Public Property FichaMedico As FichaMedico
#Region "Kinesiología"
        Public Shared Function getFichaKinesiologia(inId As Integer, ByRef NoData As Boolean) As Ficha
            Try
                Dim conn As OleDbConnection = New OleDbConnection(ConfigurationManager.ConnectionStrings("ConexionKaplan").ConnectionString)
                Dim cmd As OleDbCommand = New OleDbCommand("Kaplan.BuscarFichaKinesiologiaxReserva", conn)
                cmd.CommandType = CommandType.StoredProcedure

                Dim id As OleDbParameter = cmd.Parameters.Add("@inId", OleDbType.Decimal, Nothing)
                id.Direction = ParameterDirection.Input
                id.Value = inId

                Dim adapter As OleDbDataAdapter = New OleDbDataAdapter(cmd)
                Dim vDataSet As New DataSet
                adapter.Fill(vDataSet)
                If Not vDataSet.Tables(0).Rows.Count.Equals(0) Then
                    getFichaKinesiologia = MapeoFichaKine(vDataSet)
                End If

                If vDataSet.Tables(0).Rows.Count = 0 Then NoData = True

                Return getFichaKinesiologia

            Catch exc As Exception
                Return Nothing
            End Try

        End Function
        Private Shared Function MapeoFichaKine(prmDatos As DataSet) As Ficha
            Try
                Dim vficha As New Ficha
                Dim vKinesiologia As New FichaKinesiologia
                Dim vEvolucionE As New EvolucionEgresoKine
                Dim vEvolucionI As New EvolucionIngresoKine
                Dim vPlanKinesico As New PlanKinesico
                Dim vDiagnostico As New PlanKinesicoDiagnostico
                Dim vObjetivo As New PlanKinesicoObjetivo

                vficha.FichaKinesiologia = vKinesiologia.MapeoFichaKine(prmDatos.Tables(0))
                vficha.FichaKinesiologia.EvolucionEgresoKine = vEvolucionE.Mapeo(prmDatos.Tables(1))
                vficha.FichaKinesiologia.EvolucionIngresoKine = vEvolucionI.Mapeo(prmDatos.Tables(1))
                vficha.FichaKinesiologia.PlanKinesico = vPlanKinesico.MapeoPlan(prmDatos.Tables(4))
                vficha.FichaKinesiologia.PlanKinesico.Diagnostico = vDiagnostico.MapeoDiagnostico(prmDatos.Tables(2))
                vficha.FichaKinesiologia.PlanKinesico.Objetivo = vObjetivo.MapeoObjetivo(prmDatos.Tables(3))

                Return vficha
            Catch ex As Exception
                Return Nothing
            End Try

        End Function
        Public Function registrarFichaKinesiologia() As Boolean
            Dim conn As OleDbConnection = New OleDbConnection(ConfigurationManager.ConnectionStrings("ConexionKaplan").ConnectionString)
            Dim cmd As OleDbCommand = New OleDbCommand("Kaplan.RegistrarFichaKinesiologia", conn)
            cmd.CommandType = CommandType.StoredProcedure

            Dim inId As OleDbParameter = cmd.Parameters.Add("@id_ficha", OleDbType.Decimal, Nothing)
            inId.Direction = ParameterDirection.Input
            inId.Value = Me.Id

            Dim inIdKine As OleDbParameter = cmd.Parameters.Add("@id_ficha_kine", OleDbType.Decimal, Nothing)
            inIdKine.Direction = ParameterDirection.Input
            inIdKine.Value = Me.FichaKinesiologia.Id

            Dim inid_reserva As OleDbParameter = cmd.Parameters.Add("@id_reserva", OleDbType.Decimal, Nothing)
            inid_reserva.Direction = ParameterDirection.Input
            inid_reserva.Value = Me.FichaKinesiologia.IdReserva

            Dim inRiesgo As OleDbParameter = cmd.Parameters.Add("@riesgo", OleDbType.VarChar, 500)
            inRiesgo.Direction = ParameterDirection.Input
            inRiesgo.Value = Me.FichaKinesiologia.Riesgo

            Dim inTipoEvaluacion As OleDbParameter = cmd.Parameters.Add("@TipoEvaluacion", OleDbType.VarChar, 500)
            inTipoEvaluacion.Direction = ParameterDirection.Input
            inTipoEvaluacion.Value = Me.FichaKinesiologia.TipoEvaluacion

            Dim inIdEspecialista As OleDbParameter = cmd.Parameters.Add("@id_especialista", OleDbType.Decimal, Nothing)
            inIdEspecialista.Direction = ParameterDirection.Input
            inIdEspecialista.Value = Me.FichaKinesiologia.IdEspecialista

            Dim inErgo_fecha_ing As OleDbParameter = cmd.Parameters.Add("@ergo_fecha_ing", OleDbType.Date, Nothing)
            inErgo_fecha_ing.Direction = ParameterDirection.Input
            inErgo_fecha_ing.Value = Me.FichaKinesiologia.ERGOESPIROMETRIA.EFechaIngreso

            Dim inErgo_fecha_egr As OleDbParameter = cmd.Parameters.Add("@ergo_fecha_egr", OleDbType.Date, Nothing)
            inErgo_fecha_egr.Direction = ParameterDirection.Input
            inErgo_fecha_egr.Value = Me.FichaKinesiologia.ERGOESPIROMETRIA.EFechaEgreso

            Dim inergo_vol_ing As OleDbParameter = cmd.Parameters.Add("@ergo_vol_ing", OleDbType.Decimal, Nothing)
            inergo_vol_ing.Direction = ParameterDirection.Input
            inergo_vol_ing.Value = Me.FichaKinesiologia.ERGOESPIROMETRIA.VO2LIngreso

            Dim inergo_vol_egr As OleDbParameter = cmd.Parameters.Add("@ergo_vol_egr", OleDbType.Decimal, Nothing)
            inergo_vol_egr.Direction = ParameterDirection.Input
            inergo_vol_egr.Value = Me.FichaKinesiologia.ERGOESPIROMETRIA.VO2LEgreso

            Dim inergo_voml_ing As OleDbParameter = cmd.Parameters.Add("@ergo_voml_ing", OleDbType.Decimal, Nothing)
            inergo_voml_ing.Direction = ParameterDirection.Input
            inergo_voml_ing.Value = Me.FichaKinesiologia.ERGOESPIROMETRIA.VO2MIngreso

            Dim inergo_voml_egr As OleDbParameter = cmd.Parameters.Add("@ergo_voml_egr", OleDbType.Decimal, Nothing)
            inergo_voml_egr.Direction = ParameterDirection.Input
            inergo_voml_egr.Value = Me.FichaKinesiologia.ERGOESPIROMETRIA.VO2MEgreso

            Dim inergo_fcmax_ing As OleDbParameter = cmd.Parameters.Add("@ergo_fcmax_ing", OleDbType.Decimal, Nothing)
            inergo_fcmax_ing.Direction = ParameterDirection.Input
            inergo_fcmax_ing.Value = Me.FichaKinesiologia.ERGOESPIROMETRIA.FCIngreso

            Dim inergo_fcmax_egr As OleDbParameter = cmd.Parameters.Add("@ergo_fcmax_egr", OleDbType.Decimal, Nothing)
            inergo_fcmax_egr.Direction = ParameterDirection.Input
            inergo_fcmax_egr.Value = Me.FichaKinesiologia.ERGOESPIROMETRIA.FCEgreso

            Dim inergo_pulso_ing As OleDbParameter = cmd.Parameters.Add("@ergo_pulso_ing", OleDbType.Decimal, Nothing)
            inergo_pulso_ing.Direction = ParameterDirection.Input
            inergo_pulso_ing.Value = Me.FichaKinesiologia.ERGOESPIROMETRIA.PulsoIngreso

            Dim inergo_pulso_egr As OleDbParameter = cmd.Parameters.Add("@ergo_pulso_egr", OleDbType.Decimal, Nothing)
            inergo_pulso_egr.Direction = ParameterDirection.Input
            inergo_pulso_egr.Value = Me.FichaKinesiologia.ERGOESPIROMETRIA.PulsoEgreso

            Dim inergo_ve_ing As OleDbParameter = cmd.Parameters.Add("@ergo_ve_ing", OleDbType.Decimal, Nothing)
            inergo_ve_ing.Direction = ParameterDirection.Input
            inergo_ve_ing.Value = Me.FichaKinesiologia.ERGOESPIROMETRIA.VEIngreso

            Dim inergo_ve_egr As OleDbParameter = cmd.Parameters.Add("@ergo_ve_egr", OleDbType.Decimal, Nothing)
            inergo_ve_egr.Direction = ParameterDirection.Input
            inergo_ve_egr.Value = Me.FichaKinesiologia.ERGOESPIROMETRIA.VEEgreso

            Dim inergo_mets_ing As OleDbParameter = cmd.Parameters.Add("@ergo_mets_ing", OleDbType.Decimal, Nothing)
            inergo_mets_ing.Direction = ParameterDirection.Input
            inergo_mets_ing.Value = Me.FichaKinesiologia.ERGOESPIROMETRIA.METSIngreso

            Dim inergo_mets_egr As OleDbParameter = cmd.Parameters.Add("@ergo_mets_egr", OleDbType.Decimal, Nothing)
            inergo_mets_egr.Direction = ParameterDirection.Input
            inergo_mets_egr.Value = Me.FichaKinesiologia.ERGOESPIROMETRIA.METSEgreso

            Dim inshu_fecha_ing As OleDbParameter = cmd.Parameters.Add("@shu_fecha_ing", OleDbType.Date, Nothing)
            inshu_fecha_ing.Direction = ParameterDirection.Input
            inshu_fecha_ing.Value = Me.FichaKinesiologia.SHUTTLE.EFechaIngreso

            Dim inshu_fecha_egr As OleDbParameter = cmd.Parameters.Add("@shu_fecha_egr", OleDbType.Date, Nothing)
            inshu_fecha_egr.Direction = ParameterDirection.Input
            inshu_fecha_egr.Value = Me.FichaKinesiologia.SHUTTLE.EFechaEgreso

            Dim inshu_mts_ing As OleDbParameter = cmd.Parameters.Add("@shu_mts_ing", OleDbType.Decimal, Nothing)
            inshu_mts_ing.Direction = ParameterDirection.Input
            inshu_mts_ing.Value = Me.FichaKinesiologia.SHUTTLE.METROSIngreso

            Dim inshu_mts_egr As OleDbParameter = cmd.Parameters.Add("@shu_mts_egr", OleDbType.Decimal, Nothing)
            inshu_mts_egr.Direction = ParameterDirection.Input
            inshu_mts_egr.Value = Me.FichaKinesiologia.SHUTTLE.METROSEgreso

            Dim inshu_niv_ing As OleDbParameter = cmd.Parameters.Add("@shu_niv_ing", OleDbType.Decimal, Nothing)
            inshu_niv_ing.Direction = ParameterDirection.Input
            inshu_niv_ing.Value = Me.FichaKinesiologia.SHUTTLE.NIVELIngreso

            Dim inshu_niv_egr As OleDbParameter = cmd.Parameters.Add("@shu_niv_egr", OleDbType.Decimal, Nothing)
            inshu_niv_egr.Direction = ParameterDirection.Input
            inshu_niv_egr.Value = Me.FichaKinesiologia.SHUTTLE.NIVELEgreso

            Dim inshu_vol_ing As OleDbParameter = cmd.Parameters.Add("@shu_vol_ing", OleDbType.Decimal, Nothing)
            inshu_vol_ing.Direction = ParameterDirection.Input
            inshu_vol_ing.Value = Me.FichaKinesiologia.SHUTTLE.VO2MIngreso

            Dim inshu_vol_egr As OleDbParameter = cmd.Parameters.Add("@shu_vol_egr", OleDbType.Decimal, Nothing)
            inshu_vol_egr.Direction = ParameterDirection.Input
            inshu_vol_egr.Value = Me.FichaKinesiologia.SHUTTLE.VO2MEgreso

            Dim inshu_mets_ing As OleDbParameter = cmd.Parameters.Add("@shu_mets_ing", OleDbType.Decimal, Nothing)
            inshu_mets_ing.Direction = ParameterDirection.Input
            inshu_mets_ing.Value = Me.FichaKinesiologia.SHUTTLE.METSIngreso

            Dim inshu_mets_egr As OleDbParameter = cmd.Parameters.Add("@shu_mets_egr", OleDbType.Decimal, Nothing)
            inshu_mets_egr.Direction = ParameterDirection.Input
            inshu_mets_egr.Value = Me.FichaKinesiologia.SHUTTLE.METSEgreso

            Dim inshu_fcmax_ing As OleDbParameter = cmd.Parameters.Add("@shu_fcmax_ing", OleDbType.Decimal, Nothing)
            inshu_fcmax_ing.Direction = ParameterDirection.Input
            inshu_fcmax_ing.Value = Me.FichaKinesiologia.SHUTTLE.FCIngreso

            Dim inshu_fcmax_egr As OleDbParameter = cmd.Parameters.Add("@shu_fcmax_egr", OleDbType.Decimal, Nothing)
            inshu_fcmax_egr.Direction = ParameterDirection.Input
            inshu_fcmax_egr.Value = Me.FichaKinesiologia.SHUTTLE.FCEgreso

            Dim inshu_fcmt_ing As OleDbParameter = cmd.Parameters.Add("@shu_fcmt_ing", OleDbType.Decimal, Nothing)
            inshu_fcmt_ing.Direction = ParameterDirection.Input
            inshu_fcmt_ing.Value = Me.FichaKinesiologia.SHUTTLE.FCMTIngreso

            Dim inshu_fcmt_egr As OleDbParameter = cmd.Parameters.Add("@shu_fcmt_egr", OleDbType.Decimal, Nothing)
            inshu_fcmt_egr.Direction = ParameterDirection.Input
            inshu_fcmt_egr.Value = Me.FichaKinesiologia.SHUTTLE.FCMTEgreso

            Dim inshu_metsmax_ing As OleDbParameter = cmd.Parameters.Add("@shu_metsmax_ing", OleDbType.Decimal, Nothing)
            inshu_metsmax_ing.Direction = ParameterDirection.Input
            inshu_metsmax_ing.Value = Me.FichaKinesiologia.SHUTTLE.METSMAXIngreso

            Dim inshu_metsmax_egr As OleDbParameter = cmd.Parameters.Add("@shu_metsmax_egr", OleDbType.Decimal, Nothing)
            inshu_metsmax_egr.Direction = ParameterDirection.Input
            inshu_metsmax_egr.Value = Me.FichaKinesiologia.SHUTTLE.METSMAXEgreso

            Dim inid_evolucion_1 As OleDbParameter = cmd.Parameters.Add("@Diagnostico", OleDbType.Decimal, Nothing)
            inid_evolucion_1.Direction = ParameterDirection.Input
            inid_evolucion_1.Value = Me.FichaKinesiologia.EvolucionIngresoKine.Id

            Dim inevolucion_fecha_1 As OleDbParameter = cmd.Parameters.Add("@evolucion_fecha_1", OleDbType.Date, Nothing)
            inevolucion_fecha_1.Direction = ParameterDirection.Input
            inevolucion_fecha_1.Value = Me.FichaKinesiologia.EvolucionIngresoKine.Fecha

            Dim inevolucion_eva_mus_esq_1 As OleDbParameter = cmd.Parameters.Add("@evolucion_eva_mus_esq_1", OleDbType.VarChar, 500)
            inevolucion_eva_mus_esq_1.Direction = ParameterDirection.Input
            inevolucion_eva_mus_esq_1.Value = Me.FichaKinesiologia.EvolucionIngresoKine.EME

            Dim inevolcuion_observacion_1 As OleDbParameter = cmd.Parameters.Add("@evolcuion_observacion_1", OleDbType.VarChar, 500)
            inevolcuion_observacion_1.Direction = ParameterDirection.Input
            inevolcuion_observacion_1.Value = Me.FichaKinesiologia.EvolucionIngresoKine.Observacion

            Dim inid_evolucion_2 As OleDbParameter = cmd.Parameters.Add("@id_evolucion_2", OleDbType.Decimal, Nothing)
            inid_evolucion_2.Direction = ParameterDirection.Input
            inid_evolucion_2.Value = Me.FichaKinesiologia.EvolucionEgresoKine.Id

            Dim inevolucion_fecha_2 As OleDbParameter = cmd.Parameters.Add("@evolucion_fecha_2", OleDbType.Date, Nothing)
            inevolucion_fecha_2.Direction = ParameterDirection.Input
            inevolucion_fecha_2.Value = Me.FichaKinesiologia.EvolucionEgresoKine.Fecha

            Dim inevolucion_eva_mus_esq_2 As OleDbParameter = cmd.Parameters.Add("@evolucion_eva_mus_esq_2", OleDbType.VarChar, 500)
            inevolucion_eva_mus_esq_2.Direction = ParameterDirection.Input
            inevolucion_eva_mus_esq_2.Value = Me.FichaKinesiologia.EvolucionEgresoKine.EME

            Dim inevolcuion_observacion_2 As OleDbParameter = cmd.Parameters.Add("@evolcuion_observacion_2", OleDbType.VarChar, 500)
            inevolcuion_observacion_2.Direction = ParameterDirection.Input
            inevolcuion_observacion_2.Value = Me.FichaKinesiologia.EvolucionEgresoKine.Observacion

            Dim inidPlan_kine As OleDbParameter = cmd.Parameters.Add("@v_idPlan_kine", OleDbType.Decimal, Nothing)
            inidPlan_kine.Direction = ParameterDirection.Input
            inidPlan_kine.Value = Me.FichaKinesiologia.PlanKinesico.Id

            Dim ineje_aerobico As OleDbParameter = cmd.Parameters.Add("@eje_aerobico", OleDbType.VarChar, 500)
            ineje_aerobico.Direction = ParameterDirection.Input
            ineje_aerobico.Value = Me.FichaKinesiologia.PlanKinesico.AEROBICO

            Dim ineje_sobrecarga As OleDbParameter = cmd.Parameters.Add("@eje_sobrecarga", OleDbType.VarChar, 500)
            ineje_sobrecarga.Direction = ParameterDirection.Input
            ineje_sobrecarga.Value = Me.FichaKinesiologia.PlanKinesico.SOBRECARGA

            Dim inentre_funcional As OleDbParameter = cmd.Parameters.Add("@entre_funcional", OleDbType.VarChar, 500)
            inentre_funcional.Direction = ParameterDirection.Input
            inentre_funcional.Value = Me.FichaKinesiologia.PlanKinesico.FUNCIONAL

            Dim inedu_habitos_cardio As OleDbParameter = cmd.Parameters.Add("@edu_habitos_cardio", OleDbType.VarChar, 500)
            inedu_habitos_cardio.Direction = ParameterDirection.Input
            inedu_habitos_cardio.Value = Me.FichaKinesiologia.PlanKinesico.EDUCACION

            Dim indiagnostico As OleDbParameter = cmd.Parameters.Add("@diagnostico", OleDbType.VarChar, -1)
            indiagnostico.Direction = ParameterDirection.Input
            indiagnostico.Value = Me.FichaKinesiologia.PlanKinesico.ToJSONDiagnostico(Me.FichaKinesiologia.PlanKinesico.Diagnostico)

            Dim inobjetivo As OleDbParameter = cmd.Parameters.Add("@objetivo", OleDbType.VarChar, -1)
            inobjetivo.Direction = ParameterDirection.Input
            inobjetivo.Value = Me.FichaKinesiologia.PlanKinesico.ToJSONObjetivo(Me.FichaKinesiologia.PlanKinesico.Objetivo)

            Dim outError As OleDbParameter = cmd.Parameters.Add("@outError", OleDbType.Integer)
            outError.Direction = ParameterDirection.Output

            Dim outIdKine As OleDbParameter = cmd.Parameters.Add("@outIdKine", OleDbType.Integer)
            outIdKine.Direction = ParameterDirection.Output

            conn.Open()
            cmd.ExecuteReader()
            conn.Close()

            Dim idkine = CInt(cmd.Parameters("@outIdKine").Value)

            Return CInt(cmd.Parameters("@outError").Value)
        End Function
#End Region
#Region "Psicología"
        Public Shared Function getFichaPsicologia(inId As Integer, ByRef NoData As Boolean) As Ficha
            Try
                Dim conn As OleDbConnection = New OleDbConnection(ConfigurationManager.ConnectionStrings("ConexionKaplan").ConnectionString)
                Dim cmd As OleDbCommand = New OleDbCommand("Kaplan.BuscarFichaPsicologiaxReserva", conn)
                cmd.CommandType = CommandType.StoredProcedure

                Dim id As OleDbParameter = cmd.Parameters.Add("@inId", OleDbType.Decimal, Nothing)
                id.Direction = ParameterDirection.Input
                id.Value = inId

                Dim adapter As OleDbDataAdapter = New OleDbDataAdapter(cmd)
                Dim vDataSet As New DataSet
                adapter.Fill(vDataSet)
                If Not vDataSet.Tables(0).Rows.Count.Equals(0) Then
                    getFichaPsicologia = MapeoFichaPsicologia(vDataSet)
                End If

                If vDataSet.Tables(0).Rows.Count = 0 Then NoData = True

                Return getFichaPsicologia

            Catch exc As Exception
                Return Nothing
            End Try

        End Function
        Private Shared Function MapeoFichaPsicologia(prmDatos As DataSet) As Ficha
            Try
                Dim vficha As New Ficha
                Dim vPsicologia As New FichaPsicologia
                vficha.FichaPsicologia = vPsicologia.MapeoFichaPsicologia(prmDatos.Tables(0))
                Return vficha
            Catch ex As Exception
                Return Nothing
            End Try

        End Function
#Region "Ficha Psicología"
        Public Function registrarFichaPsicologia() As Boolean
            Dim conn As OleDbConnection = New OleDbConnection(ConfigurationManager.ConnectionStrings("ConexionKaplan").ConnectionString)
            Dim cmd As OleDbCommand = New OleDbCommand("Kaplan.RegistrarFichaPsicologia", conn)
            cmd.CommandType = CommandType.StoredProcedure

            Dim inId As OleDbParameter = cmd.Parameters.Add("@id_ficha", OleDbType.Decimal, Nothing)
            inId.Direction = ParameterDirection.Input
            inId.Value = Me.Id

            Dim inIdPsico As OleDbParameter = cmd.Parameters.Add("@id_ficha_psico", OleDbType.Decimal, Nothing)
            inIdPsico.Direction = ParameterDirection.Input
            inIdPsico.Value = Me.FichaPsicologia.Id

            Dim inIdEspecialista As OleDbParameter = cmd.Parameters.Add("@id_especialista", OleDbType.Decimal, Nothing)
            inIdEspecialista.Direction = ParameterDirection.Input
            inIdEspecialista.Value = Me.FichaPsicologia.IdEspecialista

            Dim inid_reserva As OleDbParameter = cmd.Parameters.Add("@id_reserva", OleDbType.Decimal, Nothing)
            inid_reserva.Direction = ParameterDirection.Input
            inid_reserva.Value = Me.FichaPsicologia.IdReserva

            Dim inSintomatologia As OleDbParameter = cmd.Parameters.Add("@sinto_prev", OleDbType.Decimal, Nothing)
            inSintomatologia.Direction = ParameterDirection.Input
            inSintomatologia.Value = Me.FichaPsicologia.Sintomatologia.ID

            Dim inDerivacionAPS As OleDbParameter = cmd.Parameters.Add("@deriv_aps", OleDbType.Decimal, Nothing)
            inDerivacionAPS.Direction = ParameterDirection.Input
            inDerivacionAPS.Value = Me.FichaPsicologia.DerivacionAPS.ID

            Dim inApoyoSocial As OleDbParameter = cmd.Parameters.Add("@apoyo_soc", OleDbType.Decimal, Nothing)
            inApoyoSocial.Direction = ParameterDirection.Input
            inApoyoSocial.Value = Me.FichaPsicologia.ApoyoSocial.ID

            Dim inProblemaPsicosocial As OleDbParameter = cmd.Parameters.Add("@prob_psico", OleDbType.Decimal, Nothing)
            inProblemaPsicosocial.Direction = ParameterDirection.Input
            inProblemaPsicosocial.Value = Me.FichaPsicologia.ProblemaPsicosocial.ID

            Dim inRasgoPersonalidad As OleDbParameter = cmd.Parameters.Add("@rasgo_perso", OleDbType.Decimal, Nothing)
            inRasgoPersonalidad.Direction = ParameterDirection.Input
            inRasgoPersonalidad.Value = Me.FichaPsicologia.RasgoPersonalidad.ID

            Dim inTrastornoMental As OleDbParameter = cmd.Parameters.Add("@trast_mental", OleDbType.Decimal, Nothing)
            inTrastornoMental.Direction = ParameterDirection.Input
            inTrastornoMental.Value = Me.FichaPsicologia.TrastornoMental.ID

            Dim inTraumaPostOp As OleDbParameter = cmd.Parameters.Add("@trauma_post", OleDbType.Decimal, Nothing)
            inTraumaPostOp.Direction = ParameterDirection.Input
            inTraumaPostOp.Value = Me.FichaPsicologia.TraumaPostOp.ID

            Dim inConcienciaFactor As OleDbParameter = cmd.Parameters.Add("@conci_factor", OleDbType.Decimal, Nothing)
            inConcienciaFactor.Direction = ParameterDirection.Input
            inConcienciaFactor.Value = Me.FichaPsicologia.ConcienciaFactor.ID

            Dim inDificultadResp As OleDbParameter = cmd.Parameters.Add("@dific_resp", OleDbType.Decimal, Nothing)
            inDificultadResp.Direction = ParameterDirection.Input
            inDificultadResp.Value = Me.FichaPsicologia.DificultadResp.ID

            Dim inIngresoTaller As OleDbParameter = cmd.Parameters.Add("@ingre_taller", OleDbType.Decimal, Nothing)
            inIngresoTaller.Direction = ParameterDirection.Input
            inIngresoTaller.Value = Me.FichaPsicologia.IngresoTaller.ID

            Dim inTratamiento As OleDbParameter = cmd.Parameters.Add("@tratamiento", OleDbType.Decimal, Nothing)
            inTratamiento.Direction = ParameterDirection.Input
            inTratamiento.Value = Me.FichaPsicologia.Tratamiento.ID

            Dim inObservacion As OleDbParameter = cmd.Parameters.Add("@observacion", OleDbType.VarChar, 500)
            inObservacion.Direction = ParameterDirection.Input
            inObservacion.Value = Me.FichaPsicologia.Observacion
#End Region
#Region "SF36"
            Dim inSFFechaAIng As OleDbParameter = cmd.Parameters.Add("@sf_fechaa_ing", OleDbType.Date, Nothing)
            inSFFechaAIng.Direction = ParameterDirection.Input
            inSFFechaAIng.Value = Me.FichaPsicologia.Sf36.FechaAIng

            Dim inSFFechaAEgr As OleDbParameter = cmd.Parameters.Add("@sf_fechaa_egr", OleDbType.Date, Nothing)
            inSFFechaAEgr.Direction = ParameterDirection.Input
            inSFFechaAEgr.Value = Me.FichaPsicologia.Sf36.FechaAIng

            Dim inFuncionFisicaIng As OleDbParameter = cmd.Parameters.Add("@sf_funcion_ing", OleDbType.Decimal, Nothing)
            inFuncionFisicaIng.Direction = ParameterDirection.Input
            inFuncionFisicaIng.Value = Me.FichaPsicologia.Sf36.FuncionFisicaIng

            Dim inFuncionFisicaEgr As OleDbParameter = cmd.Parameters.Add("@sf_funcion_egr", OleDbType.Decimal, Nothing)
            inFuncionFisicaEgr.Direction = ParameterDirection.Input
            inFuncionFisicaEgr.Value = Me.FichaPsicologia.Sf36.FuncionFisicaEgr

            Dim inRolFisicoIng As OleDbParameter = cmd.Parameters.Add("@sf_rol_ing", OleDbType.Decimal, Nothing)
            inRolFisicoIng.Direction = ParameterDirection.Input
            inRolFisicoIng.Value = Me.FichaPsicologia.Sf36.RolFisicoIng

            Dim inRolFisicoEgr As OleDbParameter = cmd.Parameters.Add("@sf_rol_egr", OleDbType.Decimal, Nothing)
            inRolFisicoEgr.Direction = ParameterDirection.Input
            inRolFisicoEgr.Value = Me.FichaPsicologia.Sf36.RolFisicoEgr

            Dim inDolorIng As OleDbParameter = cmd.Parameters.Add("@sf_dolor_ing", OleDbType.Decimal, Nothing)
            inDolorIng.Direction = ParameterDirection.Input
            inDolorIng.Value = Me.FichaPsicologia.Sf36.DolorIng

            Dim inDolorEgr As OleDbParameter = cmd.Parameters.Add("@sf_dolor_egr", OleDbType.Decimal, Nothing)
            inDolorEgr.Direction = ParameterDirection.Input
            inDolorEgr.Value = Me.FichaPsicologia.Sf36.DolorEgr

            Dim inSaludIng As OleDbParameter = cmd.Parameters.Add("@sf_salud_ing", OleDbType.Decimal, Nothing)
            inSaludIng.Direction = ParameterDirection.Input
            inSaludIng.Value = Me.FichaPsicologia.Sf36.SaludIng

            Dim inSaludEgr As OleDbParameter = cmd.Parameters.Add("@sf_salud_egr", OleDbType.Decimal, Nothing)
            inSaludEgr.Direction = ParameterDirection.Input
            inSaludEgr.Value = Me.FichaPsicologia.Sf36.SaludEgr

            Dim inSFFechaBIng As OleDbParameter = cmd.Parameters.Add("@sf_fechab_ing", OleDbType.Date, Nothing)
            inSFFechaBIng.Direction = ParameterDirection.Input
            inSFFechaBIng.Value = Me.FichaPsicologia.Sf36.FechaAIng

            Dim inSFFechaBEgr As OleDbParameter = cmd.Parameters.Add("@sf_fechab_egr", OleDbType.Date, Nothing)
            inSFFechaBEgr.Direction = ParameterDirection.Input
            inSFFechaBEgr.Value = Me.FichaPsicologia.Sf36.FechaAIng

            Dim inVitalidadIng As OleDbParameter = cmd.Parameters.Add("@sf_vital_ing", OleDbType.Decimal, Nothing)
            inVitalidadIng.Direction = ParameterDirection.Input
            inVitalidadIng.Value = Me.FichaPsicologia.Sf36.VitalidadIng

            Dim inVitalidadEgr As OleDbParameter = cmd.Parameters.Add("@sf_vital_egr", OleDbType.Decimal, Nothing)
            inVitalidadEgr.Direction = ParameterDirection.Input
            inVitalidadEgr.Value = Me.FichaPsicologia.Sf36.VitalidadEgr

            Dim inFuncionSocialIng As OleDbParameter = cmd.Parameters.Add("@sf_funcionsoc_ing", OleDbType.Decimal, Nothing)
            inFuncionSocialIng.Direction = ParameterDirection.Input
            inFuncionSocialIng.Value = Me.FichaPsicologia.Sf36.FuncionSocialIng

            Dim inFuncionSocialEgr As OleDbParameter = cmd.Parameters.Add("@sf_funcionsoc_egr", OleDbType.Decimal, Nothing)
            inFuncionSocialEgr.Direction = ParameterDirection.Input
            inFuncionSocialEgr.Value = Me.FichaPsicologia.Sf36.FuncionSocialEgr

            Dim inRolEmocionalIng As OleDbParameter = cmd.Parameters.Add("@sf_rolemo_ing", OleDbType.Decimal, Nothing)
            inRolEmocionalIng.Direction = ParameterDirection.Input
            inRolEmocionalIng.Value = Me.FichaPsicologia.Sf36.RolEmocionalIng

            Dim inRolEmocionalEgr As OleDbParameter = cmd.Parameters.Add("@sf_rolemo_egr", OleDbType.Decimal, Nothing)
            inRolEmocionalEgr.Direction = ParameterDirection.Input
            inRolEmocionalEgr.Value = Me.FichaPsicologia.Sf36.RolEmocionalEgr

            Dim inSaludMentalIng As OleDbParameter = cmd.Parameters.Add("@sf_saludmen_ing", OleDbType.Decimal, Nothing)
            inSaludMentalIng.Direction = ParameterDirection.Input
            inSaludMentalIng.Value = Me.FichaPsicologia.Sf36.SaludMentalIng

            Dim inSaludMentalEgr As OleDbParameter = cmd.Parameters.Add("@sf_saludmen_egr", OleDbType.Decimal, Nothing)
            inSaludMentalEgr.Direction = ParameterDirection.Input
            inSaludMentalEgr.Value = Me.FichaPsicologia.Sf36.SaludMentalEgr

            Dim inSFObservacion As OleDbParameter = cmd.Parameters.Add("@sf_observacion", OleDbType.VarChar, 500)
            inSFObservacion.Direction = ParameterDirection.Input
            inSFObservacion.Value = Me.FichaPsicologia.Sf36.Observacion
#End Region
#Region "HAD"
            Dim inHadFechaAIng As OleDbParameter = cmd.Parameters.Add("@had_fechaa_ing", OleDbType.Date, Nothing)
            inHadFechaAIng.Direction = ParameterDirection.Input
            inHadFechaAIng.Value = Me.FichaPsicologia.Had.FechaAIng

            Dim inHadFechaAEgr As OleDbParameter = cmd.Parameters.Add("@had_fechaa_egr", OleDbType.Date, Nothing)
            inHadFechaAEgr.Direction = ParameterDirection.Input
            inHadFechaAEgr.Value = Me.FichaPsicologia.Had.FechaAEgr

            Dim inAnsiedadIng As OleDbParameter = cmd.Parameters.Add("@had_ansie_ing", OleDbType.Decimal, Nothing)
            inAnsiedadIng.Direction = ParameterDirection.Input
            inAnsiedadIng.Value = Me.FichaPsicologia.Had.AnsiedadIng

            Dim inAnsiedadEgr As OleDbParameter = cmd.Parameters.Add("@had_ansie_egr", OleDbType.Decimal, Nothing)
            inAnsiedadEgr.Direction = ParameterDirection.Input
            inAnsiedadEgr.Value = Me.FichaPsicologia.Had.AnsiedadEgr


            Dim inDepresionIng As OleDbParameter = cmd.Parameters.Add("@had_depre_ing", OleDbType.Decimal, Nothing)
            inDepresionIng.Direction = ParameterDirection.Input
            inDepresionIng.Value = Me.FichaPsicologia.Had.DepresionIng

            Dim inDepresionEgr As OleDbParameter = cmd.Parameters.Add("@had_depre_egr", OleDbType.Decimal, Nothing)
            inDepresionEgr.Direction = ParameterDirection.Input
            inDepresionEgr.Value = Me.FichaPsicologia.Had.DepresionEgr

            Dim inHadFechaBIng As OleDbParameter = cmd.Parameters.Add("@had_fechab_ing", OleDbType.Date, Nothing)
            inHadFechaBIng.Direction = ParameterDirection.Input
            inHadFechaBIng.Value = Me.FichaPsicologia.Had.FechaBIng

            Dim inHadFechaBEgr As OleDbParameter = cmd.Parameters.Add("@had_fechab_egr", OleDbType.Date, Nothing)
            inHadFechaBEgr.Direction = ParameterDirection.Input
            inHadFechaBEgr.Value = Me.FichaPsicologia.Had.FechaBEgr

            Dim inSubEscalaAnsiedadIng As OleDbParameter = cmd.Parameters.Add("@had_suba_ing", OleDbType.Decimal, Nothing)
            inSubEscalaAnsiedadIng.Direction = ParameterDirection.Input
            inSubEscalaAnsiedadIng.Value = Me.FichaPsicologia.Had.SubEscalaAnsiedadIng

            Dim inSubEscalaAnsiedadEgr As OleDbParameter = cmd.Parameters.Add("@had_suba_egr", OleDbType.Decimal, Nothing)
            inSubEscalaAnsiedadEgr.Direction = ParameterDirection.Input
            inSubEscalaAnsiedadEgr.Value = Me.FichaPsicologia.Had.SubEscalaAnsiedadEgr

            Dim inSubEscalaDepresionIng As OleDbParameter = cmd.Parameters.Add("@had_subd_ing", OleDbType.Decimal, Nothing)
            inSubEscalaDepresionIng.Direction = ParameterDirection.Input
            inSubEscalaDepresionIng.Value = Me.FichaPsicologia.Had.SubEscalaDepresionIng

            Dim inSubEscalaDepresionEgr As OleDbParameter = cmd.Parameters.Add("@had_subd_egr", OleDbType.Decimal, Nothing)
            inSubEscalaDepresionEgr.Direction = ParameterDirection.Input
            inSubEscalaDepresionEgr.Value = Me.FichaPsicologia.Had.SubEscalaDepresionEgr

            Dim inHadObservacion As OleDbParameter = cmd.Parameters.Add("@had_observacion", OleDbType.VarChar, 500)
            inHadObservacion.Direction = ParameterDirection.Input
            inHadObservacion.Value = Me.FichaPsicologia.Had.Observacion
#End Region
            Dim inAntecedentes As OleDbParameter = cmd.Parameters.Add("@antecedentes", OleDbType.VarChar, 500)
            inAntecedentes.Direction = ParameterDirection.Input
            inAntecedentes.Value = Me.FichaPsicologia.Antecedentes

            Dim inDiagnostico As OleDbParameter = cmd.Parameters.Add("@diagnostico", OleDbType.VarChar, 500)
            inDiagnostico.Direction = ParameterDirection.Input
            inDiagnostico.Value = Me.FichaPsicologia.Diagnostico

            Dim inObjetivos As OleDbParameter = cmd.Parameters.Add("@objetivos", OleDbType.VarChar, 500)
            inObjetivos.Direction = ParameterDirection.Input
            inObjetivos.Value = Me.FichaPsicologia.Objetivo

            Dim inIntervencion As OleDbParameter = cmd.Parameters.Add("@intervencion", OleDbType.VarChar, 500)
            inIntervencion.Direction = ParameterDirection.Input
            inIntervencion.Value = Me.FichaPsicologia.Intervencion

            Dim inEvaluacion As OleDbParameter = cmd.Parameters.Add("@evaluacion", OleDbType.VarChar, 500)
            inEvaluacion.Direction = ParameterDirection.Input
            inEvaluacion.Value = Me.FichaPsicologia.Evaluacion

            Dim inEvolucion As OleDbParameter = cmd.Parameters.Add("@evolucion", OleDbType.VarChar, 500)
            inEvolucion.Direction = ParameterDirection.Input
            inEvolucion.Value = Me.FichaPsicologia.Evolucion

            Dim outError As OleDbParameter = cmd.Parameters.Add("@outError", OleDbType.Integer)
            outError.Direction = ParameterDirection.Output

            Dim outIdKine As OleDbParameter = cmd.Parameters.Add("@outIdPsico", OleDbType.Integer)
            outIdKine.Direction = ParameterDirection.Output

            conn.Open()
            cmd.ExecuteReader()
            conn.Close()

            Dim idpsico = CInt(cmd.Parameters("@outIdPsico").Value)

            Return CInt(cmd.Parameters("@outError").Value)
        End Function
#End Region
#Region "Enfermeria"
        Public Shared Function getFichaEnfermeria(inId As Integer, ByRef NoData As Boolean) As Ficha
            Try
                Dim conn As OleDbConnection = New OleDbConnection(ConfigurationManager.ConnectionStrings("ConexionKaplan").ConnectionString)
                Dim cmd As OleDbCommand = New OleDbCommand("Kaplan.BuscarFichaEnfermeriaxReserva", conn)
                cmd.CommandType = CommandType.StoredProcedure

                Dim id As OleDbParameter = cmd.Parameters.Add("@inId", OleDbType.Decimal, Nothing)
                id.Direction = ParameterDirection.Input
                id.Value = inId

                Dim adapter As OleDbDataAdapter = New OleDbDataAdapter(cmd)
                Dim vDataSet As New DataSet
                adapter.Fill(vDataSet)
                If Not vDataSet.Tables(0).Rows.Count.Equals(0) Then
                    getFichaEnfermeria = MapeoFichaEnfermeria(vDataSet)
                End If

                If vDataSet.Tables(0).Rows.Count = 0 Then NoData = True

                Return getFichaEnfermeria

            Catch exc As Exception
                Return Nothing
            End Try

        End Function
        Private Shared Function MapeoFichaEnfermeria(prmDatos As DataSet) As Ficha
            Try
                Dim vficha As New Ficha
                Dim vEnfermeria As New FichaEnfermeria
                Dim vMedicamentos As New MedicamentosEnfermeria
                Dim vAnamnesis As New AnamnesisEnfermeria
                Dim vExamenFisico As New ExamenFisicoEnfermeria
                Dim vEvolucion As New EvolucionEnfermeria
                Dim vPlanEnfermeria As New PlanEnfermeria
                Dim vPlanDiagnostico As New PlanEnfermeriaDiagnostico
                Dim vPlanIntervencion As New PlanEnfermeriaIntervencion
                Dim vPlanIndicador As New PlanEnfermeriaIndicador

                vficha.FichaEnfermeria = vEnfermeria.MapeoFichaEnfermeria(prmDatos.Tables(0))
                vficha.FichaEnfermeria.MedicamentosEnfermeria = vMedicamentos.MapeoMedicamentos(prmDatos.Tables(1))
                vficha.FichaEnfermeria.AnamnesisEnfermeria = vAnamnesis.MapeoAnamnesis(prmDatos.Tables(2))
                vficha.FichaEnfermeria.ExamenFisicoEnfermeria = vExamenFisico.MapeoExamenFisico(prmDatos.Tables(3))
                vficha.FichaEnfermeria.EvolucionEnfermeria = vEvolucion.MapeoEvolucion(prmDatos.Tables(4))
                vficha.FichaEnfermeria.PlanEnfermeria = vPlanEnfermeria.MapeoPlanEnfermeria(prmDatos.Tables(5))
                vficha.FichaEnfermeria.PlanEnfermeria.Diagnostico = vPlanDiagnostico.MapeoDiagnostico(prmDatos.Tables(6))
                vficha.FichaEnfermeria.PlanEnfermeria.Intervencion = vPlanIntervencion.MapeoIntervencion(prmDatos.Tables(7))
                vficha.FichaEnfermeria.PlanEnfermeria.Indicadores = vPlanIndicador.MapeoIndicador(prmDatos.Tables(8))
                Return vficha
            Catch ex As Exception
                Return Nothing
            End Try

        End Function

        Public Function registrarFichaEnfermeria() As Boolean
            Dim conn As OleDbConnection = New OleDbConnection(ConfigurationManager.ConnectionStrings("ConexionKaplan").ConnectionString)
            Dim cmd As OleDbCommand = New OleDbCommand("Kaplan.RegistrarFichaEnfermeria", conn)
            cmd.CommandType = CommandType.StoredProcedure

            Dim inId As OleDbParameter = cmd.Parameters.Add("@id_ficha", OleDbType.Decimal, Nothing)
            inId.Direction = ParameterDirection.Input
            inId.Value = Me.Id

            Dim inIdEnfer As OleDbParameter = cmd.Parameters.Add("@id_ficha_Enfermeria", OleDbType.Decimal, Nothing)
            inIdEnfer.Direction = ParameterDirection.Input
            inIdEnfer.Value = Me.FichaEnfermeria.Id

            Dim inid_reserva As OleDbParameter = cmd.Parameters.Add("@id_reserva", OleDbType.Decimal, Nothing)
            inid_reserva.Direction = ParameterDirection.Input
            inid_reserva.Value = Me.FichaEnfermeria.IdReserva

            Dim inProcedencia As OleDbParameter = cmd.Parameters.Add("@Procedencia", OleDbType.VarChar, 500)
            inProcedencia.Direction = ParameterDirection.Input
            inProcedencia.Value = Me.FichaEnfermeria.Procedencia

            Dim inTipoEvaluacion As OleDbParameter = cmd.Parameters.Add("@TipoEvaluacion", OleDbType.VarChar, 500)
            inTipoEvaluacion.Direction = ParameterDirection.Input
            inTipoEvaluacion.Value = Me.FichaEnfermeria.TipoEvaluacion

            Dim inIdEspecialista As OleDbParameter = cmd.Parameters.Add("@id_especialista", OleDbType.Decimal, Nothing)
            inIdEspecialista.Direction = ParameterDirection.Input
            inIdEspecialista.Value = Me.FichaEnfermeria.IdEspecialista

            Dim inDiagnostico As OleDbParameter = cmd.Parameters.Add("@Diagnostico", OleDbType.VarChar, 500)
            inDiagnostico.Direction = ParameterDirection.Input
            inDiagnostico.Value = Me.FichaEnfermeria.Diagnostico

            Dim inFechaDiagnostico As OleDbParameter = cmd.Parameters.Add("@FechaDiagnostico", OleDbType.Date, Nothing)
            inFechaDiagnostico.Direction = ParameterDirection.Input
            inFechaDiagnostico.Value = Me.FichaEnfermeria.FechaDiagnostico

            Dim inCxProced As OleDbParameter = cmd.Parameters.Add("@CxProced", OleDbType.VarChar, 500)
            inCxProced.Direction = ParameterDirection.Input
            inCxProced.Value = Me.FichaEnfermeria.CxProced

            Dim inFechaCxProced As OleDbParameter = cmd.Parameters.Add("@FechaCxProced", OleDbType.Date, Nothing)
            inFechaCxProced.Direction = ParameterDirection.Input
            inFechaCxProced.Value = Me.FichaEnfermeria.FechaCxProced

            Dim inControles As OleDbParameter = cmd.Parameters.Add("@Controles", OleDbType.VarChar, 500)
            inControles.Direction = ParameterDirection.Input
            inControles.Value = Me.FichaEnfermeria.Controles

            Dim inFechaAlta As OleDbParameter = cmd.Parameters.Add("@FechaAlta", OleDbType.Date, Nothing)
            inFechaAlta.Direction = ParameterDirection.Input
            inFechaAlta.Value = Me.FichaEnfermeria.FechaAlta

            Dim inHeridaCX As OleDbParameter = cmd.Parameters.Add("@HeridaCX", OleDbType.VarChar, 500)
            inHeridaCX.Direction = ParameterDirection.Input
            inHeridaCX.Value = Me.FichaEnfermeria.HeridaCX

            Dim inHTA As OleDbParameter = cmd.Parameters.Add("@HTA", OleDbType.Decimal, Nothing)
            inHTA.Direction = ParameterDirection.Input
            inHTA.Value = Me.FichaEnfermeria.HTA.ID

            Dim inDM As OleDbParameter = cmd.Parameters.Add("@DM", OleDbType.Decimal, Nothing)
            inDM.Direction = ParameterDirection.Input
            inDM.Value = Me.FichaEnfermeria.DM.ID

            Dim inDLP As OleDbParameter = cmd.Parameters.Add("@DLP", OleDbType.Decimal, Nothing)
            inDLP.Direction = ParameterDirection.Input
            inDLP.Value = Me.FichaEnfermeria.DLP.ID

            Dim inSED As OleDbParameter = cmd.Parameters.Add("@SED", OleDbType.Decimal, Nothing)
            inSED.Direction = ParameterDirection.Input
            inSED.Value = Me.FichaEnfermeria.SED.ID

            Dim inSPOB As OleDbParameter = cmd.Parameters.Add("@SPOB", OleDbType.Decimal, Nothing)
            inSPOB.Direction = ParameterDirection.Input
            inSPOB.Value = Me.FichaEnfermeria.SPOB.ID

            Dim inTB As OleDbParameter = cmd.Parameters.Add("@TB", OleDbType.Decimal, Nothing)
            inTB.Direction = ParameterDirection.Input
            inTB.Value = Me.FichaEnfermeria.TB.ID

            Dim inOH As OleDbParameter = cmd.Parameters.Add("@OH", OleDbType.Decimal, Nothing)
            inOH.Direction = ParameterDirection.Input
            inOH.Value = Me.FichaEnfermeria.OH.ID

            Dim inAF As OleDbParameter = cmd.Parameters.Add("@AF", OleDbType.Decimal, Nothing)
            inAF.Direction = ParameterDirection.Input
            inAF.Value = Me.FichaEnfermeria.AF.ID

            Dim inEstres As OleDbParameter = cmd.Parameters.Add("@Estres", OleDbType.Decimal, Nothing)
            inEstres.Direction = ParameterDirection.Input
            inEstres.Value = Me.FichaEnfermeria.Estres.ID

            Dim inIntervencion As OleDbParameter = cmd.Parameters.Add("@Intervencion", OleDbType.VarChar, 500)
            inIntervencion.Direction = ParameterDirection.Input
            inIntervencion.Value = Me.FichaEnfermeria.Intervencion

            Dim inMedicamento As OleDbParameter = cmd.Parameters.Add("@Medicamento", OleDbType.VarChar, -1)
            inMedicamento.Direction = ParameterDirection.Input
            inMedicamento.Value = Me.FichaEnfermeria.ToJSONMedicamentos(Me.FichaEnfermeria.MedicamentosEnfermeria)

            Dim inid_anamnesis As OleDbParameter = cmd.Parameters.Add("@id_anamnesis", OleDbType.Decimal, Nothing)
            inid_anamnesis.Direction = ParameterDirection.Input
            inid_anamnesis.Value = Me.FichaEnfermeria.AnamnesisEnfermeria.Id

            Dim inAntecedentesRelevantes_anamnesis As OleDbParameter = cmd.Parameters.Add("@AntecedentesRelevantes_anamnesis", OleDbType.VarChar, 500)
            inAntecedentesRelevantes_anamnesis.Direction = ParameterDirection.Input
            inAntecedentesRelevantes_anamnesis.Value = Me.FichaEnfermeria.AnamnesisEnfermeria.AntecedentesRelevantes

            Dim inPatronRespiratorio_anamnesis As OleDbParameter = cmd.Parameters.Add("@PatronRespiratorio_anamnesis", OleDbType.Decimal, Nothing)
            inPatronRespiratorio_anamnesis.Direction = ParameterDirection.Input
            inPatronRespiratorio_anamnesis.Value = Me.FichaEnfermeria.AnamnesisEnfermeria.PatronRespiratorio.ID

            Dim inRegimenHiposodico_anamnesis As OleDbParameter = cmd.Parameters.Add("@RegimenHiposodico_anamnesis", OleDbType.Decimal, Nothing)
            inRegimenHiposodico_anamnesis.Direction = ParameterDirection.Input
            inRegimenHiposodico_anamnesis.Value = Me.FichaEnfermeria.AnamnesisEnfermeria.RegimenHiposodico.ID

            Dim inFrutayVerdura_anamnesis As OleDbParameter = cmd.Parameters.Add("@FrutayVerdura_anamnesis", OleDbType.Decimal, Nothing)
            inFrutayVerdura_anamnesis.Direction = ParameterDirection.Input
            inFrutayVerdura_anamnesis.Value = Me.FichaEnfermeria.AnamnesisEnfermeria.FrutayVerdura.ID

            Dim inAgua_anamnesis As OleDbParameter = cmd.Parameters.Add("@Agua_anamnesis", OleDbType.Decimal, Nothing)
            inAgua_anamnesis.Direction = ParameterDirection.Input
            inAgua_anamnesis.Value = Me.FichaEnfermeria.AnamnesisEnfermeria.Agua.ID

            Dim inBebidaNec_anamnesis As OleDbParameter = cmd.Parameters.Add("@BebidaNec_anamnesis", OleDbType.Decimal, Nothing)
            inBebidaNec_anamnesis.Direction = ParameterDirection.Input
            inBebidaNec_anamnesis.Value = Me.FichaEnfermeria.AnamnesisEnfermeria.BebidaNec.ID

            Dim inGrasas_anamnesis As OleDbParameter = cmd.Parameters.Add("@Grasas_anamnesis", OleDbType.Decimal, Nothing)
            inGrasas_anamnesis.Direction = ParameterDirection.Input
            inGrasas_anamnesis.Value = Me.FichaEnfermeria.AnamnesisEnfermeria.Grasas.ID

            Dim inDiuresis_anamnesis As OleDbParameter = cmd.Parameters.Add("@Diuresis_anamnesis", OleDbType.Decimal, Nothing)
            inDiuresis_anamnesis.Direction = ParameterDirection.Input
            inDiuresis_anamnesis.Value = Me.FichaEnfermeria.AnamnesisEnfermeria.Diuresis.ID

            Dim inDeposicion_anamnesis As OleDbParameter = cmd.Parameters.Add("@Deposicion_anamnesis", OleDbType.Decimal, Nothing)
            inDeposicion_anamnesis.Direction = ParameterDirection.Input
            inDeposicion_anamnesis.Value = Me.FichaEnfermeria.AnamnesisEnfermeria.Deposicion.ID

            Dim inTBa_anamnesis As OleDbParameter = cmd.Parameters.Add("@TBa_anamnesis", OleDbType.Decimal, Nothing)
            inTBa_anamnesis.Direction = ParameterDirection.Input
            inTBa_anamnesis.Value = Me.FichaEnfermeria.AnamnesisEnfermeria.TBa.ID

            Dim inTBb_anamnesis As OleDbParameter = cmd.Parameters.Add("@TBb_anamnesis", OleDbType.Decimal, Nothing)
            inTBb_anamnesis.Direction = ParameterDirection.Input
            inTBb_anamnesis.Value = Me.FichaEnfermeria.AnamnesisEnfermeria.TBb.ID

            Dim inEA_anamnesis As OleDbParameter = cmd.Parameters.Add("@EA_anamnesis", OleDbType.Decimal, Nothing)
            inEA_anamnesis.Direction = ParameterDirection.Input
            inEA_anamnesis.Value = Me.FichaEnfermeria.AnamnesisEnfermeria.EA.ID

            Dim inSuenoNocturnoa_anamnesis As OleDbParameter = cmd.Parameters.Add("@SuenoNocturnoa_anamnesis", OleDbType.Decimal, Nothing)
            inSuenoNocturnoa_anamnesis.Direction = ParameterDirection.Input
            inSuenoNocturnoa_anamnesis.Value = Me.FichaEnfermeria.AnamnesisEnfermeria.SuenoNocturnoa.ID

            Dim inSuenoNocturnob_anamnesis As OleDbParameter = cmd.Parameters.Add("@SuenoNocturnob_anamnesis", OleDbType.Decimal, Nothing)
            inSuenoNocturnob_anamnesis.Direction = ParameterDirection.Input
            inSuenoNocturnob_anamnesis.Value = Me.FichaEnfermeria.AnamnesisEnfermeria.SuenoNocturnob.ID

            Dim inSuenoNocturnoc_anamnesis As OleDbParameter = cmd.Parameters.Add("@SuenoNocturnoc_anamnesis", OleDbType.Decimal, Nothing)
            inSuenoNocturnoc_anamnesis.Direction = ParameterDirection.Input
            inSuenoNocturnoc_anamnesis.Value = Me.FichaEnfermeria.AnamnesisEnfermeria.SuenoNocturnoc.ID

            Dim inMotivacion_anamnesis As OleDbParameter = cmd.Parameters.Add("@Motivacion_anamnesis", OleDbType.Decimal, Nothing)
            inMotivacion_anamnesis.Direction = ParameterDirection.Input
            inMotivacion_anamnesis.Value = Me.FichaEnfermeria.AnamnesisEnfermeria.Motivacion.ID

            Dim inAVD_anamnesis As OleDbParameter = cmd.Parameters.Add("@AVD_anamnesis", OleDbType.Decimal, Nothing)
            inAVD_anamnesis.Direction = ParameterDirection.Input
            inAVD_anamnesis.Value = Me.FichaEnfermeria.AnamnesisEnfermeria.AVD.ID

            Dim inActividadesRecreativas_anamnesis As OleDbParameter = cmd.Parameters.Add("@ActividadesRecreativas_anamnesis", OleDbType.Decimal, Nothing)
            inActividadesRecreativas_anamnesis.Direction = ParameterDirection.Input
            inActividadesRecreativas_anamnesis.Value = Me.FichaEnfermeria.AnamnesisEnfermeria.ActividadesRecreativas.ID

            Dim inid_ExamenFisico As OleDbParameter = cmd.Parameters.Add("@id_ExamenFisico", OleDbType.Decimal, Nothing)
            inid_ExamenFisico.Direction = ParameterDirection.Input
            inid_ExamenFisico.Value = Me.FichaEnfermeria.ExamenFisicoEnfermeria.Id

            Dim inCabeza_ExamenFisico As OleDbParameter = cmd.Parameters.Add("@Cabeza_ExamenFisico", OleDbType.Decimal, Nothing)
            inCabeza_ExamenFisico.Direction = ParameterDirection.Input
            inCabeza_ExamenFisico.Value = Me.FichaEnfermeria.ExamenFisicoEnfermeria.Cabeza.ID

            Dim inCuello_ExamenFisico As OleDbParameter = cmd.Parameters.Add("@Cuello_ExamenFisico", OleDbType.Decimal, Nothing)
            inCuello_ExamenFisico.Direction = ParameterDirection.Input
            inCuello_ExamenFisico.Value = Me.FichaEnfermeria.ExamenFisicoEnfermeria.Cuello.ID

            Dim inToraxa_ExamenFisico As OleDbParameter = cmd.Parameters.Add("@Toraxa_ExamenFisico", OleDbType.Decimal, Nothing)
            inToraxa_ExamenFisico.Direction = ParameterDirection.Input
            inToraxa_ExamenFisico.Value = Me.FichaEnfermeria.ExamenFisicoEnfermeria.Toraxa.ID

            Dim inToraxb_ExamenFisico As OleDbParameter = cmd.Parameters.Add("@Toraxb_ExamenFisico", OleDbType.Decimal, Nothing)
            inToraxb_ExamenFisico.Direction = ParameterDirection.Input
            inToraxb_ExamenFisico.Value = Me.FichaEnfermeria.ExamenFisicoEnfermeria.Toraxb.ID

            Dim inToraxc_ExamenFisico As OleDbParameter = cmd.Parameters.Add("@Toraxc_ExamenFisico", OleDbType.Decimal, Nothing)
            inToraxc_ExamenFisico.Direction = ParameterDirection.Input
            inToraxc_ExamenFisico.Value = Me.FichaEnfermeria.ExamenFisicoEnfermeria.Toraxc.ID

            Dim inToraxd_ExamenFisico As OleDbParameter = cmd.Parameters.Add("@Toraxd_ExamenFisico", OleDbType.Decimal, Nothing)
            inToraxd_ExamenFisico.Direction = ParameterDirection.Input
            inToraxd_ExamenFisico.Value = Me.FichaEnfermeria.ExamenFisicoEnfermeria.Toraxd.ID

            Dim inAbdomena_ExamenFisico As OleDbParameter = cmd.Parameters.Add("@Abdomena_ExamenFisico", OleDbType.Decimal, Nothing)
            inAbdomena_ExamenFisico.Direction = ParameterDirection.Input
            inAbdomena_ExamenFisico.Value = Me.FichaEnfermeria.ExamenFisicoEnfermeria.Abdomena.ID

            Dim inAbdomenb_ExamenFisico As OleDbParameter = cmd.Parameters.Add("@Abdomenb_ExamenFisico", OleDbType.Decimal, Nothing)
            inAbdomenb_ExamenFisico.Direction = ParameterDirection.Input
            inAbdomenb_ExamenFisico.Value = Me.FichaEnfermeria.ExamenFisicoEnfermeria.Abdomenb.ID

            Dim inEESS_ExamenFisico As OleDbParameter = cmd.Parameters.Add("@EESS_ExamenFisico", OleDbType.Decimal, Nothing)
            inEESS_ExamenFisico.Direction = ParameterDirection.Input
            inEESS_ExamenFisico.Value = Me.FichaEnfermeria.ExamenFisicoEnfermeria.EESS.ID

            Dim inllencap_ExamenFisico As OleDbParameter = cmd.Parameters.Add("@llencap_ExamenFisico", OleDbType.Decimal, Nothing)
            inllencap_ExamenFisico.Direction = ParameterDirection.Input
            inllencap_ExamenFisico.Value = Me.FichaEnfermeria.ExamenFisicoEnfermeria.llencap.ID

            Dim inEEII_ExamenFisico As OleDbParameter = cmd.Parameters.Add("@EEII_ExamenFisico", OleDbType.Decimal, Nothing)
            inEEII_ExamenFisico.Direction = ParameterDirection.Input
            inEEII_ExamenFisico.Value = Me.FichaEnfermeria.ExamenFisicoEnfermeria.EEII.ID

            Dim inPA_ExamenFisico As OleDbParameter = cmd.Parameters.Add("@PA_ExamenFisico", OleDbType.Decimal, Nothing)
            inPA_ExamenFisico.Direction = ParameterDirection.Input
            inPA_ExamenFisico.Value = Me.FichaEnfermeria.ExamenFisicoEnfermeria.PA

            Dim inFC_ExamenFisico As OleDbParameter = cmd.Parameters.Add("@FC_ExamenFisico", OleDbType.Decimal, Nothing)
            inFC_ExamenFisico.Direction = ParameterDirection.Input
            inFC_ExamenFisico.Value = Me.FichaEnfermeria.ExamenFisicoEnfermeria.FC

            Dim inSAT_ExamenFisico As OleDbParameter = cmd.Parameters.Add("@SAT_ExamenFisico", OleDbType.Decimal, Nothing)
            inSAT_ExamenFisico.Direction = ParameterDirection.Input
            inSAT_ExamenFisico.Value = Me.FichaEnfermeria.ExamenFisicoEnfermeria.SAT

            Dim inGlicemia_ExamenFisico As OleDbParameter = cmd.Parameters.Add("@Glicemia_ExamenFisico", OleDbType.Decimal, Nothing)
            inGlicemia_ExamenFisico.Direction = ParameterDirection.Input
            inGlicemia_ExamenFisico.Value = Me.FichaEnfermeria.ExamenFisicoEnfermeria.Glicemia

            Dim inEvolucion As OleDbParameter = cmd.Parameters.Add("@Evolucion", OleDbType.VarChar, -1)
            inEvolucion.Direction = ParameterDirection.Input
            inEvolucion.Value = Me.FichaEnfermeria.ToJSONEvolucion(Me.FichaEnfermeria.EvolucionEnfermeria)

            Dim inid_PlanEnfermeria As OleDbParameter = cmd.Parameters.Add("@id_PlanEnfermeria", OleDbType.Decimal, Nothing)
            inid_PlanEnfermeria.Direction = ParameterDirection.Input
            inid_PlanEnfermeria.Value = Me.FichaEnfermeria.PlanEnfermeria.Id

            Dim inAdeherenciaFarma_PlanEnfermeria As OleDbParameter = cmd.Parameters.Add("@AdeherenciaFarma_PlanEnfermeria", OleDbType.Decimal, Nothing)
            inAdeherenciaFarma_PlanEnfermeria.Direction = ParameterDirection.Input
            inAdeherenciaFarma_PlanEnfermeria.Value = Me.FichaEnfermeria.PlanEnfermeria.AdeherenciaFarma.ID

            Dim inRespiracion_PlanEnfermeria As OleDbParameter = cmd.Parameters.Add("@Respiracion_PlanEnfermeria", OleDbType.Decimal, Nothing)
            inRespiracion_PlanEnfermeria.Direction = ParameterDirection.Input
            inRespiracion_PlanEnfermeria.Value = Me.FichaEnfermeria.PlanEnfermeria.Respiracion.ID

            Dim inAlimentacion_PlanEnfermeria As OleDbParameter = cmd.Parameters.Add("@Alimentacion_PlanEnfermeria", OleDbType.Decimal, Nothing)
            inAlimentacion_PlanEnfermeria.Direction = ParameterDirection.Input
            inAlimentacion_PlanEnfermeria.Value = Me.FichaEnfermeria.PlanEnfermeria.Alimentacion.ID

            Dim inEliminacion_PlanEnfermeria As OleDbParameter = cmd.Parameters.Add("@Eliminacion_PlanEnfermeria", OleDbType.Decimal, Nothing)
            inEliminacion_PlanEnfermeria.Direction = ParameterDirection.Input
            inEliminacion_PlanEnfermeria.Value = Me.FichaEnfermeria.PlanEnfermeria.Eliminacion.ID

            Dim inDescanso_PlanEnfermeria As OleDbParameter = cmd.Parameters.Add("@Descanso_PlanEnfermeria", OleDbType.Decimal, Nothing)
            inDescanso_PlanEnfermeria.Direction = ParameterDirection.Input
            inDescanso_PlanEnfermeria.Value = Me.FichaEnfermeria.PlanEnfermeria.Descanso.ID

            Dim inHigienePiel_PlanEnfermeria As OleDbParameter = cmd.Parameters.Add("@HigienePiel_PlanEnfermeria", OleDbType.Decimal, Nothing)
            inHigienePiel_PlanEnfermeria.Direction = ParameterDirection.Input
            inHigienePiel_PlanEnfermeria.Value = Me.FichaEnfermeria.PlanEnfermeria.HigienePiel.ID

            Dim inActividades_PlanEnfermeria As OleDbParameter = cmd.Parameters.Add("@Actividades_PlanEnfermeria", OleDbType.Decimal, Nothing)
            inActividades_PlanEnfermeria.Direction = ParameterDirection.Input
            inActividades_PlanEnfermeria.Value = Me.FichaEnfermeria.PlanEnfermeria.Actividades.ID

            Dim inVestirse_PlanEnfermeria As OleDbParameter = cmd.Parameters.Add("@Vestirse_PlanEnfermeria", OleDbType.Decimal, Nothing)
            inVestirse_PlanEnfermeria.Direction = ParameterDirection.Input
            inVestirse_PlanEnfermeria.Value = Me.FichaEnfermeria.PlanEnfermeria.Vestirse.ID

            Dim inComunicarse_PlanEnfermeria As OleDbParameter = cmd.Parameters.Add("@Comunicarse_PlanEnfermeria", OleDbType.Decimal, Nothing)
            inComunicarse_PlanEnfermeria.Direction = ParameterDirection.Input
            inComunicarse_PlanEnfermeria.Value = Me.FichaEnfermeria.PlanEnfermeria.Comunicarse.ID

            Dim inAutoRealizacion_PlanEnfermeria As OleDbParameter = cmd.Parameters.Add("@AutoRealizacion_PlanEnfermeria", OleDbType.Decimal, Nothing)
            inAutoRealizacion_PlanEnfermeria.Direction = ParameterDirection.Input
            inAutoRealizacion_PlanEnfermeria.Value = Me.FichaEnfermeria.PlanEnfermeria.AutoRealizacion.ID

            Dim inRespiracionObservacion_PlanEnfermeria As OleDbParameter = cmd.Parameters.Add("@RespiracionObservacion_PlanEnfermeria", OleDbType.VarChar, 500)
            inRespiracionObservacion_PlanEnfermeria.Direction = ParameterDirection.Input
            inRespiracionObservacion_PlanEnfermeria.Value = Me.FichaEnfermeria.PlanEnfermeria.RespiracionObservacion

            Dim inAlimentacionObservacion_PlanEnfermeria As OleDbParameter = cmd.Parameters.Add("@AlimentacionObservacion_PlanEnfermeria", OleDbType.VarChar, 500)
            inAlimentacionObservacion_PlanEnfermeria.Direction = ParameterDirection.Input
            inAlimentacionObservacion_PlanEnfermeria.Value = Me.FichaEnfermeria.PlanEnfermeria.AlimentacionObservacion

            Dim inEliminacionObservacion_PlanEnfermeria As OleDbParameter = cmd.Parameters.Add("@EliminacionObservacion_PlanEnfermeria", OleDbType.VarChar, 500)
            inEliminacionObservacion_PlanEnfermeria.Direction = ParameterDirection.Input
            inEliminacionObservacion_PlanEnfermeria.Value = Me.FichaEnfermeria.PlanEnfermeria.EliminacionObservacion

            Dim inDescansoObservacion_PlanEnfermeria As OleDbParameter = cmd.Parameters.Add("@DescansoObservacion_PlanEnfermeria", OleDbType.VarChar, 500)
            inDescansoObservacion_PlanEnfermeria.Direction = ParameterDirection.Input
            inDescansoObservacion_PlanEnfermeria.Value = Me.FichaEnfermeria.PlanEnfermeria.DescansoObservacion

            Dim inHigienePielObservacion_PlanEnfermeria As OleDbParameter = cmd.Parameters.Add("@HigienePielObservacion_PlanEnfermeria", OleDbType.VarChar, 500)
            inHigienePielObservacion_PlanEnfermeria.Direction = ParameterDirection.Input
            inHigienePielObservacion_PlanEnfermeria.Value = Me.FichaEnfermeria.PlanEnfermeria.HigienePielObservacion

            Dim inActividadesObservacion_PlanEnfermeria As OleDbParameter = cmd.Parameters.Add("@ActividadesObservacion_PlanEnfermeria", OleDbType.VarChar, 500)
            inActividadesObservacion_PlanEnfermeria.Direction = ParameterDirection.Input
            inActividadesObservacion_PlanEnfermeria.Value = Me.FichaEnfermeria.PlanEnfermeria.ActividadesObservacion

            Dim inVestirseObservacion_PlanEnfermeria As OleDbParameter = cmd.Parameters.Add("@VestirseObservacion_PlanEnfermeria", OleDbType.VarChar, 500)
            inVestirseObservacion_PlanEnfermeria.Direction = ParameterDirection.Input
            inVestirseObservacion_PlanEnfermeria.Value = Me.FichaEnfermeria.PlanEnfermeria.VestirseObservacion

            Dim inComunicarseObservacion_PlanEnfermeria As OleDbParameter = cmd.Parameters.Add("@ComunicarseObservacion_PlanEnfermeria", OleDbType.VarChar, 500)
            inComunicarseObservacion_PlanEnfermeria.Direction = ParameterDirection.Input
            inComunicarseObservacion_PlanEnfermeria.Value = Me.FichaEnfermeria.PlanEnfermeria.ComunicarseObservacion

            Dim inAutoRealizacionObservacion_PlanEnfermeria As OleDbParameter = cmd.Parameters.Add("@AutoRealizacionObservacion_PlanEnfermeria", OleDbType.VarChar, 500)
            inAutoRealizacionObservacion_PlanEnfermeria.Direction = ParameterDirection.Input
            inAutoRealizacionObservacion_PlanEnfermeria.Value = Me.FichaEnfermeria.PlanEnfermeria.AutoRealizacionObservacion

            Dim inObjetivo_PlanEnfermeria As OleDbParameter = cmd.Parameters.Add("@Objetivo_PlanEnfermeria", OleDbType.VarChar, 500)
            inObjetivo_PlanEnfermeria.Direction = ParameterDirection.Input
            inObjetivo_PlanEnfermeria.Value = Me.FichaEnfermeria.PlanEnfermeria.Objetivo

            Dim inDiagnostico_PlanEnfermeria As OleDbParameter = cmd.Parameters.Add("@Diagnostico_PlanEnfermeria", OleDbType.VarChar, -1)
            inDiagnostico_PlanEnfermeria.Direction = ParameterDirection.Input
            inDiagnostico_PlanEnfermeria.Value = Me.FichaEnfermeria.PlanEnfermeria.ToJSONDiagnosticos(Me.FichaEnfermeria.PlanEnfermeria.Diagnostico)

            Dim inIntervencion_PlanEnfermeria As OleDbParameter = cmd.Parameters.Add("@Intervencion_PlanEnfermeria", OleDbType.VarChar, -1)
            inIntervencion_PlanEnfermeria.Direction = ParameterDirection.Input
            inIntervencion_PlanEnfermeria.Value = Me.FichaEnfermeria.PlanEnfermeria.ToJSONIntervencion(Me.FichaEnfermeria.PlanEnfermeria.Intervencion)

            Dim inIndicadores_PlanEnfermeria As OleDbParameter = cmd.Parameters.Add("@Indicadores_PlanEnfermeria", OleDbType.VarChar, -1)
            inIndicadores_PlanEnfermeria.Direction = ParameterDirection.Input
            inIndicadores_PlanEnfermeria.Value = Me.FichaEnfermeria.PlanEnfermeria.ToJSONIndicador(Me.FichaEnfermeria.PlanEnfermeria.Indicadores)

            Dim outError As OleDbParameter = cmd.Parameters.Add("@outError", OleDbType.Integer)
            outError.Direction = ParameterDirection.Output

            Dim outIdEnf As OleDbParameter = cmd.Parameters.Add("@outIdEnf", OleDbType.Integer)
            outIdEnf.Direction = ParameterDirection.Output

            conn.Open()
            cmd.ExecuteReader()
            conn.Close()

            Dim idEnfer = CInt(cmd.Parameters("@outIdEnf").Value)

            Return CInt(cmd.Parameters("@outError").Value)
        End Function
#End Region
#Region "Nutrición"
        Public Shared Function getFichaNutricion(inId As Integer, ByRef NoData As Boolean) As Ficha
            Try
                Dim conn As OleDbConnection = New OleDbConnection(ConfigurationManager.ConnectionStrings("ConexionKaplan").ConnectionString)
                Dim cmd As OleDbCommand = New OleDbCommand("Kaplan.BuscarFichaNutricionxReserva", conn)
                cmd.CommandType = CommandType.StoredProcedure

                Dim id As OleDbParameter = cmd.Parameters.Add("@inId", OleDbType.Decimal, Nothing)
                id.Direction = ParameterDirection.Input
                id.Value = inId

                Dim adapter As OleDbDataAdapter = New OleDbDataAdapter(cmd)
                Dim vDataSet As New DataSet
                adapter.Fill(vDataSet)
                If Not vDataSet.Tables(0).Rows.Count.Equals(0) Then
                    getFichaNutricion = MapeoFichaNutricion(vDataSet)
                End If

                If vDataSet.Tables(0).Rows.Count = 0 Then NoData = True

                Return getFichaNutricion

            Catch exc As Exception
                Return Nothing
            End Try

        End Function
        Private Shared Function MapeoFichaNutricion(prmDatos As DataSet) As Ficha
            Try
                Dim vficha As New Ficha
                Dim vNutricion As New FichaNutricion
                vficha.FichaNutricion = vNutricion.MapeoFichaNutricion(prmDatos.Tables(0))
                Return vficha
            Catch ex As Exception
                Return Nothing
            End Try

        End Function
        Public Function registrarFichaNutricion() As Boolean
            Dim conn As OleDbConnection = New OleDbConnection(ConfigurationManager.ConnectionStrings("ConexionKaplan").ConnectionString)
            Dim cmd As OleDbCommand = New OleDbCommand("Kaplan.RegistrarFichaNutricion", conn)
            cmd.CommandType = CommandType.StoredProcedure
#Region "Ficha Nutrición"
            Dim inId As OleDbParameter = cmd.Parameters.Add("@id_ficha", OleDbType.Decimal, Nothing)
            inId.Direction = ParameterDirection.Input
            inId.Value = Me.Id

            Dim inIdPsico As OleDbParameter = cmd.Parameters.Add("@id_ficha_nutri", OleDbType.Decimal, Nothing)
            inIdPsico.Direction = ParameterDirection.Input
            inIdPsico.Value = Me.FichaNutricion.Id

            Dim inIdEspecialista As OleDbParameter = cmd.Parameters.Add("@id_especialista", OleDbType.Decimal, Nothing)
            inIdEspecialista.Direction = ParameterDirection.Input
            inIdEspecialista.Value = Me.FichaNutricion.IdEspecialista

            Dim inid_reserva As OleDbParameter = cmd.Parameters.Add("@id_reserva", OleDbType.Decimal, Nothing)
            inid_reserva.Direction = ParameterDirection.Input
            inid_reserva.Value = Me.FichaNutricion.IdReserva
#End Region
#Region "Mediciones Antropometricas"
            Dim PesoActual As OleDbParameter = cmd.Parameters.Add("@ma_peso_actual", OleDbType.Decimal, Nothing)
            PesoActual.Direction = ParameterDirection.Input
            PesoActual.Value = Me.FichaNutricion.MedicionesAntropometricas.PesoActual

            Dim Talla As OleDbParameter = cmd.Parameters.Add("@ma_talla", OleDbType.Decimal, Nothing)
            Talla.Direction = ParameterDirection.Input
            Talla.Value = Me.FichaNutricion.MedicionesAntropometricas.Talla

            Dim MasaGrasaCorporal As OleDbParameter = cmd.Parameters.Add("@ma_masa_grasa_corp", OleDbType.Decimal, Nothing)
            MasaGrasaCorporal.Direction = ParameterDirection.Input
            MasaGrasaCorporal.Value = Me.FichaNutricion.MedicionesAntropometricas.MasaGrasaCorporal

            Dim MasaMagra As OleDbParameter = cmd.Parameters.Add("@ma_masa_magra", OleDbType.Decimal, Nothing)
            MasaMagra.Direction = ParameterDirection.Input
            MasaMagra.Value = Me.FichaNutricion.MedicionesAntropometricas.MasaMagra

            Dim IndiceCinturaCadera As OleDbParameter = cmd.Parameters.Add("@ma_indice_cint", OleDbType.Decimal, Nothing)
            IndiceCinturaCadera.Direction = ParameterDirection.Input
            IndiceCinturaCadera.Value = Me.FichaNutricion.MedicionesAntropometricas.IndiceCinturaCadera

            Dim MNA As OleDbParameter = cmd.Parameters.Add("@ma_mna", OleDbType.Decimal, Nothing)
            MNA.Direction = ParameterDirection.Input
            MNA.Value = Me.FichaNutricion.MedicionesAntropometricas.MNA

            Dim PesoHabitual As OleDbParameter = cmd.Parameters.Add("@ma_peso_hab", OleDbType.Decimal, Nothing)
            PesoHabitual.Direction = ParameterDirection.Input
            PesoHabitual.Value = Me.FichaNutricion.MedicionesAntropometricas.MasaGrasaCorporal

            Dim MasaGrasaPorc As OleDbParameter = cmd.Parameters.Add("@ma_grasa_porc", OleDbType.Decimal, Nothing)
            MasaGrasaPorc.Direction = ParameterDirection.Input
            MasaGrasaPorc.Value = Me.FichaNutricion.MedicionesAntropometricas.MasaGrasaCorporal

            Dim GrasaVisceralPorc As OleDbParameter = cmd.Parameters.Add("@ma_grasa_visceral_porc", OleDbType.Decimal, Nothing)
            GrasaVisceralPorc.Direction = ParameterDirection.Input
            GrasaVisceralPorc.Value = Me.FichaNutricion.MedicionesAntropometricas.GrasaVisceralPorc

            Dim PCintura As OleDbParameter = cmd.Parameters.Add("@ma_cintura", OleDbType.Decimal, Nothing)
            PCintura.Direction = ParameterDirection.Input
            PCintura.Value = Me.FichaNutricion.MedicionesAntropometricas.PCintura

            Dim Cribaje As OleDbParameter = cmd.Parameters.Add("@ma_cribaje", OleDbType.Decimal, Nothing)
            Cribaje.Direction = ParameterDirection.Input
            Cribaje.Value = Me.FichaNutricion.MedicionesAntropometricas.Cribaje.ID
#End Region
#Region "Anamnesis Alimentaria"
            Dim Apetito As OleDbParameter = cmd.Parameters.Add("@aa_apetito", OleDbType.Decimal, Nothing)
            Apetito.Direction = ParameterDirection.Input
            Apetito.Value = Me.FichaNutricion.Apetito.ID

            Dim AlergiaAlimentaria As OleDbParameter = cmd.Parameters.Add("@aa_alergia_alim", OleDbType.Decimal, Nothing)
            AlergiaAlimentaria.Direction = ParameterDirection.Input
            AlergiaAlimentaria.Value = Me.FichaNutricion.AlergiaAlimentaria.ID

            Dim PreferenciaAlimentaria As OleDbParameter = cmd.Parameters.Add("@aa_prefer_alim", OleDbType.Decimal, Nothing)
            PreferenciaAlimentaria.Direction = ParameterDirection.Input
            PreferenciaAlimentaria.Value = Me.FichaNutricion.PreferenciaAlimentaria.ID

            Dim IntoleranciaAlimentaria As OleDbParameter = cmd.Parameters.Add("@aa_intoler_alim", OleDbType.Decimal, Nothing)
            IntoleranciaAlimentaria.Direction = ParameterDirection.Input
            IntoleranciaAlimentaria.Value = Me.FichaNutricion.IntoleranciaAlimentaria.ID

            Dim AversionAlimentaria As OleDbParameter = cmd.Parameters.Add("@aa_aversi_alim", OleDbType.Decimal, Nothing)
            AversionAlimentaria.Direction = ParameterDirection.Input
            AversionAlimentaria.Value = Me.FichaNutricion.AversionAlimentaria.ID

            Dim ConsumoSuplemento As OleDbParameter = cmd.Parameters.Add("@aa_aversi_alim", OleDbType.Decimal, Nothing)
            ConsumoSuplemento.Direction = ParameterDirection.Input
            ConsumoSuplemento.Value = Me.FichaNutricion.ConsumoSuplemento.ID
#End Region
#Region "Ingesta Alimentaria"
            Dim DesayunoHora As OleDbParameter = cmd.Parameters.Add("@ia_desayuno_hora", OleDbType.VarChar, 500)
            DesayunoHora.Direction = ParameterDirection.Input
            DesayunoHora.Value = Me.FichaNutricion.IngestaAlimentaria.DesayunoHora

            Dim DesayunoObs As OleDbParameter = cmd.Parameters.Add("@ia_desayuno_obs", OleDbType.VarChar, 500)
            DesayunoObs.Direction = ParameterDirection.Input
            DesayunoObs.Value = Me.FichaNutricion.IngestaAlimentaria.DesayunoObs

            Dim ColacionHora As OleDbParameter = cmd.Parameters.Add("@ia_colacion_hora", OleDbType.VarChar, 500)
            ColacionHora.Direction = ParameterDirection.Input
            ColacionHora.Value = Me.FichaNutricion.IngestaAlimentaria.ColacionHora

            Dim ColacionObs As OleDbParameter = cmd.Parameters.Add("@ia_colacion_obs", OleDbType.VarChar, 500)
            ColacionObs.Direction = ParameterDirection.Input
            ColacionObs.Value = Me.FichaNutricion.IngestaAlimentaria.ColacionObs

            Dim AlmuerzoHora As OleDbParameter = cmd.Parameters.Add("@ia_almuerzo_hora", OleDbType.VarChar, 500)
            AlmuerzoHora.Direction = ParameterDirection.Input
            AlmuerzoHora.Value = Me.FichaNutricion.IngestaAlimentaria.AlmuerzoHora

            Dim AlmuerzoObs As OleDbParameter = cmd.Parameters.Add("@ia_almuerzo_obs", OleDbType.VarChar, 500)
            AlmuerzoObs.Direction = ParameterDirection.Input
            AlmuerzoObs.Value = Me.FichaNutricion.IngestaAlimentaria.AlmuerzoObs

            Dim PicoteoHora As OleDbParameter = cmd.Parameters.Add("@ia_picoteo_hora", OleDbType.VarChar, 500)
            PicoteoHora.Direction = ParameterDirection.Input
            PicoteoHora.Value = Me.FichaNutricion.IngestaAlimentaria.PicoteoHora

            Dim PicoteoObs As OleDbParameter = cmd.Parameters.Add("@ia_picoteo_obs", OleDbType.VarChar, 500)
            PicoteoObs.Direction = ParameterDirection.Input
            PicoteoObs.Value = Me.FichaNutricion.IngestaAlimentaria.PicoteoObs

            Dim OnceHora As OleDbParameter = cmd.Parameters.Add("@ia_once_hora", OleDbType.VarChar, 500)
            OnceHora.Direction = ParameterDirection.Input
            OnceHora.Value = Me.FichaNutricion.IngestaAlimentaria.OnceHora

            Dim OnceObs As OleDbParameter = cmd.Parameters.Add("@ia_once_obs", OleDbType.VarChar, 500)
            OnceObs.Direction = ParameterDirection.Input
            OnceObs.Value = Me.FichaNutricion.IngestaAlimentaria.OnceObs

            Dim CenaHora As OleDbParameter = cmd.Parameters.Add("@ia_cena_hora", OleDbType.VarChar, 500)
            CenaHora.Direction = ParameterDirection.Input
            CenaHora.Value = Me.FichaNutricion.IngestaAlimentaria.CenaHora

            Dim CenaObs As OleDbParameter = cmd.Parameters.Add("@ia_cena_obs", OleDbType.VarChar, 500)
            CenaObs.Direction = ParameterDirection.Input
            CenaObs.Value = Me.FichaNutricion.IngestaAlimentaria.CenaObs

            Dim SnackHora As OleDbParameter = cmd.Parameters.Add("@ia_snack_hora", OleDbType.VarChar, 500)
            SnackHora.Direction = ParameterDirection.Input
            SnackHora.Value = Me.FichaNutricion.IngestaAlimentaria.SnackHora

            Dim SnackObs As OleDbParameter = cmd.Parameters.Add("@ia_snack_obs", OleDbType.VarChar, 500)
            SnackObs.Direction = ParameterDirection.Input
            SnackObs.Value = Me.FichaNutricion.IngestaAlimentaria.SnackObs

            Dim DiagNutInt As OleDbParameter = cmd.Parameters.Add("@dni_obs", OleDbType.VarChar, 500)
            DiagNutInt.Direction = ParameterDirection.Input
            DiagNutInt.Value = Me.FichaNutricion.DiagNutInt

            Dim Observacion As OleDbParameter = cmd.Parameters.Add("@ia_obs", OleDbType.VarChar, 500)
            Observacion.Direction = ParameterDirection.Input
            Observacion.Value = Me.FichaNutricion.IngestaAlimentaria.Observacion
#End Region
#Region "Requerimientos Nutricionales"
            Dim GEB As OleDbParameter = cmd.Parameters.Add("@rn_geb", OleDbType.Decimal, Nothing)
            GEB.Direction = ParameterDirection.Input
            GEB.Value = Me.FichaNutricion.RequerimientosNutricionales.GEB

            Dim Energia As OleDbParameter = cmd.Parameters.Add("@rn_energia", OleDbType.Decimal, Nothing)
            Energia.Direction = ParameterDirection.Input
            Energia.Value = Me.FichaNutricion.RequerimientosNutricionales.Energia

            Dim FA As OleDbParameter = cmd.Parameters.Add("@rn_fa", OleDbType.Decimal, Nothing)
            FA.Direction = ParameterDirection.Input
            FA.Value = Me.FichaNutricion.RequerimientosNutricionales.FA

            Dim ProteinaPorc As OleDbParameter = cmd.Parameters.Add("@rn_proteina_porc", OleDbType.Decimal, Nothing)
            ProteinaPorc.Direction = ParameterDirection.Input
            ProteinaPorc.Value = Me.FichaNutricion.RequerimientosNutricionales.ProteinaPorc

            Dim LipidosPorc As OleDbParameter = cmd.Parameters.Add("@rn_lipidos_porc", OleDbType.Decimal, Nothing)
            LipidosPorc.Direction = ParameterDirection.Input
            LipidosPorc.Value = Me.FichaNutricion.RequerimientosNutricionales.LipidosPorc

            Dim AporteKCal As OleDbParameter = cmd.Parameters.Add("@rn_aporte_alim_kcal", OleDbType.Decimal, Nothing)
            AporteKCal.Direction = ParameterDirection.Input
            AporteKCal.Value = Me.FichaNutricion.RequerimientosNutricionales.AporteKCal

            Dim AporteCho As OleDbParameter = cmd.Parameters.Add("@rn_aporte_alim_cho", OleDbType.Decimal, Nothing)
            AporteCho.Direction = ParameterDirection.Input
            AporteCho.Value = Me.FichaNutricion.RequerimientosNutricionales.AporteCho

            Dim AporteLip As OleDbParameter = cmd.Parameters.Add("@rn_aporte_alim_lip", OleDbType.Decimal, Nothing)
            AporteLip.Direction = ParameterDirection.Input
            AporteLip.Value = Me.FichaNutricion.RequerimientosNutricionales.AporteLip

            Dim AporteProt As OleDbParameter = cmd.Parameters.Add("@rn_aporte_alim_prot", OleDbType.Decimal, Nothing)
            AporteProt.Direction = ParameterDirection.Input
            AporteProt.Value = Me.FichaNutricion.RequerimientosNutricionales.AporteProt
#End Region
#Region "Plan de Nutrición"
            Dim PrescripcionDietetica As OleDbParameter = cmd.Parameters.Add("@pd_obs", OleDbType.VarChar, 500)
            PrescripcionDietetica.Direction = ParameterDirection.Input
            PrescripcionDietetica.Value = Me.FichaNutricion.PrescripcionDietetica

            Dim IndicacionesGenerales As OleDbParameter = cmd.Parameters.Add("@ig_obs", OleDbType.VarChar, 500)
            IndicacionesGenerales.Direction = ParameterDirection.Input
            IndicacionesGenerales.Value = Me.FichaNutricion.IndicacionesGenerales

            Dim DiagNutInt2 As OleDbParameter = cmd.Parameters.Add("@pn_dni", OleDbType.VarChar, 500)
            DiagNutInt2.Direction = ParameterDirection.Input
            DiagNutInt2.Value = Me.FichaNutricion.DiagNutInt

            Dim ObjetivosAlimentarios As OleDbParameter = cmd.Parameters.Add("@pn_oan", OleDbType.VarChar, 500)
            ObjetivosAlimentarios.Direction = ParameterDirection.Input
            ObjetivosAlimentarios.Value = Me.FichaNutricion.ObjetivosAlimentarios

            Dim IntervencionNutricional As OleDbParameter = cmd.Parameters.Add("@pn_in", OleDbType.VarChar, 500)
            IntervencionNutricional.Direction = ParameterDirection.Input
            IntervencionNutricional.Value = Me.FichaNutricion.IntervencionNutricional
#End Region
#Region "Cuestionario"
            Dim Fruta As OleDbParameter = cmd.Parameters.Add("@frutas", OleDbType.Decimal, Nothing)
            Fruta.Direction = ParameterDirection.Input
            Fruta.Value = Me.FichaNutricion.Cuestionario.Fruta.ID

            Dim Verdura As OleDbParameter = cmd.Parameters.Add("@verduras", OleDbType.Decimal, Nothing)
            Verdura.Direction = ParameterDirection.Input
            Verdura.Value = Me.FichaNutricion.Cuestionario.Verdura.ID

            Dim Lacteo As OleDbParameter = cmd.Parameters.Add("@lacteos", OleDbType.Decimal, Nothing)
            Lacteo.Direction = ParameterDirection.Input
            Lacteo.Value = Me.FichaNutricion.Cuestionario.Lacteo.ID

            Dim Carne As OleDbParameter = cmd.Parameters.Add("@carnes", OleDbType.Decimal, Nothing)
            Carne.Direction = ParameterDirection.Input
            Carne.Value = Me.FichaNutricion.Cuestionario.Carne.ID

            Dim Azucar As OleDbParameter = cmd.Parameters.Add("@azucar", OleDbType.Decimal, Nothing)
            Azucar.Direction = ParameterDirection.Input
            Azucar.Value = Me.FichaNutricion.Cuestionario.Azucar.ID

            Dim Legumbre As OleDbParameter = cmd.Parameters.Add("@legumbres", OleDbType.Decimal, Nothing)
            Legumbre.Direction = ParameterDirection.Input
            Legumbre.Value = Me.FichaNutricion.Cuestionario.Legumbre.ID

            Dim Pescado As OleDbParameter = cmd.Parameters.Add("@pescado", OleDbType.Decimal, Nothing)
            Pescado.Direction = ParameterDirection.Input
            Pescado.Value = Me.FichaNutricion.Cuestionario.Pescado.ID

            Dim Sodio As OleDbParameter = cmd.Parameters.Add("@sodio", OleDbType.Decimal, Nothing)
            Sodio.Direction = ParameterDirection.Input
            Sodio.Value = Me.FichaNutricion.Cuestionario.Sodio.ID

            Dim Liquido As OleDbParameter = cmd.Parameters.Add("@liquidos", OleDbType.Decimal, Nothing)
            Liquido.Direction = ParameterDirection.Input
            Liquido.Value = Me.FichaNutricion.Cuestionario.Liquido.ID
#End Region
            Dim outError As OleDbParameter = cmd.Parameters.Add("@outError", OleDbType.Integer)
            outError.Direction = ParameterDirection.Output

            Dim outIdKine As OleDbParameter = cmd.Parameters.Add("@outIdNutri", OleDbType.Integer)
            outIdKine.Direction = ParameterDirection.Output

            conn.Open()
            cmd.ExecuteReader()
            conn.Close()

            Dim idpsico = CInt(cmd.Parameters("@outIdNutri").Value)

            Return CInt(cmd.Parameters("@outError").Value)
        End Function
#End Region
#Region "Medico"
        Public Shared Function getFichaMedico(inId As Integer, ByRef NoData As Boolean) As Ficha
            Try
                Dim conn As OleDbConnection = New OleDbConnection(ConfigurationManager.ConnectionStrings("ConexionKaplan").ConnectionString)
                Dim cmd As OleDbCommand = New OleDbCommand("Kaplan.BuscarFichaMedicoxReserva", conn)
                cmd.CommandType = CommandType.StoredProcedure

                Dim id As OleDbParameter = cmd.Parameters.Add("@inId", OleDbType.Decimal, Nothing)
                id.Direction = ParameterDirection.Input
                id.Value = inId

                Dim adapter As OleDbDataAdapter = New OleDbDataAdapter(cmd)
                Dim vDataSet As New DataSet
                adapter.Fill(vDataSet)
                If Not vDataSet.Tables(0).Rows.Count.Equals(0) Then
                    getFichaMedico = MapeoFichaMedico(vDataSet)
                End If

                If vDataSet.Tables(0).Rows.Count = 0 Then NoData = True

                Return getFichaMedico

            Catch exc As Exception
                Return Nothing
            End Try

        End Function
        Private Shared Function MapeoFichaMedico(prmDatos As DataSet) As Ficha
            Try
                Dim vficha As New Ficha
                Dim vMedico As New FichaMedico
                Dim vExamenMedico As New ExamenMedico
                Dim vExamenFisico As New ExamenFisico
                Dim vFarmacologia As New Farmacologia
                Dim vHistoriaCardiopatia As New HistoriaCardiopatia
                Dim vHistoriaCronica As New HistoriaCronica
                Dim vOtraCirugia As New OtraCirugia
                Dim vAlopurinol As New Alopurinol
                Dim vARA2 As New ARA2
                Dim vAntirritmicos As New Antiarritmicos
                Dim vAnticoagulanteOral As New AnticoagulanteOral
                Dim vAntiplaquetario As New Antiplaquetario
                Dim vBetabloqueador As New Betabloqueador
                Dim vBloqueadorCorrientes As New BloqueadorCorrientes
                Dim vDigitalicos As New Digitalicos
                Dim vDiuretico As New Diuretico
                Dim vEstatina As New Estatina
                Dim vEsteroides As New Esteroides
                Dim vHipoglicemiante As New Hipoglicemiante
                Dim vIECA As New IECA
                Dim vNitratos As New Nitratos
                Dim vOtros As New Otros

                vficha.FichaMedico = vMedico.MapeoFichaMedico(prmDatos.Tables(0))
                vficha.FichaMedico.Farmacologia = vFarmacologia.MapeoFarmacologia(prmDatos.Tables(1))
                vficha.FichaMedico.ExamenMedico = vExamenMedico.MapeoExamenMedico(prmDatos.Tables(2))
                vficha.FichaMedico.ExamenFisico = vExamenFisico.MapeoExamenFisico(prmDatos.Tables(3))
                vficha.FichaMedico.ListHistoriaCardiopatia = vHistoriaCardiopatia.MapeoHistoriaCardiopatia(prmDatos.Tables(4))
                vficha.FichaMedico.ListHistoriaCronica = vHistoriaCronica.MapeoHistoriaCronica(prmDatos.Tables(5))
                vficha.FichaMedico.ListOtraCirugia = vOtraCirugia.MapeoOtraCirugia(prmDatos.Tables(6))
                vficha.FichaMedico.Farmacologia.ListAlopurinol = vAlopurinol.MapeoAlopurinol(prmDatos.Tables(7))
                vficha.FichaMedico.Farmacologia.ListARA2 = vARA2.MapeoARA2(prmDatos.Tables(8))
                vficha.FichaMedico.Farmacologia.ListAntiarritmicos = vAntirritmicos.MapeoAntiarritmicos(prmDatos.Tables(9))
                vficha.FichaMedico.Farmacologia.ListAnticoagulanteOral = vAnticoagulanteOral.MapeoAnticoagulanteOral(prmDatos.Tables(10))
                vficha.FichaMedico.Farmacologia.ListAntiplaquetario = vAntiplaquetario.MapeoAntiplaquetario(prmDatos.Tables(11))
                vficha.FichaMedico.Farmacologia.ListBetabloqueador = vBetabloqueador.MapeoBetabloqueador(prmDatos.Tables(12))
                vficha.FichaMedico.Farmacologia.ListBloqueadorCorrientes = vBloqueadorCorrientes.MapeoBloqueadorCorrientes(prmDatos.Tables(13))
                vficha.FichaMedico.Farmacologia.ListDigitalicos = vDigitalicos.MapeoDigitalicos(prmDatos.Tables(14))
                vficha.FichaMedico.Farmacologia.ListDiuretico = vDiuretico.MapeoDiuretico(prmDatos.Tables(15))
                vficha.FichaMedico.Farmacologia.ListEstatina = vEstatina.MapeoEstatina(prmDatos.Tables(16))
                vficha.FichaMedico.Farmacologia.ListEsteroides = vEsteroides.MapeoEsteroides(prmDatos.Tables(17))
                vficha.FichaMedico.Farmacologia.ListHipoglicemiante = vHipoglicemiante.MapeoHipoglicemiante(prmDatos.Tables(18))
                vficha.FichaMedico.Farmacologia.ListIECA = vIECA.MapeoIECA(prmDatos.Tables(19))
                vficha.FichaMedico.Farmacologia.ListNitratos = vNitratos.MapeoNitratos(prmDatos.Tables(20))
                vficha.FichaMedico.Farmacologia.ListOtros = vOtros.MapeoOtros(prmDatos.Tables(21))

                Return vficha
            Catch ex As Exception
                Return Nothing
            End Try

        End Function

        Public Function registrarFichaMedico() As Boolean
            Dim conn As OleDbConnection = New OleDbConnection(ConfigurationManager.ConnectionStrings("ConexionKaplan").ConnectionString)
            Dim cmd As OleDbCommand = New OleDbCommand("Kaplan.RegistrarFichaMedico", conn)
            cmd.CommandType = CommandType.StoredProcedure

            Dim inId As OleDbParameter = cmd.Parameters.Add("@id_ficha", OleDbType.Decimal, Nothing)
            inId.Direction = ParameterDirection.Input
            inId.Value = Me.Id

            Dim inid_reserva As OleDbParameter = cmd.Parameters.Add("@id_reserva", OleDbType.Decimal, Nothing)
            inid_reserva.Direction = ParameterDirection.Input
            inid_reserva.Value = Me.FichaMedico.IdReserva

            Dim inIdEspecialista As OleDbParameter = cmd.Parameters.Add("@id_especialista", OleDbType.Decimal, Nothing)
            inIdEspecialista.Direction = ParameterDirection.Input
            inIdEspecialista.Value = Me.FichaMedico.IdEspecialista

            Dim inIdMedico As OleDbParameter = cmd.Parameters.Add("@id_ficha_med", OleDbType.Decimal, Nothing)
            inIdMedico.Direction = ParameterDirection.Input
            inIdMedico.Value = Me.FichaMedico.Id

            Dim inho_centrov As OleDbParameter = cmd.Parameters.Add("@ho_centrov", OleDbType.VarChar, 100)
            inho_centrov.Direction = ParameterDirection.Input
            inho_centrov.Value = Me.FichaMedico.CentroDerivacion

            Dim inho_medico As OleDbParameter = cmd.Parameters.Add("@ho_medico", OleDbType.VarChar, 100)
            inho_medico.Direction = ParameterDirection.Input
            inho_medico.Value = Me.FichaMedico.MedicoDerivador

            Dim inho_motivo As OleDbParameter = cmd.Parameters.Add("@ho_motivo", OleDbType.VarChar, 100)
            inho_motivo.Direction = ParameterDirection.Input
            inho_motivo.Value = Me.FichaMedico.MotivoDerivacion

            Dim inho_fechaAlta As OleDbParameter = cmd.Parameters.Add("@ho_fechaAlta", OleDbType.Date, Nothing)
            inho_fechaAlta.Direction = ParameterDirection.Input
            inho_fechaAlta.Value = Me.FichaMedico.FechaAlta

            Dim inho_nroHosp As OleDbParameter = cmd.Parameters.Add("@ho_nroHosp", OleDbType.Decimal, Nothing)
            inho_nroHosp.Direction = ParameterDirection.Input
            inho_nroHosp.Value = Me.FichaMedico.NumeroHospitalizaciones

            Dim iname_HistFamCardiopatia As OleDbParameter = cmd.Parameters.Add("@ame_HistFamCardiopatia", OleDbType.Decimal, Nothing)
            iname_HistFamCardiopatia.Direction = ParameterDirection.Input
            iname_HistFamCardiopatia.Value = Me.FichaMedico.HistoriaCardiopatia.ID

            Dim iname_HistFamCronica As OleDbParameter = cmd.Parameters.Add("@ame_HistFamCronica", OleDbType.Decimal, Nothing)
            iname_HistFamCronica.Direction = ParameterDirection.Input
            iname_HistFamCronica.Value = Me.FichaMedico.HistoriaCronica.ID

            Dim iname_imc As OleDbParameter = cmd.Parameters.Add("@ame_imc", OleDbType.Decimal, Nothing)
            iname_imc.Direction = ParameterDirection.Input
            iname_imc.Value = Me.FichaMedico.IndiceMasaCoporal

            Dim iname_perCint As OleDbParameter = cmd.Parameters.Add("@ame_perCint", OleDbType.Decimal, Nothing)
            iname_perCint.Direction = ParameterDirection.Input
            iname_perCint.Value = Me.FichaMedico.PerimetroCintura

            Dim iname_relCint As OleDbParameter = cmd.Parameters.Add("@ame_relCint", OleDbType.Decimal, Nothing)
            iname_relCint.Direction = ParameterDirection.Input
            iname_relCint.Value = Me.FichaMedico.RelacionCinturaCadera

            Dim iname_porGra As OleDbParameter = cmd.Parameters.Add("@ame_porGra", OleDbType.Decimal, Nothing)
            iname_porGra.Direction = ParameterDirection.Input
            iname_porGra.Value = Me.FichaMedico.PorcentajeGrasa

            Dim iname_tab As OleDbParameter = cmd.Parameters.Add("@ame_tab", OleDbType.Decimal, Nothing)
            iname_tab.Direction = ParameterDirection.Input
            iname_tab.Value = Me.FichaMedico.Tabaquismo

            Dim iame_tabObs As OleDbParameter = cmd.Parameters.Add("@ame_tabObs", OleDbType.VarChar, 100)
            iame_tabObs.Direction = ParameterDirection.Input
            iame_tabObs.Value = Me.FichaMedico.IPA

            Dim iname_tabAct As OleDbParameter = cmd.Parameters.Add("@ame_tabAct", OleDbType.Decimal, Nothing)
            iname_tabAct.Direction = ParameterDirection.Input
            iname_tabAct.Value = Me.FichaMedico.TabaquismoActivo.ID

            Dim iname_alc As OleDbParameter = cmd.Parameters.Add("@ame_alc", OleDbType.Decimal, Nothing)
            iname_alc.Direction = ParameterDirection.Input
            iname_alc.Value = Me.FichaMedico.Alcohol.ID

            Dim iname_actFis As OleDbParameter = cmd.Parameters.Add("@ame_actFis", OleDbType.Decimal, Nothing)
            iname_actFis.Direction = ParameterDirection.Input
            iname_actFis.Value = Me.FichaMedico.ActividadFisica

            Dim iname_dro As OleDbParameter = cmd.Parameters.Add("@ame_dro", OleDbType.Decimal, Nothing)
            iname_dro.Direction = ParameterDirection.Input
            iname_dro.Value = Me.FichaMedico.AbusoDrogas.ID

            Dim iname_droObs As OleDbParameter = cmd.Parameters.Add("@ame_droObs", OleDbType.VarChar, 100)
            iname_droObs.Direction = ParameterDirection.Input
            iname_droObs.Value = Me.FichaMedico.AbusoDrogasDetalle

            Dim inamo_dislipidemias As OleDbParameter = cmd.Parameters.Add("@amo_dislipidemias", OleDbType.Decimal, Nothing)
            inamo_dislipidemias.Direction = ParameterDirection.Input
            inamo_dislipidemias.Value = Me.FichaMedico.Dislipidemias.ID

            Dim inamo_dislipidemiasObs As OleDbParameter = cmd.Parameters.Add("@amo_dislipidemiasObs", OleDbType.VarChar, 100)
            inamo_dislipidemiasObs.Direction = ParameterDirection.Input
            inamo_dislipidemiasObs.Value = Me.FichaMedico.DislipidemiasObs

            Dim inamo_hipertension As OleDbParameter = cmd.Parameters.Add("@amo_hipertension", OleDbType.Decimal, Nothing)
            inamo_hipertension.Direction = ParameterDirection.Input
            inamo_hipertension.Value = Me.FichaMedico.HipertensionArterial.ID

            Dim inamo_hipertensionObs As OleDbParameter = cmd.Parameters.Add("@amo_hipertensionObs", OleDbType.VarChar, 100)
            inamo_hipertensionObs.Direction = ParameterDirection.Input
            inamo_hipertensionObs.Value = Me.FichaMedico.HipertensionArterialObs

            Dim inamo_diabetes As OleDbParameter = cmd.Parameters.Add("@amo_diabetes", OleDbType.Decimal, Nothing)
            inamo_diabetes.Direction = ParameterDirection.Input
            inamo_diabetes.Value = Me.FichaMedico.DiabetesMellitus.ID

            Dim inamo_insulinoterapia As OleDbParameter = cmd.Parameters.Add("@amo_insulinoterapia", OleDbType.Decimal, Nothing)
            inamo_insulinoterapia.Direction = ParameterDirection.Input
            inamo_insulinoterapia.Value = Me.FichaMedico.Insulinoterapia.ID

            Dim inamo_insulinoterapiaObs As OleDbParameter = cmd.Parameters.Add("@amo_insulinoterapiaObs", OleDbType.VarChar, 100)
            inamo_insulinoterapiaObs.Direction = ParameterDirection.Input
            inamo_insulinoterapiaObs.Value = Me.FichaMedico.InsulinoterapiaDosis

            Dim inamo_alergias As OleDbParameter = cmd.Parameters.Add("@amo_alergias", OleDbType.Decimal, Nothing)
            inamo_alergias.Direction = ParameterDirection.Input
            inamo_alergias.Value = Me.FichaMedico.Alergias.ID

            Dim inamo_alergiasObs As OleDbParameter = cmd.Parameters.Add("@amo_alergiasObs", OleDbType.VarChar, 100)
            inamo_alergiasObs.Direction = ParameterDirection.Input
            inamo_alergiasObs.Value = Me.FichaMedico.AlergiasObs

            Dim inamo_enfRenalCronica As OleDbParameter = cmd.Parameters.Add("@amo_enfRenalCronica", OleDbType.Decimal, Nothing)
            inamo_enfRenalCronica.Direction = ParameterDirection.Input
            inamo_enfRenalCronica.Value = Me.FichaMedico.EnfermedadRenalCronica.ID

            Dim inamo_etapa As OleDbParameter = cmd.Parameters.Add("@amo_etapa", OleDbType.VarChar, 100)
            inamo_etapa.Direction = ParameterDirection.Input
            inamo_etapa.Value = Me.FichaMedico.Etapa

            Dim inamo_proteinurea As OleDbParameter = cmd.Parameters.Add("@amo_proteinurea", OleDbType.Decimal, Nothing)
            inamo_proteinurea.Direction = ParameterDirection.Input
            inamo_proteinurea.Value = Me.FichaMedico.Proteinurea.ID

            Dim inamo_hemodialisis As OleDbParameter = cmd.Parameters.Add("@amo_hemodialisis", OleDbType.Decimal, Nothing)
            inamo_hemodialisis.Direction = ParameterDirection.Input
            inamo_hemodialisis.Value = Me.FichaMedico.Hemodialisis.ID

            Dim inamo_anemia As OleDbParameter = cmd.Parameters.Add("@amo_anemia", OleDbType.Decimal, Nothing)
            inamo_anemia.Direction = ParameterDirection.Input
            inamo_anemia.Value = Me.FichaMedico.Anemia.ID

            Dim inamo_aneHemoglobian As OleDbParameter = cmd.Parameters.Add("@amo_aneHemoglobian", OleDbType.VarChar, 100)
            inamo_aneHemoglobian.Direction = ParameterDirection.Input
            inamo_aneHemoglobian.Value = Me.FichaMedico.Hemoglobina

            Dim inamo_aneFerritina As OleDbParameter = cmd.Parameters.Add("@amo_aneFerritina", OleDbType.VarChar, 100)
            inamo_aneFerritina.Direction = ParameterDirection.Input
            inamo_aneFerritina.Value = Me.FichaMedico.Ferritina

            Dim inamo_desAlbumina As OleDbParameter = cmd.Parameters.Add("@amo_desAlbumina", OleDbType.VarChar, 100)
            inamo_desAlbumina.Direction = ParameterDirection.Input
            inamo_desAlbumina.Value = Me.FichaMedico.Albumina

            Dim inamo_desLinfocitos As OleDbParameter = cmd.Parameters.Add("@amo_desLinfocitos", OleDbType.VarChar, 100)
            inamo_desLinfocitos.Direction = ParameterDirection.Input
            inamo_desLinfocitos.Value = Me.FichaMedico.Linfocitos

            Dim inamo_enfPulmonar As OleDbParameter = cmd.Parameters.Add("@amo_enfPulmonar", OleDbType.Decimal, Nothing)
            inamo_enfPulmonar.Direction = ParameterDirection.Input
            inamo_enfPulmonar.Value = Me.FichaMedico.EnfermedadPulmonar.ID

            Dim inamo_enfPulmonarObs As OleDbParameter = cmd.Parameters.Add("@amo_enfPulmonarObs", OleDbType.VarChar, 100)
            inamo_enfPulmonarObs.Direction = ParameterDirection.Input
            inamo_enfPulmonarObs.Value = Me.FichaMedico.EnfermedadPulmonarObs

            Dim inamo_enfSevFunPul As OleDbParameter = cmd.Parameters.Add("@amo_enfSevFunPul", OleDbType.Decimal, Nothing)
            inamo_enfSevFunPul.Direction = ParameterDirection.Input
            inamo_enfSevFunPul.Value = Me.FichaMedico.SeveridadFuncionPulmonar.ID

            Dim inamo_enfHepatica As OleDbParameter = cmd.Parameters.Add("@amo_enfHepatica", OleDbType.Decimal, Nothing)
            inamo_enfHepatica.Direction = ParameterDirection.Input
            inamo_enfHepatica.Value = Me.FichaMedico.EnfermedadHepatica.ID

            Dim inamo_enfHepaticaObs As OleDbParameter = cmd.Parameters.Add("@amo_enfHepaticaObs", OleDbType.VarChar, 100)
            inamo_enfHepaticaObs.Direction = ParameterDirection.Input
            inamo_enfHepaticaObs.Value = Me.FichaMedico.EnfermedadHepaticaObs

            Dim inamo_enfArtPeriferica As OleDbParameter = cmd.Parameters.Add("@amo_enfArtPeriferica", OleDbType.Decimal, Nothing)
            inamo_enfArtPeriferica.Direction = ParameterDirection.Input
            inamo_enfArtPeriferica.Value = Me.FichaMedico.EnfermedadArterialPeriferica.ID

            Dim inamo_enfArtPerifericaObs As OleDbParameter = cmd.Parameters.Add("@amo_enfArtPerifericaObs", OleDbType.VarChar, 100)
            inamo_enfArtPerifericaObs.Direction = ParameterDirection.Input
            inamo_enfArtPerifericaObs.Value = Me.FichaMedico.EnfermedadArterialPerifericaObs

            Dim inamo_cirRevPeriferica As OleDbParameter = cmd.Parameters.Add("@amo_cirRevPeriferica", OleDbType.Decimal, Nothing)
            inamo_cirRevPeriferica.Direction = ParameterDirection.Input
            inamo_cirRevPeriferica.Value = Me.FichaMedico.CirugiaPeriferica.ID

            Dim inamo_cirRevPerifericaObs As OleDbParameter = cmd.Parameters.Add("@amo_cirRevPerifericaObs", OleDbType.VarChar, 100)
            inamo_cirRevPerifericaObs.Direction = ParameterDirection.Input
            inamo_cirRevPerifericaObs.Value = Me.FichaMedico.CirugiaPerifericaObs

            Dim inamo_enfCerVascular As OleDbParameter = cmd.Parameters.Add("@amo_enfCerVascular", OleDbType.Decimal, Nothing)
            inamo_enfCerVascular.Direction = ParameterDirection.Input
            inamo_enfCerVascular.Value = Me.FichaMedico.EnfermedadCerebroVascular.ID

            Dim inamo_enfCerVascularObs As OleDbParameter = cmd.Parameters.Add("@amo_enfCerVascularObs", OleDbType.VarChar, 100)
            inamo_enfCerVascularObs.Direction = ParameterDirection.Input
            inamo_enfCerVascularObs.Value = Me.FichaMedico.EnfermedadCerebroVascularObs

            Dim inamo_secuelas As OleDbParameter = cmd.Parameters.Add("@amo_secuelas", OleDbType.VarChar, 100)
            inamo_secuelas.Direction = ParameterDirection.Input
            inamo_secuelas.Value = Me.FichaMedico.Secuelas

            Dim inamo_cirRevCarotidea As OleDbParameter = cmd.Parameters.Add("@amo_cirRevCarotidea", OleDbType.Decimal, Nothing)
            inamo_cirRevCarotidea.Direction = ParameterDirection.Input
            inamo_cirRevCarotidea.Value = Me.FichaMedico.CirugiaCarotidea.ID

            Dim inamo_cirRevCarotideaObs As OleDbParameter = cmd.Parameters.Add("@amo_cirRevCarotideaObs", OleDbType.VarChar, 100)
            inamo_cirRevCarotideaObs.Direction = ParameterDirection.Input
            inamo_cirRevCarotideaObs.Value = Me.FichaMedico.CirugiaCarotideaObs

            Dim inamo_inmunosupresion As OleDbParameter = cmd.Parameters.Add("@amo_inmunosupresion", OleDbType.Decimal, Nothing)
            inamo_inmunosupresion.Direction = ParameterDirection.Input
            inamo_inmunosupresion.Value = Me.FichaMedico.Inmunosupresion.ID

            Dim inamo_inmunosupresionObs As OleDbParameter = cmd.Parameters.Add("@amo_inmunosupresionObs", OleDbType.VarChar, 100)
            inamo_inmunosupresionObs.Direction = ParameterDirection.Input
            inamo_inmunosupresionObs.Value = Me.FichaMedico.InmunosupresionObs

            Dim inamo_hisOncologica As OleDbParameter = cmd.Parameters.Add("@amo_hisOncologica", OleDbType.Decimal, Nothing)
            inamo_hisOncologica.Direction = ParameterDirection.Input
            inamo_hisOncologica.Value = Me.FichaMedico.HistoriaOncologica.ID

            Dim inamo_hisOncologicaObs As OleDbParameter = cmd.Parameters.Add("@amo_hisOncologicaObs", OleDbType.VarChar, 100)
            inamo_hisOncologicaObs.Direction = ParameterDirection.Input
            inamo_hisOncologicaObs.Value = Me.FichaMedico.HistoriaOncologicaObs

            Dim inamo_localizacion As OleDbParameter = cmd.Parameters.Add("@amo_localizacion", OleDbType.VarChar, 100)
            inamo_localizacion.Direction = ParameterDirection.Input
            inamo_localizacion.Value = Me.FichaMedico.Localizacion

            Dim inamo_quimioterapia As OleDbParameter = cmd.Parameters.Add("@amo_quimioterapia", OleDbType.Decimal, Nothing)
            inamo_quimioterapia.Direction = ParameterDirection.Input
            inamo_quimioterapia.Value = Me.FichaMedico.Quimioterapia.ID

            Dim inamo_quimioterapiaObs As OleDbParameter = cmd.Parameters.Add("@amo_quimioterapiaObs", OleDbType.VarChar, 100)
            inamo_quimioterapiaObs.Direction = ParameterDirection.Input
            inamo_quimioterapiaObs.Value = Me.FichaMedico.QuimioterapiaObs

            Dim inamo_radioterapia As OleDbParameter = cmd.Parameters.Add("@amo_radioterapia", OleDbType.Decimal, Nothing)
            inamo_radioterapia.Direction = ParameterDirection.Input
            inamo_radioterapia.Value = Me.FichaMedico.Radioterapia.ID

            Dim inamo_radioterapiaObs As OleDbParameter = cmd.Parameters.Add("@amo_radioterapiaObs", OleDbType.VarChar, 100)
            inamo_radioterapiaObs.Direction = ParameterDirection.Input
            inamo_radioterapiaObs.Value = Me.FichaMedico.RadioterapiaObs

            Dim inamo_apnea As OleDbParameter = cmd.Parameters.Add("@amo_apnea", OleDbType.Decimal, Nothing)
            inamo_apnea.Direction = ParameterDirection.Input
            inamo_apnea.Value = Me.FichaMedico.ApneaSueno.ID

            Dim inamo_apneaObs As OleDbParameter = cmd.Parameters.Add("@amo_apneaObs", OleDbType.VarChar, 100)
            inamo_apneaObs.Direction = ParameterDirection.Input
            inamo_apneaObs.Value = Me.FichaMedico.ApneaSuenoObs

            Dim inamo_enfCardiaca As OleDbParameter = cmd.Parameters.Add("@amo_enfCardiaca", OleDbType.VarChar, 100)
            inamo_enfCardiaca.Direction = ParameterDirection.Input
            inamo_enfCardiaca.Value = Me.FichaMedico.EnfermedadCardiaca

            Dim inamo_carCongenita As OleDbParameter = cmd.Parameters.Add("@amo_carCongenita", OleDbType.Decimal, Nothing)
            inamo_carCongenita.Direction = ParameterDirection.Input
            inamo_carCongenita.Value = Me.FichaMedico.CardiopatiaCongenita.ID

            Dim inamo_carCongenitaObs As OleDbParameter = cmd.Parameters.Add("@amo_carCongenitaObs", OleDbType.VarChar, 100)
            inamo_carCongenitaObs.Direction = ParameterDirection.Input
            inamo_carCongenitaObs.Value = Me.FichaMedico.CardiopatiaCongenitaObs

            Dim inamo_infAguMiocardio As OleDbParameter = cmd.Parameters.Add("@amo_infAguMiocardio", OleDbType.Decimal, Nothing)
            inamo_infAguMiocardio.Direction = ParameterDirection.Input
            inamo_infAguMiocardio.Value = Me.FichaMedico.InfartoAgudoMiocardio.ID

            Dim inamo_infAguMiocardioObs As OleDbParameter = cmd.Parameters.Add("@amo_infAguMiocardioObs", OleDbType.VarChar, 100)
            inamo_infAguMiocardioObs.Direction = ParameterDirection.Input
            inamo_infAguMiocardioObs.Value = Me.FichaMedico.InfartoAgudoMiocardioObs

            Dim inamo_infAguMiocardioFecha As OleDbParameter = cmd.Parameters.Add("@amo_infAguMiocardioFecha", OleDbType.Date, Nothing)
            inamo_infAguMiocardioFecha.Direction = ParameterDirection.Input
            inamo_infAguMiocardioFecha.Value = Me.FichaMedico.InfartoAgudoMiocardioFecha

            Dim inamo_insCardiacaFecha As OleDbParameter = cmd.Parameters.Add("@amo_insCardiacaFecha", OleDbType.Date, Nothing)
            inamo_insCardiacaFecha.Direction = ParameterDirection.Input
            inamo_insCardiacaFecha.Value = Me.FichaMedico.InsuficienciaCardiacaFecha

            Dim inamo_insCardiacaNYHA As OleDbParameter = cmd.Parameters.Add("@amo_insCardiacaNYHA", OleDbType.Decimal, Nothing)
            inamo_insCardiacaNYHA.Direction = ParameterDirection.Input
            inamo_insCardiacaNYHA.Value = Me.FichaMedico.InsuficienciaCardiaca.ID

            Dim inamo_insCardiacaNYHAObs As OleDbParameter = cmd.Parameters.Add("@amo_insCardiacaNYHAObs", OleDbType.VarChar, 100)
            inamo_insCardiacaNYHAObs.Direction = ParameterDirection.Input
            inamo_insCardiacaNYHAObs.Value = Me.FichaMedico.InsuficienciaCardiacaNYHA

            Dim inamo_sinCardiogenico As OleDbParameter = cmd.Parameters.Add("@amo_sinCardiogenico", OleDbType.Decimal, Nothing)
            inamo_sinCardiogenico.Direction = ParameterDirection.Input
            inamo_sinCardiogenico.Value = Me.FichaMedico.SincopeCardiogenico.ID

            Dim inamo_sinCardiogenicoObs As OleDbParameter = cmd.Parameters.Add("@amo_sinCardiogenicoObs", OleDbType.VarChar, 100)
            inamo_sinCardiogenicoObs.Direction = ParameterDirection.Input
            inamo_sinCardiogenicoObs.Value = Me.FichaMedico.SincopeCardiogenicoObs

            Dim inamo_shoCardiogenicoFecha As OleDbParameter = cmd.Parameters.Add("@amo_shoCardiogenicoFecha", OleDbType.Date, Nothing)
            inamo_shoCardiogenicoFecha.Direction = ParameterDirection.Input
            inamo_shoCardiogenicoFecha.Value = Me.FichaMedico.ShockCardiogenicoFecha

            Dim inamo_shoCardiogenico As OleDbParameter = cmd.Parameters.Add("@amo_shoCardiogenico", OleDbType.Decimal, Nothing)
            inamo_shoCardiogenico.Direction = ParameterDirection.Input
            inamo_shoCardiogenico.Value = Me.FichaMedico.ShockCardiogenico.ID

            Dim inamo_shoCardiogenicoObs As OleDbParameter = cmd.Parameters.Add("@amo_shoCardiogenicoObs", OleDbType.VarChar, 100)
            inamo_shoCardiogenicoObs.Direction = ParameterDirection.Input
            inamo_shoCardiogenicoObs.Value = Me.FichaMedico.ShockCardiogenicoObs

            Dim inamo_parCardiorrespFecha As OleDbParameter = cmd.Parameters.Add("@amo_parCardiorrespFecha", OleDbType.Date, Nothing)
            inamo_parCardiorrespFecha.Direction = ParameterDirection.Input
            inamo_parCardiorrespFecha.Value = Me.FichaMedico.ParoCardiorRespiratorioFecha

            Dim inamo_parCardiorresp As OleDbParameter = cmd.Parameters.Add("@amo_parCardiorresp", OleDbType.Decimal, Nothing)
            inamo_parCardiorresp.Direction = ParameterDirection.Input
            inamo_parCardiorresp.Value = Me.FichaMedico.ParoCardiorRespiratorio.ID

            Dim inamo_parCardiorrespObs As OleDbParameter = cmd.Parameters.Add("@amo_parCardiorrespObs", OleDbType.VarChar, 100)
            inamo_parCardiorrespObs.Direction = ParameterDirection.Input
            inamo_parCardiorrespObs.Value = Me.FichaMedico.ParoCardiorRespiratorioObs

            Dim inamo_supraventicular As OleDbParameter = cmd.Parameters.Add("@amo_supraventicular", OleDbType.Decimal, Nothing)
            inamo_supraventicular.Direction = ParameterDirection.Input
            inamo_supraventicular.Value = Me.FichaMedico.Supraventricular.ID

            Dim inamo_supraventicularObs As OleDbParameter = cmd.Parameters.Add("@amo_supraventicularObs", OleDbType.VarChar, 100)
            inamo_supraventicularObs.Direction = ParameterDirection.Input
            inamo_supraventicularObs.Value = Me.FichaMedico.SupraventricularObs

            Dim inamo_ventricular As OleDbParameter = cmd.Parameters.Add("@amo_ventricular", OleDbType.Decimal, Nothing)
            inamo_ventricular.Direction = ParameterDirection.Input
            inamo_ventricular.Value = Me.FichaMedico.Ventricular.ID

            Dim inamo_ventricularObss As OleDbParameter = cmd.Parameters.Add("@amo_ventricularObs", OleDbType.VarChar, 100)
            inamo_ventricularObss.Direction = ParameterDirection.Input
            inamo_ventricularObss.Value = Me.FichaMedico.VentricularObs

            Dim inamo_endocarditis As OleDbParameter = cmd.Parameters.Add("@amo_endocarditis", OleDbType.Decimal, Nothing)
            inamo_endocarditis.Direction = ParameterDirection.Input
            inamo_endocarditis.Value = Me.FichaMedico.Endocarditis.ID

            Dim inamo_endocarditisObs As OleDbParameter = cmd.Parameters.Add("@amo_endocarditisObs", OleDbType.VarChar, 100)
            inamo_endocarditisObs.Direction = ParameterDirection.Input
            inamo_endocarditisObs.Value = Me.FichaMedico.EndocarditisObs

            Dim inamo_disAortica As OleDbParameter = cmd.Parameters.Add("@amo_disAortica", OleDbType.Decimal, Nothing)
            inamo_disAortica.Direction = ParameterDirection.Input
            inamo_disAortica.Value = Me.FichaMedico.DiseccionAortica.ID

            Dim inamo_disAorticaTipo As OleDbParameter = cmd.Parameters.Add("@amo_disAorticaTipo", OleDbType.Decimal, Nothing)
            inamo_disAorticaTipo.Direction = ParameterDirection.Input
            inamo_disAorticaTipo.Value = Me.FichaMedico.DiseccionAorticaTipo.ID

            Dim inamo_aneAortico As OleDbParameter = cmd.Parameters.Add("@amo_aneAortico", OleDbType.Decimal, Nothing)
            inamo_aneAortico.Direction = ParameterDirection.Input
            inamo_aneAortico.Value = Me.FichaMedico.AneurismaAortico.ID

            Dim inamo_aneAorticoTipo As OleDbParameter = cmd.Parameters.Add("@amo_aneAorticoTipo", OleDbType.Decimal, Nothing)
            inamo_aneAorticoTipo.Direction = ParameterDirection.Input
            inamo_aneAorticoTipo.Value = Me.FichaMedico.AneurismaAorticoTipo.ID

            Dim inamo_tumCardiaco As OleDbParameter = cmd.Parameters.Add("@amo_tumCardiaco", OleDbType.Decimal, Nothing)
            inamo_tumCardiaco.Direction = ParameterDirection.Input
            inamo_tumCardiaco.Value = Me.FichaMedico.TumorCardiaco.ID

            Dim inamo_tumCardiacoTipo As OleDbParameter = cmd.Parameters.Add("@amo_tumCardiacoTipo", OleDbType.Decimal, Nothing)
            inamo_tumCardiacoTipo.Direction = ParameterDirection.Input
            inamo_tumCardiacoTipo.Value = Me.FichaMedico.TumorCardiacoTipo.ID

            Dim inaqc_tiempo As OleDbParameter = cmd.Parameters.Add("@aqc_tiempo", OleDbType.VarChar, 100)
            inaqc_tiempo.Direction = ParameterDirection.Input
            inaqc_tiempo.Value = Me.FichaMedico.Tiempo_ECMO

            Dim inaqc_pueCoronario As OleDbParameter = cmd.Parameters.Add("@aqc_pueCoronario", OleDbType.Decimal, Nothing)
            inaqc_pueCoronario.Direction = ParameterDirection.Input
            inaqc_pueCoronario.Value = Me.FichaMedico.PuenteCoronario.ID

            Dim inaqc_pueCoronarioObs As OleDbParameter = cmd.Parameters.Add("@aqc_pueCoronarioObs", OleDbType.VarChar, 100)
            inaqc_pueCoronarioObs.Direction = ParameterDirection.Input
            inaqc_pueCoronarioObs.Value = Me.FichaMedico.PuenteCoronarioObs

            Dim inaqc_ada As OleDbParameter = cmd.Parameters.Add("@aqc_ada", OleDbType.Decimal, Nothing)
            inaqc_ada.Direction = ParameterDirection.Input
            inaqc_ada.Value = Me.FichaMedico.ADA.ID

            Dim inaqc_adaObs As OleDbParameter = cmd.Parameters.Add("@aqc_adaObs", OleDbType.VarChar, 100)
            inaqc_adaObs.Direction = ParameterDirection.Input
            inaqc_adaObs.Value = Me.FichaMedico.ADAObs

            Dim inaqc_acx As OleDbParameter = cmd.Parameters.Add("@aqc_acx", OleDbType.Decimal, Nothing)
            inaqc_acx.Direction = ParameterDirection.Input
            inaqc_acx.Value = Me.FichaMedico.ACX.ID

            Dim inaqc_acxObs As OleDbParameter = cmd.Parameters.Add("@aqc_acxObs", OleDbType.VarChar, 100)
            inaqc_acxObs.Direction = ParameterDirection.Input
            inaqc_acxObs.Value = Me.FichaMedico.ACXObs

            Dim inaqc_acd As OleDbParameter = cmd.Parameters.Add("@aqc_acd", OleDbType.Decimal, Nothing)
            inaqc_acd.Direction = ParameterDirection.Input
            inaqc_acd.Value = Me.FichaMedico.ACD.ID

            Dim inaqc_acdObs As OleDbParameter = cmd.Parameters.Add("@aqc_acdObs", OleDbType.VarChar, 100)
            inaqc_acdObs.Direction = ParameterDirection.Input
            inaqc_acdObs.Value = Me.FichaMedico.ACDObs

            Dim inaqc_pcFecha As OleDbParameter = cmd.Parameters.Add("@aqc_pcFecha", OleDbType.Date, Nothing)
            inaqc_pcFecha.Direction = ParameterDirection.Input
            inaqc_pcFecha.Value = Me.FichaMedico.PuenteCoronarioFecha

            Dim inaqc_cirValvular As OleDbParameter = cmd.Parameters.Add("@aqc_cirValvular", OleDbType.Decimal, Nothing)
            inaqc_cirValvular.Direction = ParameterDirection.Input
            inaqc_cirValvular.Value = Me.FichaMedico.CirugiaValvular.ID

            Dim inaqc_cirValvularObs As OleDbParameter = cmd.Parameters.Add("@aqc_cirValvularObs", OleDbType.VarChar, 100)
            inaqc_cirValvularObs.Direction = ParameterDirection.Input
            inaqc_cirValvularObs.Value = Me.FichaMedico.CirugiaValvularObs

            Dim inaqc_aortica As OleDbParameter = cmd.Parameters.Add("@aqc_aortica", OleDbType.Decimal, Nothing)
            inaqc_aortica.Direction = ParameterDirection.Input
            inaqc_aortica.Value = Me.FichaMedico.Aortica.ID

            Dim inaqc_aorticaObs As OleDbParameter = cmd.Parameters.Add("@aqc_aorticaObs", OleDbType.VarChar, 100)
            inaqc_aorticaObs.Direction = ParameterDirection.Input
            inaqc_aorticaObs.Value = Me.FichaMedico.AorticaObs

            Dim inaqc_mitral As OleDbParameter = cmd.Parameters.Add("@aqc_mitral", OleDbType.Decimal, Nothing)
            inaqc_mitral.Direction = ParameterDirection.Input
            inaqc_mitral.Value = Me.FichaMedico.Mitral.ID

            Dim inaqc_mitralObs As OleDbParameter = cmd.Parameters.Add("@aqc_mitralObs", OleDbType.VarChar, 100)
            inaqc_mitralObs.Direction = ParameterDirection.Input
            inaqc_mitralObs.Value = Me.FichaMedico.MitralObs

            Dim inaqc_tricuspide As OleDbParameter = cmd.Parameters.Add("@aqc_tricuspide", OleDbType.Decimal, Nothing)
            inaqc_tricuspide.Direction = ParameterDirection.Input
            inaqc_tricuspide.Value = Me.FichaMedico.Tricuspide.ID

            Dim inaqc_tricuspideObs As OleDbParameter = cmd.Parameters.Add("@aqc_tricuspideObs", OleDbType.VarChar, 100)
            inaqc_tricuspideObs.Direction = ParameterDirection.Input
            inaqc_tricuspideObs.Value = Me.FichaMedico.TricuspideObs

            Dim inaqc_cvFecha As OleDbParameter = cmd.Parameters.Add("@aqc_cvFecha", OleDbType.Date, Nothing)
            inaqc_cvFecha.Direction = ParameterDirection.Input
            inaqc_cvFecha.Value = Me.FichaMedico.CirugiaValvularFecha

            Dim inaqc_cieComInteraur As OleDbParameter = cmd.Parameters.Add("@aqc_cieComInteraur", OleDbType.Decimal, Nothing)
            inaqc_cieComInteraur.Direction = ParameterDirection.Input
            inaqc_cieComInteraur.Value = Me.FichaMedico.CierreComInteraricular.ID

            Dim inaqc_cieComInteraurFecha As OleDbParameter = cmd.Parameters.Add("@aqc_cieComInteraurFecha", OleDbType.Date, Nothing)
            inaqc_cieComInteraurFecha.Direction = ParameterDirection.Input
            inaqc_cieComInteraurFecha.Value = Me.FichaMedico.CierreComInteraricularFecha

            Dim inaqc_cieComInterven As OleDbParameter = cmd.Parameters.Add("@aqc_cieComInterven", OleDbType.Decimal, Nothing)
            inaqc_cieComInterven.Direction = ParameterDirection.Input
            inaqc_cieComInterven.Value = Me.FichaMedico.CierreComInterVetricular.ID

            Dim inaqc_cieComIntervenFecha As OleDbParameter = cmd.Parameters.Add("@aqc_cieComIntervenFecha", OleDbType.Date, Nothing)
            inaqc_cieComIntervenFecha.Direction = ParameterDirection.Input
            inaqc_cieComIntervenFecha.Value = Me.FichaMedico.CierreComInterVetricularFecha

            Dim inaqc_cirAorta As OleDbParameter = cmd.Parameters.Add("@aqc_cirAorta", OleDbType.Decimal, Nothing)
            inaqc_cirAorta.Direction = ParameterDirection.Input
            inaqc_cirAorta.Value = Me.FichaMedico.CirugiaAorta.ID

            Dim inaqc_cirAortaFecha As OleDbParameter = cmd.Parameters.Add("@aqc_cirAortaFecha", OleDbType.Date, Nothing)
            inaqc_cirAortaFecha.Direction = ParameterDirection.Input
            inaqc_cirAortaFecha.Value = Me.FichaMedico.CirugiaAortaFecha

            Dim inaqc_cirCarCongenita As OleDbParameter = cmd.Parameters.Add("@aqc_cirCarCongenita", OleDbType.Decimal, Nothing)
            inaqc_cirCarCongenita.Direction = ParameterDirection.Input
            inaqc_cirCarCongenita.Value = Me.FichaMedico.CirugiaCardiopatiaCon.ID

            Dim inaqc_cirCarCongenitaFecha As OleDbParameter = cmd.Parameters.Add("@aqc_cirCarCongenitaFecha", OleDbType.Date, Nothing)
            inaqc_cirCarCongenitaFecha.Direction = ParameterDirection.Input
            inaqc_cirCarCongenitaFecha.Value = Me.FichaMedico.CirugiaCardiopatiaConFecha

            Dim inaqc_reoperacion As OleDbParameter = cmd.Parameters.Add("@aqc_reoperacion", OleDbType.Decimal, Nothing)
            inaqc_reoperacion.Direction = ParameterDirection.Input
            inaqc_reoperacion.Value = Me.FichaMedico.Reoperacion.ID

            Dim inaqc_reoperacionFecha As OleDbParameter = cmd.Parameters.Add("@aqc_reoperacionFecha", OleDbType.Date, Nothing)
            inaqc_reoperacionFecha.Direction = ParameterDirection.Input
            inaqc_reoperacionFecha.Value = Me.FichaMedico.ReoperacionFecha

            Dim inaqc_traCardiaco As OleDbParameter = cmd.Parameters.Add("@aqc_traCardiaco", OleDbType.Decimal, Nothing)
            inaqc_traCardiaco.Direction = ParameterDirection.Input
            inaqc_traCardiaco.Value = Me.FichaMedico.TrasplanteCardiaco.ID

            Dim inaqc_traCardiacoFecha As OleDbParameter = cmd.Parameters.Add("@aqc_traCardiacoFecha", OleDbType.Date, Nothing)
            inaqc_traCardiacoFecha.Direction = ParameterDirection.Input
            inaqc_traCardiacoFecha.Value = Me.FichaMedico.TrasplanteCardiacoFecha

            Dim inaqc_impLvad As OleDbParameter = cmd.Parameters.Add("@aqc_impLvad", OleDbType.Decimal, Nothing)
            inaqc_impLvad.Direction = ParameterDirection.Input
            inaqc_impLvad.Value = Me.FichaMedico.ImplantacionLVAD.ID

            Dim inaqc_impLvadFecha As OleDbParameter = cmd.Parameters.Add("@aqc_impLvadFecha", OleDbType.Date, Nothing)
            inaqc_impLvadFecha.Direction = ParameterDirection.Input
            inaqc_impLvadFecha.Value = Me.FichaMedico.ImplantacionLVADFecha

            Dim inaqc_otraCirugia As OleDbParameter = cmd.Parameters.Add("@aqc_otraCirugia", OleDbType.Decimal, Nothing)
            inaqc_otraCirugia.Direction = ParameterDirection.Input
            inaqc_otraCirugia.Value = Me.FichaMedico.OtraCirugia.ID

            Dim inpc_terAblativaFecha As OleDbParameter = cmd.Parameters.Add("@pc_terAblativaFecha", OleDbType.Date, Nothing)
            inpc_terAblativaFecha.Direction = ParameterDirection.Input
            inpc_terAblativaFecha.Value = Me.FichaMedico.TerapiaAblativaFecha

            Dim inpc_terAblativa As OleDbParameter = cmd.Parameters.Add("@pc_terAblativa", OleDbType.Decimal, Nothing)
            inpc_terAblativa.Direction = ParameterDirection.Input
            inpc_terAblativa.Value = Me.FichaMedico.TerapiaAblativa.ID

            Dim inpc_terAblativaObs As OleDbParameter = cmd.Parameters.Add("@pc_terAblativaObs", OleDbType.VarChar, 100)
            inpc_terAblativaObs.Direction = ParameterDirection.Input
            inpc_terAblativaObs.Value = Me.FichaMedico.TerapiaAblativaObs

            Dim inpc_marcapasoFecha As OleDbParameter = cmd.Parameters.Add("@pc_marcapasoFecha", OleDbType.Date, Nothing)
            inpc_marcapasoFecha.Direction = ParameterDirection.Input
            inpc_marcapasoFecha.Value = Me.FichaMedico.MarcapasoFecha

            Dim inpc_marcapaso As OleDbParameter = cmd.Parameters.Add("@pc_marcapaso", OleDbType.Decimal, Nothing)
            inpc_marcapaso.Direction = ParameterDirection.Input
            inpc_marcapaso.Value = Me.FichaMedico.Marcapaso.ID

            Dim inpc_marcapasoObs As OleDbParameter = cmd.Parameters.Add("@pc_marcapasoObs", OleDbType.VarChar, 100)
            inpc_marcapasoObs.Direction = ParameterDirection.Input
            inpc_marcapasoObs.Value = Me.FichaMedico.MarcapasoObs

            Dim inpc_cdiTrcFecha As OleDbParameter = cmd.Parameters.Add("@pc_cdiTrcFecha", OleDbType.Date, Nothing)
            inpc_cdiTrcFecha.Direction = ParameterDirection.Input
            inpc_cdiTrcFecha.Value = Me.FichaMedico.CDITRCFecha

            Dim inpc_cdiTrc As OleDbParameter = cmd.Parameters.Add("@pc_cdiTrc", OleDbType.Decimal, Nothing)
            inpc_cdiTrc.Direction = ParameterDirection.Input
            inpc_cdiTrc.Value = Me.FichaMedico.CDITRC.ID

            Dim inpc_cdiTrcObs As OleDbParameter = cmd.Parameters.Add("@pc_cdiTrcObs", OleDbType.VarChar, 100)
            inpc_cdiTrcObs.Direction = ParameterDirection.Input
            inpc_cdiTrcObs.Value = Me.FichaMedico.CDITRCObs

            Dim inpc_angioplastiaFecha As OleDbParameter = cmd.Parameters.Add("@pc_angioplastiaFecha", OleDbType.Date, Nothing)
            inpc_angioplastiaFecha.Direction = ParameterDirection.Input
            inpc_angioplastiaFecha.Value = Me.FichaMedico.AngioplastiaFecha

            Dim inpc_angioplastia As OleDbParameter = cmd.Parameters.Add("@pc_angioplastia", OleDbType.Decimal, Nothing)
            inpc_angioplastia.Direction = ParameterDirection.Input
            inpc_angioplastia.Value = Me.FichaMedico.Angioplastia.ID

            Dim inpc_angioplastiaObs As OleDbParameter = cmd.Parameters.Add("@pc_angioplastiaObs", OleDbType.VarChar, 100)
            inpc_angioplastiaObs.Direction = ParameterDirection.Input
            inpc_angioplastiaObs.Value = Me.FichaMedico.AngioplastiaObs

            Dim inpc_balonFecha As OleDbParameter = cmd.Parameters.Add("@pc_balonFecha", OleDbType.Date, Nothing)
            inpc_balonFecha.Direction = ParameterDirection.Input
            inpc_balonFecha.Value = Me.FichaMedico.BalonFecha

            Dim inpc_balon As OleDbParameter = cmd.Parameters.Add("@pc_balon", OleDbType.Decimal, Nothing)
            inpc_balon.Direction = ParameterDirection.Input
            inpc_balon.Value = Me.FichaMedico.Balon.ID

            Dim inpc_balonObs As OleDbParameter = cmd.Parameters.Add("@pc_balonObs", OleDbType.VarChar, 100)
            inpc_balonObs.Direction = ParameterDirection.Input
            inpc_balonObs.Value = Me.FichaMedico.BalonObs

            Dim infm_id_farmacologia As OleDbParameter = cmd.Parameters.Add("@fm_id_farmacologia", OleDbType.Decimal, Nothing)
            infm_id_farmacologia.Direction = ParameterDirection.Input
            infm_id_farmacologia.Value = Me.FichaMedico.Farmacologia.Id

            Dim infm_Alopurinol As OleDbParameter = cmd.Parameters.Add("@fm_Alopurinol", OleDbType.Decimal, Nothing)
            infm_Alopurinol.Direction = ParameterDirection.Input
            infm_Alopurinol.Value = Me.FichaMedico.Farmacologia.Alopurinol.ID

            Dim infm_Antagonista As OleDbParameter = cmd.Parameters.Add("@fm_Antagonista", OleDbType.Decimal, Nothing)
            infm_Antagonista.Direction = ParameterDirection.Input
            infm_Antagonista.Value = Me.FichaMedico.Farmacologia.ARA2.ID

            Dim infm_Antiarritmicos As OleDbParameter = cmd.Parameters.Add("@fm_Antiarritmicos", OleDbType.Decimal, Nothing)
            infm_Antiarritmicos.Direction = ParameterDirection.Input
            infm_Antiarritmicos.Value = Me.FichaMedico.Farmacologia.Antiarritmicos.ID

            Dim infm_AnticoagulanteOral As OleDbParameter = cmd.Parameters.Add("@fm_AnticoagulanteOral", OleDbType.Decimal, Nothing)
            infm_AnticoagulanteOral.Direction = ParameterDirection.Input
            infm_AnticoagulanteOral.Value = Me.FichaMedico.Farmacologia.AnticoagulanteOral.ID

            Dim infm_Antiplaquetario As OleDbParameter = cmd.Parameters.Add("@fm_Antiplaquetario", OleDbType.Decimal, Nothing)
            infm_Antiplaquetario.Direction = ParameterDirection.Input
            infm_Antiplaquetario.Value = Me.FichaMedico.Farmacologia.Antiplaquetario.ID

            Dim infm_Betabloqueador As OleDbParameter = cmd.Parameters.Add("@fm_Betabloqueador", OleDbType.Decimal, Nothing)
            infm_Betabloqueador.Direction = ParameterDirection.Input
            infm_Betabloqueador.Value = Me.FichaMedico.Farmacologia.Betabloqueador.ID

            Dim infm_bloqueadorCorr As OleDbParameter = cmd.Parameters.Add("@fm_bloqueadorCorr", OleDbType.Decimal, Nothing)
            infm_bloqueadorCorr.Direction = ParameterDirection.Input
            infm_bloqueadorCorr.Value = Me.FichaMedico.Farmacologia.BloqueadorCorrientes.ID

            Dim infm_Digitalicos As OleDbParameter = cmd.Parameters.Add("@fm_Digitalicos", OleDbType.Decimal, Nothing)
            infm_Digitalicos.Direction = ParameterDirection.Input
            infm_Digitalicos.Value = Me.FichaMedico.Farmacologia.Digitalicos.ID

            Dim infm_Diuretico As OleDbParameter = cmd.Parameters.Add("@fm_Diuretico", OleDbType.Decimal, Nothing)
            infm_Diuretico.Direction = ParameterDirection.Input
            infm_Diuretico.Value = Me.FichaMedico.Farmacologia.Diuretico.ID

            Dim infm_Estatina As OleDbParameter = cmd.Parameters.Add("@fm_Estatina", OleDbType.Decimal, Nothing)
            infm_Estatina.Direction = ParameterDirection.Input
            infm_Estatina.Value = Me.FichaMedico.Farmacologia.Estatina.ID

            Dim infm_Esteroides As OleDbParameter = cmd.Parameters.Add("@fm_Esteroides", OleDbType.Decimal, Nothing)
            infm_Esteroides.Direction = ParameterDirection.Input
            infm_Esteroides.Value = Me.FichaMedico.Farmacologia.Esteroides.ID

            Dim infm_Hipoglicemiante As OleDbParameter = cmd.Parameters.Add("@fm_Hipoglicemiante", OleDbType.Decimal, Nothing)
            infm_Hipoglicemiante.Direction = ParameterDirection.Input
            infm_Hipoglicemiante.Value = Me.FichaMedico.Farmacologia.Hipoglicemiante.ID

            Dim infm_IECA As OleDbParameter = cmd.Parameters.Add("@fm_IECA", OleDbType.Decimal, Nothing)
            infm_IECA.Direction = ParameterDirection.Input
            infm_IECA.Value = Me.FichaMedico.Farmacologia.IECA.ID

            Dim infm_Nitrato As OleDbParameter = cmd.Parameters.Add("@fm_Nitrato", OleDbType.Decimal, Nothing)
            infm_Nitrato.Direction = ParameterDirection.Input
            infm_Nitrato.Value = Me.FichaMedico.Farmacologia.Nitratos.ID

            Dim infm_Otros As OleDbParameter = cmd.Parameters.Add("@fm_Otros", OleDbType.Decimal, Nothing)
            infm_Otros.Direction = ParameterDirection.Input
            infm_Otros.Value = Me.FichaMedico.Farmacologia.Otros.ID

            Dim inex_id_examenes As OleDbParameter = cmd.Parameters.Add("@ex_id_examenes", OleDbType.Decimal, Nothing)
            inex_id_examenes.Direction = ParameterDirection.Input
            inex_id_examenes.Value = Me.FichaMedico.ExamenMedico.Id

            Dim inex_ada As OleDbParameter = cmd.Parameters.Add("@ex_ada", OleDbType.Decimal, Nothing)
            inex_ada.Direction = ParameterDirection.Input
            inex_ada.Value = Me.FichaMedico.ExamenMedico.LesionAda.ID

            Dim inex_adaObs As OleDbParameter = cmd.Parameters.Add("@ex_adaObs", OleDbType.VarChar, 100)
            inex_adaObs.Direction = ParameterDirection.Input
            inex_adaObs.Value = Me.FichaMedico.ExamenMedico.LesionAdaObs

            Dim inex_acd As OleDbParameter = cmd.Parameters.Add("@ex_acd", OleDbType.Decimal, Nothing)
            inex_acd.Direction = ParameterDirection.Input
            inex_acd.Value = Me.FichaMedico.ExamenMedico.LesionACD.ID

            Dim inex_acdObs As OleDbParameter = cmd.Parameters.Add("@ex_acdObs", OleDbType.VarChar, 100)
            inex_acdObs.Direction = ParameterDirection.Input
            inex_acdObs.Value = Me.FichaMedico.ExamenMedico.LesionACDObs

            Dim inex_acx As OleDbParameter = cmd.Parameters.Add("@ex_acx", OleDbType.Decimal, Nothing)
            inex_acx.Direction = ParameterDirection.Input
            inex_acx.Value = Me.FichaMedico.ExamenMedico.LesionACX.ID

            Dim inex_acxObs As OleDbParameter = cmd.Parameters.Add("@ex_acxObs", OleDbType.VarChar, 100)
            inex_acxObs.Direction = ParameterDirection.Input
            inex_acxObs.Value = Me.FichaMedico.ExamenMedico.LesionACXObs

            Dim inex_troCoronario As OleDbParameter = cmd.Parameters.Add("@ex_troCoronario", OleDbType.Decimal, Nothing)
            inex_troCoronario.Direction = ParameterDirection.Input
            inex_troCoronario.Value = Me.FichaMedico.ExamenMedico.TroncoCoronario.ID

            Dim inex_troCoronarioObs As OleDbParameter = cmd.Parameters.Add("@ex_troCoronarioObs", OleDbType.VarChar, 100)
            inex_troCoronarioObs.Direction = ParameterDirection.Input
            inex_troCoronarioObs.Value = Me.FichaMedico.ExamenMedico.TroncoCoronarioObs

            Dim inex_pap As OleDbParameter = cmd.Parameters.Add("@ex_pap", OleDbType.Decimal, Nothing)
            inex_pap.Direction = ParameterDirection.Input
            inex_pap.Value = Me.FichaMedico.ExamenMedico.PapMedia.ID

            Dim inex_papObs As OleDbParameter = cmd.Parameters.Add("@ex_papObs", OleDbType.VarChar, 100)
            inex_papObs.Direction = ParameterDirection.Input
            inex_papObs.Value = Me.FichaMedico.ExamenMedico.PapMediaObs

            Dim inex_wood As OleDbParameter = cmd.Parameters.Add("@ex_wood", OleDbType.Decimal, Nothing)
            inex_wood.Direction = ParameterDirection.Input
            inex_wood.Value = Me.FichaMedico.ExamenMedico.Uwood.ID

            Dim inex_woodObs As OleDbParameter = cmd.Parameters.Add("@ex_woodObs", OleDbType.VarChar, 100)
            inex_woodObs.Direction = ParameterDirection.Input
            inex_woodObs.Value = Me.FichaMedico.ExamenMedico.UwoodObs

            Dim inex_testReversibilidad As OleDbParameter = cmd.Parameters.Add("@ex_testReversibilidad", OleDbType.Decimal, Nothing)
            inex_testReversibilidad.Direction = ParameterDirection.Input
            inex_testReversibilidad.Value = Me.FichaMedico.ExamenMedico.TestReversibilidad.ID

            Dim inex_testReversibilidadObs As OleDbParameter = cmd.Parameters.Add("@ex_testReversibilidadObs", OleDbType.VarChar, 100)
            inex_testReversibilidadObs.Direction = ParameterDirection.Input
            inex_testReversibilidadObs.Value = Me.FichaMedico.ExamenMedico.TestReversibilidadObs

            Dim inex_fevi As OleDbParameter = cmd.Parameters.Add("@ex_fevi", OleDbType.Decimal, Nothing)
            inex_fevi.Direction = ParameterDirection.Input
            inex_fevi.Value = Me.FichaMedico.ExamenMedico.FEVI.ID

            Dim inex_diaSistole As OleDbParameter = cmd.Parameters.Add("@ex_diaSistole", OleDbType.VarChar, 100)
            inex_diaSistole.Direction = ParameterDirection.Input
            inex_diaSistole.Value = Me.FichaMedico.ExamenMedico.DiametroSistole

            Dim inex_diaDiastole As OleDbParameter = cmd.Parameters.Add("@ex_diaDiastole", OleDbType.VarChar, 100)
            inex_diaDiastole.Direction = ParameterDirection.Input
            inex_diaDiastole.Value = Me.FichaMedico.ExamenMedico.DiametroDiastole

            Dim inex_dilAurIzq As OleDbParameter = cmd.Parameters.Add("@ex_dilAurIzq", OleDbType.Decimal, Nothing)
            inex_dilAurIzq.Direction = ParameterDirection.Input
            inex_dilAurIzq.Value = Me.FichaMedico.ExamenMedico.DilatacionAuricular.ID

            Dim inex_dilAurIzqTipo As OleDbParameter = cmd.Parameters.Add("@ex_dilAurIzqTipo", OleDbType.Decimal, Nothing)
            inex_dilAurIzqTipo.Direction = ParameterDirection.Input
            inex_dilAurIzqTipo.Value = Me.FichaMedico.ExamenMedico.DilatacionAuricularTipo.ID

            Dim inex_hipPulmonar As OleDbParameter = cmd.Parameters.Add("@ex_hipPulmonar", OleDbType.Decimal, Nothing)
            inex_hipPulmonar.Direction = ParameterDirection.Input
            inex_hipPulmonar.Value = Me.FichaMedico.ExamenMedico.HipertensionPulmonar.ID

            Dim inex_hipPulmonarTipo As OleDbParameter = cmd.Parameters.Add("@ex_hipPulmonarTipo", OleDbType.Decimal, Nothing)
            inex_hipPulmonarTipo.Direction = ParameterDirection.Input
            inex_hipPulmonarTipo.Value = Me.FichaMedico.ExamenMedico.HipertensionPulmonarTipo.ID

            Dim inex_disVenDer As OleDbParameter = cmd.Parameters.Add("@ex_disVenDer", OleDbType.Decimal, Nothing)
            inex_disVenDer.Direction = ParameterDirection.Input
            inex_disVenDer.Value = Me.FichaMedico.ExamenMedico.DisfuncionVentriculo.ID

            Dim inex_disVenDerTipo As OleDbParameter = cmd.Parameters.Add("@ex_disVenDerTipo", OleDbType.Decimal, Nothing)
            inex_disVenDerTipo.Direction = ParameterDirection.Input
            inex_disVenDerTipo.Value = Me.FichaMedico.ExamenMedico.DisfuncionVentriculoTipo.ID

            Dim inex_estAortica As OleDbParameter = cmd.Parameters.Add("@ex_estAortica", OleDbType.Decimal, Nothing)
            inex_estAortica.Direction = ParameterDirection.Input
            inex_estAortica.Value = Me.FichaMedico.ExamenMedico.EstenosisAortica.ID

            Dim inex_estAorticaTipo As OleDbParameter = cmd.Parameters.Add("@ex_estAorticaTipo", OleDbType.Decimal, Nothing)
            inex_estAorticaTipo.Direction = ParameterDirection.Input
            inex_estAorticaTipo.Value = Me.FichaMedico.ExamenMedico.EstenosisAorticaTipo.ID

            Dim inex_estMitral As OleDbParameter = cmd.Parameters.Add("@ex_estMitral", OleDbType.Decimal, Nothing)
            inex_estMitral.Direction = ParameterDirection.Input
            inex_estMitral.Value = Me.FichaMedico.ExamenMedico.EstenosisMitral.ID

            Dim inex_estMitralTipo As OleDbParameter = cmd.Parameters.Add("@ex_estMitralTipo", OleDbType.Decimal, Nothing)
            inex_estMitralTipo.Direction = ParameterDirection.Input
            inex_estMitralTipo.Value = Me.FichaMedico.ExamenMedico.EstenosisMitralTipo.ID

            Dim inex_insAortica As OleDbParameter = cmd.Parameters.Add("@ex_insAortica", OleDbType.Decimal, Nothing)
            inex_insAortica.Direction = ParameterDirection.Input
            inex_insAortica.Value = Me.FichaMedico.ExamenMedico.InsuficienciaAortica.ID

            Dim inex_insAorticaTipo As OleDbParameter = cmd.Parameters.Add("@ex_insAorticaTipo", OleDbType.Decimal, Nothing)
            inex_insAorticaTipo.Direction = ParameterDirection.Input
            inex_insAorticaTipo.Value = Me.FichaMedico.ExamenMedico.InsuficienciaAorticaTipo.ID

            Dim inex_insMitral As OleDbParameter = cmd.Parameters.Add("@ex_insMitral", OleDbType.Decimal, Nothing)
            inex_insMitral.Direction = ParameterDirection.Input
            inex_insMitral.Value = Me.FichaMedico.ExamenMedico.InsuficienciaMitral.ID

            Dim inex_insMitralTipo As OleDbParameter = cmd.Parameters.Add("@ex_insMitralTipo", OleDbType.Decimal, Nothing)
            inex_insMitralTipo.Direction = ParameterDirection.Input
            inex_insMitralTipo.Value = Me.FichaMedico.ExamenMedico.InsuficienciaMitralTipo.ID

            Dim inex_aquinesia As OleDbParameter = cmd.Parameters.Add("@ex_aquinesia", OleDbType.Decimal, Nothing)
            inex_aquinesia.Direction = ParameterDirection.Input
            inex_aquinesia.Value = Me.FichaMedico.ExamenMedico.Aquinesia.ID

            Dim inex_aquinesiaTipo As OleDbParameter = cmd.Parameters.Add("@ex_aquinesiaTipo", OleDbType.Decimal, Nothing)
            inex_aquinesiaTipo.Direction = ParameterDirection.Input
            inex_aquinesiaTipo.Value = Me.FichaMedico.ExamenMedico.AquinesiaTipo.ID

            Dim inex_arritmia As OleDbParameter = cmd.Parameters.Add("@ex_arritmia", OleDbType.Decimal, Nothing)
            inex_arritmia.Direction = ParameterDirection.Input
            inex_arritmia.Value = Me.FichaMedico.ExamenMedico.Arrtimias.ID

            Dim inex_arritmiaObs As OleDbParameter = cmd.Parameters.Add("@ex_arritmiaObs", OleDbType.VarChar, 100)
            inex_arritmiaObs.Direction = ParameterDirection.Input
            inex_arritmiaObs.Value = Me.FichaMedico.ExamenMedico.ArrtimiasObs

            Dim inex_bloqueoAv As OleDbParameter = cmd.Parameters.Add("@ex_bloqueoAv", OleDbType.Decimal, Nothing)
            inex_bloqueoAv.Direction = ParameterDirection.Input
            inex_bloqueoAv.Value = Me.FichaMedico.ExamenMedico.BloqueosAV.ID

            Dim inex_bloqueoAvObss As OleDbParameter = cmd.Parameters.Add("@ex_bloqueoAvObs", OleDbType.VarChar, 100)
            inex_bloqueoAvObss.Direction = ParameterDirection.Input
            inex_bloqueoAvObss.Value = Me.FichaMedico.ExamenMedico.BloqueosAVObs

            Dim inex_ejeCardiaco As OleDbParameter = cmd.Parameters.Add("@ex_ejeCardiaco", OleDbType.Decimal, Nothing)
            inex_ejeCardiaco.Direction = ParameterDirection.Input
            inex_ejeCardiaco.Value = Me.FichaMedico.ExamenMedico.EjeCardiaco.ID

            Dim inex_ejeCardiacoObs As OleDbParameter = cmd.Parameters.Add("@ex_ejeCardiacoObs", OleDbType.VarChar, 100)
            inex_ejeCardiacoObs.Direction = ParameterDirection.Input
            inex_ejeCardiacoObs.Value = Me.FichaMedico.ExamenMedico.EjeCardiacoObs

            Dim inex_otros As OleDbParameter = cmd.Parameters.Add("@ex_otros", OleDbType.VarChar, 100)
            inex_otros.Direction = ParameterDirection.Input
            inex_otros.Value = Me.FichaMedico.ExamenMedico.Otro

            Dim inex_proBnp As OleDbParameter = cmd.Parameters.Add("@ex_proBnp", OleDbType.VarChar, 100)
            inex_proBnp.Direction = ParameterDirection.Input
            inex_proBnp.Value = Me.FichaMedico.ExamenMedico.ProBNP

            Dim inex_proBnpFecha As OleDbParameter = cmd.Parameters.Add("@ex_proBnpFecha", OleDbType.Date, Nothing)
            inex_proBnpFecha.Direction = ParameterDirection.Input
            inex_proBnpFecha.Value = Me.FichaMedico.ExamenMedico.ProBNPFecha

            Dim inex_troponina As OleDbParameter = cmd.Parameters.Add("@ex_troponina", OleDbType.VarChar, 100)
            inex_troponina.Direction = ParameterDirection.Input
            inex_troponina.Value = Me.FichaMedico.ExamenMedico.Troponina

            Dim inex_troponinaFecha As OleDbParameter = cmd.Parameters.Add("@ex_troponinaFecha", OleDbType.Date, Nothing)
            inex_troponinaFecha.Direction = ParameterDirection.Input
            inex_troponinaFecha.Value = Me.FichaMedico.ExamenMedico.TroponinaFecha

            Dim inex_pcr As OleDbParameter = cmd.Parameters.Add("@ex_pcr", OleDbType.VarChar, 100)
            inex_pcr.Direction = ParameterDirection.Input
            inex_pcr.Value = Me.FichaMedico.ExamenMedico.PCR

            Dim inex_pcrFecha As OleDbParameter = cmd.Parameters.Add("@ex_pcrFecha", OleDbType.Date, Nothing)
            inex_pcrFecha.Direction = ParameterDirection.Input
            inex_pcrFecha.Value = Me.FichaMedico.ExamenMedico.PCRFecha

            Dim inex_dimeroD As OleDbParameter = cmd.Parameters.Add("@ex_dimeroD", OleDbType.VarChar, 100)
            inex_dimeroD.Direction = ParameterDirection.Input
            inex_dimeroD.Value = Me.FichaMedico.ExamenMedico.DimeroD

            Dim inex_dimeroDFecha As OleDbParameter = cmd.Parameters.Add("@ex_dimeroDFecha", OleDbType.Date, Nothing)
            inex_dimeroDFecha.Direction = ParameterDirection.Input
            inex_dimeroDFecha.Value = Me.FichaMedico.ExamenMedico.DimeroDFecha

            Dim inex_sodio As OleDbParameter = cmd.Parameters.Add("@ex_sodio", OleDbType.VarChar, 100)
            inex_sodio.Direction = ParameterDirection.Input
            inex_sodio.Value = Me.FichaMedico.ExamenMedico.Sodio

            Dim inex_sodioFecha As OleDbParameter = cmd.Parameters.Add("@ex_sodioFecha", OleDbType.Date, Nothing)
            inex_sodioFecha.Direction = ParameterDirection.Input
            inex_sodioFecha.Value = Me.FichaMedico.ExamenMedico.SodioFecha

            Dim inex_potasio As OleDbParameter = cmd.Parameters.Add("@ex_potasio", OleDbType.VarChar, 100)
            inex_potasio.Direction = ParameterDirection.Input
            inex_potasio.Value = Me.FichaMedico.ExamenMedico.Potasio

            Dim inex_potasioFecha As OleDbParameter = cmd.Parameters.Add("@ex_potasioFecha", OleDbType.Date, Nothing)
            inex_potasioFecha.Direction = ParameterDirection.Input
            inex_potasioFecha.Value = Me.FichaMedico.ExamenMedico.PotasioFecha

            Dim inex_creaKinasa As OleDbParameter = cmd.Parameters.Add("@ex_creaKinasa", OleDbType.VarChar, 100)
            inex_creaKinasa.Direction = ParameterDirection.Input
            inex_creaKinasa.Value = Me.FichaMedico.ExamenMedico.CreatinaKinasa

            Dim inex_creaKinasaFecha As OleDbParameter = cmd.Parameters.Add("@ex_creaKinasaFecha", OleDbType.Date, Nothing)
            inex_creaKinasaFecha.Direction = ParameterDirection.Input
            inex_creaKinasaFecha.Value = Me.FichaMedico.ExamenMedico.CreatinaKinasaFecha

            Dim inex_ckmb As OleDbParameter = cmd.Parameters.Add("@ex_ckmb", OleDbType.VarChar, 100)
            inex_ckmb.Direction = ParameterDirection.Input
            inex_ckmb.Value = Me.FichaMedico.ExamenMedico.CKMB

            Dim inex_ckmbFecha As OleDbParameter = cmd.Parameters.Add("@ex_ckmbFecha", OleDbType.Date, Nothing)
            inex_ckmbFecha.Direction = ParameterDirection.Input
            inex_ckmbFecha.Value = Me.FichaMedico.ExamenMedico.CKMBFecha

            Dim inex_aciUrico As OleDbParameter = cmd.Parameters.Add("@ex_aciUrico", OleDbType.VarChar, 100)
            inex_aciUrico.Direction = ParameterDirection.Input
            inex_aciUrico.Value = Me.FichaMedico.ExamenMedico.AcidoUrico

            Dim inex_aciUricoFecha As OleDbParameter = cmd.Parameters.Add("@ex_aciUricoFecha", OleDbType.Date, Nothing)
            inex_aciUricoFecha.Direction = ParameterDirection.Input
            inex_aciUricoFecha.Value = Me.FichaMedico.ExamenMedico.AcidoUricoFecha

            Dim inid_examen_fisico As OleDbParameter = cmd.Parameters.Add("@id_examen_fisico", OleDbType.Decimal, Nothing)
            inid_examen_fisico.Direction = ParameterDirection.Input
            inid_examen_fisico.Value = Me.FichaMedico.ExamenFisico.Id

            Dim insignos As OleDbParameter = cmd.Parameters.Add("@signos", OleDbType.VarChar, 500)
            insignos.Direction = ParameterDirection.Input
            insignos.Value = Me.FichaMedico.ExamenFisico.Signos

            Dim incuello As OleDbParameter = cmd.Parameters.Add("@cuello", OleDbType.VarChar, 500)
            incuello.Direction = ParameterDirection.Input
            incuello.Value = Me.FichaMedico.ExamenFisico.Cuello

            Dim incardiaco As OleDbParameter = cmd.Parameters.Add("@cardiaco", OleDbType.VarChar, 500)
            incardiaco.Direction = ParameterDirection.Input
            incardiaco.Value = Me.FichaMedico.ExamenFisico.Cardiaco

            Dim inpulmon As OleDbParameter = cmd.Parameters.Add("@pulmon", OleDbType.VarChar, 500)
            inpulmon.Direction = ParameterDirection.Input
            inpulmon.Value = Me.FichaMedico.ExamenFisico.Pulmon

            Dim intorax As OleDbParameter = cmd.Parameters.Add("@torax", OleDbType.VarChar, 500)
            intorax.Direction = ParameterDirection.Input
            intorax.Value = Me.FichaMedico.ExamenFisico.Torax

            Dim inabdomen As OleDbParameter = cmd.Parameters.Add("@abdomen", OleDbType.VarChar, 500)
            inabdomen.Direction = ParameterDirection.Input
            inabdomen.Value = Me.FichaMedico.ExamenFisico.Abdomen

            Dim ineeii As OleDbParameter = cmd.Parameters.Add("@eeii", OleDbType.VarChar, 500)
            ineeii.Direction = ParameterDirection.Input
            ineeii.Value = Me.FichaMedico.ExamenFisico.EEII

            Dim ineess As OleDbParameter = cmd.Parameters.Add("@eess", OleDbType.VarChar, 500)
            ineess.Direction = ParameterDirection.Input
            ineess.Value = Me.FichaMedico.ExamenFisico.EESS

            Dim indiagnostico As OleDbParameter = cmd.Parameters.Add("@diagnostico", OleDbType.VarChar, 500)
            indiagnostico.Direction = ParameterDirection.Input
            indiagnostico.Value = Me.FichaMedico.ExamenFisico.Diagnostico

            Dim inplanMedico As OleDbParameter = cmd.Parameters.Add("@planMedico", OleDbType.VarChar, 500)
            inplanMedico.Direction = ParameterDirection.Input
            inplanMedico.Value = Me.FichaMedico.ExamenFisico.Plan

            Dim inhisFamCardiopatia As OleDbParameter = cmd.Parameters.Add("@hisFamCardiopatia", OleDbType.VarChar, -1)
            inhisFamCardiopatia.Direction = ParameterDirection.Input
            inhisFamCardiopatia.Value = Me.FichaMedico.ToJSONHistoriaCardiopatia(Me.FichaMedico.ListHistoriaCardiopatia)

            Dim inhisFamCronica As OleDbParameter = cmd.Parameters.Add("@hisFamCronica", OleDbType.VarChar, -1)
            inhisFamCronica.Direction = ParameterDirection.Input
            inhisFamCronica.Value = Me.FichaMedico.ToJSONHistoriaCronica(Me.FichaMedico.ListHistoriaCronica)

            Dim inotrasCirugias As OleDbParameter = cmd.Parameters.Add("@otrasCirugias", OleDbType.VarChar, -1)
            inotrasCirugias.Direction = ParameterDirection.Input
            inotrasCirugias.Value = Me.FichaMedico.ToJSONOtraCirugia(Me.FichaMedico.ListOtraCirugia)

            Dim inAlopurinol As OleDbParameter = cmd.Parameters.Add("@Alopurinol", OleDbType.VarChar, -1)
            inAlopurinol.Direction = ParameterDirection.Input
            inAlopurinol.Value = Me.FichaMedico.Farmacologia.ToJSONAlopurinol(Me.FichaMedico.Farmacologia.ListAlopurinol)

            Dim inAntagonista As OleDbParameter = cmd.Parameters.Add("@Antagonista", OleDbType.VarChar, -1)
            inAntagonista.Direction = ParameterDirection.Input
            inAntagonista.Value = Me.FichaMedico.Farmacologia.ToJSONARA2(Me.FichaMedico.Farmacologia.ListARA2)

            Dim inAntiarritmicos As OleDbParameter = cmd.Parameters.Add("@Antiarritmicos", OleDbType.VarChar, -1)
            inAntiarritmicos.Direction = ParameterDirection.Input
            inAntiarritmicos.Value = Me.FichaMedico.Farmacologia.ToJSONAntiarritmicos(Me.FichaMedico.Farmacologia.ListAntiarritmicos)

            Dim inAnticoagulanteOral As OleDbParameter = cmd.Parameters.Add("@AnticoagulanteOral", OleDbType.VarChar, -1)
            inAnticoagulanteOral.Direction = ParameterDirection.Input
            inAnticoagulanteOral.Value = Me.FichaMedico.Farmacologia.ToJSONAnticoagulanteOral(Me.FichaMedico.Farmacologia.ListAnticoagulanteOral)

            Dim inAntiplaquetario As OleDbParameter = cmd.Parameters.Add("@Antiplaquetario", OleDbType.VarChar, -1)
            inAntiplaquetario.Direction = ParameterDirection.Input
            inAntiplaquetario.Value = Me.FichaMedico.Farmacologia.ToJSONAntiplaquetario(Me.FichaMedico.Farmacologia.ListAntiplaquetario)

            Dim inBetabloqueador As OleDbParameter = cmd.Parameters.Add("@Betabloqueador", OleDbType.VarChar, -1)
            inBetabloqueador.Direction = ParameterDirection.Input
            inBetabloqueador.Value = Me.FichaMedico.Farmacologia.ToJSONBetabloqueador(Me.FichaMedico.Farmacologia.ListBetabloqueador)

            Dim inbloqueadorCorr As OleDbParameter = cmd.Parameters.Add("@bloqueadorCorr", OleDbType.VarChar, -1)
            inbloqueadorCorr.Direction = ParameterDirection.Input
            inbloqueadorCorr.Value = Me.FichaMedico.Farmacologia.ToJSONBloqueadorCorrientes(Me.FichaMedico.Farmacologia.ListBloqueadorCorrientes)

            Dim inDigitalicos As OleDbParameter = cmd.Parameters.Add("@Digitalicos", OleDbType.VarChar, -1)
            inDigitalicos.Direction = ParameterDirection.Input
            inDigitalicos.Value = Me.FichaMedico.Farmacologia.ToJSONDigitalicos(Me.FichaMedico.Farmacologia.ListDigitalicos)

            Dim inDiuretico As OleDbParameter = cmd.Parameters.Add("@Diuretico", OleDbType.VarChar, -1)
            inDiuretico.Direction = ParameterDirection.Input
            inDiuretico.Value = Me.FichaMedico.Farmacologia.ToJSONDiuretico(Me.FichaMedico.Farmacologia.ListDiuretico)

            Dim inEstatina As OleDbParameter = cmd.Parameters.Add("@Estatina", OleDbType.VarChar, -1)
            inEstatina.Direction = ParameterDirection.Input
            inEstatina.Value = Me.FichaMedico.Farmacologia.ToJSONEstatina(Me.FichaMedico.Farmacologia.ListEstatina)

            Dim inEsteroides As OleDbParameter = cmd.Parameters.Add("@Esteroides", OleDbType.VarChar, -1)
            inEsteroides.Direction = ParameterDirection.Input
            inEsteroides.Value = Me.FichaMedico.Farmacologia.ToJSONEsteroides(Me.FichaMedico.Farmacologia.ListEsteroides)

            Dim inHipoglicemiante As OleDbParameter = cmd.Parameters.Add("@Hipoglicemiante", OleDbType.VarChar, -1)
            inHipoglicemiante.Direction = ParameterDirection.Input
            inHipoglicemiante.Value = Me.FichaMedico.Farmacologia.ToJSONHipoglicemiante(Me.FichaMedico.Farmacologia.ListHipoglicemiante)

            Dim inIECA As OleDbParameter = cmd.Parameters.Add("@IECA", OleDbType.VarChar, -1)
            inIECA.Direction = ParameterDirection.Input
            inIECA.Value = Me.FichaMedico.Farmacologia.ToJSONIECA(Me.FichaMedico.Farmacologia.ListIECA)

            Dim inNitrato As OleDbParameter = cmd.Parameters.Add("@Nitrato", OleDbType.VarChar, -1)
            inNitrato.Direction = ParameterDirection.Input
            inNitrato.Value = Me.FichaMedico.Farmacologia.ToJSONNitratos(Me.FichaMedico.Farmacologia.ListNitratos)

            Dim inOtros As OleDbParameter = cmd.Parameters.Add("@Otros", OleDbType.VarChar, -1)
            inOtros.Direction = ParameterDirection.Input
            inOtros.Value = Me.FichaMedico.Farmacologia.ToJSONOtros(Me.FichaMedico.Farmacologia.ListOtros)

            Dim outError As OleDbParameter = cmd.Parameters.Add("@outError", OleDbType.Integer)
            outError.Direction = ParameterDirection.Output

            Dim outIdMed As OleDbParameter = cmd.Parameters.Add("@outIdMed", OleDbType.Integer)
            outIdMed.Direction = ParameterDirection.Output

            conn.Open()
            cmd.ExecuteReader()
            conn.Close()

            Dim idEnfer = CInt(cmd.Parameters("@outIdMed").Value)

            Return CInt(cmd.Parameters("@outError").Value)

        End Function
#End Region
    End Class
End Namespace


