Imports Microsoft.VisualBasic
Imports Common
Imports Umbraco
Imports Umbraco.Core.Models
Imports Umbraco.NodeFactory
Imports Umbraco.Web
Imports System.Net

Public Class linqBlogs


#Region "Properties"
#End Region

#Region "Select"
    Public Function selectBlogListEntry_byId(ByVal _thisNodeId As Integer) As BusinessReturn
        'Instantiate master variables
        Dim businessReturn As New BusinessReturn

        Try
            'Instantiate variables
            Dim uHelper As UmbracoHelper = New Umbraco.Web.UmbracoHelper(Umbraco.Web.UmbracoContext.Current)
            Dim ipContent As IPublishedContent = uHelper.TypedContent(_thisNodeId)
            Dim blogEntry As New DataLayer.BlogEntry

            'Obtain property data
            blogEntry.nodeId = _thisNodeId
            If ipContent.DocumentTypeAlias = aliases.urlEntry Then blogEntry.isExternalUrl = True
            If ipContent.HasValue(nodeProperties.title) Then blogEntry.title = ipContent.GetPropertyValue(Of String)(nodeProperties.title)
            If ipContent.HasValue(nodeProperties.navigationTitle) Then blogEntry.navigationTitle = ipContent.GetPropertyValue(Of String)(nodeProperties.navigationTitle)
            If ipContent.HasValue(nodeProperties.postDate) Then blogEntry.postDate = ipContent.GetPropertyValue(Of Date)(nodeProperties.postDate)
            If ipContent.HasValue(nodeProperties.summary) Then blogEntry.summary = ipContent.GetPropertyValue(Of String)(nodeProperties.summary)

            Try
                If ipContent.HasValue(nodeProperties.author) Then blogEntry.author.id = ipContent.GetPropertyValue(Of String)(nodeProperties.author)
                If ipContent.HasValue(nodeProperties.author) Then blogEntry.author.name = uHelper.TypedContent(blogEntry.author.id).Name
            Catch
            End Try

            Try
                'Split tag csv into list
                If ipContent.HasValue(nodeProperties.tags) Then
                    'For Each tagId As String In ipContent.GetPropertyValue(Of String)(nodeProperties.tags).Split(",")
                    For Each ipTag As IPublishedContent In ipContent.GetPropertyValue(Of IEnumerable(Of IPublishedContent))(nodeProperties.tags)
                        Dim tag As New DataLayer.Tag
                        tag.id = ipTag.Id
                        tag.name = ipTag.Name
                        blogEntry.lstTags.Add(tag)
                    Next
                End If
            Catch
            End Try




            'Set values based on doctype
            Select Case ipContent.DocumentTypeAlias
                Case aliases.blogEntry
                    blogEntry.isLocked = False
                    blogEntry.isPdf = False
                Case aliases.lockedBlogEntry
                    blogEntry.isLocked = True
                    blogEntry.isPdf = False
                Case aliases.pdfEntry
                    blogEntry.isLocked = False
                    blogEntry.isPdf = True
                Case aliases.lockedPdfEntry
                    blogEntry.isLocked = True
                    blogEntry.isPdf = True
            End Select

            'Get url of node or document
            If blogEntry.isPdf Then
                blogEntry.url = getMediaURL(ipContent.GetPropertyValue(Of IPublishedContent)(nodeProperties.pDFDocument).Id, String.Empty, True)
            ElseIf blogEntry.isExternalUrl Then
                blogEntry.url = ipContent.GetPropertyValue(Of String)(nodeProperties.externalUrl)
            Else
                blogEntry.url = ipContent.Url
            End If


            'Determine what image type will be displayed
            If blogEntry.isExternalUrl Then
                blogEntry.showFeaturedImg = True
            ElseIf ipContent.HasValue(nodeProperties.featuredOptions) Then
                blogEntry.featuredOptions = ipContent.GetPropertyValue(Of String)(nodeProperties.featuredOptions)
                Select Case blogEntry.featuredOptions
                    Case featuredOptions.featuredImage
                        blogEntry.showFeaturedImg = True
                    Case featuredOptions.youtubeVideo
                        blogEntry.showYoutubeVideo = True
                    Case featuredOptions.vimeoVideo
                        blogEntry.showVimeoVideo = True
                    Case featuredOptions.none
                        'show none
                End Select
            Else
                blogEntry.showFeaturedImg = True
            End If


            If blogEntry.showFeaturedImg Then
                'Obtain featured image
                If ipContent.HasValue(nodeProperties.featuredImage) Then
                    Try
                        blogEntry.featuredImageUrl = getMediaURL(ipContent.GetPropertyValue(Of IPublishedContent)(nodeProperties.featuredImage).Id, crops.ListItemSquared)
                        blogEntry.featuredImageName = getMediaName(ipContent.GetPropertyValue(Of IPublishedContent)(nodeProperties.featuredImage).Id)
                    Catch ex As Exception
                        blogEntry.featuredImageUrl = getMediaURL(ipContent.GetPropertyValue(Of String)(nodeProperties.featuredImage), crops.ListItemSquared)
                        blogEntry.featuredImageName = getMediaName(ipContent.GetPropertyValue(Of String)(nodeProperties.featuredImage))
                    End Try
                End If

            ElseIf (blogEntry.showYoutubeVideo) Then
                blogEntry.featuredVideoId = ipContent.GetPropertyValue(Of String)(nodeProperties.featuredVideo)
                blogEntry.featuredVideoUrl = miscellaneous.youtubePlayer.Replace("[ID]", blogEntry.featuredVideoId)
                blogEntry.featuredImageUrl = getYoutubeImg(blogEntry.featuredVideoId)
                blogEntry.widescreenVideo = ipContent.GetPropertyValue(Of String)(nodeProperties.widescreenVideo)

            ElseIf (blogEntry.showVimeoVideo) Then
                blogEntry.featuredVideoId = ipContent.GetPropertyValue(Of String)(nodeProperties.featuredVideo)
                blogEntry.featuredVideoUrl = miscellaneous.vimeoPlayer.Replace("[ID]", blogEntry.featuredVideoId)
                If ipContent.HasValue(nodeProperties.vimeoImageId) Then
                    blogEntry.vimeoImageId = ipContent.GetPropertyValue(Of String)(nodeProperties.vimeoImageId)
                    blogEntry.featuredImageUrl = getVimeoImg(blogEntry.vimeoImageId)
                End If
                blogEntry.widescreenVideo = ipContent.GetPropertyValue(Of String)(nodeProperties.widescreenVideo)
            End If



            'Save class to return
            businessReturn.DataContainer.Add(blogEntry)

        Catch ex As Exception
            'Save error to umbraco
            Dim sb As New StringBuilder
            sb.AppendLine("linqBlogs.vb | selectBlogEntry_byId()")
            sb.AppendLine("_thisNodeId: " & _thisNodeId)
            SaveErrorMessage(ex, sb, Me.GetType())

            'Return exception
            businessReturn.ExceptionMessage = ex.ToString
        End Try

        Return businessReturn
    End Function
    Public Function selectBlog_byId(ByVal _thisNodeId As Integer) As BusinessReturn
        'Instantiate master variables
        Dim businessReturn As New BusinessReturn

        Try
            'Instantiate variables
            Dim uHelper As UmbracoHelper = New umbraco.Web.UmbracoHelper(umbraco.Web.UmbracoContext.Current)
            Dim ipContent As IPublishedContent = uHelper.TypedContent(_thisNodeId)
            Dim blogEntry As New DataLayer.BlogEntry
            'Dim sbTags As New StringBuilder
            'Dim firstTag As Boolean = True

            'Obtain property data
            blogEntry.nodeId = _thisNodeId
            If ipContent.HasValue(nodeProperties.title) Then blogEntry.title = ipContent.GetPropertyValue(Of String)(nodeProperties.title)
            If ipContent.HasValue(nodeProperties.navigationTitle) Then blogEntry.navigationTitle = ipContent.GetPropertyValue(Of String)(nodeProperties.navigationTitle)
            If ipContent.HasValue(nodeProperties.postDate) Then blogEntry.postDate = ipContent.GetPropertyValue(Of Date)(nodeProperties.postDate)
            If ipContent.HasValue(nodeProperties.content) Then blogEntry.content = ipContent.GetPropertyValue(Of String)(nodeProperties.content)

            Try
                If ipContent.HasValue(nodeProperties.author) Then blogEntry.author.id = ipContent.GetPropertyValue(Of String)(nodeProperties.author)
                If ipContent.HasValue(nodeProperties.author) Then blogEntry.author.name = uHelper.TypedContent(blogEntry.author.id).Name
            Catch
            End Try


            '
            If ipContent.HasValue(nodeProperties.featuredOptions) Then blogEntry.featuredOptions = ipContent.GetPropertyValue(Of String)(nodeProperties.featuredOptions)
            Select Case blogEntry.featuredOptions
                Case featuredOptions.featuredImage
                    blogEntry.showFeaturedImg = True
                Case featuredOptions.youtubeVideo
                    blogEntry.showYoutubeVideo = True
                Case featuredOptions.vimeoVideo
                    blogEntry.showVimeoVideo = True
                Case featuredOptions.none
                    'show none
                Case Else
                    blogEntry.showFeaturedImg = True
            End Select

            If blogEntry.showFeaturedImg Then
                'Obtain featured image
                If ipContent.HasValue(nodeProperties.featuredImage) Then
                    Try
                        blogEntry.featuredImageUrl = getMediaURL(ipContent.GetPropertyValue(Of IPublishedContent)(nodeProperties.featuredImage).Id, crops.BlogFeaturedImage)
                        blogEntry.featuredImageName = getMediaName(ipContent.GetPropertyValue(Of IPublishedContent)(nodeProperties.featuredImage).Id)
                    Catch ex As Exception
                        blogEntry.featuredImageUrl = getMediaURL(ipContent.GetPropertyValue(Of String)(nodeProperties.featuredImage), crops.BlogFeaturedImage)
                        blogEntry.featuredImageName = getMediaName(ipContent.GetPropertyValue(Of String)(nodeProperties.featuredImage))
                    End Try

                End If

            ElseIf (blogEntry.showYoutubeVideo) Then
                blogEntry.featuredVideoId = ipContent.GetPropertyValue(Of String)(nodeProperties.featuredVideo)
                blogEntry.featuredVideoUrl = miscellaneous.youtubePlayer.Replace("[ID]", blogEntry.featuredVideoId)
                blogEntry.featuredImageUrl = getYoutubeImg(blogEntry.featuredVideoId)
                blogEntry.widescreenVideo = ipContent.GetPropertyValue(Of String)(nodeProperties.widescreenVideo)

            ElseIf (blogEntry.showVimeoVideo) Then
                blogEntry.featuredVideoId = ipContent.GetPropertyValue(Of String)(nodeProperties.featuredVideo)
                blogEntry.featuredVideoUrl = miscellaneous.vimeoPlayer.Replace("[ID]", blogEntry.featuredVideoId)
                If ipContent.HasValue(nodeProperties.vimeoImageId) Then
                    blogEntry.vimeoImageId = ipContent.GetPropertyValue(Of String)(nodeProperties.vimeoImageId)
                    blogEntry.featuredImageUrl = getVimeoImg(blogEntry.vimeoImageId)
                End If
                blogEntry.widescreenVideo = ipContent.GetPropertyValue(Of String)(nodeProperties.widescreenVideo)
            End If

            ''
            'If (blogEntry.showYoutubeVideo) Or (blogEntry.showVimeoVideo) Then
            '    blogEntry.featuredVideo = thisNode.GetProperty(nodeProperties.featuredVideo)
            '    blogEntry.widescreenVideo = thisNode.GetProperty(nodeProperties.widescreenVideo)
            'End If







            Try
                'Split tag csv into listtag csv into list
                If ipContent.HasValue(nodeProperties.tags) Then
                    'For Each tagId As String In ipContent.GetPropertyValue(Of String)(nodeProperties.tags).Split(",")
                    For Each ipTag As IPublishedContent In ipContent.GetPropertyValue(Of IEnumerable(Of IPublishedContent))(nodeProperties.tags)
                        Dim tag As New DataLayer.Tag
                        'Try
                        tag.id = ipTag.Id 'getIdFromGuid_byType(tagId, Core.Models.UmbracoObjectTypes.Document)
                        'Catch ex As Exception
                        '    tag.id = getIdFromGuid_byType(tagId, Core.Models.UmbracoObjectTypes.Media)
                        'End Try
                        tag.name = ipTag.Name ' uHelper.TypedContent(tag.id).Name
                        blogEntry.lstTags.Add(tag)
                    Next
                End If
            Catch
            End Try

            'Set values based on doctype
            Select Case ipContent.DocumentTypeAlias
                Case aliases.blogEntry
                    blogEntry.isLocked = False
                    blogEntry.isPdf = False
                Case aliases.lockedBlogEntry
                    blogEntry.isLocked = True
                    blogEntry.isPdf = False
                Case aliases.pdfEntry
                    blogEntry.isLocked = False
                    blogEntry.isPdf = True
                Case aliases.lockedPdfEntry
                    blogEntry.isLocked = True
                    blogEntry.isPdf = True
                Case aliases.podcast
                    blogEntry.isLocked = False
                    blogEntry.isPdf = False
                    blogEntry.isPodcast = True
            End Select

            'Get url of node or document
            If blogEntry.isPdf Then
                blogEntry.url = getMediaURL(ipContent.GetPropertyValue(Of IPublishedContent)(nodeProperties.pDFDocument).Id, String.Empty, True)
            Else
                blogEntry.url = ipContent.Url
            End If

            'If podcast, get the following info
            If blogEntry.isPodcast Then
                If ipContent.HasValue(nodeProperties.podcastAudio) Then
                    Try
                        blogEntry.podcastUrl = WebUtility.HtmlDecode(getMediaURL(ipContent.GetPropertyValue(Of IPublishedContent)(nodeProperties.podcastAudio).Id, String.Empty, True, True))
                    Catch ex As Exception
                        blogEntry.podcastUrl = WebUtility.HtmlDecode(getMediaURL(ipContent.GetPropertyValue(Of String)(nodeProperties.podcastAudio), String.Empty, True, True))
                    End Try
                End If
                If ipContent.Parent.HasValue(nodeProperties.xmlLink) Then blogEntry.rssFeedUrl = ipContent.Parent.GetPropertyValue(Of String)(nodeProperties.xmlLink)
            End If

            'Save class to return
            businessReturn.DataContainer.Add(blogEntry)

        Catch ex As Exception
            'Save error to umbraco
            Dim sb As New StringBuilder
            sb.AppendLine("linqBlogs.vb | selectBlogEntry_byId()")
            sb.AppendLine("_thisNodeId: " & _thisNodeId)
            SaveErrorMessage(ex, sb, Me.GetType())

            'Return exception
            businessReturn.ExceptionMessage = ex.ToString
        End Try

        Return businessReturn
    End Function
    Public Function selectAllBlogLinks(ByVal _parentNodeId As Integer) As BusinessReturn
        'Instantiate master variables
        Dim businessReturn As New BusinessReturn

        Try
            'Instantiate variables
            'Dim parentNode As Node = New Node(_parentNodeId)
            Dim uHelper As UmbracoHelper = New umbraco.Web.UmbracoHelper(umbraco.Web.UmbracoContext.Current)
            Dim ipParent As IPublishedContent = uHelper.TypedContent(_parentNodeId)
            Dim blogEntry As DataLayer.BlogEntry
            Dim lstBlogEntries As New List(Of DataLayer.BlogEntry)

            For Each childNode As IPublishedContent In ipParent.Children
                'Create new object
                blogEntry = New DataLayer.BlogEntry

                'Determine if entry is pdf or not
                Select Case childNode.DocumentTypeAlias
                    Case aliases.pdfEntry, aliases.lockedPdfEntry
                        blogEntry.isPdf = True
                End Select

                'Obtain property data
                blogEntry.nodeId = childNode.Id
                If childNode.HasValue(nodeProperties.title) Then blogEntry.title = childNode.GetPropertyValue(Of String)(nodeProperties.title)
                If childNode.HasValue(nodeProperties.navigationTitle) Then blogEntry.navigationTitle = childNode.GetPropertyValue(Of String)(nodeProperties.navigationTitle)
                If childNode.HasValue(nodeProperties.postDate) Then blogEntry.postDate = childNode.GetPropertyValue(Of Date)(nodeProperties.postDate)

                'Get url of node or document
                If blogEntry.isPdf Then
                    blogEntry.url = getMediaURL(childNode.GetPropertyValue(Of IPublishedContent)(nodeProperties.pDFDocument).Id, String.Empty, True)
                Else
                    blogEntry.url = childNode.Url
                End If

                lstBlogEntries.Add(blogEntry)
            Next

            'Save class to return
            businessReturn.DataContainer.Add(lstBlogEntries.OrderByDescending(Function(i) i.postDate).ToList)

        Catch ex As Exception
            'Save error to umbraco
            Dim sb As New StringBuilder
            sb.AppendLine("linqBlogs.vb | selectAllBlogLinks()")
            sb.AppendLine("_parentNodeId: " & _parentNodeId)
            SaveErrorMessage(ex, sb, Me.GetType())

            'Return exception
            businessReturn.ExceptionMessage = ex.ToString
        End Try

        Return businessReturn
    End Function
    Public Function selectTopNBlogLinks(ByVal _parentNodeId As Integer, ByVal _topN As Integer) As BusinessReturn
        'Instantiate master variables
        Dim businessReturn As New BusinessReturn

        Try
            'Instantiate variables
            Dim uHelper As UmbracoHelper = New umbraco.Web.UmbracoHelper(umbraco.Web.UmbracoContext.Current)
            Dim ipParentNode As IPublishedContent = uHelper.TypedContent(_parentNodeId)
            Dim blogEntry As DataLayer.BlogEntry
            Dim lstBlogEntries As New List(Of DataLayer.BlogEntry)

            For Each childNode As IPublishedContent In ipParentNode.Children
                'Create new object
                blogEntry = New DataLayer.BlogEntry

                'Determine if entry is pdf or not
                Select Case childNode.DocumentTypeAlias
                    Case aliases.pdfEntry, aliases.lockedPdfEntry
                        blogEntry.isPdf = True
                End Select

                'Obtain property data
                blogEntry.nodeId = childNode.Id
                blogEntry.title = childNode.GetPropertyValue(Of String)(nodeProperties.title)
                blogEntry.navigationTitle = childNode.GetPropertyValue(Of String)(nodeProperties.navigationTitle)
                blogEntry.postDate = childNode.GetPropertyValue(Of Date)(nodeProperties.postDate)

                'Get url of node or document
                If blogEntry.isPdf Then
                    blogEntry.url = getMediaURL(childNode.GetPropertyValue(Of IPublishedContent)(nodeProperties.pDFDocument).Id, String.Empty, True)
                Else
                    blogEntry.url = childNode.Url
                End If

                lstBlogEntries.Add(blogEntry)
            Next

            'Save class to return
            businessReturn.DataContainer.Add(lstBlogEntries.OrderByDescending(Function(i) i.postDate).Take(_topN).ToList)

        Catch ex As Exception
            'Save error to umbraco
            Dim sb As New StringBuilder
            sb.AppendLine("linqBlogs.vb | selectTopNBlogLinks()")
            sb.AppendLine("_parentNodeId: " & _parentNodeId)
            sb.AppendLine("_topN: " & _topN)
            SaveErrorMessage(ex, sb, Me.GetType())

            'Return exception
            businessReturn.ExceptionMessage = ex.ToString
        End Try

        Return businessReturn
    End Function
    Public Function selectAllTags() As BusinessReturn
        'Instantiate master variables
        Dim businessReturn As New BusinessReturn

        Try
            'Instantiate variables
            Dim uHelper As UmbracoHelper = New umbraco.Web.UmbracoHelper(umbraco.Web.UmbracoContext.Current)
            Dim ipTagNode As IPublishedContent = uHelper.TypedContent(siteNodes.Tags)
            Dim tag As DataLayer.Tag
            Dim lstTags As New List(Of DataLayer.Tag)

            'Obtain data for each tag
            For Each tagNode As IPublishedContent In ipTagNode.Children
                tag = New DataLayer.Tag
                tag.id = tagNode.Id
                tag.name = tagNode.Name

                lstTags.Add(tag)
            Next

            'Save class to return
            businessReturn.DataContainer.Add(lstTags)

        Catch ex As Exception
            'Save error to umbraco
            Dim sb As New StringBuilder
            sb.AppendLine("linqBlogs.vb | selectAllTags()")
            SaveErrorMessage(ex, sb, Me.GetType())

            'Return exception
            businessReturn.ExceptionMessage = ex.ToString
        End Try

        Return businessReturn
    End Function
    Public Function selectAllTags_WithinParent(ByVal id As Integer) As BusinessReturn
        'Instantiate master variables
        Dim businessReturn As New BusinessReturn

        Try
            'Instantiate variables
            Dim uHelper As UmbracoHelper = New umbraco.Web.UmbracoHelper(umbraco.Web.UmbracoContext.Current)
            Dim ipTagNode As IPublishedContent = uHelper.TypedContent(siteNodes.Tags)
            Dim ipBlogLstNode As IPublishedContent = uHelper.TypedContent(id)
            Dim tag As DataLayer.Tag
            Dim lstTags As New List(Of DataLayer.Tag)

            'Obtain data for each tag
            For Each tagNode As IPublishedContent In ipTagNode.Children
                tag = New DataLayer.Tag
                tag.id = tagNode.Id
                tag.name = tagNode.Name

                lstTags.Add(tag)
            Next

            'Loop thru each blog entry And mark in list that tag exists
            For Each blogEntry As IPublishedContent In ipBlogLstNode.Children
                If blogEntry.HasValue(nodeProperties.tags) Then
                    If blogEntry.HasValue(nodeProperties.tags) Then
                        'For Each tagId As String In blogEntry.GetPropertyValue(Of String)(nodeProperties.tags).Split(",").ToList
                        For Each ipTag As IPublishedContent In blogEntry.GetPropertyValue(Of IEnumerable(Of IPublishedContent))(nodeProperties.tags)
                            'Mark as exists in list
                            Dim item As DataLayer.Tag = lstTags.Find(Function(x) x.id = ipTag.Id) 'getIdFromGuid_byType(tagId, Core.Models.UmbracoObjectTypes.Document))
                            If Not IsNothing(item) Then item.existsInList = True
                        Next
                    End If
                End If
            Next

            'Remove all tags that are not being used (marked as false)
            lstTags.RemoveAll(Function(x) x.existsInList = False)

            'Save class to return
            businessReturn.DataContainer.Add(lstTags)

        Catch ex As Exception
            'Save error to umbraco
            Dim sb As New StringBuilder
            sb.AppendLine("linqBlogs.vb | selectAllTags_WithinParent()")
            SaveErrorMessage(ex, sb, Me.GetType())

            'Return exception
            businessReturn.ExceptionMessage = ex.ToString
        End Try

        Return businessReturn
    End Function
    Public Function selectAllAuthors_WithinParent(ByVal id As Integer) As BusinessReturn
        'Instantiate master variables
        Dim businessReturn As New BusinessReturn

        Try
            'Instantiate variables
            Dim uHelper As UmbracoHelper = New umbraco.Web.UmbracoHelper(umbraco.Web.UmbracoContext.Current)
            Dim ipAuthors As IPublishedContent = uHelper.TypedContent(siteNodes.Authors)
            Dim ipBlogLst As IPublishedContent = uHelper.TypedContent(id)
            Dim author As DataLayer.Author
            Dim lstAuthors As New List(Of DataLayer.Author)


            Try
                'Obtain data for each author
                For Each tagNode As IPublishedContent In ipAuthors.Children
                    author = New DataLayer.Author
                    author.id = tagNode.Id
                    author.name = tagNode.Name
                    lstAuthors.Add(author)
                Next
            Catch
            End Try


            'Loop thru each blog entry And mark in list that tag exists
            For Each blogEntry As IPublishedContent In ipBlogLst.Children
                If blogEntry.HasValue(nodeProperties.author) Then
                    'For Each tagId As String In blogEntry.GetPropertyValue(Of String)(nodeProperties.author).Split(",").ToList
                    Dim ipTag As IPublishedContent
                    Try
                        ipTag = blogEntry.GetPropertyValue(Of IPublishedContent)(nodeProperties.author)
                    Catch ex As Exception
                        ipTag = uHelper.TypedContent(blogEntry.GetPropertyValue(Of String)(nodeProperties.author))
                    End Try
                    'Mark as exists in list
                    If Not IsNothing(ipTag) Then
                        Dim item As DataLayer.Author = lstAuthors.Find(Function(x) x.id = ipTag.Id) 'getIdFromGuid_byType(tagId, Core.Models.UmbracoObjectTypes.Document))
                        If Not IsNothing(item) Then item.existsInList = True
                    End If

                End If
            Next

            'Remove all tags that are not being used (marked as false)
            lstAuthors.RemoveAll(Function(x) x.existsInList = False)

            'Save class to return
            businessReturn.DataContainer.Add(lstAuthors)

        Catch ex As Exception
            'Save error to umbraco
            Dim sb As New StringBuilder
            sb.AppendLine("linqBlogs.vb | selectAllAuthors_NameIdOnly()")
            sb.AppendLine("id: " & id)
            SaveErrorMessage(ex, sb, Me.GetType())

            'Return exception
            businessReturn.ExceptionMessage = ex.ToString
        End Try

        Return businessReturn
    End Function
    Public Function selectAllAuthors_NameIdOnly() As BusinessReturn
        'Instantiate master variables
        Dim businessReturn As New BusinessReturn

        Try
            'Instantiate variables
            Dim uHelper As UmbracoHelper = New umbraco.Web.UmbracoHelper(umbraco.Web.UmbracoContext.Current)
            Dim ipAuthorsNode As IPublishedContent = uHelper.TypedContent(siteNodes.Authors)
            Dim author As DataLayer.Author
            Dim lstAuthors As New List(Of DataLayer.Author)

            'Obtain data for each author
            For Each tagNode As IPublishedContent In ipAuthorsNode.Children
                author = New DataLayer.Author
                author.id = tagNode.Id
                author.name = tagNode.Name
                lstAuthors.Add(author)
            Next

            'Save class to return
            businessReturn.DataContainer.Add(lstAuthors)

        Catch ex As Exception
            'Save error to umbraco
            Dim sb As New StringBuilder
            sb.AppendLine("linqBlogs.vb | selectAllAuthors_NameIdOnly()")
            SaveErrorMessage(ex, sb, Me.GetType())

            'Return exception
            businessReturn.ExceptionMessage = ex.ToString
        End Try

        Return businessReturn
    End Function
#End Region

#Region "Methods"
    'Public Function getRssXmlUrl(ByVal ) As String
    '    Try
    '        'Instantiate variables
    '        Dim uHelper As UmbracoHelper = New Umbraco.Web.UmbracoHelper(Umbraco.Web.UmbracoContext.Current)
    '        Dim ipContent As IPublishedContent = uHelper.TypedContent(_thisNodeId)


    '        If ipContent.Parent.HasValue(nodeProperties.xmlLink) Then blogEntry.rssFeedUrl = ipContent.Parent.GetPropertyValue(Of String)(nodeProperties.xmlLink)

    '    Catch ex As Exception

    '    End Try
    'End Function
#End Region

End Class
