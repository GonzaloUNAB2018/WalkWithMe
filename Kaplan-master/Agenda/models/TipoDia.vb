Imports Agenda.Clases
Namespace Tipos

    Public Class TipoDia
        Inherits BaseType
        Private Shared CachedTipo As New CachedType(Of TipoDia)
        Private Shared CachedCollection As New Dictionary(Of Integer, TipoDia)
        Shared Sub New()
            CachedTipo.DataPackage = "Kaplan.ListarTipoDias"
        End Sub
        Shared Function getTipos() As List(Of TipoDia)
            CachedTipo.CachedCollection = CachedCollection
            Return CachedTipo.getTipos
        End Function
        Shared Function getTipo(prmID As Integer) As TipoDia
            CachedTipo.CachedCollection = CachedCollection
            Return CachedTipo.getTipo(prmID)
        End Function
        Shared Sub Release()
            CachedCollection.Clear()
        End Sub
    End Class
End Namespace