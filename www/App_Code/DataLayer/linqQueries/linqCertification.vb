Imports Microsoft.VisualBasic
Imports Common
Imports Umbraco
Imports Umbraco.Core.Models
Imports Umbraco.NodeFactory
Imports Umbraco.Web

Public Class linqCertification

#Region "Properties"
#End Region

#Region "Select"
    Public Function obtainCertification(ByVal _thisNodeId As Integer) As BusinessReturn

        'Instantiate master variables
        Dim businessReturn As New BusinessReturn

        Try
            'Instantiate variables
            Dim uHelper As UmbracoHelper = New Umbraco.Web.UmbracoHelper(Umbraco.Web.UmbracoContext.Current)
            Dim ipContent As IPublishedContent = uHelper.TypedContent(_thisNodeId)
            Dim certification As New DataLayer.Certification
            Dim blMembers As New blMembers
            Dim lstSiblings As New List(Of Integer)
            Dim index As Int16 = 0
            Dim count As Int16 = 0
            Dim link As DataLayer.QuickLink


            'Obtain property data
            certification.certificationId = _thisNodeId
            If ipContent.HasValue(nodeProperties.title) Then certification.certificationTitle = ipContent.GetPropertyValue(Of String)(nodeProperties.title)
            certification.certificationUrl = ipContent.Url
            If ipContent.HasValue(nodeProperties.commonContent) Then certification.commonContent = ipContent.GetPropertyValue(Of String)(nodeProperties.commonContent)
            If ipContent.HasValue(nodeProperties.courseHighlights) Then certification.courseHighlights = ipContent.GetPropertyValue(Of String)(nodeProperties.courseHighlights)
            If ipContent.HasValue(nodeProperties.featuredImage) Then
                certification.featuredImgUrl = getMediaURL(ipContent.GetPropertyValue(Of IPublishedContent)(nodeProperties.featuredImage).Id, crops.SideImage)
                certification.featuredImgName = getMediaName(ipContent.GetPropertyValue(Of IPublishedContent)(nodeProperties.featuredImage).Id)
            End If
            If ipContent.HasValue(nodeProperties.haveQuestions) Then certification.haveQuestions = ipContent.GetPropertyValue(Of String)(nodeProperties.haveQuestions)

            If ipContent.HasValue(nodeProperties.showOnlineContent) Then certification.showOnlineContent = ipContent.GetPropertyValue(Of Boolean)(nodeProperties.showOnlineContent)
            If certification.showOnlineContent Then
                If ipContent.HasValue(nodeProperties.onlineContent) Then certification.onlineContent = ipContent.GetPropertyValue(Of String)(nodeProperties.onlineContent)
                If ipContent.HasValue(nodeProperties.onlineCosts) Then certification.onlineCosts = ipContent.GetPropertyValue(Of String)(nodeProperties.onlineCosts)
                If ipContent.HasValue(nodeProperties.onlineFormat) Then certification.onlineFormat = ipContent.GetPropertyValue(Of String)(nodeProperties.onlineFormat)

                'Obtain list of all added members as instructors
                Dim lstMembers As IEnumerable(Of IPublishedContent)
                'If ipContent.HasValue(nodeProperties.onlineInstructors) Then lstMembers = ipContent.GetPropertyValue(Of IEnumerable(Of IPublishedContent))(nodeProperties.onlineInstructors)
                ''Loop thru each id
                'If Not IsNothing(lstMembers) Then
                '    'For Each memberGuid As String In lstGuids
                '    For Each ipMember As IPublishedContent In lstMembers
                '        Dim bReturn As BusinessReturn = blMembers.selectMember_byId(ipMember.Id)
                '        If bReturn.isValid Then certification.lstOnlineInstructors.Add(DirectCast(bReturn.DataContainer(0), DataLayer.Member))
                '    Next
                'End If

                If ipContent.HasValue(nodeProperties.onlineInstructors) Then lstMembers = ipContent.GetPropertyValue(Of IEnumerable(Of IPublishedContent))(nodeProperties.onlineInstructors)
                'Loop thru each id
                If Not IsNothing(lstMembers) Then
                    'For Each memberGuid As String In lstGuids
                    For Each ipMember As IPublishedContent In lstMembers
                        Dim ipInstructor = ipMember.GetPropertyValue(Of IPublishedContent)(nodeProperties.trusteeId)
                        Dim bReturn As BusinessReturn = blMembers.selectMember_byId(ipInstructor.Id)
                        Dim member As DataLayer.Member = DirectCast(bReturn.DataContainer(0), DataLayer.Member)
                        member.trusteeUrl = ipMember.Url
                        If bReturn.isValid Then certification.lstOnlineInstructors.Add(member)
                    Next
                End If

            End If


            If ipContent.HasValue(nodeProperties.showClassroomContent) Then certification.showClassroomContent = ipContent.GetPropertyValue(Of Boolean)(nodeProperties.showClassroomContent)
            If certification.showClassroomContent Then
                If ipContent.HasValue(nodeProperties.classroomContent) Then certification.classroomContent = ipContent.GetPropertyValue(Of String)(nodeProperties.classroomContent)
                If ipContent.HasValue(nodeProperties.classroomCosts) Then certification.classroomCosts = ipContent.GetPropertyValue(Of String)(nodeProperties.classroomCosts)
                If ipContent.HasValue(nodeProperties.classroomFormat) Then certification.classroomFormat = ipContent.GetPropertyValue(Of String)(nodeProperties.classroomFormat)

                ''Obtain list of all added members as instructors
                'Dim lstMembers As IEnumerable(Of IPublishedContent)
                'If ipContent.HasValue(nodeProperties.classroomInstructors) Then lstMembers = ipContent.GetPropertyValue(Of IEnumerable(Of IPublishedContent))(nodeProperties.classroomInstructors)
                ''Loop thru each id
                'If Not IsNothing(lstMembers) Then
                '    'For Each memberGuid As String In lstGuids
                '    For Each ipMember As IPublishedContent In lstMembers
                '        Dim bReturn As BusinessReturn = blMembers.selectMember_byId(ipMember.Id)
                '        If bReturn.isValid Then certification.lstClassroomInstructors.Add(DirectCast(bReturn.DataContainer(0), DataLayer.Member))
                '    Next
                'End If

                'Obtain list of all added members as instructors
                Dim lstMembers As IEnumerable(Of IPublishedContent)
                If ipContent.HasValue(nodeProperties.classroomInstructors) Then lstMembers = ipContent.GetPropertyValue(Of IEnumerable(Of IPublishedContent))(nodeProperties.classroomInstructors)
                'Loop thru each id
                If Not IsNothing(lstMembers) Then
                    'For Each memberGuid As String In lstGuids
                    For Each ipMember As IPublishedContent In lstMembers
                        Dim ipInstructor = ipMember.GetPropertyValue(Of IPublishedContent)(nodeProperties.trusteeId)
                        Dim bReturn As BusinessReturn = blMembers.selectMember_byId(ipInstructor.Id)
                        Dim member As DataLayer.Member = DirectCast(bReturn.DataContainer(0), DataLayer.Member)
                        member.trusteeUrl = ipMember.Url
                        If bReturn.isValid Then certification.lstClassroomInstructors.Add(member)
                    Next
                End If

            End If

            'Obtain all sponsors
            If ipContent.HasValue(nodeProperties.sponsors) Then
                'For Each sponsorGuid In ipContent.GetPropertyValue(Of String)(nodeProperties.sponsors).Split(",").ToList
                For Each sponsorNode As IPublishedContent In ipContent.GetPropertyValue(Of IEnumerable(Of IPublishedContent))(nodeProperties.sponsors)
                    'Instantiate variables
                    Dim sponsor As New DataLayer.Sponsor
                    'Add data to class
                    sponsor.id = sponsorNode.Id 'getIdFromGuid_byType(sponsorGuid, UmbracoObjectTypes.Document)
                    Try
                        sponsor.logoId = sponsorNode.GetPropertyValue(Of IPublishedContent)(nodeProperties.sponsorLogo).Id
                        sponsor.logoUrl = getMediaURL(sponsor.logoId, crops.SponsorLogo)
                    Catch
                        sponsor.logoId = sponsorNode.GetPropertyValue(Of String)(nodeProperties.sponsorLogo)
                        sponsor.logoUrl = getMediaURL(sponsor.logoId, crops.SponsorLogo)
                    End Try
                    sponsor.name = sponsorNode.Name
                    sponsor.url = sponsorNode.GetPropertyValue(Of String)(nodeProperties.sponsorUrl)
                    'Add class to list
                    certification.lstSponsors.Add(sponsor)
                Next
            End If

            'Obtain all sibling nodes
            For Each sibling As IPublishedContent In ipContent.Parent.Children
                lstSiblings.Add(sibling.Id)
            Next
            index = lstSiblings.IndexOf(ipContent.Id)
            count = lstSiblings.Count - 1

            If index > 0 Then
                'Create entry for previous button
                link = New DataLayer.QuickLink
                link.nodeId = lstSiblings(index - 1)
                link.linkUrl = uHelper.TypedContent(link.nodeId).Url
                certification.previousPage = link
            End If
            If index < count Then
                'Create entry for next button
                link = New DataLayer.QuickLink
                link.nodeId = lstSiblings(index + 1)
                link.linkUrl = uHelper.TypedContent(link.nodeId).Url
                certification.nextPage = link
            End If




            'Save class to return
            businessReturn.DataContainer.Add(certification)

        Catch ex As Exception
            'Save error to umbraco
            Dim sb As New StringBuilder
            sb.AppendLine("linqCertification.vb | obtainCertification()")
            sb.AppendLine("_thisNodeId: " & _thisNodeId)
            SaveErrorMessage(ex, sb, Me.GetType())

            'Return exception
            businessReturn.ExceptionMessage = ex.ToString
        End Try

        Return businessReturn

    End Function
    Public Function obtainListOfCertifications(ByVal thisNodeId As Integer) As BusinessReturn

        'Instantiate master variables
        Dim businessReturn As New BusinessReturn

        Try
            'Instantiate variables
            Dim uHelper As UmbracoHelper = New umbraco.Web.UmbracoHelper(umbraco.Web.UmbracoContext.Current)
            Dim ipListNode As IPublishedContent = uHelper.TypedContent(thisNodeId)
            Dim lstCertifications As New List(Of DataLayer.Certification)

            'Loop thru all certification nodes
            For Each childNode As IPublishedContent In ipListNode.Children
                'Instantiate individual variables for each class
                Dim certification As New DataLayer.Certification


                'Obtain property data
                certification.certificationId = childNode.Id
                If childNode.HasValue(nodeProperties.title) Then certification.certificationTitle = childNode.GetPropertyValue(Of String)(nodeProperties.title)
                certification.certificationUrl = childNode.Url
                certification.shortDescription = childNode.GetPropertyValue(Of String)(nodeProperties.shortDescription)

                If childNode.HasValue(nodeProperties.showClassroomContent) Then certification.showClassroomContent = childNode.GetPropertyValue(Of Boolean)(nodeProperties.showClassroomContent)
                If childNode.HasValue(nodeProperties.showOnlineContent) Then certification.showOnlineContent = childNode.GetPropertyValue(Of Boolean)(nodeProperties.showOnlineContent)

                If childNode.HasValue(nodeProperties.featuredImage) Then
                    certification.featuredImgUrl = getMediaURL(childNode.GetPropertyValue(Of IPublishedContent)(nodeProperties.featuredImage).Id, crops.SideImage)
                    certification.featuredImgName = getMediaName(childNode.GetPropertyValue(Of IPublishedContent)(nodeProperties.featuredImage).Id)
                End If
                If childNode.HasValue(nodeProperties.categories) Then
                    For Each category As String In childNode.GetPropertyValue(Of String)(nodeProperties.categories).Split(",")
                        certification.lstCategories.Add(category)
                    Next
                End If

                'Add certification to list
                lstCertifications.Add(certification)
            Next



            'Save list to return
            businessReturn.DataContainer.Add(lstCertifications)

        Catch ex As Exception
            'Save error to umbraco
            Dim sb As New StringBuilder
            sb.AppendLine("linqCertification.vb | obtainListOfCertifications()")
            sb.AppendLine("thisNodeId: " & thisNodeId)
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
