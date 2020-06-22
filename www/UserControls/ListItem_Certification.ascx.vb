Imports Umbraco
Imports Umbraco.NodeFactory
Imports Common
Imports Newtonsoft.Json

Public Class ListItem_Certification
    Inherits System.Web.UI.UserControl


#Region "Properties"
    Public Property Certification As DataLayer.Certification
#End Region


#Region "Handles"
    Private Sub ListItem_Certification_Load(sender As Object, e As EventArgs) Handles Me.Load
        '
        If IsNothing(Certification) Then
            pnlCertification.Visible = False
        Else
            'Instantiate variables
            Dim isFirstRecord As Boolean = True

            'Populate data
            ltrlTitle.Text = Certification.certificationTitle
            imgFeatured.ImageUrl = Certification.featuredImgUrl
            imgFeatured.AlternateText = Certification.featuredImgName
            hlnkReadMore.NavigateUrl = Certification.certificationUrl
            ltrlDescription.Text = Certification.shortDescription
            pnlCertification.Attributes.Add("data-certificationId", Certification.certificationId)

            'Show what type of classes are abailable
            If Certification.showClassroomContent AndAlso Certification.showOnlineContent Then
                ltrlClassType.Text = "Online&nbsp;&nbsp;|&nbsp;&nbsp;Classroom"
            ElseIf Certification.showClassroomContent Then
                ltrlClassType.Text = "Classroom"
            ElseIf Certification.showOnlineContent Then
                ltrlClassType.Text = "Online"
            End If

            'categories
            For Each category As String In Certification.lstCategories
                'Add spacer between tag
                If isFirstRecord Then
                    isFirstRecord = False
                Else
                    ltrlCategories.Text += "&nbsp;&nbsp;&nbsp;|&nbsp;&nbsp;&nbsp;"
                End If

                ltrlCategories.Text += category
            Next
        End If
    End Sub
#End Region


#Region "Methods"
#End Region

End Class