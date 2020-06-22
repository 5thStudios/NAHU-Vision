Imports Microsoft.VisualBasic
Imports Common
Imports umbraco
Imports umbraco.Core.Models
Imports umbraco.NodeFactory
Imports umbraco.Web
Imports System.Collections.Generic
Imports System
Imports System.Text
Imports System.Linq

Public Class linqPanels

#Region "Properties"
#End Region


#Region "Select"
    Public Function obtainCustomlinks(ByVal _thisNodeId As Integer) As BusinessReturn
        'Instantiate master variables
        Dim businessReturn As New BusinessReturn

        Try
            'Instantiate variables
            Dim uHelper As UmbracoHelper = New umbraco.Web.UmbracoHelper(umbraco.Web.UmbracoContext.Current)
            Dim ipContent As IPublishedContent = uHelper.TypedContent(_thisNodeId)
            Dim quickLink As DataLayer.QuickLink
            Dim lstQuickLinks As New List(Of DataLayer.QuickLink)

            'Obtain property data
            '==========================================
            'PANEL 01
            quickLink = New DataLayer.QuickLink
            If ipContent.HasValue(nodeProperties.cp_Title1) Then quickLink.title = ipContent.GetPropertyValue(Of String)(nodeProperties.cp_Title1)
            If ipContent.HasValue(nodeProperties.cp_Description1) Then quickLink.description = ipContent.GetPropertyValue(Of String)(nodeProperties.cp_Description1)
            If ipContent.HasValue(nodeProperties.cp_Quicklink1) Then
                Try
                    'quickLink.nodeId = getIdFromGuid_byType(ipContent.GetPropertyValue(Of String)(nodeProperties.cp_Quicklink1), UmbracoObjectTypes.Document)
                    quickLink.nodeId = ipContent.GetPropertyValue(Of IPublishedContent)(nodeProperties.cp_Quicklink1).Id
                    quickLink.linkUrl = uHelper.TypedContent(quickLink.nodeId).Url
                Catch ex As Exception
                End Try
            End If
            If ipContent.HasValue(nodeProperties.cp_QuicklinkTitle1) Then quickLink.linkTitle = ipContent.GetPropertyValue(Of String)(nodeProperties.cp_QuicklinkTitle1)
            If ipContent.HasValue(nodeProperties.cp_BackgroundImage1) Then quickLink.backgroundImageUrl = getMediaURL(ipContent.GetPropertyValue(Of IPublishedContent)(nodeProperties.cp_BackgroundImage1).Id, crops.CustomPanelSquared)
            If ipContent.HasValue(nodeProperties.cp_BackgroundImage1) Then quickLink.backgroundImageName = getMediaName(ipContent.GetPropertyValue(Of IPublishedContent)(nodeProperties.cp_BackgroundImage1).Id)

            lstQuickLinks.Add(quickLink)

            'PANEL 02
            quickLink = New DataLayer.QuickLink
            If ipContent.HasValue(nodeProperties.cp_Title2) Then quickLink.title = ipContent.GetPropertyValue(Of String)(nodeProperties.cp_Title2)
            If ipContent.HasValue(nodeProperties.cp_Description2) Then quickLink.description = ipContent.GetPropertyValue(Of String)(nodeProperties.cp_Description2)
            If ipContent.HasValue(nodeProperties.cp_Quicklink2) Then
                Try
                    'quickLink.nodeId = getIdFromGuid_byType(ipContent.GetPropertyValue(Of String)(nodeProperties.cp_Quicklink2), UmbracoObjectTypes.Document)
                    quickLink.nodeId = ipContent.GetPropertyValue(Of IPublishedContent)(nodeProperties.cp_Quicklink2).Id
                    quickLink.linkUrl = uHelper.TypedContent(quickLink.nodeId).Url
                Catch ex As Exception
                End Try
            End If
            If ipContent.HasValue(nodeProperties.cp_QuicklinkTitle2) Then quickLink.linkTitle = ipContent.GetPropertyValue(Of String)(nodeProperties.cp_QuicklinkTitle2)
            If ipContent.HasValue(nodeProperties.cp_BackgroundImage2) Then quickLink.backgroundImageUrl = getMediaURL(ipContent.GetPropertyValue(Of IPublishedContent)(nodeProperties.cp_BackgroundImage2).Id, crops.CustomPanelSquared)
            If ipContent.HasValue(nodeProperties.cp_BackgroundImage2) Then quickLink.backgroundImageName = getMediaName(ipContent.GetPropertyValue(Of IPublishedContent)(nodeProperties.cp_BackgroundImage2).Id)

            lstQuickLinks.Add(quickLink)

            'PANEL 03
            quickLink = New DataLayer.QuickLink
            If ipContent.HasValue(nodeProperties.cp_Title3) Then quickLink.title = ipContent.GetPropertyValue(Of String)(nodeProperties.cp_Title3)
            If ipContent.HasValue(nodeProperties.cp_Description3) Then quickLink.description = ipContent.GetPropertyValue(Of String)(nodeProperties.cp_Description3)
            If ipContent.HasValue(nodeProperties.cp_Quicklink3) Then
                Try
                    'quickLink.nodeId = getIdFromGuid_byType(ipContent.GetPropertyValue(Of String)(nodeProperties.cp_Quicklink3), UmbracoObjectTypes.Document)
                    quickLink.nodeId = ipContent.GetPropertyValue(Of IPublishedContent)(nodeProperties.cp_Quicklink3).Id
                    quickLink.linkUrl = uHelper.TypedContent(quickLink.nodeId).Url
                Catch ex As Exception
                End Try
            End If
            If ipContent.HasValue(nodeProperties.cp_QuicklinkTitle3) Then quickLink.linkTitle = ipContent.GetPropertyValue(Of String)(nodeProperties.cp_QuicklinkTitle3)
            If ipContent.HasValue(nodeProperties.cp_BackgroundImage3) Then quickLink.backgroundImageUrl = getMediaURL(ipContent.GetPropertyValue(Of IPublishedContent)(nodeProperties.cp_BackgroundImage3).Id, crops.CustomPanelSquared)
            If ipContent.HasValue(nodeProperties.cp_BackgroundImage3) Then quickLink.backgroundImageName = getMediaName(ipContent.GetPropertyValue(Of IPublishedContent)(nodeProperties.cp_BackgroundImage3).Id)

            lstQuickLinks.Add(quickLink)

            'Save class to return
            businessReturn.DataContainer.Add(lstQuickLinks)

        Catch ex As Exception
            'Save error to umbraco
            Dim sb As New StringBuilder
            sb.AppendLine("linqPanels.vb | obtainCustomlinks()")
            sb.AppendLine("_thisNodeId: " & _thisNodeId)
            SaveErrorMessage(ex, sb, Me.GetType())

            'Return exception
            businessReturn.ExceptionMessage = ex.ToString
        End Try

        Return businessReturn
    End Function
    Public Function obtainFeaturedNewsArticle(ByVal _thisNodeId As Integer) As BusinessReturn
        'Instantiate master variables
        Dim businessReturn As New BusinessReturn

        Try
            'Instantiate variables
            Dim uHelper As UmbracoHelper = New umbraco.Web.UmbracoHelper(umbraco.Web.UmbracoContext.Current)
            Dim ipContent As IPublishedContent = uHelper.TypedContent(_thisNodeId)
            Dim ipNewsArticle As IPublishedContent
            Dim newsArticle As DataLayer.NewsArticle = New DataLayer.NewsArticle
            newsArticle.articleSummary = New DataLayer.ArticleSummary
            'Dim featuredImageId As Integer
            Dim showAd As Boolean = False

            'Obtain featured article data
            If ipContent.HasValue(nodeProperties.news_showAd) Then showAd = ipContent.GetPropertyValue(Of Boolean)(nodeProperties.news_showAd)

            If ipContent.HasValue(nodeProperties.featuredItem) Then
                ipNewsArticle = ipContent.GetPropertyValue(Of IPublishedContent)(nodeProperties.featuredItem)
                'ipNewsArticle = uHelper.TypedContent(getIdFromGuid_byType(ipContent.GetPropertyValue(Of String)(nodeProperties.featuredItem), UmbracoObjectTypes.Document))

                newsArticle.articleSummary.nodeId = ipNewsArticle.Id
                If ipNewsArticle.HasValue(nodeProperties.navigationTitle) Then newsArticle.articleSummary.title = ipNewsArticle.GetPropertyValue(Of String)(nodeProperties.navigationTitle)
                If ipNewsArticle.HasValue(nodeProperties.postDate) Then newsArticle.articleSummary.postDate = ipNewsArticle.GetPropertyValue(Of Date)(nodeProperties.postDate)

                newsArticle.articleSummary.parentName = ipNewsArticle.Parent.Name
                newsArticle.articleSummary.parentUrl = ipNewsArticle.Parent.Url

                Select Case ipNewsArticle.DocumentTypeAlias
                    Case aliases.blogEntry, aliases.lockedBlogEntry, aliases.podcast
                        newsArticle.articleSummary.articleUrl = ipNewsArticle.Url

                    Case aliases.pdfEntry, aliases.lockedPdfEntry
                        Dim ipPdfArticleNode As IPublishedContent = uHelper.TypedContent(ipNewsArticle.Id)
                        Dim pdfId As Integer = getIdFromGuid_byType(ipPdfArticleNode.GetPropertyValue(Of String)(nodeProperties.pDFDocument), UmbracoObjectTypes.Media)
                        newsArticle.articleSummary.articleUrl = getMediaURL(pdfId)
                        newsArticle.articleSummary.isPdf = True

                    Case aliases.urlEntry
                        newsArticle.articleSummary.articleUrl = ipNewsArticle.GetPropertyValue(Of String)(nodeProperties.externalUrl)
                        newsArticle.articleSummary.isExternalUrl = True
                End Select






                '==============================================================================================================

                'Determine what image type will be displayed
                If ipNewsArticle.DocumentTypeAlias = aliases.urlEntry Then
                    newsArticle.articleSummary.showFeaturedImg = True
                ElseIf ipNewsArticle.HasValue(nodeProperties.featuredOptions) Then
                    newsArticle.articleSummary.featuredOptions = ipNewsArticle.GetPropertyValue(Of String)(nodeProperties.featuredOptions)
                    Select Case newsArticle.articleSummary.featuredOptions
                        Case featuredOptions.featuredImage
                            newsArticle.articleSummary.showFeaturedImg = True
                        Case featuredOptions.youtubeVideo
                            newsArticle.articleSummary.showYoutubeVideo = True
                        Case featuredOptions.vimeoVideo
                            newsArticle.articleSummary.showVimeoVideo = True
                        Case featuredOptions.none
                            'show none
                    End Select
                Else
                    newsArticle.articleSummary.showFeaturedImg = True
                End If


                If newsArticle.articleSummary.showFeaturedImg Then
                    'Obtain featured image
                    If ipNewsArticle.HasValue(nodeProperties.featuredImage) Then
                        newsArticle.articleSummary.featuredImageUrl = getMediaURL(ipNewsArticle.GetPropertyValue(Of String)(nodeProperties.featuredImage), crops.NewsPanelFeatured)
                        newsArticle.articleSummary.featuredImageName = getMediaName(ipNewsArticle.GetPropertyValue(Of String)(nodeProperties.featuredImage))
                    End If

                ElseIf (newsArticle.articleSummary.showYoutubeVideo) Then
                    newsArticle.articleSummary.featuredVideoId = ipNewsArticle.GetPropertyValue(Of String)(nodeProperties.featuredVideo)
                    newsArticle.articleSummary.featuredVideoUrl = miscellaneous.youtubePlayer.Replace("[ID]", newsArticle.articleSummary.featuredVideoId)
                    newsArticle.articleSummary.featuredImageUrl = getYoutubeImg(newsArticle.articleSummary.featuredVideoId)
                    newsArticle.articleSummary.widescreenVideo = ipNewsArticle.GetPropertyValue(Of String)(nodeProperties.widescreenVideo)

                ElseIf (newsArticle.articleSummary.showVimeoVideo) Then
                    newsArticle.articleSummary.featuredVideoId = ipNewsArticle.GetPropertyValue(Of String)(nodeProperties.featuredVideo)
                    newsArticle.articleSummary.featuredVideoUrl = miscellaneous.vimeoPlayer.Replace("[ID]", newsArticle.articleSummary.featuredVideoId)
                    If ipNewsArticle.HasValue(nodeProperties.vimeoImageId) Then
                        newsArticle.articleSummary.vimeoImageId = ipNewsArticle.GetPropertyValue(Of String)(nodeProperties.vimeoImageId)
                        newsArticle.articleSummary.featuredImageUrl = getVimeoImg(newsArticle.articleSummary.vimeoImageId)
                    End If
                    newsArticle.articleSummary.widescreenVideo = ipNewsArticle.GetPropertyValue(Of String)(nodeProperties.widescreenVideo)
                End If

            End If


            '
            businessReturn.DataContainer.Add(newsArticle)
            businessReturn.DataContainer.Add(showAd)

        Catch ex As Exception
            'Save error to umbraco
            Dim sb As New StringBuilder
            sb.AppendLine("linqPanels.vb | obtainFeaturedNewsArticle()")
            sb.AppendLine("_thisNodeId: " & _thisNodeId)
            SaveErrorMessage(ex, sb, Me.GetType())

            'Return exception
            businessReturn.ExceptionMessage = ex.ToString
        End Try

        Return businessReturn
    End Function
    Public Function obtainLatestNewsArticles(Optional ByVal addFeaturedArticle As Boolean = False) As BusinessReturn
        'Instantiate master variables
        Dim businessReturn As New BusinessReturn

        Try
            'Instantiate variables
            Dim newsArticle As DataLayer.NewsArticle = New DataLayer.NewsArticle
            Dim uHelper As UmbracoHelper = New umbraco.Web.UmbracoHelper(umbraco.Web.UmbracoContext.Current)
            Dim ipNewsArticle As IPublishedContent
            Dim lstToSort As New List(Of DataLayer.ArticleSummary)
            Dim featuredImageId As Integer

            'Obtain minimum data for sorting
            For Each ipChild As IPublishedContent In uHelper.TypedContent(siteNodes.InTheNews).Children
                Dim tempArticleSummary As New DataLayer.ArticleSummary
                tempArticleSummary.nodeId = ipChild.Id
                If ipChild.HasValue(nodeProperties.postDate) Then tempArticleSummary.postDate = ipChild.GetPropertyValue(Of Date)(nodeProperties.postDate)
                lstToSort.Add(tempArticleSummary)
            Next

            'Sort list and obtain top n
            newsArticle.lstArticleSummary = lstToSort.OrderByDescending(Function(x) x.postDate).Take(3).ToList

            'Get featured article if applicable
            If addFeaturedArticle Then
                Dim ipHome As IPublishedContent = uHelper.TypedContent(siteNodes.Home)
                If ipHome.HasValue(nodeProperties.featuredItem) Then
                    Dim _id As Integer? = ipHome.GetPropertyValue(Of Integer)(nodeProperties.featuredItem) 'getIdFromGuid_byType(ipHome.GetPropertyValue(nodeProperties.featuredNewsArticle), UmbracoObjectTypes.Document)
                    If Not IsNothing(_id) Then
                        If Not (newsArticle.lstArticleSummary.Any(Function(x) x.nodeId = _id)) Then
                            Dim tempArticleSummary As New DataLayer.ArticleSummary
                            tempArticleSummary.nodeId = _id
                            newsArticle.lstArticleSummary.Insert(0, tempArticleSummary)
                        End If
                    End If
                End If
            End If

            For Each articleSummary As DataLayer.ArticleSummary In newsArticle.lstArticleSummary
                'Obtain article data
                ipNewsArticle = uHelper.TypedContent(getIdFromGuid_byType(articleSummary.nodeId, UmbracoObjectTypes.Document))
                If ipNewsArticle.HasValue(nodeProperties.navigationTitle) Then articleSummary.title = ipNewsArticle.GetPropertyValue(Of String)(nodeProperties.navigationTitle)
                If ipNewsArticle.HasValue(nodeProperties.postDate) Then articleSummary.postDate = ipNewsArticle.GetPropertyValue(Of Date)(nodeProperties.postDate)
                If ipNewsArticle.HasValue(nodeProperties.featuredImage) Then featuredImageId = ipNewsArticle.GetPropertyValue(Of Integer)(nodeProperties.featuredImage)

                Select Case ipNewsArticle.DocumentTypeAlias
                    Case aliases.blogEntry, aliases.lockedBlogEntry, aliases.podcast
                        articleSummary.articleUrl = ipNewsArticle.Url

                    Case aliases.pdfEntry, aliases.lockedPdfEntry
                        Dim ipArticleNode As IPublishedContent = uHelper.TypedContent(ipNewsArticle.Id)
                        Dim pdfId As Integer = getIdFromGuid_byType(ipArticleNode.GetPropertyValue(Of String)(nodeProperties.pDFDocument), UmbracoObjectTypes.Media)
                        articleSummary.articleUrl = getMediaURL(pdfId)
                        articleSummary.isPdf = True

                    Case aliases.urlEntry
                        articleSummary.articleUrl = ipNewsArticle.GetPropertyValue(Of String)(nodeProperties.externalUrl)
                        articleSummary.isExternalUrl = True
                End Select

                '==============================================================================================================

                'Determine what image type will be displayed
                If ipNewsArticle.DocumentTypeAlias = aliases.urlEntry Then
                    articleSummary.showFeaturedImg = True
                ElseIf ipNewsArticle.HasValue(nodeProperties.featuredOptions) Then
                    articleSummary.featuredOptions = ipNewsArticle.GetPropertyValue(Of String)(nodeProperties.featuredOptions)
                    Select Case articleSummary.featuredOptions
                        Case featuredOptions.featuredImage
                            articleSummary.showFeaturedImg = True
                        Case featuredOptions.youtubeVideo
                            articleSummary.showYoutubeVideo = True
                        Case featuredOptions.vimeoVideo
                            articleSummary.showVimeoVideo = True
                        Case featuredOptions.none
                            'show none
                    End Select
                Else
                    articleSummary.showFeaturedImg = True
                End If


                If articleSummary.showFeaturedImg Then
                    'Obtain featured image
                    If ipNewsArticle.HasValue(nodeProperties.featuredImage) Then
                        articleSummary.featuredImageUrl = getMediaURL(ipNewsArticle.GetPropertyValue(Of IPublishedContent)(nodeProperties.featuredImage).Id, crops.ListItemSquared)
                        articleSummary.featuredImageName = getMediaName(ipNewsArticle.GetPropertyValue(Of IPublishedContent)(nodeProperties.featuredImage).Id)
                    End If

                ElseIf (articleSummary.showYoutubeVideo) Then
                    articleSummary.featuredVideoId = ipNewsArticle.GetPropertyValue(Of String)(nodeProperties.featuredVideo)
                    articleSummary.featuredVideoUrl = miscellaneous.youtubePlayer.Replace("[ID]", articleSummary.featuredVideoId)
                    articleSummary.featuredImageUrl = getYoutubeImg(articleSummary.featuredVideoId)
                    articleSummary.widescreenVideo = ipNewsArticle.GetPropertyValue(Of String)(nodeProperties.widescreenVideo)

                ElseIf (articleSummary.showVimeoVideo) Then
                    articleSummary.featuredVideoId = ipNewsArticle.GetPropertyValue(Of String)(nodeProperties.featuredVideo)
                    articleSummary.featuredVideoUrl = miscellaneous.vimeoPlayer.Replace("[ID]", articleSummary.featuredVideoId)
                    If ipNewsArticle.HasValue(nodeProperties.vimeoImageId) Then
                        articleSummary.vimeoImageId = ipNewsArticle.GetPropertyValue(Of String)(nodeProperties.vimeoImageId)
                        articleSummary.featuredImageUrl = getVimeoImg(articleSummary.vimeoImageId)
                    End If
                    articleSummary.widescreenVideo = ipNewsArticle.GetPropertyValue(Of String)(nodeProperties.widescreenVideo)
                End If
                '==============================================================================================================
            Next

            businessReturn.DataContainer.Add(newsArticle)

        Catch ex As Exception
            'Save error to umbraco
            Dim sb As New StringBuilder
            sb.AppendLine("linqPanels.vb | obtainLatestNewsArticles()")
            sb.AppendLine("addFeaturedArticle: " & addFeaturedArticle)
            SaveErrorMessage(ex, sb, Me.GetType())

            'Return exception
            businessReturn.ExceptionMessage = ex.ToString
        End Try

        Return businessReturn
    End Function
    Public Function obtainLatestNewsArticles_byList(Optional ByVal addFeaturedArticle As Boolean = False) As BusinessReturn
        'Instantiate master variables
        Dim businessReturn As New BusinessReturn

        Try
            'Instantiate variables
            Dim newsArticle As DataLayer.NewsArticle = New DataLayer.NewsArticle
            Dim uHelper As UmbracoHelper = New umbraco.Web.UmbracoHelper(umbraco.Web.UmbracoContext.Current)
            Dim ipHome As IPublishedContent = uHelper.TypedContent(siteNodes.Home)
            Dim ipNewsArticle As IPublishedContent
            Dim lstToSort As New List(Of DataLayer.ArticleSummary)
            Dim featuredImageId As Integer
            Dim articleCount As Integer = ipHome.GetPropertyValue(Of Integer)(nodeProperties.articleCount)
            Dim lstBlogs As List(Of IPublishedContent) = ipHome.GetPropertyValue(Of List(Of IPublishedContent))(nodeProperties.articleLists)



            'Obtain minimum data for sorting
            For Each ipBlog As IPublishedContent In lstBlogs
                For Each ipChild As IPublishedContent In ipBlog.Children
                    If Not IsNothing(ipChild) Then
                        Dim tempArticleSummary As New DataLayer.ArticleSummary
                        tempArticleSummary.nodeId = ipChild.Id
                        tempArticleSummary.title = ipChild.Name
                        If ipChild.HasValue(nodeProperties.postDate) Then tempArticleSummary.postDate = ipChild.GetPropertyValue(Of Date)(nodeProperties.postDate)
                        lstToSort.Add(tempArticleSummary)
                    End If
                Next
            Next


            'Sort list and obtain top n
            newsArticle.lstArticleSummary = lstToSort.OrderByDescending(Function(x) x.postDate).Take(articleCount).ToList

            'Get featured article if applicable
            If addFeaturedArticle Then
                If ipHome.HasValue(nodeProperties.featuredItem) Then
                    Dim _id As Integer? = ipHome.GetPropertyValue(Of Integer)(nodeProperties.featuredItem)
                    If Not IsNothing(_id) Then
                        If Not (newsArticle.lstArticleSummary.Any(Function(x) x.nodeId = _id)) Then
                            Dim tempArticleSummary As New DataLayer.ArticleSummary
                            tempArticleSummary.nodeId = _id
                            newsArticle.lstArticleSummary.Insert(0, tempArticleSummary)
                        End If
                    End If
                End If
            End If

            For Each articleSummary As DataLayer.ArticleSummary In newsArticle.lstArticleSummary
                'Obtain article data
                ipNewsArticle = uHelper.TypedContent(articleSummary.nodeId) 'getIdFromGuid_byType(articleSummary.nodeId, UmbracoObjectTypes.Document))
                If IsNothing(ipNewsArticle) Then
                    'Dim sb As New StringBuilder
                    'sb.AppendLine("[NULL] linqPanels.vb | obtainLatestNewsArticles_byList()")
                    'sb.AppendLine("articleSummary.nodeId: " & articleSummary.nodeId)
                    'sb.AppendLine("articleSummary.title: " & articleSummary.title)
                    'saveErrorMessage(sb.ToString, sb.ToString)
                Else
                    'Dim sb As New StringBuilder
                    'sb.AppendLine("[VALID] linqPanels.vb | obtainLatestNewsArticles_byList()")
                    'sb.AppendLine("articleSummary.nodeId: " & articleSummary.nodeId)
                    'sb.AppendLine("articleSummary.title: " & articleSummary.title)
                    'saveErrorMessage(sb.ToString, sb.ToString)

                    If ipNewsArticle.HasValue(nodeProperties.navigationTitle) Then
                        articleSummary.title = ipNewsArticle.GetPropertyValue(Of String)(nodeProperties.navigationTitle)
                    End If
                    If ipNewsArticle.HasValue(nodeProperties.postDate) Then
                        articleSummary.postDate = ipNewsArticle.GetPropertyValue(Of Date)(nodeProperties.postDate)
                    End If
                    If ipNewsArticle.HasValue(nodeProperties.featuredImage) Then
                        featuredImageId = ipNewsArticle.GetPropertyValue(Of Integer)(nodeProperties.featuredImage)
                    End If
                    articleSummary.parentName = ipNewsArticle.Parent.Name
                    articleSummary.parentUrl = ipNewsArticle.Parent.Url

                    Select Case ipNewsArticle.DocumentTypeAlias
                        Case aliases.blogEntry, aliases.lockedBlogEntry, aliases.podcast
                            articleSummary.articleUrl = ipNewsArticle.Url

                        Case aliases.pdfEntry, aliases.lockedPdfEntry
                            Dim ipArticleNode As IPublishedContent = uHelper.TypedContent(ipNewsArticle.Id)
                            Dim pdfId As Integer = getIdFromGuid_byType(ipArticleNode.GetPropertyValue(Of String)(nodeProperties.pDFDocument), UmbracoObjectTypes.Media)
                            articleSummary.articleUrl = getMediaURL(pdfId)
                            articleSummary.isPdf = True

                        Case aliases.urlEntry
                            articleSummary.articleUrl = ipNewsArticle.GetPropertyValue(Of String)(nodeProperties.externalUrl)
                            articleSummary.isExternalUrl = True
                    End Select

                    '==============================================================================================================

                    'Determine what image type will be displayed
                    If ipNewsArticle.DocumentTypeAlias = aliases.urlEntry Then
                        articleSummary.showFeaturedImg = True
                    ElseIf ipNewsArticle.HasValue(nodeProperties.featuredOptions) Then
                        articleSummary.featuredOptions = ipNewsArticle.GetPropertyValue(Of String)(nodeProperties.featuredOptions)
                        Select Case articleSummary.featuredOptions
                            Case featuredOptions.featuredImage
                                articleSummary.showFeaturedImg = True
                            Case featuredOptions.youtubeVideo
                                articleSummary.showYoutubeVideo = True
                            Case featuredOptions.vimeoVideo
                                articleSummary.showVimeoVideo = True
                            Case featuredOptions.none
                                'show none
                        End Select
                    Else
                        articleSummary.showFeaturedImg = True
                    End If


                    If articleSummary.showFeaturedImg Then
                        'Obtain featured image
                        If ipNewsArticle.HasValue(nodeProperties.featuredImage) Then
                            articleSummary.featuredImageUrl = getMediaURL(ipNewsArticle.GetPropertyValue(Of String)(nodeProperties.featuredImage), crops.ListItemSquared)
                            articleSummary.featuredImageName = getMediaName(ipNewsArticle.GetPropertyValue(Of String)(nodeProperties.featuredImage))
                        End If

                    ElseIf (articleSummary.showYoutubeVideo) Then
                        articleSummary.featuredVideoId = ipNewsArticle.GetPropertyValue(Of String)(nodeProperties.featuredVideo)
                        articleSummary.featuredVideoUrl = miscellaneous.youtubePlayer.Replace("[ID]", articleSummary.featuredVideoId)
                        articleSummary.featuredImageUrl = getYoutubeImg(articleSummary.featuredVideoId)
                        articleSummary.widescreenVideo = ipNewsArticle.GetPropertyValue(Of String)(nodeProperties.widescreenVideo)

                    ElseIf (articleSummary.showVimeoVideo) Then
                        articleSummary.featuredVideoId = ipNewsArticle.GetPropertyValue(Of String)(nodeProperties.featuredVideo)
                        articleSummary.featuredVideoUrl = miscellaneous.vimeoPlayer.Replace("[ID]", articleSummary.featuredVideoId)
                        If ipNewsArticle.HasValue(nodeProperties.vimeoImageId) Then
                            articleSummary.vimeoImageId = ipNewsArticle.GetPropertyValue(Of String)(nodeProperties.vimeoImageId)
                            articleSummary.featuredImageUrl = getVimeoImg(articleSummary.vimeoImageId)
                        End If
                        articleSummary.widescreenVideo = ipNewsArticle.GetPropertyValue(Of String)(nodeProperties.widescreenVideo)
                    End If
                End If

                '==============================================================================================================
            Next

            businessReturn.DataContainer.Add(newsArticle)

        Catch ex As Exception
            'Save error to umbraco
            Dim sb As New StringBuilder
            sb.AppendLine("linqPanels.vb | obtainLatestNewsArticles_byList()")
            sb.AppendLine("addFeaturedArticle: " & addFeaturedArticle)
            SaveErrorMessage(ex, sb, Me.GetType())

            'Return exception
            businessReturn.ExceptionMessage = ex.ToString
        End Try

        Return businessReturn
    End Function
    Public Function obtainQuicklinks(ByVal _thisNodeId As Integer) As BusinessReturn
        'Instantiate master variables
        Dim businessReturn As New BusinessReturn

        Try
            'Instantiate variables
            Dim uHelper As UmbracoHelper = New umbraco.Web.UmbracoHelper(umbraco.Web.UmbracoContext.Current)
            Dim ipContent As IPublishedContent = uHelper.TypedContent(_thisNodeId)
            Dim quickLink As DataLayer.QuickLink
            Dim lstQuickLinks As New List(Of DataLayer.QuickLink)
            'Dim lstNodeGUIDs As List(Of String)
            Dim lstIpQuicklinks As List(Of IPublishedContent)

            'Obtain property data
            '==========================================
            If ipContent.HasValue(nodeProperties.qlp_quicklinks) Then
                'lstNodeGUIDs = ipContent.GetPropertyValue(Of String)(nodeProperties.qlp_quicklinks).Split(",").ToList
                lstIpQuicklinks = ipContent.GetPropertyValue(Of List(Of IPublishedContent))(nodeProperties.qlp_quicklinks)

                'For Each guid As String In lstNodeGUIDs
                For Each ipQuickLink As IPublishedContent In lstIpQuicklinks
                    quickLink = New DataLayer.QuickLink
                    'Dim ipLinkNode As IPublishedContent

                    quickLink.nodeId = ipQuickLink.Id 'getIdFromGuid_byType(Guid, UmbracoObjectTypes.Document)
                    'ipLinkNode = uHelper.TypedContent(quickLink.nodeId)

                    'Obtain data
                    quickLink.title = ipQuickLink.GetPropertyValue(nodeProperties.title)
                    If ipQuickLink.DocumentTypeAlias = aliases.internalQuicklink Then
                        'quickLink.linkUrl = uHelper.TypedContent(getIdFromGuid_byType(ipQuickLink.GetProperty(nodeProperties.link).Value, UmbracoObjectTypes.Document)).Url

                        Try
                            quickLink.linkUrl = ipQuickLink.GetPropertyValue(Of IPublishedContent)(nodeProperties.link).Url
                        Catch
                        End Try
                    ElseIf ipQuickLink.DocumentTypeAlias = aliases.externalQuicklink Then
                        quickLink.linkUrl = ipQuickLink.GetPropertyValue(Of String)(nodeProperties.externalUrl)
                    End If
                    If ipQuickLink.HasValue(nodeProperties.description) Then quickLink.description = ipQuickLink.GetPropertyValue(Of String)(nodeProperties.description)
                    quickLink.openInNewTab = ipQuickLink.GetPropertyValue(Of Boolean)(nodeProperties.openInNewTab)
                    quickLink.backgroundImageUrl = getMediaURL(ipQuickLink.GetPropertyValue(Of String)(nodeProperties.backgroundImage), crops.Quicklink)
                    'quickLink.backgroundImageName =

                    'Add data to list
                    lstQuickLinks.Add(quickLink)
                Next
            End If

            'Save class to return
            businessReturn.DataContainer.Add(lstQuickLinks)

        Catch ex As Exception
            'Save error to umbraco
            Dim sb As New StringBuilder
            sb.AppendLine("linqPanels.vb | obtainQuicklinks()")
            sb.AppendLine("_thisNodeId: " & _thisNodeId)
            SaveErrorMessage(ex, sb, Me.GetType())

            'Return exception
            businessReturn.ExceptionMessage = ex.ToString
        End Try

        Return businessReturn
    End Function
    Public Function obtainCall2ActionPnl(ByVal _thisNodeId As Integer) As BusinessReturn
        'Instantiate master variables
        Dim businessReturn As New BusinessReturn

        Try
            'Instantiate variables
            Dim uHelper As UmbracoHelper = New umbraco.Web.UmbracoHelper(umbraco.Web.UmbracoContext.Current)
            Dim ipContent As IPublishedContent = uHelper.TypedContent(_thisNodeId)
            Dim call2ActionPnl As New DataLayer.Call2ActionPanel

            'Obtain property data
            '==========================================
            call2ActionPnl.nodeId = getIdFromGuid_byType(_thisNodeId, UmbracoObjectTypes.Document)
            If ipContent.HasValue(nodeProperties.ctap_backgroundImage) Then call2ActionPnl.backgroundImageName = getMediaName(ipContent.GetPropertyValue(Of IPublishedContent)(nodeProperties.ctap_backgroundImage).Id)
            If ipContent.HasValue(nodeProperties.ctap_backgroundImage) Then call2ActionPnl.backgroundImageUrl = getMediaURL(ipContent.GetPropertyValue(Of IPublishedContent)(nodeProperties.ctap_backgroundImage).Id)
            If ipContent.HasValue(nodeProperties.ctap_callToActionText) AndAlso ipContent.HasValue(nodeProperties.ctap_callToActionText) Then
                call2ActionPnl.callToActionLink = getNode(ipContent.GetPropertyValue(Of String)(nodeProperties.ctap_callToActionLink)).NiceUrl
                call2ActionPnl.callToActionText = ipContent.GetPropertyValue(Of String)(nodeProperties.ctap_callToActionText)
                call2ActionPnl.showCallToAction = True
            End If

            If ipContent.HasValue(nodeProperties.ctap_content) Then call2ActionPnl.content = ipContent.GetPropertyValue(Of String)(nodeProperties.ctap_content)
            If ipContent.HasValue(nodeProperties.ctap_imageOnRight) Then call2ActionPnl.imageOnRight = ipContent.GetPropertyValue(Of Boolean)(nodeProperties.ctap_imageOnRight)
            If ipContent.HasValue(nodeProperties.ctap_textAlignment) Then call2ActionPnl.textAlignment = getTextAlignment(ipContent.GetPropertyValue(Of String)(nodeProperties.ctap_textAlignment))
            If ipContent.HasValue(nodeProperties.ctap_title) Then call2ActionPnl.title = ipContent.GetPropertyValue(Of String)(nodeProperties.ctap_title)

            'Save class to return
            businessReturn.DataContainer.Add(call2ActionPnl)

        Catch ex As Exception
            'Save error to umbraco
            Dim sb As New StringBuilder
            sb.AppendLine("linqPanels.vb | obtainCall2ActionPnl()")
            sb.AppendLine("_thisNodeId: " & _thisNodeId)
            SaveErrorMessage(ex, sb, Me.GetType())

            'Return exception
            businessReturn.ExceptionMessage = ex.ToString
        End Try

        Return businessReturn
    End Function
    Public Function obtainFaqList(ByVal _thisNodeId As Integer) As BusinessReturn
        'Instantiate master variables
        Dim businessReturn As New BusinessReturn

        Try
            'Instantiate variables
            Dim uHelper As UmbracoHelper = New umbraco.Web.UmbracoHelper(umbraco.Web.UmbracoContext.Current)
            Dim ipContent As IPublishedContent = uHelper.TypedContent(_thisNodeId)
            Dim lstFAQs As New List(Of DataLayer.FAQ)
            Dim faq As DataLayer.FAQ

            'Obtain property data from each faq
            '==========================================
            For Each childNode As IPublishedContent In ipContent.Children
                '
                faq = New DataLayer.FAQ
                '
                faq.faqId = childNode.Id
                If childNode.HasValue(nodeProperties.question) Then faq.question = childNode.GetPropertyValue(Of String)(nodeProperties.question)
                If childNode.HasValue(nodeProperties.answer) Then faq.answer = childNode.GetPropertyValue(Of String)(nodeProperties.answer)
                '
                lstFAQs.Add(faq)
            Next

            'Save class to return
            businessReturn.DataContainer.Add(lstFAQs)

        Catch ex As Exception
            'Save error to umbraco
            Dim sb As New StringBuilder
            sb.AppendLine("linqPanels.vb | obtainFaqList()")
            sb.AppendLine("_thisNodeId: " & _thisNodeId)
            SaveErrorMessage(ex, sb, Me.GetType())

            'Return exception
            businessReturn.ExceptionMessage = ex.ToString
        End Try

        Return businessReturn
    End Function
    Public Function obtainBreakingNews(ByVal _thisNodeId As Integer) As BusinessReturn
        'Instantiate master variables
        Dim businessReturn As New BusinessReturn

        Try
            'Instantiate variables
            Dim uHelper As UmbracoHelper = New umbraco.Web.UmbracoHelper(umbraco.Web.UmbracoContext.Current)
            Dim ipContent As IPublishedContent = uHelper.TypedContent(_thisNodeId)
            Dim breakingNews As New DataLayer.BreakingNews

            'Obtain property data
            '==========================================
            If ipContent.HasValue(nodeProperties.bn_Content) Then breakingNews.content = ipContent.GetPropertyValue(Of String)(nodeProperties.bn_Content)
            'If ipContent.HasValue(nodeProperties.bn_Link) Then breakingNews.linkId = getIdFromGuid_byType(ipContent.GetPropertyValue(Of String)(nodeProperties.bn_Link), UmbracoObjectTypes.Document)
            'If Not IsNothing(breakingNews.linkId) Then breakingNews.linkUrl = uHelper.TypedContent(breakingNews.linkId).Url
            Try
                If ipContent.HasValue(nodeProperties.bn_Link) Then breakingNews.linkUrl = ipContent.GetPropertyValue(Of IPublishedContent)(nodeProperties.bn_Link).Url
            Catch
            End Try


            If Not String.IsNullOrWhiteSpace(breakingNews.content) AndAlso Not String.IsNullOrWhiteSpace(breakingNews.linkUrl) Then
                breakingNews.isVisible = True
            End If

            'Save class to return
            businessReturn.DataContainer.Add(breakingNews)

        Catch ex As Exception
            'Save error to umbraco
            Dim sb As New StringBuilder
            sb.AppendLine("linqPanels.vb | obtainBreakingNews()")
            sb.AppendLine("_thisNodeId: " & _thisNodeId)
            SaveErrorMessage(ex, sb, Me.GetType())

            'Return exception
            businessReturn.ExceptionMessage = ex.ToString
        End Try

        Return businessReturn
    End Function
    Public Function obtainGenericSiteData(ByVal homeId As Integer) As BusinessReturn
        'Instantiate master variables
        Dim businessReturn As New BusinessReturn

        Try
            'Instantiate variables
            Dim uHelper As UmbracoHelper = New umbraco.Web.UmbracoHelper(umbraco.Web.UmbracoContext.Current)
            Dim ipContent As IPublishedContent = uHelper.TypedContent(homeId)
            Dim genericData As New DataLayer.GenericSiteData

            'Obtain property data
            '==========================================
            Dim ipJoinNow As IPublishedContent = ipContent.GetPropertyValue(Of IPublishedContent)(nodeProperties.joinNowLink)
            If Not IsNothing(ipJoinNow) Then
                If ipContent.HasValue(nodeProperties.joinNowLink) Then genericData.joinNowLink = ipJoinNow.Url
            End If
            'If ipContent.HasValue(nodeProperties.joinNowLink) Then genericData.joinNowLink = ipContent.GetPropertyValue(Of IPublishedContent)(nodeProperties.joinNowLink).Url
            If ipContent.HasValue(nodeProperties.renewMembershipLink) Then genericData.renewMembershipLink = ipContent.GetPropertyValue(Of IPublishedContent)(nodeProperties.renewMembershipLink).Url
            'If ipContent.HasValue(nodeProperties.memberBenefits) Then genericData.memberBenefits = ipContent.GetPropertyValue(Of IPublishedContent)(nodeProperties.memberBenefits).Url

            'Dim ipJoinNow As IPublishedContent = ipContent.GetPropertyValue(Of IPublishedContent)(nodeProperties.joinNowLink)
            'genericData.joinNowLink = ipJoinNow.Url

            'If ipContent.HasValue(nodeProperties.renewMembershipLink) Then genericData.renewMembershipLink = ipContent.GetPropertyValue(Of String)(nodeProperties.renewMembershipLink)
            'genericData.renewMembershipLink = uHelper.TypedContent(getIdFromGuid_byType(genericData.renewMembershipLink, UmbracoObjectTypes.Document)).Url

            If ipContent.HasValue(nodeProperties.memberBenefits) Then genericData.memberBenefits = ipContent.GetPropertyValue(Of String)(nodeProperties.memberBenefits)
            genericData.memberBenefits = uHelper.TypedContent(getIdFromGuid_byType(genericData.memberBenefits, UmbracoObjectTypes.Document)).Url

            'Determine if login is disabled
            If ipContent.HasValue(nodeProperties.disableLogin) Then genericData.loginDisabled = ipContent.GetPropertyValue(Of Boolean)(nodeProperties.disableLogin)

            'Save class to return
            businessReturn.DataContainer.Add(genericData)

        Catch ex As Exception
            'Save error to umbraco
            Dim sb As New StringBuilder
            sb.AppendLine("linqPanels.vb | obtainGenericSiteData()")
            SaveErrorMessage(ex, sb, Me.GetType())

            'Return exception
            businessReturn.ExceptionMessage = ex.ToString
        End Try

        Return businessReturn
    End Function
#End Region

#Region "Private Methods"
#End Region

End Class
