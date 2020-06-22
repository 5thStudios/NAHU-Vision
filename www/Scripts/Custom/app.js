jQuery(function ($) {
    function jsOnLoad() {
        //=======================================
        // Set parameters for jquery ui accordion.
        //=======================================
        var $accordions = $(".accordion").accordion({
            collapsible: true,
            heightStyle: "content",
            header: "h3",
            active: false //forces all panels in the same accordion to be closed by default
        }).on('click', function () {
            //Close all other accordions except the active one.
            $accordions.not(this).accordion("option", "active", false);
        });
    }


    try {
        //Initialize Zurb Foundation
        $(document).foundation();
        //
        jsOnLoad();
    }
    catch (err) {
        console.log('ERROR: [jsOnLoad] ' + err.message);
    }
});




//jQuery(window).on('load', function ($) {
//    Foundation.reInit('equalizer');
//});