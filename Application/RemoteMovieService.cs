using Application.Interface;
using Application.Model;
using Infrastructure.Interface;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application
{
    public abstract class RemoteMovieService : IRemoteMovieService
    {
        private IHttpClientService _httpClientService { get; }

        public RemoteMovieService(IHttpClientService httpClientService)
        {
            _httpClientService = httpClientService;
        }

        public virtual async Task<IEnumerable<RemoteMovieBrief>> Get()
        {
            var apiUrl = GetMovieUrl();
            var response = await _httpClientService.GetData<RemoteMovieAll>(apiUrl);
            return response.Movies;
        }

        public virtual async Task<RemoteMovieDetail> Get(string id)
        {
            var apiUrl = GetMovieById(id);
            return await _httpClientService.GetData<RemoteMovieDetail>(apiUrl);
        }

        public abstract string GetMovieUrl();


        public abstract string GetMovieById(string id);

    }
}
