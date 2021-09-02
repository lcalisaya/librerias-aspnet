using AutoMapper;
using AutoMapperLibrary.Models;

namespace AutoMapperLibrary.Profiles
{
    public class SingerProfile : Profile
    {
        public SingerProfile()
        {
            CreateMap<Singer, SingerViewModel>()
                .ForMember(dest => dest.ArtisticName, opt => opt.MapFrom(src => src.FamousName));

            CreateMap<SingerViewModel, Singer>()
                .ForMember(dest => dest.FamousName, opt => opt.MapFrom(src => src.ArtisticName));
        }
    }
}
