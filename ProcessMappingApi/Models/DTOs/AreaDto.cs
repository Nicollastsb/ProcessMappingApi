using AutoMapper.Configuration.Annotations;
using ProcessMappingApi.Models.Domain;

namespace ProcessMappingApi.Models.DTOs
{
    public class AreaDto
    {
        public Guid? Id { get; set; }
        public string Name { get; set; }
    }
}
