Imports Agenda.Clases
Namespace Tipos

    Public Class TipoEstadoPlan
        Inherits BaseType
        Private Shared CachedTipo As New CachedType(Of TipoEstadoPlan)
        Private Shared CachedCollection As New Dictionary(Of Integer, TipoEstadoPlan)
        Shared Sub New()
            CachedTipo.DataPackage = "Kaplan.ListarTipoEstadoPlan"
        End Sub
        Shared Function getTipos() As List(Of TipoEstadoPlan)
            CachedTipo.CachedCollection = CachedCollection
            Return CachedTipo.getTipos
        End Function
        Shared Function getTipo(prmID As Integer) As TipoEstadoPlan
            CachedTipo.CachedCollection = CachedCollection
            Return CachedTipo.getTipo(prmID)
        End Function
        Shared Sub Release()
            CachedCollection.Clear()
        End Sub
    End Class
End Namespace
