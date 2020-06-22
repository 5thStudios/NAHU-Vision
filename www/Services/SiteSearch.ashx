<%@ WebHandler Language="VB" Class="SiteSearch" %>

Imports System
Imports System.Web
Imports System.Web.Services
Imports Newtonsoft.Json
Imports Common
Imports System.IO
Imports Examine
Imports Umbraco
Imports Umbraco.Web
Imports Umbraco.NodeFactory
Imports System.Xml.XPath
Imports System.Collections.Generic
Imports UmbracoExamine
Imports System.Net
Imports Newtonsoft.Json.Linq
Imports System.Data
Imports System.Xml

Public Class SiteSearch : Implements IHttpHandler

#Region "Handles"
    Sub ProcessRequest(ByVal context As HttpContext) Implements IHttpHandler.ProcessRequest
        Try

            'Obtain data that was sent to process
            Dim data As String = New StreamReader(context.Request.InputStream).ReadToEnd()
            Dim dataDictionary As Dictionary(Of String, String) = JsonConvert.DeserializeObject(Of Dictionary(Of String, String))(data)
            Dim searchFor As String = String.Empty

            '
            If dataDictionary.ContainsKey("searchFor") Then
                searchFor = dataDictionary.Item("searchFor")
            End If

            'Search for data in videos
            Dim lstSearchResults As New List(Of DataLayer.SearchList)

            If Not String.IsNullOrWhiteSpace(searchFor) Then
                lstSearchResults.AddRange(SearchVideosFor(searchFor))
                lstSearchResults.AddRange(SearchExamineFor(searchFor))
            End If

            'Return results
            context.Response.Clear()
            context.Response.ContentType = "application/json; charset=utf-8"
            context.Response.Write(JsonConvert.SerializeObject(lstSearchResults.OrderBy(Function(x) x.title)))

        Catch ex As Exception
            Dim sb As New StringBuilder()
            sb.AppendLine("\Handlers\Search.ashx : ProcessRequest()")
            sb.AppendLine("context:" & context.ToString())

            SaveErrorMessage(ex, sb, Me.GetType())
            context.Response.Clear()
            context.Response.ContentType = "application/json; charset=utf-8"
            context.Response.Write(JsonConvert.SerializeObject("Error: " & ex.ToString))
            context.Response.End()
        End Try


        'Finalize response
        context.Response.End()
    End Sub

#End Region


#Region "Methods"
    Private Function SearchExamineFor(ByVal searchFor As String) As List(Of DataLayer.SearchList)
        'Instantiate scope variable
        Dim lstSearchList As New List(Of DataLayer.SearchList)

        'Instantiate variables
        Dim searchEntry As DataLayer.SearchList
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

        '==========================================================================================
        ''Instantiate search provider and criteria
        'Dim searchProvider As Providers.BaseSearchProvider = Examine.ExamineManager.Instance.DefaultSearchProvider
        'Dim searchCriteria As SearchCriteria.ISearchCriteria = searchProvider.CreateSearchCriteria()

        ''Obtain all marked items
        'Dim query = searchCriteria.RawQuery(searchFor)
        'Dim searchResults = searchProvider.Search(query)

        ''Loop thru each id and build link list
        'For Each result As Examine.SearchResult In searchResults
        '==========================================================================================

        For Each thisNode In ipRoot.Descendants
            Try
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

            Catch ex As Exception
                'Dim sb As New StringBuilder()
                'sb.AppendLine("\Services\SiteSearch.ashx : SearchExamineFor()")
                'sb.AppendLine("searchFor:" & searchFor)
                'sb.AppendLine("Name:" & thisNode.Name)
                'sb.AppendLine("DocumentTypeAlias:" & thisNode.DocumentTypeAlias)
                'sb.AppendLine("Url:" & thisNode.Url)


                'SaveErrorMessage(ex, sb, Me.GetType())
            End Try


        Next

        Return lstSearchList
    End Function


    Private Function SearchVideosFor(ByVal searchFor As String) As List(Of DataLayer.SearchList)
        'Instantiate scope variable
        Dim lstSearchList As New List(Of DataLayer.SearchList)

        Try
            'TEST API CALL.
            'Dim apiKey As String = "CF2EC754FCD36"
            'Dim apiCall As String = "https://bdo.workerbeetv.com/wp-content/themes/enterprise/feed/mrssMob.php?apiKey=" & apiKey & "&output=xml&limit=1000&sort=ASC&q=" & searchFor.Replace(" ", "+")

            'Instantiate variables
            Dim apiKey As String = "B5B2A5E34E4C9"
            Dim apiCall As String = "https://videos.nahu.org/wp-content/themes/enterprise/feed/mrssMob.php?apiKey=" & apiKey & "&output=xml&limit=1000&sort=ASC&q=" & searchFor.Replace(" ", "+")
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
            Dim sb As New StringBuilder()
            sb.AppendLine("\Handlers\Search.ashx : SearchVideosFor()")
            sb.AppendLine("searchFor:" & searchFor)
            SaveErrorMessage(ex, sb, Me.GetType())
        End Try

        Return lstSearchList
    End Function



    ReadOnly Property IsReusable() As Boolean Implements IHttpHandler.IsReusable
        Get
            Return False
        End Get
    End Property
#End Region

End Class
