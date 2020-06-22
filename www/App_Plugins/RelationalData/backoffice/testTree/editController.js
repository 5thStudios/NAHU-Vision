angular.module("umbraco").controller("RelationalData.editController", function ($scope, $routeParams, testResource, notificationsService, navigationService) {
    $scope.loaded = false;

    if ($routeParams.id == -1) {
        $scope.test = {};
        $scope.loaded = true;
    }
    else {
        testResource.getById($routeParams.id).then(function (response) {
            $scope.test = response.data;
            $scope.loaded = true;
        });
    }

    $scope.save = function (test) {
        testResource.save(test).then(function (response) {
            $scope.test = response.data;
            navigationService.syncTree({ tree: 'testTree', path: ["-1", $scope.id], forceReload: true }).then(function (syncArgs) {
                navigationService.reloadNode(syncArgs.node);
            });   //Sync ('refresh') the tree!

            //navigationService.syncTree({ tree: 'testTree', path: ["-1"], forceReload: true });   //Sync ('refresh') the tree!
            notificationsService.success("Success", test.firstName + " " + test.lastName + " has been saved");
        });
    };
});