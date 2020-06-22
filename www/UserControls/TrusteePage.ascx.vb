Imports Umbraco
Imports Umbraco.NodeFactory
Imports Common


Public Class TrusteePage
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
            Dim member As DataLayer.Member
            Dim thisNode As Node = Node.GetCurrent

            'Obtain data
            businessReturn = blMembers.selectMemberAsTrustee_byId(getIdFromGuid_byType(thisNode.GetProperty(nodeProperties.trusteeId).Value, Core.Models.UmbracoObjectTypes.Member))

            If businessReturn.isValid Then
                'Extract data
                member = DirectCast(businessReturn.DataContainer(0), DataLayer.Member)

                'If not a trustee, redirect to parent list page.
                If Not member.isATrustee Then Response.Redirect(thisNode.Parent.NiceUrl, True)

                'Display Data
                ltrlName.Text = member.firstName & " " & member.lastName
                ltrlTitle.Text = member.title
                imgTrustee.ImageUrl = member.photoUrl
                imgTrustee.AlternateText = member.firstName & " " & member.lastName
                ltrlSummary.Text = member.summary
                If thisNode.Parent.HasProperty(nodeProperties.sb_title) Then ltrlPgTitle.Text = thisNode.Parent.GetProperty(nodeProperties.sb_title).Value
                hlnkAllTrustees.Text += ltrlPgTitle.Text

                hlnkAllTrustees.NavigateUrl = thisNode.Parent.NiceUrl

                '====================================================================
                'Dim lstMember As New List(Of DataLayer.Member)
                'lstMember.Add(member)
                'gv.DataSource = lstMember
                'gv.DataBind()
                '====================================================================

            Else
                Response.Redirect(thisNode.Parent.NiceUrl, True)
            End If
        Catch ex As Exception
            'Save error to umbraco
            Dim sb As New StringBuilder
            sb.AppendLine("TrusteePage.ascx | Load()")
            SaveErrorMessage(ex, sb, Me.GetType())

            'pnlEvent.Visible = False
        End Try
    End Sub
#End Region

#Region "Methods"
#End Region

End Class