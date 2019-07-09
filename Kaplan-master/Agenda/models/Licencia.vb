Imports Agenda.Clases
Imports System.Globalization
Imports System.Data.OleDb
Imports System.Data.SqlClient

Namespace Clases
    Public Class Licencia
        Public Property Id As Integer
        Public Property IdPaciente As Integer
        Public Property Inicio As Date
        Public Property Termino As Date
        Public Property Observacion As String
        Public Property Estado As Tipos.TipoEstadoReserva
        Public ReadOnly Property InicioString As String
            Get
                Return Inicio.ToString("dd MMM yyyy")
            End Get
        End Property
        Public ReadOnly Property TerminoString As String
            Get
                Return Termino.ToString("dd MMM yyyy")
            End Get
        End Property
        Public Shared Function getLicencias(ByVal inRut As Integer) As List(Of Licencia)
            Try
                Dim conn As OleDbConnection = New OleDbConnection(ConfigurationManager.ConnectionStrings("ConexionKaplan").ConnectionString)
                Dim cmd As OleDbCommand = New OleDbCommand("Kaplan.ListadoLicencias", conn)
                cmd.CommandType = CommandType.StoredProcedure

                Dim Dia As OleDbParameter = cmd.Parameters.Add("@inRut", OleDbType.Decimal, Nothing)
                Dia.Direction = ParameterDirection.Input
                Dia.Value = inRut

                conn.Open()
                Dim adapter As OleDbDataAdapter = New OleDbDataAdapter(cmd)
                Dim vDataTable As New DataTable
                adapter.Fill(vDataTable)
                getLicencias = New List(Of Licencia)
                For Each vRow As DataRow In vDataTable.Rows
                    getLicencias.Add(Mapeo(vRow))
                Next
                conn.Close()
                Return getLicencias
            Catch exc As Exception
            End Try

        End Function
        Public Function registrarLicencia() As Boolean
            Dim conn As OleDbConnection = New OleDbConnection(ConfigurationManager.ConnectionStrings("ConexionKaplan").ConnectionString)
            Dim cmd As OleDbCommand = New OleDbCommand("Kaplan.registrarLicencia", conn)
            cmd.CommandType = CommandType.StoredProcedure

            Dim inId As OleDbParameter = cmd.Parameters.Add("@inId", OleDbType.Decimal, Nothing)
            inId.Direction = ParameterDirection.Input
            inId.Value = Me.Id

            Dim inRut As OleDbParameter = cmd.Parameters.Add("@inPaciente", OleDbType.Decimal, Nothing)
            inRut.Direction = ParameterDirection.Input
            inRut.Value = Me.IdPaciente

            Dim inInicio As OleDbParameter = cmd.Parameters.Add("@inInicio", OleDbType.Date, Nothing)
            inInicio.Direction = ParameterDirection.Input
            inInicio.Value = Me.Inicio

            Dim inTermino As OleDbParameter = cmd.Parameters.Add("@inTermino", OleDbType.Date, Nothing)
            inTermino.Direction = ParameterDirection.Input
            inTermino.Value = Me.Termino

            Dim inObservacion As OleDbParameter = cmd.Parameters.Add("@inObservacion", OleDbType.VarChar, 250)
            inObservacion.Direction = ParameterDirection.Input
            inObservacion.Value = Me.Observacion

            Dim outError As OleDbParameter = cmd.Parameters.Add("@outError", OleDbType.Integer)
            outError.Direction = ParameterDirection.Output

            conn.Open()
            cmd.ExecuteReader()
            conn.Close()

            Return CInt(cmd.Parameters("@outError").Value)
        End Function
        Public Shared Function Mapeo(prmRow As DataRow) As Licencia
            Try
                Dim vLicencia As New Licencia
                vLicencia.Id = prmRow("Id")
                vLicencia.IdPaciente = prmRow("IdPaciente")
                vLicencia.Inicio = prmRow("Inicio")
                vLicencia.Termino = prmRow("Termino")
                vLicencia.Observacion = prmRow("Observacion").ToString
                vLicencia.Estado = Tipos.TipoEstadoReserva.getTipo(prmRow("Estado"))
                Return vLicencia

            Catch ex As Exception
                Return Nothing
            End Try
        End Function
        Public Shared Function Mapeo(prmDatos As DataTable) As List(Of Licencia)
            Mapeo = New List(Of Licencia)
            For Each prmRow As DataRow In prmDatos.Rows
                Dim vLicencia As New Licencia
                vLicencia.Id = prmRow("Id")
                vLicencia.IdPaciente = prmRow("IdPaciente")
                vLicencia.Inicio = prmRow("Inicio")
                vLicencia.Termino = prmRow("Termino")
                vLicencia.Observacion = prmRow("Observacion").ToString
                vLicencia.Estado = Tipos.TipoEstadoReserva.getTipo(prmRow("Estado"))
                Mapeo.Add(vLicencia)
            Next
            Return Mapeo
        End Function
    End Class
End Namespace