Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports System.ComponentModel
Imports System.Web.Script.Serialization
Imports Kaplan.Clases
Imports Kaplan.Tipos

' Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente.
' <System.Web.Script.Services.ScriptService()> _
<System.Web.Services.WebService(Namespace:="http://tempuri.org/")>
<System.Web.Services.WebServiceBinding(ConformsTo:=WsiProfiles.BasicProfile1_1)>
<ToolboxItem(False)>
Public Class doGet
    Inherits System.Web.Services.WebService
#Region "Generales"
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
    Public Function getPlanesxRut(intRut As Integer) As String
        Dim vPlan As List(Of Plan) = Plan.getPlanesxRut(intRut)
        Dim js As New JavaScriptSerializer
        Dim vResult As New httpResult

        If Not IsNothing(vPlan) Then
            vResult.result = True
            vResult.data = vPlan
        Else
            vResult.result = False
            vResult.data = vPlan
        End If
        Context.Response.Write(js.Serialize(vResult))

        Context.Response.End()
        Return ""
    End Function
    <WebMethod(EnableSession:=True)>
    Public Function getSesionesxPlan(intPlan As Integer, intEspecialidad As Integer) As String
        Dim vSesiones As List(Of Sesion) = Sesion.getSesionxPlan(intPlan, intEspecialidad)
        Dim js As New JavaScriptSerializer
        Dim vResult As New httpResult

        If Not IsNothing(vSesiones) Then
            vResult.result = True
            vResult.data = vSesiones
        Else
            vResult.result = False
            vResult.data = vSesiones
        End If
        Context.Response.Write(js.Serialize(vResult))

        Context.Response.End()
        Return ""
    End Function
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
    Public Function getExamenes(inRut As Integer) As String
        Dim vList As List(Of Examen) = Examen.getExamenes(inRut)
        Dim js As New JavaScriptSerializer
        Dim vResult As New httpResult

        If Not IsNothing(vList) Then
            vResult.result = True
            vResult.data = vList
        Else
            vResult.result = False
            vResult.data = vList
        End If
        Context.Response.Write(js.Serialize(vResult))

        Context.Response.End()
        Return ""
    End Function
    <WebMethod(EnableSession:=True)>
    Public Function getArchivos(inRut As Integer) As String
        Dim vList As List(Of Archivo) = Archivo.getArchivos(inRut)
        Dim js As New JavaScriptSerializer
        Dim vResult As New httpResult

        If Not IsNothing(vList) Then
            vResult.result = True
            vResult.data = vList
        Else
            vResult.result = False
            vResult.data = vList
        End If
        Context.Response.Write(js.Serialize(vResult))

        Context.Response.End()
        Return ""
    End Function
    <WebMethod(EnableSession:=True)>
    Public Function getRegistrosMedicos(inRut As Integer) As String
        Dim vList As List(Of RegistroMedico) = RegistroMedico.getRegistrosMedicos(inRut)
        Dim js As New JavaScriptSerializer
        Dim vResult As New httpResult

        If Not IsNothing(vList) Then
            vResult.result = True
            vResult.data = vList
        Else
            vResult.result = False
            vResult.data = vList
        End If
        Context.Response.Write(js.Serialize(vResult))

        Context.Response.End()
        Return ""
    End Function

#End Region
#Region "Kinesiología"
    <WebMethod(EnableSession:=True)>
    Public Function getFichaKinesiologiasxReserva(intReserva As Integer) As String

        Dim NoData As Boolean
        Dim vficha As Ficha = Ficha.getFichaKinesiologia(intReserva, NoData)
        Dim js As New JavaScriptSerializer
        Dim vResult As New httpResult

        If Not IsNothing(vficha) Then
            vResult.result = True
            vResult.data = vficha
        Else
            If NoData Then
                vResult.errorcode = 404
            Else
                vResult.errorcode = 202
            End If
            vResult.result = False
            vResult.data = vficha
        End If
        Context.Response.Write(js.Serialize(vResult))

        Context.Response.End()
        Return ""
    End Function
#End Region
#Region "Psicología"
    <WebMethod(EnableSession:=True)>
    Public Function getFichaPsicologiasReserva(intReserva As Integer) As String

        Dim NoData As Boolean
        Dim vficha As Ficha = Ficha.getFichaPsicologia(intReserva, NoData)
        Dim js As New JavaScriptSerializer
        Dim vResult As New httpResult

        If Not IsNothing(vficha) Then
            vResult.result = True
            vResult.data = vficha
        Else
            If NoData Then
                vResult.errorcode = 404
            Else
                vResult.errorcode = 202
            End If
            vResult.result = False
            vResult.data = vficha
        End If
        Context.Response.Write(js.Serialize(vResult))

        Context.Response.End()
        Return ""
    End Function
#End Region
#Region "Enfermería"
    <WebMethod(EnableSession:=True)>
    Public Function getFichaEnfermeriaxReserva(intReserva As Integer) As String

        Dim NoData As Boolean
        Dim vficha As Ficha = Ficha.getFichaEnfermeria(intReserva, NoData)
        Dim js As New JavaScriptSerializer
        Dim vResult As New httpResult

        If Not IsNothing(vficha) Then
            vResult.result = True
            vResult.data = vficha
        Else
            If NoData Then
                vResult.errorcode = 404
            Else
                vResult.errorcode = 202
            End If
            vResult.result = False
            vResult.data = vficha
        End If
        Context.Response.Write(js.Serialize(vResult))

        Context.Response.End()
        Return ""
    End Function
#End Region
#Region "Nutrición"
    <WebMethod(EnableSession:=True)>
    Public Function getFichaNutricionReserva(intReserva As Integer) As String

        Dim NoData As Boolean
        Dim vficha As Ficha = Ficha.getFichaNutricion(intReserva, NoData)
        Dim js As New JavaScriptSerializer
        Dim vResult As New httpResult

        If Not IsNothing(vficha) Then
            vResult.result = True
            vResult.data = vficha
        Else
            If NoData Then
                vResult.errorcode = 404
            Else
                vResult.errorcode = 202
            End If
            vResult.result = False
            vResult.data = vficha
        End If
        Context.Response.Write(js.Serialize(vResult))

        Context.Response.End()
        Return ""
    End Function
#End Region
#Region "Médico"
    <WebMethod(EnableSession:=True)>
    Public Function getFichaMedicoxReserva(intReserva As Integer) As String

        Dim NoData As Boolean
        Dim vficha As Ficha = Ficha.getFichaMedico(intReserva, NoData)
        Dim js As New JavaScriptSerializer
        Dim vResult As New httpResult

        If Not IsNothing(vficha) Then
            vResult.result = True
            vResult.data = vficha
        Else
            If NoData Then
                vResult.errorcode = 404
            Else
                vResult.errorcode = 202
            End If
            vResult.result = False
            vResult.data = vficha
        End If
        Context.Response.Write(js.Serialize(vResult))

        Context.Response.End()
        Return ""
    End Function
#End Region
#Region "Tipos"
#Region "Tipos Antecedentes"
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
#End Region
#Region "Tipos Kinesiología"
    <WebMethod(EnableSession:=True)>
    Public Function getTipoObjetivoKine() As String
        Dim vTipos As List(Of TipoObjetivoKine) = TipoObjetivoKine.getTipos
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
    Public Function getTipoDiagnosticoKine() As String
        Dim vTipos As List(Of TipoDiagnosticoKine) = TipoDiagnosticoKine.getTipos
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
#Region "Tipos Psicología"
    <WebMethod(EnableSession:=True)>
    Public Function getTipoSintomatologia() As String
        Dim vTipos As List(Of TipoSintomatologia) = TipoSintomatologia.getTipos
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
    Public Function getTipoDerivacionAPS() As String
        Dim vTipos As List(Of TipoDerivacionAPS) = TipoDerivacionAPS.getTipos
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
    Public Function getTipoApoyoSocial() As String
        Dim vTipos As List(Of TipoApoyoSocial) = TipoApoyoSocial.getTipos
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
    Public Function getTipoProblemaPsicosocial() As String
        Dim vTipos As List(Of TipoProblemaPsicosocial) = TipoProblemaPsicosocial.getTipos
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
    Public Function getTipoRasgoPersonalidad() As String
        Dim vTipos As List(Of TipoRasgoPersonalidad) = TipoRasgoPersonalidad.getTipos
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
    Public Function getTipoTrastornoMental() As String
        Dim vTipos As List(Of TipoTrastornoMental) = TipoTrastornoMental.getTipos
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
    Public Function getTipoTraumaPostOp() As String
        Dim vTipos As List(Of TipoTraumaPostOp) = TipoTraumaPostOp.getTipos
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
    Public Function getTipoConcienciaFactor() As String
        Dim vTipos As List(Of TipoConcienciaFactor) = TipoConcienciaFactor.getTipos
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
    Public Function getTipoDificultadResp() As String
        Dim vTipos As List(Of TipoDificultadResp) = TipoDificultadResp.getTipos
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
    Public Function getTipoIngresoTaller() As String
        Dim vTipos As List(Of TipoIngresoTaller) = TipoIngresoTaller.getTipos
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
    Public Function getTipoTratamiento() As String
        Dim vTipos As List(Of TipoTratamiento) = TipoTratamiento.getTipos
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
#Region "Tipos Enfermería"
    <WebMethod(EnableSession:=True)>
    Public Function getTipoAbdomenA() As String
        Dim vTipos As List(Of TipoAbdomenA) = TipoAbdomenA.getTipos
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
    Public Function getTipoAbdomenB() As String
        Dim vTipos As List(Of TipoAbdomenB) = TipoAbdomenB.getTipos
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
    Public Function getTipoActividadLaboral() As String
        Dim vTipos As List(Of TipoActividadLaboral) = TipoActividadLaboral.getTipos
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
    Public Function getTipoActividadRecreativa() As String
        Dim vTipos As List(Of TipoActividadRecreativa) = TipoActividadRecreativa.getTipos
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
    Public Function getTipoAdherenciaFarma() As String
        Dim vTipos As List(Of TipoAdherenciaFarma) = TipoAdherenciaFarma.getTipos
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
    Public Function getTipoAF() As String
        Dim vTipos As List(Of TipoAF) = TipoAF.getTipos
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
    Public Function getTipoAgua() As String
        Dim vTipos As List(Of TipoAgua) = TipoAgua.getTipos
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
    Public Function getTipoBebNec() As String
        Dim vTipos As List(Of TipoBebNec) = TipoBebNec.getTipos
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
    Public Function getTipoCabeza() As String
        Dim vTipos As List(Of TipoCabeza) = TipoCabeza.getTipos
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
    Public Function getTipoCuello() As String
        Dim vTipos As List(Of TipoCuello) = TipoCuello.getTipos
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
    Public Function getTipoDeposicion() As String
        Dim vTipos As List(Of TipoDeposicion) = TipoDeposicion.getTipos
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
    Public Function getTipoDiuresis() As String
        Dim vTipos As List(Of TipoDiuresis) = TipoDiuresis.getTipos
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
    Public Function getTipoDLP() As String
        Dim vTipos As List(Of TipoDLP) = TipoDLP.getTipos
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
    Public Function getTipoDM() As String
        Dim vTipos As List(Of TipoDM) = TipoDM.getTipos
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
    Public Function getTipoEEII() As String
        Dim vTipos As List(Of TipoEEII) = TipoEEII.getTipos
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
    Public Function getTipoEESS() As String
        Dim vTipos As List(Of TipoEESS) = TipoEESS.getTipos
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
    Public Function getTipoEstadoAnimo() As String
        Dim vTipos As List(Of TipoEstadoAnimo) = TipoEstadoAnimo.getTipos
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
    Public Function getTipoEstres() As String
        Dim vTipos As List(Of TipoEstres) = TipoEstres.getTipos
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
    Public Function getTipoFrutaVerdura() As String
        Dim vTipos As List(Of TipoFrutaVerdura) = TipoFrutaVerdura.getTipos
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
    Public Function getTipoGrasas() As String
        Dim vTipos As List(Of TipoGrasas) = TipoGrasas.getTipos
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
    Public Function getTipoHTA() As String
        Dim vTipos As List(Of TipoHTA) = TipoHTA.getTipos
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
    Public Function getTipoLlenCap() As String
        Dim vTipos As List(Of TipoLlenCap) = TipoLlenCap.getTipos
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
    Public Function getTipoMotivacion() As String
        Dim vTipos As List(Of TipoMotivacion) = TipoMotivacion.getTipos
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
    Public Function getTipoOH() As String
        Dim vTipos As List(Of TipoOH) = TipoOH.getTipos
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
    Public Function getTipoPatronRespiratorio() As String
        Dim vTipos As List(Of TipoPatronRespiratorio) = TipoPatronRespiratorio.getTipos
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
    Public Function getTipoRegimenHiposodico() As String
        Dim vTipos As List(Of TipoRegimenHiposodico) = TipoRegimenHiposodico.getTipos
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
    Public Function getTipoSED() As String
        Dim vTipos As List(Of TipoSED) = TipoSED.getTipos
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
    Public Function getTipoSPOB() As String
        Dim vTipos As List(Of TipoSPOB) = TipoSPOB.getTipos
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
    Public Function getTipoSuenoNocturnoA() As String
        Dim vTipos As List(Of TipoSuenoNocturnoA) = TipoSuenoNocturnoA.getTipos
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
    Public Function getTipoSuenoNocturnoB() As String
        Dim vTipos As List(Of TipoSuenoNocturnoB) = TipoSuenoNocturnoB.getTipos
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
    Public Function getTipoSuenoNocturnoC() As String
        Dim vTipos As List(Of TipoSuenoNocturnoC) = TipoSuenoNocturnoC.getTipos
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
    Public Function getTipoTB() As String
        Dim vTipos As List(Of TipoTB) = TipoTB.getTipos
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
    Public Function getTipoTBA() As String
        Dim vTipos As List(Of TipoTBA) = TipoTBA.getTipos
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
    Public Function getTipoTBB() As String
        Dim vTipos As List(Of TipoTBB) = TipoTBB.getTipos
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
    Public Function getTipoToraxA() As String
        Dim vTipos As List(Of TipoToraxA) = TipoToraxA.getTipos
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
    Public Function getTipoToraxB() As String
        Dim vTipos As List(Of TipoToraxB) = TipoToraxB.getTipos
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
    Public Function getTipoToraxC() As String
        Dim vTipos As List(Of TipoToraxC) = TipoToraxC.getTipos
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
    Public Function getTipoToraxD() As String
        Dim vTipos As List(Of TipoToraxD) = TipoToraxD.getTipos
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
    Public Function getTipoValoracion() As String
        Dim vTipos As List(Of TipoValoracion) = TipoValoracion.getTipos
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
    Public Function getTipoDiagnosticoEnfermeria() As String
        Dim vTipos As List(Of TipoDiagnosticoEnfermeria) = TipoDiagnosticoEnfermeria.getTipos
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
    Public Function getTipoIndicador() As String
        Dim vTipos As List(Of TipoIndicador) = TipoIndicador.getTipos
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
    Public Function getTipoIntervencion() As String
        Dim vTipos As List(Of TipoIntervencion) = TipoIntervencion.getTipos
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
#Region "Tipos Nutrición"
    <WebMethod(EnableSession:=True)>
    Public Function getTipoAlergiaAlimentaria() As String
        Dim vTipos As List(Of TipoAlergiaAlimentaria) = TipoAlergiaAlimentaria.getTipos
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
    Public Function getTipoApetito() As String
        Dim vTipos As List(Of TipoApetito) = TipoApetito.getTipos
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
    Public Function getTipoAversionAlimentaria() As String
        Dim vTipos As List(Of TipoAversionAlimentaria) = TipoAversionAlimentaria.getTipos
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
    Public Function getTipoAzucar() As String
        Dim vTipos As List(Of TipoAzucar) = TipoAzucar.getTipos
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
    Public Function getTipoCarne() As String
        Dim vTipos As List(Of TipoCarne) = TipoCarne.getTipos
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
    Public Function getTipoCribaje() As String
        Dim vTipos As List(Of TipoCribaje) = TipoCribaje.getTipos
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
    Public Function getTipoFruta() As String
        Dim vTipos As List(Of TipoFruta) = TipoFruta.getTipos
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
    Public Function getTipoIntoleranciaAlimentaria() As String
        Dim vTipos As List(Of TipoIntolerenciaAlimentaria) = TipoIntolerenciaAlimentaria.getTipos
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
    Public Function getTipoLacteo() As String
        Dim vTipos As List(Of TipoLacteo) = TipoLacteo.getTipos
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
    Public Function getTipoLegumbre() As String
        Dim vTipos As List(Of TipoLegumbre) = TipoLegumbre.getTipos
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
    Public Function getTipoLiquido() As String
        Dim vTipos As List(Of TipoLiquido) = TipoLiquido.getTipos
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
    Public Function getTipoPescado() As String
        Dim vTipos As List(Of TipoPescado) = TipoPescado.getTipos
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
    Public Function getTipoPreferenciaAlimentaria() As String
        Dim vTipos As List(Of TipoPreferenciaAlimentaria) = TipoPreferenciaAlimentaria.getTipos
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
    Public Function getTipoSodio() As String
        Dim vTipos As List(Of TipoSodio) = TipoSodio.getTipos
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
    Public Function getTipoSuplemento() As String
        Dim vTipos As List(Of TipoSuplemento) = TipoSuplemento.getTipos
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
    Public Function getTipoVerdura() As String
        Dim vTipos As List(Of TipoVerdura) = TipoVerdura.getTipos
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
#Region "Tipos Médico"
    <WebMethod(EnableSession:=True)>
    Public Function getTipoRespuestaMedico() As String
        Dim vTipos As List(Of TipoRespuestaMedico) = TipoRespuestaMedico.getTipos
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
    Public Function getTipoAneurismaMedico() As String
        Dim vTipos As List(Of TipoAneurismaMedico) = TipoAneurismaMedico.getTipos
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
    Public Function getTipoDiseccionMedico() As String
        Dim vTipos As List(Of TipoDiseccionMedico) = TipoDiseccionMedico.getTipos
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
    Public Function getTipoEcocardiogramaMedico() As String
        Dim vTipos As List(Of TipoEcocardiogramaMedico) = TipoEcocardiogramaMedico.getTipos
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
    Public Function getTipoTumorMedico() As String
        Dim vTipos As List(Of TipoTumorMedico) = TipoTumorMedico.getTipos
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
    Public Function getTipoSeveridadMedico() As String
        Dim vTipos As List(Of TipoSeveridadMedico) = TipoSeveridadMedico.getTipos
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
    Public Function getTipoFeviMedico() As String
        Dim vTipos As List(Of TipoFeviMedico) = TipoFeviMedico.getTipos
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
#End Region
End Class