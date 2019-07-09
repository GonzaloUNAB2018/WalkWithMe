Imports Kaplan.Clases
Namespace Tipos

    Public Class TipoSuenoNocturnoB
        Inherits BaseType
        Private Shared CachedTipo As New CachedType(Of TipoSuenoNocturnoB)
        Private Shared CachedCollection As New Dictionary(Of Integer, TipoSuenoNocturnoB)
        Shared Sub New()
            CachedTipo.DataPackage = "Kaplan.ListarTipoFESuenoNoctB"
        End Sub
        Shared Function getTipos() As List(Of TipoSuenoNocturnoB)
            CachedTipo.CachedCollection = CachedCollection
            Return CachedTipo.getTipos
        End Function
        Shared Function getTipo(prmID As Integer) As TipoSuenoNocturnoB
            CachedTipo.CachedCollection = CachedCollection
            Return CachedTipo.getTipo(prmID)
        End Function
        Shared Sub Release()
            CachedCollection.Clear()
        End Sub
    End Class
End Namespace