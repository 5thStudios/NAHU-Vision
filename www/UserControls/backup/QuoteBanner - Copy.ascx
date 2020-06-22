<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="QuoteBanner.ascx.vb" Inherits="mvcvb.QuoteBanner" %>

<form runat="server">

    <div class="quoteBanner">
        <asp:panel runat="server" ID="pnlQuoteBanner" CssClass="row collapse pnlWithBgImg">
            <asp:Image runat="server" ID="imgBackground" class="imgHeadingBanner" />

            <asp:Panel runat="server" ID="pnlContent" CssClass="large-20 large-push-2 columns floatOnTopCentered">
                <asp:panel runat="server" ID="pnlText">
                    <div class="row">
                        <div class="columns">
                            <h2 runat="server" ID="h2"><asp:Literal runat="server" ID="ltrlTitle" /></h2>
                            <br />
                        </div>
                    </div>

                    <asp:Panel runat="server" ID="pnlSubtitle" Visible="false" CssClass="row " >
                        <asp:Panel runat="server" ID="pnlSubtitleAlignLeft" CssClass="large-14 columns" Visible="false">
                            <h3 runat="server" ID="h3a">
                                <asp:Literal runat="server" ID="ltrlSubtitle" />
                            </h3>
                            <br />
                        </asp:Panel>
                        <asp:Panel runat="server" ID="pnlSubtitleAlignCenter" CssClass="large-14 large-push-5 columns" Visible="false">
                            <h3 runat="server" ID="h3b">
                                <asp:Literal runat="server" ID="ltrlSubtitle2" />
                            </h3>
                            <br />
                        </asp:Panel>
                        <asp:Panel runat="server" ID="pnlSubtitleAlignRight" CssClass="large-14 large-push-10 columns" Visible="false">
                            <h3 runat="server" ID="h3c">
                                <asp:Literal runat="server" ID="ltrlSubtitle3" />
                            </h3>
                            <br />
                        </asp:Panel>
                    </asp:Panel>
                </asp:panel>

                <div class="row">
                </div>
                <div class="row">
                    <div class="columns">
                        <asp:HyperLink runat="server" ID="hlnkCallToAction" CssClass="button" Visible="false" />
                    </div>
                </div>
            </asp:Panel>
        </asp:panel>
    </div>

</form>