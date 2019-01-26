app.controller('MoviesCtrl', function ($q, $scope, $state, $stateParams, movieService, localStorageService) {
    $scope.movies = {};

    function addMoviesToLocalStorage(movies, source) {
        if (source == "Cinema World")
            localStorage.cinemaWorldMovies = JSON.stringify(movies);

        if (source == "Film World")
            localStorage.filmWorldMovies = JSON.stringify(movies);
    }

    function addMovieResource(movies, source) {
        if (!movies)
            //if no movies from API, load movies from cache
            movies = localStorageService.loadMovie(source);
        else
            //update movies from API result
            addMoviesToLocalStorage(movies, source);


        angular.forEach(movies,
            function (movie, key) {
                if (!$scope.movies[movie.date]) {
                    $scope.movies[movie.date] = {};
                }
                $scope.movies[movie.date][source] = movie;
            });
    }

    function findCheapMovie() {
        //loop movies by date
        angular.forEach($scope.movies,
            function (movieData, key) {
                var cheapMovie = null;

                //loop movies in the same date
                angular.forEach(movieData,
                    function (movie, key) {
                        if (!cheapMovie) {
                            cheapMovie = movie;
                            return;
                        }

                        if (cheapMovie.price > movie.price)
                            cheapMovie = movie;
                    });
                cheapMovie.isCheapMovie = true;
            });
    }

    function init() {
        $scope.userName = $stateParams.userName;
        $q.all([
            movieService.cinemaWorldMovieService.movieList(),
            movieService.filmWorldMovieService.movieList()
        ]).then(function (response) {
            addMovieResource(response[0].data, "Cinema World");
            addMovieResource(response[1].data, "Film World");

            findCheapMovie();

            }, function (error) {
            // load data from cache
            addMovieResource(null, "Cinema World");
            addMovieResource(null, "Film World");
        });
    }
    init();

    $scope.loadMovieInfo = function (id, source) {
        $state.go("movie", { movieId: id, movieSource: source, userName: $stateParams.userName });
    }
});