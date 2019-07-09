Imports Kaplan.Clases
Imports System.Globalization
Imports System.Data.OleDb
Imports System.Data.SqlClient

Namespace Clases
    Public Class Paciente
        Public Property Id As Integer
        Public Property Estado As Integer
        Public Property Persona As Persona
        Public Property IdFicha As Integer

        Public Shared Function getPaciente(inRut As Integer, strPasaporte As String, ByRef NoData As Boolean) As Paciente

            Try
                Dim conn As OleDbConnection = New OleDbConnection(ConfigurationManager.ConnectionStrings("ConexionKaplan").ConnectionString)
                Dim cmd As OleDbCommand = New OleDbCommand("Kaplan.BuscarPersona", conn)
                cmd.CommandType = CommandType.StoredProcedure

                Dim Rut As OleDbParameter = cmd.Parameters.Add("@inRut", OleDbType.Decimal, Nothing)
                Rut.Direction = ParameterDirection.Input
                Rut.Value = inRut

                Dim Pasaporte As OleDbParameter = cmd.Parameters.Add("@inPasaporte", OleDbType.VarChar, 100)
                Pasaporte.Direction = ParameterDirection.Input
                Pasaporte.Value = strPasaporte

                Dim adapter As OleDbDataAdapter = New OleDbDataAdapter(cmd)
                Dim vDataSet As New DataSet
                adapter.Fill(vDataSet)
                If Not vDataSet.Tables(0).Rows.Count.Equals(0) Then
                    If Not vDataSet.Tables(0).Rows(0)("ID_PAC").Equals(DBNull.Value) Then
                        getPaciente = Mapeo(vDataSet)
                    End If
                End If

                If vDataSet.Tables(0).Rows.Count = 0 OrElse vDataSet.Tables(0).Rows(0)("ID_PAC").Equals(DBNull.Value) Then NoData = True

                Return getPaciente
            Catch exc As Exception
                Return Nothing
            End Try
        End Function
        Private Shared Function Mapeo(prmDatos As DataSet) As Paciente
            Try
                Dim vPaciente As New Paciente
                Dim prmRow As DataRow = prmDatos.Tables(0).Rows(0)

                vPaciente.Persona = New Persona
                vPaciente.Id = prmRow("id_PAC").ToString
                vPaciente.Estado = prmRow("estado_paciente").ToString
                vPaciente.Persona.Id = prmRow("id").ToString
                vPaciente.Persona.Rut = prmRow("rut").ToString
                vPaciente.Persona.Dv = prmRow("dv").ToString
                vPaciente.Persona.Nombre = prmRow("nombres").ToString
                vPaciente.Persona.Paterno = prmRow("paterno").ToString
                vPaciente.Persona.Materno = prmRow("materno").ToString
                vPaciente.Persona.FechaNac = prmRow("fecha_nac").ToString
                vPaciente.Persona.Comuna = Tipos.TipoComuna.getTipo(prmRow("comuna"))
                vPaciente.Persona.Region = Tipos.TipoRegion.getTipo(prmRow("region"))
                vPaciente.Persona.Direccion = prmRow("direccion").ToString
                vPaciente.Persona.Telefono = prmRow("telefono").ToString
                vPaciente.Persona.Movil = prmRow("movil").ToString
                vPaciente.Persona.SituacionLaboral = prmRow("situacion_laboral").ToString
                vPaciente.IdFicha = prmRow("id_ficha").ToString

                Return vPaciente
            Catch ex As Exception
                Return Nothing
            End Try

        End Function
        Public Function ModificarPaciente() As Boolean
            Dim conn As OleDbConnection = New OleDbConnection(ConfigurationManager.ConnectionStrings("ConexionKaplan").ConnectionString)
            Dim cmd As OleDbCommand = New OleDbCommand("Kaplan.ModificarPacienteFicha", conn)
            cmd.CommandType = CommandType.StoredProcedure

            Dim inId As OleDbParameter = cmd.Parameters.Add("@inIdPersona", OleDbType.Decimal, Nothing)
            inId.Direction = ParameterDirection.Input
            inId.Value = Me.Persona.Id

            Dim inNombre As OleDbParameter = cmd.Parameters.Add("@inNombre", OleDbType.VarChar, 250)
            inNombre.Direction = ParameterDirection.Input
            inNombre.Value = Me.Persona.Nombre

            Dim inPaterno As OleDbParameter = cmd.Parameters.Add("@inPaterno", OleDbType.VarChar, 200)
            inPaterno.Direction = ParameterDirection.Input
            inPaterno.Value = Me.Persona.Paterno

            Dim inMaterno As OleDbParameter = cmd.Parameters.Add("@inMaterno", OleDbType.VarChar, 200)
            inMaterno.Direction = ParameterDirection.Input
            inMaterno.Value = Me.Persona.Materno

            Dim inFechNac As OleDbParameter = cmd.Parameters.Add("@inFechNac", OleDbType.Date, Nothing)
            inFechNac.Direction = ParameterDirection.Input
            inFechNac.Value = Me.Persona.FechaNac

            Dim inRegion As OleDbParameter = cmd.Parameters.Add("@inRegion", OleDbType.Decimal, Nothing)
            inRegion.Direction = ParameterDirection.Input
            inRegion.Value = Me.Persona.Region.ID

            Dim inSituacionLaboral As OleDbParameter = cmd.Parameters.Add("@inSituacionLaboral", OleDbType.VarChar, 250)
            inSituacionLaboral.Direction = ParameterDirection.Input
            inSituacionLaboral.Value = Me.Persona.SituacionLaboral

            Dim inComuna As OleDbParameter = cmd.Parameters.Add("@inComuna", OleDbType.Decimal, Nothing)
            inComuna.Direction = ParameterDirection.Input
            inComuna.Value = Me.Persona.Comuna.ID

            Dim inDireccion As OleDbParameter = cmd.Parameters.Add("@inDireccion", OleDbType.VarChar, 250)
            inDireccion.Direction = ParameterDirection.Input
            inDireccion.Value = Me.Persona.Direccion

            Dim inTelefono As OleDbParameter = cmd.Parameters.Add("@inTelefono", OleDbType.Decimal, Nothing)
            inTelefono.Direction = ParameterDirection.Input
            inTelefono.Value = Me.Persona.Telefono

            Dim inMovil As OleDbParameter = cmd.Parameters.Add("@inMovil", OleDbType.Decimal, Nothing)
            inMovil.Direction = ParameterDirection.Input
            inMovil.Value = Me.Persona.Movil

            Dim outError As OleDbParameter = cmd.Parameters.Add("@outError", OleDbType.Integer)
            outError.Direction = ParameterDirection.Output

            conn.Open()
            cmd.ExecuteReader()
            conn.Close()

            Return CInt(cmd.Parameters("@outError").Value)
        End Function
    End Class
End Namespace