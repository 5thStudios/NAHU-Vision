<%@ Control Language="vb" AutoEventWireup="false" CodeFile="MonthlyMembershipAndRenewal.ascx.vb" EnableViewState="false" Inherits="MonthlyMembershipAndRenewal" %>


<div class="hide hiddenFields">
    <input type="hidden" name="chapter" value="ALBIRMINGHAM">
    <input type="hidden" name="chapterdues" value="$2.92">
    <input type="hidden" name="statedues" value="$5.83">
    <input type="hidden" name="nahudues" value="$22.50">
    <input type="hidden" name="totaldues" value="$31.25">
    <input type="hidden" name="Dues" size="20">
</div>


<div class="row">
    <div class="columns">
        <h1>Monthly Membership/Renewal</h1>
        <p>Now you can pay your dues monthly from your credit card.</p>
    </div>
</div>


<div class="row">
    <div class="large-12 columns">
        <h3>ALBIRMINGHAM AHU</h3>
        <p>
            <strong>ALBIRMINGHAM dues:</strong> $35.00 / 12 = $2.92<br>
            <strong>ALSW dues:</strong> $70.00 / 12 = $5.83<br>
            <strong>NAHU dues:</strong> $270.00 / 12 = $22.50<br>
            <strong>Total dues:</strong> $31.25 per month
        </p>
    </div>
    <div class="large-12 columns">
        <p>
            <strong>Member ID</strong>
            <input type="text" name="MemberID" size="10"><br>
            If you know your member ID, enter it here and you may leave all other fields blank unless you wish to make any changes. Please enter an e-mail address if you wish to receive a receipt via e-mail.
        </p>
    </div>
</div>


<fieldset>
    <legend>Personal Information</legend>

    <div class="row">
        <div class="large-3 columns">
            Prefix
            <select name="prefix">
                <option value="">None</option>
                <option value="Dr.">Dr.</option>
                <option value="Hon.">Hon.</option>
                <option value="Mr.">Mr.</option>
                <option value="Ms.">Ms.</option>
                <option value="Mrs.">Mrs.</option>
                <option value="Rev.">Rev.</option>
            </select>
        </div>
        <div class="large-6 columns">
            First Name
            <input type="text" name="first_name" size="20" maxlength="20">
        </div>
        <div class="large-6 columns">
            Middle Name
            <input type="text" name="middle_name" size="20" maxlength="20">
        </div>
        <div class="large-6 columns">
            Last Name
            <input type="text" name="last_name" size="30" maxlength="30">
        </div>
        <div class="large-3 columns">
            Suffix
            <select name="suffix">
                <option value="">None</option>
                <option value="II">II</option>
                <option value="III">III</option>
                <option value="IV">IV</option>
                <option value="Jr.">Jr.</option>
                <option value="Sr.">Sr.</option>
            </select>
        </div>
    </div>

    <hr />
    <br />

    <div class="row">
        <div class="large-6 columns">
            Designation(s) <font size="1">(separated by commas)</font>
            <input type="text" name="designation" size="20" maxlength="20">
        </div>
        <div class="large-6 columns">
            Informal Name
            <input type="text" name="informal" size="20" maxlength="20">
        </div>
        <div class="large-6 columns">
            Website
            <input type="text" name="website" size="40" maxlength="255">
        </div>
        <div class="large-6 columns">
            Company
            <input type="text" name="company" size="40" maxlength="80">
        </div>
    </div>

    <br />

    <div class="row">
        <div class="large-12 columns"> 
            Practice Areas<br>
            <div class="row">
                <div class="large-8 columns"> 
                    <input type="checkbox" name="LONG_TERM_CB" value="1">Long Term Care<br>
                    <input type="checkbox" name="INDIVIDUAL_CB" value="1">Individual Plans<br>
                    <input type="checkbox" name="TPA_CB" value="1">TPA<br>
                    <input type="checkbox" name="DISABILITY_CB" value="1">Disability<br>
                    <input type="checkbox" name="LARGE_GRP_CB" value="1">Large Group
                </div>
                <div class="large-8 columns"> 
                    <input type="checkbox" name="SELF_INSURED_CB" value="1">Self Insured<br>
                    <input type="checkbox" name="MANAGED_CARE_CB" value="1">Managed Care<br>
                    <input type="checkbox" name="SMALL_GRP_CB" value="1">Small Group<br>
                    <input type="checkbox" name="MED_SUPP_CB" value="1">Medicare<br>
                    <input type="checkbox" name="RETIREMENT" value="1">Retirement
                </div>
                <div class="large-8 columns">
                    <input type="checkbox" name="RX_PBM" value="1">RX-PBM<br>
                    <input type="checkbox" name="DENTAL" value="1">Dental<br>
                    <input type="checkbox" name="WORKSITE_MKTG" value="1">Worksite Mktg
                </div>
            </div>
        </div>
        <div class="large-6 columns">
            Name of Local HU Assoc.
            <input type="text" name="LocalHU" size="20">
        </div>
        <div class="large-6 columns">
            Referred by (If applicable)
            <input type="text" name="Referred" size="20">
            
        </div>
</div>
</fieldset>


<fieldset>
    <legend>Work Information</legend>

    <div class="row">
        <div class="large-6 columns">
            Address 1<input type="text" name="address_1" size="40" maxlength="40">
        </div>
        <div class="large-6 columns">
            Address 2<input type="text" name="address_2" size="40" maxlength="40">
        </div>
        <div class="large-4 columns">
            City<input type="text" name="city" size="40" maxlength="40">
        </div>
        <div class="large-4 columns">
            State/Province
            <select name="state_province">
                <option value="">Choose a State/Province</option>
                <option value="AL">Alabama</option>
                <option value="AK">Alaska</option>
                <option value="AZ">Arizona</option>
                <option value="AR">Arkansas</option>
                <option value="CA">California</option>
                <option value="CO">Colorado</option>
                <option value="CT">Connecticut</option>
                <option value="DE">Delaware</option>
                <option value="DC">District of Columbia</option>
                <option value="FL">Florida</option>
                <option value="GA">Georgia</option>
                <option value="HI">Hawaii</option>
                <option value="ID">Idaho</option>
                <option value="IL">Illinois</option>
                <option value="IN">Indiana</option>
                <option value="IA">Iowa</option>
                <option value="KS">Kansas</option>
                <option value="KY">Kentucky</option>
                <option value="LA">Louisiana</option>
                <option value="ME">Maine</option>
                <option value="MD">Maryland</option>
                <option value="MA">Massachusetts</option>
                <option value="MI">Michigan</option>
                <option value="MN">Minnesota</option>
                <option value="MS">Mississippi</option>
                <option value="MO">Missouri</option>
                <option value="MT">Montana</option>
                <option value="NE">Nebraska</option>
                <option value="NV">Nevada</option>
                <option value="NH">New Hampshire</option>
                <option value="NJ">New Jersey</option>
                <option value="NM">New Mexico</option>
                <option value="NY">New York</option>
                <option value="NC">North Carolina</option>
                <option value="ND">North Dakota</option>
                <option value="OH">Ohio</option>
                <option value="OK">Oklahoma</option>
                <option value="OR">Oregon</option>
                <option value="PA">Pennsylvania</option>
                <option value="RI">Rhode Island</option>
                <option value="SC">South Carolina</option>
                <option value="SD">South Dakota</option>
                <option value="TN">Tennessee</option>
                <option value="TX">Texas</option>
                <option value="UT">Utah</option>
                <option value="VT">Vermont</option>
                <option value="VA">Virginia</option>
                <option value="WA">Washington</option>
                <option value="WV">West Virginia</option>
                <option value="WI">Wisconsin</option>
                <option value="WY">Wyoming </option>
            </select>
        </div>
        <div class="large-4 columns">
            Zip/Postal Code<input type="text" name="zip" size="10" maxlength="10">
        </div>
    </div>
    
    <div class="row">
        <div class="large-6 columns">
            Phone<input type="text" name="phone" size="25" maxlength="25">
        </div>
        <div class="large-6 columns">
            Fax<input type="text" name="fax" size="25" maxlength="25">
        </div>
        <div class="large-12 columns">
            E-mail<input type="text" name="email" size="40" maxlength="100">
        </div>
    </div>
    
    <div class="row">
        <div class="large-24 columns">
            <i><strong>Please note: </strong>your membership confirmation will be sent to this email address.
                This email will serve as your login to Manage My Membership - access to NAHU's online database.</i>
        </div>
    </div>
</fieldset>


<fieldset>
    <legend>Home Information</legend>
    
    <div class="row">
        <div class="large-6 columns">
            Address 1<input type="text" name="address_1" size="40" maxlength="40">
        </div>
        <div class="large-6 columns">
            Address 2<input type="text" name="address_2" size="40" maxlength="40">
        </div>
        <div class="large-4 columns">
            City<input type="text" name="city" size="40" maxlength="40">
        </div>
        <div class="large-4 columns">
            State/Province
            <select name="state_province">
                <option value="">Choose a State/Province</option>
                <option value="AL">Alabama</option>
                <option value="AK">Alaska</option>
                <option value="AZ">Arizona</option>
                <option value="AR">Arkansas</option>
                <option value="CA">California</option>
                <option value="CO">Colorado</option>
                <option value="CT">Connecticut</option>
                <option value="DE">Delaware</option>
                <option value="DC">District of Columbia</option>
                <option value="FL">Florida</option>
                <option value="GA">Georgia</option>
                <option value="HI">Hawaii</option>
                <option value="ID">Idaho</option>
                <option value="IL">Illinois</option>
                <option value="IN">Indiana</option>
                <option value="IA">Iowa</option>
                <option value="KS">Kansas</option>
                <option value="KY">Kentucky</option>
                <option value="LA">Louisiana</option>
                <option value="ME">Maine</option>
                <option value="MD">Maryland</option>
                <option value="MA">Massachusetts</option>
                <option value="MI">Michigan</option>
                <option value="MN">Minnesota</option>
                <option value="MS">Mississippi</option>
                <option value="MO">Missouri</option>
                <option value="MT">Montana</option>
                <option value="NE">Nebraska</option>
                <option value="NV">Nevada</option>
                <option value="NH">New Hampshire</option>
                <option value="NJ">New Jersey</option>
                <option value="NM">New Mexico</option>
                <option value="NY">New York</option>
                <option value="NC">North Carolina</option>
                <option value="ND">North Dakota</option>
                <option value="OH">Ohio</option>
                <option value="OK">Oklahoma</option>
                <option value="OR">Oregon</option>
                <option value="PA">Pennsylvania</option>
                <option value="RI">Rhode Island</option>
                <option value="SC">South Carolina</option>
                <option value="SD">South Dakota</option>
                <option value="TN">Tennessee</option>
                <option value="TX">Texas</option>
                <option value="UT">Utah</option>
                <option value="VT">Vermont</option>
                <option value="VA">Virginia</option>
                <option value="WA">Washington</option>
                <option value="WV">West Virginia</option>
                <option value="WI">Wisconsin</option>
                <option value="WY">Wyoming </option>
            </select>
        </div>
        <div class="large-4 columns">
            Zip/Postal Code<input type="text" name="zip" size="10" maxlength="10">
        </div>
    </div>
    
    <div class="row">
        <div class="large-6 columns">
            Phone<input type="text" name="phone" size="25" maxlength="25">
        </div>
        <div class="large-6 columns">
            Fax<input type="text" name="fax" size="25" maxlength="25">
        </div>
        <div class="large-12 columns">
            E-mail<input type="text" name="email" size="40" maxlength="100">
        </div>
    </div>
    
</fieldset>


<fieldset>
    <legend>Contribute to HUPAC Candidate Fund (Optional) &ndash; <a href="https://www.nahu.org/hupac" target="_blank">HUPAC Information</a></legend>
    <div class="row">
        <div class="columns">            
            <p>
                These guidelines for contributions are merely suggestions. You may contribute more or less than the guidelines suggest, and the National Association of Health Underwriters (NAHU) will not favor nor disadvantage you by reason of the amount of your contribution or your decision not to contribute. A contribution to a Political Action Committee is not tax deductible. Federal law prohibits corporate or business donations to a federal PAC. Please make certain that your check or credit card is your personal account.
            </p>
            <p>
                <strong>
                    If you are making a HUPAC donation, please make sure to fill out your Company, Work Address &amp; Occupation information on the form.
                </strong>
            </p>
        </div>
    </div>
    
    <div class="row">
        <div class="large-6 columns end">

            <table cellspacing="4" cellpadding="8" border="0" class="responsive">
              <tbody>
                <tr>
                    <td colspan="3" bgcolor="#cccccc">
                        <strong>Suggested Levels</strong>&nbsp;&nbsp;&nbsp;
                        <div class="right">
                            <input type="radio" name="enrollmentType" value="monthly" checked aria-checked="true">Monthly &nbsp;&nbsp;&nbsp;
                            <input type="radio" name="enrollmentType" value="oneTime">One Time
                        </div>                
                    </td>
                </tr>
                <tr bgcolor="#eeeeee">
                    <td></td>
                    <td class="oneTime"><strong>One Time</strong></td>
                    <td class="monthly"><strong>Monthly Draft</strong></td>
                </tr>
                <tr bgcolor="#eeeeee">
                    <td><strong>Supporter</strong></td>
                    <td class="oneTime"><input type="radio" name="type_amount" value="One Time $150">$150</td>
                    <td class="monthly"><input type="radio" name="type_amount" value="Monthly $12">$12</td>
                </tr>
                <tr bgcolor="#eeeeee">
                    <td><strong>365 Club</strong></td>
                    <td class="oneTime"><input type="radio" name="type_amount" value="One Time $365">$365</td>
                    <td class="monthly"><input type="radio" name="type_amount" value="Monthly $30">$30</td>
                </tr>
                <tr bgcolor="#eeeeee">
                    <td><strong>Congressional</strong></td>
                    <td class="oneTime"><input type="radio" name="type_amount" value="One Time $500">$500</td>
                    <td class="monthly"><input type="radio" name="type_amount" value="Monthly $42">$42</td>
                </tr>
                <tr bgcolor="#eeeeee">
                    <td><strong>Senatorial</strong></td>
                    <td class="oneTime"><input type="radio" name="type_amount" value="One Time $750">$750</td>
                    <td class="monthly"><input type="radio" name="type_amount" value="Monthly $63">$63</td>
                </tr>
                <tr bgcolor="#eeeeee">
                    <td colspan="3"><strong>Capitol Club Levels</strong></td>
                </tr>
                <tr bgcolor="#eeeeee">
                    <td><strong>Gold</strong></td>
                    <td class="oneTime"><input type="radio" name="type_amount" value="One Time $1000">$1,000</td>
                    <td class="monthly"><input type="radio" name="type_amount" value="Monthly $85">$85</td>
                </tr>
                <tr bgcolor="#eeeeee">
                    <td><strong>Diamond</strong></td>
                    <td class="oneTime"><input type="radio" name="type_amount" value="One Time $2000">$2,000</td>
                    <td class="monthly"><input type="radio" name="type_amount" value="Monthly $170">$170</td>
                </tr>
                <tr bgcolor="#eeeeee">
                    <td><strong>Double Diamond</strong></td>
                    <td class="oneTime"><input type="radio" name="type_amount" value="One Time $3000">$3,000</td>
                    <td class="monthly"><input type="radio" name="type_amount" value="Monthly $250">$250</td>
                </tr>
                <tr bgcolor="#eeeeee">
                    <td><strong>Triple Diamond</strong></td>
                    <td class="oneTime"><input type="radio" name="type_amount" value="One Time $5000">$5,000</td>
                    <td class="monthly"><input type="radio" name="type_amount" value="Monthly $415">$415</td>
                </tr>
                <tr bgcolor="#eeeeee">
                    <td><strong>Other</strong></td>
                    <td class="oneTime">
                        <input type="radio" name="type_amount" value="One Time Other">
                        $<input type="text" name="one_time_other" size="5"></td>
                    <td class="monthly">
                        <input type="radio" name="type_amount" value="Monthly Other">
                        $<input type="text" name="monthly_other" size="5"></td>
                </tr>
                </tbody>
            </table>

        </div>
        <div class="large-6 columns end">
            Occupation <i>(required)</i>
            <input type="text" name="occupation" size="40" maxlength="80" required>
        </div>
    </div>
</fieldset>


<fieldset>
    <legend>Membership Dues</legend>
    <div class="row">
        <div class="large-6 columns end">
            Dues Amount <input type="text" disabled="disabled" value="$0.00" />
        </div>
    </div>
</fieldset>


<fieldset>
    <legend>Payment Information</legend>
    <div class="row">
        <div class="large-6 columns">

        </div>
        <div class="large-6 columns">

        </div>
        <div class="large-6 columns">

        </div>
        <div class="large-6 columns">

        </div>
    </div>
</fieldset>


<div class="row">
    <div class="large-6 columns">

    </div>
    <div class="large-6 columns">

    </div>
    <div class="large-6 columns">

    </div>
    <div class="large-6 columns">

    </div>
</div>





<!--

    <form runat="server">
<fieldset>
    <legend>Personal Information</legend>
    <div class="row">
        <div class="large-3 columns">
            Prefix
            <select name="prefix">
                <option value="">None</option>
                <option value="Dr.">Dr.</option>
                <option value="Hon.">Hon.</option>
                <option value="Mr.">Mr.</option>
                <option value="Ms.">Ms.</option>
                <option value="Mrs.">Mrs.</option>
                <option value="Rev.">Rev.</option>
            </select>
        </div>
        <div class="large-6 columns">
            First Name
            <input type="text" name="first_name" size="20" maxlength="20" runat="server" id="txbFirstName">
            

            <input id="Button1" type="button" value="button" runat="server" class="Button1" />
            <input id="Submit1" type="submit" value="submit" runat="server" class="Submit1" onsubmit="Submit1_ServerClick" />
            <input id="Reset1" type="reset" value="reset" runat="server" class="Reset1" />
            <input id="Hidden1" type="hidden" runat="server" value="testData" class="Hidden1" />
            <br />
            <input id="Submit2" type="submit" value="submit" class="Submit2" />
            <input id="Button2" type="button" value="button" class="Button2" />
            <input id="Reset2" type="reset" value="reset" class="Reset2" />

        </div>
        <div class="large-6 columns">
            Middle Name
            <input type="text" name="middle_name" size="20" maxlength="20">
        </div>
        <div class="large-6 columns">
            Last Name
            <input type="text" name="last_name" size="30" maxlength="30">
        </div>
        <div class="large-3 columns">
            Suffix
            <select name="suffix">
                <option value="">None</option>
                <option value="II">II</option>
                <option value="III">III</option>
                <option value="IV">IV</option>
                <option value="Jr.">Jr.</option>
                <option value="Sr.">Sr.</option>
            </select>
        </div>
    </div>

    <br />

    <div class="row">
        <div class="large-6 columns">
            Designation(s) <font size="1">(separated by commas)</font>
            <input type="text" name="designation" size="20" maxlength="20">
        </div>
        <div class="large-6 columns">
            Informal Name
            <input type="text" name="informal" size="20" maxlength="20">
        </div>
        <div class="large-6 columns">
            Website
            <input type="text" name="website" size="40" maxlength="255">
        </div>
        <div class="large-6 columns">
            Company
            <input type="text" name="company" size="40" maxlength="80">
        </div>
    </div>

    <br />

    <div class="row">
        <div class="large-12 columns"> 
            Practice Areas<br>
            <div class="row">
                <div class="large-8 columns"> 
                    <input type="checkbox" name="LONG_TERM_CB" value="1">Long Term Care<br>
                    <input type="checkbox" name="INDIVIDUAL_CB" value="1">Individual Plans<br>
                    <input type="checkbox" name="TPA_CB" value="1">TPA<br>
                    <input type="checkbox" name="DISABILITY_CB" value="1">Disability<br>
                    <input type="checkbox" name="LARGE_GRP_CB" value="1">Large Group
                </div>
                <div class="large-8 columns"> 
                    <input type="checkbox" name="SELF_INSURED_CB" value="1">Self Insured<br>
                    <input type="checkbox" name="MANAGED_CARE_CB" value="1">Managed Care<br>
                    <input type="checkbox" name="SMALL_GRP_CB" value="1">Small Group<br>
                    <input type="checkbox" name="MED_SUPP_CB" value="1">Medicare<br>
                    <input type="checkbox" name="RETIREMENT" value="1">Retirement
                </div>
                <div class="large-8 columns">
                    <input type="checkbox" name="RX_PBM" value="1">RX-PBM<br>
                    <input type="checkbox" name="DENTAL" value="1">Dental<br>
                    <input type="checkbox" name="WORKSITE_MKTG" value="1">Worksite Mktg
                </div>
            </div>
        </div>
        <div class="large-6 columns">
            Name of Local HU Assoc.
            <input type="text" name="LocalHU" size="20">
        </div>
        <div class="large-6 columns">
            Referred by (If applicable)
            <input type="text" name="Referred" size="20">
            
        </div>
</div>
</fieldset>

            </form>

-->
<div class="contentContainer hide">
    <form method="post" action="monthly4.cfm">
        <table cellspacing="0" cellpadding="3" border="0">
            <tbody>

                <tr>
                    <td colspan="3" bgcolor="#cccccc"><strong>Membership Dues</strong></td>
                </tr>

                <tr>
                    <td align="right">Dues Amount</td>
                    <td>&nbsp;</td>
                    <td><strong>$31.25</strong></td>
                </tr>



                <tr>
                    <td colspan="3" bgcolor="#cccccc"><strong>Payment Information</strong></td>
                </tr>

                <tr>
                    <td align="right">Monthly Payment by</td>
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
                    <td></td>
                    <td></td>
                    <td><strong>OR</strong></td>
                </tr>

                <tr>
                    <td align="right">Monthly Payment by</td>
                    <td>&nbsp;</td>
                    <td>
                        <input type="radio" name="payment" value="Bank Draft">Bank Draft</td>
                </tr>

                <tr>
                    <td align="right">Routing Number</td>
                    <td>&nbsp;</td>
                    <td>
                        <input type="text" name="RoutingNum" size="20"></td>
                </tr>

                <tr>
                    <td align="right">Account Number</td>
                    <td>&nbsp;</td>
                    <td>
                        <input type="text" name="AccountNum" size="20"></td>
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
