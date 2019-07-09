Imports Agenda.Clases
Namespace Tipos

    Public Class TipoPrevision
        Inherits BaseType
        Private Shared CachedTipo As New CachedType(Of TipoPrevision)
        Private Shared CachedCollection As New Dictionary(Of Integer, TipoPrevision)
        Shared Sub New()
            CachedTipo.DataPackage = "Kaplan.ListarTipoPrevision"
        End Sub
        Shared Function getTipos() As List(Of TipoPrevision)
            CachedTipo.CachedCollection = CachedCollection
            Return CachedTipo.getTipos
        End Function
        Shared Function getTipo(prmID As Integer) As TipoPrevision
            CachedTipo.CachedCollection = CachedCollection
            Return CachedTipo.getTipo(prmID)
        End Function
        Shared Sub Release()
            CachedCollection.Clear()
        End Sub
    End Class
End Namespace
