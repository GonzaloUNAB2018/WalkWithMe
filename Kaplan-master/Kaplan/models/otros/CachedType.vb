Imports System.Data.OleDb
Imports System.Data.SqlClient

Namespace Clases
    Public Class CachedType(Of entryType As {New, typeInterfase})
        Public CachedCollection As New Dictionary(Of Integer, entryType)
        Public DataPackage As String
        Public DataLock As New Object

        Public Function Updated() As Boolean
            Return (Not IsNothing(CachedCollection)) AndAlso CachedCollection.Count > 0
        End Function

        Public Function getTipos() As List(Of entryType)
            SyncLock DataLock
                If Not Updated() Then
                    Dim conn As OleDbConnection = New OleDbConnection(ConfigurationManager.ConnectionStrings("ConexionKaplan").ConnectionString)
                    Dim cmd As OleDbCommand = New OleDbCommand(DataPackage, conn)
                    cmd.CommandType = CommandType.StoredProcedure

                    If Not IsNothing(CachedCollection) Then CachedCollection.Clear()
                    CachedCollection = New Dictionary(Of Integer, entryType)

                    conn.Open()
                    Dim adapter As OleDbDataAdapter = New OleDbDataAdapter(cmd)
                    Dim vDataTable As New DataTable
                    adapter.Fill(vDataTable)

                    For Each vRow As DataRow In vDataTable.Rows
                        Dim vTipo As New entryType
                        vTipo.ID = vRow("ID")
                        vTipo.Nombre = vRow("NOMBRE")
                        vTipo.Activo = vRow("ACTIVO")
                        CachedCollection.Add(vTipo.ID, vTipo)
                    Next
                    vDataTable.Dispose()
                    conn.Close()
                    conn.Dispose()
                End If


                If Updated() Then
                    Return CachedCollection.Values.ToList
                Else
                    Return Nothing
                End If
            End SyncLock

        End Function

        Public Function getTipo(prmID As Integer) As entryType
            getTipos()
            Return CachedCollection(prmID)
        End Function
    End Class

    Public Class BaseType
        Implements typeInterfase
        Public Property Activo As Boolean Implements typeInterfase.Activo

        Public Property ID As Integer Implements typeInterfase.ID

        Public Property Nombre As String Implements typeInterfase.Nombre
    End Class

    Public Interface typeInterfase
        Property ID As Integer
        Property Nombre As String
        Property Activo As Boolean
    End Interface


End Namespace
