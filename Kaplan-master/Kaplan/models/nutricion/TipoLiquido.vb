Imports Kaplan.Clases
Namespace Tipos

    Public Class TipoLiquido
        Inherits BaseType
        Private Shared CachedTipo As New CachedType(Of TipoLiquido)
        Private Shared CachedCollection As New Dictionary(Of Integer, TipoLiquido)
        Shared Sub New()
            CachedTipo.DataPackage = "Kaplan.ListarTipoFNLiquido"
        End Sub
        Shared Function getTipos() As List(Of TipoLiquido)
            CachedTipo.CachedCollection = CachedCollection
            Return CachedTipo.getTipos
        End Function
        Shared Function getTipo(prmID As Integer) As TipoLiquido
            CachedTipo.CachedCollection = CachedCollection
            Return CachedTipo.getTipo(prmID)
        End Function
        Shared Sub Release()
            CachedCollection.Clear()
        End Sub
    End Class
End Namespace