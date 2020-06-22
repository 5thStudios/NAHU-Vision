Public Class Login
    Public Property IsValidated() As Boolean = False
    Public Property SessionToken() As String = String.Empty
    Public Property StatusMessage() As String = String.Empty
    Public Property ImisUserId() As String = String.Empty
    Public Property CookieStructures() As New List(Of CookieStructure)
End Class



Public Class CookieStructure
    Public Property Name() As String = String.Empty
    Public Property Value() As String = String.Empty
    Public Property Domain() As String = String.Empty
    Public Property Path() As String = String.Empty
    Public Property Expires() As String = String.Empty
    Public Property IsHttpOnly() As Boolean = False
    Public Property IsSecure() As Boolean = False
End Class