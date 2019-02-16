using Application.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Interface
{
    public interface IRemoteMovieService
    {
        Task<IEnumerable<RemoteMovieBrief>> Get();

        Task<RemoteMovieDetail> Get(string id);
    }
}
