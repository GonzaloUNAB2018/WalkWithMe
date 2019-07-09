Imports Kaplan.Clases
Namespace Tipos

    Public Class TipoCuello
        Inherits BaseType
        Private Shared CachedTipo As New CachedType(Of TipoCuello)
        Private Shared CachedCollection As New Dictionary(Of Integer, TipoCuello)
        Shared Sub New()
            CachedTipo.DataPackage = "Kaplan.ListarTipoFECuello"
        End Sub
        Shared Function getTipos() As List(Of TipoCuello)
            CachedTipo.CachedCollection = CachedCollection
            Return CachedTipo.getTipos
        End Function
        Shared Function getTipo(prmID As Integer) As TipoCuello
            CachedTipo.CachedCollection = CachedCollection
            Return CachedTipo.getTipo(prmID)
        End Function
        Shared Sub Release()
            CachedCollection.Clear()
        End Sub
    End Class
End Namespace