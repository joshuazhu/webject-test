using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Application.Interface;
using Application.Model;
using AutoMapper;

namespace Application
{
    public class MovieService : IMovieService
    {
        private CinemaWorldService _cinemaWorldService { get; set; }
        private FilmWorldService _filmWorldService { get; set; }
        private IMapper _mapper { get; set; }

        public MovieService(CinemaWorldService cinemaWorldService, FilmWorldService filmWorldService, IMapper mapper)
        {
            _mapper = mapper;
            _cinemaWorldService = cinemaWorldService;
            _filmWorldService = filmWorldService;
        }

        public async Task<MovieGroupsByTitle> GetAllMovies()
        {
            var cinemaWorldMovies = await GetMovieBriefs(_cinemaWorldService);
            var filmWorldMovies = await GetMovieBriefs(_filmWorldService);

            return GetGroupByTitleMovies(cinemaWorldMovies, filmWorldMovies);
        }

        public async Task<MovieDetail> GetMovieDetail(int source, string id)
        {
            switch (source)
            {
                case (int)SourceEnum.CinemaWorld:
                    return await GetMovieDetail(_cinemaWorldService, id);
                case (int)SourceEnum.FilmWorld:
                    return await GetMovieDetail(_filmWorldService, id);
            }

            return null;
        }

        /// <summary>
        /// Get movies that are grouped by movie title
        /// </summary>
        /// <param name="cinemaWorldMovieBriefs"></param>
        /// <param name="filmWorldMovieBriefs"></param>
        /// <returns>
        /// {
        ///     "movieTitle": 
        ///     {
        ///         "source": 
        ///         {
        ///             "CinemaWorldMoviesBreBriefs": {},
        ///             "FilmWorldMovieBriefs": {}
        ///         }
        ///     }
        /// }
        /// </returns>
        private MovieGroupsByTitle GetGroupByTitleMovies(List<MovieBrief> cinemaWorldMovieBriefs, List<MovieBrief> filmWorldMovieBriefs)
        {
            var mergedMovies = new Dictionary<string, MoviesBriefInSources>();

            foreach (var movieBrief in cinemaWorldMovieBriefs)
            {
                mergedMovies.Add(movieBrief.Title, new MoviesBriefInSources
                {
                    CinemaWorldMoviesBreBriefs = movieBrief
                });
            }

            foreach (var movieBrief in filmWorldMovieBriefs)
            {
                if (!mergedMovies.ContainsKey(movieBrief.Title))
                {
                    mergedMovies.Add(movieBrief.Title, new MoviesBriefInSources
                    {
                        FilmWorldMovieBriefs = movieBrief
                    });
                }
                else
                {
                    var movieInExistingTitle = mergedMovies[movieBrief.Title];

                    movieInExistingTitle.FilmWorldMovieBriefs = movieBrief;
                }

            }

            return new MovieGroupsByTitle
            {
                Sources = mergedMovies
            };
        }

        private async Task<MovieDetail> GetMovieDetail(RemoteMovieService remoteMovieService, string id)
        {
            return _mapper.Map<MovieDetail>(await remoteMovieService.Get(id));
        }

        private async Task<List<MovieBrief>> GetMovieBriefs(RemoteMovieService remoteMovieService)
        {
            var movieBriefs = await remoteMovieService.Get();

            if (movieBriefs == null)
                return new List<MovieBrief>();

            var movies = _mapper.Map<List<MovieBrief>>(movieBriefs);

            //read movie price using multi threads
            var tasks = movies.Select(movie => Task.Run(() => PopulatePriceAndSourceForMovieBrief(remoteMovieService, movie))).ToList();

            await Task.WhenAll(tasks);

            return movies;
        }

        private async Task PopulatePriceAndSourceForMovieBrief(RemoteMovieService remoteMovieService,
            MovieBrief movieBrief)
        {
            var movieDetail = await GetMovieDetail(remoteMovieService, movieBrief.Id);

            if (movieDetail != null)
            {
                movieBrief.Price = movieDetail.Price;
            }

            if (remoteMovieService.GetType() == typeof(CinemaWorldService))
            {
                movieBrief.Source = SourceEnum.CinemaWorld;
            }

            if (remoteMovieService.GetType() == typeof(FilmWorldService))
            {
                movieBrief.Source = SourceEnum.FilmWorld;
            }
        }
    }
}
