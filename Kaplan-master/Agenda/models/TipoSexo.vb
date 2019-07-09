Imports Agenda.Clases
Namespace Tipos

    Public Class TipoSexo
        Inherits BaseType
        Private Shared CachedTipo As New CachedType(Of TipoSexo)
        Private Shared CachedCollection As New Dictionary(Of Integer, TipoSexo)
        Shared Sub New()
            CachedTipo.DataPackage = "Kaplan.ListarTipoSexo"
        End Sub
        Shared Function getTipos() As List(Of TipoSexo)
            CachedTipo.CachedCollection = CachedCollection
            Return CachedTipo.getTipos
        End Function
        Shared Function getTipo(prmID As Integer) As TipoSexo
            CachedTipo.CachedCollection = CachedCollection
            Return CachedTipo.getTipo(prmID)
        End Function
        Shared Sub Release()
            CachedCollection.Clear()
        End Sub
    End Class
End Namespace
