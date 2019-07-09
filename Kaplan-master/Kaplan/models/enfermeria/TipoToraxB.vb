Imports Kaplan.Clases
Namespace Tipos

    Public Class TipoToraxB
        Inherits BaseType
        Private Shared CachedTipo As New CachedType(Of TipoToraxB)
        Private Shared CachedCollection As New Dictionary(Of Integer, TipoToraxB)
        Shared Sub New()
            CachedTipo.DataPackage = "Kaplan.ListarTipoFEToraxB"
        End Sub
        Shared Function getTipos() As List(Of TipoToraxB)
            CachedTipo.CachedCollection = CachedCollection
            Return CachedTipo.getTipos
        End Function
        Shared Function getTipo(prmID As Integer) As TipoToraxB
            CachedTipo.CachedCollection = CachedCollection
            Return CachedTipo.getTipo(prmID)
        End Function
        Shared Sub Release()
            CachedCollection.Clear()
        End Sub
    End Class
End Namespace