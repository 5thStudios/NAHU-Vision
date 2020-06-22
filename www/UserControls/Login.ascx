<%@ Control Language="vb" AutoEventWireup="false" CodeFile="Login.ascx.vb" EnableViewState="false" Inherits="Login" %>



<form runat="server" id="frmLogin">
    <input type="hidden" runat="server" id="hfldRootClass" class="hfldRootClass" />

    <div id="dialogModal" class="reveal-modal full" data-reveal aria-labelledby="modalTitle" aria-hidden="true" role="dialog">
        <div class="row">
            <div class="medium-12 medium-push-6 large-8 large-push-8 columns innerModal text-center">

                <a class="close-reveal-modal" aria-label="Close">&#215;</a>

                <br />
                <br />
                <div class="row">
                    <div class="small-20 small-push-2 columns">

                        <div class="row">
                            <div class=" columns">
                                <img alt="NAHU" src="/Images/Common/NAHU_logo.png">
                                <br />
                                <br />
                            </div>

                            <div class="errorMsg columns text-right hide"></div>
                            <div class="successMsg columns text-right hide"></div>


                            <asp:MultiView runat="server" ID="mvLogin" ActiveViewIndex="0">
                                <asp:View runat="server" ID="vLogin">
                                    <div class=" columns">
                                        <input type="text" placeholder="Email Address" id="txbUserName" />
                                    </div>

                                    <div id="loginControls">
                                        <div class=" columns">
                                            <input type="password" placeholder="Password (case sensitive)" id="txbPassword" />
                                        </div>

                                        <div class=" columns">
                                            <a class="button" id="btnSubmitLogin">Log In</a><br />
                                        </div>

                                        <div class=" columns">
                                            <br />
                                            <h6>Forgot
                                        <strong>
                                            <a href="https://members.nahu.org/NAHU_Prod_Imis/NAHU_Member/UAM/ForgotPassword/Nahu_Member/UAM/Forgot_Password.aspx?hkey=3d19850f-abc4-476a-8256-caaa2ff4a4c4" target="_blank">password</a>
                                            <%--<a href="https://members.nahu.org/nahu_prod_imis/" target="_blank">password</a>--%>				
                                        </strong>?
                                            </h6>
                                            <br />
                                        </div>

                                        <hr />
                                        <div class=" columns">
                                            <asp:HyperLink runat="server" ID="hlnkJoinNow" CssClass="button secondary" Text="Join Now" />
                                            <br />
                                            <br />
                                        </div>

                                        <div class=" columns">
                                            <asp:HyperLink runat="server" ID="hlnkRenewMembership" CssClass="button secondary" Text="Renew Membership" />
                                        </div>
                                    </div>

                                    <div id="passwordResetControls" class="hide">
                                        <div class=" columns">
                                            <a class="button" id="btnSubmitPasswordReset">Retrieve Password</a>
                                            <br />
                                        </div>

                                        <div class=" columns">
                                            <br />
                                            <a class="button quaternary" id="btnCancelPasswordReset">Cancel</a>
                                            <br />
                                            <br />
                                        </div>
                                    </div>
                                </asp:View>
                                <asp:View runat="server" ID="vDisabled">                                    
                                    <h2 style="color: #8b0000;">SITE MAINTENANCE</h2>
                                    <hr style="border: solid #8b0000;border-width: 1px 0 0;" />
                                    <h4>This site is undergoing some routine maintenance.  We'll be back up and running soon.  Thank you for your patience.</h4>
                                </asp:View>
                            </asp:MultiView>



                        </div>

                    </div>
                </div>
                <br />
                <br />


            </div>
        </div>
    </div>
</form>
