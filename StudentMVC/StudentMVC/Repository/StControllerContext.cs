using Microsoft.EntityFrameworkCore;
using StudentMVC.Models;

namespace StudentMVC.Repository
{
    public class StControllerContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string conString = @"server=localhost;port=3306;user=root; password=1234;database=studentmvc";
            optionsBuilder.UseMySQL(conString);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Student>(entity =>
            {
                entity.HasKey(e => e.id);
                entity.Property(e => e.name);
                entity.Property(e => e.address);
                entity.Property(e => e.email);
                entity.Property(e => e.fees);
                entity.Property(e => e.status);
                entity.Property(e => e.date);
                
            });
            modelBuilder.Entity<Student>().ToTable("student");
        }
    }
}
