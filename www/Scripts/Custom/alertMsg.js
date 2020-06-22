$(function () {
    try {
        //Run only if element exists
        if ($('.alertMsgPnl').length > 0) { jsAlertMsg(); }

        function jsAlertMsg() {
            //  PROERTIES
            //--------------------------------------------------
            var alertMsgPnl = $('.alertMsgPnl');
            var closePnl = $('.alertMsgPnl .closePnl');


            //  HANDLERS
            //--------------------------------------------------
            closePnl.on("click", function () {
                //Hide the alert message panel
                alertMsgPnl.hide();
                //set cookie to hide alert as long as session exists.
                Cookies.set('HideAlertMsg', true, { domain: 'theandersongrp.com' });
            });


            //  METHODS
            //--------------------------------------------------

        };
    }
    catch (err) {
        console.log('ERROR: [jsAlertMsg] ' + err.message);
    }
});