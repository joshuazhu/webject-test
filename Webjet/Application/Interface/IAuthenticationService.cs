using Application.Model;

namespace Application.Interface
{
    public interface IAuthenticationService
    {
        string GetToken(UserDTO user);

        bool ValidateToken(string token);
    }
}
