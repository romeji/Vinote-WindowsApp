Imports System.Net
Imports System.Runtime.Serialization.Json
Imports System.IO
Imports System.Text


Public Class Form1
    Dim exposants As New ArrayList
    Dim invites As New ArrayList
    Dim notes As New ArrayList
    Dim vins As New ArrayList


    ''Appel la methode chargement au démarrage de l'application
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        chargement()
    End Sub


    ''Chargement et mise à jours des données des differente tables
    Public Sub chargement()

        exposants.Clear()
        invites.Clear()
        notes.Clear()
        vins.Clear()

        Dim url As String
        Dim synClient As WebClient
        synClient = New WebClient()
        Dim content As String
        Dim serializer As DataContractJsonSerializer
        Dim objExposant As Exposant()
        serializer = New DataContractJsonSerializer(GetType(Exposant()))
        url = "http://localhost/vinote/web/app_dev.php/exposants"
        content = synClient.DownloadString(url)
        Dim msexposant As New MemoryStream(Encoding.Unicode.GetBytes(content))
        objExposant = serializer.ReadObject(msexposant)
        msexposant.Close()

        For Each prod As Exposant In objExposant
            Dim dg As String()
            dg = prod.toArrayString()
            exposants.Add(dg)
        Next

        Dim objVin As Vin()
        url = "http://localhost/vinote/web/app_dev.php/vins"
        content = synClient.DownloadString(url)
        Dim msVin As New MemoryStream(Encoding.Unicode.GetBytes(content))
        serializer = New DataContractJsonSerializer(GetType(Vin()))
        objVin = serializer.ReadObject(msVin)
        msVin.Close()

        For Each prod As Vin In objVin
            Dim dg As String()
            dg = prod.toArrayString()
            vins.Add(dg)
        Next

        Dim objVisiteur As Invite()
        url = "http://localhost/vinote/web/app_dev.php/invites"
        content = synClient.DownloadString(url)
        Dim msVisiteur As New MemoryStream(Encoding.Unicode.GetBytes(content))
        serializer = New DataContractJsonSerializer(GetType(Invite()))
        objVisiteur = serializer.ReadObject(msVisiteur)
        msVisiteur.Close()

        For Each prod As Invite In objVisiteur
            Dim dg As String()
            dg = prod.toArrayString()
            invites.Add(dg)
        Next

        Dim obj As Note()
        url = "http://localhost/vinote/web/app_dev.php/notes"
        content = synClient.DownloadString(url)
        Dim msNote As New MemoryStream(Encoding.Unicode.GetBytes(content))
        serializer = New DataContractJsonSerializer(GetType(Note()))
        obj = serializer.ReadObject(msNote)
        msNote.Close()

        For Each prod As Note In obj
            Dim dg As String()
            dg = prod.toArrayString()
            notes.Add(dg)
        Next

    End Sub


    'Private Function getRequest(uri As Uri, contentType As String, method As String) As String
    '    Dim req As WebRequest = WebRequest.Create(uri)
    '    req.ContentType = contentType
    '    req.Method = method

    '    Dim response = req.GetResponse().GetResponseStream()

    '    Dim reader As New StreamReader(response)
    '    Dim res = reader.ReadToEnd()
    '    reader.Close()
    '    response.Close()

    '    Return res
    'End Function


    ''Charge toutes les lignes de chaque colonne du tableau
    Private Sub dgridRefresh(indexCombobox As Integer)

        If (indexCombobox = 1) Then
            DataGridView1.Rows.Clear()
            For Each exp As String() In vins
                DataGridView1.Rows.Add(exp)
            Next

        ElseIf (indexCombobox = 2) Then
            DataGridView1.Rows.Clear()
            For Each exp As String() In exposants
                DataGridView1.Rows.Add(exp)
            Next

        ElseIf (indexCombobox = 3) Then
            DataGridView1.Rows.Clear()
            For Each exp As String() In invites
                DataGridView1.Rows.Add(exp)
            Next

        ElseIf (indexCombobox = 4) Then
            DataGridView1.Rows.Clear()
            For Each note As String() In notes
                DataGridView1.Rows.Add(note)
            Next
        End If

    End Sub

    ''Chargement des entête du tableau lors du choix de l'index dans le combobox 
    Public Sub changementListe()
        If (ComboBox1.SelectedItem = "vin") Then

            DataGridView1.ColumnCount = 4
            DataGridView1.Columns(0).Name = "id"
            DataGridView1.Columns(1).Name = "appellation"
            DataGridView1.Columns(2).Name = "annee"
            DataGridView1.Columns(3).Name = "type"
            Bt_ajouter.Visible = True

            dgridRefresh(1)


        ElseIf (ComboBox1.SelectedItem = "exposant") Then

            DataGridView1.ColumnCount = 4
            DataGridView1.Columns(0).Name = "id"
            DataGridView1.Columns(1).Name = "Domaine"
            DataGridView1.Columns(2).Name = "Nom"
            DataGridView1.Columns(3).Name = "Prénom"
            Bt_ajouter.Visible = True

            dgridRefresh(2)

        ElseIf (ComboBox1.SelectedItem = "invite") Then

            DataGridView1.ColumnCount = 4
            DataGridView1.Columns(0).Name = "id"
            DataGridView1.Columns(1).Name = "Nom"
            DataGridView1.Columns(2).Name = "Prenom"
            DataGridView1.Columns(3).Name = "Email"
            Bt_ajouter.Visible = True

            dgridRefresh(3)

        ElseIf (ComboBox1.SelectedItem = "note") Then

            DataGridView1.ColumnCount = 4
            DataGridView1.Columns(0).Name = "id"
            DataGridView1.Columns(1).Name = "Timestamp"
            DataGridView1.Columns(2).Name = "Note"
            DataGridView1.Columns(3).Name = "Commentaire"
            Bt_ajouter.Visible = False

            dgridRefresh(4)

        Else
            Bt_ajouter.Visible = True
            MsgBox("Selectionner un item valide")
        End If
    End Sub

    ''methode qu'en on clique sur un index du combobox
    '' qui va recharger la page en fonction de l'index
    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        changementListe()
    End Sub


    ''Action qu'en t-on clique sur le bouton modifier
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Bt_Modification.Click

        If DataGridView1 IsNot Nothing Then
            Dim rowindex As Integer = DataGridView1.SelectedCells(0).RowIndex
            Dim column As Integer = DataGridView1.SelectedCells(0).ColumnIndex
            Dim Valeur = DataGridView1.Rows(rowindex).Cells(column).Value
            Dim id = DataGridView1.Rows(rowindex).Cells(0).Value

            Dim synClient As WebClient
            synClient = New WebClient()
            Dim content As String


            Dim selectedCombobox = ComboBox1.SelectedItem

            Dim uri As New Uri("http://localhost/vinote/web/app_dev.php/" & selectedCombobox & "/" & id)
            Console.WriteLine(uri)
            content = synClient.DownloadString(uri)

            Dim formModif = New FormModifier

            Dim Item = ComboBox1.SelectedItem()
            content = synClient.DownloadString(uri)
            Console.WriteLine(content)
            Dim ms As New MemoryStream(Encoding.Unicode.GetBytes(content))

            Dim serializer As DataContractJsonSerializer
            Dim arrayString = Nothing
            Select Case Item
                Case "invite"
                    serializer = New DataContractJsonSerializer(GetType(Invite))
                    Dim obj As Invite
                    obj = serializer.ReadObject(ms)
                    arrayString = obj.toDic()
                    formModif.init(arrayString, "visiteurs", Me)
                Case "vin"
                    serializer = New DataContractJsonSerializer(GetType(Vin))
                    Dim obj As Vin
                    obj = serializer.ReadObject(ms)
                    arrayString = obj.toDic()
                    formModif.init(arrayString, "vins", Me)
                Case "note"
                    serializer = New DataContractJsonSerializer(GetType(Note))
                    Dim obj As Note
                    obj = serializer.ReadObject(ms)
                    arrayString = obj.toDic()
                    formModif.init(arrayString, "notes", Me)
                Case "exposant"
                    serializer = New DataContractJsonSerializer(GetType(Exposant))
                    Dim obj As Exposant
                    obj = serializer.ReadObject(ms)
                    arrayString = obj.toDic()
                    formModif.init(arrayString, "exposants", Me)
            End Select


            formModif.Show()
            Console.WriteLine(arrayString)

        End If

    End Sub

    ''Action qu'en t-on clique sur le bouton supprimer
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Bt_supprimer.Click
        MessageBox.Show("Voulez-vous vraiment supprimer ce champ ? ", "Supprimer", MessageBoxButtons.OKCancel)
        If (DialogResult = MessageBoxButtons.OK) Then

            Dim rowindex As Integer = DataGridView1.SelectedCells(0).RowIndex
            Dim id = DataGridView1.Rows(rowindex).Cells(0).Value

            Dim content = "{""id"":" & id & "}"
            Dim uri As New Uri("http://localhost/vinote/web/app_dev.php/" & ComboBox1.SelectedItem & "s" & "/" & id)
            Dim data = Encoding.UTF8.GetBytes(content)
            Console.WriteLine(content)
            Console.WriteLine(uri)
            SendRequest(uri, data, "application/json", "DELETE")
            MsgBox("Suppression effectuée")
            Me.chargement()
            Me.changementListe()

        End If
    End Sub

    ''Action qu'en t-on clique sur le bouton ajouter
    'Affiche la page ajouter en fonction de l'item selectionné
    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Bt_ajouter.Click

        If (ComboBox1.SelectedItem IsNot Nothing) Then
            Dim exposant As New Exposant

            If (ComboBox1.SelectedItem = "vin") Then
                Dim vin As New Vin
                FormAjouter.init(vin, "vins", exposants, Me)

            ElseIf (ComboBox1.SelectedItem = "exposant") Then
                FormAjouter.init(exposant, "exposants", exposants, Me)

            ElseIf (ComboBox1.SelectedItem = "invite") Then
                Dim visiteur As New Invite
                FormAjouter.init(visiteur, "invites", exposants, Me)

            ElseIf (ComboBox1.SelectedItem = "note") Then
                Dim note As New Note
                FormAjouter.init(note, "notes", exposants, Me)
            End If

            FormAjouter.Show()
        End If
    End Sub


    'Function qui envoie la requête au serveur REST et retourne son resultat
    Public Function SendRequest(uri As Uri, jsonDataBytes As Byte(), contentType As String, method As String) As String
        Dim req As WebRequest = WebRequest.Create(uri)
        req.ContentType = contentType
        req.Method = method
        req.ContentLength = jsonDataBytes.Length


        Dim stream = req.GetRequestStream()
        stream.Write(jsonDataBytes, 0, jsonDataBytes.Length)
        stream.Close()

        Dim response = req.GetResponse().GetResponseStream()

        Dim reader As New StreamReader(response)
        Dim res = reader.ReadToEnd()
        reader.Close()
        response.Close()

        Return res
    End Function

End Class
