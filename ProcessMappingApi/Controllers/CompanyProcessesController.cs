using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ProcessMappingApi.Data;
using ProcessMappingApi.Models.DTOs;
using ProcessMappingApi.Repositories.Interfaces;

namespace ProcessMappingApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CompanyProcessesController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ICompanyProcessServices _companyProcessServices;

        public CompanyProcessesController(IMapper mapper, ICompanyProcessServices companyProcessServices)
        {
            _mapper = mapper;
            _companyProcessServices = companyProcessServices;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllMainProcess()
        {
            return Ok(await _companyProcessServices.GetAllMainCompanyProcessServices());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {            
            var companyProcess = await _companyProcessServices.GetByIdCompanyProcessServices(id);

            if(companyProcess == null)
                return NotFound();

            return Ok(companyProcess);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CompanyProcessAreaDto addCompanyProcessAreaDto)
        {
            var process = await _companyProcessServices.CreateCompanyProcessServices(addCompanyProcessAreaDto);
            return CreatedAtAction(nameof(GetById), new { id = process.Id}, _mapper.Map<CompanyProcessAreaDto>(process));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] CompanyProcessAreaDto companyProcessAreaDto)
        {
            var process = await _companyProcessServices.UpdateCompanyProcessServices(id, companyProcessAreaDto);
            return Ok(process);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            await _companyProcessServices.DeleteCompanyProcessServices(id);
            return Ok();
        }
    }
}
