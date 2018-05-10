<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormModifier
    Inherits System.Windows.Forms.Form

    'Form remplace la méthode Dispose pour nettoyer la liste des composants.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requise par le Concepteur Windows Form
    Private components As System.ComponentModel.IContainer

    'REMARQUE : la procédure suivante est requise par le Concepteur Windows Form
    'Elle peut être modifiée à l'aide du Concepteur Windows Form.  
    'Ne la modifiez pas à l'aide de l'éditeur de code.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.Bt_Sauvegarde = New System.Windows.Forms.Button()
        Me.Bt_Annuler = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Bt_Sauvegarde
        '
        Me.Bt_Sauvegarde.Location = New System.Drawing.Point(50, 216)
        Me.Bt_Sauvegarde.Name = "Bt_Sauvegarde"
        Me.Bt_Sauvegarde.Size = New System.Drawing.Size(75, 23)
        Me.Bt_Sauvegarde.TabIndex = 1
        Me.Bt_Sauvegarde.Text = "Sauvegarder"
        Me.Bt_Sauvegarde.UseVisualStyleBackColor = True
        '
        'Bt_Annuler
        '
        Me.Bt_Annuler.Location = New System.Drawing.Point(145, 216)
        Me.Bt_Annuler.Name = "Bt_Annuler"
        Me.Bt_Annuler.Size = New System.Drawing.Size(75, 23)
        Me.Bt_Annuler.TabIndex = 2
        Me.Bt_Annuler.Text = "Annuler"
        Me.Bt_Annuler.UseVisualStyleBackColor = True
        '
        'FormModifier
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(284, 261)
        Me.Controls.Add(Me.Bt_Annuler)
        Me.Controls.Add(Me.Bt_Sauvegarde)
        Me.Name = "FormModifier"
        Me.Text = "FormModifier"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Bt_Sauvegarde As Button
    Friend WithEvents Bt_Annuler As Button
End Class
