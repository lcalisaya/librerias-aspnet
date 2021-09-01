using AutoMapper;
using AutoMapperLibrary.Models;

namespace AutoMapperLibrary.Profiles
{
    public class SingerProfile : Profile
    {
        public SingerProfile()
        {
            CreateMap<Singer, SingerViewModel>();
        }
    }
}
