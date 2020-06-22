Imports Microsoft.VisualBasic
Imports Common
Imports umbraco
Imports umbraco.NodeFactory
Imports System.Data

Public Class blBanners

#Region "Properties"
    Private linqBanners As linqBanners
#End Region


#Region "Selects"
    Public Function obtainBanner(ByVal _thisNodeId As Integer) As BusinessReturn
        'Instantiate variables
        linqBanners = New linqBanners

        'Obtain list
        Return linqBanners.obtainBanner(_thisNodeId)
    End Function
    Public Function obtainQuoteBannerWithNav(ByVal _thisNodeId As Integer) As BusinessReturn
        'Instantiate variables
        linqBanners = New linqBanners

        'Obtain list
        Return linqBanners.obtainQuoteBannerWithNav(_thisNodeId)
    End Function
    Public Function obtainTextBlock(ByVal _thisNodeId As Integer) As BusinessReturn
        'Instantiate variables
        linqBanners = New linqBanners

        'Obtain list
        Return linqBanners.obtainTextBlock(_thisNodeId)
    End Function
    Public Function obtainSimpleBanner(ByVal _thisNodeId As Integer) As BusinessReturn
        'Instantiate variables
        linqBanners = New linqBanners

        'Obtain list
        Return linqBanners.obtainSimpleBanner(_thisNodeId)
    End Function
#End Region

#Region "Methods"
#End Region
End Class

