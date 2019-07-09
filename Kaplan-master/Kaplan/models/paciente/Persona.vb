Imports Kaplan.Clases
Imports System.Globalization
Imports System.Data.OleDb
Imports System.Data.SqlClient

Namespace Clases

    Public Class Persona
        Public Property Id As Integer
        Public Property Rut As Integer
        Public Property Dv As String
        Public Property Nombre As String
        Public Property Paterno As String
        Public Property Materno As String
        Public Property FechaNac As Date
        Public ReadOnly Property FechaNacString As String
            Get
                Return FechaNac.ToString("dd MMM yyyy")
            End Get
        End Property
        Public Property Direccion As String
        Public Property Telefono As Integer
        Public Property Movil As Integer
        Public Property Region As Tipos.TipoRegion
        Public Property Comuna As Tipos.TipoComuna
        Public Property SituacionLaboral As String

    End Class

End Namespace
