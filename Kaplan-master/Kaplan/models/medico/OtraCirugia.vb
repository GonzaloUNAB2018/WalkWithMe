Namespace Clases
    Public Class OtraCirugia
        Public Property Id As Integer
        Public Property colId As String
        Public Property Cirugia As String
        Public Property Fecha As Date

        Public Shared Function MapeoOtraCirugia(prmDatos As DataTable) As List(Of OtraCirugia)
            Try
                MapeoOtraCirugia = New List(Of OtraCirugia)
                For Each vRow As DataRow In prmDatos.Rows
                    Dim vClass As New OtraCirugia
                    vClass.Id = vRow("id").ToString
                    vClass.colId = "colId" & vRow("id").ToString
                    vClass.Cirugia = vRow("descripcion").ToString
                    vClass.Fecha = vRow("fecha").ToString
                    MapeoOtraCirugia.Add(vClass)
                Next
                Return MapeoOtraCirugia
            Catch ex As Exception
                Return Nothing
            End Try

        End Function


    End Class
End Namespace