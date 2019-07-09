Imports Kaplan.Clases
Namespace Tipos

    Public Class TipoTrastornoMental
        Inherits BaseType
        Private Shared CachedTipo As New CachedType(Of TipoTrastornoMental)
        Private Shared CachedCollection As New Dictionary(Of Integer, TipoTrastornoMental)
        Shared Sub New()
            CachedTipo.DataPackage = "Kaplan.ListarTipoFPTrastorno"
        End Sub
        Shared Function getTipos() As List(Of TipoTrastornoMental)
            CachedTipo.CachedCollection = CachedCollection
            Return CachedTipo.getTipos
        End Function
        Shared Function getTipo(prmID As Integer) As TipoTrastornoMental
            CachedTipo.CachedCollection = CachedCollection
            Return CachedTipo.getTipo(prmID)
        End Function
        Shared Sub Release()
            CachedCollection.Clear()
        End Sub
    End Class
End Namespace