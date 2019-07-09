Imports System.Data.OleDb

Namespace Clases
    Public Class ConsultaMaquinasKine
        Public Property id_electro As Integer
        Public Property id_paciente As Integer
        Public Property numero_ficha As Integer
        Public Property numero_reserva As Integer
        Public Property sexo As String
        Public Property situacion_laboral As String
        Public Property datoA As String
        Public Property datoB As String
        Public Property datoC As String
        Public Property datoD As String
        Public Property datoE As String
        Public Property datoF As String

        Public Shared Function getListado() As List(Of ConsultaMaquinasKine)
            Try
                Dim conn As OleDbConnection = New OleDbConnection(ConfigurationManager.ConnectionStrings("ConexionKaplan").ConnectionString)
                Dim cmd As OleDbCommand = New OleDbCommand("Kaplan.ExportarMaquinaKine", conn)
                cmd.CommandType = CommandType.StoredProcedure

                conn.Open()
                Dim adapter As OleDbDataAdapter = New OleDbDataAdapter(cmd)
                Dim vDataTable As New DataTable
                adapter.Fill(vDataTable)
                getListado = New List(Of ConsultaMaquinasKine)
                For Each vRow As DataRow In vDataTable.Rows
                    getListado.Add(Mapeo(vRow))
                Next
                conn.Close()
                Return getListado
            Catch exc As Exception
                Return Nothing
            End Try

        End Function

        Private Shared Function Mapeo(prmRow As DataRow) As ConsultaMaquinasKine
            Try
                Dim vClass As New ConsultaMaquinasKine
                vClass.id_electro = prmRow("id_electro").ToString
                vClass.id_paciente = prmRow("id_paciente").ToString
                vClass.numero_ficha = prmRow("numero_ficha").ToString
                vClass.sexo = prmRow("sexo").ToString
                vClass.situacion_laboral = prmRow("situacion_laboral").ToString
                vClass.numero_reserva = prmRow("reserva").ToString
                vClass.datoA = prmRow("datoA").ToString
                vClass.datoB = prmRow("datoB").ToString
                vClass.datoC = prmRow("datoC").ToString
                vClass.datoD = prmRow("datoD").ToString
                vClass.datoE = prmRow("datoE").ToString
                vClass.datoF = prmRow("datoF").ToString

                Return vClass

            Catch ex As Exception
                Return Nothing
            End Try
        End Function
    End Class
End Namespace

