Imports Agenda.Clases
Imports System.Globalization
Imports System.Data.OleDb
Imports System.Data.SqlClient

Namespace Clases
    Public Class Plan
        Public Property Id As Integer
        Public Property IdPaciente As Integer
        Public Property Nombre As String
        Public Property Cantidad As Integer
        Public Property Descripcion As String
        Public Property Realizadas As Integer
        Public Property Usuario As Usuario
        Public Property Estado As Tipos.TipoEstadoPlan
        Public Property Motivo As Tipos.TipoMotivo
        Public Property FechaInicio As Nullable(Of Date)
        Public ReadOnly Property FechaInicioString As String
            Get
                If IsNothing(_FechaInicio) Then
                    Return ""
                Else
                    Return CDate(_FechaInicio).ToString("dd MMM yyyy")
                End If
            End Get
        End Property
        Public Property FechaFinalizacionPlan As Nullable(Of Date)
        Public ReadOnly Property FechaFinalizacionPlanString As String
            Get
                If IsNothing(_FechaFinalizacionPlan) Then
                    Return ""
                Else
                    Return CDate(_FechaFinalizacionPlan).ToString("dd MMM yyyy")
                End If
            End Get
        End Property

        Private Shared Function Mapeo(prmRow As DataRow) As Plan
            Try
                Dim vPlan As New Plan
                vPlan.Id = prmRow("ID")
                vPlan.Nombre = prmRow("Nombre")
                vPlan.Cantidad = prmRow("Cantidad")
                vPlan.Descripcion = prmRow("Descripcion")
                vPlan.Realizadas = prmRow("cantidad_realizada")
                vPlan.FechaInicio = prmRow("fechainicio")
                vPlan.Estado = Tipos.TipoEstadoPlan.getTipo(prmRow("Estado"))
                If Not IsDBNull(prmRow("motivo_finalizacion")) AndAlso Not prmRow("motivo_finalizacion").Equals(" ") Then vPlan.Motivo = Tipos.TipoMotivo.getTipo(prmRow("motivo_finalizacion"))
                If Not IsDBNull(prmRow("fecha_finalizacion")) AndAlso Not prmRow("fecha_finalizacion").Equals(" ") Then vPlan.FechaFinalizacionPlan = prmRow("fecha_finalizacion")
                Return vPlan

            Catch ex As Exception
                Return Nothing
            End Try
        End Function
        Public Shared Function Mapeo(prmDatos As DataTable) As List(Of Plan)
            Mapeo = New List(Of Plan)
            For Each prmRow As DataRow In prmDatos.Rows
                Dim vPlan As New Plan
                vPlan.Id = prmRow("ID")
                vPlan.Nombre = prmRow("Nombre")
                vPlan.Cantidad = prmRow("Cantidad")
                vPlan.Descripcion = prmRow("Descripcion")
                vPlan.Realizadas = prmRow("cantidad_realizada")
                If Not IsDBNull(prmRow("fecha_inicio")) AndAlso Not prmRow("fecha_inicio").Equals(" ") Then vPlan.FechaInicio = prmRow("fecha_inicio")
                vPlan.Estado = Tipos.TipoEstadoPlan.getTipo(prmRow("Estado"))
                If Not IsDBNull(prmRow("motivo_finalizacion")) AndAlso Not prmRow("motivo_finalizacion").Equals(" ") Then vPlan.Motivo = Tipos.TipoMotivo.getTipo(prmRow("motivo_finalizacion"))
                If Not IsDBNull(prmRow("fecha_finalizacion")) AndAlso Not prmRow("fecha_finalizacion").Equals(" ") Then vPlan.FechaFinalizacionPlan = prmRow("fecha_finalizacion")
                Mapeo.Add(vPlan)
            Next
            Return Mapeo
        End Function
        Public Shared Function getPlanes(ByVal inIdPaciente As Integer) As List(Of Plan)
            Try
                Dim conn As OleDbConnection = New OleDbConnection(ConfigurationManager.ConnectionStrings("ConexionKaplan").ConnectionString)
                Dim cmd As OleDbCommand = New OleDbCommand("Kaplan.ListadoPlan", conn)
                cmd.CommandType = CommandType.StoredProcedure

                Dim idPaciente As OleDbParameter = cmd.Parameters.Add("@inIdPaciente", OleDbType.Decimal, Nothing)
                idPaciente.Direction = ParameterDirection.Input
                idPaciente.Value = inIdPaciente

                conn.Open()
                Dim adapter As OleDbDataAdapter = New OleDbDataAdapter(cmd)
                Dim vDataTable As New DataTable
                adapter.Fill(vDataTable)
                getPlanes = New List(Of Plan)
                For Each vRow As DataRow In vDataTable.Rows
                    getPlanes.Add(Mapeo(vRow))
                Next
                conn.Close()
                Return getPlanes
            Catch exc As Exception
            End Try

        End Function
        Public Function registrarPlan() As Boolean
            Dim conn As OleDbConnection = New OleDbConnection(ConfigurationManager.ConnectionStrings("ConexionKaplan").ConnectionString)
            Dim cmd As OleDbCommand = New OleDbCommand("Kaplan.RegistrarPlan", conn)
            cmd.CommandType = CommandType.StoredProcedure

            Dim inId As OleDbParameter = cmd.Parameters.Add("@inId", OleDbType.Decimal, Nothing)
            inId.Direction = ParameterDirection.Input
            inId.Value = Me.Id

            Dim inPaciente As OleDbParameter = cmd.Parameters.Add("@inIdPaciente", OleDbType.Decimal, Nothing)
            inPaciente.Direction = ParameterDirection.Input
            inPaciente.Value = Me.IdPaciente

            Dim inNombre As OleDbParameter = cmd.Parameters.Add("@inNombre", OleDbType.VarChar, 200)
            inNombre.Direction = ParameterDirection.Input
            inNombre.Value = Me.Nombre

            Dim inDescripcion As OleDbParameter = cmd.Parameters.Add("@inDescripcion", OleDbType.VarChar, 250)
            inDescripcion.Direction = ParameterDirection.Input
            inDescripcion.Value = Me.Descripcion

            Dim inCantidad As OleDbParameter = cmd.Parameters.Add("@inCantidad", OleDbType.Decimal, Nothing)
            inCantidad.Direction = ParameterDirection.Input
            inCantidad.Value = Me.Cantidad

            Dim outError As OleDbParameter = cmd.Parameters.Add("@outError", OleDbType.Integer)
            outError.Direction = ParameterDirection.Output

            conn.Open()
            cmd.ExecuteReader()
            conn.Close()

            Return CInt(cmd.Parameters("@outError").Value)
        End Function

        Public Function finalizarPlan() As Boolean
            Dim conn As OleDbConnection = New OleDbConnection(ConfigurationManager.ConnectionStrings("ConexionKaplan").ConnectionString)
            Dim cmd As OleDbCommand = New OleDbCommand("Kaplan.FinalizarPlan", conn)
            cmd.CommandType = CommandType.StoredProcedure

            Dim inId As OleDbParameter = cmd.Parameters.Add("@inId", OleDbType.Decimal, Nothing)
            inId.Direction = ParameterDirection.Input
            inId.Value = Me.Id

            Dim inMotivo As OleDbParameter = cmd.Parameters.Add("@inMotivo", OleDbType.Decimal, Nothing)
            inMotivo.Direction = ParameterDirection.Input
            inMotivo.Value = Me.Motivo.ID

            Dim inUsuario As OleDbParameter = cmd.Parameters.Add("@inUsuario", OleDbType.Decimal, Nothing)
            inUsuario.Direction = ParameterDirection.Input
            inUsuario.Value = Me.Usuario.Id

            Dim outError As OleDbParameter = cmd.Parameters.Add("@outError", OleDbType.Integer)
            outError.Direction = ParameterDirection.Output

            conn.Open()
            cmd.ExecuteReader()
            conn.Close()

            Return CInt(cmd.Parameters("@outError").Value)
        End Function

    End Class
End Namespace
