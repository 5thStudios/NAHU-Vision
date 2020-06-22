Imports Microsoft.VisualBasic
Imports umbraco.Web.Models



Namespace DataLayer

    Public Class RecurringEventItem

#Region "Public"
        Public Property eventId As Integer = 0
        Public Property eventTitle As String = String.Empty
        Public Property description As String = String.Empty
        Public Property timeframeJson As String = String.Empty
        Public Property timeEntry As _TimeEntry = New _TimeEntry



        Public Property eventUrl As String = String.Empty
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
        Public Property members As New List(Of Member)
        Public Property chapters As New List(Of DataLayer.Chapter)
        Public Property eventTypes As New List(Of DataLayer.EventType)
        'Public Property chapters As List(Of String) = New List(Of String)



#End Region

#Region "Handles"
        Public Sub New()
        End Sub
#End Region
    End Class




End Namespace