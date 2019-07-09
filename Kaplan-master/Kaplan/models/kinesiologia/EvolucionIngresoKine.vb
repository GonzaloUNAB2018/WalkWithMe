Imports Kaplan.Clases
Imports System.Globalization
Imports System.Data.OleDb
Imports System.Data.SqlClient

Namespace Clases
    Public Class EvolucionIngresoKine
        Public Property Id As Integer
        Public Property Observacion As String
        Public Property EME As String
        Public Property Fecha As Date
        Public ReadOnly Property FechaString As String
            Get
                Return Fecha.ToString("dd MMM yyyy")
            End Get
        End Property

        Public Shared Function Mapeo(prmDatos As DataTable) As EvolucionIngresoKine
            Try
                Dim vEvolucion As New EvolucionIngresoKine
                prmDatos.DefaultView.RowFilter = "id_tipo = 1"
                Dim prmRow As DataRowView = prmDatos.DefaultView.Item(0)
                vEvolucion.Id = prmRow("id_evolucion").ToString
                vEvolucion.Observacion = prmRow("observacion").ToString
                vEvolucion.EME = prmRow("eva_mus_esq").ToString
                vEvolucion.Fecha = prmRow("fecha").ToString

                Return vEvolucion
            Catch ex As Exception
                Return Nothing
            End Try

        End Function

    End Class
End Namespace