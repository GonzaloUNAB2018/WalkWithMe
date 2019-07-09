Imports Kaplan.Clases
Namespace Tipos

    Public Class TipoApoyoSocial
        Inherits BaseType
        Private Shared CachedTipo As New CachedType(Of TipoApoyoSocial)
        Private Shared CachedCollection As New Dictionary(Of Integer, TipoApoyoSocial)
        Shared Sub New()
            CachedTipo.DataPackage = "Kaplan.ListarTipoFPApoyoSocial"
        End Sub
        Shared Function getTipos() As List(Of TipoApoyoSocial)
            CachedTipo.CachedCollection = CachedCollection
            Return CachedTipo.getTipos
        End Function
        Shared Function getTipo(prmID As Integer) As TipoApoyoSocial
            CachedTipo.CachedCollection = CachedCollection
            Return CachedTipo.getTipo(prmID)
        End Function
        Shared Sub Release()
            CachedCollection.Clear()
        End Sub
    End Class
End Namespace