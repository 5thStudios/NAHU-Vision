Imports Examine
Imports Common
Imports UmbracoExamine
Imports System.Collections.Generic
Imports Umbraco
Imports Umbraco.Web
Imports Umbraco.Core.Models
Imports Umbraco.Core
Imports Umbraco.NodeFactory

Public Class Navigation_Main
    Inherits System.Web.Mvc.ViewUserControl(Of IPublishedContent)


#Region "properties"
    Private maxLevel As Int16 = 4
    Private topLevel As Int16 = 3
    Private childLvl As Int16 = 4
#End Region


#Region "Handles"
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            ''TEMP: USE TO REPUBLISH ALL IMAGES [JF- 2019-06-26]
            'Response.Write("<div style='color:red;'>Images repulished: " & republishAllImages().ToString & "</div>")


            'Instantiate variables
            Dim homeNodeId As Integer = getHomeNodeId(Node.getCurrentNodeId)
            Dim homeNode As Node = New Node(homeNodeId)
            Dim uHelper As UmbracoHelper = New Umbraco.Web.UmbracoHelper(Umbraco.Web.UmbracoContext.Current)
            Dim ipContent As IPublishedContent = uHelper.TypedContent(homeNodeId)

            'Add data to page
            If homeNode.HasProperty(nodeProperties.siteLogo) Then
                imgLogo.ImageUrl = getMediaURL(homeNode.GetProperty(nodeProperties.siteLogo).Value)
                imgLogo.AlternateText = getMediaName(homeNode.GetProperty(nodeProperties.siteLogo).Value)
                hlnkLogo.NavigateUrl = homeNode.NiceUrl
            End If



            Dim ipJoinNow As IPublishedContent = ipContent.GetPropertyValue(Of IPublishedContent)(nodeProperties.joinNowLink)
            If IsNothing(ipJoinNow) Then
                'Hide button if page is disabled
                hlnkJoinNahu_Mbl.Visible = False
                hlnkJoinNow.Visible = False
            Else
                Select Case homeNode.NodeTypeAlias
                    Case aliases.home
                        If ipContent.HasValue(nodeProperties.joinNowLink) Then
                            hlnkJoinNahu_Mbl.NavigateUrl = ipJoinNow.Url
                            hlnkJoinNow.NavigateUrl = hlnkJoinNahu_Mbl.NavigateUrl
                        End If

                    Case aliases.homeMicrosite
                        If ipContent.HasValue(nodeProperties.callToActionLink) AndAlso ipContent.HasValue(nodeProperties.callToActionText) Then
                            hlnkJoinNow.NavigateUrl = ipContent.GetPropertyValue(Of IPublishedContent)(nodeProperties.callToActionLink).Url
                            hlnkJoinNow.Text = ipContent.GetPropertyValue(Of String)(nodeProperties.callToActionText)

                            hlnkJoinNahu_Mbl.NavigateUrl = hlnkJoinNow.NavigateUrl
                            hlnkJoinNahu_Mbl.Text = hlnkJoinNow.Text
                        End If
                End Select
            End If


            'hlnkSearch_Mbl.NavigateUrl = New Node(siteNodes.Search).NiceUrl
            Select Case getHomeNodeId(Node.getCurrentNodeId)
                Case siteNodes.Home
                    hlnkSearch_Mbl.NavigateUrl = New Node(siteNodes.Search).NiceUrl
                Case siteNodes.EducationFoundation
                    hlnkSearch_Mbl.NavigateUrl = New Node(siteNodes.Search_EF).NiceUrl
                Case siteNodes.HUPAC
                    hlnkSearch_Mbl.NavigateUrl = New Node(siteNodes.Search_Hupac).NiceUrl
            End Select

            If homeNode.HasProperty(nodeProperties.siteLogo) Then
                imgLogo_Mbl.ImageUrl = getMediaURL(homeNode.GetProperty(nodeProperties.siteLogo).Value)
                imgLogo_Mbl.AlternateText = getMediaName(homeNode.GetProperty(nodeProperties.siteLogo).Value)
                hlnkLogo_Mbl.NavigateUrl = homeNode.NiceUrl
            End If

            'Create navigations
            createMainNav(homeNodeId)
            createMegaNav(homeNodeId)


        Catch ex As Exception
            'Save error to umbraco
            Dim sb As New StringBuilder
            sb.AppendLine("Navigation_Main.vb | Load()")
            SaveErrorMessage(ex, sb, Me.GetType())


            Response.Write("<div style='color:red;'>" & ex.ToString & "</div>")
        End Try
    End Sub
#End Region


#Region "Methods"
    Private Sub createMainNav(ByVal homeNodeId As Integer)

        '=========================================================================================
        ''Instantiate search provider and criteria
        ''Dim searchProvider As Providers.BaseSearchProvider = Examine.ExamineManager.Instance.SearchProviderCollection(searchIndex.NavigationSearcher)
        'Dim searchProvider As Providers.BaseSearchProvider = Examine.ExamineManager.Instance.DefaultSearchProvider
        'Dim searchCriteria As SearchCriteria.ISearchCriteria = searchProvider.CreateSearchCriteria()

        ''Obtain all marked items
        'Dim query = searchCriteria.Field(nodeProperties.showInNavigation, CInt(True)) '.[And]().OrderBy(nodeProperties.sortOrder & "[Type=INT]")
        'Dim searchResults = searchProvider.Search(query.Compile())

        ''Instantiate first list
        'Dim lstNavLink As New List(Of DataLayer.NavLink)

        ''Loop thru each id and build link list
        'For Each result As Examine.SearchResult In searchResults
        '    Try
        '        'Instantiate variables
        '        Dim thisNode As New Node(result.Id)
        '=========================================================================================

        'Dim ipRoot As Umbraco.Core.Models.IPublishedContent = umbracoHelper.TypedContentAtRoot().FirstOrDefault()
        Dim umbracoHelper = New Umbraco.Web.UmbracoHelper(UmbracoContext.Current)
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

        'Instantiate first list
        Dim lstNavLink As New List(Of DataLayer.NavLink)


        For Each thisNode In ipRoot.Descendants().Where(Function(x) x.GetPropertyValue(Of Boolean)(Common.nodeProperties.showInNavigation) = True)
            Try
                'Skip ignored doctypes
                If LstIgnoreTypes.Contains(thisNode.DocumentTypeAlias) Then Continue For

                Dim lstIDs As List(Of Integer)

                'Obtain path list
                lstIDs = thisNode.Path.Split(",").ToList.ConvertAll(Function(str) Int32.Parse(str))

                'Add to list only if the node's level does not exceed the max level and is part of the main site.
                If (lstIDs.Count <= maxLevel) AndAlso (lstIDs(1) = homeNodeId) Then
                    'Instantiate variables
                    Dim navLink As New DataLayer.NavLink

                    'Add data to class
                    navLink.lstPathIDs = lstIDs
                    navLink.level = navLink.lstPathIDs.Count
                    navLink.id = thisNode.Id
                    navLink.parentId = thisNode.Parent.Id
                    navLink.name = thisNode.Name
                    navLink.path = thisNode.Path
                    navLink.url = thisNode.NiceUrl
                    navLink.sortOrder = thisNode.SortOrder
                    navLink.externalLink = thisNode.DocumentTypeAlias.Equals(aliases.externalLink)

                    'Add class to list
                    lstNavLink.Add(navLink)
                End If
            Catch ex As Exception
                'Save error to umbraco
                Dim sb As New StringBuilder
                sb.AppendLine("Navigation_Main.vb | createMainNav()")
                sb.AppendLine("result.Id: " & thisNode.Id.ToString)
                sb.AppendLine("result.Path: " & New Node(thisNode.Id).Path)
                sb.AppendLine("result.Name: " & New Node(thisNode.Id).Name)
                SaveErrorMessage(ex, sb, Me.GetType())
            End Try

        Next

        'Instantiate final list of navigations
        Dim lstSortedNavLink As New List(Of DataLayer.NavLink)

        'Sort list by level and sort order.
        Dim lstTopLevel = (From c In lstNavLink Order By c.sortOrder Where c.level = topLevel Select c).ToList
        For Each lnk As DataLayer.NavLink In lstTopLevel
            lstSortedNavLink.Add(lnk)
            Dim lstChildLvl = (From d In lstNavLink Order By d.sortOrder Where d.level = childLvl AndAlso d.parentId = lnk.id Select d).ToList
            For Each childLnk As DataLayer.NavLink In lstChildLvl
                lstSortedNavLink.Add(childLnk)
            Next
        Next

        'gv1.DataSource = lstSortedNavLink
        'gv1.DataBind()


        'Create main menu
        generateMainMenu(lstSortedNavLink)
    End Sub
    Private Sub generateMainMenu(ByRef lstSortedNavLink As List(Of DataLayer.NavLink))
        'Instantiate variables
        Dim ul_parent = New HtmlGenericControl("ul")
        Dim li_parent = New HtmlGenericControl("li")
        Dim ul_secondary = New HtmlGenericControl("ul")
        Dim li_secondary = New HtmlGenericControl("li")
        Dim hlnk As HyperLink
        Dim parentLvl As Boolean = True


        'Loop thru list of navigation links
        For Each navLink As DataLayer.NavLink In lstSortedNavLink
            Select Case navLink.level
                Case 3
                    If parentLvl = False Then
                        parentLvl = True
                    End If
                    'Instantiate variables
                    li_parent = New HtmlGenericControl("li")
                    hlnk = New HyperLink
                    'Add to parent controls
                    li_parent.Controls.Add(hlnk)
                    ul_parent.Controls.Add(li_parent)
                    'Add data to controls
                    hlnk.Text = navLink.name
                    hlnk.NavigateUrl = navLink.url
                    If navLink.externalLink Then hlnk.Target = "_blank"
                Case 4
                    If parentLvl Then
                        parentLvl = False
                        'Instantiate variable and attach to parent
                        ul_secondary = New HtmlGenericControl("ul")
                        li_parent.Controls.Add(ul_secondary)
                    End If
                    'Instantiate variables
                    li_secondary = New HtmlGenericControl("li")
                    hlnk = New HyperLink
                    'Add to parent controls
                    li_secondary.Controls.Add(hlnk)
                    ul_secondary.Controls.Add(li_secondary)
                    'Add data to controls
                    hlnk.Text = navLink.name
                    hlnk.NavigateUrl = navLink.url
                    If navLink.externalLink Then hlnk.Target = "_blank"
            End Select
        Next

        'Add all controls to placeholder
        phMainMenu.Controls.Add(ul_parent)
    End Sub
    Private Sub createMegaNav(ByVal homeNodeId As Integer)
        '=========================================================================================
        ''Instantiate search provider and criteria
        ''Dim searchProvider As Providers.BaseSearchProvider = Examine.ExamineManager.Instance.SearchProviderCollection(searchIndex.NavigationSearcher)
        'Dim searchProvider As Providers.BaseSearchProvider = Examine.ExamineManager.Instance.DefaultSearchProvider
        'Dim searchCriteria As SearchCriteria.ISearchCriteria = searchProvider.CreateSearchCriteria()

        ''Obtain all marked items
        'Dim query = searchCriteria.Field(nodeProperties.showInMegamenu, CInt(True)) '.[And]().OrderBy(nodeProperties.sortOrder & "[Type=INT]")
        'Dim searchResults = searchProvider.Search(query.Compile())

        ''Instantiate first list
        'Dim lstNavLink As New List(Of DataLayer.NavLink)

        ''Loop thru each id and build link list
        'For Each result As Examine.SearchResult In searchResults
        '    'Instantiate variables
        '    Dim thisNode As New Node(result.Id)
        '=========================================================================================
        'Dim umbracoHelper = New Umbraco.Web.UmbracoHelper(UmbracoContext.Current)
        'Dim ipRoot As Umbraco.Core.Models.IPublishedContent = umbracoHelper.TypedContentAtRoot().FirstOrDefault()

        Dim umbracoHelper = New Umbraco.Web.UmbracoHelper(UmbracoContext.Current)
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

        'Instantiate first list
        Dim lstNavLink As New List(Of DataLayer.NavLink)

        For Each thisNode In ipRoot.Descendants().Where(Function(x) x.GetPropertyValue(Of Boolean)(Common.nodeProperties.showInMegamenu) = True)
            Dim lstIDs As List(Of Integer)

            Try
                'Obtain path list
                lstIDs = thisNode.Path.Split(",").ToList.ConvertAll(Function(str) Int32.Parse(str))

                'Add to list only if the node's level does not exceed the max level and is part of the main site.
                If (lstIDs.Count <= maxLevel) AndAlso (lstIDs(1) = getHomeNodeId(Node.getCurrentNodeId)) Then
                    'Instantiate variables
                    Dim navLink As New DataLayer.NavLink

                    'Add data to class
                    navLink.lstPathIDs = lstIDs
                    navLink.level = navLink.lstPathIDs.Count
                    navLink.id = thisNode.Id
                    navLink.parentId = thisNode.Parent.Id
                    navLink.name = thisNode.Name
                    navLink.path = thisNode.Path
                    navLink.url = thisNode.NiceUrl
                    navLink.sortOrder = thisNode.SortOrder
                    navLink.externalLink = thisNode.DocumentTypeAlias.Equals(aliases.externalLink)

                    'Add class to list
                    lstNavLink.Add(navLink)
                End If
            Catch ex As Exception
                'Save error to umbraco
                Dim sb As New StringBuilder
                sb.AppendLine("Navigation_Main.vb | createMainNav()")
                sb.AppendLine("Id: " & thisNode.Id.ToString)
                sb.AppendLine("Path: " & New Node(thisNode.Id).Path)
                sb.AppendLine("Name: " & New Node(thisNode.Id).Name)
                SaveErrorMessage(ex, sb, Me.GetType())
            End Try

        Next

        'Instantiate final list of navigations
        Dim lstSortedNavLink As New List(Of DataLayer.NavLink)

        'Sort list by level and sort order.
        Dim lstTopLevel = (From c In lstNavLink Order By c.sortOrder Where c.level = topLevel Select c).ToList
        For Each lnk As DataLayer.NavLink In lstTopLevel
            lstSortedNavLink.Add(lnk)
            Dim lstChildLvl = (From d In lstNavLink Order By d.sortOrder Where d.level = childLvl AndAlso d.parentId = lnk.id Select d).ToList
            For Each childLnk As DataLayer.NavLink In lstChildLvl
                lstSortedNavLink.Add(childLnk)
            Next
        Next

        'Mark all records that have children
        MarkParentNodes(lstSortedNavLink)

        'Create megamenu and mobile menu
        generateMegaMenu(lstSortedNavLink)
        generateMblMenu(lstSortedNavLink)
    End Sub
    Private Sub generateMegaMenu(ByRef lstSortedNavLink As List(Of DataLayer.NavLink))
        'Instantiate variables
        Dim li = New HtmlGenericControl("li")
        Dim hlnk As HyperLink
        Dim pnl As Panel

        'Loop thru list of navigation links
        For Each navLink As DataLayer.NavLink In lstSortedNavLink
            Select Case navLink.level
                Case 3
                    'Instantiate variables
                    li = New HtmlGenericControl("li")
                    hlnk = New HyperLink
                    pnl = New Panel
                    'Add to parent controls
                    pnl.Controls.Add(hlnk)
                    li.Controls.Add(pnl)
                    phMegaMenu.Controls.Add(li)
                    'Add data to controls
                    hlnk.Text = navLink.name
                    hlnk.NavigateUrl = navLink.url
                    If navLink.externalLink Then hlnk.Target = "_blank"
                Case 4
                    'Instantiate variables
                    hlnk = New HyperLink
                    pnl = New Panel
                    'Add to parent controls
                    pnl.Controls.Add(hlnk)
                    li.Controls.Add(pnl)
                    'Add data to controls
                    hlnk.Text = navLink.name
                    hlnk.NavigateUrl = navLink.url
                    If navLink.externalLink Then hlnk.Target = "_blank"
            End Select
        Next
    End Sub
    Private Sub generateMblMenu(ByRef lstSortedNavLink As List(Of DataLayer.NavLink))
        'Instantiate variables
        Dim ul = New HtmlGenericControl("ul")
        Dim li = New HtmlGenericControl("li")
        Dim lbl = New HtmlGenericControl("label")
        Dim hlnk As HyperLink
        Dim header3 As Boolean = True
        Dim header4 As Boolean = True

        '====================================================
        'Build link to home page
        li = New HtmlGenericControl("li")
        hlnk = New HyperLink
        'Add to parent controls
        li.Controls.Add(hlnk)
        phMblNav.Controls.Add(li)
        'Add data to controls
        hlnk.Text = "Home"
        hlnk.NavigateUrl = New Node(siteNodes.Home).NiceUrl
        '====================================================

        'Loop thru list of navigation links
        For Each navLink As DataLayer.NavLink In lstSortedNavLink
            Select Case navLink.level
                Case 3
                    'Instantiate variables
                    li = New HtmlGenericControl("li")
                    hlnk = New HyperLink

                    'Add to parent controls
                    li.Controls.Add(hlnk)
                    phMblNav.Controls.Add(li)

                    'Does link have children
                    If navLink.hasChildren Then
                        'Add submenu class
                        li.Attributes.Add("class", "has-submenu")
                        'Add data to controls
                        hlnk.Text = navLink.name
                        hlnk.Attributes.Add("href", "#")
                        If navLink.externalLink Then hlnk.Target = "_blank"
                        'Add submenu
                        ul = New HtmlGenericControl("ul")
                        ul.Attributes.Add("class", "right-submenu")
                        li.Controls.Add(ul)

                        'Add back button to ul
                        '========================================
                        'Instantiate variables
                        li = New HtmlGenericControl("li")
                        hlnk = New HyperLink
                        'Add back class
                        li.Attributes.Add("class", "back")
                        'Add data to controls
                        hlnk.Attributes.Add("href", "#")
                        hlnk.Text = "Back"
                        If navLink.externalLink Then hlnk.Target = "_blank"
                        'Add control to parent
                        li.Controls.Add(hlnk)
                        ul.Controls.Add(li)


                        'Add header label to ul
                        '========================================
                        'Instantiate variables
                        li = New HtmlGenericControl("li")
                        lbl = New HtmlGenericControl("label")
                        'Add text and add to controls
                        lbl.InnerText = navLink.name
                        li.Controls.Add(lbl)
                        ul.Controls.Add(li)

                        'Add landing button to ul
                        '========================================
                        'Instantiate variables
                        li = New HtmlGenericControl("li")
                        hlnk = New HyperLink
                        'Add data to controls
                        hlnk.NavigateUrl = navLink.url
                        hlnk.Text = navLink.name
                        If navLink.externalLink Then hlnk.Target = "_blank"
                        'Add control to parent
                        li.Controls.Add(hlnk)
                        ul.Controls.Add(li)

                    Else
                        'Add data to controls
                        hlnk.Text = navLink.name
                        hlnk.NavigateUrl = navLink.url
                        If navLink.externalLink Then hlnk.Target = "_blank"
                    End If

                Case 4
                    'Instantiate variables
                    li = New HtmlGenericControl("li")
                    hlnk = New HyperLink
                    'Add to parent controls
                    li.Controls.Add(hlnk)
                    ul.Controls.Add(li)
                    'Add data to controls
                    hlnk.Text = navLink.name
                    hlnk.NavigateUrl = navLink.url
                    If navLink.externalLink Then hlnk.Target = "_blank"
            End Select
        Next
    End Sub
    Private Sub MarkParentNodes(ByRef lstSortedNavLink As List(Of DataLayer.NavLink))
        'Loop thru each record and get parent id
        For Each record As DataLayer.NavLink In lstSortedNavLink
            'Get parent id from record
            Dim parentId As Integer = record.parentId
            'Loop throu each record with a matching parent/child record and mark as having children
            For Each navLink In lstSortedNavLink.Where(Function(x) x.id = parentId)
                navLink.hasChildren = True
            Next
        Next
    End Sub

    Private Function republishAllImages() As Integer
        '
        Dim MediaCount As UInteger = 0
        Dim rootNodes = ApplicationContext.Current.Services.MediaService.GetRootMedia()

        For Each rootNode In rootNodes.Where(Function(x) x.Trashed = False)
            ApplicationContext.Current.Services.MediaService.Save(rootNode)
            MediaCount += 1

            For Each ancestor1 In rootNode.Descendants().Where(Function(x) x.Trashed = False)
                ApplicationContext.Current.Services.MediaService.Save(ancestor1)
                MediaCount += 1
                For Each ancestor2 In ancestor1.Descendants().Where(Function(x) x.Trashed = False)
                    ApplicationContext.Current.Services.MediaService.Save(ancestor2)
                    MediaCount += 1
                    For Each ancestor3 In ancestor2.Descendants().Where(Function(x) x.Trashed = False)
                        ApplicationContext.Current.Services.MediaService.Save(ancestor3)
                        MediaCount += 1
                        For Each ancestor4 In ancestor3.Descendants().Where(Function(x) x.Trashed = False)
                            ApplicationContext.Current.Services.MediaService.Save(ancestor4)
                            MediaCount += 1
                            For Each ancestor5 In ancestor4.Descendants().Where(Function(x) x.Trashed = False)
                                ApplicationContext.Current.Services.MediaService.Save(ancestor5)
                                MediaCount += 1
                                For Each ancestor6 In ancestor5.Descendants().Where(Function(x) x.Trashed = False)
                                    ApplicationContext.Current.Services.MediaService.Save(ancestor6)
                                    MediaCount += 1
                                    For Each ancestor7 In ancestor6.Descendants().Where(Function(x) x.Trashed = False)
                                        ApplicationContext.Current.Services.MediaService.Save(ancestor7)
                                        MediaCount += 1
                                        For Each ancestor8 In ancestor7.Descendants().Where(Function(x) x.Trashed = False)
                                            ApplicationContext.Current.Services.MediaService.Save(ancestor8)
                                            MediaCount += 1
                                        Next
                                    Next
                                Next
                            Next
                        Next
                    Next
                Next
            Next
        Next

        'MainView.SetActiveView(CompleteView)
        Return MediaCount
    End Function
#End Region


End Class