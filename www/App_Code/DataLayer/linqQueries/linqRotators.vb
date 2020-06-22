Imports Microsoft.VisualBasic
Imports Common
Imports Umbraco
Imports Umbraco.Core.Models
Imports Umbraco.NodeFactory
Imports Umbraco.Web

Public Class linqRotators

#Region "Properties"
    'Private linq2Db As linq2SqlDataContext = New linq2SqlDataContext(ConfigurationManager.ConnectionStrings("umbracoDbDSN").ToString)
#End Region


#Region "Select"
    Public Function obtainListOfRotators(ByVal _thisNodeId As Integer) As BusinessReturn
        'Instantiate master variables
        Dim businessReturn As New BusinessReturn

        Try
            'Instantiate variables
            Dim rotatorIDs As List(Of Integer)
            Dim lstRotators As New List(Of DataLayer.Rotator)

            'Obtain all rotator IDs for this node
            rotatorIDs = obtainRotatorIDs(_thisNodeId)

            'Loop thru all IDs and rotator to list
            For Each _id As Integer In rotatorIDs
                Dim result As BusinessReturn = obtainRotator(_id)
                If result.isValid Then
                    lstRotators.Add(DirectCast(result.DataContainer(0), DataLayer.Rotator))
                End If
            Next

            'Save lst to return
            businessReturn.DataContainer.Add(lstRotators)

        Catch ex As Exception
            'Save error to umbraco
            Dim sb As New StringBuilder
            sb.AppendLine("linqRotators.vb | obtainListOfRotators()")
            sb.AppendLine("_thisNodeId: " & _thisNodeId)
            SaveErrorMessage(ex, sb, Me.GetType())

            'Return exception
            businessReturn.ExceptionMessage = ex.ToString
        End Try

        Return businessReturn
    End Function
#End Region

#Region "Private Methods"
    Private Function obtainRotatorIDs(ByVal _thisNodeId As Integer) As List(Of Integer)
        'Instantiate variables
        Dim lstIDs As New List(Of Integer)
        Dim uHelper As UmbracoHelper = New umbraco.Web.UmbracoHelper(umbraco.Web.UmbracoContext.Current)
        Dim ipContent As IPublishedContent = uHelper.TypedContent(_thisNodeId)

        'Extract all node IDs from list property
        If ipContent.HasValue(nodeProperties.rotatingBanners) Then
            For Each id As IPublishedContent In ipContent.GetPropertyValue(Of IEnumerable(Of IPublishedContent))(nodeProperties.rotatingBanners)
                Dim temp As Integer? = getIdFromGuid_byType(id.Id, Core.Models.UmbracoObjectTypes.Document)
                If Not IsNothing(temp) Then lstIDs.Add(temp)
            Next
        End If

        Return lstIDs
    End Function
    Private Function obtainRotator(ByVal _nodeId As Integer) As BusinessReturn
        'Instantiate master variables
        Dim businessReturn As New BusinessReturn
        Dim ipContent As IPublishedContent

        Try
            'Instantiate variables
            Dim rotator As New DataLayer.Rotator
            Dim uHelper As UmbracoHelper = New umbraco.Web.UmbracoHelper(umbraco.Web.UmbracoContext.Current)
            ipContent = uHelper.TypedContent(_nodeId)




            'Obtain property data
            rotator.nodeId = _nodeId

            If ipContent.HasValue(nodeProperties.bl_title) Then rotator.title = ipContent.GetPropertyValue(Of String)(nodeProperties.bl_title)
            If ipContent.HasValue(nodeProperties.bl_subtitle) Then
                rotator.subtitle = ipContent.GetPropertyValue(Of String)(nodeProperties.bl_subtitle)
                rotator.showSubtitle = True
            End If

            rotator.dropShadowClass = getdropShadowClass(ipContent.GetPropertyValue(Of String)(nodeProperties.dropShadow))

            If ipContent.HasValue(nodeProperties.useNativeDimensions) Then rotator.useNativeDimensions = ipContent.GetPropertyValue(Of Boolean)(nodeProperties.useNativeDimensions)

            If ipContent.HasValue(nodeProperties.bl_backgroundImage) Then
                If rotator.useNativeDimensions Then
                    rotator.backgroundImageUrl = getMediaURL(ipContent.GetPropertyValue(Of String)(nodeProperties.bl_backgroundImage), String.Empty, True)
                Else
                    rotator.backgroundImageUrl = getMediaURL(ipContent.GetPropertyValue(Of String)(nodeProperties.bl_backgroundImage), crops.FullBanner)
                End If
                rotator.backgroundImageName = getMediaName(ipContent.GetPropertyValue(Of String)(nodeProperties.bl_backgroundImage))
            End If
            If ipContent.HasValue(nodeProperties.bl_callToActionLink) AndAlso ipContent.HasValue(nodeProperties.bl_callToActionText) Then
                'rotator.callToActionLink = getNode(ipContent.GetPropertyValue(Of String)(nodeProperties.bl_callToActionLink)).NiceUrl
                'rotator.callToActionText = ipContent.GetPropertyValue(Of String)(nodeProperties.bl_callToActionText)

                Try
                    rotator.callToActionLink = getNode(ipContent.GetPropertyValue(Of String)(nodeProperties.bl_callToActionLink)).NiceUrl
                Catch
                    If ipContent.HasValue(nodeProperties.bl_callToActionLink) Then
                        rotator.callToActionLink = ipContent.GetPropertyValue(Of IPublishedContent)(nodeProperties.bl_callToActionLink).Url
                    End If
                End Try

                rotator.callToActionText = ipContent.GetPropertyValue(Of String)(nodeProperties.bl_callToActionText)
                rotator.showCallToAction = True
            End If
            If ipContent.HasValue(nodeProperties.bl_textAlignment) Then
                rotator.textAlignment = getTextAlignment(ipContent.GetPropertyValue(Of String)(nodeProperties.bl_textAlignment))
            End If


            If ipContent.HasValue(nodeProperties.bl_quicklinkTitle) Then rotator.quicklinkTitle = ipContent.GetProperty(nodeProperties.bl_quicklinkTitle).Value
            If ipContent.HasValue(nodeProperties.bl_quicklinkSubtitle) Then
                rotator.quicklinkSubtitle = ipContent.GetPropertyValue(Of String)(nodeProperties.bl_quicklinkSubtitle)
                rotator.showQuicklinkSubtitle = True
            End If
            '

            Try
                rotator.iconImageUrl = ipContent.GetPropertyValue(Of IPublishedContent)(nodeProperties.bl_icon).Url
            Catch ex As Exception
                rotator.iconImageUrl = getMediaURL(ipContent.GetPropertyValue(Of String)(nodeProperties.bl_icon))
            End Try


            'Add rotator to data container
            businessReturn.DataContainer.Add(rotator)

        Catch ex As Exception
            'Save error to umbraco
            Dim sb As New StringBuilder
            sb.AppendLine("linqRotators.vb | obtainRotator()")
            sb.AppendLine("_nodeId: " & _nodeId)
            If Not IsNothing(ipContent) Then sb.AppendLine("ipContent.Name: " & ipContent.Name)
            SaveErrorMessage(ex, sb, Me.GetType())

            businessReturn.ExceptionMessage = ex.ToString
        End Try

        Return businessReturn
    End Function
#End Region

End Class
