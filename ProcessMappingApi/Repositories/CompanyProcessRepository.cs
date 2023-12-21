using Microsoft.EntityFrameworkCore;
using ProcessMappingApi.Data;
using ProcessMappingApi.Interfaces.IRepositories;
using ProcessMappingApi.Models.Domain;

namespace ProcessMappingApi.Repositories
{
    public class CompanyProcessRepository : ICompanyProcessRepository
    {
        private readonly ApiDbContext _context;

        public CompanyProcessRepository(ApiDbContext context)
        {
            _context = context;
        }

        public async Task<CompanyProcess> CreateCompanyProcessRepository(CompanyProcess companyProcess)
        {
            companyProcess.ModificationDate = DateTime.Now;
            companyProcess.SubProcesses.ToList().ForEach(p => { p.ModificationDate = DateTime.Now; p.AreaId = companyProcess.AreaId; p.Area = null; }) ;
            companyProcess.Area = null;
            _context.CompanyProcesses.Add(companyProcess);
            await _context.SaveChangesAsync();

            return companyProcess;
        }

        public async Task<List<CompanyProcess>> GetAllMainCompanyProcessRepository()
        {
            return await _context.CompanyProcesses.Include(p=>p.Area).Where(p => p.CompanyProcessId == null).ToListAsync();
        }

        public async Task<CompanyProcess> GetByIdCompanyProcessRepository(Guid id)
        {
            return await _context.CompanyProcesses.Include(p=>p.SubProcesses).Include(p => p.Area).FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<CompanyProcess> UpdateCompanyProcessRepository(Guid id, CompanyProcess companyProcess)
        {
            var oldCompanyProcess = await GetByIdCompanyProcessRepository(id);
            oldCompanyProcess.Name = companyProcess.Name;
            oldCompanyProcess.Description = companyProcess.Description;
            oldCompanyProcess.Order = companyProcess.Order;
            oldCompanyProcess.ModificationDate = DateTime.Now;
            _context.CompanyProcesses.Update(oldCompanyProcess);
            await _context.SaveChangesAsync();

            return oldCompanyProcess;
        }

        public async Task DeleteCompanyProcessRepository(Guid id)
        {
            var companyProcess = await GetByIdCompanyProcessRepository(id);

            if (companyProcess == null)
                throw new Exception("Elemento não encontrado");

            if (companyProcess.SubProcesses != null && companyProcess.SubProcesses.Count > 0)
            {
                foreach (var process in companyProcess.SubProcesses)
                    await DeleteCompanyProcessRepository(process.Id);
            }

            _context.CompanyProcesses.Remove(companyProcess);
            await _context.SaveChangesAsync();
        }
    }
}
