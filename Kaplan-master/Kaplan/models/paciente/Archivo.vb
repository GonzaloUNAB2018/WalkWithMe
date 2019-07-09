Imports Kaplan.Clases
Imports System.Globalization
Imports System.Data.OleDb
Imports System.Data.SqlClient
Imports System.IO
Namespace Clases
    Public Class Archivo
        Public Property Id As Integer
        Public Property FechaRegistro As Date
        Public Property FechaReserva As Date
        Public Property Plan As String
        Public Property Especialista As String
        Public Property Formato As String
        Public Property Tipo As String
        Public ReadOnly Property FechaRegistroString As String
            Get
                Return FechaRegistro.ToString("dd MMM yyyy")
            End Get
        End Property
        Public ReadOnly Property FechaReservaString As String
            Get
                Return FechaReserva.ToString("dd MMM yyyy")
            End Get
        End Property
        Public Shared Function getArchivos(inRut As Integer) As List(Of Archivo)
            Try
                Dim conn As OleDbConnection = New OleDbConnection(ConfigurationManager.ConnectionStrings("ConexionKaplan").ConnectionString)
                Dim cmd As OleDbCommand = New OleDbCommand("Kaplan.ListadoArchivos", conn)
                cmd.CommandType = CommandType.StoredProcedure

                Dim inPaciente As OleDbParameter = cmd.Parameters.Add("@inPaciente", OleDbType.Decimal, Nothing)
                inPaciente.Direction = ParameterDirection.Input
                inPaciente.Value = inRut

                conn.Open()
                Dim adapter As OleDbDataAdapter = New OleDbDataAdapter(cmd)
                Dim vDataTable As New DataTable
                adapter.Fill(vDataTable)
                getArchivos = New List(Of Archivo)
                For Each vRow As DataRow In vDataTable.Rows
                    getArchivos.Add(Mapeo(vRow))
                Next
                conn.Close()
                Return getArchivos
            Catch exc As Exception
                Return Nothing
            End Try

        End Function
        Private Shared Function Mapeo(prmRow As DataRow) As Archivo
            Try
                Dim vArchivo As New Archivo
                vArchivo.Id = prmRow("ID")
                vArchivo.FechaRegistro = prmRow("FechaRegistro")
                vArchivo.FechaReserva = prmRow("FechaReserva")
                vArchivo.Plan = prmRow("nombrePlan").ToString
                vArchivo.Especialista = prmRow("Especialista").ToString
                vArchivo.Tipo = prmRow("Tipo").ToString
                Return vArchivo
            Catch ex As Exception
                Return Nothing
            End Try
        End Function
        Public Function registrarArchivo(ruta As String, contenido As Byte()) As Boolean
            Try
                Dim olecon As OleDbConnection
                Dim olecomm As OleDbCommand
                Dim oleadpt As OleDbDataAdapter
                Dim ds As DataSet
                Dim connstring As String = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + ruta + ";Extended Properties=""Excel 8.0;HDR=NO;"""
                olecon = New OleDbConnection
                olecon.ConnectionString = connstring
                olecomm = New OleDbCommand
                olecomm.CommandText = "Select * from [Ergo$A1:AT]"
                olecomm.Connection = olecon
                oleadpt = New OleDbDataAdapter(olecomm)
                ds = New DataSet

                olecon.Open()
                oleadpt.Fill(ds, "Fijo")
                Dim jsonDemo As String = GetJson(ds.Tables("fijo"))
                cargarArchivo(jsonDemo.ToString.Replace("[", "{" + """column""" + ":[").Replace("]", "]}"), contenido)

                registrarArchivo = True
            Catch exc As Exception
                registrarArchivo = False
            End Try
        End Function
        Public Function registrarArchivoTxt(ruta As String, contenido As Byte()) As Boolean
            Try
#Region "Electro"
                Dim jsonElectro As String
                Dim jsonEjercicio As String = ""
                Dim tabla As Integer
                Dim reader As New StreamReader(ruta, Encoding.Default)
                Dim a As String
                Dim linea As String()
                Dim dtCardio As New DataTable
                dtCardio.Columns.Add("datoA")
                dtCardio.Columns.Add("datoB")
                dtCardio.Columns.Add("datoC")
                dtCardio.Columns.Add("datoD")
                dtCardio.Columns.Add("datoE")
                dtCardio.Columns.Add("datoF")
                Do
                    a = reader.ReadLine
                    If Not a Is Nothing Then
                        linea = a.Split(",")
                        If linea(0) <> "------End of Test------" Then
                            Dim row As DataRow = dtCardio.NewRow
                            row("datoA") = linea(0)
                            row("datoB") = linea(1)
                            row("datoC") = linea(2)
                            row("datoD") = linea(3)
                            row("datoE") = linea(4)
                            row("datoF") = linea(5)
                            dtCardio.Rows.Add(row)
                        Else
                            Exit Do
                        End If
                    End If
                Loop Until a Is Nothing
                jsonElectro = GetJsonElectro(dtCardio)
#End Region
#Region "Constant"
                Dim dtA As New DataTable
                dtA.Columns.Add("Starttest", GetType(String))
                dtA.Columns.Add("EndTest", GetType(String))
                dtA.Columns.Add("TestType", GetType(String))
                dtA.Columns.Add("TotalTesttime", GetType(String))
                dtA.Columns.Add("WarmupLoad", GetType(String))
                dtA.Columns.Add("WarmupLoadIncrease", GetType(String))
                dtA.Columns.Add("TrainingDuration", GetType(String))
                dtA.Columns.Add("TrainingLoad", GetType(String))
                dtA.Columns.Add("RelativeDecrease", GetType(String))
                dtA.Columns.Add("AlarmLimit", GetType(String))
                dtA.Columns.Add("LoadLimit", GetType(String))
                dtA.Columns.Add("NIBPDuration", GetType(String))
                dtA.Columns.Add("Warmup1Time", GetType(String))
                dtA.Columns.Add("RestingPulse", GetType(String))
                dtA.Columns.Add("RestingBloodPressure", GetType(String))
                dtA.Columns.Add("Warmup2Time", GetType(String))
                dtA.Columns.Add("TrainingTime", GetType(String))
                dtA.Columns.Add("StressPulse", GetType(String))
                dtA.Columns.Add("StressAvgPulse", GetType(String))
                dtA.Columns.Add("StressBloodPressure", GetType(String))
                dtA.Columns.Add("Recovery1Time", GetType(String))
                dtA.Columns.Add("RecoveryPulse", GetType(String))
                dtA.Columns.Add("RecoveryBloodPressure", GetType(String))
                dtA.Columns.Add("Recovery2Time", GetType(String))
                dtA.Columns.Add("LoadValues", GetType(String))
                dtA.Columns.Add("BeginCons", GetType(String))
                dtA.Columns.Add("EndCons", GetType(String))
                dtA.Columns.Add("Maximum", GetType(String))
                dtA.Columns.Add("Minimum", GetType(String))
                dtA.Columns.Add("Joule", GetType(String))
                dtA.Columns.Add("AverageLoad", GetType(String))
                dtA.Columns.Add("JouleBeats", GetType(String))
                dtA.Columns.Add("VO2Max", GetType(String))
                dtA.Columns.Add("Borgscale", GetType(String))
#End Region
#Region "Treadmill"
                Dim dtB As New DataTable
                dtB.Columns.Add("Startoftest", GetType(String))
                dtB.Columns.Add("EndofTest", GetType(String))
                dtB.Columns.Add("TestType", GetType(String))
                dtB.Columns.Add("TotalTesttime", GetType(String))
                dtB.Columns.Add("Warmup1Speed", GetType(String))
                dtB.Columns.Add("Warmup1Slope", GetType(String))
                dtB.Columns.Add("Warmup2Speed", GetType(String))
                dtB.Columns.Add("Warmup2Slope", GetType(String))
                dtB.Columns.Add("TrainingDuration", GetType(String))
                dtB.Columns.Add("TrainingSpeed", GetType(String))
                dtB.Columns.Add("TrainingSlope", GetType(String))
                dtB.Columns.Add("Warmup1Time", GetType(String))
                dtB.Columns.Add("RestingPulse", GetType(String))
                dtB.Columns.Add("RestingBloodPressure", GetType(String))
                dtB.Columns.Add("Warmup2Time", GetType(String))
                dtB.Columns.Add("TrainingTime", GetType(String))
                dtB.Columns.Add("StressPulse", GetType(String))
                dtB.Columns.Add("StressAvgPulse", GetType(String))
                dtB.Columns.Add("StressBloodPressure", GetType(String))
                dtB.Columns.Add("Recovery1Time", GetType(String))
                dtB.Columns.Add("RecoveryPulse", GetType(String))
                dtB.Columns.Add("RecoveryBloodPressure", GetType(String))
                dtB.Columns.Add("Recovery2Time", GetType(String))
                dtB.Columns.Add("VO2Max", GetType(String))
                dtB.Columns.Add("Distance", GetType(String))
                dtB.Columns.Add("Borgscale", GetType(String))
#End Region
#Region "Impulse"
                Dim dtC As New DataTable
                dtC.Columns.Add("Startoftest", GetType(String))
                dtC.Columns.Add("EndofTest", GetType(String))
                dtC.Columns.Add("TestType", GetType(String))
                dtC.Columns.Add("TotalTesttime", GetType(String))
                dtC.Columns.Add("WarmupLoad", GetType(String))
                dtC.Columns.Add("WarmupLoadIncrease", GetType(String))
                dtC.Columns.Add("TrainingDuration", GetType(String))
                dtC.Columns.Add("TrainingUpper", GetType(String))
                dtC.Columns.Add("RelativeDecreaseofLoad", GetType(String))
                dtC.Columns.Add("MinTimeUpperlevel", GetType(String))
                dtC.Columns.Add("TimeLowerlevel", GetType(String))
                dtC.Columns.Add("AlarmLimit", GetType(String))
                dtC.Columns.Add("LoadLimit", GetType(String))
                dtC.Columns.Add("NIBPDuration", GetType(String))
                dtC.Columns.Add("Warmup1Time", GetType(String))
                dtC.Columns.Add("RestingPulse", GetType(String))
                dtC.Columns.Add("RestingBloodPressure", GetType(String))
                dtC.Columns.Add("Warmup2Time", GetType(String))
                dtC.Columns.Add("TrainingTime", GetType(String))
                dtC.Columns.Add("StressPulse", GetType(String))
                dtC.Columns.Add("StressAvgPulse", GetType(String))
                dtC.Columns.Add("StressBloodPressure", GetType(String))
                dtC.Columns.Add("Recovery1Time", GetType(String))
                dtC.Columns.Add("RecoveryPulse", GetType(String))
                dtC.Columns.Add("RecoveryBloodPressure", GetType(String))
                dtC.Columns.Add("Recovery2Time", GetType(String))
                dtC.Columns.Add("LoadValues", GetType(String))
                dtC.Columns.Add("ImpBegin", GetType(String))
                dtC.Columns.Add("ImpEnd", GetType(String))
                dtC.Columns.Add("Maximum", GetType(String))
                dtC.Columns.Add("Minimum", GetType(String))
                dtC.Columns.Add("Joule", GetType(String))
                dtC.Columns.Add("AverageLoad", GetType(String))
                dtC.Columns.Add("JouleBeats", GetType(String))
                dtC.Columns.Add("VO2Max", GetType(String))
                dtC.Columns.Add("Borgscale", GetType(String))

                Dim inicio As String
                Dim termino As String
                Dim tipo As String

                a = reader.ReadLine
                linea = a.Split("=")
                inicio = linea(1)
                a = reader.ReadLine
                linea = a.Split("=")
                termino = linea(1)
                a = reader.ReadLine
                linea = a.Split("=")
                tipo = linea(1)
#End Region
#Region "Archivo Constant Load"
                Dim cont As Integer = 3
                If tipo = "Load : Constant Load" Then
                    Dim rowA As DataRow = dtA.NewRow
                    rowA(0) = inicio
                    rowA(1) = termino
                    rowA(2) = tipo
                    Do
                        If cont < 34 Then
                            a = reader.ReadLine
                            If Not a Is Nothing Then
                                linea = a.Split("=")
                                If linea(0).Substring(0, 1) <> "-" Then
                                    rowA(cont) = IIf(linea(1) <> "", linea(1), "0")
                                Else
                                    cont = cont - 1
                                End If
                            End If
                            cont = cont + 1
                        Else
                            Exit Do
                        End If
                    Loop Until a Is Nothing
                    dtA.Rows.Add(rowA)
                    jsonEjercicio = GetJsonConstant(dtA)
                    tabla = 1
                End If
#End Region
#Region "Archivo Treadmill"
                If tipo = "Treadmill : Treadmill" Then
                    Dim rowB As DataRow = dtB.NewRow
                    rowB(0) = inicio
                    rowB(1) = termino
                    rowB(2) = tipo
                    Do
                        If cont < 26 Then
                            a = reader.ReadLine
                            If Not a Is Nothing Then
                                linea = a.Split("=")
                                If linea(0).Substring(0, 1) <> "-" Then
                                    rowB(cont) = IIf(linea(1) <> "", linea(1), "0")
                                Else
                                    cont = cont - 1
                                End If
                            End If
                            cont = cont + 1
                        Else
                            Exit Do
                        End If
                    Loop Until a Is Nothing
                    dtB.Rows.Add(rowB)
                    jsonEjercicio = GetJsonTreadmill(dtB)
                    tabla = 2
                End If
#End Region
#Region "Archivo Impulse"
                If tipo = "Load : Impulse" Then
                    Dim rowC As DataRow = dtC.NewRow
                    rowC(0) = inicio
                    rowC(1) = termino
                    rowC(2) = tipo
                    Do
                        If cont < 36 Then
                            a = reader.ReadLine
                            If Not a Is Nothing Then
                                linea = a.Split("=")
                                If linea(0).Substring(0, 1) <> "-" Then
                                    rowC(cont) = IIf(linea(1) <> "", linea(1), "0")
                                Else
                                    cont = cont - 1
                                End If
                            End If
                            cont = cont + 1
                        Else
                            Exit Do
                        End If
                    Loop Until a Is Nothing
                    dtC.Rows.Add(rowC)
                    jsonEjercicio = GetJsonImpulse(dtC)
                    tabla = 3
                End If
#End Region
                Dim electro As String = jsonElectro.ToString.Replace("[", "{" + """columnA""" + ":[").Replace("]", "]}")
                Dim ejercicio As String = jsonEjercicio.ToString.Replace("[", "{" + """columnB""" + ":[").Replace("]", "]}")
                cargarElectro(electro, ejercicio, tabla, contenido)
                registrarArchivoTxt = True
            Catch exc As Exception
                registrarArchivoTxt = False
            End Try
        End Function
        Public Function cargarArchivo(datos As String, contenido As Byte()) As Boolean
            Dim conn As OleDbConnection = New OleDbConnection(ConfigurationManager.ConnectionStrings("ConexionKaplan").ConnectionString)
            Dim cmd As OleDbCommand = New OleDbCommand("Kaplan.registrarArchivo", conn)
            cmd.CommandType = CommandType.StoredProcedure

            Dim inId As OleDbParameter = cmd.Parameters.Add("@id", OleDbType.Decimal, Nothing)
            inId.Direction = ParameterDirection.Input
            inId.Value = Me.Id

            Dim indiagnostico As OleDbParameter = cmd.Parameters.Add("@datos", OleDbType.VarChar, -1)
            indiagnostico.Direction = ParameterDirection.Input
            indiagnostico.Value = datos

            Dim inArchivo As OleDbParameter = cmd.Parameters.Add("@archivo", OleDbType.VarBinary, -1)
            inArchivo.Direction = ParameterDirection.Input
            inArchivo.Value = contenido

            Dim outError As OleDbParameter = cmd.Parameters.Add("@outError", OleDbType.Integer)
            outError.Direction = ParameterDirection.Output

            conn.Open()
            cmd.ExecuteReader()
            conn.Close()

            Dim idkine = CInt(cmd.Parameters("@outError").Value)

            Return CInt(cmd.Parameters("@outError").Value)
        End Function
        Public Function cargarElectro(electro As String, ejercicio As String, tabla As Integer, contenido As Byte()) As Boolean
            Dim conn As OleDbConnection = New OleDbConnection(ConfigurationManager.ConnectionStrings("ConexionKaplan").ConnectionString)
            Dim cmd As OleDbCommand = New OleDbCommand("Kaplan.registrarElectro", conn)
            cmd.CommandType = CommandType.StoredProcedure

            Dim inId As OleDbParameter = cmd.Parameters.Add("@id", OleDbType.Decimal, Nothing)
            inId.Direction = ParameterDirection.Input
            inId.Value = Me.Id

            Dim inElectro As OleDbParameter = cmd.Parameters.Add("@electro", OleDbType.VarChar, -1)
            inElectro.Direction = ParameterDirection.Input
            inElectro.Value = electro

            Dim inConstant As OleDbParameter = cmd.Parameters.Add("@ejercicio", OleDbType.VarChar, -1)
            inConstant.Direction = ParameterDirection.Input
            inConstant.Value = ejercicio

            Dim inTabla As OleDbParameter = cmd.Parameters.Add("@tabla", OleDbType.Integer, Nothing)
            inTabla.Direction = ParameterDirection.Input
            inTabla.Value = tabla

            Dim inArchivo As OleDbParameter = cmd.Parameters.Add("@archivo", OleDbType.VarBinary, -1)
            inArchivo.Direction = ParameterDirection.Input
            inArchivo.Value = contenido

            Dim outError As OleDbParameter = cmd.Parameters.Add("@outError", OleDbType.Integer)
            outError.Direction = ParameterDirection.Output

            conn.Open()
            cmd.ExecuteReader()
            conn.Close()

            Dim idkine = CInt(cmd.Parameters("@outError").Value)

            Return CInt(cmd.Parameters("@outError").Value)
        End Function
        Public Function GetJsonElectro(ByVal dt As DataTable) As String
            Dim serializer As New System.Web.Script.Serialization.JavaScriptSerializer()
            Dim rows As New List(Of Dictionary(Of String, Object))()
            Dim row As Dictionary(Of String, Object) = Nothing
            For Each dr As DataRow In dt.Rows
                row = New Dictionary(Of String, Object)()
                For Each dc As DataColumn In dt.Columns
                    If dc.ColumnName.Trim() = "datoA" Then
                        row.Add(dc.ColumnName.Trim(), dr(dc))
                    End If
                    If dc.ColumnName.Trim() = "datoB" Then
                        row.Add(dc.ColumnName.Trim(), dr(dc).ToString.Replace(",", "."))
                    End If
                    If dc.ColumnName.Trim() = "datoC" Then
                        row.Add(dc.ColumnName.Trim(), dr(dc).ToString.Replace(",", "."))
                    End If
                    If dc.ColumnName.Trim() = "datoD" Then
                        row.Add(dc.ColumnName.Trim(), dr(dc).ToString.Replace(",", "."))
                    End If
                    If dc.ColumnName.Trim() = "datoE" Then
                        row.Add(dc.ColumnName.Trim(), dr(dc).ToString.Replace(",", "."))
                    End If
                    If dc.ColumnName.Trim() = "datoF" Then
                        row.Add(dc.ColumnName.Trim(), dr(dc).ToString.Replace(",", "."))
                    End If
                Next
                rows.Add(row)
            Next
            Return serializer.Serialize(rows)
        End Function
        Public Function GetJsonConstant(ByVal dt As DataTable) As String
            Dim serializer As New System.Web.Script.Serialization.JavaScriptSerializer()
            Dim rows As New List(Of Dictionary(Of String, Object))()
            Dim row As Dictionary(Of String, Object) = Nothing
            For Each dr As DataRow In dt.Rows
                row = New Dictionary(Of String, Object)()
                For Each dc As DataColumn In dt.Columns
                    If dc.ColumnName.Trim() = "Starttest" Then row.Add(dc.ColumnName.Trim(), dr(dc).ToString.Replace(",", "."))
                    If dc.ColumnName.Trim() = "EndTest" Then row.Add(dc.ColumnName.Trim(), dr(dc).ToString.Replace(",", "."))
                    If dc.ColumnName.Trim() = "TestType" Then row.Add(dc.ColumnName.Trim(), dr(dc).ToString.Replace(",", "."))
                    If dc.ColumnName.Trim() = "TotalTesttime" Then row.Add(dc.ColumnName.Trim(), dr(dc).ToString.Replace(",", "."))
                    If dc.ColumnName.Trim() = "WarmupLoad" Then row.Add(dc.ColumnName.Trim(), dr(dc).ToString.Replace(",", "."))
                    If dc.ColumnName.Trim() = "WarmupLoadIncrease" Then row.Add(dc.ColumnName.Trim(), dr(dc).ToString.Replace(",", "."))
                    If dc.ColumnName.Trim() = "TrainingDuration" Then row.Add(dc.ColumnName.Trim(), dr(dc).ToString.Replace(",", "."))
                    If dc.ColumnName.Trim() = "TrainingLoad" Then row.Add(dc.ColumnName.Trim(), dr(dc).ToString.Replace(",", "."))
                    If dc.ColumnName.Trim() = "RelativeDecrease" Then row.Add(dc.ColumnName.Trim(), dr(dc).ToString.Replace(",", "."))
                    If dc.ColumnName.Trim() = "AlarmLimit" Then row.Add(dc.ColumnName.Trim(), dr(dc).ToString.Replace(",", "."))
                    If dc.ColumnName.Trim() = "LoadLimit" Then row.Add(dc.ColumnName.Trim(), dr(dc).ToString.Replace(",", "."))
                    If dc.ColumnName.Trim() = "NIBPDuration" Then row.Add(dc.ColumnName.Trim(), dr(dc).ToString.Replace(",", "."))
                    If dc.ColumnName.Trim() = "Warmup1Time" Then row.Add(dc.ColumnName.Trim(), dr(dc).ToString.Replace(",", "."))
                    If dc.ColumnName.Trim() = "RestingPulse" Then row.Add(dc.ColumnName.Trim(), dr(dc).ToString.Replace(",", "."))
                    If dc.ColumnName.Trim() = "RestingBloodPressure" Then row.Add(dc.ColumnName.Trim(), dr(dc).ToString.Replace(",", "."))
                    If dc.ColumnName.Trim() = "Warmup2Time" Then row.Add(dc.ColumnName.Trim(), dr(dc).ToString.Replace(",", "."))
                    If dc.ColumnName.Trim() = "TrainingTime" Then row.Add(dc.ColumnName.Trim(), dr(dc).ToString.Replace(",", "."))
                    If dc.ColumnName.Trim() = "StressPulse" Then row.Add(dc.ColumnName.Trim(), dr(dc).ToString.Replace(",", "."))
                    If dc.ColumnName.Trim() = "StressAvgPulse" Then row.Add(dc.ColumnName.Trim(), dr(dc).ToString.Replace(",", "."))
                    If dc.ColumnName.Trim() = "StressBloodPressure" Then row.Add(dc.ColumnName.Trim(), dr(dc).ToString.Replace(",", "."))
                    If dc.ColumnName.Trim() = "Recovery1Time" Then row.Add(dc.ColumnName.Trim(), dr(dc).ToString.Replace(",", "."))
                    If dc.ColumnName.Trim() = "RecoveryPulse" Then row.Add(dc.ColumnName.Trim(), dr(dc).ToString.Replace(",", "."))
                    If dc.ColumnName.Trim() = "RecoveryBloodPressure" Then row.Add(dc.ColumnName.Trim(), dr(dc).ToString.Replace(",", "."))
                    If dc.ColumnName.Trim() = "Recovery2Time" Then row.Add(dc.ColumnName.Trim(), dr(dc).ToString.Replace(",", "."))
                    If dc.ColumnName.Trim() = "LoadValues" Then row.Add(dc.ColumnName.Trim(), dr(dc).ToString.Replace(",", "."))
                    If dc.ColumnName.Trim() = "BeginCons" Then row.Add(dc.ColumnName.Trim(), dr(dc).ToString.Replace(",", "."))
                    If dc.ColumnName.Trim() = "EndCons" Then row.Add(dc.ColumnName.Trim(), dr(dc).ToString.Replace(",", "."))
                    If dc.ColumnName.Trim() = "Maximum" Then row.Add(dc.ColumnName.Trim(), dr(dc).ToString.Replace(",", "."))
                    If dc.ColumnName.Trim() = "Minimum" Then row.Add(dc.ColumnName.Trim(), dr(dc).ToString.Replace(",", "."))
                    If dc.ColumnName.Trim() = "Joule" Then row.Add(dc.ColumnName.Trim(), dr(dc).ToString.Replace(",", "."))
                    If dc.ColumnName.Trim() = "AverageLoad" Then row.Add(dc.ColumnName.Trim(), dr(dc).ToString.Replace(",", "."))
                    If dc.ColumnName.Trim() = "JouleBeats" Then row.Add(dc.ColumnName.Trim(), dr(dc).ToString.Replace(",", "."))
                    If dc.ColumnName.Trim() = "VO2Max" Then row.Add(dc.ColumnName.Trim(), dr(dc).ToString.Replace(",", "."))
                    If dc.ColumnName.Trim() = "Borgscale" Then row.Add(dc.ColumnName.Trim(), dr(dc).ToString.Replace(",", "."))
                Next
                rows.Add(row)
            Next
            Return serializer.Serialize(rows)
        End Function
        Public Function GetJsonTreadmill(ByVal dt As DataTable) As String
            Dim serializer As New System.Web.Script.Serialization.JavaScriptSerializer()
            Dim rows As New List(Of Dictionary(Of String, Object))()
            Dim row As Dictionary(Of String, Object) = Nothing
            For Each dr As DataRow In dt.Rows
                row = New Dictionary(Of String, Object)()
                For Each dc As DataColumn In dt.Columns
                    If dc.ColumnName.Trim() = "Startoftest" Then row.Add(dc.ColumnName.Trim(), dr(dc).ToString.Replace(",", "."))
                    If dc.ColumnName.Trim() = "EndofTest" Then row.Add(dc.ColumnName.Trim(), dr(dc).ToString.Replace(",", "."))
                    If dc.ColumnName.Trim() = "TestType" Then row.Add(dc.ColumnName.Trim(), dr(dc).ToString.Replace(",", "."))
                    If dc.ColumnName.Trim() = "TotalTesttime" Then row.Add(dc.ColumnName.Trim(), dr(dc).ToString.Replace(",", "."))
                    If dc.ColumnName.Trim() = "Warmup1Speed" Then row.Add(dc.ColumnName.Trim(), dr(dc).ToString.Replace(",", "."))
                    If dc.ColumnName.Trim() = "Warmup1Slope" Then row.Add(dc.ColumnName.Trim(), dr(dc).ToString.Replace(",", "."))
                    If dc.ColumnName.Trim() = "Warmup2Speed" Then row.Add(dc.ColumnName.Trim(), dr(dc).ToString.Replace(",", "."))
                    If dc.ColumnName.Trim() = "Warmup2Slope" Then row.Add(dc.ColumnName.Trim(), dr(dc).ToString.Replace(",", "."))
                    If dc.ColumnName.Trim() = "TrainingDuration" Then row.Add(dc.ColumnName.Trim(), dr(dc).ToString.Replace(",", "."))
                    If dc.ColumnName.Trim() = "TrainingSpeed" Then row.Add(dc.ColumnName.Trim(), dr(dc).ToString.Replace(",", "."))
                    If dc.ColumnName.Trim() = "TrainingSlope" Then row.Add(dc.ColumnName.Trim(), dr(dc).ToString.Replace(",", "."))
                    If dc.ColumnName.Trim() = "Warmup1Time" Then row.Add(dc.ColumnName.Trim(), dr(dc).ToString.Replace(",", "."))
                    If dc.ColumnName.Trim() = "RestingPulse" Then row.Add(dc.ColumnName.Trim(), dr(dc).ToString.Replace(",", "."))
                    If dc.ColumnName.Trim() = "RestingBloodPressure" Then row.Add(dc.ColumnName.Trim(), dr(dc).ToString.Replace(",", "."))
                    If dc.ColumnName.Trim() = "Warmup2Time" Then row.Add(dc.ColumnName.Trim(), dr(dc).ToString.Replace(",", "."))
                    If dc.ColumnName.Trim() = "TrainingTime" Then row.Add(dc.ColumnName.Trim(), dr(dc).ToString.Replace(",", "."))
                    If dc.ColumnName.Trim() = "StressPulse" Then row.Add(dc.ColumnName.Trim(), dr(dc).ToString.Replace(",", "."))
                    If dc.ColumnName.Trim() = "StressAvgPulse" Then row.Add(dc.ColumnName.Trim(), dr(dc).ToString.Replace(",", "."))
                    If dc.ColumnName.Trim() = "StressBloodPressure" Then row.Add(dc.ColumnName.Trim(), dr(dc).ToString.Replace(",", "."))
                    If dc.ColumnName.Trim() = "Recovery1Time" Then row.Add(dc.ColumnName.Trim(), dr(dc).ToString.Replace(",", "."))
                    If dc.ColumnName.Trim() = "RecoveryPulse" Then row.Add(dc.ColumnName.Trim(), dr(dc).ToString.Replace(",", "."))
                    If dc.ColumnName.Trim() = "RecoveryBloodPressure" Then row.Add(dc.ColumnName.Trim(), dr(dc).ToString.Replace(",", "."))
                    If dc.ColumnName.Trim() = "Recovery2Time" Then row.Add(dc.ColumnName.Trim(), dr(dc).ToString.Replace(",", "."))
                    If dc.ColumnName.Trim() = "VO2Max" Then row.Add(dc.ColumnName.Trim(), dr(dc).ToString.Replace(",", "."))
                    If dc.ColumnName.Trim() = "Distance" Then row.Add(dc.ColumnName.Trim(), dr(dc).ToString.Replace(",", "."))
                    If dc.ColumnName.Trim() = "Borgscale" Then row.Add(dc.ColumnName.Trim(), dr(dc).ToString.Replace(",", "."))
                Next
                rows.Add(row)
            Next
            Return serializer.Serialize(rows)
        End Function
        Public Function GetJsonImpulse(ByVal dt As DataTable) As String
            Dim serializer As New System.Web.Script.Serialization.JavaScriptSerializer()
            Dim rows As New List(Of Dictionary(Of String, Object))()
            Dim row As Dictionary(Of String, Object) = Nothing
            For Each dr As DataRow In dt.Rows
                row = New Dictionary(Of String, Object)()
                For Each dc As DataColumn In dt.Columns
                    If dc.ColumnName.Trim() = "Startoftest" Then row.Add(dc.ColumnName.Trim(), dr(dc).ToString.Replace(",", "."))
                    If dc.ColumnName.Trim() = "EndofTest" Then row.Add(dc.ColumnName.Trim(), dr(dc).ToString.Replace(",", "."))
                    If dc.ColumnName.Trim() = "TestType" Then row.Add(dc.ColumnName.Trim(), dr(dc).ToString.Replace(",", "."))
                    If dc.ColumnName.Trim() = "TotalTesttime" Then row.Add(dc.ColumnName.Trim(), dr(dc).ToString.Replace(",", "."))
                    If dc.ColumnName.Trim() = "WarmupLoad" Then row.Add(dc.ColumnName.Trim(), dr(dc).ToString.Replace(",", "."))
                    If dc.ColumnName.Trim() = "WarmupLoadIncrease" Then row.Add(dc.ColumnName.Trim(), dr(dc).ToString.Replace(",", "."))
                    If dc.ColumnName.Trim() = "TrainingDuration" Then row.Add(dc.ColumnName.Trim(), dr(dc).ToString.Replace(",", "."))
                    If dc.ColumnName.Trim() = "TrainingUpper" Then row.Add(dc.ColumnName.Trim(), dr(dc).ToString.Replace(",", "."))
                    If dc.ColumnName.Trim() = "RelativeDecreaseofLoad" Then row.Add(dc.ColumnName.Trim(), dr(dc).ToString.Replace(",", "."))
                    If dc.ColumnName.Trim() = "MinTimeUpperlevel" Then row.Add(dc.ColumnName.Trim(), dr(dc).ToString.Replace(",", "."))
                    If dc.ColumnName.Trim() = "TimeLowerlevel" Then row.Add(dc.ColumnName.Trim(), dr(dc).ToString.Replace(",", "."))
                    If dc.ColumnName.Trim() = "AlarmLimit" Then row.Add(dc.ColumnName.Trim(), dr(dc).ToString.Replace(",", "."))
                    If dc.ColumnName.Trim() = "LoadLimit" Then row.Add(dc.ColumnName.Trim(), dr(dc).ToString.Replace(",", "."))
                    If dc.ColumnName.Trim() = "NIBPDuration" Then row.Add(dc.ColumnName.Trim(), dr(dc).ToString.Replace(",", "."))
                    If dc.ColumnName.Trim() = "Warmup1Time" Then row.Add(dc.ColumnName.Trim(), dr(dc).ToString.Replace(",", "."))
                    If dc.ColumnName.Trim() = "RestingPulse" Then row.Add(dc.ColumnName.Trim(), dr(dc).ToString.Replace(",", "."))
                    If dc.ColumnName.Trim() = "RestingBloodPressure" Then row.Add(dc.ColumnName.Trim(), dr(dc).ToString.Replace(",", "."))
                    If dc.ColumnName.Trim() = "Warmup2Time" Then row.Add(dc.ColumnName.Trim(), dr(dc).ToString.Replace(",", "."))
                    If dc.ColumnName.Trim() = "TrainingTime" Then row.Add(dc.ColumnName.Trim(), dr(dc).ToString.Replace(",", "."))
                    If dc.ColumnName.Trim() = "StressPulse" Then row.Add(dc.ColumnName.Trim(), dr(dc).ToString.Replace(",", "."))
                    If dc.ColumnName.Trim() = "StressAvgPulse" Then row.Add(dc.ColumnName.Trim(), dr(dc).ToString.Replace(",", "."))
                    If dc.ColumnName.Trim() = "StressBloodPressure" Then row.Add(dc.ColumnName.Trim(), dr(dc).ToString.Replace(",", "."))
                    If dc.ColumnName.Trim() = "Recovery1Time" Then row.Add(dc.ColumnName.Trim(), dr(dc).ToString.Replace(",", "."))
                    If dc.ColumnName.Trim() = "RecoveryPulse" Then row.Add(dc.ColumnName.Trim(), dr(dc).ToString.Replace(",", "."))
                    If dc.ColumnName.Trim() = "RecoveryBloodPressure" Then row.Add(dc.ColumnName.Trim(), dr(dc).ToString.Replace(",", "."))
                    If dc.ColumnName.Trim() = "Recovery2Time" Then row.Add(dc.ColumnName.Trim(), dr(dc).ToString.Replace(",", "."))
                    If dc.ColumnName.Trim() = "LoadValues" Then row.Add(dc.ColumnName.Trim(), dr(dc).ToString.Replace(",", "."))
                    If dc.ColumnName.Trim() = "ImpBegin" Then row.Add(dc.ColumnName.Trim(), dr(dc).ToString.Replace(",", "."))
                    If dc.ColumnName.Trim() = "ImpEnd" Then row.Add(dc.ColumnName.Trim(), dr(dc).ToString.Replace(",", "."))
                    If dc.ColumnName.Trim() = "Maximum" Then row.Add(dc.ColumnName.Trim(), dr(dc).ToString.Replace(",", "."))
                    If dc.ColumnName.Trim() = "Minimum" Then row.Add(dc.ColumnName.Trim(), dr(dc).ToString.Replace(",", "."))
                    If dc.ColumnName.Trim() = "Joule" Then row.Add(dc.ColumnName.Trim(), dr(dc).ToString.Replace(",", "."))
                    If dc.ColumnName.Trim() = "AverageLoad" Then row.Add(dc.ColumnName.Trim(), dr(dc).ToString.Replace(",", "."))
                    If dc.ColumnName.Trim() = "JouleBeats" Then row.Add(dc.ColumnName.Trim(), dr(dc).ToString.Replace(",", "."))
                    If dc.ColumnName.Trim() = "VO2Max" Then row.Add(dc.ColumnName.Trim(), dr(dc).ToString.Replace(",", "."))
                    If dc.ColumnName.Trim() = "Borgscale" Then row.Add(dc.ColumnName.Trim(), dr(dc).ToString.Replace(",", "."))
                Next
                rows.Add(row)
            Next
            Return serializer.Serialize(rows)
        End Function
        Public Function GetJson(ByVal dt As DataTable) As String
            Dim serializer As New System.Web.Script.Serialization.JavaScriptSerializer()
            Dim rows As New List(Of Dictionary(Of String, Object))()
            Dim row As Dictionary(Of String, Object) = Nothing
            For Each dr As DataRow In dt.Rows
                row = New Dictionary(Of String, Object)()
                For Each dc As DataColumn In dt.Columns
                    If dc.ColumnName.Trim() = "F1" Then
                        row.Add(dc.ColumnName.Trim(), dr(dc))
                    End If
                    If dc.ColumnName.Trim() = "F2" Then
                        row.Add(dc.ColumnName.Trim(), dr(dc).ToString.Replace(",", "."))
                    End If
                    If dc.ColumnName.Trim() = "F3" Then
                        row.Add(dc.ColumnName.Trim(), dr(dc).ToString.Replace(",", "."))
                    End If
                    If dc.ColumnName.Trim() = "F4" Then
                        row.Add(dc.ColumnName.Trim(), dr(dc).ToString.Replace(",", "."))
                    End If
                    If dc.ColumnName.Trim() = "F5" Then
                        row.Add(dc.ColumnName.Trim(), dr(dc).ToString.Replace(",", "."))
                    End If
                    If dc.ColumnName.Trim() = "F6" Then
                        row.Add(dc.ColumnName.Trim(), dr(dc).ToString.Replace(",", "."))
                    End If
                    If dc.ColumnName.Trim() = "F7" Then
                        row.Add(dc.ColumnName.Trim(), dr(dc).ToString.Replace(",", "."))
                    End If
                    If dc.ColumnName.Trim() = "F8" Then
                        row.Add(dc.ColumnName.Trim(), dr(dc).ToString.Replace(",", "."))
                    End If
                    If dc.ColumnName.Trim() = "F9" Then
                        row.Add(dc.ColumnName.Trim(), dr(dc).ToString.Replace(",", "."))
                    End If
                    If dc.ColumnName.Trim() = "F10" Then
                        row.Add(dc.ColumnName.Trim(), dr(dc).ToString.Replace(",", "."))
                    End If
                    If dc.ColumnName.Trim() = "F11" Then
                        row.Add(dc.ColumnName.Trim(), dr(dc).ToString.Replace(",", "."))
                    End If
                    If dc.ColumnName.Trim() = "F12" Then
                        row.Add(dc.ColumnName.Trim(), dr(dc).ToString.Replace(",", "."))
                    End If
                    If dc.ColumnName.Trim() = "F13" Then
                        row.Add(dc.ColumnName.Trim(), dr(dc).ToString.Replace(",", "."))
                    End If
                    If dc.ColumnName.Trim() = "F14" Then
                        row.Add(dc.ColumnName.Trim(), dr(dc).ToString.Replace(",", "."))
                    End If
                    If dc.ColumnName.Trim() = "F15" Then
                        row.Add(dc.ColumnName.Trim(), dr(dc).ToString.Replace(",", "."))
                    End If
                    If dc.ColumnName.Trim() = "F16" Then
                        row.Add(dc.ColumnName.Trim(), dr(dc).ToString.Replace(",", "."))
                    End If
                    If dc.ColumnName.Trim() = "F17" Then
                        row.Add(dc.ColumnName.Trim(), dr(dc).ToString.Replace(",", "."))
                    End If
                    If dc.ColumnName.Trim() = "F18" Then
                        row.Add(dc.ColumnName.Trim(), dr(dc).ToString.Replace(",", "."))
                    End If
                    If dc.ColumnName.Trim() = "F19" Then
                        row.Add(dc.ColumnName.Trim(), dr(dc).ToString.Replace(",", "."))
                    End If
                    If dc.ColumnName.Trim() = "F20" Then
                        row.Add(dc.ColumnName.Trim(), dr(dc).ToString.Replace(",", "."))
                    End If
                    If dc.ColumnName.Trim() = "F21" Then
                        row.Add(dc.ColumnName.Trim(), dr(dc).ToString.Replace(",", "."))
                    End If
                    If dc.ColumnName.Trim() = "F22" Then
                        row.Add(dc.ColumnName.Trim(), dr(dc).ToString.Replace(",", "."))
                    End If
                    If dc.ColumnName.Trim() = "F23" Then
                        row.Add(dc.ColumnName.Trim(), dr(dc).ToString.Replace(",", "."))
                    End If
                    If dc.ColumnName.Trim() = "F24" Then
                        row.Add(dc.ColumnName.Trim(), dr(dc).ToString.Replace(",", "."))
                    End If
                    If dc.ColumnName.Trim() = "F25" Then
                        row.Add(dc.ColumnName.Trim(), dr(dc).ToString.Replace(",", "."))
                    End If
                    If dc.ColumnName.Trim() = "F26" Then
                        row.Add(dc.ColumnName.Trim(), dr(dc).ToString.Replace(",", "."))
                    End If
                    If dc.ColumnName.Trim() = "F27" Then
                        row.Add(dc.ColumnName.Trim(), dr(dc).ToString.Replace(",", "."))
                    End If
                    If dc.ColumnName.Trim() = "F28" Then
                        row.Add(dc.ColumnName.Trim(), dr(dc).ToString.Replace(",", "."))
                    End If
                    If dc.ColumnName.Trim() = "F29" Then
                        row.Add(dc.ColumnName.Trim(), dr(dc).ToString.Replace(",", "."))
                    End If
                    If dc.ColumnName.Trim() = "F30" Then
                        row.Add(dc.ColumnName.Trim(), dr(dc).ToString.Replace(",", "."))
                    End If
                    If dc.ColumnName.Trim() = "F31" Then
                        row.Add(dc.ColumnName.Trim(), dr(dc).ToString.Replace(",", "."))
                    End If
                    If dc.ColumnName.Trim() = "F32" Then
                        row.Add(dc.ColumnName.Trim(), dr(dc).ToString.Replace(",", "."))
                    End If
                    If dc.ColumnName.Trim() = "F33" Then
                        row.Add(dc.ColumnName.Trim(), dr(dc).ToString.Replace(",", "."))
                    End If
                    If dc.ColumnName.Trim() = "F34" Then
                        row.Add(dc.ColumnName.Trim(), dr(dc).ToString.Replace(",", "."))
                    End If
                    If dc.ColumnName.Trim() = "F35" Then
                        row.Add(dc.ColumnName.Trim(), dr(dc).ToString.Replace(",", "."))
                    End If
                    If dc.ColumnName.Trim() = "F36" Then
                        row.Add(dc.ColumnName.Trim(), dr(dc).ToString.Replace(",", "."))
                    End If
                    If dc.ColumnName.Trim() = "F37" Then
                        row.Add(dc.ColumnName.Trim(), dr(dc).ToString.Replace(",", "."))
                    End If
                    If dc.ColumnName.Trim() = "F38" Then
                        row.Add(dc.ColumnName.Trim(), dr(dc).ToString.Replace(",", "."))
                    End If
                    If dc.ColumnName.Trim() = "F39" Then
                        row.Add(dc.ColumnName.Trim(), dr(dc).ToString.Replace(",", "."))
                    End If
                    If dc.ColumnName.Trim() = "F40" Then
                        row.Add(dc.ColumnName.Trim(), dr(dc).ToString.Replace(",", "."))
                    End If
                    If dc.ColumnName.Trim() = "F41" Then
                        row.Add(dc.ColumnName.Trim(), dr(dc).ToString.Replace(",", "."))
                    End If
                    If dc.ColumnName.Trim() = "F42" Then
                        row.Add(dc.ColumnName.Trim(), dr(dc).ToString.Replace(",", "."))
                    End If
                    If dc.ColumnName.Trim() = "F43" Then
                        row.Add(dc.ColumnName.Trim(), dr(dc).ToString.Replace(",", "."))
                    End If
                    If dc.ColumnName.Trim() = "F44" Then
                        row.Add(dc.ColumnName.Trim(), dr(dc).ToString.Replace(",", "."))
                    End If
                    If dc.ColumnName.Trim() = "F45" Then
                        row.Add(dc.ColumnName.Trim(), dr(dc).ToString.Replace(",", "."))
                    End If
                    If dc.ColumnName.Trim() = "F46" Then
                        row.Add(dc.ColumnName.Trim(), dr(dc).ToString.Replace(",", "."))
                    End If
                Next
                rows.Add(row)
            Next
            Return serializer.Serialize(rows)
        End Function
        'Public Function EliminarExamen(Id As Integer) As Boolean
        '    Try
        '        Dim conn As OleDbConnection = New OleDbConnection(ConfigurationManager.ConnectionStrings("ConexionKaplan").ConnectionString)
        '        Dim cmd As OleDbCommand = New OleDbCommand("Kaplan.Kaplan.EliminarExamen", conn)
        '        cmd.CommandType = CommandType.StoredProcedure

        '        Dim inId As OleDbParameter = cmd.Parameters.Add("@inId", OleDbType.Decimal, Nothing)
        '        inId.Direction = ParameterDirection.Input
        '        inId.Value = Id

        '        Dim outError As OleDbParameter = cmd.Parameters.Add("@outError", OleDbType.Integer)
        '        outError.Direction = ParameterDirection.Output

        '        conn.Open()
        '        cmd.ExecuteReader()
        '        conn.Close()

        '        Return CInt(cmd.Parameters("@outError").Value)
        '    Catch exc As Exception
        '        Return Nothing
        '    End Try
        'End Function
    End Class
End Namespace


