Imports Microsoft.VisualBasic

Namespace DataLayer
    Public Class EventItem
        Public Property eventId As Integer = 0
        Public Property eventUrl As String = String.Empty
        Public Property eventTitle As String = String.Empty
        Public Property description As String = String.Empty
        Public Property content As String = String.Empty
        Public Property featuredImgName As String = String.Empty
        Public Property featuredImgUrl As String = String.Empty

        Public Property eventDate As DateTime = Date.Now
        Public Property recurringEvent As Boolean = False
        Public Property allDayEvent As Boolean = False
        Public Property fromHour As String = String.Empty
        Public Property fromMinute As String = String.Empty
        Public Property toHour As String = String.Empty
        Public Property toMinute As String = String.Empty
        Public Property eventNote As String = String.Empty
        Public Property registerUrl As String = String.Empty

        Public Property eventLocation As EventLocation = New EventLocation
        Public Property recurringTimeDetails As RecurringTimeDetails = New RecurringTimeDetails
        Public Property members As List(Of Member) = New List(Of Member)
        Public Property chapters As New List(Of DataLayer.Chapter)
        Public Property eventTypes As New List(Of DataLayer.EventType)
        Public Property lstSponsors As New List(Of DataLayer.Sponsor)


        Public Sub New()
        End Sub
    End Class
End Namespace