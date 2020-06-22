Imports System.Web
Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports umbraco
Imports umbraco.NodeFactory
Imports Common
Imports Newtonsoft.Json
Imports System.Web.Script.Services
Imports System.Xml.Serialization
Imports System
Imports System.Collections.Generic
Imports System.IO
Imports umbraco.Web
Imports umbraco.Core.Models
Imports System.Net
Imports System.Xml
Imports System.Text



' To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line.
<System.Web.Script.Services.ScriptService()>
<WebService(Namespace:="http://tempuri.org/")>
<WebServiceBinding(ConformsTo:=WsiProfiles.BasicProfile1_1)>
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Public Class brokenLinkFixer
    Inherits System.Web.Services.WebService



    <WebMethod()>
    Public Function FixBrokenLinks() As String
        Dim results As results = New results()
        'results.updatedSuccessfully = True
        'results.mediaUpdate = 21
        'results.contentUpdate = 42


        Dim imisDC As New dbImisDataContext
        Dim result As String = String.Empty
        imisDC.fixBrokenLinks(result)

        'Dim m As Movie = JsonConvert.DeserializeObject(Of Movie)(json)
        'Dim name As String = m.Name

        results = JsonConvert.DeserializeObject(Of results)(result)


        'Return result

        Return Newtonsoft.Json.JsonConvert.SerializeObject(results)
    End Function




    Private Class results
        Public Property updatedSuccessfully As Boolean = False
        Public Property mediaUpdate As Integer = 0
        Public Property contentUpdate As Integer = 0
    End Class
End Class

