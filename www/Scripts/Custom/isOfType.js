//Adds a class specifying the result of the is.js request.
//Is dependant on "is.js" and can be found at: http://is.js.org/
$(function () {
    try {
        jsIsOfType();

        function jsIsOfType() {
            if (is.ie()) { $('body').addClass('ie') }
            else if (is.edge()) { $('body').addClass('edge') }
            else if (is.chrome()) { $('body').addClass('chrome') }
            else if (is.firefox()) { $('body').addClass('firefox') }
            else if (is.opera()) { $('body').addClass('opera') }
            else if (is.safari()) { $('body').addClass('safari') };
        };
    }
    catch (err) {
        console.log('ERROR: [jsIsOfType] ' + err.message);
    }
});