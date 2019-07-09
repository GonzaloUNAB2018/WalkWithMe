Imports Kaplan.Clases
Namespace Tipos

    Public Class TipoDLP
        Inherits BaseType
        Private Shared CachedTipo As New CachedType(Of TipoDLP)
        Private Shared CachedCollection As New Dictionary(Of Integer, TipoDLP)
        Shared Sub New()
            CachedTipo.DataPackage = "Kaplan.ListarTipoFEDLP"
        End Sub
        Shared Function getTipos() As List(Of TipoDLP)
            CachedTipo.CachedCollection = CachedCollection
            Return CachedTipo.getTipos
        End Function
        Shared Function getTipo(prmID As Integer) As TipoDLP
            CachedTipo.CachedCollection = CachedCollection
            Return CachedTipo.getTipo(prmID)
        End Function
        Shared Sub Release()
            CachedCollection.Clear()
        End Sub
    End Class
End Namespace