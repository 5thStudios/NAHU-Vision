<%@ Control Language="vb" AutoEventWireup="false" CodeFile="BlogPage.ascx.vb" EnableViewState="false" Inherits="BlogPage" %>
<%@ Register Src="../UserControls/BlogFilters.ascx" TagName="BlogFilter" TagPrefix="uc" %>
<%@ Register Src="~/UserControls/AddThisTemplateA.ascx" TagPrefix="uc" TagName="AddThisTemplateA" %>


<form runat="server">

  <%--<div class="row">
        <div class="columns">
            <asp:GridView runat="server" ID="gv" />
            <br>
        </div>
    </div>--%>

    <div class="row BlogPg">
        <br />
        <br />

        <div class="medium-16 columns">
            <asp:PlaceHolder runat="server" ID="phFeaturedImage" Visible="false">
                <div class="featuredImgPnl">
                    <asp:Image runat="server" ID="imgFeatured" CssClass="featuredImg" ImageUrl="https://dummyimage.com/1150x650/c6c2ff/fff" />
                    <asp:Image runat="server" ID="imgLockedVideo" Visible="false" CssClass="lockedVideoImg" ImageUrl="~/Images/Common/playBtnLocked.png" />
                </div>
                <br />
            </asp:PlaceHolder>

            <asp:Panel runat="server" ID="pnlYoutubeVideo" CssClass="flex-video " Visible="false">
                <iframe runat="server" id="ifrYoutubeVideo" width="420" height="315" frameborder="0" allowfullscreen></iframe>
                <br />
            </asp:Panel>


            <asp:Panel runat="server" ID="pnlVimeoVideo" CssClass="flex-video vimeo " Visible="false">
                <iframe runat="server" id="ifrVimeoVideo" width="400" height="225" frameborder="0" webkitallowfullscreen mozallowfullscreen allowfullscreen></iframe>
                <br />
            </asp:Panel>


            <div class="row">
                <div class="columns">
                    <h1>
                        <asp:Literal runat="server" ID="ltrlTitle" /></h1>
                    <h6>
                        <asp:Literal runat="server" ID="ltrlDatePosted" />&nbsp;&nbsp;|&nbsp;&nbsp;By:
                        <asp:HyperLink runat="server" ID="hlnkAuthor" /></h6>
                    <h6>
                        <asp:PlaceHolder runat="server" ID="phCategories" />
                    </h6>
                </div>
            </div>


            <asp:Panel runat="server" ID="pnlLockedContent" Visible="false">
                <div class="columns">
                    <br />
                    <p>
                        <umbraco:Item runat="server" Field="summary" />
                    </p>
                    <br />
                </div>
                <div class="columns panel locked text-center">
                    <br />
                    <h3>Members Only</h3>
                    <h5>To see the rest of this article and many more, become a member today!</h5>
                    <div class="row">
                        <div class="small-12 columns text-right">
                            <a class="button tertiary btnSignIn" onclick="return false;">Log In</a>
                        </div>
                        <div class="small-12 columns text-left">
                            <asp:HyperLink runat="server" ID="hlnkJoin" Text="Join" CssClass="button" />
                        </div>
                    </div>
                    <div class="readMore">
                        <asp:HyperLink runat="server" ID="hlnkMemberBenefits" Text="View member benefits" />
                    </div>
                    <br />
                </div>
                <div class="columns">
                    <br />
                </div>
            </asp:Panel>

            <asp:Panel runat="server" ID="pnlFullContent" Visible="false">
                <div class="columns">
                    <br />
                    
                    <asp:HyperLink runat="server" ID="hlnkPodcastXml" Visible="false" CssClass="rssFeed left" Target="_blank">
                        <img alt="rss" src="/Images/Common/rssIcon.png" width="41" height="41" />
                    </asp:HyperLink>


                    <asp:Literal runat="server" ID="ltrlContent" />


                    <asp:PlaceHolder runat="server" ID="phPodcast" Visible="false">
                        <div class="text-center">
                            <asp:HyperLink runat="server" ID="hlnkListenToPodcast" Text="Listen to Podcast" Target="_blank" rel="noopener noreferrer" CssClass="button" />
                        </div>
                        <br />
                        <p>Do you have a topic you’d like us to cover or a question you would like us to address in an upcoming podcast? If so, send us an email <a href="mailto:washingtonupdate@nahu.org?subject=Washington%20Update%20Podcast">here</a>.</p>
                    </asp:PlaceHolder>
                    
                    <br />

                </div>
            </asp:Panel>


            <div class="row">
                <br />
                <br />
                <div class="medium-12 large-20 columns">
                    <uc:AddThisTemplateA runat="server" ID="AddThisTemplateA" />
                </div>
                <div class="medium-12 large-4 columns right">
                    <br class="show-for-small-down" />
                    <asp:HyperLink runat="server" ID="hlnkReturnToList" Text="Return to List" CssClass="button secondary" />
                </div>
            </div>


            <br>
            <br>



            <%--
                    <br>
                    <br>
                    <uc:RelatedBlogs runat="server" />
                    <br>
                    <br>
                    <div id="disqus_thread"></div>
                    <noscript>Please enable JavaScript to view the <a href="https://disqus.com/?ref_noscript">comments powered by Disqus.</a></noscript>
                    <br />
                    <br />
            --%>
        </div>

        <div class="hide-for-small-down medium-8 columns">
            <uc:BlogFilter runat="server" />
        </div>

    </div>

</form>
