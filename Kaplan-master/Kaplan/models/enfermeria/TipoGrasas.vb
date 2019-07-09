Imports Kaplan.Clases
Namespace Tipos

    Public Class TipoGrasas
        Inherits BaseType
        Private Shared CachedTipo As New CachedType(Of TipoGrasas)
        Private Shared CachedCollection As New Dictionary(Of Integer, TipoGrasas)
        Shared Sub New()
            CachedTipo.DataPackage = "Kaplan.ListarTipoFEGrasa"
        End Sub
        Shared Function getTipos() As List(Of TipoGrasas)
            CachedTipo.CachedCollection = CachedCollection
            Return CachedTipo.getTipos
        End Function
        Shared Function getTipo(prmID As Integer) As TipoGrasas
            CachedTipo.CachedCollection = CachedCollection
            Return CachedTipo.getTipo(prmID)
        End Function
        Shared Sub Release()
            CachedCollection.Clear()
        End Sub
    End Class
End Namespace