Imports Microsoft.VisualBasic

Namespace DataLayer
    Public Class Certification

        'Common Content
        Public Property certificationId As Integer = 0
        Public Property certificationUrl As String = String.Empty
        Public Property certificationTitle As String = String.Empty
        Public Property lstCategories As New List(Of String)
        Public Property featuredImgName As String = String.Empty
        Public Property featuredImgUrl As String = String.Empty
        Public Property shortDescription As String = String.Empty
        Public Property commonContent As String = String.Empty
        Public Property courseHighlights As String = String.Empty
        Public Property haveQuestions As String = String.Empty
        Public Property lstSponsors As New List(Of DataLayer.Sponsor)


        'Online Content
        Public Property showOnlineContent As Boolean = False
        Public Property onlineContent As String = String.Empty
        Public Property onlineCosts As String = String.Empty
        Public Property onlineFormat As String = String.Empty
        Public Property onlineInstructors As String = String.Empty
        Public Property lstOnlineInstructors As New List(Of Member)


        'Classroom Content
        Public Property showClassroomContent As Boolean = False
        Public Property classroomContent As String = String.Empty
        Public Property classroomCosts As String = String.Empty
        Public Property classroomFormat As String = String.Empty
        Public Property classroomInstructors As String = String.Empty
        Public Property lstClassroomInstructors As New List(Of Member)


        'Navigation Links
        Public Property previousPage As QuickLink = Nothing
        Public Property nextPage As QuickLink = Nothing




        Public Sub New()
        End Sub
    End Class

End Namespace