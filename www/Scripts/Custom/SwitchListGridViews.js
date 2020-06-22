//  SWITCH VIEW BETWEEN GRID & LIST
//========================================
$(function () {
    try {
        //Run only if element exists
        if ($('.listViewItem').length > 0) {jsSwitchListGridViews();}

        function jsSwitchListGridViews() {
            //Instantiate variables
            var viewBy = $('input[name=viewType]:checked').val();
            var $listViewItem = $('.listViewItem');
            var $gridViewItem = $('.gridViewItem');

            //Run once on load
            showProperList(viewBy)

            //If list view changes:
            $('input[name=viewType]').on('change', function () {
                //
                viewBy = $(this).val();
                console.log(viewBy);

                //
                showProperList(viewBy)
            });

            //Show/Hide view
            function showProperList(viewType) {
                if (viewType == "list") {
                    $listViewItem.show()
                    $gridViewItem.hide()
                }
                else if (viewType == "grid") {
                    $listViewItem.hide()
                    $gridViewItem.show()
                }
            }
        }
    }
    catch (err) {
        console.log('ERROR: [jsSwitchListGridViews] ' + err.message);
    }
});