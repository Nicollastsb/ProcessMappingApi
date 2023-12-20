using ProcessMappingApi.Models.Domain;
using ProcessMappingApi.Models.DTOs;

namespace ProcessMappingApi.Repositories.Interfaces
{
    public interface ICompanyProcessServices
    {
        Task<CompanyProcess> CreateCompanyProcessServices(CompanyProcessAreaDto addCompanyProcessAreaDto);
        Task<List<CompanyProcessAreaDto>> GetAllMainCompanyProcessServices();
        Task<CompanyProcessAreaDto> GetByIdCompanyProcessServices(Guid id);
        Task<CompanyProcessAreaDto> UpdateCompanyProcessServices(Guid id, CompanyProcessAreaDto companyProcessAreaDto);
        Task CheckSubProcess(CompanyProcessAreaDto companyProcessAreaDto);
        Task DeleteCompanyProcessServices(Guid id);
    }
}
