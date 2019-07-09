Imports Kaplan.Clases
Namespace Tipos

    Public Class TipoFrutaVerdura
        Inherits BaseType
        Private Shared CachedTipo As New CachedType(Of TipoFrutaVerdura)
        Private Shared CachedCollection As New Dictionary(Of Integer, TipoFrutaVerdura)
        Shared Sub New()
            CachedTipo.DataPackage = "Kaplan.ListarTipoFEFrutaVerd"
        End Sub
        Shared Function getTipos() As List(Of TipoFrutaVerdura)
            CachedTipo.CachedCollection = CachedCollection
            Return CachedTipo.getTipos
        End Function
        Shared Function getTipo(prmID As Integer) As TipoFrutaVerdura
            CachedTipo.CachedCollection = CachedCollection
            Return CachedTipo.getTipo(prmID)
        End Function
        Shared Sub Release()
            CachedCollection.Clear()
        End Sub
    End Class
End Namespace