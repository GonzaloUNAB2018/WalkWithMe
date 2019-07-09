Imports Kaplan.Clases
Namespace Tipos

    Public Class TipoAgua
        Inherits BaseType
        Private Shared CachedTipo As New CachedType(Of TipoAgua)
        Private Shared CachedCollection As New Dictionary(Of Integer, TipoAgua)
        Shared Sub New()
            CachedTipo.DataPackage = "Kaplan.ListarTipoFEAgua"
        End Sub
        Shared Function getTipos() As List(Of TipoAgua)
            CachedTipo.CachedCollection = CachedCollection
            Return CachedTipo.getTipos
        End Function
        Shared Function getTipo(prmID As Integer) As TipoAgua
            CachedTipo.CachedCollection = CachedCollection
            Return CachedTipo.getTipo(prmID)
        End Function
        Shared Sub Release()
            CachedCollection.Clear()
        End Sub
    End Class
End Namespace