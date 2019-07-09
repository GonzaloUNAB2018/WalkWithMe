Imports Kaplan.Clases
Namespace Tipos

    Public Class TipoFeviMedico
        Inherits BaseType
        Private Shared CachedTipo As New CachedType(Of TipoFeviMedico)
        Private Shared CachedCollection As New Dictionary(Of Integer, TipoFeviMedico)
        Shared Sub New()
            CachedTipo.DataPackage = "Kaplan.ListarTipoFevi"
        End Sub
        Shared Function getTipos() As List(Of TipoFeviMedico)
            CachedTipo.CachedCollection = CachedCollection
            Return CachedTipo.getTipos
        End Function
        Shared Function getTipo(prmID As Integer) As TipoFeviMedico
            CachedTipo.CachedCollection = CachedCollection
            Return CachedTipo.getTipo(prmID)
        End Function
        Shared Sub Release()
            CachedCollection.Clear()
        End Sub
    End Class
End Namespace