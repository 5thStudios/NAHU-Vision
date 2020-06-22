Imports Microsoft.VisualBasic
Imports Common
Imports Umbraco
Imports Umbraco.NodeFactory
Imports System.Data
Imports Newtonsoft.Json
Imports Umbraco.Core.Models
Imports Umbraco.Core
Imports Umbraco.Web
Imports System.Collections.Generic

Public Class blEvents
#Region "Properties"
    Private eventItem As DataLayer.EventItem
    Private lstRecurringEvents As List(Of DataLayer.RecurringEventItem)
    Private lstGeneratedEvents As List(Of DataLayer.EventItem)
    Private linqEvents As linqEvents
#End Region


#Region "Selects"
    Public Function selectAllEvents(Optional ByVal _getTopNumber As UInt16 = 0, Optional ByVal _getEventLocation As Boolean = False, Optional ByVal _getContactInfo As Boolean = False,
                                    Optional ByVal _catagory As String = "", Optional ByVal _calendar As Integer = 0) As BusinessReturn
        'Create response class
        Dim returnMsg As BusinessReturn = New BusinessReturn

        Try
            'Instantiate variables
            Dim lstEvents As List(Of DataLayer.EventItem) = New List(Of DataLayer.EventItem)


            'Merge all lists into single list
            If _calendar > 0 Then
                'Obtain specific calendar by ID
                For Each item As DataLayer.EventItem In selectEvents_byCalendar(_calendar, _getTopNumber, _getEventLocation, _getContactInfo, _catagory).DataContainer(0)
                    lstEvents.Add(item)
                Next
            Else
                'Obtain all calendars
                Dim nodeIds = System.Enum.GetValues(GetType(calendars))
                For Each nodeId As calendars In nodeIds
                    For Each item As DataLayer.EventItem In selectEvents_byCalendar(nodeId, _getTopNumber, _getEventLocation, _getContactInfo, _catagory).DataContainer(0)
                        lstEvents.Add(item)
                    Next
                Next
            End If


            'Add sorted list to return msg.
            If _getTopNumber > 0 Then
                returnMsg.DataContainer.Add(lstEvents.OrderBy(Function(C) C.eventDate).ThenBy(Function(F) F.eventTitle).Take(_getTopNumber).ToList)
            Else
                returnMsg.DataContainer.Add(lstEvents.OrderBy(Function(C) C.eventDate).ThenBy(Function(F) F.eventTitle).ToList)
            End If

            Return returnMsg

        Catch ex As Exception
            'Save error to umbraco
            Dim sb As New StringBuilder
            sb.AppendLine("blEvents.vb | selectAllEvents()")
            sb.AppendLine("_getTopNumber: " & _getTopNumber)
            sb.AppendLine("_getEventLocation: " & _getEventLocation)
            sb.AppendLine("_getContactInfo: " & _getContactInfo)
            sb.AppendLine("_catagory: " & _catagory)
            sb.AppendLine("_calendar: " & _calendar)
            SaveErrorMessage(ex, sb, Me.GetType())

            returnMsg.ExceptionMessage = "Error: " & ex.ToString & "<br />"
            Return returnMsg
        End Try
    End Function
    Public Function selectEvents_byCalendar(ByVal _calendar As calendars, Optional ByVal _getTopNumber As UInt16 = 0, Optional ByVal _getEventLocation As Boolean = False,
                                            Optional ByVal _getContactInfo As Boolean = False, Optional ByVal _catagory As String = "") As BusinessReturn
        'Create response class
        Dim returnMsg As BusinessReturn = New BusinessReturn

        Try
            'Instantiate variables
            'Dim eventsNode As Node = New Node(_calendar)
            Dim uHelper As UmbracoHelper = New umbraco.Web.UmbracoHelper(umbraco.Web.UmbracoContext.Current)
            Dim ipEventsNode As IPublishedContent = uHelper.TypedContent(_calendar)
            Dim lstEvents As List(Of DataLayer.EventItem) = New List(Of DataLayer.EventItem)
            lstRecurringEvents = New List(Of DataLayer.RecurringEventItem)

            'Loop thru folders to find all events
            For Each eventFolder As IPublishedContent In ipEventsNode.Children
                If eventFolder.DocumentTypeAlias = aliases.singleEvents Then
                    'Recursively loop thru folders to find all single events.
                    findAllSingleEvents(eventFolder, lstEvents, False, False, _catagory)
                ElseIf eventFolder.DocumentTypeAlias = aliases.recurringEvents Then
                    'Obtain all recurring events
                    findAllRecurringEvents(eventFolder, False, False, _catagory)
                End If
            Next

            'parse json of timeframe for each record in recurring events.
            convertJsonListsToEventList(lstRecurringEvents)

            'Merge lists
            For Each item As DataLayer.EventItem In lstGeneratedEvents
                lstEvents.Add(item)
            Next

            'Remove any entries older than today.
            For i As Int32 = (lstEvents.Count - 1) To 0 Step -1
                If (lstEvents(i).eventDate < Date.Today) Or (lstEvents(i).eventDate > Date.Today.AddYears(2)) Then
                    lstEvents.RemoveAt(i)
                Else
                    'Only update if event is not all day.
                    If lstEvents(i).allDayEvent = False Then
                        'Instantiate variables
                        Dim _eventDate As DateTime
                        Dim _newEventDate As DateTime
                        Dim _hour As Integer
                        Dim _minute As Integer
                        Dim _year As Integer
                        Dim _month As Integer
                        Dim _day As Integer
                        Dim _morning As Boolean = True

                        'Obtain event's current datetime
                        _eventDate = lstEvents(i).eventDate

                        'Obtain numeric values of time
                        _hour = getOnlyNumbers(lstEvents(i).fromHour)
                        _minute = getOnlyNumbers(lstEvents(i).fromMinute)

                        'Determine if the entry starts in the morning or afternoon
                        If lstEvents(i).fromHour.Contains("PM") Then _morning = False

                        'Adjust for midnight
                        If _hour = 12 AndAlso _morning = True Then _hour = 0

                        'Adjust for afternoon in military time.
                        If Not _morning AndAlso _hour <> 12 Then _hour += 12

                        'Obtain rest of date segments
                        _year = _eventDate.Year
                        _month = _eventDate.Month
                        _day = _eventDate.Day

                        'Build new datetime for event
                        _newEventDate = New DateTime(_year, _month, _day, _hour, _minute, 0)

                        'Update the eventDate with the start time
                        lstEvents(i).eventDate = _newEventDate
                    End If
                End If
            Next

            'Add sorted list to return msg.
            If _getTopNumber > 0 Then
                returnMsg.DataContainer.Add(lstEvents.OrderBy(Function(C) C.eventDate).Take(_getTopNumber).ToList)
            Else
                returnMsg.DataContainer.Add(lstEvents.OrderBy(Function(C) C.eventDate).ToList)
            End If

            'returnMsg.DataContainer.Add(lstRecurringEvents)

            Return returnMsg
        Catch ex As Exception
            'Save error to umbraco
            Dim sb As New StringBuilder
            sb.AppendLine("blEvents.vb | selectEvents_byCalendar()")
            sb.AppendLine("_getTopNumber: " & _getTopNumber)
            sb.AppendLine("_getEventLocation: " & _getEventLocation)
            sb.AppendLine("_getContactInfo: " & _getContactInfo)
            sb.AppendLine("_catagory: " & _catagory)
            sb.AppendLine("_calendar: " & _calendar)
            SaveErrorMessage(ex, sb, Me.GetType())

            returnMsg.ExceptionMessage = "Error: " & ex.ToString & "<br />"
            Return returnMsg
        End Try
    End Function
    Public Function selectEventList_byCalendar(ByVal _calendar As calendars, Optional ByVal _getTopNumber As UInt16 = 0, Optional ByVal _getEventLocation As Boolean = False,
                                            Optional ByVal _getContactInfo As Boolean = False, Optional ByVal _catagory As String = "") As List(Of DataLayer.EventItem)
        'Create response class
        Dim returnMsg As BusinessReturn = New BusinessReturn

        Try
            'Instantiate variables
            Dim uHelper As UmbracoHelper = New umbraco.Web.UmbracoHelper(umbraco.Web.UmbracoContext.Current)
            Dim ipEventsNode As IPublishedContent = uHelper.TypedContent(_calendar)
            Dim lstEvents As List(Of DataLayer.EventItem) = New List(Of DataLayer.EventItem)
            lstRecurringEvents = New List(Of DataLayer.RecurringEventItem)

            'Loop thru folders to find all events
            For Each eventFolder As IPublishedContent In ipEventsNode.Children
                If eventFolder.DocumentTypeAlias = aliases.singleEvents Then
                    'Recursively loop thru folders to fins all single events.
                    findAllSingleEvents(eventFolder, lstEvents, False, False, _catagory)
                ElseIf eventFolder.DocumentTypeAlias = aliases.recurringEvents Then
                    'Obtain all recurring events
                    findAllRecurringEvents(eventFolder, False, False, _catagory)
                End If
            Next

            'parse json of timeframe for each record in recurring events.
            convertJsonListsToEventList(lstRecurringEvents)

            'Merge lists
            For Each item As DataLayer.EventItem In lstGeneratedEvents
                lstEvents.Add(item)
            Next

            'Remove any entries older than today.
            For i As Int32 = (lstEvents.Count - 1) To 0 Step -1
                If (lstEvents(i).eventDate < Date.Today) Or (lstEvents(i).eventDate > Date.Today.AddYears(2)) Then
                    lstEvents.RemoveAt(i)
                End If
            Next

            Return lstEvents

        Catch ex As Exception
            'Save error to umbraco
            Dim sb As New StringBuilder
            sb.AppendLine("blEvents.vb | selectEventList_byCalendar()")
            sb.AppendLine("_getTopNumber: " & _getTopNumber)
            sb.AppendLine("_getEventLocation: " & _getEventLocation)
            sb.AppendLine("_getContactInfo: " & _getContactInfo)
            sb.AppendLine("_catagory: " & _catagory)
            sb.AppendLine("_calendar: " & _calendar)
            SaveErrorMessage(ex, sb, Me.GetType())

            'Return returnMsg
            Return Nothing
        End Try
    End Function
    Public Function selectEvent_byId(ByVal _eventId As Integer, Optional ByVal _getEventLocation As Boolean = False, Optional ByVal _getContactInfo As Boolean = False) As BusinessReturn
        'Create response class
        Dim returnMsg As BusinessReturn = New BusinessReturn

        Try
            'Instantiate variables
            Dim eventItem As DataLayer.EventItem
            Dim recurringEvent = New DataLayer.RecurringEventItem
            Dim uHelper As UmbracoHelper = New umbraco.Web.UmbracoHelper(umbraco.Web.UmbracoContext.Current)
            Dim ipEventsNode As IPublishedContent = uHelper.TypedContent(_eventId)
            Dim tempLstEvent As New List(Of DataLayer.EventItem)
            Dim tempLstRecurEvent As New List(Of DataLayer.RecurringEventItem)

            '
            If ipEventsNode.DocumentTypeAlias = aliases.singleEvent Then
                eventItem = getSingleEvent_byId(_eventId, _getEventLocation, _getContactInfo)

            ElseIf ipEventsNode.DocumentTypeAlias = aliases.recurringEvent Then
                recurringEvent = getRecurringEvent_byId(uHelper.TypedContent(_eventId), _getEventLocation, _getContactInfo)
                'convert recurring event into a single event
                eventItem = convertSingleJsonToEventList(recurringEvent, _getEventLocation, _getContactInfo)
            End If

            'Obtain sponsors
            If Not IsNothing(eventItem) Then
                eventItem.lstSponsors = obtainEventSponsors(_eventId)
                tempLstEvent.Add(eventItem)
            End If

            returnMsg.DataContainer.Add(tempLstEvent)

            Return returnMsg

        Catch ex As Exception
            'Save error to umbraco
            Dim sb As New StringBuilder
            sb.AppendLine("blEvents.vb | selectEvent_byId()")
            sb.AppendLine("_eventId: " & _eventId)
            sb.AppendLine("_getEventLocation: " & _getEventLocation)
            sb.AppendLine("_getContactInfo: " & _getContactInfo)
            SaveErrorMessage(ex, sb, Me.GetType())

            returnMsg.ExceptionMessage = "Error: " & ex.ToString & "<br />"
            Return returnMsg
        End Try
    End Function

    Public Function selectAllEventTypes() As BusinessReturn
        linqEvents = New linqEvents
        Return linqEvents.selectAllEventTypes()
    End Function
    Public Function selectAllChapters() As BusinessReturn
        linqEvents = New linqEvents
        Return linqEvents.selectAllChapters()
    End Function
#End Region


#Region "Methods"

    Private Function obtainEventSponsors(ByVal nodeId As Integer) As List(Of DataLayer.Sponsor)
        'Instantiate variables
        'Dim eventNode As New Node(nodeId)
        Dim uHelper As UmbracoHelper = New umbraco.Web.UmbracoHelper(umbraco.Web.UmbracoContext.Current)
        Dim ipEventNode As IPublishedContent = uHelper.TypedContent(nodeId)
        Dim lstSponsors As New List(Of DataLayer.Sponsor)

        'Obtain all sponsors
        If ipEventNode.HasProperty(nodeProperties.sponsors) Then
            'For Each sponsorGuid In ipEventNode.GetProperty(nodeProperties.sponsors).Split(",").ToList
            For Each ipSponsor As IPublishedContent In ipEventNode.GetPropertyValue(Of IEnumerable(Of IPublishedContent))(nodeProperties.sponsors)
                'Instantiate variables
                Dim sponsor As New DataLayer.Sponsor
                'Add data to class
                sponsor.id = ipSponsor.Id
                Try
                    sponsor.logoId = ipSponsor.GetPropertyValue(Of IPublishedContent)(nodeProperties.sponsorLogo).Id
                    sponsor.logoUrl = getMediaURL(sponsor.logoId, crops.SponsorLogo)
                Catch
                    sponsor.logoId = ipSponsor.GetPropertyValue(Of String)(nodeProperties.sponsorLogo)
                    sponsor.logoUrl = getMediaURL(sponsor.logoId, crops.SponsorLogo)
                End Try
                sponsor.name = ipSponsor.Name
                sponsor.url = ipSponsor.GetPropertyValue(Of String)(nodeProperties.sponsorUrl)
                'Add class to list
                lstSponsors.Add(sponsor)
            Next
        End If

        Return lstSponsors
    End Function

    Private Sub findAllSingleEvents(ByVal thisNode As IPublishedContent, ByRef lstEvents As List(Of DataLayer.EventItem), Optional ByVal _getEventLocation As Boolean = False,
                                    Optional ByVal _getContactInfo As Boolean = False, Optional ByVal _catagory As String = "")

        If thisNode.DocumentTypeAlias = aliases.singleEvent Then
            'If sorting by catagory, check if event has catagory selected.
            If Not String.IsNullOrEmpty(_catagory.Trim) Then
                If Not doesEventMatchCategory(thisNode, _catagory) Then Exit Sub
            End If

            'Create new event object
            Dim eventItem As DataLayer.EventItem = getSingleEvent_byId(thisNode.Id)

            'Add event to list
            If Not IsNothing(eventItem) Then lstEvents.Add(eventItem)
        Else
            For Each childNode As IPublishedContent In thisNode.Children
                Try
                    findAllSingleEvents(childNode, lstEvents, False, False, _catagory)
                Catch ex As Exception
                    'Save error to umbraco
                    Dim sb As New StringBuilder
                    sb.AppendLine("blEvents.vb | findAllSingleEvents()")
                    sb.AppendLine("childNode.Id: " & childNode.Id)
                    sb.AppendLine("childNode.Name: " & childNode.Name)
                    sb.AppendLine("_catagory: " & _catagory)
                    sb.AppendLine("_getEventLocation: " & _getEventLocation)
                    sb.AppendLine("_getContactInfo: " & _getContactInfo)
                    SaveErrorMessage(ex, sb, Me.GetType())
                End Try
            Next
        End If
    End Sub
    Private Sub findAllRecurringEvents(ByVal thisNode As IPublishedContent, Optional ByVal _getEventLocation As Boolean = False,
                                       Optional ByVal _getContactInfo As Boolean = False, Optional ByVal _catagory As String = "")

        If thisNode.DocumentTypeAlias = aliases.recurringEvent Then
            'If sorting by catagory, check if event has catagory selected.
            If Not String.IsNullOrEmpty(_catagory) Then
                If Not doesEventMatchCategory(thisNode, _catagory) Then Exit Sub
            End If

            'Instantiate variables
            Dim recurringEventItem As DataLayer.RecurringEventItem = getRecurringEvent_byId(thisNode, _getEventLocation, _getContactInfo)

            'Add event to list
            lstRecurringEvents.Add(recurringEventItem)
        Else
            For Each childNode As IPublishedContent In thisNode.Children
                Try
                    findAllRecurringEvents(childNode, _getEventLocation, _getContactInfo, _catagory)
                Catch ex As Exception
                    'Save error to umbraco
                    Dim sb As New StringBuilder
                    sb.AppendLine("blEvents.vb | findAllRecurringEvents()")
                    sb.AppendLine("childNode.Id: " & childNode.Id)
                    sb.AppendLine("childNode.Name: " & childNode.Name)
                    sb.AppendLine("_catagory: " & _catagory)
                    sb.AppendLine("_getEventLocation: " & _getEventLocation)
                    sb.AppendLine("_getContactInfo: " & _getContactInfo)
                    SaveErrorMessage(ex, sb, Me.GetType())
                End Try
            Next
        End If
    End Sub
    Private Function doesEventMatchCategory(ByVal thisNode As IPublishedContent, ByVal _catagory As String) As Boolean
        'Instantiate variables
        Dim result As Boolean = False
        Dim lstNames As List(Of String) = New List(Of String)


        'if node has catagory selected, ok event.
        If thisNode.HasProperty(nodeProperties.chapterAffiliation) Then
            'lst = thisNode.GetProperty(nodeProperties.chapterAffiliation).ToLower.Replace(" ", "").Split(",").ToList
            Dim lst As IEnumerable(Of IPublishedContent) = thisNode.GetPropertyValue(Of IEnumerable(Of IPublishedContent))(nodeProperties.eventType)
            For Each item As IPublishedContent In lst
                lstNames.Add(item.Name.ToLower.Replace(" ", ""))
            Next

            If lstNames.Contains(_catagory.ToLower.Replace(" ", "")) Then result = True
        End If

        Return result
    End Function
    Private Function getSingleEvent_byId(ByVal _thisNodeId As Integer, Optional ByVal _getEventLocation As Boolean = False, Optional ByVal _getContactInfo As Boolean = False) As DataLayer.EventItem
        Try
            'Instantiate variables
            Dim eventItem As DataLayer.EventItem = New DataLayer.EventItem
            'Dim thisNode As Node = New Node(_thisNodeId)
            Dim uHelper As UmbracoHelper = New umbraco.Web.UmbracoHelper(umbraco.Web.UmbracoContext.Current)
            Dim ipContent As IPublishedContent = uHelper.TypedContent(_thisNodeId)

            'Add info to event item
            eventItem.eventId = ipContent.Id

            'Get title
            If ipContent.HasProperty(nodeProperties.title) Then
                eventItem.eventTitle = ipContent.GetPropertyValue(Of String)(nodeProperties.title)
            End If

            'Get description
            If ipContent.HasProperty(nodeProperties.shortDescription) Then
                eventItem.description = ipContent.GetPropertyValue(Of String)(nodeProperties.shortDescription)
            End If

            'Get event date
            If ipContent.HasProperty(nodeProperties.eventDate) Then
                eventItem.eventDate = ipContent.GetPropertyValue(Of Date)(nodeProperties.eventDate)
            End If
            'Get register url for button
            If ipContent.HasProperty(nodeProperties.registerUrl) Then
                eventItem.registerUrl = ipContent.GetPropertyValue(Of String)(nodeProperties.registerUrl)
            End If
            'Get content
            If ipContent.HasProperty(nodeProperties.content) Then
                eventItem.content = ipContent.GetPropertyValue(Of String)(nodeProperties.content)
            End If
            'Get timeframe of event
            If ipContent.HasProperty(nodeProperties.timeframe) Then
                'Split timeframe into string array
                Dim timeframe As String = ipContent.GetPropertyValue(Of String)(nodeProperties.timeframe)
                Dim timeframeValues As String() = timeframe.Split("|")   'EXAMPLE:   true|6PM|:00|8PM|:00|false|false|||||false|false|||||false|false|||||false|false|||||false|false|||||false|false|||||false
                'Get parts of timeframe
                If timeframeValues(singleEventArray.allDayEvent) = "true" Then eventItem.allDayEvent = True
                If timeframeValues.Count > 1 Then eventItem.fromHour = timeframeValues(singleEventArray.fromHour)
                If timeframeValues.Count > 2 Then eventItem.fromMinute = timeframeValues(singleEventArray.fromMinute)
                If timeframeValues.Count > 3 Then eventItem.toHour = timeframeValues(singleEventArray.toHour)
                If timeframeValues.Count > 4 Then eventItem.toMinute = timeframeValues(singleEventArray.toMinute)
            End If
            'Get event location
            If _getEventLocation Then
                getEventLocation(ipContent, eventItem)
            End If
            'Get featured image
            If ipContent.HasProperty(nodeProperties.featuredImage) Then
                Dim featuredImgId As Integer = ipContent.GetPropertyValue(Of IPublishedContent)(nodeProperties.featuredImage).Id
                'Dim featuredImgId As Integer = getIdFromGuid_byType(ipContent.GetPropertyValue(Of String)(nodeProperties.featuredImage), UmbracoObjectTypes.Media)
                eventItem.featuredImgName = getMediaName(featuredImgId)
                eventItem.featuredImgUrl = getMediaURL(featuredImgId, crops.ListItemSquared)
            End If
            'Get event chapters

            'If thisNode.HasProperty(nodeProperties.eventCatagories) Then
            '   For Each item As String In thisNode.GetProperty(nodeProperties.eventCatagories).Split(",")
            If ipContent.HasProperty(nodeProperties.chapterAffiliation) Then
                'For Each item As String In ipContent.GetPropertyValue(Of String)(nodeProperties.chapterAffiliation).Split(",")
                For Each item As IPublishedContent In ipContent.GetPropertyValue(Of IEnumerable(Of IPublishedContent))(nodeProperties.chapterAffiliation)
                    Dim chapter As New DataLayer.Chapter
                    chapter.id = item.Id 'getIdFromGuid_byType(item, UmbracoObjectTypes.Document)
                    chapter.name = item.Name 'New Node(chapter.id).Name
                    eventItem.chapters.Add(chapter)
                Next
            End If
            'Get event types
            If ipContent.HasProperty(nodeProperties.eventType) Then
                'For Each item As String In ipContent.GetPropertyValue(Of String)(nodeProperties.eventType).Split(",")
                For Each item As IPublishedContent In ipContent.GetPropertyValue(Of IEnumerable(Of IPublishedContent))(nodeProperties.eventType)
                    Dim eventType As New DataLayer.EventType
                    eventType.id = item.Id 'getIdFromGuid_byType(item, UmbracoObjectTypes.Document)
                    eventType.name = item.Name 'New Node(eventType.id).Name
                    eventItem.eventTypes.Add(eventType)
                Next
            End If
            'Get contact info
            If _getContactInfo Then
                getEventContactInfo(ipContent, eventItem)
            End If
            'Get event url
            eventItem.eventUrl = ipContent.Url

            Return eventItem

        Catch ex As Exception
            'Save error to umbraco
            Dim sb As New StringBuilder
            sb.AppendLine("blEvents.vb | getSingleEvent_byId()")
            sb.AppendLine("_thisNodeId: " & _thisNodeId)
            sb.AppendLine("_getEventLocation: " & _getEventLocation)
            sb.AppendLine("_getContactInfo: " & _getContactInfo)
            SaveErrorMessage(ex, sb, Me.GetType())

        End Try

        Return Nothing
    End Function
    Private Function getRecurringEvent_byId(ByVal thisNode As IPublishedContent, Optional ByVal _getEventLocation As Boolean = False, Optional ByVal _getContactInfo As Boolean = False) As DataLayer.RecurringEventItem
        'Instantiate variables
        Dim recurringEventItem As DataLayer.RecurringEventItem = New DataLayer.RecurringEventItem

        'recurringEventItem info to event item
        recurringEventItem.eventId = thisNode.Id

        recurringEventItem.eventUrl = thisNode.Url

        'Get title
        If thisNode.HasProperty(nodeProperties.title) Then
            recurringEventItem.eventTitle = thisNode.GetPropertyValue(Of String)(nodeProperties.title)
        End If

        'Get description
        If thisNode.HasProperty(nodeProperties.shortDescription) Then
            recurringEventItem.description = thisNode.GetPropertyValue(Of String)(nodeProperties.shortDescription)
        End If

        'Get timeframe of event
        If thisNode.HasProperty(nodeProperties.eventTimeframe) Then
            Dim timeframeJson As String = thisNode.GetPropertyValue(Of String)(nodeProperties.eventTimeframe)
            recurringEventItem.timeframeJson = timeframeJson
            'Convert json into class and add to list
            Newtonsoft.Json.JsonConvert.PopulateObject(timeframeJson, recurringEventItem.timeEntry)
        End If

        'Get content
        If thisNode.HasProperty(nodeProperties.content) Then
            recurringEventItem.content = thisNode.GetPropertyValue(Of String)(nodeProperties.content)
        End If

        'Get register url for button
        If thisNode.HasProperty(nodeProperties.registerUrl) Then
            recurringEventItem.registerUrl = thisNode.GetPropertyValue(Of String)(nodeProperties.registerUrl)
        End If

        'Get featured image
        If thisNode.HasProperty(nodeProperties.featuredImage) Then
            Dim featuredImgId As Integer = thisNode.GetPropertyValue(Of IPublishedContent)(nodeProperties.featuredImage).Id 'getIdFromGuid_byType(thisNode.GetPropertyValue(Of String)(nodeProperties.featuredImage), UmbracoObjectTypes.Media)
            recurringEventItem.featuredImgName = getMediaName(featuredImgId)
            recurringEventItem.featuredImgUrl = getMediaURL(featuredImgId, crops.ListItemSquared)
        End If

        'Get event chapters
        If thisNode.HasProperty(nodeProperties.chapterAffiliation) Then
            'For Each item As String In thisNode.GetProperty(nodeProperties.chapterAffiliation).Split(",")
            For Each item As IPublishedContent In thisNode.GetPropertyValue(Of IEnumerable(Of IPublishedContent))(nodeProperties.chapterAffiliation)
                Dim chapter As New DataLayer.Chapter
                chapter.id = item.Id 'getIdFromGuid_byType(item, UmbracoObjectTypes.Document)
                chapter.name = item.Name 'New Node(chapter.id).Name
                recurringEventItem.chapters.Add(chapter)
            Next
        End If
        'Get event types
        If thisNode.HasProperty(nodeProperties.eventType) Then
            'For Each item As String In thisNode.GetProperty(nodeProperties.eventType).Split(",")
            For Each item As IPublishedContent In thisNode.GetPropertyValue(Of IEnumerable(Of IPublishedContent))(nodeProperties.eventType)
                Dim eventType As New DataLayer.EventType
                eventType.id = item.Id 'getIdFromGuid_byType(item, UmbracoObjectTypes.Document)
                eventType.name = item.Name ' New Node(eventType.id).Name
                recurringEventItem.eventTypes.Add(eventType)
            Next
        End If


        Return recurringEventItem
    End Function
    Private Sub getEventLocation(ByVal thisNode As IPublishedContent, ByRef eventItem As DataLayer.EventItem)
        'Obtain location
        If thisNode.HasProperty(nodeProperties.locationName) Then
            eventItem.eventLocation.locationName = thisNode.GetPropertyValue(Of String)(nodeProperties.locationName)
        End If
        If thisNode.HasProperty(nodeProperties.address1) Then
            eventItem.eventLocation.address01 = thisNode.GetPropertyValue(Of String)(nodeProperties.address1)
        End If
        If thisNode.HasProperty(nodeProperties.address2) Then
            eventItem.eventLocation.address02 = thisNode.GetPropertyValue(Of String)(nodeProperties.address2)
        End If
        If thisNode.HasProperty(nodeProperties.city) Then
            eventItem.eventLocation.city = thisNode.GetPropertyValue(Of String)(nodeProperties.city)
        End If
        If thisNode.HasProperty(nodeProperties.state) Then
            eventItem.eventLocation.state = thisNode.GetPropertyValue(Of String)(nodeProperties.state)
        End If
        If thisNode.HasProperty(nodeProperties.zip) Then
            eventItem.eventLocation.zip = thisNode.GetPropertyValue(Of String)(nodeProperties.zip)
        End If
    End Sub
    Private Sub getEventContactInfo(ByVal thisNode As IPublishedContent, ByRef eventItem As DataLayer.EventItem)
        If thisNode.HasProperty(nodeProperties.contactMembers) Then
            'Obtain contat info
            'Dim lstGuids As List(Of String) = thisNode.GetProperty(nodeProperties.contactMembers).Split(",").ToList
            Dim lstMembers As List(Of IMember) = thisNode.GetPropertyValue(Of IEnumerable(Of IMember))(nodeProperties.contactMembers)

            'Loop thru each id
            If Not IsNothing(lstMembers) Then
                'For Each memberGuid As String In lstGuids
                For Each member As IMember In lstMembers
                    'Obtain member id
                    'Dim memberId As Integer? = getIdFromGuid_byType(memberGuid, UmbracoObjectTypes.Member)
                    'If Not IsNothing(memberId) Then
                    'Dim member As IMember = ApplicationContext.Current.Services.MemberService.GetById(memberId)

                    'if member retrieved successfully...
                    If Not IsNothing(member) Then
                        'Obtain member data
                        Dim clsMember As New DataLayer.Member
                        clsMember.memberId = member.Id
                        If member.HasProperty(nodeProperties.firstName) Then clsMember.firstName = member.GetValue(Of String)(nodeProperties.firstName)
                        If member.HasProperty(nodeProperties.lastName) Then clsMember.lastName = member.GetValue(Of String)(nodeProperties.lastName)
                        If member.HasProperty(nodeProperties.email) Then clsMember.email = member.GetValue(Of String)(nodeProperties.email)
                        If member.HasProperty(nodeProperties.phoneNumber) Then clsMember.phoneNumber = member.GetValue(Of String)(nodeProperties.phoneNumber)
                        If member.HasProperty(nodeProperties.phoneExtension) Then clsMember.phoneExtension = member.GetValue(Of String)(nodeProperties.phoneExtension)
                        If member.HasProperty(nodeProperties.photo) Then
                            Dim mediaId As Integer = getIdFromGuid_byType(member.GetValue(Of String)(nodeProperties.photo), UmbracoObjectTypes.Media)
                            If Not IsNothing(mediaId) Then clsMember.photoUrl = getMediaURL(mediaId)
                        End If
                        'Add member to class
                        eventItem.members.Add(clsMember)
                    End If
                    'Else
                    '    'Save error to umbraco
                    '    Dim sb As New StringBuilder
                    '    sb.AppendLine("blEvents.vb | getEventContactInfo()")
                    '    sb.AppendLine("thisNode.Id: " & thisNode.Id)
                    '    sb.AppendLine("memberGuid: " & memberGuid)
                    '    sb.AppendLine("memberId: " & getIdFromGuid_byType(memberGuid, UmbracoObjectTypes.Media).ToString)
                    '    saveErrorMessage("Cannot convert guid to int", sb.ToString)
                    'End If

                Next
            End If
        End If
    End Sub

#Region "Create List from Recurring Event"
    Private Sub convertJsonListsToEventList(ByVal lstRecurringEvents As List(Of DataLayer.RecurringEventItem))
        '
        lstGeneratedEvents = New List(Of DataLayer.EventItem)

        For Each RecurringEvent As DataLayer.RecurringEventItem In lstRecurringEvents
            '
            Select Case RecurringEvent.timeEntry.recurrence
                Case recurrence.none
                    createEvents_None(RecurringEvent)
                Case recurrence.daily
                    createEvents_Daily(RecurringEvent)
                Case recurrence.weekly
                    createEvents_Weekly(RecurringEvent)
                Case recurrence.monthly
                    createEvents_Monthly(RecurringEvent)
                Case recurrence.yearly
                    createEvents_Yearly(RecurringEvent)
            End Select
        Next
    End Sub
    Private Sub createEvents_None(ByRef recurringEvent As DataLayer.RecurringEventItem)
        'PSUDO-CODE
        '=================================
        '_recurrence:
        '	1- not recurring
        '		-get: _startDate, _endDate
        '		-create as single day event


        'Instantiate variables
        Dim eventItem As DataLayer.EventItem = New DataLayer.EventItem

        'Get event start/end time
        Dim startTime As DateTime = recurringEvent.timeEntry.startDate
        Dim endTime As DateTime = recurringEvent.timeEntry.endDate
        eventItem.eventDate = startTime.Date

        'Generate event times
        eventItem.fromHour = startTime.ToString("h tt")
        eventItem.fromMinute = startTime.Minute.ToString(":00")
        eventItem.toHour = endTime.ToString("h tt")
        eventItem.toMinute = endTime.Minute.ToString(":00")

        'Add general data to event
        eventItem.eventId = recurringEvent.eventId
        eventItem.eventTitle = recurringEvent.eventTitle
        eventItem.description = recurringEvent.description
        eventItem.recurringEvent = False

        'Get event catagories
        'Dim thisNode As Node = New Node(eventItem.eventId)
        Dim uHelper As UmbracoHelper = New Umbraco.Web.UmbracoHelper(Umbraco.Web.UmbracoContext.Current)
        Dim thisNode As IPublishedContent = uHelper.TypedContent(eventItem.eventId)

        'If thisNode.HasProperty(nodeProperties.eventCatagories) Then
        '    For Each item As String In thisNode.GetProperty(nodeProperties.eventCatagories).Split(",")
        If thisNode.HasProperty(nodeProperties.chapterAffiliation) Then
            'For Each item As String In thisNode.GetProperty(nodeProperties.chapterAffiliation).Split(",")
            For Each item As IPublishedContent In thisNode.GetPropertyValue(Of IEnumerable(Of IPublishedContent))(nodeProperties.chapterAffiliation)
                Dim chapter As New DataLayer.Chapter
                chapter.id = item.Id 'getIdFromGuid_byType(item, UmbracoObjectTypes.Document)
                chapter.name = item.Name 'New Node(chapter.id).Name
                eventItem.chapters.Add(chapter)
            Next
        End If
        'Get event types
        If thisNode.HasProperty(nodeProperties.eventType) Then
            'For Each item As String In thisNode.GetProperty(nodeProperties.eventType).Split(",")
            For Each item As IPublishedContent In thisNode.GetPropertyValue(Of IEnumerable(Of IPublishedContent))(nodeProperties.eventType)
                Dim eventType As New DataLayer.EventType
                eventType.id = item.Id ' getIdFromGuid_byType(item, UmbracoObjectTypes.Document)
                eventType.name = item.Name ' New Node(eventType.id).Name
                eventItem.eventTypes.Add(eventType)
            Next
        End If

        'Get properties from event in umbraco
        If thisNode.HasProperty(nodeProperties.featuredImage) Then
            Dim featuredImgId As Integer = thisNode.GetPropertyValue(Of String)(nodeProperties.featuredImage) 'getIdFromGuid_byType(thisNode.GetPropertyValue(Of String)(nodeProperties.featuredImage), UmbracoObjectTypes.Media)
            eventItem.featuredImgName = getMediaName(featuredImgId)
            eventItem.featuredImgUrl = getMediaURL(featuredImgId, crops.ListItemSquared)
        End If
        eventItem.eventUrl = thisNode.Url

        'Add event to list
        lstGeneratedEvents.Add(eventItem)
    End Sub
    Private Sub createEvents_Daily(ByRef recurringEvent As DataLayer.RecurringEventItem)
        'PSUDO-CODE
        '=================================
        '_recurrence:
        '	2- repeat daily
        '		-get: _startDate, _endDate, _recurUntil, _days, _exceptDates
        '		-create list of all days, remove exception dates



        'Instantiate variables and capture values
        Dim startTime As DateTime = recurringEvent.timeEntry.startDate
        Dim endTime As DateTime = recurringEvent.timeEntry.endDate
        Dim lstDays As List(Of Integer) = recurringEvent.timeEntry.days
        Dim lstExceptDates As List(Of Date) = recurringEvent.timeEntry.exceptDates
        Dim lstOfEntryDates As List(Of Date) = New List(Of Date)
        Dim recurUntil As Date
        If String.IsNullOrEmpty(recurringEvent.timeEntry.recurUntil) Then
            recurUntil = Date.Today.AddYears(2)
        Else
            recurUntil = CDate(recurringEvent.timeEntry.recurUntil).AddDays(1)
        End If


        'Create a list only if day(s) of week are selected
        If lstDays.Count > 0 Then
            'Create timespan between first and last date
            Dim timespan As TimeSpan = recurUntil - startTime

            'Loop thru each day and validate against the lstDays list
            For i = 0 To timespan.Days
                Dim day As Date = startTime.Date.AddDays(i)
                If lstDays.Contains(day.DayOfWeek) Then
                    'match, add to list of dates
                    lstOfEntryDates.Add(day)
                End If
            Next

            'Loop thru exception dates and remove from new list of entry dates
            If Not IsNothing(lstExceptDates) Then
                For Each day As Date In lstExceptDates
                    If lstOfEntryDates.Contains(day) Then
                        lstOfEntryDates.Remove(day)
                    End If
                Next
            End If

            'Loop thru remaining entry dates and create an event entry
            For Each entryDate As Date In lstOfEntryDates
                'Instantiate variables
                Dim eventItem As DataLayer.EventItem = New DataLayer.EventItem

                eventItem.eventDate = entryDate

                'Generate event times
                eventItem.fromHour = startTime.ToString("h tt")
                eventItem.fromMinute = startTime.Minute.ToString(":00")
                eventItem.toHour = endTime.ToString("h tt")
                eventItem.toMinute = endTime.Minute.ToString(":00")

                'Add general data to event
                eventItem.eventId = recurringEvent.eventId
                eventItem.eventTitle = recurringEvent.eventTitle
                eventItem.description = recurringEvent.description
                eventItem.recurringEvent = True

                'Get event catagories
                Dim uHelper As UmbracoHelper = New Umbraco.Web.UmbracoHelper(Umbraco.Web.UmbracoContext.Current)
                Dim thisNode As IPublishedContent = uHelper.TypedContent(eventItem.eventId)

                If thisNode.HasProperty(nodeProperties.chapterAffiliation) Then
                    'For Each item As String In thisNode.GetProperty(nodeProperties.chapterAffiliation).Split(",")
                    For Each item As IPublishedContent In thisNode.GetPropertyValue(Of IEnumerable(Of IPublishedContent))(nodeProperties.chapterAffiliation)
                        Dim chapter As New DataLayer.Chapter
                        chapter.id = item.Id ' getIdFromGuid_byType(item, UmbracoObjectTypes.Document)
                        chapter.name = item.Name '  New Node(chapter.id).Name
                        eventItem.chapters.Add(chapter)
                    Next
                End If
                'Get event types
                If thisNode.HasProperty(nodeProperties.eventType) Then
                    'For Each item As String In thisNode.GetProperty(nodeProperties.eventType).Split(",")
                    For Each item As IPublishedContent In thisNode.GetPropertyValue(Of IEnumerable(Of IPublishedContent))(nodeProperties.eventType)
                        Dim eventType As New DataLayer.EventType
                        eventType.id = item.Id 'getIdFromGuid_byType(item, UmbracoObjectTypes.Document)
                        eventType.name = item.Name ' New Node(eventType.id).Name
                        eventItem.eventTypes.Add(eventType)
                    Next
                End If

                'Get properties from event in umbraco
                If thisNode.HasProperty(nodeProperties.featuredImage) Then
                    Dim featuredImgId As Integer = thisNode.GetPropertyValue(Of IPublishedContent)(nodeProperties.featuredImage).Id 'getIdFromGuid_byType(thisNode.GetPropertyValue(Of String)(nodeProperties.featuredImage), UmbracoObjectTypes.Media)
                    eventItem.featuredImgName = getMediaName(featuredImgId)
                    eventItem.featuredImgUrl = getMediaURL(featuredImgId, crops.ListItemSquared)
                End If
                eventItem.eventUrl = thisNode.Url

                'Add event to list
                lstGeneratedEvents.Add(eventItem)
            Next
        End If
    End Sub
    Private Sub createEvents_Weekly(ByRef recurringEvent As DataLayer.RecurringEventItem)
        'PSUDO-CODE
        '=================================
        '_recurrence:
        '	3- repeat weekly
        '		-get: _startDate, _endDate, _recurUntil, _weekInterval, _days, _exceptDates
        '		-create list of all days, remove exception dates



        'Instantiate variables and capture values
        Dim startTime As DateTime = recurringEvent.timeEntry.startDate
        Dim endTime As DateTime = recurringEvent.timeEntry.endDate
        Dim weeklyInterval As Integer = recurringEvent.timeEntry.weekInterval
        Dim lstDays As List(Of Integer) = recurringEvent.timeEntry.days
        Dim lstExceptDates As List(Of Date) = recurringEvent.timeEntry.exceptDates
        Dim lstOfEntryDates As List(Of Date) = New List(Of Date)
        Dim recurUntil As Date
        If String.IsNullOrEmpty(recurringEvent.timeEntry.recurUntil) Then
            recurUntil = Date.Today.AddYears(2)
        Else
            recurUntil = CDate(recurringEvent.timeEntry.recurUntil).AddDays(1)
        End If

        'Get week of year that startdate falls on.
        Dim currCulture As Globalization.CultureInfo = Globalization.CultureInfo.CurrentCulture
        Dim startingWeek As Integer = currCulture.Calendar.GetWeekOfYear(startTime, currCulture.DateTimeFormat.CalendarWeekRule, currCulture.DateTimeFormat.FirstDayOfWeek)
        Dim currentWeek As Integer = 0
        Dim weekSpan As Integer = 0

        'Create a list only if day(s) of week are selected
        If lstDays.Count > 0 Then
            'Create timespan between first and last date
            Dim timespan As TimeSpan = recurUntil - startTime

            'Loop thru each day and validate against the lstDays list
            For i = 0 To timespan.Days
                Dim day As Date = startTime.Date.AddDays(i)
                If lstDays.Contains(day.DayOfWeek) Then
                    'Obtain looped date's week number
                    currentWeek = currCulture.Calendar.GetWeekOfYear(day, currCulture.DateTimeFormat.CalendarWeekRule, currCulture.DateTimeFormat.FirstDayOfWeek)
                    'How many weeks are spanning between start week and current week
                    weekSpan = currentWeek - startingWeek
                    'If not enough weeks have passed, skip entry and go to next one.
                    If (weekSpan <> 0) AndAlso (weekSpan < weeklyInterval) Then
                        Continue For
                    ElseIf (weekSpan = 0) Or (weekSpan Mod weeklyInterval = 0) Then
                        'add to list of dates
                        lstOfEntryDates.Add(day)

                    End If
                End If
            Next

            'Loop thru exception dates and remove from new list of entry dates
            If Not IsNothing(lstExceptDates) Then
                For Each day As Date In lstExceptDates
                    If lstOfEntryDates.Contains(day) Then
                        lstOfEntryDates.Remove(day)
                    End If
                Next
            End If


            'Loop thru remaining entry dates and create an event entry
            For Each entryDate As Date In lstOfEntryDates
                'Instantiate variables
                Dim eventItem As DataLayer.EventItem = New DataLayer.EventItem

                eventItem.eventDate = entryDate

                'Generate event times
                eventItem.fromHour = startTime.ToString("h tt")
                eventItem.fromMinute = startTime.Minute.ToString(":00")
                eventItem.toHour = endTime.ToString("h tt")
                eventItem.toMinute = endTime.Minute.ToString(":00")

                'Add general data to event
                eventItem.eventId = recurringEvent.eventId
                eventItem.eventTitle = recurringEvent.eventTitle
                eventItem.description = recurringEvent.description
                eventItem.recurringEvent = True

                'Get event catagories
                'Dim thisNode As Node = New Node(eventItem.eventId)
                Dim uHelper As UmbracoHelper = New Umbraco.Web.UmbracoHelper(Umbraco.Web.UmbracoContext.Current)
                Dim thisNode As IPublishedContent = uHelper.TypedContent(eventItem.eventId)
                'If thisNode.HasProperty(nodeProperties.eventCatagories) Then
                '    For Each item As String In thisNode.GetProperty(nodeProperties.eventCatagories).Split(",")
                If thisNode.HasProperty(nodeProperties.chapterAffiliation) Then
                    'For Each item As String In thisNode.GetProperty(nodeProperties.chapterAffiliation).Split(",")
                    For Each item As IPublishedContent In thisNode.GetPropertyValue(Of IEnumerable(Of IPublishedContent))(nodeProperties.chapterAffiliation)
                        Dim chapter As New DataLayer.Chapter
                        chapter.id = item.Id 'getIdFromGuid_byType(item, UmbracoObjectTypes.Document)
                        chapter.name = item.Name 'New Node(chapter.id).Name
                        eventItem.chapters.Add(chapter)
                    Next
                End If
                'Get event types
                If thisNode.HasProperty(nodeProperties.eventType) Then
                    'For Each item As String In thisNode.GetProperty(nodeProperties.eventType).Split(",")
                    For Each item As IPublishedContent In thisNode.GetPropertyValue(Of IEnumerable(Of IPublishedContent))(nodeProperties.eventType)
                        Dim eventType As New DataLayer.EventType
                        eventType.id = item.Id 'getIdFromGuid_byType(item, UmbracoObjectTypes.Document)
                        eventType.name = item.Name 'New Node(eventType.id).Name
                        eventItem.eventTypes.Add(eventType)
                    Next
                End If

                'Get properties from event in umbraco
                If thisNode.HasProperty(nodeProperties.featuredImage) Then
                    Dim featuredImgId As Integer = thisNode.GetPropertyValue(Of String)(nodeProperties.featuredImage) 'getIdFromGuid_byType(thisNode.GetProperty(nodeProperties.featuredImage), UmbracoObjectTypes.Media)
                    eventItem.featuredImgName = getMediaName(featuredImgId)
                    eventItem.featuredImgUrl = getMediaURL(featuredImgId, crops.ListItemSquared)
                End If
                eventItem.eventUrl = thisNode.Url

                'Add event to list
                lstGeneratedEvents.Add(eventItem)
            Next
        End If
    End Sub
    Private Sub createEvents_Monthly(ByRef recurringEvent As DataLayer.RecurringEventItem)
        '	4- repeat monthly
        '		-get: _startDate, _endDate, _recurUntil, _monthYearOption, _monthOption, _interval, _weekDay, _months, _exceptDates
        '		-create list of all days, remove exception dates



        'Instantiate variables and capture values
        Dim startTime As DateTime = recurringEvent.timeEntry.startDate
        Dim endTime As DateTime = recurringEvent.timeEntry.endDate
        Dim monthYearOption As Integer = recurringEvent.timeEntry.monthYearOption
        Dim monthOption As Integer = recurringEvent.timeEntry.monthOption
        Dim weekInterval As Integer = recurringEvent.timeEntry.interval
        Dim weekDay As Integer = recurringEvent.timeEntry.weekDay
        Dim lstMonths As List(Of Integer) = recurringEvent.timeEntry.months
        Dim lstExceptDates As List(Of Date) = recurringEvent.timeEntry.exceptDates
        Dim lstOfEntryDates As List(Of Date) = New List(Of Date)
        Dim recurUntil As Date
        If String.IsNullOrEmpty(recurringEvent.timeEntry.recurUntil) Then
            recurUntil = Date.Today.AddYears(2)
        Else
            recurUntil = CDate(recurringEvent.timeEntry.recurUntil).AddDays(1)
        End If

        'Loop thru each day and validate against the lstDays list
        Dim day As Date = startTime.Date
        While day <= recurUntil
            If day <= recurUntil Then
                If monthYearOption = 1 Then 'Use startdate
                    If monthOption = 1 Then
                        'get date for every month
                        lstOfEntryDates.Add(day)
                    ElseIf monthOption = 2 Then
                        'choose day if in list of months
                        If lstMonths.Contains(day.Month) Then
                            lstOfEntryDates.Add(day)
                        End If
                    End If

                ElseIf monthYearOption = 2 Then '(specify interval | weekday)
                    If weekInterval = 6 Then
                        'Special: get last of weekday date.
                        '==================================
                        'Calculate this month's 1st day.
                        Dim thisMonthsDay As Date = New Date(day.Year, day.Month, 1)
                        'Adjust to last day of month.
                        thisMonthsDay = thisMonthsDay.AddMonths(1).AddDays(-1)

                        'Bring date to last of selected weekday.
                        Dim thisWeekday As Integer = thisMonthsDay.DayOfWeek
                        While Not thisWeekday = weekDay
                            'decrement day
                            thisMonthsDay = thisMonthsDay.AddDays(-1)
                            'get day of week
                            thisWeekday = thisMonthsDay.DayOfWeek
                        End While

                        'Determin if date should be recorded
                        If thisMonthsDay <= recurUntil Then
                            If monthOption = 1 Then 'every month
                                lstOfEntryDates.Add(thisMonthsDay)
                            ElseIf monthOption = 2 Then 'choose day if in list of months
                                If lstMonths.Contains(thisMonthsDay.Month) Then
                                    lstOfEntryDates.Add(thisMonthsDay)
                                End If
                            End If
                        End If


                    Else
                        '*Calculate this month's date.  Will change every month.
                        Dim thisMonthsDay As Date = New Date(day.Year, day.Month, 1)
                        Dim thisWeekday As Integer = thisMonthsDay.DayOfWeek
                        Dim thisMonth As Integer = thisMonthsDay.Month

                        'Bring date to first of selected weekday.
                        While Not thisWeekday = weekDay
                            'increment day
                            thisMonthsDay = thisMonthsDay.AddDays(1)
                            'get day of week
                            thisWeekday = thisMonthsDay.DayOfWeek
                        End While

                        'Bring week up to correct week interval.  This will result in the correct date for this month
                        thisMonthsDay = thisMonthsDay.AddDays((weekInterval - 1) * 7)

                        'Record if updated date did not go into next month and is less than final date.
                        If thisMonth = thisMonthsDay.Month Then
                            If thisMonthsDay <= recurUntil Then
                                If monthOption = 1 Then
                                    'every month
                                    lstOfEntryDates.Add(thisMonthsDay)
                                ElseIf monthOption = 2 Then
                                    'choose day if in list of months
                                    If lstMonths.Contains(thisMonthsDay.Month) Then
                                        lstOfEntryDates.Add(thisMonthsDay)
                                    End If
                                End If
                            End If
                        End If
                    End If
                End If
            End If

            'Increment day by month
            day = day.AddMonths(1)
        End While

        'Loop thru exception dates and remove from new list of entry dates
        If Not IsNothing(lstExceptDates) Then
            For Each exceptDay As Date In lstExceptDates
                If lstOfEntryDates.Contains(exceptDay) Then
                    lstOfEntryDates.Remove(exceptDay)
                End If
            Next
        End If


        'Loop thru remaining entry dates and create an event entry
        For Each entryDate As Date In lstOfEntryDates
            'Instantiate variables
            Dim eventItem As DataLayer.EventItem = New DataLayer.EventItem

            eventItem.eventDate = entryDate

            'Generate event times
            eventItem.fromHour = startTime.ToString("h tt")
            eventItem.fromMinute = startTime.Minute.ToString(":00")
            eventItem.toHour = endTime.ToString("h tt")
            eventItem.toMinute = endTime.Minute.ToString(":00")

            'Add general data to event
            eventItem.eventId = recurringEvent.eventId
            eventItem.eventTitle = recurringEvent.eventTitle
            eventItem.description = recurringEvent.description
            eventItem.recurringEvent = True

            'Get event catagories
            Dim uHelper As UmbracoHelper = New Umbraco.Web.UmbracoHelper(Umbraco.Web.UmbracoContext.Current)
            Dim thisNode As IPublishedContent = uHelper.TypedContent(eventItem.eventId)
            'If thisNode.HasProperty(nodeProperties.eventCatagories) Then
            '    For Each item As String In thisNode.GetProperty(nodeProperties.eventCatagories).Split(",")
            If thisNode.HasProperty(nodeProperties.chapterAffiliation) Then
                For Each item As IPublishedContent In thisNode.GetPropertyValue(Of IEnumerable(Of IPublishedContent))(nodeProperties.chapterAffiliation)
                    Dim chapter As New DataLayer.Chapter
                    chapter.id = item.Id
                    chapter.name = item.Name
                    eventItem.chapters.Add(chapter)
                Next
            End If
            'Get event types
            If thisNode.HasProperty(nodeProperties.eventType) Then
                For Each item As IPublishedContent In thisNode.GetPropertyValue(Of IEnumerable(Of IPublishedContent))(nodeProperties.eventType)
                    Dim eventType As New DataLayer.EventType
                    eventType.id = item.Id
                    eventType.name = item.Name
                    eventItem.eventTypes.Add(eventType)
                Next
            End If

            'Get properties from event in umbraco
            If thisNode.HasProperty(nodeProperties.featuredImage) Then
                Dim featuredImgId As Integer = thisNode.GetPropertyValue(Of String)(nodeProperties.featuredImage) 'getIdFromGuid_byType(thisNode.GetProperty(nodeProperties.featuredImage), UmbracoObjectTypes.Media)
                eventItem.featuredImgName = getMediaName(featuredImgId)
                eventItem.featuredImgUrl = getMediaURL(featuredImgId, crops.ListItemSquared)
            End If
            eventItem.eventUrl = thisNode.Url

            'Add event to list
            lstGeneratedEvents.Add(eventItem)
        Next
    End Sub
    Private Sub createEvents_Yearly(ByRef recurringEvent As DataLayer.RecurringEventItem)
        '	5- repeat yearly
        '		-get: _startDate, _endDate, _recurUntil, _monthYearOption, _interval, _weekDay, _month, _exceptDates
        '		-create list of all days, remove exception dates



        'Instantiate variables and capture values
        Dim startTime As DateTime = recurringEvent.timeEntry.startDate
        Dim endTime As DateTime = recurringEvent.timeEntry.endDate
        Dim monthYearOption As Integer = recurringEvent.timeEntry.monthYearOption
        Dim weekInterval As Integer = recurringEvent.timeEntry.interval
        Dim weekDay As Integer = recurringEvent.timeEntry.weekDay
        Dim month As Integer = recurringEvent.timeEntry.month
        Dim lstExceptDates As List(Of Date) = recurringEvent.timeEntry.exceptDates
        Dim lstOfEntryDates As List(Of Date) = New List(Of Date)
        Dim recurUntil As Date
        If String.IsNullOrEmpty(recurringEvent.timeEntry.recurUntil) Then
            recurUntil = Date.Today.AddYears(2)
        Else
            recurUntil = CDate(recurringEvent.timeEntry.recurUntil).AddDays(1)
        End If

        'Determine how to increment yearly date.
        If monthYearOption = 1 Then 'Use starting date and increment by year
            ''Copy startDate to adjust as we loop thru dates.
            Dim day As Date = startTime.Date
            'Loop thru dates to find all matching and add to list.
            While day <= recurUntil
                'Add to list.
                lstOfEntryDates.Add(day)
                'Increment by year.
                day = day.AddYears(2)
            End While
        ElseIf monthYearOption = 2 Then 'Override startday/time with interval date.
            'Copy startDate to adjust as we loop thru dates.
            Dim day As Date = startTime.Date

            'Obtain override date
            Dim thisYearsDay As Date = New Date(day.Year, month, 1)

            'Determine how to adjust according to week.
            If weekInterval = 6 Then
                'Adjust to last day of month.
                thisYearsDay = thisYearsDay.AddMonths(1).AddDays(-1)

                'Bring date to last of selected weekday.
                Dim thisWeekday As Integer = thisYearsDay.DayOfWeek
                While Not thisWeekday = weekDay
                    'decrement day
                    thisYearsDay = thisYearsDay.AddDays(-1)
                    'get day of week
                    thisWeekday = thisYearsDay.DayOfWeek
                End While

                'Loop to generate future date entries
                While thisYearsDay <= recurUntil
                    If thisYearsDay >= startTime Then
                        'Add to list.
                        lstOfEntryDates.Add(thisYearsDay)
                    End If

                    'Increment by year and create next date to modify
                    day = day.AddYears(2)
                    thisYearsDay = New Date(day.Year, month, 1)

                    'Adjust to last day of month.
                    thisYearsDay = thisYearsDay.AddMonths(1).AddDays(-1)

                    'Bring date to last of selected weekday.
                    thisWeekday = thisYearsDay.DayOfWeek
                    While Not thisWeekday = weekDay
                        'decrement day
                        thisYearsDay = thisYearsDay.AddDays(-1)
                        'get day of week
                        thisWeekday = thisYearsDay.DayOfWeek
                    End While
                End While

            Else
                'Obtain this year's day of week & month
                Dim thisWeekday As Integer = thisYearsDay.DayOfWeek
                Dim thisMonth As Integer = thisYearsDay.Month

                'Bring date to first of selected weekday.
                While Not thisWeekday = weekDay
                    'increment day
                    thisYearsDay = thisYearsDay.AddDays(1)
                    'get day of week
                    thisWeekday = thisYearsDay.DayOfWeek
                End While

                'Bring week up to correct week interval.  This will result in the correct date for this month
                thisYearsDay = thisYearsDay.AddDays((weekInterval - 1) * 7)

                'Loop to obtain all matching dates.
                While thisYearsDay <= recurUntil
                    If thisYearsDay >= startTime AndAlso thisYearsDay <= recurUntil Then
                        'Add to list.
                        lstOfEntryDates.Add(thisYearsDay)
                    End If

                    'Increment by year and create next date to modify
                    day = day.AddYears(2)
                    thisYearsDay = New Date(day.Year, month, 1)

                    'Obtain this year's day of week & month
                    thisWeekday = thisYearsDay.DayOfWeek
                    thisMonth = thisYearsDay.Month

                    'Bring date to first of selected weekday.
                    While Not thisWeekday = weekDay
                        'increment day
                        thisYearsDay = thisYearsDay.AddDays(1)
                        'get day of week
                        thisWeekday = thisYearsDay.DayOfWeek
                    End While

                    'Bring week up to correct week interval.  This will result in the correct date for this month
                    thisYearsDay = thisYearsDay.AddDays((weekInterval - 1) * 7)
                End While
            End If
        End If


        'Loop thru exception dates and remove from new list of entry dates
        If Not IsNothing(lstExceptDates) Then
            For Each exceptDay As Date In lstExceptDates
                If lstOfEntryDates.Contains(exceptDay) Then
                    lstOfEntryDates.Remove(exceptDay)
                End If
            Next
        End If


        'Loop thru remaining entry dates and create an event entry
        For Each entryDate As Date In lstOfEntryDates
            'Instantiate variables
            Dim eventItem As DataLayer.EventItem = New DataLayer.EventItem

            eventItem.eventDate = entryDate

            'Generate event times
            eventItem.fromHour = startTime.ToString("h tt")
            eventItem.fromMinute = startTime.Minute.ToString(":00")
            eventItem.toHour = endTime.ToString("h tt")
            eventItem.toMinute = endTime.Minute.ToString(":00")

            'Add general data to event
            eventItem.eventId = recurringEvent.eventId
            eventItem.eventTitle = recurringEvent.eventTitle
            eventItem.description = recurringEvent.description
            eventItem.recurringEvent = True

            'Get event catagories
            Dim uHelper As UmbracoHelper = New Umbraco.Web.UmbracoHelper(Umbraco.Web.UmbracoContext.Current)
            Dim thisNode As IPublishedContent = uHelper.TypedContent(eventItem.eventId)

            If thisNode.HasProperty(nodeProperties.chapterAffiliation) Then
                For Each item As IPublishedContent In thisNode.GetPropertyValue(Of IEnumerable(Of IPublishedContent))(nodeProperties.chapterAffiliation)
                    Dim chapter As New DataLayer.Chapter
                    chapter.id = item.Id
                    chapter.name = item.Name
                    eventItem.chapters.Add(chapter)
                Next
            End If
            'Get event types
            If thisNode.HasProperty(nodeProperties.eventType) Then
                For Each item As IPublishedContent In thisNode.GetPropertyValue(Of IEnumerable(Of IPublishedContent))(nodeProperties.eventType)
                    Dim eventType As New DataLayer.EventType
                    eventType.id = item.Id
                    eventType.name = item.Name
                    eventItem.eventTypes.Add(eventType)
                Next
            End If

            'Get properties from event in umbraco
            If thisNode.HasProperty(nodeProperties.featuredImage) Then
                Dim featuredImgId As Integer = thisNode.GetPropertyValue(Of String)(nodeProperties.featuredImage) 'getIdFromGuid_byType(thisNode.GetProperty(nodeProperties.featuredImage), UmbracoObjectTypes.Media)
                eventItem.featuredImgName = getMediaName(featuredImgId)
                eventItem.featuredImgUrl = getMediaURL(featuredImgId, crops.ListItemSquared)
            End If

            eventItem.eventUrl = thisNode.Url

            'Add event to list
            lstGeneratedEvents.Add(eventItem)
        Next
    End Sub
#End Region


#Region "Extrapilate details from Recurring Event"
    Private Function convertSingleJsonToEventList(ByVal recurringEvent As DataLayer.RecurringEventItem, Optional ByVal _getEventLocation As Boolean = False, Optional ByVal _getContactInfo As Boolean = False) As DataLayer.EventItem
        '
        Dim newEvent As New DataLayer.EventItem
        Dim uHelper As UmbracoHelper = New Umbraco.Web.UmbracoHelper(Umbraco.Web.UmbracoContext.Current)

        '
        Select Case recurringEvent.timeEntry.recurrence
            Case recurrence.none
                newEvent = createEventDetails_None(recurringEvent)
            Case recurrence.daily
                newEvent = createEventDetails_Daily(recurringEvent)
            Case recurrence.weekly
                newEvent = createEventDetails_Weekly(recurringEvent)
            Case recurrence.monthly
                newEvent = createEventDetails_Monthly(recurringEvent)
            Case recurrence.yearly
                newEvent = createEventDetails_Yearly(recurringEvent)
        End Select

        'Get event location
        If _getEventLocation Then
            getEventLocation(uHelper.TypedContent(newEvent.eventId), newEvent)
        End If

        'Get contact info
        If _getContactInfo Then
            getEventContactInfo(uHelper.TypedContent(newEvent.eventId), newEvent)
        End If



        Return newEvent
    End Function
    Private Function createEventDetails_None(ByRef recurringEvent As DataLayer.RecurringEventItem) As DataLayer.EventItem
        'Instantiate variables
        Dim eventItem As DataLayer.EventItem = New DataLayer.EventItem

        'Get event start/end time
        Dim startTime As DateTime = recurringEvent.timeEntry.startDate
        Dim endTime As DateTime = recurringEvent.timeEntry.endDate
        eventItem.eventDate = startTime.Date

        'Generate event times
        eventItem.fromHour = startTime.ToString("h tt")
        eventItem.fromMinute = startTime.Minute.ToString(":00")
        eventItem.toHour = endTime.ToString("h tt")
        eventItem.toMinute = endTime.Minute.ToString(":00")

        'Add general data to event
        eventItem.eventId = recurringEvent.eventId
        eventItem.eventTitle = recurringEvent.eventTitle
        eventItem.description = recurringEvent.description
        eventItem.eventUrl = recurringEvent.eventUrl
        eventItem.content = recurringEvent.content
        eventItem.eventNote = recurringEvent.eventNote
        eventItem.registerUrl = recurringEvent.registerUrl
        eventItem.featuredImgName = recurringEvent.featuredImgName
        eventItem.featuredImgUrl = recurringEvent.featuredImgUrl
        eventItem.chapters = recurringEvent.chapters
        eventItem.recurringEvent = False
        eventItem.allDayEvent = False

        'Add event to list
        'lstGeneratedEvents.Add(eventItem)

        'Set Recurring details.
        eventItem.recurringTimeDetails.Recurrence = DataLayer.RecurringTimeDetails.recurrenceTypes.None

        Return eventItem
    End Function
    Private Function createEventDetails_Daily(ByRef recurringEvent As DataLayer.RecurringEventItem) As DataLayer.EventItem
        'Instantiate variables and capture values
        Dim eventItem As DataLayer.EventItem = New DataLayer.EventItem
        Dim startTime As DateTime = recurringEvent.timeEntry.startDate
        Dim endTime As DateTime = recurringEvent.timeEntry.endDate
        Dim lstDays As New List(Of Integer)
        Dim lstExceptDates As New List(Of Date)
        Dim lstOfEntryDates As List(Of Date) = New List(Of Date)
        Dim recurUntil As Date


        If Not IsNothing(recurringEvent.timeEntry.days) Then lstDays = recurringEvent.timeEntry.days
        If Not IsNothing(recurringEvent.timeEntry.exceptDates) Then lstExceptDates = recurringEvent.timeEntry.exceptDates
        If String.IsNullOrEmpty(recurringEvent.timeEntry.recurUntil) Then
            recurUntil = Date.Today.AddYears(2)
        Else
            recurUntil = CDate(recurringEvent.timeEntry.recurUntil) '.AddDays(1)
        End If

        'Create a list only if day(s) of week are selected
        If lstDays.Count > 0 Then
            'Create timespan between first and last date
            Dim timespan As TimeSpan = recurUntil - startTime

            'Loop thru each day and validate against the lstDays list
            For i = 0 To timespan.Days
                Dim day As Date = startTime.Date.AddDays(i)
                If lstDays.Contains(day.DayOfWeek) Then
                    'match, add to list of dates
                    lstOfEntryDates.Add(day)
                End If
            Next

            'Loop thru exception dates and remove from new list of entry dates
            If Not IsNothing(lstExceptDates) Then
                For Each day As Date In lstExceptDates
                    If lstOfEntryDates.Contains(day) Then
                        lstOfEntryDates.Remove(day)
                    End If
                Next
            End If

            'Grab only first entry and exit.  Used only for description as needed.
            For Each entryDate As Date In lstOfEntryDates
                'Instantiate variables

                eventItem.eventDate = entryDate

                'Generate event times
                eventItem.fromHour = startTime.ToString("h tt")
                eventItem.fromMinute = startTime.Minute.ToString(":00")
                eventItem.toHour = endTime.ToString("h tt")
                eventItem.toMinute = endTime.Minute.ToString(":00")

                'Add general data to event
                eventItem.eventId = recurringEvent.eventId
                eventItem.eventTitle = recurringEvent.eventTitle
                eventItem.description = recurringEvent.description
                eventItem.recurringEvent = True
                eventItem.eventUrl = recurringEvent.eventUrl
                eventItem.content = recurringEvent.content
                eventItem.eventNote = recurringEvent.eventNote
                eventItem.registerUrl = recurringEvent.registerUrl
                eventItem.featuredImgName = recurringEvent.featuredImgName
                eventItem.featuredImgUrl = recurringEvent.featuredImgUrl
                eventItem.chapters = recurringEvent.chapters
                eventItem.allDayEvent = False

                'Add event to list
                'lstGeneratedEvents.Add(eventItem)

                Exit For
            Next
        End If

        'Set Recurring details.
        eventItem.recurringTimeDetails.Recurrence = DataLayer.RecurringTimeDetails.recurrenceTypes.Daily
        eventItem.recurringTimeDetails.RecurUntil = recurUntil
        eventItem.recurringTimeDetails.ExceptOnDates = String.Join(",", lstExceptDates)
        'Create days of week list
        Dim lstDaysOfWeek As New List(Of String)
        For Each _day In lstDays
            lstDaysOfWeek.Add(WeekdayName(_day + 1))
        Next
        eventItem.recurringTimeDetails.DaysOfWeek = String.Join(",", lstDaysOfWeek)





        Return eventItem
    End Function
    Private Function createEventDetails_Weekly(ByRef recurringEvent As DataLayer.RecurringEventItem) As DataLayer.EventItem
        'Instantiate variables and capture values
        Dim eventItem As DataLayer.EventItem = New DataLayer.EventItem
        Dim startTime As DateTime = recurringEvent.timeEntry.startDate
        Dim endTime As DateTime = recurringEvent.timeEntry.endDate
        Dim weeklyInterval As Integer = recurringEvent.timeEntry.weekInterval
        Dim lstDays As List(Of Integer) = recurringEvent.timeEntry.days
        Dim lstExceptDates As List(Of Date) = recurringEvent.timeEntry.exceptDates
        Dim lstOfEntryDates As List(Of Date) = New List(Of Date)
        Dim recurUntil As Date
        If String.IsNullOrEmpty(recurringEvent.timeEntry.recurUntil) Then
            recurUntil = Date.Today.AddYears(2)
        Else
            recurUntil = CDate(recurringEvent.timeEntry.recurUntil) '.AddDays(1)
        End If

        'Get week of year that startdate falls on.
        Dim currCulture As Globalization.CultureInfo = Globalization.CultureInfo.CurrentCulture
        Dim startingWeek As Integer = currCulture.Calendar.GetWeekOfYear(startTime, currCulture.DateTimeFormat.CalendarWeekRule, currCulture.DateTimeFormat.FirstDayOfWeek)
        Dim currentWeek As Integer = 0
        Dim weekSpan As Integer = 0

        'Create a list only if day(s) of week are selected
        If lstDays.Count > 0 Then
            'Create timespan between first and last date
            Dim timespan As TimeSpan = recurUntil - startTime

            'Loop thru each day and validate against the lstDays list
            For i = 0 To timespan.Days
                Dim day As Date = startTime.Date.AddDays(i)
                If lstDays.Contains(day.DayOfWeek) Then
                    'Obtain looped date's week number
                    currentWeek = currCulture.Calendar.GetWeekOfYear(day, currCulture.DateTimeFormat.CalendarWeekRule, currCulture.DateTimeFormat.FirstDayOfWeek)
                    'How many weeks are spanning between start week and current week
                    weekSpan = currentWeek - startingWeek
                    'If not enough weeks have passed, skip entry and go to next one.
                    If (weekSpan <> 0) AndAlso (weekSpan < weeklyInterval) Then
                        Continue For
                    ElseIf (weekSpan = 0) Or (weekSpan Mod weeklyInterval = 0) Then
                        'add to list of dates
                        lstOfEntryDates.Add(day)

                    End If
                End If
            Next

            'Loop thru exception dates and remove from new list of entry dates
            If Not IsNothing(lstExceptDates) Then
                For Each day As Date In lstExceptDates
                    If lstOfEntryDates.Contains(day) Then
                        lstOfEntryDates.Remove(day)
                    End If
                Next
            End If


            'Grab only first entry and exit.  Used only for description as needed.
            For Each entryDate As Date In lstOfEntryDates
                '
                eventItem.eventDate = entryDate

                'Generate event times
                eventItem.fromHour = startTime.ToString("h tt")
                eventItem.fromMinute = startTime.Minute.ToString(":00")
                eventItem.toHour = endTime.ToString("h tt")
                eventItem.toMinute = endTime.Minute.ToString(":00")

                'Add general data to event
                eventItem.eventId = recurringEvent.eventId
                eventItem.eventTitle = recurringEvent.eventTitle
                eventItem.description = recurringEvent.description
                eventItem.recurringEvent = True
                eventItem.eventUrl = recurringEvent.eventUrl
                eventItem.content = recurringEvent.content
                eventItem.eventNote = recurringEvent.eventNote
                eventItem.registerUrl = recurringEvent.registerUrl
                eventItem.featuredImgName = recurringEvent.featuredImgName
                eventItem.featuredImgUrl = recurringEvent.featuredImgUrl
                eventItem.chapters = recurringEvent.chapters
                eventItem.allDayEvent = False

                'Add event to list
                'lstGeneratedEvents.Add(eventItem)

                Exit For
            Next
        End If

        'Set Recurring details.
        eventItem.recurringTimeDetails.Recurrence = DataLayer.RecurringTimeDetails.recurrenceTypes.Weekly
        eventItem.recurringTimeDetails.RecurUntil = recurUntil
        If Not IsNothing(lstExceptDates) Then eventItem.recurringTimeDetails.ExceptOnDates = String.Join(",", lstExceptDates)
        'If lstExceptDates.Count > 0 Then eventItem.recurringTimeDetails.ExceptOnDates = String.Join(",", lstExceptDates)
        If IsNumeric(weeklyInterval) Then eventItem.recurringTimeDetails.weeklyInterval = weeklyInterval - 1
        'Create days of week list
        Dim lstDaysOfWeek As New List(Of String)
        For Each _day In lstDays
            lstDaysOfWeek.Add(WeekdayName(_day + 1))
        Next
        eventItem.recurringTimeDetails.DaysOfWeek = String.Join(",", lstDaysOfWeek)


        '
        Return eventItem
    End Function
    Private Function createEventDetails_Monthly(ByRef recurringEvent As DataLayer.RecurringEventItem) As DataLayer.EventItem
        'Instantiate variables and capture values
        Dim eventItem As DataLayer.EventItem = New DataLayer.EventItem
        Dim startTime As DateTime = recurringEvent.timeEntry.startDate
        Dim endTime As DateTime = recurringEvent.timeEntry.endDate
        Dim monthYearOption As Integer = recurringEvent.timeEntry.monthYearOption
        Dim monthOption As Integer = recurringEvent.timeEntry.monthOption
        Dim weekInterval As Integer = recurringEvent.timeEntry.interval
        Dim weekDay As Integer = recurringEvent.timeEntry.weekDay
        Dim lstMonths As List(Of Integer) = recurringEvent.timeEntry.months
        Dim lstExceptDates As List(Of Date) = recurringEvent.timeEntry.exceptDates
        Dim lstOfEntryDates As List(Of Date) = New List(Of Date)
        Dim recurUntil As Date
        If String.IsNullOrEmpty(recurringEvent.timeEntry.recurUntil) Then
            recurUntil = Date.Today.AddYears(2)
        Else
            recurUntil = CDate(recurringEvent.timeEntry.recurUntil) '.AddDays(1)
        End If

        'Loop thru each day and validate against the lstDays list
        Dim day As Date = startTime.Date
        While day <= recurUntil
            If day <= recurUntil Then
                If monthYearOption = 1 Then 'Use startdate
                    If monthOption = 1 Then
                        'get date for every month
                        lstOfEntryDates.Add(day)
                    ElseIf monthOption = 2 Then
                        'choose day if in list of months
                        If lstMonths.Contains(day.Month) Then
                            lstOfEntryDates.Add(day)
                        End If
                    End If

                ElseIf monthYearOption = 2 Then '(specify interval | weekday)
                    If weekInterval = 6 Then
                        'Special: get last of weekday date.
                        '==================================
                        'Calculate this month's 1st day.
                        Dim thisMonthsDay As Date = New Date(day.Year, day.Month, 1)
                        'Adjust to last day of month.
                        thisMonthsDay = thisMonthsDay.AddMonths(1).AddDays(-1)

                        'Bring date to last of selected weekday.
                        Dim thisWeekday As Integer = thisMonthsDay.DayOfWeek
                        While Not thisWeekday = weekDay
                            'decrement day
                            thisMonthsDay = thisMonthsDay.AddDays(-1)
                            'get day of week
                            thisWeekday = thisMonthsDay.DayOfWeek
                        End While

                        'Determin if date should be recorded
                        If thisMonthsDay <= recurUntil Then
                            If monthOption = 1 Then 'every month
                                lstOfEntryDates.Add(thisMonthsDay)
                            ElseIf monthOption = 2 Then 'choose day if in list of months
                                If lstMonths.Contains(thisMonthsDay.Month) Then
                                    lstOfEntryDates.Add(thisMonthsDay)
                                End If
                            End If
                        End If


                    Else
                        '*Calculate this month's date.  Will change every month.
                        Dim thisMonthsDay As Date = New Date(day.Year, day.Month, 1)
                        Dim thisWeekday As Integer = thisMonthsDay.DayOfWeek
                        Dim thisMonth As Integer = thisMonthsDay.Month

                        'Bring date to first of selected weekday.
                        While Not thisWeekday = weekDay
                            'increment day
                            thisMonthsDay = thisMonthsDay.AddDays(1)
                            'get day of week
                            thisWeekday = thisMonthsDay.DayOfWeek
                        End While

                        'Bring week up to correct week interval.  This will result in the correct date for this month
                        thisMonthsDay = thisMonthsDay.AddDays((weekInterval - 1) * 7)

                        'Record if updated date did not go into next month and is less than final date.
                        If thisMonth = thisMonthsDay.Month Then
                            If thisMonthsDay <= recurUntil Then
                                If monthOption = 1 Then
                                    'every month
                                    lstOfEntryDates.Add(thisMonthsDay)
                                ElseIf monthOption = 2 Then
                                    'choose day if in list of months
                                    If lstMonths.Contains(thisMonthsDay.Month) Then
                                        lstOfEntryDates.Add(thisMonthsDay)
                                    End If
                                End If
                            End If
                        End If
                    End If
                End If
            End If

            'Increment day by month
            day = day.AddMonths(1)
        End While

        'Loop thru exception dates and remove from new list of entry dates
        If Not IsNothing(lstExceptDates) Then
            For Each exceptDay As Date In lstExceptDates
                If lstOfEntryDates.Contains(exceptDay) Then
                    lstOfEntryDates.Remove(exceptDay)
                End If
            Next
        End If


        'Grab only first entry and exit.  Used only for description as needed.
        For Each entryDate As Date In lstOfEntryDates
            eventItem.eventDate = entryDate

            'Generate event times
            eventItem.fromHour = startTime.ToString("h tt")
            eventItem.fromMinute = startTime.Minute.ToString(":00")
            eventItem.toHour = endTime.ToString("h tt")
            eventItem.toMinute = endTime.Minute.ToString(":00")

            'Add general data to event
            eventItem.eventId = recurringEvent.eventId
            eventItem.eventTitle = recurringEvent.eventTitle
            eventItem.description = recurringEvent.description
            eventItem.recurringEvent = True
            eventItem.eventUrl = recurringEvent.eventUrl
            eventItem.content = recurringEvent.content
            eventItem.eventNote = recurringEvent.eventNote
            eventItem.registerUrl = recurringEvent.registerUrl
            eventItem.featuredImgName = recurringEvent.featuredImgName
            eventItem.featuredImgUrl = recurringEvent.featuredImgUrl
            eventItem.chapters = recurringEvent.chapters
            eventItem.allDayEvent = False

            'Add event to list
            'lstGeneratedEvents.Add(eventItem)
            Exit For
        Next

        'Set Recurring details.
        eventItem.recurringTimeDetails.Recurrence = DataLayer.RecurringTimeDetails.recurrenceTypes.Monthly
        eventItem.recurringTimeDetails.RecurUntil = recurUntil
        eventItem.recurringTimeDetails.ExceptOnDates = String.Join(",", lstExceptDates)
        If monthYearOption = 2 Then
            eventItem.recurringTimeDetails.useStartDate = False
            eventItem.recurringTimeDetails.weeklyIntervalOfMonth = weekInterval - 1
            eventItem.recurringTimeDetails.DaysOfWeek = WeekdayName(weekDay + 1)
        End If
        eventItem.recurringTimeDetails.everyMonth = True
        If monthOption = 1 Then

        Else
            eventItem.recurringTimeDetails.everyMonth = False
            'Create month list
            Dim lstMonthNames As New List(Of String)
            For Each _month In lstMonths
                lstMonthNames.Add(MonthName(_month))
            Next
            eventItem.recurringTimeDetails.monthsPerYear = String.Join(",", lstMonthNames)

        End If

        '
        Return eventItem
    End Function
    Private Function createEventDetails_Yearly(ByRef recurringEvent As DataLayer.RecurringEventItem) As DataLayer.EventItem
        'Instantiate variables and capture values
        Dim eventItem As DataLayer.EventItem = New DataLayer.EventItem
        Dim startTime As DateTime = recurringEvent.timeEntry.startDate
        Dim endTime As DateTime = recurringEvent.timeEntry.endDate
        Dim monthYearOption As Integer = recurringEvent.timeEntry.monthYearOption
        Dim weekInterval As Integer = recurringEvent.timeEntry.interval
        Dim weekDay As Integer = recurringEvent.timeEntry.weekDay
        Dim month As Integer = recurringEvent.timeEntry.month
        Dim lstExceptDates As List(Of Date) = recurringEvent.timeEntry.exceptDates
        Dim lstOfEntryDates As List(Of Date) = New List(Of Date)
        Dim recurUntil As Date
        If String.IsNullOrEmpty(recurringEvent.timeEntry.recurUntil) Then
            recurUntil = Date.Today.AddYears(2)
        Else
            recurUntil = CDate(recurringEvent.timeEntry.recurUntil) '.AddDays(1)
        End If

        'Determine how to increment yearly date.
        If monthYearOption = 1 Then 'Use starting date and increment by year
            ''Copy startDate to adjust as we loop thru dates.
            Dim day As Date = startTime.Date
            'Loop thru dates to find all matching and add to list.
            While day <= recurUntil
                'Add to list.
                lstOfEntryDates.Add(day)
                'Increment by year.
                day = day.AddYears(2)
            End While
        ElseIf monthYearOption = 2 Then 'Override startday/time with interval date.
            'Copy startDate to adjust as we loop thru dates.
            Dim day As Date = startTime.Date

            'Obtain override date
            Dim thisYearsDay As Date = New Date(day.Year, month, 1)

            'Determine how to adjust according to week.
            If weekInterval = 6 Then
                'Adjust to last day of month.
                thisYearsDay = thisYearsDay.AddMonths(1).AddDays(-1)

                'Bring date to last of selected weekday.
                Dim thisWeekday As Integer = thisYearsDay.DayOfWeek
                While Not thisWeekday = weekDay
                    'decrement day
                    thisYearsDay = thisYearsDay.AddDays(-1)
                    'get day of week
                    thisWeekday = thisYearsDay.DayOfWeek
                End While

                'Loop to generate future date entries
                While thisYearsDay <= recurUntil
                    If thisYearsDay >= startTime Then
                        'Add to list.
                        lstOfEntryDates.Add(thisYearsDay)
                    End If

                    'Increment by year and create next date to modify
                    day = day.AddYears(2)
                    thisYearsDay = New Date(day.Year, month, 1)

                    'Adjust to last day of month.
                    thisYearsDay = thisYearsDay.AddMonths(1).AddDays(-1)

                    'Bring date to last of selected weekday.
                    thisWeekday = thisYearsDay.DayOfWeek
                    While Not thisWeekday = weekDay
                        'decrement day
                        thisYearsDay = thisYearsDay.AddDays(-1)
                        'get day of week
                        thisWeekday = thisYearsDay.DayOfWeek
                    End While
                End While

            Else
                'Obtain this year's day of week & month
                Dim thisWeekday As Integer = thisYearsDay.DayOfWeek
                Dim thisMonth As Integer = thisYearsDay.Month

                'Bring date to first of selected weekday.
                While Not thisWeekday = weekDay
                    'increment day
                    thisYearsDay = thisYearsDay.AddDays(1)
                    'get day of week
                    thisWeekday = thisYearsDay.DayOfWeek
                End While

                'Bring week up to correct week interval.  This will result in the correct date for this month
                thisYearsDay = thisYearsDay.AddDays((weekInterval - 1) * 7)

                'Loop to obtain all matching dates.
                While thisYearsDay <= recurUntil
                    If thisYearsDay >= startTime AndAlso thisYearsDay <= recurUntil Then
                        'Add to list.
                        lstOfEntryDates.Add(thisYearsDay)
                    End If

                    'Increment by year and create next date to modify
                    day = day.AddYears(2)
                    thisYearsDay = New Date(day.Year, month, 1)

                    'Obtain this year's day of week & month
                    thisWeekday = thisYearsDay.DayOfWeek
                    thisMonth = thisYearsDay.Month

                    'Bring date to first of selected weekday.
                    While Not thisWeekday = weekDay
                        'increment day
                        thisYearsDay = thisYearsDay.AddDays(1)
                        'get day of week
                        thisWeekday = thisYearsDay.DayOfWeek
                    End While

                    'Bring week up to correct week interval.  This will result in the correct date for this month
                    thisYearsDay = thisYearsDay.AddDays((weekInterval - 1) * 7)
                End While
            End If
        End If


        'Loop thru exception dates and remove from new list of entry dates
        If Not IsNothing(lstExceptDates) Then
            For Each exceptDay As Date In lstExceptDates
                If lstOfEntryDates.Contains(exceptDay) Then
                    lstOfEntryDates.Remove(exceptDay)
                End If
            Next
        End If


        'Grab only first entry and exit.  Used only for description as needed.
        For Each entryDate As Date In lstOfEntryDates
            '
            eventItem.eventDate = entryDate

            'Generate event times
            eventItem.fromHour = startTime.ToString("h tt")
            eventItem.fromMinute = startTime.Minute.ToString(":00")
            eventItem.toHour = endTime.ToString("h tt")
            eventItem.toMinute = endTime.Minute.ToString(":00")

            'Add general data to event
            eventItem.eventId = recurringEvent.eventId
            eventItem.eventTitle = recurringEvent.eventTitle
            eventItem.description = recurringEvent.description
            eventItem.recurringEvent = True
            eventItem.eventUrl = recurringEvent.eventUrl
            eventItem.content = recurringEvent.content
            eventItem.eventNote = recurringEvent.eventNote
            eventItem.registerUrl = recurringEvent.registerUrl
            eventItem.featuredImgName = recurringEvent.featuredImgName
            eventItem.featuredImgUrl = recurringEvent.featuredImgUrl
            eventItem.chapters = recurringEvent.chapters
            eventItem.allDayEvent = False

            'Add event to list
            'lstGeneratedEvents.Add(eventItem)

            Exit For
        Next


        'Set Recurring details.
        eventItem.recurringTimeDetails.Recurrence = DataLayer.RecurringTimeDetails.recurrenceTypes.Yearly
        eventItem.recurringTimeDetails.RecurUntil = recurUntil
        eventItem.recurringTimeDetails.ExceptOnDates = String.Join(",", lstExceptDates)
        If monthYearOption = 2 Then
            eventItem.recurringTimeDetails.useStartDate = False
            eventItem.recurringTimeDetails.weeklyIntervalOfMonth = weekInterval - 1
            eventItem.recurringTimeDetails.DaysOfWeek = WeekdayName(weekDay + 1)
            eventItem.recurringTimeDetails.monthsPerYear = MonthName(month)
        End If

        '
        Return eventItem

    End Function
#End Region

#End Region
End Class
