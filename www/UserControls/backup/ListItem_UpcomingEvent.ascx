<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="ListItem_UpcomingEvent.ascx.vb" Inherits="mvcvb.ListItem_UpcomingEvent" %>



<asp:Panel runat="server" ID="pnlViewItem" CssClass="viewItem blogListItem">


    <div class="listViewItem columns">
        <div class="row">
            <div class="hide-for-medium-down large-2 columns">
                <div class="articleDate">
                    <div class="month text-center">
                        <asp:Literal runat="server" ID="ltrlMonth" />
                    </div>
                    <div class="day text-center">
                        <asp:Literal runat="server" ID="ltrlDay" />
                    </div>
                </div>
            </div>
            <div class="hide-for-small-down medium-4 large-4 columns text-center">
                <asp:Image runat="server" ID="imgFeatured" ImageUrl="~/Images/temp/imgPlaceholder.png" />
            </div>
            <div class="small-16 medium-14 large-14 columns articleDesc" >
                <div class="row collapse">
                    <div class="columns">
                        <h2 class="title"><asp:Literal runat="server" ID="ltrlTitle" /></h2>
                        <div>
                            <span class="date"><asp:Literal runat="server" ID="ltrlDate" /> | </span>
                            <span class="chapters"><asp:PlaceHolder runat="server" ID="phChapters" /></span>
                        </div>
                        <div class="eventType">
                            <asp:PlaceHolder runat="server" ID="phEventTypes" />
                        </div>
                    </div>
                </div>
                <br />
                <div class="summary">
                    <asp:Literal runat="server" ID="ltrlDescription" />
                </div>
                <br />
                <div class="readMore">
                    <asp:HyperLink runat="server" ID="hlnkReadMore">Read More</asp:HyperLink>
                </div>
            </div>
            <div class="small-8 medium-6 large-4 columns  text-center">
                <br class="show-for-small-down" />
                <div class="timeframe">
                    <asp:Panel runat="server" ID="pnlFromTo" CssClass="floatOnTopCentered-">
                        <div>from</div>
                        <div>
                            <asp:Literal runat="server" ID="ltrlFrom" />
                            <hr />
                        </div>
                        <div>to</div>
                        <div>
                            <asp:Literal runat="server" ID="ltrlTo" />
                        </div>
                    </asp:Panel>
                    <asp:Panel runat="server" ID="pnlAllDayEvent" CssClass="floatOnTopCentered-" visible="false">
                        <div>All-Day<br />Event</div>
                    </asp:Panel>
                </div>
            </div>
        </div>
        <br />
        <hr />
        <br />
    </div>


    <div class="gridViewItem medium-12 large-8 columns articleDesc" data-equalizer-watch>
        <asp:HyperLink runat="server" ID="hlnkReadMore_grid">
            <div class="text-center featuredImg">
                <asp:Image runat="server" ID="imgFeatured_grid" ImageUrl="~/Images/temp/imgPlaceholder.png" />
            </div>

            <h2 class="title">
                <asp:Literal runat="server" ID="ltrlTitle_grid" /></h2>
        </asp:HyperLink>
        <div><span class="date">
            <asp:Literal runat="server" ID="ltrlDate_grid" />
            | </span><span class="categories">
                <asp:PlaceHolder runat="server" ID="phChapters_grid" />
            </span>
        </div>
    </div>


</asp:Panel>

