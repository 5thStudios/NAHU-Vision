Imports umbraco.NodeFactory
Imports umbraco.Core
Imports umbraco.Web
Imports umbraco.Web.Extensions
Imports umbraco.Core.Services
Imports umbraco.Core.Models
Imports System.Xml.XPath
Imports umbraco
Imports System.Net
Imports Newtonsoft.Json
Imports System.Web.Hosting
Imports System.Diagnostics
Imports umbraco.Core.Logging

Imports Examine
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text

Public Class Common

#Region "Properties"
    Public Enum siteNodes
        Authors = 1330
        ChapterAffiliation = 2548
        'CreditCard = 33050
        EducationFoundation = 1890
        Events = 1078
        EventTypes = 2547
        Home = 1075
        HUPAC = 1907
        InTheNews = 1329
        JoinNow = 1135
        MemberBenefits = 1177
        'Podcasts = 33015   'DEV
        Podcasts = 42712    'LIVE
        PressReleases = 1451
        root = -1
        Search = 1133 'hupac 43107      www 1133    ef 43494
        Search_Hupac = 43107
        Search_EF = 43494
        'SiteErrors = 1426
        Tags = 1332
    End Enum
    Public Enum doctypeNodes
        TextAlignment = 1348
        DropShadow = 16636
    End Enum
    Public Structure DropShadows
        Const none As String = "None"
        Const darkDropShadow As String = "Dark Drop Shadow"
    End Structure
    Public Structure nodeProperties
        Const address1 As String = "address1"
        Const address2 As String = "address2"
        Const administratorNotes As String = "administratorNotes"
        Const allowInSideNav As String = "allowInSideNav"
        Const answer As String = "answer"
        Const articleCount As String = "articleCount"
        Const articleLists As String = "articleLists"
        Const author As String = "author"

        Const b2BFollowUSURL As String = "b2BFollowUSURL"
        Const backgroundImage As String = "backgroundImage"
        Const bl_backgroundImage As String = "bl_backgroundImage"
        Const bl_callToActionLink As String = "bl_callToActionLink"
        Const bl_callToActionText As String = "bl_callToActionText"
        Const bl_icon As String = "bl_icon"
        Const bl_quicklinkSubtitle As String = "bl_quicklinkSubtitle"
        Const bl_quicklinkTitle As String = "bl_quicklinkTitle"
        Const bl_sublinks As String = "bl_sublinks"
        Const bl_subtitle As String = "bl_subtitle"
        Const bl_textAlignment As String = "bl_textAlignment"
        Const bl_title As String = "bl_title"
        Const bn_Content As String = "bn_Content"
        Const bn_Link As String = "bn_Link"
        Const bodyText As String = "bodyText"

        Const callToActionLink As String = "callToActionLink"
        Const callToActionText As String = "callToActionText"
        Const categories As String = "categories"
        Const city As String = "city"
        Const chapterAffiliation As String = "chapterAffiliation"
        Const classroomContent As String = "classroomContent"
        Const classroomCosts As String = "classroomCosts"
        Const classroomFormat As String = "classroomFormat"
        Const classroomInstructors As String = "classroomInstructors"
        Const commonContent As String = "commonContent"
        Const contactInfo As String = "contactInfo"
        Const contactMembers As String = "contactMembers"
        Const content As String = "content"
        Const copyright As String = "copyright"
        Const courseHighlights As String = "courseHighlights"
        Const cp_BackgroundImage1 As String = "cp_BackgroundImage1"
        Const cp_BackgroundImage2 As String = "cp_BackgroundImage2"
        Const cp_BackgroundImage3 As String = "cp_BackgroundImage3"
        Const cp_Description1 As String = "cp_Description1"
        Const cp_Description2 As String = "cp_Description2"
        Const cp_Description3 As String = "cp_Description3"
        Const cp_Quicklink1 As String = "cp_Quicklink1"
        Const cp_Quicklink2 As String = "cp_Quicklink2"
        Const cp_Quicklink3 As String = "cp_Quicklink3"
        Const cp_QuicklinkTitle1 As String = "cp_QuicklinkTitle1"
        Const cp_QuicklinkTitle2 As String = "cp_QuicklinkTitle2"
        Const cp_QuicklinkTitle3 As String = "cp_QuicklinkTitle3"
        Const cp_Title1 As String = "cp_Title1"
        Const cp_Title2 As String = "cp_Title2"
        Const cp_Title3 As String = "cp_Title3"
        Const ctap_backgroundImage As String = "ctap_backgroundImage"
        Const ctap_callToActionLink As String = "ctap_callToActionLink"
        Const ctap_callToActionText As String = "ctap_callToActionText"
        Const ctap_content As String = "ctap_content"
        Const ctap_imageOnRight As String = "ctap_imageOnRight"
        Const ctap_textAlignment As String = "ctap_textAlignment"
        Const ctap_title As String = "ctap_title"

        Const description As String = "description"
        Const disableLogin As String = "disableLogin"
        Const dropShadow As String = "dropShadow"

        Const email As String = "email"
        Const eventDate As String = "eventDate"
        Const eventTimeframe As String = "eventTimeframe"
        Const eventType As String = "eventType"
        Const exceptionMessage As String = "exceptionMessage"
        Const externalUrl As String = "externalUrl"

        Const facebookFollowUSURL As String = "facebookFollowUSURL"
        Const featuredImage As String = "featuredImage"
        Const featuredItem As String = "featuredItem"
        'Const featuredNewsArticle As String = "featuredNewsArticle"
        Const featuredOptions As String = "featuredOptions"
        Const featuredVideo As String = "featuredVideo"
        Const firstName As String = "firstName"
        Const formContainer As String = "formContainer"
        Const FullLoginResponse As String = "FullLoginResponse"

        Const generalMessage As String = "generalMessage"

        Const haveQuestions As String = "haveQuestions"

        Const icon As String = "icon"
        Const includeInRSSFeed As String = "includeInRSSFeed"
        Const instructorName As String = "instructorName"
        Const instructors As String = "instructors"
        Const isATrustee As String = "isATrustee"

        Const joinNowLink As String = "joinNowLink"

        Const languageCode As String = "languageCode"
        Const lastName As String = "lastName"
        Const link As String = "link"
        Const linkedInFollowUSURL As String = "linkedInFollowUSURL"
        Const linkTo As String = "linkTo"
        Const locationName As String = "locationName"
        Const lockedShortDescription As String = "lockedShortDescription"
        Const Login As String = "Login"

        Const managingEditor As String = "managingEditor"
        Const memberBenefits As String = "memberBenefits"
        Const metaDescription As String = "metaDescription"
        Const metaKeywords As String = "metaKeywords"

        Const navigationTitle As String = "navigationTitle"
        Const news_showAd As String = "news_showAd"
        Const nodeName As String = "nodeName"

        Const onlineContent As String = "onlineContent"
        Const onlineCosts As String = "onlineCosts"
        Const onlineFormat As String = "onlineFormat"
        Const onlineInstructors As String = "onlineInstructors"
        Const openInNewTab As String = "openInNewTab"

        Const pageTitle As String = "pageTitle"
        Const pDFDocument As String = "pDFDocument"
        Const phone As String = "phone"
        Const phoneExtension As String = "phoneExtension"
        Const phoneNumber As String = "phoneNumber"
        Const photo As String = "photo"
        Const podcastAudio As String = "podcastAudio"
        Const podcastImage As String = "podcastImage"
        Const podcastTitle As String = "podcastTitle"
        Const postDate As String = "postDate"
        Const publishDate As String = "publishDate"

        Const qb_backgroundImage As String = "qb_backgroundImage"
        Const qb_callToActionLink As String = "qb_callToActionLink"
        Const qb_callToActionText As String = "qb_callToActionText"
        Const qb_subtitle As String = "qb_subtitle"
        Const qb_dropShadow As String = "qb_dropShadow"
        Const qb_textAlignment As String = "qb_textAlignment"
        Const qb_title As String = "qb_title"
        Const qlp_quicklinks As String = "qlp_quicklinks"
        Const question As String = "question"
        Const quicklinks As String = "quicklinks"
        Const qwn_author As String = "qwn_author"
        Const qwn_backgroundImage As String = "qwn_backgroundImage"
        Const qwn_quote As String = "qwn_quote"
        Const qwn_sideNav As String = "qwn_sideNav"
        Const qwn_textAlignment As String = "qwn_textAlignment"

        Const registerUrl As String = "registerUrl"
        Const renewMembershipLink As String = "renewMembershipLink"
        Const rotatingBanners As String = "rotatingBanners"
        Const rssDescription As String = "rssDescription"
        Const rssTitle As String = "rssTitle"

        Const SaveErrorMessage As String = "saveErrorMessage"
        Const sb_backgroundImage As String = "sb_backgroundImage"
        Const sb_subtitle As String = "sb_subtitle"
        Const sb_title As String = "sb_title"
        Const search As String = "search"
        Const searchEngineSitemapChangeFrequency As String = "searchEngineSitemapChangeFrequency"
        Const searchEngineSitemapPriority As String = "searchEngineSitemapPriority"
        Const SessionGuid As String = "SessionGuid"
        Const showClassroomContent As String = "showClassroomContent"
        Const showInEyebrowNavigation As String = "showInEyebrowNavigation"
        Const showInMegamenu As String = "showInMegamenu"
        Const shortDescription As String = "shortDescription"
        Const showInNavigation As String = "showInNavigation"
        Const showOnlineContent As String = "showOnlineContent"
        Const siteClass As String = "siteClass"
        Const siteLogo As String = "siteLogo"
        Const sortOrder As String = "sortOrder"
        Const sponsorLogo As String = "sponsorLogo"
        Const sponsors As String = "sponsors"
        Const sponsorUrl As String = "sponsorUrl"
        Const state As String = "state"
        Const subtitle As String = "subtitle"
        Const summary As String = "summary"

        Const tag As String = "tag"
        Const tags As String = "tags"
        Const tb_content As String = "tb_content"
        Const tb_showAd As String = "tb_showAd"
        Const tb_showSideNavigation As String = "tb_showSideNavigation"
        Const tb_SideOnRight As String = "tb_SideOnRight"
        Const timeframe As String = "timeframe"
        Const title As String = "title"
        Const topNews As String = "topNews"
        Const trusteeId As String = "trusteeId"
        Const trusteeName As String = "trusteeName"
        Const twitterFollowUSURL As String = "twitterFollowUSURL"

        Const upcomingEvents As String = "upcomingEvents"
        Const useNativeDimensions As String = "useNativeDimensions"

        Const vimeoImageId As String = "vimeoImageId"

        Const webAddress As String = "webAddress"
        Const webmaster As String = "webmaster"
        Const widescreenVideo As String = "widescreenVideo"

        Const xmlLink As String = "xmlLink"

        Const youTubeFollowUSURL As String = "youTubeFollowUSURL"

        Const zip As String = "zip"
    End Structure
    Public Structure aliases
        Const appStartEvents As String = "appStartEvents"
        Const author As String = "author"
        Const authors As String = "authors"
        Const bannerlink As String = "bannerlink"
        Const banner As String = "banner"
        Const blogEntry As String = "blogEntry"
        Const blogHome As String = "blogHome"
        Const blogList As String = "blogList"
        Const boardTemplate As String = "boardTemplate"
        Const calendarListNew As String = "calendarListNew"
        Const callToActionPanel As String = "callToActionPanel"
        Const certification As String = "certification"
        Const certificationList As String = "certificationList"
        Const chapter As String = "chapter"
        Const chapterAffiliation As String = "chapterAffiliation"
        Const contributions As String = "contributions"
        Const contributionsBank As String = "contributionsBank"
        Const corrected As String = "corrected"
        Const customPanels As String = "customPanels"
        Const dataLayer As String = "dataLayer"
        'Const errorMessage As String = "errorMessage"
        'Const errors As String = "errors"
        Const errors As String = "errors"
        Const errorMessage As String = "errorMessage"
        Const eventType As String = "eventType"
        Const eventCalendar As String = "eventCalendar"
        Const events As String = "events"
        Const eventTypes As String = "eventTypes"
        Const externalBannerlink As String = "externalBannerlink"
        Const externalLink As String = "externalLink"
        Const externalQuicklink As String = "externalQuicklink"
        Const faq As String = "faq"
        Const form As String = "form"
        Const formContainer As String = "formContainer"
        Const genericList As String = "genericList"
        Const home As String = "home"
        Const homeMicrosite As String = "homeMicrosite"
        Const ignore As String = "ignore"
        Const instructor As String = "instructor"
        Const instructorList As String = "instructorList"
        Const internalBannerlink As String = "internalBannerlink"
        Const internalLink As String = "internalLink"
        Const internalQuicklink As String = "internalQuicklink"
        Const largeBanner As String = "largeBanner"
        Const listBlogBoardOfTrustees As String = "listBlogBoardOfTrustees"
        Const listItem As String = "listItem"
        Const listSearch As String = "listSearch"
        Const lockedBlogEntry As String = "lockedBlogEntry"
        Const lockedPdfEntry As String = "lockedPdfEntry"
        Const microsite As String = "microsite"
        Const pdfEntry As String = "pdfEntry"
        Const pdfItem As String = "pdfItem"
        Const podcast As String = "podcast"
        Const podcastList As String = "podcastList"
        Const promotionPanel As String = "promotionPanel"
        Const quicklinkPanels As String = "quicklinkPanels"
        Const quicklinks As String = "quicklinks"
        Const quoteBanner As String = "quoteBanner"
        Const quoteBannerWithNav As String = "quoteBannerWithNav"
        Const recurringEvent As String = "recurringEvent"
        Const recurringEvents As String = "recurringEvents"
        Const rotatingBanners As String = "rotatingBanners"
        Const seo As String = "seo"
        Const singleEvent As String = "singleEvent"
        Const singleEvents As String = "singleEvents"
        Const sponsor As String = "sponsor"
        Const sponsors As String = "sponsors"
        Const standard As String = "standard"
        Const standardLocked As String = "standardLocked"
        Const standardLayout As String = "standardLayout"
        Const standardLayoutLocked As String = "standardLayoutLocked"
        Const tag As String = "tag"
        Const tags As String = "tags"
        Const template01 As String = "template01"
        Const template02 As String = "template02"
        Const template02Locked As String = "template02Locked"
        Const template03 As String = "template03"
        Const textBlock As String = "textBlock"
        Const textBlockLocked As String = "textBlockLocked"
        Const toAddress As String = "toAddress"
        Const trustee As String = "trustee"
        Const trusteeList As String = "trusteeList"
        Const urlEntry As String = "urlEntry"
    End Structure
    Public Enum calendars
        Events = 1078
    End Enum
    Public Enum recurrence
        none = 1
        daily = 2
        weekly = 3
        monthly = 4
        yearly = 5
    End Enum
    Public Enum singleEventArray
        allDayEvent
        fromHour
        fromMinute
        toHour
        toMinute
    End Enum
    Public Structure crops
        Const FullBanner As String = "FullBanner" '=============================================1800x750
        Const NarrowBanner As String = "NarrowBanner" '=========================================1800x425
        Const Podcast As String = "Podcast" '===============================1400x1400
        Const BlogFeaturedImage As String = "BlogFeaturedImage" '===============================1150x650
        Const Quicklink As String = "Quicklink" '===============================================900x300
        Const NewsPanelFeatured As String = "NewsPanelFeatured" '===============================600x500
        Const SponsorLogo As String = "SponsorLogo" '===========================================500x125
        Const SideImage As String = "SideImage" '===============================================400x300

        Const CustomPanelSquared As String = "CustomPanelSquared" '=============================600x600
        Const ListItemSquared As String = "ListItemSquared" '===================================400x400
        Const NewsPanelSquared As String = "NewsPanelSquared" '=================================140x140
        Const InstructorSquared As String = "InstructorSquared" '===============================100x100
    End Structure
    Public Structure featuredOptions
        Const featuredImage As String = "Featured Image"
        Const youtubeVideo As String = "Youtube Video"
        Const vimeoVideo As String = "Vimeo Video"
        Const none As String = "none"
    End Structure
    Public Structure miscellaneous
        Const bankDonationUrl As String = "bankDonationUrl"
        Const widescreen As String = "widescreen"
        Const vimeoPlayer As String = "//player.vimeo.com/video/[ID]"
        Const youtubePlayer As String = "//www.youtube.com/embed/[ID]"
        Const httpsRedirect As String = "httpsRedirect"
        Const httpsRedirect_EF As String = "httpsRedirect_EF"
        Const httpsRedirect_HUPAC As String = "httpsRedirect_HUPAC"
        'Const saveErrorMsgs As String = "saveErrorMsgs"
        Const validBMember As String = "validBMember"
        Const boardMemberId As String = "boardMemberId"
        Const boardMemberPw As String = "boardMemberPw"
        Const proxyId As String = "proxyId"
        Const proxyPw As String = "proxyPw"
        Const rssFeed As String = "/feeds/podcasts.xml"
    End Structure
    'Public Structure searchIndex
    '    Const BlogSearcher As String = "BlogSearcher"
    '    Const ExternalSearcher As String = "ExternalSearcher"
    '    Const InternalMemberSearcher As String = "InternalMemberSearcher"
    '    Const InternalSearcher As String = "InternalSearcher"
    '    Const NavigationSearcher As String = "NavigationSearcher"
    'End Structure
#End Region

#Region "Methods"
    Public Shared Function getMediaURL(ByVal _mediaId As String, Optional ByVal sCropAlias As String = "", Optional ByVal useNative As Boolean = False, Optional getFullUrl As Boolean = False) As String
        'Instantiate variables
        Dim MediaURL As String = String.Empty
        Dim mediaId As Integer?

        Try
            If Not (ApplicationContext.Current Is Nothing) Then
                'Obtain media Id
                mediaId = getIdFromGuid_byType(_mediaId, UmbracoObjectTypes.Media)

                If Not IsNothing(mediaId) Then
                    '
                    Dim UmbracoHelper = New umbraco.Web.UmbracoHelper(umbraco.Web.UmbracoContext.Current)

                    Dim mediaNode = UmbracoHelper.TypedMedia(mediaId)
                    '
                    If useNative Then
                        'get regular image url without parameters
                        If getFullUrl Then
                            MediaURL = HttpContext.Current.Request.Url.GetLeftPart(UriPartial.Authority) & mediaNode.Url
                        Else
                            MediaURL = mediaNode.Url
                        End If

                    ElseIf sCropAlias <> "" Then
                        'get cropped version of image
                        If getFullUrl Then
                            MediaURL = HttpContext.Current.Request.Url.GetLeftPart(UriPartial.Authority) & mediaNode.GetCropUrl(sCropAlias) & "&quality=60&cacheBuster=false"
                        Else
                            MediaURL = mediaNode.GetCropUrl(sCropAlias) & "&quality=60&cacheBuster=false"
                        End If

                    Else
                        'get regular image url
                        If getFullUrl Then
                            MediaURL = HttpContext.Current.Request.Url.GetLeftPart(UriPartial.Authority) & mediaNode.Url & "?quality=60&cacheBuster=false"
                        Else
                            MediaURL = mediaNode.Url & "?quality=60&cacheBuster=false"
                        End If
                    End If
                End If
            End If
        Catch ex As Exception
            'Save error to umbraco
            Dim sb As New StringBuilder
            sb.AppendLine("Common.vb | getMediaURL()")
            sb.AppendLine("_mediaId: " & _mediaId)
            sb.AppendLine("mediaId: " & mediaId)
            sb.AppendLine("sCropAlias: " & sCropAlias)
            sb.AppendLine("StackTrace: " & ex.StackTrace)
            SaveErrorMessage(ex, sb, GetType(Common))

            MediaURL = String.Empty
        End Try

        'Return url
        Return MediaURL
    End Function
    Public Shared Function getMediaName(ByVal _mediaId As String) As String
        'Instantiate variables
        Dim mediaURL As String = String.Empty
        Dim mediaName As String = String.Empty

        Try
            If Not (ApplicationContext.Current Is Nothing) Then


                'Obtain media Id
                Dim mediaId As Integer? = getIdFromGuid_byType(_mediaId, UmbracoObjectTypes.Media)

                If Not IsNothing(mediaId) Then
                    'Obtain Image Url
                    Dim mediaObject = ApplicationContext.Current.Services.MediaService.GetById(mediaId)
                    mediaName = mediaObject.Name
                    'Remove file type from string
                    mediaName = mediaName.Split(".")(0)
                    'remove underscores and hyphens from string
                    mediaName = mediaName.Replace("_", " ").Replace("-", " ")
                End If
            End If
        Catch ex As Exception
            'Save error to umbraco
            Dim sb As New StringBuilder
            sb.AppendLine("Common.vb | getMediaName()")
            sb.AppendLine("_mediaId: " & _mediaId)
            SaveErrorMessage(ex, sb, GetType(Common))

            mediaName = String.Empty
        End Try

        'Return url
        Return mediaName
    End Function
    Public Shared Function getMediaSize(ByVal _mediaId As String) As String
        'Instantiate variables
        Dim mediaSize As String = String.Empty
        Dim mediaId As Integer?

        Try
            If Not (ApplicationContext.Current Is Nothing) Then
                'Obtain media Id
                mediaId = getIdFromGuid_byType(_mediaId, UmbracoObjectTypes.Media)

                If Not IsNothing(mediaId) Then
                    Dim UmbracoHelper = New umbraco.Web.UmbracoHelper(umbraco.Web.UmbracoContext.Current)
                    Dim mediaNode = UmbracoHelper.TypedMedia(mediaId)
                    mediaSize = mediaNode.GetPropertyValue(Of String)("umbracoBytes")
                End If
            End If
        Catch ex As Exception
            'Save error to umbraco
            Dim sb As New StringBuilder
            sb.AppendLine("Common.vb | getMediaURL()")
            sb.AppendLine("mediaId: " & mediaId)
            sb.AppendLine("StackTrace: " & ex.StackTrace)
            SaveErrorMessage(ex, sb, GetType(Common))

            mediaSize = 0
        End Try

        'Return path
        Return mediaSize
    End Function
    Public Shared Function getNode(ByVal _id As String) As Node
        'Instantiate variables
        Dim varUdi As Udi

        'Attempt to obtain the node id from the provided guid
        If Udi.TryParse(_id, varUdi) Then
            Dim guid = GuidUdi.Parse(varUdi.ToString())
            Dim entityService As IEntityService = ApplicationContext.Current.Services.EntityService

            Dim response As Attempt(Of Integer) = entityService.GetIdForKey(guid.Guid, UmbracoObjectTypes.Document)
            If response.Success Then
                Return New Node(response.Result)
            End If
        ElseIf IsNumeric(_id) Then
            'Is already an integer.  return value.
            Return New Node(_id)
        Else
            'If no integer was returned, return nothing
            Return Nothing
        End If
    End Function
    Public Shared Function getIdFromGuid_byType(ByVal _id As String, ByVal _objectType As UmbracoObjectTypes) As Integer?
        'Instantiate variables
        Dim varUdi As Udi

        'Attempt to obtain the node id from the provided id or guid
        If IsNumeric(_id) Then
            'Is already an integer.  return value.
            Return CInt(_id)
        ElseIf Udi.TryParse(_id, varUdi) Then
            Dim guid = GuidUdi.Parse(varUdi.ToString())
            Dim entityService As IEntityService = ApplicationContext.Current.Services.EntityService
            Dim response As Attempt(Of Integer) = entityService.GetIdForKey(guid.Guid, _objectType)

            If response.Success Then
                Return response.Result
            End If
        Else
            'If no integer was returned, return nothing
            Return Nothing
        End If
    End Function
    Public Shared Function getTextAlignment(ByVal _textAlignment As String) As HorizontalAlign
        'Obtain dictionary list from doctype
        Dim dictTextAlignment As Dictionary(Of String, String) = getDatatype_radioBtnLst(doctypeNodes.TextAlignment)

        'Obtain alignment
        Dim value As String = String.Empty
        If (dictTextAlignment.TryGetValue(_textAlignment, value)) Then
            Select Case value
                Case "Flush Left"
                    Return HorizontalAlign.Left
                Case "Centered"
                    Return HorizontalAlign.Center
                Case "Flush Right"
                    Return HorizontalAlign.Right
                Case Else
                    Return HorizontalAlign.NotSet
            End Select
        Else
            Return HorizontalAlign.NotSet
        End If
    End Function
    Public Shared Function getdropShadowClass(ByVal _dropShadow As String) As String
        If String.IsNullOrWhiteSpace(_dropShadow.Trim) Then
            Return String.Empty

        ElseIf _dropShadow.Trim = DropShadows.none Then
            Return String.Empty

        Else
            Return _dropShadow.Trim.ToFirstLowerInvariant.Replace(" ", "")
        End If
    End Function
    Private Shared Function getDatatype_radioBtnLst(ByVal _datatypeId As Integer) As Dictionary(Of String, String)
        'Instantiate variables
        Dim dtList As XPathNodeIterator
        Dim dtItem As XPathNodeIterator
        Dim dict As New Dictionary(Of String, String)

        'Get datatype and move to first data position
        dtList = umbraco.library.GetPreValues(_datatypeId)
        dtList.MoveNext() 'move to first
        dtItem = dtList.Current.SelectChildren("preValue", "")

        'Loop thru datatype
        While dtItem.MoveNext()
            dict.Add(dtItem.Current.GetAttribute("id", ""), dtItem.Current.Value)
        End While

        Return dict
    End Function
    Private Shared Function getDatatype_dropDownLst(ByVal _datatypeId As Integer) As Dictionary(Of String, String)
        'Instantiate variables
        Dim dtList As XPathNodeIterator
        Dim dtItem As XPathNodeIterator
        Dim dict As New Dictionary(Of String, String)

        'Get datatype and move to first data position
        dtList = umbraco.library.GetPreValues(_datatypeId)
        dtList.MoveNext() 'move to first
        dtItem = dtList.Current.SelectChildren("preValue", "")

        'Loop thru datatype
        While dtItem.MoveNext()
            dict.Add(dtItem.Current.GetAttribute("id", ""), dtItem.Current.Value)
        End While

        Return dict
    End Function
    Public Shared Function getOnlyNumbers(ByVal value As String) As Integer
        Dim returnVal As String = 0
        Dim collection As MatchCollection = Regex.Matches(value, "\d+")
        For Each m As Match In collection
            returnVal += m.ToString()
        Next
        Return Convert.ToInt32(returnVal)
    End Function
    Public Shared Function removeNumbers(ByVal input As String) As String
        Dim output As String = New [String](input.Where(Function(c) c <> "-"c AndAlso (c < "0"c OrElse c > "9"c)).ToArray())
        Return output
    End Function
    Public Shared Function getAlphaNumberic(ByVal value As String) As String
        Return Regex.Replace(value, "[^a-zA-Z0-9]", "")
    End Function
    Public Shared Function formatDay(ByVal _day As UInt16) As String
        'Obtain postfix of day
        Select Case _day
            Case 1, 21, 31
                Return _day.ToString & "<sup>st</sup>"
            Case 2
                Return _day.ToString & "<sup>nd</sup>"
            Case 3, 23
                Return _day.ToString & "<sup>rd</sup>"
            Case 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 22, 24, 25, 26, 27, 28, 29, 30
                Return _day.ToString & "<sup>th</sup>"
            Case Else
                Return _day.ToString
        End Select
    End Function
    Public Shared Function generateSideNav(ByVal _thisNodeId As Integer) As HtmlGenericControl
        'Instantiate variables
        Dim secondLvlNode As Node = New Node(get2ndLvlNodeId(_thisNodeId))
        Dim ul_parent = New HtmlGenericControl("ul")
        Dim ul_child = New HtmlGenericControl("ul")
        Dim li_parent As HtmlGenericControl
        Dim li_child As HtmlGenericControl
        Dim hlnk As HyperLink
        Dim lvl3Populated As Boolean = False
        Dim lvl4Populated As Boolean = False
        Dim pnl As Panel

        'Loop thru all 3rd level children
        For Each childNode_3rdLvl As Node In secondLvlNode.Children
            If childNode_3rdLvl.HasProperty(nodeProperties.allowInSideNav) AndAlso childNode_3rdLvl.GetProperty(Of Boolean)(nodeProperties.allowInSideNav) Then
                li_parent = New HtmlGenericControl("li")
                hlnk = New HyperLink
                pnl = New Panel
                hlnk.Text = childNode_3rdLvl.Name
                hlnk.NavigateUrl = childNode_3rdLvl.NiceUrl
                pnl.Controls.Add(hlnk)
                li_parent.Controls.Add(pnl)
                li_parent.Attributes.Add("data-nodeId", childNode_3rdLvl.Id.ToString)
                If childNode_3rdLvl.Id = _thisNodeId Then li_parent.Attributes.Add("class", "active")
                lvl3Populated = True

                'Loop thru all 4th level children
                ul_child = New HtmlGenericControl("ul")
                For Each childNode_4thLvl As Node In childNode_3rdLvl.Children
                    If childNode_4thLvl.HasProperty(nodeProperties.allowInSideNav) AndAlso childNode_4thLvl.GetProperty(Of Boolean)(nodeProperties.allowInSideNav) Then
                        li_child = New HtmlGenericControl("li")
                        hlnk = New HyperLink
                        pnl = New Panel
                        hlnk.Text = childNode_4thLvl.Name
                        hlnk.NavigateUrl = childNode_4thLvl.NiceUrl
                        pnl.Controls.Add(hlnk)
                        li_child.Controls.Add(pnl)
                        li_child.Attributes.Add("data-nodeId", childNode_4thLvl.Id.ToString)
                        If childNode_4thLvl.Id = _thisNodeId Then li_child.Attributes.Add("class", "active")
                        ul_child.Controls.Add(li_child)
                        lvl4Populated = True
                    End If
                Next
                If lvl4Populated Then li_parent.Controls.Add(ul_child)

                ul_parent.Controls.Add(li_parent)
            End If
        Next

        'Return controls
        If lvl3Populated Then
            Return ul_parent
        Else
            Return Nothing
        End If
    End Function
    Public Shared Function showInNewTab(ByVal openInNewTab As Boolean) As String
        If openInNewTab Then
            Return "target='_blank'"
        Else
            Return String.Empty
        End If
    End Function
    'Public Shared Function getVimeoImg(ByVal VideoID As String) As String
    '    Try
    '        'Instantiate variables
    '        Dim myDownloader As New WebClient()
    '        Dim vimeoImg As New DataLayer.VimeoImg
    '        Dim jsonResponse As String

    '        'Obtain json and convert to class
    '        myDownloader.Encoding = System.Text.Encoding.UTF8
    '        jsonResponse = myDownloader.DownloadString((Convert.ToString("http://vimeo.com/api/v2/video/") & VideoID) + ".json")
    '        vimeoImg = JsonConvert.DeserializeObject(Of DataLayer.VimeoImg)(jsonResponse.Replace("[", "").Replace("]", ""))

    '        'Return larger size of image
    '        Return vimeoImg.thumbnail_large.Replace("_640.", "_1280.")

    '    Catch ex As Exception
    '        Return ex.ToString 'String.Empty
    '    End Try
    'End Function
    Public Shared Function getVimeoImg(ByVal VideoImageId As String) As String
        Try
            'THIS METHOD IS TEMPORARY UNTIL WE CAN FIND OUT HOW TO OBTAIN VIMEO IMAGE FROM A PRIVATE VIDEO.
            Return "https://i.vimeocdn.com/video/[ID]_1200.webp".Replace("[ID]", VideoImageId)
        Catch ex As Exception
            Return String.Empty
        End Try
    End Function
    Public Shared Function getYoutubeImg(ByVal VideoImageId As String) As String
        Try
            Return "http://img.youtube.com/vi/[ID]/maxresdefault.jpg".Replace("[ID]", VideoImageId)
        Catch ex As Exception
            Return String.Empty
        End Try
    End Function
    Public Shared Function isUserLoggedIn(ByVal sessionCookie As HttpCookie) As Boolean
        'Check to make sure the cookie exists
        If sessionCookie Is Nothing Then
            Return False
        Else
            'Obtain the session value
            Dim sessionValue As String = sessionCookie.Value.ToString()
            'Dim imis As New mvcvb.wsImis
            Dim imis As New ImisWebservice2017

            Return imis.IsUserLoggedIn(sessionValue)
        End If
    End Function
    Public Shared Sub logBoardMemberByProxy()
        Try
            'Instantiate variables
            Dim proxyId As String = ConfigurationManager.AppSettings(miscellaneous.proxyId)
            Dim proxyPw As String = ConfigurationManager.AppSettings(miscellaneous.proxyPw)
            Dim imis As New ImisWebservice2017
            Dim currentHttp As HttpContext = System.Web.HttpContext.Current

            'Clear existing login credentials
            currentHttp.Response.Cookies.Remove(nodeProperties.Login)
            currentHttp.Response.Cookies.Remove(nodeProperties.FullLoginResponse)
            currentHttp.Response.Cookies.Remove(nodeProperties.SessionGuid)
            currentHttp.Response.Cookies.Remove(miscellaneous.validBMember)

            'Add cookie for valid board member login
            currentHttp.Response.Cookies(miscellaneous.validBMember).Value = True

            'Attempt to log in and obtain login result message
            Dim loginReturnMsg As String = imis.Login(proxyId, proxyPw)

            'Save entire message to cookie.  (for debugging purposes)
            currentHttp.Response.Cookies(nodeProperties.FullLoginResponse).Value = loginReturnMsg

            'Extract login results into class and create cookies is valid.
            Dim loginResult As Login = JsonConvert.DeserializeObject(Of Login)(loginReturnMsg)
            If loginResult.IsValidated = True Then
                For Each cookieStruct As CookieStructure In loginResult.CookieStructures
                    currentHttp.Response.Cookies(cookieStruct.Name).Value = cookieStruct.Value
                Next
            End If
        Catch ex As Exception
            Dim sb As New StringBuilder()
            sb.AppendLine("Common.vb : logBoardMemberByProxy()")
            sb.AppendLine("Failed attempt to login using proxy credentials")
            SaveErrorMessage(ex, sb, GetType(Common))
        End Try
    End Sub

    'This function will traverse the node tree and obtain the 2nd-level parent node.
    '===============================================================================
    Private Shared Function get2ndLvlNodeId(ByVal _thisNodeId As Integer) As Integer
        'Instantiate variable
        Dim thisNode As Node = New Node(_thisNodeId)

        'Determine if node is 2nd level or not.
        Select Case thisNode.Parent.NodeTypeAlias
            Case aliases.home, aliases.homeMicrosite
                Return _thisNodeId
            Case Else
                Return get2ndLvlNodeId(thisNode.Parent.Id)
        End Select
    End Function
    Public Shared Function getHomeNodeId(ByVal _thisNodeId As Integer) As Integer
        Try
            'Instantiate variable
            Dim thisNode As Node = New Node(_thisNodeId)

            'Determine if node is 2nd level or not.
            Select Case thisNode.NodeTypeAlias
                Case aliases.home, aliases.homeMicrosite
                    Return _thisNodeId
                Case aliases.dataLayer
                    Return _thisNodeId
                Case Else
                    Return getHomeNodeId(thisNode.Parent.Id)
            End Select
        Catch
            Return -1
        End Try
    End Function
    Public Shared Function UppercaseFirstLetter(ByVal val As String) As String
        ' Test for nothing or empty.
        If String.IsNullOrEmpty(val) Then
            Return val
        End If

        ' Convert to character array.
        Dim array() As Char = val.ToCharArray

        ' Uppercase first character.
        array(0) = Char.ToUpper(array(0))

        ' Return new string.
        Return New String(array)
    End Function

    Public Shared Sub SaveErrorMessage(ByVal ex As Exception, ByVal sb As StringBuilder, ByVal type As Type)
        Dim sbGeneralInfo As StringBuilder = New StringBuilder()

        Try
            Dim umbracoHelper As UmbracoHelper = New umbraco.Web.UmbracoHelper(umbraco.Web.UmbracoContext.Current)
            Dim SaveErrorMsgs As Boolean = False
            Dim ipData As IPublishedContent = umbracoHelper.TypedContentAtRoot().FirstOrDefault(Function(x) x.ContentType.[Alias].Equals(aliases.dataLayer))
            Dim ipAppStartEvents As IPublishedContent = ipData.FirstChild(Of IPublishedContent)(Function(x) x.ContentType.[Alias].Equals(aliases.appStartEvents))
            If ipAppStartEvents.HasProperty(nodeProperties.SaveErrorMessage) Then SaveErrorMsgs = ipAppStartEvents.GetPropertyValue(Of Boolean)(nodeProperties.SaveErrorMessage)

            If SaveErrorMsgs Then

                Try
                    Dim st As StackTrace = New StackTrace(ex, True)
                    Dim frame As StackFrame = st.GetFrame(0)
                    sbGeneralInfo.AppendLine("fileName: " & frame.GetFileName())
                    sbGeneralInfo.AppendLine("methodName: " & frame.GetMethod().Name)
                    sbGeneralInfo.AppendLine("line: " & frame.GetFileLineNumber())
                    sbGeneralInfo.AppendLine("col: " & frame.GetFileColumnNumber())
                Catch exc As Exception
                    'sbGeneralInfo.AppendLine("Error attempting to add stack information in SaveErrorMessage()")
                    'sbGeneralInfo.AppendLine(exc.ToString())
                End Try

                sbGeneralInfo.AppendLine(sb.ToString())
                LogHelper.[Error](type, sbGeneralInfo.ToString(), ex)
            End If

        Catch [error] As Exception
            LogHelper.[Error](GetType(Common), "Error Saving Exception Message.  Original Data: " & sbGeneralInfo.ToString() & " ||| " + ex.ToString(), [error])
        End Try
    End Sub
#End Region

End Class
