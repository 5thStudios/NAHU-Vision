Imports Microsoft.VisualBasic


Namespace DataLayer
    Public Class Member
        'Member Data
        Public Property memberId As Integer
        Public Property firstName As String = String.Empty
        Public Property lastName As String = String.Empty
        Public Property photoUrl As String = String.Empty


        'Demographics
        Public Property email As String = String.Empty
        Public Property phoneNumber As String = String.Empty
        Public Property phoneExtension As String = String.Empty


        'Trustee Info
        Public Property isATrustee As Boolean = False
        Public Property title As String = String.Empty
        Public Property summary As String = String.Empty
        Public Property trusteeUrl As String = String.Empty



        Public Sub New()
        End Sub
    End Class
End Namespace