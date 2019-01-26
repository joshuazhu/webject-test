using Application.Interface;
using Application.Model;
using AutoMapper;
using Repository.Interface;

namespace Application
{
    public class UserService : IUserService
    {
        private IUserRepository _userRepository { get; set; }
        private IAuthenticationService _authenticationService { get; set; }
        private IMapper _mapper { get; set; }

        public UserService(IUserRepository userRepository, IAuthenticationService authenticationService, IMapper mapper)
        {
            _userRepository = userRepository;
            _authenticationService = authenticationService;
            _mapper = mapper;
        }

        public string AuthenticateUser(UserDTO userDto)
        {
            var user = _mapper.Map<UserDTO>(_userRepository.Get(userDto.Username, userDto.Password));

            if (user != null)
            {
                return _authenticationService.GetToken(user);
            }

            return "";
        }
    }
}
