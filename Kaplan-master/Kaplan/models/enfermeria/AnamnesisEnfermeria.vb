Namespace Clases
    Public Class AnamnesisEnfermeria
        Public Property Id As Integer
        Public Property AntecedentesRelevantes As String
        Public Property PatronRespiratorio As Tipos.TipoPatronRespiratorio
        Public Property RegimenHiposodico As Tipos.TipoRegimenHiposodico
        Public Property FrutayVerdura As Tipos.TipoFrutaVerdura
        Public Property Agua As Tipos.TipoAgua
        Public Property BebidaNec As Tipos.TipoBebNec
        Public Property Grasas As Tipos.TipoGrasas
        Public Property Diuresis As Tipos.TipoDiuresis
        Public Property Deposicion As Tipos.TipoDeposicion
        Public Property TBa As Tipos.TipoTBA
        Public Property TBb As Tipos.TipoTBB
        Public Property EA As Tipos.TipoEstadoAnimo
        Public Property SuenoNocturnoa As Tipos.TipoSuenoNocturnoA
        Public Property SuenoNocturnob As Tipos.TipoSuenoNocturnoB
        Public Property SuenoNocturnoc As Tipos.TipoSuenoNocturnoC
        Public Property Motivacion As Tipos.TipoMotivacion
        Public Property AVD As Tipos.TipoActividadLaboral
        Public Property ActividadesRecreativas As Tipos.TipoActividadRecreativa

        Public Shared Function MapeoAnamnesis(prmDatos As DataTable) As AnamnesisEnfermeria
            Try
                Dim vAnamnesis As New AnamnesisEnfermeria

                Dim prmRow As DataRow = prmDatos.Rows(0)

                vAnamnesis.Id = prmRow("id_anamnesis").ToString
                vAnamnesis.AntecedentesRelevantes = prmRow("antecedentes_relevantes").ToString
                vAnamnesis.PatronRespiratorio = Tipos.TipoPatronRespiratorio.getTipo(prmRow("patron_resp"))
                vAnamnesis.RegimenHiposodico = Tipos.TipoRegimenHiposodico.getTipo(prmRow("regimen_hipo"))
                vAnamnesis.FrutayVerdura = Tipos.TipoFrutaVerdura.getTipo(prmRow("frut_verd"))
                vAnamnesis.Agua = Tipos.TipoAgua.getTipo(prmRow("agua"))
                vAnamnesis.BebidaNec = Tipos.TipoBebNec.getTipo(prmRow("beb_nec"))
                vAnamnesis.Grasas = Tipos.TipoGrasas.getTipo(prmRow("grasas"))
                vAnamnesis.Diuresis = Tipos.TipoDiuresis.getTipo(prmRow("diuresis"))
                vAnamnesis.Deposicion = Tipos.TipoDeposicion.getTipo(prmRow("deposicion"))
                vAnamnesis.TBa = Tipos.TipoTBA.getTipo(prmRow("tb"))
                vAnamnesis.Motivacion = Tipos.TipoMotivacion.getTipo(prmRow("motivacion"))
                vAnamnesis.SuenoNocturnoa = Tipos.TipoSuenoNocturnoA.getTipo(prmRow("sueno_noct"))
                vAnamnesis.EA = Tipos.TipoEstadoAnimo.getTipo(prmRow("estado_anim"))
                vAnamnesis.AVD = Tipos.TipoActividadLaboral.getTipo(prmRow("avd"))
                vAnamnesis.ActividadesRecreativas = Tipos.TipoActividadRecreativa.getTipo(prmRow("act_recre"))
                vAnamnesis.TBb = Tipos.TipoTBB.getTipo(prmRow("tbb"))
                vAnamnesis.SuenoNocturnob = Tipos.TipoSuenoNocturnoB.getTipo(prmRow("sueno_noctb"))
                vAnamnesis.SuenoNocturnoc = Tipos.TipoSuenoNocturnoC.getTipo(prmRow("sueno_noctc"))
                Return vAnamnesis
            Catch ex As Exception
                Return Nothing
            End Try

        End Function

    End Class
End Namespace

