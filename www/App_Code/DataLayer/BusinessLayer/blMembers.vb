Imports System.Data
Imports Common
Imports umbraco
Imports umbraco.NodeFactory
Imports umbraco.Core
Imports umbraco.Core.Models
Imports umbraco.Core.Services
Imports umbraco.Core.Publishing
Imports System.Xml.XPath

Public Class blMembers

#Region "Properties"
    Private linqMembers As linqMembers
#End Region


#Region "Selects"
    Public Function selectMember_byId(ByVal _memberId As Integer) As BusinessReturn
        'Instantiate variables
        linqMembers = New linqMembers

        'Obtain data
        Return linqMembers.selectMember_byId(_memberId)
    End Function
    Public Function selectMemberAsTrustee_byId(ByVal _memberId As Integer) As BusinessReturn
        'Instantiate variables
        linqMembers = New linqMembers

        'Obtain data
        Return linqMembers.selectMemberAsTrustee_byId(_memberId)
    End Function
    Public Function selectTrusteesList(ByVal _thisNodeId As Integer) As BusinessReturn
        'Instantiate variables
        linqMembers = New linqMembers

        'Obtain data
        Return linqMembers.selectTrusteesList(_thisNodeId)
    End Function
#End Region

#Region "Insert"
#End Region

#Region "Updates"
#End Region

#Region "Delete"
#End Region

#Region "Methods"
#End Region

#Region "Validations"
#End Region
End Class
