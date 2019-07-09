Imports Agenda.Clases
Imports System.Globalization
Imports System.Data.OleDb
Imports System.Data.SqlClient
Namespace Clases
    Public Class Dia
        Public Property Fecha As Date
        Public Property Hora As String
        Public Property Total As Integer
        Public Property Dia As Integer
        Public Shared Function getDias(ByVal inFecha As String, ByVal inDia As Integer) As List(Of Dia)
            Try
                Dim conn As OleDbConnection = New OleDbConnection(ConfigurationManager.ConnectionStrings("ConexionKaplan").ConnectionString)
                Dim cmd As OleDbCommand = New OleDbCommand("Kaplan.ListadoReservasHoras", conn)
                cmd.CommandType = CommandType.StoredProcedure

                Dim Fecha As OleDbParameter = cmd.Parameters.Add("@inFecha", OleDbType.VarChar, 20)
                Fecha.Direction = ParameterDirection.Input
                Fecha.Value = "07-09-2018"

                Dim Dia As OleDbParameter = cmd.Parameters.Add("@inDia", OleDbType.Decimal, Nothing)
                Dia.Direction = ParameterDirection.Input
                Dia.Value = 1

                conn.Open()
                Dim adapter As OleDbDataAdapter = New OleDbDataAdapter(cmd)
                Dim vDataTable As New DataTable
                adapter.Fill(vDataTable)
                getDias = New List(Of Dia)
                For Each vRow As DataRow In vDataTable.Rows
                    getDias.Add(Mapeo(vRow))
                Next
                conn.Close()
                Return getDias

            Catch exc As Exception
                Return Nothing
            End Try
        End Function
        Public Shared Function Mapeo(prmRow As DataRow) As Dia
            Try
                Dim vResumen As New Dia
                vResumen.Fecha = prmRow("fecha")
                vResumen.Hora = prmRow("hora")
                vResumen.Total = prmRow("total")
                vResumen.Dia = prmRow("dia")
                Return vResumen
            Catch ex As Exception
                Return Nothing
            End Try
        End Function
    End Class
End Namespace

