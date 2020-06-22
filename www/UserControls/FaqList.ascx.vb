Imports Umbraco
Imports Umbraco.NodeFactory
Imports Common


Public Class FaqList
    Inherits System.Web.Mvc.ViewUserControl


#Region "Properties"
    Private blPanels As blPanels
#End Region

#Region "Properties"
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            'Instantiate variables
            blPanels = New blPanels
            Dim businessReturn As BusinessReturn
            Dim lstFAQs As New List(Of DataLayer.FAQ)

            'Obtain data
            businessReturn = blPanels.obtainFaqList(Node.getCurrentNodeId)

            If businessReturn.isValid Then
                'Extract data
                lstFAQs = DirectCast(businessReturn.DataContainer(0), List(Of DataLayer.FAQ))

                'Display Data
                lvFAQs.DataSource = lstFAQs
                lvFAQs.DataBind()

                '====================================================================
                'Dim lstBlogEntry As New List(Of DataLayer.BlogEntry)
                'lstBlogEntry.Add(blogEntry)
                'gv.DataSource = lstFAQs
                'gv.DataBind()
                '====================================================================

            Else
                'pnlEvent.Visible = False
            End If
        Catch ex As Exception
            'Save error to umbraco
            Dim sb As New StringBuilder
            sb.AppendLine("FaqList.ascx | Load()")
            SaveErrorMessage(ex, sb, Me.GetType())

            'pnlEvent.Visible = False
        End Try
    End Sub
#End Region

#Region "Methods"
#End Region
End Class