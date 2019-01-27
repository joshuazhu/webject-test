using Application.Interface;
using Application.Model;
using Microsoft.AspNetCore.Mvc;
using WebjectTest.Models;

namespace WebjectTest.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserService _userService { get; set; }

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("token")]
        public ActionResult<ResponseViewModel<string>> Post([FromBody] UserDTO user)
        {
            var token = _userService.AuthenticateUser(user);

            return !string.IsNullOrEmpty(token) 
                ? new ResponseViewModel<string> { Success = true, Data = token, Message = "" } 
                : new ResponseViewModel<string> { Success = false, Data = "", Message = "Invalid username or password" };
        }
    }
}
