//=======================================
// Manages the top podcast rotator on the home page
//=======================================

$(document).ready(function () {
    try {
        function jsTopPodcasts() {
            //============================================
            //  INSTANTIATE VARIABLES
            //============================================
            var pnlTopNews = $('.pnlTopNews');
            var $lstArticles = pnlTopNews.find('li');
            var $lstHRs = pnlTopNews.find('hr');
            var lstCount = $lstArticles.length;
            var showN = 3;
            var nPanels = (Math.ceil(lstCount / showN));
            var currentN = 0;
            var sec = 10;
            var minHeight = pnlTopNews.height();


            //============================================
            //  PRESET VALUES
            //============================================         
            $lstArticles.hide();
            $lstHRs.hide();
            setIndexAttributes();
            resetAll();
            TweenMax.delayedCall(sec, nextSet);


            //============================================
            //  METHODS
            //============================================
            function resetAll() {
                //hide all
                $lstArticles.hide();
                $lstHRs.hide();

                //Increment index
                currentN = currentN + 1;
                if (currentN == showN) { currentN = 0; }

                //Show active articles
                setActiveArticles(currentN);
            }
            function setIndexAttributes() {
                //Assign index group to articles and dividing HR tags
                $lstArticles.each(function (index) {
                    $(this).attr('data-index', (Math.ceil((index - (showN - 1)) / showN)));
                });
                $lstHRs.each(function (index) {
                    //$(this).attr('data-index', (Math.ceil((index - (showN - 1)) / showN)));
                    //console.log((index - (showN - 1)) / showN);
                    //console.log((index - (showN - 1)) % showN);

                    if (((index - (showN - 1)) % showN) != 0) {
                        $(this).attr('data-index', (Math.ceil((index - (showN - 1)) / showN)));
                    }
                });
            }
            function hideActiveArticles(index) {
                //Get list of visible articles
                var lst = $lstArticles.filter('[data-index="' + index + '"]');
                var lstHr = $lstHRs.filter('[data-index="' + index + '"]');
                //Change opacity to 0 and hide
                TweenMax.staggerFromTo(lstHr, 1, { opacity: 1 }, { opacity: 0 }, 0.3);
                TweenMax.staggerFromTo(lst, 1, { opacity: 1 }, { opacity: 0 }, 0.3, resetAll);
            }
            function setActiveArticles(index) {
                //Get list of articles to make visilbe
                var lst = $lstArticles.filter('[data-index="' + index + '"]');
                var lstHr = $lstHRs.filter('[data-index="' + index + '"]');

                //Set opacity to 0 but show articles
                TweenMax.to(lst, 0, { opacity: 0 });
                TweenMax.to(lstHr, 0, { opacity: 0 });
                lst.show();
                lstHr.show();

                //Change opacity to 1
                TweenMax.staggerFromTo(lst, 1, { opacity: 0 }, { opacity: 1 }, 0.3);
                TweenMax.staggerFromTo(lstHr, 1, { opacity: 0 }, { opacity: 1 }, 0.3);

                //Adjust panel's min-height so that the max height is maintained.  (keeps panel from jumping around as article sizes differ.)
                if (pnlTopNews.height() > minHeight) {
                    minHeight = pnlTopNews.height();
                }
                TweenMax.to(pnlTopNews, 0, { 'min-height': minHeight });
            }
            function nextSet() {
                //Begin animation sequence
                hideActiveArticles(currentN);

                //delayed call to run again
                TweenMax.delayedCall(sec, nextSet)
            }
        };

        //Run only if element exists
        if ($('.pnlTopNews').length > 0) { jsTopPodcasts(); }
    }
    catch (err) {
        console.log('ERROR: [jsTopPodcasts] ' + err.message);
    }
});