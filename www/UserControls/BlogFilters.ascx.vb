﻿Imports umbraco
Imports umbraco.NodeFactory
Imports Common


Public Class BlogFilters
    Inherits System.Web.UI.UserControl


#Region "Properties"
    Private blBlogs As blBlogs
    Private isListPage As Boolean = False
    Private parentUrl As String = String.Empty

    Private Class _postByDate
        Public Property year As Integer
        Public Property blogMonth As New List(Of _pbdMonth)
    End Class
    Private Class _pbdMonth
        Public Property monthId As Integer
        Public Property monthName As String
        Public Property lstBlogEntries As New List(Of DataLayer.BlogEntry)
        'Public Property blogEntries As New List(Of _pbdBlogEntry)
    End Class

#End Region

#Region "Handles"
    Private Sub UserControls_MissionHealthyLiving_BlogFilters_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try
            'Instantiate variables
            blBlogs = New blBlogs
            Dim listId As Integer

            'Save global values for databinding function and jquery session functionality.
            Select Case Node.GetCurrent.NodeTypeAlias
                Case aliases.blogHome, aliases.podcastList
                    isListPage = True
                    parentUrl = Node.GetCurrent.NiceUrl
                    listId = Node.getCurrentNodeId
                Case Else
                    parentUrl = Node.GetCurrent.Parent.NiceUrl
                    listId = Node.GetCurrent.Parent.Id
            End Select
            'If Node.GetCurrent.NodeTypeAlias = aliases.blogHome Then
            '    isListPage = True
            '    parentUrl = Node.GetCurrent.NiceUrl
            '    listId = Node.getCurrentNodeId
            'Else
            '    parentUrl = Node.GetCurrent.Parent.NiceUrl
            '    listId = Node.GetCurrent.Parent.Id
            'End If

            hfldListPgUrl.Value = parentUrl
            hfldIsListPg.Value = isListPage
            hfldListId.Value = listId


            '=====================================
            '   Obtain all blog entries
            '=====================================
            'Instantiate variables
            Dim lstAllBlogLinks As List(Of DataLayer.BlogEntry)
            Dim bReturnBlogLinks As New BusinessReturn

            'Obtain data
            If isListPage Then
                bReturnBlogLinks = blBlogs.selectAllBlogLinks(Node.getCurrentNodeId)
            Else
                bReturnBlogLinks = blBlogs.selectAllBlogLinks(Node.GetCurrent.Parent.Id)
            End If

            If bReturnBlogLinks.isValid Then
                'Extract data
                lstAllBlogLinks = DirectCast(bReturnBlogLinks.DataContainer(0), List(Of DataLayer.BlogEntry))
            End If






            '=====================================
            '   Display top latest entries
            '=====================================
            If Not IsNothing(lstAllBlogLinks) Then
                'Display data
                lvLatestPosts.DataSource = lstAllBlogLinks.Take(3).ToList
                lvLatestPosts.DataBind()
            End If






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
            Dim pbdBlogEntry As New DataLayer.BlogEntry


            ''TEMP- TEST PREVIOUS YEAR ENTRY
            'Dim blg As New DataLayer.BlogEntry
            'blg.nodeId = 1
            'blg.url = "/"
            'blg.title = "temp"
            'blg.navigationTitle = "temp"
            'blg.postDate = Date.Today.AddYears(-1)
            'lstAllBlogLinks.Add(blg)


            'Loop thru all blog entries in descending date order
            For Each blogEntry As DataLayer.BlogEntry In lstAllBlogLinks

                'Verify is a new year class is to be created.
                If (blogEntry.postDate.Year <> _year) Then
                    'Save latest year
                    _year = blogEntry.postDate.Year
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
                If (blogEntry.postDate.Month <> _month) Or (_newYear = True) Then
                    'Save latest month
                    _month = blogEntry.postDate.Month
                    'Create new class
                    pbdMonth = New _pbdMonth
                    'Add data to class
                    pbdMonth.monthId = _month
                    pbdMonth.monthName = blogEntry.postDate.ToString("MMMM")
                    'Add class to list
                    postByDate.blogMonth.Add(pbdMonth)
                    'Reset trigger value
                    _newYear = False
                End If

                'Create new class
                pbdBlogEntry = New DataLayer.BlogEntry
                'Add data to class
                pbdBlogEntry.title = blogEntry.title
                pbdBlogEntry.url = blogEntry.url
                'Add class to list
                pbdMonth.lstBlogEntries.Add(pbdBlogEntry)
            Next

            'Display list
            lvPostYear.DataSource = lstPostByDate
            lvPostYear.DataBind()

            'gv.DataSource = lstPostByDate
            'gv.DataBind()
            'gv2.DataSource = lstPostByDate(0).blogMonth
            'gv2.DataBind()
            'gv3.DataSource = lstAllBlogLinks
            'gv3.DataBind()



            '=====================================
            '   Posts by Author
            '=====================================
            'Instantiate variables
            Dim lstAuthors As New List(Of DataLayer.Author)
            Dim bReturnAuthors As New BusinessReturn

            'Obtain data
            bReturnAuthors = blBlogs.selectAllAuthors_WithinParent(listId)

            If bReturnAuthors.isValid Then
                'Extract data
                lstAuthors = DirectCast(bReturnAuthors.DataContainer(0), List(Of DataLayer.Author))

                'Display data
                lvPostsByAuthor.DataSource = lstAuthors.OrderBy(Function(i) i.name)
                lvPostsByAuthor.DataBind()
            End If





            '=====================================
            '   Posts by Tag
            '=====================================
            'Instantiate variables
            Dim lstTags As New List(Of DataLayer.Tag)
            Dim bReturnTags As New BusinessReturn

            'Obtain data
            bReturnTags = blBlogs.selectAllTags_WithinParent(listId)

            If bReturnTags.isValid Then
                'Extract data
                lstTags = DirectCast(bReturnTags.DataContainer(0), List(Of DataLayer.Tag))

                lvPostsByTag.DataSource = lstTags.OrderBy(Function(i) i.name)
                lvPostsByTag.DataBind()

            End If





            '=====================================
            '   View All
            '=====================================
            If Not isListPage Then
                'Set link as clickable to navigate to parent page.
                hlnkViewAll.NavigateUrl = Node.GetCurrent.Parent.NiceUrl
                hlnkViewAll.Attributes.Remove("onclick")
            End If





            '=====================================
            '   Search
            '=====================================
            'IDEA: PASS SEARCH TEXT TO WEB SERVICE, RETURN LIST OF NODES, NARROW DOWN BY NODE IDs




        Catch ex As Exception
            'Save error to umbraco
            Dim sb As New StringBuilder
            sb.AppendLine("BlogFilters.ascx | Load()")
            SaveErrorMessage(ex, sb, Me.GetType())

            'Response.Write("Error: " & ex.ToString & "<br />")
        End Try
    End Sub
#End Region

#Region "Methods"
#End Region

End Class




'Private Sub lvPostsByAuthor_ItemDataBound(sender As Object, e As ListViewItemEventArgs) Handles lvPostsByAuthor.ItemDataBound
'    Try
'        'Instantiate variables
'        If Not isListPage Then
'            If e.Item.ItemType = ListViewItemType.DataItem Then
'                'Instantiate variables
'                Dim hlnk As HyperLink = DirectCast(e.Item.FindControl("hlnk"), HyperLink)
'                Dim sb As New StringBuilder

'                'Create new url & querystring
'                sb.Append(parentUrl & "?")
'                sb.Append("data-filterby=" & hlnk.Attributes("data-filterby"))
'                sb.Append("&data-filterid=" & hlnk.Attributes("data-filterid"))
'                sb.Append("&data-filtername=" & hlnk.Attributes("data-filtername"))

'                'Update control
'                hlnk.NavigateUrl = sb.ToString
'                hlnk.Attributes.Remove("onclick")


'                'ALTERNATIVE IDEA: INSTEAD OF USING A QUERYSTRING, SEND DATA AS JQUERY SESSION.
'            End If
'        End If
'    Catch ex As Exception
'        'Save error to umbraco
'        Dim sb As New StringBuilder
'        sb.AppendLine("BlogFilters.ascx.vb | lvPostsByAuthor_ItemDataBound()")
'        SaveErrorMessage(ex, sb, Me.GetType())
'    End Try
'End Sub
'Private Sub lvPostsByTag_ItemDataBound(sender As Object, e As ListViewItemEventArgs) Handles lvPostsByTag.ItemDataBound
'    Try
'        'Instantiate variables
'        If Not isListPage Then
'            If e.Item.ItemType = ListViewItemType.DataItem Then
'                'Instantiate variables
'                Dim hlnk As HyperLink = DirectCast(e.Item.FindControl("hlnk"), HyperLink)
'                Dim sb As New StringBuilder

'                'Create new url & querystring
'                sb.Append(parentUrl & "?")
'                sb.Append("data-filterby=" & hlnk.Attributes("data-filterby"))
'                sb.Append("&data-filterid=" & hlnk.Attributes("data-filterid"))
'                sb.Append("&data-filtername=" & hlnk.Attributes("data-filtername"))

'                'Update control
'                hlnk.NavigateUrl = sb.ToString
'                hlnk.Attributes.Remove("onclick")


'                'ALTERNATIVE IDEA: INSTEAD OF USING A QUERYSTRING, SEND DATA AS JQUERY SESSION.
'            End If
'        End If
'    Catch ex As Exception
'        'Save error to umbraco
'        Dim sb As New StringBuilder
'        sb.AppendLine("BlogFilters.ascx.vb | lvPostsByTag_ItemDataBound()")
'        SaveErrorMessage(ex, sb, Me.GetType())
'    End Try
'End Sub