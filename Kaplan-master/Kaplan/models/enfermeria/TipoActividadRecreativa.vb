Imports Kaplan.Clases
Namespace Tipos

    Public Class TipoActividadRecreativa
        Inherits BaseType
        Private Shared CachedTipo As New CachedType(Of TipoActividadRecreativa)
        Private Shared CachedCollection As New Dictionary(Of Integer, TipoActividadRecreativa)
        Shared Sub New()
            CachedTipo.DataPackage = "Kaplan.ListarTipoFEActivRec"
        End Sub
        Shared Function getTipos() As List(Of TipoActividadRecreativa)
            CachedTipo.CachedCollection = CachedCollection
            Return CachedTipo.getTipos
        End Function
        Shared Function getTipo(prmID As Integer) As TipoActividadRecreativa
            CachedTipo.CachedCollection = CachedCollection
            Return CachedTipo.getTipo(prmID)
        End Function
        Shared Sub Release()
            CachedCollection.Clear()
        End Sub
    End Class
End Namespace