<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="BlogFilters.ascx.vb" Inherits="mvcvb.BlogFilters" %>
<%@ Register Src="../UserControls/MeetTheAuthors.ascx" TagName="MeetTheAuthors" TagPrefix="uc" %>


<style>

/* Blog Filter
----------------------------------------------------------*/
.BlogFilter {}
.BlogFilter .sidePnl ul {list-style:none; margin:0; padding:0;}
.BlogFilter .sidePnl ul li {background-color:#f4f4f4; border:none;border-bottom:1px solid #dcddde; padding: 24px 40px 16px 40px; /*margin:0; padding:0;*/}
.BlogFilter .sidePnl ul li:last-of-type {border-bottom-color: #f4f4f4;}
.BlogFilter .sidePnl ul li:hover {/*background-color:#dcddde;*/background-color:#f1b025; }
.BlogFilter .sidePnl ul li.active {background-color:#f1b025;border-bottom-color: #f1b025; }
.BlogFilter .sidePnl ul li.active a {color:#fff;}
.BlogFilter .sidePnl ul li a {font-family:'rift',sans-serif; font-size:26px; font-weight:500; line-height:16px; margin:0; padding: 0; color:#00529a; transition: background-color 300ms ease-in-out, color 300ms ease-in-out;}




/*.viewAllBlog h2 {color:#5a5a42;background-color:#f5f5ed;border:1px solid #cccccc;font-size: 17.6px;margin: 2px 0 0 0;padding: .5em .5em .5em 2.2em;font-weight:bold;}
.viewAllBlog:hover h2 {color:#f58024;background-color:#f6f6f6;border:1px solid #f58024;}
.blogFilterPretitle span {color: #a70064;font-weight:bold;font-size: 14px;}*/



/* Accordions
----------------------------------------------------------*/
.accordion {}

/*.accordion h3 {font-family: 'rift',sans-serif;font-weight: 500;line-height: 16px;color: #00529a;transition: background-color 300ms ease-in-out, color 300ms ease-in-out;border: none;border-bottom: 1px solid #dcddde;background-image: none;font-size: 26px;background-color: #f4f4f4;}
.accordion.ui-accordion h3.ui-accordion-header { font-size: 26px; padding: 24px 40px 16px 40px;margin: 0; border-radius: 0; outline-width:0;outline-style:none;}
.accordion.ui-accordion h3.ui-accordion-header:hover { background-color: #f1b025; border-bottom-color: #f1b025; color:#fff; }
.accordion.ui-accordion h3.ui-accordion-header-active{ background-color: #f1b025; border-bottom-color: #f1b025; color:#fff; }
.accordion.ui-accordion h3.ui-accordion-header .ui-accordion-header-icon {position: absolute;left: inherit;top: 50%;margin-top: -8px;right: 1em;}*/





</style>



<div class="BlogFilter">



    <!-- Accordion -->
    <%--<div class="accordion">
        <h3>First</h3>
        <div>Lorem ipsum...</div>
    </div>--%>



            <%--FILTERED BY--%>
            <p class="blogFilterPretitle">
                Filter By &nbsp; <span id="lblFilterBy"></span>
            </p>
            <aside class="hidePrint blogFilters">

                <%--LATEST POST--%>
                <div class="accordion" id="thisBlog_LatestPosts" role="tablist">
                    <h3>Latest Posts</h3>
                    <asp:ListView runat="server" ID="lvLatestPosts">
                        <LayoutTemplate>
                            <ul>
                                <asp:PlaceHolder runat="server" ID="itemPlaceholder" />
                            </ul>
                        </LayoutTemplate>
                        <ItemTemplate>
                            <li>
                                <span><%#Eval("postDate", "{0:MMMM d, yyyy}")%></span>
                                <br>
                                <asp:HyperLink runat="server" ID="hlnkLatestPost" Target="_blank" NavigateUrl='<%#Eval("url")%>' Text='<%#Eval("title")%>' />
                                <br>
                                <br>
                            </li>
                        </ItemTemplate>
                        <EmptyDataTemplate>
                            <div>No blog entries have been created yet.</div>
                        </EmptyDataTemplate>
                    </asp:ListView>
                </div>
                <%--<div class="thisBlog_posts_container thisBlog_bottom_border accordion ui-accordion ui-widget ui-helper-reset" id="thisBlog_LatestPosts" role="tablist">
                    <h3 class="thisBlog_head_style20 ui-accordion-header ui-state-default ui-corner-all ui-accordion-icons" role="tab" id="ui-id-1" aria-controls="ui-id-2" aria-selected="false" aria-expanded="false" tabindex="0"><span class="ui-accordion-header-icon ui-icon ui-icon-triangle-1-e"></span>Latest Posts</h3>

                    <asp:ListView runat="server" ID="lvLatestPosts">
                        <LayoutTemplate>
                            <ul class="ui-accordion-content ui-helper-reset ui-widget-content ui-corner-bottom" id="ui-id-2" aria-labelledby="ui-id-1" role="tabpanel" aria-hidden="true" style="display: none;">
                                <asp:PlaceHolder runat="server" ID="itemPlaceholder" />
                            </ul>
                        </LayoutTemplate>
                        <ItemTemplate>
                            <li>
                                <span><%#Eval("postDate", "{0:MMMM d, yyyy}")%></span>
                                <br>
                                <asp:HyperLink runat="server" ID="hlnkLatestPost" Target="_blank" NavigateUrl='<%#Eval("url")%>' Text='<%#Eval("title")%>' />
                                <br>
                                <br>
                            </li>
                        </ItemTemplate>
                        <EmptyDataTemplate>
                            <div>No blog entries have been created yet.</div>
                        </EmptyDataTemplate>
                    </asp:ListView>

                </div>--%>


                <%--POSTS BY AUTHOR--%>
                <section class="thisBlog_authors_container thisBlog_bottom_border accordion ui-accordion ui-widget ui-helper-reset" role="tablist">
                    <h3 class="thisBlog_head_style20 ui-accordion-header ui-state-default ui-corner-all ui-accordion-icons" role="tab" id="ui-id-3" aria-controls="ui-id-4" aria-selected="false" aria-expanded="false" tabindex="0"><span class="ui-accordion-header-icon ui-icon ui-icon-triangle-1-e"></span>
                        Posts by Author
                    </h3>
                    <asp:ListView runat="server" ID="lvPostsByAuthor">
                        <LayoutTemplate>
                            <ul class="thisBlog_authors ui-accordion-content ui-helper-reset ui-widget-content ui-corner-bottom" id="ui-id-4" aria-labelledby="ui-id-3" role="tabpanel" aria-hidden="true" style="display: none;">
                                <asp:PlaceHolder runat="server" ID="itemPlaceholder" />
                            </ul>
                        </LayoutTemplate>
                        <ItemSeparatorTemplate>
                            <br />
                        </ItemSeparatorTemplate>
                        <ItemTemplate>
                            <li>
                                <%--<a href='<%#Eval("url")%>' title='<%#Eval("author")%>'><%#Eval("author")%></a>--%>
                                <div>
                                    <a href="#'<%#Eval("id")%>'" onclick="return false;" data-filterby="author" data-filterid="<%#Eval("id")%>" data-filtername="<%#Eval("name")%>">
                                        <%#Eval("name")%>
                                    </a>
                                </div>
                            </li>
                        </ItemTemplate>
                        <EmptyDataTemplate>
                            <div>No authors have been created yet.</div>
                        </EmptyDataTemplate>
                    </asp:ListView>
                </section>


                <%--POSTS BY TAG--%>
                <div class="thisBlog_tag_container thisBlog_bottom_border accordion ui-accordion ui-widget ui-helper-reset" role="tablist">
                    <h3 class="thisBlog_head_style20 ui-accordion-header ui-state-default ui-corner-all ui-accordion-icons" role="tab" id="ui-id-5" aria-controls="ui-id-6" aria-selected="false" aria-expanded="false" tabindex="0"><span class="ui-accordion-header-icon ui-icon ui-icon-triangle-1-e"></span>
                        Posts by Tag
                    </h3>
                    <asp:ListView runat="server" ID="lvPostsByTag">
                        <LayoutTemplate>
                            <ul class="thisBlog_tags thisBlog_tag_cloud ui-accordion-content ui-helper-reset ui-widget-content ui-corner-bottom" id="ui-id-6" aria-labelledby="ui-id-5" role="tabpanel" aria-hidden="true" style="display: none;">
                                <asp:PlaceHolder runat="server" ID="itemPlaceholder" />
                            </ul>
                        </LayoutTemplate>
                        <ItemSeparatorTemplate>&nbsp;&nbsp;&nbsp;</ItemSeparatorTemplate>
                        <ItemTemplate>
                            <li>
                                <%--<a href='<%#Eval("url")%>' class='thisBlog_tag_cloud<%#Eval("count")%>' title='<%#Eval("tag")%>'><%#Eval("tag")%></a>
                            <span>(<%#Eval("count")%>)</span>--%>
                                <div>
                                    <a href="#'<%#Eval("id")%>'" onclick="return false;" data-filterby="tag" data-filterid="<%#Eval("id")%>" data-filtername="<%#Eval("name")%>">
                                        <%#Eval("name")%>
                                    </a>
                                </div>
                            </li>
                        </ItemTemplate>
                        <EmptyDataTemplate>
                            <div>No tags have been created yet.</div>
                        </EmptyDataTemplate>
                    </asp:ListView>
                </div>


                <%--POSTS BY DATE--%>
                <section class="thisBlog_archive thisBlog_bottom_border accordion ui-accordion ui-widget ui-helper-reset" role="tablist">
                    <h3 class="thisBlog_head_style20 ui-accordion-header ui-state-default ui-corner-all ui-accordion-icons" role="tab" id="ui-id-7" aria-controls="thisBlog_post_archive" aria-selected="false" aria-expanded="false" tabindex="0"><span class="ui-accordion-header-icon ui-icon ui-icon-triangle-1-e"></span>Posts by Date</h3>
                    <div id="thisBlog_post_archive" class="ui-accordion-content ui-helper-reset ui-widget-content ui-corner-bottom" aria-labelledby="ui-id-7" role="tabpanel" aria-hidden="true" style="display: none;">

                        <asp:ListView runat="server" ID="lvPostYear">
                            <LayoutTemplate>
                                <ul class="thisBlog_years accordion ui-accordion ui-widget ui-helper-reset" role="tablist">
                                    <asp:PlaceHolder runat="server" ID="itemPlaceholder" />
                                </ul>
                            </LayoutTemplate>
                            <ItemSeparatorTemplate></ItemSeparatorTemplate>
                            <ItemTemplate>

                                <li class="thisBlog_year thisBlog_year_first">
                                    <a class="thisBlog_year_name ui-accordion-header ui-state-default ui-accordion-icons ui-accordion-header-active ui-state-active ui-corner-top" href="#" role="tab" aria-selected="true" aria-expanded="true" tabindex="0">
                                        <span class="ui-accordion-header-icon ui-icon ui-icon-triangle-1-s"></span>
                                        <span><%#Eval("year")%></span>
                                    </a>
                                    <asp:ListView runat="server" ID="lvPostMonth" DataSource='<%#Eval("blogMonth")%>'>
                                        <LayoutTemplate>
                                            <ul class="thisBlog_months ui-accordion-content ui-helper-reset ui-widget-content ui-corner-bottom ui-accordion-content-active" role="tabpanel" aria-hidden="false" style="display: none;">
                                                <asp:PlaceHolder runat="server" ID="itemPlaceholder" />
                                            </ul>

                                        </LayoutTemplate>
                                        <ItemSeparatorTemplate></ItemSeparatorTemplate>
                                        <ItemTemplate>

                                            <li class="thisBlog_month">
                                                <a class="thisBlog_month_name" href="#">
                                                    <span><%#Eval("monthName")%></span>
                                                </a>
                                                <asp:ListView runat="server" ID="lvBlogEntry" DataSource='<%#Eval("lstBlogEntries")%>'>
                                                    <LayoutTemplate>
                                                        <ul class="thisBlog_post_items" style="display: block;">
                                                            <asp:PlaceHolder runat="server" ID="itemPlaceholder" />
                                                        </ul>
                                                    </LayoutTemplate>
                                                    <ItemSeparatorTemplate></ItemSeparatorTemplate>
                                                    <ItemTemplate>
                                                        <li class="thisBlog_post_item">
                                                            <a href='<%#Eval("url")%>'>
                                                                <span class="thisBlog_post_title">
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
                                <div>No posts have been created yet.</div>
                            </EmptyDataTemplate>
                        </asp:ListView>

                    </div>
                </section>


                <%--VIEW ALL--%>
                <asp:HyperLink runat="server" ID="hlnkViewAll" CssClass="viewAllBlog">
                <h3>View All</h3>
                </asp:HyperLink>


                <div class="">&nbsp;</div>


                <%--SEARCH--%>
                <div class="thisBlog_search">
                    <div class="left">
                        <input id="thisBlogTxtSearch" type="text" placeholder="Search">
                    </div>
                    <div class="right">
                        <input id="thisBlogBtnSearch" type="submit" class="button" value="Submit">
                    </div>
                    <div class="clearfix"></div>
                </div>


                <%--AD SPACE--%>
                <%--<div class="row">
                <div class="columns">--%>
                <div>[AD SPACE]</div>
                <div>
                    <asp:GridView runat="server" ID="gv" />
                </div>
                <%--</div>
            </div>--%>
            </aside>










            <br>
            <hr />
            <br>



            <div id="1_pnlSide" class="sidePnl">
                <ul>
                    <li data-nodeid="1135" class="active"><a href="/membership/join-now/">Join Now</a></li>
                    <li data-nodeid="1136"><a href="/membership/why-join-nahu/">Why Join NAHU</a></li>
                    <li data-nodeid="1137"><a href="/membership/renew/">Renew</a><ul>
                        <li data-nodeid="1340"><a href="/membership/renew/membership-reinstatement/">Membership Reinstatement</a></li>
                        <li data-nodeid="1339"><a href="/membership/renew/monthly-membership-renewal/">Monthly Membership &amp; Renewal</a></li>
                    </ul>
                    </li>
                    <li data-nodeid="1138"><a href="/membership/corporate-partnership/">Corporate Partnership</a><ul></ul>
                    </li>
                    <li data-nodeid="1140"><a href="/membership/board-of-trustees/">Board of Trustees</a><ul></ul>
                    </li>
                </ul>
            </div>



</div>


<%--<div>

    <div id="MainContent_pnl" class="row collapse">

        <div class="small-24 columns">

            <div class="textCenter">
                <a id="MainContent_ctl02_ctl00_hlnkReturnToMHL" class="button submitInput" href="/mission-healthy-living.aspx">Back to Mission Healthy Living</a>
            </div>

            <p class="blogFilterPretitle">
                Filter By &nbsp;
            <span></span>
            </p>

            <aside class="hidePrint blogFilters">

                <div class="thisBlog_posts_container thisBlog_bottom_border accordion ui-accordion ui-widget ui-helper-reset" id="thisBlog_LatestPosts" role="tablist">
                    <h2 class="thisBlog_head_style20 ui-accordion-header ui-state-default ui-corner-all ui-accordion-icons" role="tab" id="ui-id-1" aria-controls="ui-id-2" aria-selected="false" aria-expanded="false" tabindex="0"><span class="ui-accordion-header-icon ui-icon ui-icon-triangle-1-e"></span><span class="ui-accordion-header-icon ui-icon ui-icon-triangle-1-e"></span>Latest Posts</h2>


                    <ul class="ui-accordion-content ui-helper-reset ui-widget-content ui-corner-bottom" id="ui-id-2" aria-labelledby="ui-id-1" role="tabpanel" aria-hidden="true" style="display: none;">

                        <li>
                            <span>March 24, 2017</span>
                            <br>
                            <a href="/mission-healthy-living/blog/blog-entries/seed-starter-for-spring.aspx" title="Seed starter for spring!">'Seed starter for spring!'</a>
                            <br>
                            <br>
                        </li>

                        <li>
                            <span>March 17, 2017</span>
                            <br>
                            <a href="/mission-healthy-living/blog/blog-entries/go-green-for-st-paddys-day.aspx" title="Go Green for St. Paddyday">'Go Green for St. Paddy's Day'</a>
                            <br>
                            <br>
                        </li>

                        <li>
                            <span>March 3, 2017</span>
                            <br>
                            <a href="/mission-healthy-living/blog/blog-entries/foundation-fridays-good-vibes.aspx" title="Foundation Fridays - Good Vibes">'Foundation Fridays - Good Vibes'</a>
                            <br>
                            <br>
                        </li>

                        <li>
                            <span>February 24, 2017</span>
                            <br>
                            <a href="/mission-healthy-living/blog/blog-entries/foundation-fridays-get-outside.aspx" title="Foundation Fridays-  Get outside!">'Foundation Fridays-  Get outside!'</a>
                            <br>
                            <br>
                        </li>

                        <li>
                            <span>February 17, 2017</span>
                            <br>
                            <a href="/mission-healthy-living/blog/blog-entries/spread-the-love.aspx" title="Spread the love ">'Spread the love '</a>
                            <br>
                            <br>
                        </li>

                    </ul>


                </div>

                <section class="thisBlog_authors_container thisBlog_bottom_border accordion ui-accordion ui-widget ui-helper-reset" role="tablist">
                    <h2 class="thisBlog_head_style20 ui-accordion-header ui-state-default ui-corner-all ui-accordion-icons" role="tab" id="ui-id-3" aria-controls="ui-id-4" aria-selected="false" aria-expanded="false" tabindex="0"><span class="ui-accordion-header-icon ui-icon ui-icon-triangle-1-e"></span><span class="ui-accordion-header-icon ui-icon ui-icon-triangle-1-e"></span>
                        Posts by Author
                    </h2>

                    <ul class="thisBlog_authors ui-accordion-content ui-helper-reset ui-widget-content ui-corner-bottom" id="ui-id-4" aria-labelledby="ui-id-3" role="tabpanel" aria-hidden="true" style="display: none;">

                        <li>
                            <a href="/mission-healthy-living/blog.aspx?author=3701" title="Skye Tulio">Skye Tulio</a>
                        </li>

                    </ul>

                </section>

                <div class="thisBlog_tag_container thisBlog_bottom_border accordion ui-accordion ui-widget ui-helper-reset" role="tablist">
                    <h2 class="thisBlog_head_style20 ui-accordion-header ui-state-default ui-corner-all ui-accordion-icons" role="tab" id="ui-id-5" aria-controls="ui-id-6" aria-selected="false" aria-expanded="false" tabindex="0"><span class="ui-accordion-header-icon ui-icon ui-icon-triangle-1-e"></span><span class="ui-accordion-header-icon ui-icon ui-icon-triangle-1-e"></span>
                        Posts by Tag
                    </h2>

                    <ul class="thisBlog_tags thisBlog_tag_cloud ui-accordion-content ui-helper-reset ui-widget-content ui-corner-bottom" id="ui-id-6" aria-labelledby="ui-id-5" role="tabpanel" aria-hidden="true" style="display: none;">

                        <li>
                            <a href="/mission-healthy-living/blog.aspx?tag=3703" class="thisBlog_tag_cloud1" title="2016">2016</a>
                            <span>(1)</span>
                        </li>
                        &nbsp;&nbsp;&nbsp;
                        <li>
                            <a href="/mission-healthy-living/blog.aspx?tag=3704" class="thisBlog_tag_cloud1" title="ACE Study">ACE Study</a>
                            <span>(1)</span>
                        </li>
                        &nbsp;&nbsp;&nbsp;
                        <li>
                            <a href="/mission-healthy-living/blog.aspx?tag=3705" class="thisBlog_tag_cloud2" title="ACES">ACES</a>
                            <span>(2)</span>
                        </li>
                        &nbsp;&nbsp;&nbsp;
                        <li>
                            <a href="/mission-healthy-living/blog.aspx?tag=3707" class="thisBlog_tag_cloud2" title="Adversity">Adversity</a>
                            <span>(2)</span>
                        </li>
                        &nbsp;&nbsp;&nbsp;
                        <li>
                            <a href="/mission-healthy-living/blog.aspx?tag=3708" class="thisBlog_tag_cloud2" title="Aging">Aging</a>
                            <span>(2)</span>
                        </li>
                        &nbsp;&nbsp;&nbsp;
                        <li>
                            <a href="/mission-healthy-living/blog.aspx?tag=3709" class="thisBlog_tag_cloud4" title="Balance">Balance</a>
                            <span>(4)</span>
                        </li>
                        &nbsp;&nbsp;&nbsp;
                        <li>
                            <a href="/mission-healthy-living/blog.aspx?tag=3710" class="thisBlog_tag_cloud3" title="Believe In Yourself">Believe In Yourself</a>
                            <span>(3)</span>
                        </li>
                        &nbsp;&nbsp;&nbsp;
                        <li>
                            <a href="/mission-healthy-living/blog.aspx?tag=3711" class="thisBlog_tag_cloud5" title="Better You">Better You</a>
                            <span>(5)</span>
                        </li>
                        &nbsp;&nbsp;&nbsp;
                        <li>
                            <a href="/mission-healthy-living/blog.aspx?tag=3712" class="thisBlog_tag_cloud1" title="Blizzard 2016">Blizzard 2016</a>
                            <span>(1)</span>
                        </li>
                        &nbsp;&nbsp;&nbsp;
                        <li>
                            <a href="/mission-healthy-living/blog.aspx?tag=3714" class="thisBlog_tag_cloud3" title="Change">Change</a>
                            <span>(3)</span>
                        </li>
                        &nbsp;&nbsp;&nbsp;
                        <li>
                            <a href="/mission-healthy-living/blog.aspx?tag=3715" class="thisBlog_tag_cloud2" title="Cold Weather">Cold Weather</a>
                            <span>(2)</span>
                        </li>
                        &nbsp;&nbsp;&nbsp;
                        <li>
                            <a href="/mission-healthy-living/blog.aspx?tag=3716" class="thisBlog_tag_cloud1" title="Commit">Commit</a>
                            <span>(1)</span>
                        </li>
                        &nbsp;&nbsp;&nbsp;
                        <li>
                            <a href="/mission-healthy-living/blog.aspx?tag=3717" class="thisBlog_tag_cloud1" title="Commitment">Commitment</a>
                            <span>(1)</span>
                        </li>
                        &nbsp;&nbsp;&nbsp;
                        <li>
                            <a href="/mission-healthy-living/blog.aspx?tag=3718" class="thisBlog_tag_cloud1" title="Common Cold">Common Cold</a>
                            <span>(1)</span>
                        </li>
                        &nbsp;&nbsp;&nbsp;
                        <li>
                            <a href="/mission-healthy-living/blog.aspx?tag=3719" class="thisBlog_tag_cloud1" title="Communication">Communication</a>
                            <span>(1)</span>
                        </li>
                        &nbsp;&nbsp;&nbsp;
                        <li>
                            <a href="/mission-healthy-living/blog.aspx?tag=3720" class="thisBlog_tag_cloud1" title="Comnet15">Comnet15</a>
                            <span>(1)</span>
                        </li>
                        &nbsp;&nbsp;&nbsp;
                        <li>
                            <a href="/mission-healthy-living/blog.aspx?tag=3721" class="thisBlog_tag_cloud1" title="Confidence">Confidence</a>
                            <span>(1)</span>
                        </li>
                        &nbsp;&nbsp;&nbsp;
                        <li>
                            <a href="/mission-healthy-living/blog.aspx?tag=3722" class="thisBlog_tag_cloud1" title="Courage">Courage</a>
                            <span>(1)</span>
                        </li>
                        &nbsp;&nbsp;&nbsp;
                        <li>
                            <a href="/mission-healthy-living/blog.aspx?tag=3723" class="thisBlog_tag_cloud1" title="David P Gallagher">David P Gallagher</a>
                            <span>(1)</span>
                        </li>
                        &nbsp;&nbsp;&nbsp;
                        <li>
                            <a href="/mission-healthy-living/blog.aspx?tag=3724" class="thisBlog_tag_cloud1" title="Easter">Easter</a>
                            <span>(1)</span>
                        </li>
                        &nbsp;&nbsp;&nbsp;
                        <li>
                            <a href="/mission-healthy-living/blog.aspx?tag=3725" class="thisBlog_tag_cloud4" title="Embrace Life">Embrace Life</a>
                            <span>(4)</span>
                        </li>
                        &nbsp;&nbsp;&nbsp;
                        <li>
                            <a href="/mission-healthy-living/blog.aspx?tag=3726" class="thisBlog_tag_cloud1" title="Encouragment">Encouragment</a>
                            <span>(1)</span>
                        </li>
                        &nbsp;&nbsp;&nbsp;
                        <li>
                            <a href="/mission-healthy-living/blog.aspx?tag=3727" class="thisBlog_tag_cloud3" title="Families">Families</a>
                            <span>(3)</span>
                        </li>
                        &nbsp;&nbsp;&nbsp;
                        <li>
                            <a href="/mission-healthy-living/blog.aspx?tag=3729" class="thisBlog_tag_cloud1" title="Family Time">Family Time</a>
                            <span>(1)</span>
                        </li>
                        &nbsp;&nbsp;&nbsp;
                        <li>
                            <a href="/mission-healthy-living/blog.aspx?tag=3730" class="thisBlog_tag_cloud1" title="Fathers Day">Fathers Day</a>
                            <span>(1)</span>
                        </li>
                        &nbsp;&nbsp;&nbsp;
                        <li>
                            <a href="/mission-healthy-living/blog.aspx?tag=3731" class="thisBlog_tag_cloud1" title="Fitness">Fitness</a>
                            <span>(1)</span>
                        </li>
                        &nbsp;&nbsp;&nbsp;
                        <li>
                            <a href="/mission-healthy-living/blog.aspx?tag=3732" class="thisBlog_tag_cloud1" title="Friday">Friday</a>
                            <span>(1)</span>
                        </li>
                        &nbsp;&nbsp;&nbsp;
                        <li>
                            <a href="/mission-healthy-living/blog.aspx?tag=3733" class="thisBlog_tag_cloud1" title="Friendship">Friendship</a>
                            <span>(1)</span>
                        </li>
                        &nbsp;&nbsp;&nbsp;
                        <li>
                            <a href="/mission-healthy-living/blog.aspx?tag=3734" class="thisBlog_tag_cloud2" title="Getting Better">Getting Better</a>
                            <span>(2)</span>
                        </li>
                        &nbsp;&nbsp;&nbsp;
                        <li>
                            <a href="/mission-healthy-living/blog.aspx?tag=3735" class="thisBlog_tag_cloud2" title="Getting To Sleep">Getting To Sleep</a>
                            <span>(2)</span>
                        </li>
                        &nbsp;&nbsp;&nbsp;
                        <li>
                            <a href="/mission-healthy-living/blog.aspx?tag=3736" class="thisBlog_tag_cloud1" title="Go Green">Go Green</a>
                            <span>(1)</span>
                        </li>
                        &nbsp;&nbsp;&nbsp;
                        <li>
                            <a href="/mission-healthy-living/blog.aspx?tag=3739" class="thisBlog_tag_cloud1" title="Gut Instinct">Gut Instinct</a>
                            <span>(1)</span>
                        </li>
                        &nbsp;&nbsp;&nbsp;
                        <li>
                            <a href="/mission-healthy-living/blog.aspx?tag=3740" class="thisBlog_tag_cloud5" title="Happiness">Happiness</a>
                            <span>(5)</span>
                        </li>
                        &nbsp;&nbsp;&nbsp;
                        <li>
                            <a href="/mission-healthy-living/blog.aspx?tag=3741" class="thisBlog_tag_cloud2" title="Healing">Healing</a>
                            <span>(2)</span>
                        </li>
                        &nbsp;&nbsp;&nbsp;
                        <li>
                            <a href="/mission-healthy-living/blog.aspx?tag=3742" class="thisBlog_tag_cloud1" title="Healthcare Costs">Healthcare Costs</a>
                            <span>(1)</span>
                        </li>
                        &nbsp;&nbsp;&nbsp;
                        <li>
                            <a href="/mission-healthy-living/blog.aspx?tag=3744" class="thisBlog_tag_cloud2" title="Healthy Living Journey">Healthy Living Journey</a>
                            <span>(2)</span>
                        </li>
                        &nbsp;&nbsp;&nbsp;
                        <li>
                            <a href="/mission-healthy-living/blog.aspx?tag=3745" class="thisBlog_tag_cloud26" title="Healty Living">Healty Living</a>
                            <span>(26)</span>
                        </li>
                        &nbsp;&nbsp;&nbsp;
                        <li>
                            <a href="/mission-healthy-living/blog.aspx?tag=3746" class="thisBlog_tag_cloud1" title="Heart Attack Risk">Heart Attack Risk</a>
                            <span>(1)</span>
                        </li>
                        &nbsp;&nbsp;&nbsp;
                        <li>
                            <a href="/mission-healthy-living/blog.aspx?tag=3747" class="thisBlog_tag_cloud1" title="Heart Health">Heart Health</a>
                            <span>(1)</span>
                        </li>
                        &nbsp;&nbsp;&nbsp;
                        <li>
                            <a href="/mission-healthy-living/blog.aspx?tag=3748" class="thisBlog_tag_cloud2" title="Holiday Season">Holiday Season</a>
                            <span>(2)</span>
                        </li>
                        &nbsp;&nbsp;&nbsp;
                        <li>
                            <a href="/mission-healthy-living/blog.aspx?tag=3749" class="thisBlog_tag_cloud1" title="Holidays">Holidays</a>
                            <span>(1)</span>
                        </li>
                        &nbsp;&nbsp;&nbsp;
                        <li>
                            <a href="/mission-healthy-living/blog.aspx?tag=3750" class="thisBlog_tag_cloud2" title="Impact">Impact</a>
                            <span>(2)</span>
                        </li>
                        &nbsp;&nbsp;&nbsp;
                        <li>
                            <a href="/mission-healthy-living/blog.aspx?tag=3751" class="thisBlog_tag_cloud1" title="Inner Peace">Inner Peace</a>
                            <span>(1)</span>
                        </li>
                        &nbsp;&nbsp;&nbsp;
                        <li>
                            <a href="/mission-healthy-living/blog.aspx?tag=3752" class="thisBlog_tag_cloud1" title="KPJR Films">KPJR Films</a>
                            <span>(1)</span>
                        </li>
                        &nbsp;&nbsp;&nbsp;
                        <li>
                            <a href="/mission-healthy-living/blog.aspx?tag=3753" class="thisBlog_tag_cloud1" title="Leader">Leader</a>
                            <span>(1)</span>
                        </li>
                        &nbsp;&nbsp;&nbsp;
                        <li>
                            <a href="/mission-healthy-living/blog.aspx?tag=3754" class="thisBlog_tag_cloud1" title="Life At The Beach">Life At The Beach</a>
                            <span>(1)</span>
                        </li>
                        &nbsp;&nbsp;&nbsp;
                        <li>
                            <a href="/mission-healthy-living/blog.aspx?tag=3755" class="thisBlog_tag_cloud3" title="Life Lessons">Life Lessons</a>
                            <span>(3)</span>
                        </li>
                        &nbsp;&nbsp;&nbsp;
                        <li>
                            <a href="/mission-healthy-living/blog.aspx?tag=3756" class="thisBlog_tag_cloud5" title="Living Happy">Living Happy</a>
                            <span>(5)</span>
                        </li>
                        &nbsp;&nbsp;&nbsp;
                        <li>
                            <a href="/mission-healthy-living/blog.aspx?tag=3757" class="thisBlog_tag_cloud3" title="Living Healthier">Living Healthier</a>
                            <span>(3)</span>
                        </li>
                        &nbsp;&nbsp;&nbsp;
                        <li>
                            <a href="/mission-healthy-living/blog.aspx?tag=3759" class="thisBlog_tag_cloud2" title="Motherhood">Motherhood</a>
                            <span>(2)</span>
                        </li>
                        &nbsp;&nbsp;&nbsp;
                        <li>
                            <a href="/mission-healthy-living/blog.aspx?tag=3760" class="thisBlog_tag_cloud1" title="Moving More">Moving More</a>
                            <span>(1)</span>
                        </li>
                        &nbsp;&nbsp;&nbsp;
                        <li>
                            <a href="/mission-healthy-living/blog.aspx?tag=3761" class="thisBlog_tag_cloud1" title="Music">Music</a>
                            <span>(1)</span>
                        </li>
                        &nbsp;&nbsp;&nbsp;
                        <li>
                            <a href="/mission-healthy-living/blog.aspx?tag=3762" class="thisBlog_tag_cloud1" title="New Hampshire">New Hampshire</a>
                            <span>(1)</span>
                        </li>
                        &nbsp;&nbsp;&nbsp;
                        <li>
                            <a href="/mission-healthy-living/blog.aspx?tag=3763" class="thisBlog_tag_cloud1" title="New Job">New Job</a>
                            <span>(1)</span>
                        </li>
                        &nbsp;&nbsp;&nbsp;
                        <li>
                            <a href="/mission-healthy-living/blog.aspx?tag=3764" class="thisBlog_tag_cloud1" title="New Year">New Year's Resolution</a>
                            <span>(1)</span>
                        </li>
                        &nbsp;&nbsp;&nbsp;
                        <li>
                            <a href="/mission-healthy-living/blog.aspx?tag=3765" class="thisBlog_tag_cloud3" title="Night Owl">Night Owl</a>
                            <span>(3)</span>
                        </li>
                        &nbsp;&nbsp;&nbsp;
                        <li>
                            <a href="/mission-healthy-living/blog.aspx?tag=3766" class="thisBlog_tag_cloud1" title="Night-Time Routine">Night-Time Routine</a>
                            <span>(1)</span>
                        </li>
                        &nbsp;&nbsp;&nbsp;
                        <li>
                            <a href="/mission-healthy-living/blog.aspx?tag=3767" class="thisBlog_tag_cloud1" title="Obesity">Obesity</a>
                            <span>(1)</span>
                        </li>
                        &nbsp;&nbsp;&nbsp;
                        <li>
                            <a href="/mission-healthy-living/blog.aspx?tag=3768" class="thisBlog_tag_cloud1" title="Obstacles">Obstacles</a>
                            <span>(1)</span>
                        </li>
                        &nbsp;&nbsp;&nbsp;
                        <li>
                            <a href="/mission-healthy-living/blog.aspx?tag=3769" class="thisBlog_tag_cloud1" title="Old Age">Old Age</a>
                            <span>(1)</span>
                        </li>
                        &nbsp;&nbsp;&nbsp;
                        <li>
                            <a href="/mission-healthy-living/blog.aspx?tag=3770" class="thisBlog_tag_cloud1" title="Overwhelmed">Overwhelmed</a>
                            <span>(1)</span>
                        </li>
                        &nbsp;&nbsp;&nbsp;
                        <li>
                            <a href="/mission-healthy-living/blog.aspx?tag=3771" class="thisBlog_tag_cloud1" title="Pace">Pace</a>
                            <span>(1)</span>
                        </li>
                        &nbsp;&nbsp;&nbsp;
                        <li>
                            <a href="/mission-healthy-living/blog.aspx?tag=3772" class="thisBlog_tag_cloud2" title="Parenting">Parenting</a>
                            <span>(2)</span>
                        </li>
                        &nbsp;&nbsp;&nbsp;
                        <li>
                            <a href="/mission-healthy-living/blog.aspx?tag=3773" class="thisBlog_tag_cloud4" title="Peace">Peace</a>
                            <span>(4)</span>
                        </li>
                        &nbsp;&nbsp;&nbsp;
                        <li>
                            <a href="/mission-healthy-living/blog.aspx?tag=3774" class="thisBlog_tag_cloud8" title="Physical Well-Being">Physical Well-Being</a>
                            <span>(8)</span>
                        </li>
                        &nbsp;&nbsp;&nbsp;
                        <li>
                            <a href="/mission-healthy-living/blog.aspx?tag=3775" class="thisBlog_tag_cloud2" title="Positive Influence">Positive Influence</a>
                            <span>(2)</span>
                        </li>
                        &nbsp;&nbsp;&nbsp;
                        <li>
                            <a href="/mission-healthy-living/blog.aspx?tag=3776" class="thisBlog_tag_cloud1" title="Positive Reinforcement">Positive Reinforcement</a>
                            <span>(1)</span>
                        </li>
                        &nbsp;&nbsp;&nbsp;
                        <li>
                            <a href="/mission-healthy-living/blog.aspx?tag=3778" class="thisBlog_tag_cloud1" title="Power Of Music">Power Of Music</a>
                            <span>(1)</span>
                        </li>
                        &nbsp;&nbsp;&nbsp;
                        <li>
                            <a href="/mission-healthy-living/blog.aspx?tag=3779" class="thisBlog_tag_cloud1" title="Problem-Solving">Problem-Solving</a>
                            <span>(1)</span>
                        </li>
                        &nbsp;&nbsp;&nbsp;
                        <li>
                            <a href="/mission-healthy-living/blog.aspx?tag=3782" class="thisBlog_tag_cloud1" title="Road Trip">Road Trip</a>
                            <span>(1)</span>
                        </li>
                        &nbsp;&nbsp;&nbsp;
                        <li>
                            <a href="/mission-healthy-living/blog.aspx?tag=3783" class="thisBlog_tag_cloud1" title="Role Model">Role Model</a>
                            <span>(1)</span>
                        </li>
                        &nbsp;&nbsp;&nbsp;
                        <li>
                            <a href="/mission-healthy-living/blog.aspx?tag=3784" class="thisBlog_tag_cloud1" title="Seasons">Seasons</a>
                            <span>(1)</span>
                        </li>
                        &nbsp;&nbsp;&nbsp;
                        <li>
                            <a href="/mission-healthy-living/blog.aspx?tag=3785" class="thisBlog_tag_cloud1" title="Shenandoah Chefalo">Shenandoah Chefalo</a>
                            <span>(1)</span>
                        </li>
                        &nbsp;&nbsp;&nbsp;
                        <li>
                            <a href="/mission-healthy-living/blog.aspx?tag=3786" class="thisBlog_tag_cloud2" title="Sleep">Sleep</a>
                            <span>(2)</span>
                        </li>
                        &nbsp;&nbsp;&nbsp;
                        <li>
                            <a href="/mission-healthy-living/blog.aspx?tag=3787" class="thisBlog_tag_cloud1" title="Smell The Roses">Smell The Roses</a>
                            <span>(1)</span>
                        </li>
                        &nbsp;&nbsp;&nbsp;
                        <li>
                            <a href="/mission-healthy-living/blog.aspx?tag=3788" class="thisBlog_tag_cloud1" title="Soda">Soda</a>
                            <span>(1)</span>
                        </li>
                        &nbsp;&nbsp;&nbsp;
                        <li>
                            <a href="/mission-healthy-living/blog.aspx?tag=3789" class="thisBlog_tag_cloud4" title="Spring">Spring</a>
                            <span>(4)</span>
                        </li>
                        &nbsp;&nbsp;&nbsp;
                        <li>
                            <a href="/mission-healthy-living/blog.aspx?tag=3790" class="thisBlog_tag_cloud1" title="Spring Cleaning">Spring Cleaning</a>
                            <span>(1)</span>
                        </li>
                        &nbsp;&nbsp;&nbsp;
                        <li>
                            <a href="/mission-healthy-living/blog.aspx?tag=3791" class="thisBlog_tag_cloud1" title="Spring-Like">Spring-Like</a>
                            <span>(1)</span>
                        </li>
                        &nbsp;&nbsp;&nbsp;
                        <li>
                            <a href="/mission-healthy-living/blog.aspx?tag=3792" class="thisBlog_tag_cloud1" title="St. Patrick">St. Patrick's Day</a>
                            <span>(1)</span>
                        </li>
                        &nbsp;&nbsp;&nbsp;
                        <li>
                            <a href="/mission-healthy-living/blog.aspx?tag=3793" class="thisBlog_tag_cloud1" title="Stair Master">Stair Master</a>
                            <span>(1)</span>
                        </li>
                        &nbsp;&nbsp;&nbsp;
                        <li>
                            <a href="/mission-healthy-living/blog.aspx?tag=3794" class="thisBlog_tag_cloud2" title="Strength">Strength</a>
                            <span>(2)</span>
                        </li>
                        &nbsp;&nbsp;&nbsp;
                        <li>
                            <a href="/mission-healthy-living/blog.aspx?tag=3795" class="thisBlog_tag_cloud5" title="Stress">Stress</a>
                            <span>(5)</span>
                        </li>
                        &nbsp;&nbsp;&nbsp;
                        <li>
                            <a href="/mission-healthy-living/blog.aspx?tag=3796" class="thisBlog_tag_cloud1" title="Stress Management">Stress Management</a>
                            <span>(1)</span>
                        </li>
                        &nbsp;&nbsp;&nbsp;
                        <li>
                            <a href="/mission-healthy-living/blog.aspx?tag=3797" class="thisBlog_tag_cloud4" title="Stress Relief">Stress Relief</a>
                            <span>(4)</span>
                        </li>
                        &nbsp;&nbsp;&nbsp;
                        <li>
                            <a href="/mission-healthy-living/blog.aspx?tag=3799" class="thisBlog_tag_cloud1" title="Sunshine">Sunshine</a>
                            <span>(1)</span>
                        </li>
                        &nbsp;&nbsp;&nbsp;
                        <li>
                            <a href="/mission-healthy-living/blog.aspx?tag=3800" class="thisBlog_tag_cloud2" title="Teenagers">Teenagers</a>
                            <span>(2)</span>
                        </li>
                        &nbsp;&nbsp;&nbsp;
                        <li>
                            <a href="/mission-healthy-living/blog.aspx?tag=3801" class="thisBlog_tag_cloud4" title="Tranquility">Tranquility</a>
                            <span>(4)</span>
                        </li>
                        &nbsp;&nbsp;&nbsp;
                        <li>
                            <a href="/mission-healthy-living/blog.aspx?tag=3802" class="thisBlog_tag_cloud2" title="Trauma">Trauma</a>
                            <span>(2)</span>
                        </li>
                        &nbsp;&nbsp;&nbsp;
                        <li>
                            <a href="/mission-healthy-living/blog.aspx?tag=3803" class="thisBlog_tag_cloud1" title="Trust Your Gut">Trust Your Gut</a>
                            <span>(1)</span>
                        </li>
                        &nbsp;&nbsp;&nbsp;
                        <li>
                            <a href="/mission-healthy-living/blog.aspx?tag=3804" class="thisBlog_tag_cloud2" title="Unplug">Unplug</a>
                            <span>(2)</span>
                        </li>
                        &nbsp;&nbsp;&nbsp;
                        <li>
                            <a href="/mission-healthy-living/blog.aspx?tag=3805" class="thisBlog_tag_cloud1" title="Vacation">Vacation</a>
                            <span>(1)</span>
                        </li>
                        &nbsp;&nbsp;&nbsp;
                        <li>
                            <a href="/mission-healthy-living/blog.aspx?tag=3806" class="thisBlog_tag_cloud1" title="Volunteering">Volunteering</a>
                            <span>(1)</span>
                        </li>
                        &nbsp;&nbsp;&nbsp;
                        <li>
                            <a href="/mission-healthy-living/blog.aspx?tag=3807" class="thisBlog_tag_cloud3" title="Walking">Walking</a>
                            <span>(3)</span>
                        </li>
                        &nbsp;&nbsp;&nbsp;
                        <li>
                            <a href="/mission-healthy-living/blog.aspx?tag=3808" class="thisBlog_tag_cloud1" title="Weekend">Weekend</a>
                            <span>(1)</span>
                        </li>
                        &nbsp;&nbsp;&nbsp;
                        <li>
                            <a href="/mission-healthy-living/blog.aspx?tag=3809" class="thisBlog_tag_cloud1" title="Weight Management">Weight Management</a>
                            <span>(1)</span>
                        </li>
                        &nbsp;&nbsp;&nbsp;
                        <li>
                            <a href="/mission-healthy-living/blog.aspx?tag=3810" class="thisBlog_tag_cloud5" title="Well-Being">Well-Being</a>
                            <span>(5)</span>
                        </li>
                        &nbsp;&nbsp;&nbsp;
                        <li>
                            <a href="/mission-healthy-living/blog.aspx?tag=3811" class="thisBlog_tag_cloud4" title="Winter">Winter</a>
                            <span>(4)</span>
                        </li>
                        &nbsp;&nbsp;&nbsp;
                        <li>
                            <a href="/mission-healthy-living/blog.aspx?tag=3812" class="thisBlog_tag_cloud1" title="Winter Storm Jonas">Winter Storm Jonas</a>
                            <span>(1)</span>
                        </li>

                    </ul>

                </div>

                <section class="thisBlog_archive thisBlog_bottom_border accordion ui-accordion ui-widget ui-helper-reset" role="tablist">
                    <h2 class="thisBlog_head_style20 ui-accordion-header ui-state-default ui-corner-all ui-accordion-icons" role="tab" id="ui-id-7" aria-controls="thisBlog_post_archive" aria-selected="false" aria-expanded="false" tabindex="0"><span class="ui-accordion-header-icon ui-icon ui-icon-triangle-1-e"></span><span class="ui-accordion-header-icon ui-icon ui-icon-triangle-1-e"></span>Posts by Date</h2>
                    <div id="thisBlog_post_archive" class="ui-accordion-content ui-helper-reset ui-widget-content ui-corner-bottom" aria-labelledby="ui-id-7" role="tabpanel" aria-hidden="true" style="display: none;">


                        <ul class="thisBlog_years accordion ui-accordion ui-widget ui-helper-reset" role="tablist">


                            <li class="thisBlog_year thisBlog_year_first">
                                <a class="thisBlog_year_name ui-accordion-header ui-state-default ui-accordion-icons ui-accordion-header-active ui-state-active ui-corner-top ui-corner-all" href="#" role="tab" aria-selected="false" aria-expanded="false" tabindex="0" id="ui-id-1" aria-controls="ui-id-2"><span class="ui-accordion-header-icon ui-icon ui-icon-triangle-1-e"></span>
                                    <span class="ui-accordion-header-icon ui-icon ui-icon-triangle-1-s"></span>
                                    <span>2017</span>
                                </a>

                                <ul class="thisBlog_months ui-accordion-content ui-helper-reset ui-widget-content ui-corner-bottom ui-accordion-content-active" role="tabpanel" aria-hidden="true" style="display: none;" id="ui-id-2" aria-labelledby="ui-id-1">


                                    <li class="thisBlog_month">
                                        <a class="thisBlog_month_name" href="#">
                                            <span>March</span>
                                        </a>

                                        <ul class="thisBlog_post_items" style="display: block;">

                                            <li class="thisBlog_post_item">
                                                <a href="/mission-healthy-living/blog/blog-entries/seed-starter-for-spring.aspx">
                                                    <span class="thisBlog_post_title">Seed starter for spring!
                                                    </span>
                                                </a>
                                            </li>

                                            <li class="thisBlog_post_item">
                                                <a href="/mission-healthy-living/blog/blog-entries/go-green-for-st-paddys-day.aspx">
                                                    <span class="thisBlog_post_title">Go Green for St. Paddy's Day
                                                    </span>
                                                </a>
                                            </li>

                                            <li class="thisBlog_post_item">
                                                <a href="/mission-healthy-living/blog/blog-entries/foundation-fridays-good-vibes.aspx">
                                                    <span class="thisBlog_post_title">Foundation Fridays - Good Vibes
                                                    </span>
                                                </a>
                                            </li>

                                        </ul>

                                    </li>



                                    <li class="thisBlog_month">
                                        <a class="thisBlog_month_name" href="#">
                                            <span>February</span>
                                        </a>

                                        <ul class="thisBlog_post_items" style="display: block;">

                                            <li class="thisBlog_post_item">
                                                <a href="/mission-healthy-living/blog/blog-entries/foundation-fridays-get-outside.aspx">
                                                    <span class="thisBlog_post_title">Foundation Fridays-  Get outside!
                                                    </span>
                                                </a>
                                            </li>

                                            <li class="thisBlog_post_item">
                                                <a href="/mission-healthy-living/blog/blog-entries/spread-the-love.aspx">
                                                    <span class="thisBlog_post_title">Spread the love
                                                    </span>
                                                </a>
                                            </li>

                                            <li class="thisBlog_post_item">
                                                <a href="/mission-healthy-living/blog/blog-entries/the-flourishing-child-parts-3-4.aspx">
                                                    <span class="thisBlog_post_title">The Flourishing Child: Parts 3 &amp; 4
                                                    </span>
                                                </a>
                                            </li>

                                            <li class="thisBlog_post_item">
                                                <a href="/mission-healthy-living/blog/blog-entries/the-flourishing-child-parts-1-2.aspx">
                                                    <span class="thisBlog_post_title">The Flourishing Child: Parts 1 &amp; 2
                                                    </span>
                                                </a>
                                            </li>

                                        </ul>

                                    </li>



                                    <li class="thisBlog_month">
                                        <a class="thisBlog_month_name" href="#">
                                            <span>January</span>
                                        </a>

                                        <ul class="thisBlog_post_items" style="display: block;">

                                            <li class="thisBlog_post_item">
                                                <a href="/mission-healthy-living/blog/blog-entries/foundation-fridays-if-theres-a-will-theres-a-way.aspx">
                                                    <span class="thisBlog_post_title">Foundation Fridays- If there's a will, there's a way
                                                    </span>
                                                </a>
                                            </li>

                                            <li class="thisBlog_post_item">
                                                <a href="/mission-healthy-living/blog/blog-entries/never-give-up.aspx">
                                                    <span class="thisBlog_post_title">Never give up
                                                    </span>
                                                </a>
                                            </li>

                                            <li class="thisBlog_post_item">
                                                <a href="/mission-healthy-living/blog/blog-entries/foundation-fridays-culture-of-health.aspx">
                                                    <span class="thisBlog_post_title">Foundation Fridays- Culture of Health
                                                    </span>
                                                </a>
                                            </li>

                                            <li class="thisBlog_post_item">
                                                <a href="/mission-healthy-living/blog/blog-entries/foundation-friday-think-summer.aspx">
                                                    <span class="thisBlog_post_title">Foundation Friday- Think Summer
                                                    </span>
                                                </a>
                                            </li>

                                        </ul>

                                    </li>


                                </ul>


                            </li>



                            <li class="thisBlog_year thisBlog_year_first">
                                <a class="thisBlog_year_name ui-accordion-header ui-state-default ui-accordion-icons ui-accordion-header-active ui-state-active ui-corner-top ui-corner-all" href="#" role="tab" aria-selected="false" aria-expanded="false" tabindex="-1" id="ui-id-3" aria-controls="ui-id-4"><span class="ui-accordion-header-icon ui-icon ui-icon-triangle-1-e"></span>
                                    <span class="ui-accordion-header-icon ui-icon ui-icon-triangle-1-s"></span>
                                    <span>2016</span>
                                </a>

                                <ul class="thisBlog_months ui-accordion-content ui-helper-reset ui-widget-content ui-corner-bottom ui-accordion-content-active" role="tabpanel" aria-hidden="true" style="display: none;" id="ui-id-4" aria-labelledby="ui-id-3">


                                    <li class="thisBlog_month">
                                        <a class="thisBlog_month_name" href="#">
                                            <span>December</span>
                                        </a>

                                        <ul class="thisBlog_post_items" style="display: block;">

                                            <li class="thisBlog_post_item">
                                                <a href="/mission-healthy-living/blog/blog-entries/happy-holidays-from-pahwf.aspx">
                                                    <span class="thisBlog_post_title">Happy Holidays from PAHWF!
                                                    </span>
                                                </a>
                                            </li>

                                            <li class="thisBlog_post_item">
                                                <a href="/mission-healthy-living/blog/blog-entries/25-days-of-kindness.aspx">
                                                    <span class="thisBlog_post_title">25 Days of Kindness
                                                    </span>
                                                </a>
                                            </li>

                                        </ul>

                                    </li>



                                    <li class="thisBlog_month">
                                        <a class="thisBlog_month_name" href="#">
                                            <span>November</span>
                                        </a>

                                        <ul class="thisBlog_post_items" style="display: block;">

                                            <li class="thisBlog_post_item">
                                                <a href="/mission-healthy-living/blog/blog-entries/there-is-always-something-to-be-grateful-for.aspx">
                                                    <span class="thisBlog_post_title">There is always something to be grateful for
                                                    </span>
                                                </a>
                                            </li>

                                            <li class="thisBlog_post_item">
                                                <a href="/mission-healthy-living/blog/blog-entries/foundation-friday-give-back.aspx">
                                                    <span class="thisBlog_post_title">Foundation Friday- Give Back
                                                    </span>
                                                </a>
                                            </li>

                                            <li class="thisBlog_post_item">
                                                <a href="/mission-healthy-living/blog/blog-entries/foundation-friday-be-kind.aspx">
                                                    <span class="thisBlog_post_title">Foundation Friday- Be Kind
                                                    </span>
                                                </a>
                                            </li>

                                            <li class="thisBlog_post_item">
                                                <a href="/mission-healthy-living/blog/blog-entries/foundation-fridays-bikerunkayak-to-work.aspx">
                                                    <span class="thisBlog_post_title">Foundation Fridays- Bike/Run/Kayak to Work
                                                    </span>
                                                </a>
                                            </li>

                                        </ul>

                                    </li>



                                    <li class="thisBlog_month">
                                        <a class="thisBlog_month_name" href="#">
                                            <span>October</span>
                                        </a>

                                        <ul class="thisBlog_post_items" style="display: block;">

                                            <li class="thisBlog_post_item">
                                                <a href="/mission-healthy-living/blog/blog-entries/foundation-fridays-defy-the-odds.aspx">
                                                    <span class="thisBlog_post_title">Foundation Fridays- Defy the Odds
                                                    </span>
                                                </a>
                                            </li>

                                            <li class="thisBlog_post_item">
                                                <a href="/mission-healthy-living/blog/blog-entries/foundation-fridays-kids-who-garden.aspx">
                                                    <span class="thisBlog_post_title">Foundation Fridays- Kids Who Garden
                                                    </span>
                                                </a>
                                            </li>

                                            <li class="thisBlog_post_item">
                                                <a href="/mission-healthy-living/blog/blog-entries/foundation-fridays-step-it-up.aspx">
                                                    <span class="thisBlog_post_title">Foundation Fridays- Step it Up
                                                    </span>
                                                </a>
                                            </li>

                                        </ul>

                                    </li>



                                    <li class="thisBlog_month">
                                        <a class="thisBlog_month_name" href="#">
                                            <span>September</span>
                                        </a>

                                        <ul class="thisBlog_post_items" style="display: block;">

                                            <li class="thisBlog_post_item">
                                                <a href="/mission-healthy-living/blog/blog-entries/foundation-fridays.aspx">
                                                    <span class="thisBlog_post_title">Foundation Fridays
                                                    </span>
                                                </a>
                                            </li>

                                            <li class="thisBlog_post_item">
                                                <a href="/mission-healthy-living/blog/blog-entries/foundation-fridays-1.aspx">
                                                    <span class="thisBlog_post_title">Foundation Fridays
                                                    </span>
                                                </a>
                                            </li>

                                        </ul>

                                    </li>



                                    <li class="thisBlog_month">
                                        <a class="thisBlog_month_name" href="#">
                                            <span>May</span>
                                        </a>

                                        <ul class="thisBlog_post_items" style="display: block;">

                                            <li class="thisBlog_post_item">
                                                <a href="/mission-healthy-living/blog/blog-entries/a-work-in-progress.aspx">
                                                    <span class="thisBlog_post_title">A Work in Progress
                                                    </span>
                                                </a>
                                            </li>

                                            <li class="thisBlog_post_item">
                                                <a href="/mission-healthy-living/blog/blog-entries/rain-rain-go-away.aspx">
                                                    <span class="thisBlog_post_title">Rain Rain Go Away
                                                    </span>
                                                </a>
                                            </li>

                                        </ul>

                                    </li>



                                    <li class="thisBlog_month">
                                        <a class="thisBlog_month_name" href="#">
                                            <span>April</span>
                                        </a>

                                        <ul class="thisBlog_post_items" style="display: block;">

                                            <li class="thisBlog_post_item">
                                                <a href="/mission-healthy-living/blog/blog-entries/breathe-in-breathe-out.aspx">
                                                    <span class="thisBlog_post_title">Breathe in, breathe out
                                                    </span>
                                                </a>
                                            </li>

                                            <li class="thisBlog_post_item">
                                                <a href="/mission-healthy-living/blog/blog-entries/what-is-aces.aspx">
                                                    <span class="thisBlog_post_title">What is ACEs?
                                                    </span>
                                                </a>
                                            </li>

                                            <li class="thisBlog_post_item">
                                                <a href="/mission-healthy-living/blog/blog-entries/be-kind.aspx">
                                                    <span class="thisBlog_post_title">Be Kind
                                                    </span>
                                                </a>
                                            </li>

                                            <li class="thisBlog_post_item">
                                                <a href="/mission-healthy-living/blog/blog-entries/sunny-days-ahead.aspx">
                                                    <span class="thisBlog_post_title">Sunny Days Ahead
                                                    </span>
                                                </a>
                                            </li>

                                        </ul>

                                    </li>



                                    <li class="thisBlog_month">
                                        <a class="thisBlog_month_name" href="#">
                                            <span>March</span>
                                        </a>

                                        <ul class="thisBlog_post_items" style="display: block;">

                                            <li class="thisBlog_post_item">
                                                <a href="/mission-healthy-living/blog/blog-entries/easter-week.aspx">
                                                    <span class="thisBlog_post_title">Easter Week
                                                    </span>
                                                </a>
                                            </li>

                                            <li class="thisBlog_post_item">
                                                <a href="/mission-healthy-living/blog/blog-entries/go-green.aspx">
                                                    <span class="thisBlog_post_title">Go Green
                                                    </span>
                                                </a>
                                            </li>

                                            <li class="thisBlog_post_item">
                                                <a href="/mission-healthy-living/blog/blog-entries/tgif.aspx">
                                                    <span class="thisBlog_post_title">TGIF
                                                    </span>
                                                </a>
                                            </li>

                                        </ul>

                                    </li>



                                    <li class="thisBlog_month">
                                        <a class="thisBlog_month_name" href="#">
                                            <span>February</span>
                                        </a>

                                        <ul class="thisBlog_post_items" style="display: block;">

                                            <li class="thisBlog_post_item">
                                                <a href="/mission-healthy-living/blog/blog-entries/time-flies-when.aspx">
                                                    <span class="thisBlog_post_title">Time flies when...
                                                    </span>
                                                </a>
                                            </li>

                                            <li class="thisBlog_post_item">
                                                <a href="/mission-healthy-living/blog/blog-entries/spring-cleaning.aspx">
                                                    <span class="thisBlog_post_title">Spring Cleaning
                                                    </span>
                                                </a>
                                            </li>

                                            <li class="thisBlog_post_item">
                                                <a href="/mission-healthy-living/blog/blog-entries/time-to-unplug.aspx">
                                                    <span class="thisBlog_post_title">Time to unplug
                                                    </span>
                                                </a>
                                            </li>

                                            <li class="thisBlog_post_item">
                                                <a href="/mission-healthy-living/blog/blog-entries/a-better-me.aspx">
                                                    <span class="thisBlog_post_title">A better me
                                                    </span>
                                                </a>
                                            </li>

                                            <li class="thisBlog_post_item">
                                                <a href="/mission-healthy-living/blog/blog-entries/soda-is-a-four-letter-word.aspx">
                                                    <span class="thisBlog_post_title">Soda IS a four-letter word
                                                    </span>
                                                </a>
                                            </li>

                                        </ul>

                                    </li>



                                    <li class="thisBlog_month">
                                        <a class="thisBlog_month_name" href="#">
                                            <span>January</span>
                                        </a>

                                        <ul class="thisBlog_post_items" style="display: block;">

                                            <li class="thisBlog_post_item">
                                                <a href="/mission-healthy-living/blog/blog-entries/snowed-in.aspx">
                                                    <span class="thisBlog_post_title">Snowed in
                                                    </span>
                                                </a>
                                            </li>

                                            <li class="thisBlog_post_item">
                                                <a href="/mission-healthy-living/blog/blog-entries/road-trip.aspx">
                                                    <span class="thisBlog_post_title">Road Trip
                                                    </span>
                                                </a>
                                            </li>

                                            <li class="thisBlog_post_item">
                                                <a href="/mission-healthy-living/blog/blog-entries/say-no-to-germs.aspx">
                                                    <span class="thisBlog_post_title">Say no to germs
                                                    </span>
                                                </a>
                                            </li>

                                            <li class="thisBlog_post_item">
                                                <a href="/mission-healthy-living/blog/blog-entries/winter-is-no-excuse.aspx">
                                                    <span class="thisBlog_post_title">Winter is no excuse
                                                    </span>
                                                </a>
                                            </li>

                                        </ul>

                                    </li>


                                </ul>


                            </li>



                            <li class="thisBlog_year thisBlog_year_first">
                                <a class="thisBlog_year_name ui-accordion-header ui-state-default ui-accordion-icons ui-accordion-header-active ui-state-active ui-corner-top ui-corner-all" href="#" role="tab" aria-selected="false" aria-expanded="false" tabindex="-1" id="ui-id-5" aria-controls="ui-id-6"><span class="ui-accordion-header-icon ui-icon ui-icon-triangle-1-e"></span>
                                    <span class="ui-accordion-header-icon ui-icon ui-icon-triangle-1-s"></span>
                                    <span>2015</span>
                                </a>

                                <ul class="thisBlog_months ui-accordion-content ui-helper-reset ui-widget-content ui-corner-bottom ui-accordion-content-active" role="tabpanel" aria-hidden="true" style="display: none;" id="ui-id-6" aria-labelledby="ui-id-5">


                                    <li class="thisBlog_month">
                                        <a class="thisBlog_month_name" href="#">
                                            <span>December</span>
                                        </a>

                                        <ul class="thisBlog_post_items" style="display: block;">

                                            <li class="thisBlog_post_item">
                                                <a href="/mission-healthy-living/blog/blog-entries/commit-to-a-better-you.aspx">
                                                    <span class="thisBlog_post_title">Commit to a better you
                                                    </span>
                                                </a>
                                            </li>

                                            <li class="thisBlog_post_item">
                                                <a href="/mission-healthy-living/blog/blog-entries/music-at-our-core.aspx">
                                                    <span class="thisBlog_post_title">Music at our core
                                                    </span>
                                                </a>
                                            </li>

                                            <li class="thisBlog_post_item">
                                                <a href="/mission-healthy-living/blog/blog-entries/walking-in-a-spring-wonderland.aspx">
                                                    <span class="thisBlog_post_title">Walking in a Spring Wonderland
                                                    </span>
                                                </a>
                                            </li>

                                            <li class="thisBlog_post_item">
                                                <a href="/mission-healthy-living/blog/blog-entries/overcoming-obstacles.aspx">
                                                    <span class="thisBlog_post_title">Overcoming obstacles
                                                    </span>
                                                </a>
                                            </li>

                                        </ul>

                                    </li>



                                    <li class="thisBlog_month">
                                        <a class="thisBlog_month_name" href="#">
                                            <span>November</span>
                                        </a>

                                        <ul class="thisBlog_post_items" style="display: block;">

                                            <li class="thisBlog_post_item">
                                                <a href="/mission-healthy-living/blog/blog-entries/its-the-most-wonderful-time-of-the-year.aspx">
                                                    <span class="thisBlog_post_title">It's the most wonderful time of the year
                                                    </span>
                                                </a>
                                            </li>

                                            <li class="thisBlog_post_item">
                                                <a href="/mission-healthy-living/blog/blog-entries/what-families-do.aspx">
                                                    <span class="thisBlog_post_title">What families do
                                                    </span>
                                                </a>
                                            </li>

                                            <li class="thisBlog_post_item">
                                                <a href="/mission-healthy-living/blog/blog-entries/good-night-sleep-tight.aspx">
                                                    <span class="thisBlog_post_title">Good night, sleep tight
                                                    </span>
                                                </a>
                                            </li>

                                            <li class="thisBlog_post_item">
                                                <a href="/mission-healthy-living/blog/blog-entries/take-a-walk-whatever-that-means-to-you.aspx">
                                                    <span class="thisBlog_post_title">Take a walk-whatever that means to you
                                                    </span>
                                                </a>
                                            </li>

                                            <li class="thisBlog_post_item">
                                                <a href="/mission-healthy-living/blog/blog-entries/lead-by-example-1.aspx">
                                                    <span class="thisBlog_post_title">Lead by example
                                                    </span>
                                                </a>
                                            </li>

                                            <li class="thisBlog_post_item">
                                                <a href="/mission-healthy-living/blog/blog-entries/lead-by-example.aspx">
                                                    <span class="thisBlog_post_title">Lead by example
                                                    </span>
                                                </a>
                                            </li>

                                        </ul>

                                    </li>



                                    <li class="thisBlog_month">
                                        <a class="thisBlog_month_name" href="#">
                                            <span>October</span>
                                        </a>

                                        <ul class="thisBlog_post_items" style="display: block;">

                                            <li class="thisBlog_post_item">
                                                <a href="/mission-healthy-living/blog/blog-entries/aging-successfully.aspx">
                                                    <span class="thisBlog_post_title">Aging Successfully
                                                    </span>
                                                </a>
                                            </li>

                                            <li class="thisBlog_post_item">
                                                <a href="/mission-healthy-living/blog/blog-entries/positive-thoughts.aspx">
                                                    <span class="thisBlog_post_title">Positive thoughts
                                                    </span>
                                                </a>
                                            </li>

                                            <li class="thisBlog_post_item">
                                                <a href="/mission-healthy-living/blog/blog-entries/getaway-heaven.aspx">
                                                    <span class="thisBlog_post_title">Getaway Heaven
                                                    </span>
                                                </a>
                                            </li>

                                            <li class="thisBlog_post_item">
                                                <a href="/mission-healthy-living/blog/blog-entries/communication-is-key.aspx">
                                                    <span class="thisBlog_post_title">Communication is Key
                                                    </span>
                                                </a>
                                            </li>

                                        </ul>

                                    </li>



                                    <li class="thisBlog_month">
                                        <a class="thisBlog_month_name" href="#">
                                            <span>September</span>
                                        </a>

                                        <ul class="thisBlog_post_items" style="display: block;">

                                            <li class="thisBlog_post_item">
                                                <a href="/mission-healthy-living/blog/blog-entries/those-darn-kids-with-love-from-mom.aspx">
                                                    <span class="thisBlog_post_title">Those darn kids-with love from Mom
                                                    </span>
                                                </a>
                                            </li>

                                            <li class="thisBlog_post_item">
                                                <a href="/mission-healthy-living/blog/blog-entries/i-think-i-can.aspx">
                                                    <span class="thisBlog_post_title">I think I can
                                                    </span>
                                                </a>
                                            </li>

                                            <li class="thisBlog_post_item">
                                                <a href="/mission-healthy-living/blog/blog-entries/change-of-season-memories.aspx">
                                                    <span class="thisBlog_post_title">Change of season memories
                                                    </span>
                                                </a>
                                            </li>

                                        </ul>

                                    </li>



                                    <li class="thisBlog_month">
                                        <a class="thisBlog_month_name" href="#">
                                            <span>August</span>
                                        </a>

                                        <ul class="thisBlog_post_items" style="display: block;">

                                            <li class="thisBlog_post_item">
                                                <a href="/mission-healthy-living/blog/blog-entries/back-to-school-is-much-more-than-you-think.aspx">
                                                    <span class="thisBlog_post_title">Back to school is much more than you think
                                                    </span>
                                                </a>
                                            </li>

                                            <li class="thisBlog_post_item">
                                                <a href="/mission-healthy-living/blog/blog-entries/trust-your-gut.aspx">
                                                    <span class="thisBlog_post_title">Trust your gut
                                                    </span>
                                                </a>
                                            </li>

                                            <li class="thisBlog_post_item">
                                                <a href="/mission-healthy-living/blog/blog-entries/where-is-your-haven.aspx">
                                                    <span class="thisBlog_post_title">Where is your haven?
                                                    </span>
                                                </a>
                                            </li>

                                            <li class="thisBlog_post_item">
                                                <a href="/mission-healthy-living/blog/blog-entries/gone-to-the-beach.aspx">
                                                    <span class="thisBlog_post_title">Gone to the beach
                                                    </span>
                                                </a>
                                            </li>

                                            <li class="thisBlog_post_item">
                                                <a href="/mission-healthy-living/blog/blog-entries/aces-are-not-just-playing-cards.aspx">
                                                    <span class="thisBlog_post_title">ACEs are not just playing cards
                                                    </span>
                                                </a>
                                            </li>

                                        </ul>

                                    </li>



                                    <li class="thisBlog_month">
                                        <a class="thisBlog_month_name" href="#">
                                            <span>July</span>
                                        </a>

                                        <ul class="thisBlog_post_items" style="display: block;">

                                            <li class="thisBlog_post_item">
                                                <a href="/mission-healthy-living/blog/blog-entries/great-friends-are-good-for-your-health.aspx">
                                                    <span class="thisBlog_post_title">Great friends are good for your health
                                                    </span>
                                                </a>
                                            </li>

                                            <li class="thisBlog_post_item">
                                                <a href="/mission-healthy-living/blog/blog-entries/a-morning-person-i-am-not.aspx">
                                                    <span class="thisBlog_post_title">A Morning Person I am Not
                                                    </span>
                                                </a>
                                            </li>

                                            <li class="thisBlog_post_item">
                                                <a href="/mission-healthy-living/blog/blog-entries/have-mercy.aspx">
                                                    <span class="thisBlog_post_title">Have Mercy
                                                    </span>
                                                </a>
                                            </li>

                                            <li class="thisBlog_post_item">
                                                <a href="/mission-healthy-living/blog/blog-entries/the-big-24.aspx">
                                                    <span class="thisBlog_post_title">The big 24!
                                                    </span>
                                                </a>
                                            </li>

                                        </ul>

                                    </li>



                                    <li class="thisBlog_month">
                                        <a class="thisBlog_month_name" href="#">
                                            <span>June</span>
                                        </a>

                                        <ul class="thisBlog_post_items" style="display: block;">

                                            <li class="thisBlog_post_item">
                                                <a href="/mission-healthy-living/blog/blog-entries/why-are-dads-important.aspx">
                                                    <span class="thisBlog_post_title">Why are dads important?
                                                    </span>
                                                </a>
                                            </li>

                                            <li class="thisBlog_post_item">
                                                <a href="/mission-healthy-living/blog/blog-entries/volunteers.aspx">
                                                    <span class="thisBlog_post_title">Volunteers
                                                    </span>
                                                </a>
                                            </li>

                                            <li class="thisBlog_post_item">
                                                <a href="/mission-healthy-living/blog/blog-entries/working-woman.aspx">
                                                    <span class="thisBlog_post_title">Working woman
                                                    </span>
                                                </a>
                                            </li>

                                            <li class="thisBlog_post_item">
                                                <a href="/mission-healthy-living/blog/blog-entries/a-monday-to-remember.aspx">
                                                    <span class="thisBlog_post_title">A Monday to Remember
                                                    </span>
                                                </a>
                                            </li>

                                        </ul>

                                    </li>



                                    <li class="thisBlog_month">
                                        <a class="thisBlog_month_name" href="#">
                                            <span>May</span>
                                        </a>

                                        <ul class="thisBlog_post_items" style="display: block;">

                                            <li class="thisBlog_post_item">
                                                <a href="/mission-healthy-living/blog/blog-entries/the-first-step-towards-forever.aspx">
                                                    <span class="thisBlog_post_title">The first step towards forever
                                                    </span>
                                                </a>
                                            </li>

                                            <li class="thisBlog_post_item">
                                                <a href="/mission-healthy-living/blog/blog-entries/take-the-time-to-talk-the-walk.aspx">
                                                    <span class="thisBlog_post_title">Take the time to talk the walk
                                                    </span>
                                                </a>
                                            </li>

                                            <li class="thisBlog_post_item">
                                                <a href="/mission-healthy-living/blog/blog-entries/stair-masters.aspx">
                                                    <span class="thisBlog_post_title">Stair Masters
                                                    </span>
                                                </a>
                                            </li>

                                        </ul>

                                    </li>



                                    <li class="thisBlog_month">
                                        <a class="thisBlog_month_name" href="#">
                                            <span>April</span>
                                        </a>

                                        <ul class="thisBlog_post_items" style="display: block;">

                                            <li class="thisBlog_post_item">
                                                <a href="/mission-healthy-living/blog/blog-entries/going-viral.aspx">
                                                    <span class="thisBlog_post_title">Going viral
                                                    </span>
                                                </a>
                                            </li>

                                            <li class="thisBlog_post_item">
                                                <a href="/mission-healthy-living/blog/blog-entries/meet-skye-guest-blogger.aspx">
                                                    <span class="thisBlog_post_title">Meet Skye, Guest Blogger
                                                    </span>
                                                </a>
                                            </li>

                                            <li class="thisBlog_post_item">
                                                <a href="/mission-healthy-living/blog/blog-entries/too-blessed-to-be-stressed.aspx">
                                                    <span class="thisBlog_post_title">Too blessed to be stressed
                                                    </span>
                                                </a>
                                            </li>

                                        </ul>

                                    </li>



                                    <li class="thisBlog_month">
                                        <a class="thisBlog_month_name" href="#">
                                            <span>February</span>
                                        </a>

                                        <ul class="thisBlog_post_items" style="display: block;">

                                            <li class="thisBlog_post_item">
                                                <a href="/mission-healthy-living/blog/blog-entries/hospital-usage-and-high-utilization.aspx">
                                                    <span class="thisBlog_post_title">Hospital Usage and High Utilization
                                                    </span>
                                                </a>
                                            </li>

                                            <li class="thisBlog_post_item">
                                                <a href="/mission-healthy-living/blog/blog-entries/heart-health.aspx">
                                                    <span class="thisBlog_post_title">Heart Health
                                                    </span>
                                                </a>
                                            </li>

                                            <li class="thisBlog_post_item">
                                                <a href="/mission-healthy-living/blog/blog-entries/time-alone-and-loving-it.aspx">
                                                    <span class="thisBlog_post_title">Time Alone and Loving It
                                                    </span>
                                                </a>
                                            </li>

                                            <li class="thisBlog_post_item">
                                                <a href="/mission-healthy-living/blog/blog-entries/health-is-not-just-a-six-letter-word.aspx">
                                                    <span class="thisBlog_post_title">Health is not just a six letter word
                                                    </span>
                                                </a>
                                            </li>

                                        </ul>

                                    </li>


                                </ul>


                            </li>


                        </ul>


                    </div>
                </section>

                <a id="MainContent_ctl02_hlnkViewAll" class="viewAllBlog" href="/mission-healthy-living/blog.aspx">
                    <h2>View All</h2>
                </a>

                <div class="columns">&nbsp;</div>

                <div class="thisBlog_search">
                    <div class="left">
                        <input id="thisBlogTxtSearch" type="text" placeholder="Search">
                    </div>
                    <div class="right">
                        <input id="thisBlogBtnSearch" type="submit" class="button" value="Submit">
                    </div>
                </div>

                <div class="meetTheAuthors">
                    <hr>
                    <h5>Meet the Authors</h5>


                    <ul class="small-block-grid-2 large-block-grid-3 text-center">

                        <li>
                            <a title="Skye Tulio" href="/mission-healthy-living/blog/authors/skye-tulio.aspx">
                                <img src="/media/65787/skye-tulio.jpg?crop=0.30320586215790452,0.0970495296012188,0.26111440775440159,0.47125948523906452&amp;cropmode=percentage&amp;width=250&amp;height=250&amp;rnd=131108868390000000" alt="Skye Tulio">
                                <br>
                                Skye Tulio</a>
                        </li>

                    </ul>


                    <br>
                    <br>
                </div>

            </aside>
        </div>

    </div>


</div>--%>
