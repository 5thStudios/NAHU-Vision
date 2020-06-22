Imports System
Imports System.Text
Imports Common
Imports Umbraco
Imports Umbraco.NodeFactory


Public Class LatestNews
    Inherits System.Web.UI.UserControl


#Region "Properties"
#End Region

#Region "Handles"
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            'Instantiate variables
            Dim blPanels As New blPanels
            Dim businessReturn As BusinessReturn = blPanels.obtainLatestNewsArticles_byList(False)
            Dim newsArticle As DataLayer.NewsArticle

            If businessReturn.isValid Then
                'Extract data
                newsArticle = DirectCast(businessReturn.DataContainer(0), DataLayer.NewsArticle)
                lstv.DataSource = newsArticle.lstArticleSummary
                lstv.DataBind()

                'gv.DataSource = newsArticle.lstArticleSummary
                'gv.DataBind()
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