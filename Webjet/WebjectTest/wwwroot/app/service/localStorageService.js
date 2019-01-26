app.factory('localStorageService', function () {
    var loadMovie = function(source) {
        if (source == "Cinema World" && localStorage.cinemaWorldMovies) {
            var movies = JSON.parse(localStorage.cinemaWorldMovies);
            movies.map(x => x.isLoadFromCache = true);
            return movies;
        }

        if (source == "Film World" && localStorage.filmWorldMovies) {
            var movies = JSON.parse(localStorage.filmWorldMovies);
            movies.map(x => x.isLoadFromCache = true);
            return movies;
        }
    }

    return {
        loadMovie: loadMovie
    }
});
