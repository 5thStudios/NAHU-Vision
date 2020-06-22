Imports Umbraco
Imports Umbraco.NodeFactory
Imports Common

Public Class QuoteBannerWithNav
    Inherits System.Web.Mvc.ViewUserControl


#Region "Properties"
    Private blBanners As blBanners
#End Region

#Region "Handles"
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Instantiate variables
        Dim businessReturn As BusinessReturn
        blBanners = New blBanners
        Dim quoteBannerWithNav As DataLayer.QuoteBannerWithNav

        Try
            'Obtain data
            businessReturn = blBanners.obtainQuoteBannerWithNav(Node.getCurrentNodeId)

            If businessReturn.isValid Then
                'Extract data
                quoteBannerWithNav = DirectCast(businessReturn.DataContainer(0), DataLayer.QuoteBannerWithNav)

                'Display data
                imgBackground.AlternateText = quoteBannerWithNav.backgroundImageName
                imgBackground.ImageUrl = quoteBannerWithNav.backgroundImageUrl

                ltrlQuote.Text = quoteBannerWithNav.quote
                ltrlAuthor.Text = quoteBannerWithNav.author
                pnlPrimaryText.HorizontalAlign = quoteBannerWithNav.textAlignment

                If quoteBannerWithNav.showSideNav Then
                    lstvLinks.DataSource = quoteBannerWithNav.lstSideNavLinks
                    lstvLinks.DataBind()
                Else
                    pnlSideNav.Visible = False
                End If

                pnlPrimaryText.CssClass += quoteBannerWithNav.dropShadowClass


                'Dim lst As New List(Of DataLayer.QuoteBannerWithNav)
                'lst.Add(quoteBannerWithNav)
                'gv.DataSource = lst
                'gv.DataBind()

                'gv2.DataSource = quoteBannerWithNav.lstSideNavLinks
                'gv2.DataBind()

            Else
                'Hide banner
                pnlQuoteBannerWithNav.Visible = False
            End If
        Catch ex As Exception
            'Save error to umbraco
            Dim sb As New StringBuilder
            sb.AppendLine("QuoteBannerWithNav.vb | Load()")
            SaveErrorMessage(ex, sb, Me.GetType())

            'Hide banner
            pnlQuoteBannerWithNav.Visible = False
        End Try


    End Sub
#End Region

End Class
