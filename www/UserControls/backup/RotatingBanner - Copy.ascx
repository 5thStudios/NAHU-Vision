<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="RotatingBanner.ascx.vb" Inherits="mvcvb.RotatingBanner" %>
<%@ Register Src="../UserControls/listItem_Rotator.ascx" TagPrefix="uc" TagName="listItemRotator" %>

<form runat="server">

    <style type="text/css">
        /*TEMP- DELETE THIS WHEN FINISHED*/
        .rotatingBanner .panel:not(:first-child) {display:none;}
    </style>

    <asp:ListView runat="server" ID="lstvRotatingBanner">
        <LayoutTemplate>
            <div class="rotatingBanner">
                <asp:PlaceHolder runat="server" ID="itemPlaceholder" />
            </div>
        </LayoutTemplate>
        <ItemTemplate>
            <uc:listItemRotator runat="server" bannerId='<%# Container.DataItem %>' />
        </ItemTemplate>
        <EmptyDataTemplate></EmptyDataTemplate>
    </asp:ListView>

    <div class="row panel callout">
        <div class="large-20 large-push-2 columns">
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
        </div>
    </div>

</form>