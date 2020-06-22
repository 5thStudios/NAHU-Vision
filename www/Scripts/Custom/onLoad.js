$(document).ready(function () {
    try {
        jsOnLoad();

        function jsOnLoad() {
            // Get the modal
            var modal = document.getElementById('loginModal');

            // When the user clicks anywhere outside of the modal, close it
            window.onclick = function (event) {
                if (event.target == modal) {
                    modal.style.display = "none";
                }
            }


            //=======================================
            // Set parameters
            //=======================================
            $(document).foundation({
                equalizer: {
                    equalize_on_stack: true, // Specify if Equalizer should make elements equal height once they become stacked.
                    act_on_hidden_el: true // Allow equalizer to resize hidden elements
                }
            });
            $(window).on('load resize', function () {
                // Create breakpoint body.class
                // https://github.com/zurb/foundation/issues/5139
                if (window.matchMedia(Foundation.media_queries.small).matches) {
                    $(document).foundation('equalizer', 'reflow');
                }
                if (window.matchMedia(Foundation.media_queries.medium).matches) {
                    $(document).foundation('equalizer', 'reflow');
                }
                if (window.matchMedia(Foundation.media_queries.large).matches) {
                    $(document).foundation('equalizer', 'reflow');
                }
            })


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
    }
    catch (err) {
        console.log('ERROR: [jsOnLoad] ' + err.message);
    }
});



$(window).load(function () {
    try {
        jsAfterLoad();

        function jsAfterLoad() {
            //Show the following controls after all is loaded.
            $('.RotatingBanners').show();
            $('.topUpcomingEvents').show();
            $('.customPanels').show();
            $('.newsPanel').show();
            $('.quicklinks').show();
            $('.QuoteBannerWithNav').show();
            $('.simpleBanner').show();
        }
    }
    catch (err) {
        console.log('ERROR: [jsOnLoad] ' + err.message);
    }
});