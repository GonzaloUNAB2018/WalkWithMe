Namespace Clases
    Public Class ExamenMedico
        Public Property Id As Integer
        Public Property LesionAda As Tipos.TipoRespuestaMedico
        Public Property LesionAdaObs As String
        Public Property LesionACD As Tipos.TipoRespuestaMedico
        Public Property LesionACDObs As String
        Public Property LesionACX As Tipos.TipoRespuestaMedico
        Public Property LesionACXObs As String
        Public Property TroncoCoronario As Tipos.TipoRespuestaMedico
        Public Property TroncoCoronarioObs As String
        Public Property PapMedia As Tipos.TipoRespuestaMedico
        Public Property PapMediaObs As String
        Public Property Uwood As Tipos.TipoRespuestaMedico
        Public Property UwoodObs As String
        Public Property TestReversibilidad As Tipos.TipoRespuestaMedico
        Public Property TestReversibilidadObs As String
        Public Property FEVI As Tipos.TipoFeviMedico
        Public Property DiametroSistole As String
        Public Property DiametroDiastole As String
        Public Property DilatacionAuricular As Tipos.TipoRespuestaMedico
        Public Property DilatacionAuricularTipo As Tipos.TipoEcocardiogramaMedico
        Public Property HipertensionPulmonar As Tipos.TipoRespuestaMedico
        Public Property HipertensionPulmonarTipo As Tipos.TipoEcocardiogramaMedico
        Public Property DisfuncionVentriculo As Tipos.TipoRespuestaMedico
        Public Property DisfuncionVentriculoTipo As Tipos.TipoEcocardiogramaMedico
        Public Property EstenosisAortica As Tipos.TipoRespuestaMedico
        Public Property EstenosisAorticaTipo As Tipos.TipoEcocardiogramaMedico
        Public Property EstenosisMitral As Tipos.TipoRespuestaMedico
        Public Property EstenosisMitralTipo As Tipos.TipoEcocardiogramaMedico
        Public Property InsuficienciaAortica As Tipos.TipoRespuestaMedico
        Public Property InsuficienciaAorticaTipo As Tipos.TipoEcocardiogramaMedico
        Public Property InsuficienciaMitral As Tipos.TipoRespuestaMedico
        Public Property InsuficienciaMitralTipo As Tipos.TipoEcocardiogramaMedico
        Public Property Aquinesia As Tipos.TipoRespuestaMedico
        Public Property AquinesiaTipo As Tipos.TipoEcocardiogramaMedico
        Public Property Arrtimias As Tipos.TipoRespuestaMedico
        Public Property ArrtimiasObs As String
        Public Property BloqueosAV As Tipos.TipoRespuestaMedico
        Public Property BloqueosAVObs As String
        Public Property EjeCardiaco As Tipos.TipoRespuestaMedico
        Public Property EjeCardiacoObs As String
        Public Property Otro As String
        Public Property ProBNP As String
        Public Property ProBNPFecha As Date
        Public Property Troponina As String
        Public Property TroponinaFecha As Date
        Public Property PCR As String
        Public Property PCRFecha As Date
        Public Property DimeroD As String
        Public Property DimeroDFecha As Date
        Public Property Sodio As String
        Public Property SodioFecha As Date
        Public Property Potasio As String
        Public Property PotasioFecha As Date
        Public Property CreatinaKinasa As String
        Public Property CreatinaKinasaFecha As Date
        Public Property CKMB As String
        Public Property CKMBFecha As Date
        Public Property AcidoUrico As String
        Public Property AcidoUricoFecha As Date

        Public Shared Function MapeoExamenMedico(prmDatos As DataTable) As ExamenMedico
            Try
                Dim vExamenMedico As New ExamenMedico

                Dim prmRow As DataRow = prmDatos.Rows(0)

                vExamenMedico.Id = prmRow("ex_id_examenes").ToString
                vExamenMedico.LesionAda = Tipos.TipoRespuestaMedico.getTipo(prmRow("ex_ada"))
                vExamenMedico.LesionAdaObs = prmRow("ex_adaObs").ToString
                vExamenMedico.LesionACD = Tipos.TipoRespuestaMedico.getTipo(prmRow("ex_acd"))
                vExamenMedico.LesionACDObs = prmRow("ex_acdObs").ToString
                vExamenMedico.LesionACX = Tipos.TipoRespuestaMedico.getTipo(prmRow("ex_acx"))
                vExamenMedico.LesionACXObs = prmRow("ex_acxObs").ToString
                vExamenMedico.TroncoCoronario = Tipos.TipoRespuestaMedico.getTipo(prmRow("ex_troCoronario"))
                vExamenMedico.TroncoCoronarioObs = prmRow("ex_troCoronarioObs").ToString
                vExamenMedico.PapMedia = Tipos.TipoRespuestaMedico.getTipo(prmRow("ex_pap"))
                vExamenMedico.PapMediaObs = prmRow("ex_papObs").ToString
                vExamenMedico.Uwood = Tipos.TipoRespuestaMedico.getTipo(prmRow("ex_wood"))
                vExamenMedico.UwoodObs = prmRow("ex_wood").ToString
                vExamenMedico.TestReversibilidad = Tipos.TipoRespuestaMedico.getTipo(prmRow("ex_testReversibilidad"))
                vExamenMedico.TestReversibilidadObs = prmRow("ex_testReversibilidadObs").ToString
                vExamenMedico.FEVI = Tipos.TipoFeviMedico.getTipo(prmRow("ex_fevi"))
                vExamenMedico.DiametroSistole = prmRow("ex_diaSistole").ToString
                vExamenMedico.DiametroDiastole = prmRow("ex_diaDiastole").ToString
                vExamenMedico.DilatacionAuricular = Tipos.TipoRespuestaMedico.getTipo(prmRow("ex_dilAurIzq"))
                vExamenMedico.DilatacionAuricularTipo = Tipos.TipoEcocardiogramaMedico.getTipo(prmRow("ex_dilAurIzqTipo"))
                vExamenMedico.HipertensionPulmonar = Tipos.TipoRespuestaMedico.getTipo(prmRow("ex_hipPulmonar"))
                vExamenMedico.HipertensionPulmonarTipo = Tipos.TipoEcocardiogramaMedico.getTipo(prmRow("ex_hipPulmonarTipo"))
                vExamenMedico.DisfuncionVentriculo = Tipos.TipoRespuestaMedico.getTipo(prmRow("ex_disVenDer"))
                vExamenMedico.DisfuncionVentriculoTipo = Tipos.TipoEcocardiogramaMedico.getTipo(prmRow("ex_disVenDerTipo"))
                vExamenMedico.EstenosisAortica = Tipos.TipoRespuestaMedico.getTipo(prmRow("ex_estAortica"))
                vExamenMedico.EstenosisAorticaTipo = Tipos.TipoEcocardiogramaMedico.getTipo(prmRow("ex_estAorticaTipo"))
                vExamenMedico.EstenosisMitral = Tipos.TipoRespuestaMedico.getTipo(prmRow("ex_estMitral"))
                vExamenMedico.EstenosisMitralTipo = Tipos.TipoEcocardiogramaMedico.getTipo(prmRow("ex_estMitralTipo"))
                vExamenMedico.InsuficienciaAortica = Tipos.TipoRespuestaMedico.getTipo(prmRow("ex_insAortica"))
                vExamenMedico.InsuficienciaAorticaTipo = Tipos.TipoEcocardiogramaMedico.getTipo(prmRow("ex_insAorticaTipo"))
                vExamenMedico.InsuficienciaMitral = Tipos.TipoRespuestaMedico.getTipo(prmRow("ex_insMitral"))
                vExamenMedico.InsuficienciaMitralTipo = Tipos.TipoEcocardiogramaMedico.getTipo(prmRow("ex_insMitralTipo"))
                vExamenMedico.Aquinesia = Tipos.TipoRespuestaMedico.getTipo(prmRow("ex_aquinesia"))
                vExamenMedico.AquinesiaTipo = Tipos.TipoEcocardiogramaMedico.getTipo(prmRow("ex_aquinesiaTipo"))
                vExamenMedico.Arrtimias = Tipos.TipoRespuestaMedico.getTipo(prmRow("ex_arritmia"))
                vExamenMedico.ArrtimiasObs = prmRow("ex_arritmiaObs").ToString
                vExamenMedico.BloqueosAV = Tipos.TipoRespuestaMedico.getTipo(prmRow("ex_bloqueoAv"))
                vExamenMedico.BloqueosAVObs = prmRow("ex_bloqueoAvObs").ToString
                vExamenMedico.EjeCardiaco = Tipos.TipoRespuestaMedico.getTipo(prmRow("ex_ejeCardiaco"))
                vExamenMedico.EjeCardiacoObs = prmRow("ex_ejeCardiacoObs").ToString
                vExamenMedico.Otro = prmRow("ex_otros").ToString
                vExamenMedico.ProBNP = prmRow("ex_proBnp").ToString
                vExamenMedico.ProBNPFecha = prmRow("ex_proBnpFecha").ToString
                vExamenMedico.Troponina = prmRow("ex_troponina").ToString
                vExamenMedico.TroponinaFecha = prmRow("ex_troponinaFecha").ToString
                vExamenMedico.PCR = prmRow("ex_pcr").ToString
                vExamenMedico.PCRFecha = prmRow("ex_pcrFecha").ToString
                vExamenMedico.DimeroD = prmRow("ex_dimeroD").ToString
                vExamenMedico.DimeroDFecha = prmRow("ex_dimeroDFecha").ToString
                vExamenMedico.Sodio = prmRow("ex_sodio").ToString
                vExamenMedico.SodioFecha = prmRow("ex_sodioFecha").ToString
                vExamenMedico.Potasio = prmRow("ex_potasio").ToString
                vExamenMedico.PotasioFecha = prmRow("ex_potasioFecha").ToString
                vExamenMedico.CreatinaKinasa = prmRow("ex_creaKinasa").ToString
                vExamenMedico.CreatinaKinasaFecha = prmRow("ex_creaKinasaFecha").ToString
                vExamenMedico.CKMB = prmRow("ex_ckmb").ToString
                vExamenMedico.CKMBFecha = prmRow("ex_ckmbFecha").ToString
                vExamenMedico.AcidoUrico = prmRow("ex_aciUrico").ToString
                vExamenMedico.AcidoUricoFecha = prmRow("ex_aciUricoFecha").ToString

                Return vExamenMedico
            Catch ex As Exception
                Return Nothing
            End Try

        End Function

    End Class
End Namespace

