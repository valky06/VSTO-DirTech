<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmParam
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
        Me.bAnnul = New System.Windows.Forms.Button()
        Me.bOK = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.pGrid1 = New System.Windows.Forms.PropertyGrid()
        Me.SuspendLayout()
        '
        'bAnnul
        '
        Me.bAnnul.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.bAnnul.BackColor = System.Drawing.SystemColors.Control
        Me.bAnnul.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.bAnnul.FlatAppearance.BorderColor = System.Drawing.Color.Silver
        Me.bAnnul.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bAnnul.ForeColor = System.Drawing.Color.Black
        Me.bAnnul.Location = New System.Drawing.Point(14, 222)
        Me.bAnnul.Name = "bAnnul"
        Me.bAnnul.Size = New System.Drawing.Size(75, 26)
        Me.bAnnul.TabIndex = 3
        Me.bAnnul.Text = "Annuler"
        Me.bAnnul.UseVisualStyleBackColor = False
        '
        'bOK
        '
        Me.bOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bOK.BackColor = System.Drawing.SystemColors.Control
        Me.bOK.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.bOK.FlatAppearance.BorderColor = System.Drawing.Color.Silver
        Me.bOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bOK.ForeColor = System.Drawing.Color.Black
        Me.bOK.Location = New System.Drawing.Point(611, 222)
        Me.bOK.Name = "bOK"
        Me.bOK.Size = New System.Drawing.Size(75, 26)
        Me.bOK.TabIndex = 4
        Me.bOK.Text = "OK"
        Me.bOK.UseVisualStyleBackColor = False
        '
        'Button1
        '
        Me.Button1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Button1.BackColor = System.Drawing.SystemColors.Control
        Me.Button1.FlatAppearance.BorderColor = System.Drawing.Color.Silver
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.ForeColor = System.Drawing.Color.Black
        Me.Button1.Location = New System.Drawing.Point(229, 222)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(95, 26)
        Me.Button1.TabIndex = 7
        Me.Button1.Text = "TEST Silog"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'Button2
        '
        Me.Button2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Button2.BackColor = System.Drawing.SystemColors.Control
        Me.Button2.FlatAppearance.BorderColor = System.Drawing.Color.Silver
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button2.ForeColor = System.Drawing.Color.Black
        Me.Button2.Location = New System.Drawing.Point(354, 222)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(95, 26)
        Me.Button2.TabIndex = 10
        Me.Button2.Text = "Test TopSolid"
        Me.Button2.UseVisualStyleBackColor = False
        '
        'pGrid1
        '
        Me.pGrid1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pGrid1.HelpVisible = False
        Me.pGrid1.Location = New System.Drawing.Point(14, 12)
        Me.pGrid1.Name = "pGrid1"
        Me.pGrid1.Size = New System.Drawing.Size(672, 204)
        Me.pGrid1.TabIndex = 13
        Me.pGrid1.ToolbarVisible = False
        '
        'FrmParam
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(698, 260)
        Me.Controls.Add(Me.pGrid1)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.bOK)
        Me.Controls.Add(Me.bAnnul)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow
        Me.Name = "FrmParam"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Paramètres"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents bAnnul As System.Windows.Forms.Button
    Friend WithEvents bOK As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As Windows.Forms.Button
    Friend WithEvents pGrid1 As Windows.Forms.PropertyGrid
End Class
