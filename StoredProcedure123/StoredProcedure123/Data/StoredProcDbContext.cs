using Microsoft.EntityFrameworkCore;
using StoredProcedure123.Models;

namespace StoredProcedure123.Data
{
    public class StoredProcDbContext : DbContext
    {
        public StoredProcDbContext(DbContextOptions<StoredProcDbContext> options)
            : base(options) { }

        public DbSet<Employee> Employees { get; set; }
    }
}
