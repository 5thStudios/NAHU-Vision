Imports Umbraco
Imports Umbraco.NodeFactory
Imports Common


Public Class CertificationPage
    Inherits System.Web.Mvc.ViewUserControl


#Region "Properties"
    Private blCertification As blCertification
#End Region

#Region "Handles"
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            'Instantiate variables
            blCertification = New blCertification
            Dim businessReturn As BusinessReturn
            Dim certification As DataLayer.Certification

            'Obtain data
            businessReturn = blCertification.obtainCertification(Node.getCurrentNodeId)

            If businessReturn.isValid Then
                'Extract data
                certification = DirectCast(businessReturn.DataContainer(0), DataLayer.Certification)

                'Dim lst As New List(Of DataLayer.Certification)
                'lst.Add(certification)
                'gv2.DataSource = lst
                'gv2.DataBind()

                'Display Data
                ltrlTitle.Text = certification.certificationTitle
                If Not String.IsNullOrEmpty(certification.featuredImgUrl) Then
                    imgFeatured.ImageUrl = certification.featuredImgUrl
                    imgFeatured.AlternateText = certification.featuredImgName
                End If

                ltrlContent_Common.Text = certification.commonContent
                ltrlCourseHighlights.Text = certification.courseHighlights
                ltrlHaveQuestions.Text = certification.haveQuestions

                'Show classroom content
                If certification.showClassroomContent Then
                    hfldClassroom.Value = True
                    ltrlContent_Classroom.Text = certification.classroomContent
                    ltrlCost_Classroom.Text = certification.classroomCosts
                    ltrlFormat_Classroom.Text = certification.classroomFormat

                    lvInstructors_Classroom.DataSource = certification.lstClassroomInstructors
                    lvInstructors_Classroom.DataBind()
                End If

                'Show online content
                If certification.showOnlineContent Then
                    hfldOnline.Value = True
                    ltrlContent_Online.Text = certification.onlineContent
                    ltrlCost_Online.Text = certification.onlineCosts
                    ltrlFormat_Online.Text = certification.onlineFormat

                    'gv.DataSource = certification.lstOnlineInstructors
                    'gv.DataBind()

                    lvInstructors_Online.DataSource = certification.lstOnlineInstructors
                    lvInstructors_Online.DataBind()
                End If

                If Not certification.showOnlineContent AndAlso Not certification.showClassroomContent Then
                    phCosts.Visible = False
                    phFormats.Visible = False
                    phCourseInstructors.Visible = False
                End If

                'Set up navigation pages.
                If Not IsNothing(certification.previousPage) Then
                    hlnkPreviousCourse.NavigateUrl = certification.previousPage.linkUrl
                    hlnkPreviousCourse.Visible = True
                End If
                If Not IsNothing(certification.nextPage) Then
                    hlnkNextCourse.NavigateUrl = certification.nextPage.linkUrl
                    hlnkNextCourse.Visible = True
                End If

                'Add sponsors
                lvSponsors.DataSource = certification.lstSponsors
                lvSponsors.DataBind()


                '====================================================================
                'Dim lstCertification As New List(Of DataLayer.Certification)
                'lstCertification.Add(certification)
                'gv.DataSource = lstCertification
                'gv.DataBind()

                'gv2.DataSource = certification.lstOnlineInstructors
                'gv2.DataBind()

                'gv3.DataSource = certification.lstClassroomInstructors
                'gv3.DataBind()

                'gv.DataSource = certification.lstSponsors
                'gv.DataBind()
                '====================================================================

            Else
                pnlEvent.Visible = False
            End If

            'Add parent page url to back button
            hlnkReturnToList.NavigateUrl = Node.GetCurrent.Parent.NiceUrl
            hlnkReturnToList_Mbl.NavigateUrl = Node.GetCurrent.Parent.NiceUrl
        Catch ex As Exception
            'Save error to umbraco
            Dim sb As New StringBuilder
            sb.AppendLine("EventPage.ascx | Load()")
            SaveErrorMessage(ex, sb, Me.GetType())

            pnlEvent.Visible = False
        End Try
    End Sub
#End Region

#Region "Methods"
#End Region


End Class