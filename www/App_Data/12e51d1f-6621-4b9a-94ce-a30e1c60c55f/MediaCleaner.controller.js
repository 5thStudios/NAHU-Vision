angular.module("umbraco").controller("MediaCleaner.MediaCleanerController",
    function ($scope, $http, $timeout, notificationsService, userService) {
        $scope.Refresh = function (userService) {
            startMediaCleaner($scope, $http, $timeout, notificationsService, false);
        };
        userService.getCurrentUser().then(function (curUser) {
            if (curUser.userType === "admin") {
                $scope.RefreshAndDelete = function () {
                    startMediaCleaner($scope, $http, $timeout, notificationsService, true);
                }
                $scope.isAdmin = true;
            }
            else {
                $scope.isAdmin = false;
            }
        });
        $scope.ShowResults = false;
    }
);

var timer; //Global timer variable

function startMediaCleaner($scope, $http, $timeout, notificationsService, DeleteObjects) {
    if (DeleteObjects && !confirm("Delete orphaned filees, broken media items and empty folders?"))
    {
        return;
    }
    $scope.DisabledRefresh = true;
    $http.get('backoffice/MediaCleaner/Dashboard/getStart?DeleteObjects=' + DeleteObjects, { timeout: 2000 }).then(function (response) {
        if (response.data) {
            getMediaCleanerInfo($scope, $http, $timeout, notificationsService);
        }
        else {
            notificationsService.add({
                headline: 'Error starting MediaCleaner.',
                message: "Look at the log files for more details.",
                type: 'error'
            });
        }
    }, function (fallback) {
        if (fallback.status === 0) {
            //Timeout, the server is working
            notificationsService.add({
                headline: 'Data update started',
                message: 'The server is updating the data, please wait',
                type: 'success'
            });
            timer = $timeout(function refresh() {
                getMediaCleanerInfo($scope, $http, $timeout, notificationsService);
                timer = $timeout(refresh, 2000);
            }, 2000);
            timer();
        }
        else {
            notificationsService.add({
                headline: 'Error starting MediaCleaner: ' + fallback.status,
                message: fallback.statusText,
                type: 'error'
            });
            $scope.DisabledRefresh = false;
        }
    });
}

function getMediaCleanerInfo($scope, $http, $timeout, notificationsService) {
    $http.get('backoffice/MediaCleaner/Dashboard/getInfo').then(function (response) {
        if (response.data.InProgress) {
            //Still working
            $scope.ShowProgress = true;
            $scope.ShowResults = false;
            $scope.ShowComputing = false;
            $scope.ShowDeleting = response.data.DeletionInProgress;
            $scope.progProcessedMediaItems = response.data.ProcessedMediaItems;
            $scope.progTotalMediaItems = response.data.TotalMediaItems;
            $scope.progTotalContentItems = response.data.TotalContentItems;
            if (response.data.ProcessedMediaItems == response.data.TotalMediaItems && response.data.TotalMediaItems != 0)
            {
                $scope.ShowComputing = true;
            }
        }
        else {
            //Results are ready        
            if (response.data.HasError) {
                notificationsService.add({
                    headline: 'Error updating the data',
                    message: response.data.ErrorDescription,
                    type: 'error'
                });
                $scope.ShowResults = false;
                $scope.DisabledRefresh = false;
                $scope.ShowProgress = false;
            }
            else {
                $scope.TotalFiles = response.data.TotalFiles;
                $scope.TotalFileSize = response.data.TotalFileSize;
                $scope.TotalMediaItems = response.data.TotalMediaItems;
                $scope.TotalContentItems = response.data.TotalContentItems;
                $scope.FileList = response.data.FileList;
                $scope.OrphanFileCount = response.data.OrphanFileCount;
                $scope.OrphanFileSize = response.data.OrphanFileSize;
                $scope.EmptyFolders = response.data.EmptyFolders;
                $scope.TotalFolders = response.data.TotalFolders;
                $scope.updateTime = response.data.UpdateTime;
                $scope.processTime = response.data.ProcessTime;
                $scope.OrphanFolderCount = response.data.OrphanFolderCount;
                $scope.BrokenMediaCount = response.data.BrokenMediaCount;
                $scope.BrokenMedia = response.data.BrokenMedia;                
                notificationsService.add({
                    headline: 'Data updated',
                    message: 'The data on the dashboard has been updated',
                    type: 'success'
                });
            }
            $timeout.cancel(timer);
            $scope.ShowResults = true;
            $scope.DisabledRefresh = false;
            $scope.ShowProgress = false;
        }
    }, function (fallback) {
        notificationsService.add({
            headline: 'Error getting the status of MediaCleaner: ' + fallback.status,
            message: fallback.statusText,
            type: 'error'
        });
    });
}