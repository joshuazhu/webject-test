using System.Threading.Tasks;
using Application.Interface;
using Microsoft.AspNetCore.Http;

namespace WebjectTest.Middleware
{
    public class AuthenticationMiddleware
    {
        private readonly RequestDelegate _next;
        private IAuthenticationService _authenticationService { get; set; }

        public AuthenticationMiddleware(RequestDelegate next, IAuthenticationService authenticationService)
        {
            _next = next;
            _authenticationService = authenticationService;
        }

        public async Task Invoke(HttpContext context)
        {
            string tokenHeader = context.Request.Headers["Authorization"];
            if (tokenHeader != null)
            {
                if (_authenticationService.ValidateToken(tokenHeader))
                {
                    await _next.Invoke(context);
                }
                else
                {
                    context.Response.StatusCode = 401;
                }
            }
            else
            {
                context.Response.StatusCode = 401;
            }
        }
    }
}
