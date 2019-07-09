Imports Kaplan.Clases
Namespace Tipos

    Public Class TipoEEII
        Inherits BaseType
        Private Shared CachedTipo As New CachedType(Of TipoEEII)
        Private Shared CachedCollection As New Dictionary(Of Integer, TipoEEII)
        Shared Sub New()
            CachedTipo.DataPackage = "Kaplan.ListarTipoFEEEII"
        End Sub
        Shared Function getTipos() As List(Of TipoEEII)
            CachedTipo.CachedCollection = CachedCollection
            Return CachedTipo.getTipos
        End Function
        Shared Function getTipo(prmID As Integer) As TipoEEII
            CachedTipo.CachedCollection = CachedCollection
            Return CachedTipo.getTipo(prmID)
        End Function
        Shared Sub Release()
            CachedCollection.Clear()
        End Sub
    End Class
End Namespace