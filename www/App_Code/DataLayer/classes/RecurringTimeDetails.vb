Imports Microsoft.VisualBasic

Namespace DataLayer
    Public Class RecurringTimeDetails
        Public Enum recurrenceTypes
            None
            Daily
            Weekly
            Monthly
            Yearly
        End Enum
        Public Enum weeklyIntervalType
            Every
            Second
            Third
            Forth
            Fifth
            NA
        End Enum
        Public Enum weeklyIntervalOfMonthType
            First
            Second
            Third
            Forth
            Fifth
            Last
            NA
        End Enum

        Public Property Recurrence As recurrenceTypes = recurrenceTypes.None
        Public Property RecurUntil As DateTime = Date.Now.AddYears(1)
        Public Property ExceptOnDates As String = "NA"
        Public Property weeklyIntervalOfMonth As weeklyIntervalOfMonthType = weeklyIntervalOfMonthType.NA
        Public Property DaysOfWeek As String = "NA"
        Public Property weeklyInterval As weeklyIntervalType = weeklyIntervalType.NA
        Public Property useStartDate As Boolean = True
        Public Property everyMonth As Boolean = True
        Public Property monthsPerYear As String = "NA"

        Public Sub New()
        End Sub
    End Class
End Namespace

