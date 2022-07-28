using API.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class DataDbContext : DbContext
    {
        public DataDbContext(DbContextOptions<DataDbContext> options):base(options)
        {

        }

        public DbSet<StoredProcedure> StoredProcedure { get; set; }
        public DbSet<Parameter> Parameter { get; set; }
    }
}
