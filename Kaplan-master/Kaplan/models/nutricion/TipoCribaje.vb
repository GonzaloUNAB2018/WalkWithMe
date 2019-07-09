Imports Kaplan.Clases
Namespace Tipos

    Public Class TipoCribaje
        Inherits BaseType
        Private Shared CachedTipo As New CachedType(Of TipoCribaje)
        Private Shared CachedCollection As New Dictionary(Of Integer, TipoCribaje)
        Shared Sub New()
            CachedTipo.DataPackage = "Kaplan.ListarTipoFNCribaje"
        End Sub
        Shared Function getTipos() As List(Of TipoCribaje)
            CachedTipo.CachedCollection = CachedCollection
            Return CachedTipo.getTipos
        End Function
        Shared Function getTipo(prmID As Integer) As TipoCribaje
            CachedTipo.CachedCollection = CachedCollection
            Return CachedTipo.getTipo(prmID)
        End Function
        Shared Sub Release()
            CachedCollection.Clear()
        End Sub
    End Class
End Namespace