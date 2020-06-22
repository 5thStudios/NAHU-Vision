Imports Umbraco
Imports Umbraco.NodeFactory
Imports Common
Imports Newtonsoft.Json


Public Class BlogListItem
    Inherits System.Web.UI.UserControl


#Region "Properties"
    Public Property nodeId As Integer = 0
#End Region

#Region "Handles"
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            'Instantiate variables
            If nodeId > 0 Then
                'Instantiate variables
                Dim bEntry As DataLayer.BlogEntry
                Dim blBlogs As New blBlogs
                Dim businessReturn As New BusinessReturn
                Dim isFirstRecord As Boolean = True
                Dim userLoggedIn As Boolean = isUserLoggedIn(Request.Cookies(nodeProperties.SessionGuid))

                'Obtain data
                businessReturn = blBlogs.selectBlogListEntry_byId(nodeId)

                If businessReturn.isValid Then
                    'Extract data
                    bEntry = DirectCast(businessReturn.DataContainer(0), DataLayer.BlogEntry)

                    'Dim lst As New List(Of DataLayer.BlogEntry)
                    'lst.Add(bEntry)
                    'gv.DataSource = lst
                    'gv.DataBind()

                    'Display data
                    ltrlMonth.Text = bEntry.postDate.ToString("MMM")
                    ltrlDay.Text = bEntry.postDate.ToString("dd")
                    ltrlDate.Text = bEntry.postDate.ToString("MMMM dd, yyyy")
                    ltrlDate_grid.Text = bEntry.postDate.ToString("MMMM dd, yyyy")

                    If Not String.IsNullOrWhiteSpace(bEntry.featuredImageUrl) Then
                        imgFeatured.AlternateText = bEntry.featuredImageName
                        imgFeatured.ImageUrl = bEntry.featuredImageUrl
                        imgFeatured_grid.AlternateText = bEntry.featuredImageName
                        imgFeatured_grid.ImageUrl = bEntry.featuredImageUrl
                        'ElseIf Not String.IsNullOrWhiteSpace(bEntry.featuredVideoUrl) Then
                        '    imgFeatured.AlternateText = bEntry.title
                        '    imgFeatured.ImageUrl = bEntry.featuredVideoUrl
                        '    imgFeatured_grid.AlternateText = bEntry.title
                        '    imgFeatured_grid.ImageUrl = bEntry.featuredVideoUrl
                    End If

                    ltrlTitle.Text = bEntry.title
                    ltrlTitle_grid.Text = bEntry.title
                    ltrlSummary.Text = bEntry.summary

                    If bEntry.isLocked Then

                        If userLoggedIn = True Then
                            hlnkReadMore.NavigateUrl = bEntry.url
                            hlnkReadMore_grid.NavigateUrl = bEntry.url
                        Else
                            'is pdf then remove link.
                            If bEntry.isPdf Then
                                hlnkReadMore.NavigateUrl = ""
                                hlnkReadMore_grid.NavigateUrl = ""
                            Else
                                hlnkReadMore.NavigateUrl = bEntry.url
                                hlnkReadMore_grid.NavigateUrl = bEntry.url
                            End If
                        End If



                    Else
                        hlnkReadMore.NavigateUrl = bEntry.url
                        hlnkReadMore_grid.NavigateUrl = bEntry.url
                    End If


                    If bEntry.isPdf Then
                        imgPdfIcon.Visible = True
                        imgPdfIcon_grid.Visible = True
                    ElseIf bEntry.isExternalUrl Then

                    Else
                        hlnkReadMore.Target = String.Empty
                        hlnkReadMore_grid.Target = String.Empty
                    End If

                    If bEntry.isLocked Then
                        imgLockIcon.Visible = True
                        imgLockIcon_grid.Visible = True
                    End If

                    pnlViewItem.Attributes.Add("data-author", bEntry.author.id)
                    pnlViewItem.Attributes.Add("data-tags", JsonConvert.SerializeObject(bEntry.lstTags))
                    pnlViewItem.Attributes.Add("data-filterid", bEntry.nodeId)

                    'ltrlCategory.Text = bEntry.lstTags
                    For Each tag As DataLayer.Tag In bEntry.lstTags
                        'Add spacer between tag
                        If isFirstRecord Then
                            isFirstRecord = False
                        Else
                            phCategories.Controls.Add(New LiteralControl(" &ndash; ")) 'Add seperator text between multiple tags.
                            phCategory_grid.Controls.Add(New LiteralControl(" &ndash; "))
                        End If

                        'Add tag
                        Dim hlnk As New HyperLink
                        hlnk.Text = tag.name
                        hlnk.Attributes.Add("data-filterby", "tag")
                        hlnk.Attributes.Add("data-filterid", tag.id)
                        hlnk.Attributes.Add("data-filtername", tag.name)
                        hlnk.Attributes.Add("onclick", "return false;")
                        phCategories.Controls.Add(hlnk)

                        'Add tag  (REPEATED BECAUSE YOU CANNOT ADD THE SAME CONTROL TO DIFFERENT OBJECTS.)
                        hlnk = New HyperLink
                        hlnk.Text = tag.name
                        hlnk.Attributes.Add("data-filterby", "tag")
                        hlnk.Attributes.Add("data-filterid", tag.id)
                        hlnk.Attributes.Add("data-filtername", tag.name)
                        hlnk.Attributes.Add("onclick", "return false;")
                        phCategory_grid.Controls.Add(hlnk)
                    Next

                Else
                    pnlViewItem.Visible = False
                End If
            End If
        Catch ex As Exception
            'Save error to umbraco
            Dim sb As New StringBuilder
            sb.AppendLine("BlogListItem.ascx.vb | Load()")
            SaveErrorMessage(ex, sb, Me.GetType())
        End Try

    End Sub
#End Region

#Region "Methods"
#End Region

End Class