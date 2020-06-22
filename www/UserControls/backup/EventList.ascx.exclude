<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="EventList.ascx.vb" Inherits="mvcvb.EventList" %>
<%@ Register Src="/UserControls/ListItem_UpcomingEvent.ascx" TagName="ListItem_UpcomingEvent" TagPrefix="uc" %>
<%@ Register Src="/UserControls/EventFilter.ascx" TagName="EventFilter" TagPrefix="uc" %>
<%@ Register Src="/UserControls/ListViewOptions.ascx" TagName="ListViewOptions" TagPrefix="uc" %>



<form runat="server">
    <div class="eventList row">
        <br>
        <br>
        <div class="medium-16 columns">


            <%--<asp:GridView runat="server" ID="gv1" />
                <asp:GridView runat="server" ID="gv2" />
                <asp:GridView runat="server" ID="gv3" />
                <asp:GridView runat="server" ID="gv4" />
                <asp:GridView runat="server" ID="gv5" />
                <asp:GridView runat="server" ID="gv6" />--%>


            <div class="row">
                <div class="large-7 columns">
                    <uc:ListViewOptions runat="server" />
                </div>
                <div class="large-17 columns">
                    <br />
                    <div class="pagination-page"></div>
                </div>
            </div>
            <br />
            <br />

            <div class="row">
                <div class="columns">
                    <div class="gallery">
                        <section id="sectionMainContent" class="floatLeft topMargin">
                            <section id="sectionContent">
                                <section id="sectionContentLeftColumn" class="contentPage">

                                    <asp:ListView runat="server" ID="lvEventEntries">
                                        <LayoutTemplate>
                                            <section class="">
                                                <div class="row" data-equalizer data-equalizer-mq="medium-up">
                                                    <asp:PlaceHolder runat="server" ID="itemPlaceholder" />
                                                </div>
                                            </section>
                                        </LayoutTemplate>
                                        <ItemSeparatorTemplate>
                                        </ItemSeparatorTemplate>
                                        <ItemTemplate>
                                            <uc:ListItem_UpcomingEvent runat="server" ID="ucUpcomingEvent" EventItem='<%# Container.DataItem %>' />
                                        </ItemTemplate>
                                        <EmptyDataTemplate>
                                            <div>No entries have been created yet.</div>
                                        </EmptyDataTemplate>
                                    </asp:ListView>

                                </section>
                            </section>
                        </section>
                    </div>
                </div>
            </div>

            <div class="row">
                <div class="columns">
                    <div class="pagination-page"></div>
                    <br />
                    <br />
                </div>
            </div>

        </div>

        <div class="medium-8 columns">
            <uc:EventFilter runat="server" />
        </div>
    </div>
</form>
