$(document).ready(function () {
    try {
        jsSubmitToSearchPg();

        function jsSubmitToSearchPg() {
            //=====================================================
            //      PROPERTIES
            //=====================================================
            var imgBtnSearch = $('#imgBtnSearch');
            var txbSearchFor = $('#txbSearchFor');


            //=====================================================
            //      HANDLES
            //=====================================================
            txbSearchFor.keypress(function (event) {
                //If input is focused and enter clicked:
                if (event.keyCode == 13) {
                    event.preventDefault(); //prevent default submit funcitonality
                    imgBtnSearch.click(); //click the search button
                }
            });
            imgBtnSearch.click(function () {
                //Search btn clicked
                submitToSearchPg();
                console.log('search clicked');
            });


            //=====================================================
            //      METHODS
            //=====================================================
            function submitToSearchPg() {
                //Instantiate variables
                var hfldSearchPg = $('#hfldSearchPg').val();

                //save search value in session
                localStorage.searchFor = txbSearchFor.val();

                //Transfer to search page.
                window.location.href = hfldSearchPg + "?search=" + txbSearchFor.val();
            };
        };

    }
    catch (err) {
        console.log('ERROR: [jsSubmitToSearchPg] ' + err.message);
    }
});