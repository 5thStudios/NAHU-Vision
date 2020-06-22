Imports System.Xml.XPath
Imports System.Collections.Generic
Imports Common
Imports Examine
Imports UmbracoExamine
Imports System.Net
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq
Imports System.Data
Imports System.Xml
Imports Umbraco
Imports Umbraco.Web
Imports Umbraco.Core.Models
Imports Umbraco.Core
Imports Umbraco.NodeFactory


Public Class SearchList
    Inherits System.Web.Mvc.ViewUserControl



#Region "Properties"
#End Region

#Region "Handles"
    Private Sub SearchList_Load(sender As Object, e As EventArgs) Handles Me.Load
        '
        'ONLY USE THIS FOR TESTING.  ACTUAL CODE IS LOCATED IN SERVICES/SITESEARCH.ASHX
        '

        'Try
        '    Dim tempSearchFor As String = "law"
        '    'Search for data in videos
        '    Dim lstSearch_videoList As List(Of DataLayer.SearchList) = SearchVideosFor(tempSearchFor)
        '    'gv.DataSource = lstSearch_videoList
        '    'gv.DataBind()



        '    Dim lstSearch_articleList As List(Of DataLayer.SearchList) = SearchExamineFor(tempSearchFor)
        '    'gv2.DataSource = lstSearch_articleList
        '    'gv2.DataBind()


        '    Dim lstSearchResults As New List(Of DataLayer.SearchList)

        '    lstSearchResults.AddRange(SearchVideosFor(tempSearchFor))
        '    lstSearchResults.AddRange(SearchExamineFor(tempSearchFor))
        '    'sort list
        '    gv3.DataSource = lstSearchResults.OrderBy(Function(x) x.title)
        '    gv3.DataBind()



        'Catch ex As Exception
        '    lblErrorMsg.Text = "Error: " & ex.ToString
        'End Try
    End Sub

#End Region

#Region "Methods"
    Private Function SearchExamineFor(ByVal searchFor As String) As List(Of DataLayer.SearchList)
        'Instantiate scope variable
        Dim lstSearchList As New List(Of DataLayer.SearchList)

        Try
            'Instantiate variables
            Dim searchEntry As DataLayer.SearchList

            '=========================================================================================
            ''Instantiate search provider and criteria
            ''Dim searchProvider As Providers.BaseSearchProvider = Examine.ExamineManager.Instance.SearchProviderCollection(searchIndex.ExternalSearcher)
            'Dim searchProvider As Providers.BaseSearchProvider = Examine.ExamineManager.Instance.DefaultSearchProvider
            'Dim searchCriteria As SearchCriteria.ISearchCriteria = searchProvider.CreateSearchCriteria()

            ''Obtain all marked items
            'Dim query = searchCriteria.RawQuery(searchFor)
            'Dim searchResults = searchProvider.Search(query)

            ''Loop thru each id and build link list
            'For Each result As Examine.SearchResult In searchResults
            '    'Create node
            '    Dim thisNode As New Node(result.Id)
            '=========================================================================================

            Dim umbracoHelper = New Umbraco.Web.UmbracoHelper(UmbracoContext.Current)
            Dim ipRoot As Umbraco.Core.Models.IPublishedContent = umbracoHelper.TypedContentAtRoot().FirstOrDefault()

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


            For Each thisNode In ipRoot.Descendants
                'Skip ignored doctypes
                If LstIgnoreTypes.Contains(thisNode.DocumentTypeAlias) Then Continue For


                'Search within the following fields if they exist
                Dim match As Boolean = False
                If thisNode.Name.Contains(searchFor) Then match = True
                If thisNode.HasProperty(Common.nodeProperties.title) AndAlso thisNode.GetPropertyValue(Of String)(Common.nodeProperties.title).Contains(searchFor) Then match = True
                If thisNode.HasProperty(Common.nodeProperties.bl_title) AndAlso thisNode.GetPropertyValue(Of String)(Common.nodeProperties.bl_title).Contains(searchFor) Then match = True
                If thisNode.HasProperty(Common.nodeProperties.sb_title) AndAlso thisNode.GetPropertyValue(Of String)(Common.nodeProperties.sb_title).Contains(searchFor) Then match = True
                If thisNode.HasProperty(Common.nodeProperties.qb_title) AndAlso thisNode.GetPropertyValue(Of String)(Common.nodeProperties.qb_title).Contains(searchFor) Then match = True
                If thisNode.HasProperty(Common.nodeProperties.pageTitle) AndAlso thisNode.GetPropertyValue(Of String)(Common.nodeProperties.pageTitle).Contains(searchFor) Then match = True
                If thisNode.HasProperty(Common.nodeProperties.ctap_title) AndAlso thisNode.GetPropertyValue(Of String)(Common.nodeProperties.ctap_title).Contains(searchFor) Then match = True
                If thisNode.HasProperty(Common.nodeProperties.cp_Title1) AndAlso thisNode.GetPropertyValue(Of String)(Common.nodeProperties.cp_Title1).Contains(searchFor) Then match = True
                If thisNode.HasProperty(Common.nodeProperties.cp_Title2) AndAlso thisNode.GetPropertyValue(Of String)(Common.nodeProperties.cp_Title2).Contains(searchFor) Then match = True
                If thisNode.HasProperty(Common.nodeProperties.cp_Title3) AndAlso thisNode.GetPropertyValue(Of String)(Common.nodeProperties.cp_Title3).Contains(searchFor) Then match = True

                If thisNode.HasProperty(Common.nodeProperties.sb_subtitle) AndAlso thisNode.GetPropertyValue(Of String)(Common.nodeProperties.sb_subtitle).Contains(searchFor) Then match = True
                If thisNode.HasProperty(Common.nodeProperties.bl_subtitle) AndAlso thisNode.GetPropertyValue(Of String)(Common.nodeProperties.bl_subtitle).Contains(searchFor) Then match = True
                If thisNode.HasProperty(Common.nodeProperties.subtitle) AndAlso thisNode.GetPropertyValue(Of String)(Common.nodeProperties.subtitle).Contains(searchFor) Then match = True
                If thisNode.HasProperty(Common.nodeProperties.qb_subtitle) AndAlso thisNode.GetPropertyValue(Of String)(Common.nodeProperties.qb_subtitle).Contains(searchFor) Then match = True

                If thisNode.HasProperty(Common.nodeProperties.summary) AndAlso thisNode.GetPropertyValue(Of String)(Common.nodeProperties.summary).Contains(searchFor) Then match = True
                If thisNode.HasProperty(Common.nodeProperties.content) AndAlso thisNode.GetPropertyValue(Of String)(Common.nodeProperties.content).Contains(searchFor) Then match = True
                If thisNode.HasProperty(Common.nodeProperties.tb_content) AndAlso thisNode.GetPropertyValue(Of String)(Common.nodeProperties.tb_content).Contains(searchFor) Then match = True
                If thisNode.HasProperty(Common.nodeProperties.bn_Content) AndAlso thisNode.GetPropertyValue(Of String)(Common.nodeProperties.bn_Content).Contains(searchFor) Then match = True
                If thisNode.HasProperty(Common.nodeProperties.ctap_content) AndAlso thisNode.GetPropertyValue(Of String)(Common.nodeProperties.ctap_content).Contains(searchFor) Then match = True
                If thisNode.HasProperty(Common.nodeProperties.bodyText) AndAlso thisNode.GetPropertyValue(Of String)(Common.nodeProperties.bodyText).Contains(searchFor) Then match = True

                If thisNode.HasProperty(Common.nodeProperties.bl_callToActionText) AndAlso thisNode.GetPropertyValue(Of String)(Common.nodeProperties.bl_callToActionText).Contains(searchFor) Then match = True
                If thisNode.HasProperty(Common.nodeProperties.callToActionText) AndAlso thisNode.GetPropertyValue(Of String)(Common.nodeProperties.callToActionText).Contains(searchFor) Then match = True
                If thisNode.HasProperty(Common.nodeProperties.ctap_callToActionText) AndAlso thisNode.GetPropertyValue(Of String)(Common.nodeProperties.ctap_callToActionText).Contains(searchFor) Then match = True
                If thisNode.HasProperty(Common.nodeProperties.qb_callToActionText) AndAlso thisNode.GetPropertyValue(Of String)(Common.nodeProperties.qb_callToActionText).Contains(searchFor) Then match = True

                If thisNode.HasProperty(Common.nodeProperties.description) AndAlso thisNode.GetPropertyValue(Of String)(Common.nodeProperties.description).Contains(searchFor) Then match = True
                If thisNode.HasProperty(Common.nodeProperties.shortDescription) AndAlso thisNode.GetPropertyValue(Of String)(Common.nodeProperties.shortDescription).Contains(searchFor) Then match = True
                If thisNode.HasProperty(Common.nodeProperties.cp_Description1) AndAlso thisNode.GetPropertyValue(Of String)(Common.nodeProperties.cp_Description1).Contains(searchFor) Then match = True
                If thisNode.HasProperty(Common.nodeProperties.cp_Description2) AndAlso thisNode.GetPropertyValue(Of String)(Common.nodeProperties.cp_Description2).Contains(searchFor) Then match = True
                If thisNode.HasProperty(Common.nodeProperties.cp_Description3) AndAlso thisNode.GetPropertyValue(Of String)(Common.nodeProperties.cp_Description3).Contains(searchFor) Then match = True



                If match = True Then
                    'Skip if there is no id
                    If thisNode.Id = 0 Then Continue For
                    'Add data to class
                    searchEntry = New DataLayer.SearchList
                    searchEntry.id = thisNode.Id
                    searchEntry.title = thisNode.Name
                    searchEntry.url = thisNode.NiceUrl
                    Select Case thisNode.DocumentTypeAlias
                        Case aliases.lockedBlogEntry, aliases.lockedPdfEntry
                            searchEntry.isLocked = True
                    End Select
                    'Split path to create a breadcrumb
                    Dim first As Boolean = True
                    For Each _id As String In thisNode.Path.Split(",").ToList
                        Dim id As Integer = CInt(_id)
                        If id <> -1 Then
                            If first Then
                                first = False
                            Else
                                searchEntry.breadcrumb += "&nbsp;&nbsp;⇢&nbsp;&nbsp;"
                            End If
                            searchEntry.breadcrumb += New Node(id).Name
                        End If
                    Next

                    'Add to list
                    lstSearchList.Add(searchEntry)
                End If


            Next

        Catch ex As Exception
            Response.Write("Error retrieving data from Umbraco: " & ex.ToString)
        End Try

        Return lstSearchList
    End Function
    Private Function SearchVideosFor(ByVal searchFor As String) As List(Of DataLayer.SearchList)
        'Instantiate scope variable
        Dim lstSearchList As New List(Of DataLayer.SearchList)

        Try
            'Instantiate variables
            Dim apiCall As String = "https://bdo.workerbeetv.com/wp-content/themes/enterprise/feed/mrssMob.php?apiKey=CF2EC754FCD36&output=xml&limit=1000&sort=ASC&q=" & searchFor
            Dim webClient As WebClient = New WebClient()
            Dim xmlDoc As XmlDocument = New XmlDocument()
            Dim apiResult As String
            Dim lstItems As XmlNodeList

            'Retrieve xml result of search from within videos
            apiResult = webClient.DownloadString(New Uri(apiCall))

            'load xml string into xml document
            xmlDoc.LoadXml(apiResult)

            'extract list of items portion of xml
            lstItems = xmlDoc.DocumentElement.SelectNodes("/rss/channel/item")

            'Loop thru list and extract needed data into a search list.
            For Each item As XmlNode In lstItems
                Dim searchLstItem As New DataLayer.SearchList
                searchLstItem.title = item.SelectSingleNode("title").InnerText
                searchLstItem.url = item.SelectSingleNode("link").InnerText
                searchLstItem.isVideo = True
                'Split path to create a breadcrumb
                Dim segmentId As UInt16 = 0
                For Each segment As String In searchLstItem.url.Split("/").ToList
                    If segmentId > 2 Then
                        searchLstItem.breadcrumb += "&nbsp;&nbsp;⇢&nbsp;&nbsp;"
                    End If
                    If segmentId >= 1 Then
                        searchLstItem.breadcrumb += UppercaseFirstLetter(segment.Replace("-", " ").ToLower)
                    End If
                    segmentId += 1
                Next
                'Add to search list
                lstSearchList.Add(searchLstItem)
            Next

        Catch ex As Exception
            Response.Write("Error retrieving data from WorkerbeeTv: " & ex.ToString)
        End Try

        Return lstSearchList
    End Function
#End Region

End Class