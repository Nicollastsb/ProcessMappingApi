using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ProcessMappingApi.Models.Domain
{
    public class CompanyProcess
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public Guid? CompanyProcessId { get; set; }
        public int? Order { get; set; }
        public DateTime ModificationDate { get; set; }
        public Guid AreaId { get; set; }

        public ICollection<CompanyProcess>? SubProcesses { get; set; }
        public Area Area { get; set; }
    }
}
