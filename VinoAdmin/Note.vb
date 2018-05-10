Public Class Note
    Public id As Integer
    Public timestamp As Integer
    Public commentaire As String
    Public note As String
    Public vin As Vin
    Public invite As Invite

    ''Constructeur par défaut
    Sub New()
        id = 0
        timestamp = 0
        commentaire = 0
        note = 0
        vin = New Vin
        invite = New Invite
    End Sub


    Public Function toArrayString()
        Dim result As String() = {id.ToString(), timestamp, note, commentaire}
        Return result
    End Function

    Public Function toDic()
        Dim result = New Dictionary(Of String, String) From {{"id", id.ToString()}, {"timestamp", timestamp}, {"commentaire", commentaire.ToString()}, {"note", note}, {"vin", vin.ToString}, {"invite", invite.ToString}}
        Return result
    End Function

End Class
