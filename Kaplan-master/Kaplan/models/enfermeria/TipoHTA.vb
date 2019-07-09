Imports Kaplan.Clases
Namespace Tipos

    Public Class TipoHTA
        Inherits BaseType
        Private Shared CachedTipo As New CachedType(Of TipoHTA)
        Private Shared CachedCollection As New Dictionary(Of Integer, TipoHTA)
        Shared Sub New()
            CachedTipo.DataPackage = "Kaplan.ListarTipoFEHTA"
        End Sub
        Shared Function getTipos() As List(Of TipoHTA)
            CachedTipo.CachedCollection = CachedCollection
            Return CachedTipo.getTipos
        End Function
        Shared Function getTipo(prmID As Integer) As TipoHTA
            CachedTipo.CachedCollection = CachedCollection
            Return CachedTipo.getTipo(prmID)
        End Function
        Shared Sub Release()
            CachedCollection.Clear()
        End Sub
    End Class
End Namespace