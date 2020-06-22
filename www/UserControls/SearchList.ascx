<%@ Control Language="vb" AutoEventWireup="false" CodeFile="SearchList.ascx.vb" Inherits="SearchList" %>


<form runat="server">
  
    <div class="searchPg row">
        <br class="hide-for-medium-down" />
        <br class="hide-for-small-down" />
        

        <div class="hide-for-medium large-12 columns">
            <br />
            <div class="pagination-page"></div>
            <br class="show-for-small-down" />
            <br class="show-for-small-down" />
        </div>
        


        <div class="medium-12 medium-push-12 large-8 large-push-4 columns">
            <div class="row" id="searchPnl">
                <div class="small-18 medium-18 large-20 columns searchFld" id="searchFld">
                    <input id="txtSearch" type="text" placeholder="Search..." required>
                </div>
                <div class="small-6 medium-6 large-4 columns searchBtn" id="searchBtn">
                    <img alt="" src="/Images/Common/icons/SearchIcon_Medium.png" style="">
                </div>
            </div>
            <br class="show-for-small-down" />
        </div>


        <div class="medium-12 medium-pull-12 large-4 large-pull-8 columns">
            <section id="ddlSection" class="hide">
                <select id="ddlShowType">
                    <option value="">All items</option>
                    <option value="standardContent">Standard Content</option>
                    <option value="lockedContent">Locked Content</option>
                    <option value="videoContent">Video Content</option>
                </select>
            </section>
            <br class="show-for-small-down" />
        </div>

        
        <div class="show-for-medium-only medium-24 columns">
            <br />
            <div class="pagination-page"></div>
            <br />
        </div>

    </div>

    <section class="listPnl">
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
    
    <div class="searchPg row">
        <div class="columns text-left">
            <br />
            <div class="pagination-page"></div>
            <br />
            <br />
        </div>
    </div>

</form>