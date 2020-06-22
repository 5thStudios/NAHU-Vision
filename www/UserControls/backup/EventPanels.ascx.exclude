<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="EventPanels.ascx.vb" Inherits="mvcvb.EventPanels" %>

<form runat="server">
<div class="row">
        <div class="columns">
            <br />
            <br />
            <br />
            <h4 class="text-center">EVENTS</h4>
            <br />
            <ul class="large-block-grid-4">
                <li>
                    <div class="panel text-center">
                        <br />
                        <br />
                        <img alt="" src="/Images/temp/imgPlaceholder.png" />
                        <br />
                        <br />
                        <br />
                    </div>
                    <br />
                    <div><strong>Suspendisse Fringilla</strong></div>
                    <div>APRIL 27, 2017</div>
                </li>
                <li>
                    <div class="panel text-center">
                        <br />
                        <br />
                        <img alt="" src="/Images/temp/imgPlaceholder.png" />
                        <br />
                        <br />
                        <br />
                    </div>
                    <br />
                    <div><strong>Suspendisse Fringilla</strong></div>
                    <div>APRIL 27, 2017</div>
                </li>
                <li>
                    <div class="panel text-center">
                        <br />
                        <br />
                        <img alt="" src="/Images/temp/imgPlaceholder.png" />
                        <br />
                        <br />
                        <br />
                    </div>
                    <br />
                    <div><strong>Suspendisse Fringilla</strong></div>
                    <div>APRIL 27, 2017</div>
                </li>
                <li>
                    <div class="panel text-center">
                        <br />
                        <br />
                        <img alt="" src="/Images/temp/imgPlaceholder.png" />
                        <br />
                        <br />
                        <br />
                    </div>
                    <br />
                    <div><strong>Suspendisse Fringilla</strong></div>
                    <div>APRIL 27, 2017</div>
                </li>
            </ul>
            <br />
            <div class="text-center">
                <a href="/" class="button">SEE ALL UPCOMING EVENTS</a>
            </div>
            <br />
            <br />
            <br />


            <hr />


            <%--<asp:GridView runat="server" ID="gv"></asp:GridView>
            <asp:Label runat="server" ID="lbl" ForeColor="Red" />--%>

            <asp:ListView runat="server" ID="lstviewUpcomingEvents">
                <LayoutTemplate>
                    <ul class="large-block-grid-4">
                        <asp:PlaceHolder runat="server" ID="itemPlaceholder" />
                    </ul>
                </LayoutTemplate>
                <ItemTemplate>
                    <li>
                        <uc:ListItem_TopUpcomingEvent runat="server" ID="ucUpcomingEvent" EventItem='<%# Container.DataItem %>' />
                    </li>
                </ItemTemplate>
                <EmptyDataTemplate>
                    <div>No events have been created yet.</div>
                </EmptyDataTemplate>
            </asp:ListView>


        </div>
    </div>
</form>
