//
$(document).ready(function () {
    try {
        //Run only if element exists
        if ($('.eventFilter').length > 0) { jsEventFilters(); }

        function jsEventFilters() {
            //Instantiate variables
            var listPgUrl = $('#hfldListPgUrl').val();
            var isListPg = $('#hfldIsListPg').val();
            var viewAllBtn = $('#hlnkViewAll')
            var filterBy = "";
            var filterId = "";
            var filterName = "";
            var lblFilterBy = $('#lblFilterBy');
            var $viewItems = $('.viewItem');
            var sessionVar;
            var $eventTypeLinks = $('a[data-filterby="eventType"]');
            var $chapterLinks = $('a[data-filterby="chapter"]');
            //var $eventTypeLinks = $('.accordion.eventTypes a[data-filterby="eventType"]');
            //var $chapterLinks = $('.accordion.chapters a[data-filterby="chapter"]');

            //Verify if the browser can use html5 session storage
            if (typeof (Storage) == "undefined") { alert("Your browser is out-dated and may affect your experience. Try upgrading your browser."); }


            //Does Session variable exist?
            //doesSessionVariableExist();

            //HANDLES
            //============================================
            $eventTypeLinks.click(function () {
                if (isListPg == "True") {
                    //Obtain  filtering parameters
                    filterId = $(this).attr("data-filterid");
                    filterBy = $(this).attr("data-filterby");
                    filterName = $(this).attr("data-filtername");

                    console.log(filterId);
                    console.log(filterBy);
                    console.log(filterName);

                    //Show how the page is being filtered
                    lblFilterBy.text(filterBy);

                    ////Hide all items
                    $viewItems.hide();

                    //Show only those matching author id
                    //$viewItems.filter('[data-eventtypes=' + filterId + ']').show();

                    //Loop thru EACH item and show only those with matching tag id in array
                    $viewItems.each(function () {
                        var thisItem = $(this);
                        var array = thisItem.data("eventtypes");

                        $.each(array, function (i, obj) {
                            if (obj.id == filterId) { thisItem.show(); return false; }
                        });
                    });
                }
                else {
                    //  save search value in session
                    saveFilterBy($(this));

                    //  navigate to list page
                    $(location).attr('href', listPgUrl);
                    //window.location.href = listPgUrl;
                }
            })
            $chapterLinks.click(function () {
                if (isListPg == "True") {
                    //Obtain  filtering parameters
                    filterId = $(this).attr("data-filterid");
                    filterBy = $(this).attr("data-filterby");
                    filterName = $(this).attr("data-filtername");

                    console.log(filterId);
                    console.log(filterBy);
                    console.log(filterName);

                    //Show how the page is being filtered
                    lblFilterBy.text(filterBy);

                    //Hide all items
                    $viewItems.hide();

                    //Loop thru EACH item and show only those with matching tag id in array
                    $viewItems.each(function () {
                        var thisItem = $(this);
                        var array = thisItem.data("chapters");

                        $.each(array, function (i, obj) {
                            if (obj.id == filterId) { thisItem.show(); return false; }
                        });
                    });
                }
                else {
                    //  save search value in session
                    saveFilterBy($(this));

                    //  navigate to list page
                    $(location).attr('href', listPgUrl);
                    //window.location.href = listPgUrl;
                }
            })
            viewAllBtn.click(function () {
                if (isListPg == "True") {
                    //Clear filters
                    console.log('TO BE BUILT');

                    //Clear filtering parameters
                    filterBy = '';
                    filterId = '';
                    filterName = '';

                    //Clear how the page is being filtered
                    lblFilterBy.text('');

                    //Show all items
                    $viewItems.show();
                }
                //else use existing href link.
            })



            //METHODS
            //============================================
            function doesSessionVariableExist() {
                //Does session contain data?
                try {
                    if (localStorage.getItem("searchResults") !== null) {
                        //
                        console.log(JSON.parse(localStorage.searchResults));
                        FilterByCustomSearch(localStorage.searchResults);

                        //Clear session values
                        localStorage.removeItem('searchResults');
                        //HOW TO USE LOCALSTORAGE:  http://www.mysamplecode.com/2012/04/html5-local-storage-session-tutorial.html
                    }

                    if (localStorage.getItem("filterBy") !== null) {
                        //Extract data from session
                        sessionVar = JSON.parse(localStorage.filterBy);

                        //Hide all items
                        $viewItems.hide();

                        //Filter list according to type of filter
                        if (sessionVar.dataFilterby === "author") {
                            //Show only those matching author id
                            $viewItems.filter('[data-author=' + sessionVar.dataFilterid + ']').show();
                        }
                        else if (sessionVar.dataFilterby === "tag") {
                            //Loop thru EACH item and show only those with matching tag id in array
                            $viewItems.each(function () {
                                var thisItem = $(this);
                                var array = thisItem.data("tags");

                                $.each(array, function (i, obj) {
                                    if (obj.id == sessionVar.dataFilterid) { thisItem.show(); return false; }
                                });
                            });
                        }

                        //Clear session values
                        localStorage.removeItem('filterBy');
                        sessionVar = "";
                    }
                }
                catch (e) {
                    console.log('error: ' + e);
                    localStorage.removeItem('searchResults');
                }
            }
            function saveFilterBy(thisItem) {
                //Instantiate an array of parameters to pass to handler
                var myData = {};
                myData.dataFilterid = thisItem.attr('data-filterid');
                myData.dataFiltername = thisItem.attr('data-filtername');
                myData.dataFilterby = thisItem.attr('data-filterby');

                //  save search value in session
                localStorage.filterBy = JSON.stringify(myData);
                console.log(localStorage.filterBy);
            }
        };
    }
    catch (err) {
        console.log('ERROR: [jsEventFilters] ' + err.message);
    }
});
