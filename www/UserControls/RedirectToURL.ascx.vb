Imports Umbraco.NodeFactory
Imports Common


Public Class RedirectToURL
    Inherits System.Web.Mvc.ViewUserControl


#Region "Properties"
#End Region

#Region "Handles"
    'Private Sub Masterpages_Redirect_To_Init(sender As Object, e As EventArgs) Handles Me.Init
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Obtain current node
        Dim thisNode As Node = Node.GetCurrent

        Select Case thisNode.NodeTypeAlias

            Case aliases.internalLink
                'Obtain node id from redirect field.
                Dim nodeId As Integer = getIdFromGuid_byType(thisNode.GetProperty(nodeProperties.linkTo).Value, Umbraco.Core.Models.UmbracoObjectTypes.Document)

                'Do a 301 redirect to new location.
                Response.Status = "301 Moved Permanently"
                Response.AddHeader("Location", New Node(nodeId).NiceUrl)

            Case aliases.externalLink
                'Do a 301 redirect to new location.
                Response.Status = "301 Moved Permanently"
                Response.AddHeader("Location", thisNode.GetProperty(nodeProperties.externalUrl).Value)

            Case aliases.urlEntry
                'Do a 301 redirect to new location.
                Response.Status = "301 Moved Permanently"
                Response.AddHeader("Location", thisNode.GetProperty(nodeProperties.externalUrl).Value)
        End Select
    End Sub
#End Region

#Region "Methods"
#End Region

End Class