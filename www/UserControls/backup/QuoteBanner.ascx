<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="QuoteBanner.ascx.vb" Inherits="mvcvb.QuoteBanner" %>

<form runat="server">

    <div class="">

        <asp:panel runat="server" ID="pnlQuoteBanner" CssClass="quoteBanner row collapse pnlWithBgImg show-for-large-up">
            <asp:Image runat="server" ID="imgBackground" class="imgHeadingBanner" />

            <asp:Panel runat="server" ID="pnlContent" CssClass="medium-20 medium-push-2 columns floatOnTopCentered">
                <asp:panel runat="server" ID="pnlText">
                    <div class="row">
                        <div class="columns">
                            <h2 runat="server" ID="h2"><asp:Literal runat="server" ID="ltrlTitle" /></h2>
                            <br />
                        </div>
                    </div>

                    <asp:Panel runat="server" ID="pnlSubtitle" Visible="false" CssClass="row " >
                        <asp:Panel runat="server" ID="pnlSubtitleAlignLeft" CssClass="medium-14 columns" Visible="false">
                            <h3 runat="server" ID="h3a">
                                <asp:Literal runat="server" ID="ltrlSubtitle" />
                            </h3>
                            <br />
                        </asp:Panel>
                        <asp:Panel runat="server" ID="pnlSubtitleAlignCenter" CssClass="medium-14 medium-push-5 columns" Visible="false">
                            <h3 runat="server" ID="h3b">
                                <asp:Literal runat="server" ID="ltrlSubtitle2" />
                            </h3>
                            <br />
                        </asp:Panel>
                        <asp:Panel runat="server" ID="pnlSubtitleAlignRight" CssClass="medium-14 medium-push-10 columns" Visible="false">
                            <h3 runat="server" ID="h3c">
                                <asp:Literal runat="server" ID="ltrlSubtitle3" />
                            </h3>
                            <br />
                        </asp:Panel>
                    </asp:Panel>
                </asp:panel>

                <div class="row">
                    <div class="columns">
                        <asp:HyperLink runat="server" ID="hlnkCallToAction" CssClass="button" Visible="false" />
                    </div>
                </div>
            </asp:Panel>
        </asp:panel>



        <asp:panel runat="server" ID="pnlQuoteBanner_Mbl" CssClass="quoteBanner row collapse show-for-medium-down quoteBanner_Mbl ">
            <asp:Panel runat="server" ID="pnlContent_Mbl" CssClass="small-20 small-push-2 columns">
                <asp:panel runat="server" ID="pnlText_Mbl">
                    <div class="row">
                        <br />
                        <div class="columns">
                            <h2 runat="server" ID="h2_Mbl"><asp:Literal runat="server" ID="ltrlTitle_Mbl" /></h2>
                            <br />
                        </div>
                    </div>

                    <asp:Panel runat="server" ID="pnlSubtitle_Mbl" Visible="false" CssClass="row " >
                        <asp:Panel runat="server" ID="pnlSubtitleAlignLeft_Mbl" CssClass="small-24 columns" Visible="false">
                            <h3 runat="server" ID="h3a_Mbl">
                                <asp:Literal runat="server" ID="ltrlSubtitle_Mbl" />
                            </h3>
                            <br />
                        </asp:Panel>
                        <asp:Panel runat="server" ID="pnlSubtitleAlignCenter_Mbl" CssClass="small-24 columns" Visible="false">
                            <h3 runat="server" ID="h3b_Mbl">
                                <asp:Literal runat="server" ID="ltrlSubtitle2_Mbl" />
                            </h3>
                            <br />
                        </asp:Panel>
                        <asp:Panel runat="server" ID="pnlSubtitleAlignRight_Mbl" CssClass="small-24 columns" Visible="false">
                            <h3 runat="server" ID="h3c_Mbl">
                                <asp:Literal runat="server" ID="ltrlSubtitle3_Mbl" />
                            </h3>
                            <br />
                        </asp:Panel>
                    </asp:Panel>
                </asp:panel>

                <div class="row">
                    <div class="columns">
                        <asp:HyperLink runat="server" ID="hlnkCallToAction_Mbl" CssClass="button" Visible="false" />
                    </div>
                    <br />
                    <br />
                    <br />
                </div>
            </asp:Panel>
        </asp:panel>


    </div>
</form>