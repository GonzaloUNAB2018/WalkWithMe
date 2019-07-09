Imports Kaplan.Clases
Namespace Tipos

    Public Class TipoConcienciaFactor
        Inherits BaseType
        Private Shared CachedTipo As New CachedType(Of TipoConcienciaFactor)
        Private Shared CachedCollection As New Dictionary(Of Integer, TipoConcienciaFactor)
        Shared Sub New()
            CachedTipo.DataPackage = "Kaplan.ListarTipoFPConciencia"
        End Sub
        Shared Function getTipos() As List(Of TipoConcienciaFactor)
            CachedTipo.CachedCollection = CachedCollection
            Return CachedTipo.getTipos
        End Function
        Shared Function getTipo(prmID As Integer) As TipoConcienciaFactor
            CachedTipo.CachedCollection = CachedCollection
            Return CachedTipo.getTipo(prmID)
        End Function
        Shared Sub Release()
            CachedCollection.Clear()
        End Sub
    End Class
End Namespace