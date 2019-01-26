app.controller('LoginCtrl', function ($scope, $rootScope, $state, $http, userService) {
    $scope.isLoginFailed = false;
    $scope.isLoginProcessing = false;

    $scope.login = function () {
        if ($scope.userName && $scope.password) {
            $scope.isLoginProcessing = true;
            var user = { UserName: $scope.userName, Password: $scope.password };

            userService.login(user).then(function(response) {
                if (response.success) {
                    $rootScope.isUserLogin = true;
                    localStorage.token = response.data;
                    $scope.isLoginFailed = false;
                    $state.go("movies", { userName: $scope.userName });
                } else {
                    $scope.isLoginFailed = true;
                    $rootScope.isUserLogin = false;
                }
                $scope.isLoginProcessing = false;
            });
        }
    }
    
});