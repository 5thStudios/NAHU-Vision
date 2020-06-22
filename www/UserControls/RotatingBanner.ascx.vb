Imports Umbraco
Imports Umbraco.NodeFactory
Imports Common
Imports Umbraco.Core.Services
Imports Umbraco.Core
Imports Umbraco.Core.Models

Public Class RotatingBanner
    Inherits System.Web.Mvc.ViewUserControl


#Region "Properties"
    Private blRotators As blRotators
#End Region


#Region "Handles"
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Instantiate variables
        Dim businessReturn As BusinessReturn
        blRotators = New blRotators
        Dim lstRotators As List(Of DataLayer.Rotator)

        businessReturn = blRotators.obtainListOfRotators(Node.getCurrentNodeId)

        If businessReturn.isValid Then
            '
            lstRotators = DirectCast(businessReturn.DataContainer(0), List(Of DataLayer.Rotator))

            lstvRotatingBannerImgs.DataSource = lstRotators
            lstvRotatingBannerImgs.DataBind()

            lstvBanners.DataSource = lstRotators
            lstvBanners.DataBind()

            lstvSideNav.DataSource = lstRotators
            lstvSideNav.DataBind()

            lstvRotatingBanner_Mbl.DataSource = lstRotators
            lstvRotatingBanner_Mbl.DataBind()


            'gv.DataSource = lstRotators
            'gv.DataBind()

        End If
    End Sub
#End Region

    'Public Sub saveErrorMessage2(ByVal _exceptionMsg As String, ByVal _generalMsg As String)
    '    'Create a new node
    '    Dim cs As IContentService = ApplicationContext.Current.Services.ContentService
    '    Dim siteErrors As IContent = cs.GetById(siteNodes.SiteErrors)
    '    Dim timeStamp As DateTime = DateTime.Now
    '    Dim errorMsg As IContent = cs.CreateContentWithIdentity(timeStamp.ToString, siteErrors, aliases.errorMessage)

    '    'Set values
    '    errorMsg.SetValue(nodeProperties.exceptionMessage, _exceptionMsg)
    '    errorMsg.SetValue(nodeProperties.generalMessage, _generalMsg)

    '    Response.Write("<br>exceptionMessage<br>")

    '    'Save values
    '    Dim attempt As Attempt(Of Publishing.PublishStatus) = cs.SaveAndPublishWithStatus(errorMsg)

    '    'Response.Write("attempt: " & attempt.Exception.ToString & "<br>")
    '    Response.Write(attempt.Result.ToString & "<br>")
    '    Response.Write(attempt.Success.ToString & "<br>")

    'End Sub

End Class