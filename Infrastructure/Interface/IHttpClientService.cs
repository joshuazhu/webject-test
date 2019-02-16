using System.Threading.Tasks;

namespace Infrastructure.Interface
{
    public interface IHttpClientService
    {
        Task<T> GetData<T>(string url);
    }
}
