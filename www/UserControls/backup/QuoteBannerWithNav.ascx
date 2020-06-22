<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="QuoteBannerWithNav.ascx.vb" Inherits="mvcvb.QuoteBannerWithNav" %>



<form runat="server">
    <%--<asp:GridView runat="server" ID="gv" />
    <asp:GridView runat="server" ID="gv2" />--%>

    <asp:Panel runat="server" ID="pnlQuoteBannerWithNav" CssClass="QuoteBannerWithNav hide">
        <div class="row collapse pnlWithBgImg">
            <asp:Image runat="server" ID="imgBackground" CssClass="bgImg" />
            <div class="columns floatOnTopCentered">
                <div class="row collapse " data-equalizer="banner">

                    <asp:Panel runat="server" ID="pnlPrimaryText" CssClass="medium-14 medium-push-1 large-10 large-push-2 columns " data-equalizer-watch="banner">
                        <div class="valignMiddle- small-only-text-center">
                            <img alt="" src="/Images/Common/icons/quotation.png" class="quotationMark left" />
                            <h1 runat="server" ID="h1">
                                <asp:Literal runat="server" ID="ltrlQuote" /></h1>
                            <h3  runat="server" ID="h3">
                                <asp:Literal runat="server" ID="ltrlAuthor" /></h3>
                        </div>
                    </asp:Panel>

                    <asp:Panel runat="server" ID="pnlSideNav" CssClass="hide-for-small-down medium-8 large-5 columns text-right " data-equalizer-watch="banner">

                        <asp:ListView runat="server" ID="lstvLinks">
                            <LayoutTemplate>
                                <ul class="medium-block-grid-1 sideNav valignMiddle-" data-equalizer="nav">
                                    <asp:PlaceHolder runat="server" ID="itemPlaceholder" />
                                </ul>
                            </LayoutTemplate>
                            <ItemTemplate>
                                <li class="">
                                    <a href='<%# Eval("url") %>' <%# mvcvb.Common.showInNewTab(Eval("openInNewTab")) %>>
                                        <div class="row">
                                            <div class="medium-17 large-17 columns text-right" data-equalizer-watch="nav">
                                                <div class="title"><%# Eval("quicklinkTitle") %></div>
                                                <div class="subtitle"><%# Eval("quicklinkSubtitle") %></div>
                                            </div>
                                            <div class="medium-5 medium-push-2 large-5 large-push-2 columns end text-left" data-equalizer-watch="nav">
                                                <div class="valignMiddle- imgContainer">
                                                    <img alt='<%# Eval("quicklinkTitle") %>' src='<%# Eval("iconImageUrl") %>'>
                                                </div>
                                            </div>
                                        </div>
                                    </a>
                                </li>
                            </ItemTemplate>
                            <EmptyDataTemplate></EmptyDataTemplate>
                        </asp:ListView>

                    </asp:Panel>
                </div>
            </div>
        </div>
    </asp:Panel>

</form>
