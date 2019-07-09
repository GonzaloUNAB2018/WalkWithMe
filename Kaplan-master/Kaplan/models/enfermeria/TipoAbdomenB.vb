Imports Kaplan.Clases
Namespace Tipos

    Public Class TipoAbdomenB
        Inherits BaseType
        Private Shared CachedTipo As New CachedType(Of TipoAbdomenB)
        Private Shared CachedCollection As New Dictionary(Of Integer, TipoAbdomenB)
        Shared Sub New()
            CachedTipo.DataPackage = "Kaplan.ListarTipoFEAbdomenB"
        End Sub
        Shared Function getTipos() As List(Of TipoAbdomenB)
            CachedTipo.CachedCollection = CachedCollection
            Return CachedTipo.getTipos
        End Function
        Shared Function getTipo(prmID As Integer) As TipoAbdomenB
            CachedTipo.CachedCollection = CachedCollection
            Return CachedTipo.getTipo(prmID)
        End Function
        Shared Sub Release()
            CachedCollection.Clear()
        End Sub
    End Class
End Namespace