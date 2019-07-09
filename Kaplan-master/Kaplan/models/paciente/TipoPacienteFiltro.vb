Imports System.Data.OleDb
Imports Kaplan.Clases
Namespace Tipos

    Public Class TipoPacienteFiltro
        Public ID As String
        Public Nombre As String
        Public Activo As String

        Private Shared CachedCollection As New Dictionary(Of String, TipoPacienteFiltro)
        Shared Function getTipos() As List(Of TipoPacienteFiltro)
            If Not IsNothing(CachedCollection) AndAlso CachedCollection.Count = 0 Then getListado()
            Return CachedCollection.Values.ToList
        End Function
        Shared Function getTipo(prmID As Integer) As TipoPacienteFiltro
            If Not IsNothing(CachedCollection) AndAlso CachedCollection.Count = 0 Then getListado()
            Return CachedCollection(prmID)
        End Function
        Private Shared Sub getListado()
            Dim conn As OleDbConnection = New OleDbConnection(ConfigurationManager.ConnectionStrings("ConexionKaplan").ConnectionString)
            Dim cmd As OleDbCommand = New OleDbCommand("Kaplan.ListarPacientesFiltro", conn)
            cmd.CommandType = CommandType.StoredProcedure

            conn.Open()
            Dim adapter As OleDbDataAdapter = New OleDbDataAdapter(cmd)
            Dim vDataTable As New DataTable
            adapter.Fill(vDataTable)

            CachedCollection = New Dictionary(Of String, TipoPacienteFiltro)
            Dim vPaciente As TipoPacienteFiltro
            For Each vRow As DataRow In vDataTable.Rows
                vPaciente = New TipoPacienteFiltro
                vPaciente.ID = vRow("ID")
                vPaciente.Nombre = vRow("NOMBRE")
                vPaciente.Activo = vRow("ACTIVO")
                CachedCollection.Add(vPaciente.ID, vPaciente)
            Next
            conn.Close()
        End Sub

        Shared Sub Release()
            CachedCollection.Clear()
        End Sub
    End Class
End Namespace