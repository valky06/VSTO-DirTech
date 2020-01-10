Imports System.Data
Imports System.Windows.Forms

Public Class pGammeS
    Dim init As Boolean = False
    Dim APP As Excel.Application = Globals.CompoXLCompta.Application
    Dim laLigne As Integer
    Dim NivMax As Integer

    Private Sub i_info_DoubleClick(sender As Object, e As EventArgs) Handles i_info.DoubleClick
        System.Diagnostics.Process.Start(Me.i_info.Tag)
    End Sub

    Private Sub tInit_DoubleClick(sender As Object, e As EventArgs) Handles tInit.DoubleClick
        Dim a As String = InputBox("Mot de passe")
        If a = "!KEP" Then
            Dim frm As New FrmParam
            frm.ShowDialog()
        End If
    End Sub


    Private Sub pFactor_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.i_info.Enabled = (Me.i_info.Tag <> "")
        Try
        Catch ex As Exception
        End Try
    End Sub


    Private Sub TextBox1_KeyUp(sender As Object, e As KeyEventArgs) Handles tGamme.KeyUp
        If e.KeyCode = Keys.Enter Then Call GammeCherche(Nothing, Nothing)
    End Sub

    Private Sub GammeCherche(sender As Object, e As EventArgs) Handles Button1.Click
        If Me.lSite.Text = "" Then Exit Sub
        If Me.tGamme.Text.Length < 3 Then Exit Sub

        Dim sSql As String
        Dim lers As OleDb.OleDbDataReader


        Try
            Me.gListe.Rows.Clear()
            sSql = "select top 1000 ldfe.CodeListeFabStd from ldfe inner join LDFC on ldfc.CodeListeFabStd = ldfe.CodeListeFabStd" _
            & " where ldfe.codelistefabstd Like '%" & Me.tGamme.Text & "%' group by ldfe.CodeListeFabStd order by ldfe.CodeListeFabStd "
            lers = SqlLit(sSql, conSqlSilog)
            While lers.Read
                Me.gListe.Rows.Add(lers("CodeListeFabStd"))
            End While
            lers.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub lSite_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lSite.SelectedIndexChanged
        Dim leStrCon As String

        My.Settings.Reload()
        leStrCon = My.Settings.ConStrSilog
        Me.gListe.Rows.Clear()
        Select Case Me.lSite.Text
            Case "Soucy"
                leStrCon &= ";Initial Catalog=KTISSOUCY"
            Case "Laxou"
                leStrCon &= ";Initial Catalog=KTISLAXOU"
            Case "Casablanca"
                leStrCon &= ";Initial Catalog=KMTM"
            Case "Bénaménil"
                leStrCon &= ";Initial Catalog=APL"
        End Select

        Try
            ConnexionInit(leStrCon, conSqlSilog)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub gListe_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles gListe.CellContentClick

    End Sub

    ''' <summary>
    ''' Affiche la nomenclature de la gamme au niveau N multiplié la quantité du composant
    ''' </summary>
    ''' <param name="laGamme">La gamme ou sous-gamme à afficher</param>
    ''' <param name="leNiveau">Le niveau d'affichage</param>
    ''' <param name="laQte">La quantité du composant dans la gamme N-1</param>
    Sub afficheNomenclature(laGamme As String, leNiveau As Integer, laQte As Decimal)
        Dim sSql As String
        Dim lers As OleDb.OleDbDataReader
        Try
            APP.Cells(3, leNiveau * 2 + 2).value = "Ph"
            APP.Cells(3, leNiveau * 2 + 3).value = "Composant/Opération"
            If NivMax < leNiveau Then NivMax = leNiveau

            sSql = " Select LDFC.CodeListeFabStd, LDFC.Phase, LDFC.TypeRubrique, LDFC.CodeRubrique, LDFC.SousTraitance, LDFC.QuantiteComposant, LDFC.TempsPoste, LDFC.TempsReglage, " _
            & "ARTICLE.CodeSpecifLct, ARTICLE.CodeListeFab,ARTICLE.ArtAchOuFab " _
            & " From LDFC " _
            & " LEFT OUTER Join ARTICLE On LDFC.CodeRubrique = ARTICLE.CodeArticle And TypeRubrique='A'" _
            & " where LDFC.CodeListeFabStd = '" & laGamme & "' ORDER BY LDFC.Phase"
            lers = SqlLit(sSql, conSqlSilog)
            While lers.Read
                APP.Cells(laLigne, 1).value = leNiveau
                APP.Cells(laLigne, leNiveau * 2 + 2).value = "'" & lers("Phase")
                APP.Cells(laLigne, leNiveau * 2 + 3).value = lers("CodeRubrique")
                APP.Cells(laLigne, 20).value = Val(Nz(lers("QuantiteComposant"), 1) * laQte)
                If leNiveau > 0 Then APP.Range(APP.Cells(laLigne, leNiveau * 2 + 2), APP.Cells(laLigne, 22)).Interior.Color = RGB(230 - leNiveau * 10, 230 - leNiveau * 10, 230 - leNiveau * 10)

                If Nz(lers("ArtAchOuFab"), "O") = "N" And Nz(lers("CodeSpecifLct"), "") <> "" Then
                    laLigne += 1
                    Call afficheNomenclature(lers("CodeSpecifLct"), leNiveau + 1, Nz(lers("QuantiteComposant"), 1) * laQte)
                Else
                    APP.Cells(laLigne, 21).value = lers("TempsPoste") * laQte
                    APP.Cells(laLigne, 22).value = lers("TempsReglage")
                    laLigne += 1
                End If

            End While
            lers.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try


    End Sub

    Private Sub gListe_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles gListe.CellDoubleClick

        APP.Cells.Clear()
        APP.Columns("A:S").NumberFormat = "@"
        APP.Columns("A:S").ColumnWidth = 4
        NivMax = 0

        'Mise en forme début
        APP.Cells(1, 1).select
        APP.Cells(1, 1).value = Me.gListe.Rows(e.RowIndex).Cells("Gammes").Value
        APP.Cells(1, 1).Font.Color = RGB(192, 0, 0)
        APP.Cells(1, 1).Font.size = 18

        'Ligne d'entete
        laLigne = 3
        APP.Cells(laLigne, 1).value = "N"
        APP.Cells(laLigne, 2).value = "Ph"
        APP.Cells(laLigne, 3).value = "Composant/Opération"
        APP.Cells(laLigne, 20).value = "Qté"
        APP.Cells(laLigne, 21).value = "Tps Prod/U"
        APP.Cells(laLigne, 22).value = "Tps Rég."
        APP.Range("A" & laLigne & ":V" & laLigne).Interior.Color = RGB(192, 0, 0)
        APP.Range("A" & laLigne & ":V" & laLigne).Font.Color = RGB(255, 255, 255)
        APP.Range("A" & laLigne & ":V" & laLigne).Font.Bold = True

        'Affichage Détail
        laLigne += 1
        Call afficheNomenclature(Me.gListe.Rows(e.RowIndex).Cells("Gammes").Value, 0, 1)

        'Mise en forme finale

        APP.Columns((NivMax + 1) * 2 + 1).EntireColumn.AutoFit
        For i = (NivMax + 1) * 2 + 2 To 19
            APP.Columns(i).ColumnWidth = 0
        Next
    End Sub
End Class
