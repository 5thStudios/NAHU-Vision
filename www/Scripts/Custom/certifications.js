$(function () {
    try {
        //Run only if element exists
        if ($('.CertificationPg').length > 0) { jsCertifications(); }

        function jsCertifications() {
            //Instantiate variables
            var viewBy;
            var $courseType1 = $('#courseType1 input');
            var $courseType2 = $('#courseType2 input');
            var $onlineData = $('.online');
            var $classroomData = $('.classroom');
            var hfldOnline = $('.CertificationPg .hiddenFields .hfldOnline').val().toLowerCase() == 'true' ? true : false;
            var hfldClassroom = $('.CertificationPg .hiddenFields .hfldClassroom').val().toLowerCase() == 'true' ? true : false;

            //console.log('hfldOnline: ' + hfldOnline);
            //console.log('hfldClassroom: ' + hfldClassroom);

            //Run once on load
            loadSetup(hfldOnline, hfldClassroom);
            showProperView(viewBy, true)

            //If list view changes:
            $('input[name=courseType1]').on('change', function () {
                //Obtain value of selected radio button
                viewBy = $(this).val();

                //Show proper data
                showProperView(viewBy)
            });
            $('input[name=courseType2]').on('change', function () {
                //Obtain value of selected radio button
                viewBy = $(this).val();

                //Show proper data
                showProperView(viewBy)
            });


            function loadSetup(showOnline, showClassroom) {
                ////console.log('showOnline: ' + showOnline);
                ////console.log('showClassroom: ' + showClassroom);

                if (showOnline == false && showClassroom == false) {
                    //Hide both
                    $('.courseTypes').hide();
                    $onlineData.hide();
                    $classroomData.hide();
                    //Set name of checked rb
                    viewBy = '';
                    //console.log('Hide all options');
                }
                else if (showOnline == false) {
                    //Hide Online options

                    //Set inactive option
                    $courseType1.filter('[value="online"]').attr('disabled', true);
                    $courseType2.filter('[value="online"]').attr('disabled', true);

                    //Set active option
                    $courseType1.filter('[value="classroom"]').prop("checked", true);
                    $courseType2.filter('[value="classroom"]').prop("checked", true);
                    //Set name of checked rb
                    viewBy = 'classroom';
                    //console.log('Hide online options');
                }
                else if (showClassroom == false) {
                    //Hide Classroom options

                    //Set inactive option
                    $courseType1.filter('[value="classroom"]').attr('disabled', true);
                    $courseType2.filter('[value="classroom"]').attr('disabled', true);

                    //Set active option
                    $courseType1.filter('[value="online"]').prop("checked", true);
                    $courseType2.filter('[value="online"]').prop("checked", true);
                    //Set name of checked rb
                    viewBy = 'online';
                    //console.log('Hide classroom options');
                }
                else if (showOnline == true && showClassroom == true) {
                    //Set name of checked rb
                    viewBy = 'online';
                    //console.log('Show all options');

                }

                ////Get name of checked rb
                //viewBy = $('input[name=courseType1]:checked').val();
            }
            function showProperView(viewType, firstRun) {

                //console.log('Viewtype: ' + viewType);

                //Ensure both radio button groups match.
                if (!firstRun) {
                    $courseType1.filter(function () { return this.value == viewType }).prop("checked", true);
                    $courseType2.filter(function () { return this.value == viewType }).prop("checked", true);
                }

                //Show/Hide proper data
                if (viewType == "online") {
                    $onlineData.show();
                    $classroomData.hide();
                }
                else if (viewType == "classroom") {
                    $onlineData.hide();
                    $classroomData.show();
                }
            }
        };
    }
    catch (err) {
        console.log('ERROR: [jsCertifications] ' + err.message);
    }
});