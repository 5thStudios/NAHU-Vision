Imports System.Web
Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports Umbraco
Imports Umbraco.NodeFactory
Imports Common
Imports Newtonsoft.Json
Imports System.Web.Script.Services
Imports System.Xml.Serialization
Imports System
Imports System.Collections.Generic
Imports System.IO
Imports Umbraco.Web
Imports Umbraco.Core.Models
Imports System.Net
Imports System.Xml
Imports System.Text



' To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line.
<System.Web.Script.Services.ScriptService()>
<WebService(Namespace:="http://tempuri.org/")>
<WebServiceBinding(ConformsTo:=WsiProfiles.BasicProfile1_1)>
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Public Class videoServices
    Inherits System.Web.Services.WebService


    <WebMethod()>
    Public Function ObtainListOfCompletedVideos() As String
        'Obtain list of all members with completed videos
        Return JsonConvert.SerializeObject(NAHUvision.Controller.MemberController.ObtainListOfCompletedVideos())
    End Function

End Class

