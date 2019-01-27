using Domain.Entity;

namespace Repository.Interface
{
    public interface IUserRepository
    {
        User Get(string username, string password);
    }
}
