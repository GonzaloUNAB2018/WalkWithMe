Imports Agenda.Clases
Namespace Tipos

    Public Class TipoMotivoPlan
        Inherits BaseType
        Private Shared CachedTipo As New CachedType(Of TipoMotivoPlan)
        Private Shared CachedCollection As New Dictionary(Of Integer, TipoMotivoPlan)
        Shared Sub New()
            CachedTipo.DataPackage = "Kaplan.ListarTipoMotivoPlan"
        End Sub
        Shared Function getTipos() As List(Of TipoMotivoPlan)
            CachedTipo.CachedCollection = CachedCollection
            Return CachedTipo.getTipos
        End Function
        Shared Function getTipo(prmID As Integer) As TipoMotivoPlan
            CachedTipo.CachedCollection = CachedCollection
            Return CachedTipo.getTipo(prmID)
        End Function
        Shared Sub Release()
            CachedCollection.Clear()
        End Sub
    End Class
End Namespace
