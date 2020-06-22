<%@ WebHandler Language="VB" Class="BlogSearch" %>

Imports System
Imports System.Web
Imports System.Web.Services
Imports Newtonsoft.Json
Imports Common
Imports System.IO
Imports Examine
Imports Umbraco.Web

Imports Examine.Providers
Imports Examine.SearchCriteria
Imports Examine.LuceneEngine.SearchCriteria



Public Class BlogSearch : Implements IHttpHandler

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
            Dim searchFor As String = New StreamReader(context.Request.InputStream).ReadToEnd() 'USED FOR AJAX POST REQUEST; SENT AS INPUT STREAM
            'Dim searchFor As String = HttpUtility.UrlDecode(context.Request.QueryString("data"))  'USED FOR AJAX GET REQUEST; SENT VIA QUERYSTRING

            'Extract data into a class.
            Dim customSearch As customSearch = JsonConvert.DeserializeObject(Of customSearch)(searchFor)


            '==========================================================================================
            Dim umbracoHelper = New Umbraco.Web.UmbracoHelper(UmbracoContext.Current)
            Dim ipRoot As Umbraco.Core.Models.IPublishedContent = umbracoHelper.TypedContentAtRoot().FirstOrDefault()

            'Obtain all matching items
            Dim lstAliases As New List(Of String)
            lstAliases.Add(Common.aliases.blogEntry)
            lstAliases.Add(Common.aliases.lockedBlogEntry)
            lstAliases.Add(Common.aliases.pdfEntry)
            lstAliases.Add(Common.aliases.lockedPdfEntry)
            lstAliases.Add(Common.aliases.urlEntry)

            Dim lstNodeProperties As New List(Of String)
            lstNodeProperties.Add(Common.nodeProperties.nodeName)
            lstNodeProperties.Add(Common.nodeProperties.title)
            lstNodeProperties.Add(Common.nodeProperties.summary)
            lstNodeProperties.Add(Common.nodeProperties.content)


            For Each ipNode In ipRoot.Descendants().Where(Function(x) lstAliases.Contains(x.DocumentTypeAlias))
                Dim match As Boolean = False
                If ipNode.Name.Contains(customSearch.searchFor) Then match = True
                If ipNode.GetPropertyValue(Of String)(Common.nodeProperties.title).Contains(customSearch.searchFor) Then match = True
                If ipNode.GetPropertyValue(Of String)(Common.nodeProperties.summary).Contains(customSearch.searchFor) Then match = True
                If ipNode.GetPropertyValue(Of String)(Common.nodeProperties.content).Contains(customSearch.searchFor) Then match = True
                If match = True Then
                    Dim lstPath As New List(Of Integer)
                    For Each item In ipNode.Path.Split(",").ToList()
                        lstPath.Add(CInt(item))
                    Next

                    If lstPath.Contains(customSearch.listPgId) Then customSearch.lstNodeIDs.Add(ipNode.Id)
                End If
            Next
            '==========================================================================================

            ''Fetching our SearchProvider by giving it the name of our searchprovider
            ''Dim searchProvider As Providers.BaseSearchProvider = Examine.ExamineManager.Instance.SearchProviderCollection(searchIndex.BlogSearcher)
            'Dim searchProvider As Providers.BaseSearchProvider = Examine.ExamineManager.Instance.DefaultSearchProvider

            ''Obtain all matching items
            'Dim searchCriteria As SearchCriteria.ISearchCriteria = searchProvider.CreateSearchCriteria()
            'Dim query As Examine.SearchCriteria.IBooleanOperation = searchCriteria.GroupedOr(
            '        New String() {"nodeTypeAlias"},
            '        New String() {Common.aliases.blogEntry, Common.aliases.lockedBlogEntry, Common.aliases.pdfEntry, Common.aliases.lockedPdfEntry, Common.aliases.urlEntry})
            'query.And().GroupedOr(
            '        New String() {"nodeName", "title", "summary", "content"},
            '        customSearch.searchFor.MultipleCharacterWildcard()
            '        )

            'Dim searchResults As IEnumerable(Of SearchResult) = searchProvider.Search(query.Compile()).OrderByDescending(Function(x) x.Score).TakeWhile(Function(x) x.Score > 0.05F)

            'For Each result As Examine.SearchResult In searchResults
            '    Dim fullPath As String = result.Fields("__Path")

            '    Dim lstPath As New List(Of Integer)
            '    For Each item In fullPath.Split(",").ToList()
            '        lstPath.Add(CInt(item))
            '    Next

            '    If lstPath.Contains(customSearch.listPgId) Then customSearch.lstNodeIDs.Add(result.Id)
            'Next
            '==========================================================================================

            'context.Response.ContentType = "text/plain"
            context.Response.Clear()
            context.Response.ContentType = "application/json; charset=utf-8"
            context.Response.Write(JsonConvert.SerializeObject(customSearch))


        Catch ex As Exception
            Dim sb As New StringBuilder()
            sb.AppendLine("\Handlers\BlogSearch.ashx : ProcessRequest()")
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

    Private Class customSearch
        Public Property searchFor As String = String.Empty
        Public Property listPgId As Integer? = Nothing
        Public Property lstNodeIDs As New List(Of Integer)
    End Class

End Class