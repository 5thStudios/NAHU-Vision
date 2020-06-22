Imports Umbraco.NodeFactory

Public Class RedirectToParent
    Inherits System.Web.Mvc.ViewUserControl


#Region "Properties"
#End Region

#Region "Handles"
    'Private Sub Masterpages_Redirect_To_Init(sender As Object, e As EventArgs) Handles Me.Init
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Obtain current node
        Dim thisNode As Node = Node.GetCurrent.Parent


        'Do a 301 redirect to new location.
        Response.Status = "301 Moved Permanently"
        Response.AddHeader("Location", thisNode.NiceUrl)
    End Sub
#End Region

#Region "Methods"
#End Region

End Class