using Microsoft.EntityFrameworkCore;
using MyFirstMVCApp.Entities;

namespace MyFirstMVCApp.Db;

public class SqLiteDbContext : DbContext
{
    public DbSet<ManufacturerEntity> Manufacturers { get; set; }
    
    public DbSet<FormEntity> Forms { get; set; }
    public DbSet<CarEntity> Cars { get; set; }
    
    
    public SqLiteDbContext(DbContextOptions<SqLiteDbContext> options) : base(options)
    {
    }

public DbSet<MyFirstMVCApp.Entities.CarColorEntity> CarColorEntity { get; set; } = default!;
}