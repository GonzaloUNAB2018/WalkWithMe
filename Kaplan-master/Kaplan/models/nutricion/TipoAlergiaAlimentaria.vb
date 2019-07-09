Imports Kaplan.Clases
Namespace Tipos

    Public Class TipoAlergiaAlimentaria
        Inherits BaseType
        Private Shared CachedTipo As New CachedType(Of TipoAlergiaAlimentaria)
        Private Shared CachedCollection As New Dictionary(Of Integer, TipoAlergiaAlimentaria)
        Shared Sub New()
            CachedTipo.DataPackage = "Kaplan.ListarTipoFNAlergiaAlim"
        End Sub
        Shared Function getTipos() As List(Of TipoAlergiaAlimentaria)
            CachedTipo.CachedCollection = CachedCollection
            Return CachedTipo.getTipos
        End Function
        Shared Function getTipo(prmID As Integer) As TipoAlergiaAlimentaria
            CachedTipo.CachedCollection = CachedCollection
            Return CachedTipo.getTipo(prmID)
        End Function
        Shared Sub Release()
            CachedCollection.Clear()
        End Sub
    End Class
End Namespace