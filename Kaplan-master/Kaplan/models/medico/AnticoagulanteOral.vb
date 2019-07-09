Namespace Clases
    Public Class AnticoagulanteOral
        Public Property Id As Integer
        Public Property colId As String
        Public Property Descripcion As String
        Public Property Dosis As String

        Public Shared Function MapeoAnticoagulanteOral(prmDatos As DataTable) As List(Of AnticoagulanteOral)
            Try
                MapeoAnticoagulanteOral = New List(Of AnticoagulanteOral)
                For Each vRow As DataRow In prmDatos.Rows
                    Dim vClass As New AnticoagulanteOral
                    vClass.Id = vRow("id").ToString
                    vClass.colId = "colId" & vRow("id").ToString
                    vClass.Descripcion = vRow("descripcion").ToString
                    vClass.Dosis = vRow("dosis").ToString
                    MapeoAnticoagulanteOral.Add(vClass)
                Next
                Return MapeoAnticoagulanteOral
            Catch ex As Exception
                Return Nothing
            End Try

        End Function

    End Class
End Namespace