Imports Kaplan.Clases
Namespace Tipos

    Public Class TipoEESS
        Inherits BaseType
        Private Shared CachedTipo As New CachedType(Of TipoEESS)
        Private Shared CachedCollection As New Dictionary(Of Integer, TipoEESS)
        Shared Sub New()
            CachedTipo.DataPackage = "Kaplan.ListarTipoFEEESS"
        End Sub
        Shared Function getTipos() As List(Of TipoEESS)
            CachedTipo.CachedCollection = CachedCollection
            Return CachedTipo.getTipos
        End Function
        Shared Function getTipo(prmID As Integer) As TipoEESS
            CachedTipo.CachedCollection = CachedCollection
            Return CachedTipo.getTipo(prmID)
        End Function
        Shared Sub Release()
            CachedCollection.Clear()
        End Sub
    End Class
End Namespace