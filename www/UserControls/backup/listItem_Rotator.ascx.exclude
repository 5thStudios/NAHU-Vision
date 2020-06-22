<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="listItem_Rotator.ascx.vb" Inherits="mvcvb.listItem_Rotator" %>


<%--
    Notes: use the following techniques to get the image as a responsive background image
    https://css-tricks.com/perfect-full-page-background-image/
--%>


<asp:Panel runat="server" ID="pnlRotator" CssClass="row panel callout">
    <div class="large-22 large-push-1 columns end text-right">
        <asp:Image runat="server" ID="img" style="width:64px;height:auto;" />
    </div>
    <asp:Panel runat="server" ID="pnlContent" CssClass="large-16 large-push-2 columns end">
        <h1>
            <asp:Literal runat="server" ID="ltrlTitle" />
        </h1>
        <asp:Literal runat="server" ID="ltrlSubtitle" />
        <div>
            <asp:HyperLink runat="server" ID="hlnkCallToAction" CssClass="button" Visible="false" />
        </div>
    </asp:Panel>
</asp:Panel>