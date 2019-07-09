Imports Kaplan.Clases
Namespace Tipos

    Public Class TipoIndicador
        Inherits BaseType
        Private Shared CachedTipo As New CachedType(Of TipoIndicador)
        Private Shared CachedCollection As New Dictionary(Of Integer, TipoIndicador)
        Shared Sub New()
            CachedTipo.DataPackage = "Kaplan.ListarTipoFEIndicador"
        End Sub
        Shared Function getTipos() As List(Of TipoIndicador)
            CachedTipo.CachedCollection = CachedCollection
            Return CachedTipo.getTipos
        End Function
        Shared Function getTipo(prmID As Integer) As TipoIndicador
            CachedTipo.CachedCollection = CachedCollection
            Return CachedTipo.getTipo(prmID)
        End Function
        Shared Sub Release()
            CachedCollection.Clear()
        End Sub
    End Class
End Namespace