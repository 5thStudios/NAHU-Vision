Imports System.Web
Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports Umbraco
Imports Umbraco.NodeFactory
Imports Common
Imports Newtonsoft.Json
Imports System.Web.Script.Services
Imports System.Xml.Serialization
Imports System
Imports System.Collections.Generic
Imports System.IO
Imports Umbraco.Web
Imports Umbraco.Core.Models
Imports System.Net
Imports System.Xml
Imports System.Text



' To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line.
<System.Web.Script.Services.ScriptService()>
<WebService(Namespace:="http://tempuri.org/")>
<WebServiceBinding(ConformsTo:=WsiProfiles.BasicProfile1_1)>
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Public Class rssFeeds
    Inherits System.Web.Services.WebService


    <WebMethod()>
    Public Function podcastRssFeed() As String
        Try

            'Instantiate variables
            Dim rss As New DataLayer.RssFeed.Rss
            Dim channel As New DataLayer.RssFeed.Channel
            Dim uHelper As UmbracoHelper = New Umbraco.Web.UmbracoHelper(Umbraco.Web.UmbracoContext.Current)
            Dim ipPodcastList As IPublishedContent = uHelper.TypedContent(siteNodes.Podcasts)

            If Not IsNothing(ipPodcastList) Then
                'Build xml structure
                rss.Channel = channel

                'Add channel's root information
                With channel
                    If ipPodcastList.HasProperty(nodeProperties.xmlLink) Then .atomLink.Href = ipPodcastList.GetPropertyValue(Of String)(nodeProperties.xmlLink)
                    .atomLink.Rel = "self"
                    .atomLink.Type = "application/rss+xml"
                    If ipPodcastList.HasProperty(nodeProperties.copyright) Then .Copyright = ipPodcastList.GetPropertyValue(Of String)(nodeProperties.copyright)
                    If ipPodcastList.HasProperty(nodeProperties.description) Then .Description = ipPodcastList.GetPropertyValue(Of String)(nodeProperties.description)
                    If ipPodcastList.HasProperty(nodeProperties.languageCode) Then .Language = ipPodcastList.GetPropertyValue(Of String)(nodeProperties.languageCode)

                    .LastBuildDate = DateTime.Now.ToString("r")
                    .Link.Add(HttpContext.Current.Request.Url.GetLeftPart(UriPartial.Authority))

                    If ipPodcastList.HasProperty("managingEditor") Then .ManagingEditor = ipPodcastList.GetPropertyValue(Of String)(nodeProperties.managingEditor)

                    .PubDate = DateTime.Now.ToString("r") 'DateTime.Now.ToString("ddd, dd MMM yyyy HH:mm:ss zzz")
                    .Category.Text = "News &amp; Politics"

                    If ipPodcastList.HasProperty(nodeProperties.podcastTitle) Then .Title = ipPodcastList.GetPropertyValue(Of String)(nodeProperties.podcastTitle)
                    If ipPodcastList.HasProperty(nodeProperties.webmaster) Then .WebMaster = ipPodcastList.GetPropertyValue(Of String)(nodeProperties.webmaster)
                    If ipPodcastList.HasValue(nodeProperties.podcastImage) Then
                        Try
                            .Image.Url = getMediaURL(ipPodcastList.GetPropertyValue(Of IPublishedContent)(nodeProperties.podcastImage).Id, crops.Podcast, False, True)
                        Catch ex As Exception
                            .Image.Url = getMediaURL(ipPodcastList.GetPropertyValue(Of String)(nodeProperties.podcastImage), crops.Podcast, False, True)
                        End Try
                        .Image.Link = .Image.Url
                        .ItunesImg.Href = .Image.Url
                        .Image.Title = ipPodcastList.GetPropertyValue(Of String)(nodeProperties.podcastTitle)
                    End If

                    '
                    For Each ipPodcast In ipPodcastList.Children
                        If ipPodcast.HasProperty(nodeProperties.includeInRSSFeed) AndAlso ipPodcast.GetPropertyValue(Of Boolean)(nodeProperties.includeInRSSFeed) = True Then
                            'Instantiate new podcast item
                            Dim item As New DataLayer.RssFeed.Item
                            channel.lstItems.Add(item)

                            'Obtain podcast data
                            item.Author = "info@nahu.org"
                            If ipPodcast.HasProperty(nodeProperties.rssTitle) Then item.Title = ipPodcast.GetPropertyValue(Of String)(nodeProperties.rssTitle)
                            If ipPodcast.HasProperty(nodeProperties.rssDescription) Then item.Description = ipPodcast.GetPropertyValue(Of String)(nodeProperties.rssDescription)
                            If ipPodcast.HasValue(nodeProperties.podcastAudio) Then
                                item.Enclosure.Url = getMediaURL(ipPodcast.GetPropertyValue(Of IPublishedContent)(nodeProperties.podcastAudio).Id, String.Empty, True, True)
                                item.Guid = item.Enclosure.Url

                                item.Enclosure.Length = getMediaSize(ipPodcast.GetPropertyValue(Of String)(nodeProperties.podcastAudio))
                                item.Enclosure.Type = "audio/mpeg"
                                'item.CategoryU.Code = "116" 'http://sitemanager.itunes.apple.com/help/#itu337EEAE0-035A-4660-B53D-46A13A7721E5   'https://help.apple.com/itc/podcasts_connect/#/itc9267a2f12
                            End If
                            If ipPodcast.HasProperty(nodeProperties.publishDate) Then item.PubDate = ipPodcast.GetPropertyValue(Of Date)(nodeProperties.publishDate).ToString("r")
                        End If
                    Next
                End With

                'Convert to xml format
                Dim xmlSerializer As XmlSerializer = New XmlSerializer(rss.GetType)
                Dim xmlWriterSettings As XmlWriterSettings = New XmlWriterSettings() With {
                    .Encoding = Encoding.UTF8, 'New UnicodeEncoding(True, True),
                    .Indent = True,
                    .OmitXmlDeclaration = False,
                    .CloseOutput = True}

                Dim xmlWriter As XmlWriter = XmlWriter.Create(Server.MapPath("~/feeds/podcasts.xml"), xmlWriterSettings)
                xmlSerializer.Serialize(xmlWriter, rss)

                'Flush and cllose all components connected to the xml doc
                xmlWriter.Flush()
                xmlWriter.Close()
                xmlSerializer = Nothing
                xmlWriterSettings = Nothing

                ''Return xml from created file
                'Dim lines As String() = System.IO.File.ReadAllLines(Server.MapPath("~/feeds/podcasts.xml"))
                'Dim sb As New StringBuilder
                'For Each line As String In lines
                '    sb.AppendLine(line)
                'Next
                'Return sb.ToString

                Return Newtonsoft.Json.JsonConvert.SerializeObject(rss)



            Else
                'Save error to umbraco
                Dim sb As New StringBuilder
                sb.AppendLine("Common.vb | podcastRssFeed()")
                sb.AppendLine("ipPodcastList is Nothing???  Did folder id change?")

                Dim exc As Exception = New Exception(sb.ToString)
                SaveErrorMessage(exc, sb, Me.GetType())

                Return sb.ToString
            End If

        Catch ex As Exception
            'Save error to umbraco
            Dim sb As New StringBuilder
            sb.AppendLine("Common.vb | podcastRssFeed()")
            SaveErrorMessage(ex, sb, Me.GetType())
            Return sb.ToString
        End Try
    End Function

    <WebMethod()>
    Public Function podcastRssFeed_utf16() As String
        Try

            'Instantiate variables
            Dim rss As New DataLayer.RssFeed.Rss
            Dim channel As New DataLayer.RssFeed.Channel
            Dim uHelper As UmbracoHelper = New umbraco.Web.UmbracoHelper(umbraco.Web.UmbracoContext.Current)
            Dim ipPodcastList As IPublishedContent = uHelper.TypedContent(siteNodes.Podcasts)

            If Not IsNothing(ipPodcastList) Then
                'Build xml structure
                rss.Channel = channel

                'Add channel's root information
                With channel
                    If ipPodcastList.HasProperty(nodeProperties.xmlLink) Then .atomLink.Href = ipPodcastList.GetPropertyValue(Of String)(nodeProperties.xmlLink)
                    .atomLink.Rel = "self"
                    .atomLink.Type = "application/rss+xml"
                    If ipPodcastList.HasProperty(nodeProperties.copyright) Then .Copyright = ipPodcastList.GetPropertyValue(Of String)(nodeProperties.copyright)
                    If ipPodcastList.HasProperty(nodeProperties.description) Then .Description = ipPodcastList.GetPropertyValue(Of String)(nodeProperties.description)
                    If ipPodcastList.HasProperty(nodeProperties.languageCode) Then .Language = ipPodcastList.GetPropertyValue(Of String)(nodeProperties.languageCode)

                    .LastBuildDate = DateTime.Now.ToString("r")
                    .Link.Add(HttpContext.Current.Request.Url.GetLeftPart(UriPartial.Authority))

                    If ipPodcastList.HasProperty("managingEditor") Then .ManagingEditor = ipPodcastList.GetPropertyValue(Of String)(nodeProperties.managingEditor)

                    .PubDate = DateTime.Now.ToString("r")
                    .Category.Text = "News &amp; Politics"

                    If ipPodcastList.HasProperty(nodeProperties.podcastTitle) Then .Title = ipPodcastList.GetPropertyValue(Of String)(nodeProperties.podcastTitle)
                    If ipPodcastList.HasProperty(nodeProperties.webmaster) Then .WebMaster = ipPodcastList.GetPropertyValue(Of String)(nodeProperties.webmaster)
                    If ipPodcastList.HasValue(nodeProperties.podcastImage) Then
                        Try
                            .Image.Url = getMediaURL(ipPodcastList.GetPropertyValue(Of IPublishedContent)(nodeProperties.podcastImage).Id, crops.Podcast, False, True)
                        Catch ex As Exception
                            .Image.Url = getMediaURL(ipPodcastList.GetPropertyValue(Of String)(nodeProperties.podcastImage), crops.Podcast, False, True)
                        End Try
                        .Image.Link = .Image.Url
                        .ItunesImg.Href = .Image.Url
                        .Image.Title = ipPodcastList.GetPropertyValue(Of String)(nodeProperties.podcastTitle)
                    End If

                    '
                    For Each ipPodcast In ipPodcastList.Children
                        If ipPodcast.HasProperty(nodeProperties.includeInRSSFeed) AndAlso ipPodcast.GetPropertyValue(Of Boolean)(nodeProperties.includeInRSSFeed) = True Then
                            'Instantiate new podcast item
                            Dim item As New DataLayer.RssFeed.Item
                            channel.lstItems.Add(item)

                            'Obtain podcast data
                            If ipPodcast.HasProperty(nodeProperties.rssTitle) Then item.Title = ipPodcast.GetPropertyValue(Of String)(nodeProperties.rssTitle)
                            If ipPodcast.HasProperty(nodeProperties.rssDescription) Then item.Description = ipPodcast.GetPropertyValue(Of String)(nodeProperties.rssDescription)
                            If ipPodcast.HasValue(nodeProperties.podcastAudio) Then
                                item.Enclosure.Url = getMediaURL(ipPodcast.GetPropertyValue(Of IPublishedContent)(nodeProperties.podcastAudio).Id, String.Empty, True, True)
                                item.Guid = item.Enclosure.Url

                                item.Enclosure.Length = getMediaSize(ipPodcast.GetPropertyValue(Of String)(nodeProperties.podcastAudio))
                                item.Enclosure.Type = "audio/mpeg"
                                'item.CategoryU.Code = "116" 'https://help.apple.com/itc/podcasts_connect/#/itc9267a2f12
                            End If
                            If ipPodcast.HasProperty(nodeProperties.publishDate) Then item.PubDate = ipPodcast.GetPropertyValue(Of Date)(nodeProperties.publishDate).ToString("r")
                        End If
                    Next
                End With

                'Convert to xml format
                Dim serializer As XmlSerializer = New XmlSerializer(rss.GetType)
                Dim settings As XmlWriterSettings = New XmlWriterSettings() With {
                    .Encoding = New UnicodeEncoding(False, False),
                    .Indent = True,
                    .OmitXmlDeclaration = False,
                    .CloseOutput = True}

                Dim xmlWriter As XmlWriter = XmlWriter.Create(Server.MapPath("~/feeds/podcasts_utf16.xml"), settings)
                serializer.Serialize(xmlWriter, rss)

                'Flush and cllose all components connected to the xml doc
                xmlWriter.Flush()
                xmlWriter.Close()
                serializer = Nothing
                settings = Nothing

                ''Return xml from created file
                'Dim lines As String() = System.IO.File.ReadAllLines(Server.MapPath("~/feeds/podcasts_utf16.xml"))
                'Dim sb As New StringBuilder
                'For Each line As String In lines
                '    sb.AppendLine(line)
                'Next
                'Return sb.ToString

                Return Newtonsoft.Json.JsonConvert.SerializeObject(rss)

            Else
                'Save error to umbraco
                Dim sb As New StringBuilder
                sb.AppendLine("Common.vb | podcastRssFeed()")
                sb.AppendLine("ipPodcastList is Nothing???  Did folder id change?")

                Dim exc As Exception = New Exception(sb.ToString)
                SaveErrorMessage(exc, sb, Me.GetType())

                Return sb.ToString
            End If

        Catch ex As Exception
            'Save error to umbraco
            Dim sb As New StringBuilder
            sb.AppendLine("Common.vb | podcastRssFeed()")
            sb.AppendLine(ex.ToString)
            SaveErrorMessage(ex, sb, Me.GetType())
            Return sb.ToString
        End Try
    End Function

End Class



''EXAMPLE OF RSS FEED
''=====================================
'<rss xmlns : atom = "http://www.w3.org/2005/Atom" xmlns:itunes = "http://www.itunes.com/dtds/podcast-1.0.dtd" xmlns:itunesu = "http://www.itunesu.com/feed" version="2.0">
'  <channel>
'    <link>http : //www.osu.edu</link>
'    <language>en-us</language>
'    <copyright>©2018</copyright>
'    <webMaster>MediaServices@osu.edu (Media Services)</webMaster>
'    <managingEditor>MediaServices@osu.edu (Media Services)</managingEditor>    
'    <atom:link href = "http://streaming.osu.edu/podcast/Example/podcast.xml" rel="self" type="application/rss+xml"/>
'    <pubDate>Fri, 18 May 2012 00:00:00 EST</pubDate>
'    <title>Example Podcast RSS XML Code</title>
'    <description>Example RSS 2.0 code For a XML 1.0 podcast including iTunes proprietary tags.</description>
'    <lastBuildDate>Fri, 18 May 2012 00:00:00 EST</lastBuildDate>

'    <image>
'      <url>http : //streaming.osu.edu/podcast/iTunesU/Images/Icons/Generic_OSU.jpg</url>
'      <title>The Ohio State University</title>
'      <link>http : //www.osu.edu</link>
'    </image>
'    <itunes:Image href = "http://streaming.osu.edu/podcast/iTunesU/Images/Icons/Generic_OSU.jpg" />

'    <item>
'      <title>Example Podcast Episode</title>
'      <description>Example MP3 podcast item including iTunes proprietary tags.</description>
'      <itunesu:category itunesu: code = "112" />
'      <enclosure url="https://nahu.org/media/2056/wu_091517_final.mp3" type="audio/mpeg" length="1"/>
'      <guid>https : //nahu.org/media/2056/wu_091517_final.mp3</guid>
'      <pubDate>Fri, 18 May 2012 00:00:00 EST</pubDate>
'    </item>
'  </channel>
'</rss>

'Private Shared Function GetMp3Duration(filename As String) As Double
'    Dim file = System.IO.File.OpenRead("D:\W\16-NATASHU-0457\mvcvb\mvcvb-v4\Media\2134\podcast01.mp3")
'    Dim reader As New Mp3FileReader(file)
'    Dim duration As Double = reader.TotalTime.TotalSeconds
'    reader.Dispose()
'    Return duration
'End Function




