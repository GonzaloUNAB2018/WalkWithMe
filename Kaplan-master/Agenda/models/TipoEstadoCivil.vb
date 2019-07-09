Imports Agenda.Clases
Namespace Tipos

    Public Class TipoEstadoCivil
        Inherits BaseType
        Private Shared CachedTipo As New CachedType(Of TipoEstadoCivil)
        Private Shared CachedCollection As New Dictionary(Of Integer, TipoEstadoCivil)
        Shared Sub New()
            CachedTipo.DataPackage = "Kaplan.ListarTipoEstadoCivil"
        End Sub
        Shared Function getTipos() As List(Of TipoEstadoCivil)
            CachedTipo.CachedCollection = CachedCollection
            Return CachedTipo.getTipos
        End Function
        Shared Function getTipo(prmID As Integer) As TipoEstadoCivil
            CachedTipo.CachedCollection = CachedCollection
            Return CachedTipo.getTipo(prmID)
        End Function
        Shared Sub Release()
            CachedCollection.Clear()
        End Sub
    End Class
End Namespace
