Imports Common
Imports Umbraco
Imports Umbraco.NodeFactory


Public Class ListItem_TopUpcomingEvent
    Inherits System.Web.UI.UserControl


#Region "Properties"
    Public Property eventItem As DataLayer.EventItem
#End Region

#Region "Handles"
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If Not IsNothing(eventItem) Then
                imgFeatured.ImageUrl = eventItem.featuredImgUrl
                imgFeatured.AlternateText = eventItem.featuredImgName
                ltrlTitle.Text = eventItem.eventTitle
                ltrlDate.Text = eventItem.eventDate.ToString("MMMM d, yyyy")
                hlnkEvent.NavigateUrl = eventItem.eventUrl
            End If
        Catch ex As Exception
            'Save error to umbraco
            Dim sb As New StringBuilder
            sb.AppendLine("ListItem_TopUpcomingEvent.ascx | Page_Load()")
            SaveErrorMessage(ex, sb, Me.GetType())

            Response.Write("Error: " & ex.ToString)
        End Try
    End Sub
#End Region

#Region "Methods"
    'Private Function getEventCalendar(ByVal _thisNode As Node) As Node
    '    If _thisNode.NodeTypeAlias = aliases.eventCalendar Or _thisNode.NodeTypeAlias = aliases.calendarListNew Then
    '        Return _thisNode
    '    Else
    '        Return getEventCalendar(_thisNode.Parent)
    '    End If
    'End Function
#End Region
End Class