Imports Kaplan.Clases
Namespace Tipos

    Public Class TipoDiagnosticoKine
        Inherits BaseType
        Private Shared CachedTipo As New CachedType(Of TipoDiagnosticoKine)
        Private Shared CachedCollection As New Dictionary(Of Integer, TipoDiagnosticoKine)
        Shared Sub New()
            CachedTipo.DataPackage = "Kaplan.ListarTipoDiagnostico"
        End Sub
        Shared Function getTipos() As List(Of TipoDiagnosticoKine)
            CachedTipo.CachedCollection = CachedCollection
            Return CachedTipo.getTipos
        End Function
        Shared Function getTipo(prmID As Integer) As TipoDiagnosticoKine
            CachedTipo.CachedCollection = CachedCollection
            Return CachedTipo.getTipo(prmID)
        End Function
        Shared Sub Release()
            CachedCollection.Clear()
        End Sub
    End Class
End Namespace