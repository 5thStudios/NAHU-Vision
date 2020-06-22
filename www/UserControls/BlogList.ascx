<%@ Control Language="vb" AutoEventWireup="false" CodeFile="BlogList.ascx.vb" EnableViewState="false" Inherits="BlogList" %>
<%@ Register Src="/UserControls/BlogFilters.ascx" TagName="BlogFilter" TagPrefix="uc" %>
<%@ Register Src="/UserControls/BlogListItem.ascx" TagName="BlogListItem" TagPrefix="uc" %>
<%@ Register Src="/UserControls/ListViewOptions.ascx" TagName="ListViewOptions" TagPrefix="uc" %>


<form runat="server">

  <div class="row">
        <div class="columns">
            <asp:GridView runat="server" ID="gv" />
            <br>
        </div>
    </div>

    <div class="row blogList">
        <br>
        <br>

        <asp:Panel runat="server" ID="pnlLogin" Visible="false">
            <div class="small-22 small-push-1 medium-12 medium-push-6 large-6 large-push-9 columns panel locked text-center">
                <br />
                <h3>Board Members Only</h3>
                <h5>Please login to view page.</h5>
                <br />


                <div class="errorMsg columns text-right hide"></div>

                <div class=" ">
                    <input type="text" placeholder="Email Address" id="txbUserName_bMember" />
                </div>
                <div class=" ">
                    <input type="password" placeholder="Password (case sensitive)" id="txbPassword_bMember" />
                </div>

                <br />
                <div class=" ">
                    <a class="button" id="btnSubmitBoardLogin">Log In</a><br />
                </div>
            </div>
            <div class="columns">
                <br />
                <br />
            </div>
        </asp:Panel>

        <asp:Panel runat="server" ID="pnlFullContent" Visible="false">
            <div class="medium-14 large-16 columns">

                <div class="row">
                    <div class="small-24 medium-16 large-7 columns">
                        <uc:ListViewOptions runat="server" />
                    </div>

                    <asp:Panel runat="server" ID="pnlPodcastXml" Visible="false" CssClass="small-24 medium-8 large-4 columns rssFeedPnl">
                        <br class="show-for-small-down" />
                        <asp:HyperLink runat="server" ID="hlnkPodcastXml" CssClass="rssFeed" Target="_blank">
                            <img alt="rss" src="/Images/Common/rssIcon.png" width="41" height="41" /> Subscribe
                        </asp:HyperLink>
                    </asp:Panel>

                    <div class="small-text-left large-text-right small-24 medium-24 large-12 columns">
                        <br />
                        <div class="pagination-page"></div>
                    </div>
                </div>
                <br />
                <br />

                <div class="row">
                    <div class="columns">
                        <div class="gallery">
                            <section id="sectionMainContent" class="floatLeft topMargin">
                                <section id="sectionContent">
                                    <section id="sectionContentLeftColumn" class="contentPage">

                                        <asp:ListView runat="server" ID="lvBlogEntries">
                                            <LayoutTemplate>
                                                <section class="">
                                                    <div class="row" data-equalizer="gridview" data-equalizer-mq="large-up">
                                                        <asp:PlaceHolder runat="server" ID="itemPlaceholder" />
                                                    </div>
                                                </section>
                                            </LayoutTemplate>
                                            <ItemSeparatorTemplate>
                                            </ItemSeparatorTemplate>
                                            <ItemTemplate>
                                                <uc:BlogListItem runat="server" ID="ucBlogListItem" nodeId='<%# Eval("Key") %>' />
                                            </ItemTemplate>
                                            <EmptyDataTemplate>
                                                <div>No blogs have been created yet.</div>
                                            </EmptyDataTemplate>
                                        </asp:ListView>

                                    </section>
                                </section>
                            </section>
                        </div>
                    </div>
                </div>

                <div class="row">
                    <div class="columns">
                        <div class="pagination-page"></div>
                        <br />
                        <br />
                    </div>
                </div>

            </div>
            <div class="hide-for-small-down medium-10 large-8 columns">
                <uc:BlogFilter runat="server" />
            </div>
        </asp:Panel>

        <asp:HiddenField runat="server" ID="hfldIsBoardPg" ClientIDMode="Static" />
    </div>
</form>
