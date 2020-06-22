<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="BlogList.ascx.vb" Inherits="mvcvb.BlogList" %>
<%@ Register Src="/UserControls/BlogFilters.ascx" TagName="BlogFilter" TagPrefix="uc" %>
<%@ Register Src="/UserControls/BlogListItem.ascx" TagName="BlogListItem" TagPrefix="uc" %>
<%@ Register Src="/UserControls/ListViewOptions.ascx" TagName="ListViewOptions" TagPrefix="uc" %>




<form runat="server">
    <div class="row blogList">
        <br>
        <br>
        <div class="medium-14 large-16 columns">

            <div class="row">
                <div class="large-7 columns">
                    <uc:ListViewOptions runat="server" />
                </div>
                <div class="small-text-left large-text-right large-17 columns">
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
    </div>
</form>
