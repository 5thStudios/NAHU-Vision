Imports Microsoft.VisualBasic


Namespace DataLayer
    Public Class TextBlock
        Public Property nodeId As Integer = 0
        Public Property content As String = String.Empty

        'Public Property displayMacro As Boolean = False
        Public Property showSideNav As Boolean = False
        Public Property showAd As Boolean = False
        Public Property showSideOnRight As Boolean = False
        Public Property isCCDonationPg As Boolean = False
        Public Property isBankDonationPg As Boolean = False



#Region "Handles"
        Public Sub New()
        End Sub
#End Region
    End Class

End Namespace