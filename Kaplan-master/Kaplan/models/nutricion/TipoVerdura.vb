Imports Kaplan.Clases
Namespace Tipos

    Public Class TipoVerdura
        Inherits BaseType
        Private Shared CachedTipo As New CachedType(Of TipoVerdura)
        Private Shared CachedCollection As New Dictionary(Of Integer, TipoVerdura)
        Shared Sub New()
            CachedTipo.DataPackage = "Kaplan.ListarTipoFNVerdura"
        End Sub
        Shared Function getTipos() As List(Of TipoVerdura)
            CachedTipo.CachedCollection = CachedCollection
            Return CachedTipo.getTipos
        End Function
        Shared Function getTipo(prmID As Integer) As TipoVerdura
            CachedTipo.CachedCollection = CachedCollection
            Return CachedTipo.getTipo(prmID)
        End Function
        Shared Sub Release()
            CachedCollection.Clear()
        End Sub
    End Class
End Namespace