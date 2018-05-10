Public Class Vin
    Public id As Integer
    Public appellation As String
    Public annee As Integer
    Public type As String
    Public cepage As String
    Public alcool As Integer
    Public prix As Integer
    Public score As Integer
    Public description As String
    Public avis As String
    Public photo As String
    Public exposant As Exposant

    ''Constructeur par défaut
    Sub New()
        id = 0
        appellation = "null"
        annee = 0
        type = 0
        cepage = "null"
        alcool = Nothing
        prix = 0
        score = 0
        description = "null"
        avis = "null"
        photo = "null"
        exposant = New Exposant
    End Sub

    Public Function toArrayString()
        Dim result As String() = {id.ToString(), appellation, annee, type, cepage, alcool, prix, score, description, avis, photo}

        Return result

    End Function

    Public Function toDic()
        Dim result = New Dictionary(Of String, String) From {{"id", id.ToString()}, {"appellation", appellation}, {"annee", annee.ToString()}, {"type", type}, {"cepage", cepage}, {"alcool", alcool.ToString}, {"prix", prix.ToString}, {"score", score.ToString}, {"description", description}, {"avis", avis}, {"photo", photo}, {"exposant", exposant.ToString}}
        Return result
    End Function
End Class
