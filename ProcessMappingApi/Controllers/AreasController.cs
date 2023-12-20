using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ProcessMappingApi.Data;
using ProcessMappingApi.Models.DTOs;
using ProcessMappingApi.Repositories.Interfaces;
using ProcessMappingApi.Services;

namespace ProcessMappingApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AreasController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IAreaServices _areaServices;

        public AreasController(IMapper mapper, IAreaServices areaServices)
        {
            _mapper = mapper;
            _areaServices = areaServices;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAreas()
        {
            return Ok(await _areaServices.GetAllAreaServices());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {            
            var area = await _areaServices.GetByIdAreaServices(id);

            if(area == null)
                return NotFound();

            return Ok(area);
        }
    }
}
