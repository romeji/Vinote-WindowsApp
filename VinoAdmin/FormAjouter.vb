Imports System.Text

Public Class FormAjouter
    Dim typeObjet

    Dim ArrayRecup As ArrayList

    Dim tableau
    Dim typeObjetString
    Dim tableauExposant

    Dim id As Integer

    Dim fenetreP As Form1
    Dim ComboBox As ComboBox

    ''Constructeur de la classe
    Public Sub init(Type As Object, TypeOb As String, Array As ArrayList, fen As Form1)
        typeObjet = Type

        typeObjetString = TypeOb
        tableau = typeObjet.toDic()

        ArrayRecup = Array
        fenetreP = fen
    End Sub

    ''Ferme le formulaire lors du clique sur le bouton Annuler 
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Bt_Annuler.Click
        Me.Close()
    End Sub

    ''Chargement du formulaire d'ajout,
    ' Creation des labels, des textbox, remplissage des textbox avec l'information correspondante
    ' Creation de bouton et paramètrage de leurs positionnements
    Private Sub FormAjouter_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim x As Integer = 50
        Dim y As Integer = 30
        Dim x_tab As Integer = 200
        Dim y_tab As Integer = 50

        For Each kvp As KeyValuePair(Of String, String) In tableau

            Dim label = New Label With {
                .Text = kvp.Key,
                .Size = New System.Drawing.Size(x_tab - 50, y_tab - 10),
                .Location = New System.Drawing.Point(x, y)
            }

            Me.Controls.Add(label)

            'Definit la taille de la fenetre et la position des boutons
            Me.Size = New System.Drawing.Size(500, y + 150)
            Bt_Sauvegarde.Location = New Point(100, y + 50)
            Bt_Annuler.Location = New Point(300, y + 50)


            If (typeObjet IsNot "Vin" And kvp.Key IsNot "exposant") Then
                Dim input = New TextBox With {
                    .Name = kvp.Key,
                    .Size = New System.Drawing.Size(x_tab - 50, y_tab - 10),
                    .Location = New System.Drawing.Point(x + x_tab, y)
                }
                Me.Controls.Add(input)

                If (input.Name = "id") Then
                    input.Enabled = False
                End If

                y = y + y_tab

            Else
                ComboBox = New ComboBox With {
                    .Name = kvp.Key,
                    .Size = New System.Drawing.Size(x_tab - 50, y_tab - 10),
                    .Location = New System.Drawing.Point(x + x_tab, y)
                }
                Me.Controls.Add(ComboBox)

                For Each exp As String() In ArrayRecup
                    ComboBox.Items.Add(exp(0) + ":" + exp(3) + " " + exp(2))
                Next
            End If
        Next
    End Sub

    ''Creer la chaine Json avec les nouveaux paramètres entrée par l'utilisateur
    ''et appel la fonction sendRequest pour l'envoyer au serveur
    Private Sub Sauvegarde_Click(sender As Object, e As EventArgs) Handles Bt_Sauvegarde.Click
        Dim content As String = "{"
        Dim premier As Boolean = True
        ' La variable premier permet de ne pas afficher l'id

        For Each kvp As KeyValuePair(Of String, String) In tableau
            If (kvp.Key IsNot "id") Then
                If (Not premier) Then
                    content = content + ","
                Else
                    premier = False
                End If

                If (typeObjetString = "vins") Then
                    Dim ComboSelect = Split(ComboBox.SelectedItem.ToString, ":")
                    id = Convert.ToInt64(ComboSelect(0))
                End If

                Select Case kvp.Key
                    Case "id", "annee", "alcool", "prix", "score", "cp", "timestamp", "note"
                        content = content + """" + kvp.Key + """:" + Me.Controls.Item(kvp.Key).Text + ""
                    Case "exposant"
                        content = content + """exposant"":" + id.ToString + ""
                    Case Else
                        content = content + """" + kvp.Key + """:""" + Me.Controls.Item(kvp.Key).Text + """"
                End Select
            End If
        Next

        content = content + "}"
        Console.WriteLine(content)

        Dim uri As New Uri("http://localhost/vinote/web/app_dev.php/" & typeObjetString)
        Dim data = Encoding.UTF8.GetBytes(content)

        Form1.SendRequest(uri, data, "application/json", "POST")
        MsgBox("Insertion effectuée")

        fenetreP.chargement()
        fenetreP.changementListe()
        Me.Close()

    End Sub
End Class