Imports Kaplan.Clases
Imports System.Globalization
Imports System.Data.OleDb
Imports System.Data.SqlClient

Namespace Clases
    Public Class Plan

        Public Property Id As Integer
        Public Property Nombre As String
        Public Property Estado As Tipos.TipoEstadoPlan

        Private Shared Function Mapeo(prmRow As DataRow) As Plan
            Try
                Dim vPlan As New Plan
                vPlan.Id = prmRow("ID")
                vPlan.Nombre = prmRow("Nombre")
                vPlan.Estado = Tipos.TipoEstadoPlan.getTipo(prmRow("Estado"))

                Return vPlan

            Catch ex As Exception
                Return Nothing
            End Try
        End Function
        Public Shared Function getPlanesxRut(ByVal inRut As Integer) As List(Of Plan)
            Try
                Dim conn As OleDbConnection = New OleDbConnection(ConfigurationManager.ConnectionStrings("ConexionKaplan").ConnectionString)
                Dim cmd As OleDbCommand = New OleDbCommand("Kaplan.BuscarPlanxRut", conn)
                cmd.CommandType = CommandType.StoredProcedure

                Dim Rut As OleDbParameter = cmd.Parameters.Add("@inRut", OleDbType.Decimal, Nothing)
                Rut.Direction = ParameterDirection.Input
                Rut.Value = inRut

                conn.Open()
                Dim adapter As OleDbDataAdapter = New OleDbDataAdapter(cmd)
                Dim vDataTable As New DataTable
                adapter.Fill(vDataTable)
                getPlanesxRut = New List(Of Plan)
                For Each vRow As DataRow In vDataTable.Rows
                    getPlanesxRut.Add(Mapeo(vRow))
                Next
                conn.Close()
                Return getPlanesxRut
            Catch exc As Exception
                Return Nothing
            End Try

        End Function


    End Class
End Namespace

