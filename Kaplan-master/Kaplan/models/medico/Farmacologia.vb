Imports Newtonsoft.Json
Namespace Clases
    Public Class CollectionssBetabloqueador
        Public Property column As Betabloqueador()
    End Class
    Public Class CollectionssBloqueadorCorrientes
        Public Property column As BloqueadorCorrientes()
    End Class
    Public Class CollectionssIECA
        Public Property column As IECA()
    End Class
    Public Class CollectionssARA2
        Public Property column As ARA2()
    End Class
    Public Class CollectionssNitratos
        Public Property column As Nitratos()
    End Class
    Public Class CollectionssAnticoagulanteOral
        Public Property column As AnticoagulanteOral()
    End Class
    Public Class CollectionssEstatina
        Public Property column As Estatina()
    End Class
    Public Class CollectionssAntiplaquetario
        Public Property column As Antiplaquetario()
    End Class
    Public Class CollectionssHipoglicemiante
        Public Property column As Hipoglicemiante()
    End Class
    Public Class CollectionssEsteroides
        Public Property column As Esteroides()
    End Class
    Public Class CollectionssDiuretico
        Public Property column As Diuretico()
    End Class
    Public Class CollectionssAlopurinol
        Public Property column As Alopurinol()
    End Class
    Public Class CollectionssDigitalicos
        Public Property column As Digitalicos()
    End Class
    Public Class CollectionssAntiarritmicos
        Public Property column As Antiarritmicos()
    End Class
    Public Class CollectionssOtros
        Public Property column As Otros()
    End Class
    Public Class Farmacologia
        Public Property Id As Integer
        Public Property Betabloqueador As Tipos.TipoRespuestaMedico
        Public Property ListBetabloqueador As List(Of Betabloqueador)
        Public Property BloqueadorCorrientes As Tipos.TipoRespuestaMedico
        Public Property ListBloqueadorCorrientes As List(Of BloqueadorCorrientes)
        Public Property IECA As Tipos.TipoRespuestaMedico
        Public Property ListIECA As List(Of IECA)
        Public Property ARA2 As Tipos.TipoRespuestaMedico
        Public Property ListARA2 As List(Of ARA2)
        Public Property Nitratos As Tipos.TipoRespuestaMedico
        Public Property ListNitratos As List(Of Nitratos)
        Public Property AnticoagulanteOral As Tipos.TipoRespuestaMedico
        Public Property ListAnticoagulanteOral As List(Of AnticoagulanteOral)
        Public Property Estatina As Tipos.TipoRespuestaMedico
        Public Property ListEstatina As List(Of Estatina)
        Public Property Antiplaquetario As Tipos.TipoRespuestaMedico
        Public Property ListAntiplaquetario As List(Of Antiplaquetario)
        Public Property Hipoglicemiante As Tipos.TipoRespuestaMedico
        Public Property ListHipoglicemiante As List(Of Hipoglicemiante)
        Public Property Esteroides As Tipos.TipoRespuestaMedico
        Public Property ListEsteroides As List(Of Esteroides)
        Public Property Diuretico As Tipos.TipoRespuestaMedico
        Public Property ListDiuretico As List(Of Diuretico)
        Public Property Alopurinol As Tipos.TipoRespuestaMedico
        Public Property ListAlopurinol As List(Of Alopurinol)
        Public Property Digitalicos As Tipos.TipoRespuestaMedico
        Public Property ListDigitalicos As List(Of Digitalicos)
        Public Property Antiarritmicos As Tipos.TipoRespuestaMedico
        Public Property ListAntiarritmicos As List(Of Antiarritmicos)
        Public Property Otros As Tipos.TipoRespuestaMedico
        Public Property ListOtros As List(Of Otros)
        Public Shared Function MapeoFarmacologia(prmDatos As DataTable) As Farmacologia
            Try
                Dim vFarmacologia As New Farmacologia

                Dim prmRow As DataRow = prmDatos.Rows(0)

                vFarmacologia.Id = prmRow("id_farmacologia").ToString
                vFarmacologia.Alopurinol = Tipos.TipoRespuestaMedico.getTipo(prmRow("Alopurinol"))
                vFarmacologia.ARA2 = Tipos.TipoRespuestaMedico.getTipo(prmRow("Antagonista"))
                vFarmacologia.Antiarritmicos = Tipos.TipoRespuestaMedico.getTipo(prmRow("Antiarritmicos"))
                vFarmacologia.Antiplaquetario = Tipos.TipoRespuestaMedico.getTipo(prmRow("Antiplaquetario"))
                vFarmacologia.Betabloqueador = Tipos.TipoRespuestaMedico.getTipo(prmRow("Betabloqueador"))
                vFarmacologia.BloqueadorCorrientes = Tipos.TipoRespuestaMedico.getTipo(prmRow("bloqueadorCorr"))
                vFarmacologia.Digitalicos = Tipos.TipoRespuestaMedico.getTipo(prmRow("Digitalicos"))
                vFarmacologia.Diuretico = Tipos.TipoRespuestaMedico.getTipo(prmRow("Diuretico"))
                vFarmacologia.Estatina = Tipos.TipoRespuestaMedico.getTipo(prmRow("Estatina"))
                vFarmacologia.Esteroides = Tipos.TipoRespuestaMedico.getTipo(prmRow("Esteroides"))
                vFarmacologia.Hipoglicemiante = Tipos.TipoRespuestaMedico.getTipo(prmRow("Hipoglicemiante"))
                vFarmacologia.IECA = Tipos.TipoRespuestaMedico.getTipo(prmRow("IECA"))
                vFarmacologia.Nitratos = Tipos.TipoRespuestaMedico.getTipo(prmRow("Nitrato"))
                vFarmacologia.Otros = Tipos.TipoRespuestaMedico.getTipo(prmRow("Otros"))
                vFarmacologia.AnticoagulanteOral = Tipos.TipoRespuestaMedico.getTipo(prmRow("AnticoagulanteOral"))

                Return vFarmacologia
            Catch ex As Exception
                Return Nothing
            End Try

        End Function

        Public Function ToJSONBetabloqueador(rows As List(Of Betabloqueador)) As String
            Dim data As New CollectionssBetabloqueador

            data = New CollectionssBetabloqueador With {.column = rows.ToArray}
            ToJSONBetabloqueador = JsonConvert.SerializeObject(data)
            Return ToJSONBetabloqueador
        End Function
        Public Function ToJSONBloqueadorCorrientes(rows As List(Of BloqueadorCorrientes)) As String
            Dim data As New CollectionssBloqueadorCorrientes

            data = New CollectionssBloqueadorCorrientes With {.column = rows.ToArray}
            ToJSONBloqueadorCorrientes = JsonConvert.SerializeObject(data)
            Return ToJSONBloqueadorCorrientes
        End Function
        Public Function ToJSONIECA(rows As List(Of IECA)) As String
            Dim data As New CollectionssIECA

            data = New CollectionssIECA With {.column = rows.ToArray}
            ToJSONIECA = JsonConvert.SerializeObject(data)
            Return ToJSONIECA
        End Function
        Public Function ToJSONARA2(rows As List(Of ARA2)) As String
            Dim data As New CollectionssARA2

            data = New CollectionssARA2 With {.column = rows.ToArray}
            ToJSONARA2 = JsonConvert.SerializeObject(data)
            Return ToJSONARA2
        End Function
        Public Function ToJSONNitratos(rows As List(Of Nitratos)) As String
            Dim data As New CollectionssNitratos

            data = New CollectionssNitratos With {.column = rows.ToArray}
            ToJSONNitratos = JsonConvert.SerializeObject(data)
            Return ToJSONNitratos
        End Function
        Public Function ToJSONAnticoagulanteOral(rows As List(Of AnticoagulanteOral)) As String
            Dim data As New CollectionssAnticoagulanteOral

            data = New CollectionssAnticoagulanteOral With {.column = rows.ToArray}
            ToJSONAnticoagulanteOral = JsonConvert.SerializeObject(data)
            Return ToJSONAnticoagulanteOral
        End Function
        Public Function ToJSONEstatina(rows As List(Of Estatina)) As String
            Dim data As New CollectionssEstatina

            data = New CollectionssEstatina With {.column = rows.ToArray}
            ToJSONEstatina = JsonConvert.SerializeObject(data)
            Return ToJSONEstatina
        End Function
        Public Function ToJSONAntiplaquetario(rows As List(Of Antiplaquetario)) As String
            Dim data As New CollectionssAntiplaquetario

            data = New CollectionssAntiplaquetario With {.column = rows.ToArray}
            ToJSONAntiplaquetario = JsonConvert.SerializeObject(data)
            Return ToJSONAntiplaquetario
        End Function
        Public Function ToJSONHipoglicemiante(rows As List(Of Hipoglicemiante)) As String
            Dim data As New CollectionssHipoglicemiante

            data = New CollectionssHipoglicemiante With {.column = rows.ToArray}
            ToJSONHipoglicemiante = JsonConvert.SerializeObject(data)
            Return ToJSONHipoglicemiante
        End Function
        Public Function ToJSONEsteroides(rows As List(Of Esteroides)) As String
            Dim data As New CollectionssEsteroides

            data = New CollectionssEsteroides With {.column = rows.ToArray}
            ToJSONEsteroides = JsonConvert.SerializeObject(data)
            Return ToJSONEsteroides
        End Function
        Public Function ToJSONDiuretico(rows As List(Of Diuretico)) As String
            Dim data As New CollectionssDiuretico

            data = New CollectionssDiuretico With {.column = rows.ToArray}
            ToJSONDiuretico = JsonConvert.SerializeObject(data)
            Return ToJSONDiuretico
        End Function
        Public Function ToJSONAlopurinol(rows As List(Of Alopurinol)) As String
            Dim data As New CollectionssAlopurinol

            data = New CollectionssAlopurinol With {.column = rows.ToArray}
            ToJSONAlopurinol = JsonConvert.SerializeObject(data)
            Return ToJSONAlopurinol
        End Function
        Public Function ToJSONDigitalicos(rows As List(Of Digitalicos)) As String
            Dim data As New CollectionssDigitalicos

            data = New CollectionssDigitalicos With {.column = rows.ToArray}
            ToJSONDigitalicos = JsonConvert.SerializeObject(data)
            Return ToJSONDigitalicos
        End Function
        Public Function ToJSONAntiarritmicos(rows As List(Of Antiarritmicos)) As String
            Dim data As New CollectionssAntiarritmicos

            data = New CollectionssAntiarritmicos With {.column = rows.ToArray}
            ToJSONAntiarritmicos = JsonConvert.SerializeObject(data)
            Return ToJSONAntiarritmicos
        End Function
        Public Function ToJSONOtros(rows As List(Of Otros)) As String
            Dim data As New CollectionssOtros

            data = New CollectionssOtros With {.column = rows.ToArray}
            ToJSONOtros = JsonConvert.SerializeObject(data)
            Return ToJSONOtros
        End Function
    End Class
End Namespace
