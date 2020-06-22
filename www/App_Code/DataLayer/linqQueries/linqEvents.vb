Imports Microsoft.VisualBasic
Imports Common
Imports Umbraco
Imports Umbraco.Core.Models
Imports Umbraco.NodeFactory
Imports Umbraco.Web

Public Class linqEvents

#Region "Properties"
    'Private linq2Db As linq2SqlDataContext = New linq2SqlDataContext(ConfigurationManager.ConnectionStrings("umbracoDbDSN").ToString)
#End Region

#Region "Select"
    Public Function selectAllEventTypes() As BusinessReturn
        'Instantiate scope variables
        Dim businessReturn As New BusinessReturn

        Try
            'Instantiate variables
            Dim eventType As DataLayer.EventType
            Dim lstEventTypes As New List(Of DataLayer.EventType)
            Dim uHelper As UmbracoHelper = New Umbraco.Web.UmbracoHelper(Umbraco.Web.UmbracoContext.Current)
            Dim ipEventTypes As IPublishedContent = uHelper.TypedContent(siteNodes.EventTypes)

            'Obtain each event type
            For Each type As IPublishedContent In ipEventTypes.Children
                eventType = New DataLayer.EventType
                eventType.id = type.Id
                eventType.name = type.Name
                lstEventTypes.Add(eventType)
            Next

            businessReturn.DataContainer.Add(lstEventTypes)

        Catch ex As Exception
            'Save error to umbraco
            Dim sb As New StringBuilder
            sb.AppendLine("linqEvents.ascx | selectAllEventTypes()")
            SaveErrorMessage(ex, sb, Me.GetType())
        End Try

        Return businessReturn
    End Function
    Public Function selectAllChapters() As BusinessReturn
        'Instantiate scope variables
        Dim businessReturn As New BusinessReturn

        Try
            'Instantiate variables
            Dim Chapter As DataLayer.Chapter
            Dim lstChapters As New List(Of DataLayer.Chapter)
            Dim uHelper As UmbracoHelper = New umbraco.Web.UmbracoHelper(umbraco.Web.UmbracoContext.Current)
            Dim ipChapters As IPublishedContent = uHelper.TypedContent(siteNodes.ChapterAffiliation)

            'Obtain each chapter
            For Each type As IPublishedContent In ipChapters.Children
                Chapter = New DataLayer.Chapter
                Chapter.id = type.Id
                Chapter.name = type.Name
                lstChapters.Add(Chapter)
            Next

            businessReturn.DataContainer.Add(lstChapters)

        Catch ex As Exception
            'Save error to umbraco
            Dim sb As New StringBuilder
            sb.AppendLine("linqEvents.ascx | selectAllChapters()")
            SaveErrorMessage(ex, sb, Me.GetType())
        End Try

        Return businessReturn
    End Function

    'Public Function selectAllSingEvents() As BusinessReturn
    '    'Instantiate variables
    '    Dim BusinessReturn As BusinessReturn = New BusinessReturn
    '    Dim lstEvents As List(Of ec_event) = (From a In linq2Db.ec_events.AsEnumerable Select a).ToList

    '    'Attach and return data
    '    BusinessReturn.DataContainer.Add(lstEvents)
    '    Return BusinessReturn
    'End Function
    'Public Function selectAllRecurringEvents() As BusinessReturn
    '    'Instantiate variables
    '    Dim BusinessReturn As BusinessReturn = New BusinessReturn
    '    Dim lstEvents As List(Of ec_recevent) = (From a In linq2Db.ec_recevents.AsEnumerable Select a).ToList

    '    'Attach and return data
    '    BusinessReturn.DataContainer.Add(lstEvents)
    '    Return BusinessReturn
    'End Function
    'Public Function selectLocation_byId(ByVal _locationId As Integer) As BusinessReturn
    '    'Instantiate variables
    '    Dim BusinessReturn As BusinessReturn = New BusinessReturn
    '    Dim ec_location As ec_location = (From a In linq2Db.ec_locations.AsEnumerable Where a.id = _locationId Select a)

    '    'Attach and return data
    '    BusinessReturn.DataContainer.Add(ec_location)
    '    Return BusinessReturn
    'End Function
    'Public Function selectLocationName_byId(ByVal _locationId As Integer) As String
    '    Return (From a In linq2Db.ec_locations.AsEnumerable Where a.id = _locationId Select a.lname).FirstOrDefault
    'End Function
    'Public Function selectDescription_byEventId(ByVal _eventId As Integer, ByVal _type As Integer, ByVal _calendarId As Integer) As String
    '    Return (From a In linq2Db.ec_eventdescriptions.AsEnumerable
    '            Where a.eventid = _eventId AndAlso a.type = _type AndAlso a.calendarid = _calendarId
    '            Select a.content).FirstOrDefault
    'End Function
#End Region

#Region "Methods"
#End Region

End Class
