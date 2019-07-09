Imports Agenda.Clases
Namespace Tipos

    Public Class TipoEstadoReserva
        Inherits BaseType
        Private Shared CachedTipo As New CachedType(Of TipoEstadoReserva)
        Private Shared CachedCollection As New Dictionary(Of Integer, TipoEstadoReserva)
        Shared Sub New()
            CachedTipo.DataPackage = "Kaplan.ListarTipoEstadoReserva"
        End Sub
        Shared Function getTipos() As List(Of TipoEstadoReserva)
            CachedTipo.CachedCollection = CachedCollection
            Return CachedTipo.getTipos
        End Function
        Shared Function getTipo(prmID As Integer) As TipoEstadoReserva
            CachedTipo.CachedCollection = CachedCollection
            Return CachedTipo.getTipo(prmID)
        End Function
        Shared Sub Release()
            CachedCollection.Clear()
        End Sub
    End Class
End Namespace
