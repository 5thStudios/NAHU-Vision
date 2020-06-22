<%@ Control Language="vb" AutoEventWireup="false" CodeFile="RotatingBanner.ascx.vb" EnableViewState="false" Inherits="RotatingBanner" %>


<form runat="server">
    <%--<asp:GridView runat="server" ID="gv" />--%>

    <div class="RotatingBanners hide">
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

            <div class="columns floatOnTopCentered">
                <div class="row collapse " data-equalizer="banner">
                    <div class="medium-11 medium-push-1 columns" data-equalizer-watch="banner">

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
                    <div class="medium-5 columns text-right " data-equalizer-watch="banner">

                        <asp:ListView runat="server" ID="lstvSideNav">
                            <LayoutTemplate>
                                <ul class="medium-block-grid-1 sideNav" data-equalizer="nav">
                                    <asp:PlaceHolder runat="server" ID="itemPlaceholder" />
                                </ul>
                            </LayoutTemplate>
                            <ItemTemplate>
                                    <li>
                                        <div class="row">
                                            <div class="medium-17 columns text-right" data-equalizer-watch="nav">
                                                <div class="title"><%#Eval("quicklinkTitle")%></div>

                                                <asp:PlaceHolder runat="server" Visible='<%#Eval("showQuicklinkSubtitle")%>'>
                                                    <div class="subtitle"><%#Eval("quicklinkSubtitle")%></div>
                                                </asp:PlaceHolder>

                                            </div>
                                            <div class="medium-5 medium-push-2 columns end text-left" data-equalizer-watch="nav">
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




        <%--=============================================================================================--%>




            <asp:ListView runat="server" ID="lstvRotatingBanner_Mbl">
                <LayoutTemplate>
                    <div class="mblBannerLst show-for-medium-down">
                        <asp:PlaceHolder runat="server" ID="itemPlaceholder" />
                    </div>
                </LayoutTemplate>
                <ItemTemplate>

                        <div data-nodeId='<%#Eval("nodeId")%>' class="row collapse banner hide" style="background-image: url(<%#Eval("backgroundImageUrl")%>);" >
                            <div class="small-22 small-push-1 columns">
                                <br />
                                <h1><%#Eval("title")%></h1>
                                <asp:PlaceHolder runat="server" ID="phSubtitle_Mbl" Visible='<%#Eval("showSubtitle")%>'>
                                    <h3><%#Eval("subtitle")%></h3>
                                </asp:PlaceHolder>
                            </div>
                            <div class="small-11 small-push-1 columns">
                                <asp:HyperLink runat="server" ID="hlnkCall2Action_Mbl" CssClass="button" NavigateUrl='<%#Eval("callToActionLink")%>' Text='<%#Eval("callToActionText")%>' Visible='<%#Eval("showCallToAction")%>' />
                                &nbsp;
                            </div>
                            <div class="small-12 columns text-right">
                                <img src="../images/common/icons/arrowl.png" alt="" class="arrow previous" />
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                <img src="../images/common/icons/arrowr.png" alt="" class="arrow next" />
                            </div>
                            <div class="small-22 small-push-1 columns">
                                <br />
                            </div>
                        </div>

                </ItemTemplate>
                <EmptyDataTemplate></EmptyDataTemplate>
            </asp:ListView>

    </div>
</form>