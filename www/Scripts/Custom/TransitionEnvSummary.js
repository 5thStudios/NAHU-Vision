
function TransitionEnvSummary() {
    //Instantiate variables
    var msg = $(".fgEnvironmentSummary.msg");
    var btns = $(".fgEnvironmentSummary.btn");
    var btnInactive = $(".fgEnvironmentSummary.btn.grey");
    var btnActive = $(".fgEnvironmentSummary.btn.green");
    var isActive = false;
    var speed = .75;

    //Preset values
    TweenMax.set(btnActive, { autoAlpha: "0" });
    TweenMax.set(msg, { autoAlpha: "0" });


    //On hover: transitions to/from green version when mouse over/out.
    btns.mouseover(function () {
        if (isActive == true) {
            //transition back to inactive
            TweenMax.to(btnInactive, speed, { autoAlpha: "1" });
            TweenMax.to(btnActive, speed, { autoAlpha: "0" });
        }
        else {
            //transition to active
            TweenMax.to(btnInactive, speed, { autoAlpha: "0" });
            TweenMax.to(btnActive, speed, { autoAlpha: "1" });
        };

    }).mouseout(function () {
        if (isActive == true) {
            //transition to active
            TweenMax.to(btnInactive, speed, { autoAlpha: "0" });
            TweenMax.to(btnActive, speed, { autoAlpha: "1" });
        }
        else {
            //transition back to inactive
            TweenMax.to(btnInactive, speed, { autoAlpha: "1" });
            TweenMax.to(btnActive, speed, { autoAlpha: "0" });
        };
    });


    //On click, fade in background background.
    btns.click(function () {
        if (isActive == true) {
            //Hide message
            TweenMax.to(msg, speed, { autoAlpha: "0" });

            //Set boolean
            isActive = false;
        }
        else {
            //Make message visible
            TweenMax.to(msg, speed, { autoAlpha: "1" });

            //Set boolean
            isActive = true;
        };
    });
};