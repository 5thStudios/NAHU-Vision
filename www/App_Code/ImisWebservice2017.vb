Imports System.Web
Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports System.ComponentModel
Imports System.Web.Script.Services
Imports Newtonsoft.Json
Imports System.Net.Mime.MediaTypeNames
'Imports mvcvb.org.nahu.sso
Imports umbraco
Imports umbraco.NodeFactory
Imports Common
Imports System.Net
Imports Microsoft.Ajax.Utilities
Imports org.nahu.imis2017
Imports umbraco.cms.businesslogic
Imports umbraco.Core.Services
Imports umbraco.Core
Imports umbraco.Core.Models
Imports org.nahu.members
Imports umbraco.editorControls.userControlGrapper
Imports System.Xml


' To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line.
<ScriptService()>
<WebService(Namespace:="http://tempuri.org/")>
<WebServiceBinding(ConformsTo:=WsiProfiles.BasicProfile1_1)>
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Public Class ImisWebservice2017
    Inherits WebService



    <WebMethod()>
    <ScriptMethod(ResponseFormat:=ResponseFormat.Json)>
    Public Function Login(ByVal userId As String, ByVal password As String) As String
        'Instantiate variables
        'Dim sso = New mvcvb.org.nahu.sso.SSO
        Dim sso = New org.nahu.imis2017.SSO
        Dim applicationInstance = "1"
        Dim _rememberMe As Boolean = False

        'Validate user and obtain result
        Dim result As org.nahu.imis2017.ValidationWrapper = sso.ValidateLogOn(applicationInstance, userId, password, GetIPv4Address, _rememberMe)

        'Return result in json format.
        Return JsonConvert.SerializeObject(result)
        'Return JsonConvert.SerializeObject("['test','test']")
    End Function
    '<WebMethod()>
    '<ScriptMethod(ResponseFormat:=ResponseFormat.Json)>
    'Public Function Login_BoardMember(ByVal userId As String, ByVal password As String) As String
    '    '=========================================================
    '    'Board of trustees- Login
    '    '-------------------------
    '    'On click [jq]
    '    '	submit id/pw to function [jq]
    '    '		valid id/pw
    '    '			true
    '    '				run logBoardMemberByProxy()
    '    '				return valid
    '    '               refresh page [jq]
    '    '			false
    '    '				return invalid
    '    '               display error msg [jq]
    '    '=========================================================

    '    'Instantiate variables
    '    Dim tempId As String = "abc"
    '    Dim tempPw As String = "123"
    '    Dim validBoardmember As Boolean = True

    '    'Compare credentials
    '    If Not tempId.Equals(userId) Then validBoardmember = False
    '    If Not tempPw.Equals(password) Then validBoardmember = False

    '    'Is credentials valid?
    '    If validBoardmember Then
    '        'Log board member in
    '        logBoardMemberByProxy()
    '    End If

    '    'Add response to collection
    '    Dim dict As New Dictionary(Of String, Boolean)
    '    dict.Add("IsValidated", validBoardmember)

    '    'Return in JSON format
    '    Return JsonConvert.SerializeObject(dict)
    'End Function

    <WebMethod()>
    <ScriptMethod(ResponseFormat:=ResponseFormat.Json)>
    Public Function Login_BoardMember(ByVal userId As String, ByVal password As String) As String
        '=========================================================
        'Board of trustees- Login
        '-------------------------
        'On click [jq]
        '	submit id/pw to function [jq]
        '		valid id/pw
        '			true
        '				run logBoardMemberByProxy()
        '				return valid
        '               refresh page [jq]
        '			false
        '				return invalid
        '               display error msg [jq]
        '=========================================================

        'Instantiate variables
        Dim boardMemberId As String = ConfigurationManager.AppSettings(miscellaneous.boardMemberId)
        Dim boardMemberPw As String = ConfigurationManager.AppSettings(miscellaneous.boardMemberPw)
        Dim validBoardmember As Boolean = True

        'Compare credentials
        If Not boardMemberId.Equals(userId) Then validBoardmember = False
        If Not boardMemberPw.Equals(password) Then validBoardmember = False

        'Is credentials valid?
        If validBoardmember Then
            'Log board member in
            logBoardMemberByProxy()
        End If

        'Add response to collection
        Dim dict As New Dictionary(Of String, Boolean)
        dict.Add("IsValidated", validBoardmember)

        'Return in JSON format
        Return JsonConvert.SerializeObject(dict)
    End Function

    <WebMethod()>
    <ScriptMethod(ResponseFormat:=ResponseFormat.Json)>
    Public Function IsUserLoggedIn(ByVal userToken As String) As String  'ByVal loginGuid As String
        'Instantiate variables
        'Dim sso = New mvcvb.org.nahu.sso.SSO
        Dim sso = New org.nahu.imis2017.SSO
        Dim applicationInstance = "1"
        Dim userTokenGuid As Guid

        If Guid.TryParse(userToken, userTokenGuid) Then
            Return JsonConvert.SerializeObject(sso.ValidateSession(applicationInstance, userTokenGuid.ToString))
        Else
            Return "Invalid conversion of guid: " & userToken
        End If
    End Function
    <WebMethod()>
    <ScriptMethod(ResponseFormat:=ResponseFormat.Json)>
    Public Function FetchUserInfo(ByVal userToken As String) As String
        'Instantiate variables
        Dim sso = New org.nahu.imis2017.SSO
        Dim applicationInstance = "1"
        Dim userTokenGuid As Guid

        If Guid.TryParse(userToken, userTokenGuid) Then
            Try
                'Obtain user data from Imis
                Dim UserContainer As SSOUserContainer = sso.FetchUserInfo(applicationInstance, userTokenGuid.ToString)

                'Convert data to class usable by NAHUvision project and pass to controller
                Dim imisUserInfo As NAHUvision.Models.ImisUserInfo = New NAHUvision.Models.ImisUserInfo()
                imisUserInfo.WebLogin = UserContainer.WebLogin
                imisUserInfo.FirstName = UserContainer.FirstName
                imisUserInfo.LastName = UserContainer.LastName
                imisUserInfo.FullName = UserContainer.FullName
                imisUserInfo.WorkPhone = UserContainer.WorkPhone
                imisUserInfo.EmailAddress = UserContainer.EmailAddress
                imisUserInfo.MemberType = UserContainer.MemberType
                imisUserInfo.ImisId = UserContainer.ImisId

                'Obtain the chapter
                Dim xmlTxt = "<root>" + UserContainer.ExtensionData.InnerXml + "</root>"
                Dim xdoc As XDocument = XDocument.Parse(xmlTxt)
                Dim root As XElement = xdoc.Root
                imisUserInfo.Chapter = root.Element("Chapter").Value

                NAHUvision.Controller.MemberController.SaveMemberData(imisUserInfo)

                Return JsonConvert.SerializeObject(imisUserInfo)
                'Return JsonConvert.SerializeObject(UserContainer) 'USE FOR TESTING INCOMING DATA

            Catch ex As Exception
                'Save error to umbraco
                Dim sb As New StringBuilder
                sb.AppendLine("ImisWebservice2017.vb | FetchUserInfo()")
                sb.AppendLine("userToken: " & userToken)
                SaveErrorMessage(ex, sb, Me.GetType())

                Return "Error retrieving data on user from IMIS.  Error saved in log."
            End Try

        Else
            Return "Invalid conversion of guid: " & userToken
        End If
    End Function
    <WebMethod()>
    <ScriptMethod(ResponseFormat:=ResponseFormat.Json)>
    Public Function DisposeSession(ByVal userToken As String) As String
        'Instantiate variables
        'Dim sso = New mvcvb.org.nahu.sso.SSO
        Dim sso = New org.nahu.imis2017.SSO
        Dim applicationInstance = "1"
        Dim userTokenGuid As Guid

        If Guid.TryParse(userToken, userTokenGuid) Then
            Return JsonConvert.SerializeObject(sso.DisposeSessionByUserToken(applicationInstance, userTokenGuid.ToString))
        Else
            Return "Invalid conversion of guid: " & userToken
        End If
    End Function
    <WebMethod()>
    <ScriptMethod(ResponseFormat:=ResponseFormat.Json)>
    Public Function RecoverPassword(ByVal userId As String) As String
        Try
            'If userId.Trim.Length > 0 Then
            '    'Instantiate variables
            '    'Dim membership = New mvcvb.org.nahu.members.MembershipWebService
            '    Dim membership As org.nahu.members.MembershipWebService
            '    Dim sso = New org.nahu.imis2017.UserContainer


            '    'Submit request for password reset
            '    membership.RequestPasswordReset(userId, userId, "Password Reset Request", New Node(siteNodes.Home).NiceUrl)
            '    Return JsonConvert.SerializeObject(True)
            'Else
            '    Return JsonConvert.SerializeObject(False)
            'End If
        Catch ex As Exception
            Return JsonConvert.SerializeObject(False)
        End Try
    End Function
    Private Function GetIPv4Address() As String
        GetIPv4Address = String.Empty
        Dim strHostName As String = System.Net.Dns.GetHostName()
        Dim iphe As System.Net.IPHostEntry = System.Net.Dns.GetHostEntry(strHostName)

        For Each ipheal As System.Net.IPAddress In iphe.AddressList
            If ipheal.AddressFamily = System.Net.Sockets.AddressFamily.InterNetwork Then
                GetIPv4Address = ipheal.ToString()
            End If
        Next
    End Function


    <WebMethod()>
    <ScriptMethod(ResponseFormat:=ResponseFormat.Json)>
    Public Function bankContribution(ByVal userToken As String) As String
        Try
            'Instantiate variables
            'Dim sso = New org.nahu.imis2017.SSO
            'Dim imisDC As New dbImisDataContext
            'Dim ibcPerson As ibc_nahu_GetPersonResult
            'Dim loginCredentials_bank As loginCredentials_bank

            'Obtain user
            'ibcPerson = imisDC.ibc_nahu_GetPerson(userId).FirstOrDefault
            'If IsNothing(ibcPerson) Then
            '    Return String.Empty
            'ElseIf ibcPerson.ID = 0 Then
            '    Return String.Empty
            'Else

            'Instantiate variables
            Dim sso = New org.nahu.imis2017.SSO
            Dim applicationInstance = "1"
            Dim userTokenGuid As Guid
            Dim UserContainer As SSOUserContainer
            Dim userFetched As Boolean = False

            If Guid.TryParse(userToken, userTokenGuid) Then
                'Obtain user data from Imis
                UserContainer = sso.FetchUserInfo(applicationInstance, userTokenGuid.ToString)
            End If

            If IsNothing(UserContainer) Then
                Return String.Empty
            ElseIf UserContainer.ImisId <= 0 Then
                Return String.Empty
            Else
                Dim loginCredentials_bank As loginCredentials_bank = New loginCredentials_bank
                loginCredentials_bank.m_StatusCode = 200
                loginCredentials_bank.m_Uri = ConfigurationManager.AppSettings(miscellaneous.bankDonationUrl)

                'Return result In json format.
                Return JsonConvert.SerializeObject(loginCredentials_bank)
            End If
        Catch ex As Exception
            'Return exception in json format
            Dim dict = New Dictionary(Of Int16, String)
            dict.Add(1, userToken)
            dict.Add(2, ex.Message)
            Return Newtonsoft.Json.JsonConvert.SerializeObject(dict)

            'Return Newtonsoft.Json.JsonConvert.SerializeObject(ex)
        End Try
    End Function

    '<WebMethod()>
    '<ScriptMethod(ResponseFormat:=ResponseFormat.Json)>
    'Public Function bankContribution(ByVal userId As String) As String
    '    Try
    '        'Instantiate variables
    '        'Dim sso = New org.nahu.imis2017.SSO
    '        Dim imisDC As New dbImisDataContext
    '        Dim ibcPerson As ibc_nahu_GetPersonResult
    '        Dim loginCredentials_bank As loginCredentials_bank

    '        'Obtain user
    '        ibcPerson = imisDC.ibc_nahu_GetPerson(userId).FirstOrDefault
    '        If IsNothing(ibcPerson) Then
    '            Return String.Empty
    '        ElseIf ibcPerson.ID = 0 Then
    '            Return String.Empty
    '        Else


    '            loginCredentials_bank = New loginCredentials_bank
    '            loginCredentials_bank.m_StatusCode = 200
    '            loginCredentials_bank.m_Uri = ConfigurationManager.AppSettings(miscellaneous.bankDonationUrl)


    '            'Return result In json format.
    '            Return JsonConvert.SerializeObject(loginCredentials_bank)
    '        End If
    '    Catch ex As Exception
    '        'Return exception in json format
    '        Return Newtonsoft.Json.JsonConvert.SerializeObject(ex)
    '    End Try
    'End Function

    <WebMethod()>
    <ScriptMethod(ResponseFormat:=ResponseFormat.Json)>
    Public Function ccContribution(ByVal userToken As String) As String
        Try
            'Instantiate variables
            Dim webRequest As HttpWebRequest = HttpWebRequest.Create("https://app1.vocusgr.com/Custom/SSO/NAHU.aspx?SiteName=NAHU")
            Dim encode As UTF8Encoding = New System.Text.UTF8Encoding()
            Dim postdataBytes As Byte()
            Dim sb As New StringBuilder

            '============================================================================================
            'Instantiate variables
            Dim sso = New org.nahu.imis2017.SSO
            Dim applicationInstance = "1"
            Dim userTokenGuid As Guid
            Dim UserContainer As SSOUserContainer
            Dim userFetched As Boolean = False

            If Guid.TryParse(userToken, userTokenGuid) Then
                'Obtain user data from Imis
                UserContainer = sso.FetchUserInfo(applicationInstance, userTokenGuid.ToString)
                userFetched = True
            Else
                Return "Invalid conversion of guid: " & userToken
            End If
            '============================================================================================

            If userFetched Then
                'Instantiate login credential class.  [primarily used for debugging and giving credentials a structure.]
                Dim loginCred As New loginCredentials

                loginCred.IndividualLogin_PassPhrase = "VocusToNAHU"
                'loginCred.IndividualLogin_UserName = UserContainer.WebLogin
                loginCred.IndividualLogin_UserName = UserContainer.ImisId
                loginCred.IndividualLogin_CompanyName = UserContainer.CompanyName
                loginCred.IndividualLogin_Email = UserContainer.EmailAddress
                loginCred.IndividualLogin_FirstName = UserContainer.FirstName
                loginCred.IndividualLogin_LastName = UserContainer.LastName
                loginCred.IndividualLogin_Phone = UserContainer.WorkPhone

                'Obtain the xml portion of the data
                Dim xmlTxt = "<root>" + UserContainer.ExtensionData.InnerXml + "</root>"
                Dim xdoc As XDocument = XDocument.Parse(xmlTxt)
                Dim root As XElement = xdoc.Root

                loginCred.IndividualLogin_AddressLine1 = root.Element("ADDRESS_1").Value
                loginCred.IndividualLogin_AddressLine2 = root.Element("ADDRESS_2").Value
                loginCred.IndividualLogin_City = root.Element("CITY").Value
                loginCred.IndividualLogin_State = root.Element("STATE_PROVINCE").Value
                'loginCred.IndividualLogin_Zip = "20005" 'root.Element("").Value

                'Build querystring
                sb.Append("&IndividualLogin_UserName=" & loginCred.IndividualLogin_UserName & "&")
                sb.Append("IndividualLogin_PassPhrase=" & loginCred.IndividualLogin_PassPhrase & "&")
                sb.Append("IndividualLogin_CompanyName=" & loginCred.IndividualLogin_CompanyName & "&")
                sb.Append("IndividualLogin_FirstName=" & loginCred.IndividualLogin_FirstName & "&")
                sb.Append("IndividualLogin_LastName=" & loginCred.IndividualLogin_LastName & "&")
                sb.Append("IndividualLogin_AddressLine1=" & loginCred.IndividualLogin_AddressLine1 & "&")
                sb.Append("IndividualLogin_AddressLine2=" & loginCred.IndividualLogin_AddressLine2 & "&")
                sb.Append("IndividualLogin_City=" & loginCred.IndividualLogin_City & "&")
                sb.Append("IndividualLogin_State=" & loginCred.IndividualLogin_State & "&")
                'sb.Append("IndividualLogin_Zip=" & loginCred.IndividualLogin_Zip & "&")
                sb.Append("IndividualLogin_Phone=" & loginCred.IndividualLogin_Phone & "&")
                sb.Append("IndividualLogin_Email=" & loginCred.IndividualLogin_Email)

                'convert querystring into bytes
                postdataBytes = encode.GetBytes(sb.ToString)

                'Create POST request
                webRequest.Method = "POST"
                webRequest.ContentType = "application/x-www-form-urlencoded"
                webRequest.ContentLength = postdataBytes.Length
                Using stream = webRequest.GetRequestStream()
                    stream.Write(postdataBytes, 0, postdataBytes.Length)
                End Using

                'Obtain result from request
                Dim result As HttpWebResponse = webRequest.GetResponse()

                'Return result In json format.
                Return JsonConvert.SerializeObject(result)

                'Return JsonConvert.SerializeObject(loginCred)
                'Return JsonConvert.SerializeObject(UserContainer)
                'Dim dict = New Dictionary(Of Int16, String)
                'dict.Add(1, sb.ToString)
                'Return Newtonsoft.Json.JsonConvert.SerializeObject(dict)
            End If
        Catch ex As Exception
            'Return exception in json format
            Dim dict = New Dictionary(Of Int16, String)
            dict.Add(1, userToken)
            dict.Add(2, ex.Message)
            Return Newtonsoft.Json.JsonConvert.SerializeObject(dict)
            'Return Newtonsoft.Json.JsonConvert.SerializeObject(ex)
        End Try
    End Function

    '<WebMethod()>
    '<ScriptMethod(ResponseFormat:=ResponseFormat.Json)>
    'Public Function ccContribution(ByVal userId As String) As String
    '    Try
    '        'Instantiate variables
    '        Dim webRequest As HttpWebRequest = HttpWebRequest.Create("https://app1.vocusgr.com/Custom/SSO/NAHU.aspx?SiteName=NAHU")
    '        Dim encode As UTF8Encoding = New System.Text.UTF8Encoding()
    '        Dim postdataBytes As Byte()
    '        Dim sb As New StringBuilder
    '        Dim imisDC As New dbImisDataContext
    '        Dim ibcPerson As ibc_nahu_GetPersonResult

    '        'Obtain user
    '        ibcPerson = imisDC.ibc_nahu_GetPerson(userId).FirstOrDefault

    '        If IsNothing(ibcPerson) Then
    '            Return String.Empty
    '        ElseIf ibcPerson.ID = 0 Then
    '            Return String.Empty
    '        Else
    '            'Instantiate login credential class.  [primarily used for debugging and giving credentials a structure.]
    '            Dim loginCred As New loginCredentials
    '            loginCred.IndividualLogin_AddressLine1 = ibcPerson.ADDRESS_1
    '            loginCred.IndividualLogin_AddressLine2 = ibcPerson.ADDRESS_2
    '            loginCred.IndividualLogin_City = ibcPerson.CITY
    '            loginCred.IndividualLogin_CompanyName = ibcPerson.COMPANY
    '            loginCred.IndividualLogin_Email = ibcPerson.EMAIL
    '            loginCred.IndividualLogin_FirstName = ibcPerson.FIRST_NAME
    '            loginCred.IndividualLogin_LastName = ibcPerson.LAST_NAME
    '            loginCred.IndividualLogin_PassPhrase = "VocusToNAHU"
    '            loginCred.IndividualLogin_Phone = ibcPerson.HOME_PHONE
    '            loginCred.IndividualLogin_State = ibcPerson.STATE_PROVINCE
    '            loginCred.IndividualLogin_UserName = ibcPerson.ID
    '            loginCred.IndividualLogin_Zip = ibcPerson.ZIP
    '            'Return JsonConvert.SerializeObject(loginCred)

    '            'Build querystring
    '            sb.Append("&IndividualLogin_UserName=" & loginCred.IndividualLogin_UserName & "&")
    '            sb.Append("IndividualLogin_PassPhrase=" & loginCred.IndividualLogin_PassPhrase & "&")
    '            sb.Append("IndividualLogin_CompanyName=" & loginCred.IndividualLogin_CompanyName & "&")
    '            sb.Append("IndividualLogin_FirstName=" & loginCred.IndividualLogin_FirstName & "&")
    '            sb.Append("IndividualLogin_LastName=" & loginCred.IndividualLogin_LastName & "&")
    '            sb.Append("IndividualLogin_AddressLine1=" & loginCred.IndividualLogin_AddressLine1 & "&")
    '            sb.Append("IndividualLogin_AddressLine2=" & loginCred.IndividualLogin_AddressLine2 & "&")
    '            sb.Append("IndividualLogin_City=" & loginCred.IndividualLogin_City & "&")
    '            sb.Append("IndividualLogin_State=" & loginCred.IndividualLogin_State & "&")
    '            sb.Append("IndividualLogin_Zip=" & loginCred.IndividualLogin_Zip & "&")
    '            sb.Append("IndividualLogin_Phone=" & loginCred.IndividualLogin_Phone & "&")
    '            sb.Append("IndividualLogin_Email=" & loginCred.IndividualLogin_Email)

    '            'convert querystring into bytes
    '            postdataBytes = encode.GetBytes(sb.ToString)

    '            'Create POST request
    '            webRequest.Method = "POST"
    '            webRequest.ContentType = "application/x-www-form-urlencoded"
    '            webRequest.ContentLength = postdataBytes.Length
    '            Using stream = webRequest.GetRequestStream()
    '                stream.Write(postdataBytes, 0, postdataBytes.Length)
    '            End Using

    '            'Obtain result from request
    '            Dim result As HttpWebResponse = webRequest.GetResponse()

    '            'Return result In json format.
    '            Return JsonConvert.SerializeObject(result)
    '        End If
    '    Catch ex As Exception
    '        'Return exception in json format
    '        Dim dict = New Dictionary(Of Int16, String)
    '        dict.Add(1, userId)
    '        dict.Add(2, ex.Message)
    '        Return Newtonsoft.Json.JsonConvert.SerializeObject(dict)
    '        'Return Newtonsoft.Json.JsonConvert.SerializeObject(ex)
    '    End Try
    'End Function



    <WebMethod()>
    <ScriptMethod(ResponseFormat:=ResponseFormat.Json)>
    Public Function SaveVideoCompletion(ByVal imisId As String, ByVal videoId As String) As String
        'Instantiate variables
        Dim memberId As Integer
        Dim videoUid As String = ""

        'Get member Id
        memberId = NAHUvision.Controller.MemberController.GetMemberId_byImisId(imisId)

        'Get video guid
        videoUid = NAHUvision.Controller.MemberController.GetVideoGuid_byId(videoId)

        'Add video id to member
        Dim strListOfCompletedVideos As String = ""
        If memberId > 0 Then
            strListOfCompletedVideos = NAHUvision.Controller.MemberController.UpdateMember_AddVideoById(memberId, videoId)
        End If


        ' Return all data utilized in updating member with video.  [FOR TESTING PURPOSES ONLY.  DISPLAYED IN CONSOLE.]
        Dim dict As Dictionary(Of Integer, String) = New Dictionary(Of Integer, String)()
        dict.Add(1, "imisId: " + imisId)
        dict.Add(2, "memberId: " + memberId.ToString())
        dict.Add(3, "videoId: " + videoId)
        dict.Add(4, "videoUid: " + videoUid)
        dict.Add(5, "list: " + strListOfCompletedVideos)

        Return JsonConvert.SerializeObject(dict)
    End Function

End Class

