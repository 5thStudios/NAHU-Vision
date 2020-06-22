<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="TrusteeList.ascx.vb" Inherits="mvcvb.TrusteeList" %>


<form runat="server">
    <div class="row trusteeList">
        <div class="columns">

            <asp:ListView runat="server" ID="lvTrustees">
                <LayoutTemplate>
                    <ul class="large-block-grid-5">
                        <asp:PlaceHolder runat="server" ID="itemPlaceholder" />
                    </ul>
                </LayoutTemplate>
                <ItemSeparatorTemplate>
                </ItemSeparatorTemplate>
                <ItemTemplate>
                    <li>
                        <a href='<%# Eval("trusteeUrl") %>'>
                            <div class="">
                                <div class="text-center">
                                    <br />
                                    <img alt='<%# Eval("firstName") %> <%# Eval("lastName") %>' src='<%# Eval("photoUrl") %>' />
                                    <br />
                                    <br />
                                </div>
                                <h2><%# Eval("firstName") %> <%# Eval("lastName") %></h2>
                                <h6><%# Eval("title") %></h6>
                            </div>
                        </a>
                    </li>
                    <%--<uc:BlogListItem runat="server" ID="ucBlogListItem" nodeId='<%# Eval("") %>' />--%>
                </ItemTemplate>
                <EmptyDataTemplate>
                    <div>No Trustees have been created yet.</div>
                </EmptyDataTemplate>
            </asp:ListView>

            <br />
            <br />
        </div>
    </div>
</form>
