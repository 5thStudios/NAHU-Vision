<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="LockedPgMngr.ascx.vb" Inherits="mvcvb.LockedPgMngr" %>


<asp:Panel runat="server" ID="pnlLockedInfo" CssClass="row" Visible="false">
    <div class="columns ">
        <fieldset class="panel" style="border-color: #d60000;background: rgba(214, 0, 0, 0.21);">
            <legend>Locked Page</legend>
            <h3>Please log in to view this page</h3>
            <p>Click <a href="/">here</a> to learn more about the benifits of creating an acct.</p>
            <button type="button" class="button">Log In</button>
            <br />
            <asp:Literal runat="server" ID="ltrlLockedInfo" />
        </fieldset>
    </div>
</asp:Panel>