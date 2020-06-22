<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="CallToActionPanel.ascx.vb" Inherits="mvcvb.CallToActionPanel" %>


<form runat="server">
    <asp:PlaceHolder runat="server" ID="phCallToAction">
        <%--<asp:GridView runat="server" ID="gv" />--%>

        <asp:MultiView runat="server" ID="mvCall2Action" ActiveViewIndex="0">
            <asp:View runat="server" ID="vShowOnLeft">
                <div class="row callToAction" data-equalizer>
                    <asp:Panel runat="server" ID="pnlImg" CssClass="large-12 columns bgImg" data-equalizer-watch>
                        &nbsp;
                    </asp:Panel>

                    <div class="large-12 columns" data-equalizer-watch>
                        <div class="row">
                            <asp:Panel runat="server" ID="pnlContent" CssClass="large-20 large-push-2 columns">
                                <br />
                                <br />
                                <br />

                                <h2>
                                    <asp:Literal runat="server" ID="ltrlTitle" /></h2>
                                <p>
                                    <asp:Literal runat="server" ID="ltrlContent" />
                                </p>
                                <div>
                                    <asp:HyperLink runat="server" ID="hlnkAction" CssClass="button" Visible="false" />
                                </div>

                                <br />
                                <br />
                                <br />
                            </asp:Panel>
                        </div>
                    </div>
                </div>
            </asp:View>

            <asp:View runat="server" ID="vShowOnRight">
                <div class="row callToAction" data-equalizer>
                    <div class="large-12 columns" data-equalizer-watch>
                        <div class="row">
                            <asp:Panel runat="server" ID="pnlContent_Rt" CssClass="large-20 large-push-2 columns">
                                <br />
                                <br />
                                <br />

                                <h2>
                                    <asp:Literal runat="server" ID="ltrlTitle_Rt" /></h2>
                                <p>
                                    <asp:Literal runat="server" ID="ltrlContent_Rt" />
                                </p>
                                <div>
                                    <asp:HyperLink runat="server" ID="hlnkAction_Rt" CssClass="button" Visible="false" />
                                </div>

                                <br />
                                <br />
                                <br />
                            </asp:Panel>
                        </div>
                    </div>

                    <asp:Panel runat="server" ID="pnlImg_Rt" CssClass="large-12 columns bgImg" data-equalizer-watch>
                        &nbsp;
                    </asp:Panel>
                </div>
            </asp:View>
        </asp:MultiView>

    </asp:PlaceHolder>
</form>
