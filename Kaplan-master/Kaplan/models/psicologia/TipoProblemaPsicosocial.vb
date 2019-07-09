Imports Kaplan.Clases
Namespace Tipos

    Public Class TipoProblemaPsicosocial
        Inherits BaseType
        Private Shared CachedTipo As New CachedType(Of TipoProblemaPsicosocial)
        Private Shared CachedCollection As New Dictionary(Of Integer, TipoProblemaPsicosocial)
        Shared Sub New()
            CachedTipo.DataPackage = "Kaplan.ListarTipoFPProblemasocial"
        End Sub
        Shared Function getTipos() As List(Of TipoProblemaPsicosocial)
            CachedTipo.CachedCollection = CachedCollection
            Return CachedTipo.getTipos
        End Function
        Shared Function getTipo(prmID As Integer) As TipoProblemaPsicosocial
            CachedTipo.CachedCollection = CachedCollection
            Return CachedTipo.getTipo(prmID)
        End Function
        Shared Sub Release()
            CachedCollection.Clear()
        End Sub
    End Class
End Namespace