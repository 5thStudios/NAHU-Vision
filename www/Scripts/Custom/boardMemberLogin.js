$(function () {
    try {
        //Run only if element exists and is True
        if ($('#hfldIsBoardPg').length > 0) {
            if ($('#hfldIsBoardPg').val() == "True")
            { jsBoardMemberLogin(); }
        }

        function jsBoardMemberLogin() {
            //  PROERTIES
            //--------------------------------------------------
            var btnSubmitLogin = $('#btnSubmitBoardLogin');
            var txbUserName = $('#txbUserName_bMember');
            var txbPassword = $('#txbPassword_bMember');
            var errorMsg = $('.errorMsg')

            //  HANDLERS
            //--------------------------------------------------
            btnSubmitLogin.click(function () {
                login();
            });


            //  METHODS
            //--------------------------------------------------
            function login() {
                //Instantiate variables
                var Type = "POST";
                var Url = "/Services/ImisWebservice2017.asmx/Login_BoardMember"; //"/Services/ImisWebservice.asmx/Login_BoardMember"; //"/Services/wsImis.asmx/Login_BoardMember";
                var Data = CreateParameters();
                var ContentType = "application/json; charset=utf-8";
                var DataType = "json";
                var ProcessData = true;

                //Call service
                CallService();

                function CreateParameters() {
                    //Instantiate an array of parameters to pass to handler
                    var myData = {
                        userId: txbUserName.val(),
                        password: txbPassword.val()

                        ////VALID USER
                        //userId: 'membership@nahu.org',
                        //password: '1nahu2!'

                        ////INVALID USER
                        //userId: 'dcorporon@centurytel.net',
                        //password: 'nahu123'
                    };
                    console.log(myData);

                    //Set array as json for use in ajax call
                    return JSON.stringify(myData);
                }
                function CallService() {
                    $.ajax({
                        type: Type, //GET or POST or PUT or DELETE verb
                        url: Url, // Location of the service
                        data: Data, //Data sent to server
                        contentType: ContentType, // content type sent to server
                        dataType: DataType, //Expected data format from server
                        processdata: ProcessData, //True or False
                        success: function (msg) { ServiceSucceeded(msg); },
                        error: function (msg) { ServiceFailed(msg); }
                    });
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
                    errorMsg.html('*Invalid Credentials.');
                    errorMsg.show();
                    //console.log('Error 1: ' + result);
                }
                function ServiceSucceeded(result) {
                    //
                    if (result.d.length == 0) {
                        //Error proccessing request. Show msg
                        //===========================
                        errorMsg.html('*Error logging in.');
                        errorMsg.show();
                        console.log('Error 2: ' + result.err);
                    }
                    else {
                        //Login successful
                        //===========================

                        //Parse results
                        var jResult = JSON.parse(result.d);

                        //Is user valid?
                        if (jResult.IsValidated === true) {
                            //Refresh page
                            location.reload(true);
                            console.log('Reload pg');
                        }
                        else {
                            //Invalid login
                            errorMsg.html('*Invalid credentials.');
                            errorMsg.show();
                            console.log('Error 3: ' + result.d);
                        }
                    }
                    console.log(result);
                }
            }
        }
    }
    catch (err) {
        console.log('ERROR: [jsBoardMemberLogin] ' + err.message);
    }
});