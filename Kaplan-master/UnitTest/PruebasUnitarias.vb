Imports System.Text
Imports Microsoft.VisualStudio.TestTools.UnitTesting

<TestClass()> Public Class PruebasUnitarias

    <TestMethod()> Public Sub PruebaValidarRut()
        Dim Rut = 17888566
        Dim resultado As New Kaplan.Clases.Paciente
        resultado = Kaplan.Clases.Paciente.getPaciente(Rut, DBNull.Value.ToString, False)
        Assert.AreEqual(False, Not IsNothing(resultado))

    End Sub

    <TestMethod()> Public Sub PruebaPlanxRut()
        Dim Rut = 17888566
        Dim resultado As New List(Of Kaplan.Clases.Plan)
        resultado = Kaplan.Clases.Plan.getPlanesxRut(Rut)
        Assert.AreEqual(False, Not IsNothing(resultado))

    End Sub

    <TestMethod()> Public Sub PruebaReservasxPlan()
        Dim idPlan = 10
        Dim resultado As New List(Of Kaplan.Clases.Sesion)
        resultado = Kaplan.Clases.Sesion.getSesionxPlan(idPlan, 2)
        Assert.AreEqual(False, Not IsNothing(resultado))

    End Sub

    <TestMethod()> Public Sub PruebagetFichaKinesiologia()
        Dim idReserva = 66
        Dim resultado As New Kaplan.Clases.Ficha
        resultado = Kaplan.Clases.Ficha.getFichaKinesiologia(idReserva, False)
        Assert.AreEqual(False, Not IsNothing(resultado))

    End Sub

End Class