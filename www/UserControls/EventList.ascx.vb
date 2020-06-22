Imports System.Xml.XPath
Imports Common
Imports Umbraco
Imports Umbraco.NodeFactory

Public Class EventList
    Inherits System.Web.Mvc.ViewUserControl


#Region "Properties"
    Private blEvents As blEvents
    Private returnMsg As BusinessReturn
#End Region


#Region "Handles"
    Private Sub Masterpages_CalendarList_Load(sender As Object, e As EventArgs) Handles Me.Load
        'Instantiate variables
        Dim thisNode As Node = Node.GetCurrent

        'Obtain a list of all events
        obtainEvents()
    End Sub
#End Region


#Region "Methods"
    Private Sub obtainEvents(Optional ByVal _category As String = "", Optional ByVal _calendar As Integer = 0)
        'Instantiate variables
        blEvents = New blEvents

        'Obtain all events
        returnMsg = blEvents.selectAllEvents(0, False, False, _category, _calendar)

        'If valid return, display events
        If returnMsg.isValid Then
            'Obtain list of events from return msg.
            Dim lstEvents As List(Of DataLayer.EventItem) = DirectCast(returnMsg.DataContainer(0), List(Of DataLayer.EventItem))

            'Display events
            lvEventEntries.Items.Clear()
            lvEventEntries.Controls.Clear()
            lvEventEntries.DataSource = lstEvents
            lvEventEntries.DataBind()
        Else
            Response.Write(returnMsg.ExceptionMessage)
        End If
    End Sub
#End Region
End Class