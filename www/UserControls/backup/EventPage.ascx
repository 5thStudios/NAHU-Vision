<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="EventPage.ascx.vb" Inherits="mvcvb.EventPage" %>
<%@ Register Src="/UserControls/EventTimeFrame.ascx" TagPrefix="uc" TagName="EventTimeFrame" %>
<%@ Register Src="~/UserControls/AddThisTemplateA.ascx" TagPrefix="uc" TagName="AddThisTemplateA" %>


<form runat="server">

        <asp:Panel runat="server" ID="pnlEvent" CssClass="row EventPg">

        <br />
        <br />
            <div class="medium-10 large-6 columns">

                <asp:Image runat="server" ID="imgFeatured" />
                <br />
                <br />
                <h1><asp:Literal runat="server" ID="ltrlTitle" /></h1>
                <br />

                <asp:PlaceHolder runat="server" ID="phChapterAffilitation">
                    <h2>Chapter Affiliation</h2>
                    <asp:PlaceHolder runat="server" ID="phChapters" />
                    <br />
                </asp:PlaceHolder>

                <asp:PlaceHolder runat="server" ID="phDateTime">
                    <h2>Date | Time</h2>
                    <div class="">
                        <uc:EventTimeFrame runat="server" ID="ucEventTimeFrame" />
                    </div>
                    <br />
                </asp:PlaceHolder>

                <asp:PlaceHolder runat="server" ID="phLocation">
                    <h2>Location</h2>
                    <div>
                        <asp:Literal runat="server" ID="ltrlLocation" />
                    </div>
                    <br />
                </asp:PlaceHolder>

                <asp:ListView runat="server" ID="lvSponsors">
                    <LayoutTemplate>
                        <h2>Sponsored by</h2>
                        <asp:PlaceHolder runat="server" ID="itemPlaceholder" />
                        <br />
                    </LayoutTemplate>
                    <ItemSeparatorTemplate />
                    <ItemTemplate>
                        <div>
                            <a href='<%# Eval("url") %>' data-id='<%# Eval("id") %>' target="_blank">
                                <img alt='<%# Eval("name") %>' src='<%# Eval("logoUrl") %>' />
                            </a>
                        </div>
                        <br />
                    </ItemTemplate>
                    <EmptyDataTemplate />
                </asp:ListView>

                <uc:AddThisTemplateA runat="server" id="AddThisTemplateA" />
                <br />
                <br />

            </div>

            <div class="medium-14 large-18 columns">
                <div>
                    <asp:Literal runat="server" ID="ltrlContent" />
                </div>


                <asp:PlaceHolder runat="server" ID="phContactList" Visible="false">
                    <h2>Contacts:</h2>
                    <asp:PlaceHolder runat="server" ID="phContacts" />
                    <br />
                </asp:PlaceHolder>

                <asp:Panel runat="server" ID="pnlRegister" Visible="false">
                    <br />
                    <asp:HyperLink runat="server" ID="hlnkRegister" Text="Register" CssClass="button" />
                </asp:Panel>



            </div>

        </asp:Panel>




    <%--<hr />
    <hr />
    <hr />
    <asp:GridView runat="server" ID="gv" />
    <hr />
    <asp:GridView runat="server" ID="gvRecurringEvent" />
    <hr />
    <asp:GridView runat="server" ID="gvLocations" />
    <hr />
    <asp:GridView runat="server" ID="gvMembers" />
    <hr />
    <asp:GridView runat="server" ID="gvChapters" />--%>
</form>
