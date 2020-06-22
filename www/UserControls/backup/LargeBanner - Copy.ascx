<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="LargeBanner.ascx.vb" Inherits="mvcvb.LargeBanner" %>




<div class="row panel callout">
    <div class="large-22 large-push-1 columns end text-right">
        <img alt="" src="/Images/temp/imgPlaceholder.png" />
    </div>
    <div class="large-16 large-push-2 columns end">

        <asp:Label runat="server" ID="lbl" />

        <h1>
            <asp:Literal runat="server" ID="ltrlTitle" /></h1>
        <asp:Literal runat="server" ID="ltrlSubtitle" />

        <asp:HyperLink runat="server" ID="hlnkCallToAction" CssClass="button" />
    </div>
    <div class="large-20 large-pull-2 columns">
        <hr />
        <ul class="large-block-grid-4">
            <li>
                <div class="row collapse">
                    <div class="large-8 columns">
                        <img alt="" src="/Images/temp/placeholder_in.png" />
                    </div>
                    <div class="large-16 columns">
                        <strong>Button 01</strong><br />
                        mini-text here
                    </div>
                </div>
            </li>
            <li>
                <div class="row collapse">
                    <div class="large-8 columns">
                        <img alt="" src="/Images/temp/placeholder_in.png" />
                    </div>
                    <div class="large-16 columns">
                        <strong>Button 02</strong><br />
                        mini-text here
                    </div>
                </div>
            </li>
            <li>
                <div class="row collapse">
                    <div class="large-8 columns">
                        <img alt="" src="/Images/temp/placeholder_in.png" />
                    </div>
                    <div class="large-16 columns">
                        <strong>Button 03</strong><br />
                        mini-text here
                    </div>
                </div>
            </li>
            <li>
                <div class="row collapse">
                    <div class="large-8 columns">
                        <img alt="" src="/Images/temp/placeholder_in.png" />
                    </div>
                    <div class="large-16 columns">
                        <strong>Button 04</strong><br />
                        mini-text here
                    </div>
                </div>
            </li>
        </ul>





        <asp:ListView runat="server" ID="lstvwLinks">
            <LayoutTemplate>
                <hr />
                <ul class="large-block-grid-4">
                    <asp:PlaceHolder runat="server" ID="itemPlaceholder" />
                </ul>
            </LayoutTemplate>
            <ItemTemplate>
                <li>
                    <%--<asp:HyperLink runat="server" title='<%#Eval("authorName")%>' NavigateUrl='<%#Eval("navUrl")%>'>
                    <asp:Image runat="server" AlternateText='<%#Eval("authorName")%>' ImageUrl='<%#Eval("imgUrl")%>' />
                    <br />
                    <%#Eval("authorName")%>
                    </asp:HyperLink>--%>

                    <a href='<%#Eval("_navUrl")%>'>
                        <div class="row collapse">
                            <div class="large-8 columns">
                                <img alt="" src="/Images/temp/placeholder_in.png" />
                            </div>
                            <div class="large-16 columns">
                                <strong><%#Eval("_title")%></strong><br />
                                <%#Eval("_summary")%>
                            </div>
                        </div>
                    </a>

                </li>
            </ItemTemplate>
            <EmptyDataTemplate></EmptyDataTemplate>
        </asp:ListView>






    </div>
</div>
