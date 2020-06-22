Imports Umbraco
Imports Umbraco.NodeFactory
Imports Common


Public Class AlertMsg
    Inherits System.Web.Mvc.ViewUserControl


#Region "Properties"
#End Region

#Region "Handles"
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If getHomeNodeId(Node.getCurrentNodeId) = siteNodes.Home Then
                'Determine if a cookie exists for hiding an alert message
                Dim hideAlertMsg As Boolean = False
                If Not Request.Cookies("HideAlertMsg") Is Nothing Then
                    Try
                        hideAlertMsg = CBool(Request.Cookies("HideAlertMsg").Value)
                    Catch
                    End Try
                End If


                If Not hideAlertMsg Then
                    'Instantiate variables
                    Dim blPanels As New blPanels
                    Dim businessReturn As BusinessReturn = blPanels.obtainBreakingNews(siteNodes.Home)
                    Dim breakingNews As DataLayer.BreakingNews

                    If businessReturn.isValid Then
                        'Extract data
                        breakingNews = DirectCast(businessReturn.DataContainer(0), DataLayer.BreakingNews)

                        'Display data
                        If breakingNews.isVisible Then
                            phAlertMessage.Visible = True
                            ltrlContent.Text = breakingNews.content
                            hlnkReadMore.NavigateUrl = breakingNews.linkUrl
                        End If
                    End If
                End If

                'Throw New System.Exception("JF- Test Exception Thrown")

            End If
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