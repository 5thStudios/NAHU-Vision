$(document).ready(function () {
    try {
        //Run only if element exists
        if ($('.RotatingBanners').length > 0) {
            jsRotatingBanner();
            jsRotatingBannerMbl();
        }

        function jsRotatingBanner() {
            //=======================================
            //Rotating Banner
            //=======================================

            //Instantiate variables
            var $banners = $('.RotatingBanners .banner');
            var $bannerImages = $('.RotatingBanners .bgImg');
            var $navLinks = $('.RotatingBanners ul.sideNav > li');
            var active = 'active';
            var bannerIndex = 0;

            //Initial setup
            $banners.hide();
            $bannerImages.hide();
            $banners.first().show();
            $bannerImages.first().show();
            $navLinks.first().addClass(active);

            //
            $navLinks.click(function (index) {
                //Reset all arrays
                $navLinks.removeClass(active);
                $banners.hide();
                $bannerImages.hide();

                //Obtain selected index
                bannerIndex = $(this).index();

                //Show proper elements according to selected link.
                $bannerImages.eq(bannerIndex).show();
                $banners.eq(bannerIndex).show();
                $(this).addClass(active);
            });
        }
        function jsRotatingBannerMbl() {
            //=======================================
            // Mobile Rotating Banner controls
            //=======================================

            //Instantiate variables
            var $banners = $('.RotatingBanners .mblBannerLst .banner');
            var $previous = $('.RotatingBanners .mblBannerLst .banner img.arrow.previous');
            var $next = $('.RotatingBanners .mblBannerLst .banner img.arrow.next');
            var index = 0;
            var count = $banners.length - 1;

            //Initialize banners on load
            $banners.eq(index).show();
            if (count < 1) {
                $previous.hide();
                $next.hide();
            }

            //Handles
            $previous.click(function () {
                //Decrement index
                if (index == 0) {
                    index = count;
                }
                else {
                    index = index - 1;
                }
                //Show proper panel
                $banners.hide();
                $banners.eq(index).show();
            });
            $next.click(function () {
                //Increment index
                if (index == count) {
                    index = 0;
                }
                else {
                    index = index + 1;
                }
                //Show proper panel
                $banners.hide();
                $banners.eq(index).show();
            });
        }
    }
    catch (err) {
        console.log('ERROR: [jsRotatingBanner] ' + err.message);
    }
});