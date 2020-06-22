
function TransitionBanner() {
    var multiplier = 4;
    var bannerImg01 = $(".bgPrimaryImage01");
    var bannerImg02 = $(".bgPrimaryImage02");
    var bannerImg03 = $(".bgPrimaryImage03");

    var tl = new TimelineMax({ repeat: -1, repeatDelay: (multiplier - 1), delay: multiplier });
    tl.to(bannerImg02, 1, { autoAlpha: "1" }, multiplier * 0); //blue
    tl.to(bannerImg03, 1, { autoAlpha: "1" }, multiplier * 1); //purple

    tl.to(bannerImg03, 1, { autoAlpha: "0" }, multiplier * 2); //purple
    tl.to(bannerImg02, 1, { autoAlpha: "0" }, multiplier * 2); //blue
};