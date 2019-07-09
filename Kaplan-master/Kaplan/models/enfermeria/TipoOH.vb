Imports Kaplan.Clases
Namespace Tipos

    Public Class TipoOH
        Inherits BaseType
        Private Shared CachedTipo As New CachedType(Of TipoOH)
        Private Shared CachedCollection As New Dictionary(Of Integer, TipoOH)
        Shared Sub New()
            CachedTipo.DataPackage = "Kaplan.ListarTipoFEOH"
        End Sub
        Shared Function getTipos() As List(Of TipoOH)
            CachedTipo.CachedCollection = CachedCollection
            Return CachedTipo.getTipos
        End Function
        Shared Function getTipo(prmID As Integer) As TipoOH
            CachedTipo.CachedCollection = CachedCollection
            Return CachedTipo.getTipo(prmID)
        End Function
        Shared Sub Release()
            CachedCollection.Clear()
        End Sub
    End Class
End Namespace