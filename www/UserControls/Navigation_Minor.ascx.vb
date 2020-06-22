Imports Examine
Imports Common
Imports UmbracoExamine
Imports Umbraco
Imports Umbraco.Web
Imports Umbraco.Core.Models
Imports Umbraco.Core
Imports Umbraco.NodeFactory


Public Class Navigation_Minor
    Inherits System.Web.Mvc.ViewUserControl(Of IPublishedContent)

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Dim umbracoHelper = New umbraco.Web.UmbracoHelper(UmbracoContext.Current)
            Dim ipCurrentPg As IPublishedContent = Model
            Dim ipRoot = umbracoHelper.TypedContent(Common.getHomeNodeId(ipCurrentPg.Id))

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
            'Dim ipRoot As umbraco.Core.Models.IPublishedContent = umbracoHelper.TypedContentAtRoot().FirstOrDefault()


            'lblMsg.Text = "Msg: " & Model.Id








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
                If (lstIDs(1) = ipRoot.Id) Then
                    'Instantiate variables
                    Dim href As New HyperLink
                    Dim pnl As New Panel
                    'build link and add to list
                    pnl.Controls.Add(New LiteralControl(thisNode.Name))
                    If thisNode.DocumentTypeAlias = aliases.externalLink Then
                        href.NavigateUrl = thisNode.GetPropertyValue(Of String)(nodeProperties.externalUrl)
                    Else
                        href.NavigateUrl = thisNode.Url
                    End If
                    href.Controls.Add(pnl)
                    pnlMinorNavLinks.Controls.Add(href)
                End If
            Next

            'Add link to search page with parameter.
            'hfldSearchPg.Value = New Node(siteNodes.Search).NiceUrl
            Select Case ipRoot.Id
                Case siteNodes.Home
                    hfldSearchPg.Value = New Node(siteNodes.Search).NiceUrl
                Case siteNodes.EducationFoundation
                    hfldSearchPg.Value = New Node(siteNodes.Search_EF).NiceUrl
                Case siteNodes.HUPAC
                    hfldSearchPg.Value = New Node(siteNodes.Search_Hupac).NiceUrl
            End Select

        Catch ex As Exception
            'Save error to umbraco
            Dim sb As New StringBuilder
            sb.AppendLine("Navigation_Minor.vb | Load()")
            SaveErrorMessage(ex, sb, Me.GetType())
        End Try
    End Sub

End Class