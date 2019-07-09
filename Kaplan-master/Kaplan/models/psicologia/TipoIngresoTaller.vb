Imports Kaplan.Clases
Namespace Tipos

    Public Class TipoIngresoTaller
        Inherits BaseType
        Private Shared CachedTipo As New CachedType(Of TipoIngresoTaller)
        Private Shared CachedCollection As New Dictionary(Of Integer, TipoIngresoTaller)
        Shared Sub New()
            CachedTipo.DataPackage = "Kaplan.ListarTipoFPIngresoTaller"
        End Sub
        Shared Function getTipos() As List(Of TipoIngresoTaller)
            CachedTipo.CachedCollection = CachedCollection
            Return CachedTipo.getTipos
        End Function
        Shared Function getTipo(prmID As Integer) As TipoIngresoTaller
            CachedTipo.CachedCollection = CachedCollection
            Return CachedTipo.getTipo(prmID)
        End Function
        Shared Sub Release()
            CachedCollection.Clear()
        End Sub
    End Class
End Namespace