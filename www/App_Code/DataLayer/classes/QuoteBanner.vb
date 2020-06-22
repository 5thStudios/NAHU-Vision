Imports Microsoft.VisualBasic
Imports Common

Namespace DataLayer
    Public Class QuoteBanner
        Public Property nodeId As Integer = 0
        Public Property title As String = String.Empty
        Public Property subtitle As String = String.Empty
        Public Property callToActionLink As String = String.Empty
        Public Property callToActionText As String = String.Empty
        Public Property backgroundImageUrl As String = String.Empty
        Public Property backgroundImageName As String = String.Empty
        Public Property textAlignment As HorizontalAlign = HorizontalAlign.NotSet
        Public Property dropShadowClass As String = String.Empty

        Public Property useNativeDimensions As Boolean = False
        Public Property showSubtitle As Boolean = False
        Public Property showCallToAction As Boolean = False


#Region "Handles"
        Public Sub New()
        End Sub
#End Region
    End Class
End Namespace

