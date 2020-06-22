<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="NewsPanel.ascx.vb" Inherits="mvcvb.NewsPanel" %>
<%@ Register Src="/UserControls/LatestNews.ascx" TagPrefix="uc" TagName="LatestNews" %>



<form runat="server">
    <%--<div class="">--%>


    <%--<asp:GridView runat="server" ID="gv1" />
        <hr />--%>


    <div class="row collapse newsPanel hide">
        <br class="hide-for-small-down" />
        <br />
        <br />
        <div class="medium-23 medium-push-1 columns">
            <div class="row">
                <div class="medium-8 columns featuredArticle">

                    <div class="pnlTitle show-for-small-down text-center">
                        <h2>NEWS</h2>
                        <br />
                        <br />
                    </div>

                    <asp:HyperLink runat="server" ID="hlnkFeaturedArticle" CssClass="hide-for-small-down">
                        <div class="row">
                            <div class="small-8 medium-24 columns text-center">
                                <asp:Image runat="server" ID="imgFeatured" CssClass="" />
                            </div>
                            <div class="small-16 medium-24 columns ">
                                <h3>
                                    <asp:Literal runat="server" ID="ltrlTitle" />
                                </h3>
                                <h5>
                                    <asp:Literal runat="server" ID="ltrlDatePosted" />
                                </h5>
                            </div>
                        </div>
                    </asp:HyperLink>


                    <div class="show-for-small-down mblNewsPnlLst">
                        <asp:ListView runat="server" ID="lstvNewsPnls">
                            <LayoutTemplate>
                                <asp:PlaceHolder runat="server" ID="itemPlaceholder" />
                            </LayoutTemplate>
                            <ItemTemplate>
                                <asp:HyperLink runat="server" ID="hlnkFeaturedArticle" NavigateUrl='<%#Eval("articleUrl")%>' Target='<%# If(Eval("isExternalUrl"), "_blank", "_self") %>'>
                                    <div class="row">
                                        <div class="small-8 medium-24 columns text-center">
                                            <asp:Image runat="server" ID="imgFeatured" CssClass="" AlternateText='<%#Eval("featuredImageName")%>' ImageUrl='<%# If(String.IsNullOrEmpty(Eval("featuredImageUrl").ToString()), "~/Images/temp/imgPlaceholder.png", Eval("featuredImageUrl")) %>' />
                                        </div>
                                        <div class="small-16 medium-24 columns ">
                                            <h3><%#Eval("title")%></h3>
                                            <h5><%#Eval("postDate", "{0:MMMM d, yyyy}")%></h5>
                                        </div>
                                    </div>
                                </asp:HyperLink>

                            </ItemTemplate>
                            <ItemSeparatorTemplate>
                                <br />
                            </ItemSeparatorTemplate>
                            <EmptyDataTemplate></EmptyDataTemplate>
                        </asp:ListView>
                        <div class="text-center">
                            <br />
                            <h6>
                                <asp:HyperLink runat="server" ID="hlnkAllNews" Text="SEE ALL NEWS & UPDATES" />
                            </h6>
                        </div>
                    </div>


                </div>
                <div class="medium-15 medium-push-1 columns end hide-for-small-down">

                    <div class="pnlTitle">
                        <h2>NEWS</h2>
                        <br />
                        <br />
                    </div>

                    <div class="row collapse">

                        <asp:Panel runat="server" ID="pnlTopNews" CssClass="medium-24 large-15 columns">
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
