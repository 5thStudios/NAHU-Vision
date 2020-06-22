<%@ Control Language="vb" AutoEventWireup="false" CodeFile="BlogListItem.ascx.vb" EnableViewState="false" Inherits="BlogListItem" %>



<asp:Panel runat="server" ID="pnlViewItem" CssClass="viewItem blogListItem">

    <%--<asp:GridView runat="server" ID="gv" />--%>

    <div class="listViewItem columns">
        <div class="row">
            <div class="small-24 medium-4 large-2 columns">

                <div class="row collapse">
                    <div class="small-6 medium-24 columns">
                        <div class="articleDate">
                            <div class="month text-center">
                                <asp:Literal runat="server" ID="ltrlMonth" />
                            </div>
                            <div class="day text-center">
                                <asp:Literal runat="server" ID="ltrlDay" />
                            </div>
                        </div>
                    </div>
                    <div class="small-18 medium-24 columns">
                        <asp:Panel runat="server" ID="pnlLockedDoc" CssClass="small-text-right medium-text-center">
                            <br />
                            <asp:Image runat="server" ID="imgLockIcon" ImageUrl="~/Images/Common/icons/LockIcon.png" CssClass="lockIcon" Visible="false" />
                        </asp:Panel>
                    </div>
                </div>
            </div>

            <div class="hide-for-small-down medium-20 medium-text-left large-4 columns large-text-center">
                <div class="row">
                    <div class="medium-12 large-24 columns end">
                        <asp:Image runat="server" ID="imgFeatured" ImageUrl="~/Images/temp/imgPlaceholder.png" />
                    </div>
                </div>
            </div>

            <div class="large-18 columns articleDesc">
                <div class="row collapse">
                    <div class="small-22 columns">
                        <h2 class="title">
                            <asp:Literal runat="server" ID="ltrlTitle" /></h2>
                        <div>
                            <span class="date">
                                <asp:Literal runat="server" ID="ltrlDate" />
                                | </span><span class="categories">
                                    <asp:PlaceHolder runat="server" ID="phCategories" />
                                </span>
                        </div>
                    </div>
                    <div class="small-2 columns">
                        <asp:Image runat="server" ID="imgPdfIcon" ImageAlign="Right" ImageUrl="~/Images/Common/icons/PdfIcon.png" Visible="false" />
                    </div>
                </div>

                <br />
                <div class="summary">
                    <asp:Literal runat="server" ID="ltrlSummary" />
                </div>
                <br />
                <div class="readMore">
                    <asp:HyperLink runat="server" ID="hlnkReadMore" Target="_blank">Read More</asp:HyperLink>
                </div>
            </div>
        </div>
        <br />
        <hr />
        <br />
    </div>

    <div class="gridViewItem large-8 columns articleDesc" data-equalizer-watch="gridview">
        <asp:HyperLink runat="server" ID="hlnkReadMore_grid" Target="_blank">
            <div class="text-center featuredImg">
                <asp:Image runat="server" ID="imgFeatured_grid" ImageUrl="~/Images/temp/imgPlaceholder.png" ImageAlign="Middle" />
                <asp:Image runat="server" ID="imgPdfIcon_grid" ImageUrl="~/Images/Common/icons/PdfIcon.png" CssClass="pdfIcon" Visible="false" />
                <asp:Image runat="server" ID="imgLockIcon_grid" ImageUrl="~/Images/Common/icons/LockIcon.png" CssClass="lockIcon" Visible="false" />
            </div>

            <h2 class="title">
                <asp:Literal runat="server" ID="ltrlTitle_grid" /></h2>
        </asp:HyperLink>
        <div>
            <span class="date">
                <asp:Literal runat="server" ID="ltrlDate_grid" />
                | </span>
            <span class="categories">
                <asp:PlaceHolder runat="server" ID="phCategory_grid" />
            </span>
        </div>
    </div>

</asp:Panel>

