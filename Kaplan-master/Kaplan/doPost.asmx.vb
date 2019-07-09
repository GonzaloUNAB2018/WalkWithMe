Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports System.ComponentModel
Imports System.Web.Script.Serialization
Imports Kaplan.Clases

' Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente.
' <System.Web.Script.Services.ScriptService()> _
<System.Web.Services.WebService(Namespace:="http://tempuri.org/")> _
<System.Web.Services.WebServiceBinding(ConformsTo:=WsiProfiles.BasicProfile1_1)> _
<ToolboxItem(False)> _
Public Class doPost
    Inherits System.Web.Services.WebService
#Region "Generales"
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
#End Region
#Region "Examen"
    <WebMethod(EnableSession:=True)>
    Public Function registrarExamen() As String
        Dim js As New JavaScriptSerializer
        Dim formato As String
        Dim contenidoDoc() As Byte = Nothing

        Dim vExamen As Examen = js.Deserialize(Context.Request.Form("Examen"), GetType(Examen))
        Dim vDocumento As HttpPostedFile = Context.Request.Files("documento")

        If vDocumento IsNot Nothing Then
            formato = vDocumento.ContentType
            ReDim contenidoDoc(vDocumento.ContentLength)
            vDocumento.InputStream.Read(contenidoDoc, 0, vDocumento.ContentLength)
        End If

        Dim vResult As New httpResult
        If vDocumento IsNot Nothing Then
            If vExamen.registrarExamen(contenidoDoc, formato) Then
                vResult.result = True
            Else
                vResult.result = False
                vResult.errorcode = 1
                vResult.message = "Error guardando Examen"
            End If
        Else
            vResult.result = False
            vResult.errorcode = 1
            vResult.message = "Debe Seleccionar un documento"
        End If

        Context.Response.Write(js.Serialize(vResult))
        Context.Response.End()

        Return ""
    End Function
    <WebMethod(EnableSession:=True)>
    Public Function EliminarExamen() As String
        Dim js As New JavaScriptSerializer

        Dim v_Id As Integer = js.Deserialize(Context.Request.Form("ID"), GetType(Integer))
        Dim vExamen As New Examen
        Dim vResult As New httpResult
        If vExamen.EliminarExamen(v_Id) Then
            vResult.result = True
        Else
            vResult.result = False
            vResult.message = "Error eliminando registro"
        End If

        Context.Response.Write(js.Serialize(vResult))
        Context.Response.End()

        Return ""
    End Function

#End Region
#Region "Cargar Archivo Ergo"
    <WebMethod(EnableSession:=True)>
    Public Function registrarArchivo() As String
        Dim js As New JavaScriptSerializer
        Dim formato As String
        Dim Random As New Random()
        Dim numero As Integer = Random.Next(1, 10000)
        Dim vArchivo As Archivo = js.Deserialize(Context.Request.Form("carga"), GetType(Archivo))
        Dim vErgo As HttpPostedFile = Context.Request.Files("archivo")
        Dim contenido() As Byte = Nothing
        Dim extension As String = String.Empty
        If (InStr(vErgo.FileName.ToLower, ".xls") > 0) Then
            extension = ".xls"
        ElseIf (InStr(vErgo.FileName.ToLower, ".obj") > 0) Then
            extension = ".txt"
        End If
        ReDim contenido(vErgo.ContentLength)
        vErgo.InputStream.Read(contenido, 0, vErgo.ContentLength)
        Dim ruta As String = HttpContext.Current.Server.MapPath("~/archivo/archivo" + numero.ToString + extension)
        vErgo.SaveAs(ruta)
        Dim vResult As New httpResult

        Try
            If extension = ".xls" Then
                vResult.result = vArchivo.registrarArchivo(ruta, contenido)
                vResult.message = "Archivo sin el formato esperado"
            Else
                vResult.result = vArchivo.registrarArchivoTxt(ruta, contenido)
                vResult.message = "Archivo sin el formato esperado"
            End If
        Catch ex As Exception
            vResult.message = "Error cargando archivo"
        End Try

        Context.Response.Write(js.Serialize(vResult))
        Context.Response.End()

        Return ""
    End Function
#End Region
#Region "RegistroMedico"
    <WebMethod(EnableSession:=True)>
    Public Function registrarRegistroMedico() As String
        Dim js As New JavaScriptSerializer
        Dim vRegistro As RegistroMedico = js.Deserialize(Context.Request.Form("Registro"), GetType(RegistroMedico))

        Dim vResult As New httpResult
        If vRegistro.registrarRegistroMedico() Then
            vResult.result = True
        Else
            vResult.result = False
            vResult.message = "Error guardando Registro Medico"
        End If

        Context.Response.Write(js.Serialize(vResult))
        Context.Response.End()

        Return ""
    End Function
    <WebMethod(EnableSession:=True)>
    Public Function EliminarRegistroMedico() As String
        Dim js As New JavaScriptSerializer

        Dim v_Id As Integer = js.Deserialize(Context.Request.Form("ID"), GetType(Integer))
        Dim vRegistro As New RegistroMedico
        Dim vResult As New httpResult
        If vRegistro.EliminarRegistroMedico(v_Id) Then
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
    Public Function MarcarLeidoRegistroMedico() As String
        Dim js As New JavaScriptSerializer

        Dim v_Id As Integer = js.Deserialize(Context.Request.Form("ID"), GetType(Integer))
        Dim IdEspecialista As Integer = js.Deserialize(Context.Request.Form("IdEspecialista"), GetType(Integer))
        Dim vRegistro As New RegistroMedico
        Dim vResult As New httpResult
        If vRegistro.MarcarLeidoRegistroMedico(v_Id, IdEspecialista) Then
            vResult.result = True
        Else
            vResult.result = False
            vResult.message = "Error Cambiando estado a registro"
        End If

        Context.Response.Write(js.Serialize(vResult))
        Context.Response.End()

        Return ""
    End Function

#End Region
#Region "Kinesiología"
    <WebMethod(EnableSession:=True)>
    Public Function SaveFichaKinesiologia() As String
        Dim js As New JavaScriptSerializer

        Dim vFicha As Ficha = js.Deserialize(Context.Request.Form("Ficha"), GetType(Ficha))
        Dim vPaciente As Paciente = js.Deserialize(Context.Request.Form("paciente"), GetType(Paciente))
        Dim vResult As New httpResult
        If vPaciente.ModificarPaciente() Then
            If vFicha.registrarFichaKinesiologia() Then
                vResult.result = True
            Else
                vResult.result = False
                vResult.message = "Error guardando registro"
            End If
        Else
            vResult.result = False
            vResult.message = "Error guardando registro"
        End If

        Context.Response.Write(js.Serialize(vResult))
        Context.Response.End()

        Return ""
    End Function
#End Region
#Region "Psicología"
    <WebMethod(EnableSession:=True)>
    Public Function SaveFichaPsicologia() As String
        Dim js As New JavaScriptSerializer

        Dim vFicha As Ficha = js.Deserialize(Context.Request.Form("Ficha"), GetType(Ficha))
        Dim vPaciente As Paciente = js.Deserialize(Context.Request.Form("paciente"), GetType(Paciente))
        Dim vResult As New httpResult
        If vPaciente.ModificarPaciente() Then
            If vFicha.registrarFichaPsicologia() Then
                vResult.result = True
            Else
                vResult.result = False
                vResult.message = "Error guardando registro"
            End If
        Else
            vResult.result = False
            vResult.message = "Error guardando registro"
        End If

        Context.Response.Write(js.Serialize(vResult))
        Context.Response.End()

        Return ""
    End Function
#End Region
#Region "Enfermería"
    <WebMethod(EnableSession:=True)>
    Public Function SaveFichaEnfermeria() As String
        Dim js As New JavaScriptSerializer

        Dim vFicha As Ficha = js.Deserialize(Context.Request.Form("Ficha"), GetType(Ficha))
        Dim vPaciente As Paciente = js.Deserialize(Context.Request.Form("paciente"), GetType(Paciente))
        Dim vResult As New httpResult
        If vPaciente.ModificarPaciente() Then
            If vFicha.registrarFichaEnfermeria() Then
                vResult.result = True
            Else
                vResult.result = False
                vResult.message = "Error guardando registro"
            End If
        Else
            vResult.result = False
            vResult.message = "Error guardando registro"
        End If

        Context.Response.Write(js.Serialize(vResult))
        Context.Response.End()

        Return ""
    End Function
#End Region
#Region "Nutrición"
    <WebMethod(EnableSession:=True)>
    Public Function SaveFichaNutricion() As String
        Dim js As New JavaScriptSerializer

        Dim vFicha As Ficha = js.Deserialize(Context.Request.Form("Ficha"), GetType(Ficha))
        Dim vPaciente As Paciente = js.Deserialize(Context.Request.Form("paciente"), GetType(Paciente))
        Dim vResult As New httpResult
        If vPaciente.ModificarPaciente() Then
            If vFicha.registrarFichaNutricion() Then
                vResult.result = True
            Else
                vResult.result = False
                vResult.message = "Error guardando registro"
            End If
        Else
            vResult.result = False
            vResult.message = "Error guardando registro"
        End If

        Context.Response.Write(js.Serialize(vResult))
        Context.Response.End()

        Return ""
    End Function
#End Region
#Region "Médico"
    <WebMethod(EnableSession:=True)>
    Public Function SaveFichaMedico() As String
        Dim js As New JavaScriptSerializer

        Dim vFicha As Ficha = js.Deserialize(Context.Request.Form("Ficha"), GetType(Ficha))
        Dim vPaciente As Paciente = js.Deserialize(Context.Request.Form("paciente"), GetType(Paciente))
        Dim vResult As New httpResult
        If vPaciente.ModificarPaciente() Then
            If vFicha.registrarFichaMedico() Then
                vResult.result = True
            Else
                vResult.result = False
                vResult.message = "Error guardando registro"
            End If
        Else
            vResult.result = False
            vResult.message = "Error guardando registro"
        End If

        Context.Response.Write(js.Serialize(vResult))
        Context.Response.End()

        Return ""
    End Function
#End Region

End Class