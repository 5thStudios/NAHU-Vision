<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="TextBlockLocked.ascx.vb" Inherits="mvcvb.TextBlockLocked" %>


<form runat="server">
    <asp:Panel runat="server" ID="pnlTextBlock" CssClass="row textBlock">
        <br />
        <br />
        <asp:Panel runat="server" ID="pnlLockedContent" Visible="false">
            <div class="columns">
                <br />
                <p>
                    <umbraco:Item runat="server" Field="summary" />
                </p>
                <br />
            </div>
            <div class="columns panel locked text-center">
                <br />
                <h3>Members Only</h3>
                <h5>To see the rest of this article and many more, become a member today!</h5>
                <div class="row">
                    <div class="small-12 columns text-right">
                        <a class="button tertiary btnSignIn" onclick="return false;">Log In</a>
                    </div>
                    <div class="small-12 columns text-left">
                        <asp:HyperLink runat="server" ID="hlnkJoin" Text="Join" CssClass="button" />
                    </div>
                </div>
                <div class="readMore">
                    <asp:HyperLink runat="server" ID="hlnkMemberBenefits" Text="View member benefits" />
                </div>
                <br />
            </div>
        </asp:Panel>
        <asp:Panel runat="server" ID="pnlFullContent" Visible="false">
            <asp:MultiView runat="server" ID="mvTextBlock" ActiveViewIndex="0">
                <asp:View runat="server" ID="vShowNavOnLeft">
                    <asp:Panel runat="server" ID="pnlSide" CssClass="hide-for-small-down medium-12 large-7 columns sidePnl" Visible="false">
                        <asp:PlaceHolder runat="server" ID="phSideNav"></asp:PlaceHolder>
                        <asp:Panel runat="server" ID="pnlAdSpace">
                            <br />
                            <br />
                            <div class="row">
                                <div class="large-24 columns text-center">
                                    <div class="flex-video">

                                        <div id='div-gpt-ad-1503081911370-2' style='height: 250px; width: 300px;'>
                                            <script>
                                                googletag.cmd.push(function () { googletag.display('div-gpt-ad-1503081911370-2'); });
                                            </script>
                                        </div>
                                    </div>
                                </div>
                                <br />
                                <br />
                            </div>
                        </asp:Panel>
                    </asp:Panel>
                    <asp:Panel runat="server" ID="pnlContent" CssClass="medium-12 large-17 columns">
                        <asp:Literal runat="server" ID="ltrlContent" />
                        <umbraco:Item runat="server" ID="umbItemContent" Field="tb_content" />
                    </asp:Panel>
                </asp:View>
                <asp:View runat="server" ID="vShowNavOnRight">
                    <asp:Panel runat="server" ID="pnlContent_Rt" CssClass="medium-12 large-16 columns">
                        <asp:Literal runat="server" ID="ltrlContent_Rt" />
                        <umbraco:Item runat="server" ID="umbItemContent_Rt" Field="tb_content" />
                    </asp:Panel>
                    <asp:Panel runat="server" ID="pnlSide_Rt" CssClass="hide-for-small-down medium-12 large-8 columns sidePnl" Visible="false">
                        <asp:PlaceHolder runat="server" ID="phSideNav_Rt"></asp:PlaceHolder>
                        <asp:Panel runat="server" ID="pnlAdSpace_Rt">
                            <br />
                            <br />
                            <div class="panel text-center">
                                <br />
                                <br />
                                <p>Ad Space</p>
                                <br />
                                <br />
                            </div>
                        </asp:Panel>
                    </asp:Panel>
                </asp:View>
            </asp:MultiView>
        </asp:Panel>
        <div class="columns">
            <br />
            <br />
        </div>
    </asp:Panel>
</form>
