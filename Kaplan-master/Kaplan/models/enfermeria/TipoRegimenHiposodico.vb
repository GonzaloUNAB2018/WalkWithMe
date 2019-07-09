Imports Kaplan.Clases
Namespace Tipos

    Public Class TipoRegimenHiposodico
        Inherits BaseType
        Private Shared CachedTipo As New CachedType(Of TipoRegimenHiposodico)
        Private Shared CachedCollection As New Dictionary(Of Integer, TipoRegimenHiposodico)
        Shared Sub New()
            CachedTipo.DataPackage = "Kaplan.ListarTipoFERegiHipo"
        End Sub
        Shared Function getTipos() As List(Of TipoRegimenHiposodico)
            CachedTipo.CachedCollection = CachedCollection
            Return CachedTipo.getTipos
        End Function
        Shared Function getTipo(prmID As Integer) As TipoRegimenHiposodico
            CachedTipo.CachedCollection = CachedCollection
            Return CachedTipo.getTipo(prmID)
        End Function
        Shared Sub Release()
            CachedCollection.Clear()
        End Sub
    End Class
End Namespace