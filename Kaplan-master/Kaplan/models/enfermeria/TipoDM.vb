Imports Kaplan.Clases
Namespace Tipos

    Public Class TipoDM
        Inherits BaseType
        Private Shared CachedTipo As New CachedType(Of TipoDM)
        Private Shared CachedCollection As New Dictionary(Of Integer, TipoDM)
        Shared Sub New()
            CachedTipo.DataPackage = "Kaplan.ListarTipoFEDM"
        End Sub
        Shared Function getTipos() As List(Of TipoDM)
            CachedTipo.CachedCollection = CachedCollection
            Return CachedTipo.getTipos
        End Function
        Shared Function getTipo(prmID As Integer) As TipoDM
            CachedTipo.CachedCollection = CachedCollection
            Return CachedTipo.getTipo(prmID)
        End Function
        Shared Sub Release()
            CachedCollection.Clear()
        End Sub
    End Class
End Namespace