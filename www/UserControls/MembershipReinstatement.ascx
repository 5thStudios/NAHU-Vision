<%@ Control Language="vb" AutoEventWireup="false" CodeFile="MembershipReinstatement.ascx.vb" EnableViewState="false" Inherits="MembershipReinstatement" %>

<div class="contentContainer">


    <script type="text/javascript" src="https://twitter.com/javascripts/blogger.js"></script>
    <script src="https://api.twitter.com/1/statuses/user_timeline/nahudotorg.json?callback=twitterCallback2&amp;count=2" type="text/javascript"></script>
    <h1>Membership Reinstatement</h1>

    <form method="post" action="reinstatement4.cfm">
        <h3>ALBIRMINGHAM AHU</h3>

        <p>

            <strong>ALBIRMINGHAM dues:</strong> $35.00<br>

            <strong>ALSW dues:</strong> $70.00<br>
            <strong>NAHU dues:</strong> $270.00<br>
            <strong>Total dues:</strong> $375.00<br>
        </p>

        <input type="hidden" name="chapter" value="ALBIRMINGHAM">
        <input type="hidden" name="chapterdues" value="$35.00">
        <input type="hidden" name="statedues" value="$70.00">
        <input type="hidden" name="nahudues" value="$270.00">
        <input type="hidden" name="totaldues" value="$375.00">


        <p>

            <strong>Member ID</strong>
            <input type="text" name="MemberID" size="10"><br>
            If you know your member ID, enter it here.


        </p>
        <p>
        </p>
        <table cellspacing="0" cellpadding="3" border="0">

            <tbody>
                <tr>
                    <td colspan="3" bgcolor="#cccccc"><strong>Personal Information</strong></td>
                </tr>

                <tr>
                    <td align="right">Prefix</td>
                    <td>&nbsp;</td>
                    <td>
                        <select name="prefix">
                            <option value="">None

                            </option>
                            <option value="Dr.">Dr. 
                            </option>
                            <option value="Hon.">Hon. 
                            </option>
                            <option value="Mr.">Mr. 
                            </option>
                            <option value="Ms.">Ms. 
                            </option>
                            <option value="Mrs.">Mrs. 
                            </option>
                            <option value="Rev.">Rev. </option>
                        </select>
                    </td>
                </tr>

                <tr>
                    <td align="right">First Name</td>
                    <td>&nbsp;</td>
                    <td>
                        <input type="text" name="first_name" size="20" maxlength="20"></td>
                </tr>

                <tr>
                    <td align="right">Middle Name</td>
                    <td>&nbsp;</td>
                    <td>
                        <input type="text" name="middle_name" size="20" maxlength="20"></td>
                </tr>

                <tr>
                    <td align="right">Last Name</td>
                    <td>&nbsp;</td>
                    <td>
                        <input type="text" name="last_name" size="30" maxlength="30"></td>
                </tr>

                <tr>
                    <td align="right">Suffix</td>
                    <td>&nbsp;</td>
                    <td>
                        <select name="suffix">
                            <option value="">None

                            </option>
                            <option value="II">II 
                            </option>
                            <option value="III">III 
                            </option>
                            <option value="IV">IV 
                            </option>
                            <option value="Jr.">Jr. 
                            </option>
                            <option value="Sr.">Sr. </option>
                        </select>
                    </td>
                </tr>

                <tr valign="top">
                    <td align="right">Designation(s)<br>
                        <font size="1">(separated by commas)</font></td>
                    <td>&nbsp;</td>

                    <td>
                        <input type="text" name="designation" size="20" maxlength="20"></td>
                </tr>

                <tr>
                    <td align="right">Informal Name</td>
                    <td>&nbsp;</td>
                    <td>
                        <input type="text" name="informal" size="20" maxlength="20"></td>
                </tr>

                <tr>
                    <td align="right">Website</td>
                    <td>&nbsp;</td>
                    <td>
                        <input type="text" name="website" size="40" maxlength="255"></td>
                </tr>

                <tr>
                    <td align="right">Company</td>
                    <td>&nbsp;</td>
                    <td>
                        <input type="text" name="company" size="40" maxlength="80"></td>
                </tr>


                <tr>
                    <td align="right" valign="top">Practice Areas</td>
                    <td>&nbsp;</td>
                    <td>

                        <input type="checkbox" name="LONG_TERM_CB" value="1">Long Term Care<br>

                        <input type="checkbox" name="INDIVIDUAL_CB" value="1">Individual Plans<br>

                        <input type="checkbox" name="TPA_CB" value="1">TPA<br>

                        <input type="checkbox" name="DISABILITY_CB" value="1">Disability<br>

                        <input type="checkbox" name="LARGE_GRP_CB" value="1">Large Group<br>

                        <input type="checkbox" name="SELF_INSURED_CB" value="1">Self Insured<br>

                        <input type="checkbox" name="MANAGED_CARE_CB" value="1">Managed Care<br>

                        <input type="checkbox" name="SMALL_GRP_CB" value="1">Small Group<br>

                        <input type="checkbox" name="MED_SUPP_CB" value="1">Medicare<br>

                        <input type="checkbox" name="RETIREMENT" value="1">Retirement<br>

                        <input type="checkbox" name="RX_PBM" value="1">RX-PBM<br>

                        <input type="checkbox" name="DENTAL" value="1">Dental<br>

                        <input type="checkbox" name="WORKSITE_MKTG" value="1">Worksite Mktg<br>
                    </td>
                </tr>


                <tr>
                    <td align="right">Referred by (If applicable)</td>
                    <td>&nbsp;</td>
                    <td>
                        <input type="text" name="Referred" size="20"></td>
                </tr>

                <tr>
                    <td colspan="3" bgcolor="#cccccc"><strong>Work Information</strong></td>
                </tr>

                <tr>
                    <td align="right">Address 1</td>
                    <td>&nbsp;</td>
                    <td>
                        <input type="text" name="address_1" size="40" maxlength="40"></td>
                </tr>

                <tr>
                    <td align="right">Address 2</td>
                    <td>&nbsp;</td>
                    <td>
                        <input type="text" name="address_2" size="40" maxlength="40"></td>
                </tr>

                <tr>
                    <td align="right">City</td>
                    <td>&nbsp;</td>
                    <td>
                        <input type="text" name="city" size="40" maxlength="40"></td>
                </tr>

                <tr>
                    <td align="right">State/Province</td>
                    <td>&nbsp;</td>
                    <td>
                        <select name="state_province">
                            <option value="">Choose a State/Province

                            </option>
                            <option value="AL">Alabama 
                            </option>
                            <option value="AK">Alaska 
                            </option>
                            <option value="AZ">Arizona 
                            </option>
                            <option value="AR">Arkansas 
                            </option>
                            <option value="CA">California 
                            </option>
                            <option value="CO">Colorado 
                            </option>
                            <option value="CT">Connecticut 
                            </option>
                            <option value="DE">Delaware 
                            </option>
                            <option value="DC">District of Columbia 
                            </option>
                            <option value="FL">Florida 
                            </option>
                            <option value="GA">Georgia 
                            </option>
                            <option value="HI">Hawaii 
                            </option>
                            <option value="ID">Idaho 
                            </option>
                            <option value="IL">Illinois 
                            </option>
                            <option value="IN">Indiana 
                            </option>
                            <option value="IA">Iowa 
                            </option>
                            <option value="KS">Kansas 
                            </option>
                            <option value="KY">Kentucky 
                            </option>
                            <option value="LA">Louisiana 
                            </option>
                            <option value="ME">Maine 
                            </option>
                            <option value="MD">Maryland 
                            </option>
                            <option value="MA">Massachusetts 
                            </option>
                            <option value="MI">Michigan 
                            </option>
                            <option value="MN">Minnesota 
                            </option>
                            <option value="MS">Mississippi 
                            </option>
                            <option value="MO">Missouri 
                            </option>
                            <option value="MT">Montana 
                            </option>
                            <option value="NE">Nebraska 
                            </option>
                            <option value="NV">Nevada 
                            </option>
                            <option value="NH">New Hampshire 
                            </option>
                            <option value="NJ">New Jersey 
                            </option>
                            <option value="NM">New Mexico 
                            </option>
                            <option value="NY">New York 
                            </option>
                            <option value="NC">North Carolina 
                            </option>
                            <option value="ND">North Dakota 
                            </option>
                            <option value="OH">Ohio 
                            </option>
                            <option value="OK">Oklahoma 
                            </option>
                            <option value="OR">Oregon 
                            </option>
                            <option value="PA">Pennsylvania 
                            </option>
                            <option value="RI">Rhode Island 
                            </option>
                            <option value="SC">South Carolina 
                            </option>
                            <option value="SD">South Dakota 
                            </option>
                            <option value="TN">Tennessee 
                            </option>
                            <option value="TX">Texas 
                            </option>
                            <option value="UT">Utah 
                            </option>
                            <option value="VT">Vermont 
                            </option>
                            <option value="VA">Virginia 
                            </option>
                            <option value="WA">Washington 
                            </option>
                            <option value="WV">West Virginia 
                            </option>
                            <option value="WI">Wisconsin 
                            </option>
                            <option value="WY">Wyoming </option>
                        </select>
                    </td>

                </tr>
                <tr>
                    <td align="right">Zip/Postal Code</td>
                    <td>&nbsp;</td>
                    <td>
                        <input type="text" name="zip" size="10" maxlength="10"></td>
                </tr>

                <tr>
                    <td align="right">Phone</td>
                    <td>&nbsp;</td>
                    <td>
                        <input type="text" name="phone" size="25" maxlength="25"></td>
                </tr>

                <tr>
                    <td align="right">Fax</td>
                    <td>&nbsp;</td>
                    <td>
                        <input type="text" name="fax" size="25" maxlength="25"></td>
                </tr>

                <tr valign="top">
                    <td align="right">E-mail</td>
                    <td>&nbsp;</td>
                    <td>
                        <input type="text" name="email" size="40" maxlength="100"><br>
                        <i>Please note: your membership confirmation will be sent to this address.
                            <br>
                            This email will serve as your login to Manage My Membership - access to NAHU's online database.</i></td>
                </tr>

                <tr>
                    <td colspan="3" bgcolor="#cccccc"><strong>Home Information</strong></td>
                </tr>

                <tr>
                    <td align="right">Address 1</td>
                    <td>&nbsp;</td>
                    <td>
                        <input type="text" name="ha1" size="40" maxlength="40"></td>
                </tr>

                <tr>
                    <td align="right">Address 2</td>
                    <td>&nbsp;</td>
                    <td>
                        <input type="text" name="ha2" size="40" maxlength="40"></td>
                </tr>

                <tr>
                    <td align="right">City</td>
                    <td>&nbsp;</td>
                    <td>
                        <input type="text" name="hc" size="40" maxlength="40"></td>
                </tr>

                <tr>
                    <td align="right">State/Province</td>
                    <td>&nbsp;</td>
                    <td>
                        <select name="hs">
                            <option value="">Choose a State/Province

                            </option>
                            <option value="AL">Alabama 
                            </option>
                            <option value="AK">Alaska 
                            </option>
                            <option value="AZ">Arizona 
                            </option>
                            <option value="AR">Arkansas 
                            </option>
                            <option value="CA">California 
                            </option>
                            <option value="CO">Colorado 
                            </option>
                            <option value="CT">Connecticut 
                            </option>
                            <option value="DE">Delaware 
                            </option>
                            <option value="DC">District of Columbia 
                            </option>
                            <option value="FL">Florida 
                            </option>
                            <option value="GA">Georgia 
                            </option>
                            <option value="HI">Hawaii 
                            </option>
                            <option value="ID">Idaho 
                            </option>
                            <option value="IL">Illinois 
                            </option>
                            <option value="IN">Indiana 
                            </option>
                            <option value="IA">Iowa 
                            </option>
                            <option value="KS">Kansas 
                            </option>
                            <option value="KY">Kentucky 
                            </option>
                            <option value="LA">Louisiana 
                            </option>
                            <option value="ME">Maine 
                            </option>
                            <option value="MD">Maryland 
                            </option>
                            <option value="MA">Massachusetts 
                            </option>
                            <option value="MI">Michigan 
                            </option>
                            <option value="MN">Minnesota 
                            </option>
                            <option value="MS">Mississippi 
                            </option>
                            <option value="MO">Missouri 
                            </option>
                            <option value="MT">Montana 
                            </option>
                            <option value="NE">Nebraska 
                            </option>
                            <option value="NV">Nevada 
                            </option>
                            <option value="NH">New Hampshire 
                            </option>
                            <option value="NJ">New Jersey 
                            </option>
                            <option value="NM">New Mexico 
                            </option>
                            <option value="NY">New York 
                            </option>
                            <option value="NC">North Carolina 
                            </option>
                            <option value="ND">North Dakota 
                            </option>
                            <option value="OH">Ohio 
                            </option>
                            <option value="OK">Oklahoma 
                            </option>
                            <option value="OR">Oregon 
                            </option>
                            <option value="PA">Pennsylvania 
                            </option>
                            <option value="RI">Rhode Island 
                            </option>
                            <option value="SC">South Carolina 
                            </option>
                            <option value="SD">South Dakota 
                            </option>
                            <option value="TN">Tennessee 
                            </option>
                            <option value="TX">Texas 
                            </option>
                            <option value="UT">Utah 
                            </option>
                            <option value="VT">Vermont 
                            </option>
                            <option value="VA">Virginia 
                            </option>
                            <option value="WA">Washington 
                            </option>
                            <option value="WV">West Virginia 
                            </option>
                            <option value="WI">Wisconsin 
                            </option>
                            <option value="WY">Wyoming </option>
                        </select>
                    </td>

                </tr>
                <tr>
                    <td align="right">Zip/Postal Code</td>
                    <td>&nbsp;</td>
                    <td>
                        <input type="text" name="hz" size="10" maxlength="10"></td>
                </tr>

                <tr>
                    <td align="right">Phone</td>
                    <td>&nbsp;</td>
                    <td>
                        <input type="text" name="hp" size="25" maxlength="25"></td>
                </tr>

                <tr>
                    <td align="right">Fax</td>
                    <td>&nbsp;</td>
                    <td>
                        <input type="text" name="hf" size="25" maxlength="25"></td>
                </tr>

                <tr>
                    <td align="right">E-mail</td>
                    <td>&nbsp;</td>
                    <td>
                        <input type="text" name="he" size="40" maxlength="100"></td>
                </tr>



                <tr>
                    <td colspan="3" bgcolor="#cccccc"><strong>Contribute to HUPAC Candidate Fund  (Optional)</strong> - <a href="/hupac" target="_blank">HUPAC Information</a></td>
                </tr>

                <tr>
                    <td colspan="3">These guidelines for contributions are merely suggestions. You may contribute more or less than the guidelines suggest, and the National Association of Health Underwriters (NAHU) will not favor nor disadvantage you by reason of the amount of your contribution or your decision not to contribute. A contribution to a Political Action Committee is not tax deductible. Federal law prohibits corporate or business donations to a federal PAC. Please make certain that your check or credit card is your personal account.<br>
                        <br>
                        <strong>If you are making a HUPAC donation, please make sure to fill out your Company, Work Address &amp; Occupation information on the form.</strong></td>
                </tr>

                <tr>
                    <td align="right">Occupation</td>
                    <td>&nbsp;</td>
                    <td>
                        <input type="text" name="occupation" size="40" maxlength="80">
                        <i>(required)</i></td>
                </tr>

                <tr valign="top">
                    <td align="right"></td>
                    <td>&nbsp;</td>
                    <td>
                        <table cellspacing="1" cellpadding="8" border="0">
                            <tbody>
                                <tr>
                                    <td colspan="3" bgcolor="#cccccc"><strong>Suggested Levels</strong></td>
                                </tr>
                                <tr bgcolor="#eeeeee">
                                    <td></td>
                                    <td><strong>One Time</strong></td>
                                    <td><strong>Monthly Draft</strong></td>
                                </tr>
                                <tr bgcolor="#eeeeee">
                                    <td><strong>Supporter</strong></td>
                                    <td>
                                        <input type="radio" name="type_amount" value="One Time $150">$150</td>
                                    <td>
                                        <input type="radio" name="type_amount" value="Monthly $12">$12</td>
                                </tr>
                                <tr bgcolor="#eeeeee">
                                    <td><strong>365 Club</strong></td>
                                    <td>
                                        <input type="radio" name="type_amount" value="One Time $365">$365</td>
                                    <td>
                                        <input type="radio" name="type_amount" value="Monthly $30">$30</td>
                                </tr>
                                <tr bgcolor="#eeeeee">
                                    <td><strong>Congressional</strong></td>
                                    <td>
                                        <input type="radio" name="type_amount" value="One Time $500">$500</td>
                                    <td>
                                        <input type="radio" name="type_amount" value="Monthly $42">$42</td>
                                </tr>
                                <tr bgcolor="#eeeeee">
                                    <td><strong>Senatorial</strong></td>
                                    <td>
                                        <input type="radio" name="type_amount" value="One Time $750">$750</td>
                                    <td>
                                        <input type="radio" name="type_amount" value="Monthly $63">$63</td>
                                </tr>
                                <tr bgcolor="#eeeeee">
                                    <td colspan="3"><strong>Capitol Club Levels</strong></td>
                                </tr>
                                <tr bgcolor="#eeeeee">
                                    <td><strong>Gold</strong></td>
                                    <td>
                                        <input type="radio" name="type_amount" value="One Time $1000">$1,000</td>
                                    <td>
                                        <input type="radio" name="type_amount" value="Monthly $85">$85</td>
                                </tr>
                                <tr bgcolor="#eeeeee">
                                    <td><strong>Diamond</strong></td>
                                    <td>
                                        <input type="radio" name="type_amount" value="One Time $2000">$2,000</td>
                                    <td>
                                        <input type="radio" name="type_amount" value="Monthly $170">$170</td>
                                </tr>
                                <tr bgcolor="#eeeeee">
                                    <td><strong>Double Diamond</strong></td>
                                    <td>
                                        <input type="radio" name="type_amount" value="One Time $3000">$3,000</td>
                                    <td>
                                        <input type="radio" name="type_amount" value="Monthly $250">$250</td>
                                </tr>
                                <tr bgcolor="#eeeeee">
                                    <td><strong>Triple Diamond</strong></td>
                                    <td>
                                        <input type="radio" name="type_amount" value="One Time $5000">$5,000</td>
                                    <td>
                                        <input type="radio" name="type_amount" value="Monthly $415">$415</td>
                                </tr>
                                <tr bgcolor="#eeeeee">
                                    <td><strong>Other</strong></td>
                                    <td>
                                        <input type="radio" name="type_amount" value="One Time Other">
                                        $<input type="text" name="one_time_other" size="5"></td>
                                    <td>
                                        <input type="radio" name="type_amount" value="Monthly Other">
                                        $<input type="text" name="monthly_other" size="5"></td>
                                </tr>
                            </tbody>
                        </table>
                    </td>
                </tr>

                <tr>
                    <td colspan="3" bgcolor="#cccccc"><strong>Membership Dues</strong></td>
                </tr>

                <tr>
                    <td align="right">Dues Amount</td>
                    <td>&nbsp;</td>
                    <td><strong>$375.00</strong><input type="hidden" name="Dues" size="20"></td>
                </tr>



                <tr>
                    <td colspan="3" bgcolor="#cccccc"><strong>Payment Information</strong></td>
                </tr>

                <tr>
                    <td align="right">Annual Payment by</td>
                    <td>&nbsp;</td>
                    <td>
                        <input type="radio" name="payment" value="Visa" checked="">Visa &nbsp;
                        <input type="radio" name="payment" value="MasterCard">MasterCard &nbsp;
                        <input type="radio" name="payment" value="AmEx">AmEx/Optima &nbsp;
                        <input type="radio" name="payment" value="Discover">Discover</td>
                </tr>



                <tr>
                    <td align="right">Card Number</td>
                    <td>&nbsp;</td>
                    <td>
                        <input type="text" name="CCNum" size="20"></td>
                </tr>

                <tr>
                    <td align="right">Exp. Date</td>
                    <td>&nbsp;</td>
                    <td>
                        <input type="text" name="CCDate" size="20"></td>
                </tr>



                <tr>
                    <td colspan="3" bgcolor="#cccccc">&nbsp;</td>
                </tr>

                <tr>
                    <td align="right"></td>
                    <td>&nbsp;</td>
                    <td>
                        <input type="submit" value="Submit Information"></td>
                </tr>

            </tbody>
        </table>


    </form>

</div>
