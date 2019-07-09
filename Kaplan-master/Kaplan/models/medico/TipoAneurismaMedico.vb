Imports Kaplan.Clases
Namespace Tipos

    Public Class TipoAneurismaMedico
        Inherits BaseType
        Private Shared CachedTipo As New CachedType(Of TipoAneurismaMedico)
        Private Shared CachedCollection As New Dictionary(Of Integer, TipoAneurismaMedico)
        Shared Sub New()
            CachedTipo.DataPackage = "Kaplan.ListarTipoAneurisma"
        End Sub
        Shared Function getTipos() As List(Of TipoAneurismaMedico)
            CachedTipo.CachedCollection = CachedCollection
            Return CachedTipo.getTipos
        End Function
        Shared Function getTipo(prmID As Integer) As TipoAneurismaMedico
            CachedTipo.CachedCollection = CachedCollection
            Return CachedTipo.getTipo(prmID)
        End Function
        Shared Sub Release()
            CachedCollection.Clear()
        End Sub
    End Class
End Namespace