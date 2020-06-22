Imports Microsoft.VisualBasic
Imports System
Imports System.Xml.Serialization
Imports System.Collections.Generic


Namespace DataLayer.RssFeed
    '====================================================================================================
    '--------------------------------------------------------------------------------- RSS
    <XmlRoot(ElementName:="rss")>
    Public Class Rss

        <XmlElement(ElementName:="channel")>
        Public Property Channel As Channel

        <XmlAttribute(AttributeName:="atom", [Namespace]:="http://www.w3.org/2000/xmlns/")>
        Public Property Atom As String = "http://www.w3.org/2005/Atom"

        <XmlAttribute(AttributeName:="itunes", [Namespace]:="http://www.w3.org/2000/xmlns/")>
        Public Property Itunes As String = "http://www.itunes.com/dtds/podcast-1.0.dtd"

        '<XmlAttribute(AttributeName:="itunesu", [Namespace]:="http://www.w3.org/2000/xmlns/")>
        'Public Property Itunesu As String = "http://www.itunesu.com/feed"

        <XmlAttribute(AttributeName:="version")>
        Public Property Version As String = "2.0"
    End Class
    '----------------------------------------------------------------------------------------------------
    '====================================================================================================





    '====================================================================================================
    '--------------------------------------------------------------------------------- CHANNEL
    <XmlRoot(ElementName:="channel")>
    Public Class Channel

        <XmlElement(ElementName:="link")>
        Public Property Link As New List(Of String)

        <XmlElement(ElementName:="language")>
        Public Property Language As String

        <XmlElement(ElementName:="copyright")>
        Public Property Copyright As String

        <XmlElement(ElementName:="webMaster")>
        Public Property WebMaster As String

        <XmlElement(ElementName:="managingEditor")>
        Public Property ManagingEditor As String

        <XmlElementAttribute("link", [Namespace]:="http://www.w3.org/2005/Atom")>
        Public Property atomLink As New Link

        <XmlElement(ElementName:="image")>
        Public Property Image As New Image

        <XmlElement(ElementName:="image", [Namespace]:="http://www.itunes.com/dtds/podcast-1.0.dtd")>
        Public Property ItunesImg As New ItunesImg

        <XmlElement(ElementName:="category", [Namespace]:="http://www.itunes.com/dtds/podcast-1.0.dtd")>
        Public Property Category As New Category

        <XmlElement(ElementName:="pubDate")>
        Public Property PubDate As String

        <XmlElement(ElementName:="title")>
        Public Property Title As String

        <XmlElement(ElementName:="description")>
        Public Property Description As String

        <XmlElement(ElementName:="lastBuildDate")>
        Public Property LastBuildDate As String

        <XmlElement(ElementName:="explicit", [Namespace]:="http://www.itunes.com/dtds/podcast-1.0.dtd")>
        Public Property Explicit As String = "No"

        <XmlElement(ElementName:="author", [Namespace]:="http://www.itunes.com/dtds/podcast-1.0.dtd")>
        Public Property Author As String = "info@nahu.org"

        <XmlElement(ElementName:="item")>
        Public Property lstItems As New List(Of Item)
    End Class
    '----------------------------------------------------------------------------------------------------
    '====================================================================================================





    '====================================================================================================
    '--------------------------------------------------------------------------------- CATEGORY
    <XmlRoot(ElementName:="category", [Namespace]:="http://www.itunes.com/dtds/podcast-1.0.dtd")>
    Public Class Category

        <XmlAttribute(AttributeName:="text")>
        Public Property Text As String
    End Class
    '----------------------------------------------------------------------------------------------------
    '====================================================================================================





    '====================================================================================================
    '--------------------------------------------------------------------------------- IMAGE
    <XmlRoot(ElementName:="image")>
    Public Class Image

        <XmlElement(ElementName:="url")>
        Public Property Url As String

        <XmlElement(ElementName:="title")>
        Public Property Title As String

        <XmlElement(ElementName:="link")>
        Public Property Link As String
    End Class
    '----------------------------------------------------------------------------------------------------
    '====================================================================================================





    '====================================================================================================
    '--------------------------------------------------------------------------------- IMAGE-ITUNES
    <XmlRoot(ElementName:="image", [Namespace]:="http://www.itunes.com/dtds/podcast-1.0.dtd")>
    Public Class ItunesImg

        <XmlAttribute(AttributeName:="href")>
        Public Property Href As String
    End Class
    '----------------------------------------------------------------------------------------------------
    '====================================================================================================





    '====================================================================================================
    '--------------------------------------------------------------------------------- LINK
    <XmlRoot(ElementName:="link", [Namespace]:="http://www.w3.org/2005/Atom")>
    Public Class Link

        <XmlAttribute(AttributeName:="href")>
        Public Property Href As String

        <XmlAttribute(AttributeName:="rel")>
        Public Property Rel As String

        <XmlAttribute(AttributeName:="type")>
        Public Property Type As String
    End Class
    '----------------------------------------------------------------------------------------------------
    '====================================================================================================





    '====================================================================================================
    '--------------------------------------------------------------------------------- ITEM
    <XmlRoot(ElementName:="item")>
    Public Class Item

        <XmlElement(ElementName:="title")>
        Public Property Title As String

        <XmlElement(ElementName:="author")>
        Public Property Author As String

        <XmlElement(ElementName:="description")>
        Public Property Description As String

        '<XmlElement(ElementName:="category", [Namespace]:="http://www.itunesu.com/feed")>
        'Public Property CategoryU As New CategoryU

        <XmlElement(ElementName:="enclosure")>
        Public Property Enclosure As New Enclosure

        <XmlElement(ElementName:="guid")>
        Public Property Guid As String

        <XmlElement(ElementName:="pubDate")>
        Public Property PubDate As String
    End Class
    '----------------------------------------------------------------------------------------------------
    '====================================================================================================





    '====================================================================================================
    '--------------------------------------------------------------------------------- ENCLOSURE
    <XmlRoot(ElementName:="enclosure")>
    Public Class Enclosure

        <XmlAttribute(AttributeName:="url")>
        Public Property Url As String

        <XmlAttribute(AttributeName:="type")>
        Public Property Type As String

        <XmlAttribute(AttributeName:="length")>
        Public Property Length As String
    End Class
    '----------------------------------------------------------------------------------------------------
    '====================================================================================================

End Namespace









'====================================================================================================
'--------------------------------------------------------------------------------- CATEGORY - U
'<XmlRoot(ElementName:="category", [Namespace]:="http://www.itunesu.com/feed")>
'Public Class CategoryU

'    <XmlAttribute(AttributeName:="code", [Namespace]:="http://www.itunesu.com/feed")>
'    Public Property Code As String
'End Class
'<XmlRoot(ElementName:="category", [Namespace]:="http://www.itunesu.com/feed")>
'Public Class Category

'    <XmlAttribute(AttributeName:="code", [Namespace]:="http://www.itunesu.com/feed")>
'    Public Property Code As String
'End Class
'----------------------------------------------------------------------------------------------------
'====================================================================================================