Imports Kaplan.Clases
Namespace Tipos

    Public Class TipoEstadoAnimo
        Inherits BaseType
        Private Shared CachedTipo As New CachedType(Of TipoEstadoAnimo)
        Private Shared CachedCollection As New Dictionary(Of Integer, TipoEstadoAnimo)
        Shared Sub New()
            CachedTipo.DataPackage = "Kaplan.ListarTipoFEEstAnimo"
        End Sub
        Shared Function getTipos() As List(Of TipoEstadoAnimo)
            CachedTipo.CachedCollection = CachedCollection
            Return CachedTipo.getTipos
        End Function
        Shared Function getTipo(prmID As Integer) As TipoEstadoAnimo
            CachedTipo.CachedCollection = CachedCollection
            Return CachedTipo.getTipo(prmID)
        End Function
        Shared Sub Release()
            CachedCollection.Clear()
        End Sub
    End Class
End Namespace