Imports Kaplan.Clases
Namespace Tipos

    Public Class TipoRegion
        Inherits BaseType
        Private Shared CachedTipo As New CachedType(Of TipoRegion)
        Private Shared CachedCollection As New Dictionary(Of Integer, TipoRegion)
        Shared Sub New()
            CachedTipo.DataPackage = "Kaplan.ListarTipoRegion"
        End Sub
        Shared Function getTipos() As List(Of TipoRegion)
            CachedTipo.CachedCollection = CachedCollection
            Return CachedTipo.getTipos
        End Function
        Shared Function getTipo(prmID As Integer) As TipoRegion
            CachedTipo.CachedCollection = CachedCollection
            Return CachedTipo.getTipo(prmID)
        End Function
        Shared Sub Release()
            CachedCollection.Clear()
        End Sub
    End Class
End Namespace