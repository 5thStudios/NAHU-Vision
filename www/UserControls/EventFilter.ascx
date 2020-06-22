<%@ Control Language="vb" AutoEventWireup="false" CodeFile="EventFilter.ascx.vb" EnableViewState="false" Inherits="EventFilter" %>
<%@ Register Src="../UserControls/MeetTheAuthors.ascx" TagName="MeetTheAuthors" TagPrefix="uc" %>



<div class="row collapse eventFilter">
    <div class="small-24 columns">

    <%--FILTERED BY--%>
    <h4>Filter By <span id="lblFilterBy" class="camelCase"><%--: Author--%></span></h4>

    <aside class="hidePrint eventFilters">




        <%--POSTS BY EVENT TYPE--%>
        <section class="accordion eventTypes">
            <h3>Event Type
            </h3>
            <asp:ListView runat="server" ID="lvEventTypes">
                <LayoutTemplate>
                    <ul>
                        <asp:PlaceHolder runat="server" ID="itemPlaceholder" />
                    </ul>
                </LayoutTemplate>
                <ItemSeparatorTemplate></ItemSeparatorTemplate>
                <ItemTemplate>
                    <li>
                        <asp:HyperLink   runat ="server"   ID="hlnk"   data-filterby="eventType"   data-filterid='<%#Eval("id")%>'    data-filtername='<%#Eval("name")%>'   Text='<%#Eval("name")%>'   onclick="return false;" />
                    </li>
                </ItemTemplate>
                <EmptyDataTemplate>
                    <div class="emptyDataTemplate">No tags have been created yet.</div>
                </EmptyDataTemplate>
            </asp:ListView>
        </section>


        <%--POSTS BY CHAPTER AFFILIATION--%>
        <section class="accordion chapters">
            <h3>Chapter Affiliation
            </h3>
            <asp:ListView runat="server" ID="lvChapterAffiliation">
                <LayoutTemplate>
                    <ul>
                        <asp:PlaceHolder runat="server" ID="itemPlaceholder" />
                    </ul>
                </LayoutTemplate>
                <ItemSeparatorTemplate></ItemSeparatorTemplate>
                <ItemTemplate>
                    <li>
                        <asp:HyperLink   runat ="server"   ID="hlnk"   data-filterby="chapter"   data-filterid='<%#Eval("id")%>'    data-filtername='<%#Eval("name")%>'   Text='<%#Eval("name")%>'   onclick="return false;" />
                    </li>
                </ItemTemplate>
                <EmptyDataTemplate>
                    <div class="emptyDataTemplate">No tags have been created yet.</div>
                </EmptyDataTemplate>
            </asp:ListView>
        </section>


        <%--POSTS BY DATE--%>
        <asp:PlaceHolder runat="server" ID="phPostsByDate">
            <section class="accordion">
                <h3>Posts by Date</h3>
                <asp:ListView runat="server" ID="lvEventYear">
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

                            <asp:ListView runat="server" ID="lvEventMonth" DataSource='<%#Eval("blogMonth")%>'>
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
                                        <asp:ListView runat="server" ID="lvBlogEntry" DataSource='<%#Eval("lstEventItem")%>'>
                                            <LayoutTemplate>
                                                <ul class="blog_post_items" style="display: block;">
                                                    <asp:PlaceHolder runat="server" ID="itemPlaceholder" />
                                                </ul>
                                            </LayoutTemplate>
                                            <ItemSeparatorTemplate></ItemSeparatorTemplate>
                                            <ItemTemplate>
                                                <li class="blog_post_item">
                                                    <a href='<%#Eval("eventUrl")%>'>
                                                        <span class="blog_post_title">
                                                            <%#Eval("eventTitle")%>
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
        </asp:PlaceHolder>





        <%--VIEW ALL--%>
        <asp:HyperLink runat="server" ID="hlnkViewAll" ClientIDMode="Static" CssClass="viewAllBlog" onclick="return false;">
            <h3>View All</h3>
        </asp:HyperLink>



        <div class=""><br /></div>

        <%--AD SPACE--%>
        <asp:Panel runat="server" ID="pnlAdSpace" CssClass="row">
            <div class="small-22 small-push-1 columns end small-text-center medium-text-right">
                <div id='div-gpt-ad-1503081911370-3' style='height: 250px; width: 300px;' class="small-text-center medium-text-right ">
                    <script>
                        googletag.cmd.push(function () { googletag.display('div-gpt-ad-1503081911370-3'); });
                    </script>
                </div>
            </div>
        </asp:Panel>
        <%--<div class="panel callout">[AD SPACE]</div>
        <div class=""><br /></div>
        <div class="panel callout">[AD SPACE]</div>--%>

    </aside>


        <div class="hide hiddenFields">
            <asp:HiddenField runat="server" ID="hfldIsListPg" ClientIDMode="Static" />
            <asp:HiddenField runat="server" ID="hfldListPgUrl" ClientIDMode="Static" />
        </div>

        <%--<pre id="json"></pre>--%>
    </div>

</div>
