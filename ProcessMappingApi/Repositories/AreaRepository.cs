using Microsoft.EntityFrameworkCore;
using ProcessMappingApi.Data;
using ProcessMappingApi.Interfaces.IRepositories;
using ProcessMappingApi.Models.Domain;

namespace ProcessMappingApi.Repositories
{
    public class AreaRepository : IAreaRepository
    {
        private readonly ApiDbContext _context;

        public AreaRepository(ApiDbContext context)
        {
            _context = context;
        }

        public async Task<List<Area>> GetAllAreaRepository()
        {
            return await _context.Areas.ToListAsync();
        }

        public async Task<Area> GetByIdAreaRepository(Guid id)
        {
            return await _context.Areas.FirstOrDefaultAsync(p => p.Id == id);
        }
    }
}
