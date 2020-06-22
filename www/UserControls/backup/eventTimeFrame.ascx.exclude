<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="eventTimeFrame.ascx.vb" Inherits="mvcvb.eventTimeFrame" %>


<asp:MultiView runat="server" ID="mvTimeframes">
    <asp:View runat="server" ID="vSingleDay">
        <div>
            <asp:Literal runat="server" ID="ltrlSingleDay_EventDate" />
        </div>
        <div>
            <asp:Literal runat="server" ID="ltrlSingleDay_Timeframe" />
        </div>
    </asp:View>

    <asp:View runat="server" ID="vDaily">
        <div>
            Every
            <asp:Literal runat="server" ID="ltrlDaily_Days" />
        </div>
        <div>
            Starting
            <asp:Literal runat="server" ID="ltrlDaily_StartDate" />
        </div>
        <div>
            Till
            <asp:Literal runat="server" ID="ltrlDaily_EndDate" />
        </div>
        <div>
            <asp:Literal runat="server" ID="ltrlDaily_Timeframe" />
        </div>
        <asp:Panel runat="server" ID="pnlDaily_Except" Visible="false">
            <br />
            Except on the following days:
            <blockquote>
                <asp:Literal runat="server" ID="ltrlDaily_Except" />
            </blockquote>
        </asp:Panel>
    </asp:View>

    <asp:View runat="server" ID="vWeekly">
        <div>
            Every
            <asp:Literal runat="server" ID="ltrlWeekly_Interval" />
            on
            <asp:Literal runat="server" ID="ltrlWeekly_Day" />
        </div>
        <div>
            Between
            <asp:Literal runat="server" ID="ltrlWeekly_StartDate" />
        </div>
        <div>
            and
            <asp:Literal runat="server" ID="ltrlWeekly_EndDate" />
        </div>
        <div>
            <asp:Literal runat="server" ID="ltrlWeekly_Timeframe" />
        </div>
        <asp:Panel runat="server" ID="pnlWeekly_Except" Visible="false">
            <br />
            Except on the following days:
            <blockquote>
                <asp:Literal runat="server" ID="ltrlWeekly_Except" />
            </blockquote>
        </asp:Panel>
    </asp:View>

    <asp:View runat="server" ID="vMonthly">
        <asp:MultiView runat="server" ID="mvMonthly">
            <asp:View runat="server" ID="vFromStartDate">
                <div>
                    Every
                    <asp:Literal runat="server" ID="ltrlMonthly_FromStartDate_Day" />
                    day of the month
                </div>
                <div>
                    Between
                    <asp:Literal runat="server" ID="ltrlMonthly_FromStartDate_StartDate" />
                </div>
                <div>
                    and
                    <asp:Literal runat="server" ID="ltrlMonthly_FromStartDate_EndDate" />
                </div>
                <div>
                    <asp:Literal runat="server" ID="ltrlMonthly_FromStartDate_Timeframe" />
                </div>

                <asp:Panel runat="server" ID="pnlMonthly_FromStartDate_MonthList" Visible="false">
                    <br />
                    During the following month(s):
                    <blockquote>
                        <asp:Literal runat="server" ID="ltrlMonthly_FromStartDate_MonthList" />
                    </blockquote>
                </asp:Panel>

                <asp:Panel runat="server" ID="pnlMonthly_FromStartDate_Except" Visible="false">
                    <br />
                    Except on the following day(s):
                    <blockquote>
                        <asp:Literal runat="server" ID="ltrlMonthly_FromStartDate_Except" />
                    </blockquote>
                </asp:Panel>
            </asp:View>
            <asp:View runat="server" ID="vFromWeek">
                <div>
                    Every
                    <asp:Literal runat="server" ID="ltrlMonthly_FromWeek_Interval" />
                    <asp:Literal runat="server" ID="ltrlMonthly_FromWeek_Day" />
                </div>
                <div>
                    Between
                    <asp:Literal runat="server" ID="ltrlMonthly_FromWeek_StartDate" />
                </div>
                <div>
                    and
                    <asp:Literal runat="server" ID="ltrlMonthly_FromWeek_EndDate" />
                </div>
                <div>
                    <asp:Literal runat="server" ID="ltrlMonthly_FromWeek_Timeframe" />
                </div>

                <asp:Panel runat="server" ID="pnlMonthly_FromWeek_MonthList" Visible="false">
                    <br />
                    During the following month(s):
                    <blockquote>
                        <asp:Literal runat="server" ID="ltrlMonthly_FromWeek_MonthList" />
                    </blockquote>
                </asp:Panel>

                <asp:Panel runat="server" ID="pnlMonthly_FromWeek_Except" Visible="false">
                    <br />
                    Except on the following days:
                    <blockquote>
                        <asp:Literal runat="server" ID="ltrlMonthly_FromWeek_Except" />
                    </blockquote>
                </asp:Panel>
            </asp:View>
        </asp:MultiView>
    </asp:View>

    <asp:View runat="server" ID="vYearly">
        <asp:MultiView runat="server" ID="mvYearly">
            <asp:View runat="server" ID="vFromYearlyStartDate">
                <%--<div>
                    <br />
                    <h6 class="text-center">[Recurring event- yearly: from date]</h6>
                    Every October 27th<br />
                    Starting October 27th, 2016<br />
                    Till November 1st, 2018<br />
                    10:00AM &ndash; 3:30PM
                    <br />
                    <br />
                    Except on the following days:
                    <blockquote>
                        November 1st, 2016
                        December 1st, 2016
                    </blockquote>
                </div>--%>
                <div>
                    Every
                    <asp:Literal runat="server" ID="ltrlYearly_FromStartDate_Month" />
                    <asp:Literal runat="server" ID="ltrlYearly_FromStartDate_Day" />
                </div>
                <div>
                    Starting
                    <asp:Literal runat="server" ID="ltrlYearly_FromStartDate_StartDate" />
                </div>
                <div>
                    Till
                    <asp:Literal runat="server" ID="ltrlYearly_FromStartDate_EndDate" />
                </div>
                <div>
                    <asp:Literal runat="server" ID="ltrlYearly_FromStartDate_Timeframe" />
                </div>

                <asp:Panel runat="server" ID="pnlYearly_FromStartDate_Except" Visible="false">
                    <br />
                    Except on the following day(s):
                    <blockquote>
                        <asp:Literal runat="server" ID="ltrlYearly_FromStartDate_Except" />
                    </blockquote>
                </asp:Panel>
            </asp:View>
            <asp:View runat="server" ID="vFromYearlyWeekMonth">
                <%--
                <div>
                    <br />
                    <h6 class="text-center">[Recurring event- yearly: from week/month]</h6>
                    Every third Sunday in January<br />
                    Starting October 27th, 2016<br />
                    Till November 1st, 2018<br />
                    10:00AM &ndash; 3:30PM
                </div>--%>

                <div>
                    Every
                    <asp:Literal runat="server" ID="ltrlYearly_FromWeek_Interval" />
                    <asp:Literal runat="server" ID="ltrlYearly_FromWeek_Day" />
                    in
                    <asp:Literal runat="server" ID="ltrlYearly_FromWeek_Month" />
                </div>
                <div>
                    Starting
                    <asp:Literal runat="server" ID="ltrlYearly_FromWeek_StartDate" />
                </div>
                <div>
                    Till
                    <asp:Literal runat="server" ID="ltrlYearly_FromWeek_EndDate" />
                </div>
                <div>
                    <asp:Literal runat="server" ID="ltrlYearly_FromWeek_Timeframe" />
                </div>

                <asp:Panel runat="server" ID="pnlYearly_FromWeek_Except" Visible="false">
                    <br />
                    Except on the following day(s):
                    <blockquote>
                        <asp:Literal runat="server" ID="ltrlYearly_FromWeek_Except" />
                    </blockquote>
                </asp:Panel>
            </asp:View>
        </asp:MultiView>
    </asp:View>
</asp:MultiView>