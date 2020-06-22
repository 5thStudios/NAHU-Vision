Imports Microsoft.VisualBasic
Imports Examine
Imports umbraco.Examine.Linq.Attributes


Namespace DataLayer
    Public Class IndividualBlogEntry
        Public Sub New()
        End Sub


        <Field("createDate")>
        Public Property CreatedDate As Date


        <Field("createDate")>
        Public Property DateAsInt As Double


        <Field("id")>
        Public Property Id As Integer


        <Field("nodeName")>
        Public Property Name As String


        <Field("content")>
        Public Property content As String


        <Field("postDate")>
        Public Property postDate As Date


        <Field("author")>
        Public Property author As String


        <Field("tags")>
        Public Property tags As String


        <Field("nodeTypeAlias")>
        Public Property NodeTypeAlias As String


        Public Property SearchResult As SearchResult
    End Class
End Namespace

