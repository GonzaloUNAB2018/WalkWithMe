Imports Kaplan.Clases
Imports System.Globalization
Imports System.Data.OleDb
Imports System.Data.SqlClient

Namespace Clases
    Public Class MedicionesAntropometricas
        Public Property PesoActual As Double
        Public Property Talla As Double
        Public Property IMC As Double
        Public Property EstadoIMC As String
        Public Property PesoHabitual As Double
        Public Property PesoMinimoMayor As Double
        Public Property PesoMinimo As Double
        Public Property PesoMaximoMayor As Double
        Public Property PesoMaximo As Double
        Public Property PesoIdeal As Double
        Public Property PesoIdealMayor As Double
        Public Property EstadoIMCAM As String
        Public Property MasaGrasaCorporal As Double
        Public Property MasaMagra As Double
        Public Property IndiceCinturaCadera As Double
        Public Property MNA As Double
        Public Property MasaGrasaPorc As Double
        Public Property GrasaVisceralPorc As Double
        Public Property PCintura As Double
        Public Property Cribaje As Tipos.TipoCribaje
    End Class
End Namespace
