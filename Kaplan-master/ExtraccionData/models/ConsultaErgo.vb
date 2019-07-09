Imports System.Data.OleDb

Namespace Clases
    Public Class ConsultaErgo
        Public Property id_paciente As Integer
        Public Property numero_ficha As Integer
        Public Property numero_reserva As Integer
        Public Property sexo As String
        Public Property situacion_laboral As String
        Public Property vol As String
        Public Property vcol As String
        Public Property vel As String
        Public Property hrl As String
        Public Property fergo As String
        Public Property loadA As String
        Public Property prload As String
        Public Property peto As String
        Public Property petco As String
        Public Property bpsys As String
        Public Property bpdia As String
        Public Property paoA As String
        Public Property paco As String
        Public Property speed As String
        Public Property grade As String
        Public Property dfco As String
        Public Property rer As String
        Public Property vok As String
        Public Property vcok As String
        Public Property vek As String
        Public Property ox As String
        Public Property eqo As String
        Public Property eqco As String
        Public Property vt As String
        Public Property timeA As String
        Public Property loadk As String
        Public Property paoB As String
        Public Property aado As String
        Public Property va As String
        Public Property vd As String
        Public Property vdvt As String
        Public Property mets As String
        Public Property aadco As String
        Public Property eff As String
        Public Property co As String
        Public Property sv As String
        Public Property lac As String
        Public Property br As String
        Public Property spo As String
        Public Property ee As String
        Public Property feto As String
        Public Property fetco As String
        Public Property cho As String
        Public Property grasa As String

        Public Shared Function getListado() As List(Of ConsultaErgo)
            Try
                Dim conn As OleDbConnection = New OleDbConnection(ConfigurationManager.ConnectionStrings("ConexionKaplan").ConnectionString)
                Dim cmd As OleDbCommand = New OleDbCommand("Kaplan.ExportarErgo", conn)
                cmd.CommandType = CommandType.StoredProcedure

                conn.Open()
                Dim adapter As OleDbDataAdapter = New OleDbDataAdapter(cmd)
                Dim vDataTable As New DataTable
                adapter.Fill(vDataTable)
                getListado = New List(Of ConsultaErgo)
                For Each vRow As DataRow In vDataTable.Rows
                    getListado.Add(Mapeo(vRow))
                Next
                conn.Close()
                Return getListado
            Catch exc As Exception
                Return Nothing
            End Try

        End Function

        Private Shared Function Mapeo(prmRow As DataRow) As ConsultaErgo
            Try
                Dim vClass As New ConsultaErgo
                vClass.id_paciente = prmRow("id_paciente").ToString
                vClass.numero_ficha = prmRow("numero_ficha").ToString
                vClass.numero_reserva = prmRow("reserva").ToString
                vClass.sexo = prmRow("sexo").ToString
                vClass.situacion_laboral = prmRow("situacion_laboral").ToString
                vClass.vol = prmRow("vol").ToString
                vClass.vcol = prmRow("vcol").ToString
                vClass.vel = prmRow("vel").ToString
                vClass.hrl = prmRow("hrl").ToString
                vClass.fergo = prmRow("fergo").ToString
                vClass.loadA = prmRow("loadA").ToString
                vClass.prload = prmRow("prload").ToString
                vClass.peto = prmRow("peto").ToString
                vClass.petco = prmRow("petco").ToString
                vClass.bpsys = prmRow("bpsys").ToString
                vClass.bpdia = prmRow("bpdia").ToString
                vClass.paoA = prmRow("paoA").ToString
                vClass.paco = prmRow("paco").ToString
                vClass.speed = prmRow("speed").ToString
                vClass.grade = prmRow("grade").ToString
                vClass.dfco = prmRow("dfco").ToString
                vClass.rer = prmRow("rer").ToString
                vClass.vok = prmRow("vok").ToString
                vClass.vcok = prmRow("vcok").ToString
                vClass.vek = prmRow("vek").ToString
                vClass.ox = prmRow("ox").ToString
                vClass.eqo = prmRow("eqo").ToString
                vClass.eqco = prmRow("eqco").ToString
                vClass.vt = prmRow("vt").ToString
                vClass.timeA = prmRow("timeA").ToString
                vClass.loadk = prmRow("loadk").ToString
                vClass.paoB = prmRow("paoB").ToString
                vClass.aado = prmRow("aado").ToString
                vClass.va = prmRow("va").ToString
                vClass.vd = prmRow("vd").ToString
                vClass.vdvt = prmRow("vdvt").ToString
                vClass.mets = prmRow("mets").ToString
                vClass.aadco = prmRow("aadco").ToString
                vClass.eff = prmRow("eff").ToString
                vClass.co = prmRow("co").ToString
                vClass.sv = prmRow("sv").ToString
                vClass.lac = prmRow("lac").ToString
                vClass.br = prmRow("br").ToString
                vClass.spo = prmRow("spo").ToString
                vClass.ee = prmRow("ee").ToString
                vClass.feto = prmRow("feto").ToString
                vClass.fetco = prmRow("fetco").ToString
                vClass.cho = prmRow("cho").ToString
                vClass.grasa = prmRow("grasa").ToString

                Return vClass

            Catch ex As Exception
                Return Nothing
            End Try
        End Function
    End Class
End Namespace