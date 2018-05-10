Imports System.Text

Public Class FormModifier

    Dim dicoData As Dictionary(Of String, String)
    Dim typeObjet As String
    Dim fenetreP As Form1

    ''Constructeur de la classe
    Public Sub init(dic As Dictionary(Of String, String), typeOb As String, fenP As Form1)
        dicoData = dic
        typeObjet = typeOb
        fenetreP = fenP
    End Sub

    ''Ferme le formulaire lors du clique sur le bouton Annuler 
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Bt_Annuler.Click
        Me.Close()
    End Sub

    ''Chargement du formulaire de modification,
    ' Creation des labels, des textbox, remplissage des textbox avec l'information correspondante
    ' Creation de bouton et paramètrage de leurs positionnements
    Private Sub FormModifier_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim x As Integer = 50
        Dim y As Integer = 30
        Dim x_tab As Integer = 200
        Dim y_tab As Integer = 50


        For Each kvp As KeyValuePair(Of String, String) In dicoData
            Dim label = New Label With {
                .Text = kvp.Key,
                .Size = New System.Drawing.Size(x_tab - 50, y_tab - 10),
                .Location = New System.Drawing.Point(x, y)
            }
            Me.Controls.Add(label)

            Dim input = New TextBox With {
                .Text = kvp.Value,
                .Name = kvp.Key,
                .Size = New System.Drawing.Size(x_tab - 50, y_tab - 10),
                .Location = New System.Drawing.Point(x + x_tab, y)
            }
            Me.Controls.Add(input)

            y = y + y_tab

        Next

        'Definit la taille de la fenetre et la position des boutons
        Me.Size = New System.Drawing.Size(500, y + 100)
        Bt_Sauvegarde.Location = New Point(100, y)
        Bt_Annuler.Location = New Point(300, y)

    End Sub

    ''Creer la chaine Json avec les nouveaux paramètres entrée par l'utilisateur
    ''et appel la fonction sendRequest pour l'envoyer au serveur
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Bt_Sauvegarde.Click

        Dim content As String = "{"
        Dim premier As Boolean = True

        ' La variable premier permet de ne pas afficher l'id
        For Each kvp As KeyValuePair(Of String, String) In dicoData
            If (Not premier) Then
                content = content + ","
            Else
                premier = False
            End If
            Select Case kvp.Key
                Case "id", "annee", "alcool", "prix", "score", "cp", "timestamp", "note"
                    content = content + """" + kvp.Key + """:" + Me.Controls.Item(kvp.Key).Text + ""
                Case Else
                    content = content + """" + kvp.Key + """:""" + Me.Controls.Item(kvp.Key).Text + """"
            End Select
        Next

        content = content + "}"
        Console.WriteLine(content)

        Dim uri As New Uri("http://localhost/vinote/web/app_dev.php/" & typeObjet & "/" & Me.Controls.Item("id").Text)
        Dim data = Encoding.UTF8.GetBytes(content)
        Console.WriteLine(uri)


        Form1.SendRequest(uri, data, "application/json", "PUT")
        MsgBox("Modification effectuée")

        fenetreP.chargement()
        fenetreP.changementListe()
        Me.Close()

    End Sub
End Class