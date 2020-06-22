Imports Umbraco
Imports Umbraco.NodeFactory
Imports Umbraco.Core
Imports Umbraco.Core.Models
Imports Umbraco.Core.Services
Imports Common
Imports Umbraco.Web
Imports Umbraco.Web.Templates
Imports Umbraco.Web.Routing

Public Class linqMembers

#Region "Properties"
    Dim memberShipHelper As Umbraco.Web.Security.MembershipHelper = New Umbraco.Web.Security.MembershipHelper(Umbraco.Web.UmbracoContext.Current)
#End Region

#Region "Selects"
    Public Function selectMember_byId(ByVal _memberId As Integer) As BusinessReturn
        'Instantiate master variables
        Dim businessReturn As New BusinessReturn

        Try
            'Instantiate variables
            Dim imember As IMember
            Dim member As New DataLayer.Member

            'Obtain property data
            imember = ApplicationContext.Current.Services.MemberService.GetById(_memberId)
            member.memberId = _memberId
            If imember.HasProperty(nodeProperties.email) Then member.email = imember.GetValue(Of String)(nodeProperties.email)
            If imember.HasProperty(nodeProperties.firstName) Then member.firstName = imember.GetValue(Of String)(nodeProperties.firstName)
            If imember.HasProperty(nodeProperties.lastName) Then member.lastName = imember.GetValue(Of String)(nodeProperties.lastName)
            If imember.HasProperty(nodeProperties.phoneNumber) Then member.phoneNumber = imember.GetValue(Of String)(nodeProperties.phoneNumber)
            If imember.HasProperty(nodeProperties.phoneExtension) Then member.phoneExtension = imember.GetValue(Of String)(nodeProperties.phoneExtension)
            If imember.HasProperty(nodeProperties.photo) Then
                Try
                    member.photoUrl = getMediaURL(imember.GetValue(Of IPublishedContent)(nodeProperties.photo).Id, crops.InstructorSquared)
                Catch ex As Exception
                    member.photoUrl = getMediaURL(imember.GetValue(Of String)(nodeProperties.photo), crops.InstructorSquared)
                End Try
            End If

            If imember.HasProperty(nodeProperties.isATrustee) Then member.isATrustee = imember.GetValue(Of Boolean)(nodeProperties.isATrustee)
            If imember.HasProperty(nodeProperties.title) Then member.title = imember.GetValue(Of String)(nodeProperties.title)
            If imember.HasProperty(nodeProperties.summary) Then member.summary = imember.GetValue(Of String)(nodeProperties.summary)

            'Save class to return
            businessReturn.DataContainer.Add(member)

        Catch ex As Exception
            'Save error to umbraco
            Dim sb As New StringBuilder
            sb.AppendLine("linqMembers.vb | obtainMember_byId()")
            sb.AppendLine("_memberId: " & _memberId)
            SaveErrorMessage(ex, sb, Me.GetType())

            'Return exception
            businessReturn.ExceptionMessage = ex.ToString
        End Try

        Return businessReturn

    End Function
    Public Function selectMemberAsTrustee_byId(ByVal _memberId As Integer) As BusinessReturn
        'Instantiate master variables
        Dim businessReturn As New BusinessReturn

        Try
            'Instantiate variables
            Dim imember As IMember
            Dim member As New DataLayer.Member

            'Obtain property data
            imember = ApplicationContext.Current.Services.MemberService.GetById(_memberId)
            member.memberId = _memberId
            If imember.HasProperty(nodeProperties.isATrustee) Then member.isATrustee = imember.GetValue(Of Boolean)(nodeProperties.isATrustee)
            If imember.HasProperty(nodeProperties.firstName) Then member.firstName = imember.GetValue(Of String)(nodeProperties.firstName)
            If imember.HasProperty(nodeProperties.lastName) Then member.lastName = imember.GetValue(Of String)(nodeProperties.lastName)
            If imember.HasProperty(nodeProperties.title) Then member.title = imember.GetValue(Of String)(nodeProperties.title)
            If imember.HasProperty(nodeProperties.photo) Then
                Try
                    member.photoUrl = getMediaURL(imember.GetValue(Of String)(nodeProperties.photo), crops.SideImage)
                Catch ex As Exception
                    member.photoUrl = getMediaURL(imember.GetValue(Of IPublishedContent)(nodeProperties.photo).Id, crops.SideImage)
                End Try

            End If
            If imember.HasProperty(nodeProperties.summary) Then
                member.summary = imember.GetValue(Of String)(nodeProperties.summary)
                member.summary = TemplateUtilities.ParseInternalLinks(member.summary)
                'Dim urlprovider As UrlProvider = New UrlProvider(??)
                'member.summary = TemplateUtilities.ParseInternalLinks(member.summary, urlprovider)
            End If

            'Save class to return
            businessReturn.DataContainer.Add(member)

        Catch ex As Exception
            'Save error to umbraco
            Dim sb As New StringBuilder
            sb.AppendLine("linqMembers.vb | selectMemberAsTrustee_byId()")
            sb.AppendLine("_memberId: " & _memberId)
            SaveErrorMessage(ex, sb, Me.GetType())

            'Return exception
            businessReturn.ExceptionMessage = ex.ToString
        End Try

        Return businessReturn
    End Function
    Public Function selectTrusteesList(ByVal _thisNodeId As Integer) As BusinessReturn
        'Instantiate master variables
        Dim businessReturn As New BusinessReturn

        Try
            'Instantiate variables
            Dim uHelper As UmbracoHelper = New umbraco.Web.UmbracoHelper(umbraco.Web.UmbracoContext.Current)
            Dim ipContent As IPublishedContent = uHelper.TypedContent(_thisNodeId)
            Dim imember As IMember
            Dim member As DataLayer.Member
            Dim lstMembers As New List(Of DataLayer.Member)
            Dim memberId As Integer?


            '
            For Each childNode As IPublishedContent In ipContent.Children
                'Obtain member id
                'memberId = getIdFromGuid_byType(childNode.GetPropertyValue(Of String)(nodeProperties.trusteeId), Core.Models.UmbracoObjectTypes.Member)
                memberId = childNode.GetPropertyValue(Of IPublishedContent)(nodeProperties.trusteeId).Id


                'Dim sb As New StringBuilder
                'sb.AppendLine("TEST linqMembers.vb | selectTrusteesList()")
                'sb.AppendLine("memberId: " & memberId)
                'sb.AppendLine("alt memberId: " & childNode.GetPropertyValue(Of IPublishedContent)(nodeProperties.trusteeId).Id)
                'sb.AppendLine("member name: " & childNode.GetPropertyValue(Of IPublishedContent)(nodeProperties.trusteeId).Name)
                'sb.AppendLine("ipContent: " & ipContent.Id & " | " & ipContent.Name)
                'sb.AppendLine("children count: " & ipContent.Children.Count)
                'saveErrorMessage(sb.ToString, sb.ToString)
                'Exit For

                If Not IsNothing(memberId) Then
                    'Obtain imember
                    imember = ApplicationContext.Current.Services.MemberService.GetById(memberId)

                    'If not a trustee, skip person
                    If Not imember.GetValue(Of Boolean)(nodeProperties.isATrustee) Then
                        Continue For
                    Else
                        'Create new member class
                        member = New DataLayer.Member
                        'Obtain data
                        member.memberId = memberId
                        member.trusteeUrl = childNode.Url
                        If imember.HasProperty(nodeProperties.firstName) Then member.firstName = imember.GetValue(Of String)(nodeProperties.firstName)
                        If imember.HasProperty(nodeProperties.lastName) Then member.lastName = imember.GetValue(Of String)(nodeProperties.lastName)
                        If imember.HasProperty(nodeProperties.title) Then member.title = imember.GetValue(Of String)(nodeProperties.title)
                        If imember.HasProperty(nodeProperties.photo) Then
                            Try
                                member.photoUrl = getMediaURL(imember.GetValue(Of IPublishedContent)(nodeProperties.photo).Id, crops.ListItemSquared)
                            Catch ex As Exception
                                member.photoUrl = getMediaURL(imember.GetValue(Of String)(nodeProperties.photo), crops.ListItemSquared)
                            End Try
                        End If

                        'Add member to list
                        lstMembers.Add(member)
                    End If
                End If
            Next

            'Save class to return
            businessReturn.DataContainer.Add(lstMembers)

        Catch ex As Exception
            'Save error to umbraco
            Dim sb As New StringBuilder
            sb.AppendLine("linqMembers.vb | selectTrusteesList()")
            sb.AppendLine("_thisNodeId: " & _thisNodeId)
            SaveErrorMessage(ex, sb, Me.GetType())

            'Return exception
            businessReturn.ExceptionMessage = ex.ToString
        End Try

        Return businessReturn
    End Function
#End Region

#Region "Inserts"
#End Region

#Region "Updates"
#End Region

#Region "Delete"
#End Region

#Region "Methods"
#End Region

End Class

