Imports Microsoft.VisualBasic
Imports Common
Imports Umbraco
Imports Umbraco.Core.Models
Imports Umbraco.NodeFactory
Imports Umbraco.Web

Public Class linqBanners

#Region "Properties"
#End Region


#Region "Select"
    Public Function obtainBanner(ByVal _thisNodeId As Integer) As BusinessReturn
        'Instantiate master variables
        Dim businessReturn As New BusinessReturn

        Try
            'Instantiate variables
            Dim uHelper As UmbracoHelper = New Umbraco.Web.UmbracoHelper(Umbraco.Web.UmbracoContext.Current)
            Dim ipContent As IPublishedContent = uHelper.TypedContent(_thisNodeId)
            Dim quoteBanner As New DataLayer.QuoteBanner

            'Obtain property data
            quoteBanner.nodeId = _thisNodeId

            If ipContent.HasValue(nodeProperties.qb_title) Then quoteBanner.title = ipContent.GetPropertyValue(Of String)(nodeProperties.qb_title)

            'If thisNode.HasValue(nodeProperties.qb_dropShadow) Then
            '    quoteBanner.textAlignment = getTextAlignment(thisNode.GetProperty(nodeProperties.qb_dropShadow).Value)
            'End If
            quoteBanner.dropShadowClass = getdropShadowClass(ipContent.GetPropertyValue(Of String)(nodeProperties.dropShadow))

            If ipContent.HasValue(nodeProperties.qb_backgroundImage) Then
                If ipContent.HasValue(nodeProperties.useNativeDimensions) Then quoteBanner.useNativeDimensions = ipContent.GetPropertyValue(Of Boolean)(nodeProperties.useNativeDimensions)
                If quoteBanner.useNativeDimensions Then
                    quoteBanner.backgroundImageUrl = getMediaURL(ipContent.GetPropertyValue(Of IPublishedContent)(nodeProperties.qb_backgroundImage).Id, String.Empty, True)
                Else
                    quoteBanner.backgroundImageUrl = getMediaURL(ipContent.GetPropertyValue(Of IPublishedContent)(nodeProperties.qb_backgroundImage).Id, crops.FullBanner)
                End If

                quoteBanner.backgroundImageName = getMediaName(ipContent.GetPropertyValue(Of IPublishedContent)(nodeProperties.qb_backgroundImage).Id)
            End If

            If ipContent.HasValue(nodeProperties.qb_textAlignment) Then
                quoteBanner.textAlignment = getTextAlignment(ipContent.GetPropertyValue(Of String)(nodeProperties.qb_textAlignment))
            End If

            If ipContent.HasValue(nodeProperties.qb_subtitle) Then
                quoteBanner.subtitle = ipContent.GetPropertyValue(Of String)(nodeProperties.qb_subtitle)
                quoteBanner.showSubtitle = True
            End If

            If ipContent.HasValue(nodeProperties.qb_callToActionLink) AndAlso ipContent.HasValue(nodeProperties.qb_callToActionText) Then
                If ipContent.HasValue(nodeProperties.qb_callToActionLink) AndAlso ipContent.HasValue(nodeProperties.qb_callToActionText) Then
                    Try
                        quoteBanner.callToActionLink = getNode(ipContent.GetPropertyValue(Of String)(nodeProperties.qb_callToActionLink)).NiceUrl
                    Catch ex As Exception
                        quoteBanner.callToActionLink = ipContent.GetPropertyValue(Of IPublishedContent)(nodeProperties.qb_callToActionLink).Url
                    End Try
                    quoteBanner.callToActionText = ipContent.GetPropertyValue(Of String)(nodeProperties.qb_callToActionText)
                    quoteBanner.showCallToAction = True
                End If

            End If

            'Save class to return
            businessReturn.DataContainer.Add(quoteBanner)

        Catch ex As Exception
            'Save error to umbraco
            Dim sb As New StringBuilder
            sb.AppendLine("linqBanners.vb | obtainBannerData()")
            sb.AppendLine("_thisNodeId: " & _thisNodeId)
            SaveErrorMessage(ex, sb, Me.GetType())

            'Return exception
            businessReturn.ExceptionMessage = ex.ToString
        End Try

        Return businessReturn
    End Function
    Public Function obtainQuoteBannerWithNav(ByVal _thisNodeId As Integer) As BusinessReturn
        'Instantiate master variables
        Dim businessReturn As New BusinessReturn

        Try
            'Instantiate variables
            Dim uHelper As UmbracoHelper = New umbraco.Web.UmbracoHelper(umbraco.Web.UmbracoContext.Current)
            Dim ipContent As IPublishedContent = uHelper.TypedContent(_thisNodeId)
            Dim lstNodeIDs As New List(Of Integer)
            Dim quoteBanner As New DataLayer.QuoteBannerWithNav
            Dim sideNavLinks As DataLayer.QuoteBannerWithNav.sideNavLink
            Dim imgId As Integer

            'Obtain property data
            imgId = getIdFromGuid_byType(ipContent.GetPropertyValue(Of IPublishedContent)(nodeProperties.qwn_backgroundImage).Id, UmbracoObjectTypes.Media)

            If ipContent.HasValue(nodeProperties.qwn_author) Then quoteBanner.author = ipContent.GetPropertyValue(Of String)(nodeProperties.qwn_author)
            quoteBanner.backgroundImageName = getMediaName(imgId)

            If ipContent.HasValue(nodeProperties.useNativeDimensions) Then quoteBanner.useNativeDimensions = ipContent.GetPropertyValue(Of Boolean)(nodeProperties.useNativeDimensions)
            If quoteBanner.useNativeDimensions Then
                quoteBanner.backgroundImageUrl = getMediaURL(imgId, String.Empty, True)
            Else
                quoteBanner.backgroundImageUrl = getMediaURL(imgId, crops.FullBanner)
            End If

            quoteBanner.nodeId = _thisNodeId
            If ipContent.HasValue(nodeProperties.qwn_quote) Then quoteBanner.quote = ipContent.GetPropertyValue(Of String)(nodeProperties.qwn_quote)

            If ipContent.HasValue(nodeProperties.qwn_textAlignment) Then
                quoteBanner.textAlignment = getTextAlignment(ipContent.GetPropertyValue(Of String)(nodeProperties.qwn_textAlignment))
            End If

            If ipContent.HasValue(nodeProperties.qb_dropShadow) Then
                quoteBanner.dropShadowClass = getdropShadowClass(ipContent.GetPropertyValue(Of String)(nodeProperties.qb_dropShadow))
            End If
            If ipContent.HasValue(nodeProperties.dropShadow) Then
                quoteBanner.dropShadowClass = getdropShadowClass(ipContent.GetPropertyValue(Of String)(nodeProperties.dropShadow))
            End If

            If ipContent.HasValue(nodeProperties.qwn_sideNav) Then
                'Obtain list of node IDs for side nav
                If ipContent.HasValue(nodeProperties.qwn_sideNav) Then
                    'For Each item As String In ipContent.GetPropertyValue(Of String)(nodeProperties.qwn_sideNav).Split(",").ToList
                    For Each item As IPublishedContent In ipContent.GetPropertyValue(Of IEnumerable(Of IPublishedContent))(nodeProperties.qwn_sideNav)
                        lstNodeIDs.Add(item.Id) 'getIdFromGuid_byType(item, UmbracoObjectTypes.Document))
                    Next
                End If
                For Each id As Integer In lstNodeIDs
                    'Obtain data for side nav links
                    sideNavLinks = New DataLayer.QuoteBannerWithNav.sideNavLink
                    Dim ipLinkedNode As IPublishedContent = uHelper.TypedContent(id)

                    'Try

                    'Add data to class.
                    sideNavLinks.nodeId = id

                    If ipLinkedNode.HasValue(nodeProperties.title) Then sideNavLinks.quicklinkTitle = ipLinkedNode.GetPropertyValue(Of String)(nodeProperties.title)
                    If ipLinkedNode.HasValue(nodeProperties.subtitle) Then sideNavLinks.quicklinkSubtitle = ipLinkedNode.GetPropertyValue(Of String)(nodeProperties.subtitle)
                    If ipLinkedNode.HasValue(nodeProperties.openInNewTab) Then sideNavLinks.openInNewTab = ipLinkedNode.GetPropertyValue(Of Boolean)(nodeProperties.openInNewTab)
                    If ipLinkedNode.HasValue(nodeProperties.icon) Then sideNavLinks.iconImageUrl = getMediaURL(ipLinkedNode.GetPropertyValue(Of IPublishedContent)(nodeProperties.icon).Id)

                    Select Case ipLinkedNode.DocumentTypeAlias
                        Case aliases.internalBannerlink
                            If ipLinkedNode.HasValue(nodeProperties.link) Then sideNavLinks.url = ipLinkedNode.GetPropertyValue(Of IPublishedContent)(nodeProperties.link).Url'Common.getNode(ipLinkedNode.GetPropertyValue(Of String)(nodeProperties.link)).NiceUrl
                        Case aliases.externalBannerlink
                            If ipLinkedNode.HasValue(nodeProperties.externalUrl) Then sideNavLinks.url = ipLinkedNode.GetPropertyValue(Of String)(nodeProperties.externalUrl)
                    End Select

                    'Catch ex As Exception
                    '    quoteBanner.quote += " ERROR: " & ex.ToString
                    'End Try

                    'Add class to list
                    quoteBanner.lstSideNavLinks.Add(sideNavLinks)
                Next

                If ipContent.HasValue(nodeProperties.qwn_textAlignment) Then quoteBanner.textAlignment = getTextAlignment(ipContent.GetPropertyValue(Of String)(nodeProperties.qwn_textAlignment))

                'If thisNode.HasValue(nodeProperties.qb_dropShadow) Then
                '    quoteBanner.textAlignment = getTextAlignment(thisNode.GetProperty(nodeProperties.qb_dropShadow).Value)
                'End If
                If ipContent.HasValue(nodeProperties.dropShadow) Then
                    quoteBanner.dropShadowClass = getdropShadowClass(ipContent.GetPropertyValue(Of String)(nodeProperties.dropShadow))
                End If
            Else
                quoteBanner.showSideNav = False
            End If

            'Save class to return
            businessReturn.DataContainer.Add(quoteBanner)

        Catch ex As Exception
            'Save error to umbraco
            Dim sb As New StringBuilder
            sb.AppendLine("linqBanners.vb | obtainQuoteBannerWithNav()")
            sb.AppendLine("_thisNodeId: " & _thisNodeId)
            SaveErrorMessage(ex, sb, Me.GetType())

            'Return exception
            businessReturn.ExceptionMessage = ex.ToString
        End Try

        Return businessReturn
    End Function
    Public Function obtainTextBlock(ByVal _thisNodeId As Integer) As BusinessReturn
        'Instantiate master variables
        Dim businessReturn As New BusinessReturn

        Try
            'Instantiate variables
            Dim uHelper As UmbracoHelper = New umbraco.Web.UmbracoHelper(umbraco.Web.UmbracoContext.Current)
            Dim ipContent As IPublishedContent = uHelper.TypedContent(_thisNodeId)
            Dim textBlock As New DataLayer.TextBlock

            'Obtain property data
            textBlock.nodeId = _thisNodeId
            textBlock.content = ipContent.GetPropertyValue(Of String)(nodeProperties.tb_content)
            textBlock.showAd = ipContent.GetPropertyValue(Of Boolean)(nodeProperties.tb_showAd)
            textBlock.showSideNav = ipContent.GetPropertyValue(Of Boolean)(nodeProperties.tb_showSideNavigation)
            textBlock.showSideOnRight = ipContent.GetPropertyValue(Of Boolean)(nodeProperties.tb_SideOnRight)
            textBlock.isCCDonationPg = (ipContent.DocumentTypeAlias.Equals(aliases.contributions))
            textBlock.isBankDonationPg = (ipContent.DocumentTypeAlias.Equals(aliases.contributionsBank))

            'Save class to return
            businessReturn.DataContainer.Add(textBlock)


        Catch ex As Exception
            'Save error to umbraco
            Dim sb As New StringBuilder
            sb.AppendLine("linqBanners.vb | obtainTextBlock()")
            sb.AppendLine("_thisNodeId: " & _thisNodeId)
            SaveErrorMessage(ex, sb, Me.GetType())

            'Return exception
            businessReturn.ExceptionMessage = ex.ToString
        End Try

        Return businessReturn
    End Function
    Public Function obtainSimpleBanner(ByVal _thisNodeId As Integer) As BusinessReturn
        'Instantiate master variables
        Dim businessReturn As New BusinessReturn

        Try
            'Instantiate variables
            Dim uHelper As UmbracoHelper = New umbraco.Web.UmbracoHelper(umbraco.Web.UmbracoContext.Current)
            Dim ipContent As IPublishedContent = uHelper.TypedContent(_thisNodeId)
            Dim SimpleBanner As New DataLayer.SimpleBanner


            'Determine if panel should be displayed or hidden.
            If ipContent.HasValue(nodeProperties.sb_backgroundImage) Then
                'Obtain property data
                SimpleBanner.nodeId = _thisNodeId
                SimpleBanner.title = ipContent.GetPropertyValue(Of String)(nodeProperties.sb_title)
                If ipContent.HasValue(nodeProperties.sb_subtitle) Then SimpleBanner.subtitle = ipContent.GetPropertyValue(Of String)(nodeProperties.sb_subtitle)

                Dim imgId As Integer = getIdFromGuid_byType(ipContent.GetPropertyValue(Of IPublishedContent)(nodeProperties.sb_backgroundImage).Id, UmbracoObjectTypes.Media)

                If ipContent.HasValue(nodeProperties.useNativeDimensions) Then SimpleBanner.useNativeDimensions = ipContent.GetPropertyValue(Of Boolean)(nodeProperties.useNativeDimensions)
                If SimpleBanner.useNativeDimensions Then
                    SimpleBanner.backgroundImageUrl = getMediaURL(imgId, String.Empty, True)
                Else
                    Select Case ipContent.DocumentTypeAlias
                        Case aliases.blogHome, aliases.eventCalendar, aliases.certificationList, aliases.trusteeList, aliases.listSearch, aliases.listBlogBoardOfTrustees, aliases.podcastList
                            SimpleBanner.backgroundImageUrl = getMediaURL(imgId, crops.NarrowBanner)
                        Case Else
                            SimpleBanner.backgroundImageUrl = getMediaURL(imgId, crops.FullBanner)
                    End Select
                End If

                SimpleBanner.backgroundImageName = getMediaName(imgId)
                SimpleBanner.dropShadowClass = getdropShadowClass(ipContent.GetPropertyValue(Of String)(nodeProperties.dropShadow))

                'Save class to return
                businessReturn.DataContainer.Add(SimpleBanner)
            Else
                businessReturn.ExceptionMessage = "no image to display.  hide panel."
            End If

        Catch ex As Exception
            'Save error to umbraco
            Dim sb As New StringBuilder
            sb.AppendLine("linqBanners.vb | obtainSimpleBanner()")
            sb.AppendLine("_thisNodeId: " & _thisNodeId)
            SaveErrorMessage(ex, sb, Me.GetType())

            'Return exception
            businessReturn.ExceptionMessage = ex.ToString
        End Try

        Return businessReturn
    End Function
#End Region

#Region "Private Methods"
#End Region

End Class
