Imports Microsoft.VisualBasic


Namespace DataLayer

    Public Class BreakingNews
        Public Property content As String = String.Empty
        Public Property linkId As Integer?
        Public Property linkUrl As String = String.Empty
        Public Property isVisible As Boolean = False


        Public Sub New()
        End Sub
    End Class

End Namespace