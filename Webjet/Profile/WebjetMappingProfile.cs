using System;
using Application.Utils;
using Domain.Entity;
using Domain.Enumeration;
using WebjectTest.Models;

namespace WebjectTest.Profile
{
    public class WebjetMappingProfile : AutoMapper.Profile
    {
        public WebjetMappingProfile()
        {
            CreateMap<Movie, MoviewViewModel>()
                .ForMember(dest => dest.Genre, src => src.MapFrom(x => Enum.GetName(typeof(MovieGenre), x.Genre)))
                .ForMember(dest => dest.SessionTime, src => src.MapFrom(x => x.SessionTime.ToWebjectLongDateTime()))
                .ForMember(dest => dest.Date, src => src.MapFrom(x => x.SessionTime.ToWebjectShortDateTime()));
        }
    }
}
