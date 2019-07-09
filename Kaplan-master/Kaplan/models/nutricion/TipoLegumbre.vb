Imports Kaplan.Clases
Namespace Tipos

    Public Class TipoLegumbre
        Inherits BaseType
        Private Shared CachedTipo As New CachedType(Of TipoLegumbre)
        Private Shared CachedCollection As New Dictionary(Of Integer, TipoLegumbre)
        Shared Sub New()
            CachedTipo.DataPackage = "Kaplan.ListarTipoFNLegumbre"
        End Sub
        Shared Function getTipos() As List(Of TipoLegumbre)
            CachedTipo.CachedCollection = CachedCollection
            Return CachedTipo.getTipos
        End Function
        Shared Function getTipo(prmID As Integer) As TipoLegumbre
            CachedTipo.CachedCollection = CachedCollection
            Return CachedTipo.getTipo(prmID)
        End Function
        Shared Sub Release()
            CachedCollection.Clear()
        End Sub
    End Class
End Namespace