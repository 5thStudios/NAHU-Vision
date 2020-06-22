$(function () {
    function jsDonationSubmission(serviceUrl) {
        //  Variables
        //--------------------------------------------------
        var btnWebservice = $('.btnWebservice');
        var userId = '-1';
        var pnlValidUser = $('.pnlValidUser');
        var pnlInvalidUser = $('.pnlInvalidUser');
        var panelLocked = $('.hupac .panel.locked');
        var pnlValidating = $('.pnlValidating');
        var pnlTextBlock = $('.pnlTextBlock');
        var pnlLogInAsPACMember = $('.pnlLogInAsPACMember');
        var pnlSummary_lockedContent = $('.pnlSummary_lockedContent');
        var pnlSummary_donationPgOnly = $('.pnlSummary_donationPgOnly');


        //  INITIAL STEPS
        //--------------------------------------------------
        //manage msg panel visiblities
        panelLocked.hide();
        pnlValidating.show();
        pnlLogInAsPACMember.hide();
        pnlValidUser.hide();
        pnlInvalidUser.hide();

        //get id from cookie
        getIdFromCookie();

        //login with id from cookie
        if (userId !== '-1') { login(); }


        //  METHODS
        //--------------------------------------------------
        function getIdFromCookie() {
            //Does cookie exist?
            var FullLoginResponse = Cookies.get('FullLoginResponse');
            if (FullLoginResponse === undefined) {
                pnlLogInAsPACMember.show();
                pnlValidating.hide();
                //
                pnlSummary_donationPgOnly.hide();
            }
            else {
                //Parse results
                var jResult = JSON.parse(FullLoginResponse);
                //obtain user id
                userId = jResult.ImisUserId;
                //
                pnlSummary_donationPgOnly.show();

            }
        }
        function login() {
            //Instantiate variables
            var sessionGuid = Cookies.get('SessionGuid');
            var Type = "POST";
            var Url = serviceUrl;
            var Data = CreateParameters();
            var ContentType = "application/json; charset=utf-8";
            var DataType = "json";
            var ProcessData = true;

            //Call service
            CallService();

            function CreateParameters() {
                //Instantiate an array of parameters to pass to handler
                //var myData = { userId: userId };
                var myData = { userToken: sessionGuid };

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
                    success: function (msg) { ServiceSucceeded(msg); pnlValidating.hide(); },
                    error: function (msg) { ServiceFailed(msg); pnlValidating.hide(); }
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
                console.log('Error 1: ' + result);

                //Show msg to login using proper user
                pnlInvalidUser.show();
            }
            function ServiceSucceeded(result) {
                //
                console.log("Service Succeeded");

                if (result.d.length === 0) {
                    //Error proccessing request. Show msg
                    //===========================
                    console.log('Error 2: ' + result.err);

                    //Show msg to login using proper user
                    pnlInvalidUser.show();
                }
                else {
                    //Login returned response
                    //===========================

                    //Parse results
                    var jResult = JSON.parse(result.d);
                    console.log("result:");
                    console.log(result);
                    console.log("jResult:");
                    console.log(jResult);
                    console.log("jResult.m_StatusCode:");
                    console.log(jResult.m_StatusCode);
                    console.log("jResult.m_Uri:");
                    console.log(jResult.m_Uri);

                    if (jResult.m_StatusCode === 200) {
                        console.log("Sucess Status Code: 200");

                        window.location.href = jResult.m_Uri;
                        //pnlValidUser.show();
                        //$('#strUrl').text(jResult.m_Uri);
                    }
                    else {
                        //Show msg to login using proper user
                        pnlInvalidUser.show();
                        console.log("Sucess Status Code: NOT 200");
                    }
                }
            }
        }
    }

    try {

        //Run only if element exists
        if ($('#hfldIsCCDonationPg').length > 0) {
            var isCCDonationPg = $('#hfldIsCCDonationPg').val();

            if (isCCDonationPg === 'true') {
                console.log('isCCDonationPg');
                jsDonationSubmission("/Services/ImisWebservice2017.asmx/ccContribution");
            }
        }
        if ($('#hfldIsBankDonationPg').length > 0) {
            var isBankDonationPg = $('#hfldIsBankDonationPg').val();

            if (isBankDonationPg === 'true') {
                console.log('isBankDonationPg');
                jsDonationSubmission("/Services/ImisWebservice2017.asmx/bankContribution");
            }
        }
    }
    catch (err) {
        console.log('ERROR: [jsDonationSubmission] ' + err.message);
        pnlValidating.hide();
    }
});