//=======================================
// Obtain blog list from webservice
//=======================================
$(document).ready(function () {
    try {
        //Run only if element exists
        if ($('.BlogFilter').length > 0) { jsBlogFilters(); }

        function jsBlogFilters() {
            //Instantiate variables
            var searchBtn = $('#searchBtn');
            var searchFld = $('#searchFld input[type="text"]');
            var isListPg = $('#hfldIsListPg').val();
            var listPgUrl = $('#hfldListPgUrl').val();
            var listPgId = $('#hfldListId').val();
            var $authorLnks = $('.accordion.authors a[data-filterby="author"]');
            var $tagLnks = $('a[data-filterby="tag"]'); 
            var viewAllBtn = $('#hlnkViewAll')
            var filterBy = "";
            var filterId = "";
            var filterName = "";
            var lblFilterBy = $('#lblFilterBy');
            var $viewItems = $('.viewItem');
            var sessionVar;

            //ONLOAD
            //============================================
            //Verify if the browser can use html5 session storage
            if (typeof (Storage) == "undefined") { alert("Your browser is out-dated and may affect your experience. Try upgrading your browser."); }
            //Does Session variable exist?
            doesSessionVariableExist();


            //HANDLES
            //============================================
            $authorLnks.click(function () {
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
                    $viewItems.filter('[data-author=' + filterId + ']').show();
                }
                else {
                    //  save search value in session
                    saveFilterBy($(this));

                    //  navigate to list page
                    $(location).attr('href', listPgUrl); //window.location.href = listPgUrl;
                }
            })
            $tagLnks.click(function () {
                if (isListPg == "True") {
                    //Obtain  filtering parameters
                    filterId = $(this).attr("data-filterid");
                    filterBy = $(this).attr("data-filterby");
                    filterName = $(this).attr("data-filtername");

                    //Show how the page is being filtered
                    lblFilterBy.text(filterBy);

                    //Hide all items
                    $viewItems.hide();

                    //Loop thru EACH item and show only those with matching tag id in array
                    $viewItems.each(function () {
                        var thisItem = $(this);
                        var array = thisItem.data("tags");

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
                    //Clear filtering parameters
                    filterBy = '';
                    filterId = '';
                    filterName = '';
                    searchFld.val('');

                    //Clear how the page is being filtered
                    lblFilterBy.text('');

                    //Show all items
                    $viewItems.show();
                }
                //else use existing href link.
            })
            searchBtn.click(function () {
                if (isListPg == "True") {
                    //Submit search request
                    submitSearch(searchFld.val().trim());
                }
                else {
                    //  save search value in session
                    saveSearchFor(searchFld.val().trim());
                    //  navigate to list page
                    $(location).attr('href', listPgUrl); //window.location.href = listPgUrl;
                }
            });


            //METHODS
            //============================================
            function doesSessionVariableExist() {
                //Does session contain data?
                try {
                    if (localStorage.getItem("searchResults") !== null) {
                        console.log('localStorage has searchResults');
                        console.log(JSON.parse(localStorage.searchResults));
                        //
                        FilterByCustomSearch(localStorage.searchResults);

                        //Clear session values
                        localStorage.removeItem('searchResults');
                        //HOW TO USE LOCALSTORAGE:  http://www.mysamplecode.com/2012/04/html5-local-storage-session-tutorial.html
                    }

                    if (localStorage.getItem("searchFor") !== null) {
                        //Extract data from local storage
                        var searchFor = JSON.parse(localStorage.searchFor).searchFor;
                        //Display search in search field
                        searchFld.val(searchFor);
                        //Submit search request
                        submitSearch(searchFor);
                        //Clear session values
                        localStorage.removeItem('searchFor');
                    }

                    if (localStorage.getItem("filterBy") !== null) {
                        console.log('localStorage has filterBy');
                        console.log(JSON.parse(localStorage.filterBy));
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
            function saveSearchFor(searchFor) {
                //Instantiate an array of parameters to pass to handler
                var myData = {};
                myData.searchFor = searchFor;

                //  save search value in session
                localStorage.searchFor = JSON.stringify(myData);
                //console.log(searchFor);
                //console.log(myData);
                //console.log(JSON.stringify(myData));
            }
            function submitSearch(searchFor) {
                //Valid email address. Instantiate variables
                var urlPath = window.location.protocol + '//' + window.location.host;
                var ashxUrl = urlPath + '/Services/BlogSearch.ashx'; //?data=' + data
                var data = CreateParameters();

                //Call AJAX service
                var response = CallService_POST();
                var promise = $.when(response);
                promise.done(function () { manageResponse(response) });
                promise.fail(function () { alert('failed'); });

                //METHODS
                function CreateParameters() {
                    //Instantiate an array of parameters to pass to handler
                    var myData = {};
                    myData.searchFor = searchFor;
                    myData.listPgId = listPgId;
                    //Set array as json for use in ajax call
                    return JSON.stringify(myData);
                }
                function CallService_POST() {
                    try {
                        return $.ajax({
                            url: ashxUrl, // Location of the service
                            type: "POST", //GET or POST or PUT or DELETE verb
                            data: data, //Data sent to server
                            dataType: "json", //Expected data format from server
                            contentType: "application/json; charset=utf-8", // content type sent to server
                            processdata: true //True or False
                        });
                    }
                    catch (err) {
                        if (err.message != null) {
                            console.log(err.message);
                        }
                    }
                }
                function manageResponse(searchResults) {
                    //Is page the list page
                    if (isListPg == 'True') {
                        FilterByCustomSearch(searchResults)
                    }
                    else {
                        //  save search value in session
                        localStorage.searchResults = response.responseText;
                        //  navigate to list page
                        $(location).attr('href', listPgUrl);
                        //window.location.href = listPgUrl;

                        //console.log(JSON.parse(response.responseText));
                        //console.log(promise);
                    }



                    ////Is page the list page
                    //if (isListPg == 'True') {
                    //    //  show only those node IDs
                    //    //  highlight 'View All' button
                    //    //  Filter By "Custom Search"

                    //}
                    //else {
                    //    //  save search value in session
                    //    localStorage.searchResults = searchResults;
                    //    //  navigate to list page
                    //    console.log("not list pg: " + searchResults);
                    //    //$(location).attr('href', listPgUrl);
                    //    //window.location.href = listPgUrl;

                    //    //  if search value exists
                    //    //      show only those node IDs
                    //    //      highlight 'View All' button
                    //    //      Filter By "Custom Search"

                    //}
                }
            }
            function FilterByCustomSearch(searchResults) {
                //console.log(searchResults);
                //console.log(searchResults.responseJSON);
                //console.log(JSON.parse(searchResults.responseText));
                //console.log(JSON.parse(searchResults.responseText).searchFor);
                //console.log(JSON.parse(searchResults.responseText).lstNodeIDs);


                //Obtain  filtering parameters
                var $filterIds = JSON.parse(searchResults.responseText).lstNodeIDs;

                ////Hide all items
                $viewItems.hide();

                //Show only those matching author id
                $.each($filterIds, function (i, item) {
                    console.log(item);
                    $viewItems.filter('[data-filterid=' + item + ']').show();
                });
            }
        };
    }
    catch (err) {
        console.log('ERROR: [jsBlogFilters] ' + err.message);
    }
});