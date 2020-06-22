Imports Microsoft.VisualBasic
Imports Common
Imports umbraco
Imports umbraco.NodeFactory
Imports System.Data

Public Class blCertification

#Region "Properties"
    Private linqCertification As linqCertification
#End Region

#Region "Selects"
    Public Function obtainCertification(ByVal _thisNodeId As Integer) As BusinessReturn
        'Instantiate variables
        linqCertification = New linqCertification

        'Obtain data
        Return linqCertification.obtainCertification(_thisNodeId)
    End Function
    Public Function obtainListOfCertifications(ByVal _thisNodeId As Integer) As BusinessReturn
        'Instantiate variables
        linqCertification = New linqCertification

        'Obtain data
        Return linqCertification.obtainListOfCertifications(_thisNodeId)
    End Function
#End Region

#Region "Methods"
#End Region
End Class

