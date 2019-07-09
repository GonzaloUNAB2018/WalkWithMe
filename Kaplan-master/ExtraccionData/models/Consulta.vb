Imports System.Data.OleDb

Namespace Clases
    Public Class Consulta
        Public Property id_paciente As Integer
        Public Property numero_ficha As Integer
        Public Property sexo As String
        Public Property situacion_laboral As String
        Public Property peso_actual As String
        Public Property talla As String
        Public Property masa_grasa_corporal As String
        Public Property masa_magra As String
        Public Property indice_cintura As String
        Public Property MNA As String
        Public Property peso_habitual As String
        Public Property masa_magra_porc As String
        Public Property grasa_viceral As String
        Public Property porc_cintura As String
        Public Property cribaje As String
        Public Property apetito As String
        Public Property alergia_alimentaria As String
        Public Property preferencia_alimentaria As String
        Public Property intolerancia_alimentaria As String
        Public Property aversaciones_alimentaria As String
        Public Property consumo_suplemento As String
        Public Property hora_desayuno As String
        Public Property gramaje_desayuno As String
        Public Property hora_colacion As String
        Public Property gramaje_colacion As String
        Public Property hora_almuerzo As String
        Public Property gramaje_almuerzo As String
        Public Property hora_picoteo As String
        Public Property gramaje_picoteo As String
        Public Property hora_once As String
        Public Property gramaje_once As String
        Public Property hora_cena As String
        Public Property gramaje_cena As String
        Public Property hora_snack As String
        Public Property gramaje_snack As String
        Public Property ingesta_ali_observacion As String
        Public Property diagnostico_nutricional_observacion As String
        Public Property geb As String
        Public Property energia As String
        Public Property FA As String
        Public Property proteina As String
        Public Property lipidos As String
        Public Property aporte_alimentacion_KCAL As String
        Public Property aporte_alimentacion_cho As String
        Public Property aporte_alimentacion_lip As String
        Public Property aporte_alimentacion_prot As String
        Public Property prescripcion_dietetica As String
        Public Property indicaciones_generales As String
        Public Property diagnostico_nutricional_integrado As String
        Public Property objetivo_alimentario As String
        Public Property intervencion_nutricional As String
        Public Property consumo_fruta As String
        Public Property consumo_verdura As String
        Public Property consumo_lacteos As String
        Public Property consumo_carne As String
        Public Property consumo_grasas_azucar As String
        Public Property consumo_legumbre As String
        Public Property consumo_pescado As String
        Public Property consumo_sodio As String
        Public Property consumo_liquido As String
        Public Property sintomatologia_prevalente As String
        Public Property derivacion_aps As String
        Public Property apoyo_social_significativo As String
        Public Property problemas_sociales As String
        Public Property personalidad_tipo_a As String
        Public Property trastorno_mental_diagnosticado As String
        Public Property trauma_post_operativo As String
        Public Property conciencia_factor_riesgo As String
        Public Property dificultades_respuesta_estres As String
        Public Property ingreso_taller As String
        Public Property tratamiento As String
        Public Property observacion As String
        Public Property funcion_fisica_ingreso As String
        Public Property funcion_fisica_egreso As String
        Public Property rol_fisico_ingreso As String
        Public Property rol_fisico_egreso As String
        Public Property dolor_corporal_ingreso As String
        Public Property dolor_corporal_egreso As String
        Public Property salud_general_ingreso As String
        Public Property salud_general_egreso As String
        Public Property vitalidad_ingreso As String
        Public Property vitalidad_egreso As String
        Public Property funcion_social_ingreso As String
        Public Property funcion_social_egreso As String
        Public Property rol_emocional_ingreso As String
        Public Property rol_emocional_egreso As String
        Public Property salud_mental_ingreso As String
        Public Property salud_mental_egreso As String
        Public Property observacion_sf36 As String
        Public Property ansiedad_ingreso As String
        Public Property ansiedad_egreso As String
        Public Property depresion_ingreso As String
        Public Property depresion_egreso As String
        Public Property subescala_a_ingreso As String
        Public Property subescala_a_egreso As String
        Public Property subescala_b_ingreso As String
        Public Property subescala_b_egreso As String
        Public Property observacion_escala_ansiedad As String
        Public Property antecedentes_plan_psico As String
        Public Property objetivos_plan_psico As String
        Public Property diagnosticos_plan_psico As String
        Public Property intervencion_plan_psico As String
        Public Property evaluacion_plan_psico As String
        Public Property evolucion_plan_psico As String
        Public Property ergo_fecha_ingreso As String
        Public Property ergo_fecha_egreso As String
        Public Property ergo_VO2L_ingreso As String
        Public Property ergo_VO2L_egreso As String
        Public Property ergo_VO2ML_ingreso As String
        Public Property ergo_VO2ML_egreso As String
        Public Property ergo_FCMAX_ingreso As String
        Public Property ergo_FCMAX_egreso As String
        Public Property ergo_pulso_ingreso As String
        Public Property ergo_pulso_egreso As String
        Public Property ergo_VE_ingreso As String
        Public Property ergo_VE_egreso As String
        Public Property ergo_METS_ingreso As String
        Public Property ergo_METS_egreso As String
        Public Property shuttle_fecha_ingreso As String
        Public Property shuttle_fecha_egreso As String
        Public Property shuttle_metros_ingreso As String
        Public Property shuttle_metros_egreso As String
        Public Property shuttle_nivelCOMP_ingreso As String
        Public Property shuttle_nivelCOMP_egreso As String
        Public Property shuttle_VO2ML_ingreso As String
        Public Property shuttle_VO2ML_egreso As String
        Public Property shuttle_METS_ingreso As String
        Public Property shuttle_METS_egreso As String
        Public Property shuttle_FCMAX_ingreso As String
        Public Property shuttle_FCMAX_egreso As String
        Public Property shuttle_FCMT_ingreso As String
        Public Property shuttle_FCMT_egreso As String
        Public Property shuttle_METSMAX_ingreso As String
        Public Property shuttle_METSMAX_egreso As String
        Public Property fecha_evolucion_ingreso As String
        Public Property musculo_esqueletica_evolucion_ingreso As String
        Public Property observacion_evolucion_ingreso As String
        Public Property fecha_evolucion_egreso As String
        Public Property musculo_esqueletica_evolucion_egreso As String
        Public Property observacion_evolucion_egreso As String
        Public Property ejercicio_aerobico As String
        Public Property ejercicio_sobrecarga As String
        Public Property entrenamiento_funcional As String
        Public Property habitos_cardio As String
        Public Property idDiagnosticoKinesico As String
        Public Property DiagnosticoKinesico As String
        Public Property idObjetivoKinesico As String
        Public Property ObjetivoKinesico As String
        Public Property diagnostico_medico As String
        Public Property CX_PROCED As String
        Public Property diagnostico_medico_fecha As String
        Public Property CX_PROCED_fecha As String
        Public Property fecha_alta As String
        Public Property controles As String
        Public Property procedencia As String
        Public Property tipo_evaluacion As String
        Public Property herida_cx As String
        Public Property intervencion As String
        Public Property HTA As String
        Public Property DM As String
        Public Property DLP As String
        Public Property SED As String
        Public Property SP_OB As String
        Public Property TB As String
        Public Property OH As String
        Public Property AF As String
        Public Property Estres As String
        Public Property idMedicamento As String
        Public Property Medicamento As String
        Public Property antecedentes_relevantes_anamnesis As String
        Public Property patron_respiratorio_anamnesis As String
        Public Property regimen_hiposodico_anamnesis As String
        Public Property fruta_verdura_anamnesis As String
        Public Property agua_anamnesis As String
        Public Property bebida_nec_anamnesis As String
        Public Property grasas_anamnesis As String
        Public Property diuresis_anamnesis As String
        Public Property deposicion_anamnesis As String
        Public Property tb_anamnesis As String
        Public Property tb_a_anamnesis As String
        Public Property EA_anamnesis As String
        Public Property sueno_nocturno_anamnesis As String
        Public Property sueno_a_nocturno_anamnesis As String
        Public Property sueno_b_nocturno_anamnesis As String
        Public Property motivacion_anamnesis As String
        Public Property AVD_anamnesis As String
        Public Property actividades_recreativas_anamnesis As String
        Public Property cabeza_examen_fisico As String
        Public Property cuello_examen_fisico As String
        Public Property torax_examen_fisico As String
        Public Property torax_a_examen_fisico As String
        Public Property torax_b_examen_fisico As String
        Public Property torax_c_examen_fisico As String
        Public Property abdomen_examen_fisico As String
        Public Property abdomen_a_examen_fisico As String
        Public Property EESS_examen_fisico As String
        Public Property llen_cap_examen_fisico As String
        Public Property EEII_examen_fisico As String
        Public Property PA_examen_fisico As String
        Public Property fc_examen_fisico As String
        Public Property sat_examen_fisico As String
        Public Property glicemia_examen_fisico As String
        Public Property adherencia_farma_valoracion As String
        Public Property respiracion_valoracion As String
        Public Property respiracion_obs_valoracion As String
        Public Property alimentacion_valoracion As String
        Public Property alimentacion_obs_valoracion As String
        Public Property eliminacion_valoracion As String
        Public Property eliminacion_obs_valoracion As String
        Public Property descanso_valoracion As String
        Public Property descanso_obs_valoracion As String
        Public Property higiene_valoracion As String
        Public Property higiene_obs_valoracion As String
        Public Property actividades_valoracion As String
        Public Property actividades_obs_valoracion As String
        Public Property vestirse_valoracion As String
        Public Property vestirse_obs_valoracion As String
        Public Property comunicarse_valoracion As String
        Public Property comunicarse_obs_valoracion As String
        Public Property auto_realizacion_valoracion As String
        Public Property auto_realizacion_obs_valoracion As String
        Public Property objetivo_plan_enfermeria As String
        Public Property iddiagnostico_plan_enfermeria As String
        Public Property diagnostico_plan_enfermeria As String
        Public Property idintervencion_plan_enfermeria As String
        Public Property intervencion_plan_enfermeria As String
        Public Shared Function getListado() As List(Of Consulta)
            Try
                Dim conn As OleDbConnection = New OleDbConnection(ConfigurationManager.ConnectionStrings("ConexionKaplan").ConnectionString)
                Dim cmd As OleDbCommand = New OleDbCommand("Kaplan.ExportarData", conn)
                cmd.CommandType = CommandType.StoredProcedure

                conn.Open()
                Dim adapter As OleDbDataAdapter = New OleDbDataAdapter(cmd)
                Dim vDataTable As New DataTable
                adapter.Fill(vDataTable)
                getListado = New List(Of Consulta)
                For Each vRow As DataRow In vDataTable.Rows
                    getListado.Add(Mapeo(vRow))
                Next
                conn.Close()
                Return getListado
            Catch exc As Exception
                Return Nothing
            End Try

        End Function

        Private Shared Function Mapeo(prmRow As DataRow) As Consulta
            Try
                Dim vClass As New Consulta
                vClass.id_paciente = prmRow("id_paciente").ToString
                vClass.numero_ficha = prmRow("numero_ficha").ToString
                vClass.sexo = prmRow("sexo").ToString
                vClass.situacion_laboral = prmRow("situacion_laboral").ToString
                vClass.peso_actual = prmRow("peso_actual").ToString
                vClass.talla = prmRow("talla").ToString
                vClass.masa_grasa_corporal = prmRow("masa_grasa_corporal").ToString
                vClass.masa_magra = prmRow("masa_magra").ToString
                vClass.indice_cintura = prmRow("indice_cintura").ToString
                vClass.MNA = prmRow("MNA").ToString
                vClass.peso_habitual = prmRow("peso_habitual").ToString
                vClass.masa_magra_porc = prmRow("masa_magra_porc").ToString
                vClass.grasa_viceral = prmRow("grasa_viceral").ToString
                vClass.porc_cintura = prmRow("porc_cintura").ToString
                vClass.cribaje = prmRow("cribaje").ToString
                vClass.apetito = prmRow("apetito").ToString
                vClass.alergia_alimentaria = prmRow("alergia_alimentaria").ToString
                vClass.preferencia_alimentaria = prmRow("preferencia_alimentaria").ToString
                vClass.intolerancia_alimentaria = prmRow("intolerancia_alimentaria").ToString
                vClass.aversaciones_alimentaria = prmRow("aversaciones_alimentaria").ToString
                vClass.consumo_suplemento = prmRow("consumo_suplemento").ToString
                vClass.hora_desayuno = prmRow("hora_desayuno").ToString
                vClass.gramaje_desayuno = prmRow("gramaje_desayuno").ToString
                vClass.hora_colacion = prmRow("hora_colacion").ToString
                vClass.gramaje_colacion = prmRow("gramaje_colacion").ToString
                vClass.hora_almuerzo = prmRow("hora_almuerzo").ToString
                vClass.gramaje_almuerzo = prmRow("gramaje_almuerzo").ToString
                vClass.hora_picoteo = prmRow("hora_picoteo").ToString
                vClass.gramaje_picoteo = prmRow("gramaje_picoteo").ToString
                vClass.hora_once = prmRow("hora_once").ToString
                vClass.gramaje_once = prmRow("gramaje_once").ToString
                vClass.hora_cena = prmRow("hora_cena").ToString
                vClass.gramaje_cena = prmRow("gramaje_cena").ToString
                vClass.hora_snack = prmRow("hora_snack").ToString
                vClass.gramaje_snack = prmRow("gramaje_snack").ToString
                vClass.ingesta_ali_observacion = prmRow("ingesta_ali_observacion").ToString
                vClass.diagnostico_nutricional_observacion = prmRow("diagnostico_nutricional_observacion").ToString
                vClass.geb = prmRow("geb").ToString
                vClass.energia = prmRow("energia").ToString
                vClass.FA = prmRow("FA").ToString
                vClass.proteina = prmRow("proteina").ToString
                vClass.lipidos = prmRow("lipidos").ToString
                vClass.aporte_alimentacion_KCAL = prmRow("aporte_alimentacion_KCAL").ToString
                vClass.aporte_alimentacion_cho = prmRow("aporte_alimentacion_cho").ToString
                vClass.aporte_alimentacion_lip = prmRow("aporte_alimentacion_lip").ToString
                vClass.aporte_alimentacion_prot = prmRow("aporte_alimentacion_prot").ToString
                vClass.prescripcion_dietetica = prmRow("prescripcion_dietetica").ToString
                vClass.indicaciones_generales = prmRow("indicaciones_generales").ToString
                vClass.diagnostico_nutricional_integrado = prmRow("diagnostico_nutricional_integrado").ToString
                vClass.objetivo_alimentario = prmRow("objetivo_alimentario").ToString
                vClass.intervencion_nutricional = prmRow("intervencion_nutricional").ToString
                vClass.consumo_fruta = prmRow("consumo_fruta").ToString
                vClass.consumo_verdura = prmRow("consumo_verdura").ToString
                vClass.consumo_lacteos = prmRow("consumo_lacteos").ToString
                vClass.consumo_carne = prmRow("consumo_carne").ToString
                vClass.consumo_grasas_azucar = prmRow("consumo_grasas_azucar").ToString
                vClass.consumo_legumbre = prmRow("consumo_legumbre").ToString
                vClass.consumo_pescado = prmRow("consumo_pescado").ToString
                vClass.consumo_sodio = prmRow("consumo_sodio").ToString
                vClass.consumo_liquido = prmRow("consumo_liquido").ToString
                vClass.sintomatologia_prevalente = prmRow("sintomatologia_prevalente").ToString
                vClass.derivacion_aps = prmRow("derivacion_aps").ToString
                vClass.apoyo_social_significativo = prmRow("apoyo_social_significativo").ToString
                vClass.problemas_sociales = prmRow("problemas_sociales").ToString
                vClass.personalidad_tipo_a = prmRow("personalidad_tipo_a").ToString
                vClass.trastorno_mental_diagnosticado = prmRow("trastorno_mental_diagnosticado").ToString
                vClass.trauma_post_operativo = prmRow("trauma_post_operativo").ToString
                vClass.conciencia_factor_riesgo = prmRow("conciencia_factor_riesgo").ToString
                vClass.dificultades_respuesta_estres = prmRow("dificultades_respuesta_estres").ToString
                vClass.ingreso_taller = prmRow("ingreso_taller").ToString
                vClass.tratamiento = prmRow("tratamiento").ToString
                vClass.observacion = prmRow("observacion").ToString
                vClass.funcion_fisica_ingreso = prmRow("funcion_fisica_ingreso").ToString
                vClass.funcion_fisica_egreso = prmRow("funcion_fisica_egreso").ToString
                vClass.rol_fisico_ingreso = prmRow("rol_fisico_ingreso").ToString
                vClass.rol_fisico_egreso = prmRow("rol_fisico_egreso").ToString
                vClass.dolor_corporal_ingreso = prmRow("dolor_corporal_ingreso").ToString
                vClass.dolor_corporal_egreso = prmRow("dolor_corporal_egreso").ToString
                vClass.salud_general_ingreso = prmRow("salud_general_ingreso").ToString
                vClass.salud_general_egreso = prmRow("salud_general_egreso").ToString
                vClass.vitalidad_ingreso = prmRow("vitalidad_ingreso").ToString
                vClass.vitalidad_egreso = prmRow("vitalidad_egreso").ToString
                vClass.funcion_social_ingreso = prmRow("funcion_social_ingreso").ToString
                vClass.funcion_social_egreso = prmRow("funcion_social_egreso").ToString
                vClass.rol_emocional_ingreso = prmRow("rol_emocional_ingreso").ToString
                vClass.rol_emocional_egreso = prmRow("rol_emocional_egreso").ToString
                vClass.salud_mental_ingreso = prmRow("salud_mental_ingreso").ToString
                vClass.salud_mental_egreso = prmRow("salud_mental_egreso").ToString
                vClass.observacion_sf36 = prmRow("observacion_sf36").ToString
                vClass.ansiedad_ingreso = prmRow("ansiedad_ingreso").ToString
                vClass.ansiedad_egreso = prmRow("ansiedad_egreso").ToString
                vClass.depresion_ingreso = prmRow("depresion_ingreso").ToString
                vClass.depresion_egreso = prmRow("depresion_egreso").ToString
                vClass.subescala_a_ingreso = prmRow("subescala_a_ingreso").ToString
                vClass.subescala_a_egreso = prmRow("subescala_a_egreso").ToString
                vClass.subescala_b_ingreso = prmRow("subescala_b_ingreso").ToString
                vClass.subescala_b_egreso = prmRow("subescala_b_egreso").ToString
                vClass.observacion_escala_ansiedad = prmRow("observacion_escala_ansiedad").ToString
                vClass.antecedentes_plan_psico = prmRow("antecedentes_plan_psico").ToString
                vClass.objetivos_plan_psico = prmRow("objetivos_plan_psico").ToString
                vClass.diagnosticos_plan_psico = prmRow("diagnosticos_plan_psico").ToString
                vClass.intervencion_plan_psico = prmRow("intervencion_plan_psico").ToString
                vClass.evaluacion_plan_psico = prmRow("evaluacion_plan_psico").ToString
                vClass.evolucion_plan_psico = prmRow("evolucion_plan_psico").ToString
                vClass.ergo_fecha_ingreso = prmRow("ergo_fecha_ingreso").ToString
                vClass.ergo_fecha_egreso = prmRow("ergo_fecha_egreso").ToString
                vClass.ergo_VO2L_ingreso = prmRow("ergo_VO2L_ingreso").ToString
                vClass.ergo_VO2L_egreso = prmRow("ergo_VO2L_egreso").ToString
                vClass.ergo_VO2ML_ingreso = prmRow("ergo_VO2ML_ingreso").ToString
                vClass.ergo_VO2ML_egreso = prmRow("ergo_VO2ML_egreso").ToString
                vClass.ergo_FCMAX_ingreso = prmRow("ergo_FCMAX_ingreso").ToString
                vClass.ergo_FCMAX_egreso = prmRow("ergo_FCMAX_egreso").ToString
                vClass.ergo_pulso_ingreso = prmRow("ergo_pulso_ingreso").ToString
                vClass.ergo_pulso_egreso = prmRow("ergo_pulso_egreso").ToString
                vClass.ergo_VE_ingreso = prmRow("ergo_VE_ingreso").ToString
                vClass.ergo_VE_egreso = prmRow("ergo_VE_egreso").ToString
                vClass.ergo_METS_ingreso = prmRow("ergo_METS_ingreso").ToString
                vClass.ergo_METS_egreso = prmRow("ergo_METS_egreso").ToString
                vClass.shuttle_fecha_ingreso = prmRow("shuttle_fecha_ingreso").ToString
                vClass.shuttle_fecha_egreso = prmRow("shuttle_fecha_egreso").ToString
                vClass.shuttle_metros_ingreso = prmRow("shuttle_metros_ingreso").ToString
                vClass.shuttle_metros_egreso = prmRow("shuttle_metros_egreso").ToString
                vClass.shuttle_nivelCOMP_ingreso = prmRow("shuttle_nivelCOMP_ingreso").ToString
                vClass.shuttle_nivelCOMP_egreso = prmRow("shuttle_nivelCOMP_egreso").ToString
                vClass.shuttle_VO2ML_ingreso = prmRow("shuttle_VO2ML_ingreso").ToString
                vClass.shuttle_VO2ML_egreso = prmRow("shuttle_VO2ML_egreso").ToString
                vClass.shuttle_METS_ingreso = prmRow("shuttle_METS_ingreso").ToString
                vClass.shuttle_METS_egreso = prmRow("shuttle_METS_egreso").ToString
                vClass.shuttle_FCMAX_ingreso = prmRow("shuttle_FCMAX_ingreso").ToString
                vClass.shuttle_FCMAX_egreso = prmRow("shuttle_FCMAX_egreso").ToString
                vClass.shuttle_FCMT_ingreso = prmRow("shuttle_FCMT_ingreso").ToString
                vClass.shuttle_FCMT_egreso = prmRow("shuttle_FCMT_egreso").ToString
                vClass.shuttle_METSMAX_ingreso = prmRow("shuttle_METSMAX_ingreso").ToString
                vClass.shuttle_METSMAX_egreso = prmRow("shuttle_METSMAX_egreso").ToString
                vClass.fecha_evolucion_ingreso = prmRow("fecha_evolucion_ingreso").ToString
                vClass.musculo_esqueletica_evolucion_ingreso = prmRow("musculo_esqueletica_evolucion_ingreso").ToString
                vClass.observacion_evolucion_ingreso = prmRow("observacion_evolucion_ingreso").ToString
                vClass.fecha_evolucion_egreso = prmRow("fecha_evolucion_egreso").ToString
                vClass.musculo_esqueletica_evolucion_egreso = prmRow("musculo_esqueletica_evolucion_egreso").ToString
                vClass.observacion_evolucion_egreso = prmRow("observacion_evolucion_egreso").ToString
                vClass.ejercicio_aerobico = prmRow("ejercicio_aerobico").ToString
                vClass.ejercicio_sobrecarga = prmRow("ejercicio_sobrecarga").ToString
                vClass.entrenamiento_funcional = prmRow("entrenamiento_funcional").ToString
                vClass.habitos_cardio = prmRow("habitos_cardio").ToString
                vClass.idDiagnosticoKinesico = prmRow("idDiagnosticoKinesico").ToString
                vClass.DiagnosticoKinesico = prmRow("DiagnosticoKinesico").ToString
                vClass.idObjetivoKinesico = prmRow("idObjetivoKinesico").ToString
                vClass.ObjetivoKinesico = prmRow("ObjetivoKinesico").ToString
                vClass.diagnostico_medico = prmRow("diagnostico_medico").ToString
                vClass.CX_PROCED = prmRow("CX_PROCED").ToString
                vClass.diagnostico_medico_fecha = prmRow("diagnostico_medico_fecha").ToString
                vClass.CX_PROCED_fecha = prmRow("CX_PROCED_fecha").ToString
                vClass.fecha_alta = prmRow("fecha_alta").ToString
                vClass.controles = prmRow("controles").ToString
                vClass.procedencia = prmRow("procedencia").ToString
                vClass.tipo_evaluacion = prmRow("tipo_evaluacion").ToString
                vClass.herida_cx = prmRow("herida_cx").ToString
                vClass.intervencion = prmRow("intervencion").ToString
                vClass.HTA = prmRow("HTA").ToString
                vClass.DM = prmRow("DM").ToString
                vClass.DLP = prmRow("DLP").ToString
                vClass.SED = prmRow("SED").ToString
                vClass.SP_OB = prmRow("SP_OB").ToString
                vClass.TB = prmRow("TB").ToString
                vClass.OH = prmRow("OH").ToString
                vClass.AF = prmRow("AF").ToString
                vClass.Estres = prmRow("Estres").ToString
                vClass.idMedicamento = prmRow("idMedicamento").ToString
                vClass.Medicamento = prmRow("Medicamento").ToString
                vClass.antecedentes_relevantes_anamnesis = prmRow("antecedentes_relevantes_anamnesis").ToString
                vClass.patron_respiratorio_anamnesis = prmRow("patron_respiratorio_anamnesis").ToString
                vClass.regimen_hiposodico_anamnesis = prmRow("regimen_hiposodico_anamnesis").ToString
                vClass.fruta_verdura_anamnesis = prmRow("fruta_verdura_anamnesis").ToString
                vClass.agua_anamnesis = prmRow("agua_anamnesis").ToString
                vClass.bebida_nec_anamnesis = prmRow("bebida_nec_anamnesis").ToString
                vClass.grasas_anamnesis = prmRow("grasas_anamnesis").ToString
                vClass.diuresis_anamnesis = prmRow("diuresis_anamnesis").ToString
                vClass.deposicion_anamnesis = prmRow("deposicion_anamnesis").ToString
                vClass.tb_anamnesis = prmRow("tb_anamnesis").ToString
                vClass.tb_a_anamnesis = prmRow("tb_a_anamnesis").ToString
                vClass.EA_anamnesis = prmRow("EA_anamnesis").ToString
                vClass.sueno_nocturno_anamnesis = prmRow("sueno_nocturno_anamnesis").ToString
                vClass.sueno_a_nocturno_anamnesis = prmRow("sueno_a_nocturno_anamnesis").ToString
                vClass.sueno_b_nocturno_anamnesis = prmRow("sueno_b_nocturno_anamnesis").ToString
                vClass.motivacion_anamnesis = prmRow("motivacion_anamnesis").ToString
                vClass.AVD_anamnesis = prmRow("AVD_anamnesis").ToString
                vClass.actividades_recreativas_anamnesis = prmRow("actividades_recreativas_anamnesis").ToString
                vClass.cabeza_examen_fisico = prmRow("cabeza_examen_fisico").ToString
                vClass.cuello_examen_fisico = prmRow("cuello_examen_fisico").ToString
                vClass.torax_examen_fisico = prmRow("torax_examen_fisico").ToString
                vClass.torax_a_examen_fisico = prmRow("torax_a_examen_fisico").ToString
                vClass.torax_b_examen_fisico = prmRow("torax_b_examen_fisico").ToString
                vClass.torax_c_examen_fisico = prmRow("torax_c_examen_fisico").ToString
                vClass.abdomen_examen_fisico = prmRow("abdomen_examen_fisico").ToString
                vClass.abdomen_a_examen_fisico = prmRow("abdomen_a_examen_fisico").ToString
                vClass.EESS_examen_fisico = prmRow("EESS_examen_fisico").ToString
                vClass.llen_cap_examen_fisico = prmRow("llen_cap_examen_fisico").ToString
                vClass.EEII_examen_fisico = prmRow("EEII_examen_fisico").ToString
                vClass.PA_examen_fisico = prmRow("PA_examen_fisico").ToString
                vClass.fc_examen_fisico = prmRow("fc_examen_fisico").ToString
                vClass.sat_examen_fisico = prmRow("sat_examen_fisico").ToString
                vClass.glicemia_examen_fisico = prmRow("glicemia_examen_fisico").ToString
                vClass.adherencia_farma_valoracion = prmRow("adherencia_farma_valoracion").ToString
                vClass.respiracion_valoracion = prmRow("respiracion_valoracion").ToString
                vClass.respiracion_obs_valoracion = prmRow("respiracion_obs_valoracion").ToString
                vClass.alimentacion_valoracion = prmRow("alimentacion_valoracion").ToString
                vClass.alimentacion_obs_valoracion = prmRow("alimentacion_obs_valoracion").ToString
                vClass.eliminacion_valoracion = prmRow("eliminacion_valoracion").ToString
                vClass.eliminacion_obs_valoracion = prmRow("eliminacion_obs_valoracion").ToString
                vClass.descanso_valoracion = prmRow("descanso_valoracion").ToString
                vClass.descanso_obs_valoracion = prmRow("descanso_obs_valoracion").ToString
                vClass.higiene_valoracion = prmRow("higiene_valoracion").ToString
                vClass.higiene_obs_valoracion = prmRow("higiene_obs_valoracion").ToString
                vClass.actividades_valoracion = prmRow("actividades_valoracion").ToString
                vClass.actividades_obs_valoracion = prmRow("actividades_obs_valoracion").ToString
                vClass.vestirse_valoracion = prmRow("vestirse_valoracion").ToString
                vClass.vestirse_obs_valoracion = prmRow("vestirse_obs_valoracion").ToString
                vClass.comunicarse_valoracion = prmRow("comunicarse_valoracion").ToString
                vClass.comunicarse_obs_valoracion = prmRow("comunicarse_obs_valoracion").ToString
                vClass.auto_realizacion_valoracion = prmRow("auto_realizacion_valoracion").ToString
                vClass.auto_realizacion_obs_valoracion = prmRow("auto_realizacion_obs_valoracion").ToString
                vClass.objetivo_plan_enfermeria = prmRow("objetivo_plan_enfermeria").ToString
                vClass.iddiagnostico_plan_enfermeria = prmRow("iddiagnostico_plan_enfermeria").ToString
                vClass.diagnostico_plan_enfermeria = prmRow("diagnostico_plan_enfermeria").ToString
                vClass.idintervencion_plan_enfermeria = prmRow("idintervencion_plan_enfermeria").ToString
                vClass.intervencion_plan_enfermeria = prmRow("intervencion_plan_enfermeria").ToString

                Return vClass

            Catch ex As Exception
                Return Nothing
            End Try
        End Function
    End Class
End Namespace

