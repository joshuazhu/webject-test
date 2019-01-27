var app = angular.module('app', ['ui.bootstrap', 'ui.router', 'ngRoute'])
    .config(function ($stateProvider, $urlRouterProvider) {
        $stateProvider
            .state('movies',
            {
                url: '/movies/:userName',
                templateUrl: 'app/views/movies/movies.html',
                controller: 'MoviesCtrl'
            })
            .state('movie',
            {
                url: '/movie',
                params: {
                    movieId: null,
                    movieSource: null,
                    userName: null
                },
                templateUrl: 'app/views/movies/movie.html',
                controller: 'MovieCtrl'
            })
            .state('login',
            {
                url: '/login',
                templateUrl: 'app/views/login/login.html',
                controller: 'LoginCtrl'
            });

        $urlRouterProvider.otherwise('/login');
    });

angular.
    module('exceptionOverwrite', []).
    factory('$exceptionHandler', ['$log', 'logErrorsToBackend', function ($log, logErrorsToBackend) {
        return function myExceptionHandler(exception, cause) {
            logErrorsToBackend(exception, cause);
            $log.warn(exception, cause);
        };
    }]);





