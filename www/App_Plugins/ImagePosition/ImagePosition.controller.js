angular.module("umbraco").controller("My.ImagePositionController", function ($scope) {
    if ($scope.model.value == null) {
        $scope.model.value = 'None';
    }

    //could read positions from defaultConfig
    $scope.positions = [
        { Name: 'None' },
        { Name: 'Left' },
        { Name: 'Center' },
        { Name: 'Right' }
    ];

});


