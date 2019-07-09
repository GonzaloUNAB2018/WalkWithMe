Imports Agenda.Clases
Namespace Tipos

    Public Class TipoComuna
        Inherits BaseType
        Private Shared CachedTipo As New CachedType(Of TipoComuna)
        Private Shared CachedCollection As New Dictionary(Of Integer, TipoComuna)
        Shared Sub New()
            CachedTipo.DataPackage = "Kaplan.ListarTipoComuna"
        End Sub
        Shared Function getTipos() As List(Of TipoComuna)
            CachedTipo.CachedCollection = CachedCollection
            Return CachedTipo.getTipos
        End Function
        Shared Function getTipo(prmID As Integer) As TipoComuna
            CachedTipo.CachedCollection = CachedCollection
            Return CachedTipo.getTipo(prmID)
        End Function
        Shared Sub Release()
            CachedCollection.Clear()
        End Sub
    End Class
End Namespace
