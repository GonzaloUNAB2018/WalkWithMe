Imports Kaplan.Clases
Namespace Tipos

    Public Class TipoPatronRespiratorio
        Inherits BaseType
        Private Shared CachedTipo As New CachedType(Of TipoPatronRespiratorio)
        Private Shared CachedCollection As New Dictionary(Of Integer, TipoPatronRespiratorio)
        Shared Sub New()
            CachedTipo.DataPackage = "Kaplan.ListarTipoFEPatronResp"
        End Sub
        Shared Function getTipos() As List(Of TipoPatronRespiratorio)
            CachedTipo.CachedCollection = CachedCollection
            Return CachedTipo.getTipos
        End Function
        Shared Function getTipo(prmID As Integer) As TipoPatronRespiratorio
            CachedTipo.CachedCollection = CachedCollection
            Return CachedTipo.getTipo(prmID)
        End Function
        Shared Sub Release()
            CachedCollection.Clear()
        End Sub
    End Class
End Namespace