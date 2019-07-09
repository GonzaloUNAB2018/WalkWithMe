Imports Kaplan.Clases
Namespace Tipos

    Public Class TipoSintomatologia
        Inherits BaseType
        Private Shared CachedTipo As New CachedType(Of TipoSintomatologia)
        Private Shared CachedCollection As New Dictionary(Of Integer, TipoSintomatologia)
        Shared Sub New()
            CachedTipo.DataPackage = "Kaplan.ListarTipoFPSintomatologia"
        End Sub
        Shared Function getTipos() As List(Of TipoSintomatologia)
            CachedTipo.CachedCollection = CachedCollection
            Return CachedTipo.getTipos
        End Function
        Shared Function getTipo(prmID As Integer) As TipoSintomatologia
            CachedTipo.CachedCollection = CachedCollection
            Return CachedTipo.getTipo(prmID)
        End Function
        Shared Sub Release()
            CachedCollection.Clear()
        End Sub
    End Class
End Namespace

