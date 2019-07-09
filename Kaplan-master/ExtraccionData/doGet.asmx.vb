Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports System.ComponentModel
Imports System.Web.Script.Serialization
Imports ExtraccionData.Clases

' Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente.
' <System.Web.Script.Services.ScriptService()> _
<System.Web.Services.WebService(Namespace:="http://tempuri.org/")> _
<System.Web.Services.WebServiceBinding(ConformsTo:=WsiProfiles.BasicProfile1_1)> _
<ToolboxItem(False)> _
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
    Public Function getConsulta() As String
        Dim vList As List(Of Consulta) = Consulta.getListado()
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
    Public Function getConsultaErgo() As String
        Dim vList As List(Of ConsultaErgo) = ConsultaErgo.getListado()
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
    Public Function getConsultaMaquinaKine() As String
        Dim vList As List(Of ConsultaMaquinasKine) = ConsultaMaquinasKine.getListado()
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
    Public Function getConsultaMaquinaKineTread() As String
        Dim vList As List(Of ConsultaMaquinaKineTread) = ConsultaMaquinaKineTread.getListado()
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
    Public Function getConsultaMaquinaKineCons() As String
        Dim vList As List(Of ConsultaMaquinaKineCons) = ConsultaMaquinaKineCons.getListado()
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
    Public Function getConsultaMaquinaKineImpu() As String
        Dim vList As List(Of ConsultaMaquinaKineImpu) = ConsultaMaquinaKineImpu.getListado()
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
End Class