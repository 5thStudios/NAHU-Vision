Imports Microsoft.VisualBasic
Imports Common
Imports umbraco
Imports umbraco.NodeFactory
Imports System.Data

Public Class blBlogs

#Region "Properties"
    Private linqBlogs As linqBlogs
#End Region

#Region "Selects"
    Public Function selectBlogListEntry_byId(ByVal _thisNodeId As Integer) As BusinessReturn
        'Instantiate variables
        linqBlogs = New linqBlogs

        'Obtain entry
        Return linqBlogs.selectBlogListEntry_byId(_thisNodeId)
    End Function
    Public Function selectBlog_byId(ByVal _thisNodeId As Integer) As BusinessReturn
        'Instantiate variables
        linqBlogs = New linqBlogs

        'Obtain entry
        Return linqBlogs.selectBlog_byId(_thisNodeId)
    End Function
    Public Function selectAllBlogLinks(ByVal _parentNodeId As Integer) As BusinessReturn
        'Instantiate variables
        linqBlogs = New linqBlogs

        'Obtain entry
        Return linqBlogs.selectAllBlogLinks(_parentNodeId)
    End Function
    Public Function selectTopNBlogLinks(ByVal _parentNodeId As Integer, ByVal _topN As Integer) As BusinessReturn
        'Instantiate variables
        linqBlogs = New linqBlogs

        'Obtain entry
        Return linqBlogs.selectTopNBlogLinks(_parentNodeId, _topN)
    End Function
    Public Function selectAllTags() As BusinessReturn
        'Instantiate variables
        linqBlogs = New linqBlogs

        'Obtain entry
        Return linqBlogs.selectAllTags()
    End Function
    Public Function selectAllTags_WithinParent(ByVal id As Integer) As BusinessReturn
        'Instantiate variables
        linqBlogs = New linqBlogs

        'Obtain entry
        Return linqBlogs.selectAllTags_WithinParent(id)
    End Function
    Public Function selectAllAuthors_NameIdOnly() As BusinessReturn
        'Instantiate variables
        linqBlogs = New linqBlogs

        'Obtain data
        Return linqBlogs.selectAllAuthors_NameIdOnly()
    End Function
    Public Function selectAllAuthors_WithinParent(ByVal id As Integer) As BusinessReturn
        'Instantiate variables
        linqBlogs = New linqBlogs

        'Obtain data
        Return linqBlogs.selectAllAuthors_WithinParent(id)
    End Function
#End Region

End Class