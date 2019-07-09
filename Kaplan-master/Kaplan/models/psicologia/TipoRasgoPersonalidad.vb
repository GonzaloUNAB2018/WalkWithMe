Imports Kaplan.Clases
Namespace Tipos

    Public Class TipoRasgoPersonalidad
        Inherits BaseType
        Private Shared CachedTipo As New CachedType(Of TipoRasgoPersonalidad)
        Private Shared CachedCollection As New Dictionary(Of Integer, TipoRasgoPersonalidad)
        Shared Sub New()
            CachedTipo.DataPackage = "Kaplan.ListarTipoFPPersonalidad"
        End Sub
        Shared Function getTipos() As List(Of TipoRasgoPersonalidad)
            CachedTipo.CachedCollection = CachedCollection
            Return CachedTipo.getTipos
        End Function
        Shared Function getTipo(prmID As Integer) As TipoRasgoPersonalidad
            CachedTipo.CachedCollection = CachedCollection
            Return CachedTipo.getTipo(prmID)
        End Function
        Shared Sub Release()
            CachedCollection.Clear()
        End Sub
    End Class
End Namespace