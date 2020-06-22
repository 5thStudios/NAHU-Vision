Imports Umbraco
Imports Umbraco.NodeFactory
Imports Common
Imports Newtonsoft.Json

Public Class ListItem_UpcomingEvent
    Inherits System.Web.UI.UserControl


#Region "Properties"
    Public Property EventItem As DataLayer.EventItem
#End Region


#Region "Handles"
    Private Sub Page_PreRender(sender As Object, e As EventArgs) Handles Me.PreRender
        'Instantiate variables
        Dim isFirstRecord As Boolean = True

        '
        ltrlTitle.Text = EventItem.eventTitle
        ltrlTitle_grid.Text = EventItem.eventTitle
        hlnkReadMore.NavigateUrl = New Node(EventItem.eventId).NiceUrl
        hlnkReadMore_grid.NavigateUrl = New Node(EventItem.eventId).NiceUrl
        ltrlDescription.Text = EventItem.description
        ltrlMonth.Text = MonthName(EventItem.eventDate.Month).Substring(0, 3).ToUpper
        ltrlDay.Text = EventItem.eventDate.Day
        ltrlDate.Text = EventItem.eventDate.ToString("MMMM dd, yyyy")
        ltrlDate_grid.Text = EventItem.eventDate.ToString("MMMM dd, yyyy")
        If Not String.IsNullOrEmpty(EventItem.featuredImgUrl) Then
            imgFeatured.AlternateText = EventItem.featuredImgName
            imgFeatured.ImageUrl = EventItem.featuredImgUrl
            imgFeatured_grid.AlternateText = EventItem.featuredImgName
            imgFeatured_grid.ImageUrl = EventItem.featuredImgUrl
        End If

        '
        pnlViewItem.Attributes.Add("data-chapters", JsonConvert.SerializeObject(EventItem.chapters))
        pnlViewItem.Attributes.Add("data-eventTypes", JsonConvert.SerializeObject(EventItem.eventTypes))
        pnlViewItem.Attributes.Add("data-filterid", EventItem.eventId)

        'Add each chapter
        For Each chapter As DataLayer.Chapter In EventItem.chapters
            'Add spacer between tag
            If isFirstRecord Then
                isFirstRecord = False
            Else
                phChapters.Controls.Add(New LiteralControl(" &ndash; ")) 'Add seperator text between multiple tags.
                phChapters_grid.Controls.Add(New LiteralControl(" &ndash; "))
            End If

            'Add tag
            Dim hlnk As New HyperLink
            hlnk.Text = chapter.name
            hlnk.Attributes.Add("data-filterby", "chapter")
            hlnk.Attributes.Add("data-filtername", chapter.name)
            hlnk.Attributes.Add("data-filterid", chapter.id)
            hlnk.Attributes.Add("onclick", "return false;")
            phChapters.Controls.Add(hlnk)

            'Add tag  (REPEATED BECAUSE YOU CANNOT ADD THE SAME CONTROL TO DIFFERENT OBJECTS.)
            hlnk = New HyperLink
            hlnk.Text = chapter.name
            hlnk.Attributes.Add("data-filterby", "chapter")
            hlnk.Attributes.Add("data-filtername", chapter.name)
            hlnk.Attributes.Add("data-filterid", chapter.id)
            hlnk.Attributes.Add("onclick", "return false;")
            phChapters_grid.Controls.Add(hlnk)
        Next

        'Add each event type
        isFirstRecord = True
        For Each eventType As DataLayer.EventType In EventItem.eventTypes
            'Add spacer between tag
            If isFirstRecord Then
                isFirstRecord = False
            Else
                phEventTypes.Controls.Add(New LiteralControl(" &ndash; ")) 'Add seperator text between multiple tags.
            End If

            'Add tag
            Dim hlnk As New HyperLink
            hlnk.Text = eventType.name
            hlnk.Attributes.Add("data-filterby", "eventType")
            hlnk.Attributes.Add("data-filtername", eventType.name)
            hlnk.Attributes.Add("data-filterid", eventType.id)
            hlnk.Attributes.Add("onclick", "return false;")
            phEventTypes.Controls.Add(hlnk)
        Next

        '
        If EventItem.allDayEvent Then
            'Display as all-day event
            pnlAllDayEvent.Visible = True
            pnlFromTo.Visible = False
        Else
            'Display as timed event
            pnlAllDayEvent.Visible = False
            pnlFromTo.Visible = True

            'Create the FROM time
            Dim from As New StringBuilder
            Dim fromAMPM As New StringBuilder
            For Each c As Char In EventItem.fromHour
                If IsNumeric(c) Then
                    from.Append(c)
                Else
                    fromAMPM.Append(c)
                End If
            Next
            from.Append(EventItem.fromMinute)
            from.Append(fromAMPM.ToString)
            ltrlFrom.Text = from.ToString

            'Create the TO time
            Dim toTime As New StringBuilder
            Dim toAMPM As New StringBuilder
            For Each c As Char In EventItem.toHour
                If IsNumeric(c) Then
                    toTime.Append(c)
                Else
                    toAMPM.Append(c)
                End If
            Next
            toTime.Append(EventItem.toMinute)
            toTime.Append(toAMPM.ToString)
            ltrlTo.Text = toTime.ToString
        End If

    End Sub
#End Region


#Region "Methods"
    Private Function getEventCalendar(ByVal _thisNode As Node) As Node
        If _thisNode.NodeTypeAlias = aliases.eventCalendar Or _thisNode.NodeTypeAlias = aliases.calendarListNew Then
            Return _thisNode
        Else
            Return getEventCalendar(_thisNode.Parent)
        End If
    End Function
#End Region

End Class