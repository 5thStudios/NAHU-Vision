Imports Umbraco
Imports Umbraco.NodeFactory
Imports Common
Imports System.Net
Imports System.Web.Script.Serialization
Imports Newtonsoft.Json

Public Class BlogPage
    Inherits System.Web.Mvc.ViewUserControl


#Region "Properties"
    Private blBlogs As blBlogs
#End Region

#Region "Handles"
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            'Instantiate variables
            Dim userLoggedIn As Boolean = isUserLoggedIn(Request.Cookies(nodeProperties.SessionGuid))
            blBlogs = New blBlogs
            Dim businessReturn As BusinessReturn
            Dim blogEntry As DataLayer.BlogEntry

            'Obtain data
            businessReturn = blBlogs.selectBlog_byId(Node.getCurrentNodeId)

            If businessReturn.isValid Then
                'Extract data
                blogEntry = DirectCast(businessReturn.DataContainer(0), DataLayer.BlogEntry)

                'Adjust lock by if user is logged in or not.
                If blogEntry.isLocked Then
                    blogEntry.isLocked = Not userLoggedIn
                End If

                'Display Data
                ltrlTitle.Text = blogEntry.title
                ltrlDatePosted.Text = blogEntry.postDate.ToString("MMMM d, yyyy")
                hlnkAuthor.Text = blogEntry.author.name




                'TO DO: (ONLY IF THERE WILL BE MACROS ADDED TO BLOG PAGES)
                '   ADD "DISPLAY MACRO" CHECKBOX PROPERTY TO ENTRY DOCTYPE FOR BLOGS. (AND ANYWHERE ELSE THAT USES THIS)
                '   ADDED LITERAL NEXT TO UMBRACO:ITEM TAG
                '   ADD BOOLEAN TO BLOGENTRY CLASS AND BRING DOWN VALUE
                '   IF FALSE, HIDE UMBRACO TAG AND USE LITERAL

                ''Display data
                'If Not blogEntry.displayMacro Then
                '    umbItemContent.Visible = False
                ltrlContent.Text = blogEntry.content
                'End If



                'Categories
                Dim firstEntry As Boolean = True
                For Each tag As DataLayer.Tag In blogEntry.lstTags
                    Dim hlnk As New HyperLink
                    If Not firstEntry Then
                        Dim span As New HtmlGenericControl("span")
                        span.InnerHtml = "&nbsp;&nbsp;|&nbsp;&nbsp;"
                        phCategories.Controls.Add(span)
                    End If

                    hlnk.Text = tag.name
                    hlnk.Attributes.Add("data-tagid", tag.id)
                    phCategories.Controls.Add(hlnk)
                    firstEntry = False
                Next

                'Determine how to display content
                If blogEntry.isLocked Then
                    pnlLockedContent.Visible = True 'Show content as locked
                    hlnkMemberBenefits.NavigateUrl = New Node(siteNodes.MemberBenefits).NiceUrl
                Else
                    pnlFullContent.Visible = True 'Show content as unlocked
                End If

                'Display proper featured item
                Select Case True
                    Case blogEntry.showFeaturedImg, blogEntry.isLocked
                        phFeaturedImage.Visible = True
                        imgFeatured.ImageUrl = blogEntry.featuredImageUrl
                        imgFeatured.AlternateText = blogEntry.featuredImageName
                        'Show locked video icon if locked video
                        imgLockedVideo.Visible = Not blogEntry.showFeaturedImg

                    Case blogEntry.showYoutubeVideo
                        pnlYoutubeVideo.Visible = True
                        If blogEntry.widescreenVideo Then pnlYoutubeVideo.CssClass += miscellaneous.widescreen

                        ifrYoutubeVideo.Src = blogEntry.featuredVideoUrl

                    Case blogEntry.showVimeoVideo
                        pnlVimeoVideo.Visible = True
                        If blogEntry.widescreenVideo Then pnlVimeoVideo.CssClass += miscellaneous.widescreen

                        ifrVimeoVideo.Src = blogEntry.featuredVideoUrl
                End Select

                'Show proper podcast data
                If blogEntry.isPodcast Then
                    If Not String.IsNullOrEmpty(blogEntry.rssFeedUrl) Then
                        hlnkPodcastXml.Visible = True
                        hlnkPodcastXml.NavigateUrl = blogEntry.rssFeedUrl
                    End If

                    If Not String.IsNullOrEmpty(blogEntry.podcastUrl) Then
                        phPodcast.Visible = True
                        hlnkListenToPodcast.NavigateUrl = blogEntry.podcastUrl
                    End If
                End If

                '====================================================================
                'Dim lstBlogEntry As New List(Of DataLayer.BlogEntry)
                'lstBlogEntry.Add(blogEntry)
                'gv.DataSource = lstBlogEntry
                'gv.DataBind()

                'gv2.DataSource = blogEntry.lstTags
                'gv2.DataBind()

                'Dim lstAuthors As New List(Of DataLayer.Author)
                'lstAuthors.Add(blogEntry.author)
                'gv3.DataSource = lstAuthors
                'gv3.DataBind()
                '====================================================================

            Else
                'pnlEvent.Visible = False
            End If

            'Add parent page url to back button
            hlnkReturnToList.NavigateUrl = Node.GetCurrent.Parent.NiceUrl

            'Add link to join page.
            hlnkJoin.NavigateUrl = New Node(siteNodes.JoinNow).NiceUrl

        Catch ex As Exception
            'Save error to umbraco
            Dim sb As New StringBuilder
            sb.AppendLine("BlogPage.ascx | Load()")
            SaveErrorMessage(ex, sb, Me.GetType())

            'pnlEvent.Visible = False
        End Try

    End Sub
#End Region

#Region "Methods"
#End Region

End Class