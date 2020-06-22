<%@ Control Language="vb" AutoEventWireup="false" CodeFile="NewsPanel.ascx.vb" EnableViewState="false" Inherits="NewsPanel" %>
<%@ Register Src="/UserControls/LatestNews.ascx" TagPrefix="uc" TagName="LatestNews" %>



<form runat="server" id="frmNewsPnl">

    <%--<asp:GridView runat="server" ID="gv1" /><hr />--%>

    <div class="row collapse newsPanel hide">
        <br class="hide-for-small-down" />
        <br />
        <br />
        <div class="medium-23 medium-push-1 columns">
            <div class="row">
                <div class="medium-8 columns featuredArticle">

                    <div class="pnlTitle show-for-small-down text-center">
                        <h2>PODCASTS AND WEBINARS</h2>
                        <br />
                        <br />
                    </div>

                    <div class="row hide-for-small-down">
                        <asp:HyperLink runat="server" ID="hlnkFeaturedArticle" CssClass="">
                            <div class="small-8 medium-24 columns text-center">
                                <asp:Image runat="server" ID="imgFeatured" CssClass="" />
                            </div>
                        </asp:HyperLink>
                        <div class="small-16 medium-24 columns ">
                            <asp:HyperLink runat="server" ID="hlnkFeaturedArticle_Title" CssClass="hide-for-small-down">
                                <h3>
                                    <asp:Literal runat="server" ID="ltrlTitle" />
                                </h3>
                            </asp:HyperLink>
                            <h5>
                                <asp:Literal runat="server" ID="ltrlDatePosted" />&nbsp;&nbsp;|&nbsp;&nbsp;<asp:HyperLink runat="server" ID="hlnkParent" />
                            </h5>
                        </div>
                    </div>


                    <div class="show-for-small-down mblNewsPnlLst">
                        <asp:ListView runat="server" ID="lstvNewsPnls">
                            <LayoutTemplate>
                                <asp:PlaceHolder runat="server" ID="itemPlaceholder" />
                            </LayoutTemplate>
                            <ItemTemplate>
                                <div class="row">
                                    <asp:HyperLink runat="server" NavigateUrl='<%#Eval("articleUrl")%>' Target='<%# If(Eval("isExternalUrl"), "_blank", "_self") %>'>
                                        <div class="small-8 medium-24 columns text-center">
                                            <asp:Image runat="server" ID="imgFeatured" CssClass="" AlternateText='<%#Eval("featuredImageName")%>' ImageUrl='<%# If(String.IsNullOrEmpty(Eval("featuredImageUrl").ToString()), "~/Images/temp/imgPlaceholder.png", Eval("featuredImageUrl")) %>' />
                                        </div>
                                    </asp:HyperLink>
                                    <div class="small-16 medium-24 columns ">
                                        <asp:HyperLink runat="server" NavigateUrl='<%#Eval("articleUrl")%>' Target='<%# If(Eval("isExternalUrl"), "_blank", "_self") %>'>
                                            <h3><%#Eval("title")%></h3>
                                        </asp:HyperLink>
                                        <h5><%#Eval("postDate", "{0:MMMM d, yyyy}")%>&nbsp;&nbsp;|&nbsp;&nbsp;<asp:HyperLink runat="server" Text='<%#Eval("parentName")%>' NavigateUrl='<%#Eval("parentUrl")%>' /></h5>
                                    </div>
                                </div>

                            </ItemTemplate>
                            <ItemSeparatorTemplate>
                                <br />
                            </ItemSeparatorTemplate>
                            <EmptyDataTemplate></EmptyDataTemplate>
                        </asp:ListView>
                        <%--<div class="text-center">
                            <br />
                            <h6>
                                <asp:HyperLink runat="server" ID="hlnkAllNews" Text="SEE ALL NEWS & UPDATES" />
                            </h6>
                        </div>--%>
                    </div>


                </div>
                <div class="medium-15 medium-push-1 columns end hide-for-small-down">

                    <div class="pnlTitle">
                        <h2>PODCASTS AND WEBINARS</h2>
                        <br />
                        <br />
                    </div>

                    <div class="row collapse">

                        <asp:Panel runat="server" ID="pnlTopNews" CssClass="medium-24 large-15 columns pnlTopNews">
                            <uc:LatestNews runat="server" />
                        </asp:Panel>

                        <asp:Panel runat="server" ID="pnlAdSpace" CssClass="hide-for-medium-down large-7 large-push-1 columns end">
                            <div id='div-gpt-ad-1503081911370-3' style='height: 250px; width: 300px;'>
                                <script>
                                    googletag.cmd.push(function () { googletag.display('div-gpt-ad-1503081911370-3'); });
                                </script>
                            </div>
                        </asp:Panel>

                    </div>

                </div>
            </div>
        </div>
        <div class="columns">
            <br class="hide-for-medium-down" />
            <br class="hide-for-small-down" />
            <br />
        </div>

    </div>
    <%--</div>--%>
</form>
