Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports Kaplan.Clases

<TestClass()> Public Class getplan

    <TestMethod()> Public Sub Test()
        Dim intRut = 17808695
        Dim result As List(Of Plan) = Plan.getPlanesxRut(intRut)
        Assert.AreEqual(True, Not IsNothing(result))
    End Sub

End Class