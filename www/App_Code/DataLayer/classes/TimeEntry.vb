Imports Microsoft.VisualBasic

Namespace DataLayer
    Public Class _TimeEntry
#Region "Private"
        Private m_recurrence As Integer '1- not recurring, 2- repeat daily, 3- repeat weekly, 4- repeat monthly, 5- repeat yearly
        Private m_weekInterval As Integer 'If repeat weekly this tells you if it's every week, every 2nd week, every 3rd week, etc.
        Private m_monthYearOption As Integer '0- Use startdate, 1- Specify nth week
        Private m_interval As Integer 'Interval of weekly events (eg: 1st, 2nd, last...)
        Private m_weekDay As Integer 'Weekday (Sun-Sat) for specified monthly and yearly events
        Private m_month As Integer 'Month for specified monthly and yearly events
        Private m_monthOption As String '1- Every month, 2- Select month(s) and add to months array.

        Private m_startDate As DateTime
        Private m_endDate As Nullable(Of DateTime)
        Private m_recurUntil As String

        Private m_days As List(Of Integer) 'array of days 0-6 for daily events
        Private m_months As List(Of Integer) 'array of days 0-11 for monthly events
        Private m_exceptDates As List(Of Date) 'array of dates the event will not occur on.
#End Region
#Region "Public"
        Public Property recurrence() As Integer
            Get
                Return m_recurrence
            End Get
            Set
                m_recurrence = Value
            End Set
        End Property
        Public Property weekInterval() As Integer
            Get
                Return m_weekInterval
            End Get
            Set
                m_weekInterval = Value
            End Set
        End Property
        Public Property monthYearOption() As Integer
            Get
                Return m_monthYearOption
            End Get
            Set
                m_monthYearOption = Value
            End Set
        End Property
        Public Property interval() As Integer
            Get
                Return m_interval
            End Get
            Set
                m_interval = Value
            End Set
        End Property
        Public Property weekDay() As Integer
            Get
                Return m_weekDay
            End Get
            Set
                m_weekDay = Value
            End Set
        End Property
        Public Property month() As Integer
            Get
                Return m_month
            End Get
            Set
                m_month = Value
            End Set
        End Property
        Public Property startDate() As DateTime
            Get
                Return m_startDate
            End Get
            Set
                m_startDate = Value
            End Set
        End Property
        Public Property endDate() As System.Nullable(Of DateTime)
            Get
                Return m_endDate
            End Get
            Set
                m_endDate = Value
            End Set
        End Property

        Public Property monthOption() As String
            Get
                Return m_monthOption
            End Get
            Set
                m_monthOption = Value
            End Set
        End Property
        Public Property recurUntil() As String
            Get
                Return m_recurUntil
            End Get
            Set
                m_recurUntil = Value
            End Set
        End Property
        Public Property days() As List(Of Integer)
            Get
                Return m_days
            End Get
            Set
                m_days = Value
            End Set
        End Property
        Public Property months() As List(Of Integer)
            Get
                Return m_months
            End Get
            Set
                m_months = Value
            End Set
        End Property
        Public Property exceptDates() As List(Of Date)
            Get
                Return m_exceptDates
            End Get
            Set
                m_exceptDates = Value
            End Set
        End Property

        Public Sub New()
        End Sub
#End Region
    End Class
End Namespace