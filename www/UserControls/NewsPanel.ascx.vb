Imports Umbraco
Imports Umbraco.NodeFactory
Imports Common
Imports System.Collections.Generic
Imports System
Imports System.Text

Public Class NewsPanel
    Inherits System.Web.Mvc.ViewUserControl


#Region "Properties"
#End Region

#Region "Handles"
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            'Instantiate variables
            Dim blPanels As New blPanels
            Dim businessReturn As BusinessReturn = blPanels.obtainFeaturedNewsArticle(Node.getCurrentNodeId)
            Dim newsArticle As DataLayer.NewsArticle
            Dim showAd As Boolean = False

            If businessReturn.isValid Then
                'Extract data
                newsArticle = DirectCast(businessReturn.DataContainer(0), DataLayer.NewsArticle)
                showAd = DirectCast(businessReturn.DataContainer(1), Boolean)

                'Display data
                ltrlTitle.Text = newsArticle.articleSummary.title
                ltrlDatePosted.Text = newsArticle.articleSummary.postDate.ToString("MMMM dd, yyyy")
                imgFeatured.ImageUrl = newsArticle.articleSummary.featuredImageUrl
                imgFeatured.AlternateText = newsArticle.articleSummary.featuredImageName
                hlnkFeaturedArticle.NavigateUrl = newsArticle.articleSummary.articleUrl
                hlnkFeaturedArticle_Title.NavigateUrl = newsArticle.articleSummary.articleUrl
                If newsArticle.articleSummary.isPdf Then
                    hlnkFeaturedArticle.Target = "_blank"
                    hlnkFeaturedArticle_Title.Target = "_blank"
                End If
                If newsArticle.articleSummary.isExternalUrl Then
                    hlnkFeaturedArticle.Target = "_blank"
                    hlnkFeaturedArticle_Title.Target = "_blank"
                End If

                hlnkParent.Text = newsArticle.articleSummary.parentName
                hlnkParent.NavigateUrl = newsArticle.articleSummary.parentUrl

                If Not showAd Then
                    pnlTopNews.CssClass = pnlTopNews.CssClass.Replace("16", "24") 'Set top news section to take full space
                    pnlAdSpace.Visible = False
                End If

                'lstArticleSummary.Add(newsArticle.articleSummary)
            Else
                'Save error to umbraco
                Dim sb As New StringBuilder
                sb.AppendLine("NewsPanel.ascx | Page_Load()")
                Dim exc As Exception = New Exception(businessReturn.ExceptionMessage)
                SaveErrorMessage(exc, sb, Me.GetType())
            End If

            'Instantiate variables
            businessReturn = New BusinessReturn
            businessReturn = blPanels.obtainLatestNewsArticles_byList(True)
            newsArticle = New DataLayer.NewsArticle

            If businessReturn.isValid Then
                'Extract data
                newsArticle = DirectCast(businessReturn.DataContainer(0), DataLayer.NewsArticle)
                lstvNewsPnls.DataSource = newsArticle.lstArticleSummary
                lstvNewsPnls.DataBind()



                'gv1.DataSource = newsArticle.lstArticleSummary
                'gv1.DataBind()

            End If

            'Set link to all news items
            'hlnkAllNews.NavigateUrl = New Node(siteNodes.InTheNews).NiceUrl

        Catch ex As Exception
            'Save error to umbraco
            Dim sb As New StringBuilder
            sb.AppendLine("LatestNews.ascx | Page_Load()")
            SaveErrorMessage(ex, sb, Me.GetType())
        End Try
    End Sub
#End Region

#Region "Methods"
#End Region

End Class