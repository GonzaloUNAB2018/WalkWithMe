Imports Kaplan.Clases
Namespace Tipos

    Public Class TipoAF
        Inherits BaseType
        Private Shared CachedTipo As New CachedType(Of TipoAF)
        Private Shared CachedCollection As New Dictionary(Of Integer, TipoAF)
        Shared Sub New()
            CachedTipo.DataPackage = "Kaplan.ListarTipoFEAF"
        End Sub
        Shared Function getTipos() As List(Of TipoAF)
            CachedTipo.CachedCollection = CachedCollection
            Return CachedTipo.getTipos
        End Function
        Shared Function getTipo(prmID As Integer) As TipoAF
            CachedTipo.CachedCollection = CachedCollection
            Return CachedTipo.getTipo(prmID)
        End Function
        Shared Sub Release()
            CachedCollection.Clear()
        End Sub
    End Class
End Namespace