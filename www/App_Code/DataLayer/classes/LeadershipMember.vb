Imports Microsoft.VisualBasic


Public Class LeadershipMember

#Region "Node Properties Class"
    Public Property nodeId As Integer = 0
    Public Property memberName As String = String.Empty
    Public Property title As String = String.Empty
    Public Property email As String = String.Empty
    Public Property memberImage As Integer = 0
    Public Property content As String = String.Empty
#End Region

#Region "Custom Properties Class"
    Public Property nodeUrl As String = String.Empty
    Public Property memberImageUrl As String = String.Empty
#End Region





#Region "Handles"
    Public Sub New()
    End Sub
#End Region

End Class