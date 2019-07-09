Imports Agenda.Clases
Namespace Tipos

    Public Class TipoHora
        Inherits BaseType
        Private Shared CachedTipo As New CachedType(Of TipoHora)
        Private Shared CachedCollection As New Dictionary(Of Integer, TipoHora)
        Shared Sub New()
            CachedTipo.DataPackage = "Kaplan.ListarTipoHoras"
        End Sub
        Shared Function getTipos() As List(Of TipoHora)
            CachedTipo.CachedCollection = CachedCollection
            Return CachedTipo.getTipos
        End Function
        Shared Function getTipo(prmID As Integer) As TipoHora
            CachedTipo.CachedCollection = CachedCollection
            Return CachedTipo.getTipo(prmID)
        End Function
        Shared Sub Release()
            CachedCollection.Clear()
        End Sub
    End Class
End Namespace