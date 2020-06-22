Imports Umbraco.NodeFactory
Imports Common

Public Class SideNav
    Inherits System.Web.Mvc.ViewUserControl


#Region "Properties"
#End Region

#Region "Handles"
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Generate side menu
        Dim sideNav As HtmlGenericControl = generateSideNav(Node.getCurrentNodeId)
        If Not IsNothing(sideNav) Then phSideNav.Controls.Add(sideNav)
    End Sub
#End Region

#Region "Methods"
#End Region

End Class