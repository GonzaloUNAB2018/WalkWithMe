Imports Kaplan.Clases
Namespace Tipos

    Public Class TipoPescado
        Inherits BaseType
        Private Shared CachedTipo As New CachedType(Of TipoPescado)
        Private Shared CachedCollection As New Dictionary(Of Integer, TipoPescado)
        Shared Sub New()
            CachedTipo.DataPackage = "Kaplan.ListarTipoFNPescado"
        End Sub
        Shared Function getTipos() As List(Of TipoPescado)
            CachedTipo.CachedCollection = CachedCollection
            Return CachedTipo.getTipos
        End Function
        Shared Function getTipo(prmID As Integer) As TipoPescado
            CachedTipo.CachedCollection = CachedCollection
            Return CachedTipo.getTipo(prmID)
        End Function
        Shared Sub Release()
            CachedCollection.Clear()
        End Sub
    End Class
End Namespace