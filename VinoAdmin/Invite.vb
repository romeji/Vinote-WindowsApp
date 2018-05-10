Public Class Invite
    Public id As Integer
    Public nom As String
    Public prenom As String
    Public email As String
    Public password As String
    Public photo As String

    ''Constructeur par défaut
    Sub New()
        id = 0
        nom = "null"
        prenom = "null"
        email = "null"
        password = "null"
        photo = "null"
    End Sub

    Public Function toArrayString()
        Dim result As String() = {id.ToString(), nom, prenom, email, password, photo}
        Return result
    End Function

    Public Function toDic()
        Dim result = New Dictionary(Of String, String) From {{"id", id.ToString()}, {"nom", nom.ToString}, {"prenom", prenom.ToString()}, {"email", email.ToString}, {"password", password.ToString}, {"photo", photo.ToString}}
        Return result
    End Function

End Class
