Imports Kaplan.Clases
Namespace Tipos

    Public Class TipoLacteo
        Inherits BaseType
        Private Shared CachedTipo As New CachedType(Of TipoLacteo)
        Private Shared CachedCollection As New Dictionary(Of Integer, TipoLacteo)
        Shared Sub New()
            CachedTipo.DataPackage = "Kaplan.ListarTipoFNLacteo"
        End Sub
        Shared Function getTipos() As List(Of TipoLacteo)
            CachedTipo.CachedCollection = CachedCollection
            Return CachedTipo.getTipos
        End Function
        Shared Function getTipo(prmID As Integer) As TipoLacteo
            CachedTipo.CachedCollection = CachedCollection
            Return CachedTipo.getTipo(prmID)
        End Function
        Shared Sub Release()
            CachedCollection.Clear()
        End Sub
    End Class
End Namespace