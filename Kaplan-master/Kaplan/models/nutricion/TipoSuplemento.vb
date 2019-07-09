Imports Kaplan.Clases
Namespace Tipos

    Public Class TipoSuplemento
        Inherits BaseType
        Private Shared CachedTipo As New CachedType(Of TipoSuplemento)
        Private Shared CachedCollection As New Dictionary(Of Integer, TipoSuplemento)
        Shared Sub New()
            CachedTipo.DataPackage = "Kaplan.ListarTipoFNSuplemento"
        End Sub
        Shared Function getTipos() As List(Of TipoSuplemento)
            CachedTipo.CachedCollection = CachedCollection
            Return CachedTipo.getTipos
        End Function
        Shared Function getTipo(prmID As Integer) As TipoSuplemento
            CachedTipo.CachedCollection = CachedCollection
            Return CachedTipo.getTipo(prmID)
        End Function
        Shared Sub Release()
            CachedCollection.Clear()
        End Sub
    End Class
End Namespace