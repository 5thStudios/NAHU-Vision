//=======================================
// Obtain list from webservice
//=======================================
$(document).ready(function () {
    try {

        function jsSearchSite() {
            //=====================================================
            //      PROPERTIES
            //=====================================================
            var searchBtn = $('#searchBtn');
            var txtSearch = $('#txtSearch');
            var blogTxtSearch = $('#blogTxtSearch');
            var listPnl = $('.listPnl .results');
            var noResults = $('.listPnl .noResults');
            var ddlShowType = $('#ddlShowType');
            var ddlSection = $('#ddlSection');



            //=====================================================
            //      ONLOAD
            //=====================================================
            //Obtain search criteria from session
            if (localStorage.getItem("searchFor") !== null) {
                //Obtain search text and clear session
                var searchFor = localStorage.searchFor;
                localStorage.removeItem('searchFor');
                //Add value to search textbox.
                txtSearch.val(searchFor);
                //Generate list
                generateList(searchFor);
                //HOW TO USE LOCALSTORAGE:  http://www.mysamplecode.com/2012/04/html5-local-storage-session-tutorial.html
            }
            else if (is.not.null($.urlParam('search'))) {
                //save search value in session
                localStorage.searchFor = $.urlParam('search');

                //Redirect to page without parameters
                window.location.href = window.location.href.split('?')[0];
            }
            else if ($.trim(txtSearch.val())) {
                //Generate list and display on screen.
                generateList(txtSearch.val());
            }
            else if ($.trim(blogTxtSearch.val())) {
                //Generate list and display on screen.
                generateList(blogTxtSearch.val());
            }



            //=====================================================
            //      HANDLES
            //=====================================================
            searchBtn.on("click", function () { //If search button is click, generate list
                //Validate if list can be generated
                if (!$.trim(txtSearch.val())) {
                    //Show message saying no search value was provided.
                    noResults.show();
                    listPnl.hide();
                    //clear text box
                    txtSearch.val('');
                }
                else {
                    //Generate list and display on screen.
                    generateList(txtSearch.val());
                }
            });
            txtSearch.keypress(function (event) {
                //If input is focused and enter clicked:
                if (event.keyCode == 13) {
                    event.preventDefault(); //prevent default submit funcitonality
                    searchBtn.click(); //click the search button
                }
            });
            blogTxtSearch.keypress(function (event) {
                //If input is focused and enter clicked:
                if (event.keyCode == 13) {
                    event.preventDefault(); //prevent default submit funcitonality
                    searchBtn.click(); //click the search button
                }
            });
            ddlShowType.on('change', function () {
                showItemsOfType(this.value);
            });



            //=====================================================
            //      METHODS
            //=====================================================
            function generateList(searchFor) {
                //Hide message for invalid search
                noResults.hide();
                listPnl.show();

                //Create parameters
                var urlPath = window.location.protocol + '//' + window.location.host;
                var searchUrl = urlPath + '/Services/SiteSearch.ashx';
                var parameters = CreateParameters();

                //Call AJAX service
                var searchResponse = CallService_POST(parameters);
                var promise = $.when(searchResponse);
                promise.done(function () { manageSearchResponse(searchResponse) });
                promise.fail(function () { console.log('failed'); });

                //METHODS
                function CreateParameters() {
                    //Instantiate an array of parameters to pass to handler
                    var myData = {};
                    myData.searchFor = searchFor;
                    //Set array as json for use in ajax call
                    return JSON.stringify(myData);
                }
                function CallService_POST(data) {
                    try {
                        return $.ajax({
                            url: searchUrl, // Location of the service
                            type: "POST", //GET or POST or PUT or DELETE verb
                            data: data, //Data sent to server
                            dataType: "json", //Expected data format from server
                            contentType: "application/json; charset=utf-8", // content type sent to server
                            processdata: true //True or False
                        });
                    }
                    catch (err) {
                        console.log('Error: ' + err);
                        if (err.message != null) {
                            console.log('Error: ' + err.message);
                        }
                    }
                }
                function manageSearchResponse(searchResults) {
                    //Instantiate variables
                    var jsonResults = searchResults.responseJSON;

                    //Clear list
                    listPnl.empty();

                    console.log(jsonResults);
                    console.log('searchResults count: ' + jsonResults.length);

                    if (jsonResults.length == 0) {
                        //Show message saying no valid search value was provided.
                        noResults.show();
                        listPnl.hide();
                        ddlSection.hide();
                        console.log('ddlSection hide');
                    }
                    else {
                        //Build list
                        $.each(jsonResults, function (i, obj) {
                            //Create new control
                            var newControl = '\
                            <div class="columns viewItem {TYPE}" data-nodeid="{ID}">\
                                <a href="{URL}" target="{TARGET}">\
                                    <h2 class="title">{TITLE}\
                                        {ISLOCKED}\
                                    </h2>\
                                    <h5>{BREADCRUMB}</h5>\
                                </a>\
                                <hr />\
                            </div>\
                        '
                            var lockedImg = '<img class="lockIcon" src="/Images/Common/icons/LockIcon.png">'
                            var videoImg = '<img class="lockIcon" src="/Images/Common/icons/playBtn4.png">'


                            //Add data to new control
                            newControl = newControl.replace("{ID}", obj.id);
                            newControl = newControl.replace("{TITLE}", obj.title);
                            newControl = newControl.replace("{URL}", obj.url);
                            newControl = newControl.replace("{BREADCRUMB}", obj.breadcrumb);

                            if (obj.isLocked === true) {
                                newControl = newControl.replace("{ISLOCKED}", lockedImg);
                                newControl = newControl.replace("{TARGET}", "_self");
                                newControl = newControl.replace("{TYPE}", "lockedContent");
                            }
                            else if (obj.isVideo === true) {
                                newControl = newControl.replace("{ISLOCKED}", videoImg);
                                newControl = newControl.replace("{TARGET}", "_blank");
                                newControl = newControl.replace("{TYPE}", "videoContent");
                            }
                            else {
                                newControl = newControl.replace("{ISLOCKED}", "");
                                newControl = newControl.replace("{TARGET}", "_self");
                                newControl = newControl.replace("{TYPE}", "standardContent");
                            }

                            //Add new control to panel
                            listPnl.append(newControl);
                        });
                        ddlSection.show();
                        console.log('ddlSection show');
                    }

                    refreshPagination();
                }


            };
            function showItemsOfType(showBy) {
                $('.viewItem').hide();

                switch(showBy) {
                    case "standardContent":
                        $('.viewItem.' + showBy).show();
                        break;
                    case "lockedContent":
                        $('.viewItem.' + showBy).show();
                        break;
                    case "videoContent":
                        $('.viewItem.' + showBy).show();
                        break;
                    default:
                        $('.viewItem').show();
                }

                refreshPagination();
                console.log('Type: ' + showBy);
                //<option value="standardContent">Standard Content</option>
                //<option value="lockedContent">Locked Content</option>
                //<option value="videoContent">Video Content</option>
            }
            function refreshPagination() {
                $(".pagination-page").pagination("destroy");

                // Instantiate variables
                //var items = $(".viewItem");
                var items = $(".viewItem:visible");
                var numItems = items.length;
                var paginationPnl = $('.pagination-page');
                var perPage = 10;

                console.log('numItems: ' + numItems);
                noResults.hide();

                if (numItems > perPage) {
                    //Show pagination panel
                    paginationPnl.show();

                    // Only show the first # (or first `per_page`) items initially.
                    items.slice(perPage).hide();

                    // Now setup the pagination using the `.pagination-page` div.
                    $(".pagination-page").pagination({
                        items: numItems,
                        itemsOnPage: perPage,
                        cssStyle: "light-theme",
                        // This is the actual page changing functionality.
                        onPageClick: function (pageNumber) {
                            // We need to show and hide `tr`s appropriately.
                            var showFrom = perPage * (pageNumber - 1);
                            var showTo = showFrom + perPage;

                            //console.log('onPageClick: ' + pageNumber);

                            // We'll first hide everything...
                            items.hide()
                                // ... and then only show the appropriate rows.
                                .slice(showFrom, showTo).show();
                        }
                    });

                    // EDIT: Let's cover URL fragments (i.e. #page-3 in the URL).
                    // More thoroughly explained (including the regular expression) in:
                    // https://github.com/bilalakil/bin/tree/master/simplepagination/page-fragment/index.html

                    // We'll create a function to check the URL fragment
                    // and trigger a change of page accordingly.
                    function checkFragment() {
                        // If there's no hash, treat it like page 1.
                        var hash = window.location.hash || "#page-1";

                        // We'll use a regular expression to check the hash string.
                        hash = hash.match(/^#page-(\d+)$/);

                        if (hash) {
                            // The `selectPage` function is described in the documentation.
                            // We've captured the page number in a regex group: `(\d+)`.
                            $(".pagination-page").pagination("selectPage", parseInt(hash[1]));
                        }
                    };

                    // We'll call this function whenever back/forward is pressed...
                    $(window).bind("popstate", checkFragment);

                    // ... and we'll also call it when the page has loaded
                    // (which is right now).
                    checkFragment();


                    //Add 'end' class to final gridview item.
                    var lastGridviewItem = $('div.gridViewItem:last-child');
                    lastGridviewItem.addClass("end");

                    //
                    $(".pagination-page").pagination('selectPage', 1);
                }
                else if (numItems > 0) {
                    //Hide pagination panel
                    paginationPnl.hide();
                }
                else {
                    //Hide pagination panel and show msg
                    paginationPnl.hide();
                    noResults.show();
                }
            };
            

            //// Now setup the pagination using the `.pagination-page` div.
            //var items = $(".viewItem"); //var items = $(".thisBlog_posts_container .blogEntry");
            //var numItems = items.length;
            //var perPage = 10;
            //$(".pagination-page").pagination({
            //    items: numItems,
            //    itemsOnPage: perPage,
            //    cssStyle: "light-theme",

            //    // This is the actual page changing functionality.
            //    onPageClick: function (pageNumber) {
            //        // We need to show and hide `tr`s appropriately.
            //        var showFrom = perPage * (pageNumber - 1);
            //        var showTo = showFrom + perPage;

            //        // We'll first hide everything...
            //        items.hide()
            //            // ... and then only show the appropriate rows.
            //            .slice(showFrom, showTo).show();
            //    }
            //});



        };

        $.urlParam = function (name) {
            var results = new RegExp('[\?&]' + name + '=([^&#]*)').exec(window.location.href);
            if (results == null) {
                return null;
            }
            return decodeURI(results[1]) || 0;
        }



        //Run only if element exists
        if ($('#searchBtn').length > 0) { jsSearchSite(); }
    }
    catch (err) {
        console.log('ERROR: [jsSearchSite] ' + err.message);
    }
});
