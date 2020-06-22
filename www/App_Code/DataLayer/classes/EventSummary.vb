Imports Microsoft.VisualBasic


Namespace DataLayer

    Public Class EventSummary
    'Properties for an event within the events list page.
    Public Property eventId As Integer = 0
    Public Property eventTitle As String = String.Empty
    Public Property location As String = String.Empty
    Public Property eventStartTime As DateTime = Date.Now
    Public Property eventEndTime As DateTime = Date.Now
    Public Property description As String = String.Empty
    Public Property imageUrl As String = String.Empty
    Public Property allDayEvent As Boolean = False
    Public Property recurringEvent As Boolean = False

    'Public Property landingPgUrl As String = String.Empty

#Region "Handles"
    Public Sub New()
    End Sub
#End Region
End Class

End Namespace