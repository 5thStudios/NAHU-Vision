Imports Examine
Imports Common
Imports UmbracoExamine

Imports Umbraco
Imports Umbraco.Web
Imports Umbraco.NodeFactory
Imports Umbraco.Core.Models

Public Class Footer
    Inherits System.Web.Mvc.ViewUserControl(Of IPublishedContent)

#Region "Properties"
#End Region

#Region "Handles"

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'Response.Write("<h1 style='color:red;'>LOAD...</h1>")

        If Not IsPostBack Then
            'adds current year to footer copyright
            currentYear()
            footerNav()
            obtainSocialIcons()

        End If

    End Sub
#End Region

#Region "Methods"
    Private Sub footerNav()
        Try

            '=========================================================================================
            ''Instantiate search provider and criteria
            ''Dim searchProvider As Providers.BaseSearchProvider = Examine.ExamineManager.Instance.SearchProviderCollection(searchIndex.NavigationSearcher)
            'Dim searchProvider As Providers.BaseSearchProvider = Examine.ExamineManager.Instance.DefaultSearchProvider
            'Dim searchCriteria As SearchCriteria.ISearchCriteria = searchProvider.CreateSearchCriteria()

            ''Obtain all marked items sorted by name
            'Dim query = searchCriteria.Field(nodeProperties.showInEyebrowNavigation, CInt(True)).[And]().OrderBy(nodeProperties.nodeName)
            'Dim searchResults = searchProvider.Search(query.Compile())

            ''Loop thru each id and build link
            'For Each result As Examine.SearchResult In searchResults
            '    'Instantiate variables
            '    Dim thisNode As New Node(result.Id)
            '=========================================================================================
            Dim umbracoHelper = New Umbraco.Web.UmbracoHelper(UmbracoContext.Current)
            'Dim ipRoot As Umbraco.Core.Models.IPublishedContent = umbracoHelper.TypedContentAtRoot().FirstOrDefault()
            Dim ipCurrentPg As IPublishedContent = Model
            Dim ipRoot = umbracoHelper.TypedContent(Common.getHomeNodeId(ipCurrentPg.Id))

            Dim LstIgnoreTypes As List(Of String) = New List(Of String)()
            LstIgnoreTypes.Add(Common.aliases.author)
            LstIgnoreTypes.Add(Common.aliases.authors)
            LstIgnoreTypes.Add(Common.aliases.banner)
            LstIgnoreTypes.Add(Common.aliases.bannerlink)
            LstIgnoreTypes.Add(Common.aliases.chapter)
            LstIgnoreTypes.Add(Common.aliases.chapterAffiliation)
            LstIgnoreTypes.Add(Common.aliases.corrected)
            LstIgnoreTypes.Add(Common.aliases.dataLayer)
            LstIgnoreTypes.Add(Common.aliases.errors)
            LstIgnoreTypes.Add(Common.aliases.errorMessage)
            LstIgnoreTypes.Add(Common.aliases.externalBannerlink)
            LstIgnoreTypes.Add(Common.aliases.externalQuicklink)
            LstIgnoreTypes.Add(Common.aliases.eventTypes)
            LstIgnoreTypes.Add(Common.aliases.eventType)
            LstIgnoreTypes.Add(Common.aliases.ignore)
            LstIgnoreTypes.Add(Common.aliases.internalBannerlink)
            LstIgnoreTypes.Add(Common.aliases.internalQuicklink)
            LstIgnoreTypes.Add(Common.aliases.quicklinks)
            LstIgnoreTypes.Add(Common.aliases.rotatingBanners)
            LstIgnoreTypes.Add(Common.aliases.sponsors)
            LstIgnoreTypes.Add(Common.aliases.sponsor)
            LstIgnoreTypes.Add(Common.aliases.tags)
            LstIgnoreTypes.Add(Common.aliases.tag)
            LstIgnoreTypes.Add(Common.aliases.toAddress)


            For Each thisNode In ipRoot.Descendants().Where(Function(x) x.GetPropertyValue(Of Boolean)(Common.nodeProperties.showInEyebrowNavigation) = True) '.OrderBy(nodeProperties.nodeName)
                'Skip ignored doctypes
                If LstIgnoreTypes.Contains(thisNode.DocumentTypeAlias) Then Continue For




                Dim lstIDs As List(Of Integer)

                'Obtain path list
                lstIDs = thisNode.Path.Split(",").ToList.ConvertAll(Function(str) Int32.Parse(str))

                'Add to list only if the node's level does not exceed the max level and is part of the main site.
                If (lstIDs(1) = getHomeNodeId(Node.getCurrentNodeId)) Then
                    'Instantiate variables
                    Dim href As New HyperLink
                    Dim pnl As New Panel
                    'build link and add to list
                    pnl.Controls.Add(New LiteralControl(thisNode.Name))
                    href.NavigateUrl = thisNode.NiceUrl
                    href.Controls.Add(pnl)
                    pnlMinorNavLinks.Controls.Add(href)
                End If
            Next
        Catch ex As Exception
            'Save error to umbraco
            Dim sb As New StringBuilder
            sb.AppendLine("Navigation_Minor.vb | Load()")
            SaveErrorMessage(ex, sb, Me.GetType())
        End Try
    End Sub

    Private Sub currentYear()
        ltrlYear.Text = Date.Now.Year.ToString
    End Sub

    Private Sub obtainSocialIcons()
        'Instantiate variable

        Dim homeNode As Node = New Node(siteNodes.Home)

        'Display social icons
        If homeNode.HasProperty(nodeProperties.facebookFollowUSURL) Then
            hlnkFacebook.NavigateUrl = homeNode.GetProperty(nodeProperties.facebookFollowUSURL).Value
            hlnkFacebook_Mbl.NavigateUrl = homeNode.GetProperty(nodeProperties.facebookFollowUSURL).Value
            hlnkFacebook.Visible = True
            hlnkFacebook_Mbl.Visible = True
        End If
        If homeNode.HasProperty(nodeProperties.youTubeFollowUSURL) Then
            hlnkYouTube.NavigateUrl = homeNode.GetProperty(nodeProperties.youTubeFollowUSURL).Value
            hlnkYouTube_Mbl.NavigateUrl = homeNode.GetProperty(nodeProperties.youTubeFollowUSURL).Value
            hlnkYouTube.Visible = True
            hlnkYouTube_Mbl.Visible = True
        End If
        If homeNode.HasProperty(nodeProperties.linkedInFollowUSURL) Then
            hlnkLinkedIn.NavigateUrl = homeNode.GetProperty(nodeProperties.linkedInFollowUSURL).Value
            hlnkLinkedIn_Mbl.NavigateUrl = homeNode.GetProperty(nodeProperties.linkedInFollowUSURL).Value
            hlnkLinkedIn.Visible = True
            hlnkLinkedIn_Mbl.Visible = True
        End If
        If homeNode.HasProperty(nodeProperties.twitterFollowUSURL) Then
            hlnkTwitter.NavigateUrl = homeNode.GetProperty(nodeProperties.twitterFollowUSURL).Value
            hlnkTwitter_Mbl.NavigateUrl = homeNode.GetProperty(nodeProperties.twitterFollowUSURL).Value
            hlnkTwitter.Visible = True
            hlnkTwitter_Mbl.Visible = True
        End If
        If homeNode.HasProperty(nodeProperties.b2BFollowUSURL) Then
            hlnkB2B.NavigateUrl = homeNode.GetProperty(nodeProperties.b2BFollowUSURL).Value
            hlnkB2B_Mbl.NavigateUrl = homeNode.GetProperty(nodeProperties.b2BFollowUSURL).Value
            hlnkB2B.Visible = True
            hlnkB2B_Mbl.Visible = True
        End If

    End Sub
#End Region

End Class