Imports Kaplan.Clases
Namespace Tipos

    Public Class TipoIntolerenciaAlimentaria
        Inherits BaseType
        Private Shared CachedTipo As New CachedType(Of TipoIntolerenciaAlimentaria)
        Private Shared CachedCollection As New Dictionary(Of Integer, TipoIntolerenciaAlimentaria)
        Shared Sub New()
            CachedTipo.DataPackage = "Kaplan.ListarTipoFNIntoAlim"
        End Sub
        Shared Function getTipos() As List(Of TipoIntolerenciaAlimentaria)
            CachedTipo.CachedCollection = CachedCollection
            Return CachedTipo.getTipos
        End Function
        Shared Function getTipo(prmID As Integer) As TipoIntolerenciaAlimentaria
            CachedTipo.CachedCollection = CachedCollection
            Return CachedTipo.getTipo(prmID)
        End Function
        Shared Sub Release()
            CachedCollection.Clear()
        End Sub
    End Class
End Namespace