Imports Agenda.Clases
Imports System.Globalization
Imports System.Data.OleDb
Imports System.Data.SqlClient
Imports System.Net.Mail
Imports System.IO

Namespace Clases
    Public Class Especialista
        Public Property Id As Integer
        Public Property Estado As Integer
        Public Property Especialidad As Tipos.TipoEspecialidad
        Public Property Persona As Persona
        Public Shared Function getEspecialistas(ByRef msj As String) As List(Of Especialista)
            Try
                Dim conn As OleDbConnection = New OleDbConnection(ConfigurationManager.ConnectionStrings("ConexionKaplan").ConnectionString)
                Dim cmd As OleDbCommand = New OleDbCommand("Kaplan.ListadoEspecialistas", conn)
                cmd.CommandType = CommandType.StoredProcedure

                conn.Open()
                Dim adapter As OleDbDataAdapter = New OleDbDataAdapter(cmd)
                Dim vDataTable As New DataTable
                adapter.Fill(vDataTable)
                getEspecialistas = New List(Of Especialista)
                For Each vRow As DataRow In vDataTable.Rows
                    getEspecialistas.Add(Mapeo(vRow))
                Next
                conn.Close()
                Return getEspecialistas

            Catch exc As Exception
                msj = exc.ToString
            End Try

        End Function
        Public Shared Function getEspecialista(inRut As Integer, strPasaporte As String, ByRef NoData As Boolean) As Especialista
            Dim conn As OleDbConnection = New OleDbConnection(ConfigurationManager.ConnectionStrings("ConexionKaplan").ConnectionString)
            Dim cmd As OleDbCommand = New OleDbCommand("Kaplan.BuscarPersona", conn)
            cmd.CommandType = CommandType.StoredProcedure

            Dim Rut As OleDbParameter = cmd.Parameters.Add("@inRut", OleDbType.Decimal, Nothing)
            Rut.Direction = ParameterDirection.Input
            Rut.Value = inRut

            Dim Pasaporte As OleDbParameter = cmd.Parameters.Add("@inPasaporte", OleDbType.VarChar, 100)
            Pasaporte.Direction = ParameterDirection.Input
            Pasaporte.Value = strPasaporte

            Dim adapter As OleDbDataAdapter = New OleDbDataAdapter(cmd)
            Dim vDataTable As New DataTable
            adapter.Fill(vDataTable)

            For Each vRow As DataRow In vDataTable.Rows
                getEspecialista = Mapeo(vDataTable(0))
                NoData = False
            Next

            If vDataTable.Rows.Count = 0 Then NoData = True

            Return getEspecialista
        End Function
        Public Shared Function getEspecialistaId(inId As Integer) As Especialista
            Dim conn As OleDbConnection = New OleDbConnection(ConfigurationManager.ConnectionStrings("ConexionKaplan").ConnectionString)
            Dim cmd As OleDbCommand = New OleDbCommand("Kaplan.BuscarEspecialistaId", conn)
            cmd.CommandType = CommandType.StoredProcedure

            Dim Rut As OleDbParameter = cmd.Parameters.Add("@inId", OleDbType.Decimal, Nothing)
            Rut.Direction = ParameterDirection.Input
            Rut.Value = inId

            Dim adapter As OleDbDataAdapter = New OleDbDataAdapter(cmd)
            Dim vDataTable As New DataTable
            adapter.Fill(vDataTable)

            For Each vRow As DataRow In vDataTable.Rows
                getEspecialistaId = Mapeo(vDataTable(0))
            Next

            Return getEspecialistaId
        End Function
        Public Shared Function getEspecialistasEsp(ByRef inEspecialidad As Integer) As List(Of Especialista)
            Try
                Dim conn As OleDbConnection = New OleDbConnection(ConfigurationManager.ConnectionStrings("ConexionKaplan").ConnectionString)
                Dim cmd As OleDbCommand = New OleDbCommand("Kaplan.ListadoEspecialistasEsp", conn)
                cmd.CommandType = CommandType.StoredProcedure

                Dim Especialidad As OleDbParameter = cmd.Parameters.Add("@inEspecialidad", OleDbType.Integer, Nothing)
                Especialidad.Direction = ParameterDirection.Input
                Especialidad.Value = inEspecialidad

                conn.Open()
                Dim adapter As OleDbDataAdapter = New OleDbDataAdapter(cmd)
                Dim vDataTable As New DataTable
                adapter.Fill(vDataTable)
                getEspecialistasEsp = New List(Of Especialista)
                For Each vRow As DataRow In vDataTable.Rows
                    getEspecialistasEsp.Add(Mapeo(vRow))
                Next
                conn.Close()
                Return getEspecialistasEsp

            Catch exc As Exception
            End Try

        End Function
        Private Shared Function Mapeo(prmRow As DataRow) As Especialista
            Try
                Dim vEspecialista As New Especialista
                vEspecialista.Persona = New Persona
                vEspecialista.Id = IIf(prmRow("ID_ESPECIALISTA").Equals(DBNull.Value), -1, prmRow("ID_ESPECIALISTA"))
                vEspecialista.Estado = IIf(prmRow("ESTADO_ESPECIALISTA").Equals(DBNull.Value), -1, prmRow("ESTADO_ESPECIALISTA"))
                If Not prmRow("especialidad").Equals(DBNull.Value) Then vEspecialista.Especialidad = Tipos.TipoEspecialidad.getTipo(prmRow("especialidad")) Else vEspecialista.Especialidad = New Tipos.TipoEspecialidad
                vEspecialista.Persona.Id = prmRow("ID").ToString
                vEspecialista.Persona.Rut = prmRow("rut").ToString
                vEspecialista.Persona.Dv = prmRow("dv").ToString
                vEspecialista.Persona.Nombre = prmRow("nombres").ToString
                vEspecialista.Persona.Paterno = prmRow("paterno").ToString
                vEspecialista.Persona.Materno = prmRow("materno").ToString
                vEspecialista.Persona.FechaNac = prmRow("fecha_nac").ToString
                vEspecialista.Persona.Telefono = prmRow("telefono").ToString
                vEspecialista.Persona.Movil = prmRow("movil").ToString
                vEspecialista.Persona.Sexo = Tipos.TipoSexo.getTipo(prmRow("sexo"))
                vEspecialista.Persona.Email = prmRow("email").ToString
                Return vEspecialista

            Catch ex As Exception
                Return Nothing
            End Try
        End Function
        Public Function registrarEspecialista() As Boolean
            Dim conn As OleDbConnection = New OleDbConnection(ConfigurationManager.ConnectionStrings("ConexionKaplan").ConnectionString)
            Dim cmd As OleDbCommand = New OleDbCommand("Kaplan.RegistrarEspecialista", conn)
            cmd.CommandType = CommandType.StoredProcedure

            Dim inIdEs As OleDbParameter = cmd.Parameters.Add("@inIdEspecialista", OleDbType.Decimal, Nothing)
            inIdEs.Direction = ParameterDirection.Input
            inIdEs.Value = Me.Id

            Dim inId As OleDbParameter = cmd.Parameters.Add("@inIdPersona", OleDbType.Decimal, Nothing)
            inId.Direction = ParameterDirection.Input
            inId.Value = Me.Persona.Id

            Dim inRut As OleDbParameter = cmd.Parameters.Add("@inRut", OleDbType.Decimal, Nothing)
            inRut.Direction = ParameterDirection.Input
            inRut.Value = Me.Persona.Rut

            Dim inDv As OleDbParameter = cmd.Parameters.Add("@inDv", OleDbType.Char, 1)
            inDv.Direction = ParameterDirection.Input
            inDv.Value = Me.Persona.Dv

            Dim inNombre As OleDbParameter = cmd.Parameters.Add("@inNombre", OleDbType.VarChar, 250)
            inNombre.Direction = ParameterDirection.Input
            inNombre.Value = Me.Persona.Nombre

            Dim inPaterno As OleDbParameter = cmd.Parameters.Add("@inPaterno", OleDbType.VarChar, 200)
            inPaterno.Direction = ParameterDirection.Input
            inPaterno.Value = Me.Persona.Paterno

            Dim inMaterno As OleDbParameter = cmd.Parameters.Add("@inMaterno", OleDbType.VarChar, 200)
            inMaterno.Direction = ParameterDirection.Input
            inMaterno.Value = Me.Persona.Materno

            Dim inFechNac As OleDbParameter = cmd.Parameters.Add("@inFechNac", OleDbType.Date, Nothing)
            inFechNac.Direction = ParameterDirection.Input
            inFechNac.Value = Me.Persona.FechaNac

            Dim inSexo As OleDbParameter = cmd.Parameters.Add("@inSexo", OleDbType.Decimal, Nothing)
            inSexo.Direction = ParameterDirection.Input
            inSexo.Value = Me.Persona.Sexo.ID

            Dim inTelefono As OleDbParameter = cmd.Parameters.Add("@inTelefono", OleDbType.Decimal, Nothing)
            inTelefono.Direction = ParameterDirection.Input
            inTelefono.Value = Me.Persona.Telefono

            Dim inMovil As OleDbParameter = cmd.Parameters.Add("@inMovil", OleDbType.Decimal, Nothing)
            inMovil.Direction = ParameterDirection.Input
            inMovil.Value = Me.Persona.Movil

            Dim inEmail As OleDbParameter = cmd.Parameters.Add("@inEmail", OleDbType.VarChar, 100)
            inEmail.Direction = ParameterDirection.Input
            inEmail.Value = Me.Persona.Email

            Dim inEspecialidad As OleDbParameter = cmd.Parameters.Add("@inEspecialidad", OleDbType.Decimal, Nothing)
            inEspecialidad.Direction = ParameterDirection.Input
            inEspecialidad.Value = Me.Especialidad.ID

            Dim outError As OleDbParameter = cmd.Parameters.Add("@outError", OleDbType.Integer)
            outError.Direction = ParameterDirection.Output

            Dim outLogin As OleDbParameter = cmd.Parameters.Add("@outLogin", OleDbType.VarChar, 50)
            outLogin.Direction = ParameterDirection.Output

            Dim outPass As OleDbParameter = cmd.Parameters.Add("@outPass", OleDbType.VarChar, 50)
            outPass.Direction = ParameterDirection.Output


            conn.Open()
            cmd.ExecuteReader()
            conn.Close()

            If CInt(cmd.Parameters("@outError").Value).Equals(1) And Me.Id.Equals(-1) Then
                enviarCorreo(Me.Persona.Email.ToString(), cmd.Parameters("@outLogin").Value, cmd.Parameters("@outPass").Value)
            End If

            Return CInt(cmd.Parameters("@outError").Value)
        End Function
        Public Function enviarCorreo(ByVal email As String, ByVal login As String, ByVal pass As String)
            Try
                Dim correo As New MailMessage
                Dim smtp As New SmtpClient()
#Region "Email"
                Dim body As String =
                    "<!DOCTYPE html> " +
                    "<head> " +
                    "<html> " +
                    "    <meta charset='utf-8'> <!-- utf-8 works for most cases -->" +
                    "    <meta name='viewport' content='width=device-width'> <!-- Forcing initial-scale shouldn't be necessary -->" +
                    "    <meta http-equiv='X-UA-Compatible' content='IE=edge'> <!-- Use the latest (edge) version of IE rendering engine -->" +
                    "    <meta name='x-apple-disable-message-reformatting'> <!-- Disable auto-scale in iOS 10 Mail entirely -->" +
                    "    <title>Bienvenido a Kaplan</title> <!-- The title tag shows in email notifications, like Android 4.4. -->" +
                    "    <style>" +
                    "        html," +
                    "        body {" +
                    "            margin: 0 auto !important;" +
                    "            padding 0 !important;" +
                    "            height: 100% !important;" +
                    "            width 100% !important;" +
                    "        }" +
                    "        * {" +
                    "            -ms-text-size-adjust 100%;" +
                    "            -webkit-text-size-adjust: 100%;" +
                    "        }" +
                    "        div[style*='margin: 16px 0'] {" +
                    "            margin: 0 !important;" +
                    "        }" +
                    "        table," +
                    "        td {" +
                    "            mso-table-lspace 0pt !important;" +
                    "            mso-table-rspace: 0pt !important;" +
                    "        }" +
                    "        table {" +
                    "            border-spacing: 0 !important;" +
                    "            border-collapse collapse!important;" +
                    "            table-layout: fixed!important;" +
                    "            margin 0 auto !important;" +
                    "        }" +
                    "        table table table {" +
                    "            table-layout auto;" +
                    "        }" +
                    "        a {" +
                    "            text-decoration none;" +
                    "        }" +
                    "        img {" +
                    "            -ms-interpolation-mode bicubic;" +
                    "        }" +
                    "        *[x-apple-data-detectors]," +
                    "        /* iOS */" +
                    "        .unstyle-auto-detected-links *," +
                    "        .aBn {" +
                    "            border-bottom: 0 !important;" +
                    "            cursor Default !important;" +
                    "            color: inherit !important;" +
                    "            text-decoration none!important;" +
                    "            font-size: inherit !important;" +
                    "            font-family inherit!important;" +
                    "            font-weight: inherit !important;" +
                    "            line-height inherit!important;" +
                    "        }" +
                    "        .a6S {" +
                    "            display none!important;" +
                    "            opacity: 0.01 !important;" +
                    "        }" +
                    "        img.g-img+div {" +
                    "            display: none !important;" +
                    "        }" +
                    "        @media only screen And (min-device-width 320px) And (max-device-width: 374px) {" +
                    "            u~div .email-container {" +
                    "                min-width 320px !important;" +
                    "            }" +
                    "        }" +
                    "        @media only screen And (min-device-width 375px) And (max-device-width: 413px) {" +
                    "            u~div .email-container {" +
                    "                min-width 375px !important;" +
                    "            }" +
                    "        }" +
                    "        @media only screen And (min-device-width 414px) {" +
                    "            u~div .email-container {" +
                    "                min-width 414px !important;" +
                    "            }" +
                    "        }" +
                    "    </style>" +
                    "    <style>" +
                    "        .button-td," +
                    "        .button-a {" +
                    "            transition: all 100ms ease-in;" +
                    "        }" +
                    "        .button-td-primaryhover," +
                    "        .button-a-primary:hover {" +
                    "            background:  #555555 !important;" +
                    "            border-color: #555555 !important;" +
                    "        }" +
                    "        @media screen And (max-width 600px) {" +
                    "            .email-container {" +
                    "                width 100% !important;" +
                    "                margin: auto !important;" +
                    "            }" +
                    "            .fluid {" +
                    "                max-width: 100% !important;" +
                    "                height auto!important;" +
                    "                margin-left: auto !important;" +
                    "                margin-right auto!important;" +
                    "            }" +
                    "            .stack-column," +
                    "            .stack-column-center {" +
                    "                display: block !important;" +
                    "                width 100% !important;" +
                    "                max-width: 100% !important;" +
                    "                direction ltr!important;" +
                    "            }" +
                    "            .stack-column-center {" +
                    "                text-align center!important;" +
                    "            }" +
                    "            .center-on-narrow {" +
                    "                text-align center!important;" +
                    "                display: block !important;" +
                    "                margin-left auto!important;" +
                    "                margin-right: auto !important;" +
                    "                float none!important;" +
                    "            }" +
                    "            table.center-on-narrow {" +
                    "                display inline-block!important;" +
                    "            }" +
                    "            .email-container p {" +
                    "                font-size 17px !important;" +
                    "            }" +
                    "        }" +
                    "    </style>" +
                    "</head>" +
                    "<body width='100%' style='margin: 0; padding: 0 !important; mso-line-height-rule: exactly; background-color: #fff;'>" +
                    "    <center style='width: 100%; background-color: #fff;'>" +
                    "        <div style='display: none; font-size: 1px; line-height: 1px; max-height: 0px; max-width: 0px; opacity: 0; overflow: hidden; mso-hide: all; font-family: sans-serif;'>" +
                    "            (Optional) This text will appear in the inbox preview, but not the email body. It can be used to supplement" +
                    "            the email subject line Or even summarize the email's contents. Extended text preheaders (~490 characters)" +
                    "            seems like a better UX for anyone using a screenreader or voice-command apps like Siri to dictate the" +
                    "            contents of an email. If this text Is Not included, email clients will automatically populate it using the" +
                    "            text (including image alt text) at the start of the email's body." +
                    "        </div>" +
                    "        <div style='display: none; font-size: 1px; line-height: 1px; max-height: 0px; max-width: 0px; opacity: 0; overflow: hidden; mso-hide: all; font-family: sans-serif;'>" +
                    "            &zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;" +
                    "        </div>" +
                    "        <table align='center' role='presentation' cellspacing='0' cellpadding='0' border='0' width='600' style='margin: 0 auto;'" +
                    "            class='email-container'>" +
                    "            <tr>" +
                    "                <td style='padding: 20px; font-family: sans-serif; font-size: 15px; line-height: 20px; background-color: #32b8da; height:70px'>" +
                    "                    <h1 style='margin: 0 0 10px; font-size: 25px; line-height: 30px; color: #fff; font-weight: normal;'>Fundación" +
                    "                        Kaplan</h1>" +
                    "                </td>" +
                    "            </tr>" +
                    "            <tr>" +
                    "                <td style='background-color: #ffffff;'>" +
                    "                    <img src='https://mianfolio.com/kosimedic/v1.3.1/wide/img/news/image-04.jpg' width='600' height=''" +
                    "                        alt='alt_text' border='0' style='width: 100%; max-width: 600px; height: auto; background: #dddddd; font-family: sans-serif; font-size: 15px; line-height: 15px; color: #555555; margin: auto;'" +
                    "                        class='g-img'>" +
                    "                </td>" +
                    "            </tr>" +
                    "            <tr>" +
                    "                <td style='background-color: #ffffff;'>" +
                    "                    <table role='presentation' cellspacing='0' cellpadding='0' border='0' width='100%'>" +
                    "                        <tr>" +
                    "                            <td colspan='2' style='padding: 20px; font-family: sans-serif; font-size: 15px; line-height: 20px; color: #555555;'>" +
                    "                                <h1 style='margin: 0 0 10px; font-size: 25px; line-height: 30px; color: #333333; font-weight: normal;'> Estimado(a) " + Me.Persona.Nombre + " " + Me.Persona.Paterno + "</h1>" +
                    "                                <p style='margin: 0 0 10px;'>Nos complace informarte que has sido registrado como" +
                    "                                    usuario para Agenda Electrónica & Ficha Clínica Electrónica de la Fundación Kaplan.</p>" +
                    "                                <p style='margin: 0 0 10px;'>Para iniciar sesión utiliza las siguientes credenciales.</p>" +
                    "                            </td>" +
                    "                        </tr>" +
                    "                        <tr>" +
                    "                            <td style='padding: 20px; font-family: sans-serif; font-size: 15px; line-height: 20px; color: #555555;'>" +
                    "                                <h2 style='text-align: right'>Usuario</h2>" +
                    "                            </td>" +
                    "                            <td style='padding: 20px; font-family: sans-serif; font-size: 15px; line-height: 20px; color: #555555;'>" +
                    "                                <h2>" + login + "</h2>" +
                    "                            </td>" +
                    "                        </tr>" +
                    "                        <tr>" +
                    "                            <td style='padding: 20px; font-family: sans-serif; font-size: 15px; line-height: 20px; color: #555555;'>" +
                    "                                <h2 style='text-align: right'>Contraseña</h2>" +
                    "                            </td>" +
                    "                            <td style='padding: 20px; font-family: sans-serif; font-size: 15px; line-height: 20px; color: #555555;'>" +
                    "                                <h2>" + pass + "</h2>" +
                    "                            </td>" +
                    "                        </tr>" +
                    "                        <tr>" +
                    "                            <td style='padding: 0 20px 20px;' colspan='2'>" +
                    "                                <table align='center' role='presentation' cellspacing='0' cellpadding='0' border='0'" +
                    "                                    style='margin: auto;'>" +
                    "                                    <tr>" +
                    "                                        <td class='button-td button-td-primary' style='border-radius: 4px; background: #32b8da;'>" +
                    "                                            <a class='button-a button-a-primary' href='http://sistemaskaplan.info/agenda/#!/' style='background: #32b8da; border: 1px solid #32b8da; font-family: sans-serif; font-size: 15px; line-height: 15px; text-decoration: none; padding: 13px 17px; color: #ffffff; display: block; border-radius: 4px;'>Iniciar" +
                    "                                                Sesión</a>" +
                    "                                        </td>" +
                    "                                    </tr>" +
                    "                                </table>" +
                    "                            </td>" +
                    "                        </tr>" +
                    "                    </table>" +
                    "                </td>" +
                    "            </tr>" +
                    "    </center>" +
                    "</body>" +
                    "</html>"
#End Region
                correo.From = New MailAddress("no_reply@sistemaskaplan.info", "Sistema Kaplan", System.Text.Encoding.UTF8)
                correo.To.Add(email)
                correo.SubjectEncoding = System.Text.Encoding.UTF8
                correo.Subject = "Bienvenido a Sistema Kaplan"
                correo.Body = body
                'correo.Body = "Su usuario de conexión es " + login + " y su contraseña es " + pass
                correo.BodyEncoding = System.Text.Encoding.UTF8
                correo.IsBodyHtml = True
                correo.Priority = MailPriority.High

                smtp.Credentials = New System.Net.NetworkCredential("no_reply@sistemaskaplan.info", "Kaplan*2018")
                smtp.Port = 25
                smtp.Host = "mail.sistemaskaplan.info"
                smtp.EnableSsl = False

                smtp.Send(correo)
                Dim hola As String = ""
            Catch ex As Exception
                Return False
            End Try
            Return True
        End Function
    End Class
End Namespace