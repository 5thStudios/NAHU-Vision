<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="RotatingBanner.ascx.vb" Inherits="mvcvb.RotatingBanner" %>
<%@ Register Src="../UserControls/listItem_Rotator.ascx" TagPrefix="uc" TagName="listItemRotator" %>



<form runat="server">

    <div class="RotatingBanners">
        <div class="row collapse pnlWithBgImg show-for-large-up">

            <img alt="" class="bgImg" src="https://unsplash.it/1800/750/?blur&random" />
            <img alt="" class="bgImg" src="https://unsplash.it/1800/750/?blur&random" />
            <img alt="" class="bgImg" src="https://unsplash.it/1800/750/?blur&random" />
            <img alt="" class="bgImg" src="https://unsplash.it/1800/750/?blur&random" />

            <div class="large-24 columns floatOnTopCentered">

                <div class="row collapse ">
                    <div class="large-11 large-push-1 columns">


                        <div class="banner">
                            <h1>Welcome to<br>
                                NAHU</h1>
                            <h3>Bring to the table win-win survival strategies to ensure proactive domination. At the end of the day, going forward, a new normal that has evolved from generation X is on the runway heading towards a streamlined cloud solution. User generated content in real-time will have multiple touchpoints for offshoring.
                            </h3>
                            <a class="button" href="/">LEARN MORE</a>
                        </div>


                        <div class="banner">
                            <h1>Welcome to<br>
                                NAHU 2</h1>
                            <h3>Bring to the table win-win survival strategies to ensure proactive domination. At the end of the day, going forward, a new normal that has evolved from generation X is on the runway heading towards a streamlined cloud solution. User generated content in real-time will have multiple touchpoints for offshoring.
                            </h3>
                            <a class="button" href="/">LEARN MORE</a>
                        </div>


                        <div class="banner">
                            <h1>Welcome to<br>
                                NAHU 3</h1>
                            <h3>Bring to the table win-win survival strategies to ensure proactive domination. At the end of the day, going forward, a new normal that has evolved from generation X is on the runway heading towards a streamlined cloud solution. User generated content in real-time will have multiple touchpoints for offshoring.
                            </h3>
                            <a class="button" href="/">LEARN MORE</a>
                        </div>


                        <div class="banner">
                            <h1>Welcome to<br>
                                NAHU 4</h1>
                            <h3>Bring to the table win-win survival strategies to ensure proactive domination. At the end of the day, going forward, a new normal that has evolved from generation X is on the runway heading towards a streamlined cloud solution. User generated content in real-time will have multiple touchpoints for offshoring.
                            </h3>
                            <a class="button" href="/">LEARN MORE</a>
                        </div>


                    </div>

                    <div class="large-5 columns text-right ">
                        <ul class="large-block-grid-1 sideNav" data-equalizer>
                            <li>
                                <div class="row">
                                    <div class="large-17 columns text-right" data-equalizer-watch>
                                        <div class="title">Membership</div>
                                        <div class="subtitle">Generic Info Here</div>
                                    </div>
                                    <div class="large-5 large-push-2 columns end text-left" data-equalizer-watch>
                                        <div class="valignMiddle-">
                                            <img alt="" src="../Images/Common/icons/membership.png" />
                                            <img alt="" src="../Images/Common/icons/membership_hover.png" />
                                        </div>
                                    </div>
                                </div>
                            </li>
                            <li>
                                <div class="row">
                                    <div class="large-17 columns text-right" data-equalizer-watch>
                                        <div class="title">Advocacy</div>
                                        <div class="subtitle">Generic Info Here</div>
                                    </div>
                                    <div class="large-5 large-push-2 columns end text-left" data-equalizer-watch>
                                        <div class="valignMiddle-">
                                            <img alt="" src="../Images/Common/icons/advocacy.png" />
                                            <img alt="" src="../Images/Common/icons/advocacy_hover.png" />
                                        </div>
                                    </div>
                                </div>
                            </li>
                            <li>
                                <div class="row">
                                    <div class="large-17 columns text-right" data-equalizer-watch>
                                        <div class="title">Development</div>
                                        <div class="subtitle">Generic Info Here</div>
                                    </div>
                                    <div class="large-5 large-push-2 columns end text-left" data-equalizer-watch>
                                        <div class="valignMiddle-">
                                            <img alt="" src="../Images/Common/icons/development.png" />
                                            <img alt="" src="../Images/Common/icons/development_hover.png" />
                                        </div>
                                    </div>
                                </div>
                            </li>
                            <li>
                                <div class="row">
                                    <div class="large-17 columns text-right" data-equalizer-watch>
                                        <div class="title">Resources</div>
                                        <div class="subtitle">Generic Info Here</div>
                                    </div>
                                    <div class="large-5 large-push-2 columns end text-left" data-equalizer-watch>
                                        <div class="valignMiddle-">
                                            <img alt="" src="../Images/Common/icons/resources.png" />
                                            <img alt="" src="../Images/Common/icons/resources_hover.png" />
                                        </div>
                                    </div>
                                </div>
                            </li>
                        </ul>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <%--<img id="cphMainContent_imgRow1Image" src="/media/1315/atonement-luthern-exterior.jpg?anchor=center&amp;mode=crop&amp;width=1560&amp;height=650&amp;rnd=131329776580000000" alt="Atonement Luthern Exterior">--%>


    <div class="hide">
        <asp:PlaceHolder runat="server" ID="phRotatingBanner">
            <asp:ListView runat="server" ID="lstvRotatingBanner">
                <LayoutTemplate>
                    <div class="rotatingBanner">
                        <asp:PlaceHolder runat="server" ID="itemPlaceholder" />
                    </div>
                </LayoutTemplate>
                <ItemTemplate>
                    <uc:listItemRotator runat="server" rotator='<%# Container.DataItem %>' />
                </ItemTemplate>
                <EmptyDataTemplate></EmptyDataTemplate>
            </asp:ListView>
            <asp:ListView runat="server" ID="lstvBannerLinks">
                <LayoutTemplate>
                    <div class="row panel callout">
                        <div class="large-20 large-push-2 columns">
                            <hr />
                            <ul class="large-block-grid-4">
                                <asp:PlaceHolder runat="server" ID="itemPlaceholder" />
                            </ul>
                        </div>
                    </div>
                </LayoutTemplate>
                <ItemTemplate>
                    <li>
                        <div class="row collapse">
                            <div class="large-8 columns">
                                <img alt="" src="/Images/temp/placeholder_in.png" />
                            </div>
                            <div class="large-16 columns">
                                <strong><%#Eval("quicklinkTitle")%></strong><br />
                                <%#Eval("quicklinkSubtitle")%>
                            </div>
                        </div>
                    </li>
                </ItemTemplate>
                <EmptyDataTemplate></EmptyDataTemplate>
            </asp:ListView>
        </asp:PlaceHolder>
    </div>


</form>
