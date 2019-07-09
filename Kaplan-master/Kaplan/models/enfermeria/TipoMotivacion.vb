Imports Kaplan.Clases
Namespace Tipos

    Public Class TipoMotivacion
        Inherits BaseType
        Private Shared CachedTipo As New CachedType(Of TipoMotivacion)
        Private Shared CachedCollection As New Dictionary(Of Integer, TipoMotivacion)
        Shared Sub New()
            CachedTipo.DataPackage = "Kaplan.ListarTipoFEMotiv"
        End Sub
        Shared Function getTipos() As List(Of TipoMotivacion)
            CachedTipo.CachedCollection = CachedCollection
            Return CachedTipo.getTipos
        End Function
        Shared Function getTipo(prmID As Integer) As TipoMotivacion
            CachedTipo.CachedCollection = CachedCollection
            Return CachedTipo.getTipo(prmID)
        End Function
        Shared Sub Release()
            CachedCollection.Clear()
        End Sub
    End Class
End Namespace