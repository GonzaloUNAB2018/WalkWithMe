Imports Newtonsoft.Json
Namespace Clases
    Public Class CollectionssHistoriaCardiopatia
        Public Property column As HistoriaCardiopatia()
    End Class
    Public Class CollectionssHistoriaCronica
        Public Property column As HistoriaCronica()
    End Class
    Public Class CollectionssOtraCirugia
        Public Property column As OtraCirugia()
    End Class
    Public Class FichaMedico
        Public Property Id As Integer
        Public Property IdReserva As Integer
        Public Property IdEspecialista As Integer
        Public Property CentroDerivacion As String
        Public Property MedicoDerivador As String
        Public Property MotivoDerivacion As String
        Public Property FechaAlta As Date
        Public Property NumeroHospitalizaciones As Integer
        Public Property HistoriaCardiopatia As Tipos.TipoRespuestaMedico
        Public Property ListHistoriaCardiopatia As List(Of HistoriaCardiopatia)
        Public Property HistoriaCronica As Tipos.TipoRespuestaMedico
        Public Property ListHistoriaCronica As List(Of HistoriaCronica)
        Public Property IndiceMasaCoporal As Double
        Public Property PerimetroCintura As Double
        Public Property RelacionCinturaCadera As Double
        Public Property PorcentajeGrasa As Double
        Public Property Tabaquismo As Double
        Public Property IPA As String
        Public Property TabaquismoActivo As Tipos.TipoRespuestaMedico
        Public Property Alcohol As Tipos.TipoRespuestaMedico
        Public Property ActividadFisica As Double
        Public Property AbusoDrogas As Tipos.TipoRespuestaMedico
        Public Property AbusoDrogasDetalle As String
        Public Property Dislipidemias As Tipos.TipoRespuestaMedico
        Public Property DislipidemiasObs As String
        Public Property HipertensionArterial As Tipos.TipoRespuestaMedico
        Public Property HipertensionArterialObs As String
        Public Property DiabetesMellitus As Tipos.TipoRespuestaMedico
        Public Property Insulinoterapia As Tipos.TipoRespuestaMedico
        Public Property InsulinoterapiaDosis As String
        Public Property Alergias As Tipos.TipoRespuestaMedico
        Public Property AlergiasObs As String
        Public Property EnfermedadRenalCronica As Tipos.TipoRespuestaMedico
        Public Property Etapa As String
        Public Property Proteinurea As Tipos.TipoRespuestaMedico
        Public Property Hemodialisis As Tipos.TipoRespuestaMedico
        Public Property Anemia As Tipos.TipoRespuestaMedico
        Public Property Hemoglobina As String
        Public Property Ferritina As String
        Public Property Albumina As String
        Public Property Linfocitos As String
        Public Property EnfermedadPulmonar As Tipos.TipoRespuestaMedico
        Public Property EnfermedadPulmonarObs As String
        Public Property SeveridadFuncionPulmonar As Tipos.TipoSeveridadMedico
        Public Property EnfermedadHepatica As Tipos.TipoRespuestaMedico
        Public Property EnfermedadHepaticaObs As String
        Public Property EnfermedadArterialPeriferica As Tipos.TipoRespuestaMedico
        Public Property EnfermedadArterialPerifericaObs As String
        Public Property CirugiaPeriferica As Tipos.TipoRespuestaMedico
        Public Property CirugiaPerifericaObs As String
        Public Property EnfermedadCerebroVascular As Tipos.TipoRespuestaMedico
        Public Property EnfermedadCerebroVascularObs As String
        Public Property Secuelas As String
        Public Property CirugiaCarotidea As Tipos.TipoRespuestaMedico
        Public Property CirugiaCarotideaObs As String
        Public Property Inmunosupresion As Tipos.TipoRespuestaMedico
        Public Property InmunosupresionObs As String
        Public Property HistoriaOncologica As Tipos.TipoRespuestaMedico
        Public Property HistoriaOncologicaObs As String
        Public Property Localizacion As String
        Public Property Quimioterapia As Tipos.TipoRespuestaMedico
        Public Property QuimioterapiaObs As String
        Public Property Radioterapia As Tipos.TipoRespuestaMedico
        Public Property RadioterapiaObs As String
        Public Property ApneaSueno As Tipos.TipoRespuestaMedico
        Public Property ApneaSuenoObs As String
        Public Property EnfermedadCardiaca As String
        Public Property CardiopatiaCongenita As Tipos.TipoRespuestaMedico
        Public Property CardiopatiaCongenitaObs As String
        Public Property InfartoAgudoMiocardio As Tipos.TipoRespuestaMedico
        Public Property InfartoAgudoMiocardioObs As String
        Public Property InfartoAgudoMiocardioFecha As Date
        Public Property InsuficienciaCardiaca As Tipos.TipoRespuestaMedico
        Public Property InsuficienciaCardiacaFecha As Date
        Public Property InsuficienciaCardiacaNYHA As String
        Public Property SincopeCardiogenico As Tipos.TipoRespuestaMedico
        Public Property SincopeCardiogenicoObs As String
        Public Property ShockCardiogenico As Tipos.TipoRespuestaMedico
        Public Property ShockCardiogenicoObs As String
        Public Property ShockCardiogenicoFecha As Date
        Public Property ParoCardiorRespiratorio As Tipos.TipoRespuestaMedico
        Public Property ParoCardiorRespiratorioObs As String
        Public Property ParoCardiorRespiratorioFecha As Date
        Public Property Supraventricular As Tipos.TipoRespuestaMedico
        Public Property SupraventricularObs As String
        Public Property Ventricular As Tipos.TipoRespuestaMedico
        Public Property VentricularObs As String
        Public Property Endocarditis As Tipos.TipoRespuestaMedico
        Public Property EndocarditisObs As String
        Public Property DiseccionAortica As Tipos.TipoRespuestaMedico
        Public Property DiseccionAorticaTipo As Tipos.TipoDiseccionMedico
        Public Property AneurismaAortico As Tipos.TipoRespuestaMedico
        Public Property AneurismaAorticoTipo As Tipos.TipoAneurismaMedico
        Public Property TumorCardiaco As Tipos.TipoRespuestaMedico
        Public Property TumorCardiacoTipo As Tipos.TipoTumorMedico
        Public Property Tiempo_ECMO As String
        Public Property PuenteCoronario As Tipos.TipoRespuestaMedico
        Public Property PuenteCoronarioObs As String
        Public Property ADA As Tipos.TipoRespuestaMedico
        Public Property ADAObs As String
        Public Property ACX As Tipos.TipoRespuestaMedico
        Public Property ACXObs As String
        Public Property ACD As Tipos.TipoRespuestaMedico
        Public Property ACDObs As String
        Public Property PuenteCoronarioFecha As Date
        Public Property CirugiaValvular As Tipos.TipoRespuestaMedico
        Public Property CirugiaValvularObs As String
        Public Property Aortica As Tipos.TipoRespuestaMedico
        Public Property AorticaObs As String
        Public Property Mitral As Tipos.TipoRespuestaMedico
        Public Property MitralObs As String
        Public Property Tricuspide As Tipos.TipoRespuestaMedico
        Public Property TricuspideObs As String
        Public Property CirugiaValvularFecha As Date
        Public Property CierreComInteraricular As Tipos.TipoRespuestaMedico
        Public Property CierreComInteraricularFecha As Date
        Public Property CierreComInterVetricular As Tipos.TipoRespuestaMedico
        Public Property CierreComInterVetricularFecha As Date
        Public Property CirugiaAorta As Tipos.TipoRespuestaMedico
        Public Property CirugiaAortaFecha As Date
        Public Property CirugiaCardiopatiaCon As Tipos.TipoRespuestaMedico
        Public Property CirugiaCardiopatiaConFecha As Date
        Public Property Reoperacion As Tipos.TipoRespuestaMedico
        Public Property ReoperacionFecha As Date
        Public Property TrasplanteCardiaco As Tipos.TipoRespuestaMedico
        Public Property TrasplanteCardiacoFecha As Date
        Public Property ImplantacionLVAD As Tipos.TipoRespuestaMedico
        Public Property ImplantacionLVADFecha As Date
        Public Property OtraCirugia As Tipos.TipoRespuestaMedico
        Public Property ListOtraCirugia As List(Of OtraCirugia)
        Public Property TerapiaAblativa As Tipos.TipoRespuestaMedico
        Public Property TerapiaAblativaObs As String
        Public Property TerapiaAblativaFecha As Date
        Public Property Marcapaso As Tipos.TipoRespuestaMedico
        Public Property MarcapasoObs As String
        Public Property MarcapasoFecha As Date
        Public Property CDITRC As Tipos.TipoRespuestaMedico
        Public Property CDITRCObs As String
        Public Property CDITRCFecha As Date
        Public Property Angioplastia As Tipos.TipoRespuestaMedico
        Public Property AngioplastiaObs As String
        Public Property AngioplastiaFecha As Date
        Public Property Balon As Tipos.TipoRespuestaMedico
        Public Property BalonObs As String
        Public Property BalonFecha As Date
        Public Property Farmacologia As Farmacologia
        Public Property ExamenMedico As ExamenMedico
        Public Property ExamenFisico As ExamenFisico
        Public Shared Function MapeoFichaMedico(prmDatos As DataTable) As FichaMedico
            Try
                Dim vMedico As New FichaMedico

                Dim prmRow As DataRow = prmDatos.Rows(0)

                vMedico.Id = prmRow("id_ficha_med").ToString
                vMedico.IdReserva = prmRow("id_reserva").ToString
                vMedico.CentroDerivacion = prmRow("ho_centrov").ToString
                vMedico.MedicoDerivador = prmRow("ho_medico").ToString
                vMedico.MotivoDerivacion = prmRow("ho_motivo").ToString
                vMedico.FechaAlta = prmRow("ho_fechaAlta").ToString
                vMedico.NumeroHospitalizaciones = prmRow("ho_nroHosp").ToString
                vMedico.HistoriaCardiopatia = Tipos.TipoRespuestaMedico.getTipo(prmRow("ame_HistFamCardiopatia"))
                vMedico.HistoriaCronica = Tipos.TipoRespuestaMedico.getTipo(prmRow("ame_HistFamCronica"))
                vMedico.IndiceMasaCoporal = Double.Parse(prmRow("ame_imc"))
                vMedico.PerimetroCintura = Double.Parse(prmRow("ame_perCint"))
                vMedico.RelacionCinturaCadera = Double.Parse(prmRow("ame_relCint"))
                vMedico.PorcentajeGrasa = Double.Parse(prmRow("ame_porGra"))
                vMedico.Tabaquismo = Double.Parse(prmRow("ame_tab"))
                vMedico.IPA = prmRow("ame_tabObs").ToString
                vMedico.TabaquismoActivo = Tipos.TipoRespuestaMedico.getTipo(prmRow("ame_tabAct"))
                vMedico.Alcohol = Tipos.TipoRespuestaMedico.getTipo(prmRow("ame_alc"))
                vMedico.ActividadFisica = Double.Parse(prmRow("ame_actFis"))
                vMedico.AbusoDrogas = Tipos.TipoRespuestaMedico.getTipo(prmRow("ame_dro"))
                vMedico.AbusoDrogasDetalle = prmRow("ame_droObs").ToString
                vMedico.Dislipidemias = Tipos.TipoRespuestaMedico.getTipo(prmRow("amo_dislipidemias"))
                vMedico.DislipidemiasObs = prmRow("amo_dislipidemiasObs").ToString
                vMedico.HipertensionArterial = Tipos.TipoRespuestaMedico.getTipo(prmRow("amo_hipertension"))
                vMedico.HipertensionArterialObs = prmRow("amo_hipertensionObs").ToString
                vMedico.DiabetesMellitus = Tipos.TipoRespuestaMedico.getTipo(prmRow("amo_diabetes"))
                vMedico.Insulinoterapia = Tipos.TipoRespuestaMedico.getTipo(prmRow("amo_insulinoterapia"))
                vMedico.InsulinoterapiaDosis = prmRow("amo_insulinoterapiaObs").ToString
                vMedico.Alergias = Tipos.TipoRespuestaMedico.getTipo(prmRow("amo_alergias"))
                vMedico.AlergiasObs = prmRow("amo_alergiasObs").ToString
                vMedico.EnfermedadRenalCronica = Tipos.TipoRespuestaMedico.getTipo(prmRow("amo_enfRenalCronica"))
                vMedico.Etapa = prmRow("amo_etapa").ToString
                vMedico.Proteinurea = Tipos.TipoRespuestaMedico.getTipo(prmRow("amo_proteinurea"))
                vMedico.Hemodialisis = Tipos.TipoRespuestaMedico.getTipo(prmRow("amo_hemodialisis"))
                vMedico.Anemia = Tipos.TipoRespuestaMedico.getTipo(prmRow("amo_anemia"))
                vMedico.Hemoglobina = prmRow("amo_aneHemoglobian").ToString
                vMedico.Ferritina = prmRow("amo_aneFerritina").ToString
                vMedico.Albumina = prmRow("amo_desAlbumina").ToString
                vMedico.Linfocitos = prmRow("amo_desLinfocitos").ToString
                vMedico.EnfermedadPulmonar = Tipos.TipoRespuestaMedico.getTipo(prmRow("amo_enfPulmonar"))
                vMedico.EnfermedadPulmonarObs = prmRow("amo_enfPulmonarObs").ToString
                vMedico.SeveridadFuncionPulmonar = Tipos.TipoSeveridadMedico.getTipo(prmRow("amo_enfSevFunPul"))
                vMedico.EnfermedadHepatica = Tipos.TipoRespuestaMedico.getTipo(prmRow("amo_enfHepatica"))
                vMedico.EnfermedadHepaticaObs = prmRow("amo_enfHepaticaObs").ToString
                vMedico.EnfermedadArterialPeriferica = Tipos.TipoRespuestaMedico.getTipo(prmRow("amo_enfArtPeriferica"))
                vMedico.EnfermedadArterialPerifericaObs = prmRow("amo_enfArtPerifericaObs").ToString
                vMedico.CirugiaPeriferica = Tipos.TipoRespuestaMedico.getTipo(prmRow("amo_cirRevPeriferica"))
                vMedico.CirugiaPerifericaObs = prmRow("amo_cirRevPerifericaObs").ToString
                vMedico.EnfermedadCerebroVascular = Tipos.TipoRespuestaMedico.getTipo(prmRow("amo_enfCerVascular"))
                vMedico.EnfermedadCerebroVascularObs = prmRow("amo_enfCerVascularObs").ToString
                vMedico.Secuelas = prmRow("amo_secuelas").ToString
                vMedico.CirugiaCarotidea = Tipos.TipoRespuestaMedico.getTipo(prmRow("amo_cirRevCarotidea"))
                vMedico.CirugiaCarotideaObs = prmRow("amo_cirRevCarotideaObs").ToString
                vMedico.Inmunosupresion = Tipos.TipoRespuestaMedico.getTipo(prmRow("amo_inmunosupresion"))
                vMedico.InmunosupresionObs = prmRow("amo_inmunosupresionObs").ToString
                vMedico.HistoriaOncologica = Tipos.TipoRespuestaMedico.getTipo(prmRow("amo_hisOncologica"))
                vMedico.HistoriaOncologicaObs = prmRow("amo_hisOncologicaObs").ToString
                vMedico.Localizacion = prmRow("amo_localizacion").ToString
                vMedico.Quimioterapia = Tipos.TipoRespuestaMedico.getTipo(prmRow("amo_quimioterapia"))
                vMedico.QuimioterapiaObs = prmRow("amo_quimioterapiaObs").ToString
                vMedico.Radioterapia = Tipos.TipoRespuestaMedico.getTipo(prmRow("amo_radioterapia"))
                vMedico.RadioterapiaObs = prmRow("amo_radioterapiaObs").ToString
                vMedico.ApneaSueno = Tipos.TipoRespuestaMedico.getTipo(prmRow("amo_apnea"))
                vMedico.ApneaSuenoObs = prmRow("amo_apneaObs").ToString
                vMedico.EnfermedadCardiaca = prmRow("amo_enfCardiaca").ToString
                vMedico.CardiopatiaCongenita = Tipos.TipoRespuestaMedico.getTipo(prmRow("amo_carCongenita"))
                vMedico.CardiopatiaCongenitaObs = prmRow("amo_carCongenitaObs").ToString
                vMedico.InfartoAgudoMiocardio = Tipos.TipoRespuestaMedico.getTipo(prmRow("amo_infAguMiocardio"))
                vMedico.InfartoAgudoMiocardioObs = prmRow("amo_infAguMiocardioObs").ToString
                vMedico.InfartoAgudoMiocardioFecha = prmRow("amo_infAguMiocardioFecha").ToString
                vMedico.InsuficienciaCardiaca = Tipos.TipoRespuestaMedico.getTipo(prmRow("amo_insCardiacaNYHA"))
                vMedico.InsuficienciaCardiacaFecha = prmRow("amo_insCardiacaFecha").ToString
                vMedico.InsuficienciaCardiacaNYHA = prmRow("amo_insCardiacaNYHAObs").ToString
                vMedico.SincopeCardiogenico = Tipos.TipoRespuestaMedico.getTipo(prmRow("amo_sinCardiogenico"))
                vMedico.SincopeCardiogenicoObs = prmRow("amo_sinCardiogenicoObs").ToString
                vMedico.ShockCardiogenico = Tipos.TipoRespuestaMedico.getTipo(prmRow("amo_shoCardiogenico"))
                vMedico.ShockCardiogenicoObs = prmRow("amo_shoCardiogenicoObs").ToString
                vMedico.ShockCardiogenicoFecha = prmRow("amo_shoCardiogenicoFecha").ToString
                vMedico.ParoCardiorRespiratorio = Tipos.TipoRespuestaMedico.getTipo(prmRow("amo_parCardiorresp"))
                vMedico.ParoCardiorRespiratorioObs = prmRow("amo_parCardiorrespObs").ToString
                vMedico.ParoCardiorRespiratorioFecha = prmRow("amo_parCardiorrespFecha").ToString
                vMedico.Supraventricular = Tipos.TipoRespuestaMedico.getTipo(prmRow("amo_supraventicular"))
                vMedico.SupraventricularObs = prmRow("amo_supraventicularObs").ToString
                vMedico.Ventricular = Tipos.TipoRespuestaMedico.getTipo(prmRow("amo_ventricular"))
                vMedico.VentricularObs = prmRow("amo_ventricularObs").ToString
                vMedico.Endocarditis = Tipos.TipoRespuestaMedico.getTipo(prmRow("amo_endocarditis"))
                vMedico.EndocarditisObs = prmRow("amo_endocarditisObs").ToString
                vMedico.DiseccionAortica = Tipos.TipoRespuestaMedico.getTipo(prmRow("amo_disAortica"))
                vMedico.DiseccionAorticaTipo = Tipos.TipoDiseccionMedico.getTipo(prmRow("amo_disAorticaTipo"))
                vMedico.AneurismaAortico = Tipos.TipoRespuestaMedico.getTipo(prmRow("amo_aneAortico"))
                vMedico.AneurismaAorticoTipo = Tipos.TipoAneurismaMedico.getTipo(prmRow("amo_aneAorticoTipo"))
                vMedico.TumorCardiaco = Tipos.TipoRespuestaMedico.getTipo(prmRow("amo_tumCardiaco"))
                vMedico.TumorCardiacoTipo = Tipos.TipoTumorMedico.getTipo(prmRow("amo_tumCardiacoTipo"))
                vMedico.Tiempo_ECMO = prmRow("aqc_tiempo").ToString
                vMedico.PuenteCoronario = Tipos.TipoRespuestaMedico.getTipo(prmRow("aqc_pueCoronario"))
                vMedico.PuenteCoronarioObs = prmRow("aqc_pueCoronarioObs").ToString
                vMedico.ADA = Tipos.TipoRespuestaMedico.getTipo(prmRow("aqc_ada"))
                vMedico.ADAObs = prmRow("aqc_adaObs").ToString
                vMedico.ACX = Tipos.TipoRespuestaMedico.getTipo(prmRow("aqc_acx"))
                vMedico.ACXObs = prmRow("aqc_acxObs").ToString
                vMedico.ACD = Tipos.TipoRespuestaMedico.getTipo(prmRow("aqc_acd"))
                vMedico.ACDObs = prmRow("aqc_acdObs").ToString
                vMedico.PuenteCoronarioFecha = prmRow("aqc_pcFecha").ToString
                vMedico.CirugiaValvular = Tipos.TipoRespuestaMedico.getTipo(prmRow("aqc_cirValvular"))
                vMedico.CirugiaValvularObs = prmRow("aqc_cirValvularObs").ToString
                vMedico.Aortica = Tipos.TipoRespuestaMedico.getTipo(prmRow("aqc_aortica"))
                vMedico.AorticaObs = prmRow("aqc_aorticaObs").ToString
                vMedico.Mitral = Tipos.TipoRespuestaMedico.getTipo(prmRow("aqc_mitral"))
                vMedico.MitralObs = prmRow("aqc_mitralObs").ToString
                vMedico.Tricuspide = Tipos.TipoRespuestaMedico.getTipo(prmRow("aqc_tricuspide"))
                vMedico.TricuspideObs = prmRow("aqc_tricuspideObs").ToString
                vMedico.CirugiaValvularFecha = prmRow("aqc_cvFecha").ToString
                vMedico.CierreComInteraricular = Tipos.TipoRespuestaMedico.getTipo(prmRow("aqc_cieComInteraur"))
                vMedico.CierreComInteraricularFecha = prmRow("aqc_cieComInteraurFecha").ToString
                vMedico.CierreComInterVetricular = Tipos.TipoRespuestaMedico.getTipo(prmRow("aqc_cieComInterven"))
                vMedico.CierreComInterVetricularFecha = prmRow("aqc_cieComIntervenFecha").ToString
                vMedico.CirugiaAorta = Tipos.TipoRespuestaMedico.getTipo(prmRow("aqc_cirAorta"))
                vMedico.CirugiaAortaFecha = prmRow("aqc_cirAortaFecha").ToString
                vMedico.CirugiaCardiopatiaCon = Tipos.TipoRespuestaMedico.getTipo(prmRow("aqc_cirCarCongenita"))
                vMedico.CirugiaCardiopatiaConFecha = prmRow("aqc_cirCarCongenitaFecha").ToString
                vMedico.Reoperacion = Tipos.TipoRespuestaMedico.getTipo(prmRow("aqc_reoperacion"))
                vMedico.ReoperacionFecha = prmRow("aqc_reoperacionFecha").ToString
                vMedico.TrasplanteCardiaco = Tipos.TipoRespuestaMedico.getTipo(prmRow("aqc_traCardiaco"))
                vMedico.TrasplanteCardiacoFecha = prmRow("aqc_traCardiacoFecha").ToString
                vMedico.ImplantacionLVAD = Tipos.TipoRespuestaMedico.getTipo(prmRow("aqc_impLvad"))
                vMedico.ImplantacionLVADFecha = prmRow("aqc_impLvadFecha").ToString
                vMedico.OtraCirugia = Tipos.TipoRespuestaMedico.getTipo(prmRow("aqc_otraCirugia"))
                vMedico.TerapiaAblativa = Tipos.TipoRespuestaMedico.getTipo(prmRow("pc_terAblativa"))
                vMedico.TerapiaAblativaObs = prmRow("pc_terAblativaObs").ToString
                vMedico.TerapiaAblativaFecha = prmRow("pc_terAblativaFecha").ToString
                vMedico.Marcapaso = Tipos.TipoRespuestaMedico.getTipo(prmRow("pc_marcapaso"))
                vMedico.MarcapasoObs = prmRow("pc_marcapasoObs").ToString
                vMedico.MarcapasoFecha = prmRow("pc_marcapasoFecha").ToString
                vMedico.CDITRC = Tipos.TipoRespuestaMedico.getTipo(prmRow("pc_cdiTrc"))
                vMedico.CDITRCObs = prmRow("pc_cdiTrcObs").ToString
                vMedico.CDITRCFecha = prmRow("pc_cdiTrcFecha").ToString
                vMedico.Angioplastia = Tipos.TipoRespuestaMedico.getTipo(prmRow("pc_angioplastia"))
                vMedico.AngioplastiaObs = prmRow("pc_angioplastiaObs").ToString
                vMedico.AngioplastiaFecha = prmRow("pc_angioplastiaFecha").ToString
                vMedico.Balon = Tipos.TipoRespuestaMedico.getTipo(prmRow("pc_balon"))
                vMedico.BalonObs = prmRow("pc_balonObs").ToString
                vMedico.BalonFecha = prmRow("pc_balonFecha").ToString


                Return vMedico
            Catch ex As Exception
                Return Nothing
            End Try

        End Function

        Public Function ToJSONHistoriaCardiopatia(rows As List(Of HistoriaCardiopatia)) As String
            Dim data As New CollectionssHistoriaCardiopatia

            data = New CollectionssHistoriaCardiopatia With {.column = rows.ToArray}
            ToJSONHistoriaCardiopatia = JsonConvert.SerializeObject(data)
            Return ToJSONHistoriaCardiopatia
        End Function
        Public Function ToJSONHistoriaCronica(rows As List(Of HistoriaCronica)) As String
            Dim data As New CollectionssHistoriaCronica

            data = New CollectionssHistoriaCronica With {.column = rows.ToArray}
            ToJSONHistoriaCronica = JsonConvert.SerializeObject(data)
            Return ToJSONHistoriaCronica
        End Function
        Public Function ToJSONOtraCirugia(rows As List(Of OtraCirugia)) As String
            Dim data As New CollectionssOtraCirugia

            data = New CollectionssOtraCirugia With {.column = rows.ToArray}
            ToJSONOtraCirugia = JsonConvert.SerializeObject(data)
            Return ToJSONOtraCirugia
        End Function

    End Class

End Namespace
