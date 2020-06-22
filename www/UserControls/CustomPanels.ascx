<%@ Control Language="vb" AutoEventWireup="false" CodeFile="CustomPanels.ascx.vb" EnableViewState="false" Inherits="CustomPanels" %>



<form runat="server">
    
    <%--<asp:GridView runat="server" ID="gv" />--%>
    
    <asp:Panel runat="server" ID="pnlCustomPanels" CssClass="customPanels hide row collapse">

        <div class="large-8 columns pnlWithBgImg ">
            <asp:Image runat="server" ID="bgImage01" />
            <div class="floatOnBottom gradient_65p">
                <br />
                <br />
                <div class="row">
                    <div class="small-22 small-push-1 medium-20 medium-push-2 large-16 large-push-4 columns">
                        <h2>
                            <asp:Literal runat="server" ID="ltrlTitle01" /></h2>
                        <p>
                            <asp:Literal runat="server" ID="ltrlDescription1" /></p>
                        <h6>
                            <asp:HyperLink runat="server" ID="hlnkPnl01" />
                        </h6>
                        <br />
                        <br />
                        <br />
                    </div>
                </div>
            </div>
        </div>

        <div class="large-8 columns pnlWithBgImg">
            <asp:Image runat="server" ID="bgImage02" />
            <div class="floatOnBottom gradient_65p">
                <div class="row">
                    <div class="small-22 small-push-1 medium-20 medium-push-2 large-16 large-push-4 columns">
                        <h2>
                            <asp:Literal runat="server" ID="ltrlTitle02" /></h2>
                        <p>
                            <asp:Literal runat="server" ID="ltrlDescription2" /></p>
                        <h6>
                            <asp:HyperLink runat="server" ID="hlnkPnl02" />
                        </h6>
                        <br />
                        <br />
                        <br />
                    </div>
                </div>
            </div>
        </div>

        <div class="large-8 columns pnlWithBgImg">
            <asp:Image runat="server" ID="bgImage03" />
            <div class="floatOnBottom gradient">
                <div class="row">
                    <div class="small-22 small-push-1 medium-20 medium-push-2 large-16 large-push-4 columns">
                        <h2>
                            <asp:Literal runat="server" ID="ltrlTitle03" /></h2>
                        <p>
                            <asp:Literal runat="server" ID="ltrlDescription3" /></p>
                        <h6>
                            <asp:HyperLink runat="server" ID="hlnkPnl03" />
                        </h6>
                        <br />
                        <br />
                        <br />
                    </div>
                </div>
            </div>
        </div>

    </asp:Panel>
</form>

