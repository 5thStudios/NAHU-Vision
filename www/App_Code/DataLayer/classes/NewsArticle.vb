Imports System.Collections.Generic
Imports Microsoft.VisualBasic


Namespace DataLayer

    Public Class NewsArticle

#Region "Properties"
        Public Property articleSummary As ArticleSummary
        Public Property lstArticleSummary As List(Of ArticleSummary)
#End Region

#Region "Handles"
        Public Sub New()
        End Sub
#End Region
    End Class


    Public Class ArticleSummary
        Public Property nodeId As Integer
        Public Property title As String = String.Empty
        Public Property articleUrl As String = String.Empty
        Public Property postDate As Date = New Date
        Public Property featuredImageUrl As String = String.Empty
        Public Property featuredImageName As String = String.Empty
        Public Property isPdf As Boolean = False

        Public Property featuredOptions As String = String.Empty
        Public Property featuredVideoId As String = String.Empty
        Public Property featuredVideoUrl As String = String.Empty
        Public Property widescreenVideo As Boolean = False
        Public Property vimeoImageId As String = String.Empty

        Public Property parentName As String = String.Empty
        Public Property parentUrl As String = String.Empty

        Public Property showFeaturedImg As Boolean = False
        Public Property showYoutubeVideo As Boolean = False
        Public Property showVimeoVideo As Boolean = False
        Public Property isExternalUrl As Boolean = False



        Public Sub New()
        End Sub
    End Class

End Namespace