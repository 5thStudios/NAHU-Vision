Namespace DataLayer
    Public Class NavLink
        Public Property id As Integer?
        Public Property parentId As Integer?
        Public Property lstPathIDs As List(Of Integer)
        Public Property name As String = String.Empty
        Public Property url As String = String.Empty
        Public Property path As String = String.Empty
        Public Property level As Integer?
        Public Property sortOrder As Integer?
        Public Property hasChildren As Boolean = False
        Public Property externalLink As Boolean = False


        Public Sub New()
        End Sub
    End Class
End Namespace