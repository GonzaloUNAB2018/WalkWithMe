Imports System.Data.OleDb
Imports System.Data.SqlClient

Namespace Clases

    Public Class Sesion
        Public Property Id As Integer
        Public Property Nombre As String

        Private Shared Function Mapeo(prmRow As DataRow) As Sesion
            Try
                Dim vSesion As New Sesion
                vSesion.Id = prmRow("ID")
                vSesion.Nombre = prmRow("Nombre")

                Return vSesion

            Catch ex As Exception
                Return Nothing
            End Try
        End Function
        Public Shared Function getSesionxPlan(ByVal intPlan As Integer, ByVal intEspecialidad As Integer) As List(Of Sesion)
            Try
                Dim conn As OleDbConnection = New OleDbConnection(ConfigurationManager.ConnectionStrings("ConexionKaplan").ConnectionString)
                Dim cmd As OleDbCommand = New OleDbCommand("Kaplan.BuscarSesionesxPlan", conn)
                cmd.CommandType = CommandType.StoredProcedure

                Dim Plan As OleDbParameter = cmd.Parameters.Add("@inIdPlan", OleDbType.Decimal, Nothing)
                Plan.Direction = ParameterDirection.Input
                Plan.Value = intPlan

                Dim Especialidad As OleDbParameter = cmd.Parameters.Add("@inIdEspecialidad", OleDbType.Decimal, Nothing)
                Especialidad.Direction = ParameterDirection.Input
                Especialidad.Value = intEspecialidad

                conn.Open()
                Dim adapter As OleDbDataAdapter = New OleDbDataAdapter(cmd)
                Dim vDataTable As New DataTable
                adapter.Fill(vDataTable)
                getSesionxPlan = New List(Of Sesion)
                For Each vRow As DataRow In vDataTable.Rows
                    getSesionxPlan.Add(Mapeo(vRow))
                Next
                conn.Close()
                Return getSesionxPlan
            Catch exc As Exception
            End Try

        End Function

    End Class
End Namespace