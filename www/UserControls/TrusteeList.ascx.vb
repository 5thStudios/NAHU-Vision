Imports Umbraco
Imports Umbraco.NodeFactory
Imports Common


Public Class TrusteeList
    Inherits System.Web.Mvc.ViewUserControl


#Region "Properties"
    Private blMembers As blMembers
#End Region

#Region "Handles"
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            'Instantiate variables
            blMembers = New blMembers
            Dim businessReturn As BusinessReturn
            Dim lstMember As List(Of DataLayer.Member)

            'Obtain data
            businessReturn = blMembers.selectTrusteesList(Node.getCurrentNodeId)

            If businessReturn.isValid Then
                'Extract data
                lstMember = DirectCast(businessReturn.DataContainer(0), List(Of DataLayer.Member))

                '
                lvTrustees.DataSource = lstMember
                lvTrustees.DataBind()

                '====================================================================
                'Dim lstMember As New List(Of DataLayer.Member)
                'lstMember.Add(member)
                'gv.DataSource = lstMember
                'gv.DataBind()
                '====================================================================

            Else
                'Response.Redirect(thisNode.Parent.NiceUrl, True)
            End If
        Catch ex As Exception
            'Save error to umbraco
            Dim sb As New StringBuilder
            sb.AppendLine("TrusteeList.ascx | Load()")
            SaveErrorMessage(ex, sb, Me.GetType())

        End Try
    End Sub
#End Region

#Region "Methods"
#End Region

End Class