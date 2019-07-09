Imports Kaplan.Clases
Namespace Tipos

    Public Class TipoDiseccionMedico
        Inherits BaseType
        Private Shared CachedTipo As New CachedType(Of TipoDiseccionMedico)
        Private Shared CachedCollection As New Dictionary(Of Integer, TipoDiseccionMedico)
        Shared Sub New()
            CachedTipo.DataPackage = "Kaplan.ListarTipoDiseccion"
        End Sub
        Shared Function getTipos() As List(Of TipoDiseccionMedico)
            CachedTipo.CachedCollection = CachedCollection
            Return CachedTipo.getTipos
        End Function
        Shared Function getTipo(prmID As Integer) As TipoDiseccionMedico
            CachedTipo.CachedCollection = CachedCollection
            Return CachedTipo.getTipo(prmID)
        End Function
        Shared Sub Release()
            CachedCollection.Clear()
        End Sub
    End Class
End Namespace