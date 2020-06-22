$(document).ready(function () {
    try {
        jsRootClassSwap();

        function jsRootClassSwap() {
            //Very first function- to add root class to body tag.
            $('body').addClass($('.hfldRootClass').val());
        }
    }
    catch (err) {
        console.log('ERROR: [jsRootClassSwap] ' + err.message);
    }
});