Imports Agenda.Classes
Public Class VerDocumentoCsv
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim strFileName As String = System.IO.Path.GetRandomFileName()
        Dim strName As String = ""
        Dim strPath As String = ""

        Dim vReporte As New Reporte

        Select Case Request("tipo")

            Case "ReporteMasivo"

                strPath = Server.MapPath("tmp/" + strFileName + ".txt")
                Dim fec As Date = Date.Now
                If Request("prmRut") = 0 Then
                    strName = "Reporte Masivo.csv"
                Else
                    strName = "Reporte " & Request("prmRut") & ".csv"
                End If
                Dim tbl As DataTable = vReporte.getReporteMasivo(Request("prmRut"))
                Dim l As String = ""
                Using sw As New System.IO.StreamWriter(strPath, False, System.Text.Encoding.GetEncoding(1252))
                    l = "Rut Pac.;Dv. Pac.;Nombre Pac.;Ap. Pat. Pac.;Ap. Mat. Pac.;" &
                        "Nro Res.;Fecha Res.;Hora Res.;Tipo Res.;Obs. Esp. Res.;Estado Res.;Obs. Est. Reserva;" &
                        "Rut Esp.;Dv. Esp.;Nombre Esp.;Ap. Pat. Esp.;Ap. Mat. Esp.;Especialidad;" &
                        "Nro Plan; Nombre Plan; Cant. Sesiones; Descripcion Plan; Estado Plan;"
                    sw.WriteLine(l)
                    If Not IsNothing(tbl) Then
                        For Each row As DataRow In tbl.Rows
                            l = row.Item("rut_paciente") & ";" & row.Item("dv_paciente") & ";" & row.Item("nombre_paciente") & ";" & row.Item("apellido_paterno_paciente") & ";" & row.Item("apellido_materno_paciente") _
                                & ";" & row.Item("numero_reserva") & ";" & row.Item("fecha_reserva") & ";" & row.Item("hora_reserva") & ";" & row.Item("tipo_reserva") & ";" & row.Item("obsEspecial_reserva") & ";" & row.Item("estado_reserva") & ";" & row.Item("observacion_estado") _
                                & ";" & row.Item("rut_especialista") & ";" & row.Item("dv_especialista") & ";" & row.Item("nombre_especialista") & ";" & row.Item("apellido_paterno_especialista") & ";" & row.Item("apellido_materno_especialista") & ";" & row.Item("especialidad") _
                                & ";" & row.Item("numero_plan") & ";" & row.Item("nombre_plan") & ";" & row.Item("cantidad_sesiones") & ";" & row.Item("descripcion_plan") & ";" & row.Item("estado_plan")
                            sw.WriteLine(l)
                        Next row
                    End If
                    sw.Close()
                End Using
        End Select

        Response.ClearContent()
        Response.ContentType = "text/plain"
        Response.AddHeader("content-disposition", "attachment; filename=" & strName)
        Response.WriteFile(strPath)
        Response.Flush()
        Response.End()
    End Sub

End Class