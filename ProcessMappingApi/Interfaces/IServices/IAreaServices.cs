using ProcessMappingApi.Models.Domain;
using ProcessMappingApi.Models.DTOs;

namespace ProcessMappingApi.Repositories.Interfaces
{
    public interface IAreaServices
    {
        Task<List<AreaDto>> GetAllAreaServices();
        Task<AreaDto> GetByIdAreaServices(Guid id);
    }
}
