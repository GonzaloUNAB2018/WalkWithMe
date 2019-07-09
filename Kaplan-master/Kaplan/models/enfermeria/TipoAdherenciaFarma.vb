Imports Kaplan.Clases
Namespace Tipos

    Public Class TipoAdherenciaFarma
        Inherits BaseType
        Private Shared CachedTipo As New CachedType(Of TipoAdherenciaFarma)
        Private Shared CachedCollection As New Dictionary(Of Integer, TipoAdherenciaFarma)
        Shared Sub New()
            CachedTipo.DataPackage = "Kaplan.ListarTipoFEAdhFarm"
        End Sub
        Shared Function getTipos() As List(Of TipoAdherenciaFarma)
            CachedTipo.CachedCollection = CachedCollection
            Return CachedTipo.getTipos
        End Function
        Shared Function getTipo(prmID As Integer) As TipoAdherenciaFarma
            CachedTipo.CachedCollection = CachedCollection
            Return CachedTipo.getTipo(prmID)
        End Function
        Shared Sub Release()
            CachedCollection.Clear()
        End Sub
    End Class
End Namespace