using AutoMapper;
using ProcessMappingApi.Models.Domain;
using ProcessMappingApi.Models.DTOs;

namespace ProcessMappingApi.Models
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CompanyProcess, CompanyProcessAreaDto>().ReverseMap();
            CreateMap<Area, AreaDto>().ReverseMap();
        }
    }
}
