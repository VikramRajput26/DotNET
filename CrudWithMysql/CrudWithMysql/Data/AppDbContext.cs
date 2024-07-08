using Microsoft.EntityFrameworkCore;
using CrudWithMysql.Models;
namespace CrudWithMysql.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Employee> Employees { get; set; }
    }
}
