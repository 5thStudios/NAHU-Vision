<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="TopUpcomingEvents.ascx.vb" Inherits="mvcvb.TopUpcomingEvents" %>
<%@ Register Src="/UserControls/ListItem_TopUpcomingEvent.ascx" TagPrefix="uc" TagName="ListItem_TopUpcomingEvent" %>


<form runat="server">
    <div class="row topUpcomingEvents hide">
        <br />
        <br />
        <div class="medium-24 large-20 large-push-2 columns">


            <header class="row">
                <div class="small-12 medium-24 columns small-text-left medium-text-center">
                    <h2>Events</h2>
                    <br class="hide-for-small-down" />
                </div>
                <div class="small-12 columns text-right show-for-small-down">
                    <asp:HyperLink runat="server" ID="hlnkSeeAll" Text="SEE ALL" CssClass="" />
                </div>
            </header>



            <asp:ListView runat="server" ID="lstviewUpcomingEvents">
                <LayoutTemplate>
                    <ul class="medium-block-grid-2 large-block-grid-4">
                        <asp:PlaceHolder runat="server" ID="itemPlaceholder" />
                    </ul>
                </LayoutTemplate>
                <ItemTemplate>
                    <li>
                        <uc:ListItem_TopUpcomingEvent runat="server" ID="ucUpcomingEvent" eventItem='<%# Container.DataItem %>' />
                    </li>
                </ItemTemplate>
                <EmptyDataTemplate>
                    <div>No events have been created yet.</div>
                </EmptyDataTemplate>
            </asp:ListView>



            <div class="text-center hide-for-small-down">
                <br />
                <asp:HyperLink runat="server" ID="hlnkAllEvents" Text="View all Events" CssClass="button" />
            </div>

        </div>
        <div class="columns">
            <br class="hide-for-small-down" />
            <br class="hide-for-small-down" />
            <br />
        </div>
    </div>
</form>

