Namespace Clases
    Public Class ExamenFisico
        Public Property Id As Integer
        Public Property Signos As String
        Public Property Cuello As String
        Public Property Cardiaco As String
        Public Property Pulmon As String
        Public Property Torax As String
        Public Property Abdomen As String
        Public Property EEII As String
        Public Property EESS As String
        Public Property Diagnostico As String
        Public Property Plan As String
        Public Shared Function MapeoExamenFisico(prmDatos As DataTable) As ExamenFisico
            Try
                Dim vExamenFisico As New ExamenFisico

                Dim prmRow As DataRow = prmDatos.Rows(0)

                vExamenFisico.Id = prmRow("id_examen").ToString
                vExamenFisico.Signos = prmRow("signos").ToString
                vExamenFisico.Cuello = prmRow("cuello").ToString
                vExamenFisico.Cardiaco = prmRow("cardiaco").ToString
                vExamenFisico.Pulmon = prmRow("pulmon").ToString
                vExamenFisico.Torax = prmRow("torax").ToString
                vExamenFisico.Abdomen = prmRow("abdomen").ToString
                vExamenFisico.EEII = prmRow("eeii").ToString
                vExamenFisico.EESS = prmRow("eess").ToString
                vExamenFisico.Diagnostico = prmRow("diagnostico").ToString
                vExamenFisico.Plan = prmRow("planMedico").ToString

                Return vExamenFisico
            Catch ex As Exception
                Return Nothing
            End Try

        End Function

    End Class
End Namespace
