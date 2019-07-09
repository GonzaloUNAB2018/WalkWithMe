Imports Kaplan.Clases
Namespace Tipos

    Public Class TipoActividadLaboral
        Inherits BaseType
        Private Shared CachedTipo As New CachedType(Of TipoActividadLaboral)
        Private Shared CachedCollection As New Dictionary(Of Integer, TipoActividadLaboral)
        Shared Sub New()
            CachedTipo.DataPackage = "Kaplan.ListarTipoFEActivLab"
        End Sub
        Shared Function getTipos() As List(Of TipoActividadLaboral)
            CachedTipo.CachedCollection = CachedCollection
            Return CachedTipo.getTipos
        End Function
        Shared Function getTipo(prmID As Integer) As TipoActividadLaboral
            CachedTipo.CachedCollection = CachedCollection
            Return CachedTipo.getTipo(prmID)
        End Function
        Shared Sub Release()
            CachedCollection.Clear()
        End Sub
    End Class
End Namespace