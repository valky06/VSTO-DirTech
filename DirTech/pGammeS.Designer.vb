﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class pGammeS
    Inherits System.Windows.Forms.UserControl

    'UserControl remplace la méthode Dispose pour nettoyer la liste des composants.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(pGammeS))
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lSite = New System.Windows.Forms.ComboBox()
        Me.tGamme = New System.Windows.Forms.TextBox()
        Me.Gamme = New System.Windows.Forms.Label()
        Me.gListe = New System.Windows.Forms.DataGridView()
        Me.Gammes = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.i_info = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tInit = New System.Windows.Forms.ToolStripStatusLabel()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        CType(Me.gListe, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button1.FlatAppearance.BorderSize = 0
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Image = Global.CubeAnalysis2.My.Resources.Resources.loupe1_fw
        Me.Button1.Location = New System.Drawing.Point(194, 39)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(23, 23)
        Me.Button1.TabIndex = 39
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(1, 18)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(25, 13)
        Me.Label1.TabIndex = 38
        Me.Label1.Text = "Site"
        '
        'lSite
        '
        Me.lSite.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lSite.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.lSite.FormattingEnabled = True
        Me.lSite.Items.AddRange(New Object() {"Bénaménil", "Casablanca", "Laxou", "Soucy"})
        Me.lSite.Location = New System.Drawing.Point(50, 15)
        Me.lSite.Name = "lSite"
        Me.lSite.Size = New System.Drawing.Size(168, 21)
        Me.lSite.TabIndex = 37
        '
        'tGamme
        '
        Me.tGamme.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tGamme.Location = New System.Drawing.Point(49, 40)
        Me.tGamme.Name = "tGamme"
        Me.tGamme.Size = New System.Drawing.Size(140, 20)
        Me.tGamme.TabIndex = 36
        '
        'Gamme
        '
        Me.Gamme.AutoSize = True
        Me.Gamme.Location = New System.Drawing.Point(1, 43)
        Me.Gamme.Name = "Gamme"
        Me.Gamme.Size = New System.Drawing.Size(43, 13)
        Me.Gamme.TabIndex = 35
        Me.Gamme.Text = "Gamme"
        '
        'gListe
        '
        Me.gListe.AllowUserToAddRows = False
        Me.gListe.AllowUserToDeleteRows = False
        Me.gListe.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gListe.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.gListe.BackgroundColor = System.Drawing.SystemColors.ButtonFace
        Me.gListe.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.gListe.ColumnHeadersHeight = 30
        Me.gListe.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Gammes})
        Me.gListe.Location = New System.Drawing.Point(0, 66)
        Me.gListe.MultiSelect = False
        Me.gListe.Name = "gListe"
        Me.gListe.ReadOnly = True
        Me.gListe.RowHeadersVisible = False
        Me.gListe.RowHeadersWidth = 32
        Me.gListe.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.gListe.Size = New System.Drawing.Size(217, 481)
        Me.gListe.TabIndex = 34
        '
        'Gammes
        '
        Me.Gammes.HeaderText = "Gammes Silog"
        Me.Gammes.Name = "Gammes"
        Me.Gammes.ReadOnly = True
        '
        'i_info
        '
        Me.i_info.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.i_info.Image = CType(resources.GetObject("i_info.Image"), System.Drawing.Image)
        Me.i_info.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.i_info.IsLink = True
        Me.i_info.Name = "i_info"
        Me.i_info.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.i_info.Size = New System.Drawing.Size(182, 22)
        Me.i_info.Spring = True
        Me.i_info.Tag = ""
        Me.i_info.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'tInit
        '
        Me.tInit.DoubleClickEnabled = True
        Me.tInit.Name = "tInit"
        Me.tInit.Size = New System.Drawing.Size(24, 22)
        Me.tInit.Text = "init"
        '
        'StatusStrip1
        '
        Me.StatusStrip1.ImageScalingSize = New System.Drawing.Size(22, 22)
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tInit, Me.i_info})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 550)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(221, 27)
        Me.StatusStrip1.TabIndex = 33
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'pGammeS
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.lSite)
        Me.Controls.Add(Me.tGamme)
        Me.Controls.Add(Me.Gamme)
        Me.Controls.Add(Me.gListe)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Name = "pGammeS"
        Me.Size = New System.Drawing.Size(221, 577)
        CType(Me.gListe, System.ComponentModel.ISupportInitialize).EndInit()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Button1 As Windows.Forms.Button
    Friend WithEvents Label1 As Windows.Forms.Label
    Friend WithEvents lSite As Windows.Forms.ComboBox
    Friend WithEvents tGamme As Windows.Forms.TextBox
    Friend WithEvents Gamme As Windows.Forms.Label
    Friend WithEvents gListe As Windows.Forms.DataGridView
    Friend WithEvents i_info As Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tInit As Windows.Forms.ToolStripStatusLabel
    Friend WithEvents StatusStrip1 As Windows.Forms.StatusStrip
    Friend WithEvents Gammes As Windows.Forms.DataGridViewTextBoxColumn
End Class
