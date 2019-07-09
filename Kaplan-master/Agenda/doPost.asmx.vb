Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports System.ComponentModel
Imports System.Web.Script.Serialization
Imports Agenda.Clases

' Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente.
' <System.Web.Script.Services.ScriptService()> _
<System.Web.Services.WebService(Namespace:="http://tempuri.org/")> _
<System.Web.Services.WebServiceBinding(ConformsTo:=WsiProfiles.BasicProfile1_1)>
<ToolboxItem(False)>
Public Class doPost1
    Inherits System.Web.Services.WebService

    <WebMethod(EnableSession:=True)>
    Public Function registrarPaciente() As String
        Dim js As New JavaScriptSerializer

        Dim vPaciente As Paciente = js.Deserialize(Context.Request.Form("paciente"), GetType(Paciente))
        Dim vResult As New httpResult

        If vPaciente.registrarPaciente() Then
            vResult.result = True
        Else
            vResult.result = False
            vResult.message = "Error guardando registro"
        End If

        Context.Response.Write(js.Serialize(vResult))
        Context.Response.End()

        Return ""
    End Function
    <WebMethod(EnableSession:=True)>
    Public Function registrarEspecialista() As String
        Dim js As New JavaScriptSerializer

        Dim vEspecialista As Especialista = js.Deserialize(Context.Request.Form("especialista"), GetType(Especialista))
        Dim vResult As New httpResult

        If vEspecialista.registrarEspecialista() Then
            '  If vEspecialista.enviarCorreo("jonathan.rojas.roco@gmail.com", "jrojas", "jr.1569") Then
            vResult.result = True
        Else
            vResult.result = False
            vResult.message = "Error guardando registro"
        End If

        Context.Response.Write(js.Serialize(vResult))
        Context.Response.End()

        Return ""
    End Function
    <WebMethod(EnableSession:=True)>
    Public Function registrarAusencia() As String
        Dim js As New JavaScriptSerializer

        Dim vAusencia As Ausencia = js.Deserialize(Context.Request.Form("ausencia"), GetType(Ausencia))
        Dim vResult As New httpResult

        If vAusencia.registrarAusencia() Then
            vResult.result = True
        Else
            vResult.result = False
            vResult.message = "Error guardando registro"
        End If

        Context.Response.Write(js.Serialize(vResult))
        Context.Response.End()

        Return ""
    End Function
    <WebMethod(EnableSession:=True)>
    Public Function EliminarAusencia() As String
        Dim js As New JavaScriptSerializer

        Dim vAusencia As Ausencia = js.Deserialize(Context.Request.Form("ausencia"), GetType(Ausencia))
        Dim vResult As New httpResult

        If vAusencia.eliminarAusencia() Then
            vResult.result = True
        Else
            vResult.result = False
            vResult.message = "Error eliminando registro"
        End If

        Context.Response.Write(js.Serialize(vResult))
        Context.Response.End()

        Return ""
    End Function
    <WebMethod(EnableSession:=True)>
    Public Function registrarAtencionHora() As String
        Dim js As New JavaScriptSerializer

        Dim vAtencionHora As AtencionHora = js.Deserialize(Context.Request.Form("AtencionHora"), GetType(AtencionHora))
        Dim vResult As New httpResult

        If vAtencionHora.registrarAtencionHora() Then
            vResult.result = True
        Else
            vResult.result = False
            vResult.message = "Error guardando registro"
        End If

        Context.Response.Write(js.Serialize(vResult))
        Context.Response.End()

        Return ""
    End Function
    <WebMethod(EnableSession:=True)>
    Public Function EliminarAtencionHora() As String
        Dim js As New JavaScriptSerializer

        Dim vAtencionHora As AtencionHora = js.Deserialize(Context.Request.Form("AtencionHora"), GetType(AtencionHora))
        Dim vResult As New httpResult

        If vAtencionHora.EliminarAtencionHora() Then
            vResult.result = True
        Else
            vResult.result = False
            vResult.message = "Error eliminando registro"
        End If

        Context.Response.Write(js.Serialize(vResult))
        Context.Response.End()

        Return ""
    End Function
    <WebMethod(EnableSession:=True)>
    Public Function registrarReserva() As String
        Dim js As New JavaScriptSerializer

        Dim vReserva As Reserva = js.Deserialize(Context.Request.Form("Reserva"), GetType(Reserva))
        Dim vResult As New httpResult
        Dim resultado As Integer = vReserva.registrarReserva()
        If resultado = 1 Then
            vResult.result = True
        ElseIf resultado = 2 Then
            vResult.result = False
            vResult.message = "Especialista no atiende en este horario"
        ElseIf resultado = 3 Then
            vResult.result = False
            vResult.message = "Ya existe una reserva con estos datos"
        ElseIf resultado = 4 Then
            vResult.result = False
            vResult.message = "Especialista estará ausente en este horario"
        Else
            vResult.result = False
            vResult.message = "Error guardando registro"
        End If

        Context.Response.Write(js.Serialize(vResult))
        Context.Response.End()

        Return ""
    End Function
    <WebMethod(EnableSession:=True)>
    Public Function registrarLicencia() As String
        Dim js As New JavaScriptSerializer

        Dim vReserva As Licencia = js.Deserialize(Context.Request.Form("Licencia"), GetType(Licencia))
        Dim vResult As New httpResult

        If vReserva.registrarLicencia() Then
            vResult.result = True
        Else
            vResult.result = False
            vResult.message = "Error guardando registro"
        End If

        Context.Response.Write(js.Serialize(vResult))
        Context.Response.End()

        Return ""
    End Function
    <WebMethod(EnableSession:=True)>
    Public Function anularReserva() As String
        Dim js As New JavaScriptSerializer

        Dim vReserva As Reserva = js.Deserialize(Context.Request.Form("Reserva"), GetType(Reserva))
        Dim vResult As New httpResult

        If vReserva.anularReserva() Then
            vResult.result = True
        Else
            vResult.result = False
            vResult.message = "Error guardando registro"
        End If

        Context.Response.Write(js.Serialize(vResult))
        Context.Response.End()

        Return ""
    End Function
    <WebMethod(EnableSession:=True)>
    Public Function registrarObservacion() As String
        Dim js As New JavaScriptSerializer

        Dim vReserva As Reserva = js.Deserialize(Context.Request.Form("Reserva"), GetType(Reserva))
        Dim vResult As New httpResult

        If vReserva.registrarObservacion() Then
            vResult.result = True
        Else
            vResult.result = False
            vResult.message = "Error guardando registro"
        End If

        Context.Response.Write(js.Serialize(vResult))
        Context.Response.End()

        Return ""
    End Function
    <WebMethod(EnableSession:=True)>
    Public Function getIngresar() As String
        Dim js As New JavaScriptSerializer

        Dim vUsuario As Usuario = js.Deserialize(Context.Request.Form("Usuario"), GetType(Usuario))
        Dim vResult As New httpResult

        Dim vResultado = vUsuario.Login()

        If vResultado = 1 Then
            vResult.result = False
            vResult.message = "Usuario incorrecto o inactivo"
        ElseIf vResultado = 2 Then
            vResult.result = False
            vResult.message = "Contraseña incorrecta"
        ElseIf vResultado = 0 Then
            vResult.result = True
        Else
            vResult.result = False
            vResult.message = "Error en llamado al procedimiento"
        End If

        Context.Response.Write(js.Serialize(vResult))
        Context.Response.End()

        Return ""
    End Function
    <WebMethod(EnableSession:=True)>
    Public Function registrarPlan() As String
        Dim js As New JavaScriptSerializer

        Dim vPlan As Plan = js.Deserialize(Context.Request.Form("Plan"), GetType(Plan))
        Dim vResult As New httpResult

        If vPlan.registrarPlan() Then
            vResult.result = True
        Else
            vResult.result = False
            vResult.message = "Error guardando registro"
        End If

        Context.Response.Write(js.Serialize(vResult))
        Context.Response.End()

        Return ""
    End Function
    <WebMethod(EnableSession:=True)>
    Public Function finalizarPlan() As String
        Dim js As New JavaScriptSerializer

        Dim vPlan As Plan = js.Deserialize(Context.Request.Form("Plan"), GetType(Plan))
        Dim vResult As New httpResult

        If vPlan.finalizarPlan() Then
            vResult.result = True
        Else
            vResult.result = False
            vResult.message = "Error guardando registro"
        End If

        Context.Response.Write(js.Serialize(vResult))
        Context.Response.End()

        Return ""
    End Function
    <WebMethod(EnableSession:=True)>
    Public Function registrarMotivoCierrePlan() As String
        Dim js As New JavaScriptSerializer

        Dim vMotivoCierrePlan As MotivoCierrePlan = js.Deserialize(Context.Request.Form("MotivoCierre"), GetType(MotivoCierrePlan))
        Dim vResult As New httpResult

        If vMotivoCierrePlan.registrarMotivo() Then
            vResult.result = True
        Else
            vResult.result = False
            vResult.message = "Error eliminando registro"
        End If

        Context.Response.Write(js.Serialize(vResult))
        Context.Response.End()

        Return ""
    End Function
    <WebMethod(EnableSession:=True)>
    Public Function EliminarMotivoCierrePlan() As String
        Dim js As New JavaScriptSerializer

        Dim vMotivoCierrePlan As MotivoCierrePlan = js.Deserialize(Context.Request.Form("MotivoCierre"), GetType(MotivoCierrePlan))
        Dim vResult As New httpResult

        If vMotivoCierrePlan.eliminarMotivo() Then
            vResult.result = True
        Else
            vResult.result = False
            vResult.message = "Error eliminando registro"
        End If

        Context.Response.Write(js.Serialize(vResult))
        Context.Response.End()

        Return ""
    End Function
End Class