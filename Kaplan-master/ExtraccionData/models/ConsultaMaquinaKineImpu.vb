Imports System.Data.OleDb

Namespace Clases
    Public Class ConsultaMaquinaKineImpu
        Public Property id_electro As Integer
        Public Property id_paciente As Integer
        Public Property numero_ficha As Integer
        Public Property numero_reserva As Integer
        Public Property sexo As String
        Public Property situacion_laboral As String
        Public Property Startoftest As String
        Public Property EndofTest As String
        Public Property TestType As String
        Public Property TotalTesttime As String
        Public Property WarmupLoad As String
        Public Property WarmupLoadIncrease As String
        Public Property TrainingDuration As String
        Public Property TrainingUpper As String
        Public Property RelativeDecreaseofLoad As String
        Public Property MinTimeUpperlevel As String
        Public Property TimeLowerlevel As String
        Public Property AlarmLimit As String
        Public Property LoadLimit As String
        Public Property NIBPDuration As String
        Public Property Warmup1Time As String
        Public Property RestingPulse As String
        Public Property RestingBloodPressure As String
        Public Property Warmup2Time As String
        Public Property TrainingTime As String
        Public Property StressPulse As String
        Public Property StressAvgPulse As String
        Public Property StressBloodPressure As String
        Public Property Recovery1Time As String
        Public Property RecoveryPulse As String
        Public Property RecoveryBloodPressure As String
        Public Property Recovery2Time As String
        Public Property LoadValues As String
        Public Property ImpBegin As String
        Public Property ImpEnd As String
        Public Property Maximum As String
        Public Property Minimum As String
        Public Property Joule As String
        Public Property AverageLoad As String
        Public Property JouleBeats As String
        Public Property VO2Max As String
        Public Property Borgscale As String

        Public Shared Function getListado() As List(Of ConsultaMaquinaKineImpu)
            Try
                Dim conn As OleDbConnection = New OleDbConnection(ConfigurationManager.ConnectionStrings("ConexionKaplan").ConnectionString)
                Dim cmd As OleDbCommand = New OleDbCommand("Kaplan.ExportarMaquinaKineImpulse", conn)
                cmd.CommandType = CommandType.StoredProcedure

                conn.Open()
                Dim adapter As OleDbDataAdapter = New OleDbDataAdapter(cmd)
                Dim vDataTable As New DataTable
                adapter.Fill(vDataTable)
                getListado = New List(Of ConsultaMaquinaKineImpu)
                For Each vRow As DataRow In vDataTable.Rows
                    getListado.Add(Mapeo(vRow))
                Next
                conn.Close()
                Return getListado
            Catch exc As Exception
                Return Nothing
            End Try

        End Function

        Private Shared Function Mapeo(prmRow As DataRow) As ConsultaMaquinaKineImpu
            Try
                Dim vClass As New ConsultaMaquinaKineImpu
                vClass.id_electro = prmRow("id_electro").ToString
                vClass.id_paciente = prmRow("id_paciente").ToString
                vClass.numero_ficha = prmRow("numero_ficha").ToString
                vClass.numero_reserva = prmRow("reserva").ToString
                vClass.sexo = prmRow("sexo").ToString
                vClass.situacion_laboral = prmRow("situacion_laboral").ToString
                vClass.Startoftest = prmRow("Startoftest").ToString
                vClass.EndofTest = prmRow("EndofTest").ToString
                vClass.TestType = prmRow("TestType").ToString
                vClass.TotalTesttime = prmRow("TotalTesttime").ToString
                vClass.WarmupLoad = prmRow("WarmupLoad").ToString
                vClass.WarmupLoadIncrease = prmRow("WarmupLoadIncrease").ToString
                vClass.TrainingDuration = prmRow("TrainingDuration").ToString
                vClass.TrainingUpper = prmRow("TrainingUpper").ToString
                vClass.RelativeDecreaseofLoad = prmRow("RelativeDecreaseofLoad").ToString
                vClass.MinTimeUpperlevel = prmRow("MinTimeUpperlevel").ToString
                vClass.TimeLowerlevel = prmRow("TimeLowerlevel").ToString
                vClass.AlarmLimit = prmRow("AlarmLimit").ToString
                vClass.LoadLimit = prmRow("LoadLimit").ToString
                vClass.NIBPDuration = prmRow("NIBPDuration").ToString
                vClass.Warmup1Time = prmRow("Warmup1Time").ToString
                vClass.RestingPulse = prmRow("RestingPulse").ToString
                vClass.RestingBloodPressure = prmRow("RestingBloodPressure").ToString
                vClass.Warmup2Time = prmRow("Warmup2Time").ToString
                vClass.TrainingTime = prmRow("TrainingTime").ToString
                vClass.StressPulse = prmRow("StressPulse").ToString
                vClass.StressAvgPulse = prmRow("StressAvgPulse").ToString
                vClass.StressBloodPressure = prmRow("StressBloodPressure").ToString
                vClass.Recovery1Time = prmRow("Recovery1Time").ToString
                vClass.RecoveryPulse = prmRow("RecoveryPulse").ToString
                vClass.RecoveryBloodPressure = prmRow("RecoveryBloodPressure").ToString
                vClass.Recovery2Time = prmRow("Recovery2Time").ToString
                vClass.LoadValues = prmRow("LoadValues").ToString
                vClass.ImpBegin = prmRow("ImpBegin").ToString
                vClass.ImpEnd = prmRow("ImpEnd").ToString
                vClass.Maximum = prmRow("Maximum").ToString
                vClass.Minimum = prmRow("Minimum").ToString
                vClass.Joule = prmRow("Joule").ToString
                vClass.AverageLoad = prmRow("AverageLoad").ToString
                vClass.JouleBeats = prmRow("JouleBeats").ToString
                vClass.VO2Max = prmRow("VO2Max").ToString
                vClass.Borgscale = prmRow("Borgscale").ToString

                Return vClass

            Catch ex As Exception
                Return Nothing
            End Try
        End Function
    End Class
End Namespace