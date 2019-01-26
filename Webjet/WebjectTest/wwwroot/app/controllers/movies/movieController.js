app.controller('MovieCtrl', function ($scope, $state, $stateParams, movieService, localStorageService) {
    var movieId = $stateParams.movieId;
    var movieSource = $stateParams.movieSource;
    $scope.movie = {}

    $scope.goBack = function () {
        $state.go("movies", { userName: $stateParams.userName });
    }

    function init() {
        if (movieSource == "Film World") {
            movieService.filmWorldMovieService.movieDetail(movieId).then(function (response) {
                var movieDetail = response.data;

                if (!response.success) {
                    var movies = localStorageService.loadMovie("Film World");
                    movieDetail = movies.filter(x => x.id == movieId)[0];
                }

                $scope.movie = movieDetail;

            }, function (error) {
                var movies = localStorageService.loadMovie("Film World");
                $scope.movie = movies.filter(x => x.id == movieId)[0];
            });
        }

        if (movieSource == "Cinema World") {
            movieService.cinemaWorldMovieService.movieDetail(movieId).then(function (response) {
                var movieDetail = response.data;

                if (!response.success) {
                    var movies = localStorageService.loadMovie("Cinema World");
                    movieDetail = movies.filter(x => x.id == movieId)[0];
                }

                $scope.movie = movieDetail;

            }, function (error) {
                var movies = localStorageService.loadMovie("Cinema World");
                $scope.movie = movies.filter(x => x.id == movieId)[0];
            });
        }
    }

    init();
});