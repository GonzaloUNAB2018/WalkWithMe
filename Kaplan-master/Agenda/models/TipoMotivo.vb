Imports Agenda.Clases
Namespace Tipos

    Public Class TipoMotivo
        Inherits BaseType
        Private Shared CachedTipo As New CachedType(Of TipoMotivo)
        Private Shared CachedCollection As New Dictionary(Of Integer, TipoMotivo)
        Shared Sub New()
            CachedTipo.DataPackage = "Kaplan.ListarTipoMotivos"
        End Sub
        Shared Function getTipos() As List(Of TipoMotivo)
            CachedTipo.CachedCollection = CachedCollection
            Return CachedTipo.getTipos
        End Function
        Shared Function getTipo(prmID As Integer) As TipoMotivo
            CachedTipo.CachedCollection = CachedCollection
            Return CachedTipo.getTipo(prmID)
        End Function
        Shared Sub Release()
            CachedCollection.Clear()
        End Sub
    End Class
End Namespace