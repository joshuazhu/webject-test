using Application.Interface;
using Application.Model;
using System.Collections.Generic;

namespace Application
{
    public class AuthenticationService : IAuthenticationService
    {
        private Dictionary<string, string> _tokens = new Dictionary<string, string>();

        public string GetToken(UserDTO user)
        {
            var token = GenerateToken();
            if (!_tokens.ContainsKey(user.Username))
                _tokens.Add(user.Username, token);
            
            return _tokens[user.Username];
        }

        public bool ValidateToken(string token)
        {
            return _tokens.ContainsValue(token);
        }

        public string GenerateToken()
        {
            return "sjd1HfkjU83ksdsm3802k";
        }
    }
}
