Namespace DataLayer
    Public Class Author
        Public Property id As Integer
        Public Property name As String = String.Empty
        Public Property featuredImageUrl As String = String.Empty
        Public Property featuredImageName As String = String.Empty
        Public Property email As String = String.Empty
        Public Property content As String = String.Empty
        Public Property existsInList As Boolean = False


        Public Sub New()
        End Sub
    End Class
End Namespace
