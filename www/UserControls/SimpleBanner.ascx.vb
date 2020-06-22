Imports Umbraco
Imports Umbraco.NodeFactory
Imports Common
Imports Umbraco.Core
Imports Umbraco.Core.Services
Imports Umbraco.Core.Models

Public Class SimpleBanner
    Inherits System.Web.Mvc.ViewUserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Instantiate variables
        Dim businessReturn As BusinessReturn
        Dim blBanners = New blBanners

        'Obtain data
        businessReturn = blBanners.obtainSimpleBanner(Node.getCurrentNodeId)

        If businessReturn.isValid Then
            'Extract data
            Dim simpleBanner As DataLayer.SimpleBanner = DirectCast(businessReturn.DataContainer(0), DataLayer.SimpleBanner)

            'Display data
            ltrlTitle.Text = simpleBanner.title
            If Not String.IsNullOrEmpty(simpleBanner.subtitle) Then
                ltrlSubtitle.Text = simpleBanner.subtitle
                phSubtitle.Visible = True
            End If
            pnlText.CssClass += simpleBanner.dropShadowClass

            imgBackground.ImageUrl = simpleBanner.backgroundImageUrl
            imgBackground.AlternateText = simpleBanner.backgroundImageName

        Else
            phSimpleBanner.Visible = False
        End If
    End Sub

End Class