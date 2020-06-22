<%@ Control Language="vb" AutoEventWireup="false" CodeFile="ListItem_TopUpcomingEvent.ascx.vb" EnableViewState="false" Inherits="ListItem_TopUpcomingEvent" %>


<asp:HyperLink runat="server" ID="hlnkEvent">
    <div class="row">
        <div class="small-8 medium-24 columns">
            <asp:Image runat="server" ID="imgFeatured" />
        </div>
        <div class="small-16 medium-24 columns">
            <h4>
                <asp:Literal runat="server" ID="ltrlTitle" />
            </h4>
            <h5>
                <asp:Literal runat="server" ID="ltrlDate" />
            </h5>
        </div>
    </div>
</asp:HyperLink>


