Imports Kaplan.Clases
Namespace Tipos

    Public Class TipoSPOB
        Inherits BaseType
        Private Shared CachedTipo As New CachedType(Of TipoSPOB)
        Private Shared CachedCollection As New Dictionary(Of Integer, TipoSPOB)
        Shared Sub New()
            CachedTipo.DataPackage = "Kaplan.ListarTipoFESPOB"
        End Sub
        Shared Function getTipos() As List(Of TipoSPOB)
            CachedTipo.CachedCollection = CachedCollection
            Return CachedTipo.getTipos
        End Function
        Shared Function getTipo(prmID As Integer) As TipoSPOB
            CachedTipo.CachedCollection = CachedCollection
            Return CachedTipo.getTipo(prmID)
        End Function
        Shared Sub Release()
            CachedCollection.Clear()
        End Sub
    End Class
End Namespace