Imports Kaplan.Clases
Imports System.Globalization
Imports System.Data.OleDb
Imports System.Data.SqlClient

Namespace Clases

    Public Class Shuttle
        Public Property EFechaIngreso As Date
        Public ReadOnly Property EFechaIngresoString As String
            Get
                Return EFechaIngreso.ToString("dd MMM yyyy")
            End Get
        End Property
        Public Property EFechaEgreso As Date
        Public ReadOnly Property EFechaEgresoString As String
            Get
                Return EFechaEgreso.ToString("dd MMM yyyy")
            End Get
        End Property
        Public Property METROSIngreso As Double
        Public Property METROSEgreso As Double
        Public Property NIVELIngreso As Double
        Public Property NIVELEgreso As Double
        Public Property VO2MIngreso As Double
        Public Property VO2MEgreso As Double
        Public Property METSIngreso As Double
        Public Property METSEgreso As Double
        Public Property FCIngreso As Double
        Public Property FCEgreso As Double
        Public Property FCMTIngreso As Double
        Public Property FCMTEgreso As Double
        Public Property METSMAXIngreso As Double
        Public Property METSMAXEgreso As Double
    End Class

End Namespace
