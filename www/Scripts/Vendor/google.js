
var googletag = googletag || {};
googletag.cmd = googletag.cmd || [];





googletag.cmd.push(function () {
    googletag.defineSlot('/14444846/NAHU_NAHU.org_Footer_728x90', [728, 90], 'div-gpt-ad-1503081911370-0').addService(googletag.pubads());
    googletag.defineSlot('/14444846/NAHU_NAHU.org_LargeBanner_970x250', [970, 250], 'div-gpt-ad-1503081911370-1').addService(googletag.pubads());
    googletag.defineSlot('/14444846/NAHU_NAHU.org_Rectangle1_300x250', [300, 250], 'div-gpt-ad-1503081911370-2').addService(googletag.pubads());
    googletag.defineSlot('/14444846/NAHU_NAHU.org_Rectangle2_300x250', [300, 250], 'div-gpt-ad-1503081911370-3').addService(googletag.pubads());
    googletag.pubads().enableSingleRequest();
    googletag.enableServices();
});





googletag.cmd.push(function () {

    var gptAdSlots = [];

    gptAdSlots.push(googletag.defineSlot('/3790/Flex8:1', [1, 1], 'div-gpt-flex-ad').addService(googletag.pubads()));
    gptAdSlots.push(googletag.defineSlot('/3790/Fixed728x90', [728, 90], 'div-gpt-fixed-ad').addService(googletag.pubads()));
    gptAdSlots.push(googletag.defineSlot('/3790/Static8:1', [1, 1], 'div-gpt-static-ad').addService(googletag.pubads()));
    gptAdSlots.push(googletag.defineSlot('/3790/Static728x90', [728, 90], 'div-gpt-static300-ad').addService(googletag.pubads()));

    googletag.pubads().enableSingleRequest();
    googletag.enableServices();

    /*

setInterval(function(){
    googletag.pubads().refresh([gptAdSlots[0]]);
}, 20000);
*/
});





var _gaq = _gaq || [];
_gaq.push(['_setAccount', 'UA-3569073-10']);
_gaq.push(['_trackPageview']);
(function () {
    var ga = document.createElement('script'); ga.type = 'text/javascript'; ga.async = true;
    ga.src = ('https:' == document.location.protocol ? 'https://ssl' : 'http://www') + '.google-analytics.com/ga.js';
    var s = document.getElementsByTagName('script')[0]; s.parentNode.insertBefore(ga, s);
})();