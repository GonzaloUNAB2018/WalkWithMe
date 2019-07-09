Imports Kaplan.Clases
Namespace Tipos

    Public Class TipoValoracion
        Inherits BaseType
        Private Shared CachedTipo As New CachedType(Of TipoValoracion)
        Private Shared CachedCollection As New Dictionary(Of Integer, TipoValoracion)
        Shared Sub New()
            CachedTipo.DataPackage = "Kaplan.ListarTipoFEValoracion"
        End Sub
        Shared Function getTipos() As List(Of TipoValoracion)
            CachedTipo.CachedCollection = CachedCollection
            Return CachedTipo.getTipos
        End Function
        Shared Function getTipo(prmID As Integer) As TipoValoracion
            CachedTipo.CachedCollection = CachedCollection
            Return CachedTipo.getTipo(prmID)
        End Function
        Shared Sub Release()
            CachedCollection.Clear()
        End Sub
    End Class
End Namespace