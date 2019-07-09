Imports Kaplan.Clases
Namespace Tipos

    Public Class TipoToraxD
        Inherits BaseType
        Private Shared CachedTipo As New CachedType(Of TipoToraxD)
        Private Shared CachedCollection As New Dictionary(Of Integer, TipoToraxD)
        Shared Sub New()
            CachedTipo.DataPackage = "Kaplan.ListarTipoFEToraxD"
        End Sub
        Shared Function getTipos() As List(Of TipoToraxD)
            CachedTipo.CachedCollection = CachedCollection
            Return CachedTipo.getTipos
        End Function
        Shared Function getTipo(prmID As Integer) As TipoToraxD
            CachedTipo.CachedCollection = CachedCollection
            Return CachedTipo.getTipo(prmID)
        End Function
        Shared Sub Release()
            CachedCollection.Clear()
        End Sub
    End Class
End Namespace