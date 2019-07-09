Imports Kaplan.Clases
Namespace Tipos

    Public Class TipoToraxA
        Inherits BaseType
        Private Shared CachedTipo As New CachedType(Of TipoToraxA)
        Private Shared CachedCollection As New Dictionary(Of Integer, TipoToraxA)
        Shared Sub New()
            CachedTipo.DataPackage = "Kaplan.ListarTipoFEToraxA"
        End Sub
        Shared Function getTipos() As List(Of TipoToraxA)
            CachedTipo.CachedCollection = CachedCollection
            Return CachedTipo.getTipos
        End Function
        Shared Function getTipo(prmID As Integer) As TipoToraxA
            CachedTipo.CachedCollection = CachedCollection
            Return CachedTipo.getTipo(prmID)
        End Function
        Shared Sub Release()
            CachedCollection.Clear()
        End Sub
    End Class
End Namespace