Option Explicit On
Imports System.IO
Imports Microsoft.Office.Tools.Ribbon
Imports System.Windows.Forms
Imports Office = Microsoft.Office.Tools
Imports Excel = Microsoft.Office.Interop.Excel

Public Class rDirTech


    Private Sub BConnect_Click(sender As System.Object, e As Microsoft.Office.Tools.Ribbon.RibbonControlEventArgs) Handles BConnect.Click

        Dim ctp As Office.CustomTaskPane
        Dim w = Globals.CompoXLCompta.Application.ActiveWindow
        Dim PaneTrouve As Boolean = False
        Dim PaneName As String = "Gammes Silog"
        For Each pane In Globals.CompoXLCompta.CustomTaskPanes
            Try
                If pane.Window.Hwnd = w.Hwnd And pane.Title = PaneName Then
                    pane.Visible = Not pane.Visible
                    PaneTrouve = True
                End If
            Catch
            End Try
        Next

        If PaneTrouve = False Then
            ctp = Globals.CompoXLCompta.CustomTaskPanes.Add(New pGammeS, PaneName)
            ctp.Visible = True
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As RibbonControlEventArgs) Handles Button1.Click

        Dim ctp As Office.CustomTaskPane
        Dim w = Globals.CompoXLCompta.Application.ActiveWindow
        Dim PaneTrouve As Boolean = False
        Dim PaneName As String = "Gammes TopSolid"

        For Each pane In Globals.CompoXLCompta.CustomTaskPanes
            Try
                If pane.Window.Hwnd = w.Hwnd And pane.Title = PaneName Then
                    pane.Visible = Not pane.Visible
                    PaneTrouve = True
                End If
            Catch
            End Try
        Next

        If PaneTrouve = False Then
            ctp = Globals.CompoXLCompta.CustomTaskPanes.Add(New pGammeT, PaneName)
            ctp.Visible = True
        End If
    End Sub
End Class
