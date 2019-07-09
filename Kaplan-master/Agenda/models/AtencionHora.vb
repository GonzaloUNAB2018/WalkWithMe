Imports System.Data.OleDb
Imports System.Data.SqlClient

Namespace Clases
    Public Class AtencionHora

        Public Property Id As Integer
        Public Property Hora As Tipos.TipoHora
        Public Property Dia As Tipos.TipoDia
        Public Property IdEspecialista As Integer

        Public Shared Function getListadoAtencionesHoras(ByVal prmIdEspecialista As Integer, ByRef msj As String) As List(Of AtencionHora)
            Try
                Dim conn As OleDbConnection = New OleDbConnection(ConfigurationManager.ConnectionStrings("ConexionKaplan").ConnectionString)
                Dim cmd As OleDbCommand = New OleDbCommand("Kaplan.ListadoAtencionHoras", conn)
                cmd.CommandType = CommandType.StoredProcedure

                Dim Id As OleDbParameter = cmd.Parameters.Add("@inEspecialista", OleDbType.Decimal, Nothing)
                Id.Direction = ParameterDirection.Input
                Id.Value = prmIdEspecialista

                conn.Open()
                Dim adapter As OleDbDataAdapter = New OleDbDataAdapter(cmd)
                Dim vDataTable As New DataTable
                adapter.Fill(vDataTable)
                getListadoAtencionesHoras = New List(Of AtencionHora)
                For Each vRow As DataRow In vDataTable.Rows
                    getListadoAtencionesHoras.Add(Mapeo(vRow))
                Next
                conn.Close()
                Return getListadoAtencionesHoras

            Catch exc As Exception
                msj = exc.ToString
            End Try

        End Function

        Private Shared Function Mapeo(prmRow As DataRow) As AtencionHora
            Try
                Dim vAtencion As New AtencionHora
                vAtencion.Id = prmRow("ID_ATENCION")
                vAtencion.Hora = Tipos.TipoHora.getTipo(prmRow("ID_HORA"))
                vAtencion.Dia = Tipos.TipoDia.getTipo(prmRow("ID_DIA"))
                Return vAtencion

            Catch ex As Exception
                Return Nothing
            End Try
        End Function

        Public Function registrarAtencionHora() As Boolean
            Dim conn As OleDbConnection = New OleDbConnection(ConfigurationManager.ConnectionStrings("ConexionKaplan").ConnectionString)
            Dim cmd As OleDbCommand = New OleDbCommand("Kaplan.RegistrarAtencionHora", conn)
            cmd.CommandType = CommandType.StoredProcedure

            Dim inIdEspecialista As OleDbParameter = cmd.Parameters.Add("@inIdEspecialista", OleDbType.Integer)
            inIdEspecialista.Direction = ParameterDirection.Input
            inIdEspecialista.Value = Me.IdEspecialista

            Dim inDia As OleDbParameter = cmd.Parameters.Add("@inDia", OleDbType.Integer)
            inDia.Direction = ParameterDirection.Input
            inDia.Value = Me.Dia.ID

            Dim inHora As OleDbParameter = cmd.Parameters.Add("@inHora", OleDbType.Integer)
            inHora.Direction = ParameterDirection.Input
            inHora.Value = Me.Hora.ID

            Dim outError As OleDbParameter = cmd.Parameters.Add("@outError", OleDbType.Integer)
            outError.Direction = ParameterDirection.Output

            conn.Open()
            cmd.ExecuteReader()
            conn.Close()

            Return CInt(cmd.Parameters("@outError").Value)
        End Function

        Public Function EliminarAtencionHora() As Boolean
            Dim conn As OleDbConnection = New OleDbConnection(ConfigurationManager.ConnectionStrings("ConexionKaplan").ConnectionString)
            Dim cmd As OleDbCommand = New OleDbCommand("Kaplan.EliminarAtencionHora", conn)
            cmd.CommandType = CommandType.StoredProcedure

            Dim inId As OleDbParameter = cmd.Parameters.Add("@inId", OleDbType.Decimal, Nothing)
            inId.Direction = ParameterDirection.Input
            inId.Value = Me.Id

            Dim outError As OleDbParameter = cmd.Parameters.Add("@outError", OleDbType.Integer)
            outError.Direction = ParameterDirection.Output

            conn.Open()
            cmd.ExecuteReader()
            conn.Close()

            Return CInt(cmd.Parameters("@outError").Value)
        End Function

    End Class
End Namespace