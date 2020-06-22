<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="FaqList.ascx.vb" Inherits="mvcvb.FaqList" %>


<form runat="server">
    <div class="row">
        <div class="columns text-center">
            <br />
            <h3>FAQs</h3>
            <br />
        </div>
    </div>

    <%--<hr />
    <asp:GridView runat="server" ID="gv" />
    <hr />--%>

    <div class="row">
        <div class="columns">

            <asp:ListView runat="server" ID="lvFAQs">
                <LayoutTemplate>
                    <div id="accordion">
                        <asp:PlaceHolder runat="server" ID="itemPlaceholder" />
                    </div>
                </LayoutTemplate>
                <ItemSeparatorTemplate>
                </ItemSeparatorTemplate>
                <ItemTemplate>
                    <h3><%# Eval("question") %></h3>
                    <div>
                        <p><%# Eval("answer") %></p>
                    </div>
                </ItemTemplate>
                <EmptyDataTemplate>
                    <div>No FAQs have been created yet.</div>
                </EmptyDataTemplate>
            </asp:ListView>


            <%--<div id="accordion">
                <h3>Section 1</h3>
                <div>
                    <p>Mauris mauris ante, blandit et, ultrices a, suscipit eget, quam. Integer ut neque. Vivamus nisi metus, molestie vel, gravida in, condimentum sit amet, nunc. Nam a nibh. Donec suscipit eros. Nam mi. Proin viverra leo ut odio. Curabitur malesuada. Vestibulum a velit eu ante scelerisque vulputate.</p>
                </div>
                <h3>Section 2</h3>
                <div>
                    <p>Sed non urna. Donec et ante. Phasellus eu ligula. Vestibulum sit amet purus. Vivamus hendrerit, dolor at aliquet laoreet, mauris turpis porttitor velit, faucibus interdum tellus libero ac justo. Vivamus non quam. In suscipit faucibus urna. </p>
                </div>
                <h3>Section 3</h3>
                <div>
                    <p>Cras dictum. Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia Curae; Aenean lacinia mauris vel est. </p>
                    <p>Suspendisse eu nisl. Nullam ut libero. Integer dignissim consequat lectus. Class aptent taciti sociosqu ad litora torquent per conubia nostra, per inceptos himenaeos. </p>
                </div>
            </div>

            <hr />
            <hr />

            <ul class="accordion" data-accordion>
                <li class="accordion-navigation">
                    <a href="#panel1a" class="panel">Accordion 1</a>
                    <div id="panel1a" class="content active">
                        Panel 1. Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.
                    </div>
                </li>
                <li class="accordion-navigation">
                    <a href="#panel2a" class="panel">Accordion 2</a>
                    <div id="panel2a" class="content">
                        Panel 2. Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.
                    </div>
                </li>
                <li class="accordion-navigation">
                    <a href="#panel3a" class="panel">Accordion 3</a>
                    <div id="panel3a" class="content">
                        Panel 3. Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.
                    </div>
                </li>
            </ul>--%>

        </div>
    </div>

    <br />
    <br />

</form>
