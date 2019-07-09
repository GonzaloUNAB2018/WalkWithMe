Imports Kaplan.Clases
Namespace Tipos

    Public Class TipoTB
        Inherits BaseType
        Private Shared CachedTipo As New CachedType(Of TipoTB)
        Private Shared CachedCollection As New Dictionary(Of Integer, TipoTB)
        Shared Sub New()
            CachedTipo.DataPackage = "Kaplan.ListarTipoFETB"
        End Sub
        Shared Function getTipos() As List(Of TipoTB)
            CachedTipo.CachedCollection = CachedCollection
            Return CachedTipo.getTipos
        End Function
        Shared Function getTipo(prmID As Integer) As TipoTB
            CachedTipo.CachedCollection = CachedCollection
            Return CachedTipo.getTipo(prmID)
        End Function
        Shared Sub Release()
            CachedCollection.Clear()
        End Sub
    End Class
End Namespace