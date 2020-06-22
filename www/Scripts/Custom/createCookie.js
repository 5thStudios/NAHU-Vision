function createCookie() {
    try {
        //Variables
        var shadedBackground = $('.shadedBackground');
        var cookieName = $('#hfldCookieName').val();
        var culture = $('#hfldCulture').val();

        //set cookie
        Cookies.set(cookieName, culture, { expires: 6000 });

        //Hide violator.
        shadedBackground.toggle();
    }
    catch (err) {
        console.log('ERROR: [createCookie] ' + err.message);
    }
};