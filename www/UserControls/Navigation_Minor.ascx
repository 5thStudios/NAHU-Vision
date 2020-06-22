<%@ Control Language="vb" AutoEventWireup="false" CodeFile="Navigation_Minor.ascx.vb" EnableViewState="false" Inherits="Navigation_Minor" %>


<form runat="server" id="frmNavMinor">

    <%--[[[<asp:Label runat="server" ID="lblMsg" ForeColor="IndianRed" />]]]--%>

    <%--<nav class="row superNavigation hide-for-small-down hide">
        <div class="columns">
            <ul class="medium-block-grid-7 text-center" data-equalizer="snav">
                <li runat="server" id="liNahu"><a target="_blank" href="https://nahu.org">NAHU</a></li>
                <li runat="server" id="liHupac" data-equalizer-watch="snav"><a target="_blank" href="http://hupac.org">Hupac</a></li>
                <li runat="server" id="liEducationFoundation" data-equalizer-watch="snav"><a target="_blank" href="http://www.nahueducationfoundation.org">Education Foundation</a></li>
                <li data-equalizer-watch="snav"><a target="_blank" href="http://nahu.inreachce.com/">Online Learning Institute</a></li>
                <li data-equalizer-watch="snav"><a target="_blank" href="http://careers.nahu.org">Careers</a></li>
                <li data-equalizer-watch="snav"><a target="_blank" href="http://cqrcengage.com/nahu">Operation Shout!</a></li>
                <li data-equalizer-watch="snav"><a target="_blank" href="http://community.nahu.org/home">Broker to Broker</a></li>
                <li data-equalizer-watch="snav"><a target="_blank" href="https://members.nahu.org/NAHU_Prod_Imis/Nahu_Member/Default.aspx?returnurl=/NAHU_Prod_Imis/NAHU_Member/My_NAHU/My_Account/Nahu_Member/IBCAccountPage.aspx">Member Portal</a></li>
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
                    <img alt="search" src="/images/common/icons/search.png" id="imgBtnSearch" data-equalizer-watch="search" />
                </div>
            </div>
        </div>
        <asp:HiddenField runat="server" ID="hfldSearchPg" ClientIDMode="Static" />
    </nav>
</form>
