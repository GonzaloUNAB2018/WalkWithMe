Imports Microsoft.Reporting.WebForms

Public Class reporte
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Try
                If Request("tipo") Is Nothing Then Response.End()
                If Request("id") Is Nothing Then Response.End()
                Select Case Request("tipo")
                    Case "FN"
                        Dim data As New dsReporte
                        Dim dt As DataTable = reportes.reporteNutricion(Request("id"))
                        dt.TableName = "PACIENTE"
                        Dim rds = New ReportDataSource("dsReporte", dt)
                        ReportViewer1.LocalReport.DataSources.Clear()
                        ReportViewer1.LocalReport.DataSources.Add(New ReportDataSource("dsPacientes", dt.DefaultView))
                        ReportViewer1.LocalReport.ReportEmbeddedResource = "nutricion.rdlc"
                        ReportViewer1.Visible = True
                        ReportViewer1.LocalReport.Refresh()
                    Case "FP"
                        Dim data As New dsReporte
                        Dim dt As DataTable = reportes.reportePsicologia(Request("id"))
                        dt.TableName = "PSICOLOGIA"
                        Dim rds = New ReportDataSource("dsReporte", dt)
                        ReportViewer2.LocalReport.DataSources.Clear()
                        ReportViewer2.LocalReport.DataSources.Add(New ReportDataSource("dsPacientes", dt.DefaultView))
                        ReportViewer2.LocalReport.ReportEmbeddedResource = "psicologia.rdlc"
                        ReportViewer2.Visible = True
                        ReportViewer2.LocalReport.Refresh()
                    Case "FK"
                        Dim data As New dsReporte
                        Dim ds As New DataSet
                        ds = reportes.reporteKinesiologia(Request("id"))
                        ds.Tables(0).TableName = "KINESIOLOGIA"
                        ds.Tables(1).TableName = "FKEVOLUCION"
                        ds.Tables(2).TableName = "FKDIAGNOSTICO"
                        ds.Tables(3).TableName = "FKOBJETIVO"
                        ds.Tables(4).TableName = "FKPLAN"
                        Dim rds = New ReportDataSource("dsReporte", ds.Tables(0))
                        Dim rds2 = New ReportDataSource("dsReporte", ds.Tables(1))
                        Dim rds3 = New ReportDataSource("dsReporte", ds.Tables(2))
                        Dim rds4 = New ReportDataSource("dsReporte", ds.Tables(3))
                        Dim rds5 = New ReportDataSource("dsReporte", ds.Tables(4))
                        ReportViewer3.LocalReport.DataSources.Clear()
                        ReportViewer3.LocalReport.DataSources.Add(New ReportDataSource("dsPacientes", ds.Tables(0).DefaultView))
                        ReportViewer3.LocalReport.DataSources.Add(New ReportDataSource("dsFKEvolucion", ds.Tables(1).DefaultView))
                        ReportViewer3.LocalReport.DataSources.Add(New ReportDataSource("dsFKDiagnostico", ds.Tables(2).DefaultView))
                        ReportViewer3.LocalReport.DataSources.Add(New ReportDataSource("dsFKObjetivo", ds.Tables(3).DefaultView))
                        ReportViewer3.LocalReport.DataSources.Add(New ReportDataSource("dsFKPlan", ds.Tables(4).DefaultView))
                        ReportViewer3.LocalReport.ReportEmbeddedResource = "kinesiologia.rdlc"
                        ReportViewer3.Visible = True
                        ReportViewer3.LocalReport.Refresh()
                    Case "FM"
                        Dim data As New dsReporte
                        Dim ds As New DataSet
                        ds = reportes.reporteMedico(Request("id"))
                        ds.Tables(0).TableName = "MEDICO"
                        ds.Tables(1).TableName = "FMEXAMENFISICO"
                        ds.Tables(2).TableName = "FMEXAMEN"
                        ds.Tables(3).TableName = "FMBETABLOQUEADOR"
                        ds.Tables(4).TableName = "FMBLOQUEADORCORR"
                        ds.Tables(5).TableName = "FMIECA"
                        ds.Tables(6).TableName = "FMANTAGONISTA"
                        ds.Tables(7).TableName = "FMNITRATO"
                        ds.Tables(8).TableName = "FMANTICOAGULANTEORAL"
                        ds.Tables(9).TableName = "FMESTATINA"
                        ds.Tables(10).TableName = "FMANTIPLAQUETARIO"
                        ds.Tables(11).TableName = "FMHIPOGLICEMIANTE"
                        ds.Tables(12).TableName = "FMESTEROIDES"
                        ds.Tables(13).TableName = "FMDIURETICO"
                        ds.Tables(14).TableName = "FMALOPURINOL"
                        ds.Tables(15).TableName = "FMDIGITALICOS"
                        ds.Tables(16).TableName = "FMANTIARRITMICOS"
                        ds.Tables(17).TableName = "FMOTROS"
                        ds.Tables(18).TableName = "FMHISTORIACARDIO"
                        ds.Tables(19).TableName = "FMHISTORIACRONICA"
                        ds.Tables(20).TableName = "FMOTRASCIRUGIAS"
                        Dim rds = New ReportDataSource("dsReporte", ds.Tables(0))
                        Dim rds2 = New ReportDataSource("dsReporte", ds.Tables(1))
                        Dim rds3 = New ReportDataSource("dsReporte", ds.Tables(2))
                        Dim rds4 = New ReportDataSource("dsReporte", ds.Tables(3))
                        Dim rds5 = New ReportDataSource("dsReporte", ds.Tables(4))
                        Dim rds6 = New ReportDataSource("dsReporte", ds.Tables(5))
                        Dim rds7 = New ReportDataSource("dsReporte", ds.Tables(6))
                        Dim rds8 = New ReportDataSource("dsReporte", ds.Tables(7))
                        Dim rds9 = New ReportDataSource("dsReporte", ds.Tables(8))
                        Dim rds10 = New ReportDataSource("dsReporte", ds.Tables(9))
                        Dim rds11 = New ReportDataSource("dsReporte", ds.Tables(10))
                        Dim rds12 = New ReportDataSource("dsReporte", ds.Tables(11))
                        Dim rds13 = New ReportDataSource("dsReporte", ds.Tables(12))
                        Dim rds14 = New ReportDataSource("dsReporte", ds.Tables(13))
                        Dim rds15 = New ReportDataSource("dsReporte", ds.Tables(14))
                        Dim rds16 = New ReportDataSource("dsReporte", ds.Tables(15))
                        Dim rds17 = New ReportDataSource("dsReporte", ds.Tables(16))
                        Dim rds18 = New ReportDataSource("dsReporte", ds.Tables(17))
                        Dim rds19 = New ReportDataSource("dsReporte", ds.Tables(18))
                        Dim rds20 = New ReportDataSource("dsReporte", ds.Tables(19))
                        Dim rds21 = New ReportDataSource("dsReporte", ds.Tables(20))
                        ReportViewer6.LocalReport.DataSources.Clear()
                        ReportViewer6.LocalReport.DataSources.Add(New ReportDataSource("dsReporte", ds.Tables(0).DefaultView))
                        ReportViewer6.LocalReport.DataSources.Add(New ReportDataSource("dsFMExamenFisico", ds.Tables(1).DefaultView))
                        ReportViewer6.LocalReport.DataSources.Add(New ReportDataSource("dsFMExamen", ds.Tables(2).DefaultView))
                        ReportViewer6.LocalReport.DataSources.Add(New ReportDataSource("dsFMBetabloqueador", ds.Tables(3).DefaultView))
                        ReportViewer6.LocalReport.DataSources.Add(New ReportDataSource("dsFMBloqueadorCorr", ds.Tables(4).DefaultView))
                        ReportViewer6.LocalReport.DataSources.Add(New ReportDataSource("dsFMIECA", ds.Tables(5).DefaultView))
                        ReportViewer6.LocalReport.DataSources.Add(New ReportDataSource("dsFMAntagonista", ds.Tables(6).DefaultView))
                        ReportViewer6.LocalReport.DataSources.Add(New ReportDataSource("dsFMNitrato", ds.Tables(7).DefaultView))
                        ReportViewer6.LocalReport.DataSources.Add(New ReportDataSource("dsFMAnticoagulanteoral", ds.Tables(8).DefaultView))
                        ReportViewer6.LocalReport.DataSources.Add(New ReportDataSource("dsFMEstatina", ds.Tables(9).DefaultView))
                        ReportViewer6.LocalReport.DataSources.Add(New ReportDataSource("dsFMAntiplaquetario", ds.Tables(10).DefaultView))
                        ReportViewer6.LocalReport.DataSources.Add(New ReportDataSource("dsFMHipoglicemiante", ds.Tables(11).DefaultView))
                        ReportViewer6.LocalReport.DataSources.Add(New ReportDataSource("dsFMEsteroides", ds.Tables(12).DefaultView))
                        ReportViewer6.LocalReport.DataSources.Add(New ReportDataSource("dsFMDiuretico", ds.Tables(13).DefaultView))
                        ReportViewer6.LocalReport.DataSources.Add(New ReportDataSource("dsFMAlopurinol", ds.Tables(14).DefaultView))
                        ReportViewer6.LocalReport.DataSources.Add(New ReportDataSource("dsFMDigitalicos", ds.Tables(15).DefaultView))
                        ReportViewer6.LocalReport.DataSources.Add(New ReportDataSource("dsFMAntiarritmicos", ds.Tables(16).DefaultView))
                        ReportViewer6.LocalReport.DataSources.Add(New ReportDataSource("dsFMOtros", ds.Tables(17).DefaultView))
                        ReportViewer6.LocalReport.DataSources.Add(New ReportDataSource("dsFMHisFamCardiopatia", ds.Tables(18).DefaultView))
                        ReportViewer6.LocalReport.DataSources.Add(New ReportDataSource("dsFMHistFamCronica", ds.Tables(19).DefaultView))
                        ReportViewer6.LocalReport.DataSources.Add(New ReportDataSource("dsFMOtrasCirugias", ds.Tables(20).DefaultView))
                        ReportViewer6.LocalReport.ReportEmbeddedResource = "MEDICO.rdlc"
                        ReportViewer6.Visible = True
                        ReportViewer6.LocalReport.Refresh()
                    Case "FE"
                        Dim data As New dsReporte
                        Dim ds As New DataSet
                        ds = reportes.reporteEnfermeria(Request("id"))
                        ds.Tables(0).TableName = "ENFERMERIA"
                        ds.Tables(1).TableName = "FEMEDICAMENTO"
                        ds.Tables(2).TableName = "FEEVOLUCION"
                        ds.Tables(3).TableName = "FEDIAGNOSTICO"
                        ds.Tables(4).TableName = "FECUIDADO"
                        ds.Tables(5).TableName = "FEINDICADOR"
                        Dim rds = New ReportDataSource("dsReporte", ds.Tables(0))
                        Dim rds2 = New ReportDataSource("dsReporte", ds.Tables(1))
                        Dim rds3 = New ReportDataSource("dsReporte", ds.Tables(2))
                        Dim rds4 = New ReportDataSource("dsReporte", ds.Tables(3))
                        Dim rds5 = New ReportDataSource("dsReporte", ds.Tables(4))
                        Dim rds6 = New ReportDataSource("dsReporte", ds.Tables(5))
                        ReportViewer4.LocalReport.DataSources.Clear()
                        ReportViewer4.LocalReport.DataSources.Add(New ReportDataSource("dsPacientes", ds.Tables(0).DefaultView))
                        ReportViewer4.LocalReport.DataSources.Add(New ReportDataSource("dsFEMedicamento", ds.Tables(1).DefaultView))
                        ReportViewer4.LocalReport.DataSources.Add(New ReportDataSource("dsFEEvolucion", ds.Tables(2).DefaultView))
                        ReportViewer4.LocalReport.DataSources.Add(New ReportDataSource("dsFEDiagnostico", ds.Tables(3).DefaultView))
                        ReportViewer4.LocalReport.DataSources.Add(New ReportDataSource("dsFECuidado", ds.Tables(4).DefaultView))
                        ReportViewer4.LocalReport.DataSources.Add(New ReportDataSource("dsFEIndicador", ds.Tables(5).DefaultView))
                        ReportViewer4.LocalReport.ReportEmbeddedResource = "enfermeria.rdlc"
                        ReportViewer4.Visible = True
                        ReportViewer4.LocalReport.Refresh()
                    Case "EVO"
                        Dim data As New dsReporte
                        Dim dt As DataTable = reportes.ReporteEvolucion(Request("id"))
                        dt.TableName = "EVOLUCION"
                        Dim rds = New ReportDataSource("dsReporte", dt)
                        ReportViewer5.LocalReport.DataSources.Add(New ReportDataSource("dsEvolucion", dt.DefaultView))
                        ReportViewer5.LocalReport.ReportEmbeddedResource = "evolucion.rdlc"
                        ReportViewer5.Visible = True
                        ReportViewer5.LocalReport.Refresh()
                End Select
            Catch ex As Exception

            Finally

            End Try
        End If
    End Sub

End Class