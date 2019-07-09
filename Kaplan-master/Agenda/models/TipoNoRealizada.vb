Imports Agenda.Clases
Namespace Tipos

    Public Class TipoNoRealizada
        Inherits BaseType
        Private Shared CachedTipo As New CachedType(Of TipoNoRealizada)
        Private Shared CachedCollection As New Dictionary(Of Integer, TipoNoRealizada)
        Shared Sub New()
            CachedTipo.DataPackage = "Kaplan.ListarTipoNoRealizada"
        End Sub
        Shared Function getTipos() As List(Of TipoNoRealizada)
            CachedTipo.CachedCollection = CachedCollection
            Return CachedTipo.getTipos
        End Function
        Shared Function getTipo(prmID As Integer) As TipoNoRealizada
            CachedTipo.CachedCollection = CachedCollection
            Return CachedTipo.getTipo(prmID)
        End Function
        Shared Sub Release()
            CachedCollection.Clear()
        End Sub
    End Class
End Namespace