Imports Microsoft.VisualBasic
Imports Common

Namespace DataLayer
    Public Class QuoteBannerWithNav
        Public Property nodeId As Integer = 0
        Public Property quote As String = String.Empty
        Public Property author As String = String.Empty
        Public Property backgroundImageUrl As String = String.Empty
        Public Property backgroundImageName As String = String.Empty
        Public Property lstSideNavLinks As New List(Of sideNavLink)
        Public Property useNativeDimensions As Boolean = False
        Public Property showSideNav As Boolean = True
        Public Property textAlignment As HorizontalAlign = HorizontalAlign.NotSet
        Public Property dropShadowClass As String = String.Empty


        Public Sub New()
        End Sub


        Public Class sideNavLink
            Public Property nodeId As Integer = 0
            Public Property url As String = String.Empty
            Public Property quicklinkTitle As String = String.Empty
            Public Property quicklinkSubtitle As String = String.Empty
            Public Property iconImageUrl As String = String.Empty

            Public Property openInNewTab As Boolean = False




            Public Sub New()
            End Sub
        End Class
    End Class
End Namespace