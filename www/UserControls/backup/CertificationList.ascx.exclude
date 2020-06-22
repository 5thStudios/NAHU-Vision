<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="CertificationList.ascx.vb" Inherits="mvcvb.CertificationList" %>
<%@ Register Src="/UserControls/ListItem_Certification.ascx" TagName="ListItem_Certification" TagPrefix="uc" %>


<form runat="server">

    <div class="row certificationList">

        <br />
        <br />
        <asp:ListView runat="server" ID="lvCertifications">
            <LayoutTemplate>
                <div class="row" data-equalizer data-equalizer-mq="medium-up">
                    <asp:PlaceHolder runat="server" ID="itemPlaceholder" />
                </div>
            </LayoutTemplate>
            <ItemSeparatorTemplate>
            </ItemSeparatorTemplate>
            <ItemTemplate>
                <section class="medium-12 columns" data-equalizer-watch>
                    <uc:ListItem_Certification runat="server" Certification='<%# Container.DataItem %>' />
                </section>
            </ItemTemplate>
            <EmptyDataTemplate>
                <div>No certifications have been created yet.</div>
            </EmptyDataTemplate>
        </asp:ListView>

        <br />
        <br />
    </div>

</form>
