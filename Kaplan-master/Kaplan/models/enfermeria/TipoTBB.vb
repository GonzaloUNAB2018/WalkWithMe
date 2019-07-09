Imports Kaplan.Clases
Namespace Tipos

    Public Class TipoTBB
        Inherits BaseType
        Private Shared CachedTipo As New CachedType(Of TipoTBB)
        Private Shared CachedCollection As New Dictionary(Of Integer, TipoTBB)
        Shared Sub New()
            CachedTipo.DataPackage = "Kaplan.ListarTipoFETBB"
        End Sub
        Shared Function getTipos() As List(Of TipoTBB)
            CachedTipo.CachedCollection = CachedCollection
            Return CachedTipo.getTipos
        End Function
        Shared Function getTipo(prmID As Integer) As TipoTBB
            CachedTipo.CachedCollection = CachedCollection
            Return CachedTipo.getTipo(prmID)
        End Function
        Shared Sub Release()
            CachedCollection.Clear()
        End Sub
    End Class
End Namespace