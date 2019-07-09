Imports System.Data.OleDb
Imports System.Data.SqlClient

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
            Dim cmd As OleDbCommand = New OleDbCommand("Kaplan.Login", conn)
            cmd.CommandType = CommandType.StoredProcedure

            Dim inUser As OleDbParameter = cmd.Parameters.Add("@inUser", OleDbType.VarChar, 50)
            inUser.Direction = ParameterDirection.Input
            inUser.Value = Me.User

            Dim inPass As OleDbParameter = cmd.Parameters.Add("@inPass", OleDbType.VarChar, 50)
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

    End Class
End Namespace