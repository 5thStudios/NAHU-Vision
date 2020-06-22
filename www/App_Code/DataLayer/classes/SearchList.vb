Imports Microsoft.VisualBasic


Namespace DataLayer
    Public Class SearchList
        Public Property id As Integer?
        Public Property title As String = String.Empty
        Public Property url As String = String.Empty
        Public Property isLocked As Boolean = False
        Public Property isVideo As Boolean = False
        Public Property breadcrumb As String = String.Empty


        Public Sub New()
        End Sub
    End Class
End Namespace