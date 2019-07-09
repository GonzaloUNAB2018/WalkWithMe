Imports Kaplan.Clases
Namespace Tipos

    Public Class TipoAbdomenA
        Inherits BaseType
        Private Shared CachedTipo As New CachedType(Of TipoAbdomenA)
        Private Shared CachedCollection As New Dictionary(Of Integer, TipoAbdomenA)
        Shared Sub New()
            CachedTipo.DataPackage = "Kaplan.ListarTipoFEAbdomenA"
        End Sub
        Shared Function getTipos() As List(Of TipoAbdomenA)
            CachedTipo.CachedCollection = CachedCollection
            Return CachedTipo.getTipos
        End Function
        Shared Function getTipo(prmID As Integer) As TipoAbdomenA
            CachedTipo.CachedCollection = CachedCollection
            Return CachedTipo.getTipo(prmID)
        End Function
        Shared Sub Release()
            CachedCollection.Clear()
        End Sub
    End Class
End Namespace