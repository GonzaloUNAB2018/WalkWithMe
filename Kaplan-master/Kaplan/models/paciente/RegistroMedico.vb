Imports Kaplan.Clases
Imports System.Globalization
Imports System.Data.OleDb
Imports System.Data.SqlClient

Namespace Clases
    Public Class RegistroMedico
        Public Property Id As Integer
        Public Property Paciente As Integer
        Public Property Registro As String
        Public Property idEspecialistaEmisor As Integer
        Public Property EspecialistaEmisor As String
        Public Property idEspecialistaReceptor As Integer
        Public Property EspecialistaReceptor As String
        Public Property idEspecialidadReceptor As Tipos.TipoEspecialidad
        Public Property Fecha As Date
        Public Property FechaLeido As Nullable(Of Date)
        Public Property Estado As Integer
        Public ReadOnly Property FechaLeidoString As String
            Get
                If IsNothing(_FechaLeido) Then
                    Return ""
                Else
                    Return CDate(_FechaLeido).ToString("dd MMM yyyy")
                End If
            End Get
        End Property
        Public ReadOnly Property FechaString As String
            Get
                Return Fecha.ToString("dd MMM yyyy")
            End Get
        End Property
        Private Shared Function Mapeo(prmRow As DataRow) As RegistroMedico
            Try
                Dim vClass As New RegistroMedico
                vClass.Id = prmRow("ID")
                vClass.Registro = prmRow("Registro")
                vClass.EspecialistaReceptor = prmRow("EspecialistaReceptor").ToString
                vClass.Fecha = prmRow("Fecha")
                If Not IsDBNull(prmRow("FechaLeido")) AndAlso Not prmRow("FechaLeido").Equals(" ") Then vClass.FechaLeido = prmRow("FechaLeido").ToString
                vClass.EspecialistaEmisor = prmRow("EspecialistaEmisor")
                vClass.idEspecialidadReceptor = Tipos.TipoEspecialidad.getTipo(prmRow("idEspecialidadReceptor"))
                vClass.Estado = prmRow("Estado")
                Return vClass

            Catch ex As Exception
                Return Nothing
            End Try
        End Function
        Public Shared Function getRegistrosMedicos(inRut As Integer) As List(Of RegistroMedico)
            Try
                Dim conn As OleDbConnection = New OleDbConnection(ConfigurationManager.ConnectionStrings("ConexionKaplan").ConnectionString)
                Dim cmd As OleDbCommand = New OleDbCommand("Kaplan.ListadoRegistrosMedicos", conn)
                cmd.CommandType = CommandType.StoredProcedure

                Dim inPaciente As OleDbParameter = cmd.Parameters.Add("@inPaciente", OleDbType.Decimal, Nothing)
                inPaciente.Direction = ParameterDirection.Input
                inPaciente.Value = inRut

                conn.Open()
                Dim adapter As OleDbDataAdapter = New OleDbDataAdapter(cmd)
                Dim vDataTable As New DataTable
                adapter.Fill(vDataTable)
                getRegistrosMedicos = New List(Of RegistroMedico)
                For Each vRow As DataRow In vDataTable.Rows
                    getRegistrosMedicos.Add(Mapeo(vRow))
                Next
                conn.Close()
                Return getRegistrosMedicos
            Catch exc As Exception
                Return Nothing
            End Try

        End Function
        Public Function registrarRegistroMedico() As Boolean
            Try
                Dim conn As OleDbConnection = New OleDbConnection(ConfigurationManager.ConnectionStrings("ConexionKaplan").ConnectionString)
                Dim cmd As OleDbCommand = New OleDbCommand("Kaplan.Kaplan.RegistrarRegistroMedico", conn)
                cmd.CommandType = CommandType.StoredProcedure

                Dim inPaciente As OleDbParameter = cmd.Parameters.Add("@inPaciente", OleDbType.Decimal, Nothing)
                inPaciente.Direction = ParameterDirection.Input
                inPaciente.Value = Me.Paciente

                Dim inEspecialista As OleDbParameter = cmd.Parameters.Add("@inEspecialista", OleDbType.Decimal, Nothing)
                inEspecialista.Direction = ParameterDirection.Input
                inEspecialista.Value = Me.idEspecialistaEmisor

                Dim inRegistro As OleDbParameter = cmd.Parameters.Add("@inRegistro", OleDbType.VarChar, 500)
                inRegistro.Direction = ParameterDirection.Input
                inRegistro.Value = Me.Registro

                Dim inEspecialidad As OleDbParameter = cmd.Parameters.Add("@inEspecialidad", OleDbType.Decimal, Nothing)
                inEspecialidad.Direction = ParameterDirection.Input
                inEspecialidad.Value = Me.idEspecialidadReceptor.ID

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
        Public Function EliminarRegistroMedico(Id As Integer) As Boolean
            Try
                Dim conn As OleDbConnection = New OleDbConnection(ConfigurationManager.ConnectionStrings("ConexionKaplan").ConnectionString)
                Dim cmd As OleDbCommand = New OleDbCommand("Kaplan.Kaplan.EliminarRegistroMedico", conn)
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
        Public Function MarcarLeidoRegistroMedico(Id As Integer, idEspecialista As Integer) As Boolean
            Try
                Dim conn As OleDbConnection = New OleDbConnection(ConfigurationManager.ConnectionStrings("ConexionKaplan").ConnectionString)
                Dim cmd As OleDbCommand = New OleDbCommand("Kaplan.Kaplan.MarcarLeidoRegistroMedico", conn)
                cmd.CommandType = CommandType.StoredProcedure

                Dim inId As OleDbParameter = cmd.Parameters.Add("@inId", OleDbType.Decimal, Nothing)
                inId.Direction = ParameterDirection.Input
                inId.Value = Id

                Dim inIdEspecialista As OleDbParameter = cmd.Parameters.Add("@inIdEspecialista", OleDbType.Decimal, Nothing)
                inIdEspecialista.Direction = ParameterDirection.Input
                inIdEspecialista.Value = idEspecialista

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


