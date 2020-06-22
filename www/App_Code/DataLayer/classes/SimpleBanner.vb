Imports Microsoft.VisualBasic
Imports Common

Namespace DataLayer
    Public Class SimpleBanner
        Public Property nodeId As Integer = 0
        Public Property title As String = String.Empty
        Public Property subtitle As String = String.Empty
        Public Property backgroundImageUrl As String = String.Empty
        Public Property backgroundImageName As String = String.Empty
        Public Property dropShadowClass As String = String.Empty
        Public Property useNativeDimensions As Boolean = False


#Region "Handles"
        Public Sub New()
        End Sub
#End Region
    End Class
End Namespace
