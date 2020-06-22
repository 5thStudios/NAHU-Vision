angular
    .module('umbraco')
    .controller('NAHUvisionVideoCompletionController', function ($scope) {
        //Instantiate variables
        var btnGenerate = $('.NAHUvisionVideoCompletionController button.btnGenerateList');
        var lblMsg = $('.NAHUvisionVideoCompletionController .msg');
        var lblAlertMsg = $('.NAHUvisionVideoCompletionController .alertMsg');
        var lblErrorMsg = $('.NAHUvisionVideoCompletionController .alertMsg .errorMsg');
        var btnExportToExcel = $('.NAHUvisionVideoCompletionController button.btnExportToExcel');


        lblMsg.show();


        //Handles
        btnGenerate.click(function (e) {
            //Prevent 
            e.preventDefault();

            //Call webservice
            ObtainListOfCompletedVideos();
            //lblMsg.show();
            //lblAlertMsg.show();
            btnGenerate.prop('disabled', true);
            btnGenerate.addClass('disabled');
        });
        btnExportToExcel.click(function (e) {
            //Prevent 
            e.preventDefault();

            ////Call service
            //exportTableToExcel('tblVideoCompletionData', 'NAHUvision Video Completion');

            var table = $('#tblVideoCompletionData');
            if (table && table.length) {
                var preserveColors = true; 
                $(table).table2excel({
                    exclude: ".noExl",
                    name: "NAHUvision Video Completion",
                    filename: "NAHUvisionVideoCompletion_" + new Date().toISOString().replace(/[\-\:\.]/g, "") + ".xls",
                    fileext: ".xls",
                    exclude_img: true,
                    exclude_links: true,
                    exclude_inputs: true,
                    preserveColors: preserveColors
                });
            }
        });


        function ObtainListOfCompletedVideos() {
            //Valid email address. Instantiate variables
            var urlPath = window.location.protocol + '//' + window.location.host;
            var ashxUrl = urlPath + '/Services/videoServices.asmx/ObtainListOfCompletedVideos'; 
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
                    if (err.message !== null) {
                        console.log(err.message);
                    }
                }
            }
            function ServiceFailed(result) {
                //Error message
                console.log('Service call failed: ' + result.status + ' ' + result.statusText + ' ' + result.responseText);
                console.log('Error Msg:');
                console.log(result);
            }
            function ServiceSucceeded(searchResults) {
                console.log('Video services working correctly:');
                var data = $.parseJSON(searchResults.responseJSON.d);
                
                var template = $.templates("scrObtainList", {
                    markup: "#scrObtainList",
                    templates: {
                        columnTemplate: "#columnTemplate"
                    }
                });

                var htmlOutput = template.render(data);
                $("#tblListResult").html(htmlOutput);

                console.log(data);
            }
        }
        
    });