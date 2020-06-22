<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="ListItem_LatestNews.ascx.vb" Inherits="mvcvb.ListItem_LatestNews" %>


<%--<asp:GridView runat="server" ID="gv" />--%>

<asp:HyperLink runat="server" ID="hlnkNewsArticle" Target='<%# If(Eval("isExternalUrl"), "_blank", "_self") %>'>
    <div class="small-8 medium-5 columns">
        <asp:Image runat="server" ID="imgFeatured" ImageUrl="~/Images/temp/imgPlaceholder.png" CssClass="" />
    </div>
    <div class="show-for-large-up large-17 large-push-1 columns end ">
        <h4><asp:Literal runat="server" ID="lblTitle" /></h4>
        <h5><asp:Literal runat="server" ID="lblDate" /></h5>
    </div>
    <div class="small-16 medium-17 medium-push-1 show-for-medium-down columns end">
        <h4><asp:Literal runat="server" ID="lblTitle_Mbl" /></h4>
        <h5><asp:Literal runat="server" ID="lblDate_Mbl" /></h5>
    </div>
</asp:HyperLink>