<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="RotatingBanner.ascx.vb" Inherits="mvcvb.RotatingBanner" %>


<form runat="server">

    <div class="RotatingBanners">
        <div class="row collapse pnlWithBgImg show-for-large-up">


            <asp:ListView runat="server" ID="lstvRotatingBannerImgs">
                <LayoutTemplate>
                    <asp:PlaceHolder runat="server" ID="itemPlaceholder" />
                </LayoutTemplate>
                <ItemTemplate>
                    <img class="bgImg" alt='<%#Eval("backgroundImageName")%>' src='<%#Eval("backgroundImageUrl")%>' />
                </ItemTemplate>
                <EmptyDataTemplate></EmptyDataTemplate>
            </asp:ListView>


            <div class="large-24 columns floatOnTopCentered">

                <div class="row collapse " data-equalizer="banner">
                    <div class="large-11 large-push-1 columns" data-equalizer-watch="banner">

                        <asp:ListView runat="server" ID="lstvBanners">
                            <LayoutTemplate>
                                <asp:PlaceHolder runat="server" ID="itemPlaceholder" />
                            </LayoutTemplate>
                            <ItemTemplate>
                                <asp:panel runat="server" CssClass="banner valignMiddle-" HorizontalAlign='<%#Eval("textAlignment")%>'>
                                    <h1 runat="server" ID="h1" class='<%#Eval("dropShadowClass")%>' ><%#Eval("title")%></h1>

                                    <asp:PlaceHolder runat="server" Visible='<%#Eval("showSubtitle")%>'>
                                        <h3 runat="server" ID="h3" class='<%#Eval("dropShadowClass")%>' ><%#Eval("subtitle")%></h3>
                                    </asp:PlaceHolder>

                                    <asp:PlaceHolder runat="server" Visible='<%#Eval("showCallToAction")%>'>
                                        <a class="button" href='<%#Eval("callToActionLink")%>'><%#Eval("callToActionText")%></a>
                                    </asp:PlaceHolder>
                                </asp:panel>
                            </ItemTemplate>
                            <EmptyDataTemplate></EmptyDataTemplate>
                        </asp:ListView>

                    </div>

                    <div class="large-5 columns text-right " data-equalizer-watch="banner">

                        <asp:ListView runat="server" ID="lstvSideNav">
                            <LayoutTemplate>
                                <ul class="large-block-grid-1 sideNav" data-equalizer="nav">
                                    <asp:PlaceHolder runat="server" ID="itemPlaceholder" />
                                </ul>
                            </LayoutTemplate>
                            <ItemTemplate>
                                    <li>
                                        <div class="row">
                                            <div class="large-17 columns text-right" data-equalizer-watch="nav">
                                                <div class="title"><%#Eval("quicklinkTitle")%></div>

                                                <asp:PlaceHolder runat="server" Visible='<%#Eval("showQuicklinkSubtitle")%>'>
                                                    <div class="subtitle"><%#Eval("quicklinkSubtitle")%></div>
                                                </asp:PlaceHolder>

                                            </div>
                                            <div class="large-5 large-push-2 columns end text-left" data-equalizer-watch="nav">
                                                <div class="valignMiddle- imgContainer">
                                                    <img alt='<%#Eval("quicklinkTitle")%>' src='<%#Eval("iconImageUrl")%>' />
                                                </div>
                                            </div>
                                        </div>
                                    </li>

                            </ItemTemplate>
                            <EmptyDataTemplate></EmptyDataTemplate>
                        </asp:ListView>

                    </div>
                </div>
            </div>
        </div>
    </div>


</form>
