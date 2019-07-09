Imports Kaplan.Clases
Namespace Tipos

    Public Class TipoTraumaPostOp
        Inherits BaseType
        Private Shared CachedTipo As New CachedType(Of TipoTraumaPostOp)
        Private Shared CachedCollection As New Dictionary(Of Integer, TipoTraumaPostOp)
        Shared Sub New()
            CachedTipo.DataPackage = "Kaplan.ListarTipoFPTrauma"
        End Sub
        Shared Function getTipos() As List(Of TipoTraumaPostOp)
            CachedTipo.CachedCollection = CachedCollection
            Return CachedTipo.getTipos
        End Function
        Shared Function getTipo(prmID As Integer) As TipoTraumaPostOp
            CachedTipo.CachedCollection = CachedCollection
            Return CachedTipo.getTipo(prmID)
        End Function
        Shared Sub Release()
            CachedCollection.Clear()
        End Sub
    End Class
End Namespace