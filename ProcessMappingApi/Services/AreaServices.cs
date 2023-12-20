using AutoMapper;
using ProcessMappingApi.Interfaces.IRepositories;
using ProcessMappingApi.Models.Domain;
using ProcessMappingApi.Models.DTOs;
using ProcessMappingApi.Repositories.Interfaces;

namespace ProcessMappingApi.Services
{
    public class AreaServices : IAreaServices
    {
        private readonly IMapper _mapper;
        private readonly IAreaRepository _areaRepository;
        public AreaServices(IMapper mapper, IAreaRepository areaRepository)
        {
            _mapper = mapper;
            _areaRepository = areaRepository;
        }

        public async Task<List<AreaDto>> GetAllAreaServices()
        {            
            var listAreas = await _areaRepository.GetAllAreaRepository();
            var area = _mapper.Map<List<AreaDto>>(listAreas);
            
            return area;
        }

        public async Task<AreaDto> GetByIdAreaServices(Guid id)
        {
            var area = await _areaRepository.GetByIdAreaRepository(id);
            var areaDto = _mapper.Map<AreaDto>(area);

            return areaDto;
        }
    }
}
