jQuery(function ($) {
    function jsLoadVideoFilters() {
        //=======================================
        // Initialize variables
        //=======================================
        var allVideoBlocks = $('#videoBlocks .videoBlock');
        var visibleVideoBlocks = allVideoBlocks.filter(":visible");
        var numItems = visibleVideoBlocks.length;
        var perPage = 8;
        var filterLnks = $('a.filter');
        var lblFilterBy = $('#lblFilterBy');
        var searchInput = $('#blogSearch input')
        var searchBtn = $('#blogSearch #searchBtn');
        var lblSearchFor = $('#lblSearchFor');
        var SearchPnl = $('#SearchPnl');
        var searchResultClass = $('#hfldSearchResultClass').val();



        //=======================================
        // Methods
        //=======================================
        function checkFragment(reset) {
            // Trigger a change of page

            var hash;
            if (reset == true) {
                hash = "#page-1";
            }
            else {
                // If there's no hash, treat it like page 1.
                hash = window.location.hash || "#page-1";
            }

            // We'll use a regular expression to check the hash string.
            hash = hash.match(/^#page-(\d+)$/);

            if (hash) {
                // The `selectPage` function is described in the documentation.
                // We've captured the page number in a regex group: `(\d+)`.
                $(".pagination-page").pagination("selectPage", parseInt(hash[1]));
            }
        };
        function checkSearchParams() {
            //Display the search panel if exists in query string.
            var urlParams = new URLSearchParams(window.location.search);
            var searchParam = urlParams.get('search');
            if (searchParam) {
                //Show search panel
                lblSearchFor.html(searchParam);
                SearchPnl.show();

                //Destroy pagination
                $(".pagination-page").pagination('destroy');

                //Show how the page is being filtered
                lblFilterBy.text('Search Result');

                //Hide all items
                allVideoBlocks.hide();

                //Show all items that match the filter classes.
                allVideoBlocks.filter('.' + searchResultClass).show();

                //Obtain a list of visible blocks
                visibleVideoBlocks = allVideoBlocks.filter(":visible");
                numItems = visibleVideoBlocks.length;

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

                        // We'll first hide everything...
                        visibleVideoBlocks.hide()
                            // ... and then only show the appropriate rows.
                            .slice(showFrom, showTo).show();
                    }
                });
                checkFragment(true);
            }
        }
        function ShowByFilter(filterBy, filterByText) {
            //Hide the search panel if visible.
            SearchPnl.hide();

            //Destroy the pagination
            $(".pagination-page").pagination('destroy');
            
            //Show how the page is being filtered
            lblFilterBy.text(filterByText);

            //Hide all items
            allVideoBlocks.hide();

            if (filterBy == "*") {
                //Show all items
                allVideoBlocks.show();
            }
            else {
                //Show all items that match the filter classes.
                var array = filterBy.split(".");
                $.each(array, function (i) {
                    if (array[i]) {
                        console.log(array[i]);
                        allVideoBlocks.filter('.' + array[i]).show();
                    }
                });
            }

            //Obtain a list of visible blocks
            visibleVideoBlocks = allVideoBlocks.filter(":visible");
            numItems = visibleVideoBlocks.length;

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

                    // We'll first hide everything...
                    visibleVideoBlocks.hide()
                        // ... and then only show the appropriate rows.
                        .slice(showFrom, showTo).show();
                }
            });
            checkFragment(true);
        }




        //=======================================
        // Handles
        //=======================================
        $(window).bind("popstate", checkFragment);
        $(filterLnks).click(function () {
            if ($('#VideoHomePage').length == 0) {
                //Not home page.  Save filter and redirect to list page
                $.session.clear();
                $.session.set('filterBy', $(this).attr("data-filterby"));
                $.session.set('filterByText', $(this).text());
                window.location.replace(window.location.origin);
            }
            else {
                //Obtain parameters and display by filters
                ShowByFilter($(this).attr("data-filterby"), $(this).text());
            }

        })
        $(searchBtn).click(function () {
            //Redirect if search has been submitted.
            if (searchInput.val().length > 0) {
                var url = window.location.origin + "?search=" + encodeURIComponent(searchInput.val());
                window.location.replace(url);
            }
        })




        //=======================================
        // Initialize default values/functions
        //=======================================
        //Obtain parameters and display by filters
        if (typeof $.session.get('filterBy') !== "undefined") {
            ShowByFilter($.session.get('filterBy'), $.session.get('filterByText'));
            $.session.clear();
        } 
        //Run only if on list page
        if ($('#VideoHomePage').length > 0) {
            //
            checkSearchParams();

            // Only show the first # (or first `per_page`) items initially.
            visibleVideoBlocks.slice(perPage).hide();

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

                    // We'll first hide everything...
                    visibleVideoBlocks.hide()
                        // ... and then only show the appropriate rows.
                        .slice(showFrom, showTo).show();
                }
            });
            checkFragment();
        }
    }


    try {
        //Initialize video filters
        jsLoadVideoFilters();
    }
    catch (err) {
        console.log('ERROR: [jsLoadVideoFilters] ' + err.message);
    }
});