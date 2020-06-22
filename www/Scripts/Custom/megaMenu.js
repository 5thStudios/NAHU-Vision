//Controls the megamenu's hover states
$(document).ready(function () {
    try {
        jsMegaMenu();

        function jsMegaMenu() {
            //Instantiate variables
            var navMegaMenu = $('.navMegaMenu');
            var megaMenu = $('.megaMenu');



            //When megamenu icon is hovered
            navMegaMenu.on({
                mouseenter: function () {
                    //megaMenu.show(); //megaMenu.fadeIn(500);
                    megaMenu.removeClass('hiddenPnl');
                },
                mouseleave: function () {
                    //megaMenu.hide(); //megaMenu.fadeOut(1000);
                    megaMenu.addClass('hiddenPnl');
                }
            });


            //When megamenu panel is hovered
            megaMenu.on({
                mouseenter: function () {
                    //megaMenu.show();
                    //navMegaMenu.addClass('hover'); //Add the 'hover' styling to the parent element
                    megaMenu.removeClass('hiddenPnl');
                    navMegaMenu.addClass('hiddenPnl'); //Add the 'hover' styling to the parent element
                },
                mouseleave: function () {
                    //megaMenu.hide(); //megaMenu.fadeOut(1000);
                    //navMegaMenu.removeClass('hover'); //Remove the 'hover' styling from the parent element
                    megaMenu.addClass('hiddenPnl');
                    navMegaMenu.removeClass('hiddenPnl'); //Remove the 'hover' styling from the parent element
                }
            });
            //megaMenu.show();  //For Testing Only
        };
    }
    catch (err) {
        console.log('ERROR: [jsMegaMenu] ' + err.message);
    }
});