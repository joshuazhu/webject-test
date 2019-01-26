app.controller('NavBarCtrl', function ($scope, $rootScope, $state, userService) {
    $scope.logOut = function () {
        userService.logout($rootScope.token).then(function (response) {
            if (response.message == "success") {
                $rootScope.isLogin = false;
                sessionStorage.token = "";
                $state.go("login");
            }
        });
    }
});