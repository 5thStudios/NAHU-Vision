Imports System.Web.Mvc
Imports Umbraco.Web.Editors
Imports Umbraco.Core.Persistence
Imports Umbraco.Core.Persistence.DatabaseAnnotations
Imports Umbraco.Core.Persistence.SqlSyntax
Imports mvcvb.Test
Imports Umbraco.Core
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports Umbraco.BusinessLogic
Imports Umbraco.interfaces


Public Class RegisterEvents
    Inherits ApplicationEventHandler


    Protected Overrides Sub ApplicationStarted(umbracoApplication As UmbracoApplicationBase, applicationContext As ApplicationContext)
        Dim db = applicationContext.DatabaseContext.Database
        If Not db.TableExist("Test") Then
            db.CreateTable(Of Test)(False)
        End If
    End Sub

End Class
