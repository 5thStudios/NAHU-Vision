Imports Umbraco
Imports Umbraco.NodeFactory
Imports Common

Public Class TextBlockLocked
    Inherits System.Web.Mvc.ViewUserControl


#Region "Properties"
    Private blBanners As blBanners
    Private blPanels As blPanels
    Private Enum mview
        ShowNavOnLeft
        ShowNavOnRight
    End Enum
#End Region

#Region "Handles"
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Instantiate variables
        Dim userLoggedIn As Boolean = isUserLoggedIn(Request.Cookies(nodeProperties.SessionGuid))
        Dim thisNode As Node = Node.GetCurrent
        Dim bMemberCookie As HttpCookie


        'Determine if this page is for Board Members only.
        Select Case Node.GetCurrent.NodeTypeAlias
            Case aliases.boardTemplate
                Try
                    'Set hidden value
                    hfldIsBoardPg.Value = True

                    'Does BOT cookie exist and is it valid?
                    bMemberCookie = Request.Cookies(miscellaneous.validBMember)
                    If Not IsNothing(bMemberCookie) AndAlso CBool(bMemberCookie.Value) = True Then
                        'Is IMIS proxy user logged in
                        userLoggedIn = isUserLoggedIn(Request.Cookies(nodeProperties.SessionGuid))
                        If Not userLoggedIn Then
                            'Log proxy user into IMIS
                            logBoardMemberByProxy()
                        End If

                        'Display List
                        pnlFullContent.Visible = True
                        populateList()
                    Else
                        'display login
                        pnlLogin.Visible = True
                    End If
                Catch
                    'display login
                    pnlLogin.Visible = True
                End Try

            Case Else

                'TEMP=================================================
                'userLoggedIn = True
                'pnlFullContent.BorderColor = Drawing.Color.Red
                'pnlFullContent.BorderWidth = 6
                'pnlFullContent.BorderStyle = BorderStyle.Solid


                'Determine how to display content
                If userLoggedIn Then
                    pnlFullContent.Visible = True 'Show content as unlocked
                Else
                    pnlLockedContent.Visible = True 'Show content as locked
                    'hlnkMemberBenefits.NavigateUrl = New Node(siteNodes.MemberBenefits).NiceUrl
                    'hlnkJoin.NavigateUrl = New Node(siteNodes.JoinNow).NiceUrl 'Add link to join page.


                    'Instantiate variables
                    Dim businessReturn As BusinessReturn
                    Dim genericData As New DataLayer.GenericSiteData
                    blPanels = New blPanels

                    'Obtain data
                    businessReturn = blPanels.obtainGenericSiteData(getHomeNodeId(Node.getCurrentNodeId))

                    If businessReturn.isValid Then
                        'Extract data
                        genericData = DirectCast(businessReturn.DataContainer(0), DataLayer.GenericSiteData)

                        hlnkJoin.NavigateUrl = genericData.joinNowLink
                        hlnkJoin2.NavigateUrl = genericData.joinNowLink
                        hlnkMemberBenefits.NavigateUrl = genericData.memberBenefits
                        hlnkMemberBenefits2.NavigateUrl = genericData.memberBenefits
                    End If


                End If

                populateList()
        End Select

    End Sub
#End Region

#Region "Methods"
    Private Sub populateList()
        'Instantiate variables
        Dim businessReturn As BusinessReturn
        Dim textBlock As New DataLayer.TextBlock
        blBanners = New blBanners

        'Obtain data
        businessReturn = blBanners.obtainTextBlock(Node.getCurrentNodeId)

        If BusinessReturn.isValid Then
            'Extract data
            textBlock = DirectCast(BusinessReturn.DataContainer(0), DataLayer.TextBlock)

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
                'End If

                If textBlock.showSideNav Then
                    pnlSide.Visible = True
                    pnlAdSpace.Visible = textBlock.showAd

                    If textBlock.showSideNav Then
                        'Generate side menu
                        Dim sideNav As HtmlGenericControl = generateSideNav(Node.getCurrentNodeId)
                        If Not IsNothing(sideNav) Then phSideNav.Controls.Add(sideNav)
                    End If
                Else
                    pnlContent.CssClass += " medium-push-6 large-push-4 end"
                End If
            End If






            'add to hidden field if page is cc donation pg.
            hfldIsCCDonationPg.Value = textBlock.isCCDonationPg.ToString.ToLower
            hfldIsBankDonationPg.Value = textBlock.isBankDonationPg.ToString.ToLower

            If textBlock.isCCDonationPg Or textBlock.isBankDonationPg Then
                pnlLogInAsPACMember.Visible = True
                pnlInvalidUser.Visible = True
                pnlFullContent.Visible = True
            End If
            'pnlLogInAsPACMember.Visible = textBlock.isCCDonationPg
            'pnlInvalidUser.Visible = textBlock.isCCDonationPg
            'If textBlock.isCCDonationPg Then pnlFullContent.Visible = True





            'Dim lstTextBlock As New List(Of DataLayer.TextBlock)
            'lstTextBlock.Add(textBlock)
            'gv.DataSource = lstTextBlock
            'gv.DataBind()
        Else
            pnlTextBlock.Visible = False
        End If
    End Sub
#End Region
End Class