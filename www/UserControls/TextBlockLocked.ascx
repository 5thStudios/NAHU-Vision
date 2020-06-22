﻿<%@ Control Language="vb" AutoEventWireup="false" CodeFile="TextBlockLocked.ascx.vb" EnableViewState="false" Inherits="TextBlockLocked" %>


<form runat="server">
    <div class="pnlTextBlock">
        <asp:Panel runat="server" ID="pnlTextBlock" CssClass="row textBlock">
            <br />
            <br />

            <asp:Panel runat="server" ID="pnlLogin" Visible="false">
                <div class="small-22 small-push-1 medium-12 medium-push-6 large-6 large-push-9 columns panel locked text-center">
                    <br />
                    <h3>Board Members Only</h3>
                    <h5>Please login to view page.</h5>
                    <br />


                    <div class="errorMsg columns text-right hide"></div>

                    <div class=" ">
                        <input type="text" placeholder="Email Address" id="txbUserName_bMember" />
                    </div>
                    <div class=" ">
                        <input type="password" placeholder="Password (case sensitive)" id="txbPassword_bMember" />
                    </div>

                    <br />
                    <div class=" ">
                        <a class="button" id="btnSubmitBoardLogin">Log In</a><br />
                    </div>
                </div>
                <div class="columns">
                    <br />
                    <br />
                </div>
            </asp:Panel>
            <asp:Panel runat="server" ID="pnlLockedContent" Visible="false">
                <div class="columns pnlSummary_lockedContent">
                    <p>
                        <umbraco:Item runat="server" Field="summary" />
                    </p>
                    <br />
                </div>
                <div class="columns panel locked text-center">
                    <br />
                    <h3>Members Only</h3>
                    <h5>To see the rest of this article and many more, become a member today!</h5>
                    <div class="row">
                        <div class="small-12 columns text-right">
                            <a class="button tertiary btnSignIn" onclick="return false;">Log In</a>
                        </div>
                        <div class="small-12 columns text-left">
                            <asp:HyperLink runat="server" ID="hlnkJoin" Text="Join" CssClass="button" />
                        </div>
                    </div>
                    <div class="readMore">
                        <asp:HyperLink runat="server" ID="hlnkMemberBenefits" Text="View member benefits" />
                    </div>
                    <br />
                </div>
            </asp:Panel>
            <asp:Panel runat="server" ID="pnlFullContent" Visible="false">
                <div class="columns pnlSummary_donationPgOnly hide">
                    <p>
                        <umbraco:Item runat="server" Field="summary" />
                    </p>
                    <br />
                </div>
                <asp:MultiView runat="server" ID="mvTextBlock" ActiveViewIndex="0">
                    <asp:View runat="server" ID="vShowNavOnLeft">
                        <asp:Panel runat="server" ID="pnlSide" CssClass="hide-for-small-down medium-12 large-7 columns sidePnl" Visible="false">
                            <asp:PlaceHolder runat="server" ID="phSideNav"></asp:PlaceHolder>
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
                                        </div>
                                    </div>
                                    <br />
                                    <br />
                                </div>
                            </asp:Panel>
                        </asp:Panel>
                        <asp:Panel runat="server" ID="pnlContent" CssClass="medium-12 large-17 columns">
                            <asp:Literal runat="server" ID="ltrlContent" />
                            <%--<umbraco:Item runat="server" ID="umbItemContent" Field="tb_content" />--%>



                            
                            <asp:HiddenField runat="server" ID="hfldIsCCDonationPg" ClientIDMode="Static" />
                            <asp:HiddenField runat="server" ID="hfldIsBankDonationPg" ClientIDMode="Static" />




                            <asp:Panel runat="server" ID="pnlLogInAsPACMember" Visible="false" CssClass="row pnlLogInAsPACMember">
                                <div class="columns text-center">
                                    <br />
                                    <br />
                                    <h3>Log in as a PAC-Eligible Member</h3>
                                    <h5>Or join as a PAC-eligible user to contribute.</h5>
                                    <div class="row">
                                        <div class="small-12 columns text-right">
                                            <a class="button tertiary btnSignIn" onclick="return false;">Log In</a>
                                        </div>
                                        <div class="small-12 columns text-left">
                                            <asp:HyperLink runat="server" ID="hlnkJoin2" Text="Join" CssClass="button" />
                                        </div>
                                    </div>
                                    <div class="readMore">
                                        <asp:HyperLink runat="server" ID="hlnkMemberBenefits2" Text="View member benefits" />
                                    </div>
                                    <br />
                                    <br />
                                </div>
                            </asp:Panel>




                            <asp:Panel runat="server" ID="pnlInvalidUser" Visible="false" CssClass="row pnlInvalidUser">
                                <div class="columns text-center">
                                    <br />
                                    <br />
                                    <h3>PAC-Eligible Members Only</h3>
                                    <h5>Please log in as a PAC-eligible user to contribute.</h5>
                                    <br />
                                    <br />
                                </div>
                            </asp:Panel>



                            <div class="row  pnlValidating hide">
                                <br />
                                <br />
                                <div class="small-24 medium-11 columns small-text-center medium-text-right">
                                    <img alt="loading" src="/Images/Common/icons/loading.gif" />
                                </div>
                                <div class="small-24 medium-13 columns small-text-center medium-text-left">
                                    <h3 style="margin: 12px 0 0 0;">One moment</h3>
                                    <h5>As we validate your credentials</h5>
                                </div>
                                <div class="columns">
                                    <br />
                                    <br />
                                </div>
                            </div>




                            <div class="row pnlValidUser hide">
                                <div class="columns text-center">
                                    <br />
                                    <h3>Valid Member</h3>
                                    <h5>When live, will redirect to:
                                        <br />
                                        <strong id="strUrl"></strong></h5>
                                    <br />
                                </div>
                                <br />
                                <br />
                            </div>




                        </asp:Panel>
                    </asp:View>
                    <asp:View runat="server" ID="vShowNavOnRight">
                        <asp:Panel runat="server" ID="pnlContent_Rt" CssClass="medium-12 large-16 columns">
                            <asp:Literal runat="server" ID="ltrlContent_Rt" />
                            <%--<umbraco:Item runat="server" ID="umbItemContent_Rt" Field="tb_content" />--%>
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
            </asp:Panel>
            <div class="columns">
                <br />
                <br />
            </div>

            <asp:HiddenField runat="server" ID="hfldIsBoardPg" ClientIDMode="Static" />
        </asp:Panel>
    </div>




    <br />
    <br />
</form>
