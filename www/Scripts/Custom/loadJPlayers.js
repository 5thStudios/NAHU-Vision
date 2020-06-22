//2016-08-25
//This code is used to loop thru each player object and add controls and audio to each player.
//The files needed to run this are:
//  -jplayer.ascx
//  -sermon.ascx
//  -sermons.master
//  -jquery.jplayer.min.js
//  -jplayer.css


$(window).load(function () {
    try {
        jsLoadJPlayers();

        function jsLoadJPlayers() {
            //Get list of all players
            var $jplayers = $('.jplayer');

            //Loop thru each player and set audio playback.
            $jplayers.each(function () {
                //Instantiate variables
                var jplayer = $(this);
                var hfldAudioUrl = jplayer.find('.hfldAudioUrl').val();
                var hfldContainerName = jplayer.find('.hfldContainerName').val();
                var jqueryplayer = jplayer.find('.jp-jplayer');

                try {
                    //Setup player with sermon audio.
                    jqueryplayer.jPlayer({
                        ready: function () {
                            $(this).jPlayer("setMedia", {
                                title: "",
                                mp3: hfldAudioUrl
                            });
                        },
                        cssSelectorAncestor: "." + hfldContainerName,
                        swfPath: "/scripts",
                        supplied: "mp3",
                        useStateClassSkin: true,
                        autoBlur: false,
                        smoothPlayBar: true,
                        keyEnabled: true,
                        remainingDuration: true,
                        toggleDuration: true
                    });

                }
                catch (err) {
                    //Add error message to console log
                    console.log(err.message);
                }

            });
        };
    }
    catch (err) {
        console.log('ERROR: ' + err.message);
    }
});