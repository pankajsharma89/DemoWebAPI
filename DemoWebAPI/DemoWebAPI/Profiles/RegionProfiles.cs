using AutoMapper;

namespace DemoWebAPI.Profiles
{
    public class RegionProfiles : Profile
    {
        public RegionProfiles()
        {
            CreateMap<Models.Domain.Region, Models.DTO.Region>()
                .ForMember(dest=>dest.RegionCode,options => options.MapFrom(src=>src.Code));
        }
    }
}
