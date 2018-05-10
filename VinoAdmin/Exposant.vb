Public Class Exposant
    Public id As Integer
    Public emplacement As String
    Public nom As String
    Public prenom As String
    Public email As String
    Public password As String
    Public domaine As String
    Public description As String
    Public adresse As String
    Public cp As String
    Public ville As String
    Public region As String
    Public siteweb As String
    Public photo As String

    ''Constructeur par défaut
    Sub New()
        id = 0
        emplacement = "null"
        nom = "null"
        prenom = "null"
        password = "null"
        email = "null"
        domaine = "null"
        description = "null"
        adresse = "null"
        cp = "null"
        ville = "null"
        region = "null"
        siteweb = "null"
        photo = "null"
    End Sub

    Public Function toArrayString()
        Dim result As String() = {id.ToString(), emplacement, nom, prenom, email, password, domaine, description, adresse, cp, ville, region, siteweb, photo}
        Return result
    End Function

    Public Function toDic()
        Dim result = New Dictionary(Of String, String) From {{"id", id.ToString()}, {"emplacement", emplacement.ToString}, {"nom", nom.ToString}, {"prenom", prenom.ToString}, {"email", email.ToString}, {"password", password.ToString}, {"domaine", domaine.ToString}, {"description", description.ToString}, {"adresse", adresse.ToString}, {"cp", cp}, {"ville", ville.ToString}, {"region", region.ToString}, {"siteweb", siteweb.ToArray}, {"photo", photo.ToString}}
        Return result
    End Function

End Class
