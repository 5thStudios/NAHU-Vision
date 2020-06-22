<%@ Control Language="vb" AutoEventWireup="false" CodeFile="CertificationPage.ascx.vb" EnableViewState="false" Inherits="CertificationPage" %>
<%@ Register Src="~/UserControls/AddThisTemplateA.ascx" TagPrefix="uc" TagName="AddThisTemplateA" %>



<form runat="server">

    <asp:Panel runat="server" ID="pnlEvent" CssClass="row CertificationPg">
        <br />
        <br />
        <div class="medium-8 large-6 columns">

            <asp:Image runat="server" ID="imgFeatured" />
            <br />
            <br />
            <h1>
                <asp:Literal runat="server" ID="ltrlTitle" /></h1>
            <br />

            <div class="courseTypes">
                <ul class="small-block-grid-2 toggle" id="courseType1">
                    <li>
                        <input id="rb1_Online" type="radio" value="online" name="courseType1" checked="checked" />
                        <label for="rb1_Online">Online</label>
                    </li>
                    <li>
                        <input id="rb1_Class" type="radio" value="classroom" name="courseType1" />
                        <label for="rb1_Class">Classroom</label>
                    </li>
                </ul>
                <br />
                <br />
            </div>

            <asp:ListView runat="server" ID="lvSponsors">
                <LayoutTemplate>
                    <h2>Sponsored by</h2>
                    <asp:PlaceHolder runat="server" ID="itemPlaceholder" />
                    <br />
                </LayoutTemplate>
                <ItemSeparatorTemplate />
                <ItemTemplate>
                    <div>
                        <a href='<%# Eval("url") %>' data-id='<%# Eval("id") %>' target="_blank">
                            <img alt='<%# Eval("name") %>' src='<%# Eval("logoUrl") %>' />
                        </a>
                    </div>
                    <br />
                </ItemTemplate>
                <EmptyDataTemplate />
            </asp:ListView>

            <uc:AddThisTemplateA runat="server" ID="AddThisTemplateA" />
            <br />
            <br />

            <asp:PlaceHolder runat="server" ID="phCourseInstructors">
                <h2>Course Instructors</h2>
                <div class="online instructors hide">
                    <asp:ListView runat="server" ID="lvInstructors_Online">
                        <LayoutTemplate>
                            <asp:PlaceHolder runat="server" ID="itemPlaceholder" />
                        </LayoutTemplate>
                        <ItemSeparatorTemplate>
                        </ItemSeparatorTemplate>
                        <ItemTemplate>
                            <a href='<%# Eval("trusteeUrl") %>'>
                                <div class="row" data-memberid='<%# Eval("memberId") %>'>
                                    <div class="small-6 columns">
                                        <img alt='<%# Eval("firstName") %> <%# Eval("lastName") %>' src='<%# Eval("photoUrl") %>' />
                                    </div>
                                    <div class="small-18 columns">
                                        <h5><%# Eval("firstName") %> <%# Eval("lastName") %></h5>
                                        <h6><%# Eval("title") %></h6>
                                    </div>
                                </div>
                            </a>
                        </ItemTemplate>
                        <EmptyDataTemplate>
                            <div>To be determined.</div>
                        </EmptyDataTemplate>
                    </asp:ListView>
                </div>


                <div class="classroom instructors hide">
                    <asp:ListView runat="server" ID="lvInstructors_Classroom">
                        <LayoutTemplate>
                            <asp:PlaceHolder runat="server" ID="itemPlaceholder" />
                        </LayoutTemplate>
                        <ItemSeparatorTemplate>
                        </ItemSeparatorTemplate>
                        <ItemTemplate>
                            <a href='<%# Eval("trusteeUrl") %>'>
                                <div class="row" data-memberid='<%# Eval("memberId") %>'>
                                    <div class="small-6 columns">
                                        <img alt='<%# Eval("firstName") %> <%# Eval("lastName") %>' src='<%# Eval("photoUrl") %>' />
                                    </div>
                                    <div class="small-18 columns">
                                        <h5><%# Eval("firstName") %> <%# Eval("lastName") %></h5>
                                        <h6><%# Eval("title") %></h6>
                                    </div>
                                </div>
                            </a>
                        </ItemTemplate>
                        <EmptyDataTemplate>
                            <div>To be determined.</div>
                        </EmptyDataTemplate>
                    </asp:ListView>
                </div>

                <br />
            </asp:PlaceHolder>





            <div class="row hide-for-small-down">
                <div class="columns">
                    <asp:HyperLink runat="server" ID="hlnkReturnToList" Text="Return to List" CssClass="button secondary" />
                </div>
            </div>



        </div>
        <div class="medium-16 large-18 columns ">
            <h2>About the Course</h2>
            <asp:Literal runat="server" ID="ltrlContent_Common" />

            <div class="online hide">
                <asp:Literal runat="server" ID="ltrlContent_Online" />
            </div>
            <div class="classroom hide">
                <asp:Literal runat="server" ID="ltrlContent_Classroom" />
            </div>
            <br />

            <h2>Course Highlights</h2>
            <div>
                <asp:Literal runat="server" ID="ltrlCourseHighlights" />
            </div>
            <br />

            <asp:PlaceHolder runat="server" ID="phCosts">
                <div class="online hide">
                    <h2>Online Cost</h2>
                    <asp:Literal runat="server" ID="ltrlCost_Online" />
                </div>
                <div class="classroom hide">
                    <h2>Classroom Cost</h2>
                    <asp:Literal runat="server" ID="ltrlCost_Classroom" />
                </div>
                <br />
            </asp:PlaceHolder>

            <asp:PlaceHolder runat="server" ID="phFormats">
                <div class="online hide">
                    <h2>Online Format</h2>
                    <asp:Literal runat="server" ID="ltrlFormat_Online" />
                </div>
                <div class="classroom hide">
                    <h2>Classroom Format</h2>
                    <asp:Literal runat="server" ID="ltrlFormat_Classroom" />
                </div>
            </asp:PlaceHolder>

            <br />

            <h2>Have Questions?</h2>
            <div>
                <asp:Literal runat="server" ID="ltrlHaveQuestions" />
            </div>
            <br />

            <div class="row courseTypes">
                <div class="medium-12 medium-push-6 large-8 large-push-0 columns end">
                    <ul class="small-block-grid-2 toggle" id="courseType2">
                        <li>
                            <input id="rb2_Online" type="radio" value="online" name="courseType2" checked="checked" />
                            <label for="rb1_Online">Online</label>
                        </li>
                        <li>
                            <input id="rb2_Class" type="radio" value="classroom" name="courseType2" />
                            <label for="rb1_Class">Classroom</label>
                        </li>
                    </ul>
                </div>
                <br />
                <br />
            </div>

            <div class="row">

                <%--<div class="small-text-center medium-text-left medium-6 large-4 columns">
                        <asp:HyperLink runat="server" ID="hlnkEnroll" Text="Enroll" CssClass="button" />
                        <br />
                        <br class="hide-for-medium-up" />
                        <br class="hide-for-medium-up" />
                    </div>--%>

                <div class="medium-16 medium-push-8 large-8 large-push-16 columns">
                    <div class="row">
                        <div class="small-12 columns right">
                            <asp:HyperLink runat="server" ID="hlnkNextCourse" CssClass="button secondary" Visible="false">
                                    Next Course <span class="arrow-right">&#9658;</span>
                            </asp:HyperLink>
                        </div>
                        <div class="small-12 columns right">
                            <asp:HyperLink runat="server" ID="hlnkPreviousCourse" CssClass="button secondary" Visible="false">
                                    <span class="arrow-left">&#9668;</span> Previous Course
                            </asp:HyperLink>
                        </div>
                    </div>
                </div>


            </div>

            <div class="row show-for-small-down">
                <div class="columns">
                    <br />
                    <asp:HyperLink runat="server" ID="hlnkReturnToList_Mbl" Text="Return to List" CssClass="button secondary" />
                    <br />
                    <br />
                </div>
            </div>


        </div>

        <div class="hide hiddenFields">
            <input type="hidden" runat="server" id="hfldOnline" class="hfldOnline" value="False" />
            <input type="hidden" runat="server" id="hfldClassroom" class="hfldClassroom" value="False" />
        </div>
    </asp:Panel>

    <%--[][]
    <asp:GridView runat="server" ID="gv" />
    <asp:GridView runat="server" ID="gv2" />
    <asp:GridView runat="server" ID="gv3" />
    [][]--%>
</form>
