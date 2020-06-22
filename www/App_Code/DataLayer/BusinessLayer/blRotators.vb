Imports Microsoft.VisualBasic
Imports Common
Imports umbraco
Imports umbraco.NodeFactory
Imports System.Data

Public Class blRotators

#Region "Properties"
    Private linqRotators As linqRotators
#End Region


#Region "Selects"
    Public Function obtainListOfRotators(ByVal _thisNodeId As Integer) As BusinessReturn
        'Instantiate variables
        linqRotators = New linqRotators

        'Obtain rotator list
        Return linqRotators.obtainListOfRotators(_thisNodeId)
    End Function
#End Region

#Region "Methods"
#End Region
End Class

