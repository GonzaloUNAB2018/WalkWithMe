Namespace Clases
    Public Class Digitalicos
        Public Property Id As Integer
        Public Property colId As String
        Public Property Descripcion As String
        Public Property Dosis As String

        Public Shared Function MapeoDigitalicos(prmDatos As DataTable) As List(Of Digitalicos)
            Try
                MapeoDigitalicos = New List(Of Digitalicos)
                For Each vRow As DataRow In prmDatos.Rows
                    Dim vClass As New Digitalicos
                    vClass.Id = vRow("id").ToString
                    vClass.colId = "colId" & vRow("id").ToString
                    vClass.Descripcion = vRow("descripcion").ToString
                    vClass.Dosis = vRow("dosis").ToString
                    MapeoDigitalicos.Add(vClass)
                Next
                Return MapeoDigitalicos
            Catch ex As Exception
                Return Nothing
            End Try

        End Function

    End Class
End Namespace
