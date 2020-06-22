Imports Common
Imports Umbraco
Imports Umbraco.NodeFactory


Public Class TopUpcomingEvents
    Inherits System.Web.Mvc.ViewUserControl


#Region "Properties"
    Private blEvents As blEvents
    Private returnMsg As BusinessReturn
#End Region

#Region "Handles"
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            'Instantiate variables
            blEvents = New blEvents

            'Obtain all events
            returnMsg = blEvents.selectAllEvents(4)

            'If valid return, display events
            If returnMsg.isValid Then
                'Obtain list of events from return msg.
                Dim lstEvents As List(Of DataLayer.EventItem) = DirectCast(returnMsg.DataContainer(0), List(Of DataLayer.EventItem))

                'Loop thru events and create event times in custom notes column to match design requirements.
                For Each _eventItem As DataLayer.EventItem In lstEvents
                    addCustomFields(_eventItem)
                Next

                'Display Events
                lstviewUpcomingEvents.DataSource = lstEvents
                lstviewUpcomingEvents.DataBind()

            Else
                Response.Write(returnMsg.ExceptionMessage)
            End If

            'Set the navigation url
            hlnkAllEvents.NavigateUrl = New Node(siteNodes.Events).NiceUrl
            hlnkSeeAll.NavigateUrl = New Node(siteNodes.Events).NiceUrl

        Catch ex As Exception
            'Save error to umbraco
            Dim sb As New StringBuilder
            sb.AppendLine("TopUpcomingEvents.ascx | Page_Load()")
            SaveErrorMessage(ex, sb, Me.GetType())

            Response.Write(ex.ToString)
        End Try
    End Sub
#End Region

#Region "Methods"
    Public Sub addCustomFields(ByRef _eventItem As DataLayer.EventItem)
        'Create custom time entry
        If _eventItem.allDayEvent Then
            'Show as an all-day event
            _eventItem.eventNote = "All-Day Event"
        Else
            'Create the FROM time
            Dim from As New StringBuilder
            Dim fromAMPM As New StringBuilder
            For Each c As Char In _eventItem.fromHour
                If IsNumeric(c) Then
                    from.Append(c)
                Else
                    fromAMPM.Append(c)
                End If
            Next
            from.Append(_eventItem.fromMinute)
            from.Append(fromAMPM.ToString)

            'Create the TO time
            Dim toTime As New StringBuilder
            Dim toAMPM As New StringBuilder
            For Each c As Char In _eventItem.toHour
                If IsNumeric(c) Then
                    toTime.Append(c)
                Else
                    toAMPM.Append(c)
                End If
            Next
            toTime.Append(_eventItem.fromMinute)
            toTime.Append(toAMPM.ToString)

            'Add updated time entry to record.
            _eventItem.eventNote = from.ToString & "&ndash;" & toTime.ToString
        End If

        'Create url for links
        _eventItem.eventUrl = New Node(_eventItem.eventId).NiceUrl
        '_eventItem.customFields.url = New Node(_eventItem.eventId).NiceUrl
    End Sub
#End Region

End Class