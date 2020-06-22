<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="SimpleBanner.ascx.vb" Inherits="mvcvb.SimpleBanner" %>



<form runat="server">
    <asp:PlaceHolder runat="server" ID="phSimpleBanner">
        <div class="simpleBanner hide">
            <div class="row collapse pnlWithBgImg text-center">
                <asp:Image runat="server" ID="imgBackground" ImageUrl="/Images/temp/imgPlaceholder.png" />

                <asp:Panel runat="server" ID="pnlText" CssClass="large-20 large-push-2 columns floatOnTopCentered text-center ">
                    <h1 class=""><asp:Literal runat="server" ID="ltrlTitle" /></h1>
                    <asp:PlaceHolder runat="server" ID="phSubtitle" Visible="false">
                        <h2 class=""><asp:Literal runat="server" ID="ltrlSubtitle" /></h2>
                    </asp:PlaceHolder>
                </asp:Panel>
            </div>
        </div>

    </asp:PlaceHolder>
</form>