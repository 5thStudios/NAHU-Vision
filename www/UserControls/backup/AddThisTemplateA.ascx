<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="AddThisTemplateA.ascx.vb" Inherits="mvcvb.AddThisTemplateA" %>


<asp:PlaceHolder runat="server" ID="phHorizontalView" Visible="false">
    <div class="row">
        <div class="large-3 columns">
            <h3>Share Post</h3>
        </div>
        <div class="large-20 columns end">
            <!-- Go to www.addthis.com/dashboard to customize your tools -->
            <div class="addthis_inline_share_toolbox_ogzl"></div>
        </div>
    </div>
</asp:PlaceHolder>


<asp:PlaceHolder runat="server" ID="phVerticalView" Visible="false">
    <div class="row">
        <div class="columns">
            <h2>Share</h2>
            <div>
                <!-- Go to www.addthis.com/dashboard to customize your tools -->
                <div class="addthis_inline_share_toolbox_ogzl"></div>
            </div>
        </div>
    </div>
</asp:PlaceHolder>
