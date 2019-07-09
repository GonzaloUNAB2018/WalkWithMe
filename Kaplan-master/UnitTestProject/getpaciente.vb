Imports System.Text
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports OpenQA.Selenium
Imports System.ComponentModel
Imports Kaplan.Clases
Imports Kaplan.Tipos

<TestClass()>
Public Class getpaciente
    <TestMethod()>
    Public Sub TestMethod1()
        Dim result_esperado As List(Of Kaplan.Clases.Plan)
        Dim result 'As List(Of Kaplan.Clases.Plan)
        result = Kaplan.Clases.Plan.getPlanesxRut(0)
        Assert.AreEqual(result_esperado, result)

    End Sub

End Class