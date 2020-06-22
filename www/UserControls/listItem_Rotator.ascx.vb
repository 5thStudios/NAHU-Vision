Imports Umbraco
Imports Umbraco.NodeFactory
Imports Common


Public Class listItem_Rotator
    Inherits System.Web.Mvc.ViewUserControl


#Region "Properties"
    Public Property rotator As DataLayer.Rotator
#End Region


#Region "Handles"
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsNothing(rotator) Then
            'Assign data to page
            ltrlTitle.Text = rotator.title
            If (rotator.showSubtitle) Then ltrlSubtitle.Text = rotator.subtitle
            If (rotator.showCallToAction) Then
                hlnkCallToAction.Text = rotator.callToActionText
                hlnkCallToAction.NavigateUrl = rotator.callToActionLink
                hlnkCallToAction.Visible = True
            End If
            img.ImageUrl = rotator.backgroundImageUrl
            img.AlternateText = rotator.backgroundImageName
            pnlContent.HorizontalAlign = getTextAlignment(rotator.textAlignment)
        End If
    End Sub
#End Region


#Region "Methods"
#End Region

End Class