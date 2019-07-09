Imports Kaplan.Clases
Namespace Tipos

    Public Class TipoSeveridadMedico
        Inherits BaseType
        Private Shared CachedTipo As New CachedType(Of TipoSeveridadMedico)
        Private Shared CachedCollection As New Dictionary(Of Integer, TipoSeveridadMedico)
        Shared Sub New()
            CachedTipo.DataPackage = "Kaplan.ListarTipoSeveridad"
        End Sub
        Shared Function getTipos() As List(Of TipoSeveridadMedico)
            CachedTipo.CachedCollection = CachedCollection
            Return CachedTipo.getTipos
        End Function
        Shared Function getTipo(prmID As Integer) As TipoSeveridadMedico
            CachedTipo.CachedCollection = CachedCollection
            Return CachedTipo.getTipo(prmID)
        End Function
        Shared Sub Release()
            CachedCollection.Clear()
        End Sub
    End Class
End Namespace