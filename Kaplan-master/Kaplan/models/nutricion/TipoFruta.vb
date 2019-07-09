Imports Kaplan.Clases
Namespace Tipos

    Public Class TipoFruta
        Inherits BaseType
        Private Shared CachedTipo As New CachedType(Of TipoFruta)
        Private Shared CachedCollection As New Dictionary(Of Integer, TipoFruta)
        Shared Sub New()
            CachedTipo.DataPackage = "Kaplan.ListarTipoFNFruta"
        End Sub
        Shared Function getTipos() As List(Of TipoFruta)
            CachedTipo.CachedCollection = CachedCollection
            Return CachedTipo.getTipos
        End Function
        Shared Function getTipo(prmID As Integer) As TipoFruta
            CachedTipo.CachedCollection = CachedCollection
            Return CachedTipo.getTipo(prmID)
        End Function
        Shared Sub Release()
            CachedCollection.Clear()
        End Sub
    End Class
End Namespace