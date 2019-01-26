using Application.Model;
using Domain.Entity;

namespace Application.Profile
{
    public class ApplicationMappingProfile : AutoMapper.Profile
    {
        public ApplicationMappingProfile()
        {
            CreateMap<UserDTO, User>().ReverseMap();
        }
    }
}
