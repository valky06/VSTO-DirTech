Imports System.Data
Imports System.Windows.Forms

Public Class pGammeT
    Dim init As Boolean = False
    Dim APP As Excel.Application = Globals.CompoXLCompta.Application
        Dim laLigne As Integer
        Dim NivMax As Integer

        Public Sub initialise()
            Dim APP As Excel.Application = Globals.CompoXLCompta.Application
            My.Settings.Reload()
            Try
                If Not init Then
                    Try
                    ConnexionFerme(conSqlTops)
                    ConnexionInit(My.Settings.ConStrTops, conSqlTops)

                    Me.init = True
                    Catch ex As Exception
                        MsgBox(ex.Message)
                    End Try
                End If
            Catch ex As Exception
                MsgBox(ex.Message)
            Finally
                APP.StatusBar = ""
                Me.tInit.Text = IIf(init, "Connecté", "Non connecté")
            End Try
        End Sub


        Private Sub i_info_DoubleClick(sender As Object, e As EventArgs) Handles i_info.DoubleClick
            System.Diagnostics.Process.Start(Me.i_info.Tag)
        End Sub

        Private Sub tInit_DoubleClick(sender As Object, e As EventArgs) Handles tInit.DoubleClick
            Dim a As String = InputBox("Mot de passe")
            If a = "!KEP" Then
                Dim frm As New FrmParam
                If frm.ShowDialog = Windows.Forms.DialogResult.OK Then
                    init = False
                    Call initialise()
                End If
            End If
        End Sub


        Private Sub pFactor_Load(sender As Object, e As EventArgs) Handles MyBase.Load
            Me.i_info.Enabled = (Me.i_info.Tag <> "")
            Try
                Call initialise()
            Catch ex As Exception

            End Try
        End Sub


        Private Sub TextBox1_KeyUp(sender As Object, e As KeyEventArgs) Handles tGamme.KeyUp
            If e.KeyCode = Keys.Enter Then Call GammeCherche(Nothing, Nothing)
        End Sub

        Private Sub GammeCherche(sender As Object, e As EventArgs) Handles Button1.Click
        If Me.tGamme.Text.Length < 3 Then Exit Sub

        Dim sSql As String
        Dim lers As OleDb.OleDbDataReader

        Try
            Me.gListe.Rows.Clear()
            sSql = "    select O.Id_Object,A.REFERENCE,R.REFERENCE AS Gamme,R.Version " _
            & " from t_article A" _
            & " inner join TOPPDM.OBJECT O on O.id_object=a.ID_OBJECT" _
            & " inner join TOPPDM.ROUTING R on R.Id_routing =O.Id_ROUTIng" _
            & " where A.reference like '%" & Me.tGamme.Text & "%' and rownum <= 100" _
            & " order by a.reference"
            lers = SqlLit(sSql, conSqlTops)
            While lers.Read
                Me.gListe.Rows.Add(lers("Id_Object"), lers("REFERENCE"), lers("Gamme") & " v" & Nz(lers("Version"), ""))
            End While
            lers.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        End Sub




    ''' <summary>
    ''' Affiche la nomenclature de la gamme au niveau N multiplié la quantité du composant
    ''' </summary>
    ''' <param name="lItemId">L'Objet ou sous-gamme à afficher</param>
    ''' <param name="leNiveau">Le niveau d'affichage</param>
    ''' <param name="laQte">La quantité du composant dans la gamme N-1</param>
    Sub afficheNomenclature(lItemId As String, leNiveau As Integer, laQte As Decimal)
        Dim sSql As String
        Dim lers As OleDb.OleDbDataReader
        Try
            APP.Cells(7, leNiveau * 2 + 2).value = "Ph"
            APP.Cells(7, leNiveau * 2 + 3).value = "Composant/Opération"
            If NivMax < leNiveau Then NivMax = leNiveau

            'Affichage Nomenclature
            sSql = "Select TP.id_object ,TP.Quantity, TF.ID_OBJECT,TF.Reference,TF.ID_ITEM,count(TF2.id_item) as NBFils,TF.ID_ROUTING" _
            & " from toppdm.tree_bom TP" _
            & " Left join toppdm.tree_bom TF     on TP.Id_Item=TF.Id_Parent_Item" _
            & " Left join toppdm.tree_bom TF2  on TF.Id_Item=TF2.Id_Parent_Item  " _
            & " where TP.ID_ITEM ='" & lItemId & "'" _
            & " group by TP.id_object ,TP.Quantity, TF.ID_OBJECT,TF.Reference,TF.ID_ITEM,TF.ID_ROUTING"
            lers = SqlLit(sSql, conSqlTops)
            While lers.Read
                APP.Cells(laLigne, 1).value = leNiveau
                APP.Cells(laLigne, leNiveau * 2 + 2).value = "Nm"
                APP.Cells(laLigne, leNiveau * 2 + 3).value = lers("reference")
                APP.Cells(laLigne, 20).value = Sql2num(lers("Quantity"))
                If leNiveau > 0 Then APP.Range(APP.Cells(laLigne, leNiveau * 2 + 2), APP.Cells(laLigne, 22)).Interior.Color = RGB(230 - leNiveau * 10, 230 - leNiveau * 10, 230 - leNiveau * 10)

                laLigne += 1
                If Sql2num(lers("NBFils")) > 0 Then Call afficheNomenclature(lers("ID_ITEM"), leNiveau + 1, Sql2num(lers("Quantity") * laQte))
                AfficheGamme(lers("ID_ROUTING"), leNiveau + 1, lers("Quantity"))
            End While

            lers.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try


    End Sub

    Sub AfficheGamme(laGammeId As String, leNiveau As Integer, laQte As Decimal)
        Dim sSql As String
        Dim lers As OleDb.OleDbDataReader
        Try
            APP.Cells(7, leNiveau * 2 + 2).value = "Ph"
            APP.Cells(7, leNiveau * 2 + 3).value = "Composant/Opération"
            If NivMax < leNiveau Then NivMax = leNiveau

            'affiche Matière
            sSql = "Select RM.Quantity, RM.ID_Quantity_unit,A.reference,A.B_PROD ,O.type,O.ID_ROuting,A.designation,A.MNT_ACHAT,g.libelle" _
            & " From TOPPDM.Routing R " _
            & " left Join TOPPDM.ROUTING_MATERIAL RM On RM.ID_ROUTING= R.ID_ROUTING " _
            & " Left Join T_ARTICLE A On A.ID_ARTICLE = RM.ID_ORIGIN " _
            & " left join toppdm.object O on A.ID_Object=O.id_object " _
            & "  left join t_groupe_article G on g.id_groupe_article=a.id_groupe_article" _
            & " where RM.Quantity>0 and R.ID_ROUTING='" & laGammeId & "'"
            lers = SqlLit(sSql, conSqlTops)
            While lers.Read
                APP.Cells(laLigne, 1).value = leNiveau
                APP.Cells(laLigne, leNiveau * 2 + 2).value = lers("libelle")
                APP.Cells(laLigne, leNiveau * 2 + 3).value = lers("reference")
                APP.Cells(laLigne, 20).value = Sql2num(lers("Quantity")) * laQte
                APP.Cells(laLigne, 21).value = lers("designation")
                APP.Cells(laLigne, 23).value = Sql2num(lers("MNT_ACHAT"))
                APP.Cells(laLigne, 27).value = Sql2num(lers("MNT_ACHAT")) * Sql2num(lers("Quantity")) * laQte
                If leNiveau > 0 Then APP.Range(APP.Cells(laLigne, leNiveau * 2 + 2), APP.Cells(laLigne, 22)).Interior.Color = RGB(230 - leNiveau * 10, 230 - leNiveau * 10, 230 - leNiveau * 10)
                laLigne += 1

                If Nz(lers("B_PROD"), 1) <> 0 And Nz(lers("ID_ROUTING"), 0) <> 0 Then
                    AfficheGamme(lers("ID_ROuting"), leNiveau + 1, Sql2num(lers("Quantity")) * laQte)
                End If
            End While
            lers.Close()

            'Affiche opération
            sSql = " select ROUTING.ID_ROUTING,ROUTING_OP.SEQ , ROUTING_INSTRUCTION.SETUP_TIME_HC, ROUTING_INSTRUCTION.WORK_TIME_HC,ROUTING_INSTRUCTION.CTRL_TIME_HC" _
            & " ,ROUTING_RESOURCE.id_resource, RATE_PREPARE_COST, RATE_CYCLE_COST,RATE_CONTROL_COST, RESOURCES.name, routing.reference,ROUTING_OP.ID_TYPE" _
            & " ,s.reference as RefSST,s.designation as DesSST,RESOURCES.designation as DesOP" _
            & " from TOPPDM.Routing " _
            & " left join TOPPDM.ROUTING_OP on ROUTING_OP.ID_ROUTING= ROUTING.ID_ROUTING" _
            & " LEFT JOIN TOPPDM.ROUTING_INSTRUCTION on ROUTING_INSTRUCTION.ID_ROUTING_INSTRUCTION = ROUTING_OP.ID_ROUTING_INSTRUCTION" _
            & " LEFT JOIN TOPPDM.ROUTING_RESOURCE on ROUTING_RESOURCE.ID_ROUTING_INSTRUCTION = ROUTING_INSTRUCTION.ID_ROUTING_INSTRUCTION" _
            & " LEFT JOIN TOPMES.RESOURCES on RESOURCES.id_resource =ROUTING_RESOURCE.id_resource" _
            & " LEFT JOIN T_SPECIALITE S on s.id_specialite = toppdm.routing_op.id_specialite_st" _
            & " where ROUTING.ID_ROUTING='" & laGammeId & "' order by seq"
            lers = SqlLit(sSql, conSqlTops)
            While lers.Read
                APP.Cells(laLigne, 1).value = leNiveau
                APP.Cells(laLigne, leNiveau * 2 + 2).value = "'" & lers("SEQ")
                If Nz(lers("ID_TYPE"), 0) = 1 Then
                    APP.Cells(laLigne, leNiveau * 2 + 3).value = lers("RefSST")
                    APP.Cells(laLigne, 21).value = lers("DesSST")
                    APP.Cells(laLigne, 22).value = "SST"
                Else
                    APP.Cells(laLigne, leNiveau * 2 + 3).value = lers("name")
                    APP.Cells(laLigne, 21).value = lers("DesOP")
                    APP.Cells(laLigne, 24).value = Sql2num(lers("WORK_TIME_HC")) * laQte
                    APP.Cells(laLigne, 25).value = Sql2num(lers("SETUP_TIME_HC"))
                    APP.Cells(laLigne, 26).value = Sql2num(lers("CTRL_TIME_HC"))
                    APP.Cells(laLigne, 28).value = Sql2num(lers("WORK_TIME_HC")) * laQte * Sql2num(lers("RATE_CYCLE_COST"))
                    APP.Cells(laLigne, 29).value = Sql2num(lers("SETUP_TIME_HC")) * Sql2num(lers("RATE_PREPARE_COST"))
                    APP.Cells(laLigne, 30).value = Sql2num(lers("CTRL_TIME_HC")) * Sql2num(lers("RATE_CONTROL_COST"))

                End If
                If leNiveau > 0 Then APP.Range(APP.Cells(laLigne, leNiveau * 2 + 2), APP.Cells(laLigne, 22)).Interior.Color = RGB(230 - leNiveau * 10, 230 - leNiveau * 10, 230 - leNiveau * 10)
                laLigne += 1
            End While
            lers.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try


    End Sub

    Sub AfficheObjet(lObjetID As String)
        Dim sSql As String
        Dim lers As OleDb.OleDbDataReader
        Try
            sSql = "select o.type,t.id_item,O.id_routing " _
            & " from toppdm.object O " _
            & " Left join TOPPDM.TREE_BOM T on T.ID_OBJECT=O.ID_OBJECT And O.TYpe=48" _
            & " where o.id_object = '" & lObjetID & "'"

            lers = SqlLit(sSql, conSqlTops)
            While lers.Read
                If Sql2num(lers("type")) = 48 Then afficheNomenclature(lers("id_item"), 0, 1)
                AfficheGamme(lers("ID_ROUTING"), 0, 1)
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
        APP.Cells(1, 1).value = Me.gListe.Rows(e.RowIndex).Cells("Article").Value
        APP.Cells(1, 1).Font.Color = RGB(192, 0, 0)
        APP.Cells(1, 1).Font.size = 18

        'Ligne d'entete
        laLigne = 7
        APP.Cells(laLigne, 1).value = "N"
        APP.Cells(laLigne, 2).value = "Ph"
        APP.Cells(laLigne, 3).value = "Composant/Opération"
        APP.Cells(laLigne, 20).value = "Qté"
        APP.Cells(laLigne, 21).value = "Désignation"
        APP.Cells(laLigne, 22).value = "Sous-Trait"
        APP.Cells(laLigne, 23).value = "Cout Mat/U"
        APP.Cells(laLigne, 24).value = "Tps Prod/U"
        APP.Cells(laLigne, 25).value = "Tps Rég."
        APP.Cells(laLigne, 26).value = "Tps Ctrl"
        APP.Cells(laLigne, 27).value = "Mt Mat"
        APP.Cells(laLigne, 28).value = "Mt Prod/U"
        APP.Cells(laLigne, 29).value = "Mt Rég."
        APP.Cells(laLigne, 30).value = "Mt Ctrl"
        APP.Range("A" & laLigne & ":AD" & laLigne).Interior.Color = RGB(192, 0, 0)
        APP.Range("A" & laLigne & ":AD" & laLigne).Font.Color = RGB(255, 255, 255)
        APP.Range("A" & laLigne & ":AD" & laLigne).Font.Bold = True

        'Affichage Détail
        laLigne += 1
        '        Call afficheNomenclature(Me.gListe.Rows(e.RowIndex).Cells("ObjectId").Value, 0, 1)
        Call AfficheObjet(Me.gListe.Rows(e.RowIndex).Cells("ObjectId").Value)

        'Mise en forme finale

        APP.Columns((NivMax + 1) * 2 + 1).EntireColumn.AutoFit
        For i = (NivMax + 1) * 2 + 2 To 19
            APP.Columns(i).ColumnWidth = 0
        Next
    End Sub

    Private Sub gListe_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles gListe.CellContentClick

    End Sub
End Class
