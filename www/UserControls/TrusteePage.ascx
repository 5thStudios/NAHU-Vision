<%@ Control Language="vb" AutoEventWireup="false" CodeFile="TrusteePage.ascx.vb" EnableViewState="false" Inherits="TrusteePage" %>


<form runat="server">
    <div class="row trusteePg">
        <div class="columns">

            <div class="row">
                <div class="columns text-center">
                    <br />
                    <br />
                    <h3>
                        <asp:Literal runat="server" ID="ltrlPgTitle" /></h3>
                    <br />
                </div>
            </div>

            <div class="row">
                <div class="large-6 columns">
                    <asp:Image runat="server" ID="imgTrustee" CssClass="imgTrustee" />
                    <br />
                    <br />
                    <h1>
                        <asp:Literal runat="server" ID="ltrlName" /></h1>
                    <h2>
                        <asp:Literal runat="server" ID="ltrlTitle" /></h2>
                </div>
                <div class="large-18 columns">
                    <asp:Literal runat="server" ID="ltrlSummary" />
                </div>
            </div>

            <div class="row">
                <div class="columns text-center">
                    <br />
                    <asp:HyperLink runat="server" ID="hlnkAllTrustees" Text="Return to " CssClass="button" />
                    <br />
                    <br />
                    <br />
                </div>
            </div>


            <%--<div class="row">
            <div class="columns text-center">
                <br />
                <asp:GridView runat="server" ID="gv" />
                <br />
            </div>
        </div>--%>
        </div>
    </div>

</form>
