//--------------------------------------------------https://github.com/js-cookie/js-cookie
//--------------------------------------------------http://members.nahu.org/NAHU_Prod_Imis/AsiCommon/Services/Membership/MembershipWebService.asmx
//--------------------------------------------------http://members.nahu.org/NAHU_Prod_SSOProvider/SSO.asmx
function jsModalLogin() {
    //  PROERTIES
    //--------------------------------------------------
    var btnSignIn = $('#btnSignIn');
    var btnSignIn2 = $('.btnSignIn');
    var btnSignIn_Mbl = $('#btnSignIn_Mbl');

    var btnSignOut = $('#btnSignOut');
    var btnSignOut_Mbl = $('#btnSignOut_Mbl');

    var btnSubmitLogin = $('#btnSubmitLogin');
    var btnFetchUserInfo = $('#btnFetchUserInfo');
    var divLogIn = $('#divLogIn');
    var txbUserName = $('#txbUserName');
    var txbPassword = $('#txbPassword');
    var errorMsg = $('.errorMsg');
    var successMsg = $('.successMsg');
    var dialogModal = $('#dialogModal');

    var loginControls = $('#loginControls');
    var passwordResetControls = $('#passwordResetControls');
    var btnSubmitPasswordReset = $('#btnSubmitPasswordReset');
    var btnCancelPasswordReset = $('#btnCancelPasswordReset');
    var btnResetPassword = $('#btnResetPassword');


    //  ONLOAD
    //--------------------------------------------------
    isUserLoggedIn();



    //URL is http://www.example.com/mypage?ref=registration&email=bobo@example.com
    $.urlParam = function (name) {
        var results = new RegExp('[\?&]' + name + '=([^&#]*)')
            .exec(window.location.search);

        return (results !== null) ? results[1] || 0 : false;
    };

    var showmodal = $.urlParam('showmodal');
    console.log('showmodal: ' + showmodal);
    if (showmodal === "true") {
        dialogModal.foundation('reveal', 'open');
    }




    //TEST LOGIN WITH MODAL
    //var btnModalLoginTest = $('.btnModalLoginTest');
    //btnModalLoginTest.on("click", function () {
    //    //On click reveal modal
    //    dialogModal.foundation('reveal', 'open');
    //});





    //  HANDLERS
    //--------------------------------------------------
    btnSignIn.on("click", function () {
        //On click reveal modal
        dialogModal.foundation('reveal', 'open');
        //window.location.href = "https://members.nahu.org/NAHU_Prod_Imis/Nahu_Member/Sign_In.aspx?redirectMe=prev";
        //window.location.href = "https://members.nahu.org/NAHU_Prod_Imis/Shared_Content/Sign_In.aspx?redirectMe=prev";

    });
    btnSignIn2.on("click", function () {
        //On click reveal modal
        dialogModal.foundation('reveal', 'open');
        //window.location.href = "https://members.nahu.org/NAHU_Prod_Imis/Nahu_Member/Sign_In.aspx?redirectMe=prev";
        //window.location.href = "https://members.nahu.org/NAHU_Prod_Imis/Shared_Content/Sign_In.aspx?redirectMe=prev";
    });
    btnSignIn_Mbl.on("click", function () {
        //On click reveal modal
        dialogModal.foundation('reveal', 'open');
        //window.location.href = "https://members.nahu.org/NAHU_Prod_Imis/Nahu_Member/Sign_In.aspx?redirectMe=prev";
        //window.location.href = "https://members.nahu.org/NAHU_Prod_Imis/Shared_Content/Sign_In.aspx?redirectMe=prev";
    });
    btnSubmitLogin.click(function () {
        login();
    });
    btnSignOut.click(function () {
        logout();
    });
    btnSignOut_Mbl.click(function () {
        logout();
    });
    btnFetchUserInfo.click(function () {
        fetchUserInfo();
    });
    btnCancelPasswordReset.click(function () {
        //Show login controls
        loginControls.show();
        passwordResetControls.hide();
        //Hide any messages
        errorMsg.hide();
        successMsg.hide();
    });
    btnResetPassword.click(function () {
        //Show password controls
        loginControls.hide();
        passwordResetControls.show();
        //Hide any messages
        errorMsg.hide();
        successMsg.hide();
    });
    btnSubmitPasswordReset.click(function () {
        resetPassword();
    });


    //  METHODS
    //--------------------------------------------------
    function login() {
        //Instantiate variables
        var Type = "POST";
        var Url = "/Services/ImisWebservice2017.asmx/Login";
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

            //Set array as json for use in ajax call
            console.log('myData');
            console.log(myData);
            return JSON.stringify(myData);
            //console.log(Data);
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
            errorMsg.html('*Error logging in.');
            errorMsg.show();

            //Show signin button
            btnSignIn.show();
            btnSignOut.hide();
        }
        function ServiceSucceeded(result) {
            //Delete cookie
            Cookies.remove('Login');
            Cookies.remove('SessionGuid');
            Cookies.remove('FullLoginResponse');

            //
            if (result.d.length === 0) {
                //Error proccessing request. Show msg
                //===========================
                errorMsg.html('*Error logging in.');
                errorMsg.show();

                //Show signin button
                btnSignIn.show();
                btnSignOut.hide();
                btnSignIn_Mbl.show();
                btnSignOut_Mbl.hide();
            }
            else {
                //Login successful
                //===========================

                //Save full response as cookie
                Cookies.set('FullLoginResponse', result.d, { domain: 'nahu.org' });
                Cookies.set('FullLoginResponse', result.d, { domain: 'staging.nahu.org' });
                Cookies.set('FullLoginResponse', result.d, { domain: 'nahu.5thstudios.com' });
                Cookies.set('FullLoginResponse', result.d, { domain: 'nahu-video.5thstudios.com' });

                //Parse results
                var jResult = JSON.parse(result.d);

                console.log('Service being called: ' + Url);
                console.log(jResult);

                //Is user valid?
                if (jResult.IsValidated === true) {
                    //Loop thru and create each cookie.
                    $.each(jResult.CookieStructures, function (i, cookie) {
                        //Delete cookie if it exists
                        Cookies.remove(cookie.Name);

                        //Create cookie
                        Cookies.set(cookie.Name, cookie.Value, { domain: 'nahu.org' });
                        Cookies.set(cookie.Name, cookie.Value, { domain: 'staging.nahu.org' });
                        Cookies.set(cookie.Name, cookie.Value, { domain: 'nahu.5thstudios.com' });
                        Cookies.set(cookie.Name, cookie.Value, { domain: 'nahu-video.5thstudios.com' });
                    });

                    //Hide error message and dialog modal
                    errorMsg.hide();
                    dialogModal.foundation('reveal', 'close');

                    //Show signout button
                    btnSignIn.hide();
                    btnSignOut.show();
                    btnSignIn_Mbl.hide();
                    btnSignOut_Mbl.show();

                    //Refresh page
                    location.reload();
                }
                else {
                    //Invalid login
                    errorMsg.html('*Invalid credentials.');
                    errorMsg.show();

                    //Show signin button
                    btnSignIn.show();
                    btnSignOut.hide();
                    btnSignIn_Mbl.show();
                    btnSignOut_Mbl.hide();
                }
            }
        }
    }
    function isUserLoggedIn() {
        //Does cookie exist?
        var sessionGuid = Cookies.get('SessionGuid');
        
        if (sessionGuid === undefined) {
            //====================================Cookie does not exists
            //Show signin button
            btnSignIn.show();
            btnSignOut.hide();
            console.log('Cookie does not exist.  ');
        }
        else { //=================================Cookie exists
            //Instantiate variables
            var Type = "POST";
            var Url = "/Services/ImisWebservice2017.asmx/IsUserLoggedIn";
            var Data = CreateParameters();
            var ContentType = "application/json; charset=utf-8";
            var DataType = "json";
            var ProcessData = true;

            //Call service
            CallService();

        }
        function CreateParameters() {
            //Instantiate an array of parameters to pass to handler
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

            //Show signin button
            btnSignIn.show();
            btnSignOut.hide();
            btnSignIn_Mbl.show();
            btnSignOut_Mbl.hide();
        }
        function ServiceSucceeded(result) {
            console.log(JSON.parse(result.d));

            //Show signout button
            btnSignIn.hide();
            btnSignOut.show();
            btnSignIn_Mbl.hide();
            btnSignOut_Mbl.show();
        }
    }
    function fetchUserInfo() {
        //Does cookie exist?
        var sessionGuid = Cookies.get('SessionGuid');
        if (sessionGuid === undefined) {
            //====================================Cookie does not exists
            console.log('Cookie is empty.');
            console.log('User is not logged in.');
        }
        else { //=================================Cookie exists
            //Instantiate variables
            var Type = "POST";
            var Url = "/Services/ImisWebservice2017.asmx/FetchUserInfo";
            var Data = CreateParameters();
            var ContentType = "application/json; charset=utf-8";
            var DataType = "json";
            var ProcessData = true;

            //Call service
            CallService();
        }

        function CreateParameters() {
            //Instantiate an array of parameters to pass to handler
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
        }
        function ServiceSucceeded(result) {
            console.log(JSON.parse(result.d));
        }
    }
    function disposeSession() {
        //Does cookie exist?
        var sessionGuid = Cookies.get('SessionGuid');
        if (sessionGuid === undefined) {
            //====================================Cookie does not exists
            console.log('Cookie is empty.');
            console.log('User is not logged in.');

            //Show signin button
            btnSignIn.show();
            btnSignOut.hide();
        }
        else { //=================================Cookie exists
            //Instantiate variables
            var Type = "POST";
            var Url = "/Services/ImisWebservice2017.asmx/DisposeSession";
            var Data = CreateParameters();
            var ContentType = "application/json; charset=utf-8";
            var DataType = "json";
            var ProcessData = true;

            //Call service
            CallService();
        }

        function CreateParameters() {
            //Instantiate an array of parameters to pass to handler
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
        }
        function ServiceSucceeded(result) {
            console.log(JSON.parse(result.d));
        }
    }
    function resetPassword() {
        //Instantiate variables
        var Type = "POST";
        var Url = "/Services/ImisWebservice2017.asmx/RecoverPassword";
        var Data = CreateParameters();
        var ContentType = "application/json; charset=utf-8";
        var DataType = "json";
        var ProcessData = true;

        //Call service
        CallService();

        function CreateParameters() {
            //Instantiate an array of parameters to pass to handler
            var myData = {
                userId: txbUserName.val()
            };

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
            errorMsg.html('*Error resetting password.');
            errorMsg.show();
        }
        function ServiceSucceeded(result) {
            //Determine result message
            if (result.d.length === 0) {
                //Error proccessing request. Show msg
                //===========================
                errorMsg.html('*Error resetting password.');
                errorMsg.show();
            }
            else {
                //Parse results
                var jResult = JSON.parse(result.d);

                //Is user valid?
                if (jResult === true) {
                    //Hide error message and show success message
                    errorMsg.hide();
                    successMsg.html('*Please check your email for the password reset link.');
                    successMsg.show();

                }
                else {
                    //Invalid credentials
                    successMsg.hide();
                    errorMsg.html('*Invalid credentials.');
                    errorMsg.show();
                }
            }
        }
    }
    function logout() {
        //console.log('Logout Start');

        //Delete cookie
        Cookies.remove('validBMember');
        Cookies.remove('Login');
        Cookies.remove('SessionGuid');
        Cookies.remove('FullLoginResponse');

        Cookies.remove('validBMember', { domain: 'nahu.org' });
        Cookies.remove('Login', { domain: 'nahu.org' });
        Cookies.remove('SessionGuid', { domain: 'nahu.org' });
        Cookies.remove('FullLoginResponse', { domain: 'nahu.org' });

        Cookies.remove('Login', { domain: 'hupac.nahu.org' });
        Cookies.remove('SessionGuid', { domain: 'hupac.nahu.org' });
        Cookies.remove('FullLoginResponse', { domain: 'hupac.nahu.org' });
        Cookies.remove('validBMember', { domain: 'hupac.nahu.org' });

        Cookies.remove('Login', { domain: 'staging.nahu.org' });
        Cookies.remove('SessionGuid', { domain: 'staging.nahu.org' });
        Cookies.remove('FullLoginResponse', { domain: 'staging.nahu.org' });
        Cookies.remove('validBMember', { domain: 'staging.nahu.org' });

        Cookies.remove('Login', { domain: 'nahu.5thstudios.com' });
        Cookies.remove('SessionGuid', { domain: 'nahu.5thstudios.com' });
        Cookies.remove('FullLoginResponse', { domain: 'nahu.5thstudios.com' });
        Cookies.remove('validBMember', { domain: 'nahu.5thstudios.com' });

        Cookies.remove('Login', { domain: 'nahu-video.5thstudios.com' });
        Cookies.remove('SessionGuid', { domain: 'nahu-video.5thstudios.com' });
        Cookies.remove('FullLoginResponse', { domain: 'nahu-video.5thstudios.com' });
        Cookies.remove('validBMember', { domain: 'nahu-video.5thstudios.com' });

        //Show signin button
        btnSignIn.show();
        btnSignOut.hide();
        btnSignIn_Mbl.show();
        btnSignOut_Mbl.hide();

        //Delete session from IMIS
        disposeSession();

        //console.log('Logout Stop');

        //Refresh page
        location.reload(true);
    }
}
$(document).ready(function () {
    $(function () {
        try {
            //Run only if element exists
            if ($('#nahu').length > 0) { jsModalLogin(); }
        }
        catch (err) {
            console.log('ERROR: [jsModalLogin] ' + err.message);
        }
    });
});






function jsVideoModalLogin() {
    //  PROERTIES
    //--------------------------------------------------
    var btnSignIn = $('#btnSignIn');
    var btnSignIn2 = $('.btnSignIn');
    var btnSignIn_Mbl = $('#btnSignIn_Mbl');

    var btnSignOut = $('#btnSignOut');
    var btnSignOut_Mbl = $('#btnSignOut_Mbl');

    var btnSubmitLogin = $('#btnSubmitLogin');
    var btnFetchUserInfo = $('#btnFetchUserInfo');
    var divLogIn = $('#divLogIn');
    var txbUserName = $('#txbUserName');
    var txbPassword = $('#txbPassword');
    var errorMsg = $('.errorMsg');
    var successMsg = $('.successMsg');
    var dialogModal = $('#dialogModal');

    var loginControls = $('#loginControls');
    var passwordResetControls = $('#passwordResetControls');
    var btnSubmitPasswordReset = $('#btnSubmitPasswordReset');
    var btnCancelPasswordReset = $('#btnCancelPasswordReset');
    var btnResetPassword = $('#btnResetPassword');
    var closeModal = $('.close-reveal-modal');
         


    //  HANDLERS
    //--------------------------------------------------
    btnSignIn.on("click", function () {
        //On click reveal modal
        //dialogModal.foundation('reveal', 'open');
        dialogModal.show();
        ////window.location.href = "https://members.nahu.org/NAHU_Prod_Imis/Nahu_Member/Sign_In.aspx?redirectMe=prev";
        ////window.location.href = "https://members.nahu.org/NAHU_Prod_Imis/Shared_Content/Sign_In.aspx?redirectMe=prev";

    });
    btnSignIn2.on("click", function () {
        //On click reveal modal
        //dialogModal.foundation('reveal', 'open');
        dialogModal.show();
        //window.location.href = "https://members.nahu.org/NAHU_Prod_Imis/Nahu_Member/Sign_In.aspx?redirectMe=prev";
        //window.location.href = "https://members.nahu.org/NAHU_Prod_Imis/Shared_Content/Sign_In.aspx?redirectMe=prev";
    });
    btnSignIn_Mbl.on("click", function () {
        //On click reveal modal
        //dialogModal.foundation('reveal', 'open');
        dialogModal.show();
        //window.location.href = "https://members.nahu.org/NAHU_Prod_Imis/Nahu_Member/Sign_In.aspx?redirectMe=prev";
        //window.location.href = "https://members.nahu.org/NAHU_Prod_Imis/Shared_Content/Sign_In.aspx?redirectMe=prev";
    });
    btnSubmitLogin.click(function () {
        login();
    });
    btnSignOut.click(function () {
        logout();
    });
    btnSignOut_Mbl.click(function () {
        logout();
    });
    btnFetchUserInfo.click(function () {
        fetchUserInfo();
    });
    btnCancelPasswordReset.click(function () {
        //Show login controls
        loginControls.show();
        passwordResetControls.hide();
        //Hide any messages
        errorMsg.hide();
        successMsg.hide();
    });
    btnResetPassword.click(function () {
        //Show password controls
        loginControls.hide();
        passwordResetControls.show();
        //Hide any messages
        errorMsg.hide();
        successMsg.hide();
    });
    btnSubmitPasswordReset.click(function () {
        resetPassword();
    });
    closeModal.click(function () {
        dialogModal.hide();
    })



    //  METHODS
    //--------------------------------------------------
    function login() {
        //Instantiate variables
        var Type = "POST";
        var Url = "/Services/ImisWebservice2017.asmx/Login";
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

            //Set array as json for use in ajax call
            console.log('myData');
            console.log(myData);
            return JSON.stringify(myData);
            //console.log(Data);
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
            errorMsg.html('*Error logging in.');
            errorMsg.show();

            //Show signin button
            btnSignIn.show();
            btnSignOut.hide();
        }
        function ServiceSucceeded(result) {
            //Delete cookie
            Cookies.remove('Login');
            Cookies.remove('SessionGuid');
            Cookies.remove('FullLoginResponse');

            //
            if (result.d.length === 0) {
                //Error proccessing request. Show msg
                //===========================
                errorMsg.html('*Error logging in.');
                errorMsg.show();

                //Show signin button
                btnSignIn.show();
                btnSignOut.hide();
                btnSignIn_Mbl.show();
                btnSignOut_Mbl.hide();
            }
            else {
                //Login successful
                //===========================

                //Save full response as cookie
                Cookies.set('FullLoginResponse', result.d, { domain: 'nahu.org' });
                Cookies.set('FullLoginResponse', result.d, { domain: 'staging.nahu.org' });
                Cookies.set('FullLoginResponse', result.d, { domain: 'nahu.5thstudios.com' });
                Cookies.set('FullLoginResponse', result.d, { domain: 'nahu-video.5thstudios.com' });

                //Parse results
                var jResult = JSON.parse(result.d);

                console.log('Service being called: ' + Url);
                console.log(jResult);

                //Is user valid?
                if (jResult.IsValidated === true) {
                    //Fetch and store user information within Umbraco
                    fetchUserInfo()

                    //Loop thru and create each cookie.
                    $.each(jResult.CookieStructures, function (i, cookie) {
                        //Delete cookie if it exists
                        Cookies.remove(cookie.Name);

                        //Create cookie
                        Cookies.set(cookie.Name, cookie.Value, { domain: 'nahu.org' });
                        Cookies.set(cookie.Name, cookie.Value, { domain: 'staging.nahu.org' });
                        Cookies.set(cookie.Name, cookie.Value, { domain: 'nahu.5thstudios.com' });
                        Cookies.set(cookie.Name, cookie.Value, { domain: 'nahu-video.5thstudios.com' });
                    });

                    //Hide error message and dialog modal
                    errorMsg.hide();
                    //dialogModal.foundation('reveal', 'close');
                    var modal = new Foundation.Reveal($('#dialogModal'));
                    modal.close();

                    //Show signout button
                    btnSignIn.hide();
                    btnSignOut.show();
                    btnSignIn_Mbl.hide();
                    btnSignOut_Mbl.show();

                    //Refresh page
                    location.reload();
                }
                else {
                    //Invalid login
                    errorMsg.html('*Invalid credentials.');
                    errorMsg.show();

                    //Show signin button
                    btnSignIn.show();
                    btnSignOut.hide();
                    btnSignIn_Mbl.show();
                    btnSignOut_Mbl.hide();
                }
            }
        }
    }
    function isUserLoggedIn() {
        //Does cookie exist?
        var sessionGuid = Cookies.get('SessionGuid');

        if (sessionGuid === undefined) {
            //====================================Cookie does not exists
            //Show signin button
            btnSignIn.show();
            btnSignOut.hide();
            console.log('Cookie does not exist.  ');
        }
        else { //=================================Cookie exists
            //Instantiate variables
            var Type = "POST";
            var Url = "/Services/ImisWebservice2017.asmx/IsUserLoggedIn";
            var Data = CreateParameters();
            var ContentType = "application/json; charset=utf-8";
            var DataType = "json";
            var ProcessData = true;

            //Call service
            CallService();

        }
        function CreateParameters() {
            //Instantiate an array of parameters to pass to handler
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

            //Show signin button
            btnSignIn.show();
            btnSignOut.hide();
            btnSignIn_Mbl.show();
            btnSignOut_Mbl.hide();
        }
        function ServiceSucceeded(result) {
            console.log(JSON.parse(result.d));

            //Show signout button
            btnSignIn.hide();
            btnSignOut.show();
            btnSignIn_Mbl.hide();
            btnSignOut_Mbl.show();
        }
    }
    function fetchUserInfo() {
        //Does cookie exist?
        var sessionGuid = Cookies.get('SessionGuid');
        if (sessionGuid === undefined) {
            //====================================Cookie does not exists
            console.log('Cookie is empty.');
            console.log('User is not logged in.');
        }
        else { //=================================Cookie exists
            //Instantiate variables
            var Type = "POST";
            var Url = "/Services/ImisWebservice2017.asmx/FetchUserInfo";
            var Data = CreateParameters();
            var ContentType = "application/json; charset=utf-8";
            var DataType = "json";
            var ProcessData = true;

            //Call service
            CallService();
        }

        function CreateParameters() {
            //Instantiate an array of parameters to pass to handler
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
                success: function (msg) { ServiceSucceeded(msg); },
                error: function (msg) { ServiceFailed(msg); }
            });
        }
        function ServiceFailed(result) {
            console.log('Fetch User failed: ' + result.status + ' ' + result.statusText + ' ' + result.responseText);
            Type = null;
            varUrl = null;
            Data = null;
            ContentType = null;
            DataType = null;
            ProcessData = null;
        }
        function ServiceSucceeded(result) {
            console.log("Fetch User Succeeded");
            console.log(result.d);
            console.log(JSON.parse(result.d));
        }
    }
    function disposeSession() {
        //Does cookie exist?
        var sessionGuid = Cookies.get('SessionGuid');
        if (sessionGuid === undefined) {
            //====================================Cookie does not exists
            console.log('Cookie is empty.');
            console.log('User is not logged in.');

            //Show signin button
            btnSignIn.show();
            btnSignOut.hide();
        }
        else { //=================================Cookie exists
            //Instantiate variables
            var Type = "POST";
            var Url = "/Services/ImisWebservice2017.asmx/DisposeSession";
            var Data = CreateParameters();
            var ContentType = "application/json; charset=utf-8";
            var DataType = "json";
            var ProcessData = true;

            //Call service
            CallService();
        }

        function CreateParameters() {
            //Instantiate an array of parameters to pass to handler
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
        }
        function ServiceSucceeded(result) {
            console.log(JSON.parse(result.d));
        }
    }
    function resetPassword() {
        //Instantiate variables
        var Type = "POST";
        var Url = "/Services/ImisWebservice2017.asmx/RecoverPassword";
        var Data = CreateParameters();
        var ContentType = "application/json; charset=utf-8";
        var DataType = "json";
        var ProcessData = true;

        //Call service
        CallService();

        function CreateParameters() {
            //Instantiate an array of parameters to pass to handler
            var myData = {
                userId: txbUserName.val()
            };

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
            errorMsg.html('*Error resetting password.');
            errorMsg.show();
        }
        function ServiceSucceeded(result) {
            //Determine result message
            if (result.d.length === 0) {
                //Error proccessing request. Show msg
                //===========================
                errorMsg.html('*Error resetting password.');
                errorMsg.show();
            }
            else {
                //Parse results
                var jResult = JSON.parse(result.d);

                //Is user valid?
                if (jResult === true) {
                    //Hide error message and show success message
                    errorMsg.hide();
                    successMsg.html('*Please check your email for the password reset link.');
                    successMsg.show();

                }
                else {
                    //Invalid credentials
                    successMsg.hide();
                    errorMsg.html('*Invalid credentials.');
                    errorMsg.show();
                }
            }
        }
    }
    function logout() {
        //console.log('Logout Start');

        //Delete cookie
        Cookies.remove('validBMember');
        Cookies.remove('Login');
        Cookies.remove('SessionGuid');
        Cookies.remove('FullLoginResponse');

        Cookies.remove('validBMember', { domain: 'nahu.org' });
        Cookies.remove('Login', { domain: 'nahu.org' });
        Cookies.remove('SessionGuid', { domain: 'nahu.org' });
        Cookies.remove('FullLoginResponse', { domain: 'nahu.org' });

        Cookies.remove('Login', { domain: 'hupac.nahu.org' });
        Cookies.remove('SessionGuid', { domain: 'hupac.nahu.org' });
        Cookies.remove('FullLoginResponse', { domain: 'hupac.nahu.org' });
        Cookies.remove('validBMember', { domain: 'hupac.nahu.org' });

        Cookies.remove('Login', { domain: 'staging.nahu.org' });
        Cookies.remove('SessionGuid', { domain: 'staging.nahu.org' });
        Cookies.remove('FullLoginResponse', { domain: 'staging.nahu.org' });
        Cookies.remove('validBMember', { domain: 'staging.nahu.org' });

        Cookies.remove('Login', { domain: 'nahu.5thstudios.com' });
        Cookies.remove('SessionGuid', { domain: 'nahu.5thstudios.com' });
        Cookies.remove('FullLoginResponse', { domain: 'nahu.5thstudios.com' });
        Cookies.remove('validBMember', { domain: 'nahu.5thstudios.com' });

        Cookies.remove('Login', { domain: 'nahu-video.5thstudios.com' });
        Cookies.remove('SessionGuid', { domain: 'nahu-video.5thstudios.com' });
        Cookies.remove('FullLoginResponse', { domain: 'nahu-video.5thstudios.com' });
        Cookies.remove('validBMember', { domain: 'nahu-video.5thstudios.com' });

        //Show signin button
        btnSignIn.show();
        btnSignOut.hide();
        btnSignIn_Mbl.show();
        btnSignOut_Mbl.hide();

        //Delete session from IMIS
        disposeSession();

        //console.log('Logout Stop');

        //Refresh page
        location.reload(true);
    }




    //  ONLOAD
    //--------------------------------------------------
    //
    btnSignIn.removeClass("hide");
    btnSignIn2.removeClass("hide");
    btnSignIn_Mbl.removeClass("hide");
    btnSignOut.removeClass("hide");
    btnSignOut_Mbl.removeClass("hide");
    //
    isUserLoggedIn();
    fetchUserInfo();
}
$(document).ready(function () {
    $(function () {
        try {
            //Run only if element exists
            if ($('#nahuvision').length > 0) { jsVideoModalLogin(); }
        }
        catch (err) {
            console.log('ERROR: [jsVideoModalLogin] ' + err.message);
        }
    });
});