Imports Agenda.Clases
Imports System.Globalization
Imports System.Data.OleDb
Imports System.Data.SqlClient
Namespace Clases
    Public Class ResumenCalendario
        Public Property Hora As String
        Public Property Lunes As Integer
        Public Property Martes As Integer
        Public Property Miercoles As Integer
        Public Property Jueves As Integer
        Public Property Viernes As Integer
        Public Property Sabado As Integer
        Public Property Domingo As Integer

        Public Shared Function getResumenCalendario(ByVal inFecha As Date, ByVal inEspecialista As Integer) As List(Of ResumenCalendario)
            Try
                Dim conn As OleDbConnection = New OleDbConnection(ConfigurationManager.ConnectionStrings("ConexionKaplan").ConnectionString)
                Dim cmd As OleDbCommand = New OleDbCommand("Kaplan.ListadoReservaSemana", conn)
                cmd.CommandType = CommandType.StoredProcedure

                Dim Fecha As OleDbParameter = cmd.Parameters.Add("@inFecha", OleDbType.Date, Nothing)
                Fecha.Direction = ParameterDirection.Input
                Fecha.Value = inFecha

                Dim Especialista As OleDbParameter = cmd.Parameters.Add("@inId", OleDbType.Decimal, Nothing)
                Especialista.Direction = ParameterDirection.Input
                Especialista.Value = IIf(inEspecialista = -1, DBNull.Value, inEspecialista)

                conn.Open()
                Dim adapter As OleDbDataAdapter = New OleDbDataAdapter(cmd)
                Dim vDataTable As New DataTable
                adapter.Fill(vDataTable)
                getResumenCalendario = New List(Of ResumenCalendario)
                For Each vRow As DataRow In vDataTable.Rows
                    getResumenCalendario.Add(Mapeo(vRow))
                Next
                conn.Close()
                Return getResumenCalendario

            Catch exc As Exception
                Return Nothing
            End Try
        End Function

        Public Shared Function Mapeo(prmRow As DataRow) As ResumenCalendario
            Try
                Dim vResumen As New ResumenCalendario
                vResumen.Hora = prmRow("hora").ToString
                vResumen.Lunes = prmRow("Lunes")
                vResumen.Martes = prmRow("Martes")
                vResumen.Miercoles = prmRow("Miercoles")
                vResumen.Jueves = prmRow("Jueves")
                vResumen.Viernes = prmRow("Viernes")
                vResumen.Sabado = prmRow("Sabado")
                vResumen.Domingo = prmRow("Domingo")
                Return vResumen
            Catch ex As Exception
                Return Nothing
            End Try
        End Function
    End Class
End Namespace
