<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.Bt_ajouter = New System.Windows.Forms.Button()
        Me.Bt_Modification = New System.Windows.Forms.Button()
        Me.Bt_supprimer = New System.Windows.Forms.Button()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(12, 34)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.Size = New System.Drawing.Size(598, 220)
        Me.DataGridView1.TabIndex = 1
        '
        'Bt_ajouter
        '
        Me.Bt_ajouter.Location = New System.Drawing.Point(44, 281)
        Me.Bt_ajouter.Name = "Bt_ajouter"
        Me.Bt_ajouter.Size = New System.Drawing.Size(75, 23)
        Me.Bt_ajouter.TabIndex = 8
        Me.Bt_ajouter.Text = "Ajouter"
        Me.Bt_ajouter.UseVisualStyleBackColor = True
        '
        'Bt_Modification
        '
        Me.Bt_Modification.Location = New System.Drawing.Point(277, 281)
        Me.Bt_Modification.Name = "Bt_Modification"
        Me.Bt_Modification.Size = New System.Drawing.Size(75, 23)
        Me.Bt_Modification.TabIndex = 9
        Me.Bt_Modification.Text = "Modifier"
        Me.Bt_Modification.UseVisualStyleBackColor = True
        '
        'Bt_supprimer
        '
        Me.Bt_supprimer.Location = New System.Drawing.Point(520, 281)
        Me.Bt_supprimer.Name = "Bt_supprimer"
        Me.Bt_supprimer.Size = New System.Drawing.Size(75, 23)
        Me.Bt_supprimer.TabIndex = 10
        Me.Bt_supprimer.Text = "Supprimer"
        Me.Bt_supprimer.UseVisualStyleBackColor = True
        '
        'ComboBox1
        '
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Items.AddRange(New Object() {"vin", "exposant", "invite", "note"})
        Me.ComboBox1.Location = New System.Drawing.Point(15, 7)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(121, 21)
        Me.ComboBox1.TabIndex = 11
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(622, 324)
        Me.Controls.Add(Me.ComboBox1)
        Me.Controls.Add(Me.Bt_supprimer)
        Me.Controls.Add(Me.Bt_Modification)
        Me.Controls.Add(Me.Bt_ajouter)
        Me.Controls.Add(Me.DataGridView1)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Form1"
        Me.Text = "Vinothèque"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents Bt_ajouter As Button
    Friend WithEvents Bt_Modification As Button
    Friend WithEvents Bt_supprimer As Button
    Friend WithEvents ComboBox1 As ComboBox
End Class
