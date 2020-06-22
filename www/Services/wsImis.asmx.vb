Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports System.ComponentModel
Imports System.Web.Script.Services
Imports Newtonsoft.Json
Imports System.Net.Mime.MediaTypeNames
Imports mvcvb.org.nahu.sso
Imports Umbraco
Imports Umbraco.NodeFactory
Imports Common



' To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line.
<System.Web.Script.Services.ScriptService()>
<System.Web.Services.WebService(Namespace:="http://tempuri.org/")>
<System.Web.Services.WebServiceBinding(ConformsTo:=WsiProfiles.BasicProfile1_1)>
<ToolboxItem(False)>
Public Class wsImis
    Inherits System.Web.Services.WebService


    <WebMethod()>
    <ScriptMethod(ResponseFormat:=ResponseFormat.Json)>
    Public Function Login(ByVal userId As String, ByVal password As String) As String
        'Instantiate variables
        Dim sso = New mvcvb.org.nahu.sso.SSO
        Dim applicationInstance = "1"
        Dim _rememberMe As Boolean = False

        'Validate user and obtain result
        Dim result As ValidationWrapper = sso.ValidateLogOn(applicationInstance, userId, password, GetIPv4Address, _rememberMe)

        'Return result in json format.
        Return JsonConvert.SerializeObject(result)
    End Function
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
        Dim tempId As String = "abc"
        Dim tempPw As String = "123"
        Dim validBoardmember As Boolean = True

        'Compare credentials
        If Not tempId.Equals(userId) Then validBoardmember = False
        If Not tempPw.Equals(password) Then validBoardmember = False

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
        Dim sso = New mvcvb.org.nahu.sso.SSO
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
        Dim sso = New mvcvb.org.nahu.sso.SSO
        Dim applicationInstance = "1"
        Dim userTokenGuid As Guid

        If Guid.TryParse(userToken, userTokenGuid) Then
            Return JsonConvert.SerializeObject(sso.FetchUserInfo(applicationInstance, userTokenGuid.ToString))
        Else
            Return "Invalid conversion of guid: " & userToken
        End If
    End Function
    <WebMethod()>
    <ScriptMethod(ResponseFormat:=ResponseFormat.Json)>
    Public Function DisposeSession(ByVal userToken As String) As String
        'Instantiate variables
        Dim sso = New mvcvb.org.nahu.sso.SSO
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
            If userId.Trim.Length > 0 Then
                'Instantiate variables
                Dim membership = New mvcvb.org.nahu.members.MembershipWebService
                'Submit request for password reset
                membership.RequestPasswordReset(userId, userId, "Password Reset Request", New Node(siteNodes.Home).NiceUrl)
                Return JsonConvert.SerializeObject(True)
            Else
                Return JsonConvert.SerializeObject(False)
            End If
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
End Class




'<WebMethod()>
'<ScriptMethod(ResponseFormat:=ResponseFormat.Json)>
'Public Function RecoverUserName(ByVal userToken As String) As String
'    Return ""
'    ''Instantiate variables
'    'Dim sso = New mvcvb.org.nahu.sso.SSO
'    'Dim applicationInstance = "1"
'    'Dim userTokenGuid As Guid

'    'If Guid.TryParse(userToken, userTokenGuid) Then
'    '    Return JsonConvert.SerializeObject(sso.DisposeSessionByUserToken(applicationInstance, userTokenGuid.ToString))
'    'Else
'    '    Return "Invalid conversion of guid: " & userToken
'    'End If
'End Function



'Public Class cookie
'    Public Property key As String = String.Empty
'    Public Property value As String = String.Empty
'End Class






'<WebMethod()>
'<ScriptMethod(ResponseFormat:=ResponseFormat.Json)>
'Public Function Login(ByVal userId As String, ByVal password As String) As String
'    'Instantiate imis web service
'    Dim membershipWebService = New mvcvb.org.nahu.members.MembershipWebService

'    'Attempt to log user in
'    Dim result As String = membershipWebService.LoginUserAndProvideCookies(userId, password, False)

'    If String.IsNullOrWhiteSpace(result) Then
'        'Invalid login.  Return nothing.
'        Return String.Empty
'    Else
'        '
'        Dim lstCookies As New List(Of cookie)
'        '
'        For Each item As String In result.Split("|").ToList
'            'Instantiate variables
'            Dim newCookie As New cookie
'            '
'            Dim vars As List(Of String) = item.Split("=").ToList
'            If vars.Count < 2 Then Continue For
'            If String.IsNullOrEmpty(vars(1).Trim) Then Continue For

'            'Obtain data and add to cookie
'            newCookie.key = vars(0)
'            newCookie.value = vars(1)
'            'Add cookie to list
'            lstCookies.Add(newCookie)
'        Next

'        Return JsonConvert.SerializeObject(lstCookies)
'    End If


'    'Return JsonConvert.SerializeObject(blNominations.selectAll())
'End Function