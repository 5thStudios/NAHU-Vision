angular.module("umbraco").controller("My.ImageCropsController", function ($scope) {

    if ($scope.model.value == null) {
        $scope.model.value = 'None';
    }

    //could read crops from defaultConfig
	$scope.crops = [
		{ Name: 'None' },
		{ Name: 'Photo Horizontal [300px × 200px]' },
		{ Name: 'Photo Vertical [200px × 300px]' },
		{ Name: 'Square Image [250px × 250px]' },
		{ Name: 'Home Page Banner [1000px × 358px]' },
		{ Name: 'Secondary Page Banner [1000px × 154px]' },
		{ Name: 'Featured Thumbnail [159px × 118px]' },
		{ Name: 'Success Story Photo [300px × 200px]' },
		{ Name: 'Head Shot Portrait [200px × 276px]' },
		{ Name: 'List Image [110px × 120px]' }
	];
});




//$scope.crops = [
//    { Name: 'None' },
//    { Name: 'Photo Horizontal [300px × 200px]' },
//    { Name: 'Photo Vertical [200px × 300px]' },
//    { Name: 'Square Image [250px × 250px]' },
//    { Name: 'Home Page Banner [1000px × 358px]' },
//    { Name: 'Secondary Page Banner [1000px × 154px]' },
//    { Name: 'Featured Thumbnail [159px × 118px]' },
//    { Name: 'Success Story Photo [300px × 200px]' },
//    { Name: 'Head Shot Portrait [200px × 276px]' },
//    { Name: 'List Image [110px × 120px]' }
//];




//$scope.crops = [
//{ Name: 'None' },
//{ Name: 'Photo Horizontal [300px × 200px]' },
//{ Name: 'Photo Vertical' },
//{ Name: 'Square Image' },
//{ Name: 'Home Page Banner' },
//{ Name: 'Secondary Page Banner' },
//{ Name: 'Featured Thumbnail' },
//{ Name: 'Success Story Photo' },
//{ Name: 'Head Shot Portrait' },
//{ Name: 'List Image' }
//];