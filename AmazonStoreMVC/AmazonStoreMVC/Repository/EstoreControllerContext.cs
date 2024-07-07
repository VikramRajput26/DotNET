using Microsoft.EntityFrameworkCore;
using AmazonStoreMVC.Models;
namespace AmazonStoreMVC.Repository;

public class EstoreControllerContext :DbContext
{
    public DbSet<Product> Products { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        string conString = @"server=localhost;port=3306;user=root; password=1234;database=flipkart";
        optionsBuilder.UseMySQL(conString);
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //Set Mapping of Table with POCO
        //Relational        instance: Table
        //Object Oriented   instance: POCO Class
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Title);
            entity.Property(e => e.Quantity);
            entity.Property(e => e.UnitPrice);
            entity.Property(e => e.ImageUrl);
        });
        modelBuilder.Entity<Product>().ToTable("products");
    }
}
