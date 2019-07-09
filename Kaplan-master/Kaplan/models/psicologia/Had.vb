Imports Kaplan.Clases
Imports System.Globalization
Imports System.Data.OleDb
Imports System.Data.SqlClient

Namespace Clases
    Public Class Had
        Public Property FechaAIng As Date
        Public ReadOnly Property FechaAIngString As String
            Get
                Return FechaAIng.ToString("dd MMM yyyy")
            End Get
        End Property
        Public Property FechaAEgr As Date
        Public ReadOnly Property FechaAEgrString As String
            Get
                Return FechaAEgr.ToString("dd MMM yyyy")
            End Get
        End Property
        Public Property AnsiedadIng As Double
        Public Property AnsiedadEgr As Double
        Public Property DepresionIng As Double
        Public Property DepresionEgr As Double
        Public Property FechaBIng As Date
        Public ReadOnly Property FechaBIngString As String
            Get
                Return FechaBIng.ToString("dd MMM yyyy")
            End Get
        End Property
        Public Property FechaBEgr As Date
        Public ReadOnly Property FechaBEgrString As String
            Get
                Return FechaBEgr.ToString("dd MMM yyyy")
            End Get
        End Property
        Public Property SubEscalaAnsiedadIng As Double
        Public Property SubEscalaAnsiedadEgr As Double
        Public Property SubEscalaDepresionIng As Double
        Public Property SubEscalaDepresionEgr As Double
        Public Property Observacion As String
    End Class
End Namespace
