Imports Agenda.Clases
Imports System.Globalization
Imports System.Data.OleDb
Imports System.Data.SqlClient

Namespace Clases
    Public Class Reserva
        Public Property Id As Integer
        Public Property Paciente As Paciente
        Public Property Especialista As Especialista
        Public Property Fecha As Date
        Public Property Hora As String
        Public Property Tipo As Tipos.TipoReserva
        Public Property Plan As Plan
        Public Property Estado As Tipos.TipoEstadoReserva
        Public Property Motivo As Tipos.TipoMotivo
        Public Property Observacion As String
        Public Property ObsEspecial As String
        Public Property reservasanuladas As Integer
        Public Property totalreservas As Integer
        Public ReadOnly Property FechaString As String
            Get
                Return Fecha.ToString("dd MMM yyyy")
            End Get
        End Property
        Public Shared Function getReservasDiaHora(ByVal inFecha As DateTime, ByVal inDia As Integer, ByVal inHora As String) As List(Of Reserva)
            Try
                Dim conn As OleDbConnection = New OleDbConnection(ConfigurationManager.ConnectionStrings("ConexionKaplan").ConnectionString)
                Dim cmd As OleDbCommand = New OleDbCommand("Kaplan.ListadoDiaHora", conn)
                cmd.CommandType = CommandType.StoredProcedure

                Dim Fecha As OleDbParameter = cmd.Parameters.Add("@inFecha", OleDbType.Date, Nothing)
                Fecha.Direction = ParameterDirection.Input
                'Fecha.Value = DateTime.Parse("27-09-2018")
                Fecha.Value = inFecha

                Dim Dia As OleDbParameter = cmd.Parameters.Add("@inDia", OleDbType.Decimal, Nothing)
                Dia.Direction = ParameterDirection.Input
                Dia.Value = inDia

                Dim Hora As OleDbParameter = cmd.Parameters.Add("@inHora", OleDbType.VarChar, 5)
                Hora.Direction = ParameterDirection.Input
                Hora.Value = inHora

                conn.Open()
                Dim adapter As OleDbDataAdapter = New OleDbDataAdapter(cmd)
                Dim vDataTable As New DataTable
                adapter.Fill(vDataTable)
                getReservasDiaHora = New List(Of Reserva)
                For Each vRow As DataRow In vDataTable.Rows
                    getReservasDiaHora.Add(Mapeo(vRow))
                Next
                conn.Close()
                Return getReservasDiaHora

            Catch exc As Exception
            End Try

        End Function
        Public Shared Function getReserva(ByVal inId As Integer) As Reserva
            Try
                Dim conn As OleDbConnection = New OleDbConnection(ConfigurationManager.ConnectionStrings("ConexionKaplan").ConnectionString)
                Dim cmd As OleDbCommand = New OleDbCommand("Kaplan.buscarReserva", conn)
                cmd.CommandType = CommandType.StoredProcedure

                Dim Id As OleDbParameter = cmd.Parameters.Add("@inId", OleDbType.Decimal, Nothing)
                Id.Direction = ParameterDirection.Input
                Id.Value = inId

                conn.Open()
                Dim adapter As OleDbDataAdapter = New OleDbDataAdapter(cmd)
                Dim vDataTable As New DataTable
                adapter.Fill(vDataTable)
                getReserva = Mapeo(vDataTable(0))
                conn.Close()
                Return getReserva

            Catch exc As Exception
            End Try

        End Function
        Private Shared Function Mapeo(prmRow As DataRow) As Reserva
            Try
                Dim vReserva As New Reserva
                vReserva.Id = prmRow("ID")
                vReserva.Paciente = Paciente.getPacienteId(prmRow("Paciente"))
                vReserva.Especialista = Especialista.getEspecialistaId(prmRow("Especialista"))
                vReserva.Fecha = prmRow("Fecha")
                vReserva.Hora = prmRow("Hora").ToString
                vReserva.Tipo = Tipos.TipoReserva.getTipo(prmRow("TipoReserva"))
                vReserva.Estado = Tipos.TipoEstadoReserva.getTipo(prmRow("Estado"))
                If prmRow.Table.Columns.Contains("TIPOMOTIVO") Then
                    If Not IsDBNull(prmRow("tipomotivo")) AndAlso Not prmRow("tipomotivo").Equals(" ") Then vReserva.Motivo = Tipos.TipoMotivo.getTipo(prmRow("tipomotivo"))
                    vReserva.Observacion = prmRow("observacion").ToString
                End If
                Return vReserva

            Catch ex As Exception
                Return Nothing
            End Try
        End Function
        Public Shared Function Mapeo(prmDatos As DataTable) As List(Of Reserva)
            Mapeo = New List(Of Reserva)
            For Each prmRow As DataRow In prmDatos.Rows
                Dim vReserva As New Reserva
                vReserva.Id = prmRow("ID")
                'vReserva.Paciente = Paciente.getPacienteId(prmRow("Paciente"))
                vReserva.Especialista = Especialista.getEspecialistaId(prmRow("Especialista"))
                vReserva.Fecha = prmRow("Fecha")
                vReserva.Hora = prmRow("Hora").ToString
                vReserva.Tipo = Tipos.TipoReserva.getTipo(prmRow("TipoReserva"))
                vReserva.Estado = Tipos.TipoEstadoReserva.getTipo(prmRow("Estado"))
                Mapeo.Add(vReserva)
            Next
            Return Mapeo
        End Function
        Public Function registrarReserva() As Integer
            Dim conn As OleDbConnection = New OleDbConnection(ConfigurationManager.ConnectionStrings("ConexionKaplan").ConnectionString)
            Dim cmd As OleDbCommand = New OleDbCommand("Kaplan.RegistrarReserva", conn)
            cmd.CommandType = CommandType.StoredProcedure

            Dim inId As OleDbParameter = cmd.Parameters.Add("@inId", OleDbType.Decimal, Nothing)
            inId.Direction = ParameterDirection.Input
            inId.Value = Me.Id

            Dim inPaciente As OleDbParameter = cmd.Parameters.Add("@inPaciente", OleDbType.Decimal, Nothing)
            inPaciente.Direction = ParameterDirection.Input
            inPaciente.Value = Me.Paciente.Id

            Dim inEspecialista As OleDbParameter = cmd.Parameters.Add("@inEspecialista", OleDbType.Decimal, Nothing)
            inEspecialista.Direction = ParameterDirection.Input
            inEspecialista.Value = Me.Especialista.Id

            Dim inFecha As OleDbParameter = cmd.Parameters.Add("@inFecha", OleDbType.Date, Nothing)
            inFecha.Direction = ParameterDirection.Input
            inFecha.Value = Me.Fecha

            Dim inHora As OleDbParameter = cmd.Parameters.Add("@inHora", OleDbType.VarChar, 50)
            inHora.Direction = ParameterDirection.Input
            inHora.Value = Me.Hora

            Dim Estado As OleDbParameter = cmd.Parameters.Add("@inEstado", OleDbType.Decimal, Nothing)
            Estado.Direction = ParameterDirection.Input
            Estado.Value = 1

            Dim Plan As OleDbParameter = cmd.Parameters.Add("@inPlan", OleDbType.Decimal, Nothing)
            Plan.Direction = ParameterDirection.Input
            Plan.Value = Me.Plan.Id

            Dim Tipo As OleDbParameter = cmd.Parameters.Add("@inTipo", OleDbType.Decimal, Nothing)
            Tipo.Direction = ParameterDirection.Input
            Tipo.Value = Me.Tipo.ID

            Dim outError As OleDbParameter = cmd.Parameters.Add("@outError", OleDbType.Integer)
            outError.Direction = ParameterDirection.Output

            conn.Open()
            cmd.ExecuteReader()
            conn.Close()

            Return CInt(cmd.Parameters("@outError").Value)
        End Function
        Public Function anularReserva() As Boolean
            Dim conn As OleDbConnection = New OleDbConnection(ConfigurationManager.ConnectionStrings("ConexionKaplan").ConnectionString)
            Dim cmd As OleDbCommand = New OleDbCommand("Kaplan.anularReserva", conn)
            cmd.CommandType = CommandType.StoredProcedure

            Dim inId As OleDbParameter = cmd.Parameters.Add("@inId", OleDbType.Decimal, Nothing)
            inId.Direction = ParameterDirection.Input
            inId.Value = Me.Id

            Dim Estado As OleDbParameter = cmd.Parameters.Add("@inEstado", OleDbType.Decimal, Nothing)
            Estado.Direction = ParameterDirection.Input
            Estado.Value = Me.Estado.ID

            Dim inMotivo As OleDbParameter = cmd.Parameters.Add("@inMotivo", OleDbType.Decimal, Nothing)
            inMotivo.Direction = ParameterDirection.Input
            If (Not IsNothing(Me.Motivo) AndAlso Not IsNothing(Me.Motivo.ID)) Then inMotivo.Value = Me.Motivo.ID Else inMotivo.Value = DBNull.Value

            Dim inObservacion As OleDbParameter = cmd.Parameters.Add("@inObservacion", OleDbType.VarChar, 50)
            inObservacion.Direction = ParameterDirection.Input
            inObservacion.Value = Me.Observacion

            Dim outError As OleDbParameter = cmd.Parameters.Add("@outError", OleDbType.Integer)
            outError.Direction = ParameterDirection.Output

            conn.Open()
            cmd.ExecuteReader()
            conn.Close()

            Return CInt(cmd.Parameters("@outError").Value)
        End Function
        Public Function registrarObservacion() As Boolean
            Dim conn As OleDbConnection = New OleDbConnection(ConfigurationManager.ConnectionStrings("ConexionKaplan").ConnectionString)
            Dim cmd As OleDbCommand = New OleDbCommand("Kaplan.RegistrarObservacionEspecial", conn)
            cmd.CommandType = CommandType.StoredProcedure

            Dim inId As OleDbParameter = cmd.Parameters.Add("@inId", OleDbType.Decimal, Nothing)
            inId.Direction = ParameterDirection.Input
            inId.Value = Me.Id

            Dim inObservacion As OleDbParameter = cmd.Parameters.Add("@inObservacion", OleDbType.VarChar, 50)
            inObservacion.Direction = ParameterDirection.Input
            inObservacion.Value = Me.ObsEspecial

            Dim outError As OleDbParameter = cmd.Parameters.Add("@outError", OleDbType.Integer)
            outError.Direction = ParameterDirection.Output

            conn.Open()
            cmd.ExecuteReader()
            conn.Close()

            Return CInt(cmd.Parameters("@outError").Value)
        End Function
        Public Shared Function getEstadisticaxReserva(ByVal inPaciente As Integer, ByVal inIdEspecialista As Integer) As Reserva
            Try
                Dim conn As OleDbConnection = New OleDbConnection(ConfigurationManager.ConnectionStrings("ConexionKaplan").ConnectionString)
                Dim cmd As OleDbCommand = New OleDbCommand("Kaplan.EstadisticaxReserva", conn)
                cmd.CommandType = CommandType.StoredProcedure

                Dim paciente As OleDbParameter = cmd.Parameters.Add("@inPaciente", OleDbType.Decimal, Nothing)
                paciente.Direction = ParameterDirection.Input
                paciente.Value = inPaciente

                Dim especialista As OleDbParameter = cmd.Parameters.Add("@inEspecialista", OleDbType.Decimal, Nothing)
                especialista.Direction = ParameterDirection.Input
                especialista.Value = inIdEspecialista

                conn.Open()
                Dim adapter As OleDbDataAdapter = New OleDbDataAdapter(cmd)
                Dim vDataTable As New DataTable
                adapter.Fill(vDataTable)
                getEstadisticaxReserva = MapeoEstadistica(vDataTable(0))
                conn.Close()
                Return getEstadisticaxReserva

            Catch exc As Exception
            End Try

        End Function

        Private Shared Function MapeoEstadistica(prmRow As DataRow) As Reserva
            Try
                Dim vReserva As New Reserva
                vReserva.reservasanuladas = prmRow("anuladas")
                vReserva.totalreservas = prmRow("total")
                Return vReserva

            Catch ex As Exception
                Return Nothing
            End Try
        End Function

        Public Shared Function getObservacion(ByVal prmId As Integer) As Reserva
            Try
                Dim conn As OleDbConnection = New OleDbConnection(ConfigurationManager.ConnectionStrings("ConexionKaplan").ConnectionString)
                Dim cmd As OleDbCommand = New OleDbCommand("Kaplan.BuscarObservacionEspecial", conn)
                cmd.CommandType = CommandType.StoredProcedure

                Dim Id As OleDbParameter = cmd.Parameters.Add("@inId", OleDbType.Decimal, Nothing)
                Id.Direction = ParameterDirection.Input
                Id.Value = prmId

                conn.Open()
                Dim adapter As OleDbDataAdapter = New OleDbDataAdapter(cmd)
                Dim vDataTable As New DataTable
                adapter.Fill(vDataTable)
                getObservacion = MapeoObs(vDataTable.Rows(0))
                conn.Close()
                Return getObservacion

            Catch exc As Exception
            End Try
        End Function
        Private Shared Function MapeoObs(prmRow As DataRow) As Reserva
            Try
                Dim vReserva As New Reserva
                vReserva.ObsEspecial = prmRow("OBS_ESPECIAL")
                Return vReserva
            Catch ex As Exception
                Return Nothing
            End Try
        End Function
    End Class
End Namespace