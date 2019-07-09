Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports System.ComponentModel
Imports Agenda.Clases
Imports Agenda.Tipos
Imports System.Web.Script.Serialization

' Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente.
' <System.Web.Script.Services.ScriptService()> _
<System.Web.Services.WebService(Namespace:="http://tempuri.org/")>
<System.Web.Services.WebServiceBinding(ConformsTo:=WsiProfiles.BasicProfile1_1)>
<ToolboxItem(False)>
Public Class doGet
    Inherits System.Web.Services.WebService
    <WebMethod(EnableSession:=True)>
    Public Function getLogin(strUser As String) As String
        Dim NoData As Boolean
        Dim vUsuario As Usuario = Usuario.getUsuario(strUser)
        Dim js As New JavaScriptSerializer
        Dim vResult As New httpResult

        If Not IsNothing(vUsuario) Then
            vResult.result = True
            vResult.data = vUsuario
        Else
            vResult.result = False
        End If
        Context.Response.Write(js.Serialize(vResult))

        Context.Response.End()
        Return ""
    End Function
    <WebMethod(EnableSession:=True)>
    Public Function getCorreo(inEmail As String) As String
        Dim vResultado As Boolean = Usuario.getUsuarioEmail(inEmail)
        Dim js As New JavaScriptSerializer
        js.MaxJsonLength = Int32.MaxValue
        Dim vResult As New httpResult
        If vResultado Then
            vResult.result = True
            vResult.data = ""
        Else
            vResult.result = False
            vResult.message = "Email no válido"
        End If

        Context.Response.Write(js.Serialize(vResult))
        Context.Response.End()
        Return ""
    End Function
    <WebMethod(EnableSession:=True)>
    Public Function getResumenCalendario(ByVal inFecha As Date, ByVal inEspecialista As Integer) As String
        Dim msj As String
        Dim vListado As List(Of ResumenCalendario) = ResumenCalendario.getResumenCalendario(inFecha, inEspecialista)
        Dim js As New JavaScriptSerializer
        js.MaxJsonLength = Int32.MaxValue
        Dim vResult As New httpResult
        If Not IsNothing(vListado) Then
            vResult.result = True
            vResult.data = vListado
        Else
            vResult.result = False
            vResult.message = msj
        End If

        Context.Response.Write(js.Serialize(vResult))
        Context.Response.End()
        Return ""
    End Function
    <WebMethod(EnableSession:=True)>
    Public Function getReservasDiaHora(ByVal inFecha As Date, ByVal inDia As Integer, ByVal inHora As String) As String
        Dim NoData As Boolean
        Dim vListado As List(Of Reserva) = Reserva.getReservasDiaHora(inFecha, inDia, inHora)
        Dim js As New JavaScriptSerializer
        js.MaxJsonLength = Int32.MaxValue
        Dim vResult As New httpResult
        If Not IsNothing(vListado) Then
            vResult.result = True
            vResult.data = vListado
        Else
            vResult.result = False
        End If

        Context.Response.Write(js.Serialize(vResult))
        Context.Response.End()
        Return ""
    End Function
    <WebMethod(EnableSession:=True)>
    Public Function getReserva(ByVal inId As Integer) As String
        Dim vReserva As Reserva = Reserva.getReserva(inId)
        Dim js As New JavaScriptSerializer
        js.MaxJsonLength = Int32.MaxValue
        Dim vResult As New httpResult
        If Not IsNothing(vReserva) Then
            vResult.result = True
            vResult.data = vReserva
        Else
            vResult.result = False
        End If

        Context.Response.Write(js.Serialize(vResult))
        Context.Response.End()
        Return ""
    End Function
    <WebMethod(EnableSession:=True)>
    Public Function getLicencias(ByVal inRut As Integer) As String
        Dim NoData As Boolean
        Dim vListado As List(Of Licencia) = Licencia.getLicencias(inRut)
        Dim js As New JavaScriptSerializer
        js.MaxJsonLength = Int32.MaxValue
        Dim vResult As New httpResult
        If Not IsNothing(vListado) Then
            vResult.result = True
            vResult.data = vListado
        Else
            vResult.result = False
        End If

        Context.Response.Write(js.Serialize(vResult))
        Context.Response.End()
        Return ""
    End Function
    <WebMethod(EnableSession:=True)>
    Public Function getObservacion(ByVal inId As Integer) As String
        Dim vReserva As Reserva = Reserva.getObservacion(inId)
        Dim js As New JavaScriptSerializer
        js.MaxJsonLength = Int32.MaxValue
        Dim vResult As New httpResult
        If Not IsNothing(vReserva) Then
            vResult.result = True
            vResult.data = vReserva
        Else
            vResult.result = False
        End If

        Context.Response.Write(js.Serialize(vResult))
        Context.Response.End()
        Return ""
    End Function
    <WebMethod(EnableSession:=True)>
    Public Function getPlanes(ByVal inPaciente As Integer) As String
        Dim NoData As Boolean
        Dim vListado As List(Of Plan) = Plan.getPlanes(inPaciente)
        Dim js As New JavaScriptSerializer
        js.MaxJsonLength = Int32.MaxValue
        Dim vResult As New httpResult
        If Not IsNothing(vListado) Then
            vResult.result = True
            vResult.data = vListado
        Else
            vResult.result = False
        End If

        Context.Response.Write(js.Serialize(vResult))
        Context.Response.End()
        Return ""
    End Function
    <WebMethod(EnableSession:=True)>
    Public Function getPaciente(intRut As Integer, strPasaporte As String) As String
        Dim NoData As Boolean
        Dim vPaciente As Paciente = Paciente.getPaciente(intRut, strPasaporte, NoData)
        Dim js As New JavaScriptSerializer
        Dim vResult As New httpResult

        If Not IsNothing(vPaciente) Then
            vResult.result = True
            vResult.data = vPaciente
        Else
            If NoData Then
                vResult.errorcode = 404
            Else
                vResult.errorcode = 202
            End If
            vResult.result = False
            vResult.data = vPaciente
        End If
        Context.Response.Write(js.Serialize(vResult))

        Context.Response.End()
        Return ""
    End Function
    <WebMethod(EnableSession:=True)>
    Public Function getPacienteReserva(intRut As Integer, strPasaporte As String) As String
        Dim NoData As Boolean
        Dim vPaciente As Paciente = Paciente.getPacienteReserva(intRut, strPasaporte, NoData)
        Dim js As New JavaScriptSerializer
        Dim vResult As New httpResult

        If Not IsNothing(vPaciente) Then
            vResult.result = True
            vResult.data = vPaciente
        Else
            If NoData Then
                vResult.errorcode = 404
            Else
                vResult.errorcode = 202
            End If
            vResult.result = False
            vResult.data = vPaciente
        End If
        Context.Response.Write(js.Serialize(vResult))

        Context.Response.End()
        Return ""
    End Function
    <WebMethod(EnableSession:=True)>
    Public Function getEspecialistas() As String
        Dim msj As String
        Dim vListado As List(Of Especialista) = Especialista.getEspecialistas(msj)
        Dim js As New JavaScriptSerializer
        js.MaxJsonLength = Int32.MaxValue
        Dim vResult As New httpResult
        If Not IsNothing(vListado) Then
            vResult.result = True
            vResult.data = vListado
        Else
            vResult.result = False
            vResult.message = msj
        End If

        Context.Response.Write(js.Serialize(vResult))
        Context.Response.End()
        Return ""
    End Function
    <WebMethod(EnableSession:=True)>
    Public Function getEspecialistasEsp(inEspecialidad As Integer) As String
        Dim msj As String
        Dim vListado As List(Of Especialista) = Especialista.getEspecialistasEsp(inEspecialidad)
        Dim js As New JavaScriptSerializer
        js.MaxJsonLength = Int32.MaxValue
        Dim vResult As New httpResult
        If Not IsNothing(vListado) Then
            vResult.result = True
            vResult.data = vListado
        Else
            vResult.result = False
            vResult.message = msj
        End If

        Context.Response.Write(js.Serialize(vResult))
        Context.Response.End()
        Return ""
    End Function
    <WebMethod(EnableSession:=True)>
    Public Function getEspecialista(intRut As Integer, strPasaporte As String) As String
        Dim NoData As Boolean
        Dim vEspecialista As Especialista = Especialista.getEspecialista(intRut, strPasaporte, NoData)
        Dim js As New JavaScriptSerializer
        Dim vResult As New httpResult

        If Not IsNothing(vEspecialista) Then
            vResult.result = True
            vResult.data = vEspecialista
        Else
            If NoData Then
                vResult.errorcode = 404
            Else
                vResult.errorcode = 202
            End If
            vResult.result = False
            vResult.data = vEspecialista
        End If
        Context.Response.Write(js.Serialize(vResult))

        Context.Response.End()
        Return ""
    End Function
    <WebMethod(EnableSession:=True)>
    Public Function getEspecialistaAusencias(prmIdEspecialista As Integer) As String
        Dim msj As String
        Dim vListado As List(Of Ausencia) = Ausencia.getListadoAusencias(prmIdEspecialista, msj)
        Dim js As New JavaScriptSerializer
        js.MaxJsonLength = Int32.MaxValue
        Dim vResult As New httpResult
        If Not IsNothing(vListado) Then
            vResult.result = True
            vResult.data = vListado
        Else
            vResult.result = False
            vResult.message = msj
        End If

        Context.Response.Write(js.Serialize(vResult))
        Context.Response.End()
        Return ""
    End Function
    <WebMethod(EnableSession:=True)>
    Public Function getEspecialistaAtencionHoras(prmIdEspecialista As Integer) As String
        Dim msj As String
        Dim vListado As List(Of AtencionHora) = AtencionHora.getListadoAtencionesHoras(prmIdEspecialista, msj)
        Dim js As New JavaScriptSerializer
        js.MaxJsonLength = Int32.MaxValue
        Dim vResult As New httpResult
        If Not IsNothing(vListado) Then
            vResult.result = True
            vResult.data = vListado
        Else
            vResult.result = False
            vResult.message = msj
        End If

        Context.Response.Write(js.Serialize(vResult))
        Context.Response.End()
        Return ""
    End Function
    <WebMethod(EnableSession:=True)>
    Public Function getMotivosCierrePlan() As String
        Dim vListado As List(Of MotivoCierrePlan) = MotivoCierrePlan.getMotivosCierrePlan()
        Dim js As New JavaScriptSerializer
        js.MaxJsonLength = Int32.MaxValue
        Dim vResult As New httpResult
        If Not IsNothing(vListado) Then
            vResult.result = True
            vResult.data = vListado
        Else
            vResult.result = False
            vResult.message = "Error Listado Motivos Cierre Plan"
        End If

        Context.Response.Write(js.Serialize(vResult))
        Context.Response.End()
        Return ""
    End Function
    <WebMethod(EnableSession:=True)>
    Public Function getEstadisticaxReserva(ByVal inPaciente As Integer, ByVal inEspecialista As Integer) As String
        Dim vReserva As Reserva = Reserva.getEstadisticaxReserva(inPaciente, inEspecialista)
        Dim js As New JavaScriptSerializer
        js.MaxJsonLength = Int32.MaxValue
        Dim vResult As New httpResult
        If Not IsNothing(vReserva) Then
            vResult.result = True
            vResult.data = vReserva
        Else
            vResult.result = False
        End If

        Context.Response.Write(js.Serialize(vResult))
        Context.Response.End()
        Return ""
    End Function

#Region "Tipos"
    <WebMethod(EnableSession:=True)>
    Public Function getPacientesFiltro() As String
        Dim vTipos As List(Of TipoPacienteFiltro) = TipoPacienteFiltro.getTipos
        Dim js As New JavaScriptSerializer
        Dim vResult As New httpResult
        If Not IsNothing(vTipos) Then
            vResult.result = True
            vResult.data = vTipos
        Else
            vResult.result = False
            vResult.data = vTipos
        End If

        Context.Response.Write(js.Serialize(vResult))

        Context.Response.End()
        Return ""
    End Function
    <WebMethod(EnableSession:=True)>
    Public Function getTipoSexo() As String
        Dim vTipos As List(Of TipoSexo) = TipoSexo.getTipos
        Dim js As New JavaScriptSerializer
        Dim vResult As New httpResult
        If Not IsNothing(vTipos) Then
            vResult.result = True
            vResult.data = vTipos
        Else
            vResult.result = False
            vResult.data = vTipos
        End If

        Context.Response.Write(js.Serialize(vResult))

        Context.Response.End()
        Return ""
    End Function
    <WebMethod(EnableSession:=True)>
    Public Function getTipoEstadoCivil() As String
        Dim vTipos As List(Of TipoEstadoCivil) = TipoEstadoCivil.getTipos
        Dim js As New JavaScriptSerializer
        Dim vResult As New httpResult
        If Not IsNothing(vTipos) Then
            vResult.result = True
            vResult.data = vTipos
        Else
            vResult.result = False
            vResult.data = vTipos
        End If

        Context.Response.Write(js.Serialize(vResult))

        Context.Response.End()
        Return ""
    End Function
    <WebMethod(EnableSession:=True)>
    Public Function getTipoRegion() As String
        Dim vTipos As List(Of TipoRegion) = TipoRegion.getTipos
        Dim js As New JavaScriptSerializer
        Dim vResult As New httpResult
        If Not IsNothing(vTipos) Then
            vResult.result = True
            vResult.data = vTipos
        Else
            vResult.result = False
            vResult.data = vTipos
        End If

        Context.Response.Write(js.Serialize(vResult))

        Context.Response.End()
        Return ""
    End Function
    <WebMethod(EnableSession:=True)>
    Public Function getTipoComuna() As String
        Dim vTipos As List(Of TipoComuna) = TipoComuna.getTipos
        Dim js As New JavaScriptSerializer
        Dim vResult As New httpResult
        If Not IsNothing(vTipos) Then
            vResult.result = True
            vResult.data = vTipos
        Else
            vResult.result = False
            vResult.data = vTipos
        End If

        Context.Response.Write(js.Serialize(vResult))

        Context.Response.End()
        Return ""
    End Function
    <WebMethod(EnableSession:=True)>
    Public Function getTipoPais() As String
        Dim vTipos As List(Of TipoPais) = TipoPais.getTipos
        Dim js As New JavaScriptSerializer
        Dim vResult As New httpResult
        If Not IsNothing(vTipos) Then
            vResult.result = True
            vResult.data = vTipos
        Else
            vResult.result = False
            vResult.data = vTipos
        End If

        Context.Response.Write(js.Serialize(vResult))

        Context.Response.End()
        Return ""
    End Function
    <WebMethod(EnableSession:=True)>
    Public Function getTipoPrevision() As String
        Dim vTipos As List(Of TipoPrevision) = TipoPrevision.getTipos
        Dim js As New JavaScriptSerializer
        Dim vResult As New httpResult
        If Not IsNothing(vTipos) Then
            vResult.result = True
            vResult.data = vTipos
        Else
            vResult.result = False
            vResult.data = vTipos
        End If

        Context.Response.Write(js.Serialize(vResult))

        Context.Response.End()
        Return ""
    End Function
    <WebMethod(EnableSession:=True)>
    Public Function getTipoEspecialidad() As String
        Dim vTipos As List(Of TipoEspecialidad) = TipoEspecialidad.getTipos
        Dim js As New JavaScriptSerializer
        Dim vResult As New httpResult
        If Not IsNothing(vTipos) Then
            vResult.result = True
            vResult.data = vTipos
        Else
            vResult.result = False
            vResult.data = vTipos
        End If

        Context.Response.Write(js.Serialize(vResult))

        Context.Response.End()
        Return ""
    End Function
    <WebMethod(EnableSession:=True)>
    Public Function getTipoDias() As String
        Dim vTipos As List(Of TipoDia) = TipoDia.getTipos
        Dim js As New JavaScriptSerializer
        Dim vResult As New httpResult
        If Not IsNothing(vTipos) Then
            vResult.result = True
            vResult.data = vTipos
        Else
            vResult.result = False
            vResult.data = vTipos
        End If

        Context.Response.Write(js.Serialize(vResult))

        Context.Response.End()
        Return ""
    End Function
    <WebMethod(EnableSession:=True)>
    Public Function getTipoHoras() As String
        Dim vTipos As List(Of TipoHora) = TipoHora.getTipos
        Dim js As New JavaScriptSerializer
        Dim vResult As New httpResult
        If Not IsNothing(vTipos) Then
            vResult.result = True
            vResult.data = vTipos
        Else
            vResult.result = False
            vResult.data = vTipos
        End If

        Context.Response.Write(js.Serialize(vResult))

        Context.Response.End()
        Return ""
    End Function
    <WebMethod(EnableSession:=True)>
    Public Function getTipoAnulada() As String
        Dim vTipos As List(Of TipoAnulada) = TipoAnulada.getTipos
        Dim js As New JavaScriptSerializer
        Dim vResult As New httpResult
        If Not IsNothing(vTipos) Then
            vResult.result = True
            vResult.data = vTipos
        Else
            vResult.result = False
            vResult.data = vTipos
        End If

        Context.Response.Write(js.Serialize(vResult))

        Context.Response.End()
        Return ""
    End Function
    <WebMethod(EnableSession:=True)>
    Public Function getTipoNoRealizada() As String
        Dim vTipos As List(Of TipoNoRealizada) = TipoNoRealizada.getTipos
        Dim js As New JavaScriptSerializer
        Dim vResult As New httpResult
        If Not IsNothing(vTipos) Then
            vResult.result = True
            vResult.data = vTipos
        Else
            vResult.result = False
            vResult.data = vTipos
        End If

        Context.Response.Write(js.Serialize(vResult))

        Context.Response.End()
        Return ""
    End Function
    <WebMethod(EnableSession:=True)>
    Public Function getTipoMotivoPlan() As String
        Dim vTipos As List(Of TipoMotivoPlan) = TipoMotivoPlan.getTipos
        Dim js As New JavaScriptSerializer
        Dim vResult As New httpResult
        If Not IsNothing(vTipos) Then
            vResult.result = True
            vResult.data = vTipos
        Else
            vResult.result = False
            vResult.data = vTipos
        End If

        Context.Response.Write(js.Serialize(vResult))

        Context.Response.End()
        Return ""
    End Function
    <WebMethod(EnableSession:=True)>
    Public Function getTipoEstadoReserva() As String
        Dim vTipos As List(Of TipoEstadoReserva) = TipoEstadoReserva.getTipos
        Dim js As New JavaScriptSerializer
        Dim vResult As New httpResult
        If Not IsNothing(vTipos) Then
            vResult.result = True
            vResult.data = vTipos
        Else
            vResult.result = False
            vResult.data = vTipos
        End If

        Context.Response.Write(js.Serialize(vResult))

        Context.Response.End()
        Return ""
    End Function
    <WebMethod(EnableSession:=True)>
    Public Function getTipoEstadoPlan() As String
        Dim vTipos As List(Of TipoEstadoPlan) = TipoEstadoPlan.getTipos
        Dim js As New JavaScriptSerializer
        Dim vResult As New httpResult
        If Not IsNothing(vTipos) Then
            vResult.result = True
            vResult.data = vTipos
        Else
            vResult.result = False
            vResult.data = vTipos
        End If

        Context.Response.Write(js.Serialize(vResult))

        Context.Response.End()
        Return ""
    End Function
    <WebMethod(EnableSession:=True)>
    Public Function getTipoReserva() As String
        Dim vTipos As List(Of TipoReserva) = TipoReserva.getTipos
        Dim js As New JavaScriptSerializer
        Dim vResult As New httpResult
        If Not IsNothing(vTipos) Then
            vResult.result = True
            vResult.data = vTipos
        Else
            vResult.result = False
            vResult.data = vTipos
        End If

        Context.Response.Write(js.Serialize(vResult))

        Context.Response.End()
        Return ""
    End Function
#End Region

End Class