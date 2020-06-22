<%@ Control Language="vb" AutoEventWireup="false" CodeFile="BlogFilters.ascx.vb" EnableViewState="false" Inherits="BlogFilters" %>
<%@ Register Src="../UserControls/MeetTheAuthors.ascx" TagName="MeetTheAuthors" TagPrefix="uc" %>




<div class="BlogFilter">

    <%--FILTERED BY--%>
    <h4>Filter By <span id="lblFilterBy" class="camelCase"><%--: Author--%></span></h4>

    <aside class="hidePrint blogFilters">

        <%--LATEST POST--%>
        <section class="accordion">
            <h3>Latest Posts</h3>
            <asp:ListView runat="server" ID="lvLatestPosts">
                <LayoutTemplate>
                    <ul>
                        <asp:PlaceHolder runat="server" ID="itemPlaceholder" />
                    </ul>
                </LayoutTemplate>
                <ItemTemplate>
                    <li>
                        <asp:HyperLink runat="server" ID="hlnkLatestPost" Target="_blank" NavigateUrl='<%#Eval("url")%>'>
                            <h6><%#Eval("postDate", "{0:MMMM d, yyyy}")%></h6>
                            <div class="docTitle"><%#Eval("title")%></div>
                        </asp:HyperLink>
                    </li>
                </ItemTemplate>
                <EmptyDataTemplate>
                    <div class="emptyDataTemplate">No blog entries have been created yet.</div>
                </EmptyDataTemplate>
            </asp:ListView>
        </section>


        <%--POSTS BY AUTHOR--%>
        <section class="accordion authors">
            <h3>Posts by Author
            </h3>
            <asp:ListView runat="server" ID="lvPostsByAuthor">
                <LayoutTemplate>
                    <ul>
                        <asp:PlaceHolder runat="server" ID="itemPlaceholder" />
                    </ul>
                </LayoutTemplate>
                <ItemSeparatorTemplate></ItemSeparatorTemplate>
                <ItemTemplate>
                    <li>
                        <asp:HyperLink   runat ="server"   ID="hlnk"   data-filterby="author"   data-filterid='<%#Eval("id")%>'    data-filtername='<%#Eval("name")%>'   Text='<%#Eval("name")%>'   onclick="return false;" />
                    </li>
                </ItemTemplate>
                <EmptyDataTemplate>
                    <div class="emptyDataTemplate">No authors have been created yet.</div>
                </EmptyDataTemplate>
            </asp:ListView>
        </section>


        <%--POSTS BY TAG--%>
        <section class="accordion tags">
            <h3>Posts by Tag
            </h3>
            <asp:ListView runat="server" ID="lvPostsByTag">
                <LayoutTemplate>
                    <ul>
                        <asp:PlaceHolder runat="server" ID="itemPlaceholder" />
                    </ul>
                </LayoutTemplate>
                <ItemSeparatorTemplate></ItemSeparatorTemplate>
                <ItemTemplate>
                    <li>
                        <asp:HyperLink   runat ="server"   ID="hlnk"   data-filterby="tag"   data-filterid='<%#Eval("id")%>'    data-filtername='<%#Eval("name")%>'   Text='<%#Eval("name")%>'   onclick="return false;" />
                    </li>
                </ItemTemplate>
                <EmptyDataTemplate>
                    <div class="emptyDataTemplate">No tags have been created yet.</div>
                </EmptyDataTemplate>
            </asp:ListView>
        </section>


        <%--POSTS BY DATE--%>
        <section class="accordion">
            <h3>Posts by Date</h3>
            <asp:ListView runat="server" ID="lvPostYear">
                <LayoutTemplate>
                    <ul>
                        <asp:PlaceHolder runat="server" ID="itemPlaceholder" />
                    </ul>
                </LayoutTemplate>
                <ItemSeparatorTemplate></ItemSeparatorTemplate>
                <ItemTemplate>
                    <li class="blog_year">
                        <a class="blog_year_name ui-accordion-header" onclick="return false;">
                            <%#Eval("year")%>
                        </a>

                        <asp:ListView runat="server" ID="lvPostMonth" DataSource='<%#Eval("blogMonth")%>'>
                            <LayoutTemplate>
                                <ul>
                                    <asp:PlaceHolder runat="server" ID="itemPlaceholder" />
                                </ul>
                            </LayoutTemplate>
                            <ItemSeparatorTemplate></ItemSeparatorTemplate>
                            <ItemTemplate>
                                <li class="blog_month">
                                    <a class="blog_month_name" onclick="return false;">
                                        <span><%#Eval("monthName")%></span>
                                    </a>
                                    <asp:ListView runat="server" ID="lvBlogEntry" DataSource='<%#Eval("lstBlogEntries")%>'>
                                        <LayoutTemplate>
                                            <ul class="blog_post_items" style="display: block;">
                                                <asp:PlaceHolder runat="server" ID="itemPlaceholder" />
                                            </ul>
                                        </LayoutTemplate>
                                        <ItemSeparatorTemplate></ItemSeparatorTemplate>
                                        <ItemTemplate>
                                            <li class="blog_post_item">
                                                <a href='<%#Eval("url")%>'>
                                                    <span class="blog_post_title">
                                                        <%#Eval("title")%>
                                                    </span>
                                                </a>
                                            </li>
                                        </ItemTemplate>
                                        <EmptyDataTemplate>
                                            <div>No posts have been created yet.</div>
                                        </EmptyDataTemplate>
                                    </asp:ListView>
                                </li>

                            </ItemTemplate>
                            <EmptyDataTemplate>
                                <div>No posts have been created yet.</div>
                            </EmptyDataTemplate>
                        </asp:ListView>

                    </li>
                </ItemTemplate>
                <EmptyDataTemplate>
                    <div class="emptyDataTemplate">No posts have been created yet.</div>
                </EmptyDataTemplate>
            </asp:ListView>
        </section>


        <%--VIEW ALL--%>
        <asp:HyperLink runat="server" ID="hlnkViewAll" ClientIDMode="Static" CssClass="viewAllBlog" onclick="return false;">
            <h3>View All</h3>
        </asp:HyperLink>

        

        <div class=""><br /></div>


        <%--SEARCH--%>
        <div class="row blogSearch" id="blogSearch">
            <div class="medium-18 large-19 columns searchFld" id="searchFld">
                <input id="blogTxtSearch" type="text" placeholder="Search...">
            </div>
            <div class="medium-6 large-5 columns searchBtn" id="searchBtn">
                <img alt="" src="/Images/Common/icons/SearchIcon_Medium.png" style="" />
            </div>
        </div>

        <div class=""><br /></div>


        <%--AD SPACE--%>
        <asp:Panel runat="server" ID="pnlAdSpace" CssClass="row">
            <div class="small-22 small-push-1 columns end small-text-center medium-text-right">
                <div id='div-gpt-ad-1503081911370-3' style='height: 250px; width: 300px;'>
                    <script>
                        googletag.cmd.push(function () { googletag.display('div-gpt-ad-1503081911370-3'); });
                    </script>
                </div>
            </div>
        </asp:Panel>


    </aside>


    <div class="hide hiddenFields">
        <asp:HiddenField runat="server" ID="hfldIsListPg" ClientIDMode="Static" />
        <asp:HiddenField runat="server" ID="hfldListPgUrl" ClientIDMode="Static" />
        <asp:HiddenField runat="server" ID="hfldListId" ClientIDMode="Static" />
    </div>

    <%--<pre id="json"></pre>--%>
</div>



<%--<h6>Latest Posts</h6>
<asp:GridView runat="server" ID="gv1" />
<h6>by author</h6>
<asp:GridView runat="server" ID="gv2" />
<h6>by tag</h6>
<asp:GridView runat="server" ID="gv3" />
<h6>by date</h6>
<asp:GridView runat="server" ID="gv4" />
<h6>Full List</h6>
<asp:GridView runat="server" ID="gv5" />--%>

