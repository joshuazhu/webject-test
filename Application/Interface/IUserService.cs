using Application.Model;

namespace Application.Interface
{
    public interface IUserService
    {
        string AuthenticateUser(UserDTO userDto);
    }
}
