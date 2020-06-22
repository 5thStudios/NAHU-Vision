angular
    .module('umbraco')
    .controller('SingleDayEventController', function ($scope) {
        //Instantiate variables
        var delimiter = '|';
        //$scope.info = "$scope: " + $scope.model.value;

        //All updated values are to be displayed on screen
        displayData();

        $scope.updated = function () {
            try
            {
                if ($scope.event.cbAllDayEvent == true) {
                    //All-day event.  Clear all values
                    $scope.event.ddlFromHour = '';
                    $scope.event.ddlFromMinute = '';
                    $scope.event.ddlToHour = '';
                    $scope.event.ddlToMinute = '';
                }

                //Save data to $scope
                $scope.model.value = [
                    $scope.event.cbAllDayEvent,
                    $scope.event.ddlFromHour,
                    $scope.event.ddlFromMinute,
                    $scope.event.ddlToHour,
                    $scope.event.ddlToMinute
                ].join(delimiter);
            } catch (err) {
                //Display error message
                $scope.info = "Error: " + err.toString();
            } 
        }
        

        function displayData() {
            if ($scope.model.value && (typeof $scope.model.value === "string")) {
                //Split data
                var splitVals = $scope.model.value.split(delimiter);
                //Convert boolean from string
                var allDayEvent = false;
                if (splitVals[0] == "true") {
                    allDayEvent = true;
                }
                //Get values from split and populate event
                $scope.event = {
                    cbAllDayEvent: allDayEvent, //splitVals[0]
                    ddlFromHour: splitVals[1],
                    ddlFromMinute: splitVals[2],
                    ddlToHour: splitVals[3],
                    ddlToMinute: splitVals[4]
                };
            }
        };

    });