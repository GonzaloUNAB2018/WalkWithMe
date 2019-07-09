Imports Kaplan.Clases
Namespace Tipos

    Public Class TipoSodio
        Inherits BaseType
        Private Shared CachedTipo As New CachedType(Of TipoSodio)
        Private Shared CachedCollection As New Dictionary(Of Integer, TipoSodio)
        Shared Sub New()
            CachedTipo.DataPackage = "Kaplan.ListarTipoFNSodio"
        End Sub
        Shared Function getTipos() As List(Of TipoSodio)
            CachedTipo.CachedCollection = CachedCollection
            Return CachedTipo.getTipos
        End Function
        Shared Function getTipo(prmID As Integer) As TipoSodio
            CachedTipo.CachedCollection = CachedCollection
            Return CachedTipo.getTipo(prmID)
        End Function
        Shared Sub Release()
            CachedCollection.Clear()
        End Sub
    End Class
End Namespace