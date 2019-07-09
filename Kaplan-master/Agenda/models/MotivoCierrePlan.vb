Imports System.Data.OleDb
Imports System.Data.SqlClient

Namespace Clases
    Public Class MotivoCierrePlan
        Public Property Id As Integer
        Public Property Estado As Integer
        Public Property Nombre As String
        Public ReadOnly Property EstadoString As String
            Get
                If Estado = 1 Then
                    Return "Activo"
                Else
                    Return "Inactivo"
                End If
            End Get
        End Property
        Public Shared Function getMotivosCierrePlan() As List(Of MotivoCierrePlan)
            Try
                Dim conn As OleDbConnection = New OleDbConnection(ConfigurationManager.ConnectionStrings("ConexionKaplan").ConnectionString)
                Dim cmd As OleDbCommand = New OleDbCommand("Kaplan.ListarTipoMotivoPlan", conn)
                cmd.CommandType = CommandType.StoredProcedure

                conn.Open()
                Dim adapter As OleDbDataAdapter = New OleDbDataAdapter(cmd)
                Dim vDataTable As New DataTable
                adapter.Fill(vDataTable)
                getMotivosCierrePlan = New List(Of MotivoCierrePlan)
                For Each vRow As DataRow In vDataTable.Rows
                    getMotivosCierrePlan.Add(Mapeo(vRow))
                Next
                conn.Close()
                Return getMotivosCierrePlan

            Catch exc As Exception
            End Try

        End Function
        Private Shared Function Mapeo(prmRow As DataRow) As MotivoCierrePlan
            Try
                Dim vMotivoCierrePlan As New MotivoCierrePlan
                vMotivoCierrePlan.Id = prmRow("ID")
                vMotivoCierrePlan.Nombre = prmRow("NOMBRE")
                vMotivoCierrePlan.Estado = prmRow("ACTIVO")
                Return vMotivoCierrePlan

            Catch ex As Exception
                Return Nothing
            End Try
        End Function
        Public Function registrarMotivo() As Boolean
            Dim conn As OleDbConnection = New OleDbConnection(ConfigurationManager.ConnectionStrings("ConexionKaplan").ConnectionString)
            Dim cmd As OleDbCommand = New OleDbCommand("Kaplan.RegistrarMotivoCierrePlan", conn)
            cmd.CommandType = CommandType.StoredProcedure

            Dim inIdEspecialista As OleDbParameter = cmd.Parameters.Add("@inId", OleDbType.Decimal, Nothing)
            inIdEspecialista.Direction = ParameterDirection.Input
            inIdEspecialista.Value = Me.Id

            Dim inDia As OleDbParameter = cmd.Parameters.Add("@inNombre", OleDbType.VarChar, 100)
            inDia.Direction = ParameterDirection.Input
            inDia.Value = Me.Nombre

            Dim outError As OleDbParameter = cmd.Parameters.Add("@outError", OleDbType.Integer)
            outError.Direction = ParameterDirection.Output

            conn.Open()
            cmd.ExecuteReader()
            conn.Close()

            Return CInt(cmd.Parameters("@outError").Value)
        End Function
        Public Function eliminarMotivo() As Boolean
            Dim conn As OleDbConnection = New OleDbConnection(ConfigurationManager.ConnectionStrings("ConexionKaplan").ConnectionString)
            Dim cmd As OleDbCommand = New OleDbCommand("Kaplan.EliminarMotivoCierrePlan", conn)
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
