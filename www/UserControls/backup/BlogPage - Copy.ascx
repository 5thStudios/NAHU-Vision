<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="BlogPage.ascx.vb" Inherits="mvcvb.BlogPage" %>
<%@ Register Src="../UserControls/BlogFilters.ascx" TagName="BlogFilter" TagPrefix="uc" %>



<form runat="server">

    <div class="BlogPg">
        <div class="row">
            <br>
            <br>

            <div class="medium-16 columns">

                <asp:Placeholder runat="server" ID="phFeaturedImage" Visible="false">
                    <asp:Image runat="server" ID="imgFeatured" CssClass="featuredImg" ImageUrl="https://dummyimage.com/1150x650/c6c2ff/fff" />
                </asp:Placeholder>


                <asp:Panel runat="server" ID="pnlYoutubeVideo" CssClass="flex-video " Visible="false">
                    <iframe runat="server" id="iframeYoutube" src="https://www.youtube.com/embed/[ID]?ecver=1" width="1280" height="966" frameborder="0" webkitallowfullscreen mozallowfullscreen allowfullscreen></iframe>
                </asp:Panel>


                <asp:Panel runat="server" ID="pnlVimeoVideo" CssClass="flex-video vimeo " Visible="false">
                    <iframe runat="server" id="iframeVimeo" src="https://player.vimeo.com/video/[ID]?portrait=0" width="1280" height="966" frameborder="0" webkitallowfullscreen mozallowfullscreen allowfullscreen></iframe>
                </asp:Panel>


                <div class="row">
                    <div class="columns">
                        <br />
                        <h1><asp:Literal runat="server" ID="ltrlTitle" /></h1>
                        <%--<asp:Label runat="server" ID="lblDatePosted" /> | By: <asp:Label runat="server" ID="lblAuthor" Text="Someone Else" />--%>
                        <%--<asp:Panel runat="server" ID="pnlCategories" />--%>

                        <h6>
                            <asp:Literal runat="server" ID="ltrlDatePosted" />&nbsp;&nbsp;|&nbsp;&nbsp;By: <asp:HyperLink runat="server" ID="hlnkAuthor" />
                        </h6>
                        <h6>
                            <asp:PlaceHolder runat="server" ID="phCategories" />
                        </h6>
                    </div>
                </div>


                <div class="row">
                    <div class="columns">
                        <br />
                        <umbraco:Item runat="server" Field="content" />
                    </div>
                </div>


                <div class="row">
                    <br /><br />
                    <div class="large-12 columns socialIcons">
                        <h3>
                            Share Post

                            <a href="/">
                                <img alt="" src="/Images/Common/Icons/Facebook.png" />
                            </a>
                            <a href="/">
                                <img alt="" src="/Images/Common/Icons/Twitter.png" />
                            </a>
                            <a href="/">
                                <img alt="" src="/Images/Common/Icons/LinkedIn.png" />
                            </a>
                            <a href="/">
                                <img alt="" src="/Images/Common/Icons/Email.png" />
                            </a>
                        </h3>
                        <%--<ul class="large-block-grid-6">
                            <li>
                                <a href="/">
                                    <img alt="" src="/Images/Common/Icons/Facebook.png" />
                                </a>
                            </li>
                            <li>
                                <a href="/">
                                    <img alt="" src="/Images/Common/Icons/Twitter.png" />
                                </a>
                            </li>
                            <li>
                                <a href="/">
                                    <img alt="" src="/Images/Common/Icons/LinkedIn.png" />
                                </a>
                            </li>
                            <li>
                                <a href="/">
                                    <img alt="" src="/Images/Common/Icons/Email.png" />
                                </a>
                            </li>
                        </ul>--%>
                    </div>
                    <div class="large-8 columns">
                        <div class="row">
                            <div class="large-12 columns right">
                                <a id="1_hlnkNextCourse" class="button secondary" href="/professional-development/certification-courses/hipaa-certification/">
                                    Next <span class="arrow-right">►</span>
                                </a>
                            </div>
                            <div class="large-12 columns right">
                                <a id="1_hlnkPreviousCourse" class="button secondary" href="/professional-development/certification-courses/bam-certification/">
                                    <span class="arrow-left">◄</span> Previous
                                </a>
                            </div>
                        </div>
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


            <div class="medium-8 columns">
                <uc:BlogFilter runat="server" />
            </div>

        </div>
    </div>





    <%--<hr />
    <asp:GridView runat="server" ID="gv2" />
    <hr />
    <asp:GridView runat="server" ID="gv3" />
    <hr />
    <asp:GridView runat="server" ID="gv" />
    <hr />--%>


</form>