Imports Umbraco
Imports Umbraco.NodeFactory
Imports Common

Public Class Quicklinks
    Inherits System.Web.Mvc.ViewUserControl


#Region "Properties"
    Private blPanels As blPanels
#End Region

#Region "Handles"
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        blPanels = New blPanels
        Dim bMemberCookie As HttpCookie

        'Determine if this page is for Board Members only.
        Select Case Node.GetCurrent.NodeTypeAlias
            Case aliases.boardTemplate
                'Does BOT cookie exist and is it valid?
                bMemberCookie = Request.Cookies(miscellaneous.validBMember)
                If Not IsNothing(bMemberCookie) AndAlso CBool(bMemberCookie.Value) = True Then
                    obtainQuicklinks()
                Else
                    phQuicklinks.Visible = False
                End If
            Case Else
                obtainQuicklinks()
        End Select

    End Sub
#End Region

#Region "Methods"
    Private Sub obtainQuicklinks()
        'Instantiate variables
        Dim businessReturn As BusinessReturn

        'Obtain data
        businessReturn = blPanels.obtainQuicklinks(Node.getCurrentNodeId)

        If BusinessReturn.isValid Then
            'Extract data
            Dim QuickLinks As List(Of DataLayer.QuickLink) = DirectCast(BusinessReturn.DataContainer(0), List(Of DataLayer.QuickLink))

            lstvQuickLinks.DataSource = QuickLinks
            lstvQuickLinks.DataBind()

        Else
            phQuicklinks.Visible = False
        End If
    End Sub
#End Region

End Class