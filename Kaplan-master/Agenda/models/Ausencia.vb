Imports System.Data.OleDb
Imports System.Data.SqlClient

Namespace Clases
    Public Class Ausencia
        Public Property Id As Integer
        Public Property Estado As Integer
        Public Property Hora As Tipos.TipoHora
        Public Property Dia As Date
        Public ReadOnly Property DiaString As String
            Get
                Return Dia.ToString("dd MMM yyyy")
            End Get
        End Property
        Public Property Motivo As String
        Public Property IdEspecialista As Integer

        Public Shared Function getListadoAusencias(ByVal prmIdEspecialista As Integer, ByRef msj As String) As List(Of Ausencia)
            Try
                Dim conn As OleDbConnection = New OleDbConnection(ConfigurationManager.ConnectionStrings("ConexionKaplan").ConnectionString)
                Dim cmd As OleDbCommand = New OleDbCommand("Kaplan.ListadoAusencias", conn)
                cmd.CommandType = CommandType.StoredProcedure

                Dim Id As OleDbParameter = cmd.Parameters.Add("@inEspecialista", OleDbType.Decimal, Nothing)
                Id.Direction = ParameterDirection.Input
                Id.Value = prmIdEspecialista

                conn.Open()
                Dim adapter As OleDbDataAdapter = New OleDbDataAdapter(cmd)
                Dim vDataTable As New DataTable
                adapter.Fill(vDataTable)
                getListadoAusencias = New List(Of Ausencia)
                For Each vRow As DataRow In vDataTable.Rows
                    getListadoAusencias.Add(Mapeo(vRow))
                Next
                conn.Close()
                Return getListadoAusencias

            Catch exc As Exception
                msj = exc.ToString
            End Try

        End Function

        Private Shared Function Mapeo(prmRow As DataRow) As Ausencia
            Try
                Dim vAusencia As New Ausencia
                vAusencia.Id = prmRow("ID_AUSENCIA")
                vAusencia.Estado = prmRow("ID_ESTADO")
                vAusencia.Motivo = prmRow("MENSAJE")
                vAusencia.Hora = Tipos.TipoHora.getTipo(prmRow("ID_HORA"))
                vAusencia.Dia = prmRow("DIA").ToString

                Return vAusencia

            Catch ex As Exception
                Return Nothing
            End Try
        End Function

        Public Function registrarAusencia() As Boolean
            Dim conn As OleDbConnection = New OleDbConnection(ConfigurationManager.ConnectionStrings("ConexionKaplan").ConnectionString)
            Dim cmd As OleDbCommand = New OleDbCommand("Kaplan.RegistrarAusencia", conn)
            cmd.CommandType = CommandType.StoredProcedure

            Dim inIdEspecialista As OleDbParameter = cmd.Parameters.Add("@inIdEspecialista", OleDbType.Decimal, Nothing)
            inIdEspecialista.Direction = ParameterDirection.Input
            inIdEspecialista.Value = Me.IdEspecialista

            Dim inDia As OleDbParameter = cmd.Parameters.Add("@inDia", OleDbType.Date, Nothing)
            inDia.Direction = ParameterDirection.Input
            inDia.Value = Me.Dia

            Dim inHora As OleDbParameter = cmd.Parameters.Add("@inHora", OleDbType.Integer)
            inHora.Direction = ParameterDirection.Input
            inHora.Value = Me.Hora.ID

            Dim inMotivo As OleDbParameter = cmd.Parameters.Add("@inMotivo", OleDbType.VarChar, 100)
            inMotivo.Direction = ParameterDirection.Input
            inMotivo.Value = Me.Motivo

            Dim outError As OleDbParameter = cmd.Parameters.Add("@outError", OleDbType.Integer)
            outError.Direction = ParameterDirection.Output

            conn.Open()
            cmd.ExecuteReader()
            conn.Close()

            Return CInt(cmd.Parameters("@outError").Value)
        End Function

        Public Function eliminarAusencia() As Boolean
            Dim conn As OleDbConnection = New OleDbConnection(ConfigurationManager.ConnectionStrings("ConexionKaplan").ConnectionString)
            Dim cmd As OleDbCommand = New OleDbCommand("Kaplan.EliminarAusencia", conn)
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
