app.controller("myNoteCtrl", function ($scope, $http) {

	$http({
		method: 'GET',
		url: 'api/note'
	}).then(function successCallback(response) {
		console.log("get success: " +response.data);
		$scope.message = response.data;
	}, function errorCallback(response) {
			console.log("get error: " +response);
	});


	$scope.left = function () { return 100 - $scope.message.length };
    $scope.clear = function () { $scope.message = ""; };
	$scope.save = function () {
		$http({
			method: 'POST',
			url: 'api/note',
			data: JSON.stringify({ text: $scope.message }),
		}
		).then(function successCallback(response) {
			console.log("post success: " +response.data);
		}, function errorCallback(response) {
				console.log("post error: " +response);
		});
		alert("已保存");
	};
});