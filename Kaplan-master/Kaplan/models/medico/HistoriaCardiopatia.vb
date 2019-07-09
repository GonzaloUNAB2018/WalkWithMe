Namespace Clases
    Public Class HistoriaCardiopatia
        Public Property Id As Integer
        Public Property colId As String
        Public Property Historia As String

        Public Shared Function MapeoHistoriaCardiopatia(prmDatos As DataTable) As List(Of HistoriaCardiopatia)
            Try
                MapeoHistoriaCardiopatia = New List(Of HistoriaCardiopatia)
                For Each vRow As DataRow In prmDatos.Rows
                    Dim vClass As New HistoriaCardiopatia
                    vClass.Id = vRow("id_his").ToString
                    vClass.colId = "colId" & vRow("id_his").ToString
                    vClass.Historia = vRow("observacion").ToString
                    MapeoHistoriaCardiopatia.Add(vClass)
                Next
                Return MapeoHistoriaCardiopatia
            Catch ex As Exception
                Return Nothing
            End Try

        End Function


    End Class
End Namespace