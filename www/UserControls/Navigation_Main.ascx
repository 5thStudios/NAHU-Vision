<%@ Control Language="vb" AutoEventWireup="false" CodeFile="Navigation_Main.ascx.vb" EnableViewState="false" Inherits="Navigation_Main" %>


<form runat="server" id="frmNavMain">

    <div class="show-for-small-down">
        <nav class="tab-bar">
            <section class="left tab-bar-section">
                <div class="row">
                    <div class="small-8 columns">
                        <asp:HyperLink runat="server" ID="hlnkLogo_Mbl">
                            <asp:Image runat="server" ID="imgLogo_Mbl" />
                        </asp:HyperLink>
                    </div>
                </div>
            </section>

            <section class="right-small">
                <a class="right-off-canvas-toggle menu-icon" href="#"><span></span></a>
            </section>
        </nav>

        <aside class="right-off-canvas-menu">
            <ul class="off-canvas-list">

                <li><label>Main Menu</label></li>
                <asp:PlaceHolder runat="server" ID="phMblNav" />


            </ul>
        </aside>
    </div>


    <div class="hide-for-small-down">
        <nav class="row NavigationMain" data-equalizer data-equalizer-mq="large-up">
            <br />
            <div class="medium-24 large-2 columns text-center" data-equalizer-watch>
                <asp:HyperLink runat="server" ID="hlnkLogo">
                    <asp:Image runat="server" ID="imgLogo" CssClass="siteLogo" />
                </asp:HyperLink>
            </div>

            <div class="hide-for-medium-down small-24 large-15 columns medium-text-center large-text-left" data-equalizer-watch>
                <asp:PlaceHolder runat="server" ID="phMainMenu" />
            </div>



            <div class="medium-6 large-3 columns large-text-right" data-equalizer-watch>
                <button id="btnSignIn" onclick="return false;">Sign In</button>
                <button id="btnSignOut" onclick="return false;" class="hide">Sign Out</button>
            </div>

            <div class="medium-6 medium-push-10 large-push-0 large-3 columns medium-text-center" data-equalizer-watch>
                <div class="buttonContainer">
                    <asp:HyperLink runat="server" ID="hlnkJoinNow" CssClass="button" Text="JOIN NAHU" />
                </div>
            </div>

            <div class="medium-2 medium-push-10 large-push-0 large-1 columns text-center navMegaMenu" data-equalizer-watch>
                <img alt="" src="/images/common/icons/navmenu.png" />
            </div>


            <br />
            <br />
        </nav>
        <div class="megaMenu hiddenPnl">
            <div class="row ">
                <div class="columns">
                    <ul class="large-block-grid-5">
                        <asp:PlaceHolder runat="server" ID="phMegaMenu" />
                    </ul>
                </div>
            </div>
        </div>
    </div>


    <div class="show-for-small-down">
        <div class="row collapse mblMainNav">
            <ul class="small-block-grid-3 text-center">
                <li>
                    <asp:HyperLink ID="hlnkJoinNahu_Mbl" runat="server" Text="Join Nahu"></asp:HyperLink>
                </li>
                <li>
                    <a id="btnSignIn_Mbl" onclick="return false;">Sign In</a>
                    <a id="btnSignOut_Mbl" class="hide" onclick="return false;">Sign Out</a>
                </li>
                <li>
                    <asp:HyperLink ID="hlnkSearch_Mbl" runat="server">
                        Search
                        <img alt="search" src="/images/common/icons/search_white.png" class="imgBtnSearch" />
                    </asp:HyperLink>
                </li>
            </ul>
        </div>
    </div>


    <%--<asp:GridView runat="server" ID="gv1" />--%>


</form>