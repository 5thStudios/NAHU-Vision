Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports Umbraco.Core.Persistence
Imports Umbraco.Core.Persistence.DatabaseAnnotations


<TableName("Test")>
Public Class Test

    <PrimaryKeyColumn(AutoIncrement:=True)>
    Public Property Id() As Integer

    Public Property firstName As String = String.Empty
    Public Property lastName As String = String.Empty

    Public Overrides Function ToString() As String
        Return Convert.ToString(firstName & Convert.ToString(" ")) & lastName
    End Function



    Public Sub New()
    End Sub
End Class
