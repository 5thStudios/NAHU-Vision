Imports System.Data
Imports umbraco
Imports umbraco.NodeFactory
Imports Common


Public Class MeetTheAuthors
    Inherits System.Web.UI.UserControl


#Region "Properties"
    Private Structure dtAuthors
        Const authorName As String = "authorName"
        Const imgUrl As String = "imgUrl"
        Const navUrl As String = "navUrl"
    End Structure
#End Region

#Region "Handles"
    Private Sub UserControls_MeetTheAuthors_Load(sender As Object, e As EventArgs) Handles Me.Load
        'lstviewMeetTheAuthors

        'Create table
        Dim dt As DataTable = New DataTable
        dt.Columns.Add(dtAuthors.authorName, GetType(String))
        dt.Columns.Add(dtAuthors.imgUrl, GetType(String))
        dt.Columns.Add(dtAuthors.navUrl, GetType(String))

        'Add records to table
        Dim authorsNode As Node = New Node(siteNodes.Authors)
        For Each author As Node In authorsNode.Children
            Dim dr As DataRow = dt.NewRow
            dr(dtAuthors.authorName) = author.Name
            dr(dtAuthors.imgUrl) = getMediaURL(author.GetProperty("featuredImage").Value, crops.ListItemSquared)
            dr(dtAuthors.navUrl) = author.NiceUrl
            dt.Rows.Add(dr)
        Next

        'assign table to listView
        lstviewMeetTheAuthors.DataSource = dt
        lstviewMeetTheAuthors.DataBind()
    End Sub
#End Region

#Region "Methods"
#End Region

End Class