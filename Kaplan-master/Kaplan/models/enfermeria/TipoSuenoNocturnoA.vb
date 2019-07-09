Imports Kaplan.Clases
Namespace Tipos

    Public Class TipoSuenoNocturnoA
        Inherits BaseType
        Private Shared CachedTipo As New CachedType(Of TipoSuenoNocturnoA)
        Private Shared CachedCollection As New Dictionary(Of Integer, TipoSuenoNocturnoA)
        Shared Sub New()
            CachedTipo.DataPackage = "Kaplan.ListarTipoFESuenoNoctA"
        End Sub
        Shared Function getTipos() As List(Of TipoSuenoNocturnoA)
            CachedTipo.CachedCollection = CachedCollection
            Return CachedTipo.getTipos
        End Function
        Shared Function getTipo(prmID As Integer) As TipoSuenoNocturnoA
            CachedTipo.CachedCollection = CachedCollection
            Return CachedTipo.getTipo(prmID)
        End Function
        Shared Sub Release()
            CachedCollection.Clear()
        End Sub
    End Class
End Namespace