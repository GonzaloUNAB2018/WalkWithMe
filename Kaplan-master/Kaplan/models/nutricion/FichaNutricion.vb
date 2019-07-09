Imports Kaplan.Clases
Imports System.Globalization
Imports System.Data.OleDb
Imports System.Data.SqlClient
Namespace Clases
    Public Class FichaNutricion
        Public Property Id As Integer
        Public Property IdReserva As Integer
        Public Property IdEspecialista As Integer
        Public Property Diagnostico As String
        Public Property CxProced As String
        Public Property DiagNutInt As String
        Public Property PrescripcionDietetica As String
        Public Property IndicacionesGenerales As String
        Public Property ObjetivosAlimentarios As String
        Public Property IntervencionNutricional As String
        Public Property MedicionesAntropometricas As MedicionesAntropometricas
        Public Property IngestaAlimentaria As IngestaAlimentaria
        Public Property RequerimientosNutricionales As RequerimientosNutricionales
        Public Property Cuestionario As Cuestionario
        Public Property Sedentario As Tipos.TipoSED
        Public Property Estres As Tipos.TipoEstres
        Public Property Tabaco As Tipos.TipoTB
        Public Property HTA As Tipos.TipoHTA
        Public Property DM As Tipos.TipoDM
        Public Property DLP As Tipos.TipoDLP
        Public Property SBOB As Tipos.TipoSPOB
        Public Property OH As Tipos.TipoOH
        Public Property Apetito As Tipos.TipoApetito
        Public Property AlergiaAlimentaria As Tipos.TipoAlergiaAlimentaria
        Public Property PreferenciaAlimentaria As Tipos.TipoPreferenciaAlimentaria
        Public Property IntoleranciaAlimentaria As Tipos.TipoIntolerenciaAlimentaria
        Public Property AversionAlimentaria As Tipos.TipoAversionAlimentaria
        Public Property ConsumoSuplemento As Tipos.TipoSuplemento

        Public Shared Function MapeoFichaNutricion(prmDatos As DataTable) As FichaNutricion
            Try
                Dim vNutricion As New FichaNutricion
                Dim prmRow As DataRow = prmDatos.Rows(0)
#Region "Ficha Nutrición"
                vNutricion.Id = prmRow("id_ficha_nutri")
                vNutricion.IdReserva = prmRow("id_reserva")
                vNutricion.IdEspecialista = prmRow("id_especialista")
                vNutricion.Diagnostico = prmRow("diagnostico").ToString
                vNutricion.CxProced = prmRow("cx_proced").ToString
                vNutricion.DiagNutInt = prmRow("dni_obs").ToString
                vNutricion.ObjetivosAlimentarios = prmRow("pn_oan").ToString
                vNutricion.IntervencionNutricional = prmRow("pn_in").ToString
                vNutricion.Sedentario = Tipos.TipoSED.getTipo(prmRow("Sedentario"))
                vNutricion.Estres = Tipos.TipoEstres.getTipo(prmRow("Estres"))
                vNutricion.Tabaco = Tipos.TipoTB.getTipo(prmRow("Tabaco"))
                vNutricion.HTA = Tipos.TipoHTA.getTipo(prmRow("HTA"))
                vNutricion.DM = Tipos.TipoDM.getTipo(prmRow("DM"))
                vNutricion.DLP = Tipos.TipoDLP.getTipo(prmRow("DLP"))
                vNutricion.SBOB = Tipos.TipoSPOB.getTipo(prmRow("SBOB"))
                vNutricion.OH = Tipos.TipoOH.getTipo(prmRow("OH"))
                vNutricion.Apetito = Tipos.TipoApetito.getTipo(prmRow("Apetito"))
                vNutricion.AlergiaAlimentaria = Tipos.TipoAlergiaAlimentaria.getTipo(prmRow("AlergiaAlimentaria"))
                vNutricion.PreferenciaAlimentaria = Tipos.TipoPreferenciaAlimentaria.getTipo(prmRow("PreferenciaAlimentaria"))
                vNutricion.IntoleranciaAlimentaria = Tipos.TipoIntolerenciaAlimentaria.getTipo(prmRow("IntoleranciaAlimentaria"))
                vNutricion.AversionAlimentaria = Tipos.TipoAversionAlimentaria.getTipo(prmRow("AversionAlimentaria"))
                vNutricion.ConsumoSuplemento = Tipos.TipoSuplemento.getTipo(prmRow("ConsumoSuplemento"))
                vNutricion.PrescripcionDietetica = prmRow("pd_obs")
                vNutricion.IndicacionesGenerales = prmRow("ig_obs")
#End Region
#Region "Mediciones Antropométricas"
                Dim vMedicionesAntropometricas As New MedicionesAntropometricas
                vMedicionesAntropometricas.PesoActual = prmRow("Peso_Actual")
                vMedicionesAntropometricas.Talla = prmRow("Talla")
                vMedicionesAntropometricas.PesoActual = prmRow("Peso_Actual")
                vMedicionesAntropometricas.Talla = Math.Round(prmRow("Talla"), 2)
                vMedicionesAntropometricas.IMC = Math.Round(prmRow("Peso_Actual") / Math.Pow(prmRow("Talla"), 2), 1)
                If vMedicionesAntropometricas.IMC > 25 Then
                    vMedicionesAntropometricas.EstadoIMC = "Sobrepeso"
                ElseIf vMedicionesAntropometricas.IMC > 18.5 Then
                    vMedicionesAntropometricas.EstadoIMC = "Normal"
                ElseIf vMedicionesAntropometricas.IMC < 18.5 Then
                    vMedicionesAntropometricas.EstadoIMC = "Desnutrido"
                Else
                    vMedicionesAntropometricas.EstadoIMC = ""
                End If
                vMedicionesAntropometricas.PesoHabitual = prmRow("Peso_Habitual")
                vMedicionesAntropometricas.PesoMinimo = Math.Round(Math.Pow(prmRow("Talla"), 2) * 18.5, 2)
                vMedicionesAntropometricas.PesoMaximo = Math.Round(Math.Pow(prmRow("Talla"), 2) * 24.9, 2)
                vMedicionesAntropometricas.PesoIdeal = Math.Round(Math.Pow(prmRow("Talla"), 2) * 21.7, 2)
                vMedicionesAntropometricas.PesoMinimoMayor = Math.Round(Math.Pow(prmRow("Talla"), 2) * 23.1, 2)
                vMedicionesAntropometricas.PesoMaximoMayor = Math.Round(Math.Pow(prmRow("Talla"), 2) * 27.9, 2)
                vMedicionesAntropometricas.PesoIdealMayor = Math.Round(Math.Pow(prmRow("Talla"), 2) * 25.5, 2)
                If vMedicionesAntropometricas.IMC > 31 Then
                    vMedicionesAntropometricas.EstadoIMC = "Obesidad"
                ElseIf vMedicionesAntropometricas.EstadoIMCAM > 27.9 Then
                    vMedicionesAntropometricas.EstadoIMC = "Sobrepeso"
                ElseIf vMedicionesAntropometricas.IMC > 23.1 Then
                    vMedicionesAntropometricas.EstadoIMCAM = "Normal"
                ElseIf vMedicionesAntropometricas.IMC < 23.1 Then
                    vMedicionesAntropometricas.EstadoIMCAM = "Bajopeso"
                Else
                    vMedicionesAntropometricas.EstadoIMCAM = ""
                End If
                vMedicionesAntropometricas.MasaGrasaCorporal = prmRow("masa_grasa_corp")
                vMedicionesAntropometricas.MasaMagra = prmRow("masa_magra")
                vMedicionesAntropometricas.IndiceCinturaCadera = prmRow("indice_cintura")
                vMedicionesAntropometricas.MNA = prmRow("mna")
                vMedicionesAntropometricas.MasaGrasaPorc = prmRow("masa_grasa_porc")
                vMedicionesAntropometricas.GrasaVisceralPorc = prmRow("grasa_visc_porc")
                vMedicionesAntropometricas.PCintura = prmRow("cintura")
                vMedicionesAntropometricas.Cribaje = Tipos.TipoCribaje.getTipo(prmRow("cribaje"))
                vNutricion.MedicionesAntropometricas = vMedicionesAntropometricas
#End Region
#Region "Ingesta Alimentaria"
                Dim vIngestaAlimentaria As New IngestaAlimentaria
                vIngestaAlimentaria.DesayunoHora = prmRow("ia_desayuno_hora").ToString()
                vIngestaAlimentaria.DesayunoObs = prmRow("ia_desayuno_obs").ToString()
                vIngestaAlimentaria.ColacionHora = prmRow("ia_colacion_hora").ToString()
                vIngestaAlimentaria.ColacionObs = prmRow("ia_colacion_obs").ToString()
                vIngestaAlimentaria.AlmuerzoHora = prmRow("ia_Almuerzo_hora").ToString()
                vIngestaAlimentaria.AlmuerzoObs = prmRow("ia_Almuerzo_obs").ToString()
                vIngestaAlimentaria.PicoteoHora = prmRow("ia_Picoteo_hora").ToString()
                vIngestaAlimentaria.PicoteoObs = prmRow("ia_Picoteo_obs").ToString()
                vIngestaAlimentaria.OnceHora = prmRow("ia_Once_hora").ToString()
                vIngestaAlimentaria.OnceObs = prmRow("ia_Once_obs").ToString()
                vIngestaAlimentaria.SnackHora = prmRow("ia_Snack_hora").ToString()
                vIngestaAlimentaria.SnackObs = prmRow("ia_Snack_obs").ToString()
                vIngestaAlimentaria.CenaHora = prmRow("ia_Cena_hora").ToString()
                vIngestaAlimentaria.CenaObs = prmRow("ia_Cena_obs").ToString()
                vIngestaAlimentaria.Observacion = prmRow("ia_obs").ToString()
                vNutricion.IngestaAlimentaria = vIngestaAlimentaria
#End Region
#Region "Requerimientos Nutricionales"
                Dim vRequerimientosNutricionales As New RequerimientosNutricionales
                vRequerimientosNutricionales.GEB = prmRow("rn_geb").ToString()
                vRequerimientosNutricionales.FA = prmRow("rn_fa").ToString()
                vRequerimientosNutricionales.Energia = prmRow("rn_energia")
                vRequerimientosNutricionales.KcalDia = Math.Round(prmRow("rn_energia") / vMedicionesAntropometricas.PesoActual)
                vRequerimientosNutricionales.ProteinaPorc = prmRow("rn_proteina_porc")
                vRequerimientosNutricionales.ProteinaCal = Math.Round((prmRow("rn_energia") * prmRow("rn_proteina_porc") / 100), 1)
                vRequerimientosNutricionales.ProteinaGra = Math.Round(vRequerimientosNutricionales.ProteinaCal / 4)
                vRequerimientosNutricionales.ProteinaDia = Math.Round(vRequerimientosNutricionales.ProteinaGra / vMedicionesAntropometricas.PesoActual)
                vRequerimientosNutricionales.LipidosPorc = prmRow("rn_lipidos_porc")
                vRequerimientosNutricionales.LipidosCal = Math.Round((prmRow("rn_energia") * prmRow("rn_lipidos_porc") / 100), 1)
                vRequerimientosNutricionales.LipidosGra = Math.Round(vRequerimientosNutricionales.LipidosCal / 9)
                vRequerimientosNutricionales.LipidosDia = Math.Round(vRequerimientosNutricionales.LipidosGra / vMedicionesAntropometricas.PesoActual)
                vRequerimientosNutricionales.HidratosPorc = Math.Round(100 - vRequerimientosNutricionales.ProteinaPorc - vRequerimientosNutricionales.LipidosPorc)
                vRequerimientosNutricionales.HidratosCal = Math.Round((prmRow("rn_energia") * vRequerimientosNutricionales.HidratosPorc / 100), 1)
                vRequerimientosNutricionales.HidratosGra = Math.Round(vRequerimientosNutricionales.HidratosCal / 4)
                vRequerimientosNutricionales.HidratosDia = Math.Round(vRequerimientosNutricionales.HidratosGra / vMedicionesAntropometricas.PesoActual)
                vRequerimientosNutricionales.SumaPorc = Math.Round(vRequerimientosNutricionales.ProteinaPorc + vRequerimientosNutricionales.LipidosPorc + vRequerimientosNutricionales.HidratosPorc)
                vRequerimientosNutricionales.RequerimientoKCal = vRequerimientosNutricionales.Energia
                vRequerimientosNutricionales.RequerimientoCho = vRequerimientosNutricionales.HidratosGra
                vRequerimientosNutricionales.RequerimientoLip = vRequerimientosNutricionales.LipidosGra
                vRequerimientosNutricionales.RequerimientoProt = vRequerimientosNutricionales.ProteinaGra
                vRequerimientosNutricionales.AporteKCal = prmRow("rn_aporte_alim_kcal")
                vRequerimientosNutricionales.AporteCho = prmRow("rn_aporte_alim_cho")
                vRequerimientosNutricionales.AporteLip = prmRow("rn_aporte_alim_lip")
                vRequerimientosNutricionales.AporteProt = prmRow("rn_aporte_alim_prot")
                vRequerimientosNutricionales.AdecuacionKCal = Math.Round((vRequerimientosNutricionales.AporteKCal * 100) / vRequerimientosNutricionales.RequerimientoKCal)
                vRequerimientosNutricionales.AdecuacionCho = IIf(vRequerimientosNutricionales.RequerimientoCho > 0, Math.Round((vRequerimientosNutricionales.AporteCho * 100) / vRequerimientosNutricionales.RequerimientoCho), 0)
                vRequerimientosNutricionales.AdecuacionLip = IIf(vRequerimientosNutricionales.RequerimientoLip > 0, Math.Round((vRequerimientosNutricionales.AporteLip * 100) / vRequerimientosNutricionales.RequerimientoLip), 0)
                vRequerimientosNutricionales.AdecuacionProt = IIf(vRequerimientosNutricionales.RequerimientoProt > 0, Math.Round((vRequerimientosNutricionales.AporteProt * 100) / vRequerimientosNutricionales.RequerimientoProt), 0)
                vNutricion.RequerimientosNutricionales = vRequerimientosNutricionales
#End Region
#Region "Cuestionario"
                Dim vCuestionario As New Cuestionario
                vCuestionario.Fruta = Tipos.TipoFruta.getTipo(prmRow("Frutas"))
                vCuestionario.Verdura = Tipos.TipoVerdura.getTipo(prmRow("Verduras"))
                vCuestionario.Lacteo = Tipos.TipoLacteo.getTipo(prmRow("Lacteos"))
                vCuestionario.Carne = Tipos.TipoCarne.getTipo(prmRow("Carnes"))
                vCuestionario.Azucar = Tipos.TipoAzucar.getTipo(prmRow("Azucar"))
                vCuestionario.Legumbre = Tipos.TipoLegumbre.getTipo(prmRow("Legumbres"))
                vCuestionario.Pescado = Tipos.TipoPescado.getTipo(prmRow("Pescado"))
                vCuestionario.Sodio = Tipos.TipoSodio.getTipo(prmRow("Sodio"))
                vCuestionario.Liquido = Tipos.TipoLiquido.getTipo(prmRow("Liquidos"))
                vNutricion.Cuestionario = vCuestionario
#End Region
                Return vNutricion
            Catch ex As Exception
                Return Nothing
            End Try
        End Function
    End Class
End Namespace
