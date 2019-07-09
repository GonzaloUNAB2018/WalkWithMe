Imports Kaplan.Clases
Imports System.Globalization
Imports System.Data.OleDb
Imports System.Data.SqlClient

Namespace Clases
    Public Class Sf36
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
        Public Property FuncionFisicaIng As Double
        Public Property FuncionFisicaEgr As Double
        Public Property RolFisicoIng As Double
        Public Property RolFisicoEgr As Double
        Public Property DolorIng As Double
        Public Property DolorEgr As Double
        Public Property SaludIng As Double
        Public Property SaludEgr As Double
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
        Public Property VitalidadIng As Double
        Public Property VitalidadEgr As Double
        Public Property FuncionSocialIng As Double
        Public Property FuncionSocialEgr As Double
        Public Property RolEmocionalIng As Double
        Public Property RolEmocionalEgr As Double
        Public Property SaludMentalIng As Double
        Public Property SaludMentalEgr As Double
        Public Property Observacion As String
    End Class
End Namespace
