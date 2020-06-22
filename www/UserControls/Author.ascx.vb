Imports umbraco
Imports umbraco.NodeFactory
Imports Common


Public Class Author
    Inherits System.Web.Mvc.ViewUserControl


#Region "Properties"
#End Region


#Region "Handles"
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Instantiate variables
        Dim thisNode As Node = Node.GetCurrent

        'Obtain page title
        ltrlAuthorName.Text = thisNode.Name

        'Obtain author's email
        If thisNode.HasProperty(nodeProperties.email) Then
            hlnkAuthorEmail.Text = thisNode.GetProperty(nodeProperties.email).Value
            hlnkAuthorEmail.NavigateUrl += thisNode.GetProperty(nodeProperties.email).Value
        Else
            pnlAuthorEmail.Visible = False
        End If

        'Obtain author's image
        If thisNode.HasProperty("featuredImage") Then
            imgAuthor.ImageUrl = getMediaURL(thisNode.GetProperty("featuredImage").Value, crops.ListItemSquared)
            imgAuthor.AlternateText = thisNode.Name
        Else
            imgAuthor.Visible = False
        End If

        'Assign Author name to Read More
        hlnkReadMorePosts_byAuthor.Text += thisNode.Name
        'hlnkReadMorePosts_byAuthor.NavigateUrl = New Node(siteNodes.Blog).NiceUrl & "?author=" & thisNode.Id  '+ thisNode.Name.Replace(" ", "+")
        hlnkReadMorePosts_byAuthor.Attributes.Add("title", thisNode.Name)

    End Sub
#End Region


#Region "Methods"
#End Region

End Class