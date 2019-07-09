Imports Agenda.Clases
Namespace Tipos

    Public Class TipoReserva
        Inherits BaseType
        Private Shared CachedTipo As New CachedType(Of TipoReserva)
        Private Shared CachedCollection As New Dictionary(Of Integer, TipoReserva)
        Shared Sub New()
            CachedTipo.DataPackage = "Kaplan.ListarTipoReserva"
        End Sub
        Shared Function getTipos() As List(Of TipoReserva)
            CachedTipo.CachedCollection = CachedCollection
            Return CachedTipo.getTipos
        End Function
        Shared Function getTipo(prmID As Integer) As TipoReserva
            CachedTipo.CachedCollection = CachedCollection
            Return CachedTipo.getTipo(prmID)
        End Function
        Shared Sub Release()
            CachedCollection.Clear()
        End Sub
    End Class
End Namespace
