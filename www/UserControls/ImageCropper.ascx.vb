Imports Umbraco
Imports Umbraco.NodeFactory
Imports Common



Public Class ImageCropper
    Inherits System.Web.UI.UserControl


#Region "Properties"
    Public Property crop As String = String.Empty
    Public Property mediaId As String = String.Empty
    Public Property alignment As String = String.Empty
    Public Property showBorder As Boolean = False

#End Region

#Region "Handles"
    Private Sub ImgCropper_PreRender(sender As Object, e As EventArgs) Handles Me.PreRender
        Try
            'Proceed if an image is provided to the macro.
            If Not String.IsNullOrWhiteSpace(mediaId) Then
                'Clean crop by removing [x] text
                Dim crops As String() = crop.Split("[")
                crop = crops(0).Trim

                'Obtain image url and name.
                img.ImageUrl = getMediaURL(mediaId, getCrop())
                img.AlternateText = getMediaName(mediaId)

                'Set image's alignment
                Select Case alignment
                    Case "Left"
                        img.ImageAlign = ImageAlign.Left
                        img.Attributes.Add("style", "float:left;")
                    Case "Right"
                        img.ImageAlign = ImageAlign.Right
                        img.Attributes.Add("style", "float:right;")
                    Case "Center"
                        img.ImageAlign = ImageAlign.NotSet
                        img.Attributes.Add("style", "display:block; margin-left:auto; margin-right:auto;float:none;")
                    Case Else
                        img.ImageAlign = ImageAlign.NotSet
                        img.Attributes.Add("style", "float:none;")
                End Select

            End If

            'Determine if image border should appear or not.
            If showBorder Then
                img.CssClass = "drop-shadow lifted"
            Else
                img.Attributes.Add("style", "padding:8px 16px;")
            End If

        Catch ex As Exception
            img.Visible = False
        End Try
    End Sub
#End Region

#Region "Methods"
    Private Function getCrop() As String
        'Determine what crop type is selected.
        'Select Case crop
        '    Case "Photo Horizontal"
        '        Return crops.PhotoHorizontal
        '    Case "Photo Vertical"
        '        Return crops.PhotoVertical
        '    Case "Square Image"
        '        Return crops.SquareImage
        '    Case "Home Page Banner"
        '        Return crops.HomePageBanner
        '    Case "Secondary Page Banner"
        '        Return crops.SecondaryPageBanner
        '    Case "Featured Thumbnail"
        '        Return crops.SuccessStoryFeaturedThumbnail
        '    Case "Success Story Photo"
        '        Return crops.SuccessStoryPhoto
        '    Case "Head Shot Portrait"
        '        Return crops.HeadShotPortrait
        '    Case "List Image"
        '        Return crops.ListImage
        '    Case Else
        '        Return String.Empty
        'End Select
    End Function
    Private Function getAlignment() As Integer
        Select Case alignment
            Case "Left"
                Return ImageAlign.Left
            Case "Right"
                Return ImageAlign.Right
            Case "Center"
                Return ImageAlign.Middle
            Case Else
                Return ImageAlign.NotSet
        End Select
    End Function
#End Region
End Class