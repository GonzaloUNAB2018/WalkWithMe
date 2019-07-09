Imports Kaplan.Clases
Namespace Tipos

    Public Class TipoAzucar
        Inherits BaseType
        Private Shared CachedTipo As New CachedType(Of TipoAzucar)
        Private Shared CachedCollection As New Dictionary(Of Integer, TipoAzucar)
        Shared Sub New()
            CachedTipo.DataPackage = "Kaplan.ListarTipoFNAzucar"
        End Sub
        Shared Function getTipos() As List(Of TipoAzucar)
            CachedTipo.CachedCollection = CachedCollection
            Return CachedTipo.getTipos
        End Function
        Shared Function getTipo(prmID As Integer) As TipoAzucar
            CachedTipo.CachedCollection = CachedCollection
            Return CachedTipo.getTipo(prmID)
        End Function
        Shared Sub Release()
            CachedCollection.Clear()
        End Sub
    End Class
End Namespace