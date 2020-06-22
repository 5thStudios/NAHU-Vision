Imports Microsoft.VisualBasic


Namespace DataLayer

    Public Class QuickLink
        Public Property nodeId As Integer = 0
        Public Property title As String = String.Empty
        Public Property description As String = String.Empty
        Public Property linkUrl As String = String.Empty
        Public Property linkTitle As String = String.Empty
        Public Property openInNewTab As Boolean = False
        Public Property backgroundImageUrl As String = String.Empty
        Public Property backgroundImageName As String = String.Empty


        Public Sub New()
        End Sub
    End Class

End Namespace