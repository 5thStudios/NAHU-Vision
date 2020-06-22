Imports System.Web.Mvc
Imports Umbraco.Web.Editors
Imports Umbraco.Core.Persistence
Imports Umbraco.Core.Persistence.SqlSyntax
Imports mvcvb.Test
Imports Umbraco.Web.Mvc

Namespace Controllers

    <PluginController("RelationalData")>
    Public Class TestApiController
        Inherits UmbracoAuthorizedJsonController


        Public Function GetAll() As IEnumerable(Of Test)
            Dim query = New Sql().[Select]("*").From("Test")
            Return DatabaseContext.Database.Fetch(Of Test)(query)
        End Function


        Public Function GetById(ByVal id As Integer) As Test
            Dim query = New Sql().[Select]("*").From("Test").Where(Of Test)(Function(x) x.Id = id)  'Obsolete. Use [Dim i As ISqlSyntaxProvider]
            Return DatabaseContext.Database.Fetch(Of Test)(query).FirstOrDefault()
        End Function


        Public Function PostSave(ByVal test As Test) As Test
            If test.Id > 0 Then
                DatabaseContext.Database.Update(test)
            Else
                DatabaseContext.Database.Save(test)
            End If
            Return test
        End Function


        Public Function DeleteById(ByVal id As Integer) As Integer
            Return DatabaseContext.Database.Delete(Of Test)(id)
        End Function

    End Class
End Namespace