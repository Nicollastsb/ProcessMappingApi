using ProcessMappingApi.Models.Domain;

namespace ProcessMappingApi.Interfaces.IRepositories
{
    public interface IAreaRepository
    {
        Task<List<Area>> GetAllAreaRepository();
        Task<Area> GetByIdAreaRepository(Guid id);
    }
}
