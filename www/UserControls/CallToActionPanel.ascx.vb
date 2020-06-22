Imports Umbraco
Imports Umbraco.NodeFactory
Imports Common


Public Class CallToActionPanel
    Inherits System.Web.Mvc.ViewUserControl


#Region "Properties"
    Private blPanels As blPanels
    Private Enum mview
        ShowImgOnLeft
        ShowImgOnRight
    End Enum
#End Region

#Region "Handles"
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Instantiate variables
        Dim businessReturn As BusinessReturn
        Dim call2ActionPnl As New DataLayer.Call2ActionPanel
        blPanels = New blPanels

        'Obtain data
        businessReturn = blPanels.obtainCall2ActionPnl(Node.getCurrentNodeId)

        If businessReturn.isValid Then
            'Extract data
            call2ActionPnl = DirectCast(businessReturn.DataContainer(0), DataLayer.Call2ActionPanel)

            'Dim lst As New List(Of DataLayer.Call2ActionPanel)
            'lst.Add(call2ActionPnl)
            'gv.DataSource = lst
            'gv.DataBind()

            'Determine what side to show the side nav
            If call2ActionPnl.imageOnRight Then
                'Show nav on right-hand side
                mvCall2Action.ActiveViewIndex = mview.ShowImgOnRight

                'Display Data
                pnlImg_Rt.Attributes.Add("style", "background-image:url(" & call2ActionPnl.backgroundImageUrl & ");")
                ltrlTitle_Rt.Text = call2ActionPnl.title
                ltrlContent_Rt.Text = call2ActionPnl.content
                If call2ActionPnl.showCallToAction Then
                    hlnkAction_Rt.NavigateUrl = call2ActionPnl.callToActionLink
                    hlnkAction_Rt.Text = call2ActionPnl.callToActionText
                    hlnkAction_Rt.Visible = True
                End If
                pnlContent_Rt.HorizontalAlign = call2ActionPnl.textAlignment

            Else
                'Show nav on left-hand side
                mvCall2Action.ActiveViewIndex = mview.ShowImgOnLeft

                'Display Data
                pnlImg.Attributes.Add("style", "background-image:url(" & call2ActionPnl.backgroundImageUrl & ");")
                ltrlTitle.Text = call2ActionPnl.title
                ltrlContent.Text = call2ActionPnl.content
                If call2ActionPnl.showCallToAction Then
                    hlnkAction.NavigateUrl = call2ActionPnl.callToActionLink
                    hlnkAction.Text = call2ActionPnl.callToActionText
                    hlnkAction.Visible = True
                End If
                pnlContent.HorizontalAlign = call2ActionPnl.textAlignment

            End If

        Else
            phCallToAction.Visible = False
        End If
    End Sub
#End Region

#Region "Methods"
#End Region
End Class