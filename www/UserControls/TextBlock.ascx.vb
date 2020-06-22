Imports Umbraco.NodeFactory
Imports Common
Imports Umbraco.Web
Imports Umbraco.Core.Models

'Imports Umbraco
'Imports Umbraco.Web.Templates
'Imports Umbraco.Core.Services
'Imports Umbraco.Core


Public Class TextBlock
    Inherits System.Web.Mvc.ViewUserControl '(Of IPublishedContent)


#Region "Properties"
    Private blBanners As blBanners
    Private Enum mview
        ShowNavOnLeft
        ShowNavOnRight
    End Enum
#End Region

#Region "Handles"
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Instantiate variables
        Dim businessReturn As BusinessReturn
        Dim textBlock As New DataLayer.TextBlock
        blBanners = New blBanners

        'Obtain data
        businessReturn = blBanners.obtainTextBlock(Node.getCurrentNodeId)

        If businessReturn.isValid Then
            'Extract data
            textBlock = DirectCast(businessReturn.DataContainer(0), DataLayer.TextBlock)

            'Determine what side to show the side nav
            If textBlock.showSideOnRight Then

                'Show nav on right-hand side
                mvTextBlock.ActiveViewIndex = mview.ShowNavOnRight

                'Display data
                'If Not textBlock.displayMacro Then
                '    umbItemContent_Rt.Visible = False
                ltrlContent_Rt.Text = textBlock.content
                    'End If

                    If textBlock.showSideNav Then
                    pnlSide_Rt.Visible = True
                    pnlAdSpace_Rt.Visible = textBlock.showAd

                    If textBlock.showSideNav Then
                        'Generate side menu
                        Dim sideNav As HtmlGenericControl = generateSideNav(Node.getCurrentNodeId)
                        If Not IsNothing(sideNav) Then phSideNav_Rt.Controls.Add(sideNav)
                    End If
                Else
                    pnlContent_Rt.CssClass += " medium-push-6 large-push-4"
                End If
            Else

                'Show nav on left-hand side
                mvTextBlock.ActiveViewIndex = mview.ShowNavOnLeft

                'Display data
                'If Not textBlock.displayMacro Then
                '    umbItemContent.Visible = False
                ltrlContent.Text = textBlock.content
                'ltrlContent.Text = RenderMacros(textBlock.content, 1126)
                'End If

                'Dim uHelper = New Umbraco.Web.UmbracoHelper(Umbraco.Web.UmbracoContext.Current)
                'Dim ipc As IPublishedContent = uHelper.TypedContent(1126)
                'ltrlContent.Text = ipc.GetPropertyValue(Of String)("tb_content")


                If textBlock.showSideNav Then
                    pnlSide.Visible = True
                    pnlAdSpace.Visible = textBlock.showAd

                    If textBlock.showSideNav Then
                        'Generate side menu
                        Dim sideNav As HtmlGenericControl = generateSideNav(Node.getCurrentNodeId)
                        If Not IsNothing(sideNav) Then phSideNav.Controls.Add(sideNav)
                    End If
                Else
                    pnlContent.CssClass += " medium-push-6 large-push-4"
                End If
            End If

            'Dim lstTextBlock As New List(Of DataLayer.TextBlock)
            'lstTextBlock.Add(textBlock)
            'gv.DataSource = lstTextBlock
            'gv.DataBind()

        Else
            pnlTextBlock.Visible = False
        End If
    End Sub
#End Region

#Region "Methods"
#End Region
End Class