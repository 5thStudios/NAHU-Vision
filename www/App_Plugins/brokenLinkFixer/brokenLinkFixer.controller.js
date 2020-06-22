angular
    .module('umbraco')
    .controller('brokenLinkFixerController', function ($scope) {
        //Instantiate variables
        var btnGenerate = $('.brokenLinkFixerController button');
        var lblMsg = $('.brokenLinkFixerController label.msg');
        var lblAlertMsg = $('.brokenLinkFixerController label.alertMsg');
        

        //Handles
        btnGenerate.click(function (e) {
            //Prevent 
            e.preventDefault();

            //Call webservice
            submitFix();
        });




        function submitFix() {
            //Valid email address. Instantiate variables
            var urlPath = window.location.protocol + '//' + window.location.host;
            var ashxUrl = urlPath + '/Services/brokenLinkFixer.asmx/FixBrokenLinks'; 
            var data = ''; 

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
                    console.log("CallService_POST try/catch failed:");
                    console.log(err);
                    //if (err.message !== null) {
                    //    console.log(err.message);
                    //}
                }
            }
            function ServiceSucceeded(searchResults) {
                //Extract data as json
                var jsonData = JSON.parse(searchResults.responseJSON.d);
                console.log('Broken Links Fixed Successfully');
                console.log('mediaUpdate: ' + jsonData.mediaUpdate);
                console.log('contentUpdate: ' + jsonData.contentUpdate);
                console.log(jsonData);

                //Add counts to screen
                $('#lblMediaCount').html(jsonData.mediaUpdate);
                $('#lblContentCount').html(jsonData.contentUpdate);

                //Show message
                lblMsg.show();     
            }
            function ServiceFailed(result) {
                //console.log('Service call failed: ' + result.status + ' ' + result.statusText + ' ' + result.responseText);
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
        }
    });