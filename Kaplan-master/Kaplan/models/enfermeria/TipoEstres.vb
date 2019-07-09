Imports Kaplan.Clases
Namespace Tipos

    Public Class TipoEstres
        Inherits BaseType
        Private Shared CachedTipo As New CachedType(Of TipoEstres)
        Private Shared CachedCollection As New Dictionary(Of Integer, TipoEstres)
        Shared Sub New()
            CachedTipo.DataPackage = "Kaplan.ListarTipoFEEstres"
        End Sub
        Shared Function getTipos() As List(Of TipoEstres)
            CachedTipo.CachedCollection = CachedCollection
            Return CachedTipo.getTipos
        End Function
        Shared Function getTipo(prmID As Integer) As TipoEstres
            CachedTipo.CachedCollection = CachedCollection
            Return CachedTipo.getTipo(prmID)
        End Function
        Shared Sub Release()
            CachedCollection.Clear()
        End Sub
    End Class
End Namespace