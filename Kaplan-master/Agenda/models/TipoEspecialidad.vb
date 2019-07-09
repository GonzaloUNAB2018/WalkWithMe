Imports Agenda.Clases
Namespace Tipos

    Public Class TipoEspecialidad
        Inherits BaseType
        Private Shared CachedTipo As New CachedType(Of TipoEspecialidad)
        Private Shared CachedCollection As New Dictionary(Of Integer, TipoEspecialidad)
        Shared Sub New()
            CachedTipo.DataPackage = "Kaplan.ListarTipoEspecialidad"
        End Sub
        Shared Function getTipos() As List(Of TipoEspecialidad)
            CachedTipo.CachedCollection = CachedCollection
            Return CachedTipo.getTipos
        End Function
        Shared Function getTipo(prmID As Integer) As TipoEspecialidad
            CachedTipo.CachedCollection = CachedCollection
            Return CachedTipo.getTipo(prmID)
        End Function
        Shared Sub Release()
            CachedCollection.Clear()
        End Sub
    End Class
End Namespace
