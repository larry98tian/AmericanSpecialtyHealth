using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.Data
{
    public class EmployeeDbContext :DbContext
    {
        public EmployeeDbContext(DbContextOptions options) : base(options) { }
        public DbSet<WorkerType> WorkerTypes { get; set; }
        public DbSet<Worker> Workers { get; set; }
    }
}
