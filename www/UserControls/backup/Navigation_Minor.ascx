<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="Navigation_Minor.ascx.vb" Inherits="mvcvb.Navigation_Minor" %>


<form runat="server">


    <%--Hidden for the next week until the board can approve--%>

    <%--<div class="row">
        <div class="columns temp">


            <style>
                /* Super Navigation for non-responsive sites
                ----------------------------------------------------------*/
                .superNavigation_nonResp {background-color: #00529a;display: flex;}
                .superNavigation_nonResp ul {margin: 0;padding: 0;list-style: none;display: inline-block;width:100%;}
                .superNavigation_nonResp ul li {float:left;width: 14.17%; text-align: center;list-style: none;line-height:18px;min-height: 40px;background-color: #00529a; border-width:0 1px 0 0; border-color:rgba(255, 255, 255, 0.5);border-style:solid; padding: 8px 0 8px 0;}
                .superNavigation_nonResp ul li:last-child {border-width:0; }
                .superNavigation_nonResp ul li a {color:#fff; text-decoration:none;font-family: 'rift', sans-serif;font-size:18px;font-weight:500;}
                .superNavigation_nonResp ul li:hover {background-color: #003462;}
                .superNavigation_nonResp ul li:hover a {}
            </style>
            <nav class="superNavigation_nonResp">
                <ul class="">
                    <li><a target="_blank" href="https://nahu.org">NAHU</a></li>
                    <li><a target="_blank" href="http://hupac.org">Hupac</a></li>
                    <li><a target="_blank" href="http://www.nahueducationfoundation.org">Education Foundation</a></li>
                    <li><a target="_blank" href="http://nahu.inreachce.com/">Online Learning Institute</a></li>
                    <li><a target="_blank" href="http://careers.nahu.org">Careers</a></li>
                    <li><a target="_blank" href="http://cqrcengage.com/nahu">Operation Shout!</a></li>
                    <li><a target="_blank" href="http://community.nahu.org/home">Broker to Broker</a></li>--%>
                    <%--<li><a target="_blank" href="https://members.nahu.org/NAHU_Prod_Imis/Nahu_Member/Default.aspx?returnurl=/NAHU_Prod_Imis/NAHU_Member/My_NAHU/My_Account/Nahu_Member/IBCAccountPage.aspx">Member Portal</a></li>--%>
                <%--</ul>
            </nav>


            <img src="https://forms.nahu.org/images/form-banner.jpg" alt="National Association of Health Underwriters" width="960" height="100" border="0">


        </div>
    </div>--%>




  <%--  <nav class="row superNavigation hide-for-small-down">
        <div class="columns">
            <ul class="medium-block-grid-7 text-center" data-equalizer="snav">
                <li data-equalizer-watch="snav"><a target="_blank" href="https://members.nahu.org/NAHU_Prod_Imis/Nahu_Member/Default.aspx?returnurl=/NAHU_Prod_Imis/NAHU_Member/My_NAHU/My_Account/Nahu_Member/IBCAccountPage.aspx">Member Portal</a></li>
                <li data-equalizer-watch="snav"><a target="_blank" href="http://www.nahueducationfoundation.org">Education Foundation</a></li>
                <li data-equalizer-watch="snav"><a target="_blank" href="http://cqrcengage.com/nahu">Operation Shout!</a></li>
                <li data-equalizer-watch="snav"><a target="_blank" href="http://careers.nahu.org">Careers</a></li>
                <li data-equalizer-watch="snav"><a target="_blank" href="http://community.nahu.org/home">Broker to Broker</a></li>
                <li data-equalizer-watch="snav"><a target="_blank" href="http://nahu.inreachce.com/">Online Learning Institute</a></li>
                <li data-equalizer-watch="snav"><a target="_blank" href="http://hupac.org">Hupac</a></li>
            </ul>
        </div>
    </nav>--%>


    <nav class="row NavigationMinor hide-for-small-down" data-equalizer="nav">
        <asp:Panel runat="server" ID="pnlMinorNavLinks" CssClass="medium-20 columns medium-text-right minorNavLinks" data-equalizer-watch="nav" />
        <div class="medium-4 columns text-right searchPnl" data-equalizer-watch="nav">
            <div class="row" data-equalizer="search">
                <div class="medium-16 medium-push-2 columns text-center">
                    <asp:TextBox runat="server" ID="txbSearchFor" ClientIDMode="Static" placeholder="SEARCH" data-equalizer-watch="search" />
                </div>
                <div class="medium-6 columns end text-left">
                    <img alt="search" src="/Images/Common/icons/search.png" id="imgBtnSearch" data-equalizer-watch="search" />
                </div>
            </div>
        </div>
        <asp:HiddenField runat="server" ID="hfldSearchPg" ClientIDMode="Static" />
    </nav>
</form>
