Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports Umbraco
Imports Umbraco.NodeFactory
Imports Common


Public Class LockedPgMngr
    Inherits System.Web.Mvc.ViewUserControl


#Region "Parameters"
    Private thisNode As Node
    Private isLoggedIn As Boolean = False
#End Region


#Region "Handles"
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        'Instantiate variables
        thisNode = Node.GetCurrent()

        '
        If thisNode.NodeTypeAlias = aliases.standardLocked Then
            If Not isLoggedIn Then
                pnlLockedInfo.Visible = True

                '
                If thisNode.HasProperty(nodeProperties.lockedShortDescription) Then
                    ltrlLockedInfo.Text = thisNode.GetProperty(nodeProperties.lockedShortDescription).Value
                End If
            End If
        End If
    End Sub
#End Region


#Region "Methods"
#End Region


End Class