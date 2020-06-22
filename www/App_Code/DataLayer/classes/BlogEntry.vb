Imports Microsoft.VisualBasic

Namespace DataLayer
    Public Class BlogEntry
        Public Property nodeId As Integer
        Public Property url As String = String.Empty
        Public Property title As String = String.Empty
        Public Property navigationTitle As String = String.Empty
        Public Property summary As String = String.Empty
        Public Property content As String = String.Empty

        Public Property postDate As Date = New Date
        Public Property author As New Author
        Public Property lstTags As New List(Of Tag)
        Public Property disableComments As Boolean = False

        Public Property featuredOptions As String = String.Empty
        Public Property featuredImageUrl As String = String.Empty
        Public Property featuredImageName As String = String.Empty
        Public Property featuredVideoId As String = String.Empty
        Public Property featuredVideoUrl As String = String.Empty
        Public Property widescreenVideo As Boolean = False
        Public Property vimeoImageId As String = String.Empty
        Public Property podcastUrl As String = String.Empty
        Public Property rssFeedUrl As String = String.Empty

        Public Property isPdf As Boolean = False
        Public Property isLocked As Boolean = False
        Public Property isPodcast As Boolean = False

        Public Property showFeaturedImg As Boolean = False
        Public Property showYoutubeVideo As Boolean = False
        Public Property showVimeoVideo As Boolean = False
        Public Property isExternalUrl As Boolean = False


        'Public Property authorId As Integer
        'Public Property authorName As String = String.Empty
        'Public Property tags As String = String.Empty

        Public Sub New()
        End Sub
    End Class

End Namespace