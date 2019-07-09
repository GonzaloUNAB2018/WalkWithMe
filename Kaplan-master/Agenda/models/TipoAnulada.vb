Imports Agenda.Clases
Namespace Tipos

    Public Class TipoAnulada
        Inherits BaseType
        Private Shared CachedTipo As New CachedType(Of TipoAnulada)
        Private Shared CachedCollection As New Dictionary(Of Integer, TipoAnulada)
        Shared Sub New()
            CachedTipo.DataPackage = "Kaplan.ListarTipoAnulada"
        End Sub
        Shared Function getTipos() As List(Of TipoAnulada)
            CachedTipo.CachedCollection = CachedCollection
            Return CachedTipo.getTipos
        End Function
        Shared Function getTipo(prmID As Integer) As TipoAnulada
            CachedTipo.CachedCollection = CachedCollection
            Return CachedTipo.getTipo(prmID)
        End Function
        Shared Sub Release()
            CachedCollection.Clear()
        End Sub
    End Class
End Namespace