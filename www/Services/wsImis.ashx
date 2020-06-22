<%@ WebHandler Language="VB" Class="wsImis" %>

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

Public Class wsImis : Implements IHttpHandler

    'Public Sub ProcessRequest(ByVal context As HttpContext) Implements IHttpHandler.ProcessRequest
    '    context.Response.ContentType = "text/plain"
    '    context.Response.Write("Hello World")
    'End Sub

    'Public ReadOnly Property IsReusable() As Boolean Implements IHttpHandler.IsReusable
    '    Get
    '        Return False
    '    End Get
    'End Property

    Sub ProcessRequest(ByVal context As HttpContext) Implements IHttpHandler.ProcessRequest
        Try
            'Obtain data that was sent to process
            Dim data As String = New StreamReader(context.Request.InputStream).ReadToEnd()
            Dim dataDictionary As Dictionary(Of String, String) = JsonConvert.DeserializeObject(Of Dictionary(Of String, String))(data)

            'Instantiate new list
            Dim lst As New List(Of DataLayer.SearchList)

            'If a search request exists, search for it.
            If dataDictionary.ContainsKey("searchFor") Then
                lst = ObtainList(dataDictionary.Item("searchFor"))
            End If

            'Return results
            context.Response.Clear()
            context.Response.ContentType = "application/json; charset=utf-8"
            context.Response.Write(JsonConvert.SerializeObject(lst))

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

    ReadOnly Property IsReusable() As Boolean Implements IHttpHandler.IsReusable
        Get
            Return False
        End Get
    End Property

    Private Function ObtainList(ByVal searchFor As String) As List(Of DataLayer.SearchList)
        'Instantiate variables
        Dim lstSearchList As New List(Of DataLayer.SearchList)
        Dim searchEntry As DataLayer.SearchList
        Dim umbracoHelper = New Umbraco.Web.UmbracoHelper(UmbracoContext.Current)
        Dim ipRoot As Umbraco.Core.Models.IPublishedContent = umbracoHelper.TypedContentAtRoot().FirstOrDefault()

        '=========================================================================================
        ''Instantiate search provider and criteria
        'Dim searchProvider As Providers.BaseSearchProvider = Examine.ExamineManager.Instance.DefaultSearchProvider
        'Dim searchCriteria As SearchCriteria.ISearchCriteria = searchProvider.CreateSearchCriteria()

        ''Obtain all matching items
        'Dim query As Examine.SearchCriteria.ISearchCriteria = searchCriteria.RawQuery(searchFor)
        'Dim searchResults As ISearchResults = searchProvider.Search(query)

        ''Loop thru each id and build link list
        'For Each result As Examine.SearchResult In searchResults
        '    'Create node
        '    Dim thisNode As New Node(result.Id)
        '=========================================================================================

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
                'Skip if root node is not a site node
                Dim rootId As Integer = getHomeNodeId(thisNode.Id)
                Select Case rootId
                    Case siteNodes.Home, siteNodes.EducationFoundation, siteNodes.HUPAC
                        'Proceed
                    Case Else
                        'Skip
                        Continue For
                End Select




                'Add data to class
                searchEntry = New DataLayer.SearchList
                searchEntry.id = thisNode.Id
                searchEntry.title = " [" & thisNode.DocumentTypeAlias & "]" 'thisNode.Name &
                searchEntry.url = thisNode.Url
                'searchEntry.breadcrumb = thisNode.Path

                Select Case thisNode.DocumentTypeAlias
                    Case aliases.lockedBlogEntry, aliases.lockedPdfEntry, aliases.template02Locked
                        searchEntry.isLocked = True
                End Select

                'Split path to create a breadcrumb
                Dim first As Boolean = True
                For Each _id As String In thisNode.Path.Split(",")
                    Dim id As Integer = CInt(_id)
                    If id <> -1 Then
                        If first Then
                            first = False
                        Else
                            searchEntry.breadcrumb += "&nbsp;&nbsp;⇢&nbsp;&nbsp;" ' ↠ &rArr; ⇢
                        End If
                        searchEntry.breadcrumb += New Node(id).Name
                    End If
                Next

                searchEntry.breadcrumb = " [" & thisNode.DocumentTypeAlias & "]"

                'Add to list
                lstSearchList.Add(searchEntry)
            End If

        Next

        Return lstSearchList
    End Function

End Class