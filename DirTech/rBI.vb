Option Explicit On
Imports System.IO
Imports Microsoft.Office.Tools.Ribbon
Imports System.Windows.Forms
Imports Office = Microsoft.Office.Tools
Imports Excel = Microsoft.Office.Interop.Excel

Public Class rCompta


    Private Sub BConnect_Click(sender As System.Object, e As Microsoft.Office.Tools.Ribbon.RibbonControlEventArgs) Handles BConnect.Click

        Dim ctp As Office.CustomTaskPane
        Dim w = Globals.CompoXLCompta.Application.ActiveWindow
        Dim PaneTrouve As Boolean = False
        Dim PaneName As String = "BI-Cube"

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
            ctp = Globals.CompoXLCompta.CustomTaskPanes.Add(New pTVA, PaneName)
            ctp.Visible = True
        End If
    End Sub



End Class
