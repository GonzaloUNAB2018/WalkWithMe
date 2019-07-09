Imports Kaplan.Clases
Namespace Tipos

    Public Class TipoTratamiento
        Inherits BaseType
        Private Shared CachedTipo As New CachedType(Of TipoTratamiento)
        Private Shared CachedCollection As New Dictionary(Of Integer, TipoTratamiento)
        Shared Sub New()
            CachedTipo.DataPackage = "Kaplan.ListarTipoFPTratamiento"
        End Sub
        Shared Function getTipos() As List(Of TipoTratamiento)
            CachedTipo.CachedCollection = CachedCollection
            Return CachedTipo.getTipos
        End Function
        Shared Function getTipo(prmID As Integer) As TipoTratamiento
            CachedTipo.CachedCollection = CachedCollection
            Return CachedTipo.getTipo(prmID)
        End Function
        Shared Sub Release()
            CachedCollection.Clear()
        End Sub
    End Class
End Namespace