using EMS.Models;
using Microsoft.EntityFrameworkCore;

namespace EMS.DataAccessLayer
{
    public class EMSDbContext : DbContext
    {
        public EMSDbContext(DbContextOptions<EMSDbContext> options) : base(options) { }
        public DbSet<Employee> Employees { get; set; }
    }
}
