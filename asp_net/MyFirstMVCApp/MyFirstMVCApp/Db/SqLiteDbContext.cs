using Microsoft.EntityFrameworkCore;
using MyFirstMVCApp.Entities;

namespace MyFirstMVCApp.Db;

public class SqLiteDbContext : DbContext
{
    public DbSet<ManufacturerEntity> Manufacturers { get; set; }
    
    public DbSet<FormEntity> Forms { get; set; }
    public DbSet<CarEntity> Cars { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CarEntity>()
            .HasOne(c => c.Manufacturer)
            .WithMany()
            .HasForeignKey(c => c.ManufacturerId)
            .OnDelete(DeleteBehavior.Restrict);

        base.OnModelCreating(modelBuilder);
    }
    
    
    public SqLiteDbContext(DbContextOptions<SqLiteDbContext> options) : base(options)
    {
        
    }

public DbSet<MyFirstMVCApp.Entities.CarColorEntity> CarColorEntity { get; set; } = default!;
}