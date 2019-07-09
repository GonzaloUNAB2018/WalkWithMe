Imports Kaplan.Clases
Namespace Tipos

    Public Class TipoApetito
        Inherits BaseType
        Private Shared CachedTipo As New CachedType(Of TipoApetito)
        Private Shared CachedCollection As New Dictionary(Of Integer, TipoApetito)
        Shared Sub New()
            CachedTipo.DataPackage = "Kaplan.ListarTipoFNApetito"
        End Sub
        Shared Function getTipos() As List(Of TipoApetito)
            CachedTipo.CachedCollection = CachedCollection
            Return CachedTipo.getTipos
        End Function
        Shared Function getTipo(prmID As Integer) As TipoApetito
            CachedTipo.CachedCollection = CachedCollection
            Return CachedTipo.getTipo(prmID)
        End Function
        Shared Sub Release()
            CachedCollection.Clear()
        End Sub
    End Class
End Namespace