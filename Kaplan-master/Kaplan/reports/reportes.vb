Imports Kaplan.Clases
Imports System.Globalization
Imports System.Data.OleDb
Imports System.Data.SqlClient
Imports System.IO
Public Class reportes
    Public Shared Function reporteNutricion(inId As Integer) As DataTable
        Try
            Dim conn As OleDbConnection = New OleDbConnection(ConfigurationManager.ConnectionStrings("ConexionKaplan").ConnectionString)
            Dim cmd As OleDbCommand = New OleDbCommand("Kaplan.ReporteNutricion", conn)
            cmd.CommandType = CommandType.StoredProcedure

            Dim Id As OleDbParameter = cmd.Parameters.Add("@inPaciente", OleDbType.Decimal, Nothing)
            Id.Direction = ParameterDirection.Input
            Id.Value = inId

            Dim adapter As OleDbDataAdapter = New OleDbDataAdapter(cmd)
            Dim vDataTable As New DataTable
            adapter.Fill(vDataTable)
            If Not vDataTable.Rows.Count.Equals(0) Then
                Return vDataTable
            Else
                Return Nothing
            End If
        Catch exc As Exception
            Return Nothing
        End Try
    End Function
    Public Shared Function reportePsicologia(inId As Integer) As DataTable
        Try
            Dim conn As OleDbConnection = New OleDbConnection(ConfigurationManager.ConnectionStrings("ConexionKaplan").ConnectionString)
            Dim cmd As OleDbCommand = New OleDbCommand("Kaplan.ReportePsicologia", conn)
            cmd.CommandType = CommandType.StoredProcedure

            Dim Id As OleDbParameter = cmd.Parameters.Add("@inPaciente", OleDbType.Decimal, Nothing)
            Id.Direction = ParameterDirection.Input
            Id.Value = inId

            Dim adapter As OleDbDataAdapter = New OleDbDataAdapter(cmd)
            Dim vDataTable As New DataTable
            adapter.Fill(vDataTable)
            If Not vDataTable.Rows.Count.Equals(0) Then
                Return vDataTable
            Else
                Return Nothing
            End If
        Catch exc As Exception
            Return Nothing
        End Try
    End Function
    Public Shared Function ReporteEvolucion(inId As Integer) As DataTable
        Try
            Dim conn As OleDbConnection = New OleDbConnection(ConfigurationManager.ConnectionStrings("ConexionKaplan").ConnectionString)
            Dim cmd As OleDbCommand = New OleDbCommand("Kaplan.ReporteEvolucion", conn)
            cmd.CommandType = CommandType.StoredProcedure

            Dim Id As OleDbParameter = cmd.Parameters.Add("@inPlan", OleDbType.Decimal, Nothing)
            Id.Direction = ParameterDirection.Input
            Id.Value = inId

            Dim adapter As OleDbDataAdapter = New OleDbDataAdapter(cmd)
            Dim vDataTable As New DataTable
            adapter.Fill(vDataTable)
            If Not vDataTable.Rows.Count.Equals(0) Then
                Return vDataTable
            Else
                Return Nothing
            End If
        Catch exc As Exception
            Return Nothing
        End Try
    End Function

    Public Shared Function reporteKinesiologia(inId As Integer) As DataSet
        Try
            Dim conn As OleDbConnection = New OleDbConnection(ConfigurationManager.ConnectionStrings("ConexionKaplan").ConnectionString)
            Dim cmd As OleDbCommand = New OleDbCommand("Kaplan.ReporteKinesiologia", conn)
            cmd.CommandType = CommandType.StoredProcedure

            Dim Id As OleDbParameter = cmd.Parameters.Add("@inPaciente", OleDbType.Decimal, Nothing)
            Id.Direction = ParameterDirection.Input
            Id.Value = inId

            Dim adapter As OleDbDataAdapter = New OleDbDataAdapter(cmd)
            Dim vDataSet As New DataSet
            adapter.Fill(vDataSet)

            If Not vDataSet.Tables.Count.Equals(0) Then
                Return vDataSet
            Else
                Return Nothing
            End If
        Catch exc As Exception
            Return Nothing
        End Try
    End Function
    Public Shared Function reporteEnfermeria(inId As Integer) As DataSet
        Try
            Dim conn As OleDbConnection = New OleDbConnection(ConfigurationManager.ConnectionStrings("ConexionKaplan").ConnectionString)
            Dim cmd As OleDbCommand = New OleDbCommand("Kaplan.ReporteEnfermeria", conn)
            cmd.CommandType = CommandType.StoredProcedure

            Dim Id As OleDbParameter = cmd.Parameters.Add("@inPaciente", OleDbType.Decimal, Nothing)
            Id.Direction = ParameterDirection.Input
            Id.Value = inId

            Dim adapter As OleDbDataAdapter = New OleDbDataAdapter(cmd)
            Dim vDataSet As New DataSet
            adapter.Fill(vDataSet)

            If Not vDataSet.Tables.Count.Equals(0) Then
                Return vDataSet
            Else
                Return Nothing
            End If
        Catch exc As Exception
            Return Nothing
        End Try
    End Function
    Public Shared Function reporteMedico(inId As Integer) As DataSet
        Try
            Dim conn As OleDbConnection = New OleDbConnection(ConfigurationManager.ConnectionStrings("ConexionKaplan").ConnectionString)
            Dim cmd As OleDbCommand = New OleDbCommand("Kaplan.ReporteMedico", conn)
            cmd.CommandType = CommandType.StoredProcedure

            Dim Id As OleDbParameter = cmd.Parameters.Add("@inPaciente", OleDbType.Decimal, Nothing)
            Id.Direction = ParameterDirection.Input
            Id.Value = inId

            Dim adapter As OleDbDataAdapter = New OleDbDataAdapter(cmd)
            Dim vDataSet As New DataSet
            adapter.Fill(vDataSet)

            If Not vDataSet.Tables.Count.Equals(0) Then
                Return vDataSet
            Else
                Return Nothing
            End If
        Catch exc As Exception
            Return Nothing
        End Try
    End Function
End Class
