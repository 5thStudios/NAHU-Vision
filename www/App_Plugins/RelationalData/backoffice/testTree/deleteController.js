angular.module("umbraco").controller("RelationalData.deleteController", function ($scope, testResource, notificationsService, navigationService) {

    $scope.delete = function (id) {
        testResource.deleteById(id).then(function () {
            navigationService.hideNavigation();
            navigationService.syncTree({ tree: 'testTree', path: ["-1", $scope.id], forceReload: true }).then(function (syncArgs) {
                navigationService.reloadNode(syncArgs.node);
            });   //Sync ('refresh') the tree!

            //navigationService.syncTree({ tree: 'testTree', path: ["-1"], forceReload: true });   //Sync ('refresh') the tree!
            notificationsService.success("Successfully deleted");
        });
    };

    $scope.cancelDelete = function () {
        navigationService.hideNavigation();
    };
});