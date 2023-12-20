using ProcessMappingApi.Models.Domain;

namespace ProcessMappingApi.Interfaces.IRepositories
{
    public interface ICompanyProcessRepository
    {
        Task<CompanyProcess> CreateCompanyProcessRepository(CompanyProcess companyProcess);
        Task<List<CompanyProcess>> GetAllMainCompanyProcessRepository();
        Task<CompanyProcess> GetByIdCompanyProcessRepository(Guid id);
        Task<CompanyProcess> UpdateCompanyProcessRepository(Guid id, CompanyProcess companyProcess);
        Task DeleteCompanyProcessRepository(Guid id);
    }
}
