Imports Umbraco
Imports Umbraco.NodeFactory
Imports Common


Public Class AddThisTemplateA
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Determine which view to display
        Select Case Node.GetCurrent.NodeTypeAlias
            Case aliases.blogEntry, aliases.lockedBlogEntry
                phHorizontalView.Visible = True
            Case Else
                phVerticalView.Visible = True
        End Select
    End Sub

End Class