Imports System.Xml.XPath
Imports Common
Imports Umbraco
Imports Umbraco.NodeFactory

Public Class CertificationList
    Inherits System.Web.Mvc.ViewUserControl



#Region "Properties"
    Private blCertification As blCertification
#End Region


#Region "Handles"
    Private Sub CertificationList_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try
            'Instantiate variables
            blCertification = New blCertification
            Dim businessReturn As BusinessReturn
            Dim lstCertifications As List(Of DataLayer.Certification)

            'Obtain data
            businessReturn = blCertification.obtainListOfCertifications(Node.getCurrentNodeId)

            If businessReturn.isValid Then
                'Extract data
                lstCertifications = DirectCast(businessReturn.DataContainer(0), List(Of DataLayer.Certification))

                'Display Data
                lvCertifications.DataSource = lstCertifications
                lvCertifications.DataBind()

            Else
                'pnlEvent.Visible = False
            End If
        Catch ex As Exception
            'Save error to umbraco
            Dim sb As New StringBuilder
            sb.AppendLine("CertificationList.ascx | Load()")
            SaveErrorMessage(ex, sb, Me.GetType())

            'pnlEvent.Visible = False
        End Try
    End Sub
#End Region


#Region "Methods"
#End Region

End Class
