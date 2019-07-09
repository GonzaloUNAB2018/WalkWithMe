Imports System.Data.OleDb
Imports System.Data.SqlClient
Imports System.Net.Mail
Imports System.IO

Namespace Clases
    Public Class Usuario
        Public Property Id As Integer
        Public Property User As String
        Public Property Pass As String
        Public Property Nombres As String
        Public Property Tipo As Integer
        Public Property IdEspecialista As Integer

        Public Function Login() As Integer
            Dim conn As OleDbConnection = New OleDbConnection(ConfigurationManager.ConnectionStrings("ConexionKaplan").ConnectionString)
            Dim cmd As OleDbCommand = New OleDbCommand("Kaplan.kaplan.Login", conn)
            cmd.CommandType = CommandType.StoredProcedure

            Dim inUser As OleDbParameter = cmd.Parameters.Add("@inUser", OleDbType.VarChar, 50)
            inUser.Direction = ParameterDirection.Input
            inUser.Value = Me.User

            Dim inPass As OleDbParameter = cmd.Parameters.Add("@inPass", OleDbType.VarChar, 100)
            inPass.Direction = ParameterDirection.Input
            inPass.Value = Me.Pass

            Dim outError As OleDbParameter = cmd.Parameters.Add("@outError", OleDbType.Integer)
            outError.Direction = ParameterDirection.Output

            conn.Open()
            cmd.ExecuteReader()
            conn.Close()

            Return CInt(cmd.Parameters("@outError").Value)
        End Function
        Public Shared Function getUsuario(strUser As String) As Usuario
            Dim conn As OleDbConnection = New OleDbConnection(ConfigurationManager.ConnectionStrings("ConexionKaplan").ConnectionString)
            Dim cmd As OleDbCommand = New OleDbCommand("Kaplan.BuscarLogin", conn)
            cmd.CommandType = CommandType.StoredProcedure

            Dim User As OleDbParameter = cmd.Parameters.Add("@inUser", OleDbType.VarChar, 50)
            User.Direction = ParameterDirection.Input
            User.Value = strUser

            Dim adapter As OleDbDataAdapter = New OleDbDataAdapter(cmd)
            Dim vDataSet As New DataSet
            adapter.Fill(vDataSet)

            If Not vDataSet.Tables(0).Rows.Count.Equals(0) Then
                getUsuario = Mapeo(vDataSet)
            End If

            Return getUsuario
        End Function
        Private Shared Function Mapeo(prmDatos As DataSet) As Usuario
            Try
                Dim vUser As New Usuario
                Dim prmRow As DataRow = prmDatos.Tables(0).Rows(0)

                vUser.Id = prmRow("id").ToString
                vUser.User = prmRow("login").ToString
                vUser.Nombres = prmRow("nombres").ToString
                vUser.Tipo = prmRow("tipo").ToString
                vUser.IdEspecialista = prmRow("id_especialista").ToString

                Return vUser
            Catch ex As Exception
                Return Nothing
            End Try

        End Function
        Public Shared Function getUsuarioEmail(inEmail As String) As Boolean
            Dim conn As OleDbConnection = New OleDbConnection(ConfigurationManager.ConnectionStrings("ConexionKaplan").ConnectionString)
            Dim cmd As OleDbCommand = New OleDbCommand("Kaplan.UsuarioEmail", conn)
            cmd.CommandType = CommandType.StoredProcedure

            Dim Email As OleDbParameter = cmd.Parameters.Add("@inEmail", OleDbType.VarChar, 100)
            Email.Direction = ParameterDirection.Input
            Email.Value = inEmail

            Dim outLogin As OleDbParameter = cmd.Parameters.Add("@outLogin", OleDbType.VarChar, 100)
            outLogin.Direction = ParameterDirection.Output

            Dim outPass As OleDbParameter = cmd.Parameters.Add("@outPass", OleDbType.VarChar, 100)
            outPass.Direction = ParameterDirection.Output

            Dim outError As OleDbParameter = cmd.Parameters.Add("@outError", OleDbType.Integer)
            outError.Direction = ParameterDirection.Output

            Dim adapter As OleDbDataAdapter = New OleDbDataAdapter(cmd)
            Dim vDataSet As New DataSet
            adapter.Fill(vDataSet)

            If Not outError.Value.Equals(1) Then
                enviarCorreo(inEmail, outLogin.Value, outPass.Value)
                Return True
            Else
                Return False
            End If
        End Function
        Public Shared Function enviarCorreo(ByVal email As String, ByVal login As String, ByVal pass As String)
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
                    "    <center style='width: 100%; background-color: #f5f5f5;'>" +
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
                    "                                <h1 style='margin: 0 0 10px; font-size: 25px; line-height: 30px; color: #333333; font-weight: normal;'> Estimado(a)</h1>" +
                    "                                <p style='margin: 0 0 10px;'>Hemos recibido una notificación solicitando la recuperación de su cuenta para acceder al Sistema Agenda Electrónica & Ficha Clínica Electrónica de la Fundación Kaplan.</p>" +
                    "                                <p style='margin: 0 0 10px;'>A continuación le entregamos sus credenciales</p>" +
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
                correo.Subject = "Recuperación de contraseña"
                correo.Body = body
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
