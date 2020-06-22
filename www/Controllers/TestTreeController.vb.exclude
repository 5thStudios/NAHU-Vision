Imports System.Net.Http.Formatting
Imports Umbraco.Web.Models.Trees
Imports Umbraco.Web.Trees
Imports Umbraco.Web.Mvc
Imports Umbraco.Core
Imports Umbraco.BusinessLogic.Actions
Imports Umbraco.Core.Services
Imports Umbraco.cms.presentation.Trees

Namespace Controllers

    <Tree("relationalData", "testTree", "Test")>
    <PluginController("RelationalData")>
    Public Class TestTreeController
        Inherits TreeController


        Protected Overrides Function GetTreeNodes(id As String, queryStrings As FormDataCollection) As TreeNodeCollection
            'Dim nodes = New TreeNodeCollection()
            'Dim item = Me.CreateTreeNode("dashboard", id, queryStrings, "My item", "icon-truck", True)
            'nodes.Add(item)
            'Return nodes

            If id = Constants.System.Root.ToInvariantString() Then
                Dim ctrl = New TestApiController()
                Dim nodes = New TreeNodeCollection()

                For Each test As Test In ctrl.GetAll
                    Dim node = CreateTreeNode(test.Id.ToString, "-1", queryStrings, test.ToString, "icon-theif color-orange")
                    nodes.Add(node)
                Next

                Return nodes
            End If


            Throw New NotSupportedException
        End Function

        Protected Overrides Function GetMenuForNode(id As String, queryStrings As FormDataCollection) As MenuItemCollection
            Dim menu = New MenuItemCollection()
            If id = Constants.System.Root.ToInvariantString() Then
                'menu.DefaultMenuAlias = ActionNew.Instance.[Alias]
                ''menu.Items.Add(Of ActionNew)("Create")
                'menu.Items.Add(Of CreateChildEntity, ActionNew)(Services.TextService.Localize("actions"))
                menu.Items.Add(Of CreateChildEntity, ActionNew)(Services.TextService.Localize(ActionNew.Instance.[Alias]))
                menu.Items.Add(Of RefreshNode, ActionRefresh)(Services.TextService.Localize(ActionRefresh.Instance.[Alias]), True)
                'Return menu
            Else
                'menu.DefaultMenuAlias = ActionDelete.Instance.Alias
                menu.Items.Add(Of ActionDelete)(Services.TextService.Localize(ActionDelete.Instance.Alias))
            End If
            Return menu

            'Throw New NotImplementedException()
        End Function

    End Class
End Namespace