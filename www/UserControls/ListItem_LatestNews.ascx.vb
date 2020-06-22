Imports Common


Public Class ListItem_LatestNews
    Inherits System.Web.UI.UserControl


#Region "Properties"
    Public Property ArticleSummary As DataLayer.ArticleSummary
#End Region

#Region "Handles"
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            'Show data
            lblTitle.Text = ArticleSummary.title
            lblDate.Text = ArticleSummary.postDate.ToString("MMMM d, yyyy")
            lblTitle_Mbl.Text = ArticleSummary.title
            lblDate_Mbl.Text = ArticleSummary.postDate.ToString("MMMM d, yyyy")
            imgFeatured.AlternateText = ArticleSummary.featuredImageName
            hlnkNewsArticle.NavigateUrl = ArticleSummary.articleUrl
            hlnkNewsArticle_Title.NavigateUrl = ArticleSummary.articleUrl
            hlnkNewsArticle_TitleMbl.NavigateUrl = ArticleSummary.articleUrl
            If ArticleSummary.isPdf Then hlnkNewsArticle.Target = "_blank"
            If ArticleSummary.isPdf Then hlnkNewsArticle_Title.Target = "_blank"
            If ArticleSummary.isPdf Then hlnkNewsArticle_TitleMbl.Target = "_blank"
            If Not String.IsNullOrEmpty(ArticleSummary.featuredImageUrl) Then imgFeatured.ImageUrl = ArticleSummary.featuredImageUrl
            hlnkParent.Text = ArticleSummary.parentName
            hlnkParent_Mbl.Text = ArticleSummary.parentName
            hlnkParent.NavigateUrl = ArticleSummary.parentUrl
            hlnkParent_Mbl.NavigateUrl = ArticleSummary.parentUrl

            'Dim lst As New List(Of DataLayer.ArticleSummary)
            'lst.Add(ArticleSummary)
            'gv.DataSource = lst
            'gv.DataBind()


        Catch ex As Exception
            'Save error to umbraco
            Dim sb As New StringBuilder
            sb.AppendLine("ListItem_LatestNews.ascx | Page_Load()")
            SaveErrorMessage(ex, sb, Me.GetType())
        End Try
    End Sub
#End Region

#Region "Methods"
#End Region

End Class