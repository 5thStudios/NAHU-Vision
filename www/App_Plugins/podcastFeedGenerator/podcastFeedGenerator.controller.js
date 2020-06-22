angular
    .module('umbraco')
    .controller('podcastFeedGeneratorController', function ($scope) {
        //Instantiate variables
        var btnGenerate = $('.podcastFeedGeneratorController button');
        var lblMsg = $('.podcastFeedGeneratorController label.msg');
        var lblAlertMsg = $('.podcastFeedGeneratorController label.alertMsg');
        

        //Handles
        btnGenerate.click(function (e) {
            //Prevent 
            e.preventDefault();

            //Call webservice
            submitSearch();
        });




        function submitSearch() {
            //Valid email address. Instantiate variables
            var urlPath = window.location.protocol + '//' + window.location.host;
            //var ashxUrl = urlPath + '/Services/rssFeeds.asmx/podcastRssFeed_utf16';
            var ashxUrl = urlPath + '/Services/rssFeeds.asmx/podcastRssFeed'; 
            var data = ''; //CreateParameters();

            //Call AJAX service
            var response = CallService_POST();
            var promise = $.when(response);
            promise.done(function () { ServiceSucceeded(response);});
            promise.fail(function () { ServiceFailed(response); });

            //METHODS
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
                    if (err.message !== null) {
                        console.log(err.message);
                    }
                }
            }
            function ServiceSucceeded(searchResults) {
                //  save search value in session
                //localStorage.searchResults = response.responseText;
                
                console.log(JSON.parse(searchResults.responseText));
                console.log('Rss feed successfully generated');
                //console.log(promise); 

                //Show message
                lblMsg.show();     
            }
            function ServiceFailed(result) {
                console.log('Service call failed: ' + result.status + ' ' + result.statusText + ' ' + result.responseText);
                Type = null;
                varUrl = null;
                Data = null;
                ContentType = null;
                DataType = null;
                ProcessData = null;

                //Error message
                console.log('Error Msg:');
                console.log(result);

                //Show message
                lblAlertMsg.show();
            }

            //function CreateParameters() {
            //    //Instantiate an array of parameters to pass to handler
            //    var myData = {};
            //    myData.searchFor = searchFor;
            //    //Set array as json for use in ajax call
            //    return JSON.stringify(myData);
            //}
        }
    });