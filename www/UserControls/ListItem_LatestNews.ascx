<%@ Control Language="vb" AutoEventWireup="false" CodeFile="ListItem_LatestNews.ascx.vb" EnableViewState="false" Inherits="ListItem_LatestNews" %>


<%--<asp:GridView runat="server" ID="gv" />--%>

<asp:HyperLink runat="server" ID="hlnkNewsArticle" Target='<%# If(Eval("isExternalUrl"), "_blank", "_self") %>'>
    <div class="small-8 medium-5 columns">
        <asp:Image runat="server" ID="imgFeatured" ImageUrl="~/Images/temp/imgPlaceholder.png" CssClass="" />
    </div>
</asp:HyperLink>

<div class="show-for-large-up large-17 large-push-1 columns end ">
    <asp:HyperLink runat="server" ID="hlnkNewsArticle_Title" Target='<%# If(Eval("isExternalUrl"), "_blank", "_self") %>'>
        <h4>
            <asp:Literal runat="server" ID="lblTitle" /></h4>
    </asp:HyperLink>
    <h5>
        <asp:Literal runat="server" ID="lblDate" />&nbsp;&nbsp;|&nbsp;&nbsp;<asp:HyperLink runat="server" ID="hlnkParent" /></h5>
</div>
<div class="small-16 medium-17 medium-push-1 show-for-medium-down columns end">
    <asp:HyperLink runat="server" ID="hlnkNewsArticle_TitleMbl" Target='<%# If(Eval("isExternalUrl"), "_blank", "_self") %>'>
        <h4>
            <asp:Literal runat="server" ID="lblTitle_Mbl" />
        </h4>
    </asp:HyperLink>
    <h5>
        <asp:Literal runat="server" ID="lblDate_Mbl" />&nbsp;&nbsp;|&nbsp;&nbsp;<asp:HyperLink runat="server" ID="hlnkParent_Mbl" />
    </h5>
</div>
