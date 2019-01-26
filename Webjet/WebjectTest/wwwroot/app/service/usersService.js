app.factory('userService', function ($http) {
    var serviceBase = '/User';
    var userService = {
        login: function (user) {
            return $http.post(serviceBase + "/token", user).then(function (response) {
                return response.data;
            });
        }
    };

    return userService;
});

