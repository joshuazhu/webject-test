using Application.Model;
using System.Threading.Tasks;

namespace Application.Interface
{
    public interface IMovieService
    {
        Task<MovieGroupsByTitle> GetAllMovies();

        Task<MovieDetail> GetMovieDetail(int source, string id);
    }
}
