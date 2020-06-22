<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="MeetTheAuthors.ascx.vb" Inherits="mvcvb.MeetTheAuthors" %>


<div class="meetTheAuthors">
    <hr />
    <h5>Meet the Authors</h5>
 
    <asp:ListView runat="server" ID="lstviewMeetTheAuthors">
        <LayoutTemplate>
            <ul class="small-block-grid-2 large-block-grid-3 text-center">        
                <asp:PlaceHolder runat="server" ID="itemPlaceholder" />
            </ul>
        </LayoutTemplate>
        <ItemTemplate>
            <li>
                <asp:HyperLink runat="server" title='<%#Eval("authorName")%>' NavigateUrl='<%#Eval("navUrl")%>'>
                    <asp:Image runat="server" AlternateText='<%#Eval("authorName")%>' ImageUrl='<%#Eval("imgUrl")%>' />
                    <br />
                    <%#Eval("authorName")%>
                </asp:HyperLink>
            </li>
        </ItemTemplate>
        <EmptyDataTemplate>
            <div>No authors have been created yet.</div>
        </EmptyDataTemplate>
    </asp:ListView>
    
    <br />
    <br />

</div>