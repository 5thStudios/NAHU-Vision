<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="Quicklinks.ascx.vb" Inherits="mvcvb.Quicklinks" %>


<form runat="server">
    <asp:placeholder runat="server" ID="phQuicklinks">
        <asp:ListView runat="server" ID="lstvQuickLinks">
            <LayoutTemplate>
                <div class="row collapse quicklinks hide">
                    <asp:PlaceHolder runat="server" ID="itemPlaceholder" />
                </div>
            </LayoutTemplate>
            <ItemTemplate>
                <div class="medium-12 large-12 columns ">
                    <a href='<%# Eval("linkUrl") %>' <%# mvcvb.Common.showInNewTab(Eval("openInNewTab")) %>>
                        <div class="row collapse pnlWithBgImg" data-equalizer="quicklink">
                            <img alt='<%# Eval("title") %>' class="bgImg" src='<%# Eval("backgroundImageUrl") %>' data-equalizer-watch="quicklink" />
                            <div class="medium-22 medium-push-1 large-20 large-push-2 columns end floatOnTopCentered">
                                <h2>
                                    <%# Eval("title") %>
                                </h2>
                                <h3>
                                    <%# Eval("description") %>
                                </h3>
                            </div>
                            <div class="columns floatOnTopCentered gradient_30p" data-equalizer-watch="quicklink">
                                <br />
                            </div>
                        </div>
                    </a>
                </div>
            </ItemTemplate>
            <EmptyDataTemplate></EmptyDataTemplate>
        </asp:ListView>
    </asp:placeholder>
</form>
