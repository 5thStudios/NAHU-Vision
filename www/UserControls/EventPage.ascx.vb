Imports Umbraco
Imports Umbraco.NodeFactory
Imports Common


Public Class EventPage
    Inherits System.Web.Mvc.ViewUserControl


#Region "Properties"
    Private blEvents As blEvents
#End Region

#Region "Handles"
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            'Instantiate variables
            blEvents = New blEvents
            Dim businessReturn As BusinessReturn
            Dim eventItem As DataLayer.EventItem
            Dim lstEvents As List(Of DataLayer.EventItem)
            Dim sbLocation As New StringBuilder

            'Obtain data
            businessReturn = blEvents.selectEvent_byId(Node.getCurrentNodeId, True, True)

            If businessReturn.isValid Then
                'Extract data
                lstEvents = DirectCast(businessReturn.DataContainer(0), List(Of DataLayer.EventItem))
                eventItem = lstEvents(0)

                'Display Data
                ltrlContent.Text = eventItem.content
                If Not String.IsNullOrEmpty(eventItem.featuredImgUrl) Then
                    imgFeatured.ImageUrl = eventItem.featuredImgUrl
                    imgFeatured.AlternateText = eventItem.featuredImgName
                End If
                ltrlTitle.Text = eventItem.eventTitle

                If eventItem.chapters.Count > 0 Then
                    For Each chapter As DataLayer.Chapter In eventItem.chapters
                        Dim pnl As New Panel
                        Dim ltrl As New Literal
                        ltrl.Text = chapter.name
                        pnl.Controls.Add(ltrl)
                        phChapters.Controls.Add(pnl)
                    Next
                Else
                    phChapterAffilitation.Visible = False
                End If

                If Not String.IsNullOrEmpty(eventItem.eventLocation.locationName) Then sbLocation.Append(eventItem.eventLocation.locationName & "<br />")
                If Not String.IsNullOrEmpty(eventItem.eventLocation.address01) Then sbLocation.Append(eventItem.eventLocation.address01 & "<br />")
                If Not String.IsNullOrEmpty(eventItem.eventLocation.address02) Then sbLocation.Append(eventItem.eventLocation.address02 & "<br />")
                If Not String.IsNullOrEmpty(eventItem.eventLocation.city) Then sbLocation.Append(eventItem.eventLocation.city & ", ")
                If Not String.IsNullOrEmpty(eventItem.eventLocation.state) Then sbLocation.Append(eventItem.eventLocation.state & " ")
                If Not String.IsNullOrEmpty(eventItem.eventLocation.zip) Then sbLocation.Append(eventItem.eventLocation.zip)
                If sbLocation.ToString.Length = 0 Then
                    phLocation.Visible = False
                Else
                    ltrlLocation.Text = sbLocation.ToString
                End If


                If Not String.IsNullOrEmpty(eventItem.registerUrl) Then
                    pnlRegister.Visible = True
                    hlnkRegister.NavigateUrl = eventItem.registerUrl
                End If


                If eventItem.members.Count > 0 Then
                    For Each member As DataLayer.Member In eventItem.members
                        Dim pnl As New Panel
                        Dim ltrl As New Literal
                        Dim href As New HyperLink

                        ltrl.Text = member.firstName & " " & member.lastName
                        pnl.Controls.Add(ltrl)
                        phContacts.Controls.Add(pnl)

                        pnl = New Panel
                        href.NavigateUrl = "mailto:" & member.email
                        href.Text = member.email
                        pnl.Controls.Add(href)
                        phContacts.Controls.Add(pnl)
                    Next
                    phContactList.Visible = True
                End If

                ucEventTimeFrame.eventItem = eventItem

                'Add sponsors
                lvSponsors.DataSource = eventItem.lstSponsors
                lvSponsors.DataBind()

                '====================================================================
                'gv.DataSource = lstEvents
                'gv.DataBind()

                'gvChapters.DataSource = lstEvents(0).chapters
                'gvChapters.DataBind()

                'gvMembers.DataSource = lstEvents(0).members
                'gvMembers.DataBind()

                'Dim lstLocations As New List(Of DataLayer.EventLocation)
                'lstLocations.Add(lstEvents(0).eventLocation)
                'gvLocations.DataSource = lstLocations
                'gvLocations.DataBind()

                'Dim lstRecurringTimeDetails As New List(Of DataLayer.RecurringTimeDetails)
                'lstRecurringTimeDetails.Add(lstEvents(0).recurringTimeDetails)
                'gvRecurringEvent.DataSource = lstRecurringTimeDetails
                'gvRecurringEvent.DataBind()
                '====================================================================

            Else
                pnlEvent.Visible = False
            End If
        Catch ex As Exception
            'Save error to umbraco
            Dim sb As New StringBuilder
            sb.AppendLine("EventPage.ascx | Load()")
            SaveErrorMessage(ex, sb, Me.GetType())

            pnlEvent.Visible = False
        End Try
    End Sub
#End Region

#Region "Methods"
#End Region

End Class