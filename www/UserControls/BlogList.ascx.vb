Imports Umbraco
Imports Umbraco.NodeFactory
Imports Common
Imports Umbraco.Examine.Linq
Imports Umbraco.Web
Imports Umbraco.Core.Models

Public Class BlogList
    Inherits System.Web.Mvc.ViewUserControl



#Region "Properties"
#End Region

#Region "Handles"
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Instantiate variables
        Dim ipCurrentPg As IPublishedContent = UmbracoContext.Current.PublishedContentRequest.PublishedContent

        'Dim thisNode As Node = Node.GetCurrent
        Dim bMemberCookie As HttpCookie
        Dim userLoggedIn As Boolean = False

        '============================ PSEUDOCODE ==================================
        'if BOT page
        '	If BOT account cookie exists AND = true
        '		if IMIS session cookie exists
        '			If proxy session id active
        '				Display list
        '			else
        '				log in using proxy
        '				Refresh page to display list
        '		else
        '			sign in using proxy acct
        '			Refresh page to display list
        '	else
        '		display login
        'else
        '	Display list
        '==========================================================================



        'Determine if this page is for Board Members only.
        Select Case ipCurrentPg.DocumentTypeAlias
            Case aliases.listBlogBoardOfTrustees
                ' Try
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
                'Catch
                '    'display login
                '    pnlLogin.Visible = True
                'End Try

            Case aliases.podcastList
                'Set hidden value
                hfldIsBoardPg.Value = False

                'Obtain rss info
                If ipCurrentPg.HasProperty(nodeProperties.xmlLink) Then
                    hlnkPodcastXml.NavigateUrl = ipCurrentPg.GetPropertyValue(Of String)(nodeProperties.xmlLink)
                    pnlPodcastXml.Visible = True
                End If

                'Display List
                pnlFullContent.Visible = True
                populateList()

            Case Else
                'Set hidden value
                hfldIsBoardPg.Value = False

                'Display List
                pnlFullContent.Visible = True
                populateList()
        End Select
    End Sub
#End Region

#Region "Methods"
    Private Sub populateList()
        'Instantiate variables
        Dim ipCurrentPg As IPublishedContent = UmbracoContext.Current.PublishedContentRequest.PublishedContent
        Dim lstBlogEntries As SortedList(Of Integer, Date) = New SortedList(Of Integer, Date)
        Dim nvQueryStrings As NameValueCollection = Request.QueryString

        '
        'If nvQueryStrings.AllKeys.Contains(nodeProperties.search) Then

        'Else
        'Obtain list of all child pages.
        For Each blog As IPublishedContent In ipCurrentPg.Children
            'Add list to listview
            lstBlogEntries.Add(blog.Id, blog.GetPropertyValue(Of Date)(nodeProperties.postDate))
        Next
        'End If

        'Display entries
        lvBlogEntries.DataSource = lstBlogEntries.OrderByDescending(Function(x) x.Value).ToList()
        lvBlogEntries.DataBind()
    End Sub
#End Region

End Class