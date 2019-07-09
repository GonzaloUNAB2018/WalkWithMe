Imports Kaplan.Clases
Namespace Tipos

    Public Class TipoSuenoNocturnoC
        Inherits BaseType
        Private Shared CachedTipo As New CachedType(Of TipoSuenoNocturnoC)
        Private Shared CachedCollection As New Dictionary(Of Integer, TipoSuenoNocturnoC)
        Shared Sub New()
            CachedTipo.DataPackage = "Kaplan.ListarTipoFESuenoNoctC"
        End Sub
        Shared Function getTipos() As List(Of TipoSuenoNocturnoC)
            CachedTipo.CachedCollection = CachedCollection
            Return CachedTipo.getTipos
        End Function
        Shared Function getTipo(prmID As Integer) As TipoSuenoNocturnoC
            CachedTipo.CachedCollection = CachedCollection
            Return CachedTipo.getTipo(prmID)
        End Function
        Shared Sub Release()
            CachedCollection.Clear()
        End Sub
    End Class
End Namespace