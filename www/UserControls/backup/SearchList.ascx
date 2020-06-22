﻿<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="SearchList.ascx.vb" Inherits="mvcvb.SearchList" %>


<form runat="server">
    <div class="searchPg row">
        <br class="hide-for-small-down" />
        <br class="hide-for-small-down" />
        <div class="medium-12 large-16 columns">
            &nbsp;
                <%--<br />
                <div class="pagination-page light-theme simple-pagination">
                    <ul>
                        <li class="disabled"><span class="current prev">Prev</span></li>
                        <li class="active"><span class="current">1</span></li>
                        <li class="disabled"><span class="current next">Next</span></li>
                    </ul>
                </div>
                <br class="show-for-small-down" />
                <br class="show-for-small-down" />--%>
        </div>
        <div class="medium-12 large-8 columns">
            <div class="row" id="searchPnl">
                <div class="small-18 medium-18 large-20 columns searchFld" id="searchFld">
                    <input id="txtSearch" type="text" placeholder="Search..." required>
                </div>
                <div class="small-6 medium-6 large-4 columns searchBtn" id="searchBtn">
                    <img alt="" src="/Images/Common/icons/SearchIcon_Medium.png" style="">
                </div>
            </div>
        </div>
    </div>

    <section class=" listPnl">
        <div class="row searchPg">
        <br />
            <div class="large-20 large-push-2 columns">
                <div class="row results"></div>
                <div class="row noResults">
                    <div class="columns">
                        <h3>No entries have been found matching your search criteria.</h3>
                        <br />
                        <br />
                    </div>
                </div>
            </div>
        </div>
    </section>
</form>