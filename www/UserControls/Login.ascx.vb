Imports umbraco
Imports umbraco.NodeFactory
Imports Common


Public Class Login
    Inherits System.Web.Mvc.ViewUserControl


#Region "Properties"
    Private blPanels As blPanels
#End Region

#Region "Handles"
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load


        'mvLogin.ActiveViewIndex = 0


        'Add condensed homepage's name to hidden field for jquery to add as class to body tag.
        Try
            Dim homeNode As Node = New Node(getHomeNodeId(Node.getCurrentNodeId))
            If homeNode.HasProperty(nodeProperties.siteClass) Then hfldRootClass.Value = homeNode.GetProperty(nodeProperties.siteClass).Value.Replace(" ", "")
        Catch
        End Try

        'Instantiate variables
        Dim businessReturn As BusinessReturn
        Dim genericData As New DataLayer.GenericSiteData
        blPanels = New blPanels

        'Obtain data
        businessReturn = blPanels.obtainGenericSiteData(getHomeNodeId(Node.getCurrentNodeId))

        If businessReturn.isValid Then
            'Extract data
            genericData = DirectCast(businessReturn.DataContainer(0), DataLayer.GenericSiteData)

            hlnkJoinNow.NavigateUrl = genericData.joinNowLink
            hlnkRenewMembership.NavigateUrl = genericData.renewMembershipLink

            'Show as disabled if disabled in umbraco
            If genericData.loginDisabled Then
                mvLogin.ActiveViewIndex = 1
            End If

            'Dim lst As New List(Of DataLayer.GenericSiteData)
            'lst.Add(genericData)
            'gv1.DataSource = lst
            'gv1.DataBind()
        Else
            'pnlTextBlock.Visible = False
        End If

    End Sub
#End Region

#Region "Methods"
#End Region

End Class