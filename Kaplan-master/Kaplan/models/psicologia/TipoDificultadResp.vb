Imports Kaplan.Clases
Namespace Tipos

    Public Class TipoDificultadResp
        Inherits BaseType
        Private Shared CachedTipo As New CachedType(Of TipoDificultadResp)
        Private Shared CachedCollection As New Dictionary(Of Integer, TipoDificultadResp)
        Shared Sub New()
            CachedTipo.DataPackage = "Kaplan.ListarTipoFPDificultades"
        End Sub
        Shared Function getTipos() As List(Of TipoDificultadResp)
            CachedTipo.CachedCollection = CachedCollection
            Return CachedTipo.getTipos
        End Function
        Shared Function getTipo(prmID As Integer) As TipoDificultadResp
            CachedTipo.CachedCollection = CachedCollection
            Return CachedTipo.getTipo(prmID)
        End Function
        Shared Sub Release()
            CachedCollection.Clear()
        End Sub
    End Class
End Namespace