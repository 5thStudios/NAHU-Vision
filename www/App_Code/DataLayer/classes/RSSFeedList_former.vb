Imports System.Collections.Generic
Imports System.Xml.Serialization

Namespace DataLayer.RssFeed_itunes
    '================================================================================= RSS
    Partial Public Class rss
        Public Property channel() As New rssChannel
        '
        <XmlAttribute()>
        Public Property version() As String = String.Empty
        '
        <XmlAttribute(AttributeName:="atom", [Namespace]:="http://www.w3.org/2000/xmlns/")>
        Public Property atom() As String = String.Empty
    End Class


    '================================================================================= CHANNEL
    Partial Public Class rssChannel
        Public Property title() As String
        Public Property link() As String
        Public Property lastBuildDate() As String
        '
        <XmlElementAttribute("link", [Namespace]:="http://www.w3.org/2005/Atom")>
        Public Property atomLink() As rssChannelLink()
        '
        Public Property description() As String
        Public Property category() As String
        Public Property copyright() As String
        '
        <XmlElementAttribute("item")>
        Public Property lstChannelItems() As New List(Of rssChannelItem)
    End Class


    '================================================================================= LINK
    Partial Public Class rssChannelLink
        <XmlAttribute()>
        Public Property rel() As String = String.Empty
        '
        <XmlAttribute()>
        Public Property type() As String = String.Empty
        '
        <XmlAttribute()>
        Public Property href() As String = String.Empty
    End Class


    '================================================================================= ITEM
    Partial Public Class rssChannelItem
        Public Property title() As String
        '
        <XmlElementAttribute("category")>
        Public Property lstCategory() As New List(Of rssChannelItemCategory)
        '
        Public Property link() As String
        Public Property guid() As String
        Public Property description() As String
        Public Property pubDate() As String
    End Class


    '================================================================================= CATEGORY
    Partial Public Class rssChannelItemCategory
        <XmlAttribute()>
        Public Property domain() As String
        '
        <XmlTextAttribute()>
        Public Property Value() As String
    End Class

End Namespace