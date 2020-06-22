Imports Common
Imports Umbraco
Imports Umbraco.NodeFactory


Public Class CustomPanels
    Inherits System.Web.Mvc.ViewUserControl


#Region "Properties"
    Private blPanels As blPanels
#End Region

#Region "Handles"
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            'Instantiate variables
            blPanels = New blPanels
            Dim businessReturn As BusinessReturn
            Dim lstQuickLinks As List(Of DataLayer.QuickLink)
            Dim quickLink1 As DataLayer.QuickLink
            Dim quickLink2 As DataLayer.QuickLink
            Dim quickLink3 As DataLayer.QuickLink

            'Obtain data
            businessReturn = blPanels.obtainCustomlinks(Node.getCurrentNodeId)

            If businessReturn.isValid Then
                'Extract data
                lstQuickLinks = DirectCast(businessReturn.DataContainer(0), List(Of DataLayer.QuickLink))
                quickLink1 = lstQuickLinks(0)
                quickLink2 = lstQuickLinks(1)
                quickLink3 = lstQuickLinks(2)

                'gv.DataSource = lstQuickLinks
                'gv.DataBind()

                'Display data -- PANEL 01
                ltrlTitle01.Text = quickLink1.title
                ltrlDescription1.Text = quickLink1.description
                hlnkPnl01.NavigateUrl = quickLink1.linkUrl
                hlnkPnl01.Text = quickLink1.linkTitle
                bgImage01.ImageUrl = quickLink1.backgroundImageUrl
                bgImage01.AlternateText = quickLink1.backgroundImageName


                'Display data -- PANEL 02
                ltrlTitle02.Text = quickLink2.title
                ltrlDescription2.Text = quickLink2.description
                hlnkPnl02.NavigateUrl = quickLink2.linkUrl
                hlnkPnl02.Text = quickLink2.linkTitle
                bgImage02.ImageUrl = quickLink2.backgroundImageUrl
                bgImage02.AlternateText = quickLink2.backgroundImageName


                'Display data -- PANEL 03
                ltrlTitle03.Text = quickLink3.title
                ltrlDescription3.Text = quickLink3.description
                hlnkPnl03.NavigateUrl = quickLink3.linkUrl
                hlnkPnl03.Text = quickLink3.linkTitle
                bgImage03.ImageUrl = quickLink3.backgroundImageUrl
                bgImage03.AlternateText = quickLink3.backgroundImageName

            Else
                ltrlTitle01.Text = businessReturn.ExceptionMessage
            End If



        Catch ex As Exception
            'Save error to umbraco
            Dim sb As New StringBuilder
            sb.AppendLine("CustomPanels.ascx | Page_Load()")
            SaveErrorMessage(ex, sb, Me.GetType())

            pnlCustomPanels.Visible = False
        End Try
    End Sub
#End Region

#Region "Methods"
#End Region


End Class