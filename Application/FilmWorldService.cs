using Application.Model;
using Infrastructure.Interface;
using Infrastructure.Model;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application
{
    public class FilmWorldService : RemoteMovieService
    {
        private string _apiBaseUrl { get; }
        private IMemoryCache _cache { get; }
        private string cacheKey = "filmWorldMovies";

        public FilmWorldService(IHttpClientService httpClientService, IMemoryCache cache, IOptions<AppSettings> appSettings) : base(httpClientService)
        {
            _apiBaseUrl = appSettings.Value.ApiBaseUrl;
            _cache = cache;
        }

        /// <summary>
        /// Retrieve movies from API, if API is not available, read movies from cache
        /// </summary>
        /// <returns></returns>
        public override async Task<IEnumerable<RemoteMovieBrief>> Get()
        {
            List<RemoteMovieBrief> movies;

            try
            {
                movies = (List<RemoteMovieBrief>) await base.Get();
                _cache.Set(cacheKey, movies);
            }
            catch (System.Exception e)
            {
                movies = _cache.Get<List<RemoteMovieBrief>>(cacheKey);
            }

            return movies;
        }

        /// <summary>
        /// Retrieve movie detail from API, if API is not available, read movie detail from cache
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public override async Task<RemoteMovieDetail> Get(string id)
        {
            RemoteMovieDetail remoteMovie;

            try
            {
                remoteMovie = await base.Get(id);
                _cache.Set($"{cacheKey}-{id}", remoteMovie);
            }
            catch (System.Exception e)
            {
                remoteMovie = _cache.Get<RemoteMovieDetail>($"{cacheKey}-{id}");
            }

            return remoteMovie;
        }

        public override string GetMovieUrl()
        {
            return $"{_apiBaseUrl}/filmworld/movies";
        }

        public override string GetMovieById(string id)
        {
            return $"{_apiBaseUrl}/filmworld/movie/{id}";
        }
    }
}
