<%@ Control Language="vb" AutoEventWireup="false" CodeFile="AlertMsg.ascx.vb" EnableViewState="false" Inherits="AlertMsg" %>

<form runat="server" id="frmAlertMsg">
    <asp:PlaceHolder runat="server" ID="phAlertMessage" Visible="false">
        <section class="row collapse alertMsgPnl">
            <div class="small-22 small-push-1 columns">
                <br />
                <div class="alertTitle">Breaking News</div>
                <div class="alertText">
                    <asp:Literal runat="server" ID="ltrlContent" />
                    &nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:HyperLink runat="server" ID="hlnkReadMore" Text="Read&nbsp;More" />
                </div>
                <br />
            </div>
            <div class="closePnl">
                <i class="fi-x large"></i>
            </div>
        </section>
    </asp:PlaceHolder>
</form>