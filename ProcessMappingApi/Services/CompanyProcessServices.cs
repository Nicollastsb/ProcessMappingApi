using AutoMapper;
using ProcessMappingApi.Interfaces.IRepositories;
using ProcessMappingApi.Models.Domain;
using ProcessMappingApi.Models.DTOs;
using ProcessMappingApi.Repositories.Interfaces;

namespace ProcessMappingApi.Services
{
    public class CompanyProcessServices : ICompanyProcessServices
    {
        private readonly IMapper _mapper;
        private readonly ICompanyProcessRepository _companyProcessRepository;
        public CompanyProcessServices(IMapper mapper, ICompanyProcessRepository companyProcessRepository)
        {
            _mapper = mapper;
            _companyProcessRepository = companyProcessRepository;
        }

        public async Task<CompanyProcess> CreateCompanyProcessServices(CompanyProcessAreaDto addCompanyProcessAreaDto)
        {
            var companyProcess = _mapper.Map<CompanyProcess>(addCompanyProcessAreaDto);
            var newCompanyProcess = await _companyProcessRepository.CreateCompanyProcessRepository(companyProcess);

            return newCompanyProcess;
        }

        public async Task<List<CompanyProcessAreaDto>> GetAllMainCompanyProcessServices()
        {            
            var listMainProcess = await _companyProcessRepository.GetAllMainCompanyProcessRepository();
            var companyProcess = _mapper.Map<List<CompanyProcessAreaDto>>(listMainProcess);
            
            return companyProcess;
        }

        public async Task<CompanyProcessAreaDto> GetByIdCompanyProcessServices(Guid id)
        {
            var companyProcess = await _companyProcessRepository.GetByIdCompanyProcessRepository(id);
            var companyProcessDto = _mapper.Map<CompanyProcessAreaDto>(companyProcess);

            return companyProcessDto;
        }

        public async Task<CompanyProcessAreaDto> UpdateCompanyProcessServices(Guid id, CompanyProcessAreaDto companyProcessAreaDto)
        {
            var companyProcess = _mapper.Map<CompanyProcess>(companyProcessAreaDto);

            if(companyProcessAreaDto.SubProcesses != null) 
                await CheckSubProcess(companyProcessAreaDto);

            var newCompanyProcess = await _companyProcessRepository.UpdateCompanyProcessRepository(id, companyProcess);
            var companyProcessDto = _mapper.Map<CompanyProcessAreaDto>(newCompanyProcess);

            return companyProcessDto;
        }

        public async Task CheckSubProcess(CompanyProcessAreaDto companyProcessAreaDto)
        {
            foreach(var subprocess in companyProcessAreaDto.SubProcesses.ToList())
            {
                subprocess.CompanyProcessId = companyProcessAreaDto.Id;
                subprocess.AreaId = companyProcessAreaDto.AreaId;
                if (subprocess.Id == null)
                    await CreateCompanyProcessServices(_mapper.Map<CompanyProcessAreaDto>(subprocess));
                else if (subprocess.Changed == true && subprocess.Id != null)
                    await UpdateCompanyProcessServices(subprocess.Id ?? Guid.Empty, subprocess);
            }
        }

        public async Task DeleteCompanyProcessServices(Guid id)
        {
            await _companyProcessRepository.DeleteCompanyProcessRepository(id);
        }
    }
}
