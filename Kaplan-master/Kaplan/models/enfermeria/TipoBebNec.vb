Imports Kaplan.Clases
Namespace Tipos

    Public Class TipoBebNec
        Inherits BaseType
        Private Shared CachedTipo As New CachedType(Of TipoBebNec)
        Private Shared CachedCollection As New Dictionary(Of Integer, TipoBebNec)
        Shared Sub New()
            CachedTipo.DataPackage = "Kaplan.ListarTipoFEBebNec"
        End Sub
        Shared Function getTipos() As List(Of TipoBebNec)
            CachedTipo.CachedCollection = CachedCollection
            Return CachedTipo.getTipos
        End Function
        Shared Function getTipo(prmID As Integer) As TipoBebNec
            CachedTipo.CachedCollection = CachedCollection
            Return CachedTipo.getTipo(prmID)
        End Function
        Shared Sub Release()
            CachedCollection.Clear()
        End Sub
    End Class
End Namespace