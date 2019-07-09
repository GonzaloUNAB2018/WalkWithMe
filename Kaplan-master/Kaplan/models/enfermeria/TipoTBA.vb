Imports Kaplan.Clases
Namespace Tipos

    Public Class TipoTBA
        Inherits BaseType
        Private Shared CachedTipo As New CachedType(Of TipoTBA)
        Private Shared CachedCollection As New Dictionary(Of Integer, TipoTBA)
        Shared Sub New()
            CachedTipo.DataPackage = "Kaplan.ListarTipoFETBA"
        End Sub
        Shared Function getTipos() As List(Of TipoTBA)
            CachedTipo.CachedCollection = CachedCollection
            Return CachedTipo.getTipos
        End Function
        Shared Function getTipo(prmID As Integer) As TipoTBA
            CachedTipo.CachedCollection = CachedCollection
            Return CachedTipo.getTipo(prmID)
        End Function
        Shared Sub Release()
            CachedCollection.Clear()
        End Sub
    End Class
End Namespace