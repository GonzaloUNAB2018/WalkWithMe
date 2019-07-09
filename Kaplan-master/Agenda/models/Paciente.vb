Imports Agenda.Clases
Imports System.Globalization
Imports System.Data.OleDb
Imports System.Data.SqlClient

Namespace Clases
    Public Class Paciente
        Public Property Id As Integer
        Public Property Estado As Integer
        Public Property Persona As Persona
        Public Property Licencias As List(Of Licencia)
        Public Property Reservas As List(Of Reserva)
        Public Property Planes As List(Of Plan)

        Public Shared Function getPaciente(inRut As Integer, strPasaporte As String, ByRef NoData As Boolean) As Paciente
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
        End Function

        Public Shared Function getPacienteReserva(inRut As Integer, strPasaporte As String, ByRef NoData As Boolean) As Paciente
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
                getPacienteReserva = MapeoPersona(vDataSet)
            End If

            If vDataSet.Tables(0).Rows.Count = 0 Then NoData = True

            Return getPacienteReserva
        End Function

        Public Shared Function getPacienteId(inId As Integer) As Paciente
            Dim conn As OleDbConnection = New OleDbConnection(ConfigurationManager.ConnectionStrings("ConexionKaplan").ConnectionString)
            Dim cmd As OleDbCommand = New OleDbCommand("Kaplan.BuscarPacienteId", conn)
            cmd.CommandType = CommandType.StoredProcedure

            Dim Rut As OleDbParameter = cmd.Parameters.Add("@inId", OleDbType.Decimal, Nothing)
            Rut.Direction = ParameterDirection.Input
            Rut.Value = inId

            Dim adapter As OleDbDataAdapter = New OleDbDataAdapter(cmd)
            Dim vDataSet As New DataSet
            adapter.Fill(vDataSet)

            If Not vDataSet.Tables(0).Rows.Count.Equals(0) Then
                getPacienteId = Mapeo(vDataSet)
            End If

            Return getPacienteId
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
                vPaciente.Persona.EstadoCivil = Tipos.TipoEstadoCivil.getTipo(prmRow("estadocivil"))
                vPaciente.Persona.Comuna = Tipos.TipoComuna.getTipo(prmRow("comuna"))
                vPaciente.Persona.Nacionalidad = Tipos.TipoPais.getTipo(prmRow("pais"))
                vPaciente.Persona.Region = Tipos.TipoRegion.getTipo(prmRow("region"))
                vPaciente.Persona.Prevision = Tipos.TipoPrevision.getTipo(prmRow("prevision"))
                vPaciente.Persona.Direccion = prmRow("direccion").ToString
                vPaciente.Persona.Telefono = prmRow("telefono").ToString
                vPaciente.Persona.Movil = prmRow("movil").ToString
                vPaciente.Persona.Sexo = Tipos.TipoSexo.getTipo(prmRow("sexo"))
                vPaciente.Persona.SituacionLaboral = prmRow("situacion_laboral").ToString
                vPaciente.Persona.Email = prmRow("email").ToString

                vPaciente.Licencias = Licencia.Mapeo(prmDatos.Tables(1))
                vPaciente.Reservas = Reserva.Mapeo(prmDatos.Tables(2))
                vPaciente.Planes = Plan.Mapeo(prmDatos.Tables(3))

                Return vPaciente
            Catch ex As Exception
                Return Nothing
            End Try

        End Function

        Private Shared Function MapeoPersona(prmDatos As DataSet) As Paciente
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
                vPaciente.Persona.EstadoCivil = Tipos.TipoEstadoCivil.getTipo(prmRow("estadocivil"))
                vPaciente.Persona.Comuna = Tipos.TipoComuna.getTipo(prmRow("comuna"))
                vPaciente.Persona.Nacionalidad = Tipos.TipoPais.getTipo(prmRow("pais"))
                vPaciente.Persona.Region = Tipos.TipoRegion.getTipo(prmRow("region"))
                vPaciente.Persona.Prevision = Tipos.TipoPrevision.getTipo(prmRow("prevision"))
                vPaciente.Persona.Direccion = prmRow("direccion").ToString
                vPaciente.Persona.Telefono = prmRow("telefono").ToString
                vPaciente.Persona.Movil = prmRow("movil").ToString
                vPaciente.Persona.Sexo = Tipos.TipoSexo.getTipo(prmRow("sexo"))
                vPaciente.Persona.SituacionLaboral = prmRow("situacion_laboral").ToString
                vPaciente.Persona.Email = prmRow("email").ToString

                Return vPaciente
            Catch ex As Exception
                Return Nothing
            End Try

        End Function
        Public Function registrarPaciente() As Boolean
            Dim conn As OleDbConnection = New OleDbConnection(ConfigurationManager.ConnectionStrings("ConexionKaplan").ConnectionString)
            Dim cmd As OleDbCommand = New OleDbCommand("Kaplan.RegistrarPaciente", conn)
            cmd.CommandType = CommandType.StoredProcedure

            Dim inId As OleDbParameter = cmd.Parameters.Add("@inIdPersona", OleDbType.Decimal, Nothing)
            inId.Direction = ParameterDirection.Input
            inId.Value = Me.Persona.Id

            Dim inRut As OleDbParameter = cmd.Parameters.Add("@inRut", OleDbType.Decimal, Nothing)
            inRut.Direction = ParameterDirection.Input
            inRut.Value = Me.Persona.Rut

            Dim inDv As OleDbParameter = cmd.Parameters.Add("@inDv", OleDbType.Char, 1)
            inDv.Direction = ParameterDirection.Input
            inDv.Value = Me.Persona.Dv

            Dim inPasaporte As OleDbParameter = cmd.Parameters.Add("@inPasaporte", OleDbType.VarChar, 50)
            inPasaporte.Direction = ParameterDirection.Input
            inPasaporte.Value = DBNull.Value.ToString

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

            Dim inSexo As OleDbParameter = cmd.Parameters.Add("@inSexo", OleDbType.Decimal, Nothing)
            inSexo.Direction = ParameterDirection.Input
            inSexo.Value = Me.Persona.Sexo.ID

            Dim inEstadoCivil As OleDbParameter = cmd.Parameters.Add("@inEstadoCivil", OleDbType.Decimal, Nothing)
            inEstadoCivil.Direction = ParameterDirection.Input
            inEstadoCivil.Value = Me.Persona.EstadoCivil.ID

            Dim inPais As OleDbParameter = cmd.Parameters.Add("@inPais", OleDbType.Decimal, Nothing)
            inPais.Direction = ParameterDirection.Input
            inPais.Value = Me.Persona.Nacionalidad.ID

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

            Dim inPrevision As OleDbParameter = cmd.Parameters.Add("@inPrevision", OleDbType.Decimal, Nothing)
            inPrevision.Direction = ParameterDirection.Input
            inPrevision.Value = Me.Persona.Prevision.ID

            Dim inEmail As OleDbParameter = cmd.Parameters.Add("@inEmail", OleDbType.VarChar, 100)
            inEmail.Direction = ParameterDirection.Input
            inEmail.Value = Me.Persona.Email

            Dim inEstado As OleDbParameter = cmd.Parameters.Add("@inEstado", OleDbType.Decimal, Nothing)
            inEstado.Direction = ParameterDirection.Input
            inEstado.Value = 1

            Dim outError As OleDbParameter = cmd.Parameters.Add("@outError", OleDbType.Integer)
            outError.Direction = ParameterDirection.Output

            conn.Open()
            cmd.ExecuteReader()
            conn.Close()

            Return CInt(cmd.Parameters("@outError").Value)
        End Function
    End Class
End Namespace