<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="TextBlock.ascx.vb" Inherits="mvcvb.TextBlock" %>


<form runat="server">
    <%--<asp:GridView runat="server" ID="gv" />--%>
    <asp:Panel runat="server" ID="pnlTextBlock">
        <br />
        <br />
        <div class="row">
            <asp:MultiView runat="server" ID="mvTextBlock" ActiveViewIndex="0">
                <asp:View runat="server" ID="vShowNavOnLeft">

                    <asp:Panel runat="server" ID="pnlSide" CssClass="large-8 columns" Visible="false">
                        <asp:PlaceHolder runat="server" ID="phSideNav"></asp:PlaceHolder>
                        <asp:Panel runat="server" ID="pnlAdSpace">
                            <div class="panel text-center">
                                <br />
                                <br />
                                <p>Ad Space</p>
                                <br />
                                <br />
                            </div>
                        </asp:Panel>
                    </asp:Panel>

                    <asp:Panel runat="server" ID="pnlContent" CssClass="large-16 columns">
                        <asp:Literal runat="server" ID="ltrlContent" />
                    </asp:Panel>

                </asp:View>

                <asp:View runat="server" ID="vShowNavOnRight">

                    <asp:Panel runat="server" ID="pnlContent_Rt" CssClass="large-16 columns">
                        <asp:Literal runat="server" ID="ltrlContent_Rt" />
                    </asp:Panel>

                    <asp:Panel runat="server" ID="pnlSide_Rt" CssClass="large-8 columns" Visible="false">
                        <asp:PlaceHolder runat="server" ID="phSideNav_Rt"></asp:PlaceHolder>
                        <asp:Panel runat="server" ID="pnlAdSpace_Rt">
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

        </div>
        <br />
        <br />
    </asp:Panel>

</form>
