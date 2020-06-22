//Manage monthly/annual enrollment type for "MonthlyMembershipAndRenewal.ascx"
$(document).ready(function () {
    try {
        jsMonthlyMembershipAndRenewal();

        function jsMonthlyMembershipAndRenewal() {
            //Instantiate variables
            var enrollmentType = $('input[type="radio"][name="enrollmentType"]');
            var $monthly = $('.monthly');
            var $oneTime = $('.oneTime');
            var $typeAmount = $('input[type="radio"][name="type_amount"]');

            //Set default to monthly
            $('input[type="radio"][name="enrollmentType"][value="monthly"]').prop("checked", true);
            switchEnrollmentType('monthly');

            //Call function when radiobutton is changed
            enrollmentType.change(function () {
                switchEnrollmentType(this.value);
            });

            //Switch enrollment type
            function switchEnrollmentType(type) {
                //Determine which column to show/hide
                if (type == 'monthly') {
                    $monthly.show();
                    $oneTime.hide();
                }
                else {
                    $monthly.hide();
                    $oneTime.show();
                }

                //Clear all
                $typeAmount.each(function () {
                    $(this).prop("checked", false);
                });
            };
        }
    }
    catch (err) {
        console.log('ERROR: [jsMonthlyMembershipAndRenewal] ' + err.message);
    }
});