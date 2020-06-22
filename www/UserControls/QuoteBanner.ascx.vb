Imports Umbraco
Imports Umbraco.NodeFactory
Imports Common

Public Class QuoteBanner
    Inherits System.Web.Mvc.ViewUserControl


#Region "Properties"
    Private blQuoteBanner As blBanners
#End Region


#Region "Handles"
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Instantiate variables
        Dim businessReturn As BusinessReturn
        blQuoteBanner = New blBanners

        'Obtain data
        businessReturn = blQuoteBanner.obtainBanner(Node.getCurrentNodeId)

        If businessReturn.isValid Then
            'Extract data
            Dim quoteBanner As DataLayer.QuoteBanner = DirectCast(businessReturn.DataContainer(0), DataLayer.QuoteBanner)

            'Display data
            pnlContent.HorizontalAlign = quoteBanner.textAlignment
            ltrlTitle.Text = quoteBanner.title
            If quoteBanner.showSubtitle Then
                ltrlSubtitle.Text = quoteBanner.subtitle
                ltrlSubtitle2.Text = quoteBanner.subtitle
                ltrlSubtitle3.Text = quoteBanner.subtitle
                pnlSubtitle.Visible = True

                'Add dropshadow class if present
                pnlText.CssClass = quoteBanner.dropShadowClass

                Select Case quoteBanner.textAlignment
                    Case HorizontalAlign.Center
                        pnlSubtitleAlignCenter.Visible = True
                    Case HorizontalAlign.Left
                        pnlSubtitleAlignLeft.Visible = True
                    Case HorizontalAlign.Right
                        pnlSubtitleAlignright.Visible = True
                    Case Else
                        pnlSubtitleAlignCenter.Visible = True
                End Select
            End If

            If quoteBanner.showCallToAction Then
                hlnkCallToAction.Text = quoteBanner.callToActionText
                hlnkCallToAction.NavigateUrl = quoteBanner.callToActionLink
                hlnkCallToAction.Visible = True
            End If

            imgBackground.ImageUrl = quoteBanner.backgroundImageUrl
            imgBackground.AlternateText = quoteBanner.backgroundImageName


            'Display data- Mobile
            pnlContent_Mbl.HorizontalAlign = quoteBanner.textAlignment
            ltrlTitle_Mbl.Text = quoteBanner.title
            If quoteBanner.showSubtitle Then
                ltrlSubtitle_Mbl.Text = quoteBanner.subtitle
                ltrlSubtitle2_Mbl.Text = quoteBanner.subtitle
                ltrlSubtitle3_Mbl.Text = quoteBanner.subtitle
                pnlSubtitle_Mbl.Visible = True

                'Add dropshadow class if present
                pnlText_Mbl.CssClass = quoteBanner.dropShadowClass

                Select Case quoteBanner.textAlignment
                    Case HorizontalAlign.Center
                        pnlSubtitleAlignCenter_Mbl.Visible = True
                    Case HorizontalAlign.Left
                        pnlSubtitleAlignLeft_Mbl.Visible = True
                    Case HorizontalAlign.Right
                        pnlSubtitleAlignRight_Mbl.Visible = True
                    Case Else
                        pnlSubtitleAlignCenter_Mbl.Visible = True
                End Select
            End If

            If quoteBanner.showCallToAction Then
                hlnkCallToAction_Mbl.Text = quoteBanner.callToActionText
                hlnkCallToAction_Mbl.NavigateUrl = quoteBanner.callToActionLink
                hlnkCallToAction_Mbl.Visible = True
            End If

            'Image property that is grabbed via the stylesheet.
            pnlQuoteBanner_Mbl.Style.Add("background-image", "url(" & quoteBanner.backgroundImageUrl & ")")
        Else
            pnlQuoteBanner.Visible = False
        End If
    End Sub
#End Region


End Class