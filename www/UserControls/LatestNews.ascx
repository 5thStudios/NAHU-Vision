<%@ Control Language="vb" AutoEventWireup="false" CodeFile="LatestNews.ascx.vb" EnableViewState="false" Inherits="LatestNews" %>
<%@ Register Src="/UserControls/ListItem_LatestNews.ascx" TagPrefix="uc" TagName="ListItem_LatestNews" %>


<%--<asp:GridView runat="server" ID="gv" />--%>


<asp:ListView runat="server" ID="lstv">
    <LayoutTemplate>
        <ul class="small-block-grid-1">
            <asp:PlaceHolder runat="server" ID="itemPlaceholder" />
        </ul>
    </LayoutTemplate>
    <ItemTemplate>
        <li>
            <uc:ListItem_LatestNews runat="server" ArticleSummary='<%# Container.DataItem %>' />
        </li>
    </ItemTemplate>
    <ItemSeparatorTemplate>
        <hr />
    </ItemSeparatorTemplate>
    <EmptyDataTemplate></EmptyDataTemplate>
</asp:ListView>



<%--<br />
<h6>
    <asp:HyperLink runat="server" ID="hlnkAllNews" Text="SEE ALL NEWS & UPDATES" />
</h6>--%>

