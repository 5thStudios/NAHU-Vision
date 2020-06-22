<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="TextBlock.ascx.vb" Inherits="mvcvb.TextBlock" %>


<form runat="server">
    <asp:Panel runat="server" ID="pnlTextBlock" CssClass="row textBlock">
        <br />
        <br />
            <asp:MultiView runat="server" ID="mvTextBlock" ActiveViewIndex="0">
                <asp:View runat="server" ID="vShowNavOnLeft">

                    <asp:Panel runat="server" ID="pnlSide" CssClass="hide-for-small-down medium-12 large-7 columns sidePnl" Visible="false">
                        <asp:PlaceHolder runat="server" ID="phSideNav">
                        </asp:PlaceHolder>
                        <asp:Panel runat="server" ID="pnlAdSpace">
                            <br />
                            <br />
                            <div class="row">
                            <div class="large-24 columns text-center">


                                <div class="flex-video">

                                    <div id='div-gpt-ad-1503081911370-2' style='height: 250px; width: 300px;'>
                                    <script>
                                        googletag.cmd.push(function () { googletag.display('div-gpt-ad-1503081911370-2'); });
                                    </script>
                                </div>

                                <%--<!-- /14444846/NAHU_NAHU.org_LargeBanner_970x250 -->
                                <div id='div-gpt-ad-1503081911370-1' style='height: 250px; width: 970px;'>                                     <script>
                                        googletag.cmd.push(function () { googletag.display('div-gpt-ad-1503081911370-1'); });
                                    </script>
                                </div>--%>
                                </div>
                                    </div>



<%--                                <div class="iab-flexad">
                                    <div class="iab-flexsizer flex-8x1"></div>
                                    <div class="iab-adcontent">
                                        <!-- AD INSERTED HERE -->

                                        <!-- /3790/Flex8:1 -->
                                        <div id="div-gpt-flex-ad" data-google-query-id="CJeA0b-Z7tUCFa-6swodDZ8FYg" style="height: 100%; width: 100%;">
                                            <script>
                                                googletag.cmd.push(function () { googletag.display('div-gpt-flex-ad'); });
                                            </script>
                                            <div id="google_ads_iframe_/3790/Flex8:1_0__container__" style="border: 0pt none; height: 100%; width: 100%;">
                                                <iframe id="google_ads_iframe_/3790/Flex8:1_0" title="3rd party ad content" name="google_ads_iframe_/3790/Flex8:1_0" width="1" height="1" scrolling="no" marginwidth="0" marginheight="0" frameborder="0" srcdoc="" style="border: 0px; vertical-align: bottom; width: 100%; height: 150px;"></iframe>
                                            </div>
                                        </div>

                                    </div>
                                </div>--%>







                                <br />
                                <br />
                            </div>
                        </asp:Panel>
                    </asp:Panel>

                    <asp:Panel runat="server" ID="pnlContent" CssClass="medium-12 large-17 columns">
                        <asp:Literal runat="server" ID="ltrlContent" />
                        <umbraco:Item runat="server" ID="umbItemContent" Field="tb_content"   />
                    </asp:Panel>

                </asp:View>

                <asp:View runat="server" ID="vShowNavOnRight">

                    <asp:Panel runat="server" ID="pnlContent_Rt" CssClass="medium-12 large-16 columns">
                        <asp:Literal runat="server" ID="ltrlContent_Rt" />
                        <umbraco:Item runat="server" ID="umbItemContent_Rt" Field="tb_content"  />
                    </asp:Panel>

                    <asp:Panel runat="server" ID="pnlSide_Rt" CssClass="hide-for-small-down medium-12 large-8 columns sidePnl" Visible="false">
                        <asp:PlaceHolder runat="server" ID="phSideNav_Rt"></asp:PlaceHolder>
                        <asp:Panel runat="server" ID="pnlAdSpace_Rt">
                            <br />
                            <br />
                            <div class="panel text-center">
                                <br />
                                <br />
                                <p>Ad Space</p>
                                <br />
                                <br />
                            </div>
                        </asp:Panel>
                    </asp:Panel>

                </asp:View>
            </asp:MultiView>
        <div class="columns">
            <br />
            <br />
        </div>
    </asp:Panel>
</form>