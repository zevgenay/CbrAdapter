using AutoMapper;

namespace CbrAdapter.Profiles
{
    public class CbrAdapterMappingProfle : Profile
    {
        public CbrAdapterMappingProfle()
        {
            CreateMap<Models.KeyRate, Database.Models.KeyRate>()
                .ForMember(dst => dst.Date, opt => opt.MapFrom(src => DateTime.SpecifyKind(src.Date, DateTimeKind.Utc)));

            CreateMap<Models.KeyRate[], ICollection<Database.Models.KeyRate>>();
        }
    }
}
