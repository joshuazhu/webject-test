app.factory('movieService', function ($http) {
    var serviceBase = '/api';

    var populateAuthTokenToHeader = function () {
        var token = localStorage.token;

        if (token) {
            $http.defaults.headers.common.Authorization = token;
        }
    }

    var cinemaWorldMovieService = {
        movieList: function () {
            populateAuthTokenToHeader();

            return $http.get(serviceBase + "/CinemaWorldMovie/movies").then(function (response) {
                return response.data;
            });
        },

        movieDetail: function(id) {
            populateAuthTokenToHeader();

            return $http.get(serviceBase + "/CinemaWorldMovie/movies/" + id).then(function (response) {
                return response.data;
            });
        }
    };

    var filmWorldMovieService = {
        movieList: function () {
            populateAuthTokenToHeader();

            return $http.get(serviceBase + "/FilmWorldMovie/movies").then(function (response) {
                return response.data;
            });
        },

        movieDetail: function (id) {
            populateAuthTokenToHeader();

            return $http.get(serviceBase + "/FilmWorldMovie/movies/" + id).then(function (response) {
                return response.data;
            });
        }
    };

    return {
        cinemaWorldMovieService: cinemaWorldMovieService,
        filmWorldMovieService: filmWorldMovieService
    };
});

