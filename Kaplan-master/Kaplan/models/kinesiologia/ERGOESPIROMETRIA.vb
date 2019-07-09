Imports Kaplan.Clases
Imports System.Globalization
Imports System.Data.OleDb
Imports System.Data.SqlClient

Namespace Clases

    Public Class Ergoespirometria
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
        Public Property VO2LIngreso As Double
        Public Property VO2LEgreso As Double
        Public Property VO2MIngreso As Double
        Public Property VO2MEgreso As Double
        Public Property FCIngreso As Double
        Public Property FCEgreso As Double
        Public Property PulsoIngreso As Double
        Public Property PulsoEgreso As Double
        Public Property VEIngreso As Double
        Public Property VEEgreso As Double
        Public Property METSIngreso As Double
        Public Property METSEgreso As Double
    End Class

End Namespace