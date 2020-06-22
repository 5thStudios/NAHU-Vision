Imports umbraco
Imports umbraco.NodeFactory
Imports Common


Public Class EventFilter
    Inherits System.Web.UI.UserControl


#Region "Properties"
    Private Class _postByDate
        Public Property year As Integer
        Public Property blogMonth As New List(Of _pbdMonth)
    End Class
    Private Class _pbdMonth
        Public Property monthId As Integer
        Public Property monthName As String
        Public Property lstBlogEntries As New List(Of DataLayer.BlogEntry)
        Public Property lstEventItem As New List(Of DataLayer.EventItem)
        'Public Property blogEntries As New List(Of _pbdBlogEntry)
    End Class


    Private blEvents As blEvents
    Private isListPage As Boolean = False
    Private parentUrl As String = String.Empty
#End Region

#Region "Handles"
    Private Sub EventFilter_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try
            'Instantiate variables
            blEvents = New blEvents

            'Save global values for databinding function and jquery session functionality.
            If Node.GetCurrent.NodeTypeAlias = aliases.eventCalendar Then
                isListPage = True
                parentUrl = Node.GetCurrent.NiceUrl
            Else
                parentUrl = Node.GetCurrent.Parent.Parent.NiceUrl
            End If
            hfldListPgUrl.Value = parentUrl
            hfldIsListPg.Value = isListPage


            '=====================================
            '   Obtain all event types
            '=====================================
            'Instantiate variables
            Dim lstEventTypes As List(Of DataLayer.EventType)
            Dim bReturnEventTypes As New BusinessReturn

            'Obtain data
            bReturnEventTypes = blEvents.selectAllEventTypes()

            If bReturnEventTypes.isValid Then
                'Extract data
                lstEventTypes = DirectCast(bReturnEventTypes.DataContainer(0), List(Of DataLayer.EventType))
                lvEventTypes.DataSource = lstEventTypes
                lvEventTypes.DataBind()
                'gv1.DataSource = lstEventTypes
                'gv1.DataBind()
            End If


            '=====================================
            '   Obtain all chapters
            '=====================================
            'Instantiate variables
            Dim lstChapters As List(Of DataLayer.Chapter)
            Dim bReturnChapters As New BusinessReturn

            'Obtain data
            bReturnChapters = blEvents.selectAllChapters()

            If bReturnChapters.isValid Then
                'Extract data
                lstChapters = DirectCast(bReturnChapters.DataContainer(0), List(Of DataLayer.Chapter))
                'gv2.DataSource = lstChapters
                'gv2.DataBind()
                lvChapterAffiliation.DataSource = lstChapters
                lvChapterAffiliation.DataBind()
            End If


            '=====================================
            '   Create list of events by date
            '=====================================
            EventsByDate()

        Catch ex As Exception
            'Save error to umbraco
            Dim sb As New StringBuilder
            sb.AppendLine("EventFilters.ascx | Load()")
            SaveErrorMessage(ex, sb, Me.GetType())

            Response.Write("Error: " & ex.ToString & "<br />")
        End Try
    End Sub
#End Region

#Region "Methods"
    Private Sub EventsByDate()
        '=====================================
        '   Obtain all events
        '=====================================
        'Instantiate variables
        Dim returnMsg As BusinessReturn

        'Obtain all events
        returnMsg = blEvents.selectAllEvents()

        'If valid return, display events
        If returnMsg.isValid Then
            'Obtain list of events from return msg.
            Dim lstEvents As List(Of DataLayer.EventItem) = DirectCast(returnMsg.DataContainer(0), List(Of DataLayer.EventItem))

            '=====================================
            '   Posts by Date
            '=====================================
            'Instantiate variables
            Dim _year As Integer = 0
            Dim _month As Integer = 0
            Dim _newYear As Boolean = True
            Dim lstPostByDate As List(Of _postByDate) = New List(Of _postByDate)
            Dim postByDate As New _postByDate
            Dim pbdMonth As New _pbdMonth
            Dim pbdBlogEntry As New DataLayer.EventItem

            'Loop thru all blog entries in descending date order
            For Each blogEntry As DataLayer.EventItem In lstEvents

                'Verify is a new year class is to be created.
                If (blogEntry.eventDate.Year <> _year) Then
                    'Save latest year
                    _year = blogEntry.eventDate.Year
                    'Create new class
                    postByDate = New _postByDate
                    'Add data to class
                    postByDate.year = _year
                    'Add class to list
                    lstPostByDate.Add(postByDate)
                    'Set trigger value for new month
                    _newYear = True
                End If

                'Verify is a new month class is to be created.
                If (blogEntry.eventDate.Month <> _month) Or (_newYear = True) Then
                    'Save latest month
                    _month = blogEntry.eventDate.Month
                    'Create new class
                    pbdMonth = New _pbdMonth
                    'Add data to class
                    pbdMonth.monthId = _month
                    pbdMonth.monthName = blogEntry.eventDate.ToString("MMMM")
                    'Add class to list
                    postByDate.blogMonth.Add(pbdMonth)
                    'Reset trigger value
                    _newYear = False
                End If

                'Create new class
                pbdBlogEntry = New DataLayer.EventItem
                'Add data to class
                pbdBlogEntry.eventTitle = blogEntry.eventTitle
                pbdBlogEntry.eventUrl = blogEntry.eventUrl
                'Add class to list
                pbdMonth.lstEventItem.Add(pbdBlogEntry)
            Next

            'Display list
            lvEventYear.DataSource = lstPostByDate
            lvEventYear.DataBind()

        Else
            phPostsByDate.Visible = False
        End If
    End Sub

#End Region


End Class