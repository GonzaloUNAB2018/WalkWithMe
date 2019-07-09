Imports Kaplan.Clases
Namespace Tipos

    Public Class TipoDerivacion
        Inherits BaseType
        Private Shared CachedTipo As New CachedType(Of TipoDerivacion)
        Private Shared CachedCollection As New Dictionary(Of Integer, TipoDerivacion)
        Shared Sub New()
            CachedTipo.DataPackage = "Kaplan.ListarTipoDerivacion"
        End Sub
        Shared Function getTipos() As List(Of TipoDerivacion)
            CachedTipo.CachedCollection = CachedCollection
            Return CachedTipo.getTipos
        End Function
        Shared Function getTipo(prmID As Integer) As TipoDerivacion
            CachedTipo.CachedCollection = CachedCollection
            Return CachedTipo.getTipo(prmID)
        End Function
        Shared Sub Release()
            CachedCollection.Clear()
        End Sub
    End Class
End Namespace