Imports System.IO
Imports System.Globalization
Imports System.Data.OleDb
Imports System.Data.SqlClient

Namespace Classes
    Public Class Reporte
        Public Shared Function getReporteMasivo(ByVal inRut As String) As DataTable
            Try
                Dim conn As OleDbConnection = New OleDbConnection(ConfigurationManager.ConnectionStrings("ConexionKaplan").ConnectionString)
                Dim cmd As OleDbCommand = New OleDbCommand("Kaplan.ReportePaciente", conn)
                cmd.CommandType = CommandType.StoredProcedure

                Dim Hora As OleDbParameter = cmd.Parameters.Add("@inRut", OleDbType.VarChar, 10)
                Hora.Direction = ParameterDirection.Input
                Hora.Value = IIf(inRut = 0, DBNull.Value, inRut)

                conn.Open()
                Dim adapter As OleDbDataAdapter = New OleDbDataAdapter(cmd)
                Dim vDataTable As New DataTable
                adapter.Fill(vDataTable)
                Return vDataTable

            Catch exc As Exception
            End Try
        End Function
    End Class
End Namespace