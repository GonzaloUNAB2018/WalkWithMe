Imports Kaplan.Clases
Namespace Tipos

    Public Class TipoSED
        Inherits BaseType
        Private Shared CachedTipo As New CachedType(Of TipoSED)
        Private Shared CachedCollection As New Dictionary(Of Integer, TipoSED)
        Shared Sub New()
            CachedTipo.DataPackage = "Kaplan.ListarTipoFESED"
        End Sub
        Shared Function getTipos() As List(Of TipoSED)
            CachedTipo.CachedCollection = CachedCollection
            Return CachedTipo.getTipos
        End Function
        Shared Function getTipo(prmID As Integer) As TipoSED
            CachedTipo.CachedCollection = CachedCollection
            Return CachedTipo.getTipo(prmID)
        End Function
        Shared Sub Release()
            CachedCollection.Clear()
        End Sub
    End Class
End Namespace