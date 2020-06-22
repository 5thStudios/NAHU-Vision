Imports Microsoft.VisualBasic
Imports Common
Imports umbraco
Imports umbraco.NodeFactory
Imports System.Data

Public Class blPanels


#Region "Properties"
    Private linqPanels As linqPanels
#End Region

#Region "Selects"
    Public Function obtainCustomlinks(ByVal _thisNodeId As Integer) As BusinessReturn
        'Instantiate variables
        linqPanels = New linqPanels

        'Obtain list
        Return linqPanels.obtainCustomlinks(_thisNodeId)
    End Function
    Public Function obtainFeaturedNewsArticle(ByVal _thisNodeId As Integer) As BusinessReturn
        'Instantiate variables
        linqPanels = New linqPanels

        'Obtain article
        Return linqPanels.obtainFeaturedNewsArticle(_thisNodeId)
    End Function
    Public Function obtainLatestNewsArticles(Optional ByVal addFeaturedArticle As Boolean = False) As BusinessReturn
        'Instantiate variables
        linqPanels = New linqPanels

        'Obtain list
        Return linqPanels.obtainLatestNewsArticles(addFeaturedArticle)
    End Function
    Public Function obtainLatestNewsArticles_byList(Optional ByVal addFeaturedArticle As Boolean = False) As BusinessReturn
        'Instantiate variables
        linqPanels = New linqPanels

        'Obtain list
        Return linqPanels.obtainLatestNewsArticles_byList(addFeaturedArticle)
    End Function
    Public Function obtainQuicklinks(ByVal _thisNodeId As Integer) As BusinessReturn
        'Instantiate variables
        linqPanels = New linqPanels

        'Obtain list
        Return linqPanels.obtainQuicklinks(_thisNodeId)
    End Function
    Public Function obtainCall2ActionPnl(ByVal _thisNodeId As Integer) As BusinessReturn
        'Instantiate variables
        linqPanels = New linqPanels

        'Obtain list
        Return linqPanels.obtainCall2ActionPnl(_thisNodeId)
    End Function
    Public Function obtainFaqList(ByVal _thisNodeId As Integer) As BusinessReturn
        'Instantiate variables
        linqPanels = New linqPanels

        'Obtain list
        Return linqPanels.obtainFaqList(_thisNodeId)
    End Function
    Public Function obtainBreakingNews(ByVal _thisNodeId As Integer) As BusinessReturn
        'Instantiate variables
        linqPanels = New linqPanels

        'Obtain list
        Return linqPanels.obtainBreakingNews(_thisNodeId)
    End Function
    Public Function obtainGenericSiteData(ByVal homeId As Integer) As BusinessReturn
        'Instantiate variables
        linqPanels = New linqPanels

        'Obtain list
        Return linqPanels.obtainGenericSiteData(homeId)
    End Function
#End Region

#Region "Methods"
#End Region

End Class

