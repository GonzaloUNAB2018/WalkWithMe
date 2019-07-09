Namespace Clases

    Public Class ExamenFisicoEnfermeria
        Public Property Id As Integer
        Public Property Cabeza As Tipos.TipoCabeza
        Public Property Cuello As Tipos.TipoCuello
        Public Property Toraxa As Tipos.TipoToraxA
        Public Property Toraxb As Tipos.TipoToraxB
        Public Property Toraxc As Tipos.TipoToraxC
        Public Property Toraxd As Tipos.TipoToraxD
        Public Property Abdomena As Tipos.TipoAbdomenA
        Public Property Abdomenb As Tipos.TipoAbdomenB
        Public Property EESS As Tipos.TipoEESS
        Public Property llencap As Tipos.TipoLlenCap
        Public Property EEII As Tipos.TipoEEII
        Public Property PA As Double
        Public Property FC As Double
        Public Property SAT As Double
        Public Property Glicemia As Double
        Public Shared Function MapeoExamenFisico(prmDatos As DataTable) As ExamenFisicoEnfermeria
            Try
                Dim vExamenfisico As New ExamenFisicoEnfermeria

                Dim prmRow As DataRow = prmDatos.Rows(0)

                vExamenfisico.Id = prmRow("id_examen_fisico").ToString
                vExamenfisico.Cabeza = Tipos.TipoCabeza.getTipo(prmRow("cabeza"))
                vExamenfisico.Cuello = Tipos.TipoCuello.getTipo(prmRow("cuello"))
                vExamenfisico.Toraxa = Tipos.TipoToraxA.getTipo(prmRow("toraxA"))
                vExamenfisico.Toraxb = Tipos.TipoToraxB.getTipo(prmRow("toraxB"))
                vExamenfisico.Toraxc = Tipos.TipoToraxC.getTipo(prmRow("toraxC"))
                vExamenfisico.Toraxd = Tipos.TipoToraxD.getTipo(prmRow("toraxD"))
                vExamenfisico.Abdomena = Tipos.TipoAbdomenA.getTipo(prmRow("abdomenA"))
                vExamenfisico.Abdomenb = Tipos.TipoAbdomenB.getTipo(prmRow("abdomenB"))
                vExamenfisico.EESS = Tipos.TipoEESS.getTipo(prmRow("eess"))
                vExamenfisico.EEII = Tipos.TipoEEII.getTipo(prmRow("eeii"))
                vExamenfisico.llencap = Tipos.TipoLlenCap.getTipo(prmRow("llen_cap"))
                vExamenfisico.PA = Double.Parse(prmRow("pa"))
                vExamenfisico.FC = Double.Parse(prmRow("fc"))
                vExamenfisico.SAT = Double.Parse(prmRow("sat"))
                vExamenfisico.Glicemia = Double.Parse(prmRow("glicemia"))

                Return vExamenfisico
            Catch ex As Exception
                Return Nothing
            End Try

        End Function


    End Class
End Namespace