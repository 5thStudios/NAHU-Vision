<%@ Control Language="VB" AutoEventWireup="false" CodeFile="AdminFund_OneTimePayment.ascx.vb" Inherits="UserControls_AdminFund_OneTimePayment" %>



<div class="wrapper">
	<div class="container">

		<div class="header">
			<div class="">
				<h1 class="merchant" style="padding-bottom: 0;">${DBA}</h1>
                <h4>One-Time Donation</h4>
                <p>Please enter all fields below to make a one time or monthly contribution via credit card or bank draft.</p>
                <p>The administrative fund accepts businesses and individual contributions. State and local chapters can also contribute. Money in this account goes to the operating costs of HUPAC so that the candidate fund can be reserved solely for political contributions. Unlike the candidate account, there are <strong>no contribution limits</strong> on the administrative account.</p>
			</div>
		</div>

        <form name="mainform" class="mainform" action="https://secure.bluepay.com/interfaces/bp10emu" method="POST">

            <input type="hidden" name="MERCHANT" value="${SHPF_ACCOUNT_ID}">
            <input type="hidden" name="DBA" value="${DBA}">
            <input type="hidden" name="TRANSACTION_TYPE" value="${TRANSACTION_TYPE}">
            <input type="hidden" name="TAMPER_PROOF_SEAL" value="${TAMPER_PROOF_SEAL}">
            <input type="hidden" name="APPROVED_URL" value="${REDIRECT_URL}">
            <input type="hidden" name="DECLINED_URL" value="${REDIRECT_URL}">
            <input type="hidden" name="MISSING_URL" value="${REDIRECT_URL}">
            <input type="hidden" name="CUSTOM_ID" value="${CUSTOM_ID}">
            <input type="hidden" name="CUSTOM_ID2" value="${CUSTOM_ID2}">
            <input type="hidden" name="ORDER_ID" value="${ORDER_ID}">
            <input type="hidden" name="INVOICE_ID" value="${INVOICE_ID}">
            <input type="hidden" name="COMMENT" value="${COMMENT}">
            <input type="hidden" name="MODE" value="${MODE}">
            <input type="hidden" name="REB_CYCLES" value="${REB_CYCLES}">
            <input type="hidden" name="REB_AMOUNT" value="${REB_AMOUNT}">
            <input type="hidden" name="REB_FIRST_DATE" value="${REB_FIRST_DATE}">
            <input type="hidden" name="TPS_DEF" value="${TPS_DEF}">
            <input type="hidden" name="MERCHDATA_shpf-form-id" value="mobileradio01RD">
            <input type="hidden" name="RESPONSEVERSION" value="${RESPONSEVERSION}">
            <input type="hidden" name="RESPONSETYPE" value="${RESPONSETYPE}">
            <input type="hidden" name="RESPONSE_TITLE" value="${RESPONSE_TITLE}">
            <input type="hidden" name="RESPONSE_BODY" value="${RESPONSE_BODY}">
            <input type="hidden" name="BP_STAMP_DEF" value="${BP_STAMP_DEF}">




            <fieldset>
                <legend class="block">Your Information</legend>
                <ul class="fields">
                    <li>
                        <div class="block-01">
                            <label for="NAME1">First Name</label>
                        </div>
                        <div class="block-02">
                            <input type="text" name="NAME1" id="NAME1" class="required" value="${NAME1}">
                        </div>
                    </li>
                    <li>
                        <div class="block-01">
                            <label for="MERCHDATA_MiddleName">Middle Name</label>
                        </div>
                        <div class="block-02">
                            <input type="text" name="MERCHDATA_MiddleName" id="MERCHDATA_MiddleName" class="required" value="${MERCHDATA_MiddleName}">
                        </div>
                    </li>
                    <li>
                        <div class="block-01">
                            <label for="NAME2">Last Name</label>
                        </div>
                        <div class="block-02">
                            <input type="text" name="NAME2" id="NAME2" class="required" value="${NAME2}">
                        </div>
                    </li>
                    <li>
                        <div class="block-01">
                            <label for="MERCHDATA_Occupation">Occupation</label>
                        </div>
                        <div class="block-02">
                            <input type="text" name="MERCHDATA_Occupation" id="MERCHDATA_Occupation" class="required" value="${MERCHDATA_Occupation}">
                        </div>
                    </li>
                    <li>
                        <div class="block-01">
                            <label for="COMPANY_NAME">Employer</label>
                        </div>
                        <div class="block-02">
                            <input type="text" name="COMPANY_NAME" id="COMPANY_NAME" class="required" value="${COMPANY_NAME}">
                        </div>
                    </li>
                    <li>
                        <div class="block-01">
                            <label for="ADDR1">Address 1</label>
                        </div>
                        <div class="block-02">
                            <input type="text" name="ADDR1" id="ADDR1" class="required" value="${ADDR1}">
                        </div>
                    </li>
                    <li>
                        <div class="block-01">
                            <label for="ADDR2">Address 2</label>
                        </div>
                        <div class="block-02">
                            <input type="text" name="ADDR2" id="ADDR2" value="${ADDR2}">
                        </div>
                    </li>
                    <li>
                        <div class="block-01">
                            <label for="CITY">City</label>
                        </div>
                        <div class="block-02">
                            <input type="text" name="CITY" id="CITY" value="${CITY}">
                        </div>
                    </li>
                    <li>
                        <div class="block-01">
                            <label for="STATE">Province/State</label>
                        </div>
                        <div class="block-02">
                            <select name="STATE" id="STATE">
                                <option value="">Choose a State/Province
                                </option><option value="AL">Alabama 
                                </option><option value="AK">Alaska 
                                </option><option value="AZ">Arizona 
                                </option><option value="AR">Arkansas 
                                </option><option value="CA">California 
                                </option><option value="CO">Colorado 
                                </option><option value="CT">Connecticut 
                                </option><option value="DE">Delaware 
                                </option><option value="DC">District of Columbia 
                                </option><option value="FL">Florida 
                                </option><option value="GA">Georgia 
                                </option><option value="HI">Hawaii 
                                </option><option value="ID">Idaho 
                                </option><option value="IL">Illinois 
                                </option><option value="IN">Indiana 
                                </option><option value="IA">Iowa 
                                </option><option value="KS">Kansas 
                                </option><option value="KY">Kentucky 
                                </option><option value="LA">Louisiana 
                                </option><option value="ME">Maine 
                                </option><option value="MD">Maryland 
                                </option><option value="MA">Massachusetts 
                                </option><option value="MI">Michigan 
                                </option><option value="MN">Minnesota 
                                </option><option value="MS">Mississippi 
                                </option><option value="MO">Missouri 
                                </option><option value="MT">Montana 
                                </option><option value="NE">Nebraska 
                                </option><option value="NV">Nevada 
                                </option><option value="NH">New Hampshire 
                                </option><option value="NJ">New Jersey 
                                </option><option value="NM">New Mexico 
                                </option><option value="NY">New York 
                                </option><option value="NC">North Carolina 
                                </option><option value="ND">North Dakota 
                                </option><option value="OH">Ohio 
                                </option><option value="OK">Oklahoma 
                                </option><option value="OR">Oregon 
                                </option><option value="PA">Pennsylvania 
                                </option><option value="RI">Rhode Island 
                                </option><option value="SC">South Carolina 
                                </option><option value="SD">South Dakota 
                                </option><option value="TN">Tennessee 
                                </option><option value="TX">Texas 
                                </option><option value="UT">Utah 
                                </option><option value="VT">Vermont 
                                </option><option value="VA">Virginia 
                                </option><option value="WA">Washington 
                                </option><option value="WV">West Virginia 
                                </option><option value="WI">Wisconsin 
                                </option><option value="WY">Wyoming </option>
                            </select>
                        </div>
                    </li>
                    <li>
                        <div class="block-01">
                            <label for="ZIPCODE">Postal Code</label>
                        </div>
                        <div class="block-02">
                            <input type="text" name="ZIPCODE" id="ZIPCODE" class="required" value="${ZIPCODE}" size="7">
                        </div>
                    </li>
                    <li>
                        <div class="block-01">
                            <label for="PHONE">Phone</label>
                        </div>
                        <div class="block-02">
                            <input type="text" name="PHONE" id="PHONE" value="${PHONE}" size="20">
                        </div>
                    </li>
                    <li>
                        <div class="block-01">
                            <label for="EMAIL">Email</label>
                        </div>
                        <div class="block-02">
                            <input type="text" name="EMAIL" id="EMAIL" class="email" value="${EMAIL}">
                        </div>
                    </li>
                </ul>
            </fieldset>

                    
            <fieldset>
                <legend class="block">Suggested Contribution Levels for Candidate Fund<br />One-Time Donation</legend>
                <ul class="fields">
                    <li>
                        <div class="block-01">
                            <!--<label for="AMOUNT">Amount</label>-->&nbsp;
                        </div>
                        <div class="block-02">
                            <ul class="radio--list" data-radio data-toggle-elements>
                                <li>
                                    <input type="radio" name="AMOUNT" id="donation_radio_1" value="150.00" checked="" data-radio-checked data-toggle-el>
                                    <label for="donation_radio_1">$150  &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[Supporter]</label>
                                </li>
                                <li>
                                    <input type="radio" name="AMOUNT" id="donation_radio_2" value="365.00" data-toggle-el>
                                    <label for="donation_radio_2">$365  &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[365 Club]</label>
                                </li>
                                <li>
                                    <input type="radio" name="AMOUNT" id="donation_radio_3" value="500.00" data-toggle-el>
                                    <label for="donation_radio_3">$500  &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[Congressional]</label>
                                </li>
                                <li>
                                    <input type="radio" name="AMOUNT" id="donation_radio_4" value="750.00" data-toggle-el>
                                    <label for="donation_radio_4">$750  &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[Senatorial]</label>
                                </li>

                                <li><label><strong><br />Capitol Club Levels</strong></label></li>

                                <li>
                                    <input type="radio" name="AMOUNT" id="donation_radio_5" value="1000.00" data-toggle-el>
                                    <label for="donation_radio_5">$1000  &nbsp;&nbsp;&nbsp;[Gold]</label>
                                </li>
                                <li>
                                    <input type="radio" name="AMOUNT" id="donation_radio_6" value="2000.00" data-toggle-el>
                                    <label for="donation_radio_6">$2000  &nbsp;&nbsp;&nbsp;[Diamond]</label>
                                </li>
                                <li>
                                    <input type="radio" name="AMOUNT" id="donation_radio_7" value="4000.00" data-toggle-el>
                                    <label for="donation_radio_7">$4000  &nbsp;&nbsp;&nbsp;[Double Diamond]</label>
                                </li>
                                <li>
                                    <input type="radio" name="AMOUNT" id="donation_radio_8" value="5000.00" data-toggle-el>
                                    <label for="donation_radio_8">$5000  &nbsp;&nbsp;&nbsp;[Triple Diamond]</label>
                                </li>
                                <li>
                                    <input type="radio" name="AMOUNT" id="donation_radio_9" value="" data-sync-values-el-amount data-toggle-el="amount">
                                    <label for="donation_radio_9">Other</label>
                                </li>
                                <li>
                                    <input type="text" class="js-hidden" value="" data-sync-values-with="amount" data-toggle="amount">
                                </li>
                            </ul>
                        </div>
                    </li>
                </ul>
                <h5 style="font-weight: 400;margin-top: 0;">**These guidelines for contributions are merely suggestions. You may contribute more or less than the guidelines suggest, and the National Association of Health Underwriters (NAHU) will not favor nor disadvantage you by reason of the amount of your contribution or your decision not to contribute.</h5>
            </fieldset>


            <fieldset>
                <legend class="block">Payment Information</legend>
                <ul class="fields">
                    <li>
                        <div class="block-01-push">
                            <div class="icons ${CARD_TYPES}" data-credit-card-type></div>
                        </div>
                    </li>
                    <li>
                        <div class="block-01">
                            <label for="CC_NUM">Credit Card Number</label>
                        </div>
                        <div class="block-02">
                            <input type="text" name="CC_NUM" id="CC_NUM" class="required creditcard" value="${CC_NUM}" autocomplete="off" data-credit-card-number>
                        </div>
                    </li>
                    <li>
                        <div class="block-01">
                            <label for="CVCCVV2">CVV2</label>
                        </div>
                        <div class="block-02">
                            <input type="text" name="CVCCVV2" id="CVCCVV2" value="${CVCCVV2}" size="4" autocomplete="off" maxlength="4">
                            <a href="#" class="tooltip icons help" title="3 digit security code on back of Visa, Mastercard &amp; Discover. 4 digit code on front of Amex."></a>
                        </div>
                    </li>
                    <li>
                        <div class="block-01">
                            <label for="CC_EXPIRES">Expiration Date</label>
                        </div>
                        <div class="block-02">
                            <div class="date-month">
                                <select name="CC_EXPIRES_MONTH" id="CC_EXPIRES" class="required">
                                    <option value="" selected>Month</option>
                                    <option value="01">01</option>
                                    <option value="02">02</option>
                                    <option value="03">03</option>
                                    <option value="04">04</option>
                                    <option value="05">05</option>
                                    <option value="06">06</option>
                                    <option value="07">07</option>
                                    <option value="08">08</option>
                                    <option value="09">09</option>
                                    <option value="10">10</option>
                                    <option value="11">11</option>
                                    <option value="12">12</option>
                                </select>
                                <div class="select-error-01"></div>
                            </div>
                            <div class="date-year">
                                <select name="CC_EXPIRES_YEAR" class="required">
                                    <option value="" selected>Year</option>
                                    ${SHPF_YEARBLOCK}
                                </select>
                                <div class="select-error-02"></div>
                            </div>
                        </div>
                    </li>
                    <li>
                        <div class="block-01-push">
                            <input type="submit" class="button--primary" value="Make Donation">
                            <input type="reset" value="Reset" class="button">
                        </div>
                    </li>
                </ul>
            </fieldset>

        </form>
	</div>
</div>