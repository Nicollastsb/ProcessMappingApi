using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using ProcessMappingApi.Models.Domain;

namespace ProcessMappingApi.Data
{
    public class ApiDbContext : DbContext
    {
        public ApiDbContext(DbContextOptions options)
            : base(options)
        {
        }


        public DbSet<Area> Areas { get; set; }
        public DbSet<CompanyProcess> CompanyProcesses { get; set; }
    }
}
