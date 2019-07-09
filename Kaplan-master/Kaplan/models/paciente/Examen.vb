Imports Kaplan.Clases
Imports System.Globalization
Imports System.Data.OleDb
Imports System.Data.SqlClient

Namespace Clases
    Public Class Examen
        Public Property Id As Integer
        Public Property Paciente As Integer
        Public Property Nombre As String
        Public Property Especialista As Integer
        Public Property EspecialistaNombre As String
        Public Property Fecha As Date
        Public Property Formato As String
        Public Property Descripcion As String
        Public ReadOnly Property FechaString As String
            Get
                Return Fecha.ToString("dd MMM yyyy")
            End Get
        End Property
        Private Shared Function Mapeo(prmRow As DataRow) As Examen
            Try
                Dim vExamen As New Examen
                vExamen.Id = prmRow("ID")
                vExamen.Nombre = prmRow("Nombre")
                vExamen.Descripcion = prmRow("Descripcion")
                vExamen.Fecha = prmRow("Fecha")
                vExamen.EspecialistaNombre = prmRow("EspecialistaNombre")
                vExamen.Formato = prmRow("Formato")
                Return vExamen

            Catch ex As Exception
                Return Nothing
            End Try
        End Function
        Public Shared Function getExamenes(inRut As Integer) As List(Of Examen)
            Try
                Dim conn As OleDbConnection = New OleDbConnection(ConfigurationManager.ConnectionStrings("ConexionKaplan").ConnectionString)
                Dim cmd As OleDbCommand = New OleDbCommand("Kaplan.ListadoExamenes", conn)
                cmd.CommandType = CommandType.StoredProcedure

                Dim inPaciente As OleDbParameter = cmd.Parameters.Add("@inPaciente", OleDbType.Decimal, Nothing)
                inPaciente.Direction = ParameterDirection.Input
                inPaciente.Value = inRut

                conn.Open()
                Dim adapter As OleDbDataAdapter = New OleDbDataAdapter(cmd)
                Dim vDataTable As New DataTable
                adapter.Fill(vDataTable)
                getExamenes = New List(Of Examen)
                For Each vRow As DataRow In vDataTable.Rows
                    getExamenes.Add(Mapeo(vRow))
                Next
                conn.Close()
                Return getExamenes
            Catch exc As Exception
                Return Nothing
            End Try

        End Function
        Public Function registrarExamen(archivo As Byte(), formato As String) As Boolean
            Try
                Dim conn As OleDbConnection = New OleDbConnection(ConfigurationManager.ConnectionStrings("ConexionKaplan").ConnectionString)
                Dim cmd As OleDbCommand = New OleDbCommand("Kaplan.RegistrarExamen", conn)
                cmd.CommandType = CommandType.StoredProcedure

                Dim inPaciente As OleDbParameter = cmd.Parameters.Add("@inPaciente", OleDbType.Decimal, Nothing)
                inPaciente.Direction = ParameterDirection.Input
                inPaciente.Value = Me.Paciente

                Dim inEspecialista As OleDbParameter = cmd.Parameters.Add("@inEspecialista", OleDbType.Decimal, Nothing)
                inEspecialista.Direction = ParameterDirection.Input
                inEspecialista.Value = Me.Especialista

                Dim inNombre As OleDbParameter = cmd.Parameters.Add("@inNombre", OleDbType.VarChar, 250)
                inNombre.Direction = ParameterDirection.Input
                inNombre.Value = Me.Nombre

                Dim inFecha As OleDbParameter = cmd.Parameters.Add("@inFecha", OleDbType.Date, Nothing)
                inFecha.Direction = ParameterDirection.Input
                inFecha.Value = Me.Fecha

                Dim inArchivo As OleDbParameter = cmd.Parameters.Add("@inArchivo", OleDbType.VarBinary, -1)
                inArchivo.Direction = ParameterDirection.Input
                inArchivo.Value = archivo

                Dim inFormato As OleDbParameter = cmd.Parameters.Add("@inFormato", OleDbType.VarChar, 250)
                inFormato.Direction = ParameterDirection.Input
                inFormato.Value = formato

                Dim inDescripcion As OleDbParameter = cmd.Parameters.Add("@inDescripcion", OleDbType.VarChar, 250)
                inDescripcion.Direction = ParameterDirection.Input
                inDescripcion.Value = Me.Descripcion

                Dim outError As OleDbParameter = cmd.Parameters.Add("@outError", OleDbType.Integer)
                outError.Direction = ParameterDirection.Output

                conn.Open()
                cmd.ExecuteReader()
                conn.Close()

                Return CInt(cmd.Parameters("@outError").Value)
            Catch exc As Exception
                Return Nothing
            End Try
        End Function
        Public Function EliminarExamen(Id As Integer) As Boolean
            Try
                Dim conn As OleDbConnection = New OleDbConnection(ConfigurationManager.ConnectionStrings("ConexionKaplan").ConnectionString)
                Dim cmd As OleDbCommand = New OleDbCommand("Kaplan.EliminarExamen", conn)
                cmd.CommandType = CommandType.StoredProcedure

                Dim inId As OleDbParameter = cmd.Parameters.Add("@inId", OleDbType.Decimal, Nothing)
                inId.Direction = ParameterDirection.Input
                inId.Value = Id

                Dim outError As OleDbParameter = cmd.Parameters.Add("@outError", OleDbType.Integer)
                outError.Direction = ParameterDirection.Output

                conn.Open()
                cmd.ExecuteReader()
                conn.Close()

                Return CInt(cmd.Parameters("@outError").Value)
            Catch exc As Exception
                Return Nothing
            End Try
        End Function
    End Class
End Namespace


