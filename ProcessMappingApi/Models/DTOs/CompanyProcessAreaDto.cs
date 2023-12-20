using AutoMapper.Configuration.Annotations;
using ProcessMappingApi.Models.Domain;

namespace ProcessMappingApi.Models.DTOs
{
    public class CompanyProcessAreaDto
    {
        public Guid? Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public Guid? CompanyProcessId { get; set; }
        public int? Order { get; set; }
        public Guid? AreaId { get; set; }
        public List<CompanyProcessAreaDto>? SubProcesses { get; set; }
        [SourceMember(nameof(Domain.Area.Name))]
        public string? AreaName { get; set; }
        public bool? Changed { get; set; }
        public bool? Deleted { get; set; }
    }
}
