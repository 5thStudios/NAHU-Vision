Imports System.Net


Partial Class UserControls_Donations
    Inherits System.Web.Mvc.ViewUserControl

    Private Sub UserControls_Donations_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try

            'Create temp cookies to mimic loged-in user that can donate.
            Dim myCookie1 As HttpCookie = New HttpCookie("Login")
            myCookie1.Value = "41FCEE602665599AD34F19E8D8C695DD6172A1D14CEE5DA2F530E26C6523501B163F33C8FA256CC5B0126D3741394503CCAEF31A3C21536E7359D36396F4634879DF6C112CCFDB6410A9AA155258D6EA8FD7AA9A4128CC33536534E695D3A520ECABDCC75FB3CA1320ADBA098F0FF6057B6DB521B5BE75CF5D6913FF420B42087DD11B9CCBC35435733859EC098E502F4C4D4C0DB5AB589CECDB0FBBB0F8DB67D09CF92AC6A6F253D7C97E240B5EE1B9A96437A3"
            myCookie1.Expires = Now.AddDays(1)
            Response.Cookies.Add(myCookie1)

            Dim myCookie2 As HttpCookie = New HttpCookie("SessionGuid")
            myCookie2.Value = "088292c4-2c6b-e811-9dee-0050569e42df"
            myCookie2.Expires = Now.AddDays(1)
            Response.Cookies.Add(myCookie2)

            Dim myCookie3 As HttpCookie = New HttpCookie("FullLoginResponse")
            myCookie3.Value = "{%22IsValidated%22:true%2C%22SessionToken%22:%22088292c4-2c6b-e811-9dee-0050569e42df%22%2C%22StatusMessage%22:%22Successfull%20Login%22%2C%22ImisUserId%22:%22326977%22%2C%22CookieStructures%22:[{%22Name%22:%22Login%22%2C%22Value%22:%2241FCEE602665599AD34F19E8D8C695DD6172A1D14CEE5DA2F530E26C6523501B163F33C8FA256CC5B0126D3741394503CCAEF31A3C21536E7359D36396F4634879DF6C112CCFDB6410A9AA155258D6EA8FD7AA9A4128CC33536534E695D3A520ECABDCC75FB3CA1320ADBA098F0FF6057B6DB521B5BE75CF5D6913FF420B42087DD11B9CCBC35435733859EC098E502F4C4D4C0DB5AB589CECDB0FBBB0F8DB67D09CF92AC6A6F253D7C97E240B5EE1B9A96437A3%22%2C%22Domain%22:%22nahu.com%22%2C%22Path%22:%22/%22%2C%22Expires%22:%22%22%2C%22IsHttpOnly%22:false%2C%22IsSecure%22:false}%2C{%22Name%22:%22SessionGuid%22%2C%22Value%22:%22088292c4-2c6b-e811-9dee-0050569e42df%22%2C%22Domain%22:%22nahu.com%22%2C%22Path%22:%22/%22%2C%22Expires%22:%22%22%2C%22IsHttpOnly%22:false%2C%22IsSecure%22:false}]}"
            myCookie3.Expires = Now.AddDays(1)
            Response.Cookies.Add(myCookie3)


        Catch ex As Exception
            Response.Write("<div style='color:red;'><b>Error:</b> " & ex.ToString & "</div>")
        End Try
    End Sub

#Region "Properties"
#End Region

End Class
