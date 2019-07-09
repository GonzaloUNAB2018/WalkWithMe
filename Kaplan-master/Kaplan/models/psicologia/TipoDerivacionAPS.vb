Imports Kaplan.Clases
Namespace Tipos

    Public Class TipoDerivacionAPS
        Inherits BaseType
        Private Shared CachedTipo As New CachedType(Of TipoDerivacionAPS)
        Private Shared CachedCollection As New Dictionary(Of Integer, TipoDerivacionAPS)
        Shared Sub New()
            CachedTipo.DataPackage = "Kaplan.ListarTipoFPDerivacionAPS"
        End Sub
        Shared Function getTipos() As List(Of TipoDerivacionAPS)
            CachedTipo.CachedCollection = CachedCollection
            Return CachedTipo.getTipos
        End Function
        Shared Function getTipo(prmID As Integer) As TipoDerivacionAPS
            CachedTipo.CachedCollection = CachedCollection
            Return CachedTipo.getTipo(prmID)
        End Function
        Shared Sub Release()
            CachedCollection.Clear()
        End Sub
    End Class
End Namespace