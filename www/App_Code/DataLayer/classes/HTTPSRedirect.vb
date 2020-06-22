Imports SEOChecker.Extensions.Providers.UrlRewriteProvider
Imports System.Configuration
Imports Common
Imports Umbraco.NodeFactory

Public Class HTTPSRedirect
    Inherits UrlRewriteProviderBase

    Public Overrides Sub RewriteUrl(builder As UrlBuilder, config As UrlRewriteConfiguration)
        Try
            ''Instantiate variables
            'Dim homeNodeId As Integer = getHomeNodeId(Node.getCurrentNodeId)
            'Dim httpsRedirect As Boolean = False

            ''Obtain value from web.config
            'Select Case homeNodeId
            '    Case siteNodes.Home
            '        httpsRedirect = CBool(ConfigurationManager.AppSettings(miscellaneous.httpsRedirect))
            '    Case siteNodes.HUPAC
            '        httpsRedirect = CBool(ConfigurationManager.AppSettings(miscellaneous.httpsRedirect_HUPAC))
            '    Case siteNodes.EducationFoundation
            '        httpsRedirect = CBool(ConfigurationManager.AppSettings(miscellaneous.httpsRedirect_EF))
            'End Select

            ''Redirect if needed
            'If httpsRedirect Then
            '    If builder.Scheme.Equals("http", StringComparison.InvariantCultureIgnoreCase) Then
            '        builder.Scheme = "https"
            '    End If
            'End If

        Catch ex As Exception
            'Save error to umbraco
            Dim sb As New StringBuilder
            sb.AppendLine("HTTPSRedirect.vb | RewriteUrl()")
            SaveErrorMessage(ex, sb, Me.GetType())
        End Try
    End Sub
End Class
