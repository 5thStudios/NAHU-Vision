<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="Author.ascx.vb" Inherits="mvcvb.Author" %>
<%@ Register Src="../UserControls/BlogFilters.ascx" TagName="BlogFilter" TagPrefix="uc" %>

<%--<%@ Register Src="../UserControls/SocialShare.ascx" TagName="SocialShare" TagPrefix="uc" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="Server"></asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="HeadContent" runat="Server">
    <link type="text/css" rel="stylesheet" href="/Css/thisBlog.css?v=1" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="Server">--%>


        <div class="row outerContent">
            <br>
            <br>
            <div class="medium-16 columns panel callout">
                <%--<div class="row">
                    <div class="columns">
                        <section id="sectionSocialShare">
                            <uc:SocialShare runat="server" />
                        </section>
                    </div>
                </div>--%>

                <div class="row">
                    <div class="columns">
                        <div class="authorInfo">
                            <h1>
                                <asp:Literal runat="server" ID="ltrlAuthorName" />
                            </h1>
                            <asp:Panel runat="server" ID="pnlAuthorEmail" CssClass="row">
                                <div class="columns">
                                    <h5>
                                        <asp:HyperLink runat="server" ID="hlnkAuthorEmail" Target="_blank" NavigateUrl="mailto:" />
                                    </h5>
                                </div>
                            </asp:Panel>
                        </div>
                    </div>
                </div>

                <div class="row">
                    <div class="columns">
                        <div>
                            <asp:Image runat="server" ID="imgAuthor" CssClass="imgAuthor left" />
                            <umbraco:Item runat="server" Field="content" />
                            <br>
                        </div>
                        <div id="MainContent_pnlReadMoreBy_forAuthPg2" class="small-text-center medium-text-right">
                            <div class="ReadMorePosts button submitInput">
                                <asp:HyperLink runat="server" ID="hlnkReadMorePosts_byAuthor" Text="Read More Posts by " />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="medium-8 columns panel">
                <uc:BlogFilter runat="server" />
            </div>
        </div>



<%--</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="FinalScripts" runat="Server">
    <script type="text/javascript" src="/Scripts/blogFilters.js"></script>
</asp:Content>--%>