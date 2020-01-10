
Public Class FrmParam

    Private Sub bOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bOK.Click
        My.Settings.Save()
        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub bAnnul_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bAnnul.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub FrmParam_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        My.Settings.Reload()
        pGrid1.SelectedObject = My.Settings
        Me.Text = "Parameters " & My.Application.Info.Version.ToString
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If ConnexionTest(My.Settings.ConStrTops) Then
            MsgBox("Connexion OK")
        Else
            MsgBox("Erreur connexion")

        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If ConnexionTest(My.Settings.ConStrSilog) Then
            MsgBox("Connexion OK")
        Else
            MsgBox("Erreur connexion")

        End If
    End Sub
End Class