Imports Common


Public Class eventTimeFrame
    Inherits System.Web.UI.UserControl


#Region "Properties"
    Public Property eventItem As DataLayer.EventItem

    Private Enum _recurringViews
        None
        Daily
        Weekly
        Monthly
        Yearly
    End Enum
    Private Enum recurrenceTypes
        None
        Daily
        Weekly
        Monthly
        Yearly
    End Enum
    Private Enum monthlyViews
        FromStartDate
        FromCustomDay
    End Enum
    Private Enum yearlyViews
        FromStartDate
        FromCustomDay
    End Enum
#End Region

#Region "Handles"
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Is event a single or recurrent event
        If Not eventItem.recurringEvent Then
            'Single-day event
            mvTimeframes.ActiveViewIndex = _recurringViews.None
            ltrlSingleDay_EventDate.Text = eventItem.eventDate.ToLongDateString

            If eventItem.allDayEvent Then
                'Show all-day event
                ltrlSingleDay_Timeframe.Text = "All-day event"
            Else
                'Show timeframe
                ltrlSingleDay_Timeframe.Text = getTimeframe()
            End If

        Else
            'Recurring event
            Select Case eventItem.recurringTimeDetails.Recurrence

                Case recurrenceTypes.Daily
                    createTimeframe_Daily()

                Case recurrenceTypes.Weekly
                    createTimeframe_Weekly()

                Case recurrenceTypes.Monthly
                    createTimeframe_Monthly()

                Case recurrenceTypes.Yearly
                    createTimeframe_Yearly()

            End Select
        End If
    End Sub
#End Region

#Region "Methods"
    Private Function getTimeframe() As String
        'Show timeframe
        Dim sbTimeframe As New StringBuilder



        'Create the FROM time
        Dim from As New StringBuilder
        Dim fromAMPM As New StringBuilder
        For Each c As Char In eventItem.fromHour
            If IsNumeric(c) Then
                from.Append(c)
            Else
                fromAMPM.Append(c)
            End If
        Next
        from.Append(eventItem.fromMinute)
        from.Append(fromAMPM.ToString)
        sbTimeframe.Append(from.ToString)
        'sbTimeframe.Append(" &ndash; ")

        'Create the TO time
        Dim toTime As New StringBuilder
        Dim toAMPM As New StringBuilder
        For Each c As Char In eventItem.toHour
            If IsNumeric(c) Then
                toTime.Append(c)
            Else
                toAMPM.Append(c)
            End If
        Next
        toTime.Append(eventItem.toMinute)
        toTime.Append(toAMPM.ToString)

        'Adds an Ndash if and end time exists
        If toTime.ToString <> "" Then
            sbTimeframe.Append(" &ndash; ")
        End If

        sbTimeframe.Append(toTime.ToString)

        'ltrlSingleDay_Timeframe.Text = sbTimeframe.ToString
        Return sbTimeframe.ToString
    End Function
    Private Sub createTimeframe_Daily()
        mvTimeframes.ActiveViewIndex = _recurringViews.Daily
        ltrlDaily_StartDate.Text = eventItem.eventDate.ToLongDateString
        ltrlDaily_EndDate.Text = eventItem.recurringTimeDetails.RecurUntil.ToLongDateString
        ltrlDaily_Timeframe.Text = getTimeframe()

        'Format days of week
        If Not String.IsNullOrEmpty(eventItem.recurringTimeDetails.DaysOfWeek) Then
            Dim first As Boolean = True
            Dim lst As List(Of String) = eventItem.recurringTimeDetails.DaysOfWeek.Split(",").ToList

            For Each item As String In lst
                If Not first Then
                    ltrlDaily_Days.Text += ", "
                End If
                first = False
                ltrlDaily_Days.Text += item
            Next
            If ltrlDaily_Days.Text.Contains(",") Then
                Dim last = ltrlDaily_Days.Text.LastIndexOf(",")
                ltrlDaily_Days.Text = ltrlDaily_Days.Text.Remove(last, 1).Insert(last, " and")
            End If
        End If

        'Format dates
        If Not String.IsNullOrEmpty(eventItem.recurringTimeDetails.ExceptOnDates) Then
            pnlDaily_Except.Visible = True
            Dim first As Boolean = True
            Dim lst As List(Of String) = eventItem.recurringTimeDetails.ExceptOnDates.Split(",").ToList

            For Each item As String In lst
                If Not first Then
                    ltrlDaily_Except.Text += "<br />"
                End If
                first = False
                ltrlDaily_Except.Text += CDate(item).ToLongDateString
            Next

        End If
    End Sub
    Private Sub createTimeframe_Weekly()
        mvTimeframes.ActiveViewIndex = _recurringViews.Weekly

        'ltrlWeekly_Interval.Text = eventItem.recurringTimeDetails.weeklyInterval
        If eventItem.recurringTimeDetails.weeklyInterval = 0 Then
            ltrlWeekly_Interval.Text = "week"
        Else
            ltrlWeekly_Interval.Text = (eventItem.recurringTimeDetails.weeklyInterval + 1).ToString & " weeks"
        End If

        'Format days of week
        If Not String.IsNullOrEmpty(eventItem.recurringTimeDetails.DaysOfWeek) Then
            Dim first As Boolean = True
            Dim lst As List(Of String) = eventItem.recurringTimeDetails.DaysOfWeek.Split(",").ToList

            For Each item As String In lst
                If Not first Then
                    ltrlWeekly_Day.Text += ", "
                End If
                first = False
                ltrlWeekly_Day.Text += item
            Next
            Dim last = ltrlWeekly_Day.Text.LastIndexOf(",")
            If last >= 0 Then ltrlWeekly_Day.Text = ltrlWeekly_Day.Text.Remove(last, 1).Insert(last, " and")
        End If

        ltrlWeekly_StartDate.Text = eventItem.eventDate.ToLongDateString
        ltrlWeekly_EndDate.Text = eventItem.recurringTimeDetails.RecurUntil.ToLongDateString
        ltrlWeekly_Timeframe.Text = getTimeframe()

        'Format dates
        If Not String.IsNullOrEmpty(eventItem.recurringTimeDetails.ExceptOnDates) Then
            pnlWeekly_Except.Visible = True
            Dim first As Boolean = True
            Dim lst As List(Of String) = eventItem.recurringTimeDetails.ExceptOnDates.Split(",").ToList

            For Each item As String In lst
                If Not first Then
                    ltrlWeekly_Except.Text += "<br />"
                End If
                first = False
                If IsDate(item) Then ltrlWeekly_Except.Text += CDate(item).ToLongDateString
            Next

        End If
    End Sub
    Private Sub createTimeframe_Monthly()
        mvTimeframes.ActiveViewIndex = _recurringViews.Monthly

        If eventItem.recurringTimeDetails.useStartDate Then
            'Display view for start date
            mvMonthly.ActiveViewIndex = monthlyViews.FromStartDate

            'Populate general data
            ltrlMonthly_FromStartDate_Day.Text = formatDay(eventItem.eventDate.Day)
            ltrlMonthly_FromStartDate_StartDate.Text = eventItem.eventDate.ToLongDateString
            ltrlMonthly_FromStartDate_EndDate.Text = eventItem.recurringTimeDetails.RecurUntil.ToLongDateString
            ltrlMonthly_FromStartDate_Timeframe.Text = getTimeframe()
            pnlMonthly_FromStartDate_Except.Visible = False

            'Create list of months
            If eventItem.recurringTimeDetails.everyMonth = False Then
                If Not String.IsNullOrEmpty(eventItem.recurringTimeDetails.monthsPerYear) Then
                    pnlMonthly_FromStartDate_MonthList.Visible = True
                    Dim first As Boolean = True
                    Dim lst As List(Of String) = eventItem.recurringTimeDetails.monthsPerYear.Split(",").ToList

                    For Each item As String In lst
                        If Not first Then
                            ltrlMonthly_FromStartDate_MonthList.Text += "<br/>"
                        End If
                        first = False
                        ltrlMonthly_FromStartDate_MonthList.Text += item
                    Next
                End If
            End If

            'Format dates
            If Not String.IsNullOrEmpty(eventItem.recurringTimeDetails.ExceptOnDates) Then
                pnlMonthly_FromStartDate_Except.Visible = True
                Dim first As Boolean = True
                Dim lst As List(Of String) = eventItem.recurringTimeDetails.ExceptOnDates.Split(",").ToList

                For Each item As String In lst
                    If Not first Then
                        ltrlMonthly_FromStartDate_Except.Text += "<br />"
                    End If
                    first = False
                    ltrlMonthly_FromStartDate_Except.Text += CDate(item).ToLongDateString
                Next
            End If
        Else
            'Display view for start week
            mvMonthly.ActiveViewIndex = monthlyViews.FromCustomDay

            'Populate general data
            ltrlMonthly_FromWeek_Interval.Text = eventItem.recurringTimeDetails.weeklyIntervalOfMonth


            If eventItem.recurringTimeDetails.weeklyIntervalOfMonth >= 0 Then
                ltrlMonthly_FromWeek_Interval.Text = formatDay(eventItem.recurringTimeDetails.weeklyIntervalOfMonth + 1)
            End If


            ltrlMonthly_FromWeek_Day.Text = eventItem.recurringTimeDetails.DaysOfWeek 'formatDay(eventItem.eventDate.Day)
            ltrlMonthly_FromWeek_StartDate.Text = eventItem.eventDate.ToLongDateString
            ltrlMonthly_FromWeek_EndDate.Text = eventItem.recurringTimeDetails.RecurUntil.ToLongDateString
            ltrlMonthly_FromWeek_Timeframe.Text = getTimeframe()
            pnlMonthly_FromWeek_Except.Visible = False

            'Create list of months
            If eventItem.recurringTimeDetails.everyMonth = False Then
                If Not String.IsNullOrEmpty(eventItem.recurringTimeDetails.monthsPerYear) Then
                    pnlMonthly_FromWeek_MonthList.Visible = True
                    Dim first As Boolean = True
                    Dim lst As List(Of String) = eventItem.recurringTimeDetails.monthsPerYear.Split(",").ToList

                    For Each item As String In lst
                        If Not first Then
                            ltrlMonthly_FromWeek_MonthList.Text += "<br/>"
                        End If
                        first = False
                        ltrlMonthly_FromWeek_MonthList.Text += item
                    Next
                End If
            End If

            'Format dates
            If Not String.IsNullOrEmpty(eventItem.recurringTimeDetails.ExceptOnDates) Then
                pnlMonthly_FromWeek_Except.Visible = True
                Dim first As Boolean = True
                Dim lst As List(Of String) = eventItem.recurringTimeDetails.ExceptOnDates.Split(",").ToList

                For Each item As String In lst
                    If Not first Then
                        ltrlMonthly_FromWeek_Except.Text += "<br />"
                    End If
                    first = False
                    ltrlMonthly_FromWeek_Except.Text += CDate(item).ToLongDateString
                Next
            End If
        End If

    End Sub
    Private Sub createTimeframe_Yearly()
        mvTimeframes.ActiveViewIndex = _recurringViews.Yearly

        If eventItem.recurringTimeDetails.useStartDate Then
            'Display view for start date
            mvYearly.ActiveViewIndex = yearlyViews.FromStartDate

            'Populate general data
            ltrlYearly_FromStartDate_Month.Text = MonthName(eventItem.eventDate.Month)
            ltrlYearly_FromStartDate_Day.Text = formatDay(eventItem.eventDate.Day)
            ltrlYearly_FromStartDate_StartDate.Text = eventItem.eventDate.ToLongDateString
            ltrlYearly_FromStartDate_EndDate.Text = eventItem.recurringTimeDetails.RecurUntil.ToLongDateString
            ltrlYearly_FromStartDate_Timeframe.Text = getTimeframe()

            'Format dates
            If Not String.IsNullOrEmpty(eventItem.recurringTimeDetails.ExceptOnDates) Then
                pnlYearly_FromStartDate_Except.Visible = True
                Dim first As Boolean = True
                Dim lst As List(Of String) = eventItem.recurringTimeDetails.ExceptOnDates.Split(",").ToList

                For Each item As String In lst
                    If Not first Then
                        ltrlYearly_FromStartDate_Except.Text += "<br />"
                    End If
                    first = False
                    ltrlYearly_FromStartDate_Except.Text += CDate(item).ToLongDateString
                Next
            End If
        Else
            'Display view for start week
            mvYearly.ActiveViewIndex = yearlyViews.FromCustomDay

            'Populate general data
            'ltrlYearly_FromWeek_Interval.Text = eventItem.recurringTimeDetails.weeklyIntervalOfMonth

            ltrlYearly_FromWeek_Interval.Text = formatDay(eventItem.recurringTimeDetails.weeklyIntervalOfMonth + 1)
            ltrlYearly_FromWeek_Day.Text = eventItem.recurringTimeDetails.DaysOfWeek
            ltrlYearly_FromWeek_Month.Text = eventItem.recurringTimeDetails.monthsPerYear

            'ltrlYearly_FromWeek_Day.Text = eventItem.recurringTimeDetails.DaysOfWeek 'formatDay(eventItem.eventDate.Day)
            ltrlYearly_FromWeek_StartDate.Text = eventItem.eventDate.ToLongDateString
            ltrlYearly_FromWeek_EndDate.Text = eventItem.recurringTimeDetails.RecurUntil.ToLongDateString
            ltrlYearly_FromWeek_Timeframe.Text = getTimeframe()
            pnlYearly_FromWeek_Except.Visible = False

            'Format dates
            If Not String.IsNullOrEmpty(eventItem.recurringTimeDetails.ExceptOnDates) Then
                pnlYearly_FromWeek_Except.Visible = True
                Dim first As Boolean = True
                Dim lst As List(Of String) = eventItem.recurringTimeDetails.ExceptOnDates.Split(",").ToList

                For Each item As String In lst
                    If Not first Then
                        ltrlYearly_FromWeek_Except.Text += "<br />"
                    End If
                    first = False
                    ltrlYearly_FromWeek_Except.Text += CDate(item).ToLongDateString
                Next
            End If
        End If

    End Sub
#End Region


End Class